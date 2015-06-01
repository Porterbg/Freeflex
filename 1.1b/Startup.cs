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
        private void Startup()
        {

            // Checks if the install file exists and, if it does, mark the program as 'Installed'.
            if (File.Exists(Program.binFilepath + @"\installed.dub") == true)
            {
                Program.isInstalled = true;
                using (var reader = new StreamReader(Program.binFilepath + @"\config.txt"))
                {
                    // Variables to keep track of what information has been found in the config file. These will be set to true when the corresponding info has been found.
                    #region Config Variables
                    var hasHomepage = false;
                    var hasSearchEngine = false;
                    var hasTabClose = false;
                    var hasHomeOnStartup = false;
                    var hasShowDebug = false;
                    var hasVersion = false;
                    var hasShowStatus = false;
                    #endregion

                    #region Config Reader
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        #region Home
                        if (!hasHomepage)
                        {
                            if (line.StartsWith("home:"))
                            {
                                homepage = line.Replace("home: ", "");
                                hasHomepage = true;
                            }
                            else
                            {
                                homepage = "www.google.com";
                            }
                        }
                        #endregion

                        #region Search Engine
                        if (!hasSearchEngine)
                        {
                            if (line.StartsWith("searchengine:"))
                            {
                                searchEngine = line.Replace("searchengine: ", "");
                                hasSearchEngine = true;
                            }
                            else
                            {
                                searchEngine = "google";
                            }
                        }
                        #endregion

                        #region Tab Settings
                        if (!hasTabClose)
                        {
                            if (line.StartsWith("exitwhentabsclosed:"))
                            {
                                closeWhenTabsClosed = Convert.ToBoolean(line.Replace("exitwhentabsclosed: ", ""));
                                hasTabClose = true;
                            }
                            else
                            {
                                closeWhenTabsClosed = false;
                            }
                        }
                        #endregion

                        #region Home on Startup
                        if (!hasHomeOnStartup)
                        {
                            if (line.StartsWith("homeonstartup:"))
                            {
                                homeOnStartup = Convert.ToBoolean(line.Replace("homeonstartup: ", ""));
                                hasHomeOnStartup = true;
                            }
                            else
                            {
                                homeOnStartup = true;
                            }
                        }
                        #endregion

                        #region Debug Settings
                        if (!hasShowDebug)
                        {
                            if (line.StartsWith("showdebug:"))
                            {
                                showDebugOptions = Convert.ToBoolean(line.Replace("showdebug: ", ""));
                                hasShowDebug = true;
                            }
                            else
                            {
                                showDebugOptions = false;
                            }
                        }
                        #endregion

                        #region Config version
                        if (!hasVersion)
                        {
                            if (line.StartsWith("version:"))
                            {
                                configVersionNumber = line.Replace("version: ", "");
                                hasVersion = true;
                            }
                            else
                            {
                                hasVersion = false;
                            }
                        }
                        #endregion

                        #region Status Bar
                        if (!hasShowStatus)
                        {
                            if (line.StartsWith("showstatus:"))
                            {
                                showStatus = Convert.ToBoolean(line.Replace("showstatus: ", ""));
                                hasShowStatus = true;
                            }
                            else
                            {
                                hasShowStatus = false;
                            }
                        }
                        #endregion
                    }
                    #endregion

                    reader.Close();
                }
            }
            
            else
            {
                Program.isInstalled = false;
            }

            
        }

        public static bool Install()
        {
            if (MessageBox.Show("Install program in current directory? The program will need to restart.", "Freeflex Installer", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //if (Directory.Exists(Program.binFilepath))
                //    Directory.Delete(Program.binFilepath, true);

                Directory.CreateDirectory(Program.binFilepath);

                using (var r2 = File.Create(Program.binFilepath + @"\installed.dub")) { }
                using (var r2 = File.Create(Program.binFilepath + @"\config.txt")) { }
                using (StreamWriter sw1 = new StreamWriter(Program.binFilepath + @"\config.txt"))
                {
                    sw1.WriteLine("version: " + MainWindow.versionNumber + "\r\nhome: http://www.google.com\r\nsearchengine: google\r\nexitwhentabsclosed: False\r\nhomeonstartup: True\r\nshowdebug: False\r\nshowstatus: False");
                }


                Program.isInstalled = true;
                Application.Restart();
                return true;
            }
            else
                return false;
        }

    }
}
