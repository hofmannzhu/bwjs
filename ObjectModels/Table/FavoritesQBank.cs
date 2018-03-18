using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModels.Table
{
    public class FavoritesQBank
    {
        public int FavoritesID { get; set; }
        public int? UserID { get; set; }  
        public int? QBID { get; set; }      
        public bool RecordIsDelete { get; set; }
        public DateTime RecordCreateTime { get; set; }
        public DateTime RecordUpdateTime { get; set; }
    }
}
