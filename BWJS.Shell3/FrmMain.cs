using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BWJS.Shell3
{
    public partial class FrmMain : Form
    {
        private string WebUrlProduct = "";
        private string WebUrlAd = "";
        public FrmMain()
        {
            InitializeComponent();
            splitContainer1.IsSplitterFixed = true;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            WebUrlAd= ConfigurationManager.AppSettings["WebUrlAd"];
            WebUrlProduct = ConfigurationManager.AppSettings["WebUrlProduct"];
            RegHelper.RegEdit();
            this.DesktopBounds = Screen.AllScreens[0].Bounds;
            this.TopMost = true;
            this.TopMost = false;
            webBrowserProduct.ScriptErrorsSuppressed = true; 
            webBrowserProduct.Navigate(WebUrlProduct);

            webBrowserAd.ScriptErrorsSuppressed = true;
            webBrowserAd.Navigate(WebUrlAd); 
        }

        private void picHomeBox_Click(object sender, EventArgs e)
        {
            webBrowserProduct.Navigate(WebUrlProduct);
        }
        private void picRefreshBox_Click(object sender, EventArgs e)
        {
            webBrowserProduct.Refresh();
        }

        private void picBackBox_Click(object sender, EventArgs e)
        {
            webBrowserProduct.GoBack();
        }  
    }
}
