using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class WarningLabel : Label
    {
        System.Windows.Forms.Timer styleTick = new System.Windows.Forms.Timer();

        private bool _blinking = false;

        public bool Blinking
        {
            get { return _blinking; }
            set
            {
                _blinking = value;
                if (value == true)
                    StartBlinking();
                else if (value == false)
                    StopBlinking();
            }
        }
        

        public WarningLabel()
        {
            InitializeComponent();
            styleTick.Interval = 500;
            styleTick.Tick += new EventHandler(changeStyle);

            this.ForeColor = Color.Red;
            this.Visible = true;
            this.Font = new Font(this.Font, FontStyle.Bold);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.AllPaintingInWmPaint, true);
        }

        private void StartBlinking()
        {
            styleTick.Start();
        }

        private void StopBlinking()
        {
            styleTick.Stop();
        }

        private void changeStyle(object sender, EventArgs e)
        {
            if (this.Visible == true)
                this.Visible = false;

            else if (this.Visible == false)
                this.Visible = true;
        }

    }
}
