using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

using BWJSLog.DAL;
using BWJSLog.Model;

namespace BWJSLog.BLL
{
	 	//魔方接受日志
		public partial class MofangReceivedLogBLL
    {
   		     
		private readonly MofangReceivedLogDAL dal=new MofangReceivedLogDAL();
		public MofangReceivedLogBLL()
		{}
		
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MofangReceivedLog model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MofangReceivedLog model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool UpdateDelete(int MofangReceivedLogID)
		{
			
			return dal.UpdateDelete(MofangReceivedLogID);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool UpdateDeleteList(string MofangReceivedLogIDlist )
		{
			return dal.UpdateDeleteList(MofangReceivedLogIDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MofangReceivedLog GetModel(int MofangReceivedLogID)
		{
			
			return dal.GetModel(MofangReceivedLogID);
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
		public List<MofangReceivedLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MofangReceivedLog> DataTableToList(DataTable dt)
		{
			List<MofangReceivedLog> modelList = new List<MofangReceivedLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MofangReceivedLog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new MofangReceivedLog();					
													if(dt.Rows[n]["MofangReceivedLogID"].ToString()!="")
				{
					model.MofangReceivedLogID=int.Parse(dt.Rows[n]["MofangReceivedLogID"].ToString());
				}
																																				model.MothodName= dt.Rows[n]["MothodName"].ToString();
																																model.TransNo= dt.Rows[n]["TransNo"].ToString();
																																												if(dt.Rows[n]["IsProcessed"].ToString()!="")
				{
					if((dt.Rows[n]["IsProcessed"].ToString()=="1")||(dt.Rows[n]["IsProcessed"].ToString().ToLower()=="true"))
					{
					model.IsProcessed= true;
					}
					else
					{
					model.IsProcessed= false;
					}
				}
																				model.Message= dt.Rows[n]["Message"].ToString();
																												if(dt.Rows[n]["ReceivedTime"].ToString()!="")
				{
					model.ReceivedTime=DateTime.Parse(dt.Rows[n]["ReceivedTime"].ToString());
				}
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
   
	}
}