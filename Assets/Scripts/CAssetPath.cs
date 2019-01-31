using UnityEngine;
using System.Collections;
using System;
using System.IO;
/********************************************************************
	created:	2017/02/14
	created:	14:2:2017   11:39
	filename: 	E:\frameWork\Project\XXCQ\XXCQ-Dev\Client\Assets\Plugins\Engine\Scripts\Asset\AssetPath.cs
	file path:	E:\frameWork\Project\XXCQ\XXCQ-Dev\Client\Assets\Plugins\Engine\Scripts\Asset
	file base:	AssetPath
	file ext:	cs
	author:		zero
	
	purpose:	路径管理类
*********************************************************************/
public class AssetPath
{
    /// <summary>
    /// 当前平台
    /// </summary>
#if UNITY_ANDROID
    public const string Platform = "Android";
#elif UNITY_IPHONE
    public const string Platform = "Ios";
#else
    public const string Platform = "Others";
#endif
    /// <summary>
    /// 游戏资源下载地址
    /// </summary>
    public const string BuildRemoteUri = "http://192.168.1.15:8060/XXCQ/";
    //public const string BuildRemoteUri = "http://192.168.1.59/BundleDownloadable/";
    /// <summary>
    /// 资源下载存放的地址
    /// </summary>
    public static string DownloadableOutputPath = string.Format("{0}/../../BundleDownloadable", Application.dataPath);
    /// <summary>
    /// 游戏打包默认的包名
    /// </summary>
    public static string BuildGamePackName = "GamePack";
    /// <summary>
    /// 游戏打包的存放路径
    /// </summary>
    public static string BuildGamePackOutputPath = Path.GetFullPath(string.Format("{0}/../BuildGamePack", Application.dataPath));
    /// <summary>
    /// 游戏资源打包后的存放文件名称
    /// </summary>
    public const string AssetBundlePath = "Bundles";
    /// <summary>
    /// 游戏资源打包后单个资源下载的存放路径
    /// </summary>
    public const string AssetBundleWebPath = "WebBundles";
    /// <summary>
    /// 游戏资源打包后原始资源存放文件名称
    /// </summary>
    public const string BuildBundlePath = "BuildBundles";
    /// <summary>
    /// 压缩包的后缀
    /// </summary>
    public const string CompressionFormat = ".zip";
    /// <summary>
    /// 场景目录
    /// </summary>
    public const string ScenePath = "Assets/Scenes";
    /// <summary>
    /// 需要打包的资源存放目录
    /// </summary>
    public const string ResourcesPath = "Assets/BundleDownloadable/AllPrefabs";
    /// <summary>
    /// 美术资源源文件目录
    /// </summary>
    public const string ResourcesArtResourcePath = "Assets/ArtResourceData";
    /// <summary>
    /// 美术资源源文件目录--角色文件
    /// </summary>
    public const string ResourcesArtResourceActorPath = "/Actor";
    /// <summary>
    /// 美术资源源文件目录--特效文件
    /// </summary>
    public const string ResourcesArtResourceEffectPath = "/Effect";
    /// <summary>
    /// 美术资源源文件目录--地形文件
    /// </summary>
    public const string ResourcesArtResourceMapsPath = "/Maps";
    /// <summary>
    /// 美术资源源文件目录--地形文件_Prefab
    /// </summary>
    public const string ResourcesArtResourceMapsPrefabPath = "/MapPrefabs";
    /// <summary>
    /// 美术资源源文件目录--地形文件_T4m
    /// </summary>
    public const string ResourcesArtResourceMapsT4MPath = "Assets/T4MOBJ/Terrains";
    /// <summary>
    /// 资源拷贝存放的文件名称
    /// </summary>
    public const string ResourcesBackupPath = "ResourcesBackup";
    /// <summary>
    /// 加载资源时的背景图片路径
    /// </summary>
    public const string ResourcesLoadingPromptPath = "Textures/LoadingPrompt/UI_Loading_";

