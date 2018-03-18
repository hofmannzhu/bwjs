using MofangInterface.BLL;
using MofangInterface.Model.InputModel;
using MofangInterface.Model.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MofangInterface.Model;
using UtilityHelper;
using BWJS.AppCode;

namespace BWJS.WebApp.Mofang
{
    public partial class ProductDetail : BasePage
    {
        public ProductDetailsResp detailModel = new ProductDetailsResp();
        /// <summary>
        /// Mofang.Products表主键编号
        /// </summary>
        public int productId = 0;
        public string caseCode = string.Empty;
        public string transNo = string.Empty;
        public bool isGotoNoticeInsurance = false;//是否直接跳到承保添加页面 
        public bool isJBBERestrictGenes = false;
        public bool isYQHWMZRestrictGenes = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            BaoxianDataBLL bll = new BaoxianDataBLL();
            if (!Page.IsPostBack)
            {
                productId = DNTRequest.GetInt("productId", 0);
                //caseCode = UtilityHelper.BWJSCommonHelper.SafeString(Request["caseCode"], "0001077178502139");
                caseCode = DNTRequest.GetString("caseCode");
                if (!string.IsNullOrWhiteSpace(caseCode))
                {
                    try
                    {
                        ProductDetailsReq req = new ProductDetailsReq(); 

                        transNo = req.transNo = UtilityHelper.CommonHelper.OrderNoOne();
                        req.caseCode = caseCode;

                        
                        detailModel = bll.GetProductDetails(req);
                        if (detailModel == null)
                        {
                            detailModel = new ProductDetailsResp();
                        }
                    }
                    catch
                    { }
                    switch (caseCode)
                    {
                        case "0001077178502139":
                            isGotoNoticeInsurance = true;
                            isJBBERestrictGenes = true;//JBBE 有基本保额，首字母
                            break;
                        case "0001077178602140":
                            isGotoNoticeInsurance = true;
                            isJBBERestrictGenes = true;//JBBE 有基本保额，首字母
                            break;
                        case "0000052178002133"://“账户保”个人账户资金安全险
                            isJBBERestrictGenes = true;//JBBE 有基本保额，首字母
                            break;
                        case "0001076209802609"://一起慧99-百万医疗保险 无门诊计划
                            isGotoNoticeInsurance = true;
                            isYQHWMZRestrictGenes = true;//YQHWMZ 一起慧无门诊首字母 
                            isJBBERestrictGenes = true;//JBBE 有基本保额，首字母
                            break;
                        case "0001076211102627"://一起慧99-百万医疗保险 无门诊计划
                            isGotoNoticeInsurance = true;
                            isYQHWMZRestrictGenes = true;//YQHWMZ 一起慧无门诊首字母 
                            isJBBERestrictGenes = true;//JBBE 有基本保额，首字母
                            break;
                        case "0001075190802342"://少儿住院宝
                            isGotoNoticeInsurance = true; 
                            break;
                            
                    }
                }
                else
                {
                    Response.Redirect("/Product/Index.aspx?wd=0");
                }

            }
        }
        public string restrictGenes(RestrictDictionary oRestrictDictionary, RestrictGene oRestrictGene)
        {
            int minValue = 0, MaxValue = 0, step = 0;
            string strValue = oRestrictDictionary.value;
            string[] array = strValue.Split('-');
            minValue = UtilityHelper.BWJSCommonHelper.SafeInt(array[0], 0);
            MaxValue = UtilityHelper.BWJSCommonHelper.SafeInt(array[1], 0);
            step = oRestrictDictionary.step;

            StringBuilder bulider = new StringBuilder();
            for (int j = minValue; j <= MaxValue; j = j + step)
            {
                if (!string.IsNullOrWhiteSpace(oRestrictGene.defaultValue))
                {
                   
                        bulider.AppendLine("<option  " + GetDefalutSelected(oRestrictGene.defaultValue, j + oRestrictDictionary.unit) + " value = '" + j + "'   unit='" + oRestrictDictionary.unit + "' >");
                        bulider.Append(j + oRestrictDictionary.unit);
                        bulider.Append("</option >");
                    
                }
                   
               
            }
            return bulider.ToString();
        }

        public string GetRestrictGenesList()
        {
            if (detailModel.restrictGenes != null)
            {
                StringBuilder bulider = new StringBuilder();
                for (int i = 0; i < detailModel.restrictGenes.Count; i++)
                {
                    RestrictGene oRestrictGene = detailModel.restrictGenes[i];
                    RestrictDictionary oRestrictDictionary = oRestrictGene.values[0];

                    bulider.Append("<div> 名称：" + oRestrictGene.name + "</div><div>");
                    if (oRestrictGene.name == "基本保额")
                    {
                        bulider.AppendLine(" <select id='jibenbaoe' name='jibenbaoe'  key='" + oRestrictGene.key + "' sort='" + oRestrictGene.sort + "' protectItemId='" + oRestrictGene.protectItemId + "'>");
                    }
                    else
                    {
                        bulider.Append(" <select id = \"" + oRestrictGene.key + "\" name = \"" + oRestrictGene.key + "\" key='" + oRestrictGene.key + "' sort='" + oRestrictGene.sort + "' >");
                    }
                    for (int c = 0; c < oRestrictGene.values.Count; c++)
                    {
                        if (oRestrictGene.values[c].type == "1")
                        {
                            string unit = oRestrictGene.values[c].unit;
                            bulider.Append(" <option value ='" + oRestrictGene.values[c].value + "' unit='" + unit + "' " + GetDefalutSelected(oRestrictGene.defaultValue, oRestrictGene.values[c].value + unit) + ">" + oRestrictGene.values[c].value + unit + "</option>");
                        }
                        else if (oRestrictGene.values[c].type == "2")
                        {
                            oRestrictDictionary = oRestrictGene.values[c];
                            bulider.Append(restrictGenes(oRestrictDictionary, oRestrictGene));
                        }
                    }
                    bulider.Append(" </select></div> ");


                }
                return bulider.ToString();
            }
            return string.Empty;
        }
        public string GetPriceArgs(List<genes> oListgenes)
        {
            return Utils.base64Encode(SerializerHelper.ToJson(oListgenes));
        }
        public string GetDefalutSelected(string defaultValue, string dataValue)
        {
            if (!string.IsNullOrEmpty(defaultValue))
            {
                if (defaultValue.Equals(dataValue))
                {
                    return "selected = 'selected'";
                } 
            }
            return ""; 
        }
    }

}