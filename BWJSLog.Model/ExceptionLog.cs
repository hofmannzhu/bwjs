using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJSLog.Model
{
    public class ExceptionLog
    {
        public int  LogID { get; set; }
        public string  ClassName { get; set; }
        public string MethodName { get; set; }
        public string  ErrorDesc { get; set; }
        public bool RecordIsDelete { get; set; }
        public DateTime RecordUpdateTime { get; set; }
        public DateTime RecordCreateTime { get; set; }
    
    }
}
