using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using BWJS.Model;
using BWJS.Model.Model;
using UtilityHelper;
using System.Data.SqlClient;
using BWJSLog.BLL;
using System.Linq;

namespace BWJS.BLL
{
    //资源表
    public partial class ResourceBLL
    {

        private readonly BWJS.DAL.Ad.ResourceDAL dal = new DAL.Ad.ResourceDAL();
        public ResourceBLL()
        { }

        #region  Method

        /// <summary>
        /// 增加一条数据8
        /// </summary>
        public int Add(Resource model)
        {
            return dal.Add(model);
        }

        public bool ResourceAdd(int ResourceID, int AdPositionID, AdRelease AdRelease, string TPath, out string msg, byte[] fileData = null, string fileName = "")
        {
            msg = "true";
            using (SqlConnection conn = new SqlConnection(BWJSHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        if (ResourceID == 0)
                        {
                            ResourceID = SaveFile(fileName, fileData, TPath);
                        }

                        if (ResourceID > 0)
                        {
                            AdReleaseBLL AdReleasebll = new AdReleaseBLL();
                            AdRelease.ResourceID = ResourceID;
                            AdRelease.RecordUpdateUserID = 1;
                            int AdReleaseID = 0;
                            if (AdRelease.AdReleaseID > 0)
                            {
                                AdReleaseID = Convert.ToInt32(AdReleasebll.Update(AdRelease));
                            }
                            else {
                                AdReleaseID = AdReleasebll.Add(AdRelease);
                                AdRelease.AdReleaseID = AdReleaseID;
                            }
                            //bool b = AdReleasebll.UpdateResourceID(AdRelease);
                            if (AdReleaseID > 0)
                            {
                                if (AdPositionID > 0)
                                {
                                    AdPositionBLL bll = new AdPositionBLL();
                                    bool c = false;
                                    bll.BackUpdate(AdRelease.AdReleaseID);
                                    c = bll.UpdateAdReleaseID(AdRelease.AdReleaseID, AdPositionID);


                                    if (c)
                                    {
                                        trans.Commit();
                                        return true;
                                    }
                                    else {
                                        msg = "广告绑定失败！";
                                        return false;
                                    }
                                }
                                else {
                                    msg = "广告位选定失败！";
                                    return false;
                                }
                            }
                            else {
                                msg = "广告资源添加失败！";
                                return false;
                            }

                        }
                        else {
                            msg = "资源保存失败！";
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        ExceptionLogBLL.WriteExceptionLogToDB(e.ToString());
                        trans.Rollback();
                        msg = "False";
                        return false;
                    }
                }
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Resource model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateDelete(int ResourceID)
        {

            return dal.UpdateDelete(ResourceID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool UpdateDeleteList(string ResourceIDlist)
        {
            return dal.UpdateDeleteList(ResourceIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Resource GetModel(int ResourceID)
        {

            return dal.GetModel(ResourceID);
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Resource> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Resource> DataTableToList(DataTable dt)
        {
            List<Resource> modelList = new List<Resource>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Resource model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Resource();
                    if (dt.Rows[n]["ResourceID"].ToString() != "")
                    {
                        model.ResourceID = int.Parse(dt.Rows[n]["ResourceID"].ToString());
                    }
                    model.ResourceName = dt.Rows[n]["ResourceName"].ToString();
                    model.FileName = dt.Rows[n]["FileName"].ToString();
                    model.VirtualPath = dt.Rows[n]["VirtualPath"].ToString();
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    model.FileSuffix = dt.Rows[n]["FileSuffix"].ToString();
                    model.MD5 = dt.Rows[n]["MD5"].ToString();
                    if (dt.Rows[n]["CreatUserID"].ToString() != "")
                    {
                        model.CreatUserID = int.Parse(dt.Rows[n]["CreatUserID"].ToString());
                    }
                    if (dt.Rows[n]["RecordUpdateUserID"].ToString() != "")
                    {
                        model.RecordUpdateUserID = int.Parse(dt.Rows[n]["RecordUpdateUserID"].ToString());
                    }
                    if (dt.Rows[n]["RecordIsDelete"].ToString() != "")
                    {
                        if ((dt.Rows[n]["RecordIsDelete"].ToString() == "1") || (dt.Rows[n]["RecordIsDelete"].ToString().ToLower() == "true"))
                        {
                            model.RecordIsDelete = true;
                        }
                        else
                        {
                            model.RecordIsDelete = false;
                        }
                    }
                    if (dt.Rows[n]["RecordUpdateTime"].ToString() != "")
                    {
                        model.RecordUpdateTime = DateTime.Parse(dt.Rows[n]["RecordUpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["RecordCreateTime"].ToString() != "")
                    {
                        model.RecordCreateTime = DateTime.Parse(dt.Rows[n]["RecordCreateTime"].ToString());
                    }


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
        #endregion


        public static int SaveFile(string fileName, byte[] fileData, string TPath, bool isNewName = true)
        {
            int ResourceID = 0;
            try
            {

                //var basePath = CommonHelper.GetConfigValue("ResourceBasePath");
                //if (string.IsNullOrEmpty(basePath))
                //    throw new NullReferenceException("ResourceBasePath 不能为空！");

                //文件后缀
                var fileSuffix = fileName.Substring(fileName.LastIndexOf('.') + 1);

                var newFileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), fileSuffix);
                //区分是否使用原有名称
                if (!isNewName)
                {
                    newFileName = fileName;
                }
                //var filePath = System.IO.Path.Combine(basePath, newFileName);
                string fPath = "/Resources/";
                string filePath = fPath + TPath;



                // 保存资源
                ResourceBLL bll = new ResourceBLL();
                var resource = new BWJS.Model.Resource()
                {
                    ResourceName = fileName,
                    FileName = fileName,
                    FilePath = filePath,
                    VirtualPath = "/" + System.IO.Path.Combine(newFileName).Replace("\\", "/"),
                    FileSuffix = fileSuffix,
                    CreatUserID = 1,
                    RecordUpdateUserID = 1,
                    RecordIsDelete = false
                };
                ResourceID = bll.Add(resource);
                //if (b)
                //{
                //    ResourceID = resource.ResourceID;
                //}
                return ResourceID;
            }
            catch (Exception ex)
            {
                ExceptionLogBLL.WriteExceptionLogToDB(ex.ToString());
            }

            return ResourceID;
        }

    }
}