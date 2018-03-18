using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using Mofang.Model;
namespace Mofang.DAL
{
    //投保人信息
    public partial class ApplicantInfoDAL : BaseService
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ApplicantInfo model, SqlTransaction trans, SqlConnection conn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ApplicantInfo(");
            strSql.Append("OrderApplyID,CName,EName,CardType,CardCode,Sex,BirthDay,Mobile,Email,CardPeriod,CreatUserID,RecordUpdateUserID,RecordUpdateTime,RecordIsDelete,RecordCreateTime,Job");
            strSql.Append(") values (");
            strSql.Append("@OrderApplyID,@CName,@EName,@CardType,@CardCode,@Sex,@BirthDay,@Mobile,@Email,@CardPeriod,@CreatUserID,@RecordUpdateUserID,@RecordUpdateTime,@RecordIsDelete,@RecordCreateTime,@Job");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@CName", model.CName) ,
                        new SqlParameter("@EName",  model.EName) ,
                        new SqlParameter("@CardType", model.CardType) ,
                        new SqlParameter("@CardCode", model.CardCode) ,
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@BirthDay", model.BirthDay) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@Email", model.Email) ,
                        new SqlParameter("@CardPeriod", model.CardPeriod) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime),
                        new SqlParameter("@Job", model.Job)
                        

            };

            object obj = DbHelperSQL.GetSingle(conn, trans, strSql.ToString(), parameters);
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
        /// 增加一条数据
        /// </summary>
        public int Add(ApplicantInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ApplicantInfo(");
            strSql.Append("OrderApplyID,CName,EName,CardType,CardCode,Sex,BirthDay,Mobile,Email,CardPeriod,CreatUserID,RecordUpdateUserID,RecordUpdateTime,RecordIsDelete,RecordCreateTime,Job");
            strSql.Append(") values (");
            strSql.Append("@OrderApplyID,@CName,@EName,@CardType,@CardCode,@Sex,@BirthDay,@Mobile,@Email,@CardPeriod,@CreatUserID,@RecordUpdateUserID,@RecordUpdateTime,@RecordIsDelete,@RecordCreateTime,@Job");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@CName", model.CName) ,
                        new SqlParameter("@EName",model.EName) ,
                        new SqlParameter("@CardType", model.CardType) ,
                        new SqlParameter("@CardCode",  model.CardCode) ,
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@BirthDay", model.BirthDay) ,
                        new SqlParameter("@Mobile",  model.Mobile) ,
                        new SqlParameter("@Email", model.Email) ,
                        new SqlParameter("@CardPeriod",model.CardPeriod) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime),
                        new SqlParameter("@Job", model.Job)
                        
            };
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(ApplicantInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApplicantInfo set ");
            strSql.Append(" OrderApplyID = @OrderApplyID , ");
            strSql.Append(" CName = @CName , ");
            strSql.Append(" EName = @EName , ");
            strSql.Append(" CardType = @CardType , ");
            strSql.Append(" CardCode = @CardCode , ");
            strSql.Append(" Sex = @Sex , ");
            strSql.Append(" BirthDay = @BirthDay , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" CardPeriod = @CardPeriod , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordUpdateTime = GetDate() ,");
            strSql.Append(" Job = @Job");
            
            strSql.Append(" where ApplicantInfoID=@ApplicantInfoID  and RecordUpdateTime = @RecordUpdateTime");

            SqlParameter[] parameters = {
                        new SqlParameter("@ApplicantInfoID",model.ApplicantInfoID) ,
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@CName", model.CName) ,
                        new SqlParameter("@EName", model.EName) ,
                        new SqlParameter("@CardType", model.CardType) ,
                        new SqlParameter("@CardCode", model.CardCode) ,
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@BirthDay", model.BirthDay) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@Email", model.Email) ,
                        new SqlParameter("@CardPeriod", model.CardPeriod) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@Job", model.Job)


            };
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool UpdateDelete(int ApplicantInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApplicantInfo set  RecordIsDelete =1   ");
            strSql.Append(" where ApplicantInfoID=@ApplicantInfoID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ApplicantInfoID", SqlDbType.Int,4)
            };
            parameters[0].Value = ApplicantInfoID;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool UpdateDeleteList(string ApplicantInfoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ApplicantInfo set  RecordIsDelete =1 ");
            strSql.Append(" where ID in (" + ApplicantInfoIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public ApplicantInfo GetModel(int ApplicantInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ApplicantInfoID, OrderApplyID, CName, EName, CardType, CardCode, Sex, BirthDay, Mobile, Email, CardPeriod, CreatUserID, RecordUpdateUserID, RecordUpdateTime, RecordIsDelete, RecordCreateTime ,Job ");
            strSql.Append("  from ApplicantInfo ");
            strSql.Append(" where ApplicantInfoID=@ApplicantInfoID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ApplicantInfoID", SqlDbType.Int,4)
            };
            parameters[0].Value = ApplicantInfoID;


            ApplicantInfo model = new ApplicantInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ApplicantInfoID"].ToString() != "")
                {
                    model.ApplicantInfoID = int.Parse(ds.Tables[0].Rows[0]["ApplicantInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderApplyID"].ToString() != "")
                {
                    model.OrderApplyID = int.Parse(ds.Tables[0].Rows[0]["OrderApplyID"].ToString());
                }
                model.CName = ds.Tables[0].Rows[0]["CName"].ToString();
                model.EName = ds.Tables[0].Rows[0]["EName"].ToString();
                if (ds.Tables[0].Rows[0]["CardType"].ToString() != "")
                {
                    model.CardType = int.Parse(ds.Tables[0].Rows[0]["CardType"].ToString());
                }
                model.CardCode = ds.Tables[0].Rows[0]["CardCode"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                model.BirthDay = ds.Tables[0].Rows[0]["BirthDay"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.CardPeriod = ds.Tables[0].Rows[0]["CardPeriod"].ToString();
                if (ds.Tables[0].Rows[0]["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(ds.Tables[0].Rows[0]["CreatUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordIsDelete"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["RecordIsDelete"].ToString() == "1") || (ds.Tables[0].Rows[0]["RecordIsDelete"].ToString().ToLower() == "true"))
                    {
                        model.RecordIsDelete = true;
                    }
                    else
                    {
                        model.RecordIsDelete = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Job"].ToString() != "")
                {
                    model.Job =ds.Tables[0].Rows[0]["Job"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ApplicantInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM ApplicantInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }





        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ApplicantInfoBackups GetOrderModel(int OrderApplyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  top 1 aio.ApplicantInfoID, aio.OrderApplyID, aio.CName, aio.EName, aio.CardType,
 aio.CardCode, aio.Sex, aio.BirthDay, aio.Mobile, aio.Email, aio.CardPeriod, aio.CreatUserID,
  aio.RecordUpdateUserID, aio.RecordUpdateTime, aio.RecordIsDelete, aio.RecordCreateTime, ct.Name as CardTypeName,ISNULL(u.UserName,'') as CreatUserName
    from ApplicantInfo aio LEFT JOIN dbo.CardType ct ON ct.Value = aio.CardType
	LEFT JOIN  [BWJSDB].[dbo].[Users] u  ON  u.UserID=aio.CreatUserID  AND u.RecordIsDelete=0
");
            strSql.Append(" where OrderApplyID=@OrderApplyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderApplyID", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderApplyID;

            ApplicantInfoBackups model = new ApplicantInfoBackups();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ApplicantInfoID"].ToString() != "")
                {
                    model.ApplicantInfoID = int.Parse(ds.Tables[0].Rows[0]["ApplicantInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderApplyID"].ToString() != "")
                {
                    model.OrderApplyID = int.Parse(ds.Tables[0].Rows[0]["OrderApplyID"].ToString());
                }
                model.CName = ds.Tables[0].Rows[0]["CName"].ToString();
                model.EName = ds.Tables[0].Rows[0]["EName"].ToString();
                if (ds.Tables[0].Rows[0]["CardType"].ToString() != "")
                {
                    model.CardType = int.Parse(ds.Tables[0].Rows[0]["CardType"].ToString());
                }
                model.CardCode = ds.Tables[0].Rows[0]["CardCode"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                model.BirthDay = ds.Tables[0].Rows[0]["BirthDay"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.CardPeriod = ds.Tables[0].Rows[0]["CardPeriod"].ToString();
                if (ds.Tables[0].Rows[0]["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(ds.Tables[0].Rows[0]["CreatUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordIsDelete"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["RecordIsDelete"].ToString() == "1") || (ds.Tables[0].Rows[0]["RecordIsDelete"].ToString().ToLower() == "true"))
                    {
                        model.RecordIsDelete = true;
                    }
                    else
                    {
                        model.RecordIsDelete = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CardTypeName"].ToString() != "")
                {
                    model.CardTypeName = ds.Tables[0].Rows[0]["CardTypeName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["CreatUserName"].ToString() != "")
                {
                    model.CreatUserName = ds.Tables[0].Rows[0]["CreatUserName"].ToString();
                }
                
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

