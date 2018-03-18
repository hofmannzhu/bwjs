using BWJSLog.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper.Data;

namespace BWJSLog.DAL
{
    public class ExcptionLogDAL:BaseService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddExceptionLog(ExceptionLog model)
        {

            int result = 0;
            try
            { 

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into ExceptionLog(");
                strSql.Append("ClassName,MethodName,ErrorDesc,RecordIsDelete,RecordUpdateTime,RecordCreateTime");
                strSql.Append(") values (");
                strSql.Append("@ClassName,@MethodName,@ErrorDesc,0,getdate(),getdate()");
                strSql.Append(") ");
                strSql.Append(";select SCOPE_IDENTITY()");
                SqlParameter[] parameters = {
                    new SqlParameter("@ClassName", model.ClassName),
                    new SqlParameter("@MethodName", model.MethodName),
                    new SqlParameter("@ErrorDesc", model.ErrorDesc),
              
                   };

                result = SqlDataUtilityHelper.ExecuteScalar(this.ConnectionString, strSql.ToString(), parameters);


            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
    
