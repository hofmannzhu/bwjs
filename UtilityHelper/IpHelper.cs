using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace UtilityHelper
{
    public class IpHelper : IDisposable
    {
        #region 获取本机信息
        /// <summary>
        /// 测试获取本机信息
        /// </summary>
        /// <returns></returns>
        static public string Test()
        {
            string result = string.Empty;
            /*
            RegistryKey folders;
            folders = OpenRegistryPath(Registry.LocalMachine, @"/software/microsoft/windows/currentversion/explorer/shell folders");
            // Windows用户桌面路径
            string desktopPath = folders.GetValue("Common Desktop").ToString();
            // Windows用户字体目录路径
            string fontsPath = folders.GetValue("Fonts").ToString();
            // Windows用户网络邻居路径
            string nethoodPath = folders.GetValue("Nethood").ToString();
            // Windows用户我的文档路径
            string personalPath = folders.GetValue("Personal").ToString();
            // Windows用户开始菜单程序路径
            string programsPath = folders.GetValue("Programs").ToString();
            // Windows用户存放用户最近访问文档快捷方式的目录路径
            string recentPath = folders.GetValue("Recent").ToString();
            // Windows用户发送到目录路径
            string sendtoPath = folders.GetValue("Sendto").ToString();
            // Windows用户开始菜单目录路径
            string startmenuPath = folders.GetValue("Startmenu").ToString();
            // Windows用户开始菜单启动项目录路径
            string startupPath = folders.GetValue("Startup").ToString();
            // Windows用户收藏夹目录路径
            string favoritesPath = folders.GetValue("Favorites").ToString();
            // Windows用户网页历史目录路径
            string historyPath = folders.GetValue("History").ToString();
            // Windows用户Cookies目录路径
            string cookiesPath = folders.GetValue("Cookies").ToString();
            // Windows用户Cache目录路径
            string cachePath = folders.GetValue("Cache").ToString();
            // Windows用户应用程式数据目录路径
            string appdataPath = folders.GetValue("Appdata").ToString();
            // Windows用户打印目录路径
            string printhoodPath = folders.GetValue("Printhood").ToString();
            */

            
            result += "221.221.150.232的mac " + GetClientMacAddress("221.221.150.232") + "<br />";
            result += "获得客户端内网IP地址 " + GetClientIP() + "<br />";
            result += "获得客户端内网IP地址2 " + GetClientIP2() + "<br />";
            result += "获得客户端外网IP地址 " + GetClientInternetIP() + "<br />";
            result += "系统的登录用户名 " + GetUserName() + "<br />";
            result += "本机MAC地址 " + GetLocalMacAddress() + "<br />";
            List<string> list = GetMacByNetworkInterface();
            result += "通过NetworkInterface读取网卡Mac " + string.Join(",", list.ToArray()) + "<br />";
            list = GetClientMacByWMI();
            result += "通过WMI读取系统信息里的网卡MAC " + string.Join(",", list.ToArray()) + "<br />";
            list = GetClientMacByIPConfig();
            result += "根据截取ipconfig /all命令的输出流获取网卡Mac " + string.Join(",", list.ToArray()) + "<br />";

            result += "客户端MAC地址 " + GetClientMacAddress() + "<br />";
            result += "获取客户端IP地址 " + GetWebClientIp() + "<br />";
            result += "UserHostAddress " + System.Web.HttpContext.Current.Request.UserHostAddress + "<br />";
            result += "通过ARP协议由IP地址获取客户端MAC地址 " + GetClientMacAddress(System.Web.HttpContext.Current.Request.UserHostAddress) + "<br />";
            result += "获取本机的物理地址 " + getMacAddr_Local() + "<br />";
            result += "获取客户端内网IPv6地址 " + GetClientLocalIPv6Address() + "<br />";
            result += "获取客户端内网IPv4地址 " + GetClientLocalIPv4Address() + "<br />";
            result += "返回客户端内网IPv4地址集合 " + GetClientLocalIPv4AddressList() + "<br />";
            result += "客户端外网IP地址 " + GetClientInternetIPAddress() + "<br />";
            result += "本机公网IP地址 " + GetClientInternetIPAddress2() + "<br />";
            result += "硬盘序号 " + GetDiskID() + "<br />";
            result += "获取CpuID " + GetCpuID() + "<br />";
            result += "操作系统类型 " + GetSystemType() + "<br />";
            result += "操作系统名称 " + GetSystemName() + "<br />";
            result += "物理内存信息 " + GetTotalPhysicalMemory() + "<br />";
            result += "获取主板id " + GetMotherBoardID() + "<br />";
            result += "获取公用桌面路径 " + GetAllUsersDesktopFolderPath() + "<br />";
            result += "获取公用启动项路径 " + GetAllUsersStartupFolderPath() + "<br />";
            /*
            result += "Windows用户桌面路径" + desktopPath + "<br />";
            result += "Windows用户字体目录路径 " + fontsPath + "<br />";
            result += "Windows用户网络邻居路径" + nethoodPath + "<br />";
            result += "Windows用户我的文档路径 " + personalPath + "<br />";
            result += "Windows用户开始菜单程序路径 " + programsPath + "<br />";
            result += "Windows用户存放用户最近访问文档快捷方式的目录路径 " + recentPath + "<br />";
            result += "Windows用户发送到目录路径 " + sendtoPath + "<br />";
            result += "Windows用户开始菜单目录路径 " + startmenuPath + "<br />";
            result += "Windows用户开始菜单启动项目录路径 " + startupPath + "<br />";
            result += "Windows用户收藏夹目录路径 " + favoritesPath + "<br />";
            result += "Windows用户网页历史目录路径 " + historyPath + "<br />";
            result += "Windows用户Cookies目录路径 " + cookiesPath + "<br />";
            result += "Windows用户Cache目录路径 " + cachePath + "<br />";
            result += "Windows用户应用程式数据目录路径 " + appdataPath + "<br />";
            result += "Windows用户打印目录路径 " + printhoodPath + "<br />";
            */
            return result;
        }

        #region 获取外网IP地址
        /// <summary>
        /// 获得客户端内网IP地址
        /// </summary>
        /// <returns>IP地址</returns>
        static public string GetClientIP()
        {
            var ipHost = Dns.Resolve(Dns.GetHostName());
            var ipaddress = ipHost.AddressList[0];
            string innerIP = ipaddress.ToString();
            return innerIP;
        }
        static public string GetClientIP2()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }

        /// <summary>
        /// 获得客户端外网IP地址
        /// </summary>
        /// <returns>IP地址</returns>
        static public string GetClientInternetIP()
        {
            string ip;
            //using (WebClient webClient = new WebClient())
            //{
            //    string content = webClient.DownloadString("http://www.ip138.com/ips1388.asp"); //站获得IP的网页
            //    //判断IP是否合法
            //    ip = new Regex(@"\[((\d{1,3}\.){3}\d{1,3})\]").Match(content).Groups[1].Value;
            //}
            string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp("http://www.ip138.com/", string.Empty);
            Regex Reg = new Regex(@"(?is)(?<=<center>).*?(?=</center>)", RegexOptions.IgnoreCase);
            string Content = Reg.Match(retrunStr).Value;
            Content = Regex.Replace(Content, @"(?i)(<BR>|&nbsp;)", "", RegexOptions.IgnoreCase);

            return Content;
        }
        /// <summary>
        /// 获得客户端外网IP地址
        /// </summary>
        /// <returns></returns>
        static public string GetIPAddress()
        {
            string ip = "";
            //try
            //{
            //    WebClient MyWebClient = new WebClient();
            //    MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

            //    Byte[] pageData = MyWebClient.DownloadData("http://www.net.cn/static/customercare/yourip.asp"); //从指定网站下载数据

            //    string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句

            //    //string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

            //    string[] str = HtmlHelper.GetElementsByTagName(pageHtml, "h2");
            //    string[] str1 = str[0].Replace("<h2>", "").Split(',');

            //    ip = str1[0];
            //}
            //catch (WebException webEx)
            //{
            //    webEx.Message.ToString()
            //}
            return ip;
        }

        #region 路由获取IP地址

        Encoding gb2312 = Encoding.GetEncoding(936);//路由器的web管理系统默认编码为gb2312
        /// <summary>
        /// 使用HttpWebRequest对象发送请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding">编码</param>
        /// <param name="cache">凭证</param>
        /// <returns></returns>
        private static string SendRequest(string url, Encoding encoding, CredentialCache cache)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            if (cache != null)
            {
                request.PreAuthenticate = true;
                request.Credentials = cache;
            }
            string html = null;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader srd = new StreamReader(response.GetResponseStream(), encoding);
                html = srd.ReadToEnd();
                srd.Close();
                response.Close();
            }
            catch (Exception ex) { html = "FALSE" + ex.Message; }
            return html;
        }
        /// <summary>
        /// 获取路由MAC和外网IP地址
        /// </summary>
        /// <param name="RouterIP">路由IP地址，就是网关地址了，默认192.168.1.1</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Passowrd">密码</param>
        /// <returns></returns>
        private string LoadMACWanIP(string RouterIP, string UserName, string Passowrd)
        {
            CredentialCache cache = new CredentialCache();
            string url = "http://" + RouterIP + "/userRpm/StatusRpm.htm";
            cache.Add(new Uri(url), "Basic", new NetworkCredential(UserName, Passowrd));
            return SendRequest(url, gb2312, cache);
        }
        #endregion

        #endregion

        /// <summary>
        /// 操作系统的登录用户名
        /// </summary>
        /// <returns>系统的登录用户名</returns>
        static public string GetUserName()
        {
            try
            {
                string strUserName = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strUserName = mo["UserName"].ToString();
                }
                moc = null;
                mc = null;
                return strUserName;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取本机MAC地址
        /// </summary>
        /// <returns>本机MAC地址</returns>
        static public string GetLocalMacAddress()
        {
            try
            {
                string strMac = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        strMac = mo["MacAddress"].ToString();
                    }
                }
                moc = null;
                mc = null;
                return strMac;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        static public string GetWebClientIp()
        {
            string userIP = "未获取用户IP";

            try
            {
                if (System.Web.HttpContext.Current == null
            || System.Web.HttpContext.Current.Request == null
            || System.Web.HttpContext.Current.Request.ServerVariables == null)
                    return "";

                string CustomerIP = "";

                //CDN加速后取到的IP 
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


                if (!String.IsNullOrEmpty(CustomerIP))
                    return CustomerIP;

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (CustomerIP == null)
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                }

                if (string.Compare(CustomerIP, "unknown", true) == 0)
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                return CustomerIP;
            }
            catch { }

            return userIP;
        }

        #region 获取客户端MAC

        [DllImport("Iphlpapi.dll")]

        static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 MacAddr, ref Int32 PhyAddrLen);
        [DllImport("Ws2_32.dll")]

        static extern Int32 inet_addr(string ipaddr);
        ///<summary>
        /// 通过ARP协议由IP地址获取客户端MAC地址
        ///</summary>
        ///<param name="remoteIP">目标机器的IP地址如(192.168.1.1)</param>
        ///<returns>目标机器的mac 地址</returns>
        static public string GetClientMacAddress(string remoteIP)
        {

            StringBuilder macAddress = new StringBuilder();

            try
            {
                Int32 remote = inet_addr(remoteIP);
                Int64 macInfo = new Int64();
                Int32 length = 6;
                SendARP(remote, 0, ref macInfo, ref length);
                string temp = Convert.ToString(macInfo, 16).PadLeft(12, '0').ToUpper();
                int x = 12;
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                    {
                        macAddress.Append(temp.Substring(x - 2, 2));
                    }
                    else
                    {
                        macAddress.Append(temp.Substring(x - 2, 2) + "-");
                    }

                    x -= 2;
                }
                return macAddress.ToString();
            }
            catch
            {
                return macAddress.ToString();
            }
        }
        /// <summary>
        /// 通过ARP协议由IP地址获取客户端MAC地址
        /// </summary>
        /// <returns></returns>
        static public string GetClientMacAddress()
        {
            string remoteIP = System.Web.HttpContext.Current.Request.UserHostAddress;
            StringBuilder macAddress = new StringBuilder();

            try
            {
                Int32 remote = inet_addr(remoteIP);
                Int64 macInfo = new Int64();
                Int32 length = 6;
                SendARP(remote, 0, ref macInfo, ref length);
                string temp = Convert.ToString(macInfo, 16).PadLeft(12, '0').ToUpper();
                int x = 12;
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                    {
                        macAddress.Append(temp.Substring(x - 2, 2));
                    }
                    else
                    {
                        macAddress.Append(temp.Substring(x - 2, 2) + "-");
                    }

                    x -= 2;
                }
                return macAddress.ToString();
            }
            catch
            {
                return macAddress.ToString();
            }
        }
        /// <summary>
        /// 根据ip地址获取客户端mac
        /// </summary>
        /// <param name="clientip">ip地址</param>
        /// <returns></returns>
        static public string GetClientMacByClientIp(string clientip)
        {
            string mac = "";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "nbtstat";
            process.StartInfo.Arguments = "-a " + clientip;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            int length = output.IndexOf("MAC Address =");
            if (length > 0)
            {
                mac = output.Substring(length + 14, 17);
            }
            return mac;
        }
        /// <summary>
        /// 返回描述本地计算机上的网络接口的对象(网络接口也称为网络适配器)
        /// </summary>
        /// <returns></returns>
        static public NetworkInterface[] NetCardInfo()
        {
            return NetworkInterface.GetAllNetworkInterfaces();
        }

        ///<summary>
        /// 通过NetworkInterface读取网卡Mac
        ///</summary>
        ///<returns></returns>
        static public List<string> GetMacByNetworkInterface()
        {
            List<string> macs = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                macs.Add(ni.GetPhysicalAddress().ToString());
            }
            return macs;
        }
        ///<summary>
        /// 通过WMI读取系统信息里的网卡MAC
        ///</summary>
        ///<returns></returns>
        static public List<string> GetClientMacByWMI()
        {
            List<string> macs = new List<string>();
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        mac = mo["MacAddress"].ToString();
                        macs.Add(mac);
                    }
                }
                moc = null;
                mc = null;
            }
            catch
            {
            }

            return macs;
        }
        ///<summary>
        /// 根据截取ipconfig /all命令的输出流获取网卡Mac
        ///</summary>
        ///<returns></returns>
        static public List<string> GetClientMacByIPConfig()
        {
            List<string> macs = new List<string>();
            ProcessStartInfo startInfo = new ProcessStartInfo("ipconfig", "/all");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            Process p = Process.Start(startInfo);
            //截取输出流
            StreamReader reader = p.StandardOutput;
            string line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    line = line.Trim();

                    if (line.StartsWith("Physical Address"))
                    {
                        macs.Add(line);
                    }
                }

                line = reader.ReadLine();
            }

            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();
            reader.Close();

            return macs;
        }
        #endregion

        /// <summary>
        /// 获取本机的物理地址
        /// </summary>
        /// <returns></returns>
        static public string getMacAddr_Local()
        {
            string madAddr = null;
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if (Convert.ToBoolean(mo["IPEnabled"]) == true)
                    {
                        madAddr = mo["MacAddress"].ToString();
                        madAddr = madAddr.Replace(':', '-');
                    }
                    mo.Dispose();
                }
                if (madAddr == null)
                {
                    return "unknown";
                }
                else
                {
                    return madAddr;
                }
            }
            catch (Exception)
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取客户端内网IPv6地址
        /// </summary>
        /// <returns>客户端内网IPv6地址</returns>
        static public string GetClientLocalIPv6Address()
        {
            string strLocalIP = string.Empty;
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHost.AddressList[0];
                strLocalIP = ipAddress.ToString();
                return strLocalIP;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取客户端内网IPv4地址
        /// </summary>
        /// <returns>客户端内网IPv4地址</returns>
        static public string GetClientLocalIPv4Address()
        {
            string strLocalIP = string.Empty;
            try
            {
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHost.AddressList[0];
                strLocalIP = ipAddress.ToString();
                return strLocalIP;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取客户端内网IPv4地址集合
        /// </summary>
        /// <returns>返回客户端内网IPv4地址集合</returns>
        static public List<string> GetClientLocalIPv4AddressList()
        {
            List<string> ipAddressList = new List<string>();
            try
            {
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                foreach (IPAddress ipAddress in ipHost.AddressList)
                {
                    if (!ipAddressList.Contains(ipAddress.ToString()))
                    {
                        ipAddressList.Add(ipAddress.ToString());
                    }
                }
            }
            catch
            {

            }
            return ipAddressList;
        }

        /// <summary>
        /// 获取客户端外网IP地址
        /// </summary>
        /// <returns>客户端外网IP地址</returns>
        static public string GetClientInternetIPAddress()
        {
            string strInternetIPAddress = string.Empty;
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    strInternetIPAddress = webClient.DownloadString("http://www.coridc.com/ip");
                    Regex r = new Regex("[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}");
                    Match mth = r.Match(strInternetIPAddress);
                    if (!mth.Success)
                    {
                        strInternetIPAddress = GetClientInternetIPAddress2();
                        mth = r.Match(strInternetIPAddress);
                        if (!mth.Success)
                        {
                            strInternetIPAddress = "unknown";
                        }
                    }
                    return strInternetIPAddress;
                }
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取本机公网IP地址
        /// </summary>
        /// <returns>本机公网IP地址</returns>
        private static string GetClientInternetIPAddress2()
        {
            string tempip = "";
            try
            {
                WebRequest wr = WebRequest.Create("http://iframe.ip138.com/ic.asp");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int start = all.IndexOf("[") + 1;
                int end = all.IndexOf("]", start);
                tempip = all.Substring(start, end - start);
                sr.Close();
                s.Close();
                return tempip;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取硬盘序号
        /// </summary>
        /// <returns>硬盘序号</returns>
        static public string GetDiskID()
        {
            try
            {
                string strDiskID = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strDiskID = mo.Properties["Model"].Value.ToString();
                }
                moc = null;
                mc = null;
                return strDiskID;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取CpuID
        /// </summary>
        /// <returns>CpuID</returns>
        static public string GetCpuID()
        {
            try
            {
                string strCpuID = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return strCpuID;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取操作系统类型
        /// </summary>
        /// <returns>操作系统类型</returns>
        static public string GetSystemType()
        {
            try
            {
                string strSystemType = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strSystemType = mo["SystemType"].ToString();
                }
                moc = null;
                mc = null;
                return strSystemType;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取操作系统名称
        /// </summary>
        /// <returns>操作系统名称</returns>
        static public string GetSystemName()
        {
            try
            {
                string strSystemName = string.Empty;
                ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT PartComponent FROM Win32_SystemOperatingSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    strSystemName = mo["PartComponent"].ToString();
                }
                mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT Caption FROM Win32_OperatingSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    strSystemName = mo["Caption"].ToString();
                }
                return strSystemName;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>
        /// 获取物理内存信息
        /// </summary>
        /// <returns>物理内存信息</returns>
        static public string GetTotalPhysicalMemory()
        {
            try
            {
                string strTotalPhysicalMemory = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strTotalPhysicalMemory = mo["TotalPhysicalMemory"].ToString();
                }
                moc = null;
                mc = null;
                return strTotalPhysicalMemory;
            }
            catch
            {
                return "unknown";
            }
        }

        /// <summary>
        /// 获取主板id
        /// </summary>
        /// <returns></returns>
        static public string GetMotherBoardID()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_BaseBoard");
                ManagementObjectCollection moc = mc.GetInstances();
                string strID = null;
                foreach (ManagementObject mo in moc)
                {
                    strID = mo.Properties["SerialNumber"].Value.ToString();
                    break;
                }
                return strID;
            }
            catch
            {
                return "unknown";
            }
        }

        /// <summary>
        /// 获取公用桌面路径         
        static public string GetAllUsersDesktopFolderPath()
        {
            RegistryKey folders;
            folders = OpenRegistryPath(Registry.LocalMachine, @"/software/microsoft/windows/currentversion/explorer/shell folders");
            string desktopPath = folders.GetValue("Common Desktop").ToString();
            return desktopPath;
        }
        /// <summary>
        /// 获取公用启动项路径
        /// </summary>
        static public string GetAllUsersStartupFolderPath()
        {
            RegistryKey folders;
            folders = OpenRegistryPath(Registry.LocalMachine, @"/software/microsoft/windows/currentversion/explorer/shell folders");
            string Startup = folders.GetValue("Common Startup").ToString();
            return Startup;
        }
        private static RegistryKey OpenRegistryPath(RegistryKey root, string s)
        {
            s = s.Remove(0, 1) + @"/";
            while (s.IndexOf(@"/") != -1)
            {
                root = root.OpenSubKey(s.Substring(0, s.IndexOf(@"/")));
                s = s.Remove(0, s.IndexOf(@"/") + 1);
            }
            return root;
        }
        #endregion

        private string _FilePath = string.Empty;
        private List<IpInfo> _IpSource = null;

        /// <summary>
        /// IP地址查询
        /// </summary>
        /// <param name="filePath">QQ IP数据库 纯真版 Ip导出文件，文件格式为UTF8编码</param>
        public IpHelper(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
            {
                throw new System.IO.FileNotFoundException("IP文件不存在！", filePath);
            }
            _FilePath = filePath;
            Init();
        }

        private void Init()
        {
            _IpSource = new List<IpInfo>();
            using (var fs = new StreamReader(_FilePath, UTF8Encoding.UTF8))
            {
                var txt = fs.ReadLine();
                while (!string.IsNullOrEmpty(txt))
                {
                    var arr = txt.Split(new char[] { ' ' }).Where(t => !string.IsNullOrEmpty(t));
                    if (arr.Count() > 2)
                    {
                        var ip = new IpInfo();
                        ip.StartIp = IpToNumber(arr.ElementAt(0));
                        ip.EndIp = IpToNumber(arr.ElementAt(1));
                        ip.Province = GetProvince(arr.ElementAt(2));
                        _IpSource.Add(ip);
                    }
                    txt = fs.ReadLine();
                }
            }
        }

        private string GetProvince(string country)
        {
            if (string.IsNullOrEmpty(country))
            {
                return "未知";
            }
            try
            {
                var heads = "西藏,新疆,宁夏,广西,内蒙古".Split(new char[] { ',' });
                foreach (var h in heads)
                {
                    if (country.Trim().StartsWith(h))
                    {
                        return h;
                    }
                }
                var index = country.IndexOf("市");
                if (country.IndexOf("省") > -1)
                {
                    index = country.IndexOf("省");
                }
                if (index > 0)
                {
                    return country.Substring(0, index);
                }
            }
            catch (Exception ex)
            {

            }

            return country;
        }

        public long IpToNumber(string ip)
        {
            var dot = new char[] { '.' };
            var ipArr = ip.Split(dot);
            if (ipArr.Length == 3)
            {
                ip = ip + ".0";
            }
            ipArr = ip.Split(dot);

            long ip_Int = 0;
            var p1 = long.Parse(ipArr[0]) * 256 * 256 * 256;
            var p2 = long.Parse(ipArr[1]) * 256 * 256;
            var p3 = long.Parse(ipArr[2]) * 256;
            var p4 = long.Parse(ipArr[3]);
            ip_Int = p1 + p2 + p3 + p4;
            return ip_Int;
        }

        /// <summary>
        /// Ip地址查询
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public IpInfo IpSearch(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                return null;
            }
            var pattern = @"(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))";
            var objRe = new Regex(pattern);
            var objMa = objRe.Match(ip);
            if (!objMa.Success)
            {
                return null;
            }
            var value = IpToNumber(ip);
            var info = _IpSource.Where(t => t.StartIp >= value).FirstOrDefault();

            if (info == null)
            {
                info = _IpSource.Where(t => t.EndIp <= value).FirstOrDefault();
            }
            return info;
        }

        public void Dispose()
        {
            if (_IpSource != null)
            {
                _IpSource.Clear();
            }
        }
    }
}
