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
        

        public settingsPane()
        {
            InitializeComponent();

            if (Program.isInstalled == true)
            {
                button2.Enabled = false;
                button2.Text = "Already Installed";
            }

            if (MainWindow.searchEngine == "google")
            {
                if (MainWindow.showStartup == "true")
                    MessageBox.Show("radio engine set to google");

                radioButton1.Checked = true;
            }

            else if (MainWindow.searchEngine == "gizoogle")
            {
                if (MainWindow.showStartup == "true")
                    MessageBox.Show("radio engine set to gizoogle");
                radioButton2.Checked = true;
            }

            textBox1.Text = MainWindow.homepage;
        }

        public void bSetResolution_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldHomepage = MainWindow.homepage;

            MainWindow.homepage = textBox1.Text;
            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("home:" + oldHomepage, "home:" + textBox1.Text);
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);
                if (MainWindow.showStartup == "true") 
                    MessageBox.Show("Executed - Homepage: " + MainWindow.homepage);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.Install();
            button2.Enabled = false;
            button2.Text = "Installed!";
        }

        private void setEngineToGoogle(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string oldSearchEngine = MainWindow.searchEngine;

                MainWindow.searchEngine = "google";
                if (Program.isInstalled == true)
                {
                    if (MainWindow.showStartup == "true")
                        MessageBox.Show("Executed - google");

                    string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                    config = config.Replace("searchengine:" + oldSearchEngine, "searchengine:" + MainWindow.searchEngine);
                    File.WriteAllText(Program.binFilepath + @"\config.txt", config);
                }
            }
        }

        private void setEngineToGizoogle(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                string oldSearchEngine = MainWindow.searchEngine;

                MainWindow.searchEngine = "gizoogle";
                if (Program.isInstalled == true)
                {
                    if (MainWindow.showStartup == "true")
                        MessageBox.Show("Executed - gizoogle");

                    string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                    config = config.Replace("searchengine:" + oldSearchEngine, "searchengine:" + MainWindow.searchEngine);
                    File.WriteAllText(Program.binFilepath + @"\config.txt", config);
                }
            }
        }
    }
}
