using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWJS.Model.InputModel;
using BWJS.Model.OutputModel;
using System.Data.SqlClient;
using UtilityHelper.Data;

namespace BWJS.DAL.AdHelper
{
    public partial class AdHelperDAL : BaseService
    {
        public List<AdPostionReleaseOutputModel> GetAdPostionReleaseList(int typeId)
        {
            try
            {
                string strOrderBy = "  ORDER BY AP.Sort ";
                string strOutFields = "DefaultPicUrl, [FileName], FilePath ,FileSuffix,BeginTime,EndTime";
                string strSelectFields = "AP.DefaultPicUrl, R.FileName, R.FilePath , R.FileSuffix,AR.BeginTime,AR.EndTime";
                string strTable = @"AdPosition AP
                    Left join  AdRelease AR on AP.AdReleaseID =AR.AdReleaseID  and AR.RecordIsDelete = 0
                    Left join  [Resource] R on R.ResourceID = AR.ResourceID and R.RecordIsDelete = 0";
                string strSql = "SELECT  " + strSelectFields + " FROM " + strTable + " WHERE  AP.RecordIsDelete= 0 and AP.TypeId="+ typeId;
                strSql = strSql + strOrderBy;
                SqlParameter[] parameters = new SqlParameter[]{
                // new SqlParameter ("@TypeID",TypeID)
               };
                List<AdPostionReleaseOutputModel> list = SqlDataUtilityHelper.GetListFromDB<AdPostionReleaseOutputModel>(strOutFields, ConnectionString, strSql, parameters);

                return list;
            }
          catch
            {

            }
            return null;
        }
    }
}
