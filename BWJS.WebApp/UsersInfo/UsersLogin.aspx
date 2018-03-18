<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersLogin.aspx.cs" Inherits="BWJS.WebApp.UsersInfo.UsersLogin" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport">
    <script src="/Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/main.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/font-awesome.min.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/templatemo_style.css" />
    <script src="/Scripts/layer.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="main">
        <div class="adm-box1">欢迎 <b>"商家管理员"</b> 登录</div>
        <!--注册窗口-->
        <div class="for-box form-horizontal templatemo-container templatemo-login-form-1 margin-bottom-30">
            <span class="man-til">管理员登录</span>
            <div class="form-group">
                <div class="col-xs-12">
                    <div class="control-wrapper">
                        <label for="username" class="control-label fa-label"><i class="fa fa-user fa-medium"></i></label>
                        <input type="text" class="form-control" value="admin" id="LoginNameID" placeholder="您的帐号" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-12">
                    <div class="control-wrapper">
                        <label for="password" class="control-label fa-label"><i class="fa fa-lock fa-medium"></i></label>
                        <input type="password" class="form-control" id="PasswordID" placeholder="您的密码" />
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12 ">
                    <div class="control-wrapper">
                        <label for="cardid" class="control-label fa-label"><i class="fa fa-lock fa-medium"></i></label>
                        <div class="col-md-9  mar">
                            <input type="text" class="form-control" id="CardID" value="" placeholder="您的身份证号码" />
                        </div>
                        <div class="col-md-3 mar1">
                            <span class="btn mar-btn1  btn-danger" id="readCardId">身份证扫描</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group  ">
                <div class="col-md-12">
                    <div class="control-wrapper">
                        <span class="ts"><i class="red">温馨提示</i>：<br />
                            请首选扫描身份证，系统将自动添加您的身份证号码,<br />
                            <b>第1步：</b>在设备面板身份证区域放置身份证,<br />
                            <b>第2步：</b>点击“身份证扫描”按钮;也可手写输入信息。
                           
                        </span>

                        <div class="imgbox photo  hid">
                            <span class="pho">
                                <img id="PhotoID" name="Photo" style="width: 96px; height: 118px;" />
                                <object classid="clsid:5819234B-5977-4C82-9C59-A9D3C7D46083"
                                    id="CertCtl" name="CertCtl" width="0" height="0">
                                </object>
                            </span>
                            <span class="sm">请将身份证拿起后放入感应器对应虚线内</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-12">
                    <div class="control-wrapper">
                        <button id="LoginID" class="btn btn-info mr" onclick="LoginOn()">登 录</button>
                        <button id="Loginre" class="btn btn-danger" onclick="LoginReset()">重 置</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.modal-content -->
        <div class="footer" style="text-align: center; width: 68%; font-size: 13px">
             技术支持QQ：2738023369
        </div>
    </div>
</body>
<%--<input type="text" id="result" size="49" style="width: 400px;" readonly="readonly">--%>
</html>
<script>
    $(document).ready(function () {
        connect();
        $("#readCardId").click(function () {
            Cardclick();
            connect();
        });
    });


    function Cardclick(){
        connect();
        $(".photo").show();
    }
    function connect() {
        var CertCtl = document.getElementById("CertCtl");
        try {
            var result = CertCtl.OpenComm();
            if (result == "") {
                //document.getElementById("result").value = "连接成功";
                readCert();
            }
            else {
                // document.getElementById("result").value = result;
            }
        } catch (e) {
        }
    }
    function readCert() {
        var CertCtl = document.getElementById("CertCtl");
        try {
            var startDt = new Date();
            var result = CertCtl.ReadCard();
            var endDt = new Date();
            //if (result == "")
            //    document.getElementById("result").value = "读卡成功";
            //else
            //    document.getElementById("result").value = result;

            if (result == "") {
                document.all("PhotoID").src = 'data:image/jpeg;base64,' + CertCtl.CardPictureData;//显示图片  
                $("#CardID").val(CertCtl.CardNo); //身份证号  
            }
            disconnect();
        } catch (e) {
        }
    }
    function disconnect() {
        var CertCtl = document.getElementById("CertCtl");
        try {
            var result = CertCtl.CloseComm();
            //if (result == "")
            //    document.getElementById("result").value = "断开成功";
            //else
            //    document.getElementById("result").value = result;
        } catch (e) {
        }
    }

    //////////////////////////


    //////////////////////////////////读取卡信息/////////////////////////////////////////////// 
    //function readCard() {
      
    //}
    //$(function () { readCard(); });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        //张建永添加的定时换背景图
        setInterval(showBgn, <%=BackgroundRefreshTime%>);
        function showBgn() {
            var numbg = Math.floor(Math.random() * 7);
            $("body").css({
                "background": "url('../Content/img/Mofang/body-bg" + numbg + ".jpg')",
                "background-size": "100% 100%"
            })
        }
    });
    function LoginReset() {
        $("#LoginNameID").val("");
        $("#PasswordID").val("");
        $("#CardID").val("");
        document.all("PhotoID").src = '';
        $(".photo").hide();
    }
    function IsValidate() {
        if (!$("#LoginNameID").val()) {
            layer.msg('帐号不能为空');
            return false;
        }
        if (!$("#PasswordID").val()) {
            layer.msg('密码不能为空');
            return false;
        }
        if (!$("#CardID").val()) {
            layer.msg('身份证号码不能为空');
            return false;
        }
        var isIDCard2 = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;//(18位)
        var lengthvalue = document.getElementById('CardID').value.length;
        if (lengthvalue == 18) {
            if (isIDCard2.test(document.getElementById('CardID').value) === false) {
                layer.msg('身份证输入不合法,请重新填写！');
                return false;
            }
            else {
                return true;
            }
        } else {
            layer.msg('身份证位数不正确,请重新填写！');
            return false;
        }
        return true;
    }
    function LoginOn() {
        try{
            if (!IsValidate()) {
                return false;
            }
            $.ajax({
                type: "get",
                async: true,
                dataType: "json",
                url: "../Ajax/UsersLogin/HUsersLogin.ashx?r=" + Math.random(),
                data: { Action: "GetLoginOn", LoginName: $("#LoginNameID").val(), Password: $("#PasswordID").val(), CardID: $("#CardID").val() },
                success: function (data) {
                    if (data.IsSuccess > 0) {
                        layer.msg('登录成功');
                        //location.href = "/Product/HomePage.aspx";
                        location.href = "/Product/NewSSKD/Index.aspx";
                    } else {
                        layer.msg("登录失败，"+data.ErrMessage);
                    }
                }
            });
        }
        catch(e){
            alert(e.message);
        }
    }
</script>
