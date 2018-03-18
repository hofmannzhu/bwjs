<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtractTheAmount.aspx.cs" Inherits="BWJS.WebPad.Product.NewSSKD.ExtractTheAmount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>添加银行卡</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />

    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
        
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <script src="/Scripts/messages_zh.min.js"></script>
     <script src="/Scripts/jquery.mailAutoComplete-4.0.js" type="text/javascript"></script>

    <script>
        $(document).ready(function () {
            $(".btn-n").click(function () {
                $(".mask").fadeOut();
            });
        });

        function IsYes() {
            $(".mask").fadeOut();
            SubmitData();
        }

        function ValueCheck() {
            var b = true;
            var amountId = $("#amountId").val();
            var merchantsAcountId = $("#merchantsAcountId").val();
            var authorizedPasswordId = $("#authorizedPasswordId").val();
            var merchantsIdCardNoId = $("#merchantsIdCardNoId").val();
            if (amountId == "") {
                myAlert("额度不能为空");
                return false;
            } else {
                if (amountId==0) {
                    myAlert("额度不能为0");
                    return false;
                }
            }
            if (merchantsAcountId == "") {
                myAlert("商家账号不能为空");
                return false;
            }
            if (authorizedPasswordId == "") {
                myAlert("商户密码不能为空");
                return false;
            }
            if (merchantsIdCardNoId == "") {
                myAlert("商户身份证号不能为空");
                return false;
            } else {
                var un = /^\w+$/;
                if (!un.test($("#merchantsIdCardNoId").val())) {
                    myAlert("商户授权身份证号输入有误，不能包含特殊字符");
                    return false;
                }
                else {
                    var isIDCard2 = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;//(18位)
                    var lengthvalue = document.getElementById('merchantsIdCardNoId').value.length;
                    if (lengthvalue == 18) {
                        if (isIDCard2.test(document.getElementById('merchantsIdCardNoId').value) === false) {
                            myAlert('商户授权身份证号输入不合法,请重新填写！');
                            return false;
                        }
                        else {
                            return true;
                        }
                    } else {
                        myAlert('商户授权身份证号位数不正确,请重新填写！');
                        return false;
                    }
                }

            }

            return b;
        }

        function SubmitSure() {
            var d = ValueCheck();
            if (d) {
                $(".mask").fadeIn();
            }
        }


        ///确认
        function SubmitData() {
            lindex = layer.load("请稍等...");
            var sskdRequestParas = {};
            sskdRequestParas.op = "bwjs";
            sskdRequestParas.om = "newnetloan";
            sskdRequestParas.action = "merchantacceptance";
            sskdRequestParas.amount = $("#amountId").val();
            sskdRequestParas.merchantsAcount = $("#merchantsAcountId").val();
            sskdRequestParas.merchantsIdCardNo = $("#merchantsIdCardNoId").val();
            sskdRequestParas.authorizedPassword = $("#authorizedPasswordId").val();
            sskdRequestParas.token = '<%= sskdModel.Token%>';
            sskdRequestParas.ConsultId = '<%= sskdModel.ConsultId%>';
            sskdRequestParas.timestamp = '<%=sskdModel.TimeStamp%>'
            sskdRequestParas.orderNo = '<%=sskdModel.OrderNo%>';
            sskdRequestParas.sign = '<%=GetSign%>';
            sskdRequestParas.equipmentNo = '<%= sskdModel.MachineId %>';
            sskdRequestParas.merchantsNo = '<%= sskdModel.MerchantId %>';
            sskdRequestParas.OrderSource = 'BWPAD';
            sskdRequestParas.authorizedType = '<%=authorizedType %>';
            sskdRequestParas.merchantNo = '<%= sskdModel.MerchantId%>';
            var json = getJson(sskdRequestParas, false);

            if (json.success) {
                layer.close(lindex);
                $("#ExtractForm").submit();
            }
            else {
                layer.close(lindex);
                myAlert(json.message);
            }

        }


        var ipassword = '';
        function checkpassword(obj) {
            //alert(obj.value);
            ipassword = ',' + obj.value;
            var nn = obj.value.length;
            //var re=/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{6,20}$/g;  //密码必须有大小写字母和数字且6-20位
            //var rez = re.test(obj.value);
            //obj.value = obj.value.replace(/([^\d][a-zA-Z\d][*])/g, ""); //清除"数字"和"字母"以外的字符
            var cc = '';
            for (var d = 0; d < nn; d++) {
                cc += "*";
            }
            obj.value=cc;
        }


        function checkloginName(obj) {
            //用户名正则，4到16位（字母，数字，下划线，减号）
            var uPattern = /^[a-zA-Z0-9_-]{4,16}$/;
            //输出 true
            return obj.value;
        }

        function clearNoNum(obj) {
            obj.value = obj.value.replace(/[^\d.]/g, ""); //清除"数字"和"."以外的字符
            obj.value = obj.value.replace(/^\./g, ""); //验证第一个字符是数字
            obj.value = obj.value.replace(/\.{2,}/g, "."); //只保留第一个. 清除多余的
            obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");
            obj.value = obj.value.replace(/^(\-)*(\d+)\.(\d\d).*$/, '$1$2.$3'); //只能输入两个小数
        }

        //身份证算法
        function cardIdNoNum(obj) {
            //alert(obj);
            //alert(i);
            //$("#merchantsIdCardNoId").val(i);
            var numlength = document.getElementById('merchantsIdCardNoId').value.length;
            if (numlength <= 17) {
                obj.value = obj.value.replace(/\D/g, "");
            } else if (numlength == 18) {
                var type = CheckNum();
                if (!type) {
                    obj.value = obj.value.substring(0, 17);
                    $("#merchantsIdCardNoId").val(obj.value);
                    return false;
                }
            }
        }

        function CheckNum() {
            var numlength = document.getElementById('merchantsIdCardNoId').value.length;
            var numvalue = $("#merchantsIdCardNoId").val();
            var min = 1;
            var max = 18;
            if (numlength < min || numlength > max) {
                return false;
            }
            else {
                var city = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江 ", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "南", 42: "湖北 ", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏 ", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外 " };
                var isIDCard1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;//(15位)
                var isIDCard2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;//(18位)
                var value2 = "";
                if (numvalue.length == 18) {
                    value2 = numvalue.split('');
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

                return ((isIDCard1.test(numvalue)) || (isIDCard2.test(numvalue))) && ((city[numvalue.substr(0, 2)] != "") && (city[numvalue.substr(0, 2)] != undefined) && (parity[sum % 11] == numvalue[17]));
            }
        }
    </script>


</head>
<body>
    <div class="mask">
        <div class="pop-box-dhk">
            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                <span class="qr-msg" id="typemassge">请您确认是否提额</span>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">

                <div class="col-lg-5 col-sm-5 col-xs-5">
                    <input type="button" class="btn-y" value="是" onclick="IsYes();" />
                    <%--  <a href="AddBankCard.aspx"><span class="btn-y">是</span></a>--%>
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
                    <img src="../../Content/img/NewSSKD/tab-dot1.png" /></span>身份校验</li>
                <li class="" style="color: #FA6113" />
                <span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot2.png" /></span>授权认证</li>
                <li class="" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot3.png" /></span>评估报告</li>
                <li class=""><span class="line"></span><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot5.png" /></span>选择银行卡</li>
                <li class=""><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot4.png" /></span>申请确认</li>
            </ul>
        </div>

        <div >
            <form method="post" class="form-horizontal mar-top1" role="form" id="ExtractForm" action="/Product/NewSSKD/AddBankCard">
                <div class="col-sm-12  text-right">
                    <div class="form-group">
                        <label for="inpBankCardNo" class="col-lg-3 col-sm-3 col-xs-3 control-label">可提额度：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8">
                            <input type="text" value="" id="amountId" name="amount" onkeyup="clearNoNum(this)" onblur="clearNoNum(this)" maxlength="8" class="form-control" placeholder="可提额度5000-20000元" data-msg-required="不能为空"   autocomplete="off" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label  class="col-lg-3 col-sm-3 col-xs-3 control-label">商家账号：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8 text-left">
                            <input type="text" class="form-control" id="merchantsAcountId" name="merchantsAcount" onkeyup="checkloginName(this)" onblur="checkloginName(this)" maxlength="30" placeholder="请输入商家账号"   autocomplete="off" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpMobileForBankCard" class="col-lg-3 col-sm-3 col-xs-3 control-label">特许商家授权密码：</label>

                        <div class="col-lg-8 col-sm-8 col-xs-8 text-left"><%--onkeyup="checkpassword(this)" onblur="checkpassword(this)--%>
                            <input type="text" class="form-control " id="authorizedPasswordId" name="authorizedPassword" maxlength="40"  onkeyup="checkpassword(this)" onblur="checkpassword(this)" placeholder="请输入商家授权密码"   autocomplete="off" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inpBankCardMobileValidCode" class="col-lg-3 col-sm-3 col-xs-3 control-label">商家身份证号：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8">
                            <input type="text" value="" id="merchantsIdCardNoId" name="merchantsIdCardNo" onkeyup="cardIdNoNum(this)" onblur="cardIdNoNum(this)" maxlength="18" class="form-control" placeholder="请输入商家身份证号" data-msg-required="不能为空"  autocomplete="off" />
                        </div>
                    </div>

                </div>
                <div class="col-lg-12 col-sm-12 col-xs-12">
                    <div class="col-lg-1 col-sm-1 col-xs-1">
                    </div>

                    <div class="col-lg-4 col-sm-4 col-xs-4">
                        <input type="button" class="next-btn  " id="nextdata" value="确 认" onclick="SubmitSure()" />
                    </div>
                    <div class="col-lg-2 col-sm-2 col-xs-2">
                    </div>
                    <div class="col-lg-4 col-sm-4 col-xs-4">
                        <a href="TheAppraisalReport.aspx">
                            <div class="btn-cal" id="">取 消</div>
                        </a>
                    </div>
                    <div class="col-lg-1 col-sm-1 col-xs-1">
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>


