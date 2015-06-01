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
        #region Strings
        public static string homepage = "http://www.google.com";
        public string lastSite = "";
        public static string showStartup = "false";
        public static string searchEngine = "google";
        public static string versionNumber = "1.0b";
        public static string configVersionNumber = "";
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

        #region Other Variables
        public static bool closeWhenTabsClosed = false;
        public static bool homeOnStartup = true;
        public static bool showDebugOptions = false;
        public static bool showStatus = true;
        #endregion

        #region Get active controls
        public WebBrowser getBrowserInFocus()
        {
            return (WebBrowser)TabControl.SelectedTab.Controls.Cast<Control>()
                               .FirstOrDefault(x => x is WebBrowser);
        }

        public TabPage getTabInFocus()
        {
            return TabControl.SelectedTab;
        }
        #endregion
    }
}
