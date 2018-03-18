using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BWJSLog.DAL;
using BWJSLog.Model;

namespace BWJSLog.BLL
{
	 	//魔方发送日志表
		public partial class MofangSendLogBLL
    {
   		     
		private readonly MofangSendLogDAL dal=new MofangSendLogDAL();
		public MofangSendLogBLL()
		{}
		
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MofangSendLog model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MofangSendLog model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool UpdateDelete(int MofangSendLogID)
		{
			
			return dal.UpdateDelete(MofangSendLogID);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool UpdateDeleteList(string MofangSendLogIDlist )
		{
			return dal.UpdateDeleteList(MofangSendLogIDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MofangSendLog GetModel(int MofangSendLogID)
		{
			
			return dal.GetModel(MofangSendLogID);
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
		public List<MofangSendLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MofangSendLog> DataTableToList(DataTable dt)
		{
			List<MofangSendLog> modelList = new List<MofangSendLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MofangSendLog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new MofangSendLog();					
													if(dt.Rows[n]["MofangSendLogID"].ToString()!="")
				{
					model.MofangSendLogID=int.Parse(dt.Rows[n]["MofangSendLogID"].ToString());
				}
																																				model.MothodName= dt.Rows[n]["MothodName"].ToString();
																												if(dt.Rows[n]["FKID"].ToString()!="")
				{
					model.FKID=int.Parse(dt.Rows[n]["FKID"].ToString());
				}
																																				model.TransNo= dt.Rows[n]["TransNo"].ToString();
																																												if(dt.Rows[n]["IsSend"].ToString()!="")
				{
					if((dt.Rows[n]["IsSend"].ToString()=="1")||(dt.Rows[n]["IsSend"].ToString().ToLower()=="true"))
					{
					model.IsSend= true;
					}
					else
					{
					model.IsSend= false;
					}
				}
																				model.Message= dt.Rows[n]["Message"].ToString();
																												if(dt.Rows[n]["SendTime"].ToString()!="")
				{
					model.SendTime=DateTime.Parse(dt.Rows[n]["SendTime"].ToString());
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