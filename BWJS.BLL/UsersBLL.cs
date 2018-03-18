using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BWJS.Model;
using BWJS.DAL;
using BWJSLog.BLL;
using System.Web;
using UtilityHelper;
using BWJS.Model.Model;

namespace BWJS.BLL
{
    /// <summary>
    /// 会员表
    /// </summary>
    public partial class UsersBLL
    {
        private readonly UsersDAL dal = new UsersDAL();

        public UsersBLL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Users model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.Users model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {

            return dal.Delete(UserID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            return dal.DeleteList(UserIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.Users GetModel(int UserID)
        {

            return dal.GetModel(UserID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.Users> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.Users> modelList = new List<BWJS.Model.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.Users model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.Users DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderBy">排序字段&排序方向</param>
        /// <param name="sql">返回完整的的可执行sql</param>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return dal.GetNameList(where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="tablesql">要执行的sql语句</param>
        /// <param name="where">查询条件</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderBy">排序字段&排序方向</param>
        /// <param name="sql">返回完整的的可执行sql</param>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return dal.GetList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region  ExtensionMethod

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public Users AdminLogin(string AdminName)
        {
            return dal.AdminLogin(AdminName);
        }

        public UsersBackups DataRowBackupsToModel(DataRow row)
        {
            return dal.DataRowBackupsToModel(row);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UsersBackups> GetModelListName(string strWhere)
        {
            DataSet ds = dal.GetListName(strWhere);
            return DataTableToList2(ds.Tables[0]);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UsersBackups> DataTableToList2(DataTable dt)
        {
            List<UsersBackups> modelList = new List<UsersBackups>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                UsersBackups model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowBackupsToModel(dt.Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        public int VerificationIsUserName(string LoginName)
        {
            UsersDAL dal = new UsersDAL();
            int UserID = 0;
            try
            {
                UserID = dal.VerificationIsUserName(LoginName);
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }

            return UserID;
        }

        public int VerificationIsManager(string LoginName, string Password)
        {
            UsersDAL dal = new UsersDAL();
            int IsMaster = 0;
            try
            {
                IsMaster = dal.VerificationIsManager(LoginName, Password);
            }
            catch (Exception ex)
            {

            }

            return IsMaster;
        }

        public ReturnModel VerificationPassword(string LoginName, string Password, string CardID)
        {
            UsersDAL dal = new UsersDAL();
            ReturnModel rmodel = new ReturnModel();
            int UserID = 0;
            try
            {
                UserID = dal.VerificationPassword(LoginName, Password, CardID);
                if (UserID > 0)
                {
                    rmodel.IsSuccess = true;
                    rmodel.Data = UserID;
                }
                else {
                    rmodel.Data = UserID;
                    rmodel.IsSuccess = false;
                    if (UserID == -1)
                    {
                        rmodel.ErrMessage = "用户名不存在！";
                    }
                    else if (UserID == -2)
                    {
                        rmodel.ErrMessage = "请确认用户名和密码输入是否正确！";
                    }
                    else if (UserID == -3)
                    {
                        rmodel.ErrMessage = "身份证号输入与用户名不匹配！";
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return rmodel;
        }


        public DataSet GetNameList(string strWhere)
        {
            return dal.GetNameList(strWhere);
        }
        #endregion
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateDepartmentID(BWJS.Model.Users model)
        {
            return dal.UpdateDepartmentID(model);
        }

        public DataTable GetUserRoleTable(string strWhere)
        {
            return dal.GetUserRoleTable(strWhere);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        public bool UserUpdatePwd(string newPwd, string oldPwd, int userId, out string msg)
        {
            string PwdKey = LinkFun.getPwdKey();
            return dal.UserUpdatePwd(newPwd, oldPwd, userId, PwdKey, out msg);
        }
        public Users GetModelBySId(int sId)
        {
            return dal.GetModelBySId(sId);
        }
    }
}