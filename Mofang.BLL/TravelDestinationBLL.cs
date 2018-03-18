using Mofang.DAL;
using Mofang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mofang.BLL
{
    /// <summary>
    /// 出行目的地
    /// </summary>
    public partial class TravelDestinationBLL
    {
        private readonly TravelDestinationDAL dal = new TravelDestinationDAL();
        public TravelDestinationBLL() { }
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Mofang.Model.TravelDestination model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Mofang.Model.TravelDestination model)
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
        public Mofang.Model.TravelDestination GetModel(int Id)
        {

            return dal.GetModel(Id);
        }
        /*
                /// <summary>
                /// 得到一个对象实体，从缓存中
                /// </summary>
                public BWJS.Model.TravelDestination GetModelByCache(int Id)
                {

                    string CacheKey = "TravelDestinationModel-" + Id;
                    object objModel = BWJS.Common.DataCache.GetCache(CacheKey);
                    if (objModel == null)
                    {
                        try
                        {
                            objModel = dal.GetModel(Id);
                            if (objModel != null)
                            {
                                int ModelCache = BWJS.Common.ConfigHelper.GetConfigInt("ModelCache");
                                BWJS.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                            }
                        }
                        catch{}
                    }
                    return (BWJS.Model.TravelDestination)objModel;
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
        public List<Mofang.Model.TravelDestination> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Mofang.Model.TravelDestination> DataTableToList(DataTable dt)
        {
            List<Mofang.Model.TravelDestination> modelList = new List<Mofang.Model.TravelDestination>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Mofang.Model.TravelDestination model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Mofang.Model.TravelDestination();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["Value"].ToString() != "")
                    {
                        model.Value = int.Parse(dt.Rows[n]["Value"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["Sort"].ToString() != "")
                    {
                        model.Sort = int.Parse(dt.Rows[n]["Sort"].ToString());
                    }


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
        public List<TravelDestination> GetTravelDestinationList(string caseCode)
        {
            return dal.GetTravelDestinationList(caseCode);
        }

    }
}
