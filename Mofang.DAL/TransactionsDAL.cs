using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using Mofang.Model; 
namespace Mofang.DAL
{
	 	//交易表
		public partial class TransactionsDAL : BaseService
	{
   		     
		public bool Exists(string TransNo,int TransactionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Transactions");
			strSql.Append(" where ");
			                                       strSql.Append(" TransNo = @TransNo and  ");
                                                                   strSql.Append(" TransactionID = @TransactionID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@TransNo", SqlDbType.NVarChar,50),
					new SqlParameter("@TransactionID", SqlDbType.Int,4)			};
			parameters[0].Value = TransNo;
			parameters[1].Value = TransactionID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Transactions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Transactions(");			
            strSql.Append("TransNo,Customkey,InsurantDateLimit,CaseCode,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime");
			strSql.Append(") values (");
            strSql.Append("@TransNo,@Customkey,@InsurantDateLimit,@CaseCode,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime");            
            strSql.Append(") ");            
            strSql.Append(";select SCOPE_IDENTITY()");		
			SqlParameter[] parameters = {
			            new SqlParameter("@TransNo", model.TransNo) ,            
                        new SqlParameter("@Customkey", model.Customkey) ,            
                        new SqlParameter("@InsurantDateLimit", model.InsurantDateLimit) ,            
                        new SqlParameter("@CaseCode",  model.CaseCode) ,            
                        new SqlParameter("@CreatUserID",  model.CreatUserID) ,            
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,            
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,            
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,            
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime)             
              
            };  
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}			   
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Transactions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Transactions set ");
			            	            strSql.Append(" TransNo = @TransNo , ");
	                                                            	            strSql.Append(" Customkey = @Customkey , ");
	                                    	            strSql.Append(" InsurantDateLimit = @InsurantDateLimit , ");
	                                    	            strSql.Append(" CaseCode = @CaseCode , ");
	                                    	            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
	                                                     strSql.Append(" RecordUpdateTime = GetDate() ");
	                        			
			strSql.Append(" where TransactionID=@TransactionID  and RecordUpdateTime = @RecordUpdateTime");
						
SqlParameter[] parameters = {
			            new SqlParameter("@TransNo", model.TransNo) ,            
                        new SqlParameter("@TransactionID", model.TransactionID) ,            
                        new SqlParameter("@Customkey", model.Customkey) ,            
                        new SqlParameter("@InsurantDateLimit", model.InsurantDateLimit) ,            
                        new SqlParameter("@CaseCode", model.CaseCode) ,       
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,   
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime)    
              
            };            
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool UpdateDelete(int TransactionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Transactions set  RecordIsDelete =1  ");
			strSql.Append(" where TransactionID=@TransactionID");
						SqlParameter[] parameters = {
					new SqlParameter("@TransactionID", SqlDbType.Int,4)
			};
			parameters[0].Value = TransactionID;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool UpdateDeleteList(string TransactionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Transactions set  RecordIsDelete =1  ");
			strSql.Append(" where ID in ("+TransactionIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Transactions GetModel(int TransactionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TransNo, TransactionID, Customkey, InsurantDateLimit, CaseCode, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime  ");			
			strSql.Append("  from Transactions ");
			strSql.Append(" where TransactionID=@TransactionID");
						SqlParameter[] parameters = {
					new SqlParameter("@TransactionID", SqlDbType.Int,4)
			};
			parameters[0].Value = TransactionID;

			
			Transactions model=new Transactions();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.TransNo= ds.Tables[0].Rows[0]["TransNo"].ToString();
																												if(ds.Tables[0].Rows[0]["TransactionID"].ToString()!="")
				{
					model.TransactionID=int.Parse(ds.Tables[0].Rows[0]["TransactionID"].ToString());
				}
																																				model.Customkey= ds.Tables[0].Rows[0]["Customkey"].ToString();
																																model.InsurantDateLimit= ds.Tables[0].Rows[0]["InsurantDateLimit"].ToString();
																																model.CaseCode= ds.Tables[0].Rows[0]["CaseCode"].ToString();
																												if(ds.Tables[0].Rows[0]["CreatUserID"].ToString()!="")
				{
					model.CreatUserID=int.Parse(ds.Tables[0].Rows[0]["CreatUserID"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString()!="")
				{
					model.RecordUpdateUserID=int.Parse(ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString());
				}
																																																if(ds.Tables[0].Rows[0]["RecordIsDelete"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["RecordIsDelete"].ToString()=="1")||(ds.Tables[0].Rows[0]["RecordIsDelete"].ToString().ToLower()=="true"))
					{
					model.RecordIsDelete= true;
					}
					else
					{
					model.RecordIsDelete= false;
					}
				}
																if(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString()!="")
				{
					model.RecordUpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString()!="")
				{
					model.RecordCreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM Transactions ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM Transactions ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

