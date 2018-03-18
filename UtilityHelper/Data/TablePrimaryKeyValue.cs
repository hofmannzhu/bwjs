using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityHelper.Data
{
    public class TablePrimaryKeyValue
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 主键名称
        /// </summary>
        public string PkName { get; set; }

        /// <summary>
        /// 主键值
        /// </summary>
        public object PkValue { get; set; }

        /// <summary>
        /// 表索引，用于区分同一个表多个的情况
        /// </summary>
        public int TableIndex { get; set; }
    }
}
