////////////////////////身份证扫描开始////////////////////////////////
var issOnlineUrl = "http://127.0.0.1:24010/ZKIDROnline";
var browserFlag = getBrowserType();
var setting = {
    Cert: {
        callBack: function (result) {
            setCertificateData(result);
        },
        select: "#button_readID"
    },
    Methods: {
        showMessage: function (type, message) {
            $("#cert_message").text(message);
            $("#cert_message_type").text(msgType[type]);
        },
        downloadDrive: function () {
            $.jBox.closeTip();
            messageBox({
                messageType: "confirm", text: "请安装相关硬件驱动！点击确定下载驱动。",
                callback: function (result) {
                    if (result) {
                        window.location.href = "middleware/ZKIDROnline.exe";
                    }
                    closeMessage();
                }
            });
        }
    }
}
createISSonlineDevice(setting);

function setCertificateData(result) {
    //$("#birthday").val(result.Certificate.Birthday.replace(/\./g, "-").substr(0, 10));
    //$("#certNumber").val(result.Certificate.IDNumber);
    //$("#idIssued").val(result.Certificate.IDIssued);
    //$("#issuedValidDate").val(result.Certificate.IssuedData + "-" + result.Certificate.ValidDate);

    //imgData = result.Certificate.Base64Photo;
    //$("#id_img_pers").attr("src", "data:image/jpg;base64," + imgData);
    //$("#personIdPhoto").val(imgData);
    //$("#personPhoto").val("");

    //$("#personName").val(result.Certificate.Name);
    //$("#gender").val(result.Certificate.Sex);
    //$("#nation").val(result.Certificate.Nation);
    //$("#address").val(result.Certificate.Address);
    //////////////////////////////////


    var sexpersonValue = (result.Certificate.Sex == "男" ? 1 : 0);
    var strPhotoBase64 = result.Certificate.Base64Photo;
    var idphotoSrc = "data:image/png;base64," + strPhotoBase64;
    var born = result.Certificate.Birthday.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
    var effectedDate = result.Certificate.IssuedData.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
    var expiredDate = result.Certificate.ValidDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
    var effectedDateForBankCard = result.Certificate.IssuedData.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1$2$3");
    effectedDateForBankCard = effectedDateForBankCard.replace(/\./g, '');
    var expiredDateForBankCard = result.Certificate.ValidDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1$2$3");
    expiredDateForBankCard = expiredDateForBankCard.replace(/\./g, '');
    $("#inpFullName").val(result.Certificate.Name);
    $("#inpIdentityCardNumber").val(result.Certificate.IDNumber);
    if (sexpersonValue == 1) {
        $("#inpSex1").attr('checked', 'checked');
    } else {
        $("#inpSex0").attr('checked', 'checked');
    }
    $("#inpIdPhoto").attr("src", idphotoSrc);
    //$("#divIdPhoto").show();
    $("#inpBirthDay").val(born);
    $("#inpNation").val(result.Certificate.Nation);
    $("#inpAddress").val(result.Certificate.Address);
    $("#inpIssuedAt").val(result.Certificate.IDIssued);
    $("#inpExpiredDate").val(effectedDateForBankCard + "-" + expiredDateForBankCard);
    $("#hiddEffectedDate").val(effectedDate);
    $("#hiddExpiredDate").val(expiredDate);
    modelIdentityCardLibrary.CompanyId = $("#hiddCompanyId").val();
    modelIdentityCardLibrary.IdentityCardNumber = result.Certificate.IDNumber;
    modelIdentityCardLibrary.FullName = result.Certificate.Name;
    modelIdentityCardLibrary.Sex = sexpersonValue;
    modelIdentityCardLibrary.Nation = result.Certificate.Nation;
    modelIdentityCardLibrary.BirthDay = born;
    modelIdentityCardLibrary.Address = result.Certificate.Address;
    modelIdentityCardLibrary.IssuedAt = result.Certificate.IDIssued;
    modelIdentityCardLibrary.EffectedDate = effectedDateForBankCard;
    modelIdentityCardLibrary.ExpiredDate = expiredDateForBankCard;
    modelIdentityCardLibrary.IdentityCardPhotoPath = "";
    modelIdentityCardLibrary.IdentityCardPhotoData = result.Certificate.Base64Photo;
    modelIdentityCardLibrary.base64Code = strPhotoBase64;
    modelIdentityCardLibrary.IdentityCardData = JSON.stringify(result.Certificate);

    modelNetLoanApply.CompanyId = $("#hiddCompanyId").val();
    modelNetLoanApply.FullName = result.Certificate.Name;
    modelNetLoanApply.IdCardType = 1;
    modelNetLoanApply.IdCard = result.Certificate.IDNumber;
    modelNetLoanApply.Sex = sexpersonValue;
    modelNetLoanApply.RecommendationCode = "";
}

