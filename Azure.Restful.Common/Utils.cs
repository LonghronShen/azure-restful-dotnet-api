using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWACloud.Foundation
{
    public static class Utils
    {
        private static string appPath;

        public static string AppPath
        {
            get
            {
                if (string.IsNullOrEmpty(appPath))
                {
                    appPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                }
                return appPath;
            }
        }

        public static string GetIcon(string iconName)
        {
            return Path.Combine(AppPath, @"icons\" + iconName);
        }
    }
}
