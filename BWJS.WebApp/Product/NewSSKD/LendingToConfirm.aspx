<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LendingToConfirm.aspx.cs" Inherits="BWJS.WebApp.Product.NewSSKD.LendingToConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title></title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
     <script src="/Scripts/pagecommon.js"></script>
      <!--身份证扫描js开始(顺序不要变)-->
    <script src="/Scripts/IDCard/jquery.jBox-2.3.min.js"></script>
    <script src="/Scripts/IDCard/baseISSObject.js"></script>
    <script src="/Scripts/IDCard/baseISSOnline.js"></script>
    <script src="/Scripts/IDCard/common.js"></script>
    <!--身份证扫描js结束-->
</head>
<script>
    $(document).ready(function () {  
        $(".next-btn").click(function () {
            var inpAccountExec = $("#inpAccountExec").val();
            var inpAuthorizedPassword = $("#inpAuthorizedPassword").val();
            var certNumber = $("#certNumber").val(); 
            if (inpAccountExec == "" && inpAuthorizedPassword == "" && certNumber == "") {
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("确认没有商家特许授权放款吗？", function (result) {
                    if (result) {
                        $(".mask2").show();
                    }
                });
            } else {
                nextauth();
            }
        });

    }); 
    function nextauth() {
        if ($("#authorizationForm").valid()) {
            bootbox.setDefaults("locale", "zh_CN");
            bootbox.confirm("确认授权吗？", function (result) {
                if (result) {
                    bwjsLoadingDemo("努力加载中...");
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "newnetloan";
                    paramter.action = "confirmationofauthorization";
                    paramter.ConsultId = '<%=sskdModel.ConsultId%>';
                    paramter.sign = '<%=GetSign%>';
                    paramter.orderNo = '<%=sskdModel.OrderNo%>';
                    paramter.timeUnix = '<%=timeUnix%>';
                    paramter.merchantsAcount = $.trim($("#inpAccountExec").val());
                    paramter.authorizedPassword = $.trim($("#inpAuthorizedPassword").val());
                    paramter.merchantsIdCardNo = $.trim($("#certNumber").val());
                    paramter.token = $("#hiddToken").val();
                    paramter.equipmentNo = $("#hiddEquipmentNo").val();
                    paramter.borrowNo = $("#hidborrowNo").val();
                    paramter.merchantsNo = $("#hiddMerchantsNo").val();

                    var json = getJson(paramter, false);
                    if (json.success) {
                        $(".mask2").show();
                    } else {
                        myAlert(json.message);
                    }
                }
            });
        }
        return false;
    }
</script>
<body>
    <!--遮罩弹窗申请结果start-->
    <div class="mask2">
        <div class="pop-box">
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
                <span class="ts-msg1">您的贷款已提交，审核后会有专员客服与您联系，非常感谢！</span>
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
                <li class="" style="color:#FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot1.png"></span>人像采集</li>
                <li class="" style="color:#FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot2.png"></span>授权认证</li>
                <li class="" style="color:#FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot3.png"></span>评估报告</li>
                <li class="" style="color:#FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot5.png"></span>选择银行卡</li>
                <li class="" style="color:#FA6113"><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot4.png"></span>申请确认</li>

            </ul>
        </div>
        <!--步骤条end-->

        <!--放款确认start-->
        <form class="form-horizontal mar-top1" role="form" id="authorizationForm" enctype="application/x-www-form-urlencoded" runat="server" action="/Product/NewSSKD/AddBankCard">
            <%--        <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="">--%>
            <div class="col-sm-12 text-center til">
                <span class="til">商家特许放款确认</span>
            </div>
            <div class="col-sm-12 text-right">
                <div class="form-group">
                    <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">授权账号：</label>
                    <div class="col-lg-8 col-sm-8 col-xs-8">
                        <input type="text" class="form-control" id="inpAccountExec" name="" placeholder="请输入授权账号" data-msg-required="不能为空" data-msg-age="用户唯一标识" /><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">授权密码：</label>

                    <div class="col-lg-8 col-sm-8 col-xs-8">
                        <input type="password" value="" id="inpAuthorizedPassword" name="cardImgPro" class="form-control" placeholder="请输入授权密码" data-msg-required="不能为空" /><em>*</em>
                    </div>
                </div>
                <div class="form-group">
                    <label for="" class="col-lg-3 col-sm-3 col-xs-3 control-label">商家身份证号：</label>
                    <div class="col-lg-6 col-sm-6 col-xs-6">
                        <input type="text" class="form-control" value="" name="orderNo" id="certNumber" placeholder="请输入商家身份证号" /><em>*</em>
                    </div>
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                        <div class="yzm-btn" onclick="new Device().startFun()" id="button_readID">扫描身份证</div>
                    </div> 
                </div>
                <div class="col-lg-12 col-sm-12 col-xs-12">
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                    </div>
                    <div class="col-lg-6 col-sm-6 col-xs-6">
                        <a>
                            <div class="next-btn">下一步</div>
                        </a>
                    </div>
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                    </div>
                </div>
            </div>
            <div style="display: none">
                <input id="hidorderNo" name="hidorderNo" type="hidden" value="<%=sskdModel.OrderNo %>" />
                <input id="hiddToken" name="hiddToken" type="hidden" value="<%=sskdModel.Token %>" />
                <input id="hidConsultId" name="hidConsultId" type="hidden" value="<%=sskdModel.ConsultId %>" />
                <input id="hidsign" name="hidsign" type="hidden" value="<%=GetSign %>" />
                <input id="hiddEquipmentNo" name="hiddEquipmentNo" type="hidden" value="<%=sskdModel.MachineId %>" />
                <input id="hiddMerchantsNo" name="hiddMerchantsNo" type="hidden" value="<%=sskdModel.MerchantId %>" />
            </div>
        </form>
        <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
            <span class="ts-msg">重要提示：经商家特许授权后可直接放款，请商家谨慎审核，避免造成经济损失</span>
        </div>
        <!--放款确认end-->
    </div>
</body>

</html>