function getRandomNum() {
    var random = parseInt(Math.random() * 10000);
    return random;
}

//消息控件的使用类型的类
var msgType =
{
    info: "info",
    success: "success",
    warning: "warning",
    error: "error",
    loading: "loading"
};

function getBrowserType() {
    var browserFlag = "";
    //是否支持html5的cors跨域
    if (typeof (Worker) !== "undefined") {
        browserFlag = "html5";
    }
        //此处判断ie8、ie9
    else if (navigator.userAgent.indexOf("MSIE 7.0") > 0 || navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE 9.0") > 0) {
        browserFlag = "simple";
    }
    else {
        browserFlag = "upgradeBrowser";//当前浏览器不支持该功能,请升级浏览器
    }
    return browserFlag;
}


function openMessage(type, text, ptimeout) {
    text = (text == "" ? null : text);
    var timeout = 1000;
    if (type == msgType.warning || type == msgType.info)//警告
    {
        timeout = 3000;
    }
    else if (type == msgType.success)//成功 
    {

        text = (text && text != null ? text : "操作成功");//${common_op_succeed}:操作成功
        var num = strlen(text) / 30;
        num = num > 8 ? 8 : num;
        timeout = Math.ceil(num) * timeout;//动态判断显示字符数的长度来延长显示时间
    }
    else if (type == msgType.error)//失败
    {
        text = (text && text != null) ? text : "操作失败";//${common_op_failed}:操作失败，程序出现异常
        timeout = 3000;
    }
    else if (type == msgType.loading)//处理中
    {
        timeout = 0;//当为'loading'时，timeout值会被设置为0，表示不会自动关闭。
        text = text && text != null ? text : "处理中";//${common_op_processing}:处理中
    }
    var width = strlen(text) * 6.1 + 45;//按字符计算宽度
    timeout = ptimeout ? ptimeout : timeout;
    $.jBox.tip(text, type, { timeout: timeout, width: (width > 400 ? 400 : "auto") });//设定最大宽度为400
}


function closeMessage(timeout) {
    timeout = timeout ? timeout : 1000;
    window.setTimeout("$.jBox.closeTip();", timeout);//设定最小等待时间
}

function strlen(str) {
    var len = 0;
    if (str != null) {
        for (var i = 0; i < str.length; i++) {
            var c = str.charCodeAt(i);
            if ((c >= 0x0001 && c <= 0x007e) || (0xff60 <= c && c <= 0xff9f)) {
                len++;
            }
            else {
                len += 2;
            }
        }
    }
    return len;
}

function messageBox(paramsJson) {

    this.messageType = paramsJson.messageType ? $.trim(paramsJson.messageType) : "confirm";
    this.types = "";
    if (paramsJson.type) {
        this.typeArray = paramsJson.type.split(" ");
        for (var i = 0; i < this.typeArray.length; i++) {
            this.types += this.typeArray[i] + " ";
        }
    }
    switch (this.messageType) {
        case "confirm":
            $.jBox.confirm(paramsJson.text, "提示", function (v, h, f) {
                if (v == "ok") {
                    paramsJson.callback(true);
                }
            });
            break;
    }
}
////////////////////////身份证扫描结束////////////////////////////////
var modelIdentityCardLibrary = {};
var modelNetLoanApply = {};
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

$(document).ready(function () {
    bindFormInpKeyupEvent();
});

function bindFormInpKeyupEvent() {
    $("#inpFullName").bind("keyup", function () {
        formCheck();
    });
    $("#inpIdentityCardNumber").bind("keyup", function () {
        formCheck();
    });
    $("#LoanAmountId").bind("keyup", function () {
        formCheck();
    });
    $("#LoanTermId").bind("change", function () {
        formCheck();
    });
    $("#LoanUseId").bind("change", function () {
        formCheck();
    });
    $("#inpMobile").bind("keyup", function () {
        formCheck();
    });
    $("#inpValidCode").bind("keyup", function () {
        formCheck();
    });
    $("#checkboxId").bind("change", function () {
        formCheck();
    });
}

