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
using Browser;

namespace Browser
{
    public partial class MainWindow : Form
    {
        private void ReloadPage()
        {
            // Sets Status label to 'Loading...'
            toolStripStatusLabel1.Text = "Loading...";

            // Diables Adress Bar and Navigate Controls.
           
            WebBrowser browserInFocus = getBrowserInFocus();
            TabPage tabInFocusTitle = getTabInFocus();
            
            browserInFocus.Navigate(browserInFocus.Url.ToString());
        }

        public void NavigateToPage()
        {
            // Sets 'url' to text in adress bar.
            url = textBox1.Text;
            lastSite = textBox1.Text;

            // Sets Status label to 'Loading...'
            toolStripStatusLabel1.Text = "Loading...";

            // Diables Adress Bar and Navigate Controls.
            if (_lockControlsWhenNavigating == true)
            {
                button4.Enabled = false;
                homeButton.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }

            WebBrowser browserInFocus = getBrowserInFocus();
            TabPage tabInFocusTitle = getTabInFocus();

            // Checks if the inputted address is a URL or a search term.

            tabInFocusTitle.Text = url;
            browserInFocus.Navigate(url);
        }

        private void Search(string searchterm)
        {
            WebBrowser browserInFocus = getBrowserInFocus();
            TabPage tabInFocusTitle = getTabInFocus();

            // Diables Adress Bar and Navigate Controls.
            if (_lockControlsWhenNavigating == true)
            {
                button4.Enabled = false;
                homeButton.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }

            if (searchEngine == "google")
            {
                string title = "Google Search - " + searchterm;
                tabInFocusTitle.Text = title;
                // Replaces Spaces with '+'s
                searchterm.Replace(" ", "+");
                browserInFocus.Navigate("https://www.google.co.uk/search?q=" + searchterm);
            }

            else if (searchEngine == "gizoogle")
            {
                string title = "Gizoogle Search - " + searchterm;
                tabInFocusTitle.Text = title;
                // Repace Spaces with '+'s
                searchterm.Replace(" ", "+");
                browserInFocus.Navigate("http://www.gizoogle.net/index.php?search=" + searchterm + "&se=Gizoogle+Dis+Shiznit");
            }

            else if (searchEngine == "yahoo")
            {
                string title = "Yahoo Search - " + searchterm;
                tabInFocusTitle.Text = title;
                // Repace Spaces with '+'s
                searchterm.Replace(" ", "+");
                browserInFocus.Navigate("https://search.yahoo.com/search?p=" + searchterm);
            }

            else if (searchEngine == "bing")
            {
                string title = "Bing Search - " + searchterm;
                tabInFocusTitle.Text = title;
                // Repace Spaces with '+'s
                searchterm.Replace(" ", "+");
                browserInFocus.Navigate("https://www.bing.com/search?q=" + searchterm);
            }


        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (_lockControlsWhenNavigating == true)
            {
                button4.Enabled = true;
                homeButton.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            
            toolStripStatusLabel1.Text = "Page Loaded.";
            TabPage activeTab = getTabInFocus();
            WebBrowser activeBrowser = getBrowserInFocus();

            activeTab.Text = activeBrowser.Document.Title;

            // Check if the browser can go backwards or forwards.

            button2.Enabled = activeBrowser.CanGoBack;
            button3.Enabled = activeBrowser.CanGoForward;
        }
    }
    
}
