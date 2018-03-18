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
    public class ExceptionLogBLL
    {
        ExcptionLogDAL excptionLogDAL = new ExcptionLogDAL();
        private int AddExceptionLog(ExceptionLog model)
        {
            return excptionLogDAL.AddExceptionLog(model);
        }

        #region 记录日志到数据库
        /// <summary>
        /// 记录日志到数据库
        /// </summary>
         public static void WriteExceptionLogToDB(string msg)
        {
            try
            {
                StackTrace st = new StackTrace(true);
                MethodBase mb = st.GetFrame(1).GetMethod();
                string clsString = mb.DeclaringType.FullName;
                string mName = mb.Name;

                ExceptionLog entity = new ExceptionLog();
                entity.ClassName = clsString;
                entity.MethodName = mName;
                entity.ErrorDesc = msg;
                entity.RecordIsDelete = false;
                entity.RecordCreateTime = DateTime.Now;
                entity.RecordUpdateTime = DateTime.Now;
                ExceptionLogBLL op = new ExceptionLogBLL();
                op.AddExceptionLog(entity);
            }
            catch
            {
            }
        }
        #endregion
    }
}