var canSubmit = false;
function formCheck() {
    if ($.trim($("#inpFullName").val()) &&
    $.trim($("#inpIdentityCardNumber").val()) &&
    $.trim($("#LoanAmountId").val()) &&
    $.trim($("#LoanTermId").val()) &&
    $.trim($("#LoanUseId").val()) &&
    $.trim($("#inpMobile").val()) &&
    $.trim($("#inpValidCode").val()).length == 4 &&
    $("#checkboxId").prop("checked")) {
        $("#next-info").removeClass("mr");
        $("#next-info").addClass("gl");

        if (!checkClickIsBind($("#next-info"))) {
            $("#next-info").bind("click", function () {
                var checkresult = nextStepCheck();
                if (checkresult) {
                    if (!canSubmit) {
                        canSubmit = true;
                        return nextinfoClick();
                    }
                }
            });
        }
    }
    else {
        $("#next-info").removeClass("gl");
        $("#next-info").addClass("mr");
        $("#next-info").unbind("click");
    }
}

function nextStepCheck() {
    if (!$("#inpFullName").val() || !$("#inpIdentityCardNumber").val()) {
        myAlert('请扫描本人身份证！');
        return false;
    }
    if (!$("#LoanAmountId").val()) {
        myAlert('请填写借款金额！');
        return false;
    }
    if (!$("#LoanTermId").val()) {
        myAlert('请选择借款期限！');
        return false;
    }
    if (!$("#LoanUseId").val()) {
        myAlert('请选择借款用途！');
        return false;
    }
    if (!checkMoblie($("#inpMobile"))) {
        return false;
    }
    if ($("#sedMSM").val() !== "ok") {
        myAlert('请发送验证码！');
        return false;
    }
    var flag = VerificationCode();
    if (flag == 1) {
        myAlert('请输入验证码！');
        return false;
    } else if (flag == 2) {
        myAlert('验证码错误！');
        return false;
    } else if (flag == 3) {
        myAlert('非法操作！');
        return false;
    }
    if (!$("#checkboxId").prop("checked")) {
        myAlert('请阅读声明并勾选同意！');
        return false;
    }
    return true;
}

function VerificationCode() {

    var flag = 0;
    var ValidCode = $("#inpValidCode").val();
    var HidMoblie = $("#hidMoblie").val();
    if (!ValidCode) {
        flag = 1;
    }
    if (ValidCode != $("#NumberId").val()) {
        flag = 2;
    }
    if (HidMoblie != $("#inpMobile").val()) {
        flag = 3;
    }
    return flag;
};

//存入我方库
function nextinfoClick() {
    var fullName = $.trim($("#inpFullName").val());
    var identityCardNumber = $.trim($("#inpIdentityCardNumber").val());
    var loanAmount = $.trim($("#LoanAmountId").val());
    var loanTerm = $.trim($("#LoanTermId").val());
    var loanUse = $.trim($("#LoanUseId").val());
    var mobile = $.trim($("#inpMobile").val());
    //jsForm

    var ConsultId = 0;
    var Consult = {};
    Consult.FullName = $("#inpFullName").val();
    Consult.Mobile = $("#inpMobile").val();
    Consult.IDNo = $("#inpIdentityCardNumber").val();
    Consult.LoanAmount = $("#LoanAmountId").val();
    Consult.LoanTerm = $("#LoanTermId").val();
    Consult.LoanUse = $("#LoanUseId").val();
    //// 开始 身份证读取相关信息 ////
    Consult.sex = modelIdentityCardLibrary.Sex;//性别
    Consult.national = modelIdentityCardLibrary.Nation;//民族
    Consult.birth = modelIdentityCardLibrary.BirthDay;//出生日期
    Consult.address = modelIdentityCardLibrary.Address;//住址
    Consult.authority = modelIdentityCardLibrary.IssuedAt;//签发机关
    Consult.validperiod = modelIdentityCardLibrary.EffectedDate + "-" + modelIdentityCardLibrary.ExpiredDate;
    Consult.faceId = 12;
    Consult.magId = $("#hidmagId").val();
    //// 结束 身份证读取相关信息 //// 

    var sskdRequestParas = {};
    sskdRequestParas.PageLoadDateTime = $("#hiddPageLoadDateTime").val();

    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "InsertConsult";
    paramter.Consult = JSON.stringify(Consult);
    paramter.equipmentNo = $.trim($("#hiddEquipmentNo").val());
    paramter.merchantsNo = $.trim($("#hiddMerchantsNo").val());
    paramter.base64Code = modelIdentityCardLibrary.base64Code;
    paramter.sskdRequestParas = JSON.stringify(sskdRequestParas);

    bwjsLoadingDemo("努力加载中...");
    $("#next-info").removeClass("gl");
    $("#next-info").addClass("mr");
    $("#next-info").unbind("click");
    var json = getJson(paramter, false);
    if (json.success) {
        $("#hiddTimeStamp").val(json.data.TimeStamp);
        $("#hiddToken").val(json.data.Token);
        $("#hidConsultId").val(json.data.ConsultId);
        $("#hidIDNo").val(json.data.IDNo);
        $("#hidMobile").val(json.data.Mobile);
        $("#hidOrderNo").val(json.data.OrderNo);

        $("#hiddFullName").val(json.data.FullName);// 身份证姓名
        $("#hiddSex").val(json.data.Sex);//性别
        $("#hiddBirth").val(json.data.Birth);//出生年月
        $("#hiddNational").val(json.data.National);//民族
        $("#hiddAddress").val(json.data.Address);//住址
        $("#hiddAuthority").val(json.data.Authority);//签发机关
        $("#hiddValidperiod").val(json.data.Validperiod);//有效期

        $("#jsForm").submit();
    }
    else {
        myAlert(json.message);
        canSubmit = false;
    }
    return false;
}

