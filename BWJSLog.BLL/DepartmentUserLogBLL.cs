using BWJSLog.DAL;
using BWJSLog.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BWJSLog.BLL
{
    public class DepartmentUserLogBLL
    {
        DepartmentUserLogDAL departmentUserLogdal = new DepartmentUserLogDAL();
        private int AddDepartmentUserLog(DepartmentUserLog model)
        {
            return departmentUserLogdal.AddDepartmentUserLog(model);
        }
        #region 记录日志到数据库
        /// <summary>
        /// 记录日志到数据库
        /// </summary>
        public static void WriteDepartmentUserLogToDB(int DepartmentID, string Remark, int UpType, int UserID, int UpdateUser)
        {
            try
            {
                StackTrace st = new StackTrace(true);
                MethodBase mb = st.GetFrame(1).GetMethod();
                string clsString = mb.DeclaringType.FullName;
                string mName = mb.Name;

                DepartmentUserLog entity = new DepartmentUserLog();
                entity.DepartmentID = DepartmentID;
                entity.Remark = Remark;
                entity.UpType = UpType;
                entity.UserID = UserID;
                entity.UpdateUser = UpdateUser;
                entity.RecordIsDelete = false;
                entity.RecordCreateTime = DateTime.Now;
                entity.RecordUpdateTime = DateTime.Now;
                DepartmentUserLogBLL op = new DepartmentUserLogBLL();
                op.AddDepartmentUserLog(entity);
            }
            catch
            {
            }
        }
        #endregion
    }

}
