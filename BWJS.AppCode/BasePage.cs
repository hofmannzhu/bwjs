using UtilityHelper;
using BWJS.Model;
using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using BWJS.Model.Model;
using BWJS.BLL;

namespace BWJS.AppCode
{
    /// <summary>
    /// PC前端页面继承类
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        #region 是否测试

        bool istest = false;
        #endregion

        #region 其他变量
        /// <summary>
        /// 设备编号
        /// </summary>
        static public string equipmentNo = string.Empty;
        /// <summary>
        /// 商户编号
        /// </summary>
        static public string merchantsNo = string.Empty;

        Users currentuser = null;
        /// <summary>
        /// 签名参数实例
        /// </summary>
        static public NewSSKDCookie sskdModel = null;
        /// <summary>
        /// 时间戳
        /// </summary>
        static public long timeUnix = DNTRequest.GetCurrentTimeUnix;

        /// <summary>
        /// 接口请求参数
        /// </summary>
        static public SSKDRequestParas sskdRequestParas = null;

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造函数，初始化PageBase类的新实例。
        /// </summary>
        public BasePage()
        {
            currentuser = ComPage.CurrentUser;
            if (currentuser != null)
            {
                sskdRequestParas = new SSKDRequestParas();
                sskdRequestParas.PageLoadDateTime = DateTime.Now;

                equipmentNo = currentuser.EquipmentNo;
                merchantsNo = currentuser.UserID.ToString();
                GetOtherParas();
                string lastloginip = currentuser.LastAccessIP;
                string currentloginip = HttpContext.Current.Request.UserHostAddress;
                if (lastloginip != currentloginip)//currentuser.IsLogined == 1 && 
                {
                    SendMessage.Alert(this, "退出登录，用户在其他设备登录", "/Product/NewSSKD/SignIn.aspx");
                }
            }
            else
            {
                if (!istest)
                {
                    string PermissionUrl = GetPageUrl;
                    if (!NotIncluded(HttpContext.Current.Request.Url.AbsolutePath.ToString().ToLower()))
                    {
                        string loginurl = "/Product/NewSSKD/SignIn.aspx?posturl=" + Server.UrlEncode(PermissionUrl);
                        //HttpContext.Current.Response.Redirect(loginurl);
                        SendMessage.Alert(this, "登录超时，请重新登录。", loginurl);
                    }
                }
            }
            //this.Load += new EventHandler(PageBase_Load);
        }

        /// <summary>
        /// 加载页面时进行的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageBase_Load(object sender, EventArgs e)
        {
            checkLogin();
        }
        #endregion

