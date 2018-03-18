<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettlementApply.aspx.cs" Inherits="BWJS.WebApp.Admin.SettlementApply" %>

<div class="form-box form-user tabshow">
    <form class="form-horizontal" role="form" id="queryForm">
        <ul>
            <li class="form-group">
                <label class="col-sm-2 control-label" for="inpUserId">商家：</label>
                <div class="col-sm-3">
                    <select id="inpUserId" name="inpUserId" class="form-control" placeholder="商家" required></select><em>*</em>
                </div>
                <label class="col-sm-2 control-label" for="inpCompany">渠道：</label>
                <div class="col-sm-3">
                    <select id="inpCompany" name="inpCompany" class="form-control" placeholder="渠道"></select>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-2 control-label" for="inpStartDateForInput">结算周期：</label>
                <div class="col-sm-3">
                    <input id="inpStartDateForInput" name="inpStartDateForInput" class="form-control" type="text" placeholder="结算开始日期" readonly />
                </div>
                <label class="col-sm-2 control-label" for="inpEndDateForInput">至：</label>
                <div class="col-sm-3">
                    <input id="inpEndDateForInput" name="inpEndDateForInput" class="form-control" type="text" placeholder="结算截止日期" readonly />
                </div>
            </li>
            <li class="form-group">
                <div class="col-sm-12 text-center">
                    <button id="btnQuery" type="button" class="btn btn-success btn-group-lg">查 询</button>
                    <button id="btnResetQuery" type="reset" class="btn btn-danger btn-group-lg">重 置</button>
                    <button id="btnClose" type="button" class="btn btn-danger btn-group-lg" data-dismiss="modal">关 闭</button>
                </div>
            </li>
        </ul>
        <script type="text/javascript">
            //商家列表
            function getMerchantList() {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/x-www-form-urlencoded",
                    url: "/ajax/helper.ashx",
                    data: { op: "bwjs", om: "gl", action: "merchantListForSelect", r: Math.random() },
                    async: false,
                    cache: false,
                    traditional: false,
                    success: function (json) {
                        if (json.result) {
                            $("#inpUserId").append("<option value=\"\">请选择</option>");
                            $.each(json.data, function (key, value) {
                                $("#inpUserId").append("<option value=\"" + value.UserID + "," + value.DepartmentID + "\">" + value.UserName + " " + value.Address + "</option>");
                            });
                        } else {
                            alert(json.msg);
                        }
                    },
                    error: function (json) {
                        alert("加载商家列表失败，请重试");
                    },
                });
            }

            //渠道列表
            function getCompanyList() {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/x-www-form-urlencoded",
                    url: "/ajax/helper.ashx",
                    data: { op: "bwjs", om: "gl", action: "companyListForSelect", r: Math.random() },
                    async: false,
                    cache: false,
                    traditional: false,
                    success: function (json) {
                        if (json.result) {
                            $("#inpCompany").append("<option value=\"\">请选择</option>");
                            $.each(json.data, function (key, value) {
                                $("#inpCompany").append("<option value=\"" + value.CompanyId + "\">" + value.CompanyName + "</option>");
                            });
                        } else {
                            alert(json.msg);
                        }
                    },
                    error: function (json) {
                        alert("加载渠道列表失败，请重试");
                    },
                });
            }

            //我的银行卡
            function getBankList() {
                $("#inpBank").empty();
                $("#inpOpeningBankForInput").val("");
                $("#inpCardHolderForInput").val("");
                $("#inpCardNumberForInput").val("");
                var userIdAndDepartmentId = $.trim($("#inpUserId").val());
                var merchantId = -1;
                if (userIdAndDepartmentId != null && userIdAndDepartmentId != "") {
                    var userIdAndDepartmentIdList = userIdAndDepartmentId.split(',');
                    merchantId = userIdAndDepartmentIdList[0];
                }
                if (merchantId != null && merchantId != null) {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        contentType: "application/x-www-form-urlencoded",
                        url: "/ajax/helper.ashx",
                        data: { op: "bwjs", om: "gl", action: "bankforselect", merchantId: merchantId, r: Math.random() },
                        async: false,
                        cache: false,
                        traditional: false,
                        success: function (json) {
                            if (json.result) {
                                $("#inpBank").append("<option value=\"\">请选择</option>");
                                $.each(json.data, function (key, value) {
                                    $("#inpBank").append("<option value=\"" + value.UserBankId + "," + value.OpeningBank + "," + value.CardHolder + "," + value.CardNumber + "\">" + value.OpeningBank + "</option>");
                                });
                            }
                        },
                        error: function (json) {
                            myAlert("加载我的银行卡失败，请重试");
                        },
                    });
                }
            }

            //结算查询
            var queryOrderTable;
            function QueryOrder() {
                if (typeof (queryOrderTable) != "undefined") {
                    queryOrderTable.fnClearTable(false); //清空一下table
                    queryOrderTable.fnDestroy(); //还原初始化了的datatable
                }
                queryOrderTable = $("#queryOrderList").dataTable({
                    paging: false,
                    bAutoWidth: true,
                    aaSorting: [[0, "desc"]],
                    bDestroy: true,
                    bServerSide: true,
                    sServerMethod: "POST",
                    sAjaxSource: "/ajax/helper.ashx",
                    fnServerData: function (sUrl, aoData, fnCallback) {
                        var userIdAndDepartmentId = $.trim($("#inpUserId").val());
                        var merchantId = null;
                        if (userIdAndDepartmentId != null && userIdAndDepartmentId != "") {
                            var userIdAndDepartmentIdList = userIdAndDepartmentId.split(',');
                            merchantId = userIdAndDepartmentIdList[0];
                        }
                        aoData.push(
                                { "name": "op", "value": "bwjs" },
                                { "name": "om", "value": "settlement" },
                                { "name": "action", "value": "queryOrder" },
                                { "name": "UserId", "value": merchantId },
                                { "name": "CompanyId", "value": $("#inpCompany").val() },
                                { "name": "StartDate", "value": $("#inpStartDateForInput").val() },
                                { "name": "EndDate", "value": $("#inpEndDateForInput").val() },
                                { "name": "timeStamp", "value": new Date().getTime() }
                        );
                        $.ajax({
                            url: sUrl,
                            type: "POST",
                            contentType: "application/json",
                            data: JSON.stringify(aoData),
                            dataType: "json",
                            cache: false,
                            traditional: true,
                            async: false,
                            success: function (json) {
                                if (json.result) {

                                    var html = "";
                                    html += "订单总金额：<b style=\"color:red\">（" + ((json.sumOrderMoney == null) ? ("0.00") : (json.sumOrderMoney.toFixed(2))) + "）</b> 元 | ";
                                    html += "总部返利总金额：<b style=\"color:red\">（" + ((json.sumHQMoney == null) ? ("0.00") : (json.sumHQMoney.toFixed(2))) + "）</b> 元 | ";
                                    html += "代理商返利总金额：<b style=\"color:red\">（" + ((json.sumAgentMoney == null) ? ("0.00") : (json.sumAgentMoney.toFixed(2))) + "）</b> 元 | ";
                                    html += "商家返利总金额：<b style=\"color:red\">（" + ((json.sumMerchantMoney == null) ? ("0.00") : (json.sumMerchantMoney.toFixed(2))) + "）</b> 元 | ";
                                    html += "净利润：<b style=\"color:red\">（" + ((json.sumNetProfit == null) ? ("0.00") : (json.sumNetProfit.toFixed(2))) + "）</b> 元 ";
                                    $("#queryOrderShow").html(html);

                                    var applyMoney = (json.sumApplyMoney == null) ? ("0.00") : (json.sumApplyMoney.toFixed(2));
                                    if (applyMoney != 0) {
                                        $("#inpApplyMoneyForInput").val(applyMoney);
                                        $("#btnApply").show();
                                        $("#applyForm").show();
                                        $("#queryOrderList").show();
                                    }
                                    else {
                                        $("#btnApply").hide();
                                        $("#applyForm").hide();
                                        $("#btnResetApply").trigger("click");
                                        $("#queryOrderList").hide();
                                    }

                                    fnCallback(json);
                                } else {
                                    myAlert(json.msg);
                                }
                            },
                            error: function (json) {
                                var error = "";
                                $.each(json, function (key, value) {
                                    switch (key) {
                                        case "status":
                                        case "statusText":
                                            error += ((error == "") ? (value) : ("," + value));
                                            break;
                                    }
                                });
                                myAlert(error);
                            },
                        });
                    },
                    columns: [
                        { mData: "CompanyName" },
                        { mData: "MerchantName" },
                        {
                            mData: "SettlementMethod",
                            mRender: function (data, type, full) {
                                var result = full.SettlementMethod;
                                switch (full.SettlementMethod) {
                                    case 1:
                                        result = "销售额百分比";
                                        break;
                                    case 2:
                                        result = "单笔结算";
                                        break;
                                }
                                return result;
                            },
                        },
                        { mData: "sumOrderMoney", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                        { mData: "sumHQMoney", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                        { mData: "sumAgentMoney", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                        { mData: "sumMerchantMoney", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                        { mData: "sumNetProfit", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                    ],
                });
            }

            $(document).ready(function () {
                $("#btnApply").hide();
                $("#applyForm").hide();

                getCompanyList();
                getMerchantList();
                $("#inpUserId").change(function () {
                    getBankList();
                });

                $('#inpStartDateForInput').on('focus', function () {
                    WdatePicker({ onpicked: function (db) { db.$('inpEndDateForInput').focus(); }, dateFmt: 'yyyy-MM-dd' });
                });
                $('#inpEndDateForInput').on('focus', function () {
                    WdatePicker({ minDate: '#F{$dp.$D(\'inpStartDateForInput\')}', dateFmt: 'yyyy-MM-dd' });
                });
                $("#btnQuery").click(function () {
                    if ($("#queryForm").valid()) {
                        QueryOrder();
                    }
                });
                $("#btnResetQuery").click(function () {
                    $("#queryForm").resetForm;
                });
                $("#btnResetApply").click(function () {
                    $("#applyForm").resetForm;
                });
            });
        </script>
    </form>
    <form class="form-horizontal" role="form" id="applyForm">
        <ul>
            <li class="form-group">
                <label class="col-sm-2 control-label" for="inpPaymentMode">支付方式：</label>
                <div class="col-sm-3">
                    <select id="inpPaymentMode" name="inpPaymentMode" class="form-control" required>
                        <option value="">请选择</option>
                        <option value="1">线下转账</option>
                        <option value="2">在线支付</option>
                    </select><em>*</em>
                </div>
                <label class="col-sm-2 control-label" for="inpBank">我的银行卡：</label>
                <div class="col-sm-3">
                    <select id="inpBank" name="inpBank" class="form-control" placeholder="我的银行卡"></select>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-2 control-label" for="inpOpeningBankForInput">开户行：</label>
                <div class="col-sm-3">
                    <input id="inpOpeningBankForInput" name="inpOpeningBankForInput" class="form-control" type="text" placeholder="开户行" required /><em>*</em>
                </div>
                <label class="col-sm-2 control-label" for="inpCardHolderForInput">持卡人：</label>
                <div class="col-sm-3">
                    <input id="inpCardHolderForInput" name="inpCardHolderForInput" class="form-control" type="text" placeholder="持卡人" required /><em>*</em>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-2 control-label" for="inpCardNumberForInput">卡号：</label>
                <div class="col-sm-3">
                    <input id="inpCardNumberForInput" name="inpCardNumberForInput" class="form-control" type="text" placeholder="卡号" required /><em>*</em>
                </div>
                <label class="col-sm-2 control-label" for="inpApplyMoneyForInput">申请结算金额：</label>
                <div class="col-sm-3">
                    <input id="inpApplyMoneyForInput" name="inpApplyMoneyForInput" class="form-control" type="text" placeholder="申请结算金额" required readonly /><em>*</em>
                </div>
            </li>
            <li class="form-group">
                <div class="col-sm-12 text-center">
                    <button id="btnApply" type="button" class="btn btn-success btn-group-lg">申请结算</button>
                    <button id="btnResetApply" type="reset" class="btn btn-danger btn-group-lg">重 置</button>
                </div>
            </li>
        </ul>

        <script type="text/javascript">
            $(document).ready(function () {
                $("#btnApply").click(function () {
                    if ($.trim($("#inpApplyMoneyForInput").val()) != "" && $.trim($("#inpApplyMoneyForInput").val()) != "0.00") {
                        if ($("#applyForm").valid()) {

                            //alert($("#inpPaymentMode").val());
                            //alert($("#inpBank").val());
                            //alert($("#inpPaymentMode option:selected").attr("value"));

                            applySettlement();
                        }
                    }
                    else {
                        myAlert("申请结算金额不正确");
                    }
                });
                $("#inpBank").change(function () {
                    var banks = $.trim($.trim($("#inpBank").val()));
                    if (bankList != "") {
                        var bankList = banks.split(',');
                        $("#inpOpeningBankForInput").val(bankList[1]);
                        $("#inpCardHolderForInput").val(bankList[2]);
                        $("#inpCardNumberForInput").val(bankList[3]);
                    }
                    else {
                        $("#inpOpeningBankForInput").val("");
                        $("#inpCardHolderForInput").val("");
                        $("#inpCardNumberForInput").val("");
                    }
                });
            });

            jQuery.validator.addMethod("checkCardHolder", function (value, element) {
                var realname = /^([\u4e00-\u9fa5]{2,8}|[a-zA-Z]{2,16})$/g;
                return this.optional(element) || (realname.test(value));
            }, "只能输入2-8个汉字或2-16个英文字符");

            jQuery.validator.addMethod("checkCardNumber", function (value, element) {
                return this.optional(element) || (luhmCheck(value));
            }, "卡号输入有误，请检查输入");

            $.validator.setDefaults({
                errorElement: 'span',
                rules: {
                    inpCardHolderForInput: {
                        required: true,
                        checkCardHolder: true,
                    },
                    inpCardNumberForInput: {
                        required: true,
                        checkCardNumber: true,
                    },
                    inpApplyMoneyForInput: {
                        required: true,
                    },
                },
            });

            function applySettlement() {
                var userIdAndDepartmentId = $.trim($("#inpUserId").val());
                var merchantId = 0;
                if (userIdAndDepartmentId != null && userIdAndDepartmentId != "") {
                    var userIdAndDepartmentIdList = userIdAndDepartmentId.split(',');
                    merchantId = userIdAndDepartmentIdList[0];
                }
                var modelOrderRebateSettlementApply = getSettlementModel();
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "settlement";
                paramter.action = "applysettlement";
                paramter.UserId = merchantId;
                paramter.CompanyId = $.trim($("#inpCompany").val());
                paramter.StartDate = $.trim($("#inpStartDateForInput").val());
                paramter.EndDate = $.trim($("#inpEndDateForInput").val());
                paramter.userIdAndDepartmentId = userIdAndDepartmentId;
                paramter.modelOrderRebateSettlementApply = JSON.stringify(modelOrderRebateSettlementApply);
                paramter.timeStamp = new Date().getTime();
                $.ajax({
                    type: "POST",
                    url: "/Ajax/helper.ashx",
                    data: paramter,
                    dataType: "json",
                    async: false,
                    success: function (json) {
                        if (json.result) {
                            $("#btnResetQuery").trigger("click");
                            $("#btnResetApply").trigger("click");
                            $("#applyModal").modal("hide");
                        }
                        else {
                            myAlert(json.msg);
                        }
                    },
                    error: function () { myAlert("服务器没有返回数据，可能服务器忙，请重试"); }
                });
            }

            function getSettlementModel() {
                var model = {};
                model.StartDate = $.trim($("#inpStartDateForInput").val());
                model.EndDate = $.trim($("#inpEndDateForInput").val());
                model.ApplyMoney = $.trim($("#inpApplyMoneyForInput").val());
                model.ActualMoney = $.trim($("#inpApplyMoneyForInput").val());
                model.PaymentMethod = $.trim($("#inpPaymentMode").val());
                model.OpeningBank = $.trim($("#inpOpeningBankForInput").val());
                model.CardHolder = $.trim($("#inpCardHolderForInput").val());
                model.CardNumber = $.trim($("#inpCardNumberForInput").val());
                model.Remark = "";
                return model;
            }

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

        </script>
    </form>
</div>
<div class="container-fluid user-list mat1">
    <div class="add-box">
        <div id="queryOrderShow" class="form-inline">
            订单总金额：<b style="color: red">（0.00）</b> 元 | 总部返利总金额：<b style="color: red">（0.00）</b> 元 | 代理商返利总金额：<b style="color: red">（0.00）</b> 元 | 商家返利总金额：<b style="color: red">（0.00）</b> 元 | 净利润：<b style="color: red">（0.00）</b> 元
        </div>
    </div>
    <div id="tableArea">
        <table id="queryOrderList" class="display table table-bordered" style="display: none;">
            <thead>
                <tr>
                    <th>渠道</th>
                    <th>商家</th>
                    <th>结算方式</th>
                    <th>订单金额</th>
                    <th>总部返利</th>
                    <th>代理商返利</th>
                    <th>商家返利</th>
                    <th>净利润</th>
                </tr>
            </thead>
        </table>
    </div>
</div>
