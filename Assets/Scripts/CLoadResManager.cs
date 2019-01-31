namespace LuaInterface
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CLoadResManager : MonoBehaviour
    {

        public static T Load<T>(string path) where T : UnityEngine.Object, new()
        {
            return LoadAssetFromFile<T>(path);
        }
        private static T LoadAssetFromFile<T>(string path) where T : UnityEngine.Object, new()
        {
            T obj = null;
            string assetPath = path;
            if (assetPath.IndexOf(".") != -1)
            {
                int length = assetPath.IndexOf(".");
                assetPath = assetPath.Substring(0, length).Trim();
                path = string.Format("{0}{1}", assetPath, path.Replace(assetPath, "").Trim());
            }


            if (obj == null)
            {
                obj = Resources.Load<T>(assetPath);
            }
            if (obj == null)
            {
                //Logger.LogError(string.Format("Load {0} Is Error!!!!!!", assetPath));
            }
            return obj;
        }
    }
}
