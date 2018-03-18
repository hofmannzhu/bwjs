using BWJS.AppCode;
using BWJS.BLL;
using BWJS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityHelper;

namespace BWJS.WebApp.Admin
{
    public partial class CompanyAddpx : AdminPage
    {
        public StringBuilder strCityAreaTree = new StringBuilder(); //
        CityAreaBLL CityAreabll = new CityAreaBLL();
        public int CompanyId = 0;
        public int LoginUserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginUserID = currentAdmin.UserID;
            CompanyId = DNTRequest.GetInt("CompanyId", 0);
            DrpCityAreaData(1);
        }
        public void DrpCityAreaData(int ParentID)
        {

            strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", "", "请选择");

            List<CityArea> lstCityArea = new List<CityArea>();
            lstCityArea = CityAreabll.GetCityAreaAllList(ParentID);
            var list = lstCityArea.Where(d => d.ParentID == ParentID);
            foreach (var item in list)
            {
                strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), item.Name);
            }

        }
    }
}