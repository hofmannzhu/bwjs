using UtilityHelper;
using BWJS.SMS.HuaXinSMS;
using BWJSLog.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWJSLog.Model;

namespace BWJS.SMS
{
    /// <summary>
    /// 华信短信发送接口
    /// </summary>
    public partial class SmsHelper
    {
        /*
            北京创世华信科技有限公司
            地址： 北京市朝阳区东三环南路联合国际大厦甲段12层
            网址：www.ipyy.com      
            售后服务：010-57135000
            接口说明：客户接口部分提供http 和 WebService（目前只支持提交短信） 方式的接口，客户可以根据需求选择相应接口，接口编码方式默认采用UTF-8
            短信平台客户端地址：http://c.ipyy.net（近期将会升级，如果访问不通请使用https://c.ipyy.net）
            发送规则:
            同一个号码，发送内容带有（验证码），3分钟之内只能3条，
            超过3条，系统会默认为（恶意注册）
            同一个号码，系统默认一天之内只能发送10条信息，超过
            10条会超限失败（特殊号码、或特殊客户需要找客服处理）
            注：短信计费条数跟短信的字数有关，一般的短信70个字计费一条。超过70个字就划分为长短信，67个字计费一条，例如；71字的短信就是长短信计费2条，134个字也是计费2条（67*2）。135个字计费3条，依次类推。
            SendI18NSms 
            国际短信发送
            SendMms 
            发送彩信接口
            SendSms 
            发送短信接口

            userName	    发送用户帐号	用户帐号，由系统管理员
            password	    发送帐号密码	
            sms	            短信参数对象	SmsObject结构，详见下面说明
            Msisdns	        全部被叫号码	发信发送的目的号码.多个号码之间用半角逗号隔开 
            SMSContent	    发送内容	    短信的内容，内容需要UTF-8编码，提交内容格式：内容+【签名】。签名是公司的名字或者公司项目名称。示例：您的验证码：1439【腾飞】。【】是签名的标识符。请按照正规的格式提交内容测试，请用正规内容下发，最好不要当成是测试，就当是正式使用在给自己的客户发信息，签名字数3-8个字 
            PlanSendTime	定时发送时间	为空表示立即发送，定时发送格式2010-10-24T 09:08:10
            ExtNumber	    扩展子号	    请先询问配置的通道是否支持扩展子号，如果不支持，请填空。子号只能为数字，且最多5位数。

            返回值
            StatusCode	    发送的状态代码	OK表示成功，其它为失败，参见最后的错误代码表。
            Description	    发送说明	    发送结果状态操作说明 
            MsgId	        任务ID	        提交短信的任务批次
            Amount	        当前余额	    当前账户的余额
            SuccessCounts	成功的号码数量	成功的号码数量
            BillingCount	消费的条数	    消费的条数值
            Errors	        错误描述	    本次发送中，相关的错误描述
        */


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="msisdns">发信发送的目的号码.多个号码之间用半角逗号隔开</param>
        /// <param name="smsContent">短信的内容，内容需要UTF-8编码，提交内容格式：内容+【签名】。签名是公司的名字或者公司项目名称。示例：您的验证码：1439【腾飞】。【】是签名的标识符。请按照正规的格式提交内容测试，请用正规内容下发，最好不要当成是测试，就当是正式使用在给自己的客户发信息，签名字数3-8个字 </param>
        /// <param name="planSendTime">定时发送时间	为空表示立即发送，定时发送格式2010-10-24T 09:08:10</param>
        /// <param name="extNumber">扩展子号 请先询问配置的通道是否支持扩展子号，如果不支持，请填空。子号只能为数字，且最多5位数</param>
        /// <returns>发送结果</returns>
        static public string DoSend(string msisdns, int? smsTemplateId, string smsContent, DateTime? planSendTime, string extNumber)
        {
            string result = string.Empty;
            try
            {
                DateTime CreateDate = DateTime.Now;
                string userName = CommonHelper.GetAppSettingsValue("smsUserName", "AA01177");
                string password = CommonHelper.GetAppSettingsValue("smsPass", "AA0117706");
                string apiPass = CommonHelper.GetAppSettingsValue("apiPass", "AA0117755");

                SmsObject smsObj = new SmsObject();
                smsObj.Msisdns = msisdns;
                smsObj.SMSContent = smsContent;
                smsObj.PlanSendTime = planSendTime;
                smsObj.ExtNumber = extNumber;

                WebServiceSoapClient op = new WebServiceSoapClient();
                SendResult rlt = op.SendSms(userName, apiPass, smsObj);

                result = FormatResult(rlt);

                SmsSendLogBLL opSmsSendLogBLL = new SmsSendLogBLL();
                SmsSendLog modelSmsSendLog = new SmsSendLog();
                modelSmsSendLog.SmsTemplateId = smsTemplateId;
                modelSmsSendLog.SendType = ((planSendTime == null) ? (1) : (2));
                modelSmsSendLog.SmsContent = smsContent;
                modelSmsSendLog.Mobile = msisdns;
                if (rlt.StatusCode == ResultCode.OK)
                {
                    modelSmsSendLog.Status = 1;
                }
                else
                {
                    modelSmsSendLog.Status = 0;
                }
                modelSmsSendLog.IsDeleted = 0;
                modelSmsSendLog.CreateDate = CreateDate;
                modelSmsSendLog.SendDate = DateTime.Now;
                modelSmsSendLog.SendResult = result;
                int res = opSmsSendLogBLL.Add(modelSmsSendLog);

            }
            catch (Exception ex)
            {
                result = ex.Message;
                ExceptionLogBLL.WriteExceptionLogToDB("发送短信接口：" + ex.ToString());
            }
            return result;
        }

        static private string FormatResult(SendResult result)
        {
            //var sb = new StringBuilder();
            //sb.AppendFormat("发送的状态:{0}{1}", result.StatusCode, Environment.NewLine);
            //sb.AppendFormat("发送说明:{0}{1}", result.Description, Environment.NewLine);
            //sb.AppendFormat("提交短信的任务批次:{0}{1}", result.MsgId, Environment.NewLine);
            //sb.AppendFormat("账户的余额:{0}{1}", result.Amount, Environment.NewLine);
            //sb.AppendFormat("成功的号码数量:{0}{1}", result.SuccessCounts, Environment.NewLine);
            //sb.AppendFormat("消费的条数值:{0}{1}", result.BillingCount, Environment.NewLine);
            //sb.AppendFormat("错误描述:{0}{1}", result.Errors, Environment.NewLine);

            Hashtable ht = new Hashtable();
            ht.Add("发送状态", result.StatusCode);
            ht.Add("发送说明", result.Description);
            ht.Add("提交短信的任务批次", result.MsgId);
            ht.Add("账户的余额", result.Amount);
            ht.Add("成功的号码数量", result.SuccessCounts);
            ht.Add("消费的条数值", result.BillingCount);
            ht.Add("描述", result.Errors);

            string resultJson = Newtonsoft.Json.JsonConvert.SerializeObject(ht);
            return resultJson;
        }
    }
}
