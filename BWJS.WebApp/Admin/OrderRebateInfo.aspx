<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderRebateInfo.aspx.cs" Inherits="BWJS.WebApp.Admin.OrderRebateInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script src="../Scripts/jquery.min.js"></script>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <style>
                body {
                    background-color: #EEE;
                }

                .tabsDiv {
                    width: 100%;
                    height: 100%;
                    margin: 0px auto;
                    border: 1px solid #dddddd;
                    background-color: white;
                }

                    .tabsDiv ul {
                        width: 100%;
                        height: 30px;
                        list-style: none;
                        margin: 0px;
                        padding: 0px;
                    }

                    .tabsDiv li {
                        width: 33.3%;
                        height: 30px;
                        line-height: 30px;
                    }

                    .tabsDiv div {
                        text-align: center;
                        margin: 50px auto;
                    }

                .tabsSeletedLi {
                    background-color: white;
                    float: left;
                    text-align: center;
                }

                    .tabsSeletedLi a {
                        color: black;
                        text-decoration: none;
                        font-weight: bold;
                    }

                        .tabsSeletedLi a:hover {
                            color: grey;
                        }

                .tabsUnSeletedLi {
                    background-color: rgb(238, 238, 238);
                    float: left;
                    text-align: center;
                }

                    .tabsUnSeletedLi a {
                        color: rgb(95, 154, 231);
                        text-decoration: none;
                        font-weight: bold;
                    }

                        .tabsUnSeletedLi a:hover {
                            color: grey;
                        }
            </style>
            <div id="mytabs">
                <ul>
                    <li><a href="#OrderRebatetabs">订单信息</a></li>
                    <li><a href="#ApplicantInfotabs">投保人信息</a></li>
                    <li><a href="#InsurantInfotabs">被保人信息</a></li>
                </ul>
                <div id="OrderRebatetabs"></div>
                <div id="ApplicantInfotabs"></div>
                <div id="InsurantInfotabs"></div>
            </div>
        </div>
    </form>
