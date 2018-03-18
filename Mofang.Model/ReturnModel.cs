using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mofang.Model
{
    public class ReturnModel
    {
        public ReturnModel()
        {
            IsSuccess = false;
        }
        public bool IsSuccess { get; set; }

        public string ErrCode { get; set; }

        public string ErrMessage { get; set; }

        public object Data { get; set; }
    }
}
