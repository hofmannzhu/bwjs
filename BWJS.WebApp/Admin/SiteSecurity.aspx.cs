using BWJS.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Admin
{
    public partial class SiteSecurity : AdminPage
    {
        /// <summary>
        /// 密钥必须为8位
        /// </summary>
        string secretKey = ConstantsConfig.secretKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtSecretKey.Text = secretKey;
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (CheckedAuthorize("7r1i6j"))
            {
                string plaintext = txtPlaintext.Text.Trim();
                secretKey = txtSecretKey.Text.Trim();
                if (!string.IsNullOrEmpty(plaintext) && !string.IsNullOrEmpty(secretKey))
                {
                    string ciphertext = DESEncrypt.Encrypt(secretKey, plaintext);
                    txtCiphertext.Text = ciphertext;
                    txtPlaintext.Text = string.Empty;
                }
            }
            else
            {
                litCiphertext.Text = "无权限";
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (CheckedAuthorize("6ppd8z"))
            {
                string ciphertext = txtCiphertext.Text.Trim();
                secretKey = txtSecretKey.Text.Trim();
                if (!string.IsNullOrEmpty(ciphertext) && !string.IsNullOrEmpty(secretKey))
                {
                    string plaintext = DESEncrypt.Decrypt(secretKey, ciphertext);
                    txtPlaintext.Text = plaintext;
                    txtCiphertext.Text = string.Empty;
                }
            }
            else
            {
                litPlaintext.Text = "无权限";
            }
        }
    }
}