using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BWJS.Model
{
    /// <summary>
    /// 会员表
    /// </summary>	
    [Serializable]
    public partial class Users
    {
        #region Model

        /// <summary>
        /// 用户ID
        /// </summary>		
        [DataMember]
        public int UserID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户名（用手机号）
        /// </summary>		
        [DataMember]
        public string LoginName
        {
            get;
            set;
        }
        /// <summary>
        /// 密码
        /// </summary>		
        [DataMember]
        public string Password
        {
            get;
            set;
        }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        [DataMember]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// 性别 1男0女
        /// </summary>		
        [DataMember]
        public string Sex
        {
            get;
            set;
        }
        /// <summary>
        /// 电话
        /// </summary>		
        [DataMember]
        public string Phone
        {
            get;
            set;
        }
        /// <summary>
        /// QQ号
        /// </summary>		
        [DataMember]
        public string QQ
        {
            get;
            set;
        }
        /// <summary>
        /// 微信号
        /// </summary>		
        [DataMember]
        public string Wechat
        {
            get;
            set;
        }
        /// <summary>
        /// 邮箱
        /// </summary>		
        [DataMember]
        public string Email
        {
            get;
            set;
        }
        /// <summary>
        /// 用户类型，暂定1管理员 2商家3代理商
        /// </summary>		
        [DataMember]
        public int UserType
        {
            get;
            set;
        }
        /// <summary>
        /// 用户头像
        /// </summary>		
        [DataMember]
        public string GravatarResourceID
        {
            get;
            set;
        }
        /// <summary>
        /// 最后访问IP
        /// </summary>		
        [DataMember]
        public string LastAccessIP
        {
            get;
            set;
        }
        /// <summary>
        /// 商家名称
        /// </summary>		
        [DataMember]
        public string CompanyName
        {
            get;
            set;
        }
        /// <summary>
        /// CreatUserID
        /// </summary>		
        [DataMember]
        public int CreatUserID
        {
            get;
            set;
        }
        /// <summary>
        /// RecordUpdateUserID
        /// </summary>		
        [DataMember]
        public int RecordUpdateUserID
        {
            get;
            set;
        }
        /// <summary>
        /// RecordIsDelete
        /// </summary>		
        [DataMember]
        public bool RecordIsDelete
        {
            get;
            set;
        }
        /// <summary>
        /// RecordUpdateTime
        /// </summary>		
        [DataMember]
        public DateTime RecordUpdateTime
        {
            get;
            set;
        }
        /// <summary>
        /// RecordCreateTime
        /// </summary>		
        [DataMember]
        public DateTime RecordCreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证号
        /// </summary>		
        [DataMember]
        public string CardID
        {
            get;
            set;
        }
        /// <summary>
        /// 区域编号
        /// </summary>		
        [DataMember]
        public int ReginId
        {
            get;
            set;
        }
        /// <summary>
        /// 锁定状态0正常1锁定
        /// </summary>		
        [DataMember]
        public int IsLocked
        {
            get;
            set;
        }
        /// <summary>
        /// 登录状态0未登录1已登录
        /// </summary>		
        [DataMember]
        public int IsLogined
        {
            get;
            set;
        }
        /// <summary>
        /// 登录次数
        /// </summary>		
        [DataMember]
        public int LoginTimes
        {
            get;
            set;
        }
        /// <summary>
        /// 所在省
        /// </summary>		
        [DataMember]
        public int ProvinceID
        {
            get;
            set;
        }
        /// <summary>
        /// 所在市
        /// </summary>		
        [DataMember]
        public int CityID
        {
            get;
            set;
        }
        /// <summary>
        /// 所在区县
        /// </summary>		
        [DataMember]
        public int CountyID
        {
            get;
            set;
        }
        /// <summary>
        /// 详细地址
        /// </summary>		
        [DataMember]
        public string Address
        {
            get;
            set;
        }
        [DataMember]
        public int DepartmentID
        {
            get;
            set;
        }

        #endregion

        #region ModelExpand

        /// <summary>
        /// 设备编号
        /// </summary>		
        [DataMember]
        public string EquipmentNo
        {
            get;
            set;
        }
        /// <summary>
        /// 所属商户编号
        /// </summary>		
        [DataMember]
        public string SId
        {
            get;
            set;
        }
        #endregion
    }
}