    #region EditorAsset
    /// <summary>
    /// 资源打包后的存放路径
    /// </summary>
    public static string EditorBuildBundlePath { get { return string.Format("{0}/../../{1}/{2}", Application.dataPath, BuildBundlePath, Platform); } }
    /// <summary>
    /// 打包资源--资源拷贝存放的路径
    /// </summary>
    public static string EditorBundleInputPath { get { return string.Format("{0}/../{1}", Application.dataPath, ResourcesPath); } }
    /// <summary>
    /// 打包资源--美术资源源文件
    /// </summary>
    public static string EditorBundleArtResourceInputPath { get { return string.Format("{0}/../{1}", Application.dataPath, ResourcesArtResourcePath); } }
    /// <summary>
    /// 打包资源--美术资源源文件__角色文件
    /// </summary>
    public static string EditorBundleArtResourceActorInputPath { get { return string.Format("{0}/{1}/", EditorBundleArtResourceInputPath, ResourcesArtResourceActorPath); } }
    /// <summary>
    /// 打包资源--美术资源源文件__特效文件
    /// </summary>
    public static string EditorBundleArtResourceEffectInputPath { get { return string.Format("{0}/{1}/", EditorBundleArtResourceInputPath, ResourcesArtResourceEffectPath); } }
    /// <summary>
    /// 打包资源--美术资源源文件__地形文件
    /// </summary>
    public static string EditorBundleArtResourceMapsInputPath { get { return string.Format("{0}/{1}/", EditorBundleArtResourceInputPath, ResourcesArtResourceMapsPath); } }
    /// 打包资源--美术资源源文件__地形文件_Prefab
    /// </summary>
    public static string EditorBundleArtResourceMapsPrefabInputPath { get { return string.Format("{0}/{1}/", EditorBundleInputPath, ResourcesArtResourceMapsPrefabPath); } }
    /// 打包资源--美术资源源文件__地形文件_T4m
    /// </summary>
    public static string EditorBundleArtResourceMapsT4mInputPath { get { return string.Format("{0}/../{1}", Application.dataPath, ResourcesArtResourceMapsT4MPath); } }
    /// <summary>
    /// 本地测试打包后存放的路径
    /// </summary>
    public static string EditorBundleOutputPath { get { return string.Format("{0}/{1}", Application.streamingAssetsPath, Platform); } }
    /// <summary>
    /// 资源打包后需要下载的资源存放路径
    /// </summary>
   // public static string EditorDownloadableOutputPath { get { return string.Format("{0}/{1}/{2}", DownloadableOutputPath, Platform, Constants.BuildVersion); } }
    /// <summary>
    /// 资源打包后需要下载的资源存放路径
    /// </summary>
   // public static string EditorDownloadableOutputBundlesPath { get { return string.Format("{0}/{1}", EditorDownloadableOutputPath, AssetBundlePath); } }
    /// <summary>
    /// 资源打包后需要下载的资源存放路径
    /// </summary>
   // public static string EditorDownloadableOutputGrowPath { get { return string.Format("{0}/{1}/{2}", DownloadableOutputPath, Platform, Constants.GrowBuildVersion); } }
    /// <summary>
    /// 资源打包后需要下载的资源存放路径
    /// </summary>
  //  public static string EditorDownloadableOutputGrowBundlesPath { get { return string.Format("{0}/{1}", EditorDownloadableOutputGrowPath, AssetBundlePath); } }
    /// <summary>
    /// 资源打包后需要单个下载的资源存放路径
    /// </summary>
  //  public static string EditorWebDownloadOutputPath { get { return string.Format("{0}/{1}", EditorDownloadableOutputPath, AssetBundleWebPath); } }
    /// <summary>
    /// 资源打包后需要单个下载的资源存放路径
    /// </summary>
  //  public static string EditorWebDownloadGrowOutputPath { get { return string.Format("{0}/{1}", EditorDownloadableOutputGrowPath, AssetBundleWebPath); } }
    /// <summary>
    /// 游戏打包的存放路径
    /// </summary>
    public static string EditorBuildGamePackOutputPath { get { return BuildGamePackOutputPath; } }
    #endregion

