using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModels.Table
{
    public  class QuestionBank
    {
        public int QBID { get; set; }
        public string Question { get; set; }
        public int? QType { get; set; }
        public string Answer { get; set; }
        public string  OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public int? TrainID { get; set; }
         
        public bool RecordIsDelete { get; set; }
        public DateTime RecordCreateTime { get; set; }
        public DateTime RecordUpdateTime { get; set; }
    }
}
