using BWJS.AppCode;
using BWJSLog.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace BWJS.WebApp.Test
{
    public partial class a : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetLocation();
            }
        }

        protected void GetLocation()
        {
            #region 设置位置信息
            string longitude = string.Empty;
            string latitude = string.Empty;
            string locationData = string.Empty;
            
            string jsonText = MachineLocationLogBLL.GetLocationInfo();
            if (!string.IsNullOrEmpty(jsonText))
            {
                JObject o = JObject.Parse(jsonText);
                longitude = o["content"]["point"]["x"].ToString();
                latitude = o["content"]["point"]["y"].ToString();
            }

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


            if (!string.IsNullOrEmpty(locationData))
            {
                string xmlheader = "<xml version=\"1.0\" encoding=\"utf-8\">";
                locationXml = locationData.Replace("?", "");
                locationXml = locationXml.Replace(xmlheader, string.Empty);
            }
            #endregion
        }
    }
}