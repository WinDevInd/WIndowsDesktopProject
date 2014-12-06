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
        static string configFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"FingerScan\fsDs.xml");
        static string dirPath = (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"FingerScan"));

        public static bool CreateDefaultDataSet()
        {
            try
            {

                if (!File.Exists(configFile))
                {
                    Directory.CreateDirectory(dirPath);
                    if (File.Exists("fsDs.config"))
                    {
                        File.Copy("fsDs.config", configFile);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool VarifyConfig(FSDataSet fsDataSet)
        {
            bool isVarified = false;
            try
            {
                if (fsDataSet != null && fsDataSet.Tables["Users"].Rows.Count > 0)
                {
                    isVarified = true;
                }
            }
            catch
            {
                isVarified = false;
            }
            return isVarified;
        }

        public static string GetConfigFilepath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"FingerScan\fsDs.xml");
        }
    }
}
