using UtilityHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BWJS.WebPad.Ajax.Helper.BWJS;
using BWJS.WebPad.Ajax.Helper.Mofang;

namespace BWJS.WebPad.Ajax.Helper
{
    /// <summary>
    /// 调度
    /// </summary>
    [DataContract]
    public partial class BWJSDisptcher
    {
        /// <summary>
        /// 调度
        /// </summary>
        static public void Dispatcher()
        {
            string op = DNTRequest.GetString("op");
            string jsonText = string.Empty;
            if (string.IsNullOrEmpty(op))
            {
                op = JsonRequest.GetJsonKeyVal("op", ref jsonText);
            }

            if (!string.IsNullOrEmpty(op))
            {
                switch (op)
                {
                    case "bwjs":
                        BWJSDispatcherServices.Dispatcher(jsonText);
                        break;
                    case "mofang":
                        MofangDispatcherServices.Dispatcher(jsonText);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
