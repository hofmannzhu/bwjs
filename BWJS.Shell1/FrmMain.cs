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

namespace BWJS.Shell1
{
    public partial class FrmMain : Form
    {
        private  string WebUrl = "";


        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            WebUrl = ConfigurationManager.AppSettings["WebUrl"];
            RegHelper.RegEdit();
            this.DesktopBounds = Screen.AllScreens[0].Bounds;
            this.TopMost = true;
            this.TopMost = false;
            webBrowser1.ScriptErrorsSuppressed = true;
           
            webBrowser1.Navigate(WebUrl);
           
        }

        

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
   
        private void picHomeBox_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(WebUrl);
        }

        private void picRefreshBox_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void picBackBox_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
    }
}
