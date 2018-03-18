using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.DAL;
using Mofang.Model;
using Mofang.Model.ViewModel;

namespace Mofang.BLL
{
    //投保人与被投保人关系表
    public partial class RelationBLL
    {

        private readonly RelationDAL dal = new RelationDAL();
        public RelationBLL()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Relation model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Relation model)
        {
            return dal.Update(model);
        }

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool UpdateDelete(int ID)
        //{

        //	return dal.UpdateDelete(ID);
        //}
        //		/// <summary>
        ///// 批量删除一批数据
        ///// </summary>
        //public bool UpdateDeleteList(string IDlist )
        //{
        //	return dal.UpdateDeleteList(IDlist );
        //}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Relation GetModel(int ID)
        {

            return dal.GetModel(ID);
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
        public List<Relation> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Relation> DataTableToList(DataTable dt)
        {
            List<Relation> modelList = new List<Relation>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Relation model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Relation();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
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

        public List<RelationViewModel> GetRelationViewModelList(string caseCode)
        {
            return dal.GetRelationViewModelList(caseCode);
        }
        #endregion

    }
}