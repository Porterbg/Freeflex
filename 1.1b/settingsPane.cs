using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Browser
{
    public partial class settingsPane : Form
    {
        public static string oldSearchEngine = "";
        public static bool showDebug = false;
        public static bool showStatus = true;
        public static bool oldStatus;

        public settingsPane()
        {
            InitializeComponent();



            if (Program.isInstalled == true)
            {
                label2.Text = "Installed.";
                button2.Enabled = false;
                button2.Text = "Already Installed";
                
                if (MainWindow.configVersionNumber != MainWindow.versionNumber)
                {
                    label2.Text = "Out-of-Date Install.";
                    button2.Enabled = true;
                    button2.Text = "Re-Install";
                }
            }

            

            else
                label2.Text = "Not Installed.";

            if (MainWindow.searchEngine == "google")
                radioButton1.Checked = true;
            

            else if (MainWindow.searchEngine == "gizoogle")
                radioButton2.Checked = true;

            else if (MainWindow.searchEngine == "yahoo")
                radioButton3.Checked = true;

            else if (MainWindow.searchEngine == "bing")
                radioButton4.Checked = true;

            checkBox1.Checked = MainWindow.closeWhenTabsClosed;
            label4.Text = MainWindow.versionNumber;
            textBox1.Text = MainWindow.homepage;
            checkBox1.Checked = MainWindow.closeWhenTabsClosed;
            checkBox2.Checked = MainWindow.homeOnStartup;
            checkBox3.Checked = MainWindow.showDebugOptions;
            checkBox4.Checked = MainWindow.showStatus;
            
            
            if ((Program.isInstalled == true) && (MainWindow.configVersionNumber != MainWindow.versionNumber))
            {
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
            }


            if (Program.isInstalled == true)
            {
                label6.Text = MainWindow.configVersionNumber;
                if (MainWindow.configVersionNumber != MainWindow.versionNumber)
                {
                    label6.ForeColor = Color.Red;
                    label6.Font = new Font(label6.Font, FontStyle.Bold);
                }
            }
            else
                label6.Text = "---";
        }

        public void bSetResolution_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldHomepage = MainWindow.homepage;

            if (textBox1.Text.Contains("www.") == false)
                textBox1.Text = "www." + textBox1.Text;

            MainWindow.homepage = textBox1.Text;
            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("home: " + oldHomepage, "home: " + textBox1.Text);
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MainWindow.Install() == true)
            {
                button2.Enabled = false;
                button2.Text = "Installed!";
            }
        }

        private void setEngineToGoogle(object sender, EventArgs e)
        {
                oldSearchEngine = Program.form1.searchEngineAccess;

                Program.form1.searchEngineAccess = "google";
                if (Program.isInstalled == true)
                {
                    string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                    config = config.Replace("searchengine: " + oldSearchEngine, "searchengine: " + MainWindow.searchEngine);
                    File.WriteAllText(Program.binFilepath + @"\config.txt", config);
                }
        }

        private void setEngineToGizoogle(object sender, EventArgs e)
        {
                oldSearchEngine = Program.form1.searchEngineAccess;

                Program.form1.searchEngineAccess = "gizoogle";
                if (Program.isInstalled == true)
                {
                    string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                    config = config.Replace("searchengine: " + oldSearchEngine, "searchengine: " + MainWindow.searchEngine);
                    File.WriteAllText(Program.binFilepath + @"\config.txt", config);
                }
        }

        private void setEngineToYahoo(object sender, EventArgs e)
        {
            oldSearchEngine = Program.form1.searchEngineAccess;

            Program.form1.searchEngineAccess = "yahoo";
            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("searchengine: " + oldSearchEngine, "searchengine: " + MainWindow.searchEngine);
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);   
            }
        }

        private void setEngineToBing(object sender, EventArgs e)
        {
            oldSearchEngine = Program.form1.searchEngineAccess;

            Program.form1.searchEngineAccess = "bing";

            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("searchengine: " + oldSearchEngine, "searchengine: " + MainWindow.searchEngine);
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);
            }
            
        }

        private void TabCheckboxClick(object sender, EventArgs e)
        {
            bool oldTabSetting = MainWindow.closeWhenTabsClosed;

            MainWindow.closeWhenTabsClosed = checkBox1.Checked;

            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("exitwhentabsclosed: " + oldTabSetting.ToString(), "exitwhentabsclosed: " + MainWindow.closeWhenTabsClosed.ToString());
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);
            }

        }

        private void HomeCheckboxClick(object sender, EventArgs e)
        {
            bool oldHomeSetting = MainWindow.homeOnStartup;

            MainWindow.homeOnStartup = checkBox2.Checked;

            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("exitwhentabsclosed: " + oldHomeSetting.ToString(), "exitwhentabsclosed: " + MainWindow.homeOnStartup.ToString());
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);
            }
        }

        private void showDebugCheckBox(object sender, EventArgs e)
        {
            bool oldDebug = MainWindow.showDebugOptions;
            MainWindow.showDebugOptions = checkBox3.Checked;  

            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("showdebug: " + oldDebug, "showdebug: " + MainWindow.showDebugOptions);
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);
            }
        }

        private void StatusIndicatorCheckBoxClick(object sender, EventArgs e)
        {
            oldStatus = Program.form1.isStatusVisible;
            Program.form1.isStatusVisible = checkBox4.Checked;

            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("showstatus: " + oldStatus, "showstatus: " + MainWindow.showStatus);
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);
            }
        }
    }
}
