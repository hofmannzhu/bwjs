using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.InputModel
{
    public class UnBindMachineInputModel :InputModelBase
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public string MAC { get; set; }

    }
}
