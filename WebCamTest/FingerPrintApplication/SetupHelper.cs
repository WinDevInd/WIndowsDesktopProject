using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerPrintApplication
{
    class SetupHelper
    {
        public static void Init()
        {
            DateTime UpdatedTime = new DateTime(2015, 2, 9, 23, 59, 59);
            long curDateTime = 1420309800000;
            if (UpdatedTime < DateTime.Now)
            {
                System.Diagnostics.Debug.WriteLine("Invalid system date time - correct system date time");
                Application.Exit();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Synced with system date time");
                Application.Run(new Login());
            }

        }
    }
}
