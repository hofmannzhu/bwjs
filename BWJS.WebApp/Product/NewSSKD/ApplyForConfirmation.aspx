<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyForConfirmation.aspx.cs" Inherits="BWJS.WebApp.Product.SSKD.ApplyForConfirmation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/css/NewSSKD/main.css" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/NewSSKD/main.js"></script>
    <script src="/Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#inpLoanAmount").blur(function () {
                return loanMoneyChange();
            });
            
            getLoanParas();
            productSelect();
        }); 
    </script>
    <script> 
        //借款分期计算
        function calculationClick() {
            if(parasResult){
                $("#planList tbody").html("");
                var productId = $("#hidProduct").val();
                var loanAmount = parseFloat($.trim($("#inpLoanAmount").val()));
                var loanMoneyChcekResult = loanMoneyChange();
                if(loanMoneyChcekResult)
                {
                    var result = false;
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "newnetloan";
                    paramter.action = "StagingCalculation";//借款分期计算
                    paramter.ConsultId = '<%=sskdModel.ConsultId%>';
                    paramter.sign = '<%=GetSign%>';
                    paramter.orderNo = '<%=sskdModel.OrderNo%>';
                    paramter.timeUnix = '<%=timeUnix%>';
                    paramter.productId = productId;
                    paramter.loanAmount = loanAmount;
                    paramter.equipmentNo = '<%= sskdModel.MachineId %>';
                    paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
                    paramter.token = '<%= sskdModel.Token %>';
                    bwjsLoadingDemo("努力加载中...");
                    var json = getJson(paramter, false);
                    //myAlert(JSON.stringify(json));
                    if (json.success) {
                        //$(".jg").toggle();
                        $(".jg").show();
                        if (json.data != null && json.data != "") {
                            $("#jine").html(json.data.loanAmount.toFixed(2));
                            $("#fenqishu").html(json.data.periods);
                            var bills = json.data.bills;
                            $(bills).each(function (j) {
                                $("#planList tbody").append("<tr><td>" + bills[j].period + "</td><td>" + bills[j].interest + "</td><td>" + bills[j].principal + "</td><td>" + bills[j].returnAmount + "</td><td>" + bills[j].repaymentDate + "</td></tr>");
                            });
                        }
                    }
                    else {
                        myAlert(json.message);
                        $(".jg").hide();
                    }
                }
            }
            else{
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("您的可用额度不够不符合借款要求，即将回到首页。", function (result) {
                    if (result) {
                        window.location.href = "/Product/NewSSKD/Index";
                    }
                });
            }
            return false;
        }  
        //下一步
        function nextStepClick() {
            if(parasResult){
                var productId = $("#hidProduct").val();
                var loanAmount = parseFloat($.trim($("#inpLoanAmount").val()));
                var loanMoneyChcekResult = loanMoneyChange();
                if(loanMoneyChcekResult)
                {
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "newnetloan";
                    paramter.action = "LoanApplication";//借款分期计算  
                    paramter.ConsultId = '<%=sskdModel.ConsultId%>';
                    paramter.sign = '<%=GetSign%>';
                    paramter.orderNo = '<%=sskdModel.OrderNo%>';
                    paramter.timeUnix = '<%=timeUnix%>';
                    paramter.equipmentNo = '<%= sskdModel.MachineId %>';
                    paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
                    paramter.token = '<%= sskdModel.Token %>';
                    paramter.bankCardNo = '<%=bankCardNo %>';
                    paramter.productId = productId;
                    paramter.loanAmount = loanAmount; 

                    bwjsLoadingDemo("努力加载中...");
                    var json = getJson(paramter, false);
                    if (json.success) {
                        if (json.data != null && json.data != "") {                        
                            $(".mask2").show();
                            //$("#jsForm").submit();
                        }
                    }
                    else {
                        myAlert(json.message);
                        carSubmit = false;
                    }
                }
            }
            else{
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("您的可用额度不够不符合借款要求，即将回到首页。", function (result) {
                    if (result) {
                        window.location.href = "/Product/NewSSKD/Index";
                    }
                });
            }
            return false;
        } 
        
        var carSubmit = false;
        var parasResult = false;
        //获取借款参数
        function getLoanParas() { 
            var result = false;
            try {
                bwjsLoadingDemo("努力加载中...");
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
                    parasResult = true;
                    if (json.data != null && json.data != "") {
                        $("#hidMerchantsLending").val(json.data.merchantsLending);//当前设备是否能放款
                        $("#hidEquipmentLending").val(json.data.equipmentLending);//当前商户是否能放款
                        $("#hidUserLending").val(json.data.userLending);//当前用户是否能放款
                        $("#hidOraerNormal").val(json.data.oraerNormal);//当前订单是否正常
                        $("#hidMinAmount").val(json.data.minAmount);
                        $("#hidMaxAmount").val(json.data.maxAmount);
                        var placeholder = "请输入" + json.data.minAmount + "-" + json.data.maxAmount + "区间金额"
                        $("#inpLoanAmount").attr("placeholder", placeholder);

                        var debxhtml = "";//等额本息
                        var projectsList = eval(json.data.projects);
                            
                        for (var i = 0; i < projectsList.length; i++) { 
                            var psc = projectsList[i].stagingCode;
                            if (psc == "debx") {
                                var detailList = eval(projectsList[i].details);
                                for (var j = 0; j < detailList.length; j++) {
                                    var act = "";
                                    if (j == 0) {
                                        act = " class=\"active\"";
                                    }
                                    else{
                                        act = "";
                                    }
                                    debxhtml+="<div class=\"sel col-lg-3 col-sm-3 col-xs-3\">";
                                    debxhtml+="<span class=\"fq-box\">";
                                    debxhtml+="<p" + act + " product=\"" + detailList[j].projectId + "\"></p>";
                                    debxhtml+="<b>分 " + detailList[j].periods + " 期</b>";
                                    debxhtml+="</span>";
                                    debxhtml+="</div>";
                                }
                            }
                        }
                        $("#debx").html(debxhtml);

                        result = json.success;

                        $("#btnCalculation").removeClass("mr");
                        $("#btnCalculation").addClass("gl");
                        $("#btnCalculation").bind("click", function () {
                            return calculationClick();
                        });
                
                        $("#btnNextStep").removeClass("mr");
                        $("#btnNextStep").addClass("gl");
                        $("#btnNextStep").bind("click", function () {
                            if(!carSubmit){
                                carSubmit = true;
                                return nextStepClick();
                            }
                        });
                    }
                } else {
                    myAlert(json.message);

                    $("#btnCalculation").removeClass("gl");
                    $("#btnCalculation").addClass("mr");
                    $("#btnCalculation").unbind("click");
                
                    $("#btnNextStep").removeClass("gl");
                    $("#btnNextStep").addClass("mr");
                    $("#btnNextStep").unbind("click");
                }
            }
            catch (e) {
                myAlert(e.message);
            }
            return result;
        } 
        //判断输入金额
        function loanMoneyChange() {
            if($.trim($("#inpLoanAmount").val()) != ""){
                var loanAmount = parseFloat($.trim($("#inpLoanAmount").val()));
                var loanMinAmount = parseFloat($.trim($("#hidMinAmount").val()));
                var loanMaxAmount = parseFloat($.trim($("#hidMaxAmount").val()));
                if(loanMinAmount > 0 && loanMaxAmount > 0){
                    if (loanAmount < loanMinAmount) {
                        myAlert("申请金额有误，范围（" + loanMinAmount + "至" + loanMaxAmount + "）");
                        $("#inpLoanAmount").val("");
                        return false;
                    }
                    if (loanAmount > loanMaxAmount) {
                        myAlert("申请金额有误，范围（" + loanMinAmount + "至" + loanMaxAmount + "）");
                        $("#inpLoanAmount").val("");
                        return false;
                    }
                }
                else{
                    myAlert("您的可用额度不够不符合借款要求");
                    return false;
                }
            }
            else{
                myAlert("请输入申请贷款金额");
                return false;
            }
            return true;
        }
        //产品选择
        function productSelect() {
            $(".hk-sel .fs-sel p").each(function (i) {
                $(this).click(function () {
                    $(this).addClass("active").parents(".hk-sel").siblings(".hk-sel").children(".fs-sel").children("p").removeClass("active");
                    var curIndex = $('.hk-sel .fs-sel p').index(this);
                    $('.bnum').eq(curIndex).show().siblings('.bnum').hide();
                    if (i == 0) {
                        $(".sel .fq-box p").each(function (j) {
                            $(this).click(function () {
                                $(this).addClass("active").parents(".sel").siblings(".sel").children(".fq-box").children("p").removeClass("active");
                                $("#hidProduct").val($(this).attr("product"));
                            })
                            if (j == 0) {
                                $(this).click();
                            }
                        });
                    }
                    else if (i == 1) {
                        $(".sel2 .fq-box p").each(function (j) {
                            $(this).click(function () {
                                $(this).addClass("active").parents(".sel2").siblings(".sel2").children(".fq-box").children("p").removeClass("active");
                                $("#hidProduct").val($(this).attr("product"));
                            })
                            if (j == 0) {
                                $(this).click();
                            }
                        });
                    }
                });
                if (i == 0) {
                    $(this).click();
                }
            })
        }
    </script>
    <title></title>
