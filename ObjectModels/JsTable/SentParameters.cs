
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ObjectModels.JsTable
{
    /// <summary>
    /// jquery.dataTables.js 服务端接收类
    /// </summary>
    public class SentParameters
    {

        /// <summary>
        /// 业务类型
        /// </summary>
        [JsonProperty("do")]
        public string Do { get; set; }

        /// <summary>
        /// 显示起始点，页码
        /// </summary>
        [JsonProperty("iDisplayStart")]
        public int DisplayStart { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        [JsonProperty("iDisplayLength")]
        public int DisplayLength { get; set; }

        /// <summary>
        /// 显示的列数
        /// </summary>
        [JsonProperty("iColumns")]
        public int Columns { get; set; }

        /// <summary>
        /// 全局搜索字段
        /// </summary>
        [JsonProperty("sSearch")]
        public string GlobalSearch { get; set; }

        /// <summary>
        /// 是否是正则过滤
        /// </summary>
        [JsonProperty("bRegex")]
        public bool GlobalRegex { get; set; }

        /// <summary>
        /// 列标记是否可以搜索，bSearchable_(int),这里的int对应iColumns的数量
        /// </summary>
        [JsonProperty("bSearchable_")]
        public List<bool> Searchable { get; set; }

        /// <summary>
        /// 列过滤，sSearch_(int),这里的int对应iColumns的数量
        /// </summary>
        [JsonProperty("sSearch_")]
        public List<string> Search { get; set; }

        /// <summary>
        /// 列是否是正则过滤，bRegex_(int),这里的int对应iColumns的数量
        /// </summary>
        [JsonProperty("bRegex_")]
        public List<bool> Regex { get; set; }

        /// <summary>
        /// 列是否能排序，bSortable_(int),这里的int对应iColumns的数量
        /// </summary>
        [JsonProperty("bSortable_")]
        public List<bool> Sortable { get; set; }

        /// <summary>
        /// 能够同时排序的列数量
        /// </summary>
        [JsonProperty("iSortingCols")]
        public int SortingCols { get; set; }

        /// <summary>
        /// 排序的列索引，iSortCol_(int)，这里的int对应iSortingCols的数量
        /// </summary>
        [JsonProperty("iSortCol_")]
        public List<int> SortCol { get; set; }

        /// <summary>
        /// 排序方式， "desc" or "asc".sSortDir_(int)，这里的int对应iSortingCols的数量
        /// </summary>
        [JsonProperty("sSortDir_")]
        public List<string> SortDir { get; set; }

        /// <summary>
        /// The value specified by mDataProp for each column. This can be useful for ensuring that the processing of data is independent from the order of the columns.
        /// mDataProp_(int),这里的int对应iColumns的数量
        /// </summary>
        [JsonProperty("mDataProp_")]
        public List<string> DataProp { get; set; }

        /// <summary>
        /// 客户端请求附带参数，服务器原样返回
        /// An unaltered copy of sEcho sent from the client side. This parameter will change with each draw (it is basically a draw count) - so it is important that this is implemented. Note that it strongly recommended for security reasons that you 'cast' this parameter to an integer in order to prevent Cross Site Scripting (XSS) attacks.
        /// </summary>
        [JsonProperty("sEcho")]
        public string Echo { get; set; }

        /// <summary>
        /// 自定义参数集合，用户自定义的，默认已"c_"开头
        /// </summary>
        [JsonIgnore()]
        public Dictionary<string, string> CustomerParameters { get; set; }

        public SentParameters()
        {
            Searchable = new List<bool>();
            Search = new List<string>();
            Regex = new List<bool>();
            Sortable = new List<bool>();
            SortCol = new List<int>();
            SortDir = new List<string>();
            DataProp = new List<string>();
            CustomerParameters = new Dictionary<string, string>();
        }
 

    }
}
