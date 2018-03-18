using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using BWJSLog.Model;

namespace BWJSLog.DAL
{
	 	//魔方发送日志表
		public partial class MofangSendLogDAL : BaseService
	{
   		     		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MofangSendLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MofangSendLog(");			
            strSql.Append("MothodName,FKID,TransNo,IsSend,Message,SendTime,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime");
			strSql.Append(") values (");
            strSql.Append("@MothodName,@FKID,@TransNo,@IsSend,@Message,@SendTime,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime");            
            strSql.Append(") ");            
            strSql.Append(";select SCOPE_IDENTITY()");		
			SqlParameter[] parameters = {
			            new SqlParameter("@MothodName",  model.MothodName) ,            
                        new SqlParameter("@FKID", model.FKID) ,            
                        new SqlParameter("@TransNo", model.TransNo) ,            
                        new SqlParameter("@IsSend",  model.IsSend) ,            
                        new SqlParameter("@Message", model.Message) ,            
                        new SqlParameter("@SendTime",  model.SendTime) ,            
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,            
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,            
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,            
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,            
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
		public bool Update(MofangSendLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MofangSendLog set ");
			                                    	            strSql.Append(" MothodName = @MothodName , ");
	                                    	            strSql.Append(" FKID = @FKID , ");
	                                    	            strSql.Append(" TransNo = @TransNo , ");
	                                    	            strSql.Append(" IsSend = @IsSend , ");
	                                    	            strSql.Append(" Message = @Message , ");
	                                    	            strSql.Append(" SendTime = @SendTime , ");
	                                    	            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");	                                    
	                                                     strSql.Append(" RecordUpdateTime = GetDate() ");                                    	      
	                        			
			strSql.Append(" where MofangSendLogID=@MofangSendLogID  and RecordUpdateTime = @RecordUpdateTime");						
SqlParameter[] parameters = {
			            new SqlParameter("@MofangSendLogID", model.MofangSendLogID) ,            
                        new SqlParameter("@MothodName", model.MothodName) ,            
                        new SqlParameter("@FKID", model.FKID) ,            
                        new SqlParameter("@TransNo", model.TransNo) ,            
                        new SqlParameter("@IsSend", model.IsSend) ,            
                        new SqlParameter("@Message", model.Message) ,            
                        new SqlParameter("@SendTime", model.SendTime) ,       
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
		public bool UpdateDelete(int MofangSendLogID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MofangSendLog set  RecordIsDelete =1    ");
			strSql.Append(" where MofangSendLogID=@MofangSendLogID");
						SqlParameter[] parameters = {
					new SqlParameter("@MofangSendLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = MofangSendLogID;


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
		public bool UpdateDeleteList(string MofangSendLogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MofangSendLog set  RecordIsDelete =1 ");
			strSql.Append(" where ID in ("+MofangSendLogIDlist + ")  ");
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
		public MofangSendLog GetModel(int MofangSendLogID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MofangSendLogID, MothodName, FKID, TransNo, IsSend, Message, SendTime, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime  ");			
			strSql.Append("  from MofangSendLog ");
			strSql.Append(" where MofangSendLogID=@MofangSendLogID");
						SqlParameter[] parameters = {
					new SqlParameter("@MofangSendLogID", SqlDbType.Int,4)
			};
			parameters[0].Value = MofangSendLogID;

			
			MofangSendLog model=new MofangSendLog();
			DataSet ds=BWJSLogHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["MofangSendLogID"].ToString()!="")
				{
					model.MofangSendLogID=int.Parse(ds.Tables[0].Rows[0]["MofangSendLogID"].ToString());
				}
																																				model.MothodName= ds.Tables[0].Rows[0]["MothodName"].ToString();
																												if(ds.Tables[0].Rows[0]["FKID"].ToString()!="")
				{
					model.FKID=int.Parse(ds.Tables[0].Rows[0]["FKID"].ToString());
				}
																																				model.TransNo= ds.Tables[0].Rows[0]["TransNo"].ToString();
																																												if(ds.Tables[0].Rows[0]["IsSend"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsSend"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsSend"].ToString().ToLower()=="true"))
					{
					model.IsSend= true;
					}
					else
					{
					model.IsSend= false;
					}
				}
																				model.Message= ds.Tables[0].Rows[0]["Message"].ToString();
																												if(ds.Tables[0].Rows[0]["SendTime"].ToString()!="")
				{
					model.SendTime=DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
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
			strSql.Append(" FROM MofangSendLog ");
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
			strSql.Append(" FROM MofangSendLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return BWJSLogHelperSQL.Query(strSql.ToString());
		}

   
	}
}

