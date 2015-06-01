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

            debugToolStripMenuItem.Visible = showDebugOptions;
            statusStrip1.Visible = showStatus;

            if (showDebugOptions == false)
                debugToolStripMenuItem.Visible = false;

            if ((Program.isInstalled == true) && (configVersionNumber != versionNumber))
            {
                warningLabel1.Visible = true;
                warningLabel1.Blinking = true;
            }
            else
                warningLabel1.Visible = false;   
        }

        private void newTabToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Set up the title of New tab.
            string title = "Tab " + (TabControl.TabCount + 1).ToString();

            // Create the Tab Object with the pre-set title.
            TabPage newTab = new TabPage(title);

            // Set the width and height of the new tab to the size of the browser window.
            newTab.Height = TabControl.Height;
            newTab.Width = TabControl.Width - 8;

            // Create a new Web Browser control.
            WebBrowser tabBrowser = new WebBrowser();

            // Add DocumentCompleted event to the new browser.
            tabBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);

            // Set the width and height of thw new web browser to the size of the new tab page.
            tabBrowser.Width = newTab.Width;
            tabBrowser.Height = newTab.Height;

            // Add the new tab page to the main tab control.
            TabControl.TabPages.Add(newTab);

            // Add the web browser to the new tab.
            newTab.Controls.Add(tabBrowser);

            // Set the web browser to suppress all script errors.
            tabBrowser.ScriptErrorsSuppressed = true;

            // Set anchors for the new web browser.
            tabBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // Show the new tab.
            TabControl.SelectedTab = newTab;

            if (TabControl.TabCount > 0)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                homeButton.Enabled = true;
                textBox1.Enabled = true;
                if (homeOnStartup == true)
                {
                    textBox1.Text = homepage;
                    NavigateToPage();
                }
            }
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);

            if (TabControl.TabCount < 1)
            {
                if (closeWhenTabsClosed == false)
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    homeButton.Enabled = false;
                    textBox1.Enabled = false;
                    textBox1.Text = "";
                }

                else if (closeWhenTabsClosed == true)
                    this.Close();

            }
        }

        private void OpenSettings()
        {
            settingsPane settingsPane = new settingsPane();
            settingsPane.ShowDialog();
            debugToolStripMenuItem.Visible = MainWindow.showDebugOptions;
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
                button1_Click(null, null);
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Page Loaded.";
            TabPage activeTab = getTabInFocus();
            WebBrowser activeBrowser = getBrowserInFocus();

            activeTab.Text = activeBrowser.Document.Title;
            
            // Check if the browser can go backwards or forwards.

            button2.Enabled = activeBrowser.CanGoBack;
            button3.Enabled = activeBrowser.CanGoForward;
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
                button4_Click(null, null);
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            WebBrowser browserInFocus = getBrowserInFocus();
            textBox1.Text = homepage;
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
            if (activeTab.Contains(getBrowserInFocus()) == true)
            //    textBox1.Text = activeBrowser.Url.ToString();

            button2.Enabled = activeBrowser.CanGoBack;
            button3.Enabled = activeBrowser.CanGoForward;
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

        
        
            
        

    }
}
