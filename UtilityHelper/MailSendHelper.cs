using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UtilityHelper
{
    /// <summary>
    /// 邮件发送类
    /// </summary>
    public class MailSendHelper : SmtpClient
    {
        public SendCompletedEventHandler SendCompleted { get; set; }

        /// <summary>
        /// 发送者
        /// </summary>
        public string Sender { get; set; }
        public MailSendHelper(string sender, string userName, string password, string host, bool enableSsl = false, int port = 25)
            : base(host, port)
        {
            this.Sender = sender;
            this.Credentials = new NetworkCredential(userName, password);
            this.EnableSsl = enableSsl;
         }
 

        /// <summary>
        /// 给多人发送邮件
        /// </summary>
        /// <param name="toArray">收件人集合</param>
        /// <param name="subject">主题</param>
        /// <param name="body">正文</param>
        /// <param name="isBodyHtml">正文是否是html</param>
        public void Send(IEnumerable<string> toArray,string subject,string body,bool isBodyHtml = false,string[] files = null,IEnumerable<string> ccArray = null)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.Sender);
            message.Subject = subject;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = body;
            if (ccArray != null)
            {
                 foreach (var cc in ccArray)
                {
                    message.CC.Add(new MailAddress(cc));
                }
                
            }
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = isBodyHtml;
            if (files != null)
            {
                foreach (var file in files)
                    message.Attachments.Add(new Attachment(file));
            }
            foreach (var to in toArray)
            {
                message.To.Add(new MailAddress(to));
            }
            
            this.Send(message);
        }
    }
}
