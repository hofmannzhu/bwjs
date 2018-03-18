using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model.Model
{
    public class MachineBackups : Machine
    {
        public string UserName { get; set; }

        public string LoginName { get; set; }
        public string SignName { get; set; }
        
    }
}
