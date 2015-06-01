using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace Browser
{
    static class Program
    {
        public static bool isInstalled = false;
        public static string binFilepath = Application.StartupPath + @"\bin";
        public static string historyFilePath = Application.StartupPath + @"\bin\history.txt";
        public static MainWindow form1 = new MainWindow();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            form1.Size = new System.Drawing.Size(1280, 720);

            form1.KeyPreview = false;
            Application.Run(form1);          
        }
    }
}
