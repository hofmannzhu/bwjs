using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper;
using Mofang.Model;
using System.Data.SqlClient;
using System.Data;

namespace Mofang.DAL
{
    public partial class
        OtherInfoDAL : BaseService
    {
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(OtherInfo model, SqlTransaction trans, SqlConnection conn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OtherInfo(");
            strSql.Append("OrderApplyID , ProvCityID , CardPeriod , NotifyAnswerID , PriceArgsID , VisaCity , Destination , TripPurposeId  , PropertyAddress , RelatedPersonHouse  , CreatUserID   , RecordUpdateUserID   , RecordIsDelete    , RecordUpdateTime   , RecordCreateTime");
            strSql.Append(") values (");
            strSql.Append("@OrderApplyID  , @ProvCityID  , @CardPeriod  , @NotifyAnswerID  , @PriceArgsID   , @VisaCity , @Destination  , @TripPurposeId  , @PropertyAddress , @RelatedPersonHouse  , @CreatUserID  , @RecordUpdateUserID  , @RecordIsDelete   ,  GETDATE() ,  GETDATE()");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                                    new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                                    new SqlParameter("@ProvCityID", model.ProvCityID) ,
                                    new SqlParameter("@CardPeriod", model.CardPeriod) ,
                                    new SqlParameter("@NotifyAnswerID", model.NotifyAnswerID) ,
                                    new SqlParameter("@PriceArgsID", model.PriceArgsID) ,
                                    new SqlParameter("@VisaCity", model.VisaCity) ,
                                    new SqlParameter("@Destination", model.Destination) ,
                                    new SqlParameter("@TripPurposeId", model.TripPurposeId) ,
                                    new SqlParameter("@PropertyAddress", model.PropertyAddress) ,
                                    new SqlParameter("@RelatedPersonHouse", model.RelatedPersonHouse) ,
                                    new SqlParameter("@CreatUserID", model.CreatUserID) ,
                                    new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                                    new SqlParameter("@RecordIsDelete", model.RecordIsDelete)

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
        public int Add(OtherInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OtherInfo(");
            strSql.Append("OrderApplyID , ProvCityID , CardPeriod , NotifyAnswerID , PriceArgsID , VisaCity , Destination , TripPurposeId  , PropertyAddress , RelatedPersonHouse  , CreatUserID   , RecordUpdateUserID   , RecordIsDelete    , RecordUpdateTime   , RecordCreateTime");
            strSql.Append(") values (");
            strSql.Append("@OrderApplyID  , @ProvCityID  , @CardPeriod  , @NotifyAnswerID  , @PriceArgsID   , @VisaCity , @Destination  , @TripPurposeId  , @PropertyAddress , @RelatedPersonHouse  , @CreatUserID  , @RecordUpdateUserID  , @RecordIsDelete   ,  GETDATE() ,  GETDATE()");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                 new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                                    new SqlParameter("@ProvCityID", model.ProvCityID) ,
                                    new SqlParameter("@CardPeriod", model.CardPeriod) ,
                                    new SqlParameter("@NotifyAnswerID", model.NotifyAnswerID) ,
                                    new SqlParameter("@PriceArgsID", model.PriceArgsID) ,
                                    new SqlParameter("@VisaCity", model.VisaCity) ,
                                    new SqlParameter("@Destination", model.Destination) ,
                                    new SqlParameter("@TripPurposeId", model.TripPurposeId) ,
                                    new SqlParameter("@PropertyAddress", model.PropertyAddress) ,
                                    new SqlParameter("@RelatedPersonHouse", model.RelatedPersonHouse) ,
                                    new SqlParameter("@CreatUserID", model.CreatUserID) ,
                                    new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                                    new SqlParameter("@RecordIsDelete", model.RecordIsDelete)

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
        public bool Update(OtherInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OtherInfo set ");
            strSql.Append(" OrderApplyID = @OrderApplyID , ");
            strSql.Append(" ProvCityID = @ProvCityID , ");
            strSql.Append(" CardPeriod = @CardPeriod , ");
            strSql.Append(" NotifyAnswerID = @NotifyAnswerID , ");
            strSql.Append(" PriceArgsID = @PriceArgsID , ");
            strSql.Append(" VisaCity = @VisaCity , ");
            strSql.Append(" Destination = @Destination , ");
            strSql.Append(" TripPurposeId = @TripPurposeId , ");
            strSql.Append(" PropertyAddress = @PropertyAddress , ");
            strSql.Append(" RelatedPersonHouse = @RelatedPersonHouse , ");
            strSql.Append(" RecordUpdateUserID = @RecordUpdateUserID , ");
            strSql.Append(" RecordUpdateTime = GetDate() ");
            strSql.Append(" where OtherInfoID=@OtherInfoID");

            SqlParameter[] parameters = {
                                new SqlParameter("@OrderApplyID", model.OrderApplyID) ,
                                new SqlParameter("@OtherInfoID",  model.OtherInfoID) ,
                                new SqlParameter("@ProvCityID", model.ProvCityID) ,
                                new SqlParameter("@CardPeriod", model.CardPeriod) ,
                                new SqlParameter("@NotifyAnswerID", model.NotifyAnswerID) ,
                                new SqlParameter("@PriceArgsID", model.PriceArgsID) ,
                                new SqlParameter("@VisaCity", model.VisaCity) ,
                                new SqlParameter("@Destination", model.Destination) ,
                                new SqlParameter("@TripPurposeId", model.TripPurposeId) ,
                                new SqlParameter("@PropertyAddress", model.PropertyAddress) ,
                                new SqlParameter("@RelatedPersonHouse", model.RelatedPersonHouse) ,
                                new SqlParameter("@CreatUserID", model.CreatUserID) ,
                                new SqlParameter("@RecordUpdateUserID", model.RecordUpdateUserID) ,
                                new SqlParameter("@RecordIsDelete", model.RecordIsDelete)
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
        public bool UpdateDelete(int OtherInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OtherInfo set  RecordIsDelete =1 ");
            strSql.Append(" where OtherInfoID=@OtherInfoID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OtherInfoID", SqlDbType.Int,4)
            };
            parameters[0].Value = OtherInfoID;


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
        public bool UpdateDeleteList(string OtherInfoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OtherInfo set  RecordIsDelete =1 ");
            strSql.Append(" where ID in (" + OtherInfoIDlist + ")  ");
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
        public OtherInfo GetModel(int OtherInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderApplyID, OtherInfoID,ProvCityID, CardPeriod, NotifyAnswerID, PriceArgsID, VisaCity, Destination, TripPurposeId, PropertyAddress, RelatedPersonHouse, CreatUserID, RecordUpdateUserID, RecordIsDelete, RecordUpdateTime, RecordCreateTime");
            strSql.Append("  from OtherInfo ");
            strSql.Append(" where OtherInfoID=@OtherInfoID");
            SqlParameter[] parameters = {
                    new SqlParameter("@OtherInfoID", SqlDbType.Int,4)
            };
            parameters[0].Value = OtherInfoID;


            OtherInfo model = new OtherInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["OrderApplyID"].ToString() != "")
                {
                    model.OrderApplyID = int.Parse(ds.Tables[0].Rows[0]["OrderApplyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OtherInfoID"].ToString() != "")
                {
                    model.OtherInfoID = int.Parse(ds.Tables[0].Rows[0]["OtherInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecordCreateTime"].ToString() != "")
                {
                    model.RecordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecordCreateTime"].ToString());
                }
                model.ProvCityID = ds.Tables[0].Rows[0]["ProvCityID"].ToString();
                if (ds.Tables[0].Rows[0]["CardPeriod"].ToString() != "")
                {
                    model.CardPeriod = DateTime.Parse(ds.Tables[0].Rows[0]["CardPeriod"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NotifyAnswerID"].ToString() != "")
                {
                    model.NotifyAnswerID = int.Parse(ds.Tables[0].Rows[0]["NotifyAnswerID"].ToString());
                }
                model.PriceArgsID = ds.Tables[0].Rows[0]["PriceArgsID"].ToString();
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
            strSql.Append(" FROM OtherInfo ");
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
            strSql.Append(" FROM OtherInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
