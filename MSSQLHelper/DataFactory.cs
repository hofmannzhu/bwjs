using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSSQLHelper
{
    public sealed class DataFactory
    {
         
       
        /// <summary>
        /// 产生一个数据提供程序
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        public static DataProvider CreateDataProvider(string strConntionString, DataBaseType dataBaseType)
        {
            DataProvider dataProvider = null;

            switch (dataBaseType)
            {
                 case DataBaseType.MSSQL:
                    dataProvider = new SqlDataProvider(strConntionString);
                    break;
                //case DataBaseType.MYSQL:
                //    dataProvider = new MySqlDataProvider(strConntionString);
                //    break;
            }

            return dataProvider;
        }
        
    }

}
