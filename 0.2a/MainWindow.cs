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
using waiolib;

namespace Browser
{
    public partial class MainWindow : Form
    {
        #region Strings
        public static string localHistoryLocation = Program.historyFilePath;
        public static string historyEntry;
        public static string url;
        #endregion

        #region Integers
        public string versionNumber = "0.1.2";
        public int ResX;
        public int ResY;
        #endregion

        #region Objects
        waiolib.Math m1 = new waiolib.Math();
        // public StreamWriter historyWriter = new StreamWriter(Program.historyFilePath);
        Random _random = new Random();
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            //Checks if the program is installed by looking for installed file (empty).
            if (File.Exists(Program.binFilepath + @"\installed.dub") == true)
                label2.Text = "Yes";

            else if (Program.isInstalled == false)
                label2.Text = "No";

            else
                label2.Text = "---";
        }

        private void newTabToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string title = "Tab " + (TabControl.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            myTabPage.Height = TabControl.Height;
            myTabPage.Width = TabControl.Width;
            WebBrowser tabBrowser = new WebBrowser();
            tabBrowser.Width = myTabPage.Width;
            tabBrowser.Height = myTabPage.Height;
            TabControl.TabPages.Add(myTabPage);
            myTabPage.Show();
            myTabPage.Controls.Add(tabBrowser);
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl.TabPages.Remove(TabControl.SelectedTab);
        }

        public static void SetResolution()
        {
            settingsPane settingsPane = new settingsPane();



            settingsPane.ShowDialog();

            int ResX = settingsPane.ReturnResX();
            int ResY = settingsPane.ReturnResY();



            // For Debugging.
            MessageBox.Show("ResX: " + ResX + ", ResY: " + ResY + ".");
        }

        public void NavigateToPage()
        {
            // Sets 'url' to text in adress bar.
            url = textBox1.Text;

            // Holds converted adress (Spaces replaced with '+' to use with google).
            string searchTerm;

            // Sets Status label to 'Loading...'
            toolStripStatusLabel1.Text = "Loading...";

            // Diables Adress Bar and Navigate Controls.
            if (lockControlsWhileNavigatingToolStripMenuItem.Checked == true)
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
            }

            WebBrowser browserInFocus = (WebBrowser)TabControl.SelectedTab.Controls.Cast<Control>()
                                .FirstOrDefault(x => x is WebBrowser);

            // Checks if the inputted adress is a URL or a search term.
            if (url.Contains("www.") == true)
            {
                browserInFocus.Navigate(url);
            }
            else if (url.Contains("www.") == false)
            {
                searchTerm = url;

                // Replaces Spaces with '+'s
                searchTerm.Replace(" ", "+");
                textBox1.Text = searchTerm;
                browserInFocus.Navigate("https://www.google.co.uk/search?q=" + searchTerm);
            }

            // Save to history file. Not currently working.
            //historyEntry = url + "\r\n";
            //File.WriteAllText(@localHistoryLocation, historyEntry);

        }

        private void ReloadPage(string url)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

            ////if (nicholasCageToolStripMenuItem.Checked == true)
            ////{
            //    foreach (HtmlElement image in webBrowser1.Document.Images)
            //    {
            //        image.SetAttribute("src", "ncage/ncage1.jpg");
            //    }
            //}
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WebBrowser browserInFocus = (WebBrowser)TabControl.SelectedTab.Controls.Cast<Control>()
                                .FirstOrDefault(x => x is WebBrowser);

            browserInFocus.Navigate(url);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void aboutWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Freeflex Web Browser version " + versionNumber + ". " + "\n" + "Developed by Max Wash");
        }

        private void nicholasCageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void argumentOutOfBoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                throw new ArgumentOutOfRangeException(@"debugOutOfRange");
            }

            catch (SystemException dbz)
            {
                int result = ExceptionHandler.ExceptionReporter(dbz);
                if (result == 0)
                    this.Close();

                else if (result == 1)
                    ResetBrowser();

            }

        }

        private void divideByZeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                throw new DivideByZeroException(@"debugDivideByZero");
            }

            catch (DivideByZeroException dbz)
            {
                string errorMessage = "Am unhandled exception has occured: @@" + dbz + "@@Continue?";
                errorMessage = errorMessage.Replace("@", System.Environment.NewLine);

                if (MessageBox.Show(errorMessage, "DivideByZero Exception - Web Browser", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    Application.Exit();
                }
            }

        }

        private void setingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetResolution();
        }

        public void ResetBrowser()
        {
            textBox1.Text = null;
            webBrowser1.Navigate("about:blank");
        }

        private void unlockBrowserControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = true;
        }

        private void swapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not available in this version.", "Web Browser v1.5", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void crashWaiolibExceptionHandlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void crashWaiolibExceptionHandlerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            waiolib.Core.ExceptionHandlerCrash();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        
    }
}
