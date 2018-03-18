<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="BWJS.WebApp.Product.NewSSKD.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>登录</title>
    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/Mofang/font-awesome.min.css" rel="stylesheet" />
    <link href="/Content/css/Mofang/templatemo_style.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <!--身份证扫描js开始(顺序不要变)-->
    <script src="/Scripts/IDCard/jquery.jBox-2.3.min.js"></script>
    <script src="/Scripts/IDCard/baseISSObject.js"></script>
    <script src="/Scripts/IDCard/baseISSOnline.js"></script>
    <script src="/Scripts/IDCard/common.js"></script>
    <!--身份证扫描js结束-->

    <!--弹出对话框脚本-->
    <script>
        $(document).ready(function () {
            $(".adm-box1").click(function () {
                $(".mask5").show();
                $(".pop-box-msg").animate({ 'top' : '250' },500)
            });
            $(".clo-btn").click(function () {
                $(".pop-box-msg").animate({ 'top' : '0' },500,function () {
                    $(".mask5").fadeOut()
                });
            });
        });
    </script>
    <script type="text/javascript">
        window.onload = function () {
            var show = document.getElementById("show");
            var shi = document.getElementById("shi");
            setInterval(function () {
                var time = new Date();

                //分别取出时分秒
                var hours = time.getHours();
                var minutes = time.getMinutes();
                var seconds = time.getSeconds();

                //如果是单个数，则前面补0
                hours = hours < 10 ? "0" + hours : hours;
                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;

                // 程序计时的月从0开始取值后+1
                var m = time.getMonth() + 1;
                var t = time.getFullYear() + "年" + m + "月"
                  + time.getDate() + "日 ";
                var s = hours + ":" + minutes + ":" + seconds;

                show.innerHTML = t;
                shi.innerHTML = s;

            }, 1000);
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
            }, parseInt('<%=BackgroundRefreshTime%>'));
        };
    </script>


    <style>
        body, html {
            margin: 0;
            padding: 0;
            width: 100%;
            height: 100%;
            overflow-x: hidden;
        }

        .for-box {
            margin-top: 18%;
        }

        input {
            color: red;
        }

        .yuan {
            display: block;
            float: left;
            width: 20px;
            height: 20px;
            padding-left: 3px;
            line-height: 20px;
            background: #FB6113;
            border-radius: 50%;
            color: #fff;
            margin-right: 15px;
            text-align: center;
            font-weight: normal;
            margin-top: 4px;
        }


        .sfz-btn {
            width: 100%;
            height: 38px;
            text-align: center;
            background: #fa6113;
            line-height: 38px;
            color: #fff;
            font-size: 13px;
            border-radius: 8px;
            font-family: 微软雅黑;
            cursor: pointer;
        }

            .sfz-btn:hover {
                background: #ea5002;
            }


        .dl-btn {
            width: 100%;
            height: 40px;
            text-align: center;
            background: #ccc;
            line-height: 40px;
            color: #A2A2A2;
            font-size: 18px;
            border-radius: 8px;
            font-family: 微软雅黑;
            cursor: pointer;
            margin-bottom: 40px;
        }

        .form-group {
            margin-bottom: 10px;
        }

            .form-group input {
                height: 38px;
                border: 1px #E7E1DB solid;
            }

        .templatemo-container {
            background-color: rgba(255,255,255,0.9);
            padding-top: 30px;
            padding-bottom: 30px;
        }

        .ok {
            background: #fb6113;
            color: #fff;
        }

            .ok:hover {
                background: #ea5002;
            }

        .cz {
            background: #039ad2;
            color: #fff;
        }

            .cz:hover {
                background: #0488b9;
            }
    </style>
