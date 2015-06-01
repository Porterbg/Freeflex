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
        private string oldHomepage = MainWindow.homepage;

        public settingsPane()
        {
            InitializeComponent();

            if (Program.isInstalled == true)
            {
                button2.Enabled = false;
                button2.Text = "Already Installed";
            }


            textBox1.Text = MainWindow.homepage;
        }

        public void bSetResolution_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.homepage = textBox1.Text;
            if (Program.isInstalled == true)
            {
                string config = File.ReadAllText(Program.binFilepath + @"\config.txt");
                config = config.Replace("home:" + oldHomepage, "home:" + textBox1.Text);
                File.WriteAllText(Program.binFilepath + @"\config.txt", config);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.Install();
            button2.Enabled = false;
            button2.Text = "Installed!";
        }
    }
}
