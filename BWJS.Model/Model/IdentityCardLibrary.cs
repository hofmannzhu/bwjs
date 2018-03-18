using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 身份证号码库
    /// </summary>
    [Serializable]
    public partial class IdentityCardLibrary
    {
        #region Basic

        /// <summary>
        /// 身份证号码库编号
        /// </summary>		
        [DataMember]
        public int IdentityCardLibraryId
        {
            get;
            set;
        }
        /// <summary>
        /// 数据来源
        /// </summary>		
        [DataMember]
        public int CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证号码
        /// </summary>		
        [DataMember]
        public string IdentityCardNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名
        /// </summary>		
        [DataMember]
        public string FullName
        {
            get;
            set;
        }
        /// <summary>
        /// 性别
        /// </summary>		
        [DataMember]
        public int Sex
        {
            get;
            set;
        }
        /// <summary>
        /// 民族
        /// </summary>		
        [DataMember]
        public string Nation
        {
            get;
            set;
        }
        /// <summary>
        /// 生日
        /// </summary>		
        [DataMember]
        public DateTime? BirthDay
        {
            get;
            set;
        }
        /// <summary>
        /// 地址
        /// </summary>		
        [DataMember]
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// 签发地
        /// </summary>		
        [DataMember]
        public string IssuedAt
        {
            get;
            set;
        }
        /// <summary>
        /// 生效日期
        /// </summary>		
        [DataMember]
        public DateTime? EffectedDate
        {
            get;
            set;
        }
        /// <summary>
        /// 失效日期
        /// </summary>		
        [DataMember]
        public DateTime? ExpiredDate
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证照片
        /// </summary>		
        [DataMember]
        public byte[] IdentityCardPhoto
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证照片路径
        /// </summary>		
        [DataMember]
        public string IdentityCardPhotoPath
        {
            get;
            set;
        }
        /// <summary>
        /// jpg格式头像的Base64编码
        /// </summary>		
        [DataMember]
        public string IdentityCardPhotoData
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证扫描信息
        /// </summary>		
        [DataMember]
        public string IdentityCardData
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展字段1
        /// </summary>		
        [DataMember]
        public string ExtendedField1
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展字段2
        /// </summary>		
        [DataMember]
        public string ExtendedField2
        {
            get;
            set;
        }
        /// <summary>
        /// 扩展字段3
        /// </summary>		
        [DataMember]
        public string ExtendedField3
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>		
        [DataMember]
        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 建档人编号
        /// </summary>		
        [DataMember]
        public int CreateId
        {
            get;
            set;
        }
        /// <summary>
        /// 建档日期
        /// </summary>		
        [DataMember]
        public DateTime CreateDate
        {
            get;
            set;
        }
        /// <summary>
        /// 修改人编号
        /// </summary>		
        [DataMember]
        public int EditId
        {
            get;
            set;
        }
        /// <summary>
        /// 修改日期
        /// </summary>		
        [DataMember]
        public DateTime? EditDate
        {
            get;
            set;
        }
        /// <summary>
        /// 是否删除
        /// </summary>		
        [DataMember]
        public int IsDeleted
        {
            get;
            set;
        }
        #endregion
    }
}
