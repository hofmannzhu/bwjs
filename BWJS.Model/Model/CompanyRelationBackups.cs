using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWJS.Model
{
    public class CompanyRelationBackups:CompanyRelation
    {
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string MainBusiness { get; set; }
    }
}
