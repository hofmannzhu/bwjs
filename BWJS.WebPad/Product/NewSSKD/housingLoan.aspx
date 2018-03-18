<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="housingLoan.aspx.cs" Inherits="BWJS.WebPad.Product.NewSSKD.housingLoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>填写信息</title>
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js" type="text/javascript"></script>
</head>
<body>
    <div class="mask">
        <div class="pop-box-dhk">
            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                <span class="qr-msg1" style="height:140px;  padding-top:20px;  line-height: 35px;">您的房贷需求已提交，稍后会有专员客服与您联系，谢谢！！！</span>
                <div class="col-lg-3  col-sm-3 col-xs-3">
                </div>

                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <a href="home.aspx"><span class="btn-n" style=" background-color:#fb6113;">完 成</span></a>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
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
                <script src="/Scripts/NewSSKD/housing.js"></script>
            </div>
        </div>
        <!--头部元素end-->

        <!--填写信息start-->
        <div class="formbox">

            <form class="form-horizontal mar-top1" role="form" id="jsForm" runat="server">
                <div class="col-sm-12 text-center til">
                    <span class="til1">房贷平台</span>
                </div>

                <div class="form-group">
                    <label for="inpFullName" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">姓 名：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" class="form-control" id="inpFullName" name="inpFullName" placeholder="请输入您中文姓名" />
                    </div>

                </div>
                <div class="form-group">
                    <label for="inpIdentityCardNumber" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">身份证号：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" id="inpIdentityCardNumber" name="inpIdentityCardNumber" class="form-control" placeholder="请输入您的身份证号" required data-msg-required="扫描身份证" />
                    </div>

                </div>
                <div class="form-group">
                    <label for="inpMobile" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">电 话：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpMobile" name="inpMobile" maxlength="11" class="form-control" placeholder="请输入您的电话号码" />

                    </div>
                </div>


                <div class="form-group ma" style="margin-bottom: 18px;">
                    <label for="SeleCity3" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">房子所在地：</label>

                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpAddress" name="inpAddress" maxlength="50" class="form-control" placeholder="请输入房子所在地" />

                    </div>

                    <div class="col-lg-12 col-sm-12 col-xs-12">
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                        <div class="col-lg-6 col-sm-6 col-xs-6">
                            <div class="next-btn mr" id="nextStep" >确 定</div>
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        var companyId = 999;
        $(document).ready(function () {
            bindFormInpKeyupEvent();
        });
        var modelIdentityCardLibrary = {};
        var modelNetLoanApply = {};
    </script>
    <script type="text/javascript">
        function bindFormInpKeyupEvent() {
            $("#inpFullName").bind("blur", function () {
                formCheck();
            });
            $("#inpIdentityCardNumber").bind("blur", function () {
                formCheck();
            });
            $("#inpMobile").bind("blur", function () {
                formCheck();
            });
            $("#inpAddress").bind("blur", function () {
                formCheck();
            });
        }
        var flagSubmit = false;
        $(function () { 
            $("#nextStep").bind("click", function () {
                if (flagSubmit) {
                    var checkresult = nextStepCheck();
                    if (checkresult) {
                        bwjsLoadingDemo("努力加载中...");
                        var id = netLoanApply(); 
                        if (parseInt(id) > 0) {
                            $(".mask").show();
                        }
                    }
                }
            });
        });

        function formCheck() {
            if ($.trim($("#inpFullName").val()) &&
            $.trim($("#inpIdentityCardNumber").val()) &&
            $.trim($("#inpMobile").val()) &&
            $.trim($("#inpAddress").val())) {
                $("#nextStep").removeClass("mr");
                $("#nextStep").addClass("gl");
                flagSubmit = true;
                //nextStepCheck(); 
            }
            else {
                $("#nextStep").removeClass("gl");
                $("#nextStep").addClass("mr");
                flagSubmit = false;//得加这个效果好点点..
             //   $("#nextStep").unbind("click");
            }
        }

        function nextStepCheck() {
            if (!$("#inpFullName").val()) {
                myAlert('请填写姓名！');
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
                    if (JSON.stringify(modelIdentityCardLibrary) == "{}") {
                        modelIdentityCardLibrary.CompanyId = companyId;
                        modelIdentityCardLibrary.IdentityCardNumber = $("#inpIdentityCardNumber").val();
                        modelIdentityCardLibrary.FullName = $("#inpFullName").val();
                        modelIdentityCardLibrary.Sex = 0;
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
                        modelNetLoanApply.CompanyId = companyId;
                        modelNetLoanApply.FullName = $("#inpFullName").val();
                        modelNetLoanApply.IdCardType = 1;
                        modelNetLoanApply.IdCard = $("#inpIdentityCardNumber").val();
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
                    var json = getJson(paramter, false);
                    if (json.success) {
                        netLoanApplyId = json.data; 
                        $("#jsForm")[0].reset();
                    }
                }
            }
            catch (e) { myAlert(e.message); }
            return netLoanApplyId;
        }
    </script>
</body>
</html>
