using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model{
	    /// <summary>
    /// 职业信息
    /// </summary>
	    [Serializable]
	public partial class NL_ProfessionInfo
    {
        #region BasicModel
        /// <summary>
        /// 网贷申请编号
        /// </summary>
        [DataMember]
        public int ConsultId
        {
            set;
            get;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string FullName
        {
            set;
            get;
        }
        /// <summary>
        /// 年龄
        /// </summary>
        [DataMember]
        public int? Age
        {
            set;
            get;
        }
        /// <summary>
        /// 月收入1500-2499元,2500-3499元,3500-5000元,5000-8000元,8000元以上
        /// </summary>
        [DataMember]
        public int? MonthlyIncome
        {
            set;
            get;
        }
        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string Company
        {
            set;
            get;
        }
        /// <summary>
        /// 单位性质政府单位/公务员,事业制单位,上市企业,普通民营企业
        /// </summary>
        [DataMember]
        public int? UnitNature
        {
            set;
            get;
        }
        /// <summary>
        /// 单位工作时间不满6个月,6-12个月,12-24个月,24个月以上
        /// </summary>
        [DataMember]
        public int? WorkingHour
        {
            set;
            get;
        }
        /// <summary>
        /// 工资发放形式现金发放,银行转账,银行代发
        /// </summary>
        [DataMember]
        public int? Payroll
        {
            set;
            get;
        }
        /// <summary>
        /// 职业身份上班族，生意族，企业族
        /// </summary>
        [DataMember]
        public int? JobPosition
        {
            set;
            get;
        }
        /// <summary>
        /// 社保没有；有，购买不满6个月；有，已购买6-12个月；有，已购买12个月以上；
        /// </summary>
        [DataMember]
        public int? SocialSecurit
        {
            set;
            get;
        }
        /// <summary>
        /// 公积金没有；有，购买不满6个月；有，已购买6-12个月；有，已购买12个月以上；
        /// </summary>
        [DataMember]
        public int? Fund
        {
            set;
            get;
        }
        /// <summary>
        /// 学历初中以下学历,高中/中专,大专,本科,硕士/博士
        /// </summary>
        [DataMember]
        public int? Degree
        {
            set;
            get;
        }
        /// <summary>
        /// 毕业年份1年,2年,3年,5年以上
        /// </summary>
        [DataMember]
        public int? GraduationYear
        {
            set;
            get;
        }
        #endregion BasicModel

        #region ExtensionModel

        #endregion
    }
}