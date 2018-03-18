using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace UtilityHelper
{
    public sealed class HtmlHelper
    {
        /// <summary>
        /// html代码正则过滤，过滤危险节点   
        /// 默认屏蔽html、body、meta、frame、frameset、layer、ilayer、ilayer、script
        /// </summary>
        /// <param name="html">html内容</param>
        /// <param name="codes">自定义屏蔽的代码</param>
        /// <returns></returns>
        public static string RegexFilter(string html,string codes = null)
        {
            if (string.IsNullOrEmpty(html))
                return "";
            string defaultCodes = (!string.IsNullOrEmpty(codes) ? codes : "html,body,meta,frame,frameset,layer,ilayer,ilayer,script");
              //过滤 
            Regex regex;
            foreach (var txt in defaultCodes.Split(','))
            {
                if (string.IsNullOrEmpty(txt))
                    continue;
                try
                {
                    regex = new Regex(string.Format(@"<{0}[^>]*?>[\s\S]*?</{0}>", txt), RegexOptions.IgnoreCase);
                    html = regex.Replace(html, "");
                    regex = new Regex(string.Format(@"<{0}[^>]*?/>", txt), RegexOptions.IgnoreCase);
                    html = regex.Replace(html, "");
                }
                catch 
                {
 
                }
            }
            return html;
        }


        #region 获得当前绝对路径


        /*****************
         * 谷彬
         * **************/
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        #endregion

        #region 检测是否有Sql危险字符

        /*****************
         * 谷彬
         * **************/
        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检查危险字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Filter(string sInput)
        {
            if (sInput == null || sInput == "")
                return null;
            string sInput1 = sInput.ToLower();
            string output = sInput;
            string pattern = @"*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
            {
                throw new Exception("字符串中含有非法字符!");
            }
            else
            {
                output = output.Replace("'", "''");
            }
            return output;
        }

        /// <summary> 
        /// 检查过滤设定的危险字符
        /// </summary> 
        /// <param name="InText">要过滤的字符串 </param> 
        /// <returns>如果参数存在不安全字符，则返回true </returns> 
        public static bool SqlFilter(string word, string InText)
        {
            if (InText == null)
                return false;
            foreach (string i in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    

    }
}
