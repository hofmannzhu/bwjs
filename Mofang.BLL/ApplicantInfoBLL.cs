using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.DAL;
using Mofang.Model;

namespace Mofang.BLL {
	 	//投保人信息
		public partial class ApplicantInfoBLL
    {

        private readonly   ApplicantInfoDAL dal = new  ApplicantInfoDAL();
		public ApplicantInfoBLL()
		{}
		
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ApplicantInfo model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApplicantInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool UpdateDelete(int ApplicantInfoID)
		{
			
			return dal.UpdateDelete(ApplicantInfoID);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool UpdateDeleteList(string ApplicantInfoIDlist )
		{
			return dal.UpdateDeleteList(ApplicantInfoIDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApplicantInfo GetModel(int ApplicantInfoID)
		{
			
			return dal.GetModel(ApplicantInfoID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
	

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
		public List<ApplicantInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApplicantInfo> DataTableToList(DataTable dt)
		{
			List<ApplicantInfo> modelList = new List<ApplicantInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApplicantInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApplicantInfo();					
													if(dt.Rows[n]["ApplicantInfoID"].ToString()!="")
				{
					model.ApplicantInfoID=int.Parse(dt.Rows[n]["ApplicantInfoID"].ToString());
				}
																																if(dt.Rows[n]["OrderApplyID"].ToString()!="")
				{
					model.OrderApplyID=int.Parse(dt.Rows[n]["OrderApplyID"].ToString());
				}
																																				model.CName= dt.Rows[n]["CName"].ToString();
																																model.EName= dt.Rows[n]["EName"].ToString();
																												if(dt.Rows[n]["CardType"].ToString()!="")
				{
					model.CardType=int.Parse(dt.Rows[n]["CardType"].ToString());
				}
																																				model.CardCode= dt.Rows[n]["CardCode"].ToString();
																												if(dt.Rows[n]["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(dt.Rows[n]["Sex"].ToString());
				}
																																				model.BirthDay= dt.Rows[n]["BirthDay"].ToString();
																																model.Mobile= dt.Rows[n]["Mobile"].ToString();
																																model.Email= dt.Rows[n]["Email"].ToString();
																																model.CardPeriod= dt.Rows[n]["CardPeriod"].ToString();
																												if(dt.Rows[n]["CreatUserID"].ToString()!="")
				{
					model.CreatUserID=int.Parse(dt.Rows[n]["CreatUserID"].ToString());
				}
																																if(dt.Rows[n]["RecordUpdateUserID"].ToString()!="")
				{
					model.RecordUpdateUserID=int.Parse(dt.Rows[n]["RecordUpdateUserID"].ToString());
				}
																																if(dt.Rows[n]["RecordUpdateTime"].ToString()!="")
				{
					model.RecordUpdateTime=DateTime.Parse(dt.Rows[n]["RecordUpdateTime"].ToString());
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
        public ApplicantInfoBackups GetOrderModel(int OrderApplyID)
        {

            return dal.GetOrderModel(OrderApplyID);
        }

    }
}