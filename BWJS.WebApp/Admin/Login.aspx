<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BWJS.WebApp.Admin.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet">
    <link href="/Content/css/Admin/main.css" rel="stylesheet">
    <link href="/Content/css/Admin/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="/Content/css/Admin/templatemo_style.css" rel="stylesheet" type="text/css">
    <title>信息服务平台</title>
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js"></script>
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
</head>


<body style="background: #f3f2f2">
    <div class="redline"></div>
    <div class="header">
        <div class="logo1">
            <%--  <img src="/Content/img/logo.png">--%>
        </div>
        <div class="title">金融超市平台</div>
        <div class="logouser">HI! 用户你好! <span class="lu">“请您登录”</span></div>
    </div>
    <!--用户列表start-->
    <div class="container mar-top">
        <form id="form1" class="form-horizontal templatemo-container templatemo-login-form-1 margin-bottom-30" role="form">
            <div class="form-group">
                <div class="col-xs-12">
                    <div class="control-wrapper">
                        <label class="control-label fa-label"><i class="fa fa-user fa-medium"></i></label>
                        <input type="text" class="form-control" name="inpUid" id="inpUid" placeholder="用户帐号">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <div class="control-wrapper">
                        <label class="control-label fa-label"><i class="fa fa-lock fa-medium"></i></label>
                        <input type="password" class="form-control" name="inpPwd" id="inpPwd" placeholder="用户密码">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <div class="checkbox control-wrapper">
                        <label>
                            <input type="checkbox" checked>
                            记住密码
                        </label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <div class="control-wrapper">
                        <input id="inpbtnSignIn" name="inpbtnSignIn" type="button" value="登 录" class="btn btn-info">
                        <a href="javascript:void(0)" class="text-right pull-right">忘记密码</a>
                    </div>
                </div>
            </div>
            <hr>
            <div>技术支持QQ：2738023369 </div>
            <script src="/Scripts/bootbox.js" type="text/javascript"></script>
            <script src="/Scripts/Admin/signin.js" type="text/javascript"></script>
        </form>

    </div>
    <!--添加用户 end-->

</body>
</html>