    #region EditorData
    /// <summary>
    /// 游戏中表的存放路径
    /// </summary>
    public const string ExcelDataPath = "Configs/ExcelData/";
    /// <summary>
    /// 游戏中表的存放路径
    /// </summary>
    public static string EditorExcelDataInputPath { get { return string.Format("{0}/{1}", EditorBundleInputPath, ExcelDataPath); } }
    /// <summary>
    /// 游戏中场景信息的导出路径
    /// </summary>
    public const string SceneDataPath = "Configs/SceneData/";
    /// <summary>
    /// 游戏中场景信息的导出路径
    /// </summary>
    public static string EditorSceneDataInputPath { get { return string.Format("{0}/{1}", EditorBundleInputPath, SceneDataPath); } }

    /// <summary>
    /// 游戏中Lua转换txt的路径
    /// </summary>
    public const string LuaScriptPath = "uLua/Lua/";
    /// <summary>
    /// 游戏中Lua转换txt的路径
    /// </summary>
    public static string EditorLuaScriptInputPath { get { return string.Format("{0}/{1}", EditorBundleInputPath, LuaScriptPath); } }
    #endregion



    /// <summary>
    /// 压缩包的名称
    /// </summary>
    public static string CompressionFileName { get { return AssetBundlePath; } }
    /// <summary>
    /// 资源下载的存放路径
    /// </summary>
    public static string PersistentDataPath { get { return Path.Combine(Application.persistentDataPath, Platform); } }
    /// <summary>
    /// 资源下载的存放Url路径
    /// </summary>
    public static string PersistentDataPathUri { get { return new Uri(PersistentDataPath).AbsoluteUri; } }
    /// <summary>
    /// 游戏中的streamingAssetsPath路径
    /// </summary>
    public static string StreamingAssetsPath { get { return Path.Combine(Application.streamingAssetsPath, Platform); } }
    /// <summary>
    /// 游戏中的streamingAssetsPath的Url路径
    /// </summary>
    public static string StreamingAssetsPathUri { get { return new Uri(StreamingAssetsPath).AbsoluteUri; } }
    /// <summary>
    /// 游戏本地的版本配置文件路径
    /// </summary>
    public static string ManifestPathSAUri { get { return Path.Combine(StreamingAssetsPathUri, "manifest"); } }
    /// <summary>
    /// 本地下载最新的版本配置文件路径
    /// </summary>
    public static string ManifestPathDLC { get { return Path.Combine(PersistentDataPath, "newmanifest"); } }
    /// <summary>
    /// 最终版本配置文件配置文件路径
    /// </summary>
    public static string ManifestPathLKG { get { return Path.Combine(PersistentDataPath, "manifest"); } }

    /// <summary>
    /// 下载的资源存放目录
    /// </summary>
    public static string DownAssetsPath { get { return Path.Combine(PersistentDataPath, AssetBundlePath); } }
    /// <summary>
    /// Web资源存放目录
    /// </summary>
    public static string WebBundlePath{ get{return Path.Combine(PersistentDataPath, AssetBundleWebPath); }}
    /// <summary>
    /// 通过路径获取资源名称
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string GetAssetName(string path)
    {
        return Path.GetFileNameWithoutExtension(path).ToLower();
    }
    /// <summary>
    /// 通过路径转换资源名称
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string GetAssetBundleName(string path)
    {
        if (string.IsNullOrEmpty(path))
            return null;
        if (path.IndexOf(".") != -1)
            path = path.Substring(0, path.IndexOf("."));
        path = path.Replace(" ", "");
        var assetPath = Path.GetDirectoryName(path);
        assetPath = assetPath.Replace("\\", "_");
        assetPath = assetPath.Replace("/", "_");
        var assetName = Path.GetFileNameWithoutExtension(path);
        if (!string.IsNullOrEmpty(assetPath))
        {
            return string.Format("{0}_{1}", assetPath, assetName).ToLower();
        }
        else
        {
            if (!string.IsNullOrEmpty(assetName))
            {
                return assetName;
            }
        }
        return string.Empty;
    }
    /// <summary>
    /// 通过资源信息获取资源名称
    /// </summary>
    /// <param name="bundleInfo">路径</param>
    /// <returns></returns>
    //public static string GetAssetBundleName(BundleInfo bundleInfo)
    //{
    //    if (bundleInfo != null)
    //    {
    //        return bundleInfo.Name;
    //    }
    //    return string.Empty;
    //}

