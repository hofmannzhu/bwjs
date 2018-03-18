namespace BWJS.Shell5
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.webBrowserAd = new System.Windows.Forms.WebBrowser();
            this.picRefreshBox = new System.Windows.Forms.PictureBox();
            this.picHomeBox = new System.Windows.Forms.PictureBox();
            this.webBrowserProduct = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.webBrowserAd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picRefreshBox);
            this.splitContainer1.Panel2.Controls.Add(this.picHomeBox);
            this.splitContainer1.Panel2.Controls.Add(this.webBrowserProduct);
            this.splitContainer1.Size = new System.Drawing.Size(800, 642);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 0;
            // 
            // webBrowserAd
            // 
            this.webBrowserAd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserAd.Location = new System.Drawing.Point(0, 0);
            this.webBrowserAd.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserAd.Name = "webBrowserAd";
            this.webBrowserAd.Size = new System.Drawing.Size(800, 224);
            this.webBrowserAd.TabIndex = 2;
            // 
            // picRefreshBox
            // 
            this.picRefreshBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picRefreshBox.Image = ((System.Drawing.Image)(resources.GetObject("picRefreshBox.Image")));
            this.picRefreshBox.Location = new System.Drawing.Point(128, 355);
            this.picRefreshBox.Name = "picRefreshBox";
            this.picRefreshBox.Size = new System.Drawing.Size(110, 50);
            this.picRefreshBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRefreshBox.TabIndex = 4;
            this.picRefreshBox.TabStop = false;
            this.picRefreshBox.Click += new System.EventHandler(this.picRefreshBox_Click);
            // 
            // picHomeBox
            // 
            this.picHomeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picHomeBox.Image = ((System.Drawing.Image)(resources.GetObject("picHomeBox.Image")));
            this.picHomeBox.Location = new System.Drawing.Point(12, 355);
            this.picHomeBox.Name = "picHomeBox";
            this.picHomeBox.Size = new System.Drawing.Size(110, 50);
            this.picHomeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHomeBox.TabIndex = 2;
            this.picHomeBox.TabStop = false;
            this.picHomeBox.Click += new System.EventHandler(this.picHomeBox_Click);
            // 
            // webBrowserProduct
            // 
            this.webBrowserProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserProduct.Location = new System.Drawing.Point(0, 0);
            this.webBrowserProduct.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserProduct.Name = "webBrowserProduct";
            this.webBrowserProduct.Size = new System.Drawing.Size(800, 414);
            this.webBrowserProduct.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 642);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRefreshBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHomeBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser webBrowserProduct;
        private System.Windows.Forms.PictureBox picHomeBox;
        private System.Windows.Forms.PictureBox picRefreshBox;
        private System.Windows.Forms.WebBrowser webBrowserAd;
    }
}