<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BWJS.WebPad.Product.SSKD.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport">
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/NewSSKD/bootstrap.min.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <link rel="stylesheet" href="../../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../Content/css/NewSSKD/main.css" />
    <style>
        .main {
    position: fixed;
    width: 100%;
    left: 0;
    top: 0;
    padding-top:50px;
    background:#fff;
    height: 100%;
}

    </style>
    <title></title>
</head>
<body >
  <!--广告幻灯片部分 start 调用原来的一个IP地址-->
<%--    <script src="/Scripts/NewSSKD/banner.js"></script>--%>
    <!--广告幻灯片部分END-->
<div class="main">

    <!--申请借款start-->
    <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="">

        <div class="col-sm-12 text-center til">
            <span class="til1">欢迎商家管理员登录</span>
        </div>
        <div class="col-sm-12 text-right">

            <div class="form-group">
                <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">商家账号：</label>
                <div class="col-lg-8 col-sm-8 col-xs-8" style="padding-right: 30px">
                    <input type="text" value="" id=""  name="cardImgPro" class="form-control" placeholder="请输入商家账号" required data-msg-required="扫描身份证" />
                </div>

            </div>

            <div class="form-group">
                <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">密 码：</label>
                <div class="col-lg-8 col-sm-8 col-xs-8" style="padding-right: 30px">
                    <input type="password" value="" id=""  name="cardImgPro" class="form-control" placeholder="请输入密码" required data-msg-required="扫描身份证" />
                </div>

            </div>
            <div class="form-group">
                <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">身份证号：</label>
                <div class="col-lg-8 col-sm-8 col-xs-8" style="padding-right: 30px">
                    <input type="text" value="" id=""  name="cardImgPro" class="form-control" placeholder="请输入身份证号" required data-msg-required="不能为空" />
                </div>
            </div>


            <div class="col-lg-12 col-sm-12 col-xs-12">

                <div class="col-lg-2 col-sm-2 col-xs-2">

                </div>
              
                <div class="col-lg-3 col-sm-3 col-xs-3">
                    <a href="ToApplyForALoan.aspx"> <div class="login-btn lo-bg1">登 录</div></a>
                </div>
                <div class="col-lg-1 col-sm-1 col-xs-1">

                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                    <a href="填写信息.html"> <div class="login-btn lo-bg2">重 置</div></a>
                </div>
                <div class="col-lg-2 col-sm-2 col-xs-2">

                </div>


            </div>
        </div>

    </form>
    <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
        <span class="ts-msg"></span>
    </div>
    <!--申请借款end-->

</div>
</body>
</html>
   
