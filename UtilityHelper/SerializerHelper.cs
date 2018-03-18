using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace UtilityHelper
{
    public static class SerializerHelper
    {
        /// <summary>
        /// XML序列化
        /// </summary>
        /// <param name="o"></param>
        public static string XmlSerialize<T>(object o)
            where T : class, new()
        {
            string xmlString = string.Empty;
            try
            {
                XmlSerializer xmlSerializr = new XmlSerializer(typeof(T));
                byte[] data = null;
                using (MemoryStream stream = new MemoryStream())
                {
                    xmlSerializr.Serialize(stream, o);
                    if (stream.CanRead)
                    {
                        data = stream.ToArray();
                    }
                }
                if (data != null)
                    xmlString = Encoding.UTF8.GetString(data);
            }
            catch (SerializationException e)
            {
                throw e;
            }
            return xmlString;
        }


        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xmlString)
            where T : class, new()
        {
            T o;
            if (string.IsNullOrEmpty(xmlString))
                return null;
            XmlSerializer xmlSerializr = new XmlSerializer(typeof(T));
            try
            {
                var data = Encoding.UTF8.GetBytes(xmlString);
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                    //有两种设置方法，一种是设置Position属性，一种是调用Seek方法                    
                    //设置Position属性代码： stream.Position=0;
                    stream.Seek(0, SeekOrigin.Begin);
                    o = xmlSerializr.Deserialize(stream) as T;
                }
            }
            catch (SerializationException e)
            {
                throw e;
            }
            return o;
        }

        /// <summary>
        /// 序列化Json
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string ToJson<T>(T item)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, item);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray()));
                return sb.ToString();
            }
        }

        /// <summary>
        /// 将Json反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJsonTo<T>(string json)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                T jsonObject = (T)jsonSerializer.ReadObject(ms);
                return jsonObject;

            }  
        }

        /// <summary>
        /// Newtonsoft.Json 序列化对象 (object对象序列化成json数据)
        /// 日期类型格式化为 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObject(object value)
        {
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss"
            };
            return JsonConvert.SerializeObject(value, timeConverter);
        }

        /// <summary>
        /// Newtonsoft.Json 反序列化对象 (json数据序列化成object对象)
        /// </summary>
        /// <typeparam name="T">任意类型</typeparam>
        /// <param name="strJson">json字符串</param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string strJson) where T : class,new()
        {
            return JsonConvert.DeserializeObject(strJson, typeof(T)) as T;
        }

        /// <summary>
        /// 把json转换成匿名对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool JsonToAnonymousType<T>(string json, out T t)
        {
            t = default(T);

            if (!String.IsNullOrEmpty(json))
            {
                try
                {
                    t = JsonConvert.DeserializeAnonymousType(json, t);
                    return true;
                }
                catch
                {
                }
            }

            return false;
        }

        /// <summary>
        /// 把DataTable转换成json
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            return JsonConvert.SerializeObject(dt, new DataTableConverter());
        }

        public static Dictionary<string, string> Split(string json)
        {
            if (string.IsNullOrEmpty(json) || !json.StartsWith("{") || !json.EndsWith("}"))
            {
                return null;
            }
            json = json.TrimStart('{').TrimEnd('}');
            List<string> items = new List<string>();
            string splitKey = "\",\"";
            int index = json.IndexOf(splitKey, StringComparison.Ordinal);
            if (index == -1)
            {
                splitKey = "','";
                index = json.IndexOf(splitKey, StringComparison.Ordinal);
                if (index == -1)
                {
                    splitKey = ",";
                    index = json.IndexOf(splitKey, StringComparison.Ordinal);
                }
            }
            while (index > -1)
            {
                string item = json.Substring(0, index + 1);
                int startIndex;
                if (item.Contains(":"))
                {
                    items.Add(item);
                    json = json.Remove(0, index + 2);
                    startIndex = 0;
                }
                else
                {
                    startIndex = index + 2;
                }
                index = json.IndexOf(splitKey, startIndex, StringComparison.Ordinal);
            }
            items.Add(json);
            Dictionary<string, string> keyValueDic = null;
            if (items.Count > 0)
            {
                keyValueDic = new Dictionary<string, string>();
                foreach (string keyValue in items)
                {
                    index = keyValue.IndexOf(':');
                    if (index > -1)
                    {
                        keyValueDic.Add(keyValue.Substring(0, index).Trim('\'', '\"'), keyValue.Substring(index + 1).Trim('\'', '\"'));
                    }
                }
            }
            return keyValueDic;
        }
    }
}
