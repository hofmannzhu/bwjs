using UtilityHelper;
using BWJS.BLL;
using BWJS.Model;
using Mofang.BLL;
using Mofang.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;
using System.Web.Caching;

namespace BWJS.AppCode
{
    /// <summary>
    /// 页面继承类实现
    /// </summary>
    public class ComPage
    {
        #region 静态变量

        /// <summary>
        /// 前端当前用户对象key CurrentUser
        /// </summary>
        static public string memberModel = "CurrentUser";
        /// <summary>
        /// 前端当前用户CacheDependencyKey User
        /// </summary>
        static public string memberModelCacheDependency = "User";
        /// <summary>
        /// 后台当前用户对象key AdminUser
        /// </summary>
        static public string employeeModel = "AdminUser";
        /// <summary>
        /// 后台当前用户CacheDependencyKey Admin
        /// </summary>
        static public string employeeModelCacheDependency = "Admin";

        #endregion

        #region 前端登录对象
        /// <summary>
        /// 前端当前登录人信息
        /// </summary>
        static public Users CurrentUser
        {
            get
            {
                Users currentuser = null;
                if (System.Web.HttpContext.Current.Request.Cookies[LinkFun.ConfigString("FrontEndCookieName", "BWJSFrontEnd20180108")] != null)
                {
                    int Id = ComPage.SafeToInt(System.Web.HttpContext.Current.Request.Cookies[LinkFun.ConfigString("FrontEndCookieName", "BWJSFrontEnd20180108")]["Id"]);
                    string key = memberModel + Id;
                    if (GetBWJSCache(key) == null)
                    {
                        UsersBLL op = new UsersBLL();
                        currentuser = op.GetModel(Id);
                        key = memberModelCacheDependency + Id;
                        SetBWJSCache(key, currentuser, GetBWJSCacheDependency(key), DateTime.Now.AddMinutes(ComPage.SafeToDouble(LinkFun.ConfigString("FrontEndCookieExpires", "120"))), TimeSpan.Zero);
                    }
                    else
                    {
                        currentuser = GetBWJSCache(key) as Users;
                    }
                }
                return currentuser;
            }
        }
        #endregion

        #region 后台登录对象
        /// <summary>
        /// 后台当前登录人信息
        /// </summary>
        static public Users CurrentAdmin
        {
            get
            {
                Users currentAdmin = null;
                if (System.Web.HttpContext.Current.Request.Cookies[Utils.GetAppSettingsValue("cookieName")] != null)
                {
                    int adminId = ComPage.SafeToInt(System.Web.HttpContext.Current.Request.Cookies[Utils.GetAppSettingsValue("cookieName")]["Id"]);
                    string key = employeeModel + adminId;
                    if (GetBWJSCache(key) == null)
                    {
                        UsersBLL op = new UsersBLL();
                        currentAdmin = op.GetModel(adminId);
                        key = employeeModelCacheDependency + adminId;
                        SetBWJSCache(key, currentAdmin, GetBWJSCacheDependency(key), DateTime.Now.AddMinutes(ComPage.SafeToDouble(LinkFun.ConfigString("cookieExpires", "120"))), TimeSpan.Zero); //Utils.GetAppSettingsValue("cookieExpires")
                    }
                    else
                    {
                        currentAdmin = GetBWJSCache(key) as Users;
                    }
                }
                return currentAdmin;
            }
        }
        #endregion

        #region 格式化

        static public string SafeToString(object v)
        {
            if (v == null || v == Convert.DBNull || v.ToString().Equals("")) return string.Empty;
            return Convert.ToString(v).Trim();
        }
        static public int SafeToInt(object v)
        {
            if (v == null || Convert.DBNull.Equals(v)) return -1;
            if (v.GetType() == typeof(string) && string.Empty.Equals(v)) return -1;
            try { return Convert.ToInt32(v); }
            catch (InvalidCastException) { }
            catch (FormatException) { }
            return -1;
        }

        static public int? SafeToIntNull(object v)
        {
            if (v == null || Convert.DBNull.Equals(v)) return null;
            if (v.GetType() == typeof(string) && string.Empty.Equals(v)) return null;
            try { return Convert.ToInt32(v); }
            catch (InvalidCastException) { }
            catch (FormatException) { }
            return null;
        }
        static public double SafeToDouble(object v)
        {
            if (v == null || Convert.DBNull.Equals(v)) return 0;
            if (v.GetType() == typeof(string) && string.Empty.Equals(v)) return 0;
            try { return Convert.ToDouble(v); }
            catch (InvalidCastException) { }
            catch (FormatException) { }
            return 0;
        }

