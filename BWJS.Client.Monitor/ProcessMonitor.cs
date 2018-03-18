using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Client.Monitor
{
    public class ProcessMonitor
    {
        static IntPtr intPtr0 = new IntPtr(0);
        private static Process[] MyProcesses;
        /// <summary>
        /// 监控进程，发现没有直接启动
        /// </summary>
        /// <param name="processName"></param>
        /// <param name="file"></param>
        public static void MonitorProcess(string processName, string file)
        {
            MyProcesses = Process.GetProcessesByName(processName);//需要监控的程序名，该方法带出该程序所有用到的进程
            if (MyProcesses.Count() == 0)
                Run(file);
            else if (MyProcesses.Count() > 1 || MyProcesses.Count(o => o.MainWindowHandle != intPtr0) != 1)
            {
                foreach (Process myprocess in MyProcesses)
                {
                    myprocess.Kill();
                }
                Run(file);
            }
        }

        static void Run(string file)
        {
            if (File.Exists(file))
            {

                RunCmd2(file, "");



            }
        }


        /// <summary>
        /// 运行cmd命令
        /// 不显示命令窗口
        /// </summary>
        /// <param name="cmdExe">指定应用程序的完整路径</param>
        /// <param name="cmdStr">执行命令行参数</param>
        static bool RunCmd2(string cmdExe, string cmdStr)
        {
            bool result = false;
            try
            {
                using (Process myPro = new Process())
                {
                    myPro.StartInfo.FileName = "cmd.exe";
                    myPro.StartInfo.UseShellExecute = false;
                    myPro.StartInfo.RedirectStandardInput = true;
                    myPro.StartInfo.RedirectStandardOutput = true;
                    myPro.StartInfo.RedirectStandardError = true;
                    myPro.StartInfo.CreateNoWindow = true;
                    myPro.Start();
                    //如果调用程序路径中有空格时，cmd命令执行失败，可以用双引号括起来 ，在这里两个引号表示一个引号（转义）
                    string str = string.Format(@"""{0}"" {1} {2}", cmdExe, cmdStr, "&exit");

                    myPro.StandardInput.WriteLine(str);
                    myPro.StandardInput.AutoFlush = true;
                    myPro.WaitForExit();

                    result = true;
                }
            }
            catch
            {

            }
            return result;
        }
    }
}
