using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.InputModel
{
    public class LoginInputModel : InputModelBase
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// 机器网卡地址
        /// </summary>
        public string Mac { get; set; }

    }
}
