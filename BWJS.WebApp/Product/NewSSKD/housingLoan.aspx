<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="housingLoan.aspx.cs" Inherits="BWJS.WebApp.Product.NewSSKD.housingLoan" %> 
<!DOCTYPE html> 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>填写信息</title>
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script> 
    <script src="/Scripts/pagecommon.js" type="text/javascript"></script>
    <!--身份证扫描js开始(顺序不要变)-->
    <script src="/Scripts/IDCard/jquery.jBox-2.3.min.js"></script>
    <script src="/Scripts/IDCard/baseISSObject.js"></script>
    <script src="/Scripts/IDCard/baseISSOnline.js"></script>
 <%--   <script src="/Scripts/IDCard/common.js"></script>--%>
    <!--身份证扫描js结束--> 
</head>
<body> 
       <!--遮罩弹窗显示是和否end-->
    <div class="main">
        <!--头部元素start-->
        <div class="head-box">
            <div class="col-lg-12">
                <!--申请成功移动字幕start-->
                <script src="/Scripts/NewSSKD/housing.js"></script>
            </div>
        </div>
        <!--头部元素end--> 
        <!--填写信息start-->
        <div class="formbox"> 
            <form class="form-horizontal mar-top1" role="form" id="jsForm" runat="server">
                <div class="col-sm-12 text-center til">
                    <span class="til1">房 贷 平 台</span>
                </div> 
                <div class="form-group">
                    <label for="personName" class="col-lg-2 col-sm-2 col-xs-2 control-label">姓 名：</label>
                    <div class="col-lg-7 col-sm-7 col-xs-7">
                        <input type="text" class="form-control" id="personName" name="personName" placeholder="请输入您中文姓名" disabled="disabled" style="background: #ddd" />
                    </div>
                    <div class="col-lg-3 col-sm-3 col-xs-3 text-left">
                        <div class="yzm-btn" onclick="new Device().startFun()" id="button_readID">身份证扫描</div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="certNumber" class="col-lg-2 col-sm-2 col-xs-2 control-label">身份证号：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" id="certNumber" name="certNumber" class="form-control" placeholder="请输入您的身份证号" required data-msg-required="扫描身份证" disabled="disabled" style="background: #ddd" />
                    </div> 
                </div>
                <div class="form-group">
                    <label for="inpMobile" class="col-lg-2 col-sm-2 col-xs-2 control-label">电 话：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpMobile" name="inpMobile" maxlength="11" class="form-control" placeholder="请输入您的电话号码" />
                    </div>
                </div> 
                <div class="form-group ma" style="margin-bottom: 18px;">
                    <label for="SeleCity3" class="col-lg-2 col-sm-2 col-xs-2 control-label">房子所在地址：</label> 
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpAddress" name="inpAddress" maxlength="50" class="form-control" placeholder="请输入房子所在地址" />
                    </div> 
                    <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-top: 100px;">
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                        <div class="col-lg-6 col-sm-6 col-xs-6">
                            <div class="next-btn mr" id="nextStep">确 定</div>
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <!--填写信息end--> 
    <script type="text/javascript">
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
            $("#personName").val(result.Certificate.Name);
            $("#certNumber").val(result.Certificate.IDNumber); 
            var sexpersonValue = (result.Certificate.Sex == "男" ? 1 : 0);
            var strPhotoBase64 = result.Certificate.Base64Photo;
            var idphotoSrc = "data:image/png;base64," + strPhotoBase64;
            var born = result.Certificate.Birthday.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
            var effectedDate = result.Certificate.IssuedData.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
            var expiredDate = result.Certificate.ValidDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
            var effectedDateForBankCard = result.Certificate.IssuedData.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1$2$3");
            effectedDateForBankCard = stringToJsTime_(effectedDateForBankCard);
          //  effectedDateForBankCard = effectedDateForBankCard.replace(".", "");
            var expiredDateForBankCard = result.Certificate.ValidDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1$2$3");
            expiredDateForBankCard = stringToJsTime_(expiredDateForBankCard);
           // expiredDateForBankCard = expiredDateForBankCard.replace(".", ""); 

           // modelIdentityCardLibrary.CompanyId = $("#hiddCompanyId").val();
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

          //  modelNetLoanApply.CompanyId = $("#hiddCompanyId").val();
            //modelNetLoanApply.FullName = result.Certificate.Name;
            //modelNetLoanApply.IdCardType = 1;
            //modelNetLoanApply.IdCard = result.Certificate.IDNumber;
            //modelNetLoanApply.Sex = sexpersonValue;
            //modelNetLoanApply.RecommendationCode = "";
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
        var companyId = 999;

        $(document).ready(function () { 
            bindFormInpKeyupEvent();
        });
        var modelIdentityCardLibrary = {};
        var modelNetLoanApply = {};  
    </script>

    <script type="text/javascript">

        function bindFormInpKeyupEvent() {
            $("#inpMobile").bind("blur", function () {
                formCheck();
            });
            $("#inpAddress").bind("blur", function () {
                formCheck();
            });
        }
        var flagSubmit = false;
        $(function () {
            $("#nextStep").bind("click", (function () {  
                if (flagSubmit) {
                    var checkresult = nextStepCheck();
                    if (checkresult) {
                        bwjsLoadingDemo("努力加载中...");
                        return netLoanApply();
                    }
                }
            }));
        });
        function formCheck() {
            if ($.trim($("#personName").val()) &&
            $.trim($("#certNumber").val()) &&
            $.trim($("#inpMobile").val()) &&
            $.trim($("#inpAddress").val())) {
                $("#nextStep").removeClass("mr");
                $("#nextStep").addClass("gl"); 
                flagSubmit= nextStepCheck(); 
            }
            else {
                $("#nextStep").removeClass("gl");
                $("#nextStep").addClass("mr");
                flagSubmit = false;
              //  $("#nextStep").unbind("click");
            }
        }

        function nextStepCheck() {
            if (!$("#personName").val() || !$("#certNumber").val()) {
                myAlert('请扫描本人身份证！');
                return false;
            }
            if (!$("#inpMobile").val()) {
                myAlert('请填写电话！');
                return false;
            }
            else {
                if (!mobileReg2.test($.trim($("#inpMobile").val()))) {
                    myAlert("电话格式不对");
                    return false;
                }
            }
            if (!$("#inpAddress").val()) {
                myAlert('请填写房子所在地！');
                return false;
            }
            return true;
        }

        function netLoanApply() {
            var netLoanApplyId = 0;
            try {
                if ($("#jsForm").valid()) { 
                    //if (JSON.stringify(modelIdentityCardLibrary) == "{}") {
                    //    modelIdentityCardLibrary.CompanyId = companyId;
                    //    modelIdentityCardLibrary.IdentityCardNumber = $("#certNumber").val();
                    //    modelIdentityCardLibrary.FullName = $("#personName").val();
                    //    modelIdentityCardLibrary.Sex = 0;
                    //    modelIdentityCardLibrary.Nation = "";
                    //    modelIdentityCardLibrary.BirthDay = new Date("1900-01-01");
                    //    modelIdentityCardLibrary.Address = "";
                    //    modelIdentityCardLibrary.IssuedAt = "";
                    //    modelIdentityCardLibrary.EffectedDate = new Date("1900-01-01");
                    //    modelIdentityCardLibrary.ExpiredDate = new Date("1900-01-01");
                    //    modelIdentityCardLibrary.IdentityCardPhotoPath = "";
                    //    modelIdentityCardLibrary.IdentityCardPhotoData = "";
                    //    modelIdentityCardLibrary.IdentityCardData = "";
                    //}
                    if (JSON.stringify(modelNetLoanApply) == "{}") {
                        modelNetLoanApply.CompanyId = companyId;
                        modelNetLoanApply.FullName = $("#personName").val();
                        modelNetLoanApply.IdCardType = 1;
                        modelNetLoanApply.IdCard = $("#certNumber").val();
                        modelNetLoanApply.Sex = 0;
                        modelNetLoanApply.RecommendationCode = "";
                    }
                    modelNetLoanApply.Mobile = $("#inpMobile").val();

                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "newnetloan";
                    paramter.action = "housingloanapply";
                    paramter.modelIdentityCardLibrary = JSON.stringify(modelIdentityCardLibrary);
                    paramter.modelNetLoanApply = JSON.stringify(modelNetLoanApply); 
                    //alert(JSON.stringify(paramter));
                    var json = getJson(paramter, false);
                    if (json.success) { 
                        netLoanApplyId = json.data;
                        //myAlert(json.message);
                        myAlert("您是房贷需求已提交，稍后会有专员客服与您联系,谢谢！！！");
                        $("#jsForm")[0].reset();
                    }
                }
            }
            catch (e) { myAlert(e.message); }
            return netLoanApplyId;
        }
        function stringToJsTime_(timeString) {
            var y = timeString.substring(0, 4);
            var m = timeString.substring(5, 7) - 1;
            var d = timeString.substring(8, 10);
            var h = timeString.substring(11, 13);
            var mm = timeString.substring(14, 16);
            var ss = timeString.substring(17, 19);
            var time = new Date(y, m, d, h, mm, ss, 0);
            return time;
        }
    </script>
</body>
</html>
