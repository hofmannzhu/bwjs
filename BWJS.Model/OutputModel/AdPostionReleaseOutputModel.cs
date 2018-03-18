using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.OutputModel
{
    public class AdPostionReleaseOutputModel
    {
         public string DefaultPicUrl { get; set; }
        public string FileName { get; set; }
        public string VirtualPath { get; set; }
        public string FileSuffix { get; set; }

        public string FilePath { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
