<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToApplyForALoan.aspx.cs" Inherits="BWJS.WebApp.Product.SSKD.ToApplyForALoan" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>申请借款</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
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
    <!--身份证扫描js结束-->
    <script src="/Scripts/NewSSKD/consultjs.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $(".yhxy").click(function () {
                $(".mask2").fadeIn();
            });

            $(".next-btn-tc").click(function () {
                $(".mask2").fadeOut();
            });
        });
    </script>
</head>
<body>

    <div class="mask2">
        <div class="pop-box-xy">

            <iframe class="ifr-xy" src="xy.html" frameborder="0"></iframe>



            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <div class="next-btn-tc">确 认</div>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
        </div>
    </div>


    <div class="main">
        <!--头部元素start-->
        <div class="head-box">
            <div class="col-lg-12">
                <!--申请成功移动字幕start-->
                <script src="/Scripts/NewSSKD/success.js"></script>
            </div>
        </div>
        <!--头部元素end-->

        <!--申请借款start-->
        <div class="formbox">
            <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" action="/Product/NewSSKD/FillInTheInformation">

                <div class="col-sm-12 text-center til">
                    <span class="til1">申 请 借 款</span>
                </div>
                <div class="col-lg-12 col-sm-12 col-xs-12 text-right">
                    <div class="form-group">
                        <label for="inpFullName" class="col-lg-2 col-sm-2 col-xs-2 control-label">姓 名：</label>
                        <div class="col-lg-7 col-sm-7 col-xs-7">
                            <input type="text" class="form-control" id="inpFullName" name="inpFullName" placeholder="中文姓名" disabled="disabled" style="background: #ddd" />
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3 text-left">
                            <div class="sfz-btn" onclick="new Device().startFun()" id="button_readID">身份证扫描</div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpIdentityCardNumber" class="col-lg-2 col-sm-2 col-xs-2 control-label">身份证号：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <input type="text" id="inpIdentityCardNumber" name="inpIdentityCardNumber" class="form-control" placeholder="身份证号" required data-msg-required="扫描身份证" disabled="disabled" style="background: #ddd" />
                        </div>

                    </div>
                    <div class="form-group" style="display: none">
                        <label for="Sex" class="col-sm-3 control-label">性 别：</label>
                        <div class="col-sm-8">
                            <label>
                                <input style="width: 22px; height: 22px;" id="inpSex1" name="Sex" type="radio" value="1" />
                                男</label>
                            <label>
                                <input style="width: 22px; height: 22px;" id="inpSex0" name="Sex" type="radio" checked="checked" value="0" />
                                女</label>
                        </div>
                    </div>
                    <div class="form-group" style="display: none">
                        <label for="inpBirthDay" class="col-sm-3 control-label">出生日期：</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" value="" name="inpBirthDay" id="inpBirthDay" placeholder="请输入例如：1900-01-01" data-msg-required="不能为空" data-msg-minlength="请输入出生年月" />
                        </div>
                    </div>
                    <div class="form-group" style="display: none">
                        <label for="inpNation" class="col-sm-3 control-label">民族：</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" value="" name="inpNation" id="inpNation" placeholder="请输入民族" data-msg-required="不能为空" data-msg-minlength="请输入民族">
                        </div>
                    </div>
                    <div class="form-group" style="display: none">
                        <label for="inpAddress" class="col-sm-3 control-label">住址：</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" value="" name="inpAddress" id="inpAddress" placeholder="请输入住址" data-msg-required="不能为空" data-msg-minlength="请输入住址" />
                        </div>
                    </div>
                    <div class="form-group" style="display: none">
                        <label for="inpIssuedAt" class="col-sm-3 control-label">签发机关：</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" value="" name="inpIssuedAt" id="inpIssuedAt" placeholder="请输入签发机关" data-msg-required="不能为空" data-msg-minlength="请输入签发机关" />
                        </div>
                    </div>
                    <div class="form-group" style="display: none">
                        <label for="inpExpiredDate" class="col-sm-3 control-label">有效期：</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" value="" name="inpExpiredDate" id="inpExpiredDate" placeholder="请输入例如：20171129-20371129" data-msg-required="不能为空" data-msg-minlength="请输入有效期" />
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
                        <label for="" class="col-lg-2 col-sm-2 col-xs-2 control-label">期望金额：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <input type="text" id="LoanAmountId" name="LoanAmountId" maxlength="6" onkeyup="this.value=this.value.replace(/\D/g,'');" class="form-control" placeholder="请输入金额" required data-msg-required="不能为空" autocomplete="off" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="" class="col-lg-2 col-sm-2 col-xs-2 control-label">借款期限：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <select name="LoanTermId" id="LoanTermId" class="form-control" required>
                                <%=strLoanTerm %>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="" class="col-lg-2 col-sm-2 col-xs-2 control-label">借款用途：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <select name="LoanUseId" id="LoanUseId" class="form-control" required>
                                <%=strLoanUse %>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="MobileId" class="col-lg-2 col-sm-2 col-xs-2 control-label">手机号：</label>
                        <div class="col-lg-9 col-sm-9 col-xs-9">
                            <input type="text" class="form-control" value="" name="inpMobile" id="inpMobile" placeholder="请输入手机号" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="11" required data-rule-mobile="true" data-msg-required="请输入手机号" data-msg-mobile="请输入手机号" autocomplete="off" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="MobileId" class="col-lg-2 col-sm-2 col-xs-2 control-label">验证码：</label>
                        <div class="col-lg-7 col-sm-7 col-xs-7">

                            <input type="text" id="inpValidCode" name="inpValidCode" maxlength="4" onkeyup="this.value=this.value.replace(/\D/g,'');" class="form-control" placeholder="请输入验证码" required data-msg-required="请输入验证码" autocomplete="off" />
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3 text-left">
                            <input type="button" class="yzm-btn gl" style="color: white" value="点击发送验证码" onclick="sendCode(this)" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="" class="col-lg-2 col-sm-2 col-xs-2 control-label" style="margin-top: 17px;">
                            <input class="che" type="checkbox" id="checkboxId" name="checkboxId" checked="checked" />
                        </label>
                        <div class="col-lg-9 col-sm-9 col-xs-9 text-left font3 " style="margin-top: 12px; color: #666">
                            <i style="font-style: normal;" class="yd-text">我已阅读并同意</i><i style="color: #fb6113; font-style: normal; cursor: pointer;" class="yhxy">《用户协议》</i>
                        </div>
                    </div>
                
                    <div class="col-lg-12 col-sm-12 col-xs-12">
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                        <div class="col-lg-6 col-sm-6 col-xs-6">
                            <div id="next-info" class="next-btn mr">下一步</div>
                        </div>
                        <div class="col-lg-3 col-sm-3 col-xs-3">
                        </div>
                    </div>
                </div>

                <input id="hiddTimeStamp" name="hiddTimeStamp" type="hidden" />
                <input id="hiddToken" name="hiddToken" type="hidden" />
                <input id="hidConsultId" name="hidConsultId" type="hidden" />
                <input id="hidIDNo" name="hidIDNo" type="hidden" />
                <input id="hidMobile" name="hidMobile" type="hidden" />
                <input id="hidOrderNo" name="hidOrderNo" type="hidden" />
                <input id="hidmagId" name="hidmagId" value="<%=magId %>" type="hidden" />
                <input id="hiddMemberFlag" name="hiddMemberFlag" type="hidden" value="0" />
                <input id="hiddNetLoanApplyId" name="hiddNetLoanApplyId" type="hidden" />
                <input id="hiddCompanyId" name="hiddCompanyId" type="hidden" value="<%=companyId %>" />
                <input id="hiddExpiredDate" name="hiddExpiredDate" type="hidden" />
                <input id="hiddEffectedDate" name="hiddEffectedDate" type="hidden" />

                <input id="hiddFullName" name="hiddFullName" type="hidden" />
                <input id="hiddSex" name="hiddSex" type="hidden" />
                <input id="hiddBirth" name="hiddBirth" type="hidden" />
                <input id="hiddNational" name="hiddNational" type="hidden" />
                <input id="hiddAddress" name="hiddAddress" type="hidden" />
                <input id="hiddAuthority" name="hiddAuthority" type="hidden" />
                <input id="hiddValidperiod" name="hiddValidperiod" type="hidden" />
                <input id="hiddEquipmentNo" name="hiddEquipmentNo" type="hidden" value="<%=equipmentNo %>" />
                <input id="hiddMerchantsNo" name="hiddMerchantsNo" type="hidden" value="<%=merchantsNo %>" />
                <input id="hiddPageLoadDateTime" name="hiddPageLoadDateTime" type="hidden" value="<%=sskdRequestParas.PageLoadDateTime %>" />
                <input type="hidden" id="sedMSM" name="sedMSM" value="" />
                <input type="hidden" id="NumberId" name="NumberId" value="" />
                <input type="hidden" id="hidMoblie" name="hidMoblie" value="" />

            </form>
        </div>

        <%-- <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
            <object classid="clsid:5819234B-5977-4C82-9C59-A9D3C7D46083" id="CertCtl" name="CertCtl" width="0" height="0"></object>
            <span class="ts-msg"></span>
        </div>--%>
        <!--申请借款end-->
    </div>
</body>
</html>
