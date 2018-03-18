using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityHelper
{
    [Serializable]
    public class UrlAuthorizationConfig
    {
        public List<AllowItem> Allows { get; set; }

        public List<VerifyItem> Verifys { get; set; }

        public UrlAuthorizationConfig()
        {
            Allows = new List<AllowItem>();
            Verifys = new List<VerifyItem>();
        }
    }

    public class AllowItem
    {
            public string Key { get; set; }

            public bool Like { get; set; }
    }

    public class VerifyItem {

        public string Title { get; set; }

        public string CssClass { get; set; }

        public string Url { get; set; }

        public string Code { get; set; }

        public bool IsDisplay { get; set; }

        public List<VerifyItem> Nodes { get; set; }
    }
}
