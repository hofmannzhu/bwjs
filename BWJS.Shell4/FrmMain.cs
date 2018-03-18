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
using CefSharp;
using CefSharp.WinForms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;
using Microsoft.VisualBasic;

namespace BWJS.Shell4
{
    public partial class FrmMain : Form
    {
        private string WebUrl = "";


        // 申明要使用的dll和api
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private System.Diagnostics.Process softKey;


        //64位转向
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);
        IntPtr oldWOW64State = new IntPtr();


        public FrmMain()
        {
            InitializeComponent();

            InitializeChromium();
        }

        public ChromiumWebBrowser chromeBrowser;

        /// <summary>
        /// 开启摄像头
        /// </summary>
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            Cef.Initialize(settings);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadChromiumWebBrowser();
        }

        private void picHomeBox_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Controls.Remove(chromeBrowser);
            LoadChromiumWebBrowser();
        }

        private void LoadChromiumWebBrowser()
        {
            WebUrl = ConfigurationManager.AppSettings["WebUrl"];
            this.DesktopBounds = Screen.AllScreens[0].Bounds;
            this.TopMost = true;
            this.TopMost = false;
            chromeBrowser = new ChromiumWebBrowser(WebUrl);
            webBrowser1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void picRefreshBox_Click(object sender, EventArgs e)
        {
            chromeBrowser.Reload();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void picKeyBoard_Click(object sender, EventArgs e)
        {
            Wow64DisableWow64FsRedirection(ref oldWOW64State); // 关闭64位（文件系统）的操作转向
            //System.Diagnostics.Process.Start("C:\\Windows\\System32\\osk.exe");//调出屏幕键盘
            //System.Diagnostics.Process.Start("C:\\Program Files\\Common Files\\microsoft shared\\ink\\TabTip.exe");//调出屏幕键盘
            //打开软键盘
            try
            {
                if (!System.IO.File.Exists(Environment.SystemDirectory + "\\osk.exe"))
                {
                    MessageBox.Show("软件盘可执行文件不存在！");
                    return;
                }


                softKey = System.Diagnostics.Process.Start("C:\\Windows\\System32\\osk.exe");
                //softKey = System.Diagnostics.Process.Start("C:\\Program Files\\Common Files\\microsoft shared\\ink\\TabTip.exe");//调出屏幕键盘
                // 上面的语句在打开软键盘后，系统还没用立刻把软键盘的窗口创建出来了。所以下面的代码用循环来查询窗口是否创建，只有创建了窗口
                // FindWindow才能找到窗口句柄，才可以移动窗口的位置和设置窗口的大小。这里是关键。
                IntPtr intptr = IntPtr.Zero;
                while (IntPtr.Zero == intptr)
                {
                    System.Threading.Thread.Sleep(100);
                    intptr = FindWindow(null, "屏幕键盘");
                }


                // 获取屏幕尺寸
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;


                // 设置软键盘的显示位置，底部居中
                int posX = (iActulaWidth - 1000) / 2;
                int posY = (iActulaHeight - 300);


                //设定键盘显示位置
                MoveWindow(intptr, posX, posY, 1000, 300, true);


                //设置软键盘到前端显示
                SetForegroundWindow(intptr);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\explorer.exe");

            //Type oleType = Type.GetTypeFromProgID("Shell.Application");
            //object oleObject = System.Activator.CreateInstance(oleType);
            //oleType.InvokeMember("ToggleDesktop", BindingFlags.InvokeMethod, null, oleObject, null);
        }
    }
}