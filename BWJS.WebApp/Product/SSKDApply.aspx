<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSKDApply.aspx.cs" Inherits="BWJS.WebApp.Product.SSKDApply" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
    <script type="text/javascript">
        function pageBack()
        {
            $("#backId").click(function(){
                location.href="/Product/Index?wd=1";
            });
            $("#next-fh").click(function(){
                location.href="/Product/Index?wd=1";
            });
        }

        var isBrowser;
        $(function () {
            pageBack();
            //按钮样式
            $("#takePhoto").button()
                .click(function (event) {
                    event.preventDefault();
                });
            //判断浏览器
            isBrowser = doVerificationBrowser();
            //根据浏览器不同使用不同方法调用摄像头
            if (isBrowser) {
                $("#FalshDiv").show();
            } else {
                //判断浏览器是否 支持HTML5
                if (checkHtml5()) {
                    $("#HTML5Div").show();
                    doHtml5();
                }
            }
        });

        function checkCamera() {
        }

        function checkHtml5() {
            return !!document.createElement("video").canPlayType;
        }

        function doVerificationBrowser() {
            var userAgent = navigator.userAgent;
            if (!!window.ActiveXObject || "ActiveXObject" in window || userAgent.indexOf("trident") > -1) {
                return true;
            } else {
                return false;
            }
        }
        var canvas, context, video, videoObj, errBack;
        function doHtml5() {
            window.addEventListener("DOMContentLoaded", function () {
                canvas = document.getElementById("canvas"),
                    context = canvas.getContext("2d"),
                    video = document.getElementById("video"),
                    videoObj = { "video": true },
                    errBack = function (error) {
                        console.log("Video capture error: ", error.code);
                    };
                if (navigator.getUserMedia) {
                    navigator.getUserMedia(videoObj, function (stream) {
                        video.src = stream;
                        video.play();
                    }, errBack);
                } else if (navigator.webkitGetUserMedia) {
                    navigator.webkitGetUserMedia(videoObj, function (stream) {
                        video.src = window.webkitURL.createObjectURL(stream);
                        video.play();
                    }, errBack);
                }
                else if (navigator.mozGetUserMedia) {
                    navigator.mozGetUserMedia(videoObj, function (stream) {
                        video.src = window.URL.createObjectURL(stream);
                        video.play();
                    }, errBack);
                }
            }, false);
        }

        function photo(id) {
            if (isBrowser) {
                doFlash(id);
            } else {
                tabkePhotoForHtml5(id);
            }
            return false;
        }

        function doFlash(id) {
            var MyCan = thisMovie("My_Cam");
            var base64Code = MyCan.GetBase64Code();
            var src="data:image/png;base64," + base64Code;
            $("#showImg"+id).attr("src", src);
            imgAdd(id, base64Code);
        }

        function thisMovie(movieName) {
            if (navigator.appName.indexOf("Microsoft") != -1) {
                return document[movieName];
            }
            else {
                return document[movieName];
            }
        }

        function tabkePhotoForHtml5(id) {
            context.drawImage(video, 0, 0, 500, 400);
            var canvas = document.getElementById("canvas");
            var imgData = canvas.toDataURL();
            var base64Code = imgData.substr(22);
            var src="data:image/png;base64," + base64Code;
            $("#showImg"+id).attr("src", src);
            imgAdd(id, src);
        }
    </script>
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
                width: 12.5%;
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

        .show, .show1, .show2, .show3, .show4, .show5, .show6, .show7 {
            display: none;
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
                        layer.msg('努力加载中.....', { icon: 6, time: 1000 });
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
    <script type="text/javascript">
        var modelIdentityCardLibrary = {};
        var modelNetLoanApply = {};
        $(document).ready(function () {
            connect();
            $("#AreaCodeID").change(function(){
                var label=document.getElementById("ShowCode");  
                label.innerText= $("#AreaCodeID").val()+"+";
                var label1=document.getElementById("ShowCode1");  
                label1.innerText= $("#AreaCodeID").val()+"+";
                var label2=document.getElementById("ShowCode2");  
                label2.innerText= $("#AreaCodeID").val()+"+";
            });
            $("#AreaCodeID1").change(function(){
                var label1=document.getElementById("ShowCode1");  
                label1.innerText= $("#AreaCodeID").val()+"+";
            });
            $("#readCardId").click(function () {
                connect();
                return false;
            });

            $("#next-info").click(function () {
                return nextinfoClick();
                ////测试完成后删除
                //$("#identityForm").hide();
                //$(".show1").show();
                //$(".no0").addClass("tab-bg");
            });

            $("#next-pho").click(function () {
                return nextphoClick();
                ////测试完成后删除
                //$(".show1").hide();
                //$(".show2").show();
                //$(".no1").addClass("tab-bg");
            });

            $('#next-phorz').click(function () {
                return nextphorzClick();
                ////测试完成后删除                
                ////资料审核
                ////dataReview();
                //$(".show2").hide();
                //$(".show3").show();
                //$(".no2").addClass("tab-bg");
            });
            
            $('#next-zlsh').click(function () {
                $(".show3").hide();
                $(".show4").show();
                $(".no3").addClass("tab-bg");
                return false;
            });
            
            $('#next-jksq').click(function () {
                return nextjksqClick();                
                ////测试完成后删除
                //$(".show4").hide();
                //$(".show5").show();
                //$(".no4").addClass("tab-bg");
                //return false;
            })

            $('#next-jkqr').click(function () {
                return nextjkqrClick();
                ////测试完成后删除
                //$(".show5").hide();
                //$(".show6").show();
                //$(".no5").addClass("tab-bg");
            });

            $('#next-auth').click(function () {
                return nextauthClick();   
                ////测试完成后删除
                //$(".show6").hide();
                //$(".show7").show();
                //$(".no6").addClass("tab-bg");
            });

            $("#inpLoanAmount").change(function (){
                var loanAmount = parseFloat($.trim($("#inpLoanAmount").val()));
                var loanMinQuota = parseFloat($.trim($("#hiddLoanMinQuota").val()));
                var loanMaxQuota = parseFloat($.trim($("#hiddLoanMaxQuota").val()));
                var loanLimte = parseFloat($.trim($("#hiddLoanLimte").val()));
                if(loanLimte < loanMinQuota)
                {
                    myAlert("申请金额有误，范围（" + loanMinQuota + "至" + loanMaxQuota + "），您的可借额度为" + loanLimte);
                    $("#inpLoanAmount").val("");
                }
                else{
                    if(loanAmount >= loanMinQuota && loanAmount <= loanLimte)
                    {
                    }
                    else
                    {
                        myAlert("申请金额有误，范围（" + loanMinQuota + "至" + loanLimte + "），您的可借额度为" + loanLimte);
                        $("#inpLoanAmount").val("");
                    }
                }
            });
        });
    </script>

    <script type="text/javascript">

        function nextinfoClick()
        {
            if ($("#identityForm").valid()) 
            {
                var inputValidCode = $.trim($("#inpValidCode").val());
                var mobileValidCode = $.trim($("#hiddValidCode").val());
                checkMobile();
                var memberFlag = parseInt($.trim($("#hiddMemberFlag").val()));
                var netLoanApplyId = netLoanApply();
                if(netLoanApplyId == 0)
                {
                    myAlert("申请异常，请稍后重试。");
                    return false;
                }
                else
                {
                    if(memberFlag == 0)
                    {
                        var paramter = {};
                        paramter.op = "bwjs";
                        paramter.om = "netloan";
                        paramter.action = "memerregister";
                        paramter.telNo = $("#AreaCodeID") .val()+$.trim($("#inpMobile").val());
                        paramter.netLoanApplyId = netLoanApplyId;
                        paramter.password = $.trim($("#inpPassword").val());
                        paramter.inviteCode = <%="'"+recommendationCode+"'"%>;
                        paramter.smsCode = $.trim($("#inpValidCode").val());
                        //myAlert(JSON.stringify(json));
                        var json = getJson(paramter, false);
                        if (json.success) {
                            $("#hiddIMEI").val(json.data.imei);
                            $("#hiddTelNo").val(json.data.telNo);  
                            $("#hiddMemberId").val(json.data.memberId);
                            $("#hiddCustomerId").val(json.data.customerId);
                            $("#hiddToken").val(json.data.token);
                            $("#inpMobileForBankCard").val($("#inpMobile").val());

                            bankCardList();

                            $("#identityForm").hide();
                            $(".show1").show();
                            $(".no0").addClass("tab-bg");
                        
                        } else {
                            myAlert(json.message);
                        }
                    }
                    else if(memberFlag == 1)
                    {
                        var paramter = {};
                        paramter.op = "bwjs";
                        paramter.om = "netloan";
                        paramter.action = "memersignin";
                        paramter.telNo = $("#AreaCodeID") .val()+$.trim($("#inpMobile").val());
                        paramter.netLoanApplyId = netLoanApplyId;
                        paramter.password = $.trim($("#inpPassword").val());
                        paramter.smsCode = $.trim($("#inpValidCode").val());
                        var json = getJson(paramter, false);
                        //myAlert(JSON.stringify(json));
                        if (json.success) {
                            $("#hiddIMEI").val(json.data.imei);
                            $("#hiddTelNo").val(json.data.telNo);  
                            $("#hiddMemberId").val(json.data.memberId);
                            $("#hiddCustomerId").val(json.data.customerId);
                            $("#hiddToken").val(json.data.token);
                            $("#inpMobileForBankCard").val($("#inpMobile").val());
                            
                            bankCardList();
                            checkUserIsAuthentication();

                            $("#identityForm").hide();
                            $(".show1").show();
                            $(".no0").addClass("tab-bg");
                        } 
                        else {
                            myAlert(json.message);
                        }
                    }
                }
            }
            return false;
        }

        function nextphoClick()
        {
            if ($("#bankCardForm").valid()) 
            {
                var bankCardListLength = $("#hiddBankCardListLength").val();
                if(bankCardListLength == 0){
                    var no = $.trim($("#hiddNo").val());
                    var bankCardMobileValidCode = $.trim($("#inpBankCardMobileValidCode").val());
                    if(no != "" && bankCardMobileValidCode != ""){
                        var paramter = {};
                        paramter.op = "bwjs";
                        paramter.om = "netloan";
                        paramter.action = "bankcardsmscodecheck";
                        paramter.no = $("#hiddNo").val();
                        paramter.code = $.trim($("#inpBankCardMobileValidCode").val());
                        paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                        paramter.token = $("#hiddToken").val();

                        var json = getJson(paramter, false);
                        if (json.success) {
                            $(".show1").hide();
                            $(".show2").show();
                            $(".no1").addClass("tab-bg");
                        } else {
                            myAlert(json.message);
                        }
                    }
                    else{
                        myAlert("请先获取验证码验证银行手机号");
                    }
                }
                else
                {
                    $(".show1").hide();
                    $(".show2").show();
                    $(".no1").addClass("tab-bg");
                }
            }
            return false;
        }

        function dataReview(){
            $("#next-zlsh").attr("disabled", true); 
            $("#divDataReview1").show();
            $("#divDataReview2").hide();
            
            dataReviewCheck();
            
            var task = getLoanParas();
            if(!task){
                myAlert("获取借款参数失败，请稍后再试");
                return false;
            }
        }

        var dataReviewTimer; 
        function dataReviewCheck(){
            var isopen = comprehensiveQuery();
            //alert(isopen);
            if(isopen)
            {
                clearTimeout(dataReviewTimer); 
                $("#divDataReview1").hide();
                $("#divDataReview2").show();
                $("#next-zlsh").attr("disabled", false); 
            }
            else{
                dataReviewTimer = setTimeout(function() { 
                    dataReviewCheck() }
                ,5000) 
            }
        }

        function nextphorzClick()
        {
            var imgid1 = $("#hiddImgId1").val();
            var imgid2 = $("#hiddImgId2").val();
            var imgid3 = $("#hiddImgId3").val();
            var imgid4 = $("#hiddImgId4").val();
            var imgid5 = $("#hiddImgId5").val();
            var imgid6 = $("#hiddImgId6").val();
            var imgid7 = $("#hiddImgId7").val();
            var imgid8 = $("#hiddImgId8").val();
            var checkUserIsAuthentication = parseInt($("#hiddCheckUserIsAuthentication").val());
            if(checkUserIsAuthentication == 0){
                if(!istest){
                    if(imgid1 == "")
                    {
                        myAlert("请正面脸拍照");
                        return false;
                    }
                    if(imgid2 == "")
                    {
                        myAlert("请左侧脸拍照");
                        return false;
                    }
                    if(imgid3 == "")
                    {
                        myAlert("请右侧脸拍照");
                        return false;
                    }
                    if(imgid4 == "")
                    {
                        myAlert("请仰脸拍照");
                        return false;
                    }
                    if(imgid5 == "")
                    {
                        myAlert("请身份证正面拍照");
                        return false;
                    }
                    if(imgid6 == "")
                    {
                        myAlert("请身份证正面拍照");
                        return false;
                    }
                    if(imgid7 == "")
                    {
                        myAlert("请身份证正反面拍照");
                        return false;
                    }
                    if(imgid8 == "")
                    {
                        myAlert("请身份证反面拍照");
                        return false;
                    }
                }
                if(!istest){
                    if(imgid1 != "" && imgid2 != "" && imgid3 != "" && imgid4 != "" && imgid5 != "" && imgid6 != "" && imgid7 != "" && imgid8 != ""){
                        var auth = idinformationAuthentication();
                        if(!auth){
                            myAlert("身份认证失败，请稍后再试");
                            return false;
                        }
                        //资料审核
                        dataReview();

                        $(".show2").hide();
                        $(".show3").show();
                        $(".no2").addClass("tab-bg");
                    }
                }
            }
            else{
                //资料审核
                dataReview();

                $(".show2").hide();
                $(".show3").show();
                $(".no2").addClass("tab-bg");
            }
            return false;
        }
        
        function taskCreate()
        {
            var result = false;
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "netloan";
            paramter.action = "taskcreate";
            paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
            paramter.telNo = $("#AreaCodeID") .val()+$.trim($("#inpMobile").val());
            paramter.token = $("#hiddToken").val();
            var json = getJson(paramter, false);
            //myAlert(JSON.stringify(json));
            if (json.success) {
                result = json.success;
                var url = json.data.url;
                $("#taskFrame").attr("src", url);
            }
            else{
                myAlert(json.message);
            }
            return result;
        }
        
        function nextjksqClick(){
            if ($("#loanForm").valid()) {
                var loanAmount = parseFloat($.trim($("#inpLoanAmount").val()));
                var loanMinQuota = parseFloat($.trim($("#hiddLoanMinQuota").val()));
                var loanMaxQuota = parseFloat($.trim($("#hiddLoanMaxQuota").val()));
                var loanLimte = parseFloat($.trim($("#hiddLoanLimte").val()));
                if(loanLimte < loanMinQuota)
                {
                    myAlert("申请金额有误，范围（" + loanMinQuota + "至" + loanMaxQuota + "），您的可借额度为" + loanLimte);
                    $("#inpLoanAmount").val("");
                    return false;
                }
                else{
                    if(loanAmount >= loanMinQuota && loanAmount <= loanLimte)
                    {
                        var paramter = {};
                        paramter.op = "bwjs";
                        paramter.om = "netloan";
                        paramter.action = "submitloanapply";
                        paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                        paramter.loanAmount = $.trim($("#inpLoanAmount").val());
                        paramter.bankId = $("#hiddBankId").val();
                        paramter.token = $("#hiddToken").val();
                        var json = getJson(paramter, false);
                        //myAlert(JSON.stringify(json));
                        if (json.success) {
                            $("#hiddBorrowNo").val(json.data.borrowNo);
                            $("#spLoanAmount").text($.trim($("#inpLoanAmount").val()));

                            $("#spActuaAmount").text(json.data.amountReceived);
                            $("#spTotalAmount").text(json.data.loanServiceCharge);
                            $("#spAmountPayable").text(json.data.returnAmount);
                            
                            //var dueDate = json.data.dueDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1.$2.$3");
                            $("#spExpiryDate").text(myToDate(json.data.dueDate));
                            if(json.data.bankCard != null && json.data.bankCard != ""){
                                var bankCardNo = json.data.bankCard.bankCardNo;
                                if(bankCardNo.length >4){
                                    var start = bankCardNo.length - 4;
                                    bankCardNo = bankCardNo.substr(start);
                                }
                                var bankCardNoShow = json.data.bankCard.bankName + "（" + bankCardNo + "）";
                                $("#spCashCard").text(bankCardNoShow);
                            }

                            $(".show4").hide();
                            $(".show5").show();
                            $(".no4").addClass("tab-bg");
                        } else {
                            myAlert(json.message);
                        }
                    }
                    else
                    {
                        myAlert("申请金额有误，范围（" + loanMinQuota + "至" + loanLimte + "），您的可借额度为" + loanLimte);
                        $("#inpLoanAmount").val("");
                        return false;
                    }
                }

            }
            return false;
        }
        
        function nextjkqrClick(){
            bootbox.setDefaults("locale", "zh_CN");
            bootbox.confirm("确认借款吗？", function (result) {
                if (result) {
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "netloan";
                    paramter.action = "confirmationloanapply";
                    paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                    paramter.borrowNo = $.trim($("#hiddBorrowNo").val());
                    paramter.tradePassword = "123456";
                    paramter.tradePasswordSecond = "123456";
                    paramter.token = $("#hiddToken").val();
                    var json = getJson(paramter, false);
                    //myAlert(JSON.stringify(json));
                    if (json.success) {                                               
                        $(".show5").hide();
                        $(".show6").show();
                        $(".no5").addClass("tab-bg");
                    } else {
                        myAlert(json.message);
                    }
                }
            });
            return false;
        }

        function nextzlshClick()
        {
            if ($("#taskForm").valid()) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "netloan";
                paramter.action = "taskcreate";
                paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                //paramter.telNo =$("#AreaCodeID2").val()+ $.trim($("#inpMobileForTask").val());
                //paramter.servicePwd = $.trim($("#inpServicePwd").val());
                paramter.token = $("#hiddToken").val();
                var json = getJson(paramter, false);
                //myAlert(JSON.stringify(json));
                if (json.success) {
                    //$("#hiddTaskId").val(json.data.taskId);
                    //getLoanParas();
                    //if(parseInt($.trim($("#hiddLoanLimte").val())) > 0){
                    //    $("#taskForm").hide();
                    //    $(".show3").hide();
                    //    $(".show4").show();
                    //    $(".no3").addClass("tab-bg");
                    //}
                    //else{
                    //    myAlert("授权额度不足");
                    //}

                    var url = json.data.url;
                    var iWidth = 640; //window.screen.width;
                    var iHeight = 480; //window.screen.height;
                    var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
                    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
                    var win = window.open(url, "手机运营商认证", "width=" + iWidth + ", height=" + iHeight + ",top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no,alwaysRaised=yes,depended=yes");
                    //win.document.title = "手机运营商认证";
                    $(".show3").hide();
                    $(".show4").show();
                    $(".no3").addClass("tab-bg");
                }
                else{
                    myAlert(json.message);
                }
            }
            return false;
        }
        
        function nextauthClick(){
            if ($("#authorizationForm").valid()) {
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("确认授权吗？", function (result) {
                    if (result) {
                        var paramter = {};
                        paramter.op = "bwjs";
                        paramter.om = "netloan";
                        paramter.action = "confirmationofauthorization";
                        paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                        paramter.identityCardNumber = $.trim($("#inpIdentityCardNumberForMerchant").val());
                        paramter.accountExec = $.trim($("#inpAccountExec").val());
                        paramter.authorizedPassword = $.trim($("#inpAuthorizedPassword").val());  
                        paramter.borrowNo = $.trim($("#hiddBorrowNo").val());
                        paramter.operatorId = "123456";
                        paramter.operatorName = $.trim($("#inpIdentityCardNumberForMerchant").val());
                        paramter.token = $("#hiddToken").val();
                        var json = getJson(paramter, false);
                        if (json.success) {

                            borrowingStateCheck();

                            $(".show6").hide();
                            $(".show7").show();
                            $(".no6").addClass("tab-bg");
                        } else {
                            myAlert(json.message);
                        }
                    }
                });
            }
            return false;
        }

        function bankCardList(){
            
            $("#bankCardForm").valid();

            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "netloan";
            paramter.action = "bankcardlist";
            paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
            paramter.token = $("#hiddToken").val();e
            var json = getJson(paramter, false);
            //myAlert(JSON.stringify(json));
            if (json.success) {
                $("#hiddBankCardListLength").val(json.data.length);
                if(json.data.length >0 ){
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "netloan";
                    paramter.action = "bankcardlistby";
                    paramter.realName = $.trim($("#inpFullName").val());
                    paramter.idNo = $.trim($("#inpIdentityCardNumber").val());
                    paramter.telNo = $("#AreaCodeID") .val()+$.trim($("#inpMobile").val());
                    paramter.flag = 1;
                    var json = getJson(paramter, false);
                    if (json.result) {
                        if(json.data != null){
                            $("#inpFullNameForBankCard").val(json.data.RealName);
                            $("#inpIdentityCardNumberForBankCard").val(json.data.IdNo);
                            var telNo = json.data.TelNo;
                            var countryCode = "";
                            if(telNo.length > 11){
                                var start = telNo.length - 11;
                                telNo = telNo.substr(start);
                                countryCode = json.data.TelNo.substr(0, start);
                            }
                            
                            $("#AreaCodeID1").val(countryCode);
                            $("#inpMobileForBankCard").val(telNo);
                            $("#inpBankCardNo").val(json.data.BankCardNo);
                            
                            $("#inpFullNameForBankCard").attr("readonly", true);
                            $("#inpIdentityCardNumberForBankCard").attr("readonly", true);
                            $("#inpBankCardNo").attr("readonly", true);
                            $("#AreaCodeID1").attr("disabled", true);
                            $("#inpMobileForBankCard").attr("readonly", true);
                            $("#divBankCardMobileValidCode").hide();                    
                            $("#inpBankCardMobileValidCode").attr("readonly", true);
                            $("#btnGetBankCardMobileValidCode").attr("disabled", true); 
                            $("#inpBankCardMobileValidCode").rules("remove");
                        }
                    }
                    
                }
            }
        }

        function bankCardAdd(){
            var bankcardNo = "";
            if ($("#bankCardForm").valid()) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "netloan";
                paramter.action = "bankcardadd";
                paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                paramter.realName =  $.trim($("#inpFullNameForBankCard").val());
                paramter.idNo =  $.trim($("#inpIdentityCardNumberForBankCard").val());
                paramter.bankCardNo =  $.trim($("#inpBankCardNo").val());
                paramter.telNo = $("#AreaCodeID1") .val()+$.trim($("#inpMobileForBankCard").val());
                if(parseInt($("#hiddBankCardListLength").val()) == 0){
                    paramter.cash = 1;
                }
                else{
                    paramter.cash = 0;
                }
                paramter.token = $("#hiddToken").val();

                var json = getJson(paramter, false);
                //myAlert(JSON.stringify(json));
                if (json.success) {
                    bankcardNo = json.data.no;
                    $("#hiddNo").val(json.data.no);
                }
                else{
                    myAlert(json.message);
                }
            }
            return bankcardNo;
        }
        
        function imgAdd(id, base64Code)
        {                    
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "netloan";
            paramter.action = "imagesupload";
            paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
            paramter.base64Code = base64Code;
            paramter.token = $("#hiddToken").val();

            var json = getJson(paramter, false);
            //myAlert(JSON.stringify(json));
            if (json.success) {
                $("#hiddImgId"+id).val(json.data.imgId);

            } else {
                myAlert(json.message);
            }
        }
        
        function idinformationAuthentication(){
            var result = false;
            if ($("#bankCardForm").valid()) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "netloan";
                paramter.action = "submitidinformation";
                paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                var fontId = $.trim($("#hiddImgId5").val()) + "," + $.trim($("#hiddImgId6").val());
                paramter.fontId = fontId;
                var bankId = $.trim($("#hiddImgId7").val()) + "," + $.trim($("#hiddImgId8").val());
                paramter.bankId = bankId;
                paramter.realName = $.trim($("#inpFullName").val());
                paramter.idNo = $.trim($("#inpIdentityCardNumber").val());
                paramter.birth = $.trim($("#inpBirthDay").val());
                paramter.national = $.trim($("#inpNation").val());
                paramter.address = $.trim($("#inpAddress").val());
                paramter.authority = $.trim($("#inpIssuedAt").val());
                paramter.validperiod = $.trim($("#inpExpiredDate").val());
                var faceNo = $.trim($("#hiddImgId1").val()) + "," + $.trim($("#hiddImgId2").val()) + "," + $.trim($("#hiddImgId3").val()) + "," + $.trim($("#hiddImgId4").val()) + ",FV_5";                
                paramter.faceNo = faceNo;
                paramter.token = $("#hiddToken").val();

                var json = getJson(paramter, false);
                //myAlert(JSON.stringify(json));
                if (json.success) {
                    result = json.success;
                }
                else{
                    //myAlert(json.message);
                }
            }
            return result;
        }

        function checkUserIsAuthentication()
        {
            var result = false;
            var memberId = $.trim($("#hiddMemberId").val());
            var customerId = $.trim($("#hiddCustomerId").val());
            if(memberId != "" && customerId != "")
            {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "netloan";
                paramter.action = "checkuserisauthentication";
                paramter.memberId = memberId;
                paramter.customerId = customerId;
                var json = getJson(paramter, false);
                if (json.result) {
                    result = json.result;
                    $("#hiddCheckUserIsAuthentication").val(1);
                }
            }
            return result;
        }

        function getLoanParas(){
            var result = false;
            try{
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "netloan";
                paramter.action = "getloanparas";
                paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                paramter.token = $("#hiddToken").val();
                var json = getJson(paramter, false);
                //myAlert(JSON.stringify(json));
                if (json.success) {
                    if(json.data != null && json.data!=""){
                        $("#spLoanLimte").text(json.data.loanLimte);//可借额度
                        $("#spAvailableCredit").text(json.data.loanLimte);
                        $("#inpLoanAmount").val(json.data.loanLimte);
                        $("#hiddLoanLimte").val(json.data.loanLimte);
                        $("#hiddloanType").val(json.data.loanType);//借款方式
                        $("#spLoanSection").text(json.data.loanMinQuota + "-" + json.data.loanMaxQuota);
                        $("#hiddLoanMinQuota").val(json.data.loanMinQuota);
                        $("#hiddLoanMaxQuota").val(json.data.loanMaxQuota);
                        $("#spBorrowDays").text(json.data.borrowDays);
                        var loanRate = parseFloat(json.data.loanRate);//借款费率
                        loanRate = loanRate * 100;
                        if(json.data.cashCard != null && json.data.cashCard != ""){
                            $("#hiddBankId").val(json.data.cashCard.bankCardId);
                        }
                        result = json.success;
                    }
                } else {
                    myAlert("获取借款参数失败，"+json.message);
                }
            }
            catch(e){
                myAlert("异常，"+json.message);
            }
            return result;
        }
        
        function comprehensiveQuery(){
            var result = false;
            //try{
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "netloan";
            paramter.action = "comprehensivequery";
            paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
            paramter.token = $("#hiddToken").val();
            var json = getJson(paramter, false);
            //myAlert(JSON.stringify(json));
            if (json.success) {
                if(json.data != null && json.data!=""){
                    $("#spLoanLimte").text(json.data.loanAccount.availableLoanLimit);//可借额度
                    $("#spLoanSection").text(json.data.loanAccount.minQuota + "-" + json.data.loanAccount.maxQuota);
                    $("#hiddLoanMinQuota").val(json.data.loanAccount.minQuota);
                    $("#hiddLoanMaxQuota").val(json.data.loanAccount.maxQuota);
                    //alert(json.data.loanAccount.state);
                    if(parseInt(json.data.loanAccount.state) == 2){
                        result = true;
                    }
                }
            } 
            //else {
            //    myAlert("首页综合信息查询失败，"+json.message);
            //}
            //}
            //catch(e){
            //    myAlert("首页综合信息查询异常，"+json.message);
            //}
            return result;
        }
        
        function borrowingStateCheck(){
            $("#divLoanAudit1").show();
            $("#divLoanAudit2").hide();
            $("#divLoanAudit3").hide();
            
            borrowingStateCheckInner();
        }
        var borrowingStateTimer; 
        function borrowingStateCheckInner(){
            var borrowingState = borrowingStateQuery();
            //-1位审核中，1位审核通过银行处理中，2借款成功
            switch(parseInt(borrowingState)){
                case -1:
                    $("#divLoanAudit1").show();
                    $("#divLoanAudit2").hide();
                    $("#divLoanAudit3").hide();
                    break;
                case 1:
                    $("#divLoanAudit1").hide();
                    $("#divLoanAudit2").show();
                    $("#divLoanAudit3").hide();
                    break;
                case 2:
                    $("#divLoanAudit1").hide();
                    $("#divLoanAudit2").hide();
                    $("#divLoanAudit3").show();
                    clearTimeout(borrowingStateTimer);
                    break;
            }
            if(parseInt(borrowingState) != 2){
                borrowingStateTimer = setTimeout(function() { 
                    borrowingStateCheckInner() }
                ,10000)
            }
        }

        function borrowingStateQuery(){
            var borrowState = -1;
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "netloan";
            paramter.action = "borrowingstatequery";
            paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
            paramter.borrowNo = $.trim($("#hiddBorrowNo").val());
            paramter.token = $("#hiddToken").val();
            var json = getJson(paramter, false);
            //myAlert(JSON.stringify(json));
            if (json.success) {
                if(json.data != null && json.data!=""){
                    borrowState = json.data.borrowState;
                }
            }
            return borrowState;
        }

    </script>

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
                            <li class="no3">资料审核</li>
                            <li class="no4">借款申请</li>
                            <li class="no5">确认借款</li>
                            <li class="no6">特许授权</li>
                            <li class="no7">借款结果</li>
                        </ul>
                    </div>
                    <!--身份认证start-->

                    <div class="show">
                        <form class="form-horizontal mar-top1" role="form" id="identityForm" enctype="application/x-www-form-urlencoded">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label for="inpFullName" class="col-sm-3 control-label">姓 名：</label>
                                    <div class="col-sm-7 mar1">
                                        <input type="text" class="form-control" id="inpFullName" name="inpFullName" placeholder="请输入中文名" required data-msg-required="不能为空" data-msg-age="请输入姓名" /><em>*</em>
                                        <em>*</em>
                                    </div>
                                    <div class="col-sm-2 mar">
                                        <span class="btn mar-btn  btn-danger" id="readCardId">身份证扫描</span>
                                    </div>
                                    <div class="col-sm-3 "></div>
                                    <div class="col-sm-8" id="divIdCardDescription">
                                        <span class="ts">温馨提示：请首选扫描身份证，系统将自动添加您的身份信息,<br />
                                            <b>第1步：</b>点击“身份证扫描”按钮 ,<br />
                                            <b>第2步：</b>在设备面板扫描身份证，当然您也可以选择手写输入信息。</span>
                                    </div>
                                </div>
                                <div class="form-group" id="divIdPhoto" style="display: none;">
                                    <label for="inpIdPhoto" class="col-sm-3 control-label">头 像：</label>
                                    <div class="col-sm-8">
                                        <div class="imgbox">
                                            <span class="pho">
                                                <img id="inpIdPhoto" name="inpIdPhoto" style="width: 96px; height: 118px;" /></span>
                                            <span class="sm">请将身份证拿起后放入感应器对应虚线内</span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpIdentityCardNumber" class="col-sm-3 control-label">证件号：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" value="" name="inpIdentityCardNumber" id="inpIdentityCardNumber" placeholder="请输入身份证号码" required data-msg-required="不能为空" data-msg-minlength="请输入证件号" maxlength="18"><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="Sex" class="col-sm-3 control-label">性 别：</label>
                                    <div class="col-sm-8">
                                        <label>
                                            <input style="width: 22px; height: 22px;" id="inpSex1" name="Sex" type="radio" value="1" required />
                                            男</label>
                                        <label>
                                            <input style="width: 22px; height: 22px;" id="inpSex0" name="Sex" type="radio" checked="checked" value="0" />
                                            女</label><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpBirthDay" class="col-sm-3 control-label">出生日期：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" value="" name="inpBirthDay" id="inpBirthDay" placeholder="请输入例如：1900-01-01" required data-msg-required="不能为空" data-msg-minlength="请输入出生年月"><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpNation" class="col-sm-3 control-label">民族：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" value="" name="inpNation" id="inpNation" placeholder="请输入民族" required data-msg-required="不能为空" data-msg-minlength="请输入民族"><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpAddress" class="col-sm-3 control-label">住址：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" value="" name="inpAddress" id="inpAddress" placeholder="请输入住址" required data-msg-required="不能为空" data-msg-minlength="请输入住址"><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpIssuedAt" class="col-sm-3 control-label">签发机关：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" value="" name="inpIssuedAt" id="inpIssuedAt" placeholder="请输入签发机关" required data-msg-required="不能为空" data-msg-minlength="请输入签发机关"><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpExpiredDate" class="col-sm-3 control-label">有效期：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" value="" name="inpExpiredDate" id="inpExpiredDate" placeholder="请输入例如：20171129-20371129" required data-msg-required="不能为空" data-msg-minlength="请输入有效期" /><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpMobile" class="col-sm-3 control-label">手机号：</label>
                                    <div class="col-sm-8 ">
                                        <div class="col-sm-2">
                                            <select name="AreaCode" class="form-control" id="AreaCodeID" style="width: 100px; margin-top: -3px">
                                                <option value="86">中国</option>
                                                <option value="81">日本</option>
                                            </select>
                                        </div>
                                        <div class="col-sm-1">
                                            <label id="ShowCode" style="margin-top: 4px">86+</label>
                                        </div>
                                        <input type="text" class="form-control" value="" name="inpMobile" id="inpMobile" placeholder="请输入手机号" maxlength="14" required data-rule-mobile="true" data-msg-required="请输入手机号" data-msg-mobile="请输入手机号" style="width: 75%" /><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpValidCode" class="col-sm-3 control-label">验证码：</label>
                                    <div class="col-sm-8">
                                        <div style="width: 100%; float: left">
                                            <input type="text" id="inpValidCode" name="inpValidCode" style="width: 80%; float: left;" class="form-control" placeholder="请输入验证码" required data-msg-required="请输入验证码" />
                                            <input type="button" style="width: 18%; background-color: #30abcd; float: left; margin-left: 10px; margin-top: 2px; border: none; height: 30px; border-radius: 2px;" value="获取验证码" class="btn mar-btn  btn-danger " onclick="getValidCode(this)" />
                                            <input id="hiddMemberFlag" name="hiddMemberFlag" type="hidden" value="0" />
                                            <input id="hiddNetLoanApplyId" name="hiddNetLoanApplyId" type="hidden" />
                                            <input id="hiddEffectedDate" name="hiddEffectedDate" type="hidden" />
                                            <input id="hiddExpiredDate" name="hiddExpiredDate" type="hidden" />
                                            <input id="hiddValidCode" name="hiddValidCode" type="hidden" />
                                            <input id="hiddIMEI" name="hiddIMEI" type="hidden" />
                                            <input id="hiddTelNo" name="hiddTelNo" type="hidden" />
                                            <input id="hiddMemberId" name="hiddMemberId" type="hidden" />
                                            <input id="hiddCustomerId" name="hiddCustomerId" type="hidden" />
                                            <input id="hiddCheckUserIsAuthentication" name="hiddCheckUserIsAuthentication" type="hidden" value="0" />
                                            <input id="hiddToken" name="hiddToken" type="hidden" />
                                            <input id="hiddBankId" name="hiddBankId" type="hidden" />
                                            <input id="hiddNo" name="hiddNo" type="hidden" />
                                            <input id="hiddBankCardListLength" name="hiddBankCardListLength" type="hidden" value="0" />
                                            <input id="hiddImgId1" name="hiddImgId1" type="hidden" />
                                            <input id="hiddImgId2" name="hiddImgId2" type="hidden" />
                                            <input id="hiddImgId3" name="hiddImgId3" type="hidden" />
                                            <input id="hiddImgId4" name="hiddImgId4" type="hidden" />
                                            <input id="hiddImgId5" name="hiddImgId5" type="hidden" />
                                            <input id="hiddImgId6" name="hiddImgId6" type="hidden" />
                                            <input id="hiddImgId7" name="hiddImgId7" type="hidden" />
                                            <input id="hiddImgId8" name="hiddImgId8" type="hidden" />
                                            <input id="hiddTaskId" name="hiddTaskId" type="hidden" />
                                            <input id="hiddLoanLimte" name="hiddLoanLimte" type="hidden" value="0" />
                                            <input id="hiddBorrowNo" name="hiddBorrowNo" type="hidden" />
                                            <input id="hiddLoanMinQuota" name="hiddLoanMinQuota" type="hidden" value="0" />
                                            <input id="hiddLoanMaxQuota" name="hiddLoanMaxQuota" type="hidden" value="3000" />

                                            <em>*</em>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpPassword" class="col-sm-3 control-label">密码：</label>
                                    <div class="col-sm-8">
                                        <input type="password" value="" id="inpPassword" name="inpPassword" class="form-control" placeholder="请输入App登录密码" required data-msg-required="请输入App登录密码" />
                                    </div>
                                </div>
                            </div>
                            <div class="text-center">
                                <input id="next-info" type="button" value="下一步" class="sub2" />
                            </div>
                            <object classid="clsid:5819234B-5977-4C82-9C59-A9D3C7D46083" id="CertCtl" name="CertCtl" width="0" height="0"></object>
                            <script type="text/javascript">
                                var rules = {
                                    inpFullName: {
                                        required: true,
                                        checkFullName: true,
                                    },
                                    inpMobile: {
                                        required: true,
                                        chkMobile: true,
                                    },
                                    inpIdentityCardNumber: {
                                        required: true,
                                        checkIdentityCardNumber: true,
                                    },
                                    inpFullNameForBankCard: {
                                        required: true,
                                        checkFullName: true,
                                    },
                                    inpMobileForBankCard: {
                                        required: true,
                                        chkMobile: true,
                                    },
                                    inpBankCardMobileValidCode: {
                                        required: true,
                                    },
                                    inpIdentityCardNumberForBankCard: {
                                        required: true,
                                        checkIdentityCardNumber: true,
                                    },
                                    inpBankCardNo: {
                                        required: true,
                                        checkBankCardNo: true,
                                        maxlength: 19
                                    }
                                };
                                $.validator.setDefaults({
                                    errorElement: 'span',
                                    rules: rules,
                                });
                                //姓名
                                jQuery.validator.addMethod("checkFullName", function (value, element) {
                                    var realname = /^([\u4e00-\u9fa5]{2,8}|[a-zA-Z]{2,16})$/g;
                                    return this.optional(element) || (realname.test(value));
                                }, "输入错误，姓名只能输入2-8个汉字或2-16个英文字符");
                                //手机验证规则
                                jQuery.validator.addMethod("chkMobile", function (value, element) {
                                    var mobile = /^1[3|4|5|6|7|8|9]\d{9}$/;///^((\+?86)|(\(\+86\)))?\d{3,4}-\d{7,8}(-\d{3,4})?$/;///^(\d{2,4})?(1[3|4|5|8][0-9]\d{4,8})$/;
                                    return this.optional(element) || (mobile.test(value));
                                }, "手机格式不对");
                                //身份证
                                jQuery.validator.addMethod("checkIdentityCardNumber", function (value, element) {
                                    var min = 1;
                                    var max = 18;
                                    if (parseInt(value.length) < min || parseInt(value.length) > max) {
                                        return false;
                                    } 
                                    else {
                                        var city = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "南", 42: "湖北 ", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 " };
                                        var isIDCard1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;//(15位)
                                        var isIDCard2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;//(18位)
                                        var value2 = "";
                                        if (value.length == 18) {
                                            value2 = value.split('');
                                            //∑(ai×Wi)(mod 11)
                                            //加权因子
                                            var factor = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
                                            //校验位
                                            var parity = [1, 0, 'X', 9, 8, 7, 6, 5, 4, 3, 2];
                                            var sum = 0;
                                            var ai = 0;
                                            var wi = 0;
                                            for (var i = 0; i < 17; i++) {
                                                ai = value2[i];
                                                wi = factor[i];
                                                sum += ai * wi;
                                            }
                                            var last = parity[sum % 11];
                                        }
                                        return (this.optional(element) || (isIDCard1.test(value)) || (isIDCard2.test(value))) && ((city[value.substr(0, 2)] != "") && (city[value.substr(0, 2)] != undefined) && (parity[sum % 11] == value2[17]));
                                    }
                                }, "格式不对");
                                
                                jQuery.validator.addMethod("checkBankCardNo", function (value, element) {
                                    return this.optional(element) || (luhmCheck(value));
                                }, "银行卡号输入有误，请检查输入");
                                
                                //Description:  银行卡号Luhm校验
                                //Luhm校验规则：16位银行卡号（19位通用）:
                                // 1.将未带校验位的 15（或18）位卡号从右依次编号 1 到 15（18），位于奇数位号上的数字乘以 2。
                                // 2.将奇位乘积的个十位全部相加，再加上所有偶数位上的数字。
                                // 3.将加法和加上校验位能被 10 整除。
                                //方法步骤很清晰，易理解，需要在页面引用Jquery.js
                                //bankno为银行卡号 banknoInfo为显示提示信息的DIV或其他控件
                                function luhmCheck(bankno) {
                                    var lastNum = bankno.substr(bankno.length - 1, 1);//取出最后一位（与luhm进行比较）

                                    var first15Num = bankno.substr(0, bankno.length - 1);//前15或18位
                                    var newArr = new Array();
                                    for (var i = first15Num.length - 1; i > -1; i--) {    //前15或18位倒序存进数组
                                        newArr.push(first15Num.substr(i, 1));
                                    }
                                    var arrJiShu = new Array();  //奇数位*2的积 <9
                                    var arrJiShu2 = new Array(); //奇数位*2的积 >9

                                    var arrOuShu = new Array();  //偶数位数组
                                    for (var j = 0; j < newArr.length; j++) {
                                        if ((j + 1) % 2 == 1) {//奇数位
                                            if (parseInt(newArr[j]) * 2 < 9)
                                                arrJiShu.push(parseInt(newArr[j]) * 2);
                                            else
                                                arrJiShu2.push(parseInt(newArr[j]) * 2);
                                        }
                                        else //偶数位
                                            arrOuShu.push(newArr[j]);
                                    }

                                    var jishu_child1 = new Array();//奇数位*2 >9 的分割之后的数组个位数
                                    var jishu_child2 = new Array();//奇数位*2 >9 的分割之后的数组十位数
                                    for (var h = 0; h < arrJiShu2.length; h++) {
                                        jishu_child1.push(parseInt(arrJiShu2[h]) % 10);
                                        jishu_child2.push(parseInt(arrJiShu2[h]) / 10);
                                    }

                                    var sumJiShu = 0; //奇数位*2 < 9 的数组之和
                                    var sumOuShu = 0; //偶数位数组之和
                                    var sumJiShuChild1 = 0; //奇数位*2 >9 的分割之后的数组个位数之和
                                    var sumJiShuChild2 = 0; //奇数位*2 >9 的分割之后的数组十位数之和
                                    var sumTotal = 0;
                                    for (var m = 0; m < arrJiShu.length; m++) {
                                        sumJiShu = sumJiShu + parseInt(arrJiShu[m]);
                                    }

                                    for (var n = 0; n < arrOuShu.length; n++) {
                                        sumOuShu = sumOuShu + parseInt(arrOuShu[n]);
                                    }

                                    for (var p = 0; p < jishu_child1.length; p++) {
                                        sumJiShuChild1 = sumJiShuChild1 + parseInt(jishu_child1[p]);
                                        sumJiShuChild2 = sumJiShuChild2 + parseInt(jishu_child2[p]);
                                    }
                                    //计算总和
                                    sumTotal = parseInt(sumJiShu) + parseInt(sumOuShu) + parseInt(sumJiShuChild1) + parseInt(sumJiShuChild2);

                                    //计算Luhm值
                                    var k = parseInt(sumTotal) % 10 == 0 ? 10 : parseInt(sumTotal) % 10;
                                    var luhm = 10 - k;

                                    if (lastNum == luhm && lastNum.length != 0) {
                                        //$("#banknoInfo").html("Luhm验证通过");
                                        return true;
                                    }
                                    else {
                                        //$("#banknoInfo").html("银行卡号必须符合Luhm校验");
                                        return false;
                                    }
                                }
                                //
                                jQuery.validator.addMethod("checkProtocol",function(value,element){
                                    return this.optional(element) || element.checked;  
                                }," ！请同意信息授权及使用协议");	

                                function checkMobile() {
                                    var mobile =$("#AreaCodeID") .val()+$.trim($("#inpMobile").val());
                                    if (mobile == "") {
                                        myAlert("请输入手机号码");
                                    }
                                    else{
                                        var reqdata = 
                                            {
                                                telNo : mobile,
                                                netLoanApplyId : 0
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
                                
                                function getBankCardMobileValidCode(obj) {
                                    $("#inpBankCardMobileValidCode").rules("remove");
                                    if ($("#bankCardForm").valid()) {
                                        var no = $("#hiddNo").val();
                                        if(no == ""){
                                            no = bankCardAdd();
                                        }
                                        if(no != "")
                                        {
                                            validCodeTimer(obj);
                                            var paramter = {};
                                            paramter.op = "bwjs";
                                            paramter.om = "netloan";
                                            paramter.action = "bankcardsmscode";
                                            paramter.no = $.trim($("#hiddNo").val());
                                            paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                                            paramter.token = $("#hiddToken").val();
                                            var json = getJson(paramter, false);
                                            if (json.success) {
                                                $("#inpBankCardMobileValidCode").rules("add",{required:true});  
                                            } else {
                                                myAlert(json.message);
                                            }
                                        }
                                    }
                                }
                                
                                function getValidCode(obj) {
                                    var mobile = $("#AreaCodeID1").val() + $.trim($("#inpMobile").val());
                                    if ($.trim($("#inpMobile").val()) == "") {
                                        myAlert("请输入手机号码");
                                    }
                                    else{
                                        validCodeTimer(obj);
                                        var paramter = {};
                                        paramter.op = "bwjs";
                                        paramter.om = "netloan";
                                        paramter.action = "getmonbilesmscode";
                                        paramter.telNo = mobile;
                                        paramter.netLoanApplyId = $.trim($("#hiddNetLoanApplyId").val());
                                        var json = getJson(paramter, false);
                                        if (json.success) {
                                            //$("#hiddValidCode").val(json.data.smsCode);
                                        } else {
                                            myAlert(json.message);
                                        }
                                    }
                                }
                                
                                var countdown = 60; 
                                function validCodeTimer(obj){
                                    if (countdown == 0) { 
                                        //$("#inpMobile").removeAttr("disabled");
                                        obj.removeAttribute("disabled"); 
                                        obj.value="获取验证码"; 
                                        countdown = 60; 
                                        return;
                                    } else { 
                                        obj.setAttribute("disabled", true); 
                                        obj.value="重新发送(" + countdown + ")"; 
                                        countdown--; 
                                    } 
                                    setTimeout(function() { 
                                        validCodeTimer(obj) }
                                    ,1000) 
                                }

                                function netLoanApply()
                                {
                                    var netLoanApplyId = 0;
                                    if (JSON.stringify(modelIdentityCardLibrary) == "{}") {
                                        modelIdentityCardLibrary.CompanyId = <%= companyId%>;
                                        modelIdentityCardLibrary.IdentityCardNumber = $("#inpIdentityCardNumber").val();
                                        modelIdentityCardLibrary.FullName = $("#inpFullName").val();
                                        modelIdentityCardLibrary.Sex = parseInt($("input[name='Sex']:checked").val());
                                        modelIdentityCardLibrary.Nation = "";
                                        modelIdentityCardLibrary.BirthDay = new Date("1900-01-01");
                                        modelIdentityCardLibrary.Address = "";
                                        modelIdentityCardLibrary.IssuedAt = "";
                                        modelIdentityCardLibrary.EffectedDate = new Date("1900-01-01");
                                        modelIdentityCardLibrary.ExpiredDate = new Date("1900-01-01");
                                        modelIdentityCardLibrary.IdentityCardPhotoPath = "";
                                        modelIdentityCardLibrary.IdentityCardPhotoData = "";
                                        modelIdentityCardLibrary.IdentityCardData = "";
                                    }
                                    if (JSON.stringify(modelNetLoanApply) == "{}") {
                                        modelNetLoanApply.CompanyId = <%= companyId%>;
                                        modelNetLoanApply.FullName = $("#inpFullName").val();
                                        modelNetLoanApply.IdCardType = 1;
                                        modelNetLoanApply.IdCard = $("#inpIdentityCardNumber").val();
                                        modelNetLoanApply.Sex = parseInt($("input[name='Sex']:checked").val());
                                        modelNetLoanApply.RecommendationCode=<%="'"+recommendationCode+"'"%>;
                                    }
                                    modelNetLoanApply.Mobile = $("#MobileId").val();

                                    var paramter = {};
                                    paramter.op = "bwjs";
                                    paramter.om = "netloan";
                                    paramter.action = "idcardlibraryadd";
                                    paramter.modelIdentityCardLibrary = JSON.stringify(modelIdentityCardLibrary);
                                    paramter.modelNetLoanApply = JSON.stringify(modelNetLoanApply);
                                    var json = getJson(paramter, false);
                                    if (json.result) {
                                        netLoanApplyId = json.data;
                                        $("#hiddNetLoanApplyId").val(netLoanApplyId);
                                    }
                                    return netLoanApplyId;
                                }

                                function connect() {
                                    var CertCtl = document.getElementById("CertCtl");
                                    try {
                                        var result = CertCtl.OpenComm();
                                        if (result == "") {
                                            readCert();
                                        }
                                        else {
                                        }
                                    } catch (e) {
                                    }
                                }
                                var modelIdentityCardLibrary = {};
                                var modelNetLoanApply = {};

                                function readCert() {
                                    var CertCtl = document.getElementById("CertCtl");
                                    try {
                                        var startDt = new Date();
                                        var result = CertCtl.ReadCard();
                                        var endDt = new Date();
                                        if (result == "") {
                                            var sexpersonValue = (CertCtl.Sex == "男" ? 1 : 0);
                                            var strPhotoBase64 = CertCtl.CardPictureData;
                                            var idphotoSrc = "data:image/png;base64," + strPhotoBase64;
                                            var born = CertCtl.Born.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
                                            var effectedDate = CertCtl.EffectedDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
                                            var expiredDate = CertCtl.ExpiredDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
                                            var effectedDateForBankCard = CertCtl.EffectedDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1$2$3");
                                            var expiredDateForBankCard = CertCtl.ExpiredDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1$2$3");
                                            $("#inpFullName").val(CertCtl.Name);
                                            $("#inpFullNameForBankCard").val(CertCtl.Name);
                                            $("#inpIdentityCardNumber").val(CertCtl.CardNo);
                                            $("#inpIdentityCardNumberForBankCard").val(CertCtl.CardNo);
                                            if (sexpersonValue == 1) {
                                                $("#inpSex1").attr('checked', 'checked');
                                            } else {
                                                $("#inpSex0").attr('checked', 'checked');
                                            }
                                            $("#inpIdPhoto").attr("src", idphotoSrc);
                                            $("#divIdPhoto").show();
                                            $("#inpBirthDay").val(born);
                                            $("#inpNation").val(CertCtl.Nation);
                                            $("#inpAddress").val(CertCtl.Address);
                                            $("#inpIssuedAt").val(CertCtl.IssuedAt);
                                            $("#inpExpiredDate").val(effectedDateForBankCard + "-" + expiredDateForBankCard);   
                                            $("#hiddEffectedDate").val(effectedDate);
                                            $("#hiddExpiredDate").val(expiredDate);

                                            modelIdentityCardLibrary.CompanyId = <%= companyId%>;
                                            modelIdentityCardLibrary.IdentityCardNumber = CertCtl.CardNo;
                                            modelIdentityCardLibrary.FullName = CertCtl.Name;
                                            modelIdentityCardLibrary.Sex = sexpersonValue;
                                            modelIdentityCardLibrary.Nation = CertCtl.Nation;
                                            modelIdentityCardLibrary.BirthDay = born;
                                            modelIdentityCardLibrary.Address = CertCtl.Address;
                                            modelIdentityCardLibrary.IssuedAt = CertCtl.IssuedAt;
                                            modelIdentityCardLibrary.EffectedDate = effectedDate;
                                            modelIdentityCardLibrary.ExpiredDate = expiredDate;
                                            modelIdentityCardLibrary.IdentityCardPhotoPath = CertCtl.CardPicPath;
                                            modelIdentityCardLibrary.IdentityCardPhotoData = CertCtl.CardPictureData;
                                            modelIdentityCardLibrary.IdentityCardData = JSON.stringify(CertCtl);
                                        
                                            modelNetLoanApply.CompanyId = <%= companyId%>;
                                            modelNetLoanApply.FullName = CertCtl.Name;
                                            modelNetLoanApply.IdCardType = 1;
                                            modelNetLoanApply.IdCard = CertCtl.CardNo;
                                            modelNetLoanApply.Sex = sexpersonValue;
                                            modelNetLoanApply.RecommendationCode=<%="'"+recommendationCode+"'"%>;

                                        }
                                        else{
                                            myAlert(result+"，请重试。");
                                        }
                                        disconnect();
                                    } catch (e) {
                                    }
                                }

                                function disconnect() {
                                    var CertCtl = document.getElementById("CertCtl");
                                    try {
                                        var result = CertCtl.CloseComm();
                                    } catch (e) {
                                    }
                                }
                            </script>
                        </form>
                    </div>
                    <!--身份认证end-->

                    <!--添加银行卡start-->
                    <div class="show1">
                        <form method="post" class="form-horizontal mar-top1" role="form" id="bankCardForm">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label for="inpFullNameForBankCard" class="col-sm-3 control-label">姓 名：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" id="inpFullNameForBankCard" name="inpFullNameForBankCard" placeholder="姓 名" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpIdentityCardNumberForBankCard" class="col-sm-3 control-label">身份证号：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" value="" name="inpIdentityCardNumberForBankCard" id="inpIdentityCardNumberForBankCard" placeholder="身份证号" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpBankCardNo" class="col-sm-3 control-label">银行卡号：</label>
                                    <div class="col-sm-8">
                                        <input type="text" value="" id="inpBankCardNo" name="inpBankCardNo" class="form-control" placeholder="银行卡号" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group marb">
                                    <label for="inpMobileForBankCard" class="col-sm-3 control-label">银行手机：</label>
                                    <div class="col-sm-8">
                                        <div class="col-sm-2">
                                            <select name="AreaCode" class="form-control" id="AreaCodeID1" style="width: 100px; margin-top: -3px">
                                                <option value="86">中国</option>
                                                <option value="81">日本</option>
                                            </select>
                                        </div>
                                        <div class="col-sm-1">
                                            <label id="ShowCode1" style="margin-top: 4px">86+</label>
                                        </div>
                                        <input type="text" value="" name="inpMobileForBankCard" id="inpMobileForBankCard" class="form-control" placeholder="请输入银行手机" required data-msg-required="不能为空" style="width: 75%" /><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group marb" id="divBankCardMobileValidCode">
                                    <label for="inpBankCardMobileValidCode" class="col-sm-3 control-label">银行手机验证码：</label>
                                    <div class="col-sm-8">
                                        <div style="width: 100%; float: left">
                                            <input type="text" id="inpBankCardMobileValidCode" name="inpBankCardMobileValidCode" style="width: 80%; float: left;" class="form-control" placeholder="请输入银行手机验证码" data-msg-required="不能为空" />
                                            <input id="btnGetBankCardMobileValidCode" name="btnGetBankCardMobileValidCode" type="button" style="width: 18%; background-color: #30abcd; float: left; margin-left: 10px; margin-top: 2px; border: none; height: 30px; border-radius: 2px;" value="获取验证码" class="btn mar-btn  btn-danger " onclick="getBankCardMobileValidCode(this)" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="text-center">
                                <input id="next-pho" type="button" value="下一步" class="sub2" />
                            </div>
                        </form>
                    </div>
                    <!--添加银行卡end-->

                    <!--照片识别Start-->
                    <div class="show2">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="pho-box">
                                        <div class="col-lg-12" style="margin-bottom: 20px;">
                                            <!-- FLASH调用 -->
                                            <div id="FalshDiv" style="text-align: center; display: none;">
                                                <object style="z-index: 100" id="My_Cam" align="middle" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
                                                    codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0"
                                                    height="400" viewastext="在线拍照" width="500">
                                                    <param name="allowScriptAccess" value="sameDomain" />
                                                    <param name="movie" value="/Test/camera/js/MyCamera.swf" />
                                                    <param name="quality" value="high" />
                                                    <param name="bgcolor" value="#ffffff" />
                                                    <param name="wmode" value="transparent" />
                                                    <embed style="z-index: 100" align="middle" allowscriptaccess="sameDomain" bgcolor="#ffffff" height="400"
                                                        name="My_Cam" pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high" wmode="transparent"
                                                        src="../Content/img/Mofang/MyCamera.swf" type="application/x-shockwave-flash" width="500"></embed>
                                                </object>
                                            </div>
                                            <!-- HTML5调用 -->
                                            <div id="HTML5Div" style="text-align: center; display: none;">
                                                <video id="video" width="500" height="400" autoplay></video>
                                                <canvas id="canvas" width="500" height="400" style="display: none;"></canvas>
                                            </div>

                                            <%--<div class="v-box"><span style="background: yellow; padding: 3px 12px 3px 12px">摄像头捕捉影像区域</span></div>--%>
                                        </div>
                                        <div class="col-lg-12 text-center">
                                            <div class="col-lg-3 col-sm-3  col-xs-6 ">
                                                <form id="photoForm1">
                                                    <img src="/Content/img/Mofang/df-pho.jpg" class="thumbnail img-responsive" id="showImg1" />
                                                    <button id="takePhoto" type="button" value="拍照" onclick="return photo(1);" class="btn mar-btn  btn-danger">正面脸拍照</button>
                                                </form>
                                            </div>
                                            <div class="col-lg-3 col-sm-3  col-xs-6 ">
                                                <form id="photoForm2">
                                                    <img src="/Content/img/Mofang/df-pho.jpg" class="thumbnail img-responsive" id="showImg2">
                                                    <button class="btn  mar-btom  btn-danger" id="" onclick="return photo(2);">左侧脸拍照</button>
                                                </form>
                                            </div>
                                            <div class="col-lg-3 col-sm-3  col-xs-6 ">
                                                <form id="photoForm3">
                                                    <img src="/Content/img/Mofang/df-pho.jpg" class="thumbnail img-responsive" id="showImg3">
                                                    <button class="btn mar-btom  btn-danger" id="" onclick="return photo(3);">右侧脸拍照</button>
                                                </form>
                                            </div>
                                            <div class="col-lg-3 col-sm-3  col-xs-6 ">
                                                <form id="photoForm4">
                                                    <img src="/Content/img/Mofang/df-pho.jpg" class="thumbnail img-responsive" id="showImg4">
                                                    <button class="btn mar-btom   btn-danger" id="" onclick="return photo(4);">仰脸拍照</button>
                                                </form>
                                            </div>

                                            <div class="col-lg-3 col-sm-3  col-xs-6 ">
                                                <form id="photoForm5">
                                                    <img src="/Content/img/Mofang/sfzz.jpg" class="thumbnail img-responsive" id="showImg5">
                                                    <button class="btn mar-btom  btn-danger" id="" onclick="return photo(5);">身份证正面</button>
                                                </form>
                                            </div>

                                            <div class="col-lg-3 col-sm-3  col-xs-6 ">
                                                <form id="photoForm6">
                                                    <img src="/Content/img/Mofang/sfzz.jpg" class="thumbnail img-responsive" id="showImg6">
                                                    <button class="btn mar-btom  btn-danger" id="" onclick="return photo(6);">身份证正面</button>
                                                </form>
                                            </div>
                                            <div class="col-lg-3 col-sm-3  col-xs-6 ">
                                                <form id="photoForm7">
                                                    <img src="/Content/img/Mofang/sfzf.jpg" class="thumbnail img-responsive" id="showImg7">
                                                    <button class="btn mar-btom  btn-danger" id="" onclick="return photo(7);">身份证反面</button>
                                                </form>
                                            </div>

                                            <div class="col-lg-3 col-sm-3  col-xs-6 ">
                                                <form id="photoForm8">
                                                    <img src="/Content/img/Mofang/sfzf.jpg" class="thumbnail img-responsive" id="showImg8">
                                                    <button class="btn mar-btom  btn-danger" id="" onclick="return photo(8);">身份证反面</button>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="text-center">
                            <input id="next-phorz" type="button" value="下一步" class="sub2" />
                        </div>
                    </div>
                    <!--照片识别end-->

                    <!--资料审核页面Start-->
                    <div class="show3">
                        <form class="form-horizontal mar-top1" role="form" id="infoForm">
                            <div class="col-lg-12 col-sm-12 col-xs-12 text-center" style="font-family: 微软雅黑; color: red; font-size: 30px">
                                <div class="form-group" id="divDataReview1">
                                    <p style="font-size: 26px; font-family: 微软雅黑; display: block; color: red;">开户审核中，请耐心等待。。。</p>
                                </div>
                                <div class="form-group" id="divDataReview2" style="display: none;">
                                    <span id="spOpenAccountResult">开户成功</span>
                                    <br />
                                    可用额度：<span id="spAvailableCredit">1000.00</span>
                                </div>
                            </div>
                            <div class="text-center">
                                <input id="next-zlsh" type="button" value="申请借款" class="sub2" />
                            </div>
                        </form>
                    </div>
                    <!--资料审核页面end-->

                    <!--借款申请Start-->
                    <div class="show4">
                        <form class="form-horizontal mar-top1" role="form" id="loanForm">
                            <div class="col-sm-12  text-center">

                                <div class="form-group" style="font-family: 微软雅黑; color: red; font-size: 30px">
                                    <div class="col-sm-12">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-6">
                                            借款金额<br />
                                            <input type="text" class="form-control" value="" name="inpLoanAmount" id="inpLoanAmount" placeholder="请输入借款金额" required data-msg-required="不能为空" />
                                        </div>
                                        <div class="col-sm-3"></div>
                                    </div>
                                </div>

                                <div class="form-group" style="font-family: 微软雅黑; color: red; font-size: 30px">
                                    <div class="col-sm-12 " style="font-family: 微软雅黑; color: red; font-size: 25px">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-6">
                                            <b style="color: #666">单笔可借</b> <span id="spLoanSection">500-3000</span>  <b style="color: #666">期限</b><span id="spBorrowDays">21</span><b style="color: #666">天</b><br />
                                        </div>
                                        <div class="col-sm-3"></div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="text-center">
                                        <input id="next-jksq" type="button" value="立即借款" class="sub2" />
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                    <!--借款申请end-->

                    <!--借款确认start-->
                    <div class="show5">
                        <form class="form-horizontal mar-top1" role="form" id="confirmForm">
                            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                                <div class="form-group" style="font-family: 微软雅黑; color: red; font-size: 30px">
                                    到账金额：<span id="spActuaAmount">950.00</span>
                                </div>
                                <div class="form-group">
                                    借款费用合计：<span id="spTotalAmount">50.00</span>
                                </div>
                                <div class="form-group">
                                    应还金额：<span id="spAmountPayable">1000.00</span>
                                </div>
                                <div class="form-group">
                                    到期时间：<span id="spExpiryDate">2018.02.15</span>
                                    <br />
                                    请按时还款，避免产生<a href="javascript:void(0)" style="color: red;">逾期费用</a>
                                </div>
                                <div class="form-group">
                                    提现卡：<span id="spCashCard">工商银行（1234）</span>
                                </div>
                                <div class="form-group">
                                    同意<a href="javascript:void(0)" id="protocol" onclick="return protocolClick();">《闪速借款服务协议》</a>
                                    <br />
                                    违约或预期将会记录到银行的信用报告中
                                </div>
                            </div>
                            <div class="text-center">
                                <input id="next-jkqr" type="button" value="确认借款" class="sub2" />
                            </div>
                        </form>
                    </div>
                    <!--借款确认end-->

                    <!--授权确认start-->
                    <div class="show6">
                        <form class="form-horizontal mar-top1" role="form" id="authorizationForm">
                            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                                <div class="form-group">
                                    <label for="inpIdentityCardNumberForMerchant" class="col-sm-3 control-label">管理员身份证：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" id="inpIdentityCardNumberForMerchant" name="inpIdentityCardNumberForMerchant" placeholder="输入管理员身份证" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpAccountExec" class="col-sm-3 control-label">授权账号：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" id="inpAccountExec" name="inpAccountExec" placeholder="输入授权账号" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inpAuthorizedPassword" class="col-sm-3 control-label">授权密码：</label>
                                    <div class="col-sm-8">
                                        <input type="password" class="form-control" id="inpAuthorizedPassword" name="inpAuthorizedPassword" placeholder="输入授权密码" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </div>
                            </div>
                            <div class="text-center">
                                <input id="next-auth" type="button" value="确认授权" class="sub2" />
                            </div>
                        </form>
                    </div>
                    <!--授权确认end-->

                    <!--借款结果Start-->
                    <div class="show7" style="margin-bottom: 120px">
                        <form class="form-horizontal mar-top1" role="form">
                            <div class="col-sm-12 " style="font-family: 微软雅黑; color: red; font-size: 30px">
                                <div class="form-group" id="divLoanAudit1">
                                    <div class="col-sm-12 text-center">
                                        借款审核中，请耐心等待。。。<br />
                                    </div>
                                </div>
                                <div class="form-group" id="divLoanAudit2" style="display: none;">
                                    <div class="col-sm-12 text-center">
                                        银行处理中，请耐心等待。。。<br />
                                    </div>
                                </div>
                                <div class="form-group" id="divLoanAudit3" style="display: none;">
                                    <div class="col-sm-12 text-center">
                                        <span id="spLoanSuccess">借款成功</span>
                                        <br />
                                        借款金额：<span id="spLoanAmount">1000.00</span>
                                    </div>
                                </div>
                            </div>
                            <div class="text-center" style="display: none;">
                                <input id="next-fh" type="button" value="返 回" class="sub2" />
                            </div>
                        </form>
                    </div>
                    <!--借款结果end-->
                </div>
            </div>
        </div>
    </div>
    <div id="loading"></div>
    <script type="text/javascript">
        $(document).ready(function () {
        });

        function myToDate(obj){            
            var time = new Date(obj);
            var y = time.getFullYear();//年
            var m = time.getMonth() + 1;//月
            var d = time.getDate();//日
            var h = time.getHours();//时
            var mm = time.getMinutes();//分
            var s = time.getSeconds();//秒
            var res = y + "-" + m + "-" + d;
            return res;
            //var res = y + "-" + m + "-" + d + " " + h + ":" + mm + ":" + s;
        }
        function protocolClick()
        {
            var url = "/loanprotocol.html";
            var iWidth = 800;
            var iHeight = 480;
            var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
            var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
            var win = window.open(url, "闪速借款服务协议", "width=" + iWidth + ", height=" + iHeight + ",top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no,alwaysRaised=yes,depended=yes");
            return false;
        }
    </script>
</body>
</html>
