<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BWJS.WebApp.Product.HomePage" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport">
    <script src="/Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/css/Mofang/main.css" />
    <style>
        body {
            background: url("../Content/img/Mofang/index-bg.jpg");
            background-size: 100% 102%;
        }
    </style>
    <title></title>
</head>
<body>

    <div class="container">
        <p id="shi"></p>
        <p id="show" class="data-time"></p>
        <div class="col-lg-12 text-center">
            <div class="btn-box">
                <ul>
                    <a href="index.aspx?wd=1">
                        <li style="background: url(../Content/img/Mofang/btn-red-bg.png)">网  贷<span class="lb-dot"><img src="../Content/img/Mofang/do1.jpg" /></span></li>
                    </a>
                    <a href="index.aspx?wd=0">
                        <li style="background: url(../Content/img/Mofang/btn-blue-bg.png)">保  险<span class="lb-dot"><img src="../Content/img/Mofang/do2.jpg" /></span></li>
                    </a>
                </ul>
                <ul>
                    <a href="index.aspx?wd=3">
                        <li style="background: url(../Content/img/Mofang/btn-qf-bg.png)">信 用 卡<span class="lb-dot"><img src="../Content/img/Mofang/do3.jpg" /></span></li>
                    </a>
                    <li style="padding: 0;">
                        <div class="btn-c-box">
                            <ul>
                                <a href="index.aspx?wd=2">
                                    <li style="background: url(../Content/img/Mofang/btn-green-bg.png); margin: 0 4% 0 0; padding-left: 2%; padding-top: 40px;">银  行<span class="lb-dot2"><img src="../Content/img/Mofang/do4.jpg" /></span></li>
                                </a>
                                <a href="index.aspx?wd=4">
                                    <li style="background: url(../Content/img/Mofang/btn-feng-bg.png); margin: 0 0 0 4%; padding-left: 2%; padding-top: 40px;">其  它<span class="lb-dot2"><img src="../Content/img/Mofang/do5.jpg" /></span></li>
                                </a>
                            </ul>
                        </div>
                    </li>
                </ul>
            </div>

        </div>
    </div>
    <div class="container">
        <div class="col-lg-12 text-center gyj">
            自 助 金 融 柜 员 机
        </div>
        <div class="col-lg-12 text-center fot">
       
        </div>

    </div>
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
            }, parseInt('<%=HomePageRefreshTime%>'));
        };
    </script>

</body>
</html>
