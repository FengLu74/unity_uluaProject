#pragma warning disable 219
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Security.Cryptography;

public class LuaEditorTool
{
    //[MenuItem("Tools/Lua/Gen Lua Wrap Files", priority = 1)]
    //static void GenerateLuaBind()
    //{
    //    LuaBinding.Binding();
    //}

    //[MenuItem("Tools/Lua/Gen U3d Wrap Files", priority = 1)]
    //static void GenerateU3dBind()
    //{
    //    LuaBinding.U3dBinding();
    //}

    //[MenuItem("Tools/Lua/Clear U3d Wrap Files", priority = 1)]
    //static void GenerateClearLuaBind()
    //{
    //    LuaBinding.ClearLuaBinder();
    //}

    [MenuItem("Tools/Lua/Generate AnimationList (Keep Debug Info)", priority = 2)]
    public static void GenerateAnimationListDebug()
    {
        GenerateAnimationList();
    }

    [MenuItem("Tools/导出/导出Excel表结构类", priority = 3)]
    public static void GenerateTableDefineDebug()
    {
        //GenerateTableDefine();
        //GenerateTableList();
        GenerateClass();
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
    }

    //[MenuItem("Tools/Lua/LuaJITCompile", priority = 4)]
    //public static void GenerateTableListDebug()
    //{
    //    GenerateTableDefineDebug();
    //    LuaJITCompile(true);
    //    AssetDatabase.Refresh();
    //    AssetDatabase.SaveAssets();
    //}

