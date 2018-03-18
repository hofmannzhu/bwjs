namespace BWJS.Shell4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.picKeyBoard = new System.Windows.Forms.PictureBox();
            this.picRefreshBox = new System.Windows.Forms.PictureBox();
            this.picHomeBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picKeyBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeBox)).BeginInit();
            this.SuspendLayout();
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
            // picKeyBoard
            // 
            this.picKeyBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picKeyBoard.Image = global::BWJS.Shell4.Properties.Resources.keyboard;
            this.picKeyBoard.Location = new System.Drawing.Point(254, 496);
            this.picKeyBoard.Name = "picKeyBoard";
            this.picKeyBoard.Size = new System.Drawing.Size(110, 50);
            this.picKeyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picKeyBoard.TabIndex = 3;
            this.picKeyBoard.TabStop = false;
            this.picKeyBoard.Click += new System.EventHandler(this.picKeyBoard_Click);
            // 
            // picRefreshBox
            // 
            this.picRefreshBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picRefreshBox.Image = ((System.Drawing.Image)(resources.GetObject("picRefreshBox.Image")));
            this.picRefreshBox.Location = new System.Drawing.Point(133, 496);
            this.picRefreshBox.Name = "picRefreshBox";
            this.picRefreshBox.Size = new System.Drawing.Size(110, 50);
            this.picRefreshBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRefreshBox.TabIndex = 2;
            this.picRefreshBox.TabStop = false;
            this.picRefreshBox.Click += new System.EventHandler(this.picRefreshBox_Click);
            // 
            // picHomeBox
            // 
            this.picHomeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picHomeBox.Image = ((System.Drawing.Image)(resources.GetObject("picHomeBox.Image")));
            this.picHomeBox.Location = new System.Drawing.Point(12, 496);
            this.picHomeBox.Name = "picHomeBox";
            this.picHomeBox.Size = new System.Drawing.Size(110, 50);
            this.picHomeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHomeBox.TabIndex = 1;
            this.picHomeBox.TabStop = false;
            this.picHomeBox.Click += new System.EventHandler(this.picHomeBox_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(420, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "回到桌面";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(659, 560);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picKeyBoard);
            this.Controls.Add(this.picRefreshBox);
            this.Controls.Add(this.picHomeBox);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picKeyBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picHomeBox;
        private System.Windows.Forms.PictureBox picRefreshBox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox picKeyBoard;
        private System.Windows.Forms.Button button1;
    }
}