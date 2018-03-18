<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorizationCertification.aspx.cs" Inherits="BWJS.WebApp.Product.SSKD.AuthorizationCertification" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>授权认证</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <style type="text/css">

        #ucBrowser {
            height: 100%;
            width: 100%;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            sqBindClick();
            authStateCheck();
            initAuthenticationResults();
        });

    </script>
</head>
<body>
    <!--遮罩弹窗start-->
    <div class="mask6">
        <div class="pop-box-rzd">
            <%--<iframe src="http://www.sina.com.cn" id="iframerz" frameborder="1"></iframe>--%>
            <object classid="clsid:6a501d33-a734-4568-b8b0-4bc507400a81" id="ucBrowser"></object>
            <div class="next-btn" id="btnLayer" style="position: absolute; bottom: -40px; left: 30%; width: 40%;">关闭</div>
        </div>
    </div>
    <!--遮罩弹窗end-->

    <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NewSSKD/TheAppraisalReport">
        <!--遮罩弹窗显示是和否start-->
        <div class="main">
            <!--头部元素start-->
            <div class="head-box">
                <div class="col-lg-12">
                    <!--申请成功移动字幕start-->
                    <script src="/Scripts/NewSSKD/success.js"></script>
                </div>
            </div>
            <!--头部元素end-->

            <!--步骤条start-->
            <div class="tab-box">
                <ul>
                    <li class="bg-blue" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot1.png"></span>人像采集</li>
                    <li class="active-bg-red" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot2.png"></span>授权认证</li>
                    <li class="bg-blue"><span class="line"></span><span class="bg-r ">
                        <img src="../../Content/img/NewSSKD/tab-dot3.png"></span>评估报告</li>
                    <li class="bg-blue"><span class="line"></span><span class="bg-r">
                        <img src="../../Content/img/NewSSKD/tab-dot5.png"></span>选择银行卡</li>
                    <li class="bg-blue"><span class="bg-r">
                        <img src="../../Content/img/NewSSKD/tab-dot4.png"></span>申请确认</li>

                </ul>
            </div>
            <!--步骤条end-->

            <!--授权认证start-->
            <div class="main-box">
                <div class="jg-con-box">

                    <div class="col-lg-12 col-sm-12 col-xs-12 text-center ma" style="margin-bottom: 40px; margin-top: 40px;">
                        <div class="col-lg-4 col-sm-4 col-xs-4">
                            <table class="table table-bordered row">
                                <caption class="ort">必 填 项</caption>
                                <tr>
                                    <td style="border-bottom: 0; border-top: 0;">
                                        <div class="sq-box bg1" id="sq-mobie">
                                            <img class="dot" src="../../Content/img/NewSSKD/sq-dot1.png" />
                                        </div>
                                        <p>手机运营认证<i style="color: red; font-style: normal; font-size: 16px;"></i></p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-lg-8 col-sm-8 col-xs-8">
                            <table class="table table-bordered row">
                                <caption class="ort">三 选 一</caption>

                                <tr>
                                    <td>
                                        <div class="sq-box bg2" id="sq-sss">
                                            <img class="dot" src="../../Content/img/NewSSKD/sq-dot2.png" />
                                        </div>
                                        <p>社 保</p>
                                    </td>
                                    <td>
                                        <div class="sq-box bg1" id="sq-jds">
                                            <img class="dot" src="../../Content/img/NewSSKD/sq-dot6.png" />
                                        </div>
                                        <p>京 东</p>
                                    </td>
                                    <td>
                                        <div class="sq-box bg2" id="sq-zfbs">
                                            <img class="dot" src="../../Content/img/NewSSKD/sq-dot4.png" />
                                        </div>
                                        <p>支 付 宝</p>
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </div>

                    <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                        <table class="table table-bordered row">
                            <caption style="padding-top: 0px;">授信额度最高增加3万元</caption>
                            <tr>
                                <td>
                                    <div class="sq-box bg2" id="sq-ms">
                                        <img class="dot" src="../../Content/img/NewSSKD/sq-dot9.png" />
                                    </div>
                                    <p>信  用 卡</p>
                                </td>

                                <td>
                                    <div class="sq-box bg3" id="sq-wy">
                                        <img class="dot" src="../../Content/img/NewSSKD/sq-dot10.png" />
                                    </div>
                                    <p>网 银</p>
                                </td>
                                <td>
                                    <div class="sq-box bg3" id="sq-xxs">
                                        <img class="dot" src="../../Content/img/NewSSKD/sq-dot7.png" />
                                    </div>
                                    <p>学 信 网</p>
                                </td>
                                <td>
                                    <div class="sq-box bg1" id="sq-rhzxs">
                                        <img class="dot" src="../../Content/img/NewSSKD/sq-dot8.png" />
                                    </div>
                                    <p>人行征信</p>
                                </td>
                                <td>
                                    <div class="sq-box bg2" id="sq-gjjs">
                                        <img class="dot" src="../../Content/img/NewSSKD/sq-dot3.png" />
                                    </div>
                                    <p>公 积 金</p>
                                </td>
                            </tr>


                        </table>
                    </div>
                    <div class="col-lg-12 col-sm-12 col-xs-12">
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                        <div class="col-lg-6 col-sm-6 col-xs-6">
                            <a href="javsscript:void(0)">
                                <div class="next-btn" id="IsTypeStr">下 一 步</div>
                            </a>
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>

                    </div>

                </div>
                <!--授权认证end-->
            </div>
        </div>
        <div class="modal fade" id="rong360Modal" tabindex="-1" role="dialog" aria-labelledby="rong360ModalLabel" data-backdrop="false">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="rong360ModalLabel">授权认证</h4>
                    </div>
                    <div class="modal-body">
                        <object classid="clsid:6a501d33-a734-4568-b8b0-4bc507400a81" id="ucBrowser">
                        </object>
                    </div>
                </div>
            </div>
        </div>
        <input id="hidtypeId" name="hidtypeId" type="hidden" />
        <input id="hiddObjId" name="hiddObjId" type="hidden" />

        <script src="/Scripts/jquery.query-2.1.7.js" type="text/javascript"></script>
        <script type="text/javascript">
            Array.prototype.contains = function (val) {
                for (var i = 0; i < this.length; i++) {
                    if (this[i] == val) {
                        return true;
                    }
                }
                return false;
            };
            Array.prototype.remove = function (val) {
                for (var i = 0; i < this.length; i++) {
                    if (this[i] == val) {
                        this.splice(i, 1);
                        break;
                    }
                }
            }

            function sqBindClick() {
                $("#sq-mobie").click(function () {
                    querenLayer("您真的要申请授权吗？", "mcs", "sq-mobie");
                })
                $("#sq-sss").click(function () {
                    querenLayer("您真的要申请授权吗？", "sss", "sq-sss");
                })
                $("#sq-gjjs").click(function () {
                    querenLayer("您真的要申请授权吗？", "gjjs", "sq-gjjs");
                })
                $("#sq-zfbs").click(function () {
                    querenLayer("您真的要申请授权吗？", "zfbs", "sq-zfbs");
                })
                $("#sq-tbs").click(function () {
                    querenLayer("您真的要申请授权吗？", "tbs", "sq-tbs");
                })
                $("#sq-jds").click(function () {
                    querenLayer("您真的要申请授权吗？", "jds", "sq-jds");
                })
                $("#sq-xxs").click(function () {
                    querenLayer("您真的要申请授权吗？", "xxs", "sq-xxs");
                })
                $("#sq-rhzxs").click(function () {
                    querenLayer("您真的要申请授权吗？", "rhzxs", "sq-rhzxs");
                })
                $("#sq-ms").click(function () {
                    querenLayer("您真的要申请授权吗？", "ms", "sq-ms");
                })

                $("#sq-wy").click(function () {
                    querenLayer("您真的要申请授权吗？", "wy", "sq-wy");
                })

                $(".clo").click(function () {
                    $(".mask").hide();
                })

                $("#IsTypeStr").bind("click", function () {
                    return nextStep();
                })
            }

            //显示运营商页面
            function Showmcs(type, objId) {
                $("#hidtypeId").val(type);
                $("#hiddObjId").val(objId);
                return submitClick();
            }

            function submitClick() {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "newnetloan";
                paramter.action = "Checkmcs";
                paramter.typeId = $("#hidtypeId").val();
                paramter.objId = $("#hiddObjId").val();
                paramter.realName = '<%= sskdModel.FullName %>';
                paramter.idNo = '<%= sskdModel.IDCardNo %>';
                paramter.telNo = '<%= sskdModel.Mobile %>';
                paramter.consultId = '<%= sskdModel.ConsultId %>';
                paramter.orderNo = '<%= sskdModel.OrderNo %>';
                paramter.equipmentNo = '<%= sskdModel.MachineId %>';
                paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
                paramter.sign = '<%= GetSign %>';
                paramter.token = '<%= sskdModel.Token %>';

                var json = getJson(paramter, false);
                if (json.success) {
                    //var WSH = new ActiveXObject("WScript.Shell");
                    //WSH.Run("chrome.exe   " + json.data.url + "");
                    ////SetUrl(json.data.url);
                    //window.location.href = json.data.url;
                    var index = layer.open({
                        type: 2,
                        content: json.data.url,
                        area: ['640px', '480px'],
                        maxmin: true,
                        title: "授权认证"
                    });
                    layer.full(index);
                }
                else {
                    myAlert(json.message);
                }
                return true;
            }


            //认证结果查询
            function GetRzjd() {
                allHasNotAuth = "";
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "newnetloan";
                paramter.action = "GetRzjd";
                paramter.consultId = '<%= sskdModel.ConsultId %>';
                paramter.orderNo = '<%= sskdModel.OrderNo %>';
                paramter.equipmentNo = '<%= sskdModel.MachineId %>';
                paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
                paramter.sign = '<%= GetSign %>';
                paramter.token = '<%= sskdModel.Token %>';
                paramter.timeUnix = new Date().getTime();
                $.ajax({
                    type: "post",
                    url: "/ajax/helper.ashx",
                    data: paramter,
                    dataType: "json",
                    async: true,
                    success: function (json) {
                        bwjsLoadingClose();
                        authResult(json);
                    },
                    complete: function (XMLHttpRequest, textStatus) {
                        bwjsLoadingClose();
                    },
                    error: function () {
                        bwjsLoadingClose();
                    }
                });
                return false;
            }

            //去下一步
            function nextStep() {
                if (allHasNotAuth != "") {
                    var msg = "继续完成 " + allHasNotAuth + " 的认证才可以继续下一步操作";
                    myAlert(msg);
                }
                bwjsLoadingDemo("努力加载中...");
                $("#jsForm").submit();
                return false;

                if (canSubmit) {
                    bwjsLoadingDemo("努力加载中...");
                    $("#jsForm").submit();
                }
                else {
                    if (allHasNotAuth != "") {
                        var msg = "继续完成 " + allHasNotAuth + " 的认证才可以继续下一步操作";
                        myAlert(msg);
                        return false;
                    }
                }
                return false;
            }


            function allMustIsAuth(must, hadAuthCodes) {
                var result = false;
                $(hadAuthCodes).each(function (index, value) {
                    if (isContains(must, value)) {
                        result = true;
                        return false;
                    }
                });
                return result;
            }

            function GetDesc(code) {
                var desc = "";
                switch (code) {
                    case "BASE_INFO":
                        desc = "申请信息";
                        break;
                    case "SELF_DESC":
                        desc = "自描述";
                        break;
                    case "FACE":
                        desc = "人像";
                        break;
                    case "BANK_CARD":
                        desc = "银行卡";
                        break;
                    case "SPIDER_MC":
                        desc = "运营商爬取";
                        break;
                    case "SPIDER_JD_SPIDER_TAOBAO_SPIDER_ALIPAY":
                        desc = "电商爬取";
                        break;
                    case "SPIDER_INSURE_SPIDER_FUND":
                        desc = "工作爬取";
                        break;
                }
                return desc;
            }

            var canSubmit = false;
            var allHasNotAuth = ""

            //认证进度结果处理
            function authResult(json) {
                var mustAuthDesc = ["申请信息", "自描述", "人像", "银行卡", "运营商爬取", "工作爬取", "电商爬取"];
                var allAuthCodes = json.data.allAuthCodes;
                var mustAuthCodes = json.data.mustAuthCodes;
                var hadAuthCodes = json.data.hadAuthCodes;
                mustAuthCodes.remove("BANK_CARD");
                mustAuthCodes.remove("SPIDER_INSURE_SPIDER_FUND");
                //alert(hadAuthCodes);
                $(mustAuthCodes).each(function (index, value) {
                    var must = value;
                    if (!allMustIsAuth(must, hadAuthCodes)) {
                        if (allHasNotAuth == "") {
                            allHasNotAuth = GetDesc(must);
                        }
                        else {
                            allHasNotAuth += "," + GetDesc(must);
                        }
                    }
                });

                //myAlert(allHasNotAuth);

                if (allHasNotAuth == "") {
                    canSubmit = true;
                }

                $(allAuthCodes).each(function (index, value) {
                    switch (value) {
                        case "SPIDER_MC"://运营商爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-mobie");
                                $("#sq-mobie").unbind("click");
                            }
                            break;
                        case "SPIDER_ALIPAY"://支付宝爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-zfbs");
                                $("#sq-zfbs").unbind("click");
                            }
                            break;
                        case "SPIDER_JD"://京东爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-jds");
                                $("#sq-jds").unbind("click");
                            }
                            break;
                        case "SPIDER_TAOBAO"://淘宝爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-tbs");
                                $("#sq-tbs").unbind("click");
                            }
                            break;
                        case "SPIDER_INSURE"://社保爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-sss");
                                $("#sq-sss").unbind("click");
                            }
                            break;
                        case "SPIDER_FUND"://公积金爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-gjjs");
                                $("#sq-gjjs").unbind("click");
                            }
                            break;
                        case "SPIDER_EMAIL"://邮箱爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-ms");
                                $("#sq-ms").unbind("click");
                            }
                            break;
                        case "SPIDER_ZX"://征信爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-rhzxs");
                                $("#sq-rhzxs").unbind("click");
                            }
                            break;
                        case "SPIDER_IBANK"://网银爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-wy");
                                $("#sq-wy").unbind("click");
                            }
                            break;
                        case "SPIDER_CHSI"://学信网爬取
                            if (hadAuthCodes.contains(value)) {
                                sqSpan("sq-xxs");
                                $("#sq-xxs").unbind("click");
                            }
                            break;
                        case "ID_CARD":
                            break;
                        case "TEL_NO":
                            break;
                    }
                });

            }

            var authStateCheckTimer;
            function authStateCheck() {
                if (canSubmit) {
                    clearTimeout(authStateCheckTimer);
                }
                else {
                    GetRzjd();
                    authStateCheckTimer = setTimeout(function () {
                        authStateCheck()
                    }
                    , 10000)
                }
            }

        </script>

        <script type="text/javascript">

            function querenLayer(msg, service, objId) {
                if ($("#confirmlayer").length > 0) {
                    $("#confirmlayer").remove();
                }
                var confirmHtml = "";
                confirmHtml += "<div class=\"mask2\" id=\"confirmlayer\">";
                confirmHtml += "<div class=\"pop-box-dhk\">";
                confirmHtml += "<span class=\"qr-msg\">" + msg + "</span>";
                confirmHtml += "<div class=\"col-lg-12 col-sm-12 col-xs-12\">";
                confirmHtml += "<div class=\"col-lg-1 col-sm-1 col-xs-1\">";
                confirmHtml += "</div>";
                confirmHtml += "<div class=\"col-lg-4 col-sm-4 col-xs-4\">";
                confirmHtml += "<span class=\"btn-y\" onclick=\"btnYes('" + service + "','" + objId + "');\">是</span>";
                confirmHtml += "</div>";
                confirmHtml += "<div class=\"col-lg-1 col-sm-1 col-xs-1\">";
                confirmHtml += "</div>";
                confirmHtml += "<div class=\"col-lg-1 col-sm-1 col-xs-1\">";
                confirmHtml += "</div>";
                confirmHtml += "<div class=\"col-lg-4 col-sm-4 col-xs-4\">";
                confirmHtml += "<span class=\"btn-n\" onclick=\"btnNo();\">否</span>";
                confirmHtml += "</div>";
                confirmHtml += "<div class=\"col-lg-1 col-sm-1 col-xs-1\">";
                confirmHtml += "</div>";
                confirmHtml += "</div>";
                confirmHtml += "</div>";
                confirmHtml += "</div";
                $("body").append(confirmHtml);
                //打开层
                $(".mask2").show();
            }

            function btnYes(service, objId) {
                bwjsLoadingDemo("努力加载中...");
                if ($("#" + objId).find("#tagspan").length > 0) {
                    $("#" + objId).remove("#tagspan");
                }
                //$("#" + objId).prepend("<span class=\"mask1\" id=\"tagspan\"><b class=\"bt\"><img src=\"/Content/img/NewSSKD/dot-sqz.png\" /></b></span>");
                $(".mask1").show();
                $(".mask2").hide();
                Showmcs(service, objId);
            }

            function btnNo() {
                $(".mask2").hide();
            }

            function sqSpan(objId) {
                if ($("#" + objId).find("span").length > 0) {
                    $("#" + objId).children("span").remove();
                }
                $("#" + objId).prepend("<span class=\"mask1\" id=\"tagspan\"><b class=\"bt\"><img src=\"/Content/img/NewSSKD/dot-sq.png\" /></b></span>");
                $(".mask1").show();
            }

            function initAuthenticationResults() {
                ///Product/NewSSKD/AuthorizationCertification?userId=193&outUniqueId=26772a40-9925-4726-a03c-9b2e04e082c1&state=login
                var userId = $.query.get("userId");
                var outUniqueId = $.query.get("outUniqueId");
                var state = $.query.get("state");
                var objId = $.query.get("objId");
                if (state != null && state != "" && objId != null && objId != "") {
                    if (state == "report" || state == "login" || state == "crawl") {
                        initSpan(objId);
                    }
                    var index = parent.layer.getFrameIndex(window.name);
                    parent.layer.close(index);
                }
            }

            function initSpan(objId) {
                if ($("#" + objId).find("span").length > 0) {
                    $("#" + objId).children("span").remove();
                }
                $("#" + objId).prepend("<span class=\"mask1\" id=\"tagspan\"><b class=\"bt\"><img src=\"/Content/img/NewSSKD/dot-sqz.png\" /></b></span>");
                $(".mask1").show();
            }

            function SetUrl(strUrl) {
                document.getElementById("ucBrowser").SetUrl(strUrl);
                //SetUrl("https://tianji.rong360.com/tianjiwapreport/login?data=nD%2BRaNTUBXKJrM1QPpIetGZIAU%2Bz5fjQWsSkUFo9nsbI2n7Utz4sDrlYyOKdFNPkdwvIkKnkU0XteCKRDrxJa91D4wqhLf40EYQZ7ldqYYzGxGv9AT9XijOhUfZuriHghW98fdMHhRQuUsM8DS2%2F9UtLMA7RPb%2Fo1lEoaCuKILknoF9RFhYJXBzeMeYRwrIWKea%2ByuMaeVqT64Wr9CXljnZ0a4PezF7tcHiolJXccYbdxQR4OGUQvtcImP%2BO0Shh");

                $(".mask6").fadeIn();

                $("#btnLayer").click(function () {
                    $(".mask6").fadeOut();
                })


                //$("#rong360Modal").modal("show");
                //alert(strUrl);
                //var a = document.getElementById("ucBrowser").GetStr();
                //myAlert(a);
            }
        </script>
    </form>
</body>
</html>
