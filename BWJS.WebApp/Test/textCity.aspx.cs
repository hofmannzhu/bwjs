using BWJS.BLL;
using BWJS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BWJS.WebApp.AD
{
    public partial class textCity : System.Web.UI.Page
    {
        public StringBuilder strCityAreaTree = new StringBuilder(); //
        CityAreaBLL CityAreabll = new CityAreaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(),  item.Name);
            }

        }

        /// <summary>
        /// 绑定生成一个有树结构的下拉菜单 
        /// </summary>
        /// <param name="ParentId">父ID</param>
        /// <param name="i">用来控制缩入量的值，请输入-1</param>
        private void CityAreaTree(int ParentId, int i, List<CityArea> lstCityArea)
        {
            string strPading = ""; //缩入字符 
            i++;
            for (int j = 0; j < i; j++)
            {
                strPading += "　";//如果要增加缩入的长度，改成两个全角的空格就可以了 
            }
            var list = lstCityArea.Where(d => d.ParentID == ParentId);
            foreach (var item in list)
            {
                strCityAreaTree.AppendFormat("  <option value=\"{0}\">{1}</option>", item.ID.ToString(), strPading + " " + item.Name);
                CityAreaTree(item.ID, i, lstCityArea);
            }
            i--;
        }

    }
}