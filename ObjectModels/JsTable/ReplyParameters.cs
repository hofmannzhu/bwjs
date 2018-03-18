using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModels.JsTable
{
    /// <summary>
    /// DataTables.js服务器返回对象
    /// </summary>
    [Serializable]
    public class ReplyParameters<T> 
    {
        /// <summary>
        /// 过滤前的总数
        /// </summary>
        [JsonProperty("iTotalRecords")]
        public int TotalRecords { get; set; }
        /// <summary>
        /// 过滤后的总数
        /// </summary>
        [JsonProperty("iTotalDisplayRecords")]
        public int TotalDisplayRecords { get; set; }

        /// <summary>
        /// 客户端请求附带参数，原样返回
        /// An unaltered copy of sEcho sent from the client side. This parameter will change with each draw (it is basically a draw count) - so it is important that this is implemented. Note that it strongly recommended for security reasons that you 'cast' this parameter to an integer in order to prevent Cross Site Scripting (XSS) attacks.
        /// </summary>
        [JsonProperty("sEcho")]
        public string Echo { get; set; }

        /// <summary>
        /// 客户端需要显示的列，非必填
        /// Optional - this is a string of column names, comma separated (used in combination with sName) which will allow DataTables to reorder data on the client-side if required for display. Note that the number of column names returned must exactly match the number of columns in the table. For a more flexible JSON format, please consider using mData.
        /// </summary>
        [JsonProperty("sColumns")]
        public string Columns { get; set; }

        /// <summary>
        /// The data in a 2D array. Note that you can change the name of this parameter with sAjaxDataProp.
        /// </summary>
        [JsonProperty("aaData")]
        public List<T> Data { get; set; }

        public ReplyParameters()
        {
            Data = new List<T>();
        }
 
    }
}