        static public double? SafeToDoubleNull(object v)
        {
            if (v == null || Convert.DBNull.Equals(v)) return null;
            if (v.GetType() == typeof(string) && string.Empty.Equals(v)) return null;
            try { return Convert.ToDouble(v); }
            catch (InvalidCastException) { }
            catch (FormatException) { }
            return null;
        }

        static public Decimal SafeToDecimal(object v)
        {
            if (v == null || Convert.DBNull.Equals(v)) return 0;
            if (v.GetType() == typeof(string) && string.Empty.Equals(v)) return 0;
            try { return Convert.ToDecimal(v); }
            catch (InvalidCastException) { }
            catch (FormatException) { }
            return 0;
        }
        static public Decimal? SafeToDecimalNull(object v)
        {
            if (v == null || Convert.DBNull.Equals(v)) return null;
            if (v.GetType() == typeof(string) && string.Empty.Equals(v)) return null;
            try { return Convert.ToDecimal(v); }
            catch (InvalidCastException) { }
            catch (FormatException) { }
            return null;
        }

        static public DateTime? SafeToDateTimeNull(object v)
        {
            if (v == DBNull.Value || v == null || v.ToString().Trim() == "")
                return null;
            else
                return Convert.ToDateTime(v);
        }
        static public DateTime SafeToDateTime(object v)
        {
            if (v == DBNull.Value || v == null || v.ToString().Trim() == "")
                return DateTime.Now;
            else
                return Convert.ToDateTime(v);
        }

        #endregion

        #region 分页

        #region 通用分页

        /// <summary>
        /// 拼html
        /// </summary>
        public static string ShowPageHtml(int zys, int sumcount, int currpage, string url, string Page_Parameter_Name)
        {
            StringBuilder sb = new StringBuilder();
            //计算分页---前后各显示8条记录
            int qian = 1;  //开始的页数
            int end = zys;  //结束页数
            if (currpage > 4)
            {
                qian = currpage - 4;
            }
            if (zys > currpage + 4)
            {
                end = currpage + 4;
            }
            sb.Append("<div class='divpage'>");
            sb.Append("共 <strong>" + sumcount + "</strong> 条记录");
            //加载前面页数
            if (currpage > 1)
            {
                sb.Append("<a href='" + url + Page_Parameter_Name + "=1'>首页</a> ");
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + (currpage - 1) + "#m1' title='上一页'>上一页</a> ");
            }
            for (int g = qian; g < currpage; g++)
            {
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + g.ToString() + "#m1' title='转到第" + g.ToString() + "页'>" + g.ToString() + "</a> ");
            }
            //加载当前页
            //sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + currpage.ToString() + "#m1' title='当前页第" + currpage + "页' ><font color='red'>" + currpage.ToString() + "</font></a> ");

            sb.Append(" <a class=\"on\" href='" + url + Page_Parameter_Name + "=" + currpage.ToString() + "#m1' title='当前页第" + currpage + "页' >" + currpage.ToString() + "</a> ");

