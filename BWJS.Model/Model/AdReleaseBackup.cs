using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.Model
{
    public class AdReleaseBackup : AdRelease
    {
        public string ResourceInfo { get; set; }
        public string FileName { get; set; }
        public int  AdPositionID { get; set; }
        
    }
}
