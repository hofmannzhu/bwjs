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
    public partial class SupplierInfoBLL
    {
        private readonly SupplierInfoDAL dal = new SupplierInfoDAL();
        public SupplierInfoBLL()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SId)
        {
            return dal.Exists(SId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SupplierInfo model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SupplierInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SId)
        {

            return dal.Delete(SId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string SIdlist)
        {
            return dal.DeleteList(SIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SupplierInfo GetModel(int SId)
        {

            return dal.GetModel(SId);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public SupplierInfo GetModelByCache(int SId)
        //{

        //    string CacheKey = "SupplierInfoModel-" + SId;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(SId);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (SupplierInfo)objModel;
        //}

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
        public List<SupplierInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SupplierInfo> DataTableToList(DataTable dt)
        {
            List<SupplierInfo> modelList = new List<SupplierInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                SupplierInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new SupplierInfo();
                    if (dt.Rows[n]["SId"].ToString() != "")
                    {
                        model.SId = int.Parse(dt.Rows[n]["SId"].ToString());
                    }
                    model.CompanyWebsite = dt.Rows[n]["CompanyWebsite"].ToString();
                    model.CompanyPhone = dt.Rows[n]["CompanyPhone"].ToString();
                    model.CautionMoney = dt.Rows[n]["CautionMoney"].ToString();
                    model.Guarantee = dt.Rows[n]["Guarantee"].ToString();
                    model.GuaranteeMobile = dt.Rows[n]["GuaranteeMobile"].ToString();
                    model.Balance = dt.Rows[n]["Balance"].ToString();
                    model.LockBalance = dt.Rows[n]["LockBalance"].ToString();
                    model.TotalBalance = dt.Rows[n]["TotalBalance"].ToString();
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    model.SignName = dt.Rows[n]["SignName"].ToString();
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    model.extend1 = dt.Rows[n]["extend1"].ToString();
                    model.extend2 = dt.Rows[n]["extend2"].ToString();
                    model.extend3 = dt.Rows[n]["extend3"].ToString();
                    model.extend4 = dt.Rows[n]["extend4"].ToString();
                    model.extend5 = dt.Rows[n]["extend5"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.UserMobile = dt.Rows[n]["UserMobile"].ToString();
                    model.UserEmail = dt.Rows[n]["UserEmail"].ToString();
                    model.UserAdress = dt.Rows[n]["UserAdress"].ToString();
                    if (dt.Rows[n]["UserQQ"].ToString() != "")
                    {
                        model.UserQQ = dt.Rows[n]["UserQQ"].ToString();
                    }
                    model.UserWechat = dt.Rows[n]["UserWechat"].ToString();
                    model.CorporateName = dt.Rows[n]["CorporateName"].ToString();


                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public SupplierInfo GetModelBySId(int SId)
        {
            return dal.GetModelBySId(SId);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        public string GetSignName(int SId)
        {
            return dal.GetSignName(SId);
        }
        #endregion
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
    }
}