            //加载后面页数
            for (int epage = currpage + 1; epage < end + 1; epage++)
            {
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + epage.ToString() + "#m1' title='转到第" + epage + "页' >" + epage.ToString() + "</a> ");
            }
            if (currpage < end)
            {
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + (currpage + 1) + "#m1' title='下一页' >下一页</a> ");
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + end + "#m1'>尾页</a>");
            }
            sb.Append("页次：" + currpage + "/" + zys + "</div>");
            return sb.ToString();
        }
        /// <summary>
        /// 显示Html
        /// </summary>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <param name="currpage">当前页索引</param>
        /// <param name="url">重定向Url</param>
        public static string ShowPageHtml(int zys, int sumcount, int currpage, string url)
        {
            if (url.IndexOf("?") != -1)
            {
                return ShowPageHtml(zys, sumcount, currpage, url, "&page");
            }
            else
            {
                return ShowPageHtml(zys, sumcount, currpage, url, "?page");
            }
        }
        /// <summary>
        /// 显示Html
        /// </summary>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <param name="currpage">当前页索引</param>
        /// <param name="url">重定向Url</param>
        public static string ShowPageHtmlByPage(int zys, int sumcount, int currpage, string url, string page)
        {
            if (url.IndexOf("?") != -1)
            {
                return ShowPageHtml(zys, sumcount, currpage, url, "&" + page);
            }
            else
            {
                return ShowPageHtml(zys, sumcount, currpage, url, "?" + page);
            }
        }

        public static string SetPageHtml(int zys, int sumcount, int currpage, string url, string page)
        {
            string html = string.Empty;
            string Page_Parameter_Name = string.Empty;
            if (url.IndexOf("?") != -1)
            {
                Page_Parameter_Name = "&" + page;
            }
            else
            {
                Page_Parameter_Name = "?" + page;
            }
            if (currpage == 1 && zys == 1)
            {
                html += string.Format(" <a href=\"javascript:void(0)\">&lt; 上一题</a> <a href=\"javascript:void(0)\">下一题 &gt;</a> ");
            }
            else if (currpage == 1 && zys > 1)
            {
                html += string.Format(" <a href=\"javascript:void(0)\">&lt; 上一题</a>");
                html += string.Format(" <a class=\"on\" href=\"" + url + Page_Parameter_Name + "=" + (currpage + 1) + "#m1\">下一题 &gt;</a>");
            }
            else if (currpage == zys && zys > 1)
            {
                html += string.Format(" <a class=\"on\" href=\"" + url + Page_Parameter_Name + "=" + (currpage - 1) + "#m1\">&lt; 上一题</a>");
                html += string.Format(" <a href=\"javascript:void(0)\">下一题 &gt;</a> ");
            }
            if (currpage > 1 && currpage < zys)
            {
                html += string.Format(" <a class=\"on\" href=\"" + url + Page_Parameter_Name + "=" + (currpage - 1) + "#m1\">&lt; 上一题</a> ");
                html += string.Format(" <a class=\"on\" href=\"" + url + Page_Parameter_Name + "=" + (currpage + 1) + "#m1\">下一题 &gt;</a>");
            }
            return html;
        }


        #endregion

        #region 视频评论分页

        /// <summary>
        /// 拼html
        /// </summary>
        public static string CommentPageHtml(int zys, int sumcount, int currpage, string url, string Page_Parameter_Name)
        {
            StringBuilder sb = new StringBuilder();
            //计算分页---前后各显示8条记录
            int qian = 1;  //开始的页数
            int end = zys;  //结束页数
            if (currpage > 4)
            {
                qian = currpage - 4;
            }
            if (zys > currpage + 4)
            {
                end = currpage + 4;
            }
            //sb.Append("<div class='divpage'>");
            //sb.Append("共 <strong>" + sumcount + "</strong> 条记录");
            //加载前面页数
            if (currpage > 1)
            {
                sb.AppendFormat("<a class=\"p\" href=\"javascript:void(0)\" onclick=\"commentList(1);\">首页</a> ");
                sb.AppendFormat(" <a class=\"p prevPage\" href=\"javascript:void(0)\" onclick=\"commentList({0});\" title='上一页'>上一页</a> ", (currpage - 1));
            }
            for (int g = qian; g < currpage; g++)
            {
                sb.AppendFormat(" <a class=\"p\" href=\"javascript:void(0)\" onclick=\"commentList({0});\" title='转到第{0}页'>{0}</a> ", g);
            }
            sb.AppendFormat(" <a class=\"p active\" href=\"javascript:void(0)\" title='当前页第{0}页' >{0}</a> ", currpage);

            //加载后面页数
            for (int epage = currpage + 1; epage < end + 1; epage++)
            {
                sb.AppendFormat(" <a class=\"p\" href=\"javascript:void(0)\" onclick=\"commentList({0});\" title='转到第{0}页' >{0}</a> ", epage);
            }
            if (currpage < end)
            {
                sb.AppendFormat(" <a class=\"p nextPage\" href=\"javascript:void(0)\" onclick=\"commentList({0});\" title='下一页' >下一页</a> ", (currpage + 1));
                sb.AppendFormat(" <a class=\"p\" href=\"javascript:void(0)\" onclick=\"commentList({0});\" title='转到第{0}页'>尾页</a>", end);
            }
            //sb.Append("页次：" + currpage + "/" + zys + "</div>");
            sb.Append("<div class=\"custom-right\">");
            sb.AppendFormat("<span class=\"result custom-right-inner\">共 {0}条记录 {1}/{2} 页</span>", sumcount, currpage, zys);
            sb.Append("</div>");
            return sb.ToString();
        }
        /// <summary>
        /// 显示Html
        /// </summary>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <param name="currpage">当前页索引</param>
        /// <param name="url">重定向Url</param>
        public static string ShowCommentPageHtml(int zys, int sumcount, int currpage, string url)
        {
            if (url.IndexOf("?") != -1)
            {
                return CommentPageHtml(zys, sumcount, currpage, url, "&page");
            }
            else
            {
                return CommentPageHtml(zys, sumcount, currpage, url, "?page");
            }
        }
        #endregion

        #region 个人中心分页

        /// <summary>
        /// 拼html
        /// </summary>
        public static string UserCenterPageHtml(int zys, int sumcount, int currpage, string url, string Page_Parameter_Name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<span class=\"result custom-right-inner\">{0}/{1} 页 </span>", currpage, zys);
            if (currpage > 1)
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"jump({0});\" title='上一页'>上一页</a> ", (currpage - 1));
            }
            if (currpage < zys)
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"jump({0});\" title='下一页' >下一页</a> ", (currpage + 1));
            }
            if (zys > 1)
            {
                sb.AppendFormat("<input type=\"text\" class=\"custompage\" onchange=\"jump(this.value);\" />");
                sb.AppendFormat("<span class=\"custom-right-inner\">页</span>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 显示Html
        /// </summary>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <param name="currpage">当前页索引</param>
        /// <param name="url">重定向Url</param>
        public static string ShowUserCenterPageHtml(int zys, int sumcount, int currpage, string url)
        {
            if (url.IndexOf("?") != -1)
            {
                return UserCenterPageHtml(zys, sumcount, currpage, url, "&page");
            }
            else
            {
                return UserCenterPageHtml(zys, sumcount, currpage, url, "?page");
            }
        }
        #endregion

        #region 评论分页

        /// <summary>
        /// 拼html
        /// </summary>
        public static string SetCommonPageHtml(int zys, int sumcount, int currpage, string url, string Page_Parameter_Name)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<span class=\"result custom-right-inner\">{0}/{1} 页 </span>", currpage, zys);
            if (currpage > 1)
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"jump({0});\" title='上一页'>上一页</a> ", (currpage - 1));
            }
            if (currpage < zys)
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"jump({0});\" title='下一页' >下一页</a> ", (currpage + 1));
            }
            if (zys > 1)
            {
                sb.AppendFormat("<input type=\"text\" class=\"custompage\" onchange=\"jump(this.value);\" />");
                sb.AppendFormat("<span class=\"custom-right-inner\">页</span>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 显示Html
        /// </summary>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <param name="currpage">当前页索引</param>
        /// <param name="url">重定向Url</param>
        public static string GetPageHtml(int zys, int sumcount, int currpage, string url)
        {
            if (url.IndexOf("?") != -1)
            {
                return SetCommonPageHtml(zys, sumcount, currpage, url, "&page");
            }
            else
            {
                return SetCommonPageHtml(zys, sumcount, currpage, url, "?page");
            }
        }
        #endregion

        #region 产品分页

        /// <summary>
        /// 产品分页拼html
        /// </summary>
        public static string ProductPageHtmlOnClick(int zys, int sumcount, int currpage, string url, string Page_Parameter_Name)
        {
            StringBuilder sb = new StringBuilder();
            //计算分页---前后各显示8条记录
            int qian = 1;  //开始的页数
            int end = zys;  //结束页数
            if (currpage > 4)
            {
                qian = currpage - 4;
            }
            if (zys > currpage + 4)
            {
                end = currpage + 4;
            }
            //sb.Append("<div class='divpage'>");
            //sb.Append("共 <strong>" + sumcount + "</strong> 条记录");
            //加载前面页数
            if (currpage > 1)
            {
                sb.AppendFormat("<a href=\"javascript:void(0)\" onclick=\"productList(1);\">首页</a> ");
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"productList({0});\" title='上一页'>上一页</a> ", (currpage - 1));
            }
            for (int g = qian; g < currpage; g++)
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"productList({0});\" title='转到第{0}页'>{0}</a> ", g);
            }
            sb.AppendFormat(" <a class=\"on\" href=\"javascript:void(0)\" title='当前页第{0}页' >{0}</a> ", currpage);

            //加载后面页数
            for (int epage = currpage + 1; epage < end + 1; epage++)
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"productList({0});\" title='转到第{0}页' >{0}</a> ", epage);
            }
            if (currpage < end)
            {
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"productList({0});\" title='下一页' >下一页</a> ", (currpage + 1));
                sb.AppendFormat(" <a href=\"javascript:void(0)\" onclick=\"productList({0});\" title='转到第{0}页'>尾页</a>", end);
            }
            //sb.Append("页次：" + currpage + "/" + zys + "</div>");
            sb.AppendFormat("<span>共 {0}条记录 {1}/{2} 页</span>", sumcount, currpage, zys);
            return sb.ToString();
        }
        /// <summary>
        /// 显示Html
        /// </summary>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <param name="currpage">当前页索引</param>
        /// <param name="url">重定向Url</param>
        public static string InitProductPageHtml(int zys, int sumcount, int currpage, string url)
        {
            if (url.IndexOf("?") != -1)
            {
                return ProductPageHtmlOnClick(zys, sumcount, currpage, url, "&page");
            }
            else
            {
                return ProductPageHtmlOnClick(zys, sumcount, currpage, url, "?page");
            }
        }
        #endregion 

        #region 产品分页

        /// <summary>
        /// 产品分页
        /// </summary>
        public static string ShowProductPageHtml(int zys, int sumcount, int currpage, string url, string Page_Parameter_Name)
        {
            StringBuilder sb = new StringBuilder();
            //计算分页---前后各显示8条记录
            int qian = 1;  //开始的页数
            int end = zys;  //结束页数
            if (currpage > 4)
            {
                qian = currpage - 4;
            }
            if (zys > currpage + 4)
            {
                end = currpage + 4;
            }

            //加载前面页数
            if (currpage > 1)
            {
                sb.Append("<a href='" + url + Page_Parameter_Name + "=1'>首页</a> ");
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + (currpage - 1) + "' title='上一页'>上一页</a> ");
            }
            for (int g = qian; g < currpage; g++)
            {
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + g.ToString() + "' title='转到第" + g.ToString() + "页'>" + g.ToString() + "</a> ");
            }

            sb.Append(" <a class=\"on\" href='" + url + Page_Parameter_Name + "=" + currpage.ToString() + "' title='当前页第" + currpage + "页' >" + currpage.ToString() + "</a> ");

            //加载后面页数
            for (int epage = currpage + 1; epage < end + 1; epage++)
            {
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + epage.ToString() + "' title='转到第" + epage + "页' >" + epage.ToString() + "</a> ");
            }
            if (currpage < end)
            {
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + (currpage + 1) + "' title='下一页' >下一页</a> ");
                sb.Append(" <a href='" + url + Page_Parameter_Name + "=" + end + "'>尾页</a>");
            }
            sb.AppendFormat("<span>共{0}页/{1}条</span>", zys, sumcount);
            return sb.ToString();
        }
        /// <summary>
        /// 产品分页显示Html
        /// </summary>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <param name="currpage">当前页索引</param>
        /// <param name="url">重定向Url</param>
        public static string ProductPageHtml(int zys, int sumcount, int currpage, string url)
        {
            if (url.IndexOf("?") != -1)
            {
                return ShowProductPageHtml(zys, sumcount, currpage, url, "&page");
            }
            else
            {
                return ShowProductPageHtml(zys, sumcount, currpage, url, "?page");
            }
        }
        #region ajax实现分页
        /// <summary>
        /// 产品分页
        /// </summary>
        /// <param name="zys">总页数</param>
        /// <param name="sumcount">总记录数</param>
        /// <param name="currpage">当前页索引</param>
        public static string ShowProductPageHtml(int zys, int sumcount, int currpage)
        {
            StringBuilder sb = new StringBuilder();
            //计算分页---前后各显示8条记录
            int qian = 1;  //开始的页数
            int end = zys;  //结束页数
            if (currpage > 4)
            {
                qian = currpage - 4;
            }
            if (zys > currpage + 4)
            {
                end = currpage + 4;
            }

            //加载前面页数
            if (currpage > 1)
            {
                sb.AppendFormat("<a href='javascript:void(0)' onclick=\"getTeacherProductList(1);\">首页</a> ");
                sb.AppendFormat(" <a href='javascript:void(0)' title='上一页' onclick=\"getTeacherProductList({0});\">上一页</a> ", (currpage - 1));
            }
            for (int g = qian; g < currpage; g++)
            {
                sb.AppendFormat(" <a href='javascript:void(0)' title='转到第{0}页' onclick=\"getTeacherProductList({0});\">{0}</a> ", g);
            }

            sb.AppendFormat(" <a class=\"on\" href='javascript:void(0)' title='当前页第{0}页'>{0}</a> ", currpage);

            //加载后面页数
            for (int epage = currpage + 1; epage < end + 1; epage++)
            {
                sb.AppendFormat(" <a href='javascript:void(0)' title='转到第{0}页' onclick=\"getTeacherProductList({0});\">{0}</a> ", epage);
            }
            if (currpage < end)
            {
                sb.AppendFormat(" <a href='javascript:void(0)' title='下一页' onclick=\"getTeacherProductList({0});\">下一页</a> ", (currpage + 1));
                sb.AppendFormat(" <a href='javascript:void(0)' onclick=\"getTeacherProductList({0});\">尾页</a>", end);
            }
            sb.AppendFormat("<span>共{0}页/{1}条</span>", zys, sumcount);
            return sb.ToString();
        }
        #endregion

        #endregion

        #endregion

        #region 设置缓存

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="cacheKey">缓存标识符</param>
        /// <returns>缓存object</returns>
        static public object GetBWJSCache(object cacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[SafeToString(cacheKey)];
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey">缓存标识符</param>
        /// <param name="cacheObject">缓存object</param>
        static public void SetBWJSCache(object cacheKey, object cacheObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(SafeToString(cacheKey), cacheObject);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="cacheKey">缓存标识符</param>
        /// <param name="cacheObject">缓存object</param>
        /// <param name="dependencies">缓存依赖项：.Net中支持两种依赖：CacheDependency和SqlDependency(两者都是Dependency的子类)。从.Net2.0开始，CacheDependency不再是密封的，而是可以继承的。CacheDependency：表示对文件或者目录的依赖；SqlDependency：表示基于SQL数据库的依赖</param>
        /// <param name="absoluteExpiration">绝对过期时间：为特定时间点，类型为DateTime，如果不使用绝对过期时间，那么，使用System.Web.Caching.Cache.NoAbsoluteExpiration表示</param>
        /// <param name="slidingExpiration">滑动过期时间：最后一次访问的时间隔为一个事件间隔，类型为TimeSpan，如果不使用滑动过期时间，使用System.Web.Cacheing.NoSlidingExpiration或者TimeSpan.Zero表示</param>
        static public void SetBWJSCache(object cacheKey, object cacheObject, CacheDependency dependencies, object absoluteExpiration, TimeSpan slidingExpiration)
        {
            //HttpContext.Current.Response.Cache.SetExpires(ComPage.SafeToDateTime(absoluteExpiration));
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Public);

            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(SafeToString(cacheKey), cacheObject, dependencies, ComPage.SafeToDateTime(absoluteExpiration), slidingExpiration);
        }

        #endregion

        #region 获取缓存依赖项
        /// <summary>
        /// 获取缓存依赖项
        /// </summary>
        /// <param name="Id">当前用户编号</param>
        /// <returns>缓存依赖项</returns>
        static public CacheDependency GetBWJSCacheDependency(object guidKey)
        {
            CacheDependency dep = new CacheDependency(null, new string[] { guidKey.ToString() });
            return dep;
        }
        #endregion

        #region 清除缓存

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        static public void ClearBWJSCache()
        {
            try
            {
                List<string> keys = new List<string>();
                IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    keys.Add(enumerator.Key.ToString());

                }
                for (int i = 0; i < keys.Count; i++)
                {
                    HttpRuntime.Cache.Remove(keys[i]);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("Com.AppCode.ComPage.ClearCache error：" + ex.Message);
            }
        }
        /// <summary>
        /// 清除指定缓存
        /// </summary>
        /// <param name="list">缓存标识符集合</param>
        static public void ClearBWJSCache(ArrayList list)
        {
            try
            {
                if (list.Count > 0)
                {
                    foreach (string cacheKey in list)
                    {
                        HttpRuntime.Cache.Remove(cacheKey);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("Com.AppCode.ComPage.ClearCache error：" + ex.Message);
            }
        }
        #endregion

        #region 清除缓存2
        /*
         * 本以为ObjectDataSource等数据源的缓存也是保存在HttpRuntime.Cache中，经过测试没想到竟然不是，因为执行上面的代码以后ObjectDataSource仍然是从缓存读取数据。
         * 使用Reflector反编译发现ObjectDataSource是使用HttpRuntime.CacheInternal来实现的缓存，气氛呀，为什么微软总爱搞“特殊化”，对外提供一个Cache用，自己偷偷用CacheInternal做缓存。
         * CacheInternal是 internal的，因此没法直接写代码调用，同时CacheInternal中也没提供清空缓存的方法，只能通过实验发现 _caches._entries是保存缓存的Hashtable，
         * 因此就用反射的方法调用CacheInternal，然后拿到 _caches._entries，最后clear才算ok。         * 
         * HttpRuntime下的CacheInternal属性（Internal的，内存中是CacheMulti类型）是ObjectDataSource等DataSource保存缓存的管理器
         * 因为CacheInternal、_caches、_entries等都是internal或者private的，所以只能通过反射调用，而且可能会随着.Net升级而失效
         * 此方法由于是通过crack的方法进行调用，可能有潜在的问题，因此仅供参考。
         */

        #region 调用
        private void Get()
        {
            object cacheIntern = GetPropertyValue(typeof(HttpRuntime), "CacheInternal") as IEnumerable;
            //_caches是CacheMulti中保存多CacheSingle的一个IEnumerable字段。
            IEnumerable _caches = GetFieldValue(cacheIntern, "_caches") as IEnumerable;
            foreach (object cacheSingle in _caches)
            {
                ClearCacheInternal(cacheSingle);
            }
        }
        #endregion

        #region 清除缓存2

        private static void ClearCacheInternal(object cacheSingle)
        {
            //_entries是cacheSingle中保存缓存数据的一个private Hashtable
            Hashtable _entries = GetFieldValue(cacheSingle, "_entries") as Hashtable;
            _entries.Clear();
        }

        /// <summary>
        /// 得到type类型的静态属性propertyName的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetPropertyValue(Type type, string propertyName)
        {
            foreach (PropertyInfo rInfo in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance))
            {
                if (rInfo.Name == propertyName)
                {
                    return rInfo.GetValue(null, new object[0]);
                }
            }
            throw new Exception("无法找到属性：" + propertyName);
        }

        /// <summary>
        /// 得到object对象的propertyName属性的值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            Type type = obj.GetType();
            foreach (PropertyInfo rInfo in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance))
            {
                if (rInfo.Name == propertyName)
                {
                    return rInfo.GetValue(obj, new object[0]);
                }
            }
            throw new Exception("无法找到属性：" + propertyName);
        }

        public static object GetFieldValue(object obj, string fieldName)
        {
            Type type = obj.GetType();
            foreach (FieldInfo rInfo in type.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance))
            {
                if (rInfo.Name == fieldName)
                {
                    return rInfo.GetValue(obj);
                }
            }
            throw new Exception("无法找到字段：" + fieldName);
        }
        #endregion

        #endregion

        #region 清除缓存3

        #endregion

        #region 前端分页
        /// <summary>
        /// 前端分页
        /// </summary>
        public static string SetPageHtml(int zys, int sumcount, int currpage, string functionName)
        {
            StringBuilder sb = new StringBuilder();
            //if (zys > 1)
            //{
            sb.Append("<div class=\"page\">");
            sb.AppendFormat("<span onclick=\"{0}(1);\" title='首页' style=\"cursor: pointer\">首 页</span>", functionName);
            if (currpage > 1)
            {
                sb.AppendFormat("<span onclick=\"{1}({0});\" title='转到第{0}页' style=\"cursor: pointer\">上一页</span>", (currpage - 1), functionName);
            }
            if (currpage < zys)
            {
                sb.AppendFormat("<span onclick=\"{1}({0});\" title='转到第{0}页' style=\"cursor: pointer\">下一页</span>", (currpage + 1), functionName);
            }
            sb.AppendFormat(" <span onclick=\"{1}({0});\" title='转到第{0}页' style=\"cursor: pointer;border: 0px;\">尾页</span>", zys, functionName);
            sb.Append("</div>");
            //}
            return sb.ToString();
        }

        #endregion 
    }
}