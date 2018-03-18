using UtilityHelper;

namespace BWJS.WebApp.Ajax.Helper.Mofang
{
    /// <summary>
    /// 魔方实现
    /// </summary>
    public class MofangDispatcherServices
    {
        /// <summary>
        /// 调度实现
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
                    case "regionhelper":
                        IRegion.Implementation(jsonText);
                        break;
                    case "jobhelper":
                        IJob.Implementation(jsonText);
                        break;
                }

                #endregion
            }
        }
    }
}