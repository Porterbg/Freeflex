namespace Browser
{
    partial class settingsPane
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbResY = new System.Windows.Forms.TextBox();
            this.tbResX = new System.Windows.Forms.TextBox();
            this.bSetResolution = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bSetResolution);
            this.panel1.Controls.Add(this.tbResX);
            this.panel1.Controls.Add(this.tbResY);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 113);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolution";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y: ";
            // 
            // tbResY
            // 
            this.tbResY.Location = new System.Drawing.Point(40, 49);
            this.tbResY.Name = "tbResY";
            this.tbResY.Size = new System.Drawing.Size(100, 20);
            this.tbResY.TabIndex = 3;
            // 
            // tbResX
            // 
            this.tbResX.Location = new System.Drawing.Point(40, 21);
            this.tbResX.Name = "tbResX";
            this.tbResX.Size = new System.Drawing.Size(100, 20);
            this.tbResX.TabIndex = 4;
            // 
            // bSetResolution
            // 
            this.bSetResolution.Location = new System.Drawing.Point(17, 75);
            this.bSetResolution.Name = "bSetResolution";
            this.bSetResolution.Size = new System.Drawing.Size(123, 23);
            this.bSetResolution.TabIndex = 5;
            this.bSetResolution.Text = "Set Resolution";
            this.bSetResolution.UseVisualStyleBackColor = true;
            this.bSetResolution.Click += new System.EventHandler(this.bSetResolution_Click);
            // 
            // settingsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 140);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "settingsPane";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbResX;
        private System.Windows.Forms.TextBox tbResY;
        private System.Windows.Forms.Button bSetResolution;
    }
}