using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.DAL;
using Mofang.Model;

namespace Mofang.BLL {
	 	//交易表
		public partial class TransactionsBLL
    {
   		     
		private readonly TransactionsDAL dal=new TransactionsDAL();
		public TransactionsBLL()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TransNo,int TransactionID)
		{
			return dal.Exists(TransNo,TransactionID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Transactions model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Transactions model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool UpdateDelete(int TransactionID)
		{
			
			return dal.UpdateDelete(TransactionID);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool UpdateDeleteList(string TransactionIDlist )
		{
			return dal.UpdateDeleteList(TransactionIDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Transactions GetModel(int TransactionID)
		{
			
			return dal.GetModel(TransactionID);
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
		public List<Transactions> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Transactions> DataTableToList(DataTable dt)
		{
			List<Transactions> modelList = new List<Transactions>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Transactions model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Transactions();					
																	model.TransNo= dt.Rows[n]["TransNo"].ToString();
																												if(dt.Rows[n]["TransactionID"].ToString()!="")
				{
					model.TransactionID=int.Parse(dt.Rows[n]["TransactionID"].ToString());
				}
																																				model.Customkey= dt.Rows[n]["Customkey"].ToString();
																																model.InsurantDateLimit= dt.Rows[n]["InsurantDateLimit"].ToString();
																																model.CaseCode= dt.Rows[n]["CaseCode"].ToString();
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