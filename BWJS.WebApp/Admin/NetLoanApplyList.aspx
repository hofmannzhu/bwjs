<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="NetLoanApplyList.aspx.cs" Inherits="BWJS.WebApp.Admin.NetLoanApplyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
    <style>
        th, td {
            white-space: nowrap;
        }

        div.dataTables_wrapper {
            width: 100%;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container-fluid user-list mat1">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpCompanyCategoryForQuery"><i class="jg">类</i>别</label>
                        <select id="inpCompanyCategoryForQuery" name="inpCompanyCategoryForQuery" class="form-control"></select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpStatusForQuery">申请状态</label>
                        <select id="inpStatusForQuery" name="inpStatusForQuery" class="form-control">
                            <option value="">请选择</option>
                            <option value="0">未成功</option>
                            <option value="1">成功</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpIsSettledForQuery">结算状态</label>
                        <select id="inpIsSettledForQuery" name="inpIsSettledForQuery" class="form-control">
                            <option value="">请选择</option>
                            <option value="0">未结算</option>
                            <option value="1">已申请</option>
                            <option value="2">已结算</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpFullNameForQuery"><i class="jg">姓</i>名</label>
                        <input id="inpFullNameForQuery" name="inpFullNameForQuery" type="text" class="form-control" placeholder="请输入姓名" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpIdCardForQuery">证件号码</label>
                        <input id="inpIdCardForQuery" name="inpIdCardForQuery" type="text" class="form-control" placeholder="请输入证件号码" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpMobileForQuery">手机号码</label>
                        <input id="inpMobileForQuery" name="inpMobileForQuery" type="text" class="form-control" placeholder="请输入手机号码" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpRecommendationCodeForQuery"><i class="jg3">推</i><i class="jg3">荐</i>码</label>
                        <input id="inpRecommendationCodeForQuery" name="inpRecommendationCodeForQuery" type="text" class="form-control" placeholder="请输入推荐码" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpApplicationAmountForQuery">申请金额</label>
                        <input id="inpApplicationAmountForQuery" name="inpApplicationAmountForQuery" type="text" class="form-control" placeholder="请输入申请金额" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpLoanAmountForQuery">放款金额</label>
                        <input id="inpLoanAmountForQuery" name="inpLoanAmountForQuery" type="text" class="form-control" placeholder="请输入放款金额" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpLoanTermForQuery">申请期限</label>
                        <input id="inpLoanTermForQuery" name="inpLoanTermForQuery" type="text" class="form-control" placeholder="请输入申请期限" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpProductNameForQuery">申请产品</label>
                        <input id="inpProductNameForQuery" name="inpProductNameForQuery" type="text" class="form-control" placeholder="请输入申请产品" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpMerchantNameForQuery">所属商家</label>
                        <input id="inpMerchantNameForQuery" name="inpMerchantNameForQuery" type="text" class="form-control" placeholder="请输入所属商家" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpCompanyNameForQuery"><i class="jg">渠</i>道</label>
                        <input id="inpCompanyNameForQuery" name="inpCompanyNameForQuery" type="text" class="form-control" placeholder="请输入渠道" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpMainBusinessForQuery"><i class="jg">产</i>品</label>
                        <input id="inpMainBusinessForQuery" name="inpMainBusinessForQuery" type="text" class="form-control" placeholder="请输入产品" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <a class="btn btn-info" id="btnSearch"><span class="glyphicon glyphicon-search"></span>查 询</a>
                        <button id="btnReset" type="reset" class="btn btn-info"><span class="glyphicon glyphicon-refresh"></span>重 置</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="tableArea">
            <table class="display table table-bordered" id="netLoanApplyList" scrollX:"true" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>类别</th>
                        <th>渠道</th>
                        <th>产品</th>
                        <th>商家</th>
                        <th>姓名</th>
                        <th>证件类型</th>
                        <th>证件号码</th>
                        <th>性别</th>
                        <th>手机号码</th>
                        <th>推荐码</th>
                        <th>状态</th>
                        <th>申请金额（元）</th>
                        <th>申请产品</th>
                        <th>申请日期</th>
                        <th>操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <div class="modal fade" id="detailsModal" tabindex="-1" role="dialog" aria-labelledby="detailsModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="detailsModalLabel">查看详情</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row" id="detailsDiv">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input id="hiddId" name="hiddId" type="hidden" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">

        var netLoanApplyTable;

        $(document).ready(function () {
            getCompanyCategoryList();
            GetNetLoanApplyList();

            $("#btnMultyDel").click(function () {
                delnetLoanApplyList();
            });

            $("#btnSearch").click(function () {
                GetNetLoanApplyList()
            });

            $("#detailsModal")
                .on('show.bs.modal', function (e) {
                    var op = $(e.relatedTarget);
                    var id = op.data("id");
                })
                .on('shown.bs.modal', function (e) {
                    var op = $(e.relatedTarget);
                    var id = op.data("id");
                    if (id != undefined) {
                        $("#hiddId").val(id);
                        look(id);
                    }
                })
                .on('hide.bs.modal', function () {
                })
                .on('hidden.bs.modal', function () {

                });
        });

        function GetNetLoanApplyList() {
            if (typeof (netLoanApplyTable) != "undefined") {
                netLoanApplyTable.fnClearTable(false); //清空一下table
                netLoanApplyTable.fnDestroy(); //还原初始化了的datatable
            }
            netLoanApplyTable = $("#netLoanApplyList").dataTable({
                bAutoWidth: true,
                aaSorting: [[13, "desc"]],
                bDestroy: true,
                bServerSide: true,
                sServerMethod: "POST",
                sAjaxSource: "/ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var companyCategory = $.trim($("#inpCompanyCategoryForQuery").val());
                    var status = $.trim($("#inpStatusForQuery").val());
                    var isSettled = $.trim($("#inpIsSettledForQuery").val());
                    var fullName = $.trim($("#inpFullNameForQuery").val());
                    var idCard = $.trim($("#inpIdCardForQuery").val());
                    var mobile = $.trim($("#inpMobileForQuery").val());
                    var recommendationCode = $.trim($("#inpRecommendationCodeForQuery").val());
                    var applicationAmount = $.trim($("#inpApplicationAmountForQuery").val());
                    var loanAmount = $.trim($("#inpLoanAmountForQuery").val());
                    var loanTerm = $.trim($("#inpLoanTermForQuery").val());
                    var productName = $.trim($("#inpProductNameForQuery").val());
                    var merchantName = $.trim($("#inpMerchantNameForQuery").val());
                    var companyName = $.trim($("#inpCompanyNameForQuery").val());
                    var mainBusiness = $.trim($("#inpMainBusinessForQuery").val());
                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "netloan" },
                            { "name": "action", "value": "getnetloan" },
                            { "name": "companyCategory", "value": companyCategory },
                            { "name": "status", "value": status },
                            { "name": "isSettled", "value": isSettled },
                            { "name": "fullName", "value": encodeURI(fullName) },
                            { "name": "idCard", "value": encodeURI(idCard) },
                            { "name": "mobile", "value": encodeURI(mobile) },
                            { "name": "recommendationCode", "value": encodeURI(recommendationCode) },
                            { "name": "applicationAmount", "value": encodeURI(applicationAmount) },
                            { "name": "loanAmount", "value": encodeURI(loanAmount) },
                            { "name": "loanTerm", "value": encodeURI(loanTerm) },
                            { "name": "productName", "value": encodeURI(productName) },
                            { "name": "merchantName", "value": encodeURI(merchantName) },
                            { "name": "companyName", "value": encodeURI(companyName) },
                            { "name": "mainBusiness", "value": encodeURI(mainBusiness) },
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
                    { mData: "CompanyCategoryName" },
                    { mData: "CompanyName" },
                    { mData: "MainBusiness" },
                    { mData: "MerchantName" },
                    { mData: "FullName" },
                    { mData: "IdCardTypeName" },
                    {
                        mData: "IdCard", mRender: function (data, type, full) {
                            var result = "";
                            if (data != null && data != "") {
                                result = data.replace(/^(.{6})(?:\d+)(.{4})$/, "$1****$2");
                            }
                            return result;
                        }

                    },
                    {
                        mData: "Sex",
                        mRender: function (data, type, full) {
                            var result = full.Sex;
                            switch (full.Sex) {
                                case 0:
                                    result = "女";
                                    break;
                                case 1:
                                    result = "男";
                                    break;
                            }
                            return result;
                        },
                    },
                    {
                        mData: "Mobile", mRender: function (data, type, full) { 
                            var result = ""
                            if (data != null && data != "") {
                                result = data.replace(/(\d{3})\d{4}(\d{4})/, '$1****$2');
                            }
                            return result;
                        }
                    },
                    { mData: "RecommendationCode" },
                    {
                        mData: "Status",
                        mRender: function (data, type, full) {
                            var result = full.Status;
                            switch (full.Status) {
                                case 0:
                                    result = "未成功";
                                    break;
                                case 1:
                                    result = "成功";
                                    break;
                            }
                            return result;
                        },
                    },
                    {
                        mData: "ApplicationAmount",
                        mRender: function (data, type, full) {
                            var result = full.ApplicationAmount.toFixed(2);
                            return result;
                        },
                    },
                    { mData: "ProductName" },
                    {
                        mData: "CreateDate",
                        mRender: function (data, type, full) {
                            var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.CreateDate));
                            return result;
                        },
                    },
                    {
                        sClass: "center",
                        mData: "NetLoanApplyId",
                        bSortable: false,
                        mRender: function (data, type, full) {
                            var option = "<a data-toggle=\"modal\" data-target=\"#detailsModal\" data-action=\"orderCancle\" data-id=\"" + full.NetLoanApplyId + "\" class=\"btn btn-mini\" title=\"查看详情\">查看</a>";
                            return option;
                        }
                    },
                ],
            });
        }

        function look(postId) {
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "netloan";
            paramter.action = "getnetloanmodel";
            paramter.netLoanApplyId = postId;
            var json = getJson(paramter, false);
            if (json.result) {
                selectedData = json.data;
                var html = "";
                $.each(json.data, function (key, value) {
                    html += modelConvert(key, value);
                });
                $("#detailsDiv").html(html);
            } else {
                myAlert(json.msg);
            }
        }

        function modelConvert(key, value) {
            var html = "";
            var left = "";
            switch (key) {
                case "NetLoanApplyId": left = "网贷申请编号"; break;
                case "SN": left = "设备编号"; break;
                case "FullName": left = "姓名"; break;
                case "IdCardType":
                    left = "证件类型";
                    switch (value) {
                        case 1:
                            value = "身份证";
                            break;
                    }
                    break;
                case "IdCard": left = "证件号码";
                    value = value.replace(/^(.{6})(?:\d+)(.{4})$/, "$1****$2");
                    break;
                case "Sex":
                    left = "性别";
                    switch (value) {
                        case 0:
                            value = "女";
                            break;
                        case 1:
                            value = "男";
                            break;
                    }
                    break;
                case "Mobile": left = "手机号码";
                    value = value.replace(/(\d{3})\d{4}(\d{4})/, '$1****$2');
                    break;
                case "RecommendationCode": left = "推荐码"; break;
                case "Remark": left = "备注"; break;
                case "Status":
                    left = "状态";
                    switch (value) {
                        case 0:
                            value = "未成功";
                            break;
                        case 1:
                            value = "成功";
                            break;
                    }
                    break;
                case "ApplicationAmount ":
                    left = "申请金额（元）";
                    value = value.toFixed(2);
                    break;
                case "LoanAmount":
                    left = "放款金额（元）";
                    value = value.toFixed(2);
                    break;
                case "ContractAmount":
                    left = "合同金额（元）";
                    value = value.toFixed(2);
                    break;
                case "LoanTerm": left = "申请期限"; break;
                case "CreateDate":
                    left = "建档日期";
                    value = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    break;
                case "LoanDate":
                    left = "放款日期";
                    if (value != null && value != "") {
                        value = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    }
                    break;
                case "ProductName": left = "申请产品名"; break;
                case "IsSettled ":
                    left = "结算状态";
                    switch (value) {
                        case 0:
                            value = "未结算";
                            break;
                        case 1:
                            value = "已申请";
                            break;
                        case 2:
                            value = "已结算";
                            break;
                    }
                    break;
                case "MerchantRebate":
                    left = "商家返利百分比（%）";
                    value = value.toFixed(2);
                    break;
                case "MerchantMoney":
                    left = "商家返利金额（元）";
                    value = value.toFixed(2);
                    break;
                case "HQRebate":
                    left = "总部返利百分比（%）";
                    value = value.toFixed(2);
                    break;
                case "HQMoney":
                    left = "总部返利金额（元）";
                    value = value.toFixed(2);
                    break;
                case "SettlementDate":
                    left = "结算日期";
                    if (value != null && value != "") {
                        value = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    }
                    break;
            }
            if (left != "" && value != "" && value != null) {
                html += "<div class=\"col-lg-4 text-right\">" + left + "</div>";
                html += "<div class=\"col-lg-8\">" + value + "</div>";
            }
            return html;
        }

        //渠道类别列表
        function getCompanyCategoryList() {
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/x-www-form-urlencoded",
                url: "/ajax/helper.ashx",
                data: { op: "bwjs", om: "gl", action: "companyCategoryListForSelect", r: Math.random() },
                async: false,
                cache: false,
                traditional: false,
                success: function (json) {
                    if (json.result) {
                        $("#inpCompanyCategoryForQuery").append("<option value=\"\">请选择</option>");
                        $.each(json.data, function (key, value) {
                            $("#inpCompanyCategoryForQuery").append("<option value=\"" + value.CompanyCategoryId + "\">" + value.CompanyCategoryName + "</option>");
                        });
                    } else {
                        alert(json.msg);
                    }
                },
                error: function (json) {
                    alert("加载渠道类别列表失败，请重试");
                },
            });
        }
    </script>
</asp:Content>
