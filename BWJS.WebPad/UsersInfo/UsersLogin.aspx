<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersLogin.aspx.cs" Inherits="BWJS.WebPad.UsersInfo.UsersLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js" type="text/javascript"></script>
    <script src="/Scripts/iPass.packed.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>

    <title></title>
    <style>
        .main {
            top: 0;
            height: 100%;
        }
    </style>
</head>
<body>
    <!--广告幻灯片部分 start 调用原来的一个IP地址-->
    <%--    <script src="../Scripts/NewSSKD/banner.js"></script>--%>
    <!--广告幻灯片部分END-->
    <div class="main">

        <!--申请借款start-->
        <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="">

            <div class="col-sm-12 text-center til" style="margin-top: 60px;">
                <span class="til1">欢迎商家管理员登录</span>
            </div>
            <div class="col-sm-12 text-right">

                <div class="form-group" style="margin-top: 20px;">
                    <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">商家账号：</label>
                    <div class="col-lg-8 col-sm-8 col-xs-8" style="padding-right: 30px">
                        <input type="text" value="" id="LoginNameID" name="cardImgPro" class="form-control" placeholder="请输入商家账号" maxlength="15" required data-msg-required="请输入商家账号" />
                    </div>

                </div>

                <div class="form-group">
                    <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">密 码：</label>
                    <div class="col-lg-8 col-sm-8 col-xs-8" style="padding-right: 30px">
                        <input type="password" value="" id="PasswordID" name="cardImgPro" class="form-control" placeholder="请输入密码" maxlength="16" required data-msg-required="请输入密码" />
                    </div>

                </div>
                <div class="form-group">
                    <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">身份证号：</label>
                    <div class="col-lg-8 col-sm-8 col-xs-8" style="padding-right: 30px">
                        <input type="text" value="" id="CardID" name="cardImgPro" onkeyup="clearNoNum(this)" onblur="clearNoNum(this)" class="form-control" placeholder="请输入身份证号" maxlength="18" required data-msg-required="请输入身份证号" />
                    </div>
                </div>


                <div class="col-lg-12 col-sm-12 col-xs-12">

                    <div class="col-lg-2 col-sm-2 col-xs-2">
                    </div>
                    <div class="col-lg-1 col-sm-1 col-xs-1">
                    </div>
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                        <div class="login-btn lo-bg1" onclick="LoginOn()">登 录</div>
                    </div>
                    <div class="col-lg-1 col-sm-1 col-xs-1">
                    </div>
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                        <div class="login-btn1 lo-bg2" onclick="LoginReset()">重 置</div>
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
<script type="text/javascript">
    $(document).ready(function () {
        //张建永添加的定时换背景图
        setInterval(showBgn, <%=BackgroundRefreshTime%>);
        function showBgn() {
            var numbg = Math.floor(Math.random() * 7);
            $("body").css({
                "background": "url('/Content/img/Mofang/body-bg" + numbg + ".jpg')",
                "background-size": "100% 100%"
            })
        }
        //$("input[type=password]").iPass();
        formInpKeyUpCheck();
    });
    function LoginReset() {
        $("#LoginNameID").val("");
        $("#PasswordID").val("");
        $("#CardID").val("");
    }

    //验证只能输入数字
    function clearNoNum(obj) {
        var numlength = document.getElementById('CardID').value.length;
        if (numlength <= 17) {
            obj.value = obj.value.replace(/\D/g, "");
        } else if (numlength == 18) {
            var type = CheckNum();
            if (!type) {
                obj.value = obj.value.substring(0,17);
                $("#CardID").val(obj.value);
                return false;
            }
        }
    }

    function CheckNum() {
        var numlength = document.getElementById('CardID').value.length;
        var numvalue = $("#CardID").val();
        var min = 1;
        var max = 18;
        if (numlength < min || numlength > max) {
            return false;
        }
        else {
            var city = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "南", 42: "湖北 ", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 " };
            var isIDCard1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;//(15位)
            var isIDCard2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;//(18位)
            var value2 = "";
            if (numvalue.length == 18) {
                value2 = numvalue.split('');
                //∑(ai×Wi)(mod 11)
                //加权因子
                var factor = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
                //校验位
                var parity = [1, 0, 'X', 9, 8, 7, 6, 5, 4, 3, 2];
                var sum = 0;
                var ai = 0;
                var wi = 0;
                for (var i = 0; i < 17; i++) {
                    ai = value2[i];
                    wi = factor[i];
                    sum += ai * wi;
                }
                var last = parity[sum % 11];
            }

            return ((isIDCard1.test(numvalue)) || (isIDCard2.test(numvalue))) && ((city[numvalue.substr(0, 2)] != "") && (city[numvalue.substr(0, 2)] != undefined) && (parity[sum % 11] == numvalue[17]));
        }
    }

    function formInpKeyUpCheck(){
        //$("#LoginNameID").blur(function (){
        //    IsValidate();
        //});
        //$("#PasswordID").blur(function (){
        //    IsValidate();
        //});
        //$("#CardID").blur(function (){
        //    IsValidate();
        //});
    }

    function LoginOn() {
        try {
            var   Imei='';
            //var   Imei=  android.getImei();
            if (!IsValidate()) {
                return false;
            }
            $.ajax({
                type: "get",
                async: true,
                dataType: "json",
                url: "/Ajax/UsersLogin/HUsersLogin.ashx?r=" + Math.random(),
                data: { Action: "GetLoginOn", LoginName: $("#LoginNameID").val(), Password: $("#PasswordID").val(), CardID: $("#CardID").val(),Imei:Imei },
                success: function (data) {
                    if (data.IsSuccess > 0) {
                        layer.msg('登录成功');
                        //location.href = "/Product/HomePage.aspx";
                        location.href = "/Product/NewSSKD/home.aspx";
                    } else {
                        if (data.ErrMessage!=null&&data.ErrMessage!="") {
                            layer.msg("登录失败，" + data.ErrMessage);
                        }else{
                            layer.msg("登录失败，服务器异常");
                        }
                      
                    }
                }


            });
        }
        catch (e) {
            alert(e.message);
        }
    }

    function IsValidate() {
        if (!$("#LoginNameID").val()) {
            layer.msg('帐号不能为空');
            return false;
        }
        else{
            var un = /^\w+$/;
            if (!un.test($("#LoginNameID").val())) {
                layer.msg("商家账号只能为字母、数字或下划线的组合");
                return false;
            }
            else {
                var ulen = $("#LoginNameID").val().length;
                if (ulen < 5 || ulen > 15) {
                    layer.msg("输入限制，商家账号长度必须在5至15位之间");
                    return false;
                }
            }
        }
        if (!$("#PasswordID").val()) {
            layer.msg('密码不能为空');
            return false;
        }
        else {
            var ulen = $("#PasswordID").val().length;
            if (ulen < 6 || ulen > 16) {
                layer.msg("输入限制，密码长度必须在6至16位之间");
                return false;
            }
        }

        if (!$("#CardID").val()) {
            layer.msg('身份证号不能为空');
            return false;
        }
        else{
            var un = /^\w+$/;
            if (!un.test($("#CardID").val())) {
                layer.msg("身份证号输入有误，不能包含特殊字符");
                return false;
            }
            else {
                var isIDCard2 = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;//(18位)
                var lengthvalue = document.getElementById('CardID').value.length;
                if (lengthvalue == 18) {
                    if (isIDCard2.test(document.getElementById('CardID').value) === false) {
                        layer.msg('身份证号输入不合法,请重新填写！');
                        return false;
                    }
                    else {
                        return true;
                    }
                } else {
                    layer.msg('身份证号位数不正确,请重新填写！');
                    return false;
                }
            }
        }
        return true;
    }
</script>

