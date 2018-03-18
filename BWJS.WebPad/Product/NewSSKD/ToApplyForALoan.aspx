<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToApplyForALoan.aspx.cs" Inherits="BWJS.WebPad.Product.SSKD.ToApplyForALoan" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/bootstrap-select.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/consultjs.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap-select.js"></script>
    <link href="../../Content/img/default/layer.css" rel="stylesheet" />
    <script src="../../Scripts/layer.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <script>
        $(document).ready(function () {
            $(".head-btn").click(function () {
                $(".mask").fadeIn();
            });
            $(".btn-n").click(function () {
                $(".mask").fadeOut();
            });
            $(".yhxy").click(function () {
                $(".mask2").fadeIn();
            });
            $(".clo").click(function () {
                $(".mask2").fadeOut();
            });
            $(".next-btn-tc").click(function () {
                $(".mask2").hide();
            });
            $("#hiddCompanyId").val(<%=companyId%>);
        });

    </script>
    <style>
        .form-group {
            margin-bottom: 6px;
        }

        .he-box {
            width: 100%;
            height: 100px;
            float: left;
        }
    </style>
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
    <!--用户协议start-->

    <div class="mask2">
        <div class="col-lg-12 col-sm-12 col-xs-12">
            <iframe class="ifr-xy" src="xy.html" frameborder="0"></iframe>
        </div>
        <div class="clo">关闭</div>
    </div>

    <!--用户协议end-->
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

        <!--申请借款start-->
        <div class="formbox">
            <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NewSSKD/FillInTheInformation">

                <div class="col-sm-12 text-center til">
                    <span class="til1">申请借款</span>
                </div>


                <div class="col-lg-12 col-sm-12 col-xs-12 text-right">
                    <div class="form-group">
                        <label for="inpFullName" class="col-lg-2 col-sm-2 col-xs-2 control-label">姓 名：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <input type="text" class="form-control" id="inpFullName" name="inpFullName" maxlength="4" placeholder="请输入中文姓名"  />
                        </div>

                    </div>
                    <div class="form-group">
                        <label for="inpIdentityCardNumber" class="col-lg-2 col-sm-2 col-xs-2 control-label">身份证号：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <input type="text" id="inpIdentityCardNumber" name="inpIdentityCardNumber" onkeyup="clearNoNum(this)" onblur="clearNoNum(this)" class="form-control" placeholder="请输入身份证号" maxlength="18" required data-msg-required="扫描身份证"  />
                        </div>

                    </div>
                    <div class="form-group">
                        <label for="LoanAmountId" class="col-lg-2 col-sm-2 col-xs-2 control-label">期望金额：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <input type="text" id="LoanAmountId" name="LoanAmountId" class="form-control" placeholder="请输入金额" maxlength="6" onkeyup="this.value=this.value.replace(/\D/g,'');" required data-msg-required="不能为空"  />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="LoanTermId" class="col-lg-2 col-sm-2 col-xs-2 control-label">借款期限：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <select name="LoanTerm" id="LoanTermId" class="form-control" required>
                                <%=strLoanTerm %>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="LoanUseId" class="col-lg-2 col-sm-2 col-xs-2 control-label">借款用途：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <select name="LoanUse" id="LoanUseId" class="form-control" required>
                                <%=strLoanUse %>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="MobileId" class="col-lg-2 col-sm-2 col-xs-2 control-label">手机号：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <input type="text" class="form-control" value="" name="inpMobile" id="inpMobile" placeholder="请输入手机号" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="11" required data-rule-mobile="true" data-msg-required="请输入手机号" onkeyup="VMobileId();" data-msg-mobile="请输入手机号"  />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpValidCode" class="col-lg-2 col-sm-2 col-xs-2 control-label">验证码：</label>
                        <div class="col-lg-7 col-sm-6 col-xs-6">
                            <input type="text" id="inpValidCode" name="inpValidCode" class="form-control" placeholder="请输入验证码" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="4" required data-msg-required="请输入验证码"  />
                        </div>
                        <div class="col-lg-3 col-sm-4 col-xs-4 text-left">
                            <%-- <div  class="yzm-btn" id="ValidCodeBT">获取验证码</div>--%>
                            <input type="button" class="yzm-btn gl" style="color: white" value="点击发送验证码" onclick="sendCode(this)" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="" class="col-lg-2 col-sm-2 col-xs-2 control-label">
                            <input class="che" type="checkbox" id="checkboxId" name="checkboxId" checked="checked" /></label>
                        <div class="col-lg-9 col-sm-9 col-xs-9 text-left " style="color: #666; line-height: 45px;">
                            <i style="font-style: normal; font-size: 15px;" class="yd-text">我已阅读并同意</i><i style="color: #fb6113; font-style: normal; cursor: pointer; font-size: 18px;" class="yhxy">《用户协议》</i>
                        </div>
                    </div>

                </div>
                <div style="display: none">
                    <input id="hiddTimeStamp" name="hiddTimeStamp" type="hidden" />
                    <input id="hiddToken" name="hiddToken" type="hidden" />
                    <input id="hidConsultId" name="hidConsultId" type="hidden" />
                    <input id="hidIDNo" name="hidIDNo" type="hidden" />
                    <input id="hidMobile" name="hidMobile" type="hidden" />
                    <input id="hidOrderNo" name="hidOrderNo" type="hidden" />
                    <input id="hidmagId" name="hidmagId" value="<%=magId %>" type="hidden" />
                    <input id="hiddMemberFlag" name="hiddMemberFlag" type="hidden" value="0" />
                    <input id="hiddNetLoanApplyId" name="hiddNetLoanApplyId" type="hidden" />
                    <input id="hiddCompanyId" name="hiddCompanyId" type="hidden" />
                    <input id="hiddExpiredDate" name="hiddExpiredDate" type="hidden" />
                    <input id="hiddEffectedDate" name="hiddEffectedDate" type="hidden" />

                    <input id="hiddFullName" name="hiddFullName" type="hidden" />
                    <input id="hiddSex" name="hiddSex" type="hidden" />
                    <input id="hiddBirth" name="hiddBirth" type="hidden" />
                    <input id="hiddNational" name="hiddNational" type="hidden"  />
                    <input id="hiddAddress" name="hiddAddress" type="hidden" />
                    <input id="hiddAuthority" name="hiddAuthority" type="hidden" />
                    <input id="hiddValidperiod" name="hiddValidperiod" type="hidden" />
                    <input id="hiddEquipmentNo" name="hiddEquipmentNo" type="hidden" value="<%=equipmentNo %>" />
                    <input id="hiddMerchantsNo" name="hiddMerchantsNo" type="hidden" value="<%=merchantsNo %>" />
                    <input id="hiddPageLoadDateTime" name="hiddPageLoadDateTime" type="hidden" value="<%=sskdRequestParas.PageLoadDateTime %>" />
                     <input id="hidtimestamp" name="hidtimestamp" type="hidden"  />
                       <input id="hidsign" name="hidsign" type="hidden" value="" />
                    <input type="hidden" id="sedMSM" name="sedMSM" value="" />
                    <input type="hidden" id="NumberId" name="NumberId" value="" />
                    <input type="hidden" id="hidMoblie" name="hidMoblie" value="" />
                </div>
            </form>
        </div>

        <div class="col-lg-12 col-sm-12 col-xs-12">
            <div class="col-lg-3 col-sm-3 col-xs-3">
            </div>
            <div class="col-lg-6 col-sm-6 col-xs-6">
                <div id="next-info" class="next-btn sub2 mr" style="margin-top: 4px; margin-bottom: 0">下一步</div>
            </div>
            <div class="col-lg-3 col-sm-3 col-xs-3">
            </div>
        </div>

        <div class="he-box">
        </div>
        <!--申请借款end-->

    </div>
</body>
</html>