        #region 其他变量取值
        /// <summary>
        /// 获取各签名数据项
        /// </summary>
        static public void GetOtherParas()
        {
            HttpCookie sskdCookie = HttpContext.Current.Request.Cookies["NewSSKDCookie"];
            if (sskdCookie != null)
            {
                string cookievalue = HttpUtility.UrlDecode(sskdCookie.Value, Encoding.GetEncoding("UTF-8"));
                sskdModel = Newtonsoft.Json.JsonConvert.DeserializeObject<NewSSKDCookie>(cookievalue) as NewSSKDCookie;
            }
        }
        /// <summary>
        /// 签名参数写入Cookie
        /// </summary>
        protected void SSKDHelperPage_Load(NewSSKDCookie postModel)
        {
            sskdModel = new NewSSKDCookie()
            {
                IDCardNo = postModel.IDCardNo,
                Mobile = postModel.Mobile,
                OrderNo = postModel.OrderNo,
                ConsultId = postModel.ConsultId,
                MachineId = equipmentNo,
                MerchantId = currentuser.UserID.ToString(),
                Token = postModel.Token,
                FullName = postModel.FullName,
                Sex = postModel.Sex,
                Birth = postModel.Birth,
                National = postModel.National,
                Address = postModel.Address,
                Authority = postModel.Authority,
                Validperiod = postModel.Validperiod,
                TimeStamp = postModel.TimeStamp
            };
            Utils.DelCoookie("NewSSKDCookie");
            HttpCookie SSKDCookie = new HttpCookie("NewSSKDCookie");
            SSKDCookie.Value = HttpUtility.UrlEncode(Newtonsoft.Json.JsonConvert.SerializeObject(sskdModel), Encoding.GetEncoding("UTF-8"));
            SSKDCookie.Expires = DateTime.Now.AddHours(8);
            HttpContext.Current.Response.Cookies.Add(SSKDCookie);
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        public string GetSign
        {
            get
            {
                string resutlt = string.Empty;
                try
                {
                    if (sskdModel != null)
                    {
                        //商户号+设备号+身份证号+手机号+时间戳，连接符为-
                        string str = sskdModel.MerchantId + "-" + sskdModel.MachineId + "-" + sskdModel.IDCardNo + "-" + sskdModel.Mobile + "-" + sskdModel.TimeStamp;
                        resutlt = UtilityHelper.CommonHelper.MD5(str, false);
                    }
                    else
                    {
                        resutlt = "error";
                    }

                }
                catch (Exception ex)
                {
                    resutlt = "error，" + ex.Message;
                }
                return resutlt;
            }
        }

        #endregion

        #region 错误日志
        /// <summary>
        /// 引发 <see cref="E:System.Web.UI.TemplateControl.Error"></see> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs"></see>。</param>
        protected override void OnError(EventArgs e)
        {
            Exception ex = this.Context.Server.GetLastError();
            Log.WriteLog("异常原因：" + ex.Message);
            //Response.Redirect("/Error.aspx", true);
        }
        #endregion

        #region 登录验证

        /// <summary>
        /// 是否登录
        /// </summary>
        public void checkLogin()
        {
            if (!istest)
            {
                string PermissionUrl = GetPageUrl;
                if (!NotIncluded(HttpContext.Current.Request.Url.AbsolutePath.ToString().ToLower()))
                {
                    if (ComPage.CurrentUser == null)
                    {
                        HttpContext.Current.Response.Redirect("/signin.aspx?posturl=" + Server.UrlEncode(PermissionUrl));
                    }
                }
            }
        }

        /// <summary>
        /// 不包括登录验证的页面
        /// </summary>
        public bool NotIncluded(string currentpage)
        {
            bool res = false;
            try
            {
                ArrayList arr = new ArrayList();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Current.Server.MapPath("/xml/NotIncluded.xml"));
                XmlNodeList nodeList = xmlDoc.SelectNodes("/NotIncluded/list");
                foreach (XmlNode modelObj in nodeList)
                {
                    XmlElement model = (XmlElement)modelObj;
                    arr.Add(model.GetAttribute("url").ToLower());
                }

                if (arr.Contains(currentpage))
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog("Com.AppCode.NotIncluded error：" + ex.Message);
            }
            return res;
        }

        #endregion

        #region sql防流防过滤关键字
        /// <summary>
        /// sql防流防过滤关键字 
        /// </summary>
        /// <param name="sWord"></param>
        /// <returns></returns>
        static public bool CheckKeyWord(string sWord)
        {
            //过滤关键字
            string StrKeyWord = @"select|insert|delete|from|count\(|drop table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec master|netlocalgroup administrators|:|net user|""|or|and|administrators|admin";

            //过滤关键字符
            string StrRegex = @"[|;|,|/|\(|\)|\[|\]|}|{|%|\@|*|!|']";
            if (System.Text.RegularExpressions.Regex.IsMatch(sWord, StrKeyWord, System.Text.RegularExpressions.RegexOptions.IgnoreCase) || System.Text.RegularExpressions.Regex.IsMatch(sWord, StrRegex))
                return true;
            return false;
        }

        /// <summary>
        /// 检查指定的数据是否是安全的
        /// </summary>
        /// <param name="strName">参数数据</param>
        /// <param name="sqlSafeCheck">是否进行安全检查</param>
        /// <returns>安全数据</returns>
        static public string GetSafeString(string strName, bool sqlSafeCheck)
        {
            if (sqlSafeCheck && CheckKeyWord(strName))
                return "unsafe";

            return strName;
        }

        /// <summary>
        /// 获得指定Url参数的值
        /// </summary> 
        /// <param name="strName">Url参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>Url参数的值</returns>
        static public string GetQueryString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
                return string.Empty;

            if (sqlSafeCheck && !CheckKeyWord(HttpContext.Current.Request.QueryString[strName]))
                return "unsafe";

