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
    public class DepartmentUserLogDAL : BaseService
    { /// <summary>
      /// 新增
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
        public int AddDepartmentUserLog(DepartmentUserLog model)
        {

            int result = 0;
            try
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"INSERT INTO [dbo].[DepartmentUserLog]
                                       ([DepartmentID],[Remark],[UpType],[UserID],[UpdateUser],[RecordIsDelete],[RecordCreateTime] ,[RecordUpdateTime])
                                       VALUES   (@DepartmentID ,@Remark ,@UpType  ,@UserID
                                       ,@UpdateUser ,@RecordIsDelete ,@RecordCreateTime,@RecordUpdateTime  )");
                SqlParameter[] parameters = {
                    new SqlParameter("@DepartmentID", model.DepartmentID),
                    new SqlParameter("@Remark", model.Remark),
                    new SqlParameter("@UpType", model.UpType),
                     new SqlParameter("@UserID", model.UserID),
                    new SqlParameter("@UpdateUser", model.UpdateUser),
                    new SqlParameter("@RecordIsDelete", model.RecordIsDelete),
                     new SqlParameter("@RecordCreateTime", model.RecordCreateTime),
                      new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime)
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
