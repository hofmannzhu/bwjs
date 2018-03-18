using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.DAL;
using Mofang.Model;
namespace Mofang.BLL {
	 	//订单信息
		public partial class ApplicationDataBLL
    {

        private readonly ApplicationDataDAL dal = new ApplicationDataDAL();
		public ApplicationDataBLL()
		{}
		
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(ApplicationData model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ApplicationData model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool UpdateDelete(int AppDataID)
		{
			
			return dal.UpdateDelete(AppDataID);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool UpdateDeleteList(string AppDataIDlist )
		{
			return dal.UpdateDeleteList(AppDataIDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ApplicationData GetModel(int AppDataID)
		{
			
			return dal.GetModel(AppDataID);
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
		public List<ApplicationData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ApplicationData> DataTableToList(DataTable dt)
		{
			List<ApplicationData> modelList = new List<ApplicationData>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ApplicationData model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ApplicationData();					
													if(dt.Rows[n]["AppDataID"].ToString()!="")
				{
					model.AppDataID=int.Parse(dt.Rows[n]["AppDataID"].ToString());
				}
																																if(dt.Rows[n]["OrderApplyID"].ToString()!="")
				{
					model.OrderApplyID=int.Parse(dt.Rows[n]["OrderApplyID"].ToString());
				}
																																				model.ApplicationDate= dt.Rows[n]["ApplicationDate"].ToString();
																																model.StartDate= dt.Rows[n]["StartDate"].ToString();
																																model.EndDate= dt.Rows[n]["EndDate"].ToString();
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
																if(dt.Rows[n]["RecordCreateTime"].ToString()!="")
				{
					model.RecordCreateTime=DateTime.Parse(dt.Rows[n]["RecordCreateTime"].ToString());
				}
																																if(dt.Rows[n]["RecordUpdateTime"].ToString()!="")
				{
					model.RecordUpdateTime=DateTime.Parse(dt.Rows[n]["RecordUpdateTime"].ToString());
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