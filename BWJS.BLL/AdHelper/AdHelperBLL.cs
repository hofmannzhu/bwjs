using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWJS.Model.OutputModel;
using BWJS.Model.InputModel;
using BWJS.DAL.AdHelper;

namespace BWJS.BLL.AdHelper
{
    public class AdHelperBLL
    {
        private readonly AdHelperDAL dal = new AdHelperDAL();
        public List<AdPostionReleaseOutputModel> GetAdPostionReleaseList(int typeId)
        {
            return dal.GetAdPostionReleaseList(typeId);
        }
    }
}
