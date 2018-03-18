namespace BWJS.Shell1
{
    partial class FrmMain
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
            this.picBackBox = new System.Windows.Forms.PictureBox();
            this.picRefreshBox = new System.Windows.Forms.PictureBox();
            this.picHomeBox = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.picBackBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackBox
            // 
            this.picBackBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picBackBox.Image = global::BWJS.Shell1.Properties.Resources.back;
            this.picBackBox.Location = new System.Drawing.Point(194, 470);
            this.picBackBox.Name = "picBackBox";
            this.picBackBox.Size = new System.Drawing.Size(75, 47);
            this.picBackBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBackBox.TabIndex = 3;
            this.picBackBox.TabStop = false;
            this.picBackBox.Click += new System.EventHandler(this.picBackBox_Click);
            // 
            // picRefreshBox
            // 
            this.picRefreshBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picRefreshBox.Image = global::BWJS.Shell1.Properties.Resources.sx;
            this.picRefreshBox.Location = new System.Drawing.Point(103, 470);
            this.picRefreshBox.Name = "picRefreshBox";
            this.picRefreshBox.Size = new System.Drawing.Size(75, 47);
            this.picRefreshBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRefreshBox.TabIndex = 2;
            this.picRefreshBox.TabStop = false;
            this.picRefreshBox.Click += new System.EventHandler(this.picRefreshBox_Click);
            // 
            // picHomeBox
            // 
            this.picHomeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picHomeBox.Image = global::BWJS.Shell1.Properties.Resources.home;
            this.picHomeBox.Location = new System.Drawing.Point(12, 470);
            this.picHomeBox.Name = "picHomeBox";
            this.picHomeBox.Size = new System.Drawing.Size(75, 47);
            this.picHomeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHomeBox.TabIndex = 1;
            this.picHomeBox.TabStop = false;
            this.picHomeBox.Click += new System.EventHandler(this.picHomeBox_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(659, 560);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(659, 560);
            this.Controls.Add(this.picBackBox);
            this.Controls.Add(this.picRefreshBox);
            this.Controls.Add(this.picHomeBox);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBackBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picHomeBox;
        private System.Windows.Forms.PictureBox picRefreshBox;
        private System.Windows.Forms.PictureBox picBackBox;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}