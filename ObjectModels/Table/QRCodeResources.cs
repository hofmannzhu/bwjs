using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModels.Table
{
    public class QRCodeResources
    {
        public int QRCodeID { get; set; }
        public string Name { get; set; }
        public string PicPathName { get; set; }
        public string VideoPathName { get; set; }
        public string QRCodePathName { get; set; }
        public string PdfPathName { get; set; }
        public string STLPathName { get; set; }

        public int TrainID { get; set; }
        public string Description { get; set; }
        public bool RecordIsDelete { get; set; }
        public DateTime RecordCreateTime { get; set; }
        public DateTime RecordUpdateTime { get; set; }
    }
}
