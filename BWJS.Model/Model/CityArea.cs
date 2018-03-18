using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.Model
{
    /// <summary>
    /// 地区
    /// </summary>
    [Serializable]
    public  class CityArea
    {
        /// <summary>
        ///地区
        /// </summary>	
        public int ID { get; set; }

        /// <summary>
        ///地区父级
        /// </summary>	
        public int ParentID { get; set; }


        /// <summary>
        ///地区父级
        /// </summary>	
        public string Name { get; set; }

        /// <summary>
        ///树结构分支
        /// </summary>	
        public string Grade { get; set; }

    }
}
