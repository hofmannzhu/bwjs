using System; 
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace MSSQLHelper
{
    /// <summary>
    /// 数据库交互操作类
    /// 这个类只提供静态方法，阻止构造函数
    /// </summary>
    public static class SqlHelperParameterCache
    {
        #region 全局变量, 私有方法, 构造函数

        private static readonly Hashtable ParamCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 在运行时解析并设置存储过程的SqlParameters参数组
        /// </summary>
        /// <param name="connection">数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="includeReturnValueParameter">是否包括返回值参数</param>
        /// <returns>SqlParameter数组.</returns>
        private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentNullException("spName");
            SqlCommand cmd = new SqlCommand(spName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            connection.Open();
            SqlCommandBuilder.DeriveParameters(cmd);
            connection.Close(); 
            if (!includeReturnValueParameter)
            {
                cmd.Parameters.RemoveAt(0);
            } 
            SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count]; 
            cmd.Parameters.CopyTo(discoveredParameters, 0); 
            // 初始化参数并给DBNull值
            foreach (SqlParameter discoveredParameter in discoveredParameters)
            {
                discoveredParameter.Value = DBNull.Value;
            }
            return discoveredParameters;
        }

        /// <summary>
        /// 深拷贝缓存SqlParameter数组
        /// </summary>
        /// <param name="originalParameters">源数组</param>
        /// <returns>SqlParameter数组.</returns>
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }
            return clonedParameters;
        }

        #endregion 全局变量, 私有方法, 构造函数

        #region 缓存功能函数

        /// <summary>
        /// 添加SqlParameters到缓存中
        /// </summary>
        /// <param name="connectionString">有效的SqlConnection连接字符串</param>
        /// <param name="commandText">T-SQL命令或存储过程名称</param>
        /// <param name="commandParameters">要缓存的SqlParameter数组</param>
        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            string hashKey = connectionString + ":" + commandText;
            ParamCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// 从缓存中检索SqlParameter数组
        /// </summary>
        /// <param name="connectionString">有效的SqlConnection连接字符串</param>
        /// <param name="commandText">T-SQL命令或存储过程名称</param>
        /// <returns>SqlParameter数组.</returns>
        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");
            string hashKey = connectionString + ":" + commandText;
            SqlParameter[] cachedParameters = ParamCache[hashKey] as SqlParameter[];
            return cachedParameters == null ? null : CloneParameters(cachedParameters);
        }

        #endregion 缓存功能函数

        #region 参数提取功能函数

        /// <summary>
        /// 提取缓存中的SqlParameter数组
        /// </summary>
        /// <remarks>
        /// 此方法将在数据库中查询，然后将它存储在缓存中，供以后的请求。
        /// </remarks>
        /// <param name="connectionString">有效的SqlConnection连接字符串</param>
        /// <param name="spName">存储过程名称</param>
        /// <returns>SqlParameter数组.</returns>
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        /// <summary>
        /// 提取缓存中的SqlParameter数组
        /// </summary>
        /// <remarks>
        /// 此方法将在数据库中查询，然后将它存储在缓存中，供以后的请求。
        /// </remarks>
        /// <param name="connectionString">有效的SqlConnection连接字符串</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="includeReturnValueParameter">是否包括返回值参数</param>
        /// <returns>SqlParameter数组.</returns>
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentNullException("spName");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// 提取缓存中的SqlParameter数组
        /// </summary>
        /// <remarks>
        /// 此方法将在数据库中查询，然后将它存储在缓存中，供以后的请求。
        /// </remarks>
        /// <param name="connection">有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <returns>SqlParameter数组.</returns>
        internal static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName)
        {
            return GetSpParameterSet(connection, spName, false);
        }

        /// <summary>
        /// 提取缓存中的SqlParameter数组
        /// </summary>
        /// <remarks>
        /// 此方法将在数据库中查询，然后将它存储在缓存中，供以后的请求。
        /// </remarks>
        /// <param name="connection">有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="includeReturnValueParameter">是否包括返回值参数</param>
        /// <returns>SqlParameter数组.</returns>
        internal static SqlParameter[] GetSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            using (SqlConnection clonedConnection = (SqlConnection)((ICloneable)connection).Clone())
            {
                return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
            }
        }

        /// <summary>
        /// 提取缓存中的SqlParameter数组
        /// </summary>
        /// <param name="connection">有效的数据库连接对象</param>
        /// <param name="spName">存储过程名称</param>
        /// <param name="includeReturnValueParameter">是否包括返回值参数</param>
        /// <returns>SqlParameter数组.</returns>
        private static SqlParameter[] GetSpParameterSetInternal(SqlConnection connection, string spName, bool includeReturnValueParameter)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            if (string.IsNullOrEmpty(spName))
                throw new ArgumentNullException("spName");
            string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
            SqlParameter[] cachedParameters = ParamCache[hashKey] as SqlParameter[];
            if (cachedParameters == null)
            {
                SqlParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                ParamCache[hashKey] = spParameters;
                cachedParameters = spParameters;
            }
            return CloneParameters(cachedParameters);
        }

        #endregion 参数提取功能函数

    }
}
