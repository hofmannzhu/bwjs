<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consult.aspx.cs" Inherits="BWJS.WebApp.Test.SSKDtest.LYtest.Consult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../../../Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../Content/css/Mofang/main.css" rel="stylesheet" />
    <link href="../../../Scripts/skin/layer.css" rel="stylesheet" />
    <link href="../../../Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../../../Scripts/jquery.validate.js"></script>
    <script src="../../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/bootbox.js" type="text/javascript"></script>
    <%--    <script src="../../../Scripts/layer.js"></script>--%>
    <script src="../../../Scripts/layer.min.js"></script>
    <script src="../../../Scripts/Product/heartbeatcheck.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <script type="text/javascript">
        var modelIdentityCardLibrary = {};
        var modelNetLoanApply = {};
        $(document).ready(function () {
            $("#ValidCodeBT").attr("disabled", "disabled");
            connect();
            $("#ValidCodeBT").click(function(){   
                var moblie= $("#MobileId").val();
                var c=true;
                if(!moblie)
                {    
                    layer.msg('手机号不能为空！', 1,3); 
                    c=false;
                    return  c;
                }else{
                    var isIDCard2 =/^1[3|4|5|6|7|8|9][0-9]{9}$/; //验证规则
                    var lengthvalue = document.getElementById('MobileId').value.length;
                    if (lengthvalue == 11) {
                        if (isIDCard2.test(document.getElementById('MobileId').value) === false) {
                            layer.msg('手机号输入不合法,请重新填写!',2,3,function(){
                                $("#MobileId").val("");
                            })
                            c=false;
                            return  c;
                        }
                    }else{
                        layer.msg('手机号位数不正确！', 1,3); 
                        c=false;
                        return  c;
                    }
                }
                if (c) {
                    $.ajax({
                        url: '/Ajax/MofangOrder/ValidCode.ashx',
                        type: 'post',
                        dataType: 'json',
                        timeout: 0,
                        async: true,
                        data: {
                            Action: "ValidCodeAction",
                            moblie: moblie
                        },
                        success: function (result) {
                            if (result.isSend == "ok") {    
                                $("#sedMSM").val("ok");
                                $("#NumberId").val(result.number);
                            }
                            else {
                                $("#sedMSM").val("");
                                $("#NumberId").val("");
                            }

                        },
                        error: function (xmlHttpRequest, textStatus, errorThrown) {
                            if (textStatus != 'timeout') {
                                //   alert(xmlHttpRequest.responseText);
                            } else {
                            }
                        }
                    });
                }
            });
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

        //存入我方库
        function InsertData(){
            var ConsultId = 0; 
            var Consult={};
            Consult.FullName = $("#inpFullName").val();
            Consult.Mobile = $("#MobileId").val();
            Consult.IDNo =$("#inpIdentityCardNumber").val();
            Consult.LoanAmount = $("#LoanAmountId").val();
            Consult.LoanTerm =$("#LoanTermId").val();
            Consult.LoanUse =$("#LoanUseId").val();
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "InsertConsult";
            paramter.Consult = JSON.stringify(Consult);
            debugger;
            var json = getJson(paramter, false);
            alert(JSON.stringify(json));
            if (json.result) {
                ConsultId = json.data;
                $("#hidConsultId").val(ConsultId);
            }
            return ConsultId;
        
        }
        function nextinfoClick()
        {
            //下级页面
            //ShowAssetInfo();
            if ($("#identityForm").valid()) 
            {

                //入我方库
                InsertData();
                //下级页面
                ShowAssetInfo();
            }
            return false;
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
                    success: function (json) {
                        result = json;
                    },
                    error: function () { 
                        myAlert("服务器没有返回数据，可能服务器忙，请重试"); 
                    }
                });
            }
            catch (ex) { myAlert("出错了，可能服务器忙，请重试"); }
            return result;
        }

        //显示添加页面
        function ShowAssetInfo() {
            $.layer({
                type: 2,
                title: [
              
                ],
                border: [0],
                area: ['800px', '500px'],
                end: function () {
                    location.reload();
                },
                iframe: { src: 'AssetInfo.aspx?ConsultId='+$("#hidConsultId").val() }
            });
            return false;
        }
    </script>
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
                    <label for="inpIdentityCardNumber" class="col-sm-3 control-label">身份证号：</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" value="" name="inpIdentityCardNumber" id="inpIdentityCardNumber" placeholder="请输入身份证号码" required data-msg-required="不能为空" data-msg-minlength="请输入证件号" maxlength="18" /><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inpIdentityCardNumber" class="col-sm-3 control-label">金额：</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" value="" name="LoanAmount" id="LoanAmountId" placeholder="请输入金额" required data-msg-required="不能为空" data-msg-minlength="请输贷款金额" maxlength="18" /><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inpIdentityCardNumber" class="col-sm-3 control-label">期限：</label>
                    <div class="col-sm-8">
                        <select name="LoanTerm" id="LoanTermId" style="border-radius: 8px" class="form-control">
                            <%=strLoanTerm %>
                        </select>
                    </div>
                </div>

                <div class="form-group">
                    <label for="inpIdentityCardNumber" class="col-sm-3 control-label">用途：</label>
                    <div class="col-sm-8">
                        <select name="LoanUse" id="LoanUseId" style="border-radius: 8px" class="form-control">
                            <%=strLoanUse %>
                        </select><em>*</em>
                    </div>
                </div>

                <div class="form-group" style="display: none">
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
                <div class="form-group" style="display: none">
                    <label for="inpBirthDay" class="col-sm-3 control-label">出生日期：</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" value="" name="inpBirthDay" id="inpBirthDay" placeholder="请输入例如：1900-01-01" required data-msg-required="不能为空" data-msg-minlength="请输入出生年月"><em>*</em>
                    </div>
                </div>
                <div class="form-group" style="display: none">
                    <label for="inpNation" class="col-sm-3 control-label">民族：</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" value="" name="inpNation" id="inpNation" placeholder="请输入民族" required data-msg-required="不能为空" data-msg-minlength="请输入民族"><em>*</em>
                    </div>
                </div>
                <div class="form-group" style="display: none">
                    <label for="inpAddress" class="col-sm-3 control-label">住址：</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" value="" name="inpAddress" id="inpAddress" placeholder="请输入住址" required data-msg-required="不能为空" data-msg-minlength="请输入住址"><em>*</em>
                    </div>
                </div>
                <div class="form-group" style="display: none">
                    <label for="inpIssuedAt" class="col-sm-3 control-label">签发机关：</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" value="" name="inpIssuedAt" id="inpIssuedAt" placeholder="请输入签发机关" required data-msg-required="不能为空" data-msg-minlength="请输入签发机关"><em>*</em>
                    </div>
                </div>
                <div class="form-group" style="display: none">
                    <label for="inpExpiredDate" class="col-sm-3 control-label">有效期：</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" value="" name="inpExpiredDate" id="inpExpiredDate" placeholder="请输入例如：20171129-20371129" required data-msg-required="不能为空" data-msg-minlength="请输入有效期" /><em>*</em>
                    </div>
                </div>
                <div class="form-group">
                    <label for="MobileId" class="col-sm-3 control-label">手机号：</label>
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
                        <input type="text" class="form-control" value="" name="MobileId" id="MobileId" placeholder="请输入手机号" maxlength="14" required data-rule-mobile="true" data-msg-required="请输入手机号" onkeyup="VMobileId();" data-msg-mobile="请输入手机号" style="width: 75%" /><em>*</em>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inpValidCode" class="col-sm-3 control-label">验证码：</label>
                    <div class="col-sm-8">
                        <div style="width: 100%; float: left">
                            <input type="text" id="inpValidCode" name="inpValidCode" style="width: 80%; float: left;" class="form-control" placeholder="请输入验证码" required data-msg-required="请输入验证码" />
                            <input type="button" id="ValidCodeBT" name="ValidCodeBT" style="width: 18%; background-color: #30abcd; float: left; margin-left: 10px; margin-top: 2px; border: none; height: 30px; border-radius: 2px;" value="获取验证码" class="btn mar-btn  btn-danger " onclick="settime(this)" />





                            <input id="hiddMemberFlag" name="hiddMemberFlag" type="hidden" value="0" />
                            <input id="hiddNetLoanApplyId" name="hiddNetLoanApplyId" type="hidden" />
                            <input id="hidConsultId" name="hidConsultId" type="hidden" />
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
            </div>
            <div class="text-center">
                <%-- 下一步--%>
                <input id="next-info" type="button" value="立即申请" class="sub2" />
            </div>
            <object classid="clsid:5819234B-5977-4C82-9C59-A9D3C7D46083" id="CertCtl" name="CertCtl" width="0" height="0"></object>

        </form>
    </div>
    <!--身份认证end-->