            return HttpContext.Current.Request.QueryString[strName];
        }

        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <param name="sqlSafeCheck">是否进行SQL安全检查</param>
        /// <returns>表单参数的值</returns>
        static public string GetFormString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
                return string.Empty;

            if (sqlSafeCheck && !CheckKeyWord(HttpContext.Current.Request.Form[strName]))
                return "unsafe";

            return HttpContext.Current.Request.Form[strName];
        }

        #endregion

        #region 获得页面地址

        /// <summary>
        /// 获得页面地址
        /// </summary>
        public string GetPageUrl
        {
            get
            {
                string strTemp = "";
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTPS"] == "off")
                {
                    strTemp = "http://";
                }
                else
                {
                    strTemp = "https://";
                }
                if (strTemp == "https://")
                {
                    strTemp = "http://";
                }
                strTemp = strTemp + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"];

                if (System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"] != "80")
                {
                    strTemp = strTemp + ":" + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                }

                strTemp = strTemp + System.Web.HttpContext.Current.Request.ServerVariables["URL"];

                if (System.Web.HttpContext.Current.Request.QueryString.AllKeys.Length > 0)
                {
                    strTemp = strTemp + "?" + System.Web.HttpContext.Current.Request.QueryString;
                }

                return strTemp;
            }
        }
        #endregion


        /// <summary>
        /// 获取分页SQL语句，排序字段需要构成唯一记录
        /// </summary>
        /// <param name="_recordCount">记录总数</param>
        /// <param name="_pageSize">每页记录数</param>
        /// <param name="_pageIndex">当前页数</param>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <param name="_orderField">排序字段，多个则用“,”隔开</param>
        /// <returns>分页SQL语句</returns>
        static public string CreatePagingSql(int _recordCount, int _pageSize, int _pageIndex, string _safeSql, string _orderField)
        {
            //重新组合排序字段，防止有错误
            string[] arrStrOrders = _orderField.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sbOriginalOrder = new StringBuilder(); //原排序字段
            StringBuilder sbReverseOrder = new StringBuilder(); //与原排序字段相反，用于分页
            for (int i = 0; i < arrStrOrders.Length; i++)
            {
                arrStrOrders[i] = arrStrOrders[i].Trim();  //去除前后空格
                if (i != 0)
                {
                    sbOriginalOrder.Append(", ");
                    sbReverseOrder.Append(", ");
                }
                sbOriginalOrder.Append(arrStrOrders[i]);

                int index = arrStrOrders[i].IndexOf(" "); //判断是否有升降标识
                if (index > 0)
                {
                    //替换升降标识，分页所需
                    bool flag = arrStrOrders[i].IndexOf(" DESC", StringComparison.OrdinalIgnoreCase) != -1;
                    sbReverseOrder.AppendFormat("{0} {1}", arrStrOrders[i].Remove(index), flag ? "ASC" : "DESC");
                }
                else
                {
                    sbReverseOrder.AppendFormat("{0} DESC", arrStrOrders[i]);
                }
            }

            //计算总页数
            _pageSize = _pageSize == 0 ? _recordCount : _pageSize;
            int pageCount = (_recordCount + _pageSize - 1) / _pageSize;

            //检查当前页数
            if (_pageIndex < 1)
            {
                _pageIndex = 1;
            }
            else if (_pageIndex > pageCount)
            {
                _pageIndex = pageCount;
            }

            StringBuilder sbSql = new StringBuilder();
            //第一页时，直接使用TOP n，而不进行分页查询
            if (_pageIndex == 1)
            {
                sbSql.AppendFormat(" SELECT TOP {0} * ", _pageSize);
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
            }
            //最后一页时，减少一个TOP
            else if (_pageIndex == pageCount)
            {
                sbSql.Append(" SELECT * FROM ");
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * ", _recordCount - _pageSize * (_pageIndex - 1));
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                sbSql.AppendFormat(" ORDER BY {0} ", sbReverseOrder.ToString());
                sbSql.Append(" ) AS T ");
                sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
            }
            //前半页数时的分页
            else if (_pageIndex <= (pageCount / 2 + pageCount % 2) + 1)
            {
                sbSql.Append(" SELECT * FROM ");
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * FROM ", _pageSize);
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * ", _pageSize * _pageIndex);
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
                sbSql.Append(" ) AS T ");
                sbSql.AppendFormat(" ORDER BY {0} ", sbReverseOrder.ToString());
                sbSql.Append(" ) AS T ");
                sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
            }
            //后半页数时的分页
            else
            {
                sbSql.AppendFormat(" SELECT TOP {0} * FROM ", _pageSize);
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * ", ((_recordCount % _pageSize) + _pageSize * (pageCount - _pageIndex) + 1));
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                sbSql.AppendFormat(" ORDER BY {0} ", sbReverseOrder.ToString());
                sbSql.Append(" ) AS T ");
                sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
            }
            return sbSql.ToString();
        }

        /// <summary>
        /// 获取记录总数SQL语句
        /// </summary>
        /// <param name="_n">限定记录数</param>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <returns>记录总数SQL语句</returns>
        static public string CreateTopnSql(int _n, string _safeSql)
        {
            return string.Format(" SELECT TOP {0} * FROM ({1}) AS T ", _n, _safeSql);
        }

        /// <summary>
        /// 获取记录总数SQL语句
        /// </summary>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <returns>记录总数SQL语句</returns>
        static public string CreateCountingSql(string _safeSql)
        {
            return string.Format(" SELECT COUNT(1) AS RecordCount FROM ({0}) AS T ", _safeSql);
        }

    }
}