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
    public class CityAreaBLL
    {
        public List<CityArea> GetCityAreaAllList(int ParentID)
        {
            List<CityArea> lstCityArea = new List<CityArea>();
            CityAreaDAL CityAreadal = new CityAreaDAL();
            lstCityArea = CityAreadal.GetCityAreaAllList(ParentID);
            return lstCityArea;
        }

        public string GetCityAreaName(int ID)
        {
            string strCityArea = "";
            DataSet ds = new DataSet();
            CityAreaDAL CityAreadal = new CityAreaDAL();
            ds = CityAreadal.GetCityAreaName(ID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                strCityArea= ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                strCityArea="";
            }

            return strCityArea;
        }


    }
}
