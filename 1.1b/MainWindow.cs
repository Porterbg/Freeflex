using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using System.Text.RegularExpressions;


namespace Browser
{
    public partial class MainWindow : Form
    {
        #region Properties

        public bool isStatusVisible
        {
            get { return showStatus; }
            set
            {
                showStatus = value;
                if (value == true && value != settingsPane.oldStatus)
                {
                    TabControl.Height = TabControl.Height - 22;
                    statusStrip1.Visible = true;
                }
                else if (value == false && value != settingsPane.oldStatus)
                {
                    TabControl.Height = TabControl.Height + 22;
                    statusStrip1.Visible = false;
                }
            }
        }
        public bool lockControlsWhenNavigating
        {
            get { return _lockControlsWhenNavigating; }
            set { _lockControlsWhenNavigating = value; }
        }
        public string searchEngineAccess
        {
            get { return searchEngine; }
            set
            {
                searchEngine = value;
                textBox2.ForeColor = SystemColors.GrayText;
                textBox2.Text = "Search " + char.ToUpper(searchEngine[0]) + searchEngine.Substring(1) + "...";
            }
        }
        #endregion
        public MainWindow()
        {
            Startup();

            // Creates all form controls. Do not reference any form controls before this point (especially in Startup() ).
            InitializeComponent();

            textBox2.Text = "Search " + char.ToUpper(searchEngine[0]) + searchEngine.Substring(1) + "...";

            WebBrowser browserInFocus = getBrowserInFocus();
            browserInFocus.ScriptErrorsSuppressed = true;

            if (homeOnStartup == true)
            {
                browserInFocus.Navigate(homepage);
                TabControl.SelectedTab.Text = "Home";
            }

            if (showStatus == false)
                TabControl.Height = TabControl.Height + 22;

            statusStrip1.Visible = showStatus;

            if ((Program.isInstalled == true) && (configVersionNumber != versionNumber))
            {
                warningLabel1.Visible = true;
                warningLabel1.Blinking = true;
            }
            else
                warningLabel1.Visible = false;   
        }

        public void newTab()
        {

        }

        private void newTabToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewTab();
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseTab();
        }

        public void OpenSettings()
        {
            settingsPane settingsPane = new settingsPane();
            settingsPane.ShowDialog();
            statusStrip1.Visible = MainWindow.showStatus; 
        }

        private void postConfigControls()
        {
            
        }

        private string getPageTitle()
        {
            WebBrowser activeBrowser = getBrowserInFocus();
            return activeBrowser.Document.Title;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }
        }

        

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                try
                {
                    toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
                }
                catch (SystemException ex)
                {

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void aboutWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Freeflex Web Browser version " + versionNumber + ". " + "\n" + "Developed by Max Wash");
        }
   
        private void setingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void unlockBrowserControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainWindow f1 = new MainWindow();
            f1.Show();
        }

        private void MainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.F5)
            {
                //button4_Click(null, null);
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            WebBrowser browserInFocus = getBrowserInFocus();
            textBox1.Text = homepage;
            textBox1.ForeColor = SystemColors.WindowText;
            browserInFocus.Navigate(homepage);
            TabControl.SelectedTab.Text = "Home";
        }

        private void ReloadPage(object sender, EventArgs e)
        {
            ReloadPage();
        }

        private void showCurrentSearchEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(searchEngine);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "Enter Address...";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Address...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Search " + char.ToUpper(searchEngine[0]) + searchEngine.Substring(1) + "...";
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

            if (textBox2.Text == "Search " + char.ToUpper(searchEngine[0]) + searchEngine.Substring(1) + "...")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.WindowText;
            }

            if (settingsPane.oldSearchEngine != "")
            {
                if (textBox2.Text == "Search " + char.ToUpper(settingsPane.oldSearchEngine[0]) + settingsPane.oldSearchEngine.Substring(1) + "...")
                {
                    textBox2.Text = "";
                    textBox2.ForeColor = SystemColors.WindowText;
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebBrowser activeBrowser = getBrowserInFocus();
            TabPage activeTab = getTabInFocus();

            if (TabControl.TabCount > 0)
            {
                button2.Enabled = activeBrowser.CanGoBack;
                button3.Enabled = activeBrowser.CanGoForward;
            }
        }

        private void searchBarKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                Search(textBox2.Text);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        
        
        
            
        

    }
}
