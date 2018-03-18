using BWJS.DAL;
using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BWJS.BLL
{

    /// <summary>
    /// 角色
    /// </summary>
    public partial class DepartmentInfoBLL
    {
        private readonly DepartmentInfoDAL dal = new DepartmentInfoDAL();
        public DepartmentInfoBLL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.DepartmentInfo model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.DepartmentInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int DepartmentInfoId,int EditId)
        {

            return dal.Delete(DepartmentInfoId, EditId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string DepartmentInfoIdlist,int EditId)
        {
            return dal.DeleteList(DepartmentInfoIdlist,EditId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.DepartmentInfo GetModel(int DepartmentInfoId)
        {

            return dal.GetModel(DepartmentInfoId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.DepartmentInfo GetModelByCache(int DepartmentInfoId)
		{
			
			string CacheKey = "DepartmentInfoModel-" + DepartmentInfoId;
			object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DepartmentInfoId);
					if (objModel != null)
					{
						int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.DepartmentInfo)objModel;
		}*/

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
        public List<BWJS.Model.DepartmentInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.DepartmentInfo> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.DepartmentInfo> modelList = new List<BWJS.Model.DepartmentInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.DepartmentInfo model;
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
        public BWJS.Model.DepartmentInfo DataRowToModel(DataRow row)
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
        #endregion

        #region  ExtensionMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DepartmentInfo GetDepartmentInfoOne(int DepartmentInfoId)
        {
            DepartmentInfoDAL dal = new DepartmentInfoDAL();
            return dal.GetDepartmentInfoOne(DepartmentInfoId);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int DepartmentID,int EditId)
        {
            DepartmentInfoDAL dal = new DepartmentInfoDAL();
            return dal.UpdateDelete(DepartmentID, EditId);
        }
        #endregion  ExtensionMethod



        public DataSet GetParentNameList(string where)
        {
            return dal.GetParentNameList(where);
        }


        public List<DepartmentInfo> GetDepartmentInfolist(int ParentID, int RecordIsDelete)
        {

            DepartmentInfoDAL dal = new DepartmentInfoDAL();
            return dal.GetDepartmentInfolist(ParentID, RecordIsDelete);
        }


    }
}