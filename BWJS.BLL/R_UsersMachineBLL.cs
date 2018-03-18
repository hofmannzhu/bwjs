using BWJS.DAL;
using BWJS.Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.BLL
{
    public class R_UsersMachineBLL
    {
        private readonly R_UsersMachineDAL dal = new R_UsersMachineDAL();
        public R_UsersMachineBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RUMID)
        {
            return dal.Exists(RUMID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(R_UsersMachine model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(R_UsersMachine model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int RUMID)
        {

            return dal.Delete(RUMID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string RUMIDlist)
        {
            return dal.DeleteList(RUMIDlist);
        }
        /// <summary>
        /// 根据设备号删除相关的绑定用户
        /// </summary>
        /// <param name="machineID"></param>
        /// <returns></returns>
        public bool DeleteListByMachineID(int machineID)
        {
            return dal.DeleteListByMachineID(machineID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public R_UsersMachine GetModel(int RUMID)
        {

            return dal.GetModel(RUMID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public R_UsersMachine GetModelByCache(int RUMID)
        //{

        //    string CacheKey = "R_UsersMachineModel-" + RUMID;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(RUMID);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (R_UsersMachine)objModel;
        //}

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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<R_UsersMachine> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<R_UsersMachine> DataTableToList(DataTable dt)
        {
            List<R_UsersMachine> modelList = new List<R_UsersMachine>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                R_UsersMachine model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
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

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
