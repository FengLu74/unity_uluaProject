using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
/********************************************************************
	created:	2017/06/23
	created:	23:6:2017   18:00
	filename: 	E:\frameWork\Project\XXCQ\XXCQ-Dev\Client\Assets\Editor\CustomTools\Lua\LuaConversion.cs
	file path:	E:\frameWork\Project\XXCQ\XXCQ-Dev\Client\Assets\Editor\CustomTools\Lua
	file base:	LuaConversion
	file ext:	cs
	author:		zero
	
	purpose:	Lua转换工具
*********************************************************************/
public class LuaConversion
{
    /// <summary>
    /// 本地Lua存放路径
    /// </summary>
    private static string LocalLuaPath = string.Format("{0}/Lua/", Application.dataPath);
    /// <summary>
    /// 备份Lua存放路径
    /// </summary>
    private static string BackupLuaPath = string.Format("{0}/../../Lua/", Application.dataPath);
    /// <summary>
    /// 本地存放Lua转换Txt的路径
    /// </summary>
    private static string LocalLuaToTxtPath = AssetPath.EditorLuaScriptInputPath;

    /// <summary>
    /// 导出所有Lua文件
    /// </summary>
    public static void LuaAllToTxt()
    {
        var backupLuaDi = new DirectoryInfo(BackupLuaPath);
        if (backupLuaDi.Exists)
        {
            backupLuaDi.Delete(true);
        }
        var fileNames = Directory.GetFiles(LocalLuaPath, "*.lua", SearchOption.AllDirectories);
        foreach (var fileName in fileNames)
        {
            LuaFileBackup(fileName);
            LuaConversionTxt(fileName);
        }
        RefreshTxtFiles();
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
        //Logger.Log("导出所有Lua文件，完毕！！");
    }

    /// <summary>
    /// 导出差异Lua文件
    /// </summary>
    public static void LuaDifferenceToTxt()
    {
        var fileNames = new List<string>();
        FolderFileCompare(LocalLuaPath, BackupLuaPath, ref fileNames);
        foreach (var fileName in fileNames)
        {
            LuaFileBackup(fileName);
            LuaConversionTxt(fileName);
           // Logger.Log(string.Format("差异Lua文件：{0}", fileName));
        }
        var removefileNames = new List<string>();
        FolderFileCompare(BackupLuaPath, LocalLuaPath, ref removefileNames);
        foreach (var removefileName in removefileNames)
        {
            if (File.Exists(removefileName))
            {
                File.Delete(removefileName);
               // Logger.Log(string.Format("删除备份文件：{0}", removefileName));
            }
        }
        RefreshTxtFiles();
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
        //Logger.Log("导出差异Lua文件，完毕！！");
    }
    /// </summary>
    [MenuItem("Lua/生成所有Lua文件的归类Table", priority = 5)]
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
                //Logger.LogError(string.Format("Lua Utility path does not exist. {0}", UtilityLuaFilePath));
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
                Logger.LogError(string.Format("Lua Excel path does not exist. {0}", ExcelLuaFilePath));
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
                //Logger.LogError(string.Format("Lua Variable path does not exist. {0}", VariableLuaFilePath));
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
                //Logger.LogError(string.Format("Lua Manager path does not exist. {0}", ManagerLuaFilePath));
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
                //Logger.LogError(string.Format("Lua Protocol path does not exist. {0}", ProtocolLuaFilePath));
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
               // Logger.LogError(string.Format("Lua Panel path does not exist. {0}", PanelLuaFilePath));
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
    /// Lua文件备份
    /// </summary>
    /// <param name="luaDirectoryName">本地Lua文件路径</param>
    private static void LuaFileBackup(string luaDirectoryName)
    {
        luaDirectoryName = luaDirectoryName.Replace("\\", "/");
        var luaFileName = Path.GetFileName(luaDirectoryName);
        var luaFilePath = Path.GetDirectoryName(luaDirectoryName);
        luaFilePath = luaFilePath.Replace(LocalLuaPath, "");
        var luaFileBackupPath = Path.Combine(BackupLuaPath, luaFilePath);
        if (!Directory.Exists(luaFileBackupPath))
        {
            Directory.CreateDirectory(luaFileBackupPath);
        }
        var luaFileBackupName = Path.Combine(luaFileBackupPath, luaFileName);
        if (File.Exists(luaFileBackupName))
        {
            File.Delete(luaFileBackupName);
        }
        File.Copy(luaDirectoryName, luaFileBackupName);
    }

