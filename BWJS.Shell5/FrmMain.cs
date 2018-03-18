using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CefSharp.WinForms;
using CefSharp;

namespace BWJS.Shell5
{
    public partial class FrmMain : Form
    {
        private string WebUrlProduct = "";
        private string WebUrlAd = "";
        public FrmMain()
        {
            InitializeComponent();

            InitializeChromium();

            splitContainer1.IsSplitterFixed = true;
        }

        public ChromiumWebBrowser chromeBrowserAd;
        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            Cef.Initialize(settings);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadChromiumWebBrowser();
        }
        private void LoadChromiumWebBrowser()
        {
            WebUrlAd = ConfigurationManager.AppSettings["WebUrlAd"];
            WebUrlProduct = ConfigurationManager.AppSettings["WebUrlProduct"];
            //RegHelper.RegEdit();
            this.DesktopBounds = Screen.AllScreens[0].Bounds;
            this.TopMost = true;
            this.TopMost = false;
            chromeBrowserAd = new ChromiumWebBrowser(WebUrlAd);
            chromeBrowser = new ChromiumWebBrowser(WebUrlProduct);
            webBrowserAd.Controls.Add(chromeBrowserAd);
            webBrowserProduct.Controls.Add(chromeBrowser);
            chromeBrowserAd.Dock = DockStyle.Fill;
            chromeBrowser.Dock = DockStyle.Fill;
        }
        private void picHomeBox_Click(object sender, EventArgs e)
        {
            this.webBrowserProduct.Controls.Remove(chromeBrowser);
            LoadChromiumWebBrowser();
        }
        private void picRefreshBox_Click(object sender, EventArgs e)
        {
            chromeBrowser.Reload();
        }
    }
}
