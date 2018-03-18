<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBankCard.aspx.cs" Inherits="BWJS.WebApp.Product.SSKD.AddBankCard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>添加银行卡</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/messages_zh.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <script type="text/javascript">
        var rules = {
            inpBankCardNo: {
                required: true,
                checkBankCardNo: true,
                maxlength: 23
            },
            inpMobileForBankCard: {
                required: true,
                chkMobile: true
            }
            //inpBankCardMobileValidCode: {
            //    required: true
            //}
        };
        $.validator.setDefaults({
            errorElement: 'span',
            rules: rules
        });

        //手机验证规则
        jQuery.validator.addMethod("chkMobile", function (value, element) {
            var mobile = /^1[3|4|5|6|7|8|9]\d{9}$/;
            return this.optional(element) || (mobile.test(value));
        }, "手机格式不对");
        jQuery.validator.addMethod("checkBankCardNo", function (value, element) {
            value = bankCardNoTrim(value, "g")
            return this.optional(element) || (luhmCheck(value));
        }, "银行卡号输入有误，请检查输入");


    </script>
</head>
<body>
    <!--头部元素start-->
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
                <ul>
                    <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot1.png"></span>人像采集</li>
                    <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot2.png"></span>授权认证</li>
                    <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot3.png"></span>评估报告</li>
                    <li class="" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot5.png"></span>选择银行卡</li>
                    <li class=""><span class="bg-r">
                        <img src="../../Content/img/NewSSKD/tab-dot4.png"></span>申请确认</li>


                </ul>
            </ul>
        </div>
        <!--步骤条end-->

        <!--添加银行卡start-->
        <div class="formbox">
            <form method="post" class="form-horizontal mar-top1" role="form" id="bankCardForm" action="/Product/NewSSKD/ApplyForConfirmation">
                <div class="col-sm-12 text-right" style="margin-top: 40px;">
                    <div class="form-group">
                        <label for="inpBankCardNolist" class="col-lg-3 col-sm-3 col-xs-3 control-label">已绑银行卡号：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8 text-left">
                            <select name="inpBankCardNolist" id="inpBankCardNolist" class="form-control"></select>
                            <span style="display: inline-block;"></span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpBankCardNo" class="col-lg-3 col-sm-3 col-xs-3 control-label">银行卡号：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8 text-left">
                            <input type="text" class="form-control" id="inpBankCardNo" name="inpBankCardNo" maxlength="23" placeholder="请输入有效银行卡号" required data-msg-required="不能为空" data-msg-age="用户唯一标识" />
                            <span style="display: inline-block;"></span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpMobileForBankCard" class="col-lg-3 col-sm-3 col-xs-3 control-label">银行预留手机号：</label>
                        <div class="col-lg-6 col-sm-6 col-xs-6 text-left">
                            <input type="text" class="form-control" value="" name="inpMobileForBankCard" id="inpMobileForBankCard" maxlength="11" onkeyup="this.value=this.value.replace(/\D/g,'');" placeholder="请输入有效银行预留手机号" required data-msg-required="不能为空" />
                            <span style="display: inline-block;"></span>
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                            <div class="yzm-btn" id="btnGetSmsCode">获取验证码</div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inpBankCardMobileValidCode" class="col-lg-3 col-sm-3 col-xs-3 control-label">手机短信验证码：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8">
                            <input type="text" value="" id="inpBankCardMobileValidCode" name="inpBankCardMobileValidCode" maxlength="6" onkeyup="this.value=this.value.replace(/\D/g,'');" class="form-control" placeholder="请输入手机短信验证码" />
                            <span style="display: inline-block;"></span>
                        </div>
                    </div>
                    <div class="col-lg-12 col-sm-12 col-xs-12">
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                        <div class="col-lg-6 col-sm-6 col-xs-6">
                            <div class="next-btn mr" id="nextStep">下一步</div>
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                    </div>
                </div>
                <input type="hidden" id="hidbankCardId" name="hidbankCardId" />
                <input type="hidden" id="hiddBankCardNo" name="hiddBankCardNo" />
                <input type="hidden" id="hiddBankCardNoForApply" name="hiddBankCardNoForApply" />
                <input type="hidden" id="hiddMobileForBankCard" name="hiddMobileForBankCard" />
            </form>
        </div>
    </div>
    <script type="text/javascript">
        var canSubmit = false;
        $(document).ready(function () {
            $("#inpBankCardNo").bind("keyup", function () {
                $(this).val(bankCardNoSplit($(this).val()));
            });

            getbankcardlist();
            $("#inpBankCardNolist").change(function () {
                bankCardNolistChange($(this).val());
            });

            formKeyupCheck();
        });

        function formKeyupCheck() {
            $("#inpBankCardNo").bind("keyup", function () { $("#bankCardForm").valid(); });
            $("#inpMobileForBankCard").bind("keyup", function () { $("#bankCardForm").valid(); });
            $("#inpBankCardMobileValidCode").bind("keyup", function () {
                if ($.trim($("#inpBankCardMobileValidCode").val()).length == 6) {
                    $("#nextStep").removeClass("mr");
                    $("#nextStep").addClass("gl");
                    if (!checkClickIsBind($("#nextStep"))) {
                        $("#nextStep").bind("click", function () {
                            BankCardSmsCodeCheck();
                        });
                    }
                }
                else {
                    $("#nextStep").removeClass("gl");
                    $("#nextStep").addClass("mr");
                    $("#nextStep").unbind("click");
                }
            });
        }

        function BankCardSmsCodeCheck() {
            if ($("#bankCardForm").valid()) {
                var isadd = true;
                var bankCardNo = bankCardNoTrim($.trim($("#inpBankCardNo").val()), "g");
                var telNo = $.trim($("#inpMobileForBankCard").val());
                var bankCardNoFromDB = $("#hiddBankCardNo").val();
                var telNoFromDB = $("#hiddMobileForBankCard").val();

                if (bankCardNo == bankCardNoFromDB && telNo == telNoFromDB) {
                    bootbox.setDefaults("locale", "zh_CN");
                    bootbox.confirm("确认使用此卡号和手机号码继续操作吗？", function (result) {
                        if (result) {
                            bwjsLoadingDemo("努力加载中...");
                            $("#bankCardForm").submit();
                            return false;
                        }
                    });
                }
                else {
                    bankCardCheck();
                }
            }
        }

        function bankCardCheck() {
            var bankCardMobileValidCode = $.trim($("#inpBankCardMobileValidCode").val());
            if (bankCardMobileValidCode == "") {
                myAlert("请输入验证码");
                return false;
            }
            else {
                if (!canSubmit) {
                    bwjsLoadingDemo("努力加载中...");
                    canSubmit = true;
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "newnetloan";
                    paramter.action = "bankcardsmscodecheck";
                    paramter.consultId = "<%=sskdModel.ConsultId%>";
                    paramter.code = $.trim($("#inpBankCardMobileValidCode").val());
                    paramter.bankCardId = $.trim($("#hidbankCardId").val());
                    paramter.token = '<%=sskdModel.Token%>';
                    paramter.sign = '<%= GetSign %>';
                    paramter.orderNo = '<%= sskdModel.OrderNo %>';
                    paramter.timeUnix = '<%=timeUnix %>';
                    paramter.merchantsNo = '<%=sskdModel.MerchantId %>';
                    paramter.equipmentNo = '<%=sskdModel.MachineId %>';
                    var json = getJson(paramter, false);
                    //myAlert(JSON.stringify(json));
                    if (json.success) {
                        $("#bankCardForm").submit();
                    }
                    else {
                        myAlert(json.message);
                        canSubmit = false;
                    }
                }
            }
        }

        function GetBankAddResult() {
            var result = false;
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "bankcardadd";
            paramter.realName = '<%=sskdModel.FullName%>';
            paramter.idCardNo = '<%=sskdModel.IDCardNo %>';
            paramter.bankCardNo = bankCardNoTrim($.trim($("#inpBankCardNo").val()), "g");
            paramter.telNo = $.trim($("#inpMobileForBankCard").val());
            paramter.sign = '<%=GetSign%>';
            paramter.orderNo = '<%=sskdModel.OrderNo%>';
            paramter.timeUnix = '<%=timeUnix%>';
            paramter.token = '<%=sskdModel.Token%>';
            paramter.consultId = '<%=sskdModel.ConsultId%>';
            paramter.merchantsNo = '<%=sskdModel.MerchantId%>';
            paramter.equipmentNo = '<%=sskdModel.MachineId%>';
            var json = getJson(paramter, false);
            if (json.success) {
                result = true;
                $("#hidbankCardId").val(json.data.bankCardId);
            }
            else {
                myAlert(json.message);
            }
            return result;
        }

        function getBankCardMobileValidCode(obj) {
            //$("#inpBankCardMobileValidCode").rules("remove");
            if ($("#bankCardForm").valid()) {
                var isadd = GetBankAddResult();
                if (isadd) {
                    getSmsCodeClick(obj);
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "newnetloan";
                    paramter.action = "bankcardsmscode";
                    paramter.realName = '<%=sskdModel.FullName%>';
                    paramter.idCardNo = '<%=sskdModel.IDCardNo %>';
                    paramter.bankCardNo = bankCardNoTrim($.trim($("#inpBankCardNo").val()), "g");
                    paramter.telNo = $.trim($("#inpMobileForBankCard").val());
                    paramter.sign = '<%=GetSign%>';
                    paramter.orderNo = '<%=sskdModel.OrderNo %>';
                    paramter.timeUnix = '<%=timeUnix%>';
                    paramter.token = '<%=sskdModel.Token%>';
                    paramter.consultId = '<%=sskdModel.ConsultId%>';
                    paramter.merchantsNo = '<%=sskdModel.MerchantId%>';
                    paramter.equipmentNo = '<%=sskdModel.MachineId%>';
                    var json = getJson(paramter, false);
                    if (json.success) {
                        //$("#inpBankCardMobileValidCode").rules("add", { required: true });
                        $("#nextStep").removeClass("mr");
                        $("#nextStep").addClass("gl");
                        if (!checkClickIsBind($("#nextStep"))) {
                            $("#nextStep").bind("click", function () {
                                BankCardSmsCodeCheck();
                            });
                        }

                    } else {
                        myAlert(json.message);
                        $("#nextStep").removeClass("gl");
                        $("#nextStep").addClass("mr");
                        $("#nextStep").unbind("click");
                    }
                }
            }
            return false;
        }

        var i = 60;
        function getSmsCodeClick(obj) {
            if (i == 1) {
                obj.removeClass("mr");
                obj.addClass("gl");
                obj.on("click", function () {
                    getBankCardMobileValidCode($(this));
                });
                obj.html("获取验证码");
                i = 60;
            }
            else {
                obj.removeClass("gl");
                obj.addClass("mr");
                obj.unbind("click");
                obj.html("重新发送(" + i + ")");
                i--;
                setTimeout(function () {
                    getSmsCodeClick(obj)
                }
                , 1000);
            }
            return false;
        }

        function getbankcardlist() {
            var html = "<option value=\"\">新增银行卡号</option>";
            var sskdRequestParas = {};
            sskdRequestParas.PageLoadDateTime = '<%=sskdRequestParas.PageLoadDateTime %>';
            sskdRequestParas.ConsultId = '<%=sskdModel.ConsultId %>';
            sskdRequestParas.Timestamp = '<%=sskdModel.TimeStamp %>';
            sskdRequestParas.OrderNo = '<%=sskdModel.OrderNo %>';
            sskdRequestParas.Sign = '<%=GetSign%>';
            sskdRequestParas.EquipmentNo = '<%=sskdModel.MachineId %>';
            sskdRequestParas.MerchantsNo = '<%=sskdModel.MerchantId %>';
            sskdRequestParas.Token = '<%=sskdModel.Token %>';
            sskdRequestParas.OrderSource = "BWPC";
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "bankcardlist";
            paramter.sskdRequestParas = JSON.stringify(sskdRequestParas);
            var json = getJson(paramter, false);
            if (json.success) {
                var bankCardId = "";
                var bankCardNo = "";
                var telNo = -1;
                $.each(json.data, function (index, value) {
                    var isSelected = "";
                    if (index == 0) {
                        isSelected = " selected=\"selected\"";
                        bankCardId = value.bankCardId;
                        bankCardNo = value.bankCardNo;
                        telNo = value.telNo;
                    }
                    html += "<option value=\"" + value.bankCardId + "," + value.telNo + "," + value.bankCardNo + "\"" + isSelected + ">" + value.bankCardNo + "</option>";
                });
                if (json.data.length > 0) {
                    $("#inpBankCardNo").val(bankCardNoSplit(bankCardNo));
                    $("#hiddBankCardNoForApply").val(bankCardNo);
                    $("#inpMobileForBankCard").val(telNo);
                    $("#hiddBankCardNo").val(bankCardNo);
                    $("#hiddMobileForBankCard").val(telNo);
                    $("#hidbankCardId").val(bankCardId);

                    $("#btnGetSmsCode").removeClass("gl");
                    $("#btnGetSmsCode").addClass("mr");
                    $("#btnGetSmsCode").unbind("click");
                    $("#inpBankCardNo").attr("disabled", true);
                    $("#inpMobileForBankCard").attr("disabled", true);
                    $("#inpBankCardMobileValidCode").attr("disabled", true);

                    $("#nextStep").removeClass("mr");
                    $("#nextStep").addClass("gl");
                    if (!checkClickIsBind($("#nextStep"))) {
                        $("#nextStep").bind("click", function () {
                            BankCardSmsCodeCheck();
                        });
                    }
                }
                else {
                }
            }
            else {
                //myAlert(json.message);
                $("#btnGetSmsCode").removeClass("mr");
                $("#btnGetSmsCode").addClass("gl");
                $("#inpBankCardNo").attr("disabled", false);
                $("#inpMobileForBankCard").attr("disabled", false);
                $("#inpBankCardMobileValidCode").attr("disabled", false);
                if (!checkClickIsBind($("#btnGetSmsCode"))) {
                    $("#btnGetSmsCode").bind("click", function () {
                        getBankCardMobileValidCode($(this));
                    });
                }

                $("#nextStep").removeClass("gl");
                $("#nextStep").addClass("mr");
                $("#nextStep").unbind("click");
            }
            $("#inpBankCardNolist").append(html);

        }

        function bankCardNolistChange(obj) {
            if (obj != "") {
                var bankCardNoArrayList = obj.split(",");
                $("#inpBankCardNo").val(bankCardNoSplit(bankCardNoArrayList[2]));
                $("#hiddBankCardNoForApply").val(bankCardNoArrayList[2]);
                $("#inpMobileForBankCard").val(bankCardNoArrayList[1]);
                $("#hiddBankCardNo").val(bankCardNoArrayList[2]);
                $("#hiddMobileForBankCard").val(bankCardNoArrayList[1]);
                $("#hidbankCardId").val(bankCardNoArrayList[0]);
                $("#inpBankCardNo").attr("disabled", true);
                $("#inpMobileForBankCard").attr("disabled", true);
                $("#inpBankCardMobileValidCode").attr("disabled", true);

                $("#btnGetSmsCode").removeClass("gl");
                $("#btnGetSmsCode").addClass("mr");
                $("#btnGetSmsCode").unbind("click");

                $("#nextStep").removeClass("mr");
                $("#nextStep").addClass("gl");
                if (!checkClickIsBind($("#nextStep"))) {
                    $("#nextStep").bind("click", function () {
                        BankCardSmsCodeCheck();
                    });
                }
            }
            else {
                $("#inpBankCardNo").val("");
                $("#hiddBankCardNoForApply").val("");
                $("#inpMobileForBankCard").val("");
                $("#hiddBankCardNo").val("");
                $("#hiddMobileForBankCard").val("");
                $("#hidbankCardId").val(-1);
                $("#inpBankCardNo").attr("disabled", false);
                $("#inpMobileForBankCard").attr("disabled", false);
                $("#inpBankCardMobileValidCode").attr("disabled", false);

                $("#btnGetSmsCode").removeClass("mr");
                $("#btnGetSmsCode").addClass("gl");
                if (!checkClickIsBind($("#btnGetSmsCode"))) {
                    $("#btnGetSmsCode").bind("click", function () {
                        getBankCardMobileValidCode($(this));
                    });
                }

                $("#nextStep").removeClass("gl");
                $("#nextStep").addClass("mr");
                $("#nextStep").unbind("click");
            }
        }

    </script>
</body>
</html>
