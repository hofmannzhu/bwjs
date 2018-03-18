using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLHelper
{
    /// <summary>
    /// SQL错误消息类
    /// </summary>
    public class SqlErrorMessage
    {
        /// <summary>
        /// SQL语句
        /// </summary>
        public string CommonText { get; set; }

        /// <summary>
        /// 入参集合
        /// </summary>
        public List<SqlParameter> Parameters { get; set; }

        /// <summary>
        /// 是否有错误
        /// </summary>
        public bool IsError { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 对应的异常
        /// </summary>
        public Exception Ex { get; set; }

        public SqlErrorMessage()
        {
            Parameters = new List<SqlParameter>();
        }
    }
}
