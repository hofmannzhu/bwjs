using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModels.Output
{
    public  class ReturnModel
    {

        public ReturnModel()
        {
            IsSuccess = false;          
            ErrMessage = "";
            Data = null;

        }
         

        /// <summary>
        /// 是否成功返回
        /// </summary>
        public bool IsSuccess { get; set; }

      
        /// <summary>
        /// 失败是错误提示信息（返给客户看见的提示信息，而不是Exception）
        /// </summary>
        public string ErrMessage { get; set; }


        /// <summary>
        /// 成功返回时的数据
        /// </summary>
        public object Data { get; set; }
    }
}
