using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UtilityHelper;
using Mofang.Model;
namespace Mofang.DAL
{
    //被投保人信息表
    public partial class InsurantInfoDAL : BaseService
    {
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(InsurantInfo model, SqlTransaction trans, SqlConnection conn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into InsurantInfo(");
            strSql.Append("OrderApplyID,CName,EName,Sex,CardType,CardCode,Birthday,RelationID,Count,SinglePrice,CardPeriod,Mobile,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime,Email,Job");
            strSql.Append(") values (");
            strSql.Append("@OrderApplyID,@CName,@EName,@Sex,@CardType,@CardCode,@Birthday,@RelationID,@Count,@SinglePrice,@CardPeriod,@Mobile,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime,@Email,@Job");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@CName", model.CName) ,
                        new SqlParameter("@EName", model.EName) ,
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@CardType", model.CardType) ,
                        new SqlParameter("@CardCode",  model.CardCode) ,
                        new SqlParameter("@Birthday",model.Birthday) ,
                        new SqlParameter("@RelationID", model.RelationID) ,
                        new SqlParameter("@Count", model.Count) ,
                        new SqlParameter("@SinglePrice", model.SinglePrice) ,
                        new SqlParameter("@CardPeriod", model.CardPeriod) ,
                        new SqlParameter("@Mobile",  model.Mobile) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID",  model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime",  model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime),
                        new SqlParameter("@Email", model.Email),
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
        public int Add(InsurantInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into InsurantInfo(");
            strSql.Append("OrderApplyID,CName,EName,Sex,CardType,CardCode,Birthday,RelationID,Count,SinglePrice,CardPeriod,Mobile,CreatUserID,RecordUpdateUserID,RecordIsDelete,RecordUpdateTime,RecordCreateTime,Email,Job");
            strSql.Append(") values (");
            strSql.Append("@OrderApplyID,@CName,@EName,@Sex,@CardType,@CardCode,@Birthday,@RelationID,@Count,@SinglePrice,@CardPeriod,@Mobile,@CreatUserID,@RecordUpdateUserID,@RecordIsDelete,@RecordUpdateTime,@RecordCreateTime,@Email,@Job");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@CName", model.CName) ,
                        new SqlParameter("@EName",model.EName) ,
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@CardType", model.CardType) ,
                        new SqlParameter("@CardCode", model.CardCode) ,
                        new SqlParameter("@Birthday", model.Birthday) ,
                        new SqlParameter("@RelationID",model.RelationID) ,
                        new SqlParameter("@Count", model.Count) ,
                        new SqlParameter("@SinglePrice", model.SinglePrice) ,
                        new SqlParameter("@CardPeriod", model.CardPeriod) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@CreatUserID", model.CreatUserID) ,
                        new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordIsDelete", model.RecordIsDelete) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime) ,
                        new SqlParameter("@RecordCreateTime", model.RecordCreateTime) ,
                        new SqlParameter("@Email", model.Email),
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
        public bool Update(InsurantInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update InsurantInfo set ");
            strSql.Append(" OrderApplyID = @OrderApplyID , ");
            strSql.Append(" CName = @CName , ");
            strSql.Append(" EName = @EName , ");
            strSql.Append(" Sex = @Sex , ");
            strSql.Append(" CardType = @CardType , ");
            strSql.Append(" CardCode = @CardCode , ");
            strSql.Append(" Birthday = @Birthday , ");
            strSql.Append(" RelationID = @RelationID , ");
            strSql.Append(" Count = @Count , ");
            strSql.Append(" SinglePrice = @SinglePrice , ");
            strSql.Append(" CardPeriod = @CardPeriod , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordUpdateTime = GetDate(), ");
            strSql.Append(" Email = @Email ");
            strSql.Append(" Job = @Job ,");

            strSql.Append(" where InsurantInfoID=@InsurantInfoID  and RecordUpdateTime = @RecordUpdateTime");

            SqlParameter[] parameters = {
                        new SqlParameter("@InsurantInfoID",  model.InsurantInfoID) ,
                        new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                        new SqlParameter("@CName", model.CName) ,
                        new SqlParameter("@EName",  model.EName) ,
                        new SqlParameter("@Sex", model.Sex) ,
                        new SqlParameter("@CardType", model.CardType) ,
                        new SqlParameter("@CardCode", model.CardCode) ,
                        new SqlParameter("@Birthday", model.Birthday) ,
                        new SqlParameter("@RelationID",  model.RelationID) ,
                        new SqlParameter("@Count", model.Count) ,
                        new SqlParameter("@SinglePrice", model.SinglePrice) ,
                        new SqlParameter("@CardPeriod", model.CardPeriod) ,
                        new SqlParameter("@Mobile", model.Mobile) ,
                        new SqlParameter("@RecordUpdateUserID",model.RecordUpdateUserID) ,
                        new SqlParameter("@RecordUpdateTime", model.RecordUpdateTime)    ,
                        new SqlParameter("@Email", model.Email)    ,
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
        public bool UpdateDelete(int InsurantInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update InsurantInfo set  RecordIsDelete =1  ");
            strSql.Append(" where InsurantInfoID=@InsurantInfoID");
            SqlParameter[] parameters = {
                    new SqlParameter("@InsurantInfoID", SqlDbType.Int,4)
            };
            parameters[0].Value = InsurantInfoID;


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
        public bool UpdateDeleteList(string InsurantInfoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update InsurantInfo set  RecordIsDelete =1");
            strSql.Append(" where ID in (" + InsurantInfoIDlist + ")  ");
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
        public InsurantInfo GetModel(int InsurantInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select InsurantInfoID, OrderApplyID, CName, EName, Sex, CardType, CardCode, Birthday, RelationID, Count, SinglePrice, CardPeriod, Mobile, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime ,Email ,Job");
            strSql.Append("  from InsurantInfo ");
            strSql.Append(" where InsurantInfoID=@InsurantInfoID");
            SqlParameter[] parameters = {
                    new SqlParameter("@InsurantInfoID", SqlDbType.Int,4)
            };
            parameters[0].Value = InsurantInfoID;


            InsurantInfo model = new InsurantInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["InsurantInfoID"].ToString() != "")
                {
                    model.InsurantInfoID = int.Parse(ds.Tables[0].Rows[0]["InsurantInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderApplyID"].ToString() != "")
                {
                    model.OrderApplyID = int.Parse(ds.Tables[0].Rows[0]["OrderApplyID"].ToString());
                }
                model.CName = ds.Tables[0].Rows[0]["CName"].ToString();
                model.EName = ds.Tables[0].Rows[0]["EName"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CardType"].ToString() != "")
                {
                    model.CardType = int.Parse(ds.Tables[0].Rows[0]["CardType"].ToString());
                }
                model.CardCode = ds.Tables[0].Rows[0]["CardCode"].ToString();
                model.Birthday = ds.Tables[0].Rows[0]["Birthday"].ToString();
                if (ds.Tables[0].Rows[0]["RelationID"].ToString() != "")
                {
                    model.RelationID = int.Parse(ds.Tables[0].Rows[0]["RelationID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SinglePrice"].ToString() != "")
                {
                    model.SinglePrice = decimal.Parse(ds.Tables[0].Rows[0]["SinglePrice"].ToString());
                }
                model.CardPeriod = ds.Tables[0].Rows[0]["CardPeriod"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                if (ds.Tables[0].Rows[0]["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(ds.Tables[0].Rows[0]["CreatUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString());
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
                if (ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Job"].ToString() != "")
                {
                    model.Job = ds.Tables[0].Rows[0]["Job"].ToString();
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
            strSql.Append(" FROM InsurantInfo ");
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
            strSql.Append(" FROM InsurantInfo ");
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
        public InsurantInfoBackups GetOrderModel(int OrderApplyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select iio.InsurantInfoID, iio.OrderApplyID,iio.CName,iio.EName, iio.Sex,
 iio.CardType, iio.CardCode, iio.Birthday, iio.RelationID, iio.[Count],
 iio.SinglePrice, iio.CardPeriod, iio.Mobile, iio.CreatUserID, iio.RecordUpdateUserID, iio.RecordIsDelete,
  iio.RecordUpdateTime, iio.RecordCreateTime, iio.Email, ct.Name as CardTypeName , u.UserName as CreatUserName
  from InsurantInfo iio LEFT JOIN dbo.CardType ct ON ct.Value = iio.CardType
    LEFT JOIN[BWJSDB].[dbo].[Users] u  ON  u.UserID = iio.CreatUserID AND u.RecordIsDelete = 0
 ");
            strSql.Append(" where OrderApplyID=@OrderApplyID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderApplyID", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderApplyID;


            InsurantInfoBackups model = new InsurantInfoBackups();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["InsurantInfoID"].ToString() != "")
                {
                    model.InsurantInfoID = int.Parse(ds.Tables[0].Rows[0]["InsurantInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderApplyID"].ToString() != "")
                {
                    model.OrderApplyID = int.Parse(ds.Tables[0].Rows[0]["OrderApplyID"].ToString());
                }
                model.CName = ds.Tables[0].Rows[0]["CName"].ToString();
                model.EName = ds.Tables[0].Rows[0]["EName"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CardType"].ToString() != "")
                {
                    model.CardType = int.Parse(ds.Tables[0].Rows[0]["CardType"].ToString());
                }
                model.CardCode = ds.Tables[0].Rows[0]["CardCode"].ToString();
                model.Birthday = ds.Tables[0].Rows[0]["Birthday"].ToString();
                if (ds.Tables[0].Rows[0]["RelationID"].ToString() != "")
                {
                    model.RelationID = int.Parse(ds.Tables[0].Rows[0]["RelationID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count"].ToString() != "")
                {
                    model.Count = int.Parse(ds.Tables[0].Rows[0]["Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SinglePrice"].ToString() != "")
                {
                    model.SinglePrice = decimal.Parse(ds.Tables[0].Rows[0]["SinglePrice"].ToString());
                }
                model.CardPeriod = ds.Tables[0].Rows[0]["CardPeriod"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                if (ds.Tables[0].Rows[0]["CreatUserID"].ToString() != "")
                {
                    model.CreatUserID = int.Parse(ds.Tables[0].Rows[0]["CreatUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString() != "")
                {
                    model.RecordUpdateUserID = int.Parse(ds.Tables[0].Rows[0]["RecordUpdateUserID"].ToString());
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
                if (ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString() != "")
                {
                    model.RecordUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
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

