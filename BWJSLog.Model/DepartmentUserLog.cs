using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJSLog.Model
{
    public class DepartmentUserLog
    {
        public int DULID { get; set; }
        public int DepartmentID { get; set; }
        public string Remark { get; set; }
        public int UpType { get; set; }
        public int UserID { get; set; }
        public int UpdateUser { get; set; }

        public bool RecordIsDelete { get; set; }

        public DateTime RecordCreateTime { get; set; }

        public DateTime RecordUpdateTime { get; set; }

    }
}
