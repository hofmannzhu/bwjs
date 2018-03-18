<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorizationCertification.aspx.cs" Inherits="BWJS.WebPad.Product.SSKD.AuthorizationCertification" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <script>
        $(document).ready(function () {

            $(".head-btn").click(function () {
                $(".mask").fadeIn();
            });
            $(".btn-n").click(function () {
                $(".mask").fadeOut();
            });
            var state = "<%=state%>";
            var typename = "<%= typename %>";
            if (state == "report" || state == "login" || state == "crawl") {
                $("#sq-" + typename).prepend("<span class=\"mask1\" id=\"tagspan\"><b class=\"bt\"><img src=\"/Content/img/NewSSKD/dot-sqz.png\" /></b></span>");
            }

            sqBindClick();
            authStateCheck();
        });
    </script>
    <title></title>
    <style>
        .tab-box {
            height: 70px;
        }
    </style>
</head>
<body>


    <div class="mask">
        <div class="pop-box-dhk">
            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                <span class="qr-msg">您是否要取消申请吗？</span>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">

                <div class="col-lg-5 col-sm-5 col-xs-5">
                    <a href="home.aspx"><span class="btn-y">是</span></a>
                </div>
                <div class="col-lg-2 col-sm-2 col-xs-2">
                </div>
                <div class="col-lg-5 col-sm-5 col-xs-5">
                    <span class="btn-n">否</span>
                </div>

            </div>
        </div>
    </div>
    <!--遮罩弹窗显示是和否end-->


    <div class="main">
        <!--头部元素start-->
        <div class="head-box">
            <div class="col-lg-12">
                <!--申请成功移动字幕start-->
                <script src="/Scripts/NewSSKD/success.js"></script>
                <div class="col-lg-2 col-sm-2 col-xs-2">
                    <div class="head-btn">取消申请</div>
                </div>
            </div>
        </div>
        <!--头部元素end-->

        <!--步骤条start-->
        <div class="tab-box">
            <ul>
                <li class="bg-blue" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot1.png"></span>身份校验</li>
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
        <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NewSSKD/TheAppraisalReport">
            <div class="container">
                <div class="col-lg-12 col-sm-12 col-xs-12 text-center ma" style="margin-bottom: 0; margin-top: -6px;">
                    <div class="col-lg-4 col-sm-4 col-xs-4 ma">
                        <table class="table table-bordered row">
                            <caption class="ort">必 填 项</caption>
                            <tr>
                                <td>
                                    <div class="sq-box bg1" id="sq-mcs">
                                        <img class="dot" src="../../Content/img/NewSSKD/dot-sj.png" />
                                    </div>
                                    <p>手机运营认证</p>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-lg-8 col-sm-8 col-xs-8">
                        <table class="table table-bordered row">
                            <caption class="ort">三 选 一必填</caption>

                            <tr>
                                <td><%--style="border-bottom: 0; border-top: 0;"--%>
                                    <div class="sq-box bg2" id="sq-jds">
                                        <img class="dot" src="../../Content/img/NewSSKD/sq-dot6.png" />
                                    </div>
                                    <p>京 东</p>
                                </td>
                                <td>
                                    <div class="sq-box bg1" id="sq-zfbs">
                                        <img class="dot" src="../../Content/img/NewSSKD/sq-dot4.png" />
                                    </div>
                                    <p>支付宝</p>
                                </td>
                                <td>
                                    <div class="sq-box bg2" id="sq-tbs">
                                        <img class="dot" src="../../Content/img/NewSSKD/sq-dot5.png" />
                                    </div>
                                    <p>淘 宝</p>
                                </td>
                            </tr>
                        </table>

                    </div>
                </div>

                <div class="col-lg-12 col-sm-12 col-xs-12 text-center ma">
                    <table class="table table-bordered row">
                        <caption style="padding-top: 0px;">授信额度最高增加3万元</caption>
                        <tr>

                            <td>
                                <div class="sq-box bg1" id="sq-sss">
                                    <img class="dot" src="../../Content/img/NewSSKD/sq-dot2.png" />
                                </div>
                                <p>社 保</p>
                            </td>
                            <td>
                                <div class="sq-box bg2" id="sq-gjjs">
                                    <img class="dot" src="../../Content/img/NewSSKD/sq-dot3.png" />
                                </div>
                                <p>公 积 金</p>
                            </td>
                            <td>
                                <div class="sq-box bg3" id="sq-wy">
                                    <img class="dot" src="../../Content/img/NewSSKD/sq-dot10.png" />
                                </div>
                                <p>网 银</p>
                            </td>
                            <td>
                                <div class="sq-box bg2" id="sq-ms">
                                    <img class="dot" src="../../Content/img/NewSSKD/sq-dot9.png" />
                                </div>
                                <p>信  用 卡</p>
                            </td>
                            <td>
                                <div class="sq-box bg3" id="sq-xxs">
                                    <img class="dot" src="../../Content/img/NewSSKD/sq-dot7.png" />
                                </div>
                                <p>学 信 网</p>
                            </td>
                        </tr>
                    </table>
                    <!--授权认证end-->
                </div>
                <!--授权认证end-->
                <input id="hidsign" name="hidsign" type="hidden" value="<%=GetSign %>" />
                <input id="hididNo" name="IdNo" type="hidden" value="<%=sskdModel.IDCardNo %>" />
                <input id="hidtelNo" name="telNo" type="hidden" value="<%=sskdModel.Mobile %>" />
                <input id="hidrealName" name="realName" type="hidden" value="<%=sskdModel.FullName %>" />
                <input id="hidConsultId" name="hidConsultId" type="hidden" value="<%=sskdModel.ConsultId %>" />
                <input id="hidorderNo" name="orderNo" type="hidden" value="<%=sskdModel.OrderNo %>" />
                <input id="hidmerhcantNo" name="merhcantNo" type="hidden" value="<%=sskdModel.MerchantId %>" />
                <input id="hiddeviceNo" name="deviceNo" type="hidden" value="<%=sskdModel.MachineId %>" />
                <input id="hidtypeId" name="typeId" type="hidden" />
                <input id="hidstate" name="state" type="hidden" value="<%=state %>" />

                <script type="text/javascript">
                    function sqBindClick() {
                        $("#sq-mcs").click(function () {
                            querenLayer("您真的要申请授权吗？", "mcs", "sq-mcs");
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

                        $("#IsTypeStr").click(function () {
                            return nextStep();
                        })
                    }
                    //显示运营商页面
                    function Showmcs(type, objId) {
                        $("#hidtypeId").val(type);
                        if (type == "zfbs") {
                            android.rongAlipay();
                            $("#" + objId).prepend("<span class=\"mask1\" id=\"tagspan\"><b class=\"bt\"><img src=\"/Content/img/NewSSKD/dot-sqz.png\" /></b></span>");
                            //authStateCheck();
                            bwjsLoadingClose();

                        } else if (type == "tbs") {
                            android.rongTaoBao();
                            $("#" + objId).prepend("<span class=\"mask1\" id=\"tagspan\"><b class=\"bt\"><img src=\"/Content/img/NewSSKD/dot-sqz.png\" /></b></span>");
                            //authStateCheck();
                            bwjsLoadingClose();
                        } else {
                            submitClick(type, objId)
                        }
                    }

                    function submitClick(type) {

                        var paramter = {};
                        paramter.op = "bwjs";
                        paramter.om = "newnetloan";
                        paramter.action = "Checkmcs";
                        paramter.sign = $("#hidsign").val();
                        paramter.idNo = $("#hididNo").val();
                        paramter.telNo = $("#hidtelNo").val();
                        paramter.realName = $("#hidrealName").val();
                        paramter.ConsultId = $("#hidConsultId").val();
                        paramter.orderNo = $("#hidorderNo").val();
                        paramter.telNo = $("#hidtelNo").val();
                        paramter.typeId = $("#hidtypeId").val();
                        paramter.equipmentNo = '<%= sskdModel.MachineId %>';
                        paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
                        paramter.token = '<%= sskdModel.Token %>';
                        var json = getJson(paramter, false);
                        if (json.success) {
                            window.location.href = json.data.url;
                        }
                        else {
                            myAlert(json.message);
                        }
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
                            async: true,
                            type: 'post',
                            url: "/ajax/helper.ashx",
                            dataType: 'json',
                            data: paramter,
                            success: function (json) {
                                authResult(json);
                            }
                        })
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
                        mustAuthCodes.remove("BANK_CARD");
                        var hadAuthCodes = json.data.hadAuthCodes;
                        mustAuthCodes.remove("SPIDER_INSURE_SPIDER_FUND");


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
                                        sqSpan("sq-mcs");
                                        $("#sq-mcs").unbind("click");
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
                    //去下一步
                    function nextStep() {
                        //if (allHasNotAuth != "") {
                        //    var lindex = layer.load("请稍等...");
                        //    var msg = "继续完成 " + allHasNotAuth + " 的认证才可以继续下一步操作";
                        //    layer.close(lindex);
                        //    myAlert(msg);
                        //}
                        //var lindex1 = layer.load("请稍等...");
                        //$("#jsForm").submit();
                        //layer.close(lindex1);
                        //return false;

                        if (allHasNotAuth != "") {
                            var msg = "继续完成 " + allHasNotAuth + " 的认证才可以继续下一步操作";
                            myAlert(msg);
                            return false;
                        }
                        else {
                            if (canSubmit) {
                                bwjsLoadingDemo("努力加载中...");
                                $("#jsForm").submit();
                            }

                        }
                        return false;
                        //window.location.href = "/Product/NewSSKD/TheAppraisalReport";
                    }

                    function sqSpan(objId) {
                        if ($("#" + objId).find("span").length > 0) {
                            $("#" + objId).children("span").remove();
                        }
                        $("#" + objId).prepend("<span class=\"mask1\"><b class=\"bt\"><img src=\"/Content/img/NewSSKD/dot-sq.png\" /></b></span>");
                        $(".mask1").show();
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
                        //$(".mask1").show();
                        $(".mask2").hide();
                        Showmcs(service, objId);
                    }

                    function btnNo() {
                        $(".mask2").hide();
                    }

                </script>
            </div>
        </form>

        <div class="col-lg-12 col-sm-12 col-xs-12">
            <div class="col-lg-3 col-sm-3 col-xs-3">
            </div>
            <div class="col-lg-6 col-sm-6 col-xs-6">
                <a href="javascript:void(0)">
                    <div class="next-btn" id="IsTypeStr" style="margin-bottom: 10px; margin-top: 2px;">下 一 步</div>
                </a>
            </div>
            <div class="col-lg-3 col-sm-3 col-xs-3">
            </div>

        </div>

    </div>

</body>
</html>
