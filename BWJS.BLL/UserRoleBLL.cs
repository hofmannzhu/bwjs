﻿using BWJS.DAL;
using BWJS.Model;
using BWJS.Model.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BWJS.BLL
{

    /// <summary>
    /// 用户角色
    /// </summary>
    public partial class UserRoleBLL
    {
        private readonly UserRoleDAL dal = new UserRoleDAL();
        public UserRoleBLL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.UserRole model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.UserRole model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserRoleId)
        {

            return dal.Delete(UserRoleId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string UserRoleIdlist)
        {
            return dal.DeleteList(UserRoleIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.UserRole GetModel(int UserRoleId)
        {

            return dal.GetModel(UserRoleId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.UserRole GetModelByCache(int UserRoleId)
		{
			
			string CacheKey = "UserRoleModel-" + UserRoleId;
			object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserRoleId);
					if (objModel != null)
					{
						int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.UserRole)objModel;
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
        public List<BWJS.Model.UserRole> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.UserRole> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.UserRole> modelList = new List<BWJS.Model.UserRole>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.UserRole model;
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
        public BWJS.Model.UserRole DataRowToModel(DataRow row)
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserRoleName(string strWhere)
        {
            return dal.GetUserRoleName(strWhere);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  UpdateRole(BWJS.Model.UserRole model)
        {
            return dal.UpdateRole(model);
        }


        /// <summary>
        /// 获得用户权限
        /// </summary>
        public DataTable GetUserFunction(int userId)
        {
            return dal.GetUserFunction(userId);
        }

        #endregion  ExtensionMethod
    }
}
