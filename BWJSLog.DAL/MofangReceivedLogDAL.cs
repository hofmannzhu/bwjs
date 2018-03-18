using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using BWJSLog.Model;

namespace BWJSLog.DAL
{
	 	//魔方接受日志
		public partial class MofangReceivedLogDAL : BaseService
	{
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MofangReceivedLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MofangReceivedLog(");			
            strSql.Append("MothodName,TransNo,IsProcessed,Message,ReceivedTime,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime");
			strSql.Append(") values (");
            strSql.Append("@MothodName,@TransNo,@IsProcessed,@Message,@ReceivedTime,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime");            
            strSql.Append(") ");            
            strSql.Append(";select SCOPE_IDENTITY()");		
			SqlParameter[] parameters = {
			            new SqlParameter("@MothodName", model.MothodName) ,            
                        new SqlParameter("@TransNo",model.TransNo) ,            
                        new SqlParameter("@IsProcessed",  model.IsProcessed) ,            
                        new SqlParameter("@Message", model.Message) ,            
                        new SqlParameter("@ReceivedTime", model.ReceivedTime) ,            
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,            
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,            
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,            
                        new SqlParameter("@RecordUpdateTime",model.RecordUpdateTime) ,            
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime)             
              
            }; 
			object obj = BWJSLogHelperSQL.GetSingle(strSql.ToString(),parameters);			
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
		public bool Update(MofangReceivedLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MofangReceivedLog set ");
			                                    	            strSql.Append(" MothodName = @MothodName , ");
	                                    	            strSql.Append(" TransNo = @TransNo , ");
	                                    	            strSql.Append(" IsProcessed = @IsProcessed , ");
	                                    	            strSql.Append(" Message = @Message , ");
	                                    	            strSql.Append(" ReceivedTime = @ReceivedTime , ");	                                    
	                                    	            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");	                                   
	                                                     strSql.Append(" RecordUpdateTime = GetDate() ");                                    	          
	                        			
			strSql.Append(" where MofangReceivedLogID=@MofangReceivedLogID  and RecordUpdateTime = @RecordUpdateTime");
						
SqlParameter[] parameters = {
			            new SqlParameter("@MofangReceivedLogID", model.MofangReceivedLogID) ,            
                        new SqlParameter("@MothodName", model.MothodName) ,            
                        new SqlParameter("@TransNo", model.TransNo) ,            
                        new SqlParameter("@IsProcessed", model.IsProcessed) ,            
                        new SqlParameter("@Message", model.Message) ,            
                        new SqlParameter("@ReceivedTime", model.ReceivedTime) ,            
                  
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,            
               
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime)           
                      
              
            }; 	                       
            int rows=BWJSLogHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool UpdateDelete(int MofangReceivedLogID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MofangReceivedLog set  RecordIsDelete =1   ");
			strSql.Append(" where MofangReceivedLogID=@MofangReceivedLogID");
						SqlParameter[] parameters = {
					new SqlParameter("@MofangReceivedLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = MofangReceivedLogID;


			int rows=BWJSLogHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool UpdateDeleteList(string MofangReceivedLogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MofangReceivedLog set  RecordIsDelete =1");
			strSql.Append(" where ID in ("+MofangReceivedLogIDlist + ")  ");
			int rows=BWJSLogHelperSQL.ExecuteSql(strSql.ToString());
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
		public MofangReceivedLog GetModel(int MofangReceivedLogID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MofangReceivedLogID, MothodName, TransNo, IsProcessed, Message, ReceivedTime, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime  ");			
			strSql.Append("  from MofangReceivedLog ");
			strSql.Append(" where MofangReceivedLogID=@MofangReceivedLogID");
						SqlParameter[] parameters = {
					new SqlParameter("@MofangReceivedLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = MofangReceivedLogID;

			
			MofangReceivedLog model=new MofangReceivedLog();
			DataSet ds=BWJSLogHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["MofangReceivedLogID"].ToString()!="")
				{
					model.MofangReceivedLogID=int.Parse(ds.Tables[0].Rows[0]["MofangReceivedLogID"].ToString());
				}
																																				model.MothodName= ds.Tables[0].Rows[0]["MothodName"].ToString();
																																model.TransNo= ds.Tables[0].Rows[0]["TransNo"].ToString();
																																												if(ds.Tables[0].Rows[0]["IsProcessed"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsProcessed"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsProcessed"].ToString().ToLower()=="true"))
					{
					model.IsProcessed= true;
					}
					else
					{
					model.IsProcessed= false;
					}
				}
																				model.Message= ds.Tables[0].Rows[0]["Message"].ToString();
																												if(ds.Tables[0].Rows[0]["ReceivedTime"].ToString()!="")
				{
					model.ReceivedTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReceivedTime"].ToString());
				}
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
			strSql.Append(" FROM MofangReceivedLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return BWJSLogHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" FROM MofangReceivedLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return BWJSLogHelperSQL.Query(strSql.ToString());
		}

   
	}
}

