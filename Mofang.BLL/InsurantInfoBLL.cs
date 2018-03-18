using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.DAL;
using Mofang.Model;

namespace Mofang.BLL {
	 	//被投保人信息表
		public partial class InsurantInfoBLL
    {
   		     
		private readonly InsurantInfoDAL dal=new InsurantInfoDAL();
		public InsurantInfoBLL()
		{}
		
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(InsurantInfo model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(InsurantInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool UpdateDelete(int InsurantInfoID)
		{
			
			return dal.UpdateDelete(InsurantInfoID);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool UpdateDeleteList(string InsurantInfoIDlist )
		{
			return dal.UpdateDeleteList(InsurantInfoIDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public InsurantInfo GetModel(int InsurantInfoID)
		{
			
			return dal.GetModel(InsurantInfoID);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<InsurantInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<InsurantInfo> DataTableToList(DataTable dt)
		{
			List<InsurantInfo> modelList = new List<InsurantInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				InsurantInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new InsurantInfo();					
													if(dt.Rows[n]["InsurantInfoID"].ToString()!="")
				{
					model.InsurantInfoID=int.Parse(dt.Rows[n]["InsurantInfoID"].ToString());
				}
																																if(dt.Rows[n]["OrderApplyID"].ToString()!="")
				{
					model.OrderApplyID=int.Parse(dt.Rows[n]["OrderApplyID"].ToString());
				}
																																				model.CName= dt.Rows[n]["CName"].ToString();
																																model.EName= dt.Rows[n]["EName"].ToString();
																												if(dt.Rows[n]["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(dt.Rows[n]["Sex"].ToString());
				}
																																if(dt.Rows[n]["CardType"].ToString()!="")
				{
					model.CardType=int.Parse(dt.Rows[n]["CardType"].ToString());
				}
																																				model.CardCode= dt.Rows[n]["CardCode"].ToString();
																																model.Birthday= dt.Rows[n]["Birthday"].ToString();
																												if(dt.Rows[n]["RelationID"].ToString()!="")
				{
					model.RelationID=int.Parse(dt.Rows[n]["RelationID"].ToString());
				}
																																if(dt.Rows[n]["Count"].ToString()!="")
				{
					model.Count=int.Parse(dt.Rows[n]["Count"].ToString());
				}
																																if(dt.Rows[n]["SinglePrice"].ToString()!="")
				{
					model.SinglePrice=decimal.Parse(dt.Rows[n]["SinglePrice"].ToString());
				}
																																				model.CardPeriod= dt.Rows[n]["CardPeriod"].ToString();
																																model.Mobile= dt.Rows[n]["Mobile"].ToString();
																												if(dt.Rows[n]["CreatUserID"].ToString()!="")
				{
					model.CreatUserID=int.Parse(dt.Rows[n]["CreatUserID"].ToString());
				}
																																if(dt.Rows[n]["RecordUpdateUserID"].ToString()!="")
				{
					model.RecordUpdateUserID=int.Parse(dt.Rows[n]["RecordUpdateUserID"].ToString());
				}
																																																if(dt.Rows[n]["RecordIsDelete"].ToString()!="")
				{
					if((dt.Rows[n]["RecordIsDelete"].ToString()=="1")||(dt.Rows[n]["RecordIsDelete"].ToString().ToLower()=="true"))
					{
					model.RecordIsDelete= true;
					}
					else
					{
					model.RecordIsDelete= false;
					}
				}
																if(dt.Rows[n]["RecordUpdateTime"].ToString()!="")
				{
					model.RecordUpdateTime=DateTime.Parse(dt.Rows[n]["RecordUpdateTime"].ToString());
				}
																																if(dt.Rows[n]["RecordCreateTime"].ToString()!="")
				{
					model.RecordCreateTime=DateTime.Parse(dt.Rows[n]["RecordCreateTime"].ToString());
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



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public InsurantInfo GetOrdertModel(int InsurantInfoID)
        {

            return dal.GetOrderModel(InsurantInfoID);
        }

    }
}