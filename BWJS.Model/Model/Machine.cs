using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BWJS.Model
{
	/// <summary>
	/// 设备表
    /// </summary>	
    [Serializable]
	public partial class Machine
	{

        
        /// <summary>
        /// 厂商编号
        /// </summary>		
        [DataMember]
        public int MachineSupplierId
        {
            get;
            set;
        }
        /// <summary>
        /// 设备自增编号
        /// </summary>		
        [DataMember]
        public int MachineID
        {
            get;
            set;
        }
        /// <summary>
        /// 商户编号Users外键UserType=2的类型
        /// </summary>		
        [DataMember]
        public int UserID
        {
            get;
            set;
        }
        /// <summary>
        /// 设备号(前缀+8位偏移量数字)
        /// </summary>		
        [DataMember]
        public string SN
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
        /// 设备所在地
        /// </summary>		
        [DataMember]
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// 状态：1正常 0冻结
        /// </summary>		
        [DataMember]
        public int Status
        {
            get;
            set;
        }
        /// <summary>
        /// 远程TeamViewer号
        /// </summary>		
        [DataMember]
        public string TeamViewerNumber
        {
            get;
            set;
        }
        /// <summary>
        /// 远程TeamViewer密码
        /// </summary>		
        [DataMember]
        public string TeamViewerPwd
        {
            get;
            set;
        }
        /// <summary>
        /// 随机生成激活码(数字+字母)待定几位
        /// </summary>		
        [DataMember]
        public string ActivationCode
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
        /// 代理编号Users外键UserType=3的类型
        /// </summary>		
        [DataMember]
        public int AgentId
        {
            get;
            set;
        }
        /// <summary>
        /// 代理人姓名
        /// </summary>		
        [DataMember]
        public string AgentName
        {
            get;
            set;
        }
        /// <summary>
        /// 业务主管编号
        /// </summary>		
        [DataMember]
        public int SupervisorId
        {
            get;
            set;
        }
        /// <summary>
        /// 业务主管姓名
        /// </summary>		
        [DataMember]
        public string SupervisorName
        {
            get;
            set;
        }
        /// <summary>
        /// 业务员编号
        /// </summary>		
        [DataMember]
        public int SalesmanId
        {
            get;
            set;
        }
        /// <summary>
        /// 业务员姓名
        /// </summary>		
        [DataMember]
        public string SalesmanName
        {
            get;
            set;
        }
        /// <summary>
        /// 平台类型
        /// </summary>		
        [DataMember]
        public string Platform
        {
            get;
            set;
        }
        /// <summary>
        /// 平板设备号
        /// </summary>		
        [DataMember]
        public string FlatDeviceNumber
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
    }
}

