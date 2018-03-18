using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Threading;

namespace BWJS.Client.Monitor
{
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        static Dictionary<string, string> dic = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            Console.Title = "BLJS";
            IntPtr intptr = FindWindow("ConsoleWindowClass", "BLJS");
            if (intptr != IntPtr.Zero)
            {
                ShowWindow(intptr, 0);//隐藏这个窗口
            }

            ReadConfig();

            while (true)
            {
                try
                {
                    foreach (var item in dic)
                    {
                        ProcessMonitor.MonitorProcess(item.Key, item.Value);
                    }
                }
                finally
                {
                    Thread.Sleep(3000);
                }
            }

        }

        static void ReadConfig()
        {
            var settings = ConfigurationManager.AppSettings;
            foreach (var item in settings)
            {
                var key = item.ToString();
                dic.Add(key, settings.Get(key));
            }
        }
    }
}
