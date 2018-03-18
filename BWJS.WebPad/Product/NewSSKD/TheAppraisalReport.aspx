<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TheAppraisalReport.aspx.cs" Inherits="BWJS.WebPad.Product.SSKD.TheAppraisalReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>评估报告</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#rptLoading2").modal("show");
            $(".head-btn").click(function () {
                $(".mask2").fadeIn();
            });
            $(".btn-n").click(function () {
                $(".mask2").fadeOut();
            });
        });
    </script>
    <style>
        .tab-box {
            height: 70px;
        }
    </style>
</head>

<body>


    <!--遮罩弹窗显示详情start-->
    <div class="mask">
        <form id="jsForm" style="font-size: 14px; font-style: normal" runat="server" action="/Product/NewSSKD/AddBankCard">
            <input id="hiddLoanLimte" name="hiddLoanLimte" type="hidden" value="0" />
            <input id="hiddNetLoanApplyId" name="hiddNetLoanApplyId" type="hidden" />
            <input id="hiddToken" name="hiddToken" type="hidden" />
            <input id="hiddLoanMinAmount" name="hiddLoanMinAmount" type="hidden" value="0" />
            <input id="hiddLoanMaxAmount" name="hiddLoanMaxAmount" type="hidden" value="3000" />
        </form>
    </div>

    <!--遮罩弹窗显示详情end-->
    <!--遮罩弹窗显示是和否start-->

    <div class="mask2">
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
                <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot1.png"></span>身份校验</li>
                <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot2.png"></span>授权认证</li>
                <li class="" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot3.png"></span>评估报告</li>
                <li class=""><span class="line"></span><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot5.png"></span>选择银行卡</li>
                <li class=""><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot4.png"></span>申请确认</li>
            </ul>
        </div>
        <!--步骤条end-->

        <!--评估报告start-->
        <div>
         <div class="modal fade" id="rptLoading2" tabindex="-1" role="dialog" aria-labelledby="loadingModalLabel" data-backdrop="false">
        <div class="modal-dialog" role="document" style="position: absolute; margin-top: 30%; margin-left: 33%;border-radius:20%;border:8px">
          
                    <img src="/Content/img/timg.gif"  style="width:50%"/>&nbsp;&nbsp;
              
        </div>
    </div>

            <iframe src="/Product/NewSSKD/ReportDemo.html" id="iframeId" frameborder="0"></iframe>

            <div class="col-lg-12 col-sm-12 col-xs-12">

                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <input class="next-btn" id="grantQuotaId" style="margin-bottom: 30px; margin-top: 4px;" value="授 额" onclick="return incrQuotaIdPage('quota');" />
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>


            <div class="col-lg-12 col-sm-12 col-xs-12">

                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <input class="next-btn" id="incrQuotaId" style="margin-bottom: 30px; margin-top: 4px;" value="提 额" onclick="return incrQuotaIdPage('improve');" />
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <input type="button" class="next-btn" id="nextStep" style="margin-bottom: 30px; margin-top: 4px;" value="下 一 步" onclick="NextBtnPage();" />
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>

        </div>

        <!--评估报告end-->

    </div>

        <div class="modal fade" id="rptLoading" tabindex="-1" role="dialog" aria-labelledby="loadingModalLabel" data-backdrop="false">
        <div class="modal-dialog" role="document" style="position: absolute; top: 40%; left: 30%;">
            <div class="modal-content">
                <div class="modal-body">
                    <img src="/Content/img/loadingsmall.gif" />&nbsp;&nbsp;
                </div>
            </div>
        </div>
    </div>

    <%-- <div class="modal fade" id="merchantCredit" tabindex="-1" role="dialog" aria-labelledby="merchantCreditModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="merchantCreditModalLabel">商户授信</h4>
                </div>
                <div class="modal-body">
                    <form class="form-horizontal" role="form" id="merchantCreditForm">
                        <div class="form-group">
                            <label for="firstname" class="col-sm-2 control-label">授信额度</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="inpCreditLine" name="inpCreditLine" placeholder="请输入授信额度" maxlength="4" onkeyup="this.value=this.value.replace(/\D/g,'');" required data-msg-required="授信额度不能为空" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inpAccountExec" class="col-sm-2 control-label">授权账号</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" id="inpAccountExec" name="inpAccountExec" placeholder="请输入授权账号" required data-msg-required="授权账号不能为空" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inpAuthorizedPassword" class="col-sm-2 control-label">授权密码</label>
                            <div class="col-sm-10">
                                <input type="password" value="" id="inpAuthorizedPassword" name="inpAuthorizedPassword" class="form-control" placeholder="请输入授权密码" required data-msg-required="授权密码不能为空" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inpIdentityCardNumberForMerchant" class="col-sm-2 control-label">身份证号</label>
                            <div class="col-sm-10">
                                <input type="text" class="form-control" value="" name="inpIdentityCardNumberForMerchant" id="inpIdentityCardNumberForMerchant" placeholder="请输入商家身份证号" required data-msg-required="商家身份证号不能为空" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <button type="button" class="btn btn-default" id="btnMerchantCreditForm">提 交</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>--%>
    <script src="/Scripts/messages_zh.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var lindex;
        var loanResult=false;
        var rules = {
            inpCreditLine: {
                required: true,
                maxlength: 4
            },
            inpAccountExec: {
                required: true
            },
            inpAuthorizedPassword: {
                required: true
            },
            inpIdentityCardNumberForMerchant: {
                required: true
            }
        };
        $.validator.setDefaults({
            errorElement: 'span',
            rules: rules
        });
        var canSubmit = false;
        $(document).ready(function () {
       
            $("#incrQuotaId").hide();
            $("#grantQuotaId").hide();
            $("#merchantCredit").modal("hide");
            $("#nextStep"). disabled= true;
            //获取用户报告
            reportProgressCheck();
            //获取借款参数
            //nextStepClick();
            //$("#nextStep").click(function () {
            //    if (!canSubmit) {
            //        canSubmit = true;
            //        nextStepClick();
            //    }
               
            //});
            //GetAppraisalReport();
         
            Querypermissions();
            //$("#btnMerchantCreditForm").click(function () {
            //    btnMerchantCreditFormClick();
            //});
            
            $("#inpCreditLine").change(function () {
                inpCreditLineChange();
            });
        });




        function  Querypermissions(){
            var paramter = {};
            var sskdRequestParas = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "querybusinesspermissions";
            sskdRequestParas.Timestamp= '<%=sskdModel.TimeStamp%>'
            sskdRequestParas.OrderNo = '<%=sskdModel.OrderNo%>';
            sskdRequestParas.Sign = '<%=GetSign%>';
            sskdRequestParas.EquipmentNo = '<%= sskdModel.MachineId %>';
            sskdRequestParas.MerchantsNo = '<%= sskdModel.MerchantId %>';
            sskdRequestParas.Token = '<%= sskdModel.Token%>';
            sskdRequestParas.MerchantNo = '<%= sskdModel.MerchantId%>';
            sskdRequestParas.orderSource="BWPAD";
            paramter.sskdRequestParas=JSON.stringify(sskdRequestParas);
            var json = getJson(paramter, false);
            if (json.success) {
                if (json.data.grantQuota) {
                    if (accountAmount<=0) {
                        if (json.data.avaiBalance>0) {
                            $("#grantQuotaId").show();
                        }
                    }

                }
                if (json.data.incrQuota) {
                    if (accountAmount>0) {
                        if (json.data.avaiBalance>0) {
                            $("#incrQuotaId").show();
                        }
                    }
                } 
            }
            else {
                //myAlert(json.message);
                layer.close(lindex);
            }
        }


        var reportProgress = -1;
        function GetAppraisalReport() {

            //lindex = layer.load("请稍等...");
            var sskdRequestParas = {};
            sskdRequestParas.PageLoadDateTime = "<%=sskdRequestParas.PageLoadDateTime %>";
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "AppraisalReport";
            paramter.ConsultId = '<%=sskdModel.ConsultId%>';
            paramter.Sign = '<%=GetSign%>';
            paramter.OrderNo = '<%=sskdModel.OrderNo%>';
            paramter.TimeUnix = '<%=timeUnix%>';
            paramter.ReportType = 'html';
            paramter.EquipmentNo = '<%= sskdModel.MachineId %>';
            paramter.MerchantsNo = '<%= sskdModel.MerchantId %>';
            paramter.Token = '<%= sskdModel.Token%>';
            paramter.sskdRequestParas = JSON.stringify(sskdRequestParas);
            //var json = getJson(paramter, true);

            $.ajax({
                async: true,
                type: 'post',
                url: "/ajax/helper.ashx",
                dataType: 'json',
                data: paramter,
                success: function (json) {
                    bwjsLoadingClose();
                    if (json.data!=null&&json.data!="") {
                        var progress = json.data.progress; var progress = json.data.progress;
                        if (progress != null && progress != "") {
                            reportProgress = parseInt(progress);
                            switch (parseInt(progress)) {
                                case -1://无报告
                                    break;
                                case 0://报告正在生成中
                                    break;
                                case 1://报告已生成
                                    $("#rptLoading2").modal("hide");
                                    //layer.close(lindex);
                                    break;
                            }
                        }
                        $("#iframeId").attr("src", json.data.html);
                    }
                },
                error: function () {
                    //layer.close(lindex);
                    //bwjsLoadingClose();
                }
            })
            //layer.close(lindex);
        }
        
        var reportProgressTimer;
        function reportProgressCheck() {
            if (reportProgress == 1) {
                clearTimeout(reportProgressTimer);
            }
            else {
                GetAppraisalReport();
                reportProgressTimer = setTimeout(function () {
                    reportProgressCheck();
                }
                , 3000)
            }
        }

        //提额
        function incrQuotaIdPage(type){
            bwjsLoadingDemo("努力加载中...");
            //incrQuota//tie
            //grantQuota
            window.location.href = "/Product/NewSSKD/ExtractTheAmount.aspx?authorizedType="+type;
        }
        //下一步
      
        function NextBtnPage(){
            if (getLoanParas()) {
                $("#jsForm").submit();
            }
        }


        function nextStepClick() {
            loanResult = getLoanParas();
           
            return loanResult;
        }
        var accountAmount=0;
        //获取借款参数
        function getLoanParas() { 
            lindex = layer.load("请稍等...");
            var result = false;
            try {
                //bwjsLoadingDemo("努力加载中...");
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "newnetloan";
                paramter.action = "getloanparas";
                paramter.ConsultId =<%=sskdModel.ConsultId%>;
                paramter.Sign = '<%=GetSign %>';
                paramter.OrderNo = '<%=sskdModel.OrderNo %>';
                paramter.TimeUnix = '<%=timeUnix %>';
                paramter.EquipmentNo = '<%= sskdModel.MachineId %>';
                paramter.MerchantsNo = '<%= sskdModel.MerchantId %>';
                paramter.Token = '<%= sskdModel.Token %>';
                var json = getJson(paramter, false);
                //myAlert(JSON.stringify(json)); 
                layer.close(lindex);
                if (json.success) {
                    result = json.success;
                    accountAmount= json.accountAmount;
                } else {
                    myAlert(json.message);
                    
                    //$("#merchantCredit").modal("show");

                    //$("#btnMerchantCreditForm").click(function () {
                    //    btnMerchantCreditFormClick();
                    //});
                    
                    //bootbox.setDefaults("locale", "zh_CN");
                    //bootbox.confirm("您的可用额度不够不符合借款要求，即将回到首页。", function (result) {
                    //    if (result) {
                    //        //window.location.href = "/Product/NewSSKD/home";
                    //    }
                    //});
                    return false;
                }
            }
            catch (e) {
                myAlert(e.message);
            }
            return result;
        }
        

