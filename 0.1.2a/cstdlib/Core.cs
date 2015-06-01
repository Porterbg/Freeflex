using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;

namespace waiolib
{
    public class Core
    {
        public static string[] classes = {"Core", "ExceptionHandler", "MathLogic", "WebLogic", "System"};
        
        public static void ExceptionHandlerCrash()
        {
            try
            {
                throw new Exception("Waiolib Exception Handler Crash");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show("A fatal error has occured in Waiolib Exception Handler. The program will now close", "Waiolib Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(1);
            }
        }

        public int Random(int x, int y)
        {
            Random _random = new Random();
            int rnd = _random.Next(x, y);

            return rnd;
        }

        public static void Shutdown(string mode)
        {
            if (mode == "WMI")
            {
                ManagementBaseObject mboShutdown = null;
                ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
                mcWin32.Get();

                // Get Security Privilages
                mcWin32.Scope.Options.EnablePrivileges = true;
                ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");

                //Option Flags
                mboShutdownParams["Flags"] = "1";
                mboShutdownParams["Reserved"] = "0";
                foreach (ManagementObject manObj in mcWin32.GetInstances())
                {
                    mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
                }
            }
            else if (mode == "Core")
            {
                Process.Start("shutdown", "/s /t 0");
            }
        }
    }
}
