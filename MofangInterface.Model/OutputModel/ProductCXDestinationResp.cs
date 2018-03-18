using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MofangInterface.Model.OutputModel
{
    public class ProductCXDestinationResp
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        public string respstat { get; set; }

        /// <summary>
        /// 返回状态
        /// </summary>
        public string respmsg { get; set; }
        public string transNo { get; set; }
        public string customkey { get; set; }
        public bool chooseOne { get; set; }
        public List<ProductDestination> destinations { get; set; }
    }
    public class ProductDestination
    {
        public int id { get; set; }
        public string cName { get; set; }
        public string eName { get; set; }
        public int continentId { get; set; }
        public string continentName { get; set; }
        public string initial { get; set; }
        public int? sort { get; set; }
    }
}
