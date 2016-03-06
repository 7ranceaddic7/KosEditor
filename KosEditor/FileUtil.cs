using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KosEditor
{
    public class FileUtil
    {
        public static string rscUrl = "file://" + KSPUtil.ApplicationRootPath.Replace("\\", "/") +
                         "/GameData/kOSEditor/resource/";

        public static string rscDir = KSPUtil.ApplicationRootPath.Replace("\\", "/") +
                                   "/GameData/kOSEditor/resource/";

        //Load from a local path (starting at resource/
        public static UnityEngine.Texture2D loadTexture(string path)
        {
            UnityEngine.WWW loader = new UnityEngine.WWW(rscUrl + path);
            return loader.texture;
        }

    }
}
