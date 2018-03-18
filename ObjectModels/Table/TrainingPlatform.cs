using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModels.Table
{
    public class TrainingPlatform
    {
        public int TrainID { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public string PicPathName { get; set; }
        public bool RecordIsDelete { get; set; }
        public DateTime RecordCreateTime { get; set; }
        public DateTime RecordUpdateTime { get; set; }
    }
}
