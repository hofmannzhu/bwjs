using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityHelper
{
    public class SMSSendHelper
    {

        public string BaseUrl { get; set; }

        public string Name { get; set; }

        public string PassWord { get; set; }

        public SMSSendHelper(string baseUrl, string name, string pwd)
        {
            BaseUrl = baseUrl;
            Name = name;
            PassWord = pwd;
        }


        /// <summary>
        /// 获取Url
        /// </summary>
        /// <param name="sUrl"></param>
        /// <returns></returns>
        private string GetUrl(string sUrl)
        {
            var baseUrl = BaseUrl.Trim();
            //if (!baseUrl.EndsWith("/"))
            //{
            //}
            if (sUrl.StartsWith("/"))
                sUrl = sUrl.Substring(1);

            return baseUrl + sUrl;
        }

        /// <summary>
        /// 群发短信
        /// </summary>
        /// <param name="phones">手机号，多个"，"号分隔</param>
        /// <param name="msg">内容</param>
        public SMSSendResult GSend(string phones, string msg)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", this.Name);
            dic.Add("password", this.PassWord);
            dic.Add("phone", phones);
            dic.Add("message", System.Web.HttpUtility.UrlEncode(msg, System.Text.Encoding.GetEncoding("GB2312")));
            //dic.Add("time",DateTime.Now.ToString("yyyyMMddHHmmss"));


            HttpUtils httpUtils = new HttpUtils();
            var url = httpUtils.BuildGetUrl(GetUrl(""), dic);


            var result = httpUtils.DoGet(url, null);

            return new SMSSendResult(result);
        }



        public class SMSSendResult
        {
            ///// <summary>
            ///// 已成功提交短信条数
            ///// =0，为发送失败；>0，为正确结果，调用者应该根据此值唯一判断短信提交成功与否。
            ///// </summary>
            //public int Number { get; set; }

            ///// <summary>
            ///// 成功提交的手机号
            ///// 用英文逗号分割
            ///// </summary>
            //public string Success { get; set; }

            ///// <summary>
            ///// 发送失败的手机号
            ///// 用英文逗号分割
            ///// </summary>
            //public string Faile { get; set; }

            //public string Err { get; set; }


            //public string ErrID { get; set; }

            //public string Url { get; set; }

            public bool IsError { get; set; }

            public string Code { get; set; }

            public string Message
            {

                get
                {
                    switch (Code)
                    {
                        case "00": return "提交成功";
                        case "1": return "参数不完整";
                        case "2": return "鉴权失败";
                        case "3": return "号码数量超过50条";
                        case "4": return "发送失败";
                        case "5": return "余额不足";
                        case "6": return "发送内容含屏蔽字";
                        case "7": return "短信内容超过350个字";
                        case "8": return "号码列表中没有合法的手机号";
                        case "9": return "夜间管理，不允许一次提交超过20个号码";
                        case "72": return "内容被审核员屏蔽";
                        default: return Code;
                    }
                }
            }

            public SMSSendResult(string code)
            {
                Code = code;
            }

        }
    }
}
