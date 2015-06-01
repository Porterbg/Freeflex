using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSys = System;

namespace waiolib
{
    public class ExceptionHandler
    {
        public static int ExceptionReporter(SystemException e)
        {
            string ExceptionMessage = "An exception has occured: " + e + ".@Contine?@@ABORT to Close Program.@RETRY to reset Browser and continue.@IGNORE to ignore error and continue.";
            ExceptionMessage = ExceptionMessage.Replace("@", WinSys.Environment.NewLine);

            if (MessageBox.Show(ExceptionMessage, "Waiolib Error handler.", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) == DialogResult.Abort)
            {
                return 0;
            }
            else if (MessageBox.Show(ExceptionMessage, "Waiolib Error handler.", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error) == DialogResult.Retry)
            {
                return 1;
            }
            else
            {
                Core.ExceptionHandlerCrash();
                return 2;
            }
        }

    }
}
