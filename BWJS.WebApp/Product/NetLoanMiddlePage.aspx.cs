using BWJS.BLL;
using BWJS.BLL.CookieMag;
using BWJS.Model;
using BWJSLog.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Product
{
    public partial class NetLoanMiddlePage : System.Web.UI.Page
    {
        public Company model = null;
        public int CompanyId = 0;
        public int NetLoanApplyId = 0;
        CompanyBLL opCompanyBLL = new CompanyBLL();
        CompanyRelationBLL oCompanyRelationBLL = new CompanyRelationBLL();
        public string QRImg = string.Empty;
        public int QRType = 0, openTypeQR = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyId = DNTRequest.GetInt("CompanyId", 0);
            openTypeQR = DNTRequest.GetInt("openTypeQR", 0);
            NetLoanApplyId = DNTRequest.GetInt("NetLoanApplyId", 0);
            if (CompanyId <= 0)
            {
                Response.Redirect("/Product/Index?wd=0");
            }
            try
            {
                int UserId = MerchantFrontCookieBLL.GetMerchantFrontUserId();
                CompanyRelation relationModel = oCompanyRelationBLL.GetModel(CompanyId, UserId);//获取商家(只能给多个二维码的)二维码
                if (relationModel != null)
                {
                    QRImg = relationModel.QRCode;
                    if (string.IsNullOrEmpty(QRImg))
                    {
                        if (!string.IsNullOrEmpty(relationModel.API))
                        {
                            string imgName = relationModel.CompanyRelationId + "_" + relationModel.CompanyId.ToString() + "_" + UserId.ToString();//组合文件名格式：渠道扩展编号加横杆加渠道编号
                            QRImg = GetQRImg(relationModel.API, imgName, "", "");
                        }
                    }
                }
                else
                {
                    model = opCompanyBLL.GetModel(CompanyId);
                    if (model != null)
                    {
                        if (!string.IsNullOrEmpty(model.QRCode))
                        {
                            QRImg = model.QRCode;
                        }
                        else
                        {
                            string url = string.Empty;
                            string referralCode = string.Empty;
                            string imgName = string.Empty;
                            if (!model.IsAPK)
                            {
                                QRType = 0;
                                url = model.API;
                                if (model.IsRelyOnPrimaryKey == 1)
                                {
                                    string prefix = model.RecommendationPrefix;
                                    int maxlength = model.RecommendationLength;
                                    referralCode = prefix + "-" + UserId.ToString() + "-" + NetLoanApplyId.ToString().PadLeft(maxlength, '0');
                                }
                                else {
                                    referralCode = model.RecommendationCode;
                                }
                                if (url.IndexOf("{0}") > 0)
                                {
                                    url = string.Format(url, referralCode);
                                }
                                //if (!string.IsNullOrEmpty(model.ReplaceUrlParam))
                                //{
                                //    url = WebUtils.ReplaceUrlParamValue(model.API, model.ReplaceUrlParam, referralCode);
                                //}
                            }
                            else
                            {
                                QRType = 1;
                                string domain = LinkFun.getBWJSDomain();
                                url = domain + "/Product/NetLoanMiddlePage.aspx?openTypeQR=" + QRType + "&CompanyId=" + CompanyId;
                            }
                            imgName = model.CompanyId.ToString() + "_" + UserId;//渠道编号加下划线加经销商编号
                            QRImg = GetQRImg(url, imgName, model.Logo, "");
                        }
                    }
                }
                if (!string.IsNullOrEmpty(QRImg))//追加时间戳
                {
                    if (QRImg.IndexOf("?") == -1)
                        QRImg += string.Format("?{0}={1}", "times", DateTime.Now.ToFileTime());
                    else
                        QRImg += string.Format("&{0}={1}", "times", DateTime.Now.ToFileTime());
                }
            }
            catch (Exception ex) { ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString()); }
        }
        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="url"></param>
        /// <param name="imgName"></param>
        /// <param name="logoImg"></param>
        /// <param name="logoPath"></param>
        /// <returns></returns>
        public string GetQRImg(string url, string imgName, string logoImg, string logoPath)
        {
            QRHelper qr = new QRHelper();
            string qrurl = url;
            int scale = 5;
            int version = 0;
            int size = 600;
            int border = 5;
            if (string.IsNullOrEmpty(logoImg) || QRType == 1)
            {
                logoImg = "/Content/img/cqg.png";
            }
            return qr.CCLCreateQR_Member(qrurl, "/Upload/CompanyQR/", imgName, logoImg, scale, version, size, border, "");
        }
    }
}