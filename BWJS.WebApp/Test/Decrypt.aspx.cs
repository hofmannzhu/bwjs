using BWJS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Test
{
    public partial class Decrypt : System.Web.UI.Page
    {
        string PwdKey = LinkFun.getPwdKey();
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Password = TextBox1.Text;
          
            Password = DESEncrypt.Decrypt(PwdKey, Password);//解密
            Label1.Text = Password; 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string word = TextBox2.Text;
            word = DESEncrypt.Encrypt(PwdKey, word);//解密
            Label2.Text = word;
        }
    }
}