using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mofang.Model.ViewModel
{
    public class ProductsViewModel
    {
        public int ProductsID { get; set; }

        public string ProductPictureUrl { get; set; }

        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CaseCode { get; set; }

        public string ProducDescribe { get; set; }
    }
}
