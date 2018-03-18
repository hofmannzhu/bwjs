using BWJS.Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityHelper;
using UtilityHelper.Data;

namespace BWJS.DAL
{
    public class CityAreaDAL : BaseService
    {
        public List<CityArea> GetCityAreaAllList(int ParentID)
        {
            string strSelectFields = " ID,ParentID,Name,Grade";
            string strSql = "SELECT " + strSelectFields + " FROM [CityArea]  WHERE ParentID=" + ParentID + "    ORDER BY ParentID ASC ";
            return SqlDataUtilityHelper.GetListFromDB<CityArea>(strSelectFields, this.ConnectionString, strSql);
        }


        public DataSet GetCityAreaName(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  Name  FROM [CityArea]  WHERE ID=" + ID + "   ");
            return BWJSHelperSQL.Query(strSql.ToString());
        }

    }
}
