<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TheAppraisalReport.aspx.cs" Inherits="BWJS.WebApp.Product.SSKD.TheAppraisalReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>评估报告</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <style>
        .wh96 {
            width: 96%;
        }
    </style>
</head>
<body>
    <form id="jsForm" style="font-size: 14px; font-style: normal" runat="server" action="/Product/NewSSKD/AddBankCard">
        <input id="hiddLoanLimte" name="hiddLoanLimte" type="hidden" value="0" />
        <input id="hiddNetLoanApplyId" name="hiddNetLoanApplyId" type="hidden" />
        <input id="hiddToken" name="hiddToken" type="hidden" />
        <input id="hiddLoanMinAmount" name="hiddLoanMinAmount" type="hidden" value="0" />
        <input id="hiddLoanMaxAmount" name="hiddLoanMaxAmount" type="hidden" value="3000" />
    </form>

    <!--用户报告更多详情-->
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
                <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot1.png"></span>人像采集</li>
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

            <iframe src="/Product/NewSSKD/ReportDemo.html" id="iframeId" frameborder="0"></iframe>

            <!--评估报告-->
            <div class="col-lg-12 col-sm-12 col-xs-12 hid">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6  ">
                    <a href="ExtractTheAmount.aspx">
                        <div class="next-btn-te" id="" style="margin-bottom: 30px; margin-top: 4px;">提 额</div>
                    </a>
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6 hid">
                    <a href="LineOfCredit.aspx">
                        <div class="next-btn-te" id="" style="margin-bottom: 30px; margin-top: 4px;">授 额</div>
                    </a>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>

            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">

                    <div class="next-btn" id="nextStep">下 一 步</div>

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
                    <img src="/Content/img/loadingsmall.gif" />&nbsp;&nbsp;报告正在生成中，请稍候。。。
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#nextStep").click(function () {
                nextStepClick();
            });
            
            $("#rptLoading").modal("show");
            reportProgressCheck();
        });
        
        var reportProgress = -1;
        function GetAppraisalReport() {
            var sskdRequestParas = {};
            sskdRequestParas.PageLoadDateTime = "<%=sskdRequestParas.PageLoadDateTime %>";
            sskdRequestParas.ConsultId = "<%=sskdModel.ConsultId %>";
            sskdRequestParas.Timestamp = "<%=sskdModel.TimeStamp %>";
            sskdRequestParas.Sign = "<%=GetSign %>";
            sskdRequestParas.OrderNo = "<%=sskdModel.OrderNo %>";
            sskdRequestParas.Token = "<%=sskdModel.Token %>";
            sskdRequestParas.EquipmentNo = "<%=sskdModel.MachineId %>";
            sskdRequestParas.MerchantsNo = "<%=sskdModel.MerchantId %>";

            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "AppraisalReport";
            paramter.ConsultId = '<%=sskdModel.ConsultId %>';
            paramter.sign = '<%=GetSign %>';
            paramter.orderNo = '<%=sskdModel.OrderNo %>';
            paramter.timeUnix = '<%=timeUnix%>';
            paramter.reportType = 'html';//html/json
            paramter.equipmentNo = '<%= sskdModel.MachineId %>';
            paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
            paramter.token = '<%= sskdModel.Token%>';
            paramter.sskdRequestParas = JSON.stringify(sskdRequestParas);
            paramter.timeUnix = new Date().getTime();
            $.ajax({
                type: "post",
                url: "/ajax/helper.ashx",
                data: paramter,
                dataType: "json",
                async: true,
                success: function (json) {
                    bwjsLoadingClose();
                    if (json.success) {
                        if (json.data != null && json.data != "") {
                            var progress = json.data.progress;
                            reportProgress = parseInt(progress);
                            if (progress != null && progress != "") {
                                switch (parseInt(progress)) {
                                    case -1://无报告
                                        break;
                                    case 0://报告正在生成中
                                        break;
                                    case 1://报告已生成
                                        $("#rptLoading").modal("hide");
                                        $("#iframeId").attr("src", json.data.html);
                                        //$("#iframeId").toggle();
                                        break;
                                }
                            }
                        }
                    }
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

        function nextStepClick() {
            var loanResult = getLoanParas();
            if(loanResult){
                bwjsLoadingDemo("努力加载中...");
                $("#jsForm").submit();
            }
            else{
            }
            return false;
        }
        
        //获取借款参数
        function getLoanParas() { 
            var result = false;
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "getloanparas";
            paramter.ConsultId =<%=sskdModel.ConsultId%>;
            paramter.sign = '<%=GetSign %>';
            paramter.orderNo = '<%=sskdModel.OrderNo %>';
            paramter.timeUnix = '<%=timeUnix %>';
            paramter.equipmentNo = '<%= sskdModel.MachineId %>';
            paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
            paramter.token = '<%= sskdModel.Token %>';
            var json = getJson(paramter, false);
                 
            //myAlert(JSON.stringify(json)); 
            if (json.success) {
                result = json.success;
            } else {
                //myAlert(json.message);
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("您的可用额度不够不符合借款要求，即将回到首页。", function (result) {
                    if (result) {
                        //window.location.href = "/Product/NewSSKD/Index";
                    }
                });
                return false;
            }
            return result;
        }

    </script>
</body>
</html>
