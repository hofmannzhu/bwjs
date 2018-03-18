using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mofang.Model;
using Mofang.DAL;
namespace Mofang.BLL
{
    public partial class OtherInfoBLL
    {

        private readonly OtherInfoDAL    dal = new OtherInfoDAL();
        public OtherInfoBLL()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OtherInfo model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(OtherInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int OtherInfoID)
        {

            return dal.UpdateDelete(OtherInfoID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool UpdateDeleteList(string OtherInfoIDlist)
        {
            return dal.UpdateDeleteList(OtherInfoIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OtherInfo GetModel(int OtherInfoID)
        {

            return dal.GetModel(OtherInfoID);
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
        public List<OtherInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<OtherInfo> DataTableToList(DataTable dt)
        {
            List<OtherInfo> modelList = new List<OtherInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                OtherInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new OtherInfo();
                    if (dt.Rows[n]["OtherInfoID"].ToString() != "")
                    {
                        model.OtherInfoID = int.Parse(dt.Rows[n]["OtherInfoID"].ToString());
                    }
                    if (dt.Rows[n]["RecordCreateTime"].ToString() != "")
                    {
                        model.RecordCreateTime = DateTime.Parse(dt.Rows[n]["RecordCreateTime"].ToString());
                    }
                    model.ProvCityID = dt.Rows[n]["ProvCityID"].ToString();
                    if (dt.Rows[n]["CardPeriod"].ToString() != "")
                    {
                        model.CardPeriod = DateTime.Parse(dt.Rows[n]["CardPeriod"].ToString());
                    }
                    if (dt.Rows[n]["NotifyAnswerID"].ToString() != "")
                    {
                        model.NotifyAnswerID = int.Parse(dt.Rows[n]["NotifyAnswerID"].ToString());
                    }
                    model.PriceArgsID = dt.Rows[n]["PriceArgsID"].ToString();
                    if (dt.Rows[n]["CreatUserID"].ToString() != "")
                    {
                        model.CreatUserID = int.Parse(dt.Rows[n]["CreatUserID"].ToString());
                    }
                    if (dt.Rows[n]["RecordUpdateUserID"].ToString() != "")
                    {
                        model.RecordUpdateUserID = int.Parse(dt.Rows[n]["RecordUpdateUserID"].ToString());
                    }
                    if (dt.Rows[n]["RecordIsDelete"].ToString() != "")
                    {
                        if ((dt.Rows[n]["RecordIsDelete"].ToString() == "1") || (dt.Rows[n]["RecordIsDelete"].ToString().ToLower() == "true"))
                        {
                            model.RecordIsDelete = true;
                        }
                        else
                        {
                            model.RecordIsDelete = false;
                        }
                    }
                    if (dt.Rows[n]["RecordUpdateTime"].ToString() != "")
                    {
                        model.RecordUpdateTime = DateTime.Parse(dt.Rows[n]["RecordUpdateTime"].ToString());
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
        #endregion
    }
}
