using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModels.Table
{
    public class ProductInfo
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int TypeID { get; set; }
        public string PicPathName { get; set; }
        public string Introduction { get; set; }   
        public bool RecordIsDelete { get; set; }
        public DateTime RecordCreateTime { get; set; }
        public DateTime RecordUpdateTime { get; set; }
    }
}
