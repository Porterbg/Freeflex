using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Browser
{
    public partial class ContextButton : Button
    {
        /// <summary>
        /// Represents a button that will open a Contex menu when clicked.
        /// </summary>


        ContextMenu buttonMenu = new ContextMenu();
        Point controlPos;
        MenuItem debug = new MenuItem("Debug");

        MenuItem newTab = new MenuItem("New Tab");
        MenuItem closeTab = new MenuItem("Close Current Tab");
        MenuItem settings = new MenuItem("Settings");
        MenuItem about = new MenuItem("About");
        MenuItem exit = new MenuItem("Exit");

        MenuItem lockControlsWhenNavigating = new MenuItem("Lock Controls When Navigating");
        
        public ContextButton()
        {
            InitializeComponent();

            buttonMenu.MenuItems.Add(newTab);
            buttonMenu.MenuItems.Add(closeTab);
            buttonMenu.MenuItems.Add("-");
            buttonMenu.MenuItems.Add(settings);
            buttonMenu.MenuItems.Add(debug);
            buttonMenu.MenuItems.Add(about);
            buttonMenu.MenuItems.Add("-");
            buttonMenu.MenuItems.Add(exit);
            debug.MenuItems.Add(lockControlsWhenNavigating);

            newTab.Click += new EventHandler(newTabMenuClick);
            closeTab.Click += new EventHandler(closeTabMenuClick);
            settings.Click += new EventHandler(settingsMenuClick);
            about.Click += new EventHandler(aboutMenuClick);
            exit.Click += new EventHandler(exitMenuClick);
            lockControlsWhenNavigating.Click += new EventHandler(lockControlsWhenNavigatingMenuClick);
            debug.Click += new EventHandler(debugMenuClick);
            this.Click += new EventHandler(onButtonClick);

            controlPos = this.Location;
            controlPos.Y = controlPos.Y + (this.Height - 2);
            controlPos.X = controlPos.X - 111;

        }

        private void onButtonClick(object sender, EventArgs e)
        {
            debug.Visible = MainWindow.showDebugOptions;
            buttonMenu.Show(this, controlPos);
        }

        private void lockControlsWhenNavigatingMenuClick(object sender, EventArgs e)
        {
            if (lockControlsWhenNavigating.Checked == false)
                lockControlsWhenNavigating.Checked = true;
            else if (lockControlsWhenNavigating.Checked == true)
                lockControlsWhenNavigating.Checked = false;

            Program.form1.lockControlsWhenNavigating = lockControlsWhenNavigating.Checked;
        }
        

        private void newTabMenuClick(object sender, EventArgs e)
        {
             Program.form1.NewTab();
        }

        private void closeTabMenuClick(object sender, EventArgs e)
        {
            Program.form1.CloseTab();
        }

        private void settingsMenuClick(object sender, EventArgs e)
        {
            Program.form1.OpenSettings();
        }

        private void debugMenuClick(object sender, EventArgs e)
        {
            
        }

        private void aboutMenuClick(object sender, EventArgs e)
        {
            Program.form1.About();
        }

        private void exitMenuClick(object sender, EventArgs e)
        {
            Program.form1.Exit();
        }


    }
}
