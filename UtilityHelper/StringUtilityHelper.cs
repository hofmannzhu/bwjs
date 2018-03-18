using System;
using System.Web;
using System.Text;

namespace UtilityHelper
{
    public class StringUtilityHelper
    {
        /// <summary>
        /// 字符串如果操过指定长度则将超出的部分用指定字符串代替
        /// </summary>
        /// <param name="pSrcString">要检查的字符串</param>
        /// <param name="pLength">指定长度</param>
        /// <param name="pTailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string pSrcString, int pLength, string pTailString)
        {
            return GetSubString(pSrcString, 0, pLength, pTailString);
        }

        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="pSrcString">要检查的字符串</param>
        /// <param name="pStartIndex">起始位置</param>
        /// <param name="pLength">指定长度</param>
        /// <param name="pTailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string pSrcString, int pStartIndex, int pLength, string pTailString = "...")
        {
            string myResult = pSrcString;
            byte[] bComments = Encoding.UTF8.GetBytes(pSrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {    //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    //if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") || System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
                    //当截取的起始位置超出字段串长度时
                    if (pStartIndex >= pSrcString.Length)
                        return "";
                    return pSrcString.Substring(pStartIndex,
                        ((pLength + pStartIndex) > pSrcString.Length) ? (pSrcString.Length - pStartIndex) : pLength) + "...";
                }
            }

            if (pLength >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(pSrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > pStartIndex)
                {
                    int pEndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (pStartIndex + pLength))
                    {
                        pEndIndex = pLength + pStartIndex;
                    }
                    else
                    {   //当不在有效范围内时,只取到字符串的结尾

                        pLength = bsSrcString.Length - pStartIndex;
                        pTailString = "";
                    }

                    int nRealLength = pLength;
                    int[] anResultFlag = new int[pLength];

                    int nFlag = 0;
                    for (int i = pStartIndex; i < pEndIndex; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                                nFlag = 1;
                        }
                        else
                            nFlag = 0;

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[pEndIndex - 1] > 127) && (anResultFlag[pLength - 1] == 1))
                        nRealLength = pLength + 1;

                    var bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, pStartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);
                    myResult = myResult + pTailString;
                }
            }

            return myResult;
        }

        #region URL处理

        /*****************
         * 谷彬
         * **************/
        /// <summary>
        /// URL字符编码
        /// </summary>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }
        #endregion


        /// 转全角的函数(SBC case)
        ///
        ///任意字符串
        ///全角字符串
        ///
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///
        public static string ToSBC(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (var c in input.ToCharArray())
            {
                sb.Append(ConvertDBCcaseToSBCcase(c));
            }
            return sb.ToString();
        }


        /*最大的有效全角英文字符转换成int型数据的值*/
        private const int MaxSbCcaseToInt = 65374;

        /*最小的有效全角英文字符转换成int型数据的值*/
        private const int MinSbCcaseToInt = 65281;

        /*最大的有效半角英文字符转换成int型数据的值*/
        private const int MaxDbCcaseToInt = 126;

        /*最小的有效半角英文字符转换成int型数据的值*/
        private const int MinDbCcaseToInt = 33;

        /*对应的全角和半角的差*/
        private const int Margin = 65248;

        /// <summary>
        /// 功能:将全角字符转换为半角字符
        /// version:1.0
        /// </summary>
        /// <param name="originalChar">要进行全角到半角转换的字符</param>
        /// <returns>全角字符转换为半角后的字符</returns>
        public static char ConvertSBCcaseToDBCcase(char originalChar)
        {
            /*空格是特殊的,其全角和半角的差值也与其他字符不同*/
            if (originalChar == '　')
            {
                return ' ';
            }
            if (originalChar >= MinSbCcaseToInt && originalChar <= MaxSbCcaseToInt)
            {
                return (char)(originalChar - Margin);
            }
            return originalChar;
        }


        /// <summary>
        /// 功能:半角转换为全角
        /// version:1.0
        /// </summary>
        /// <param name="originalChar">要进行半角到全角转换的字符</param>
        /// <returns>半角字符转换为全角后的字符</returns>
        public static char ConvertDBCcaseToSBCcase(char originalChar)
        {
            /*空格是特殊的,其全角和半角的差值也与其他字符不同*/
            if (originalChar == ' ')
            {
                return '　';
            }
            if (originalChar >= MinDbCcaseToInt && originalChar <= MaxDbCcaseToInt)
            {
                return (char)(originalChar + Margin);
            }
            return originalChar;
        }

        ///<summary>
        ///转半角的函数(DBC case) 
        ///任意字符串
        ///半角字符串 
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</summary>
        public static string ToDBC(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (var c in input.ToCharArray())
            { 
                sb.Append(ConvertSBCcaseToDBCcase(c)); 
            }
            return sb.ToString();
        }
    }
}
