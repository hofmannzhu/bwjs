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
using System.Runtime.InteropServices;
using System.Timers;

namespace BWJS.Shell2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (Screen.AllScreens.Count() != 1)
            {
                this.DesktopBounds = Screen.AllScreens[1].Bounds;
            } 
            string WebUrl = ConfigurationManager.AppSettings["WebUrl"];
            RegHelper.RegEdit(); 
            webBrowser1.ScriptErrorsSuppressed = true; 
            webBrowser1.Navigate(WebUrl); 
        }
    }
}