</body>
</html>

<script type="text/javascript">
    var rules = {
        inpFullName: {
            required: true,
            checkFullName: true,
        },
        MobileId: {
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
        var mobile =$("#AreaCodeID") .val()+$.trim($("#MobileId").val());
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
        var mobile = $("#AreaCodeID1").val() + $.trim($("#MobileId").val());
        if ($.trim($("#MobileId").val()) == "") {
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
    //存身份证库
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

    var countdown=60; 
    function settime(obj) { 
        $("#inpMobile").attr("disabled","disabled");
        var moblie= $("#inpMobile").val();
        if(!moblie)
        {
            layer.msg("请填写手机号");
            return false;
        }else{
            var isIDCard2 =/^1[3|4|5|7|8][0-9]{9}$/; //验证规则
            var lengthvalue = document.getElementById('inpMobile').value.length;
            if (lengthvalue == 11) {
                if (isIDCard2.test(document.getElementById('inpMobile').value) === false) {
                    layer.msg('手机号输入不合法,请重新填写!',2,3,function(){
                        $("#inpMobile").val("");
                    })
                    return false;
                }
            }else{
                layer.msg('手机号位数不正确！', 1,3); 
                return false;
            }
        }
        if (countdown == 0) { 
            $("#MobileId").removeAttr("disabled");
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
            settime(obj) }
        ,1000) 
    };
    function VMobileId(){
        var b=true;
        var moblie= $("#MobileId").val();
        if(!moblie)
        {    
            $("#ValidCodeBT").attr("disabled","disabled");
            $("#spanMobileId").show();
            b=false;
        }else{
            var isIDCard2 =/^1[3|4|5|7|8][0-9]{9}$/; //验证规则
            var lengthvalue = document.getElementById('MobileId').value.length;
            if (lengthvalue == 11) {
                if (isIDCard2.test(document.getElementById('MobileId').value) === false) {
                    $("#ValidCodeBT").attr("disabled","disabled");
                    $("#spanMobileId").show();
                    b=false;
                }
            }else{
                $("#ValidCodeBT").attr("disabled","disabled");
                $("#spanMobileId").show();
                b=false;
            }
        };
        if (b) {
            $("#ValidCodeBT").removeAttr("disabled");
            $("#spanMobileId").hide();
        }
    };
</script>