<%--        //获取商户授权API
        function MerchantAcceptance() { 
            //lindex = layer.load("请稍等...");
            var result = false;
            try {
                //bwjsLoadingDemo("努力加载中...");
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "newnetloan";
                paramter.action = "merchantacceptance";
                paramter.timestamp ='<%=sskdModel.TimeStamp%>';
                paramter.ConsultId =<%=sskdModel.ConsultId%>;
                paramter.sign = '<%=GetSign %>';
                paramter.orderNo = '<%=sskdModel.OrderNo %>';
                paramter.timeUnix = '<%=timeUnix %>';
                paramter.equipmentNo = '<%= sskdModel.MachineId %>';
                paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
                paramter.token = '<%= sskdModel.Token %>';
                paramter.orderSource = 'BWPAD';
           
                //string amount = DNTRequest.GetString("amount");
                //string merchantsAcount = DNTRequest.GetString("merchantAcount");
                //string merchantsIdCardNo = DNTRequest.GetString("merchantIdCardNo");
                //string authorizedPassword = DNTRequest.GetString("merchantPassword");
                //string sskdRequestParas = DNTRequest.GetString("sskdRequestParas");
              
    
                var json = getJson(paramter, false);
                //layer.close(lindex);
                //myAlert(JSON.stringify(json)); 
                if (json.success) {
                    result = json.success;
                } else {
                    myAlert(json.message);
                    return false;
                }
            }
            catch (e) {
                myAlert(e.message);
            }
            return result;
        }--%>

        //function btnMerchantCreditFormClick(){
        //    if($("#merchantCreditForm").valid()){
        //        return merchantSignIn();
        //    }
        //}

        function inpCreditLineChange(){
            var result = false;
            var creditLine = parseFloat($.trim($("#inpCreditLine").val()));
            if (creditLine > 1000 && creditLine < 10000) {
                result = true;
            }
            else{
                layer.msg("申请授信额度10000以内");
                $("#inpCreditLine").val("");
            }
            return result;
        }
        
        function merchantValidate() {
            if (!$("#inpAccountExec").val()) {
                layer.msg('商家授权账号不能为空');
                return false;
            }
            else{
                var un = /^\w+$/;
                if (!un.test($("#inpAccountExec").val())) {
                    layer.msg("商家授权账号只能为字母、数字或下划线的组合");
                    return false;
                }
                else {
                    var ulen = $("#inpAccountExec").val().length;
                    if (ulen < 5 || ulen > 15) {
                        layer.msg("商家授权账号长度必须在5至15位之间");
                        return false;
                    }
                }
            }
            if (!$("#inpAuthorizedPassword").val()) {
                layer.msg('商户授权密码不能为空');
                return false;
            }
            else {
                var ulen = $("#inpAuthorizedPassword").val().length;
                if (ulen < 6 || ulen > 16) {
                    layer.msg("商户授权密码长度必须在6至16位之间");
                    return false;
                }
            }

            if (!$("#inpIdentityCardNumberForMerchant").val()) {
                layer.msg('商户授权身份证号不能为空');
                return false;
            }
            else{
                var un = /^\w+$/;
                if (!un.test($("#inpIdentityCardNumberForMerchant").val())) {
                    layer.msg("商户授权身份证号输入有误，不能包含特殊字符");
                    return false;
                }
                else {
                    var isIDCard2 = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;//(18位)
                    var lengthvalue = document.getElementById('inpIdentityCardNumberForMerchant').value.length;
                    if (lengthvalue == 18) {
                        if (isIDCard2.test(document.getElementById('inpIdentityCardNumberForMerchant').value) === false) {
                            layer.msg('商户授权身份证号输入不合法,请重新填写！');
                            return false;
                        }
                        else {
                            return true;
                        }
                    } else {
                        layer.msg('商户授权身份证号位数不正确,请重新填写！');
                        return false;
                    }
                }
            }
            return true;
        }
        
        <%--        function merchantSignIn() {           
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "confirmationofauthorization";
            paramter.ConsultId = '<%=sskdModel.ConsultId %>';
            paramter.sign = '<%=GetSign%>';
            paramter.orderNo = '<%=sskdModel.OrderNo %>';
            paramter.timeUnix = '<%=sskdModel.TimeStamp %>';
            paramter.merchantAcount = $.trim($("#inpAccountExec").val());
            paramter.merchantPassword = $.trim($("#inpAuthorizedPassword").val());
            paramter.merchantIdCardNo = $.trim($("#inpIdentityCardNumberForMerchant").val());
            paramter.creditLine = $.trim($("#inpCreditLine").val());
            paramter.token = '<%=sskdModel.Token %>';
            paramter.equipmentNo = '<%=sskdModel.MachineId %>';
            paramter.merchantsNo = '<%=sskdModel.MerchantId %>';

            var json = getJson(paramter, false);
            if (json.success) {
                $("#merchantCredit").modal("hide");
                $("#jsForm").submit();
                //layer.close(lindex);

            } else {
                layer.msg(json.message);
            }
        }--%>
    </script>
</body>
</html>
