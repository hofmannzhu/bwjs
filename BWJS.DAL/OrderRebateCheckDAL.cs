using UtilityHelper;
using UtilityHelper.Data;
using BWJS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BWJS.DAL
{
    /// <summary>
    /// 订单返利
    /// </summary>
    public partial class OrderRebateCheckDAL : BaseService
    {
        #region BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.OrderRebateCheck model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.[OrderRebateCheck](");
            strSql.Append("AgentMoney,AgentRebate,HQRebate,HQMoney,NetProfit,PayStatus,IsSettled,IsCancel,SettlementDate,CreateDate,TransNo,Remark,IsDeleted,Exp_CreateId,Exp_CreateDate,Exp_EditId,Exp_EditDate,Exp_BatchNo,Exp_NewId,Exp_CompanyCategoryId,Exp_CompanyId,CompanyId,Exp_SettlementMethod,Exp_SalesPercentage,Exp_UserId,Exp_FullName,Exp_IdCardType,Exp_IdCard,Exp_Sex,Exp_Mobile,Exp_RecommendationCode,Exp_ApplicationAmount,UserId,Exp_LoanAmount,Exp_ContractAmount,Exp_LoanTerm,Exp_LoanDate,Exp_ProductId,Exp_ProductName,Exp_MerchantRebate,Exp_MerchantMoney,Exp_AgentRebate,Exp_AgentMoney,OrderApplyId,Exp_HQRebate,Exp_HQMoney,Exp_NetProfit,CompanyRebateId,OrderMoney,MerchantRebate,MerchantMoney");
            strSql.Append(") values (");
            strSql.Append("@AgentMoney,@AgentRebate,@HQRebate,@HQMoney,@NetProfit,@PayStatus,@IsSettled,@IsCancel,@SettlementDate,@CreateDate,@TransNo,@Remark,@IsDeleted,@Exp_CreateId,@Exp_CreateDate,@Exp_EditId,@Exp_EditDate,@Exp_BatchNo,@Exp_NewId,@Exp_CompanyCategoryId,@Exp_CompanyId,@CompanyId,@Exp_SettlementMethod,@Exp_SalesPercentage,@Exp_UserId,@Exp_FullName,@Exp_IdCardType,@Exp_IdCard,@Exp_Sex,@Exp_Mobile,@Exp_RecommendationCode,@Exp_ApplicationAmount,@UserId,@Exp_LoanAmount,@Exp_ContractAmount,@Exp_LoanTerm,@Exp_LoanDate,@Exp_ProductId,@Exp_ProductName,@Exp_MerchantRebate,@Exp_MerchantMoney,@Exp_AgentRebate,@Exp_AgentMoney,@OrderApplyId,@Exp_HQRebate,@Exp_HQMoney,@Exp_NetProfit,@CompanyRebateId,@OrderMoney,@MerchantRebate,@MerchantMoney");
            strSql.Append(") ");
            strSql.Append(";select SCOPE_IDENTITY()");
            SqlParameter[] parameters = {
                        new SqlParameter("@AgentMoney", model.AgentMoney) ,
                        new SqlParameter("@AgentRebate", model.AgentRebate) ,
                        new SqlParameter("@HQRebate", model.HQRebate) ,
                        new SqlParameter("@HQMoney", model.HQMoney) ,
                        new SqlParameter("@NetProfit", model.NetProfit) ,
                        new SqlParameter("@PayStatus", model.PayStatus) ,
                        new SqlParameter("@IsSettled", model.IsSettled) ,
                        new SqlParameter("@IsCancel", model.IsCancel) ,
                        new SqlParameter("@SettlementDate", model.SettlementDate) ,
                        new SqlParameter("@CreateDate", model.CreateDate) ,
                        new SqlParameter("@TransNo", model.TransNo) ,
                        new SqlParameter("@Remark", model.Remark) ,
                        new SqlParameter("@IsDeleted", model.IsDeleted) ,
                        new SqlParameter("@Exp_CreateId", model.Exp_CreateId) ,
                        new SqlParameter("@Exp_CreateDate", model.Exp_CreateDate) ,
                        new SqlParameter("@Exp_EditId", model.Exp_EditId) ,
                        new SqlParameter("@Exp_EditDate", model.Exp_EditDate) ,
                        new SqlParameter("@Exp_BatchNo", model.Exp_BatchNo) ,
                        new SqlParameter("@Exp_NewId", model.Exp_NewId) ,
                        new SqlParameter("@Exp_CompanyCategoryId", model.Exp_CompanyCategoryId) ,
                        new SqlParameter("@Exp_CompanyId", model.Exp_CompanyId) ,
                        new SqlParameter("@CompanyId", model.CompanyId) ,
                        new SqlParameter("@Exp_SettlementMethod", model.Exp_SettlementMethod) ,
                        new SqlParameter("@Exp_SalesPercentage", model.Exp_SalesPercentage) ,
                        new SqlParameter("@Exp_UserId", model.Exp_UserId) ,
                        new SqlParameter("@Exp_FullName", model.Exp_FullName) ,
                        new SqlParameter("@Exp_IdCardType", model.Exp_IdCardType) ,
                        new SqlParameter("@Exp_IdCard", model.Exp_IdCard) ,
                        new SqlParameter("@Exp_Sex", model.Exp_Sex) ,
                        new SqlParameter("@Exp_Mobile", model.Exp_Mobile) ,
                        new SqlParameter("@Exp_RecommendationCode", model.Exp_RecommendationCode) ,
                        new SqlParameter("@Exp_ApplicationAmount", model.Exp_ApplicationAmount) ,
                        new SqlParameter("@UserId", model.UserId) ,
                        new SqlParameter("@Exp_LoanAmount", model.Exp_LoanAmount) ,
                        new SqlParameter("@Exp_ContractAmount", model.Exp_ContractAmount) ,
                        new SqlParameter("@Exp_LoanTerm", model.Exp_LoanTerm) ,
                        new SqlParameter("@Exp_LoanDate", model.Exp_LoanDate) ,
                        new SqlParameter("@Exp_ProductId", model.Exp_ProductId) ,
                        new SqlParameter("@Exp_ProductName", model.Exp_ProductName) ,
                        new SqlParameter("@Exp_MerchantRebate", model.Exp_MerchantRebate) ,
                        new SqlParameter("@Exp_MerchantMoney", model.Exp_MerchantMoney) ,
                        new SqlParameter("@Exp_AgentRebate", model.Exp_AgentRebate) ,
                        new SqlParameter("@Exp_AgentMoney", model.Exp_AgentMoney) ,
                        new SqlParameter("@OrderApplyId", model.OrderApplyId) ,
                        new SqlParameter("@Exp_HQRebate", model.Exp_HQRebate) ,
                        new SqlParameter("@Exp_HQMoney", model.Exp_HQMoney) ,
                        new SqlParameter("@Exp_NetProfit", model.Exp_NetProfit) ,
                        new SqlParameter("@CompanyRebateId", model.CompanyRebateId) ,
                        new SqlParameter("@OrderMoney", model.OrderMoney) ,
                        new SqlParameter("@MerchantRebate", model.MerchantRebate) ,
                        new SqlParameter("@MerchantMoney", model.MerchantMoney)

            };


            object obj = BWJSHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(BWJS.Model.OrderRebateCheck model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderRebateCheck] set ");

            strSql.Append(" AgentMoney = @AgentMoney , ");
            strSql.Append(" AgentRebate = @AgentRebate , ");
            strSql.Append(" HQRebate = @HQRebate , ");
            strSql.Append(" HQMoney = @HQMoney , ");
            strSql.Append(" NetProfit = @NetProfit , ");
            strSql.Append(" PayStatus = @PayStatus , ");
            strSql.Append(" IsSettled = @IsSettled , ");
            strSql.Append(" IsCancel = @IsCancel , ");
            strSql.Append(" SettlementDate = @SettlementDate , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" TransNo = @TransNo , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" IsDeleted = @IsDeleted , ");
            strSql.Append(" Exp_CreateId = @Exp_CreateId , ");
            strSql.Append(" Exp_CreateDate = @Exp_CreateDate , ");
            strSql.Append(" Exp_EditId = @Exp_EditId , ");
            strSql.Append(" Exp_EditDate = @Exp_EditDate , ");
            strSql.Append(" Exp_BatchNo = @Exp_BatchNo , ");
            strSql.Append(" Exp_NewId = @Exp_NewId , ");
            strSql.Append(" Exp_CompanyCategoryId = @Exp_CompanyCategoryId , ");
            strSql.Append(" Exp_CompanyId = @Exp_CompanyId , ");
            strSql.Append(" CompanyId = @CompanyId , ");
            strSql.Append(" Exp_SettlementMethod = @Exp_SettlementMethod , ");
            strSql.Append(" Exp_SalesPercentage = @Exp_SalesPercentage , ");
            strSql.Append(" Exp_UserId = @Exp_UserId , ");
            strSql.Append(" Exp_FullName = @Exp_FullName , ");
            strSql.Append(" Exp_IdCardType = @Exp_IdCardType , ");
            strSql.Append(" Exp_IdCard = @Exp_IdCard , ");
            strSql.Append(" Exp_Sex = @Exp_Sex , ");
            strSql.Append(" Exp_Mobile = @Exp_Mobile , ");
            strSql.Append(" Exp_RecommendationCode = @Exp_RecommendationCode , ");
            strSql.Append(" Exp_ApplicationAmount = @Exp_ApplicationAmount , ");
            strSql.Append(" UserId = @UserId , ");
            strSql.Append(" Exp_LoanAmount = @Exp_LoanAmount , ");
            strSql.Append(" Exp_ContractAmount = @Exp_ContractAmount , ");
            strSql.Append(" Exp_LoanTerm = @Exp_LoanTerm , ");
            strSql.Append(" Exp_LoanDate = @Exp_LoanDate , ");
            strSql.Append(" Exp_ProductId = @Exp_ProductId , ");
            strSql.Append(" Exp_ProductName = @Exp_ProductName , ");
            strSql.Append(" Exp_MerchantRebate = @Exp_MerchantRebate , ");
            strSql.Append(" Exp_MerchantMoney = @Exp_MerchantMoney , ");
            strSql.Append(" Exp_AgentRebate = @Exp_AgentRebate , ");
            strSql.Append(" Exp_AgentMoney = @Exp_AgentMoney , ");
            strSql.Append(" OrderApplyId = @OrderApplyId , ");
            strSql.Append(" Exp_HQRebate = @Exp_HQRebate , ");
            strSql.Append(" Exp_HQMoney = @Exp_HQMoney , ");
            strSql.Append(" Exp_NetProfit = @Exp_NetProfit , ");
            strSql.Append(" CompanyRebateId = @CompanyRebateId , ");
            strSql.Append(" OrderMoney = @OrderMoney , ");
            strSql.Append(" MerchantRebate = @MerchantRebate , ");
            strSql.Append(" MerchantMoney = @MerchantMoney  ");
            strSql.Append(" where OrderRebateId=@OrderRebateId ");

            SqlParameter[] parameters = {
                        new SqlParameter("@OrderRebateId",model.OrderRebateId) ,
                        new SqlParameter("@AgentMoney",model.AgentMoney) ,
                        new SqlParameter("@AgentRebate",model.AgentRebate) ,
                        new SqlParameter("@HQRebate",model.HQRebate) ,
                        new SqlParameter("@HQMoney",model.HQMoney) ,
                        new SqlParameter("@NetProfit",model.NetProfit) ,
                        new SqlParameter("@PayStatus",model.PayStatus) ,
                        new SqlParameter("@IsSettled",model.IsSettled) ,
                        new SqlParameter("@IsCancel",model.IsCancel) ,
                        new SqlParameter("@SettlementDate",model.SettlementDate) ,
                        new SqlParameter("@CreateDate",model.CreateDate) ,
                        new SqlParameter("@TransNo",model.TransNo) ,
                        new SqlParameter("@Remark",model.Remark) ,
                        new SqlParameter("@IsDeleted",model.IsDeleted) ,
                        new SqlParameter("@Exp_CreateId",model.Exp_CreateId) ,
                        new SqlParameter("@Exp_CreateDate",model.Exp_CreateDate) ,
                        new SqlParameter("@Exp_EditId",model.Exp_EditId) ,
                        new SqlParameter("@Exp_EditDate",model.Exp_EditDate) ,
                        new SqlParameter("@Exp_BatchNo",model.Exp_BatchNo) ,
                        new SqlParameter("@Exp_NewId",model.Exp_NewId) ,
                        new SqlParameter("@Exp_CompanyCategoryId",model.Exp_CompanyCategoryId) ,
                        new SqlParameter("@Exp_CompanyId",model.Exp_CompanyId) ,
                        new SqlParameter("@CompanyId",model.CompanyId) ,
                        new SqlParameter("@Exp_SettlementMethod",model.Exp_SettlementMethod) ,
                        new SqlParameter("@Exp_SalesPercentage",model.Exp_SalesPercentage) ,
                        new SqlParameter("@Exp_UserId",model.Exp_UserId) ,
                        new SqlParameter("@Exp_FullName",model.Exp_FullName) ,
                        new SqlParameter("@Exp_IdCardType",model.Exp_IdCardType) ,
                        new SqlParameter("@Exp_IdCard",model.Exp_IdCard) ,
                        new SqlParameter("@Exp_Sex",model.Exp_Sex) ,
                        new SqlParameter("@Exp_Mobile",model.Exp_Mobile) ,
                        new SqlParameter("@Exp_RecommendationCode",model.Exp_RecommendationCode) ,
                        new SqlParameter("@Exp_ApplicationAmount",model.Exp_ApplicationAmount) ,
                        new SqlParameter("@UserId",model.UserId) ,
                        new SqlParameter("@Exp_LoanAmount",model.Exp_LoanAmount) ,
                        new SqlParameter("@Exp_ContractAmount",model.Exp_ContractAmount) ,
                        new SqlParameter("@Exp_LoanTerm",model.Exp_LoanTerm) ,
                        new SqlParameter("@Exp_LoanDate",model.Exp_LoanDate) ,
                        new SqlParameter("@Exp_ProductId",model.Exp_ProductId) ,
                        new SqlParameter("@Exp_ProductName",model.Exp_ProductName) ,
                        new SqlParameter("@Exp_MerchantRebate",model.Exp_MerchantRebate) ,
                        new SqlParameter("@Exp_MerchantMoney",model.Exp_MerchantMoney) ,
                        new SqlParameter("@Exp_AgentRebate",model.Exp_AgentRebate) ,
                        new SqlParameter("@Exp_AgentMoney",model.Exp_AgentMoney) ,
                        new SqlParameter("@OrderApplyId",model.OrderApplyId) ,
                        new SqlParameter("@Exp_HQRebate",model.Exp_HQRebate) ,
                        new SqlParameter("@Exp_HQMoney",model.Exp_HQMoney) ,
                        new SqlParameter("@Exp_NetProfit",model.Exp_NetProfit) ,
                        new SqlParameter("@CompanyRebateId",model.CompanyRebateId) ,
                        new SqlParameter("@OrderMoney",model.OrderMoney) ,
                        new SqlParameter("@MerchantRebate",model.MerchantRebate) ,
                        new SqlParameter("@MerchantMoney",model.MerchantMoney)

            };

            int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public BWJS.Model.OrderRebateCheck GetModel(int OrderRebateId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrderRebateId, AgentMoney, AgentRebate, HQRebate, HQMoney, NetProfit, PayStatus, IsSettled, IsCancel, SettlementDate, CreateDate, TransNo, Remark, IsDeleted, Exp_CreateId, Exp_CreateDate, Exp_EditId, Exp_EditDate, Exp_BatchNo, Exp_NewId, Exp_CompanyCategoryId, Exp_CompanyId, CompanyId, Exp_SettlementMethod, Exp_SalesPercentage, Exp_UserId, Exp_FullName, Exp_IdCardType, Exp_IdCard, Exp_Sex, Exp_Mobile, Exp_RecommendationCode, Exp_ApplicationAmount, UserId, Exp_LoanAmount, Exp_ContractAmount, Exp_LoanTerm, Exp_LoanDate, Exp_ProductId, Exp_ProductName, Exp_MerchantRebate, Exp_MerchantMoney, Exp_AgentRebate, Exp_AgentMoney, OrderApplyId, Exp_HQRebate, Exp_HQMoney, Exp_NetProfit, CompanyRebateId, OrderMoney, MerchantRebate, MerchantMoney  ");
            strSql.Append("  from dbo.[OrderRebateCheck] ");
            strSql.Append(" where OrderRebateId=@OrderRebateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderRebateId", SqlDbType.Int,4)
            };
            parameters[0].Value = OrderRebateId;


            BWJS.Model.OrderRebateCheck model = new BWJS.Model.OrderRebateCheck();
            DataSet ds = BWJSHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// datarow转成对象实体
        /// </summary>
        public BWJS.Model.OrderRebateCheck DataRowToModel(DataRow row)
        {
            BWJS.Model.OrderRebateCheck model = new BWJS.Model.OrderRebateCheck();

            if (row != null)
            {
                if (row["OrderRebateId"].ToString() != "")
                {
                    model.OrderRebateId = int.Parse(row["OrderRebateId"].ToString());
                }
                if (row["AgentMoney"].ToString() != "")
                {
                    model.AgentMoney = decimal.Parse(row["AgentMoney"].ToString());
                }
                if (row["AgentRebate"].ToString() != "")
                {
                    model.AgentRebate = decimal.Parse(row["AgentRebate"].ToString());
                }
                if (row["HQRebate"].ToString() != "")
                {
                    model.HQRebate = decimal.Parse(row["HQRebate"].ToString());
                }
                if (row["HQMoney"].ToString() != "")
                {
                    model.HQMoney = decimal.Parse(row["HQMoney"].ToString());
                }
                if (row["NetProfit"].ToString() != "")
                {
                    model.NetProfit = decimal.Parse(row["NetProfit"].ToString());
                }
                if (row["PayStatus"].ToString() != "")
                {
                    model.PayStatus = int.Parse(row["PayStatus"].ToString());
                }
                if (row["IsSettled"].ToString() != "")
                {
                    model.IsSettled = int.Parse(row["IsSettled"].ToString());
                }
                if (row["IsCancel"].ToString() != "")
                {
                    model.IsCancel = int.Parse(row["IsCancel"].ToString());
                }
                if (row["SettlementDate"].ToString() != "")
                {
                    model.SettlementDate = DateTime.Parse(row["SettlementDate"].ToString());
                }
                if (row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                model.TransNo = row["TransNo"].ToString();
                model.Remark = row["Remark"].ToString();
                if (row["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = int.Parse(row["IsDeleted"].ToString());
                }
                if (row["Exp_CreateId"].ToString() != "")
                {
                    model.Exp_CreateId = int.Parse(row["Exp_CreateId"].ToString());
                }
                if (row["Exp_CreateDate"].ToString() != "")
                {
                    model.Exp_CreateDate = DateTime.Parse(row["Exp_CreateDate"].ToString());
                }
                if (row["Exp_EditId"].ToString() != "")
                {
                    model.Exp_EditId = int.Parse(row["Exp_EditId"].ToString());
                }
                if (row["Exp_EditDate"].ToString() != "")
                {
                    model.Exp_EditDate = DateTime.Parse(row["Exp_EditDate"].ToString());
                }
                model.Exp_BatchNo = row["Exp_BatchNo"].ToString();
                if (row["Exp_NewId"].ToString() != "")
                {
                    model.Exp_NewId = int.Parse(row["Exp_NewId"].ToString());
                }
                if (row["Exp_CompanyCategoryId"].ToString() != "")
                {
                    model.Exp_CompanyCategoryId = int.Parse(row["Exp_CompanyCategoryId"].ToString());
                }
                if (row["Exp_CompanyId"].ToString() != "")
                {
                    model.Exp_CompanyId = int.Parse(row["Exp_CompanyId"].ToString());
                }
                if (row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                if (row["Exp_SettlementMethod"].ToString() != "")
                {
                    model.Exp_SettlementMethod = int.Parse(row["Exp_SettlementMethod"].ToString());
                }
                if (row["Exp_SalesPercentage"].ToString() != "")
                {
                    model.Exp_SalesPercentage = decimal.Parse(row["Exp_SalesPercentage"].ToString());
                }
                if (row["Exp_UserId"].ToString() != "")
                {
                    model.Exp_UserId = int.Parse(row["Exp_UserId"].ToString());
                }
                model.Exp_FullName = row["Exp_FullName"].ToString();
                if (row["Exp_IdCardType"].ToString() != "")
                {
                    model.Exp_IdCardType = int.Parse(row["Exp_IdCardType"].ToString());
                }
                model.Exp_IdCard = row["Exp_IdCard"].ToString();
                if (row["Exp_Sex"].ToString() != "")
                {
                    model.Exp_Sex = int.Parse(row["Exp_Sex"].ToString());
                }
                model.Exp_Mobile = row["Exp_Mobile"].ToString();
                model.Exp_RecommendationCode = row["Exp_RecommendationCode"].ToString();
                if (row["Exp_ApplicationAmount"].ToString() != "")
                {
                    model.Exp_ApplicationAmount = decimal.Parse(row["Exp_ApplicationAmount"].ToString());
                }
                if (row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Exp_LoanAmount"].ToString() != "")
                {
                    model.Exp_LoanAmount = decimal.Parse(row["Exp_LoanAmount"].ToString());
                }
                if (row["Exp_ContractAmount"].ToString() != "")
                {
                    model.Exp_ContractAmount = decimal.Parse(row["Exp_ContractAmount"].ToString());
                }
                if (row["Exp_LoanTerm"].ToString() != "")
                {
                    model.Exp_LoanTerm = int.Parse(row["Exp_LoanTerm"].ToString());
                }
                if (row["Exp_LoanDate"].ToString() != "")
                {
                    model.Exp_LoanDate = DateTime.Parse(row["Exp_LoanDate"].ToString());
                }
                if (row["Exp_ProductId"].ToString() != "")
                {
                    model.Exp_ProductId = int.Parse(row["Exp_ProductId"].ToString());
                }
                model.Exp_ProductName = row["Exp_ProductName"].ToString();
                if (row["Exp_MerchantRebate"].ToString() != "")
                {
                    model.Exp_MerchantRebate = decimal.Parse(row["Exp_MerchantRebate"].ToString());
                }
                if (row["Exp_MerchantMoney"].ToString() != "")
                {
                    model.Exp_MerchantMoney = decimal.Parse(row["Exp_MerchantMoney"].ToString());
                }
                if (row["Exp_AgentRebate"].ToString() != "")
                {
                    model.Exp_AgentRebate = decimal.Parse(row["Exp_AgentRebate"].ToString());
                }
                if (row["Exp_AgentMoney"].ToString() != "")
                {
                    model.Exp_AgentMoney = decimal.Parse(row["Exp_AgentMoney"].ToString());
                }
                if (row["OrderApplyId"].ToString() != "")
                {
                    model.OrderApplyId = int.Parse(row["OrderApplyId"].ToString());
                }
                if (row["Exp_HQRebate"].ToString() != "")
                {
                    model.Exp_HQRebate = decimal.Parse(row["Exp_HQRebate"].ToString());
                }
                if (row["Exp_HQMoney"].ToString() != "")
                {
                    model.Exp_HQMoney = decimal.Parse(row["Exp_HQMoney"].ToString());
                }
                if (row["Exp_NetProfit"].ToString() != "")
                {
                    model.Exp_NetProfit = decimal.Parse(row["Exp_NetProfit"].ToString());
                }
                if (row["CompanyRebateId"].ToString() != "")
                {
                    model.CompanyRebateId = int.Parse(row["CompanyRebateId"].ToString());
                }
                if (row["OrderMoney"].ToString() != "")
                {
                    model.OrderMoney = decimal.Parse(row["OrderMoney"].ToString());
                }
                if (row["MerchantRebate"].ToString() != "")
                {
                    model.MerchantRebate = decimal.Parse(row["MerchantRebate"].ToString());
                }
                if (row["MerchantMoney"].ToString() != "")
                {
                    model.MerchantMoney = decimal.Parse(row["MerchantMoney"].ToString());
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
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM dbo.[OrderRebateCheck] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return BWJSHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" FROM dbo.[OrderRebateCheck] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return BWJSHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获得数据列表
        /// </summary>
        /// <param name="tablesql">要执行的sql语句</param>
        /// <param name="where">查询条件</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="orderBy">排序字段&排序方向</param>
        /// <param name="sql">返回完整的的可执行sql</param>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            StringBuilder tablesql = new StringBuilder();
            tablesql.Append("select * ");
            tablesql.Append(" FROM dbo.[OrderRebateCheck] ");
            return BWJSHelperSQL.GetPageList(tablesql.ToString(), where.ToString(), pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion

        #region ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int OrderRebateId, int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo.[OrderRebateCheck] set IsDeleted=1,Exp_EditId=@Exp_EditId,Exp_EditDate=@Exp_EditDate");
            strSql.Append(" where OrderRebateId=@OrderRebateId");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderRebateId", OrderRebateId),
                    new SqlParameter("@Exp_EditId", userId),
                    new SqlParameter("@Exp_EditDate", DateTime.Now)
            };


            int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string OrderRebateIdlist, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.[OrderRebateCheck] set IsDeleted=1,Exp_EditId={0},Exp_EditDate='{1}'", userId, DateTime.Now);
            strSql.AppendFormat(" where OrderRebateId in ({0})", OrderRebateIdlist);
            int rows = BWJSHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion
    }
}
