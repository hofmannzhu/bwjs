using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
 

namespace UtilityHelper
{
    /// <summary>
    /// @author:
    /// @datetime:2015-07-10
    /// @describe:
    ///     1、用于一般处理程序继承
    ///     2、实现一个Handler文件多个Action的处理
    /// </summary>
    public class BaseHandler : IHttpHandler, IRequiresSessionState
    {
        private HttpContext _context;

        

        /// <summary>
        /// Action字典项，不区分大小写
        /// </summary>
        protected Dictionary<string, Action> DictAction = new Dictionary<string, Action>(StringComparer.CurrentCultureIgnoreCase);

        /// <summary>
        /// 方法
        /// </summary>
        protected string Action { get; set; }

        /// <summary>
        /// Session对象
        /// </summary>
        protected HttpSessionState Session
        {
            get
            {
                return _context.Session;
            }
        }

        /// <summary>
        /// 请求对象
        /// </summary>
        protected HttpRequest Request
        {
            get
            {
                return _context.Request;
            }
        }

        /// <summary>
        /// 响应对象
        /// </summary>
        protected HttpResponse Response
        {
            get
            {
                return _context.Response;
            }
        }

        /// <summary>
        /// 分页列表，当前页数
        /// </summary>
        protected int PageIndex
        {
            get
            {
                int pageIndex;
                Int32.TryParse(Request.Params["pagenum"], out pageIndex);
                return pageIndex + 1;
            }
        }

        /// <summary>
        /// 分页列表，每页条数，默认15
        /// </summary>
        protected int PageSize
        {
            get
            {
                int pageSize;
                Int32.TryParse(Request.Params["pagesize"], out pageSize);
                return pageSize == 0 ? 15 : pageSize;
            }
        }

        /// <summary>
        /// 数据列表排序
        /// </summary>
        protected string OrderBy
        {
            get
            {
                //排序字段
                string field = ParamString("sortdatafield");
                if (field == "") return "";
                //方向
                string desc = ParamString("sortorder");
                if (desc == "")
                    desc = "DESC";
                return field + " " + desc.ToUpper();
            }
        }

        /// <summary>
        /// 处理业务事件
        /// </summary>
        /// <param name="actionName">事件方法</param>
        protected virtual void DoAction(string actionName)
        {
            if (string.IsNullOrEmpty(actionName) || !DictAction.ContainsKey(actionName))
                return;
            Action action;
            if (!DictAction.TryGetValue(actionName, out action))
            {
                throw new ArgumentException("Action Is Not Found");
            }
            action();
        }

        /// <summary>
        /// Http请求处理
        /// </summary>
        /// <param name="context">HTTP请求上下文</param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1000;
            _context = context;
            try
            {
                Action = Request.Params["Action"];
                DoAction(Action);
            }
            catch (ArgumentException aex)
            {
                //参数异常
                throw new ArgumentException("Action Is Not Found");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 提取URL请求中Int类型参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected int? ParamInt(string name)
        {
            if (string.IsNullOrEmpty(GetParam(name)))
                return null;
            int result;
            int.TryParse(GetParam(name), out result);
            return result;
        }

        /// <summary>
        /// 提取URL请求中string类型参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected string ParamString(string name)
        {
            return GetParam(name);
        }

        /// <summary>
        /// 提取URL请求中DateTime类型参数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected DateTime? ParamDateTime(string name)
        {
            if (string.IsNullOrEmpty(GetParam(name)))
                return null;
            DateTime dateTime;
            DateTime.TryParse(GetParam(name), out dateTime);
            return dateTime;
        }

        private string GetParam(string name)
        {
            string value =  Request.QueryString[name] ?? Request.Form[name];
            return string.IsNullOrEmpty(value) ? "" : value.Trim();
        }
    }
}