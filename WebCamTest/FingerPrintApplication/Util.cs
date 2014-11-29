using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintApplication
{
    class Util
    {
        public static void CreadeDefaultDataSet()
        {
            string configFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"FingerScan\fsDs.xml");
            string dirPath = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"FingerScan"));
            if (!File.Exists(configFile))
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                File.Copy("fsDs.config", configFile);
            }
        }

        public static string GetConfigFilepath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"FingerScan\fsDs.xml");
        }
    }
}
