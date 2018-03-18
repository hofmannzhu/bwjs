using BWJS.DAL;
using BWJS.Model;
using BWJS.Model.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using UtilityHelper;

namespace BWJS.BLL
{

    /// <summary>
    /// NLLoanConfig
    /// </summary>
    public partial class NLLoanConfigBLL
    {
        private readonly static NLLoanConfigDAL sdal = new NLLoanConfigDAL();
        private readonly NLLoanConfigDAL dal = new NLLoanConfigDAL();
        public NLLoanConfigBLL()
        { }

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.NLLoanConfig model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.NLLoanConfig model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.NLLoanConfig GetModel(int Id)
        {

            return dal.GetModel(Id);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJS.Model.NLLoanConfig GetModelByCache(int Id)
		{
			
			string CacheKey = "NLLoanConfigModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJS.Model.NLLoanConfig)objModel;
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
        public List<BWJS.Model.NLLoanConfig> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }


        public List<BWJS.Model.NLLoanConfig> GetConfigList(string TypeName)
        {
            DataSet ds = dal.GetConfigList(TypeName);
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJS.Model.NLLoanConfig> DataTableToList(DataTable dt)
        {
            List<BWJS.Model.NLLoanConfig> modelList = new List<BWJS.Model.NLLoanConfig>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJS.Model.NLLoanConfig model;
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
        public BWJS.Model.NLLoanConfig DataRowToModel(DataRow row)
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
        /// <summary>
        /// 根据Key的名称 查询Key值
        /// </summary>
        /// <param name="Keyname"></param>
        /// <returns></returns>
        public static string GetValue(string Keyname)
        {
            return sdal.GetValue(Keyname);
        }
        /// <summary>
        ///  Get an object entity，From cache
        /// </summary>
        /// <param name="Keyname"></param>
        /// <returns></returns>
        public static string GetValueByCache(string Keyname)
        {
            Hashtable ht = GetHashListByCache();
            if (ht != null && ht.ContainsKey(Keyname) && ht[Keyname] != null)
            {
                return ht[Keyname].ToString();
            }
            return GetValue(Keyname);
        }
        /// <summary>
        ///  Get an object entity for INT，From cache
        /// </summary>
        /// <param name="Keyname"></param>
        /// <remarks>Default -1</remarks>
        public static int GetIntValueByCache(string Keyname)
        {
            Hashtable ht = GetHashListByCache();
            if (ht != null && ht.ContainsKey(Keyname) && ht[Keyname] != null)
            {
                return UtilityHelper.BWJSCommonHelper.SafeInt(ht[Keyname], -1);
            }
            return UtilityHelper.BWJSCommonHelper.SafeInt(GetValue(Keyname), -1);
        }
        public static int GetIntValueByCache(string Keyname, int defaultVal)
        {
            Hashtable ht = GetHashListByCache();
            if (ht != null && ht.ContainsKey(Keyname) && ht[Keyname] != null)
            {
                return UtilityHelper.BWJSCommonHelper.SafeInt(ht[Keyname], defaultVal);
            }
            return UtilityHelper.BWJSCommonHelper.SafeInt(GetValue(Keyname), defaultVal);
        }
        /// <summary>
        /// GetDecimalValueByCache 重写，带默认值  
        /// </summary>
        /// <param name="Keyname"></param>
        /// <remarks>Default -1</remarks>
        public static decimal GetDecimalValueByCache(string Keyname, decimal defaultVal)
        {
            Hashtable ht = GetHashListByCache();
            if (ht != null && ht.ContainsKey(Keyname) && ht[Keyname] != null)
            {
                return UtilityHelper.BWJSCommonHelper.SafeDecimal(ht[Keyname], defaultVal);
            }
            return UtilityHelper.BWJSCommonHelper.SafeDecimal(GetValue(Keyname), defaultVal);
        }
        /// <summary>
        /// Get an object list，From the cache 
        /// </summary>
        public static Hashtable GetHashListByCache()
        {
            string CacheKey = "ConfigSystemHashList";
            object objModel = CacheHelper.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = GetHashList();
                    if (objModel != null)
                    {
                        int CacheTime = UtilityHelper.BWJSCommonHelper.SafeInt(GetValue("CacheTime"), 30);
                        CacheHelper.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(CacheTime));
                    }
                }
                catch { }
            }
            return (Hashtable)objModel;
        }
        /// <summary>
        /// Get an object list
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetHashList()
        {
            DataSet ds = sdal.GetList("");
            Hashtable ht = new Hashtable();
            if (ds != null && (ds.Tables.Count > 0) && (ds.Tables[0] != null))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string Keyname = dr["KeyName"].ToString();
                    string Value = dr["KeyVal"].ToString();
                    ht.Add(Keyname, Value);
                }
            }
            return ht;
        }
    }
}