    /// <summary>
    /// 通过资源名称获取资源所在的加载路径
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string GetAssetBundlePath(string path)
    {
        var assetBundleName = GetAssetBundleName(path);
        var assetBundlePath = Path.Combine(PersistentDataPath, assetBundleName);
        if (File.Exists(assetBundlePath))
        {
            return assetBundlePath;
        }
#if UNITY_ANDROID&&!UNITY_EDITOR
        return Path.Combine(string.Format("{0}!assets/{1}/", Application.dataPath, Platform), assetBundleName);
#else
        return Path.Combine(StreamingAssetsPath, assetBundleName);
#endif
    }
    /// <summary>
    /// 通过文件信息获取资源所在的加载路径
    /// </summary>
    /// <param name="bundleInfo">路径</param>
    /// <returns></returns>
//    public static string GetAssetBundlePath(BundleInfo bundleInfo)
//    {
//        var assetBundleName = GetAssetBundleName(bundleInfo);
//        string assetBundlePath;
//        if(bundleInfo.DownloadMode == BundleDownloadMode.Web)
//            assetBundlePath = Path.Combine(WebBundlePath, bundleInfo.Hash);
//        else
//            assetBundlePath = Path.Combine(PersistentDataPath, assetBundleName);
//        if (File.Exists(assetBundlePath))
//        {
//            return assetBundlePath;
//        }
//#if UNITY_ANDROID&&!UNITY_EDITOR
//        return Path.Combine(string.Format("{0}!assets/{1}/", Application.dataPath, Platform), assetBundleName);
//#else
//        return Path.Combine(StreamingAssetsPath, assetBundleName);
//#endif
//    }
    /// <summary>
    /// 通过路径获取打包文件的路径
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string GetAllAssetBundlePath(string path)
    {
        var allAssetBundleName = GetAllAssetBundleName(path);
        var assetBundlePath = Path.Combine(PersistentDataPath, allAssetBundleName);
        if (File.Exists(assetBundlePath))
        {
            return assetBundlePath;
        }
#if UNITY_ANDROID&&!UNITY_EDITOR
        return Path.Combine(string.Format("{0}!assets/{1}/", Application.dataPath, Platform), allAssetBundleName);
#else
        return Path.Combine(StreamingAssetsPath, allAssetBundleName);
#endif
    }
    /// <summary>
    /// 通过路径获取打包所有文件的文件名称
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string GetAllAssetBundleName(string path)
    {
        var splits = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        if (splits != null && splits.Length > 0)
        {
            return splits[0].ToLower();
        }
        return path.ToLower();
    }

    /// <summary>
    /// 通过场景路径获取场景名字
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string GetSceneName(string path)
    {
        var sceneName = Path.GetFileNameWithoutExtension(path);
        return string.Format("scene_{0}", sceneName.ToLower());
    }
    /// <summary>
    /// 存储聊天文件路径
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string GetLocalFilePath(string fileName)
    {
        return Path.Combine(PersistentDataPath, fileName);
    }
    /// <summary>
    /// 获取Lua路径
    /// </summary>
    /// <param name="name">文件名称</param>
    /// <returns></returns>
    public static string GetLuaPath(string name)
    {
#if UNITY_EDITOR
       string path = Application.dataPath;    
 
#else
        string path = Application.streamingAssetsPath;  
#endif
       //string lowerName = name.ToLower();
        if (name.EndsWith(".lua"))
        {
            int index = name.LastIndexOf('.');
            name = name.Substring(0, index);
        }
        name = name.Replace('.', '/');
        name = path + "/lua/" + name + ".lua";
        Debug.Log("Path: "+ name);
        return name;
    }

}