</head>
<body>
    <!--遮罩弹窗申请结果start-->
    <div class="mask2">
        <div class="pop-box" style="border-radius: 8%;">
            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6 text-center mar">
                    <img src="../../../Content/img/NewSSKD/pic-jg.jpg" class="thumbnail img-responsive jg">
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>

            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                <span class="ts-msg1">暂时仅支持安卓手机</span>
                <span class="ts-msg1">您的贷款申请已提交,审核通过后会有专员客服联系您。</span>
                <span class="ts-msg1">请扫描上方二维码并下载APP可实时查询审核结果,后续的还款操作将在APP上进行</span>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="col-lg-2 col-sm-2 col-xs-2">
                </div>
                <div class="col-lg-8 col-sm-8 col-xs-8">
                    <a href="/Product/NewSSKD/Index.aspx">
                        <div class="next-btn-tc">完 成</div>
                    </a>
                </div>
                <div class="col-lg-2 col-sm-2 col-xs-2">
                </div>
            </div>
        </div>
    </div>

    <!--遮罩弹窗申请结果end-->
    <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NewSSKD/LendingToConfirm">
        <div class="main">
            <!--头部元素start-->
            <div class="head-box">
                <div class="col-lg-12">
                    <!--申请成功移动字幕start-->
                    <script src="/Scripts/NewSSKD/success.js"></script>
                    <div class="head-btn">取消申请</div>
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
                    <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot3.png"></span>评估报告</li>
                    <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD//tab-dot5.png"></span>选择银行卡</li>
                    <li class="" style="color: #FA6113"><span class="bg-r active">
                        <img src="../../Content/img/NewSSKD/tab-dot4.png"></span>申请确认</li>
                </ul>
            </div>
            <!--步骤条end-->
            <!--申请确认start-->

            <div class="hkbox">
                <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-bottom: 4%; margin-top: 30px;">
                    <div class="col-lg-3 col-sm-3 col-xs-3 text-left">
                        <span class="til-je">申请贷款金额:</span>
                    </div>
                    <div class="col-lg-9 col-sm-9 col-xs-9 ma">
                        <input type="text" value="" id="inpLoanAmount" name="inpLoanAmount" class="form-control je" style="font-size: 30px; height: 66px;" placeholder="最大申请金额15000元" onkeyup="this.value=this.value.replace(/\D/g,'')" maxlength="6" autocomplete="off" />
                    </div>
                </div>
                <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-bottom: 80px;">
                    <div class="col-lg-2 col-sm-2 col-xs-2 text-right">
                        <span class="til-je">还款方式:</span>
                    </div>
                    <div class="hk-sel col-lg-4 col-sm-4 col-xs-4 ma" style="padding-left: 115px;">
                        <div class="fs-sel bg2 active">
                            <p class="active"></p>
                            等额本息
                        </div>
                    </div>
                </div>
            </div>
            <div class="container" style="margin-bottom: 100px;">
                <div id="debx" class="col-lg-12 col-sm-12 col-xs-12 text-center bnum">
                    <%--        <div class="sel col-lg-3 col-sm-3 col-xs-3">
                        <span class="fq-box">
                            <p class="active"></p>
                            <b>分 1 期</b>
                        </span>
                    </div>--%>
                    <div class="sel col-lg-3 col-sm-3  col-xs-3">
                        <span class="fq-box">
                            <p></p>
                            <b>分 3 期</b>
                        </span>
                    </div>
                    <div class=" sel col-lg-3 col-sm-3 col-xs-3">
                        <span class="fq-box">
                            <p></p>
                            <b>分 6 期</b>
                        </span>
                    </div>
                    <div class=" sel col-lg-3 col-sm-3 col-xs-3">
                        <span class="fq-box">
                            <p></p>
                            <b>分12期</b>
                        </span>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-top: 50px">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <a href="javascript:void(0)">
                        <div class="js-btn" id="btnCalculation">计 算</div>
                    </a>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>

            <div class="container font1 jg hid">
                <table class="table table-bordered" style="margin-top: 30px; float: left; width: 94%; margin-left: 3%">
                    <tr>
                        <td>金额（元）</td>
                        <td id="jine">00.00</td>
                    </tr>
                    <tr>
                        <td>分期数</td>
                        <td id="fenqishu">0</td>
                    </tr>
                </table>
                <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                    <span class="til" style="margin-top: 0">分期详情</span>
                </div>
                <table class="table table-bordered " style="margin-top: 30px; float: left; width: 94%; margin-left: 3%" id="planList">
                    <thead>
                        <tr>
                            <th>期 数</th>
                            <th>月还利息（元）</th>
                            <th>月还本金（元）</th>
                            <th>应还金额（元）</th>
                            <th>还 款 日</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>12</td>
                            <td>0.6</td>
                            <td>2234432</td>
                            <td>5465465</td>
                            <td>2012-09-12</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-top: 75px">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <a href="javascript:void(0)">
                        <div class="next-btn" style="margin-top: 15px" id="btnNextStep">下 一 步</div>
                    </a>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
            <!--申请确认end-->
        </div>
        <input id="hidMerchantsLending" name="hidMerchantsLending" type="hidden" value="" />
        <input id="hidEquipmentLending" name="hidEquipmentLending" type="hidden" value="" />
        <input id="hidUserLending" name="hidUserLending" type="hidden" value="" />
        <input id="hidOraerNormal" name="hidOraerNormal" type="hidden" value="" />
        <input id="hidMinAmount" name="hidMinAmount" type="hidden" value="0" />
        <input id="hidMaxAmount" name="hidMaxAmount" type="hidden" value="0" />
        <input id="hidProduct" name="hidProduct" type="hidden" value="" />
        <input type="hidden" id="inpBankCardNo" name="inpBankCardNo" value="<%=bankCardNo %>" />
    </form>
</body>
</html>
