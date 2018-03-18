using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mofang.Model.ViewModel
{
    public partial class OrderApplyViewModel
    {
        public ApplicantInfo applicantInfo { get; set; }
        public ApplicationData applicationData { get; set; }
        public InsurantInfo insurantInfo { get; set; }
        public Transactions transactions { get; set; }
        public OrderApply orderApply { get; set; }
        public OtherInfo otherInfo { get; set; }     
        public string transNo { get; set; }
        public string caseCode { get; set; }
        public int productId { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
