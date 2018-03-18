using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModels.Table
{
    public class ApkRelease
    {
        public int ARID { get; set; }
        public string  VersionNumber { get; set; }
        public string ApkUrl { get; set; }
        public string  ApkContent { get; set; }
        public bool RecordIsDelete { get; set; }
        public DateTime RecordCreateTime { get; set; }
        public DateTime RecordUpdateTime { get; set; }
    }
}
