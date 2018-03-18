using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Reflection;

namespace UtilityHelper
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class Log
    {
        #region 记录日志到文件

        private static Mutex m_Mutex = new Mutex();
        /// <summary>
        /// 日志文件记录
        /// </summary>
        /// <param name="sMessage">内容</param>
        static public void WriteLog(string sMessage)
        {
            try
            {
                m_Mutex.WaitOne();
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                #region 获取父类+方法名
                /*
                //取得当前方法命名空间
                clsString += "命名空间名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "<br />";
                //取得当前方法类全名 包括命名空间
                clsString += "命名空间+类名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "<br />";
                //获得当前类名
                clsString += "类名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "<br />";
                //取得当前方法名
                clsString += "方法名:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "<br />";
                clsString += "<br />";
                StackTrace ss = new StackTrace(true);
                MethodBase mb = ss.GetFrame(1).GetMethod();
                //取得父方法命名空间
                clsString += mb.DeclaringType.Namespace + "<br />";
                //取得父方法类名
                clsString += mb.DeclaringType.Name + "<br />";
                //取得父方法类全名
                clsString += mb.DeclaringType.FullName + "<br />";
                //取得父方法名
                clsString += mb.Name + "<br />";
                */

                string clsString = string.Empty;
                //clsString += System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName+ " ";
                StackTrace st = new StackTrace(true);
                MethodBase mb = st.GetFrame(1).GetMethod();
                clsString += mb.Name + " ";
                clsString += mb.DeclaringType.FullName;
                sMessage = clsString + sMessage;
                #endregion

                string sPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (sPath.Substring(sPath.Length - 1, 1) != "\\")
                {
                    sPath += "\\";
                }
                if (!Directory.Exists(sPath + "log"))
                {
                    Directory.CreateDirectory(sPath + "log");
                }

                string sFileName = sPath + "log\\" + "Com" + System.DateTime.Today.ToString("yyyyMMdd") + ".log";
                string sTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                System.IO.TextWriter oWrite = System.IO.File.AppendText(sFileName);
                //oWrite.WriteLine(sMessage);
                oWrite.WriteLine(sTime + ": " + sMessage);
                oWrite.Close();
            }
            catch (Exception e)
            {
                EventLog myLog = new EventLog();
                myLog.Source = "Com";
                myLog.WriteEntry("Err:" + sMessage + "\t" + e.ToString());
            }
            finally
            {
                m_Mutex.ReleaseMutex();
            }
        }

        /// <summary>
        /// 日志文件记录
        /// </summary>
        /// <param name="sMessage">内容</param>
        static public void WriteLog(string sMessage, string filePre, string split)
        {
            try
            {
                m_Mutex.WaitOne();
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                string sPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (sPath.Substring(sPath.Length - 1, 1) != "\\")
                {
                    sPath += "\\";
                }
                if (!Directory.Exists(sPath + "\\log"))
                {
                    Directory.CreateDirectory(sPath + "\\log");
                }

                string sFileName = sPath + "\\log\\" + ((!string.IsNullOrEmpty(filePre)) ? (filePre) : ("Com")) + System.DateTime.Today.ToString("yyyyMMdd") + ".log";
                System.IO.TextWriter oWrite = System.IO.File.AppendText(sFileName);
                oWrite.WriteLine(((!string.IsNullOrEmpty(split)) ? (split) : (",")) + sMessage);
                oWrite.Close();
            }
            catch (Exception e)
            {
                EventLog myLog = new EventLog();
                myLog.Source = ((!string.IsNullOrEmpty(filePre)) ? (filePre) : ("Com"));
                myLog.WriteEntry("Err:" + sMessage + "\t" + e.ToString());
            }
            finally
            {
                m_Mutex.ReleaseMutex();
            }
        }
        #endregion

        #region 生成html文件
        /// <summary>
        /// 生成html文件
        /// </summary>
        static public void WriteToHtml(string content, bool append, ref string msg, ref string fileName, ref string filePath)
        {
            try
            {
                string folder = DateTime.Now.ToString("yyyyMM");
                string sPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (sPath.Substring(sPath.Length - 1, 1) != "\\")
                {
                    sPath += "\\";
                }
                string dir = sPath + "Temp\\Report\\" + folder + "\\";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string tempName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".html";
                string sfile = dir + tempName;
                fileName = tempName;
                filePath = "/Temp/Report/" + folder + "/" + tempName;

                if (!File.Exists(sfile))
                {
                    File.Create(sfile).Close();
                }
                StreamWriter Sw = new StreamWriter(sfile, append, System.Text.Encoding.UTF8);

                Sw.WriteLine(content);
                Sw.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }
        #endregion
    }
}
