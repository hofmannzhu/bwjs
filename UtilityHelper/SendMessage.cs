using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace UtilityHelper
{
    /// <summary>
    /// ��Ϣ��ʾ��
    /// </summary>
    public class SendMessage
    {
        public static void Alert(Page p, string msg)
        {
            msg = msg.Replace("\"", "\\\"").Replace("\r\n", "");
            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append("alert(\"" + msg + "\");");
            script.Append("</script>");
            if (!p.ClientScript.IsStartupScriptRegistered("Alert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "Alert", script.ToString());

            }
        }
        public static void Alert(Page p, string msg, string url)//��ʾ���ض���
        {
            msg = msg.Replace("\"", "\\\"").Replace("\r\n", "");
            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append("alert(\"" + msg + "\");");
            script.Append("window.location='" + url + "';");
            script.Append("</script>");
            if (!p.ClientScript.IsStartupScriptRegistered("Alert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "Alert", script.ToString());

            }
        }
        public static void Alert(Page p)
        {

            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append("alert(\"ϵͳ����:����ϵ����Աrosedean@126.com\");");
            script.Append("</script>");
            if (!p.ClientScript.IsStartupScriptRegistered("Alert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "Alert", script.ToString());

            }
        }
        public static void AlertAndClose(Page p, string msg)  //��ʾ��ر�
        {
            msg = msg.Replace("\"", "\\\"").Replace("\r\n", "");
            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append("alert(\"" + msg + "\");window.close();");
            script.Append("</script>");
            if (!p.ClientScript.IsStartupScriptRegistered("Alert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "Alert", script.ToString());

            }
        }
        public static void navgate(Page p, string url)
        {
            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append("window.location=\"" + url + "\";");
            script.Append("</script>");
            if (!p.ClientScript.IsStartupScriptRegistered("Alert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "Alert", script.ToString());

            }
        }
        public static void zxjs(Page p, string js)
        {
            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append(js);
            string zuih = js.Substring(js.Length - 1);
            if (js.Equals(";") == false)
            {
                script.Append(";");
            }
            //script.Append("window.close();");
            script.Append("</script>");
            if (!p.ClientScript.IsStartupScriptRegistered("Alert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "Alert", script.ToString());

            }
        }
        public static void closepage(Page p)
        {
            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append("opener.document.location.reload();");
            script.Append("window.close();");
            script.Append("</script>");
            if (!p.ClientScript.IsStartupScriptRegistered("Alert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "Alert", script.ToString());
            }
        }
        //ģ��Ի�����Ҫ����ymPrompt.�ʣ�֧��
        public static void ErrorAlert(Page p, string msg, string title)
        {
            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append("ymPrompt.errorInfo(\"" + msg + "\",null,null,\"" + title + "\",null);");
            script.Append("</script>");

            if (!p.ClientScript.IsStartupScriptRegistered("MnAlert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "MnAlert", script.ToString());

            }
        }
        //ģ��Ի�����Ҫ����ymPrompt.�ʣ�֧��
        public static void ErrorAlertlo(Page p, string msg, string title, string url)//ˢ��ҳ��
        {
            StringBuilder script = new StringBuilder();
            script.Append("<script language=javascript>");
            script.Append("ymPrompt.errorInfo(\"" + msg + "\",null,null,\"" + title + "\",null);window.location=\"" + url + "\";");
            script.Append("</script>");

            if (!p.ClientScript.IsStartupScriptRegistered("MnAlert"))
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "MnAlert", script.ToString());

            }
        }
        /// <summary>
        /// �ڿͻ���ִ��һ�νű���
        /// </summary>
        /// <param name="name">�ű����ʾ��</param>
        /// <param name="cmd">Ҫִ�е����</param>
        public static void JsExe(Page p, string name, string cmd)
        {
            if (name.IndexOf("before") != -1)
            {
                p.ClientScript.RegisterClientScriptBlock(p.GetType(), name, "<script type=\"text/javascript\">" + cmd + ";</script>");
            }
            else
            {
                //p.ClientScript.RegisterStartupScript(p.GetType(), name, "<script type=\"text/javascript\">" + cmd + ";</script>");
                p.ClientScript.RegisterClientScriptBlock(p.GetType(), name, cmd, true);
            }
        }
    }
}