function checkMobile() {
    var mobile = $.trim($("#inpMobile").val());
    if (mobile == "") {
        myAlert("请输入手机号码");
    }
    else {
        var reqdata =
            {
                telNo: mobile,
                netLoanApplyId: 0
            };
        var paramter = {};
        paramter.op = "bwjs";
        paramter.om = "netloan";
        paramter.action = "checkmonbileisregister";
        paramter.telNo = mobile;
        paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
        paramter.reqdata = JSON.stringify(reqdata);
        var json = getJson(paramter, false);
        //myAlert(JSON.stringify(json));
        if (json.success) {
            $("#hiddMemberFlag").val(json.data.flag)
        }
    }
}

var clock = '';
var nums = 20;
var btn;
function settime(thisBtn) {
    btn = thisBtn;
    btn.classList.remove("gl");
    btn.classList.add("mr");
    btn.disabled = true; //将按钮置为不可点击
    btn.value = '重新发送(' + nums + ')';
    clock = setInterval(doLoop, 1000); //一秒执行一次
};

function VinpMobile() {
    var b = true;
    var moblie = $("#inpMobile").val();
    if (!moblie) {
        $("#ValidCodeBT").attr("disabled", "disabled");
        $("#spanMobileId").show();
        b = false;
    } else {
        var isIDCard2 = /^1[3|4|5|6|7|8|9][0-9]{9}$/; //验证规则
        var lengthvalue = document.getElementById('inpMobile').value.length;
        if (lengthvalue == 11) {
            if (isIDCard2.test(document.getElementById('inpMobile').value) === false) {
                $("#ValidCodeBT").attr("disabled", "disabled");
                $("#spanMobileId").show();
                b = false;
            }
        } else {
            $("#ValidCodeBT").attr("disabled", "disabled");
            $("#spanMobileId").show();
            b = false;
        }
    };
    if (b) {
        $("#ValidCodeBT").removeAttr("disabled");
        $("#spanMobileId").hide();
    }
};

function sendCode(thisBtn) {
    var moblie = $("#inpMobile");
    var c = true;
    c = checkMoblie(moblie);
    if (c) {
        settime(thisBtn);
        $.ajax({
            url: '/Ajax/MofangOrder/ValidCode.ashx',
            type: 'post',
            dataType: 'json',
            timeout: 0,
            async: true,
            data: {
                Action: "ValidCodeAction",
                moblie: moblie.val()
            },
            success: function (result) {
                if (result.isSend == "ok") {
                    $("#sedMSM").val("ok");
                    $("#NumberId").val(result.number);
                    $("#hidMoblie").val(result.moblie);
                }
                else {
                    $("#sedMSM").val("");
                    $("#NumberId").val("");
                }

            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                if (textStatus != 'timeout') {
                    //   alert(xmlHttpRequest.responseText);
                } else {
                }
            }
        });
    }

}

function doLoop() {
    nums--;
    if (nums > 0) {
        btn.value = '重新发送(' + nums + ')';
    } else {
        clearInterval(clock);
        btn.disabled = false;
        btn.value = '获取验证码';
        nums = 20; //重置时间
        btn.classList.remove("mr");
        btn.classList.add("gl");
    }
}
