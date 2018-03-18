using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityHelper
{
    public class TemplateHelper
    {

        /// <summary>
        /// 文件模板替换，模板替换字段格式为：{实体属性名称}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string CreateFileTemplate<T>(T obj,string filePath) where T : class, new()
        {
            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException(filePath + " 文件不存在！");


            string fileStr = "";

            using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
            {
                fileStr = reader.ReadToEnd();
            }


            if (string.IsNullOrEmpty(fileStr))
                throw new ArgumentNullException("模板文件内容不能为空！");

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\{(.*)\}");

            var pNameList = new List<string>();
            foreach (System.Text.RegularExpressions.Match m in  regex.Matches(fileStr))
            {
                if (m.Success)
                    pNameList.Add(m.Value);
            }


            
            foreach (var pName in pNameList)
            {
                var p = obj.GetType().GetProperty(pName.Replace("{","").Replace("}",""),System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase );

                if (p != null)
                {
                    var rValue = p.GetValue(obj);
                    fileStr = StringRegexReplace(fileStr, pName, rValue != null ? rValue.ToString():"");
                }

            }

            return fileStr;

        }

        /// <summary>
        /// 字符串正则替换
        /// </summary>
        /// <param name="objStr"></param>
        /// <param name="pattern"></param>
        /// <param name="repValue"></param>
        /// <returns></returns>
        public static string StringRegexReplace(string objStr,string pattern,string repValue)
        {
            if (string.IsNullOrEmpty(objStr))
                throw new ArgumentNullException("字符串内容不能为空！");

            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException("Regex表达式内容不能为空！");

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);
            return regex.Replace(objStr, repValue);
        }
    }
}
