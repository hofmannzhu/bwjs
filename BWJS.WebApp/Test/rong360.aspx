<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rong360.aspx.cs" Inherits="BWJS.WebApp.Test.rong360" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/Mofang/main.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>

    <style>
        .pho-box {
            width: 100%;
            height: auto;
            border: 1px #ccc solid;
            float: left;
            background: #EFEEED;
            padding: 2%;
            border-radius: 5px;
        }

        .sh-box {
            width: 88%;
            padding: 6%;
            margin-left: 6%;
            margin-top: 2%;
            padding-top: 2%;
            margin-bottom: 2%;
            height: auto;
            background: #fff;
        }

        .v-box {
            position: absolute;
            top: 0;
            left: 0;
            width: 50%;
            height: 100%;
            text-align: center;
            color: red;
            border: 1px red dotted;
            border-radius: 6px;
            font-size: 26px;
            font-family: "微软雅黑 Light";
            z-index: 1;
        }

        #HTML5Div {
            padding-top: 4%;
            z-index: 20;
        }

        .tab-box {
            width: 100%;
            height: 50px;
            background: orange;
            color: #fff;
            font-weight: bold;
        }

            .tab-box li {
                float: left;
                text-align: center;
                font-size: 18px;
                width: 20%;
                height: 50px;
                border-right: 1px #fff solid;
                line-height: 50px;
            }

        .tab-bg {
            background: #ccc;
            color: #999;
        }

        .mar-btom {
            margin-bottom: 20px;
        }

        .show, .show1, .show2, .show3, .show4, .show5, .show6 {
            /*display: none;*/
        }
    </style>

    <title>闪速快贷申请</title>

    <script type="text/javascript">
        var istest = false;
        function myAlert(msg) {
            bootbox.dialog({
                message: "<div style=\"word-wrap: break-word;word-break: normal;\">" + msg + "</div>",
                buttons: {
                    "success": {
                        "label": "关闭",
                        "className": "btn btn-sm btn-primary"
                    }
                }
            });
        }
        function getJson(paramter, async) {
            var result = "";
            try {
                paramter.timeStamp = new Date().getTime();
                $.ajax({
                    type: "post",
                    url: "/ajax/helper.ashx",
                    data: paramter,
                    dataType: "json",
                    async: async,
                    xhrFields: {
                        withCredentials: true
                    },
                    crossDomain: true,
                    beforeSend: function (XMLHttpRequest) {
                        $("#loading").html("<img src='/Content/images/loading.gif' />");
                    },
                    success: function (json) {
                        result = json;
                        $("#loading").empty();
                    },
                    complete: function (XMLHttpRequest, textStatus) {
                        $("#loading").empty();
                    },
                    error: function () {
                        myAlert("服务器没有返回数据，可能服务器忙，请重试");
                        $("#loading").empty();
                    }
                });
            }
            catch (ex) { myAlert("出错了，可能服务器忙，请重试"); }
            return result;
        }
    </script>
