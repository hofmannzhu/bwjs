using MSSQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace UtilityHelper.Data
{
    public static class SqlDataUtilityHelper
    {
        //private static readonly ILog Log4NetHelp = LogManager.GetLogger(typeof(SqlDataUtilityHelper));
        /// <summary>
        /// 数据是否已经删除的条件语句
        ///  RecordIsDelete = 0
        /// </summary>
        public const string NOTISDELETEWHERESTRING = "RecordIsDelete = 0 ";

        /// <summary>
        /// 通过属性名称获取对应的数据对象绑定，限定为，属性名称必须与数据库中的字段名称对应
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="selectFields">查询字段</param>
        /// <param name="target">绑定的目标对象</param>
        /// <param name="reader">数据读取游标</param>
        public static void BindObject<T>(string[] selectFields, T target, IDataReader reader) where T : class
        {
            if (reader == null)
                return;
            var properties = target.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var pro in properties)
            {
                // 过滤除字符串以外的引用类型
                if (pro.PropertyType.IsClass && pro.PropertyType != typeof(string)
                    || !selectFields.Select(t => t.Trim()).Contains(pro.Name))
                    continue;
                try
                {
                    var index = reader.GetOrdinal(pro.Name);
                    if (index == -1 || reader.IsDBNull(index))
                        continue;
                    pro.SetValue(target, Convert.ChangeType(reader.GetValue(index),
                        pro.PropertyType.GetGenericArguments().Length > 0 ? pro.PropertyType.GetGenericArguments()[0] : pro.PropertyType));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 从数据库获取一个对象,限定为，属性名称必须与数据库中的字段名称对应
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="outFields">输出字段</param>
        /// <param name="connectionString">链接字符串</param>
        /// <param name="strSql">查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static T GetObjectFromDB<T>(string[] outFields, string connectionString, string strSql, params SqlParameter[] parameters) where T : class, new()
        {
            T target = null;
            try
            {
                target = new T();
                // 获取查询记录
                using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSql, parameters))
                {
                    while (reader.Read())
                    {
                        BindObject<T>(outFields, target, reader);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // 异常处理
                throw ex;
            }
            return target;
        }


        /// <summary>
        /// 从数据库获取一个对象集合,限定为，属性名称必须与数据库中的字段名称对应
        /// </summary>
        /// <param name="outFields">查询字段,不带别名</param>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="connectionString">链接字符串</param>
        /// <param name="strSql">查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static List<T> GetListFromDB<T>(string outFields, string connectionString, string strSql, SqlParameter[] parameters = null, CommandType commType = CommandType.Text) where T : class, new()
        {
            string[] selectFields = outFields.Split(',');
            List<T> targetList = new List<T>();
            SqlDataReader reader = null;
            try
            {
                // 获取查询记录
                if (parameters != null)
                    reader = SqlHelper.ExecuteReader(connectionString, commType, strSql, parameters);
                else
                    reader = SqlHelper.ExecuteReader(connectionString, commType, strSql);

                while (reader.Read())
                {
                    T target = new T();
                    BindObject<T>(selectFields, target, reader);
                    targetList.Add(target);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return targetList;
        }


        public static List<object> GetListFromDB(string connectionString, string strSql, SqlParameter[] parameters = null, CommandType commType = CommandType.Text)
        {

            List<object> targetList = new List<object>();
            SqlDataReader reader = null;
            try
            {
                // 获取查询记录
                if (parameters != null)
                    reader = SqlHelper.ExecuteReader(connectionString, commType, strSql, parameters);
                else
                    reader = SqlHelper.ExecuteReader(connectionString, commType, strSql);

                while (reader.Read())
                {

                    targetList.Add(reader[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return targetList;
        }


        //2015
        public static DataTable GetListFromDBTable(string strSelectFields, string connectionString, string strSql, SqlParameter[] parameters = null, CommandType commType = CommandType.Text)
        {
            string[] selectFields = strSelectFields.Split(',');

            DataTable dt = new DataTable();
            try
            {
                // 获取查询记录
                if (parameters != null)
                    dt = SqlHelper.ExecuteDataset(connectionString, commType, strSql, parameters).Tables[0];
                else
                    dt = SqlHelper.ExecuteDataset(connectionString, commType, strSql).Tables[0];


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            return dt;

        }


        public static List<T> ReadeBindObject<T>(string[] bindFields, IDataReader reader) where T : class, new()
        {
            List<T> targetList = new List<T>();
            while (reader.Read())
            {
                T target = new T();
                BindObject<T>(bindFields, target, reader);
                targetList.Add(target);
            }

            return targetList;
        }


   

        /// <summary>
        /// 分页获取数据库数据记录
        /// 限定：属性名称必须与数据库中的字段名称对应
        /// </summary>
        /// <typeparam name="T">转换的对象</typeparam>
        /// <param name="outFields">输出的字段，逗号分隔，不能有空格,接收对象的属性名称</param>
        /// <param name="selectFields">查询的字段，逗号分隔，不能有空格</param>
        /// <param name="tableName">表名</param>
        /// <param name="OrderByField">排序字段，字段 DESC|ASC</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="strWhere">条件语句</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页大小</param>
      
        /// <returns></returns>
        public static DataPager<T> GetDataToPager<T>(string outFields, string selectFields, string tableName, string OrderByField, string connectionString,  string strWhere, List<SqlParameter> parameters, int pageNo, int pageSize) where T : class, new()
        {
            
            StringBuilder strSql = new StringBuilder();
            DataPager<T> dataPager = new DataPager<T>();

            if (parameters == null)
            {
                parameters = new List<SqlParameter>();
            }

            //新代码段落
            try
            {
                string totalSql = string.Format("SELECT COUNT(1) AS Total FROM {0} {1}", tableName, String.IsNullOrEmpty(strWhere) ? "" : "WHERE " + strWhere);
                object total = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, totalSql, parameters.ToArray());
                if (total != null)
                {
                    dataPager.TotalRecord = Convert.ToInt32(total);
                }
            }
            catch (Exception ex)
            {
                // 异常处理
                throw ex;
            }
            if (dataPager.TotalRecord > 0)
            {
                int  totalPage = dataPager.TotalRecord / pageSize;
                if (dataPager.TotalRecord % pageSize > 0)
                {
                    totalPage += 1;
                }
                dataPager.TotalPage = totalPage;

                dataPager.PageSize = pageSize;

                if (pageNo > totalPage)
                {
                    dataPager.Items = new List<T>();
                }


                ////SQL Server 2012 以上版本翻页

                strSql.AppendFormat("SELECT {0} FROM {1} WHERE {2} ORDER BY {3} OFFSET @startNumber ROW FETCH NEXT @endNumber ROWS ONLY", selectFields, tableName, String.IsNullOrEmpty(strWhere) ? "1=1" : strWhere, OrderByField);
                parameters.Add(new SqlParameter("@startNumber", (pageNo - 1) * pageSize));
                parameters.Add(new SqlParameter("@endNumber", pageSize));

                ////通用  

                //strSql.AppendFormat("SELECT TOP {0} {1} FROM (", pageSize, outFields);
                //strSql.AppendFormat(" SELECT ROW_NUMBER() OVER (ORDER BY {2}) AS rowNumber, {0} FROM {1}", selectFields, tableName, OrderByField);
                //strSql.Append(string.IsNullOrEmpty(strWhere) ? "" : " WHERE " + strWhere);
                //strSql.Append(") AS t_Table WHERE rowNumber > @startNumber AND rowNumber <=@endNumber");
                //parameters.Add(new SqlParameter("@startNumber", (pageNo - 1) * pageSize));
                //parameters.Add(new SqlParameter("@endNumber", pageNo * pageSize));

                dataPager.Items = GetListFromDB<T>(outFields, connectionString, strSql.ToString(), parameters.ToArray());
            }

        

            parameters.Clear();
            return dataPager;
        }


        public static DataPagerTable GetDataToPagerNew(string outFields, string selectFields, string tableName, string rowNumberOrderBy, string connectionString,
            string strWhere, List<SqlParameter> parameters, int pageNo, int pageSize, string selectGroupByString = "", string topOrderByFields = "")
        {
            if (parameters == null)
                parameters = new List<SqlParameter>();
            StringBuilder strSql = new StringBuilder();
            DataPagerTable dataPager = new DataPagerTable();
            strSql.AppendFormat("SELECT TOP {0} {1} FROM (", pageSize, outFields);
            strSql.AppendFormat("SELECT ROW_NUMBER() OVER (ORDER BY {2}) AS rowNumber, {0} FROM {1}", selectFields, tableName, rowNumberOrderBy);
            try
            {
                string totalSql = string.Format("SELECT COUNT(0) AS Total FROM {0} {1}", tableName, !string.IsNullOrEmpty(strWhere) ? " WHERE " + strWhere : "");
                var total = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, totalSql, parameters.ToArray());
                if (total != null)
                {
                    dataPager.Total = Convert.ToInt32(total);
                }
            }
            catch (Exception ex)
            {
                // 异常处理
                throw ex;
            }
            if (dataPager.Total > 0)
            {
                #region 添加判断当前页与总页数
                var tempTotPage = dataPager.Total / pageSize;
                if (dataPager.Total % pageSize > 0)
                {
                    tempTotPage += 1;
                }
                #endregion
                if (!string.IsNullOrEmpty(strWhere))
                    strSql.Append(" WHERE " + strWhere);
                if (!string.IsNullOrEmpty(selectGroupByString))
                    strSql.Append(" GROUP BY " + selectGroupByString);
                strSql.Append(") AS t_Table WHERE rowNumber > @startNumber AND rowNumber <=@endNumber");
                if (!string.IsNullOrEmpty(topOrderByFields))
                    strSql.Append(" ORDER BY " + topOrderByFields);
                parameters.Add(new SqlParameter("@startNumber", (pageNo - 1) * pageSize));
                parameters.Add(new SqlParameter("@endNumber", pageNo * pageSize));
                dataPager.Table = GetListFromDBTable(outFields, connectionString, strSql.ToString(), parameters.ToArray());
            }
            parameters.Clear();
            return dataPager;
        }

        /// <summary>
        /// 创建一个插入SQL语句以及命令参数集合，
        /// 限定：数据库表字段与传入的对象T的属性名称必须一致，不区分大小写
        /// </summary>
        /// <typeparam name="T">插入的数据对象类型</typeparam>
        /// <param name="objData">插入的数据对象类型</param>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段集合，字段与字段中间逗号(,)分隔</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="commonFields">共用字段</param>
        /// <param name="commonFieldsValues">共用字段默认值</param>
        /// <returns></returns>
        public static string CreateInsertSqlString<T>(T objData, string tableName, string fields, ref List<SqlParameter> parameters,
            string commonFields = "RecordIsDelete ,RecordCreateTime,RecordUpdateTime",
            string commonFieldsValues = "0,getdate(),getdate()") where T : class, new()
        {
            var objType = objData.GetType();
            StringBuilder strSql = new StringBuilder();
            StringBuilder strValue = new StringBuilder();
            strSql.AppendFormat(" INSERT INTO {0}", tableName);
            strSql.Append("(");
            strValue.Append(" VALUES (");
            foreach (var fName in fields.Split(','))
            {
                if (string.IsNullOrEmpty(fName))
                    continue;
                var p = objType.GetProperty(fName);
                if (p != null)
                {
                    strSql.Append(fName + ",");
                    strValue.Append("@" + fName + ",");
                    var pValue = p.GetValue(objData, null);
                    if (pValue == null)
                    {
                        if (p.PropertyType.IsValueType)
                        {
                            if (p.PropertyType == typeof(DateTime))
                                pValue = DateTime.MinValue;
                            else
                                pValue = -1;
                        }
                        else
                            pValue = "";
                    }
                    parameters.Add(new SqlParameter("@" + fName, pValue));
                }

            }
            strValue.Append(commonFieldsValues).Append(" )");
            strSql.Append(commonFields).Append(")").Append(strValue);
            strValue.Clear();
            strValue = null;
            return strSql.ToString();
        }
        /// <summary>
        /// 创建一个插入SQL语句以及命令参数集合，
        /// 限定：数据库表字段与传入的对象T的属性名称必须一致，不区分大小写
        /// </summary>
        /// <typeparam name="T">插入的数据对象类型</typeparam>
        /// <param name="objData">插入的数据对象类型</param>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段集合，字段与字段中间逗号(,)分隔</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="commonFields">共用字段</param>
        /// <param name="commonFieldsValues">共用字段默认值</param>
        /// <returns></returns>
        public static string CreateInsertSqlString<T>(List<T> array, string tableName, string fields, ref List<SqlParameter> parameters,
            string commonFields = "RecordIsDelete ,RecordCreateTime,RecordUpdateTime",
            string commonFieldsValues = "0,getdate(),getdate()") where T : class, new()
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strValue = new StringBuilder();
            strSql.AppendFormat(" INSERT INTO {0}", tableName);
            strSql.Append("(");
            foreach (var fName in fields.Split(','))
            {
                if (string.IsNullOrEmpty(fName))
                    continue;
                strSql.Append(fName + ",");
            }
            strSql.Append(commonFields).Append(")").Append(" VALUES ");

            var index = 1;
            foreach (var objData in array)
            {
                strValue.Clear();
                var objType = objData.GetType();
                foreach (var fName in fields.Split(','))
                {
                    if (string.IsNullOrEmpty(fName))
                        continue;
                    var p = objType.GetProperty(fName);
                    if (p != null)
                    {
                        strValue.Append("@" + fName + "_" + index + ",");
                        var pValue = p.GetValue(objData, null);
                        if (pValue == null)
                        {
                            if (p.PropertyType.IsValueType)
                            {
                                if (p.PropertyType == typeof(DateTime))
                                    pValue = DateTime.MinValue;
                                else
                                    pValue = -1;
                            }
                            else
                                pValue = "";
                        }
                        parameters.Add(new SqlParameter("@" + fName, pValue));
                    }
                }
                strSql.Append("(").Append(strValue.ToString()).Append(commonFieldsValues).Append(" ),");
            }
            var sqlString = strSql.ToString();
            if (sqlString.EndsWith(","))
                sqlString.Remove(sqlString.Length - 1, 1);
            strValue.Clear();
            strValue = null;
            strSql.Clear();
            strSql = null;
            return sqlString;
        }

        /// <summary>
        /// 创建一个更新SQL语句以及命令参数集合，主键必填
        /// 限定：数据库表字段与传入的对象T的属性名称必须一致，不区分大小写
        /// </summary>
        /// <typeparam name="T">插入的数据对象类型</typeparam>
        /// <param name="objData">插入的数据对象类型</param>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段集合，字段与字段中间逗号(,)分隔</param>
        /// <param name="PK">主键集合</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="commonFields">共用字段</param>
        /// <param name="commonFieldsValues">共用字段默认值</param>
        /// <returns></returns>
        public static string CreateUpdateSqlString<T>(T objData, string tableName, string fields, string PK, ref List<SqlParameter> parameters,
            string commonFields = "RecordUpdateTime",
            string commonFieldsValues = "getdate()") where T : class, new()
        {
            var objType = objData.GetType();
            if (string.IsNullOrEmpty(PK))
            {
                throw new ArgumentNullException("主键不能为空！");
            }
            StringBuilder strSql = new StringBuilder();
            StringBuilder strPK = new StringBuilder();
            // 主键
            var pkFields = PK.Split(',');
            for (var n = 0; n < pkFields.Length; n++)
            {
                var fName = pkFields[n];
                if (string.IsNullOrEmpty(fName))
                    continue;

                var p = objType.GetProperty(fName);
                if (p != null)
                {
                    if (strPK.Length > 0)
                        strPK.Append(" AND ");
                    strPK.AppendFormat("{0}=@{0}", fName);
                    var pValue = p.GetValue(objData, null);
                    if (pValue == null)
                    {
                        if (p.PropertyType.IsValueType)
                        {
                            if (p.PropertyType == typeof(DateTime))
                                pValue = DateTime.MinValue;
                            else
                                pValue = -1;
                        }
                        else
                            pValue = "";
                    }
                    parameters.Add(new SqlParameter("@" + fName, pValue));
                }
                else
                    throw new ArgumentNullException("属性" + fName + " 在类" + objType.Name + "上未找到!");
            }

            // 字段
            foreach (var fName in fields.Split(','))
            {
                if (string.IsNullOrEmpty(fName))
                    continue;
                if (strSql.Length > 0)
                    strSql.Append(",");
                strSql.AppendFormat("{0}=@{0}", fName);
                var p = objType.GetProperty(fName);
                if (p != null)
                    parameters.Add(new SqlParameter("@" + fName, p.GetValue(objData, null)));
            }
            // 公用字段
            var comFields = commonFields.Split(',');
            var comValues = commonFieldsValues.Split(',');
            for (var n = 0; n < comFields.Length; n++)
            {
                var fName = comFields[n];
                if (string.IsNullOrEmpty(fName))
                    continue;
                if (strSql.Length > 0)
                    strSql.Append(",");
                strSql.AppendFormat("{0}={1}", fName, comValues[n]);
            }
            strSql.Insert(0, string.Format(" UPDATE {0} SET ", tableName));
            strSql.Append(" WHERE ").Append(strPK.ToString());
            strPK.Clear();
            strPK = null;

            return strSql.ToString();
        }

        /// <summary>
        /// 从数据库获取一个字典数据，只能取两列
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetDictionary(string connectionString, string strSql, List<SqlParameter> parameters = null)
        {
            Dictionary<int, string> basicDictionary = new Dictionary<int, string>();
            SqlDataReader reader = null;
            try
            {
                if (parameters == null)
                    reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSql);
                else
                    reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSql, parameters.ToArray());

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            if (!basicDictionary.Keys.Contains(reader.GetInt32(0)))
                                basicDictionary.Add(reader.GetInt32(0), !reader.IsDBNull(1) ? reader.GetString(1) : "");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return basicDictionary;
        }
        public static Dictionary<string, string> GetDictionaryKeyString(string connectionString, string strSql, List<SqlParameter> parameters = null)
        {
            Dictionary<string, string> basicDictionary = new Dictionary<string, string>();
            SqlDataReader reader = null;
            try
            {
                if (parameters == null)
                    reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSql);
                else
                    reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSql, parameters.ToArray());

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            if (!basicDictionary.Keys.Contains(reader.GetString(0)))
                                basicDictionary.Add(reader.GetString(0), !reader.IsDBNull(1) ? reader.GetString(1) : "");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return basicDictionary;
        }


        /// <summary>
        /// 从数据库获取一个字典数据，只能取两列
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static Dictionary<T1, T2> GetDictionaryT<T1, T2>(string connectionString, string strSql, List<SqlParameter> parameters = null)
        {
            Dictionary<T1, T2> basicDictionary = new Dictionary<T1, T2>();
            SqlDataReader reader = null;
            try
            {
                if (parameters == null)
                    reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSql);
                else
                    reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSql, parameters.ToArray());

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            if (!basicDictionary.Keys.Contains((T1)reader.GetValue(0)))
                                basicDictionary.Add((T1)reader.GetValue(0), (T2)reader.GetValue(1));
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return basicDictionary;
        }

        /// <summary>
        /// 从数据库获取一个字典
        /// </summary>
        /// <typeparam name="T1">Key类型</typeparam>
        /// <typeparam name="T2">Value类型</typeparam>
        /// <param name="connectionString">连接串</param>
        /// <param name="strSql">查询语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static Dictionary<T1, T2> GetDictionary<T1, T2>(string connectionString, string strSql, IEnumerable<SqlParameter> parameters)
        {
            Dictionary<T1, T2> basicDictionary = new Dictionary<T1, T2>();
            try
            {
                if (parameters == null)
                    parameters = new List<SqlParameter>();
                using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSql, parameters.ToArray()))
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                            basicDictionary.Add((T1)reader.GetValue(0), (T2)reader.GetValue(1));
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return basicDictionary;
        }


        public static SqlErrorMessage BeginTransaction(string connectionString, Queue<SqlTransactionParameter> exeQueue)
        {
            List<TablePrimaryKeyValue> tablePkValue = null;
            return BeginTransaction(connectionString, exeQueue, ref tablePkValue);
        }

        /// <summary>
        /// 数据库事物处理
        /// 自动增长列的表，自动处理外键赋值
        /// 执行的队列必须严格按照顺序添加入队列
        /// 目前不支持单表多个主键
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="exeQueue">执行队列，自动增长列的表，外键不需要赋值</param>
        /// <returns></returns>
        public static SqlErrorMessage BeginTransaction(string connectionString, Queue<SqlTransactionParameter> exeQueue, ref List<TablePrimaryKeyValue> tablePkValue)
        {
            SqlErrorMessage errorMessage = new SqlErrorMessage();
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            try
            {

                var index = 0;
                // 外键数据集合
                Dictionary<string, object> FKValues = new Dictionary<string, object>();
                conn = new SqlConnection(connectionString);
                conn.Open();
                transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                var stp = exeQueue.Dequeue();
                while (stp != null)
                {
                    errorMessage.CommonText = stp.CommonText;
                    errorMessage.Parameters = stp.Parameters;
                    var sqlCommand = new SqlCommand(stp.CommonText, conn, transaction);
                    sqlCommand.CommandType = CommandType.Text;
                    // 自动增长列的保存主键，用于其他执行的外键赋值
                    if (stp.PkIsIdentity && !stp.IsUpdate)
                    {
                        if (tablePkValue == null)
                            tablePkValue = new List<TablePrimaryKeyValue>();
                        sqlCommand.CommandText = sqlCommand.CommandText + ";SELECT SCOPE_IDENTITY()";

                        foreach (var fk in FKValues)
                        {
                            var pFK = stp.Parameters.Find(t => t.ParameterName == "@" + fk.Key);
                            if (pFK != null)
                                pFK.Value = fk.Value;
                        }

                        if (stp.Parameters.Count > 0)
                            sqlCommand.Parameters.AddRange(stp.Parameters.ToArray());
                        var resultPK = sqlCommand.ExecuteScalar();
                        // 如果外键名称不为空的使用外键名称
                        if (!FKValues.ContainsKey(string.IsNullOrEmpty(stp.FKName) ? stp.PK : stp.FKName))
                            FKValues.Add(string.IsNullOrEmpty(stp.FKName) ? stp.PK : stp.FKName, resultPK);

                        tablePkValue.Add(new TablePrimaryKeyValue() { TableName = stp.TableName, PkName = stp.PK, PkValue = resultPK, TableIndex = index });
                        index++;
                    }
                    else
                    {
                        if (stp.Parameters.Count > 0)
                            sqlCommand.Parameters.AddRange(stp.Parameters.ToArray());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (exeQueue.Count == 0)
                        break;
                    stp = exeQueue.Dequeue();
                }
                transaction.Commit();
                FKValues.Clear();

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                errorMessage.IsError = true;
                errorMessage.ErrorMessage = ex.Message;
                errorMessage.Ex = ex;
                throw ex;
            }
            finally
            {
                if (transaction != null)
                    transaction = null;
                if (conn != null)
                    conn.Close();
            }

            return errorMessage;
        }

        /// <summary>
        /// 执行非查询操作
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandTxt">命令</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="commandType">类型</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string commandTxt, IEnumerable<SqlParameter> parameters, CommandType commandType = CommandType.Text)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(connectionString, commandType, commandTxt, parameters.ToArray());
            }
            catch (Exception ex)
            {
                // 异常处理
                throw ex;
            }

        }
        /// <summary>
        /// 执行查询操作，返回单一值
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandTxt">命令</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="commandType">类型</param
        /// <returns></returns>
        public static int ExecuteScalar(string connectionString, string commandTxt, IEnumerable<SqlParameter> parameters, CommandType commandType = CommandType.Text)
        {
            try
            {
                var obj = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, commandTxt, parameters.ToArray());
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                // 异常处理
                throw ex;
            }

        }

        /// <summary>
        /// 执行查询操作，返回string
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="commandTxt">命令</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="commandType">类型</param>
        /// <returns></returns>
        public static string ExecuteScalarStr(string connectionString, string commandTxt, IEnumerable<SqlParameter> parameters, CommandType commandType = CommandType.Text)
        {
            try
            {
                var obj = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, commandTxt, parameters.ToArray());
                if (obj != null)
                {
                    return obj.ToString();
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex)
            {
                // 异常处理
                throw ex;
            }

        }
    }

}
