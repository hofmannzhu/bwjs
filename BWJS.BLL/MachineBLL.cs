using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BWJS.DAL;
using BWJS.Model;
using BWJS.Model.InputModel;
using BWJS.Model.Model;

namespace BWJS.BLL
{
    public partial class MachineBLL
    {

        private readonly MachineDAL dal = new MachineDAL();
        public MachineBLL()
        { }

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJS.Model.Machine model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJS.Model.Machine model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.Machine GetModel(int MachineID)
        {

            return dal.GetModel(MachineID);
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
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.Machine> GetModelList(string strWhere)
        //{
        //    DataSet ds = dal.GetList(strWhere);
        //    return DataTableToList(ds.Tables[0]);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public List<BWJS.Model.Machine> DataTableToList(DataTable dt)
        //{
        //    List<BWJS.Model.Machine> modelList = new List<BWJS.Model.Machine>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        BWJS.Model.Machine model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = DataRowToModel(dt.Rows[n]);
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetAllList()
        //{
        //    return GetList("");
        //}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        //public BWJS.Model.Machine DataRowToModel(DataRow row)
        //{
        //    return dal.DataRowToModel(row);
        //}

        /// <summary>
        /// 分页获得数据列表
        /// </summary>
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
            return dal.GetList(where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }

        #endregion  BasicMethod

        #region  ExtensionMethod
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string machineIdlist, int userId)
        {
            return dal.DeleteList(machineIdlist, userId);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsBySN(string SN)
        {
            return dal.ExistsBySN(SN);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJS.Model.Machine GetModelByUserId(int userId)
        {

            return dal.GetModelByUserId(userId);
        }

        #endregion


        public MachineBackups GetModelListName2(string strWhere)
        {
            DataSet ds = dal.GetModelListName(strWhere);
            return DataTableToListName2(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public MachineBackups DataTableToListName2(DataTable dt)
        {
            MachineBackups model = new MachineBackups();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {

                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelName(dt.Rows[n]);
                }
            }
            return model;
        }
        public bool Exists(int machineId, string SN)
        {
            return dal.Exists(machineId, SN);
        }
        public bool ExistsByUserIdImei(int userId, string Imei)
        {
            return dal.ExistsByUserIdImei(userId, Imei);
        }
        public int TotalUserIdPlatform(int userId, string Platform)
        {
            return dal.TotalUserIdPlatform(userId, Platform);
        }
    }
}
