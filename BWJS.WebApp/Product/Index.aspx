<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BWJS.WebApp.Product.Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport">
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/css/Mofang/main.css" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/layer.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <script type="text/javascript">        //window.location.reload(); 
        $(document).ready(function () {
            window.onload = function () {
                setInterval(function () {
                    $.ajax({
                        type: "GET",
                        async: false,
                        dataType: "text",
                        url: "/Ajax/BWJS/HPageRefresh.ashx?r=" + Math.random(),
                        success: function (data) {
                            if (data == "OnLine") {
                                window.location.reload();
                            }
                        }
                    });
                }, parseInt('<%=ProductIndexRefreshTime%>'));
            };
        });
    </script>
    <title></title>
</head>
<body>
    <div class="main1">
        <div class="zc-box">
        
            <div class="yhbox">
                <b>X</b>
                <iframe id="fra" frameborder="0" src="" height="100%" width="100%"></iframe>
            </div>
            <div class="cp-menu-box">
                <ul>
                    <%if (oCategoryList != null) %>
                    <%{ %>
                    <%for (int i = 0; i < oCategoryList.Count; i++) %>
                    <%{ %>
                    <div class="pcName" provalu="<%=oCategoryList[i].ProductCategoryId%>">
                        <li class="btn-cp ma3 wid"><span class="le">
                            <img src="<%=oCategoryList[i].ProductCaPictureUrl%>" /></span><span class="ri fon"><%=oCategoryList[i].CategoryName %></span>
                        </li>
                    </div>
                    <%} %>
                    <%}%>
                </ul>

                <!--网贷START-->

                <ul class="hid" id="ulNetLoan">

                    <%if (litCompanyNetLoan != null) %>
                    <%{ %>
                    <%for (int i = 0; i < litCompanyNetLoan.Count; i++) %>
                    <%{ %>
                    <li class="btn-cp wd ma1 wid" companyid="<%=litCompanyNetLoan[i].CompanyId%>"
                        <% if (litCompanyNetLoan[i].Status == 0)
                        { %>
                        onclick="netLoanClick(this);"
                        <%} %>>
                        <% if (litCompanyNetLoan[i].Status == 1)
                            { %>
                        <span class="mask"></span>
                        <%} %>
                        <span class="le1">
                            <img src="<%=litCompanyNetLoan[i].Logo%>" onerror="this.src='/Content/img/NetLoan/default.jpg'" />
                        </span>
                        <div class="con1">

                            <%--     <%=litCompanyNetLoan[i].CompanyName%></h5>
                            <%=litCompanyNetLoan[i].MainBusiness%>--%>
                            <%if (!string.IsNullOrEmpty(litCompanyNetLoan[i].DescriptionHtml)) %>
                            <%{ %>
                            <%=litCompanyNetLoan[i].DescriptionHtml%>
                            <%} %>
                            <%--      <%if (litCompanyNetLoan[i].CompanyNetLoan != null) %>
                            <%{ %>
                                  
                                    <%else %>
                                    <%{ %>
                                    <div class="ys">
                                        <ol style="font-size: 12px">
                                            <li>最高可贷<%=((litCompanyNetLoan[i].CompanyNetLoan != null) ? (litCompanyNetLoan[i].CompanyNetLoan.HighestLoan.ToString("0.00")) : (string.Empty))%>万</li>
                                            <li><%=((litCompanyNetLoan[i].CompanyNetLoan != null) ? ((litCompanyNetLoan[i].CompanyNetLoan.IsHaveGuarantee.ToString() == "0") ? ("无") : ("有")) : (string.Empty))%>担保<br />
                                                <%=((litCompanyNetLoan[i].CompanyNetLoan != null) ? ((litCompanyNetLoan[i].CompanyNetLoan.IsMortgage.ToString() == "0") ? ("无") : ("有")) : (string.Empty))%>抵押</li>
                                            <li>月息不超过<%=((litCompanyNetLoan[i].CompanyNetLoan != null) ? (litCompanyNetLoan[i].CompanyNetLoan.MaxMonthlyInterest.ToString()) : (string.Empty))%>%</li>
                                            <li class="norb">最快<%=((litCompanyNetLoan[i].CompanyNetLoan != null) ? (litCompanyNetLoan[i].CompanyNetLoan.LoanPrescription.ToString()) : (string.Empty))%>小时内放款</li>
                                        </ol>
                                    </div>
                                    <%} %>
                            <%} %>--%>
                        </div>
                        <span class="ri wd  fon1">申请贷款</span>
                    </li>

                    <%} %>
                    <%}%>
                    <li></li>
                    <div class="page"><span class="pactive">首 页</span><span>上一页</span><span style="border: 0px">下一页</span></div>
                </ul>
                <!--网贷END-->
                <!--银行START-->
                <ul class="yh hid">
                    <li class="btn-cp ma2 wid">
                        <i>http://www.icbc.com.cn/icbc/</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh1.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                    <li class="btn-cp ma2 wid">
                        <i>http://www.abchina.com/cn/</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh5.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                    <li class="btn-cp ma2 wid">
                        <i>http://www.bankofbeijing.com.cn/</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh6.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                    <li class="btn-cp ma2 wid">
                        <i>http://www.bankcomm.com/BankCommSite/shtml/jyjr/cn/7158/list.shtml?channelId=7158</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh7.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                    <li class="btn-cp ma2 wid">
                        <i>http://www.bosc.cn/</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh8.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                    <li class="btn-cp ma2 wid">
                        <i>http://www.adbc.com.cn/</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh9.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                    <li class="btn-cp ma2 wid">
                        <i>http://www.ccb.com/cn/home/indexv3.html</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh3.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                    <li class="btn-cp ma2 wid">
                        <i>http://www.citicbank.com/</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh10.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                    <li class="btn-cp ma2 wid">
                        <i>http://www.bank-of-tianjin.com.cn/</i>
                        <span class="le">
                            <img src="../Content/img/Mofang/yh2.jpg" /></span><span class="ri fon1">项目对接中</span>
                    </li>
                </ul>
                <!--银行END-->
                <!--信用卡START-->
                <ul class="hid" id="ulCreditCard">
                    <%if (litCompanyBank != null) %>
                    <%{ %>
                    <%for (int i = 0; i < litCompanyBank.Count; i++) %>
                    <%{ %>
                    <li class="btn-cp wd ma1 wid" companyid="<%=litCompanyBank[i].CompanyId%>" onclick="creditCardClick(this);">
                        <span class="le1">
                            <img src="<%=litCompanyBank[i].Logo%>" onerror="this.src='/Content/img/Mofang/logo-xyk1.jpg'" />
                        </span>
                        <%if (!string.IsNullOrEmpty(litCompanyBank[i].DescriptionHtml)) %>
                        <%{ %>
                        <%=litCompanyBank[i].DescriptionHtml %>
                        <%} %>
                        <%--   <%=((litCompanyBank[i].CompanyNetLoan!=null)?(litCompanyBank[i].CompanyNetLoan.DescriptionHtml):(string.Empty))%>--%>
                        <%--<div class="con2">
                                <%=litCompanyNetLoan[i].MainBusiness%><br />
                                <div class="ys">
                                    <ol>
                                        <li>三秒核发</li>
                                        <li>首刷好礼</li>
                                        <li>礼宾服务</li>
                                        <li class="norb">免首年年费</li>
                                    </ol>
                                </div>
                            </div>--%>
                        <span class="ri  fon1">申 请</span>
                    </li>

                    <%--<li class="btn-cp wd ma1 wid">
                        <span class="le1">
                            <img src="../Content/img/Mofang/logo-xyk1.jpg" />
                        </span>
                        <div class="con2">
                            标准卡，高端卡，吃喝玩乐，购物达人，出行优选，女神专享<br />
                            <div class="ys">
                                <ol>
                                    <li>三秒核发</li>
                                    <li>首刷好礼</li>
                                    <li>礼宾服务</li>
                                    <li class="norb">免首年年费</li>
                                </ol>
                            </div>
                        </div>
                        <span class="ri  fon1">申 请</span>
                    </li>--%>

                    <%} %>
                    <%}%>
                </ul>
                <!--信用卡END-->

                <ul class="hid">
                    <%if (litCompanyOther != null) %>
                    <%{ %>
                    <%for (int i = 0; i < litCompanyOther.Count; i++) %>
                    <%{ %>
                    <li class="btn-cp wd ma1 wid" companyid="<%=litCompanyOther[i].CompanyId%>" onclick="creditCardClick(this);">
                        <span class="le1">
                            <img src="<%=litCompanyOther[i].Logo%>" onerror="this.src='/Content/img/Mofang/logo-xyk1.jpg'" />
                        </span>
                        <%if (!string.IsNullOrEmpty(litCompanyOther[i].DescriptionHtml)) %>
                        <%{ %>
                        <%=litCompanyOther[i].DescriptionHtml %>
                        <%} %>
                        <span class="ri  fon1">申 请</span>
                    </li>
                    <%} %>
                    <%}%>
                    <%--        <li class="btn-cp wd ma1 wid">
                        <span class="mask"></span>
                        <span class="le1">
                            <img src="../Content/img/Mofang/mr.jpg" />
                        </span>

                        <span class="ri  fon1">项目对接中</span>
                    </li>--%>
                </ul>
            </div>

        </div>
        <p class="syz"></p>
        <div class="footer">
            <span class="logo"></span>
            <div class="adm-box">商家管理员：<%=magName %></div>
        </div>

        <form id="formId" name="formName" action="ProductList" method="post">
            <input type="hidden" id="hdCategoryId" name="CategoryId" value="" />
        </form>
        <form id="formCompany" name="formCompany" action="/Product/NetLoanApply" method="post">
            <input type="hidden" id="hiddNetPayCategoryId" name="hiddNetPayCategoryId" value="2" />
            <input type="hidden" id="hiddNetPayPageIndex" name="hiddNetPayPageIndex" value="1" />
            <input type="hidden" id="hiddCompanyId" name="hiddCompanyId" value="0" />
        </form>
    </div>
