<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetLoanApply.aspx.cs" Inherits="BWJS.WebApp.Product.NetLoanApply" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/css/Mofang/main.css" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/layer.min.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <title></title>
</head>
<body>
    <div class="main1">
        <div class="zc-box">
            <div class="leftbox">
                <div class="back" onclick="showBack()">返回</div>
            </div>
            <!--网贷身份认证页面Start-->
            <div class="form-box" style="display: block;">
                <div class="group-box1 bg-d">
                    <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NetLoanPlatform">

                        <div class="col-sm-12 text-center bg-e">
                            <h4 class="modal-title fon2" id="myModalLabel">申请人身份认证</h4>
                        </div>
                        <div class="col-sm-12  bg-e">

                            <div class="form-group">
                                <label for="inpIdentityCardNumberType" class="col-sm-3 control-label">证件类型：</label>
                                <div class="col-sm-7 mar1">
                                    <select class="form-control" id="inpIdentityCardNumberType" name="inpIdentityCardNumberType"></select><em>*</em>
                                </div>
                                <div class="col-sm-2 mar">
                                    <button class="btn mar-btn  btn-danger" id="readCardId">身份证扫描</button>
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
                                <label for="inpFullName" class="col-sm-3 control-label">姓 名：</label>
                                <div class="col-sm-8">
                                    <input type="text" class="form-control" id="inpFullName" name="inpFullName" placeholder="您的中文名称" required data-msg-required="不能为空" data-msg-age="请输入姓名" /><em>*</em>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="inpIdentityCardNumber" class="col-sm-3 control-label">证件号：</label>
                                <div class="col-sm-8">
                                    <input type="text" class="form-control" value="" name="inpIdentityCardNumber" id="inpIdentityCardNumber" placeholder="有效证件号" required data-msg-required="不能为空" data-msg-minlength="请输入证件号" maxlength="18"><em>*</em>
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
                            <%--     <div class="form-group marb">
                                <label for="inpMobile" class="col-sm-3 control-label">贷款人移动电话：</label>
                                <div class="col-sm-8">--%>
                            <%--         <input type="text" class="form-control" id="inpMobile" name="inpMobile" placeholder="11位手机号" required data-rule-mobile="true" data-msg-required="请输入手机号" data-msg-mobile="请输入11位电话号码" /><em>*</em>--%>



                            <%--                                </div>
                            </div>--%>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">贷款人移动电话：</label>
                                <div class="col-sm-8 ">
                                    <div style="width: 100%">
                                        <div style="width: 100%; float: left">
                                            <input type="text" value="" id="MobileId" style="width: 83%; float: left;" name="Mobile" class="form-control" placeholder="11位手机号" maxlength="11" required data-rule-mobile="true" data-msg-required="请输入手机号" onkeyup="VMobileId();" data-msg-mobile="请输入11位电话号码" />
                                            <input type="button" id="ValidCodeBT" style="width: 15%; background-color: #30abcd; float: left; margin-left: 10px; margin-top: 2px; border: none; height: 30px; border-radius: 2px;" name="ValidCodeBT" value="获取验证码" class="btn mar-btn  btn-danger " onclick="settime(this)" />
                                            <em>*</em>
                                        </div>
                                        <div style="width: 100%; display: none" id="spanMobileId"><span style="color: red">输入有误</span></div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="" class="col-sm-3 control-label">短信验证码：</label>
                                <div class="col-sm-8">
                                    <input type="text" value="" id="ValidCode" style="width: 100%" name="ValidCode" class="form-control" placeholder="请输入手机验证码" required data-msg-required="请输入手机验证码" />
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-12 col-sm-12 col-xs-12 text-center tjm">
                            <asp:Literal ID="litRecommendationCode" runat="server"></asp:Literal>
                        </div>



                        <div class="text-center">

                            <input id="sbOrderApply" type="button" value="提交申请" class="sub2" />
                            <input type="reset" value="重 置" class="res2" />
                        </div>
                        <input type="hidden" id="sedMSM" name="sedMSM" value="">
                        <input type="hidden" id="NumberId" name="NumberId" value="">
                        <asp:HiddenField ID="rc" runat="server" />
                        <object classid="clsid:5819234B-5977-4C82-9C59-A9D3C7D46083" id="CertCtl" name="CertCtl" width="0" height="0"></object>

                        <script src="/Scripts/bootbox.js" type="text/javascript"></script>
                        <script src="/Scripts/Admin/m1.js" type="text/javascript"></script>
                        <script type="text/javascript">
                            $(document).ready(function () {
                                $("#ValidCodeBT").attr("disabled", "disabled");
                                connect();


                                getIdCardTypeList();

                                setInterval(showBgn, 55000);
                                function showBgn() {
                                    var numbg = Math.floor(Math.random() * 7);
                                    $("body").css({
                                        "background": "url('../Content/img/Mofang/body-bg" + numbg + ".jpg')",
                                        "background-size": "100% 100%"
                                    })
                                }
                                $("#inpIdentityCardNumberType").change(function () {
                                    if ($.trim($(this).val()) == "1") {
                                        $("#readCardId").removeAttr("disabled");
                                        //$("#divIdPhoto").show();
                                        $("#divIdCardDescription").show();
                                        $("#inpIdentityCardNumber").attr("minlength", 15);
                                        $("#inpIdentityCardNumber").rules("add",{required:true,checkIdentityCardNumber:true});  
                                    }
                                    else {
                                        $("#readCardId").attr("disabled", "disabled");
                                        $("#divIdPhoto").hide();
                                        $("#divIdCardDescription").hide();
                                        $("#inpIdentityCardNumber").attr("minlength", 1);
                                        $("#inpIdentityCardNumber").rules("remove");  
                                    }
                                });

                                $(".sub2").click(function () {
                                    if (VerificationCode()) {
                                        applySubmitClick();
                                    }else{
                                        layer.msg("验证码输入不正确，请重新填写！");
                                    } 
                                });
                                $(".res2").click(function () {
                                    $("#jsForm").resetForm;
                                    $("#readCardId").removeAttr("disabled");
                                    $("#divIdPhoto").hide();
                                    $("#divIdCardDescription").show();
                                    $("#inpIdentityCardNumber").attr("minlength", 15);
                                });
                                $("#readCardId").click(function () {
                                    connect();
                                });

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

                            });
                            function VMobileId(){
                                var b=true;
                                var moblie= $("#MobileId").val();
                                if(!moblie)
                                {    
                                    $("#ValidCodeBT").attr("disabled","disabled");
                                    $("#spanMobileId").show();
                                    b=false;
                                }else{
                                    var isIDCard2 =/^1[3|4|5|6|7|8|9][0-9]{9}$/; //验证规则
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
                            function   VerificationCode(){
                                var b=true;
                                var ValidCode=$("#ValidCode").val();
                                if (ValidCode!=$("#NumberId").val()) {
                                    b= false;
                                }
                                return b;
                            };


                            var countdown=60; 
                            function settime(obj) { 
                                $("#MobileId").attr("disabled","disabled");
                                var moblie= $("#MobileId").val();
                                if(!moblie)
                                {
                                    layer.msg("请填写手机号");
                                    return false;
                                }else{
                                    var isIDCard2 =/^1[3|4|5|6|7|8|9][0-9]{9}$/; //验证规则
                                    var lengthvalue = document.getElementById('MobileId').value.length;
                                    if (lengthvalue == 11) {
                                        if (isIDCard2.test(document.getElementById('MobileId').value) === false) {
                                            layer.msg('手机号输入不合法,请重新填写!',2,3,function(){
                                                $("#MobileId").val("");
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

              
                            //证件类型列表
                            function getIdCardTypeList() {
                                var paramter = {};
                                paramter.op = "bwjs";
                                paramter.om = "netloan";
                                paramter.action = "getidcardtype";
                                var json = getJson(paramter, false);
                                if (json.result) {
                                    $.each(json.data, function (key, value) {
                                        $("#inpIdentityCardNumberType").append("<option value=\"" + value.Value + "\">" + value.Name + "</option>");
                                    });
                                } else {
                                    layer.alert(json.msg);
                                }
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
                                        //alert(JSON.stringify(CertCtl));
                                        var sexpersonValue = (CertCtl.Sex == "男" ? 1 : 0);
                                        var strPhotoBase64 = CertCtl.CardPictureData;
                                        var idphotoSrc = "data:image/jpeg;base64," + strPhotoBase64;

                                        $("#inpIdentityCardNumberType").val(1);
                                        $("#inpFullName").val(CertCtl.Name);
                                        $("#inpIdentityCardNumber").val(CertCtl.CardNo);

                                        if (sexpersonValue == 1) {
                                            $("#inpSex1").attr('checked', 'checked');
                                        } else {
                                            $("#inpSex0").attr('checked', 'checked');
                                        }

                                        $("#inpIdPhoto").attr("src", idphotoSrc);
                                        $("#divIdPhoto").show();

                                        modelIdentityCardLibrary.CompanyId = <%= companyId%>;
                                        modelIdentityCardLibrary.IdentityCardNumber = CertCtl.CardNo;
                                        modelIdentityCardLibrary.FullName = CertCtl.Name;
                                        modelIdentityCardLibrary.Sex = sexpersonValue;
                                        modelIdentityCardLibrary.Nation = CertCtl.Nation;
                                        modelIdentityCardLibrary.BirthDay = CertCtl.Born.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
                                        modelIdentityCardLibrary.Address = CertCtl.Address;
                                        modelIdentityCardLibrary.IssuedAt = CertCtl.IssuedAt;
                                        modelIdentityCardLibrary.EffectedDate = CertCtl.EffectedDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
                                        modelIdentityCardLibrary.ExpiredDate = CertCtl.ExpiredDate.replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3");
                                        modelIdentityCardLibrary.IdentityCardPhotoPath = CertCtl.CardPicPath;
                                        modelIdentityCardLibrary.IdentityCardPhotoData = CertCtl.CardPictureData;
                                        modelIdentityCardLibrary.IdentityCardData = JSON.stringify(CertCtl);
                                        
                                        modelNetLoanApply.CompanyId = <%= companyId%>;
                                        modelNetLoanApply.FullName = CertCtl.Name;
                                        modelNetLoanApply.IdCardType = $("#inpIdentityCardNumberType").val();
                                        modelNetLoanApply.IdCard = CertCtl.CardNo;
                                        modelNetLoanApply.Sex = sexpersonValue;
                                        modelNetLoanApply.RecommendationCode=<%="'"+recommendationCode+"'"%>;

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

                            function applySubmitClick() {
                                if ($("#jsForm").valid()) {
                                    $("#sbOrderApply").attr("disabled", "disabled");
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
                                        modelNetLoanApply.IdCardType = parseInt($("#inpIdentityCardNumberType").val());
                                        modelNetLoanApply.IdCard = $("#inpIdentityCardNumber").val();
                                        modelNetLoanApply.Sex = parseInt($("input[name='Sex']:checked").val());
                                        modelNetLoanApply.RecommendationCode=<%="'"+recommendationCode+"'"%>;
                                    }
                                    modelNetLoanApply.Mobile = $("#MobileId").val();
                                    //modelIdentityCardLibrary.ValidCode=$("#ValidCode").val();
                                    //alert($("#ValidCode").val());
                                    //alert(JSON.stringify(modelIdentityCardLibrary));
                                    //alert(JSON.stringify(modelNetLoanApply));


                                    var paramter = {};
                                    paramter.op = "bwjs";
                                    paramter.om = "netloan";
                                    paramter.action = "idcardlibraryadd";
                                    paramter.modelIdentityCardLibrary = JSON.stringify(modelIdentityCardLibrary);
                                    paramter.modelNetLoanApply = JSON.stringify(modelNetLoanApply);
                                    var json = getJson(paramter, false);
                                    if (json.result) {  
                                        if(<%=IsOpenPage%>==0)//手机扫描二维码
                                        {

                                           <%-- window.location.href='/product/NetLoanMiddlePage.aspx?CompanyId='+ <%= companyId%>;--%>
                                            $.layer({
                                                type: 2,
                                                title: [
                                                 "扫描二维码"
                                                ],
                                                border: [0],
                                                area: ['100%', '100%'],
                                                end: function () {
                                                    setTimeout(function () {
                                                        window.location.reload();
                                                    }, 1);
                                                },
                                                iframe: { src: '/product/NetLoanMiddlePage.aspx?CompanyId='+ <%= companyId%>+'&NetLoanApplyId='+json.data}
                                            });

                                        }
                                        else if(<%=IsOpenPage%>==1)//Pc网页版
                                        {  
                                            //var url = "http://hhtycf.com/";
                                            var url = <%="'"+apiUrl+"'"%>;
                                            //window.location.href = url;
                                            //$("#jsForm").submit();
                                            //return false;
                                            if(url!=""){
                                                var iWidth = window.screen.width;//640
                                                var iHeight = window.screen.height;//480
                                                var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
                                                var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
                                                var win = window.open(url, "弹出窗口", "width=" + iWidth + ", height=" + iHeight + ",top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no,alwaysRaised=yes,depended=yes");
                                                //win.document.title = "专属5位推荐码("+<% =recommendationCode %>+")";

                                                $(".res2").trigger("click");
                                                $("#sbOrderApply").removeAttr("disabled");
                                            }
                                            else{
                                                layer.alert("认证完成，但获取渠道接口地址失败，请先配置渠道接口地址");
                                            } 
                                        }
                                }
                                else {
                                    layer.alert(json.msg);
                                }
                            }
                        }
                        function ruleSet(idType){
                            if (idType == "1") {
                                if(!rules.hasOwnProperty("inpIdentityCardNumber")){
                                    var inpIdentityCardNumber={};
                                    inpIdentityCardNumber.required=true;
                                    inpIdentityCardNumber.checkIdentityCardNumber=true;
                                    rules.inpIdentityCardNumber=inpIdentityCardNumber;
                                }
                            }
                            else {
                                delete rules["inpIdentityCardNumber"];
                            }
                        }
                        var rules={
                            inpFullName: {
                                required: true,
                                checkFullName: true,
                            },
                            MobileId: {
                                required: true,
                                checkMobile: true,
                                checkMobile1: true,
                            },
                            inpIdentityCardNumber: {
                                required: true,
                                checkIdentityCardNumber: true,
                            },
                        };
                        $.validator.setDefaults({
                            errorElement: 'span',
                            rules: rules,
                        });

                        //配置通用的默认提示语
                        $.extend($.validator.messages, {
                            required: '必选(填)',
                            equalTo: "请再次输入相同的值"
                        });
                        //手机验证规则
                        jQuery.validator.addMethod("checkMobile", function (value, element) {
                            var mobile = /^1[3|4|5|6|7|8|9]\d{9}$/;
                            return this.optional(element) || (mobile.test(value));
                        }, "手机格式不对");

                        //邮箱或手机验证规则
                        jQuery.validator.addMethod("mm", function (value, element) {
                            var mm = /^[a-z0-9._%-]+@([a-z0-9-]+\.)+[a-z]{2,4}$|^1[3|4|5|7|8|9]\d{9}$/;
                            return this.optional(element) || (mm.test(value));
                        }, "格式不对");
                        //身份证
                        jQuery.validator.addMethod("checkIdentityCardNumber", function (value, element) {
                            if ($("#inpIdentityCardNumberType").val()!="1") {
                                var min=1;
                                var max=18;
                                if(parseInt(value)<min||parseInt(value)>max){
                                    return  false;
                                }else{
                                    return true;
                                }
                            }else{
                                var city= {11:"北京",12:"天津",13:"河北",14:"山西",15:"内蒙古",21:"辽宁",22:"吉林",23:"黑龙江 ",31:"上海",32:"江苏",33:"浙江",34:"安徽",35:"福建",36:"江西",37:"山东",41:"南",42:"湖北 ",43:"湖南",44:"广东",45:"广西",46:"海南",50:"重庆",51:"四川",52:"贵州",53:"云南",54:"西藏 ",61:"陕西",62:"甘肃",63:"青海",64:"宁夏",65:"新疆",71:"台湾",81:"香港",82:"澳门",91:"国外 "};
                                var isIDCard1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;//(15位)
                                var isIDCard2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;//(18位)
                                var value2="";
                                if(value.length == 18){
                                    value2 = value.split('');
                                    //∑(ai×Wi)(mod 11)
                                    //加权因子
                                    var factor = [ 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 ];
                                    //校验位
                                    var parity = [ 1, 0, 'X', 9, 8, 7, 6, 5, 4, 3, 2 ];
                                    var sum = 0;
                                    var ai = 0;
                                    var wi = 0;
                                    for (var i = 0; i < 17; i++)
                                    {
                                        ai = value2[i];
                                        wi = factor[i];
                                        sum += ai * wi;
                                    }
                                    var last = parity[sum % 11];
                                }
                                return (this.optional(element) || (isIDCard1.test(value)) || (isIDCard2.test(value)))&&((city[value.substr(0,2)]!="") &&(city[value.substr(0,2)]!=undefined)&&(parity[sum % 11] == value2[17]));
                            }
                        }, "格式不对");

                          

                        //姓名
                        jQuery.validator.addMethod("checkFullName", function (value, element) {
                            var realname = /^([\u4e00-\u9fa5]{2,8}|[a-zA-Z]{2,16})$/g;
                            return this.optional(element) || (realname.test(value));
                        }, "输入错误，姓名只能输入2-8个汉字或2-16个英文字符");
                        </script>
                    </form>
                </div>
            </div>
            <!--网贷身份认证页面end-->
        </div>
        <div class="footer">
            <span class="logo"></span>
            <div class="adm-box">商家管理员：<%=loginUserName %></div>
        </div>
    </div>
    <script src="/Scripts/jquery.query-2.1.7.js" type="text/javascript"></script>
    <script>
      
        function showBack(){
            var num = $.query.get("wd");
            window.location.href='/Product/Index?wd='+num;//+"&nppi="+<%=netPayPageIndex %>
        }
    </script>
</body>
</html>
