using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJSLog.Model
{

    /// <summary>
    /// 设备登录日志
    /// </summary>
    [Serializable]
    public partial class MachineLocationLog
    {
        #region BasicModel
        /// <summary>
        /// 设备位置信息日志编号
        /// </summary>		
        [DataMember]
        public int MachineLocationLogId
        {
            get;
            set;
        }
        /// <summary>
        /// 用户编号
        /// </summary>		
        [DataMember]
        public int? UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 设备编号
        /// </summary>		
        [DataMember]
        public int? MachineId
        {
            get;
            set;
        }
        /// <summary>
        /// IP地址
        /// </summary>		
        [DataMember]
        public string IP
        {
            get;
            set;
        }
        /// <summary>
        /// mac地址
        /// </summary>		
        [DataMember]
        public string MAC
        {
            get;
            set;
        }
        /// <summary>
        /// 纬度
        /// </summary>		
        [DataMember]
        public string Latitude
        {
            get;
            set;
        }
        /// <summary>
        /// 经度
        /// </summary>		
        [DataMember]
        public string Longitude
        {
            get;
            set;
        }
        /// <summary>
        /// 百度地址解析
        /// </summary>		
        [DataMember]
        public string LocationAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 百度地址解析xml
        /// </summary>		
        [DataMember]
        public string LocationData
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
        /// 是否删除
        /// </summary>		
        [DataMember]
        public int IsDeleted
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>		
        [DataMember]
        public string Remark
        {
            get;
            set;
        }
        #endregion Model

        #region ExtensionModel

        #endregion
    }
}
