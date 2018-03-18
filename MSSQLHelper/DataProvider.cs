using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MSSQLHelper
{
    /// <summary>
    /// 数据库访问接口
    /// </summary>
    public abstract class DataProvider:IDisposable
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected string _ConnectionString = string.Empty;
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        protected IDbConnection _Connection = null;
        
        /// <param name="strConnectionString">数据库连接字符串</param>
        public DataProvider(string strConnectionString)
        {
            if (string.IsNullOrEmpty(strConnectionString))
                throw new System.Exception("数据库连接字符串不能为空！");

            this._ConnectionString = strConnectionString;

            this._Connection = this.CreateConnection();
            this._Connection.ConnectionString = strConnectionString;
        }

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return this._Connection;
            }
            set {
                this._Connection = value;
            }
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {
            try
            {
                if (this._Connection != null && this._Connection.State != ConnectionState.Open)
                    this._Connection.Open();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            try
            {
                if (this._Connection != null && this._Connection.State != ConnectionState.Closed)
                    this._Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行一条Sql语句返回受影响的行数；如果执行语句之前连接处于打开状态，在执行完后，将会处于关闭状态。
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        public int ExecuteNonQuery(string strSql)
        {
            return this.ExecuteNonQuery(strSql, CommandType.Text, null);
        }

        /// <summary>
        /// 执行一条Sql语句返回受影响的行数；如果执行语句之前连接处于打开状态，在执行完后，将会处于关闭状态。
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <param name="commonType">命令类型</param>
        /// <param name="dataParameters">参数集</param>
        public int ExecuteNonQuery(string strSql, System.Data.CommandType commonType, List<IDataParameter> dataParameters)
        {
            return this.ExecuteNonQuery(strSql,commonType,dataParameters,CommandBehavior.Default);
        }

        /// <summary>
        /// 执行一条Sql语句返回受影响的行数；如果执行语句之前连接处于打开状态，在执行完后，将会处于关闭状态。
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <param name="commonType">命令类型</param>
        /// <param name="dataParameters">参数集</param>
        /// <param name="cb">命令参数，主要用于性能优化</param>
        private int ExecuteNonQuery(string strSql, System.Data.CommandType commonType, List<IDataParameter> dataParameters, System.Data.CommandBehavior cb)
        {
            int nQuery = -1;
            
            IDbCommand cmd = this.CreateCommand(strSql, commonType, dataParameters, cb);
            cmd.Connection = this.Connection;

            try
            {
                this.Open();

                if (cmd.Connection.State == ConnectionState.Open)
                    nQuery = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();
            }

            return nQuery;
        }

        /// <summary>
        /// 根据查询语句返回一个对象
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        public object ExecuteScalar(string strSql)
        {
            return this.ExecuteScalar(strSql, CommandType.Text, null);
        }

        /// <summary>
        /// 根据查询语句返回一个对象
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <param name="commonType">命令类型</param>
        /// <param name="dataParameters">参数集</param>
        public object ExecuteScalar(string strSql, System.Data.CommandType commonType, List<IDataParameter> dataParameters)
        {
            return this.ExecuteScalar(strSql, commonType, dataParameters, CommandBehavior.Default);
        }

        /// <summary>
        /// 根据查询语句返回一个对象
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <param name="commonType">命令类型</param>
        /// <param name="dataParameters">参数集</param>
        /// <param name="cb">命令参数，主要用于性能优化</param>
        private object ExecuteScalar(string strSql, System.Data.CommandType commonType, List<IDataParameter> dataParameters, System.Data.CommandBehavior cb)
        {
            object Scalar = null;
            IDbCommand cmd = this.CreateCommand(strSql, commonType, dataParameters, cb);
            cmd.Connection = this.Connection;

            try {
                this.Open();

                if (cmd.Connection.State == ConnectionState.Open)
                    Scalar = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                this.Close();
            }

            return Scalar;
        }

        /// <summary>
        /// 根据查询获取一张表
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable(string strSql)
        {
            System.Data.DataSet ds = this.GetDataSet(strSql, CommandType.Text, null);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// 根据查询语句返回一个结果集
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        public System.Data.DataSet GetDataSet(string strSql)
        {
            return this.GetDataSet(strSql,CommandType.Text,null);
        }

        /// <summary>
        /// 根据查询语句返回一个结果集
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <param name="commonType">命令类型</param>
        /// <param name="dataParameters">参数集</param>
        public System.Data.DataSet GetDataSet(string strSql, System.Data.CommandType commonType, List<IDataParameter> dataParameters)
        {
            DataSet ds = new DataSet();
            IDbDataAdapter adapter = this.CreateAdapter();
            IDbCommand cmd = this.CreateCommand(strSql, commonType, dataParameters, CommandBehavior.Default);
            cmd.Connection = this.Connection;
            adapter.SelectCommand = cmd;

            try
            {
                  adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                adapter.SelectCommand.Dispose();
                adapter = null;
            }

            return ds;
        }

        /// <summary>
        /// 根据查询语句返回一个游标
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <param name="commonType">命令类型</param>
        /// <param name="dataParameters">参数集</param>
        /// <param name="cb">命令参数，主要用于性能优化</param>
        private System.Data.IDataReader GetDataReader(string strSql, System.Data.CommandType commonType, List<IDataParameter> dataParameters, System.Data.CommandBehavior cb)
        {
            IDataReader reader = null;
            IDbCommand cmd = this.CreateCommand(strSql, commonType, dataParameters,cb);
            cmd.Connection = this.Connection;

            try
            {
                this.Open();
                if (cmd.Connection.State == ConnectionState.Open)
                    reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                this.Close();
                throw ex;
            }
            finally
            {
            }

            return reader;
        }

        /// <summary>
        /// 根据查询语句返回一个游标
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        public System.Data.IDataReader GetDataReader(string strSql)
        {
            return this.GetDataReader(strSql, CommandType.Text, null);
        }

        /// <summary>
        /// 根据查询语句返回一个游标
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <param name="commonType">命令类型</param>
        /// <param name="dataParameters">参数集</param>
        public System.Data.IDataReader GetDataReader(string strSql, System.Data.CommandType commonType, List<IDataParameter> dataParameters)
        {
            return this.GetDataReader(strSql, commonType, dataParameters, CommandBehavior.Default);
        }

        /// <summary>
        /// 得到一个连接对象
        /// </summary>
        protected abstract System.Data.IDbConnection CreateConnection();

        /// <summary>
        /// 得到一个命令对象
        /// </summary>
        protected abstract System.Data.IDbCommand CreateCommand();

        /// <summary>
        /// 得到一个命令对象
        /// </summary>
        /// <param name="strSql">查询字符串</param>
        /// <param name="commonType">命令类型</param>
        /// <param name="dataParameters">参数集</param>
        /// <param name="cb">命令参数，主要用于性能优化</param>
        private System.Data.IDbCommand CreateCommand(string strSql, System.Data.CommandType commonType, List<IDataParameter> dataParameters, System.Data.CommandBehavior cb)
        {
            System.Data.IDbCommand cmd = this.CreateCommand();
            cmd.CommandText = strSql;
            cmd.CommandType = commonType;
            cmd.CommandTimeout = 30000;

            if (dataParameters != null && dataParameters.Count > 0)
            {
                foreach (IDataParameter parameter in dataParameters)
                    cmd.Parameters.Add(parameter);
            }

            if ((cb & CommandBehavior.CloseConnection) != CommandBehavior.CloseConnection)
                cb |= CommandBehavior.CloseConnection;

            return cmd;
        }

        /// <summary>
        /// 得到一个适配器对象
        /// </summary>
        protected abstract System.Data.IDbDataAdapter CreateAdapter();

        /// <summary>
        /// 得到一个参数对象
        /// </summary>
        protected abstract System.Data.IDbDataParameter CreateParameter();

        #region IDisposable 成员

        public void Dispose()
        {
            this.Close();
            if (Connection != null)
                Connection.Close();
        }

        #endregion

       
    }
}
