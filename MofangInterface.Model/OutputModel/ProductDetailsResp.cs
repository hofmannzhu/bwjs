using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    /// <summary>
    /// 产品详情信息响应
    /// </summary>
    public class ProductDetailsResp
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        public string respstat { get; set; }

        /// <summary>
        /// 返回状态
        /// </summary>
        public string respmsg { get; set; }

        #region 1.4文档中不包含所以注释掉
        ///// <summary>
        ///// 主条款
        ///// </summary>
        //public List<ProductTerm> mainProductTerms { get; set; }

        ///// <summary>
        ///// 附加条款
        ///// </summary>
        //public List<ProductTerm> additionalProductTerms { get; set; }

        ///// <summary>
        ///// 索赔方式
        ///// </summary>
        //public List<ProductTerm> claimTypes { get; set; } 
        #endregion

        /// <summary>
        /// 产品特色
        /// </summary>
        public List<ProductFeature> features { get; set; }


        /// <summary>
        /// 常见问题
        /// </summary>
        public List<CommonQuestion> commonQuestions { get; set; }

        /// <summary>
        /// 试算因子
        /// </summary>
        public List<RestrictGene> restrictGenes { get; set; }

        /// <summary>
        /// 保障项目
        /// </summary>
        public List<ProtectItem> protectItems { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// 产品试算信息
        /// </summary>
        public string priceArgsId { get; set; }

    

    }

    /// <summary>
    /// 产品特色
    /// </summary>
    public class ProductFeature
    {
        public int dataType { get; set; }


        public string content { get; set; }

        public string pic { get; set; }

    }

    /// <summary>
    /// 保障项目
    /// </summary>
    public class ProtectItem
    {
        /// <summary>
        /// 保障项id
        /// </summary>
        public int protectItemId { get; set; }

        /// <summary>
        /// 序列号、顺序值(升序排序)
        /// </summary>
        public int sort { get; set; }

        /// <summary>
        /// 保障项目名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 默认显示值
        /// </summary>
        public string defaultValue { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
    }

    /// <summary>
    /// 常见问题
    /// </summary>
    public class CommonQuestion
    {
        /// <summary>
        /// 问题
        /// </summary>
        public string question { get; set; }

        /// <summary>
        /// 答案
        /// </summary>
        public string answer { get; set; }

    }

    /// <summary>
    /// 主条款
    /// </summary>
    public class ProductTerm
    {
        /// <summary>
        /// 条款名称
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string attachmentUrl { get; set; }

        /// <summary>
        ///  条款内容
        /// </summary>
        public string content { get; set; }

    } 
}
