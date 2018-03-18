using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MSSQLHelper
{
    class SqlDataProvider : DataProvider
    {
        /// <param name="strConnection">数据库连接字符串</param>
        internal SqlDataProvider(string strConnection):base(strConnection)
        {
             
        }
    
        protected override System.Data.IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        protected override System.Data.IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        protected override System.Data.IDbDataAdapter CreateAdapter()
        {
            return new SqlDataAdapter();
        }

        protected override System.Data.IDbDataParameter CreateParameter()
        {
            return new SqlParameter();
        }

    }
}
