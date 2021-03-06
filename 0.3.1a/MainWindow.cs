﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using System.Text.RegularExpressions;


namespace Browser
{
    public partial class MainWindow : Form
    {
        #region Strings
        public static string homepage = "http://www.google.com";
        public string lastSite = "";
        public string versionNumber = "0.3.1a";
        public static string localHistoryLocation = Program.historyFilePath;
        public static string historyEntry;
        public static string url;
        #endregion

        #region Integers
        public int ResX;
        public int ResY;
        #endregion

        #region Objects
        
        // public StreamWriter historyWriter = new StreamWriter(Program.historyFilePath);
        Random _random = new Random();
        #endregion


        public WebBrowser getBrowserInFocus()
        {
            return (WebBrowser)TabControl.SelectedTab.Controls.Cast<Control>()
                               .FirstOrDefault(x => x is WebBrowser);
        }

        public TabPage getTabInFocus()
        {
            return TabControl.SelectedTab;
        }

        public MainWindow()
        {
            InitializeComponent();
            if (Program.isInstalled == true)
            {
                if (new FileInfo(Program.binFilepath + @"\config.txt").Length == 0)
                {
                    using (StreamWriter sw1 = new StreamWriter(Program.binFilepath + @"\config.txt"))
                    {
                        sw1.WriteLine("home:http://www.google.com");
                    }
                }
            }


            WebBrowser browserInFocus = getBrowserInFocus();

            //Checks if the program is installed by looking for install file.
            if (File.Exists(Program.binFilepath + @"\installed.dub") == true)
            {
                label2.Text = "Yes";
                using (var reader = new StreamReader(Program.binFilepath + @"\config.txt"))
                {
                    var hasHomepage = false;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!hasHomepage)
                        {
                            if (line.StartsWith("home:"))
                            {
                                homepage = line.Replace("home:", "");
                            }
                            else
                            {
                                homepage = "http://www.google.com";
                            }
                        }
                    }
                }
            }

            else if (Program.isInstalled == false)
            {
                label2.Text = "No";
                homepage = "http://www.google.com";
            }

            else
            {
                label2.Text = "---";
            }
            textBox1.Text = homepage;
            browserInFocus.Navigate(homepage);
            TabControl.SelectedTab.Text = "Home";
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

            // Set the width and height of thw new web browser to the size of the new tab page.
            tabBrowser.Width = newTab.Width;
            tabBrowser.Height = newTab.Height;

            // Add the new tab page to the main tab control.
            TabControl.TabPages.Add(newTab);

            // Add the web browser to the new tab.
            newTab.Controls.Add(tabBrowser);

            // Set anchors for the new web browser.
            tabBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            // Show the new tab.
            newTab.Show();
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
        }

        public static void SetHomepage()
        {
            settingsPane settingsPane = new settingsPane();

            settingsPane.ShowDialog();
        }

        public void NavigateToPage()
        {
            // Sets 'url' to text in adress bar.
            url = textBox1.Text;
            lastSite = textBox1.Text;

            // Holds converted address (Spaces replaced with '+' to use with google).
            string searchTerm;

            // Sets Status label to 'Loading...'
            toolStripStatusLabel1.Text = "Loading...";

            // Diables Adress Bar and Navigate Controls.
            if (lockControlsWhileNavigatingToolStripMenuItem.Checked == true)
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
            }

            WebBrowser browserInFocus = getBrowserInFocus();
            TabPage tabInFocusTitle = getTabInFocus();
            


            // Checks if the inputted address is a URL or a search term.
            if (url.Contains("www.") == true)
            {
                tabInFocusTitle.Text = url;
                browserInFocus.Navigate(url);
            }

            else if (url.Contains("www.") == false)
            {
                searchTerm = url;
                string title = "Google Search - " + searchTerm;
                tabInFocusTitle.Text = title;
                // Replaces Spaces with '+'s
                searchTerm.Replace(" ", "+");
                textBox1.Text = searchTerm;
                browserInFocus.Navigate("https://www.google.co.uk/search?q=" + searchTerm);
            }
        }

        private void ReloadPage()
        {
            // Sets Status label to 'Loading...'
            toolStripStatusLabel1.Text = "Loading...";

            // Diables Adress Bar and Navigate Controls.
            if (lockControlsWhileNavigatingToolStripMenuItem.Checked == true)
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
            }
            WebBrowser browserInFocus = getBrowserInFocus();
            TabPage tabInFocusTitle = getTabInFocus();

            browserInFocus.Navigate(lastSite);
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
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Page Loaded.";
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
            SetHomepage();
        }

        private void unlockBrowserControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = true;
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
    }
}
