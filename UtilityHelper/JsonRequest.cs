using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Web;

namespace UtilityHelper
{
    /// <summary>
    /// json和Dictionary互转
    /// </summary>
    public class JsonRequest
    {
        #region json和Dictionary互转

        #region 3
        /// <summary>
        /// 获取json串里的键值
        /// </summary>
        /// <param name="postKey">key</param>
        /// <returns>value</returns>
        static public string GetJsonKeyVal(string postKey, ref string jsonText)
        {
            string result = string.Empty;

            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            byte[] reqData = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes);
            jsonText = Encoding.Default.GetString(reqData);
            if (!string.IsNullOrEmpty(jsonText))
            {
                List<Object> list = JsonConvert.DeserializeObject<List<Object>>(jsonText);
                if (list != null && list.Count > 0)
                {
                    foreach (Object obj in list)
                    {
                        JObject jo = JObject.Parse(obj.ToString());
                        if (jo != null)
                        {
                            if (jo["name"] != null)
                            {
                                string key = jo["name"].ToString();
                                if (postKey == key)
                                {
                                    result = jo["value"].ToString();
                                    //result += string.Format("{0}-{1},", op1, action1);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取json串里的键值
        /// </summary>
        /// <param name="postKey">key</param>
        /// <returns>value</returns>
        static public string GetJsonKeyVal(string postKey)
        {
            string result = string.Empty;

            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            byte[] reqData = HttpContext.Current.Request.BinaryRead(HttpContext.Current.Request.TotalBytes);
            string jsonText = Encoding.Default.GetString(reqData);
            if (!string.IsNullOrEmpty(jsonText))
            {
                List<Object> list = JsonConvert.DeserializeObject<List<Object>>(jsonText);
                if (list != null && list.Count > 0)
                {
                    foreach (Object obj in list)
                    {
                        JObject jo = JObject.Parse(obj.ToString());
                        if (jo != null)
                        {
                            if (jo["name"] != null)
                            {
                                string key = jo["name"].ToString();
                                if (postKey == key)
                                {
                                    result = jo["value"].ToString();
                                    //result += string.Format("{0}-{1},", op1, action1);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取json串里的键值
        /// </summary>
        /// <param name="jsonText">jsonText</param>
        /// <param name="postKey">key</param>
        /// <returns>value</returns>
        static public string GetJsonKeyVal(string jsonText, string postKey)
        {
            string result = string.Empty;
            List<Object> list = JsonConvert.DeserializeObject<List<Object>>(jsonText);
            if (list != null && list.Count > 0)
            {
                string f1 = string.Empty;
                foreach (Object obj in list)
                {
                    JObject jo = JObject.Parse(obj.ToString());
                    if (jo != null)
                    {
                        if (jo["name"] != null)
                        {
                            f1 += string.Format("{0}={1},", jo["name"], ((jo["value"] == null) ? ("") : (jo["value"])));

                            string key = jo["name"].ToString();
                            if (postKey == key)
                            {
                                result = jo["value"].ToString();
                            }
                        }
                    }
                }
            }
            return result;
        }

        #endregion

        #region 2
        /// <summary>
        /// JSON序列化
        /// </summary>
        static public string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
        /// <summary>
        /// 将json数据反序列化为Dictionary
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        static public Dictionary<string, object> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, object>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 将Dictionary序列化为json数据
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        static public string DictionaryToJson(Dictionary<string, object> dic)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Serialize(dic);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region 1
        /// <summary>
        /// 将字典类型序列化为json字符串
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="dict">要序列化的字典数据</param>
        /// <returns>json字符串</returns>
        static public string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            if (dict.Count == 0)
                return "";

            string jsonStr = JsonConvert.SerializeObject(dict);
            return jsonStr;
        }

        /// <summary>
        /// 将json字符串反序列化为字典类型
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>字典数据</returns>
        static public Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new Dictionary<TKey, TValue>();

            Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr);

            return jsonDict;

        }
        #endregion

        #endregion
    }
}
