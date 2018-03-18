using BWJS.DAL;
using BWJS.Model;
using BWJS.Model.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BWJSLog.BLL;

namespace BWJS.BLL
{
    /// <summary>
    /// 功能菜单
    /// </summary>
    public partial class FunctionBLL
    {
        private readonly FunctionDAL dal = new FunctionDAL();

        public FunctionBLL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Function model)
        {
            return dal.Add(model); 
        } 
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.Function model)
        {
            return dal.Update(model);
        }  
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.Function GetModel(int FunctionId)
        { 
            return dal.GetModel(FunctionId);
        } 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.Function> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.Function> DataTableToList(DataTable dt)
        //{
        //    List<BWJS.Model.Function> modelList = new List<BWJS.Model.Function>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        BWJS.Model.Function model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = DataRowToModel(dt.Rows[n]);
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //} 
        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public BWJS.Model.Function DataRowToModel(DataRow row)
        //{
        //    return dal.DataRowToModel(row);
        //}


        ///// <summary>
        ///// 分页获得数据列表
        ///// </summary>
        ///// <param name="tablesql">要执行的sql语句</param>
        ///// <param name="where">查询条件</param>
        ///// <param name="pageIndex">当前页索引</param>
        ///// <param name="pageSize">页尺寸</param>
        ///// <param name="orderBy">排序字段&排序方向</param>
        ///// <param name="sql">返回完整的的可执行sql</param>
        ///// <param name="zys">总页数</param>
        ///// <param name="sumcount">总记录数</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        //{
        //    return dal.GetList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        //}
        #endregion

        #region ExtensionMethod
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
            return dal.GetList(where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        /// <summary>
        /// 获取最大排序编号加1
        /// </summary>
        public int GetMaxOrderId()
        {
            return dal.GetMaxOrderId();
        }

        public int VerificationIsFunName(string FunctionName, int FunctionId)
        {
            FunctionDAL dal = new FunctionDAL();
            int FunctionId2 = 0;
            try
            {
                FunctionId2 = dal.VerificationIsFunName(FunctionName, FunctionId);
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }

            return FunctionId2;
        }


        public List<Function> GetFuctionDepartmentExtentList()
        {
            FunctionDAL dal = new FunctionDAL();
            List<Function> list = new List<Function>();
            try
            {
                list = dal.GetFuctionDepartmentExtentList();
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }

            return list;
        }


        //public List<Function> GetFunctionInfolist(int ParentID)
        //{
        //    FunctionDAL dal = new FunctionDAL();
        //    List<Function> list = new List<Function>();
        //    try
        //    {
        //        list = dal.GetFunctionInfolist(ParentID);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
        //    }

        //    return list;
        //}


        //public Function GetFunctionInfoOne(int FunctionId)
        //{
        //    FunctionDAL dal = new FunctionDAL();
        //    Function list = new Function();
        //    try
        //    {
        //        list = dal.GetFunctionInfoOne(FunctionId);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
        //    }

        //    return list;
        //}

        //public string GetFunctionName(int FunctionID, int RecordIsDelete) {
        //    FunctionDAL dal = new FunctionDAL();
        //    string str = "";
        //    try
        //    {
        //        str = dal.GetFunctionName(FunctionID, RecordIsDelete);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
           

        //    return str;
        //}


        public bool soleFunctionCode(string RandomCode, int RecordIsDelete)
        {
            FunctionDAL dal = new FunctionDAL();
            bool b = false;
            b=dal.soleFunctionCode(RandomCode, RecordIsDelete);
            return b;

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int AdReleaseID)
        {

            return dal.UpdateDelete(AdReleaseID);
        }




        public List<Function> GetFuctionDepartmentExtentList2(string where)
        {
            FunctionDAL dal = new FunctionDAL();
            List<Function> list = new List<Function>();
            try
            {
                list = dal.GetFuctionDepartmentExtentList2(where);
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }

            return list;
        }


        public DataSet GetListParent(string strWhere)
        {
            return dal.GetPsrentNameList(strWhere);
        }

        #endregion
    }
}
