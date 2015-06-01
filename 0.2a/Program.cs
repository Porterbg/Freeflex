using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Browser
{
    static class Program
    {
        public static bool isInstalled = false;
        public static string WaiolibFilepath = Application.StartupPath + @"\waiolib.dll";
        public static string binFilepath = Application.StartupPath + @"\bin";
        public static string historyFilePath = Application.StartupPath + @"\bin\history.txt";
        

        private static void Install()
        {
                if (MessageBox.Show("Install program in current directory?", "Web Browser Installer", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Directory.CreateDirectory(binFilepath);
                    File.Create(historyFilePath);
                    File.Create(binFilepath + @"\installed.dub");
                    isInstalled = true;
                }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists(binFilepath + @"\installed.dub") == false | Directory.Exists(binFilepath) == false)
            {
                
                isInstalled = false;
                Install();
            }
          

            if (File.Exists(WaiolibFilepath) == false)
            {
                MessageBox.Show("waiolib.dll could not be found. Please ensure the file exists and restart the program.");
                Environment.Exit(1);
            }

            string s1 = "test";
            Application.EnableVisualStyles();
            
            MainWindow form1 = new MainWindow();

            form1.Size = new System.Drawing.Size(1280, 720);

            MainWindow ref1 = form1;

            
            Application.Run(form1);
            
        }

        static void FormAccess()
        {
            
        }
    }
}
