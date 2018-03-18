<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSKDAddBackCard.aspx.cs" Inherits="BWJS.WebApp.Test.SSKDtest.SYtest.SSKDAddBackCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/Mofang/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js"></script>
    <title></title>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#next-pho").click(function () {
                bankCardAdd();
            });

        });

        function bankCardAdd() {
            var bankcardNo = "";
            if ($("#bankCardForm").valid()) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "INewNetLoan";
                paramter.action = "bankcardadd";
                paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                paramter.idcard = $.trim($("#iDCardNo").val());
                paramter.backcard = $.trim($("#bankCardNo").val());
                paramter.telNo = $("#telNo").val() + $.trim($("#telNo").val());
                paramter.captcna = $.trim($("#captcna").val());
                if (parseInt($("#hiddBankCardListLength").val()) == 0) {
                    paramter.cash = 1;s
                }
                else {
                    paramter.cash = 0;
                }
                paramter.token = $("#hiddToken").val();

                var json = getJson(paramter, false);
                //myAlert(JSON.stringify(json));
                if (json.success) {
                    bankcardNo = json.data.no;
                    $("#hiddNo").val(json.data.no);
                }
                else {
                    myAlert(json.message);
                }
            }
            return bankcardNo;
        }

        function getBankCardMobileValidCode(obj) {
            $("#k").rules("remove");
            if ($("#bankCardForm").valid()) {
                var no = $("#hiddNo").val();
                if (no == "") {
                    no = bankCardAdd();
                }
                if (no != "") {
                    validCodeTimer(obj);
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "netloan";
                    paramter.action = "bankcardsmscode";
                    paramter.realNameo = $.trim($("#realName").val());
                    paramter.idCardNo = $.trim($("#idCardNo").val());
                    paramter.bankCardNo = $.trim($("#bankCardNo").val());
                    paramter.telNo = $.trim($("#telNo").val());
                    var json = getJson(paramter, false);
                    if (json.success) {
                        $("#inpBankCardMobileValidCode").rules("add", { required: true });
                    } else {
                        myAlert(json.message);
                    }
                }
            }
        }
    </script>
</head>
<body>
    <div>
        <div class="show1">
            <form method="post" class="form-horizontal mar-top1" role="form" id="bankCardForm">
                <div class="col-sm-12">

                    <div class="form-group">
                        <label for="inpIdentityCardNumberForBankCard" class="col-sm-3 control-label">身份证号：</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" value="" name="inpIdentityCardNumberForBankCard" id="inpIdentityCardNumberForBankCard" placeholder="身份证号" required data-msg-required="不能为空" /><em>*</em>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpBankCardNo" class="col-sm-3 control-label">贮蓄卡号：</label>
                        <div class="col-sm-8">
                            <input type="text" value="" id="inpBankCardNo" name="inpBankCardNo" class="form-control" placeholder="银行卡号" required data-msg-required="不能为空" /><em>*</em>
                        </div>
                    </div>

                    <div class="form-group marb" id="divBankCardMobileValidCode">
                        <label for="inpBankCardMobileValidCode" class="col-sm-3 control-label">银行预留手机号：</label>
                        <div class="col-sm-8">
                            <div style="width: 100%; float: left">
                                <input type="text" id="inpBankCardMobileValidCode" name="inpBankCardMobileValidCode" style="width: 80%; float: left;" class="form-control" placeholder="请输入银行手机验证码" data-msg-required="不能为空" />
                                <input id="btnGetBankCardMobileValidCode" name="btnGetBankCardMobileValidCode" type="button" style="width: 18%; background-color: #30abcd; float: left; margin-left: 10px; margin-top: 2px; border: none; height: 30px; border-radius: 2px;" value="获取验证码" class="btn mar-btn  btn-danger " onclick="getBankCardMobileValidCode(this)" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpBankCardNo" class="col-sm-3 control-label">手机验证号：</label>
                        <div class="col-sm-8">
                            <input type="text" value="" id="inpBankCardNo" name="inpBankCardNo" class="form-control" placeholder="银行卡号" required data-msg-required="不能为空" /><em>*</em>
                        </div>
                    </div>

                </div>
                <div class="text-center">
                    <input id="next-pho" type="button" value="下一步" class="sub2" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
