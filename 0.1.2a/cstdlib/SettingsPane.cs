using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace waiolib
{
    public partial class SettingsPane : Form
    {
        int ResX;
        int ResY;
        Size res1;

        public SettingsPane()
        {
            InitializeComponent();
        }

        public Size setResolution()
        {
            ResX = int.Parse(textBox1.Text);
            ResY = int.Parse(textBox2.Text);

            res1 = new Size(ResX, ResY);

            return res1;
        }
    }
}
