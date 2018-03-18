using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BWJS.Model;
using BWJS.DAL.Ad;
using BWJSLog.BLL;
using BWJS.Model.Model;

namespace BWJS.BLL
{
    //广告位表
    public partial class AdPositionBLL
    {
        private readonly AdPositionDAL dal = new AdPositionDAL();

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.AdPosition model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.AdPosition model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.AdPosition GetModel(int AdPositionID)
        {

            return dal.GetModel(AdPositionID);
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
        public List<BWJS.Model.AdPosition> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.AdPosition> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.AdPosition> modelList = new List<BWJS.Model.AdPosition>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.AdPosition model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.AdPosition DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        #endregion

        #region  ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AdPositionID)
        {

            return dal.Delete(AdPositionID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string AdPositionIDlist)
        {
            return dal.DeleteList(AdPositionIDlist);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AdPositionID, int userId)
        {

            return dal.Delete(AdPositionID, userId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string AdPositionIDlist, int userId)
        {
            return dal.DeleteList(AdPositionIDlist, userId);
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
            return dal.GetList(where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
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
                
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool ChangeSort(int AdPositionID,int Sort)
        {
            return dal.ChangeSort(AdPositionID,Sort);
        }
        
        public bool BackUpdate(int AdReleaseID)
        {
            return dal.BackUpdate(AdReleaseID);
        }
        
        /// <summary>
        /// 广告位绑定广告
        /// </summary>
        public bool UpdateAdReleaseID(int AdReleaseID, int AdPositionID)
        {
            return dal.UpdateAdReleaseID(AdReleaseID, AdPositionID);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int AdPositionID)
        {

            return dal.UpdateDelete(AdPositionID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool UpdateDeleteList(string AdPositionIDlist)
        {
            return dal.UpdateDeleteList(AdPositionIDlist);
        }
        
        /// <summary>
        /// 查询广告位最该序号
        /// </summary>
        /// <returns></returns>
        public int GetMaxSort()
        {

            int MaxSort = 1;
            try
            {
                MaxSort = dal.GetMaxSort();

            }
            catch (Exception ex)
            {

                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }
            return MaxSort;
        }
        
        public int VerificationIsName(string Name,int AdPositionID)
        {
            AdPositionDAL dal = new AdPositionDAL();
            int AdPositionID2 = 0;
            try
            {
                AdPositionID2 = dal.VerificationIsName(Name, AdPositionID);
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }

            return AdPositionID2;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.AdPosition> GetNameModelList(string strWhere)
        {
            DataSet ds = dal.GetNameList(strWhere);
            return DataNameTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.AdPosition> DataNameTableToList(DataTable dt)
        {
            List<BWJS.Model.AdPosition> modelList = new List<BWJS.Model.AdPosition>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AdPositionBackups model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowNameToModel(dt.Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdPositionBackups DataRowNameToModel(DataRow row)
        {
            return dal.DataRowNameToModel(row);
        }

        #endregion

    }
}