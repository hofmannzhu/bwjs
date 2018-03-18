<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyForConfirmation.aspx.cs" Inherits="BWJS.WebPad.Product.SSKD.ApplyForConfirmation" %>

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
        $(document).ready(function () {
            $(".mask8").css("z-index",999);
            $(".ifr-xy").css("z-index",999);
           
           
            $(".mask9").css("z-index",0);
            $(".mask8").fadeOut();
            $(".mask9").fadeOut();
            $(".head-btn").click(function () {
                $(".mask").fadeIn();
            });
            $(".btn-n").click(function () {
                $(".mask").fadeOut();
            });

            $(".jkxy").click(function () {
                $(".mask8").fadeIn();
            });
            $(".wtdkksqs").click(function () {
                $(".mask9").fadeIn();
            });

            $(".clo8").click(function () {
                $(".mask8").fadeOut();
            });
            $(".clo9").click(function () {
                $(".mask9").fadeOut();
            });
            //调取安卓方法
           
        });
   
    </script>



    <script type="text/javascript">
        $(function () {
            $("#inpLoanAmount").change(function () {
                loanMoneyChange();
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
                var loanAmount = $.trim($("#inpLoanAmount").val());
                if (loanAmount == "") {
                    myAlert("请输入期望贷款金额");
                    return false;
                }
                bwjsLoadingDemo("努力加载中...");
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
                var json = getJson(paramter, false);
                //myAlert(JSON.stringify(json));
             
                if (json.success) {
                    $(".jg").toggle();
                    if (json.data != null && json.data != "") {
                        $("#jine").html(json.data.loanAmount.toFixed(2));
                        $("#zonglixi").html(json.data.allInterest.toFixed(2));
                        $("#fenqishu").html(json.data.periods);
                        $("#zonghuankuan").html(json.data.allReturnAmount.toFixed(2));
                        var bills = json.data.bills;
                        if(bills.length>0){
                            $(bills).each(function (j) {
                                $("#planList tbody").append("<tr><td>" + bills[j].period + "</td><td>" + bills[j].interest + "</td><td>" + bills[j].principal + "</td><td>" + bills[j].returnAmount + "</td><td>" + bills[j].repaymentDate + "</td></tr>");
                            });
                        }
                    }
                }
                else {
                    myAlert(json.message);
                }
            }
            else{
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("您的可用额度不够不符合借款要求，即将回到首页。", function (result) {
                    if (result) {
                        window.location.href = "/Product/NewSSKD/home";
                    }
                });
            }
            return false;
        }  
        //下一步
        function nextStepClick() {
            if(parasResult){
                var productId = $("#hidProduct").val();
                var loanAmount = $.trim($("#inpLoanAmount").val());
                if (loanAmount == "") {
                    myAlert("请输入期望贷款金额");
                    return false;
                }
                bwjsLoadingDemo("努力加载中...");
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
                var json = getJson(paramter, false);
                if (json.success) {
                    if (json.data != null && json.data != "") {
                        var borrowNo=data.borrowNo;
                        //$("#jsForm").submit();
                        $(".mask2").show();
                    }
                }
                else {
                    canSubmit = false;
                    myAlert(json.message);
                }
            }
            else{
                canSubmit = false;
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("您的可用额度不够不符合借款要求，即将回到首页。", function (result) {
                    if (result) {
                        window.location.href = "/Product/NewSSKD/home";
                    }
                });
            }
            return false;
        } 
        var canSubmit = false;
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
                        $("#btnCalculation").click(function () {
                            return calculationClick();
                        });
                
                        $("#btnNextStep").removeClass("mr");
                        $("#btnNextStep").addClass("gl");
                        $("#btnNextStep").click(function () {
                            if (!canSubmit) {
                                canSubmit = true;
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
            var loanAmount = parseFloat($.trim($("#inpLoanAmount").val()));
            var loanMinAmount = parseFloat($.trim($("#hidMinAmount").val()));
            var loanMaxAmount = parseFloat($.trim($("#hidMaxAmount").val()));
            if (loanAmount < loanMinAmount) {
                myAlert("申请金额有误，范围（" + loanMinAmount + "至" + loanMaxAmount + "）");
                $("#inpLoanAmount").val("");
            }
            if (loanAmount > loanMaxAmount) {
                myAlert("申请金额有误，范围（" + loanMinAmount + "至" + loanMaxAmount + "）");
                $("#inpLoanAmount").val("");
            }
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


    <!--遮罩弹窗申请结果start-->
    <div class="mask2">
        <div class="pop-box-qd" style="border-radius: 8%; height: 480px;">
            <div class="col-lg-12 col-sm-12 col-xs-12" style="padding-left: 0;">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6 text-center mar" style="margin-top: 40px; padding-left: 0;">
                    <img src="../../../Content/img/NewSSKD/pic-jg.jpg" style="width: 200px; height: 200px" />
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>

            <div class="col-lg-12 col-sm-12 col-xs-12 text-center" style="padding-left: 0;">
                <span style="font-size: 14px; padding-top: 5px; display: inline-block; width: 100%;">暂时仅支持安卓手机</span>
                <br />
                <br />
                <%--  <span class="ts-msg1">您的贷款申请已提交,审核通过后会有专员客服联系您。</span>--%>
                <span style="margin-top: -11px; font-size: 18px; display: inline-block; padding: 20px;">请扫描上方二维码并下载APP可实时查询审核结果,     后续的还款操作将在APP上进行   </span>
            </div>
            <a href="/Product/NewSSKD/home.aspx">
                <div class="next-btn-wc">完 成</div>
            </a>
        </div>
    </div>

    <!--遮罩弹窗申请结果end-->

    <!--遮罩弹窗显示是和否start-->


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
                <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot3.png"></span>评估报告</li>
                <li class="" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD//tab-dot5.png"></span>选择银行卡</li>
                <li class="" style="color: #FA6113"><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot4.png"></span>申请确认</li>
            </ul>
        </div>
        <!--步骤条end-->
        <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NewSSKD/LendingToConfirm">
            <!--申请确认start-->
            <div class="hkbox">
                <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-bottom: 40px;">
                    <div class="col-lg-3 col-sm-3 col-xs-3 text-right">
                        <span class="til-je">申请贷款金额 :</span>
                    </div>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpLoanAmount" name="inpLoanAmount" class="form-control je" placeholder="最大申请金额15000元" onkeyup="this.value=this.value.replace(/\D/g,'')" maxlength="6" autocomplete="off" />
                    </div>
                    <input id="hidMerchantsLending" name="hidMerchantsLending" type="hidden" value="" />
                    <input id="hidEquipmentLending" name="hidEquipmentLending" type="hidden" value="" />
                    <input id="hidUserLending" name="hidUserLending" type="hidden" value="" />
                    <input id="hidOraerNormal" name="hidOraerNormal" type="hidden" value="" />
                    <input id="hidMinAmount" name="hidMinAmount" type="hidden" value="" />
                    <input id="hidMaxAmount" name="hidMaxAmount" type="hidden" value="" />
                    <input id="hidProduct" name="hidProduct" type="hidden" value="" />
                    <input type="hidden" id="inpBankCardNo" name="inpBankCardNo" value="<%=bankCardNo %>" />
                </div>
                <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-bottom: 50px;">
                    <div class="col-lg-2 col-sm-2 col-xs-3 text-right">
                        <span class="til-je" style="color: #333;">还款方式 :</span>
                    </div>
                    <div class="hk-sel col-lg-6 col-sm-4 col-xs-4">
                        <div class="fs-sel bg2 active">
                            <p class="active"></p>
                            等额本息
                        </div>
                    </div>
                </div>
            </div>


            <div id="debx" class="col-lg-12 col-sm-12 col-xs-12 text-center bnum">
                <%--   <div class="sel col-lg-3 col-sm-3 col-xs-6" style="margin-bottom: 30px;">
                    <span class="fq-box">
                        <p class="active"></p>


                        <b>分1期</b>
                    </span>
                </div>--%>
                <div class="sel col-lg-3 col-sm-3  col-xs-6" style="margin-bottom: 30px;">
                    <span class="fq-box">
                        <p></p>
                        <b>分3期</b>
                    </span>
                </div>
                <div class=" sel col-lg-3 col-sm-3 col-xs-6" style="margin-bottom: 30px;">
                    <span class="fq-box">
                        <p></p>
                        <b>分6期</b>
                    </span>
                </div>
                <div class=" sel col-lg-3 col-sm-3 col-xs-6" style="margin-bottom: 30px;">
                    <span class="fq-box">
                        <p></p>
                        <b>分12期</b>
                    </span>
                </div>

            </div>
            <br />
            <br />
            <div class="form-group" style="margin-top: 50px">
                <label for="" class="col-lg-2 col-sm-2 col-xs-2 control-label">
                    <input class="che" type="checkbox" id="checkboxId" name="checkboxId"  style="margin-left:80px" checked="checked" /></label>
                <div class="col-lg-9 col-sm-9 col-xs-9 text-left " style="color: #666; line-height: 45px;">
                    <i style="font-style: normal; font-size: 15px;" class="yd-text">我已阅读并同意</i><i style="color: #fb6113; font-style: normal; cursor: pointer; font-size: 18px;" class="jkxy">《借款协议》</i><i style="color: #fb6113; font-style: normal; cursor: pointer; font-size: 18px;" class="wtdkksqs">《委托代扣款授权书》</i>
                </div>
            </div>
            <br />
            <br />
            <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-top: 50px">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <a href="javascript:void(0)">
                        <div class="js-btn mr" id="btnCalculation">计 算</div>
                    </a>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
            <div>
                <div class="pop-box-js">
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
                            </tbody>
                        </table>
                    </div>


                </div>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <a href="javascript:void(0)">
                        <div class="next-btn mr" style="margin-top: 25px" id="btnNextStep">下 一 步</div>
                    </a>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
            <!--申请确认end-->
            <!--start-->

            <div class="mask8">
                <div class="col-lg-12 col-sm-12 col-xs-12">
                    <iframe class="ifr-xy" src="jkxy.html" frameborder="0"></iframe>
                </div>
                <div class="clo clo8">关闭</div>
            </div>

            <!--end-->
            <!--start-->

            <div class="mask9">
                <div class="col-lg-12 col-sm-12 col-xs-12">
                    <iframe class="ifr-xy" src="wtdkksqs.html" frameborder="0"></iframe>
                </div>
                <div class="clo clo9">关闭</div>
            </div>



            <!--end-->
        </form>
    </div>

</body>
</html>