</head>
<body>

    <div class="home">
        <div class="container-fluid">
            <div class="da-time text-center">
                <p id="shi"></p>
                <p id="show" class="data-time"></p>
            </div>

            <!--   <div class="adm-box1">欢迎 <b>"商家管理员"</b> 登录</div>-->
            <!--注册窗口-->
            <div class="for-box form-horizontal templatemo-container templatemo-login-form-1">
                <div class="col-sm-12 text-center">
                    <span style="font-size: 30px; font-family: 微软雅黑; color: #FB6113; margin-bottom: 10px; float: left; margin-left: 30%;">管理员登录</span>
                </div>
                <div class="form-group" style="margin-bottom: 13px;">
                    <div class="col-xs-12">
                        <div class="control-wrapper">
                            <label for="username" class="control-label fa-label">
                                <img style="position: absolute; top: 2px; left: -1px;" src="../../Content/img/NewSSKD/yhm.png" />
                            </label>
                            <input type="text" class="form-control" value="" id="LoginNameID" placeholder="请输入您的帐号" />
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-12">
                        <div class="control-wrapper">
                            <label for="password" class="control-label fa-label">
                                <img style="position: absolute; top: 2px; left: -1px;" src="../../Content/img/NewSSKD/mima.png" />
                            </label>
                            <input type="password" class="form-control" id="PasswordID" placeholder="请输入您的密码" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12 ">
                        <div class="control-wrapper">
                            <label for="cardid" class="control-label fa-label">
                                <img style="position: absolute; top: 6px; left: -3px;" src="../../Content/img/NewSSKD/sfzdot.png" />
                            </label>
                            <div class="col-lg-9 col-sm-9 col-xs-9 ma">
                                <input type="text" class="form-control" id="certNumber" value="" placeholder="请输入您的身份证号码" />
                            </div>
                            <div class="col-lg-3 col-sm-3 col-xs-3">

                                <div class="sfz-btn" onclick="new Device().startFun()" id="button_readID">身份证扫描</div>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group  ">
                    <div class="col-md-12">
                        <div class="control-wrapper">
                            <span style="color: #bdbdbd; font-size: 12px; font-family: 微软雅黑; line-height: 30px"><i style="color: #FB6722; font-style: normal; line-height: 20px">温馨提示：</i><br />
                                请首选扫描身份证，系统将自动添加您的身份证号码<br />
                                <b><span class="yuan">1</span></b>在设备面板身份证区域放置身份证<br />
                                <b><span class="yuan">2</span></b>点击“身份证扫描”按钮
                           
                            </span>

                            <div class="imgbox photo  hid">
                                <span class="pho">
                                    <img id="PhotoID" name="Photo" style="width: 96px; height: 118px;" /> 
                                </span>
                                <span class="sm">请将身份证拿起后放入感应器对应虚线内</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-12 col-sm-12 col-xs-12">
                        <div class="col-lg-1 col-sm-1 col-xs-1">
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                            <div class="dl-btn ok" onclick="LoginOn()">登 录</div>
                        </div>
                        <div class="col-lg-2 col-sm-2 col-xs-2">
                        </div>
                        <div class="col-lg-2 col-sm-2 col-xs-2">
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                            <div class="dl-btn cz" onclick="LoginReset()">重 置</div>
                        </div>
                        <div class="col-lg-1 col-sm-1 col-xs-1">
                        </div>
                    </div>

                    <div class="col-sm-12 text-center">
                        <div class="control-wrapper">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.modal-content -->
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
            $("#certNumber").val("");
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
            if (!$("#certNumber").val()) {
                layer.msg('身份证号码不能为空');
                return false;
            }
            var isIDCard2 = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;//(18位)
            var lengthvalue = document.getElementById('certNumber').value.length;
            if (lengthvalue == 18) {
                if (isIDCard2.test(document.getElementById('certNumber').value) === false) {
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
                if(IsValidate()){
                    bwjsLoadingDemo("努力加载中...");
                    $.ajax({
                        type: "get",
                        async: true,
                        dataType: "json",
                        url: "/Ajax/UsersLogin/HUsersLogin.ashx?r=" + Math.random(),
                        data: { Action: "GetLoginOn", LoginName: $("#LoginNameID").val(), Password: $("#PasswordID").val(), CardID: $("#certNumber").val() },
                        success: function (data) {
                            bwjsLoadingClose();
                            if (data.IsSuccess > 0) {
                                layer.msg('登录成功');
                                //location.href = "/Product/HomePage.aspx";
                                location.href = "/Product/NewSSKD/Index.aspx";
                            } else {
                                layer.msg("登录失败，"+data.ErrMessage);
                            }
                        },
                        complete: function (XMLHttpRequest, textStatus) {
                            bwjsLoadingClose();
                        },
                        error: function () {
                            bwjsLoadingClose();
                        }
                    });
                }
            }
            catch(e){
                myAlert(e.message);
            }
        }
    </script>
</body>
</html>
