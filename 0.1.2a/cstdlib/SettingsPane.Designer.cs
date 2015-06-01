using WinSys = System;

namespace waiolib
{
    partial class SettingsPane
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private WinSys.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new WinSys.Windows.Forms.GroupBox();
            this.button1 = new WinSys.Windows.Forms.Button();
            this.textBox2 = new WinSys.Windows.Forms.TextBox();
            this.textBox1 = new WinSys.Windows.Forms.TextBox();
            this.label1 = new WinSys.Windows.Forms.Label();
            this.label2 = new WinSys.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new WinSys.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new WinSys.Drawing.Size(143, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resolution";
            // 
            // button1
            // 
            this.button1.Location = new WinSys.Drawing.Point(29, 69);
            this.button1.Name = "button1";
            this.button1.Size = new WinSys.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new WinSys.Drawing.Point(29, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new WinSys.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new WinSys.Drawing.Point(29, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new WinSys.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new WinSys.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new WinSys.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new WinSys.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new WinSys.Drawing.Size(17, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y:";
            // 
            // SettingsPane
            // 
            this.AutoScaleDimensions = new WinSys.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = WinSys.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new WinSys.Drawing.Size(175, 132);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = WinSys.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingsPane";
            this.Text = "SettingsPane";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WinSys.Windows.Forms.GroupBox groupBox1;
        private WinSys.Windows.Forms.Label label1;
        private WinSys.Windows.Forms.Button button1;
        private WinSys.Windows.Forms.TextBox textBox2;
        private WinSys.Windows.Forms.TextBox textBox1;
        private WinSys.Windows.Forms.Label label2;
    }
}