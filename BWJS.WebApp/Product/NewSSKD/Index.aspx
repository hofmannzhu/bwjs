<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BWJS.WebApp.Product.SSKD.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport">
    <script src="/Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="../../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../Content/css/NewSSKD/main.css" />
     <script src="/Scripts/pagecommon.js"></script>
    <title></title>
     <style>
        body,html{
            margin: 0;
            padding: 0;
            width: 100%;
            height: 100%;
            overflow-x: hidden;
        }
    </style>
        <script>
            $(document).ready(function () {
             $(".no1").click(function () {
                    $(this).css("background", "url(../../../Content/img/NewSSKD/over1.png)");
                    $(this).css("background-size", "100% 100%;");

                });
            $(".no2").click(function () {
                $(this).css("background", "url(../../../Content/img/NewSSKD/over2.png)");
                $(this).css("background-size", "100% 100%;");

            });
            $(".no3").click(function () {
                $(this).css("background", "url(../../../Content/img/NewSSKD/over3.png)");
                $(this).css("background-size", "100% 100%;");

            });

            $(".no4").click(function () {
                $(this).css("background", "url(../../../Content/img/NewSSKD/over4.png)");
                $(this).css("background-size", "100% 100%;");

            });
        });
    </script>
    <%--    <script>
        $(document).ready(function () {
            $(".no1,.no3").click(function () {
                $(".mask2").fadeIn();
            });
            $(".next-btn-tc").click(function () {
                $(".mask2").fadeOut();
            });
        });
    </script>--%>
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
</head>
<body >
    <%--   <!--遮罩弹窗申请结果start-->
<div class="mask2">
    <div class="pop-box-kf">
        <div class="col-lg-12 col-sm-12 col-xs-12">
            <div class="col-lg-3 col-sm-3 col-xs-3">
            </div>
            <div class="col-lg-6 col-sm-6 col-xs-6 text-center mar" >
                <img style="margin-top:60px;"   src="../../Content/img/NewSSKD/kf.jpg">
            </div>
            <div class="col-lg-3 col-sm-3 col-xs-3">
            </div>
        </div>

    <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
        <span class="ts-msg3">产品对接中，敬请期待...</span>
    </div>
    <div class="col-lg-12 col-sm-12 col-xs-12">
        <div class="col-lg-3 col-sm-3 col-xs-3">
        </div>
        <div class="col-lg-6 col-sm-6 col-xs-6">
           <div class="next-btn-tc">完 成</div>
        </div>
        <div class="col-lg-3 col-sm-3 col-xs-3">
        </div>
    </div>
    </div>
</div>
<!--遮罩弹窗申请结果end-->--%>
<div class="home">
    <div class="container-fluid">
       <div class="da-time text-center">
            <p id="shi"></p>
            <p id="show" class="data-time"></p>
        </div>
        <div class="col-lg-12 text-center">
            <div class="btn-box">
                <ul>
                   <a href="/Product/index?wd=0"><li class="no1">保 险<span class="lb-dot"><img src="../../Content/img/NewSSKD/home-dot1.png" /></span></li> </a>
                   <a href="/Product/NewSSKD/ToApplyForALoan.aspx">  <li class="no2" >工薪贷<span class="lb-dot" style="line-height: 90px"><img src="../../Content/img/NewSSKD/home-dot2.png" /></span></li></a>
                   <a href="/Product/index?wd=3"><li class="no3">信用卡<span class="lb-dot"><img src="../../Content/img/NewSSKD/home-dot3.png" /></span></li></a>
                   <a href="housingLoan.aspx"><li class="no4">房 贷<span class="lb-dot"  style="line-height: 80px"><img src="../../Content/img/NewSSKD/home-dot4.png" /></span></li></a> 
                </ul>
            </div>

        </div>
    </div>
</div>
</body>
</html>
   
