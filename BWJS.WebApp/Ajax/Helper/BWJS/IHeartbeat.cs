using BWJS.AppCode;
using BWJS.BLL;
using BWJS.BLL.CookieMag;
using BWJS.Model;
using BWJSLog.BLL;
using BWJSLog.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Xml;
using UtilityHelper;

namespace BWJS.WebApp.Ajax.Helper.BWJS
{
    /// <summary>
    /// 心跳监视
    /// </summary>
    public class IHeartbeat
    {
        static string jsonText = string.Empty;

        static public void Implementation(string postJsonText)
        {
            jsonText = postJsonText;
            string action = DNTRequest.GetString("action");
            if (string.IsNullOrEmpty(action))
            {
                action = JsonRequest.GetJsonKeyVal(jsonText, "action");
            }
            if (!string.IsNullOrEmpty(action))
            {
                #region 实现

                switch (action)
                {
                    case "heartbeatcheck":
                        HttpContext.Current.Response.Write(HeartbeatCheck());
                        break;
                    case "getheartbeatinterval":
                        HttpContext.Current.Response.Write(GetHeartbeatInterval());
                        break; 
                }

                #endregion
            }
        }

        #region 获取心跳检查间隔
        /// <summary>
        /// 获取心跳检查间隔
        /// </summary>
        static public Object GetHeartbeatInterval()
        {
            string result = string.Empty;
            try
            {
                double heartbeatInterval = 1000;
                int hours = 1;
                int minutes = 1;
                int seconds = 60;

                SysSettingsBLL opSysSettingsBLL = new SysSettingsBLL();
                SysSettings modelSysSettings = new SysSettings();
                List<SysSettings> list = opSysSettingsBLL.GetModelList("IsDeleted=0 and Status=0");
                if (list.Count > 0)
                {
                    modelSysSettings = list[0];
                }
                if (modelSysSettings != null)
                {
                    hours = modelSysSettings.TimerHours;
                    minutes = modelSysSettings.TimerMinutes;
                    seconds = modelSysSettings.TimerSeconds;
                }
                heartbeatInterval = hours * minutes * seconds * 1000;
                result = DNTRequest.GetResultJson(true, "获取心跳检查间隔成功", heartbeatInterval);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "获取心跳检查间隔异常", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 设备心跳检查
        /// <summary>
        /// 设备心跳检查
        /// </summary>
        static public Object HeartbeatCheck()
        {
            string result = string.Empty;
            try
            {
                #region 启动定时器
                //double interval = 1000;
                //int hours = 1;
                //int minutes = 1;
                //int seconds = 60;

                //SysSettingsBLL opSysSettingsBLL = new SysSettingsBLL();
                //SysSettings modelSysSettings = new SysSettings();
                //List<SysSettings> list = opSysSettingsBLL.GetModelList("IsDeleted=0 and Status=0");
                //if (list.Count > 0)
                //{
                //    modelSysSettings = list[0];
                //}
                //if (modelSysSettings != null)
                //{
                //    hours = modelSysSettings.TimerHours;
                //    minutes = modelSysSettings.TimerMinutes;
                //    seconds = modelSysSettings.TimerSeconds;
                //}
                //interval = hours * minutes * seconds * 1000;
                //int enabled = DNTRequest.GetInt("enabled", 1);
                //bool timerEnabled = ((enabled == 1) ? (true) : (false));
                //System.Timers.Timer timer = new System.Timers.Timer();
                //timer.Enabled = timerEnabled;
                //timer.Interval = interval;
                //timer.Start();
                //timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);
                //if (!timerEnabled)
                //{
                //    timer.Enabled = false;
                //}

                #endregion

                UpdateMachineSettings();

                result = DNTRequest.GetResultJson(true, "心跳检测启动成功", null);
            }
            catch (Exception ex)
            {
                result = DNTRequest.GetResultJson(false, "心跳检测启动异常", ex.Message);
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 定时器代码

        static private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateMachineSettings();

            #region 定点检查暂时不用
            ////获取当前时分秒
            //int intHour = e.SignalTime.Hour;
            //int intMinute = e.SignalTime.Minute;
            //int intSecond = e.SignalTime.Second;

            ////定制时间
            //int iHour = 10;
            //int iMinute = 30;
            //int iSecond = 00;

            //Log.WriteLog(" 每秒钟的开始执行一次！");
            //Log.WriteLog(" " + IpHelper.GetClientIP() + " " + IpHelper.GetLocalMacAddress());
            //GetLocalInfo();

            ////开始比较
            ////每天的10:30:00开始执行程序
            //if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
            //{
            //    Log.WriteLog(" 在每天10点30分开始执行！");
            //    Log.WriteLog(IpHelper.GetClientIP2());
            //    GetLocalInfo();
            //    UpdateMachineSettings();
            //} 
            #endregion

        }

        #endregion

        #region 更新设备信息
        /// <summary>
        /// 更新设备信息
        /// </summary>
        static void UpdateMachineSettings()
        {
            try
            {
                string description = string.Empty;
                string ip = string.Empty;
                string mac = string.Empty;
                try
                {
                    ip = HttpContext.Current.Request.UserHostAddress;//IpHelper.GetClientIP2();
                    mac = IpHelper.GetClientMacAddress();
                    if (mac == "00-00-00-00-00-00")
                    {
                        mac = IpHelper.GetLocalMacAddress();
                    }
                }
                catch { }

                int currentUserId = MerchantFrontCookieBLL.GetMerchantFrontUserId();

                MachineBLL opMachineBLL = new MachineBLL();
                Machine modelMachine = new Machine();
                if (currentUserId != 0)
                {
                    modelMachine = opMachineBLL.GetModelByUserId(currentUserId);
                }

                int machineId = 0;
                if (modelMachine != null)
                {
                    machineId = modelMachine.MachineID;
                }

                #region 设置位置信息
                string longitude = string.Empty;
                string latitude = string.Empty;
                string locationData = string.Empty;

                #region 获取当前位置信息
                string jsonText = MachineLocationLogBLL.GetLocationInfo();
                if (!string.IsNullOrEmpty(jsonText))
                {
                    JObject o = JObject.Parse(jsonText);
                    longitude = o["content"]["point"]["x"].ToString();
                    latitude = o["content"]["point"]["y"].ToString();
                }
                #endregion

                #region 逆地理位置解析
                string locationAddress = string.Empty;
                string locationXml = string.Empty;
                if (!string.IsNullOrEmpty(longitude) && !string.IsNullOrEmpty(latitude))
                {
                    locationData = MachineLocationLogBLL.GetAddressByLocation(longitude, latitude, "xml", 0);
                    if (!string.IsNullOrEmpty(locationData))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(locationData);
                        //locationXml = doc.DocumentElement.InnerXml;
                        //settings.OmitXmlDeclaration = true;//这一句表示忽略xml声明
                        XmlNodeList locationNodeList = doc.SelectNodes("GeocoderSearchResponse/result");
                        if (locationNodeList != null)
                        {
                            foreach (XmlNode locationNode in locationNodeList)
                            {
                                XmlNode formatted_address = locationNode.SelectSingleNode("formatted_address");
                                if (formatted_address != null)
                                {
                                    locationAddress += formatted_address.InnerText;
                                }
                                XmlNode sematic_description = locationNode.SelectSingleNode("sematic_description");
                                if (sematic_description != null)
                                {
                                    locationAddress += sematic_description.InnerText;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 更新设备信息
                opMachineBLL = new MachineBLL();
                modelMachine = new Machine();
                modelMachine = opMachineBLL.GetModel(machineId);
                if (modelMachine != null)
                {
                    modelMachine.MAC = mac;
                    modelMachine.Longitude = longitude;
                    modelMachine.Latitude = latitude;
                    modelMachine.LocationAddress = locationAddress;
                    opMachineBLL.Update(modelMachine);
                }
                #endregion

                #region 记录位置信息日志
                if (!string.IsNullOrEmpty(locationData))
                {
                    string xmlheader = "<xml version=\"1.0\" encoding=\"utf-8\">";
                    locationXml = locationData.Replace("?", "");
                    locationXml = locationXml.Replace(xmlheader, string.Empty);
                }

                MachineLocationLogBLL opMachineLocationLogBLL = new MachineLocationLogBLL();
                MachineLocationLog modelMachineLocationLog = new MachineLocationLog();
                modelMachineLocationLog.UserId = currentUserId;
                modelMachineLocationLog.MachineId = machineId;
                modelMachineLocationLog.IP = ip;
                modelMachineLocationLog.MAC = mac;
                modelMachineLocationLog.Longitude = longitude;
                modelMachineLocationLog.Latitude = latitude;
                modelMachineLocationLog.LocationAddress = locationAddress;
                modelMachineLocationLog.LocationData = locationXml;
                modelMachineLocationLog.CreateDate = DateTime.Now;
                modelMachineLocationLog.IsDeleted = 0;
                modelMachineLocationLog.Remark = description;
                int res = opMachineLocationLogBLL.Add(modelMachineLocationLog);

                #endregion

                #endregion

            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB("心跳检查异常，" + ex.ToString());
            }
        }
        #endregion
    }
}