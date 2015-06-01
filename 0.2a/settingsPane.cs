using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class settingsPane : Form
    {
        public int ResXReturn;
        public int ResYReturn;

        public int ReturnResX() { ResXReturn = int.Parse(tbResX.Text); return ResXReturn; }

        public int ReturnResY() { ResYReturn = int.Parse(tbResY.Text); return ResYReturn; }

        public settingsPane()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void bSetResolution_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
