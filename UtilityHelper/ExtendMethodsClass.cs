using System;
using System.Collections.Generic;
 

namespace UtilityHelper
{
    /// <summary>
    /// 扩展类
    /// </summary>
    public static class ExtendMethodsClass
    { 
        /// <summary>
        /// 字符串转数字
        /// </summary>
        /// <param name="str">需要转换的字符串</param>
        /// <param name="defValue">内容</param>
        /// <returns></returns>
        public static int ToInt(this string str, int defValue = 0)
        {
            return SysUtils.StrToInt(str, defValue);
        }

        public static int ToInt(this object expression, int defValue = 0)
        {
            return SysUtils.StrToInt(expression, defValue);
        }


        /// <summary>
        /// 去掉首尾空格，null值不操作
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStrTrim(this string str)
        {
            if (str != null)
                str = str.Trim();
            return str;


        }

        public static int ToTimeStamp(this DateTime dt)
        {
            DateTime time = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan span = (TimeSpan)(dt - time);
            return (int)span.TotalSeconds;
        }

    }
}

