<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="BWJS.WebPad.Product.ProductList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0;" name="viewport" />
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <link rel="stylesheet" href="../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/css/Mofang/main.css" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/layer.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <title></title>
</head>
<body>
    <div class="main1">
        <div class="zc-box">
            <div class="leftbox">
                <div class="back" onclick="javascript:window.location.href='/Product/Index?wd=0'">返回</div>
            </div>
            <div class="cp-menu-box">
                <ul class="cp-1 ma-top">
                    <%for (int i = 0; i < listMofang.Count; i++) %>
                    <%{
                    %>
                    <div class="btm-link " name="objName" valu="<%=listMofang[i].CaseCode %>">
                        <li class="btn-cp ma3 wid">
                            <span class="le">
                                <img src="<%=listMofang[i].ProductPictureUrl %>" /></span>
                            <span class="con"><%=listMofang[i].ProducDescribe %> <span class="flr"><%=listMofang[i].CompanyName %></span></span>
                            <span class="ri"><%=listMofang[i].ProductName %></span></li>
                    </div>
                    <%
                        }%>
                </ul>
            </div>
        </div>
        <div class="footer">
            <span class="logo">
            <div class="adm-box">商家管理员：<%=UserName %></div>
        </div>
    </div>
    <form id="formId" name="formName" action="/Mofang/ProductDetail" method="post">
        <input type="hidden" id="hdcaseCode" name="caseCode" value="" />
    </form>
</body>
</html>
<script type="text/javascript">
    //张建永添加的定时换背景图
    setInterval(showBgn, <%=BackgroundRefreshTime%>);
    function showBgn() {
        var numbg = Math.floor(Math.random() * 7);
        $("body").css({
            "background": "url('../Content/img/Mofang/body-bg" + numbg + ".jpg')",
            "background-size": "100% 100%"
        })
    }
    $(function () {

        $("[name='objName']").click(function () {
            layer.msg('努力加载中.....', { icon: 6, time: 120000 });
            $("#hdcaseCode").val($(this).attr("Valu"));
            $("#formId").submit();
           
        });

    });
    function BackstagePage() {
        location.href = "../Admin/default.aspx";
    }
</script>