    /// <summary>
    /// 生成所有Lua文件的归类Table
    /// </summary>
    [MenuItem("Tools/Lua/生成所有Lua文件的归类Table", priority = 5)]
    public static void GenerateAllLuaFileNameTable()
    {
        string LuaFilePath = Application.dataPath + LuaScriptMgr.LuaFileFolderPath;
        string outputPath = Application.dataPath + LuaScriptMgr.LuaFileFolderPath + LuaScriptMgr.ConfigLuaFileFolderPath;
        string outputFileName = "AllLuaFileNameConfig.lua";
        int iFileNum = 0;
        File.Delete(Path.Combine(outputPath, outputFileName));
        using (StreamWriter writer = File.CreateText(Path.Combine(outputPath, outputFileName)))
        {
            writer.WriteLine("--此文件由工具自动生成，不需要手动修改");
            writer.WriteLine("module(\"AllLuaFileNameConfig\")");
            DirectoryInfo folder;

            //写入Lua/Utility文件夹下的所有文件到一个luaTable中
            writer.WriteLine("UtilityLuaFileTable = ");
            writer.WriteLine("{");
            string UtilityLuaFilePath = LuaFilePath + LuaScriptMgr.UtilityLuaFileFolderPath;
            if (!Directory.Exists(UtilityLuaFilePath))
            {
                Debug.LogError(string.Format("Lua Utility path does not exist. {0}", UtilityLuaFilePath));
                return;
            }
            folder = new DirectoryInfo(UtilityLuaFilePath);
            foreach (FileInfo file in folder.GetFiles("*.lua"))
            {
                iFileNum++;
                writer.WriteLine(string.Format("    \"{0}\",", LuaScriptMgr.UtilityLuaFileFolderPath + file.Name));
            }
			/*
            writer.WriteLine("}");
            writer.WriteLine();

            //写入Lua/Excel文件夹下的所有文件到一个luaTable中
            writer.WriteLine("ExcelLuaFileTable = ");
            writer.WriteLine("{");
            string ExcelLuaFilePath = LuaFilePath + LuaScriptMgr.ExcelTableFolderPath;
            if (!Directory.Exists(ExcelLuaFilePath))
            {
                Debug.LogError(string.Format("Lua Excel path does not exist. {0}", ExcelLuaFilePath));
                return;
            }
            folder = new DirectoryInfo(ExcelLuaFilePath);
            foreach (FileInfo file in folder.GetFiles("*.lua"))
            {
                iFileNum++;
                writer.WriteLine(string.Format("    \"{0}\",", LuaScriptMgr.ExcelTableFolderPath + file.Name));
            }
			*/
            writer.WriteLine("}");
            writer.WriteLine();

            //写入Lua/Variable文件夹下的所有文件到一个luaTable中
            writer.WriteLine("VariableLuaFileTable = ");
            writer.WriteLine("{");
            string VariableLuaFilePath = LuaFilePath + LuaScriptMgr.VariableLuaFileFolderPath;
            if (!Directory.Exists(VariableLuaFilePath))
            {
                Debug.LogError(string.Format("Lua Variable path does not exist. {0}", VariableLuaFilePath));
                return;
            }
            folder = new DirectoryInfo(VariableLuaFilePath);
            foreach (FileInfo file in folder.GetFiles("*.lua"))
            {
                iFileNum++;
                writer.WriteLine(string.Format("    \"{0}\",", LuaScriptMgr.VariableLuaFileFolderPath + file.Name));
            }
            writer.WriteLine("}");
            writer.WriteLine();

            //写入Lua/Manager文件夹下的所有文件到一个luaTable中
            writer.WriteLine("ManagerLuaFileTable = ");
            writer.WriteLine("{");
            string ManagerLuaFilePath = LuaFilePath + LuaScriptMgr.ManagerLuaFileFolderPath;
            if (!Directory.Exists(ManagerLuaFilePath))
            {
                Debug.LogError(string.Format("Lua Manager path does not exist. {0}", ManagerLuaFilePath));
                return;
            }
            folder = new DirectoryInfo(ManagerLuaFilePath);
            foreach (FileInfo file in folder.GetFiles("*.lua"))
            {
                iFileNum++;
                writer.WriteLine(string.Format("    \"{0}\",", LuaScriptMgr.ManagerLuaFileFolderPath + file.Name));
            }
            writer.WriteLine("}");
            writer.WriteLine();

            //写入Lua/Protocol文件夹下的所有文件到一个luaTable中
            writer.WriteLine("ProtocolLuaFileTable = ");
            writer.WriteLine("{");
            string ProtocolLuaFilePath = LuaFilePath + LuaScriptMgr.ProtocolLuaFileFolderPath;
            if (!Directory.Exists(ProtocolLuaFilePath))
            {
                Debug.LogError(string.Format("Lua Protocol path does not exist. {0}", ProtocolLuaFilePath));
                return;
            }
            folder = new DirectoryInfo(ProtocolLuaFilePath);
            foreach (FileInfo file in folder.GetFiles("*.lua"))
            {
                iFileNum++;
                writer.WriteLine(string.Format("    \"{0}\",", LuaScriptMgr.ProtocolLuaFileFolderPath + file.Name));
            }
            writer.WriteLine("}");
            writer.WriteLine();

            //写入Lua/Panel文件夹下的所有文件到一个luaTable中
            writer.WriteLine("PanelLuaFileTable = ");
            writer.WriteLine("{");
            string PanelLuaFilePath = LuaFilePath + LuaScriptMgr.PanelLuaFileFolderPath;
            if (!Directory.Exists(PanelLuaFilePath))
            {
                Debug.LogError(string.Format("Lua Panel path does not exist. {0}", PanelLuaFilePath));
                return;
            }
            folder = new DirectoryInfo(PanelLuaFilePath);
            foreach (FileInfo file in folder.GetFiles("*.lua"))
            {
                iFileNum++;
                writer.WriteLine(string.Format("    \"{0}\",", LuaScriptMgr.PanelLuaFileFolderPath + file.Name));
            }
            writer.WriteLine("}");
            writer.WriteLine();

            writer.WriteLine("FileNum = ");
            writer.WriteLine("{");
            writer.WriteLine(string.Format("    Size={0},", iFileNum));
            writer.WriteLine("}");
            writer.WriteLine();
            writer.Flush();
            writer.Close();
        }
        AssetDatabase.Refresh();
        LuaConversion.LuaAllToTxt();
    }

