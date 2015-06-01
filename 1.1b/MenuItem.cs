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

namespace Browser
{
    public partial class MainWindow : Form
    {
        public void NewTab()
        {
            // Set up the title of New tab.
            string title = "Tab " + (TabControl.TabCount + 1).ToString();

            // Create the Tab Object with the pre-set title.
            TabPage newTab = new TabPage(title);

            // Set the width and height of the new tab to the size of the browser window.
            newTab.Height = TabControl.Height;
            newTab.Width = TabControl.Width - 7;

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
                textBox1.Text = "Enter Address...";
                textBox2.Enabled = true;
                textBox2.Text = "Search " + char.ToUpper(searchEngine[0]) + searchEngine.Substring(1) + "...";
                if (homeOnStartup == true)
                {
                    tabBrowser.Navigate(homepage);
                }
            }
        }

        public void CloseTab()
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
                    textBox2.Text = "";
                    textBox2.Enabled = false;

                }

                else if (closeWhenTabsClosed == true)
                    this.Close();

            }
        }

        public void About()
        {
            MessageBox.Show("Freeflex Web Browser version " + versionNumber + ". " + "\n" + "Developed by Max Wash");
        }

        public void Exit() { Program.form1.Close(); }
    }
}
