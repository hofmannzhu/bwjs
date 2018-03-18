using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityHelper.Data
{
    /// <summary>
    /// SQL事物处理参数类
    /// 使用时需严格按照插入顺序设置队列
    /// 
    /// </summary>
    public class SqlTransactionParameter
    {
        /// <summary>
        /// 当前的表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 外键的名称
        /// 没有值的时候默认使用主键名称
        /// </summary>
        public string FKName { get; set; }
        /// <summary>
        /// SQL语句
        /// </summary>
        public string CommonText { get; set; }
        /// <summary>
        /// 主键是否是自动增长列,默认值：true,
        /// 用于判断是否给后续的队列中有需要前面插入返回的主键赋值
        /// </summary>
        public bool PkIsIdentity { get; set; }

        public bool IsUpdate { get; set; }

        /// <summary>
        /// 主键字段，多个主键的使用逗号(,)分隔
        /// </summary>
        public string PK { get; set; }

        /// <summary>
        /// 入参集合
        /// </summary>
        public List<SqlParameter> Parameters { get; set; }

        public SqlTransactionParameter()
        {
            PkIsIdentity = true;
            IsUpdate = false;
            Parameters = new List<SqlParameter>();
        }
    }
}
