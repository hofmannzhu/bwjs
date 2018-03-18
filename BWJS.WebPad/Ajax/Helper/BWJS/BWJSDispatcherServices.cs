using UtilityHelper;

namespace BWJS.WebPad.Ajax.Helper.BWJS
{
    /// <summary>
    /// 调度实现
    /// </summary>
    public class BWJSDispatcherServices
    {
        /// <summary>
        /// 调度
        /// </summary>
        static public void Dispatcher(string jsonText)
        {
            string om = DNTRequest.GetString("om");
            if (string.IsNullOrEmpty(om))
            {
                om = JsonRequest.GetJsonKeyVal(jsonText, "om");
            }
            if (!string.IsNullOrEmpty(om))
            {
                #region 实现

                switch (om)
                {
                    case "test":
                        ITest.Implementation(jsonText);
                        break;
                    case "gl":
                        IGL.Implementation(jsonText);
                        break;
                    case "func":
                        IFunction.Implementation(jsonText);
                        break;
                    case "netloan":
                        INetLoan.Implementation(jsonText);
                        break;
                    case "newnetloan":
                        INewNetLoan.Implementation(jsonText);
                        break;
                    case "menu":
                        ILeftMenu.Implementation(jsonText);
                        break;
                    case "heartbeat":
                        IHeartbeat.Implementation(jsonText);
                        break;
                    case "settlement":
                        ISettlement.Implementation(jsonText);
                        break;
                    case "product":
                        IProduct.Implementation(jsonText);
                        break;

                }

                #endregion
            }
        }
    }
}