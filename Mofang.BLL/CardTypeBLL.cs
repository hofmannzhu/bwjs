using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Mofang.DAL;
using Mofang.Model;
using Mofang.Model.ViewModel;

namespace Mofang.BLL {
	 	//退保表单
		public partial class CardTypeBLL
    {
   		     
		private readonly  CardTypeDAL dal= new CardTypeDAL();
		public CardTypeBLL()
		{}
		
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(CardType model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CardType model)
		{
			return dal.Update(model);
		}

		///// <summary>
		///// 删除一条数据
		///// </summary>
		//public bool UpdateDelete(int CDID)
		//{
			
		//	return dal.UpdateDelete(CDID);
		//}
		//		/// <summary>
		///// 批量删除一批数据
		///// </summary>
		//public bool UpdateDeleteList(string CDIDlist )
		//{
		//	return dal.UpdateDeleteList(CDIDlist );
		//}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CardType GetModel(int CDID)
		{
			
			return dal.GetModel(CDID);
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
		public List<CardType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<CardType> DataTableToList(DataTable dt)
		{
			List<CardType> modelList = new List<CardType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				CardType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new CardType();					
													if(dt.Rows[n]["CDID"].ToString()!="")
				{
					model.CDID=int.Parse(dt.Rows[n]["CDID"].ToString());
				}
																																if(dt.Rows[n]["Value"].ToString()!="")
				{
					model.Value=int.Parse(dt.Rows[n]["Value"].ToString());
				}
																																				model.Name= dt.Rows[n]["Name"].ToString();
																												if(dt.Rows[n]["Sort"].ToString()!="")
				{
					model.Sort=int.Parse(dt.Rows[n]["Sort"].ToString());
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

        public List<CardTypeViewModel> GetCardTypeList(string caseCode)
        {
            return dal.GetCardTypeList(caseCode);
        }
        #endregion

    }
}