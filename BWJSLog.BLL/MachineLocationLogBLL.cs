using BWJSLog.DAL;
using BWJSLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UtilityHelper;
using System.Device.Location;

namespace BWJSLog.BLL
{

    /// <summary>
    /// 分类类别表
    /// </summary>
    public partial class MachineLocationLogBLL
    {
        private readonly MachineLocationLogDAL dal = new MachineLocationLogDAL();

        public MachineLocationLogBLL() { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BWJSLog.Model.MachineLocationLog model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BWJSLog.Model.MachineLocationLog model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MachineLocationLogId)
        {

            return dal.Delete(MachineLocationLogId);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string MachineLocationLogIdlist)
        {
            return dal.DeleteList(MachineLocationLogIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJSLog.Model.MachineLocationLog GetModel(int MachineLocationLogId)
        {

            return dal.GetModel(MachineLocationLogId);
        }
        /*
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public BWJSLog.Model.MachineLocationLog GetModelByCache(int MachineLocationLogId)
		{
			
			string CacheKey = "MachineLocationLogModel-" + MachineLocationLogId;
			object objModel = BWJSLog.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MachineLocationLogId);
					if (objModel != null)
					{
						int ModelCache = BWJSLog.Common.ConfigHelper.GetConfigInt("ModelCache");
						BWJSLog.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (BWJSLog.Model.MachineLocationLog)objModel;
		}*/

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
        public List<BWJSLog.Model.MachineLocationLog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BWJSLog.Model.MachineLocationLog> DataTableToList(DataTable dt)
        {
            List<BWJSLog.Model.MachineLocationLog> modelList = new List<BWJSLog.Model.MachineLocationLog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BWJSLog.Model.MachineLocationLog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]);
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BWJSLog.Model.MachineLocationLog DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

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
        public DataTable GetList(string tablesql, string where, int pageIndex, int pageSize, string orderBy, ref string sql, ref int zys, ref int sumcount)
        {
            return dal.GetList(tablesql, where, pageIndex, pageSize, orderBy, ref sql, ref zys, ref sumcount);
        }
        #endregion

        #region  ExtensionMethod


        #endregion  ExtensionMethod


        #region 百度IP定位当前位置信息
        /// <summary>
        /// 百度IP定位当前位置信息
        /// </summary>
        /// <returns></returns>
        static public String GetLocationInfo()
        {
            try
            {
                string Ak = CommonHelper.GetAppSettingsValue("Ak", "TBHTGEjDi6X1MRIthT3TLFvo5Zy07IhK");
                string baiduIpApi = CommonHelper.GetAppSettingsValue("baiduIpApi", "http://api.map.baidu.com/location/ip");
                string url = string.Format("{1}?ak={0}&coor=bd09ll", Ak, baiduIpApi);
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, string.Empty);
                return retrunStr;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }

        /// <summary>
        /// 地址解析
        /// </summary>
        /// <param name="address">要定位的地址</param>
        /// <returns>返回位置信息json</returns>
        static public String GetLocationByAddress(string address)
        {
            try
            {
                string Ak = CommonHelper.GetAppSettingsValue("Ak", "TBHTGEjDi6X1MRIthT3TLFvo5Zy07IhK");
                string baiduLocationApi = CommonHelper.GetAppSettingsValue("baiduLocationApi", "http://api.map.baidu.com/geocoder/v2/");
                string url = string.Format("{2}?address={0}&output=json&ak={1}&callback=showLocation", address, Ak, baiduLocationApi);
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, string.Empty);
                return retrunStr;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }

        /// <summary>
        /// 逆地址解析
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="output">输出格式为json或者xml</param>
        /// <param name="pois">是否显示指定位置周边的poi，0为不显示，1为显示。当值为1时，默认显示周边1000米内的poi。</param>
        /// <returns>json或者xml</returns>
        static public String GetAddressByLocation(string longitude, string latitude, string output, int pois = 0)
        {
            try
            {
                string Ak = CommonHelper.GetAppSettingsValue("Ak", "TBHTGEjDi6X1MRIthT3TLFvo5Zy07IhK");
                string baiduLocationApi = CommonHelper.GetAppSettingsValue("baiduLocationApi", "http://api.map.baidu.com/geocoder/v2/");
                string url = string.Format("{5}?callback=renderReverse&location={0},{1}&output={2}&pois={3}&ak={4}"
                    , latitude, longitude, output, pois, Ak, baiduLocationApi);
                string retrunStr = UtilityHelper.HttpService.GetHttpWebResponseByRestSharp(url, string.Empty);
                //string temp1 = UtilityHelper.Utils.UnicodeToString(retrunStr);
                return retrunStr;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());

                return null;
            }
        }

        #endregion

        #region 获取当位置的经纬度
        /// <summary>
        /// 获取当位置的经纬度
        /// </summary>
        /// <returns></returns>
        static public String GetCurrentLocation()
        {
            string result = string.Empty;
            try
            {
                GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
                watcher.Start();
                watcher.TryStart(false, TimeSpan.FromMilliseconds(60000));////超过5S则返回False;  
                GeoCoordinate coord = watcher.Position.Location;
                if (coord.IsUnknown != true)
                {
                    result = "东经:" + coord.Longitude.ToString() + "\t北纬" + coord.Latitude.ToString() + "\n";
                }
                else
                {
                    result = "地理未知";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
                result = "地理未知"+ ex.Message;
            }
            return result;
        }
        #endregion
    }
}