</body>
</html>
<script src="/Scripts/jquery.query-2.1.7.js" type="text/javascript"></script>
<script src="/Scripts/Product/heartbeatcheck.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
      
        //张建永：银行产品的点击在IFRAME中显示不同的银行网站
        $(".cp-menu-box ul.yh li").each(function () {
            $(this).click(function () {
                var sr = $(this).children("i").text();
                $("#fra").attr("src", sr)
                $(".cp-menu-box ul.yh").fadeOut();
                $(".yhbox").fadeIn();
                $(".cp-menu-box").hide();
                $(".zc-box").addClass("hei");
            });
            //张建永：关闭IFRAME银行产品
            $(".yhbox b").click(function () {
                $(".yhbox").hide();
                $(".cp-menu-box").show();
                $(".cp-menu-box ul.yh").show();
                $(".zc-box").removeClass("hei");
            })

        })
        //张建永：遮罩产品层的显示和隐藏
        $(".cp-menu-box ul li").each(function () {
            $(this).click(function () {
                $(this).children(".mask").fadeIn().parents("li").siblings("li").children(".mask").fadeOut();
                $(this).children(".mask").text("项目对接中")
            })
        })
        $(".pcName").click(function () {
            $("#hdCategoryId").val($(this).attr("proValu"));
            layer.msg('努力加载中.....', { icon: 6, time: 120000 });
            $("#formId").submit();
        });
        var htmlBackGroud = "<span class='mask'>项目对接中</span>";
        $(".pcName").each(function (index, val) {
            var valu = $(this).attr("provalu");
            switch (valu) {

                case "4":
                    $(this).children("li").css("cursor", "default");
                    $(this).children().append(htmlBackGroud);
                    $(this).find('.le').click(function () {
                        $(this).children(".mask").show();
                        $(this).parents().siblings().children("li").children(".mask").hide();
                    });
                    $(this).unbind("click");
                    break;
                case "6":
                    $(this).children("li").css("cursor", "default");
                    $(this).children().append(htmlBackGroud);
                    $(this).find('.le').click(function () {
                        $(this).children(".mask").show();
                        $(this).parents().siblings().children("li").children(".mask").hide();
                    });
                    $(this).unbind("click");
                    break;
                case "3":
                    $(this).children("li").css("cursor", "default");
                    $(this).children().append(htmlBackGroud);
                    $(this).find('.le').click(function () {
                        $(this).children(".mask").show();
                        $(this).parents().siblings().children("li").children(".mask").hide();
                    });
                    $(this).unbind("click");
                    break;
            }
        });
        //张建永：背景图片的定时显示
        setInterval(showBgn, <%=BackgroundRefreshTime%>);
        function showBgn() {
            var ImageNum =  <%=ImageNum%>
            $("body").css({
                "background": "url('../Content/img/Mofang/body-bg" + ImageNum + ".jpg')",
                "background-size": "100% 100%"
            })
        }
        if($.query.get("nppi")!=null&&$.query.get("nppi")!="")
        {
            $("#hiddNetPayPageIndex").val($.query.get("nppi"));
        }
        GetNetPayList($("#hiddNetPayPageIndex").val());
    });

    function BackstagePage() {
        location.href = "../Admin/default.aspx";
    }
    var wdIndex = $.query.get("wd");
    $("p.syz").text(wdIndex);
    if (wdIndex != null && wdIndex != "") {
        $('.leftmenu li').eq(wdIndex).addClass('active2').siblings("li").removeClass("active2")
        $('.cp-menu-box ul').eq(wdIndex).show().siblings('.cp-menu-box ul').hide();
        $(".cp-menu-box").show(); 
    }
    //左侧边栏按钮点击效果


    $(".page span").each(function(){
        $(this).click(function(){
            $(this).addClass("pactive").siblings("span").removeClass("pactive");
        })

    })

  

   
    $(".leftmenu li").each(function () {
        $(this).click(function () {
            $(this).addClass('active2').siblings("li").removeClass("active2")
            var num = $(".leftmenu li").index(this);
            $('.cp-menu-box ul').eq(num).show().siblings('.cp-menu-box ul').hide();
            $(".cp-menu-box").show();
            $(".yhbox").hide();
            $(".zc-box").removeClass("hei");

            $("p.syz").text(num);
            $('.leftmenu li').eq(num).addClass('active2').siblings("li").removeClass("active2");

      
            //var index=layer.msg('努力加载中.....', { icon: 6});
            windows.location.href = "/Product/Index.aspx?wd="+num;
            //layer.close(index);
        });
    })

    //首页按钮点击跳转到当前页的显示
    var test = window.location.href;
    var num=test.charAt(test.length - 1)
    $(".leftmenu li").eq(num).addClass('active2')

    $('.cp-menu-box ul').eq(num).show().siblings('.cp-menu-box ul').hide();


    //网贷点击事件
    function netLoanClick(obj) {
        try {
          
            var sy=$("p.syz").text();
            var companyId = $(obj).attr("companyid");
            $("#hiddCompanyId").val(companyId);
            layer.msg('努力加载中.....', { icon: 6, time: 120000 });
            if(companyId==3)
            {
                $("#formCompany").attr("action", "/Product/SSKDApply?wd="+sy);
            }else
            {
                $("#formCompany").attr("action", "/Product/NetLoanApply?wd="+sy);
            }
            $("#formCompany").submit();
         
        } catch (e) { alert(e.message); }
    }
    //信用卡点击事件
    function creditCardClick(obj) {
        var sy=$("p.syz").text();
        var companyId = $(obj).attr("companyid");
        $("#hiddCompanyId").val(companyId);
        layer.msg('努力加载中.....', { icon: 6, time: 120000 });
        $("#formCompany").attr("action", "/Product/NetLoanApply?wd="+sy);
        $("#formCompany").submit();
    }
    //获取网贷列表
    function GetNetPayList(pageIndex) {
        var listHtml = "";
        var pageHtml = "";
        var json = GetCompanyList($("#hiddNetPayCategoryId").val(), pageIndex,"GetNetPayList");
        if (json.result) {
            if (json.data.list != null && json.data.list != "") {
                $("#hiddNetPayPageIndex").val(json.data.pageIndex);
                $.each(json.data.list, function (key, value) {	
                    listHtml+="<li class=\"btn-cp wd ma1 wid\" companyid=\""+value.CompanyId+"\"";
                    if (value.Status == 0)
                    {
                        listHtml+=" onclick=\"netLoanClick(this);\"";
                    }
                    listHtml+=">";
                    if (value.Status == 1)
                    {

                        listHtml+="<span class=\"mask\"></span>";
                    }
                    listHtml+="<span class=\"le1\">";
                    listHtml+="<img src=\""+value.Logo+"\" onerror=\"this.src='/Content/img/NetLoan/default.jpg'\" />";
                    listHtml+="</span>";
                    listHtml+="<div class=\"con1\">";
                    if(value.DescriptionHtml!=null&&value.DescriptionHtml!="")
                    {
                        listHtml+= value.DescriptionHtml;
                    }
                    listHtml+="</div>";
                    listHtml+="<span class=\"ri wd fon1\">申请贷款</span>";
                    listHtml+="</li>";
                });
            }
            else{
                listHtml="<li暂无数据</li>";
            }
            pageHtml = json.data.pageHtml;

        }
        $("#ulNetLoan").html(pageHtml + listHtml);
    }
    //
    function GetCompanyList(companyCategoryId, pageIndex, functionName) {
        var paramter = {};
        paramter.op = "bwjs";
        paramter.om = "netloan";
        paramter.action = "companylist";
        paramter.companyCategoryId = companyCategoryId;
        paramter.pageIndex = pageIndex;
        paramter.pageSize = 9;
        paramter.functionName = functionName;
        var json = getJson(paramter, false);
        return json;
    }
</script>