    /// <summary>
    /// Lua文件转换Txt文件
    /// </summary>
    /// <param name="luaDirectoryName"></param>
    private static void LuaConversionTxt(string luaDirectoryName)
    {
        luaDirectoryName = luaDirectoryName.Replace("\\", "/");
        var luaFileName = Path.GetFileName(luaDirectoryName);
        var txtFileName = luaFileName.Replace(".lua", ".txt");
        var luaFilePath = Path.GetDirectoryName(luaDirectoryName);
        luaFilePath = luaFilePath.Replace(LocalLuaPath, "");
        var txtFilePath = Path.Combine(LocalLuaToTxtPath, luaFilePath);
        if (!Directory.Exists(txtFilePath))
        {
            Directory.CreateDirectory(txtFilePath);
        }
        using (StreamWriter writer = new StreamWriter(Path.Combine(txtFilePath, txtFileName), false, System.Text.Encoding.UTF8))
        {
            using (FileStream stream = new FileStream(luaDirectoryName, FileMode.Open))
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

    /// <summary>
    /// 刷新Txt目录文件
    /// </summary>
    /// <param name="path1"></param>
    /// <param name="path2"></param>
    private static void RefreshTxtFiles()
    {
        var addFileNames = new List<string>();
        var removeFileNames = new List<string>();
        FolderFileNameCompare(LocalLuaPath, LocalLuaToTxtPath, ref addFileNames, ref removeFileNames);
        foreach (var fileName in addFileNames)
        {
            if (File.Exists(fileName))
            {
                LuaConversionTxt(fileName);
               // Logger.Log(string.Format("增加Txt文件：{0}", fileName));
            }
        }
        foreach (var fileName in removeFileNames)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                //Logger.Log(string.Format("删除Txt文件：{0}", fileName));
            }
        }
    }

    /// <summary>
    /// 对比两个路径下的文件获取差异文件路径
    /// </summary>
    /// <param name="path1"></param>
    /// <param name="path2"></param>
    /// <param name="list1Only"></param>
    private static void FolderFileCompare(string path1, string path2, ref List<string> list1Only)
    {
        List<FileInfo> list1 = GetFiles(path1, "*.lua");
        List<FileInfo> list2 = GetFiles(path2, "*.lua");
        FileCompare fileCompare = new FileCompare();
        var queryList1Only = (from file in list1 select file).Except(list2, fileCompare);
        foreach (var v in queryList1Only)
        {
            list1Only.Add(v.FullName);
        }
    }

    /// <summary>
    /// 对比两个路径下的文件获取差异文件路径
    /// </summary>
    /// <param name="path1"></param>
    /// <param name="path2"></param>
    /// <param name="list1Only"></param>
    private static void FolderFileNameCompare(string path1, string path2, ref List<string> list1Only, ref List<string> list2Only)
    {
        List<FileInfo> list1 = GetFiles(path1, "*.lua");
        List<FileInfo> list2 = GetFiles(path2, "*.txt");
        FileNameCompare fileCompare = new FileNameCompare();
        var queryList1Only = (from file in list1 select file).Except(list2, fileCompare);
        foreach (var v in queryList1Only)
        {
            list1Only.Add(v.FullName);
        }
        var queryList2Only = (from file in list2 select file).Except(list1, fileCompare);
        foreach (var v in queryList2Only)
        {
            list2Only.Add(v.FullName);
        }
    }

    /// <summary>
    /// 获取文件夹路径下的所有Lua文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static List<FileInfo> GetFiles(string path, string searchPattern)
    {
        var files = new List<FileInfo>();
        var fileNames = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
        foreach (var name in fileNames)
        {
            files.Add(new FileInfo(name));
        }
        return files;
    }

    /// <summary>
    /// 相同文件对比条件
    /// </summary>
    class FileCompare : IEqualityComparer<FileInfo>
    {
        public FileCompare() { }

        public bool Equals(FileInfo f1, FileInfo f2)
        {
            return (f1.Name == f2.Name && f1.Length == f2.Length);
        }

        public int GetHashCode(FileInfo fi)
        {
            var s = string.Format("{0}{1}", fi.Name, fi.Length);
            return s.GetHashCode();
        }
    }

    /// <summary>
    /// 相同文件名称对比条件
    /// </summary>
    class FileNameCompare : IEqualityComparer<FileInfo>
    {
        public FileNameCompare() { }

        public bool Equals(FileInfo f1, FileInfo f2)
        {
            string name1 = Path.GetFileNameWithoutExtension(f1.Name);
            string name2 = Path.GetFileNameWithoutExtension(f2.Name);
            return (name1 == name2 && name1.Length == name2.Length);
        }
        public int GetHashCode(FileInfo fi)
        {
            string name1 = Path.GetFileNameWithoutExtension(fi.Name);
            var s = string.Format("{0}{1}", name1, name1.Length);
            return s.GetHashCode();
        }
    }

}