    /// <summary>
    /// 生成Animation文件
    /// </summary>
    private static void GenerateAnimationList()
    {
        string inputPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), string.Format("{0}/Others/Animation/", AssetPath.ResourcesPath));
        string outputPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "Assets/Lua/Configs/Animation/");
        string outputFile = "AnimationList.lua";

        if (!Directory.Exists(inputPath))
        {
            Debug.LogError(string.Format("Input path does not exist. {0}", inputPath));
            return;
        }

        if (!Directory.Exists(outputPath))
        {
            Debug.LogError(string.Format("Output path does not exist. {0}", outputPath));
            return;
        }

        string[] fileList = Directory.GetFiles(inputPath, "*.asset");

        File.Delete(Path.Combine(outputPath, outputFile));
        using (StreamWriter writer = File.CreateText(Path.Combine(outputPath, outputFile)))
        {
            writer.WriteLine("--此文件由工具生成，不要手动修改");
            writer.WriteLine("local AnimationList = ");
            writer.WriteLine("{");

            foreach (string filePath in fileList)
            {
                writer.WriteLine(string.Format("    \"{0}\",", Path.GetFileNameWithoutExtension(filePath)));
            }

            writer.WriteLine("}");
            writer.WriteLine("return AnimationList");
            writer.Flush();
            writer.Close();
        }
        AssetDatabase.Refresh();
    }


    /// <summary>
    /// 生成表结构文件
    /// </summary>
    private static void GenerateTableDefine()
    {
        string inputPath = "";//AssetPath.EditorExcelDataInputPath;
        string outputPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "Assets/Lua/Configs/DataTable/");
        Debug.Log(inputPath);
        Debug.Log(outputPath);
        if (!Directory.Exists(inputPath))
        {
            Debug.LogError(string.Format("Input path does not exist. {0}", inputPath));
            return;
        }

        if (!Directory.Exists(outputPath))
        {
            Debug.LogError(string.Format("Output path does not exist. {0}", inputPath));
            return;
        }

        string[] deleteFile = Directory.GetFiles(outputPath, "TableDefine*.lua");
        foreach (string fileName in deleteFile)
        {
            File.Delete(fileName);
        }

        string[] fileList = Directory.GetFiles(inputPath, "*.txt");
        foreach (string fileName in fileList)
        {
            using (StreamReader reader = File.OpenText(fileName))
            {
                int indexColumn = -1;
                string[] columnName = reader.ReadLine().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                string[] columnType = reader.ReadLine().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < columnName.Length; ++i)
                {
                    columnName[i] = columnName[i].Trim();
                    if (indexColumn == -1 && columnName[i].StartsWith("!"))
                    {
                        columnName[i] = columnName[i].Substring(1);
                        indexColumn = i;
                    }
                }
                for (int i = 0; i < columnType.Length; ++i)
                {
                    columnType[i] = columnType[i].Trim();
                }
                reader.Close();

                if (indexColumn == -1)
                {
                    Debug.LogError(string.Format("数据表没有索引列 {0}。", fileName));
                    continue;
                }
                if (columnName.Length != columnType.Length)
                {
                    Debug.LogError(string.Format("数据表列名和类型的数量不匹配 {0}。", fileName));
                    continue;
                }

                string outputFile = Path.Combine(outputPath, "TableDefine" + Path.GetFileName(fileName));
                outputFile = outputFile.Replace(".txt", ".lua");
                using (StreamWriter writer = File.CreateText(Path.Combine(outputPath, outputFile)))
                {
                    writer.WriteLine("--此文件由工具生成，不要手动修改");
                    writer.WriteLine("local Define = ");
                    writer.WriteLine("{");

                    writer.WriteLine(string.Format("    IndexColumn = {0},", indexColumn));
                    writer.WriteLine(string.Format("    ColumnNum = {0},", columnName.Length));
                    writer.WriteLine("    Columns =");
                    writer.WriteLine("    {");
                    for (int i = 0; i < columnName.Length; ++i)
                    {
                        writer.WriteLine(string.Format("        {{ Name = \"{0}\", Type = \"{1}\" }},", columnName[i], columnType[i]));
                    }
                    writer.WriteLine("    },");

                    writer.WriteLine("}");
                    writer.WriteLine("return Define");
                    writer.Flush();
                    writer.Close();
                }
            }
        }
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 生成总表文件
    /// </summary>
    private static void GenerateTableList()
    {
        string inputPath = "";//AssetPath.EditorExcelDataInputPath;
        string outputPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "Assets/Lua/Configs/DataTable/");
        string outputFile = "TableList.lua";

        if (!Directory.Exists(inputPath))
        {
            Debug.LogError(string.Format("Input path does not exist. {0}", inputPath));
            return;
        }

        if (!Directory.Exists(outputPath))
        {
            Debug.LogError(string.Format("Output path does not exist. {0}", inputPath));
            return;
        }

        string[] fileList = Directory.GetFiles(inputPath, "*.txt");

        File.Delete(Path.Combine(outputPath, outputFile));
        using (StreamWriter writer = File.CreateText(Path.Combine(outputPath, outputFile)))
        {
            writer.WriteLine("--此文件由工具生成，不要手动修改");
            writer.WriteLine("local TableList = ");
            writer.WriteLine("{");

            foreach (string filePath in fileList)
            {
                writer.WriteLine(string.Format("    \"{0}\",", Path.GetFileNameWithoutExtension(filePath)));
            }

            writer.WriteLine("}");
            writer.WriteLine("return TableList");
            writer.Flush();
            writer.Close();
        }
        AssetDatabase.Refresh();
    }







    /// <summary>
    /// 导出Lua脚本
    /// </summary>
    /// <param name="debug"></param>
    private static void LuaJITCompile(bool debug)
    {
        string _luaScriptTxtPath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "Assets/Lua/");
        string _luaScriptJITPath = "";// AssetPath.EditorLuaScriptInputPath;
        string line = string.Empty;

        if (Directory.Exists(_luaScriptJITPath))
        {
            Directory.Delete(_luaScriptJITPath, true);
        }
        Directory.CreateDirectory(_luaScriptJITPath);

        string[] fileList = Directory.GetFiles(_luaScriptTxtPath, "*.lua", SearchOption.AllDirectories);
        if (fileList.Length <= 0)
        {
            return;
        }

        foreach (string fileName in fileList)
        {
            string inputFile = fileName;
            string outputFile = inputFile.Replace(_luaScriptTxtPath, _luaScriptJITPath);
            outputFile = outputFile.Replace(".lua", ".txt");
            string outputDir = Path.GetDirectoryName(outputFile);
            if (outputDir == null)
            {
                continue;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                using (FileStream stream = new FileStream(inputFile, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        writer.Write(reader.ReadToEnd());
                        reader.Close();
                        reader.Dispose();
                    }
                    stream.Close();
                    stream.Dispose();
                }
                writer.Close();
                writer.Dispose();
            }
        }
    }

    /// <summary>
    /// 导出表的结构信息
    /// </summary>
    private static void GenerateClass()
    {
        string inputPath = "";// AssetPath.EditorExcelDataInputPath;
        string outputPath = string.Format("{0}/../../AssetsExcelData/", Application.dataPath); //Path.Combine(Path.GetDirectoryName(Application.dataPath), "AssetsExcelData/");

        if (!Directory.Exists(inputPath))
        {
            Directory.CreateDirectory(inputPath);
        }

        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        string[] deleteFile = Directory.GetFiles(outputPath, "*.txt");
        foreach (string fileName in deleteFile)
        {
            File.Delete(fileName);
        }

        string[] fileList = Directory.GetFiles(inputPath, "*.txt");
        foreach (string fileName in fileList)
        {
            string fileText = File.ReadAllText(fileName, UnicodeEncoding.GetEncoding("GB2312"));
            fileText = fileText.Replace("\n", "");
            using (StringReader reader = new StringReader(fileText))
            {
                int indexColumn = -1;
                string[] columnName = reader.ReadLine().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                string[] columnType = reader.ReadLine().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                string[] columnNotes = reader.ReadLine().Trim('"').Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < columnName.Length; ++i)
                {
                    columnName[i] = columnName[i].Trim();
                    if (indexColumn == -1 && columnName[i].StartsWith("!"))
                    {
                        columnName[i] = columnName[i].Substring(1);
                        indexColumn = i;
                    }
                }
                for (int i = 0; i < columnType.Length; ++i)
                {
                    columnType[i] = columnType[i].Trim();
                }
                for (int i = 0; i < columnNotes.Length; ++i)
                {
                    columnNotes[i] = columnNotes[i].Trim();
                }

                reader.Close();

                if (indexColumn == -1)
                {
                    Debug.LogError(string.Format("数据表没有索引列 {0}。", fileName));
                    continue;
                }
                if (columnName.Length != columnType.Length && !fileName.Contains("random_name") || columnName.Length != columnNotes.Length && !fileName.Contains("random_name"))
                {
                    Debug.LogError(string.Format("数据表列名、类型、列描述的数量不匹配fileName:: {0}:::columnName.Length:::,{1},:::columnType.Length:::{2},:::columnNotes.Length::::{3}。", fileName, columnName.Length, columnType.Length, columnNotes.Length));
                    continue;
                }

                string outputFile = Path.Combine(outputPath, Path.GetFileName(fileName));
                using (StreamWriter writer = File.CreateText(Path.Combine(outputPath, outputFile)))
                {
                    string formatFileName = Path.GetFileNameWithoutExtension(fileName);
                    formatFileName = formatFileName.Substring(0, 1).ToUpper() + formatFileName.Substring(1);
                    string m_className = "C" + formatFileName;
                    if (m_className.Contains("_"))
                    {
                        string[] m_classNameArray = m_className.Split('_');
                        m_className = m_classNameArray[0];
                        for (int i = 1; i < m_classNameArray.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(m_classNameArray[i].Trim()))
                            {
                                m_className += m_classNameArray[i].Substring(0, 1).ToUpper() + m_classNameArray[i].Substring(1);
                            }
                        }
                    }
                    else
                    {
                        m_className = m_className.Substring(0, 1).ToUpper() + m_className.Substring(1);
                    }
                    writer.WriteLine("public partial class " + m_className);
                    writer.WriteLine("{");

                    for (int i = 0; i < columnName.Length; ++i)
                    {
                        if (columnNotes.Length - 1 >= i)
                        {
                            writer.WriteLine("    /// <summary>");
                            writer.WriteLine("    /// {0}", columnNotes[i]);
                            writer.WriteLine("    /// </summary>");
                        }
                        string m_columnType = ParseColumnType(columnType[i]);
                        writer.WriteLine("    public {0} {1}", m_columnType, ChangeContent(columnName[i]));
                        writer.WriteLine("    { get; private set; }");
                    }
                    writer.WriteLine("}");
                    writer.Flush();
                    writer.Close();
                }
            }
        }
    }

    private static string ParseColumnType(string columnType)
    {
        switch (columnType)
        {
            case "bool":
            case "Bool":
                return "bool";
            case "int":
            case "Int":
                return "int";
            case "uint":
            case "UInt":
                return "uint";
            case "Short":
            case "short":
                return "short";
            case "UShort":
            case "ushort":
            case "Word":
            case "word":
                return "ushort";
            case "Byte":
            case "byte":
                return "byte";
            case "SByte":
            case "sbyte":
                return "sbyte";
            case "long":
            case "int64":
            case "Long":
                return "long";
            case "ulong":
            case "ULong":
                return "ulong";
            case "float":
            case "Float":
                return "float";
            case "string":
            case "String":
                return "string";
        }
        return string.Empty;
    }

    /// <summary>
    /// 转换字符转
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private static string ChangeContent(string text)
    {
        string[] strArray = text.Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
        string newText = string.Empty;
        if (strArray.Length > 0)
        {
            foreach (string str in strArray)
            {
                string frist = str.Substring(0, 1);
                string leave = str.Substring(1, str.Length - 1);
                int index;
                if (!int.TryParse(frist, out index))
                {
                    frist = frist.ToUpper();
                }
                newText += frist + leave;
            }
        }
        else
        {
            string frist = text.Substring(0, 1);
            string leave = text.Substring(1, text.Length - 1);
            frist = frist.ToUpper();
            newText += frist + leave;
        }
        return newText;
    }
}