</body>
</html>
<script>
    $(function () {
        $("#mytabs").tabs();

        GetOrderRebatetabs();
        GetApplicantInfotabs();
        GetInsurantInfotabs();
    });

    function GetInsurantInfotabs() {
        $.ajax({
            type: "GET",
            async: false,
            dataType: "json",
            url: "../Ajax/MofangOrder/HInsurantInfo.ashx?OrderApplyID=" +<%=OrderApplyId%> +"&r=" + Math.random(),
            data: { Action: "GetInsurantInfotabs" },
            success: function (data) {
                var stringData = "";
                for (var ds in data) {
                    stringData += "<table style=\"width:100%\">";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">承保单号：</td><td   style=\"width:70%;text-align:left \">" + (<%=InsureNum%>==null?"": <%=InsureNum%>) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">被投保人姓名：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CName==null?"":data[ds].CName) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">被投保人姓名拼音：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].EName==null?"":data[ds].EName) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">被投保人证件类型：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CardTypeName==null?"":data[ds].CardTypeName) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">被投保人证件号：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CardCode==null?"":data[ds].CardCode.replace(/^(.{6})(?:\d+)(.{4})$/, "$1****$2"))+ "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">被投保人性别：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].Sex == 0 ? "女" : (data[ds].Sex == 1 ? "男" : "女")) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">被投保人出生日期：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].Birthday == null ? "" : data[ds].Birthday) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">被投保人移动电话：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].Mobile==null?"":data[ds].Mobile.replace(/(\d{3})\d{4}(\d{4})/, '$1****$2')) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">被投保人邮箱：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].Email==null?"":data[ds].Email) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">证件有效期：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CardPeriod==null?"":data[ds].CardPeriod) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">创建时间：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].RecordCreateTime==null?"": data[ds].RecordCreateTime)+ "</td></tr>";

                    stringData += "</table>";

                }

                $("#InsurantInfotabs").html(stringData);
            }
        });

    }

    //投保人信息
    function GetApplicantInfotabs() {
        $.ajax({
            type: "GET",
            async: false,
            dataType: "json",
            url: "../Ajax/MofangOrder/HApplicantInfo.ashx?OrderApplyID=" +<%=OrderApplyId%> +"&r=" + Math.random(),
            data: { Action: "GetApplicantInfotabs" },
            success: function (data) {
                var stringData = "";
                for (var ds in data) {
                    stringData += "<table style=\"width:100%\">";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">承保单号：</td><td   style=\"width:70%;text-align:left \">" + (<%=InsureNum%>==null?"": <%=InsureNum%>)+ "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">投保人姓名：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CName==null?"": data[ds].CName) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">投保人姓名拼音：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].EName==null?"":data[ds].EName) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">投保人证件类型：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CardTypeName==null?"":data[ds].CardTypeName) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">投保人证件号：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CardCode==null?"": data[ds].CardCode.replace(/^(.{6})(?:\d+)(.{4})$/, "$1****$2")) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">投保人性别：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].Sex == 0 ? "女" : (data[ds].Sex == 1 ? "男" : "女")) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">投保人出生日期：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].BirthDay == null ? "" : data[ds].BirthDay) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">投保人移动电话：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].Mobile==null?"": data[ds].Mobile.replace(/(\d{3})\d{4}(\d{4})/, '$1****$2'))+ "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">投保人邮箱：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].Email==null?"": data[ds].Email)+ "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">证件有效期：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CardPeriod == null ? "" : data[ds].CardPeriod) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">创建时间：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].RecordCreateTime == null ? "" : data[ds].RecordCreateTime) + "</td></tr>";

                    stringData += "</table>";
                }

                $("#ApplicantInfotabs").html(stringData);
            }
        });
    }
    //订单信息的tabs
    function GetOrderRebatetabs() {
        $.ajax({
            type: "GET",
            async: false,
            dataType: "json",
            url: "../Ajax/Admin/HOrderRebate.ashx?OrderRebateId=" + <%=OrderRebateId%> + "&r=" + Math.random(),
            data: { Action: "GetOrderRebatetabs" },
            success: function (data) {
                var stringData = "";
                for (var ds in data) {
                    stringData += "<table style=\"width:100%\">";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">流水单号：</td><td   style=\"width:70%;text-align:left \">" + (data[ds].TransNo==null?"":data[ds].TransNo) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">订单金额：</td><td  style=\"width:70%;text-align:left \">￥" + (data[ds].OrderMoney==null?"":data[ds].OrderMoney) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">商家返利百分比：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].MerchantRebate==null?"": data[ds].MerchantRebate) + "%</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">商家返利金额：</td><td  style=\"width:70%;text-align:left \">￥" + data[ds].MerchantMoney + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">总部返利百分比：</td><td  style=\"width:70%;text-align:left \">" + data[ds].HQRebate + "%</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">总部返利金额：</td><td  style=\"width:70%;text-align:left \">￥" + data[ds].HQMoney + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">支付状态：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].PayStatus == 0 ? "未支付" : (data[ds].PayStatus == 1 ? "已支付" : (data[ds].PayStatus == 2 ? "支付失败" : "未支付"))) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">结算状态：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].IsSettled == 0 ? "未结算" : (data[ds].IsSettled == 1 ? "已申请" : (data[ds].IsSettled == 2 ? "已结算" : "未知"))) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">退保状态：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].IsCancel == 0 ? "未退保" : (data[ds].IsCancel == 1 ? "已退保" : "未退保")) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">结算日期：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].SettlementDate == null ? "" : data[ds].SettlementDate) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">建档日期：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].CreateDate == null ? "" : data[ds].CreateDate) + "</td></tr>";
                    stringData += " <tr><td  style=\"width:30%;text-align:right \">备注：</td><td  style=\"width:70%;text-align:left \">" + (data[ds].Remark==null?"":data[ds].Remark) + "</td></tr>";

                    stringData += "</table>";
                }

                $("#OrderRebatetabs").html(stringData);
            }
        });
    }


    (function ($) {
        $.fn.tabs = function () {
            var opts = {
                switchingMode: "click"  // or "click"---通过点击鼠标事件切换tabs  
            };
            var obj = $(this);
            var clickIndex = 0;
            obj.addClass("tabsDiv");
            $("ul li:first", obj).addClass("tabsSeletedLi");
            $("ul li", obj).not(":first").addClass("tabsUnSeletedLi");
            $("div", obj).not(":first").hide();
            $("ul li", obj).bind(opts.switchingMode,
            function () {
                if (clickIndex != $("ul li", obj).index($(this))) {
                    clickIndex = $("ul li", obj).index($(this));
                    $(".tabsSeletedLi", obj).removeClass("tabsSeletedLi").addClass("tabsUnSeletedLi");
                    $(this).removeClass("tabsUnSeletedLi").addClass("tabsSeletedLi");
                    var divid = $("a", $(this)).attr("href").substr(1);
                    $("div", obj).hide();
                    $("#" + divid, obj).show();
                };
            });
        };
    })(jQuery);
</script>
