using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace XBWN.DAL
{
    public class BaseService
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private readonly string _connectionString;
        static string secretKey = ConstantsConfig.secretKey;
        protected BaseService(string conn = "BWJSConn")
        {
            _connectionString = CommonHelper.GetConfigValue(conn);
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new KeyNotFoundException("BWJSConn节点没有找到或者其值不能为空！");
            }
            string conStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (!string.IsNullOrEmpty(conStringEncrypt))
            {
                if (conStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(secretKey, _connectionString);
                }
            }

        }
        /// <summary>
        /// 数据库连接配置
        /// </summary>
        protected string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }
    }
}
