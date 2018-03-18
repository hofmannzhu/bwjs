<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBankCard.aspx.cs" Inherits="BWJS.WebPad.Product.SSKD.AddBankCard" %>

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
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <script src="/Scripts/messages_zh.min.js"></script>
    <script type="text/javascript">
        var rules = {
            //inpBankCardNo: {
            //    required: true,
            //    checkBankCardNo: true,
            //    maxlength: 23
            //},
            inpMobileForBankCard: {
                required: true,
                chkMobile: true
            }
            //,
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
        }, "手机格式不正确");
        jQuery.validator.addMethod("checkBankCardNo", function (value, element) {
            return this.optional(element) || (luhmCheck(value));
        }, "银行卡号输入有误，请检查输入");



        $(document).ready(function () {
            $(".head-btn").click(function () {
                $(".mask").fadeIn();
            });

            $(".btn-n").click(function () {
                $(".mask").fadeOut();
            });
        })


    </script>

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
    <!--头部元素start-->
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
                <ul>
                    <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot1.png"></span>身份校验</li>
                    <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot2.png"></span>授权认证</li>
                    <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot3.png"></span>评估报告</li>
                    <li class="" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot5.png"></span>添加银行卡</li>
                    <li class=""><span class="bg-r">
                        <img src="../../Content/img/NewSSKD/tab-dot4.png"></span>申请确认</li>


                </ul>
            </ul>
        </div>
        <!--步骤条end-->

        <!--添加银行卡start-->
        <div class="formbox">
            <form method="post" class="form-horizontal mar-top1" role="form" id="bankCardForm" action="/Product/NewSSKD/ApplyForConfirmation">
                <div class="col-sm-12  text-right">
                    <div class="form-group">
                        <label for="inpBankCardNo" class="col-lg-3 col-sm-3 col-xs-3 control-label">已绑银行卡号：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8 text-left">
                            <select name="inpBankCardNolist" id="inpBankCardNolist" class="form-control">
                            </select>

                        </div>
                    </div>
                    <div class="form-group">
                        <input type="hidden" id="inpBankCardNo1" />
                        <label for="inpBankCardNo" class="col-lg-3 col-sm-3 col-xs-3 control-label">银行卡号：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8 text-left">
                            <input type="text" class="form-control" id="inpBankCardNo" name="inpBankCardNo" onkeyup="CheckbankNum(this)" maxlength="30" placeholder="请输入有效银行卡号" data-msg-required="不能为空" data-msg-age="用户唯一标识" required autocomplete="off" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpMobileForBankCard" class="col-lg-3 col-sm-3 col-xs-3 control-label">银行预留手机号：</label>
                        <div class="col-lg-6 col-sm-5 col-xs-5 text-left">
                            <input type="text" class="form-control" value="" name="inpMobileForBankCard" id="inpMobileForBankCard" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="11" placeholder="请输入有效银行预留手机号"  data-msg-required="不能为空" required autocomplete="off" />
                        </div>
                        <div class="col-lg-2 col-sm-4  col-xs-4" style="margin-left: -9%">
                            <%-- <div class="yzm-btn" id="btnGetSmsCode">获取验证码</div>--%>
                            <input type="button" class="yzm-btn gl" style="color: white; margin-left: 30px" id="btnGetSmsCode" onclick="getBankCardMobileValidCode(this)" value="点击发送验证码" />
                            <!-- <input class="yzm-btn" type="button" onclick="getBankCardMobileValidCode(this)" value="获取验证码" />-->
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inpBankCardMobileValidCode" class="col-lg-3 col-sm-3 col-xs-3 control-label">手机短信验证码：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8">
                            <input type="text" value="" id="inpBankCardMobileValidCode" name="inpBankCardMobileValidCode" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="6" class="form-control" placeholder="请输入手机短信验证码" data-msg-required="不能为空" autocomplete="off" />
                        </div>
                    </div>

                </div>
                <div class="col-lg-12 col-sm-12 col-xs-12">
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                    </div>
                    <div class="col-lg-6 col-sm-6 col-xs-6">
                        <div class="next-btn" id="nextStep">下一步</div>
                    </div>
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                    </div>
                </div>
                <div class="modal fade" id="loading" tabindex="-1" role="dialog" aria-labelledby="loadingModalLabel" data-backdrop="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-body">
                                <img src="/Content/img/loadingsmall.gif" />
                                处理中，请稍候。。。
                            </div>
                        </div>
                    </div>
                </div>
                <input type="hidden" id="hidbankCardId" name="hidbankCardId" />
                <input type="hidden" id="hiddBankCardNo" name="hiddBankCardNo" />
                <input type="hidden" id="hiddBankCardNoForApply" name="hiddBankCardNoForApply" />
                <input type="hidden" id="hiddMobileForBankCard" name="hiddMobileForBankCard" />
                <input type="hidden" id="hiddFlag" name="hiddFlag" value="0" />
            </form>
        </div>

    </div>
    <script type="text/javascript">
        var canSubmit = false;
        $(document).ready(function () {
            GetBankCardList();
            //getbankcardlistbytwoelements();

            $("#nextStep").click(function () {
                if (!canSubmit) {
                    canSubmit = true;
                    BankCardSmsCodeCheck();
                }
            });

            //$("#btnGetSmsCode").click(function () {
            //    getBankCardMobileValidCode($(this));
            //});

            $("select#inpBankCardNolist").change(function () {
                var oo = $(this).val();
                if (oo == "0") {
                    disabledfalse();
                } else {
                    disabledtrue(oo);
                }
            });
            formKeyupCheck();
        });


        function disabledtrue(oo) {
            var str;
            if (oo != "") {
                str = oo.split(',');
                $('#inpBankCardNo').val(str[2]);
                $('#inpBankCardNo1').val(str[2]);
                $("#hiddBankCardNoForApply").val(str[2]);
                $('#inpMobileForBankCard').val(str[1]);
            }
            $('#inpBankCardNo').attr('disabled', true);
            $('#inpMobileForBankCard').attr('disabled', true);
            $('#inpBankCardMobileValidCode').attr('disabled', true);
            $('#btnGetSmsCode').attr('disabled', true);

        }

        function disabledfalse() {
            $('#inpBankCardNo').val("");
            $('#inpBankCardNo1').val("");
            $("#hiddBankCardNoForApply").val("");
            $('#inpMobileForBankCard').val("");
            $('#inpBankCardMobileValidCode').val("");
            $('#inpBankCardNo').attr('disabled', false);
            $('#inpMobileForBankCard').attr('disabled', false);
            $('#inpBankCardMobileValidCode').attr('disabled', false);
            $('#btnGetSmsCode').attr('disabled', false);
        }

        var nn = 0;
        function GetBankCardList() {
            var html = "<option value=\"0\">新增银行卡号</option>";
            try {
                var sskdRequestParas = {};
                sskdRequestParas.timestamp = '<%=timeUnix%>';
                sskdRequestParas.orderNo = '<%=sskdModel.OrderNo%>';
                sskdRequestParas.sign = '<%=GetSign%>';
                sskdRequestParas.equipmentNo = '<%=sskdModel.MachineId%>';
                sskdRequestParas.merchantsNo = '<%=sskdModel.MerchantId%>';
                sskdRequestParas.token = '<%=sskdModel.Token%>';
                sskdRequestParas.orderSource = "BWPAD";
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "newnetloan";
                paramter.action = "bankcardlist";
                paramter.sskdRequestParas = JSON.stringify(sskdRequestParas);
                bwjsLoadingDemo("努力加载中...");
                var json = getJson(paramter, false);
                if (json.success) {
                    var bankCardList = json.data;
                    $.each(json.data, function (key, value) {
                        var bankstr = '';
                        if (value.bankCardNo.length > 0) {
                            bankstr = value.bankCardNo;
                        }
                        nn = nn + 1;
                        html += "<option value=\"" + value.bankCardId + "," + value.telNo + "," + formatfro(bankstr) + "   \">" + formatfro(bankstr) + "</option>";
                    });
                }
                else {
                    myAlert(json.message);
                }

                $("#inpBankCardNolist").append(html);
                $('#inpBankCardNolist option:last').attr('selected', 'selected');
                if (nn > 0) {
                    disabledtrue($("#inpBankCardNolist").val());
                }
            }
            catch (e) {
                myAlert(e.message);
            }
        }


        function formKeyupCheck() {
            $("#inpBankCardNo").blur(function () { $("#bankCardForm").valid(); });
            $("#inpMobileForBankCard").blur(function () { $("#bankCardForm").valid(); });
        }


        function BankCardSmsCodeCheck() {
            var options = $("#inpBankCardNolist option:selected");
            if (options.text() == "新增银行卡号") {
                if ($("#bankCardForm").valid()) {
                    var isadd = bankCardCheck();
                    var bankCardNo = $.trim($("#inpBankCardNo").val().replace(/\s/g, ""));
                    var telNo = $.trim($("#inpMobileForBankCard").val());
                    var bankCardNoFromDB = $("#hiddBankCardNo").val();
                    var telNoFromDB = $("#hiddMobileForBankCard").val();
                    var flagFromDB = parseInt($("#hiddFlag").val());
                    //if (bankCardNo == bankCardNoFromDB && telNo == telNoFromDB) {
                    //    if (flagFromDB == 1) {
                    //        bootbox.setDefaults("locale", "zh_CN");
                    //        bootbox.confirm("此卡号和手机号已验证成功，点击确定直接进行下一步或点击取消填写可以修改卡号和手机号码继续验证", function (result) {
                    //            if (result) {
                    //                //var lindex = layer.load("请稍等...");
                    //                $("#bankCardForm").submit();
                    //                //layer.close(lindex);
                    //                return false;
                    //            }

                    //        });
                    //    } else {
                    //        bankCardCheck();
                    //    }
                    //}
                    //else {
                    //        bankCardCheck();
                    //}
                }
            } else {
                $("#bankCardForm").submit();
                return false;
            }
        }
        function bankCardCheck() {
            var bankCardMobileValidCode = $.trim($("#inpBankCardMobileValidCode").val());
            if (bankCardMobileValidCode == "") {
                canSubmit = false;
                myAlert("请输入验证码");
                return false;
            }
            else {
                bwjsLoadingDemo("努力加载中...");
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "newnetloan";
                paramter.action = "bankcardsmscodecheck";
                paramter.consultId = '<%=sskdModel.ConsultId%>';
                paramter.code = $.trim($("#inpBankCardMobileValidCode").val());
                paramter.bankCardId = $.trim($("#hidbankCardId").val());
                paramter.token = '<%=sskdModel.Token%>';
                paramter.sign = '<%= GetSign %>';
                paramter.orderNo = '<%= sskdModel.OrderNo %>';
                paramter.timeUnix = '<%=timeUnix %>';
                paramter.merchantsNo = '<%=sskdModel.MerchantId %>';
                paramter.equipmentNo = '<%=sskdModel.MachineId %>';
                var json = getJson(paramter, false);
                if (json.success) {
                    $("#bankCardForm").submit();
                }
                else {
                    canSubmit = false;
                    myAlert(json.message);
                }
            }

        }

        function GetBankAddResult() {
            bwjsLoadingDemo("努力加载中...");
            var result = false;
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "bankcardadd";
            paramter.realName = '<%=sskdModel.FullName%>';
            paramter.idCardNo = '<%=sskdModel.IDCardNo %>';
            paramter.bankCardNo = $.trim($("#inpBankCardNo").val().replace(/\s/g, ""));
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
                if (json.message == '银行卡已经存在') {
                    bootbox.setDefaults("locale", "zh_CN");
                    bootbox.confirm("此卡号和手机号已验证成功，点击确定直接进行下一步或点击取消填写可以修改卡号和手机号码继续验证", function (result) {
                        if (result) {
                            //var lindex = layer.load("请稍等...");
                            $("#bankCardForm").submit();
                            //layer.close(lindex);
                            return false;
                        }
                    });
                }
            }
            return result;
        }
        function checkCardMobile() {
            if (!$.trim($("#inpBankCardNo").val().replace(/\s/g, ""))) {
                myAlert("银行卡号不能为空哦~");
                return;
            }
            if (!$.trim($("#inpMobileForBankCard").val())) {
                myAlert("手机号不能为空哦~");
                return;
            }
            return true;
        }
        function getBankCardMobileValidCode(obj) {
            //$("#inpBankCardMobileValidCode").rules("remove"); 
            if ($("#bankCardForm").valid()) {
                if (checkCardMobile()) {
                    var isadd = GetBankAddResult();
                    var bankCardNo = $.trim($("#inpBankCardNo").val().replace(/\s/g, ""));
                    var telNo = $.trim($("#inpMobileForBankCard").val());
                    var bankCardNoFromDB = $("#hiddBankCardNo").val();
                    var telNoFromDB = $("#hiddMobileForBankCard").val();
                    var flagFromDB = $("#hiddFlag").val();
                    //if (bankCardNo == bankCardNoFromDB && telNo == telNoFromDB) {
                    //    if (flagFromDB == 1) {
                    //        bootbox.setDefaults("locale", "zh_CN");
                    //        bootbox.confirm("此卡号和手机号已验证成功，点击确定直接进行下一步或点击取消填写可以修改卡号和手机号码继续验证", function (result) {
                    //            if (result) {
                    //                bwjsLoadingDemo("努力加载中...");
                    //                isadd = false;
                    //                $("#bankCardForm").submit();
                    //                return false;
                    //            }
                    //            //else {
                    //            //    //isadd = GetBankAddResult();
                    //            //}
                    //        });
                    //    }
                    //    else {
                    //        isadd = true;
                    //    }
                    //}
                    //else {
                    //    isadd = GetBankAddResult();
                    //}

                    if (isadd) {
                        bwjsLoadingDemo("努力加载中...");
                        getSmsCodeClick(obj);
                        var paramter = {};
                        paramter.op = "bwjs";
                        paramter.om = "newnetloan";
                        paramter.action = "bankcardsmscode";
                        paramter.realName = '<%=sskdModel.FullName%>';
                        paramter.idCardNo = '<%=sskdModel.IDCardNo %>';
                        paramter.bankCardNo = $.trim($("#inpBankCardNo").val().replace(/\s/g, ""));
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

                        } else {
                            myAlert(json.message);
                        }
                    }
                }
            }
            return false;
        }


        function doLoop() {
            nums--;
            if (nums > 0) {
                btn.value = '重新发送(' + nums + ')';
            } else {
                clearInterval(clock); //清除js定时器
                btn.disabled = false;
                btn.value = '获取验证码';
                nums = 60; //重置时间
                btn.classList.remove("mr");
                btn.classList.add("gl");
            }
        }

        var clock = '';
        var nums = 60;
        var btn;
        function getSmsCodeClick(obj) {
            btn = obj;
            btn.classList.remove("gl");
            btn.classList.add("mr");
            btn.disabled = true; //将按钮置为不可点击
            btn.value = '重新发送(' + nums + ')';
            clock = setInterval(doLoop, 1000); //一秒执行一次
            //if (i == 1) {
            //    obj.removeClass("mr");
            //    obj.addClass("gl");
            //    obj.on("click", function () {
            //        getBankCardMobileValidCode($(this));
            //    });
            //    obj.html("获取验证码");
            //    i = 60;
            //}
            //else {
            //    obj.classList.remove("gl");
            //    obj.classList.add("mr");
            //    //obj.removeClass("gl");
            //    //obj.addClass("mr");
            //    obj.disabled = true; //将按钮置为不可点击
            //    //obj.unbind("click");

            //    obj.html("重新发送(" + i + ")");
            //    i--;
            //    setTimeout(function () {
            //        getSmsCodeClick(obj)
            //    }
            //    , 1000);
            //}
            return false;
        }

        function checkMoblie(moblie) {
            var c = true;
            if (!moblie.val()) {
                myAlert('手机号不能为空！');
                c = false;
                return c;
            } else {
                var isIDCard2 = /^1[3|4|5|6|7|8|9][0-9]{9}$/; //验证规则
                var lengthvalue = moblie.val().length;
                if (lengthvalue == 11) {
                    if (isIDCard2.test(moblie.val()) === false) {
                        myAlert('手机号输入不合法,请重新填写!');
                        moblie.val("");
                        c = false;
                        return c;
                    }
                } else {
                    myAlert('手机号位数不正确！');
                    moblie.val("");
                    c = false;
                    return c;
                }
            }
            return c;
        }

        function getbankcardlistbytwoelements() {
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "getbankcardlistbytwoelements";
            paramter.realName = '<%=sskdModel.FullName %>';
            paramter.idCardNo = '<%=sskdModel.IDCardNo %>';
            paramter.token = '<%=sskdModel.Token %>';
            paramter.consultId = '<%=sskdModel.ConsultId %>';
            var json = getJson(paramter, false);
            if (json.success) {
                if (json.data != null && json.data != "") {
                    var num = 0;
                    var list = json.data;
                    var str = list[0].BankCardNo;
                    var bankstr = '';
                    if (str.length > 0) {
                        bankstr = formatfro(str);
                    }
                    $("#inpBankCardNo").val(bankstr);
                    $("#hiddBankCardNoForApply").val(list[0].BankCardNo);
                    $("#inpMobileForBankCard").val(list[0].TelNo);
                    $("#hiddBankCardNo").val(list[0].BankCardNo);
                    $("#hiddMobileForBankCard").val(list[0].TelNo);
                    $("#hiddFlag").val(list[0].Flag);
                    $("#hidbankCardId").val(list[0].No);
                }
            }
        }


        function formatfro(str) {
            var bankstr = '';
            var c = str.replace(/\s/g, "");
            for (var i = 1; i < c.length + 1; i++) {
                if (i % 4 == 0) {
                    num = i;
                    bankstr += c.substring(i - 4, i) + " ";
                }
            }
            bankstr += c.substring(num, c.length)
            return bankstr;
        }

        function CheckbankNum(obj) {
            obj.value = obj.value.replace(/\D/g, "");
            obj.value = obj.value.replace(/[\s]/g, '').replace(/(\d{4})(?=\d)/g, "$1 ");//不换行
        }
    </script>
</body>
</html>