</head>
<body>
    <div class="main1">
        <div class="leftbox">
            <div class="back" id="backId">返回</div>
        </div>
        <div class="zc-box">
            <div class="form-box">
                <div class="sh-box">
                    <div class="tab-box">
                        <ul>
                            <li class="no0">身份认证</li>
                            <li class="no1">添加银行卡</li>
                            <li class="no2">照片识别</li>
                            <li class="no3">手机运营商认证</li>
                            <li class="no4">资料审核</li>
                            <li class="no5">借款结果</li>
                            <li class="no6">借款成功</li>
                        </ul>
                    </div>
                    <!--手机运营商认证页面Start1-->
                    <div class="show3">
                        <form class="form-horizontal mar-top1" role="form" id="taskForm">
                            <div class="col-sm-12" style="margin: 0; padding: 0;" id="divFrame">
                            </div>
                            <div class="col-sm-12" style="margin: 0; padding: 0;">
                                <iframe id="taskFrame" name="taskFrame" src="https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetO9sakaM2ObZY2YPPMuifX%2Bp5AULJX6pbCTi3Win3HPvUy31JjWPiJP3terkw%2F7IgSgwd3b6bsXLz7hXZxYEdkQgQChYTIXiGh0Uup17q6heHvtry6WjiqU7KJcrwrjXQXprzmAMFmy9M6wPPRVKrapEYk%2BjzxkEkD1Sof0WyjE72k8oKdomg%2FpV9hSPGUDoVpON%2FyGkoEYF8lB0Xi9kSJJCq7Wj%2Fph7Epl%2F0Gb0bUw8" frameborder="0" width="100%" style="margin-bottom: 10px; height: auto; min-height: 550px;"></iframe>
                                <iframe id="testFrame" name="testFrame" src="/Test/ceshi" frameborder="0" width="100%" style="margin-bottom: 10px; height: auto; min-height: 550px;"></iframe>
                            </div>
                            <div class="text-center">
                                <p style="font-size: 26px; font-family: 微软雅黑; display: block; color: red;">必须填写该信息认证，否则审核通不过影响您的贷款</p>
                                <input id="next-zlsh" type="button" value="下一步" class="sub2" onclick="nextzlshClick();" />
                            </div>
                        </form>
                    </div>
                    <!--手机运营商认证页面end-->
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            //fetchrong360();
            //$(window.frames["taskFrame"].document).find(".cont").css({"padding-left","50px"});
            //myAlert($(window.frames["testFrame"].document).find(".sp_phone .cont .tabwrap").css({"position","absolute"}));
            //$(window.frames["taskFrame"].document).find(".title").css({ "color": "red" });
            //myAlert($(window.frames["taskFrame"].document).find(".cont").html());

            //$("#next-zlsh").trigger("click");
        });

        function nextzlshClick() {
            //myAlert(document.domain);
            $(window.frames["testFrame"].document).find(".container").css({ "color": "#ff0000" });
            //$(window.frames["testFrame"].document).find(".bgcoclor").each(function () {
            //});
            $(window.frames["taskFrame"].document).find(".title").css({ "color": "red" });
        }
        function fetchrong360() {
            var result = false;
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "netloan";
            paramter.action = "fetchrong360";
            paramter.url = "https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetPJUvC1%2FPyzqaQRKYIkAoClL13V6%2B5RPX4DZbI8GOINVvYzgnz%2BS3BSww5C%2Fyh2LLs751vD8zWgyEl4jk68eyngZsVr2RbUcNIL0%2BgKk56xltjvaeUvD5qSRs3ob2COv0qqcdU76SgjlGH6WADut4Ftgu2YN%2FDsJI3MVmsQLwcDtUoGsurUwBZ%2FgPzJbZEPokRyvdQSxAJBMxdTlQ6h6Ish0UMf5igU1IEZvNCSpw7y4";
            paramter.telNo = "13426086182";
            paramter.servicePwd = "123456";
            paramter.token = "";
            var json = getJson(paramter, false);
            //myAlert(JSON.stringify(json));
            if (json.result) {
                //myAlert(json.html);
                $("#divFrame").html(json.html);
            }
            else {
                myAlert(json.msg);
            }
            return result;
        }

        function tj() {
            var paramter = {};
            paramter.cellphone = "13426086182";
            paramter.password = "123456";
            paramter.timeStamp = new Date().getTime();
            $.ajax({
                type: "post",
                url: "https://tianjim.rong360.com/web_crawler/crawler/do?BusinessType=6&method=login",
                data: paramter,
                dataType: "json",
                async: false,
                xhrFields: {
                    withCredentials: true
                },
                crossDomain: true,
                beforeSend: function (XMLHttpRequest) {
                    $("#loading").html("<img src='/Content/images/loading.gif' />");
                },
                success: function (json) {
                    result = json;
                    $("#loading").empty();
                },
                complete: function (XMLHttpRequest, textStatus) {
                    $("#loading").empty();
                },
                error: function () {
                    myAlert("服务器没有返回数据，可能服务器忙，请重试");
                    $("#loading").empty();
                }
            });
        }
    </script>
</body>
</html>
