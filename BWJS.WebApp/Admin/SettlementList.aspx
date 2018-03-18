<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="SettlementList.aspx.cs" Inherits="BWJS.WebApp.Admin.SettlementList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
    <%-- <style type="text/css">
        table th {
            width: 7.5%;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/messages_zh.min.js"></script>
    <script src="/Scripts/WdatePicker/WdatePicker.js"></script>
    <script src="/Scripts/WdatePicker/config.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container-fluid user-list mat1">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a">
                    <div class="form-inline">
                        <label for="inpPaymentMethod">支付方式</label>
                        <select id="inpPaymentMethod" name="inpPaymentMethod" class="form-control">
                            <option value="">请选择</option>
                            <option value="1">线下转账</option>
                            <option value="2">在线支付</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a">
                    <div class="form-inline">
                        <label for="inpApplyStatus">结算状态</label>
                        <select id="inpApplyStatus" name="inpApplyStatus" class="form-control">
                            <option value="">请选择</option>
                            <option value="0">未结算</option>
                            <option value="1">待支付</option>
                            <option value="2">已结算</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpMerchantName"><i class="jg">商</i>家</label>
                        <input id="inpMerchantName" name="inpMerchantName" type="text" class="form-control" placeholder="请输入商家" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpApplyMoney">结算金额</label>
                        <input id="inpApplyMoney" name="inpApplyMoney" type="text" class="form-control" placeholder="请输入结算金额" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpOpeningBank"><i class="jg2">开</i> <i class="jg2">户</i>  行</label>
                        <input id="inpOpeningBank" name="inpOpeningBank" type="text" class="form-control" placeholder="请输入开户行" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpCardHolder"><i class="jg2">持</i> <i class="jg2">卡</i> 人</label>
                        <input id="inpCardHolder" name="inpCardHolder" type="text" class="form-control" placeholder="请输入持卡人" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpCardNumber"><i class="jg">卡</i>号</label>
                        <input id="inpCardNumber" name="inpCardNumber" type="text" class="form-control" placeholder="请输入卡号" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpRemark"><i class="jg">备</i>注</label>
                        <input id="inpRemark" name="inpRemark" type="text" class="form-control" placeholder="请输入备注" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpStartDate">结算周期</label>
                        <input id="inpStartDate" name="inpStartDate" type="text" class="form-control" placeholder="结算开始日期" readonly />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpStartDate"><i class="jg1">-</i>至</label>
                        <input id="inpEndDate" name="inpEndDate" type="text" class="form-control" placeholder="结算截止日期" readonly />
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
        <div class="container-fluid">
            <div class="row">
                <div class="form-inline">
                    <%if (CheckedAuthorize("d6uxvo"))
                        { %>
                    <%--<a class="btn btn-info" onclick="return ShowAdd(0)"><span class="glyphicon glyphicon-plus"></span>结算申请</a>--%>
                    <a class="btn btn-info" data-toggle="modal" data-target="#applyModal" href="/Admin/SettlementApply.aspx" title="结算申请"><span class="glyphicon glyphicon-plus"></span>结算申请</a>

                    <%} %>
                    <%if (CheckedAuthorize("k0bntq"))
                        { %>
                    <a class="btn btn-info" id="btnMultySettlement"><span class="glyphicon glyphicon-trash"></span>批量结算完成</a>
                    <%} %>
                </div>
            </div>
        </div>
        <div id="tableArea">
            <table id="settlementList" class="display table table-bordered">
                <thead>
                    <tr>
                        <th style="width: 5%;">
                            <input type="checkbox" class="checkall" />
                        </th>
                        <th style="width: 7.5%;">商家</th>
                        <th style="width: 7.5%;">结算周期</th>
                        <th style="width: 7.5%;">结算金额</th>
                        <th style="width: 7.5%;">开户行</th>
                        <th style="width: 7.5%;">持卡人</th>
                        <th style="width: 7.5%;">卡号</th>
                        <%--<th>结算方式</th>--%>
                        <th style="width: 7.5%;">结算状态</th>
                        <th style="width: 7.5%;">支付方式</th>
                        <th style="width: 7.5%;">建档人</th>
                        <th style="width: 7.5%;">建档日期</th>
                        <th style="width: 7.5%;">操作</th>
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
                    <h4 class="modal-title" id="detailsModalLabel">结算详情</h4>
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
    <div class="modal fade" id="applyModal" data-backdrop="false" tabindex="-1" role="dialog" aria-labelledby="applyModalLabel">
        <div class="modal-dialog" role="document" style="width: 60%;">
            <div class="modal-content">
                <div class="modal-body">
                    数据加载...
                        <a data-dismiss="modal" href="javascript:void(0)">取 消</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">

        var settlementTable;

        $(document).ready(function () {
            $('#inpStartDate').on('focus', function () {
                WdatePicker({ onpicked: function (db) { db.$('inpEndDate').focus(); }, dateFmt: 'yyyy-MM-dd' });
            });
            $('#inpEndDate').on('focus', function () {
                WdatePicker({ minDate: '#F{$dp.$D(\'inpStartDate\')}', dateFmt: 'yyyy-MM-dd' });
            });
            $("#applyModal")
                .on('show.bs.modal', function (e) {
                })
                .on('shown.bs.modal', function (e) {
                    $("#btnResetQuery").trigger("click");
                    $("#btnResetApply").trigger("click");
                    $("#btnApply").hide();
                    $("#applyForm").hide();
                    $("#queryOrderList").hide();
                    $("#queryOrderShow").html("订单总金额：<b style=\"color: red\">（0.00）</b> 元 | 总部返利总金额：<b style=\"color: red\">（0.00）</b> 元 | 代理商返利总金额：<b style=\"color: red\">（0.00）</b> 元 | 商家返利总金额：<b style=\"color: red\">（0.00）</b> 元 | 净利润：<b style=\"color: red\">（0.00）</b> 元");

                    if (typeof (queryOrderTable) != "undefined") {
                        queryOrderTable.fnClearTable(false); //清空一下table
                        queryOrderTable.fnDestroy(); //还原初始化了的datatable
                    }
                })
                .on('hide.bs.modal', function () {
                })
                .on('hidden.bs.modal', function () {
                    if (typeof (settlementTable) != "undefined") {
                        settlementTable.fnDraw(false);
                    }
                });

            GetSettlementList();

            $("#btnMultySettlement").click(function () {
                multySettlement();
            });

            $("#btnSearch").click(function () {
                GetSettlementList()
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

        function GetSettlementList() {
            if (typeof (settlementTable) != "undefined") {
                settlementTable.fnClearTable(false); //清空一下table
                settlementTable.fnDestroy(); //还原初始化了的datatable
            }
            settlementTable = $("#settlementList").dataTable({
                bAutoWidth: true,
                aaSorting: [[0, "desc"]],
                bDestroy: true,
                bServerSide: true,
                sServerMethod: "POST",
                sAjaxSource: "/ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {

                    var paymentMethod = $("#inpPaymentMethod").val();
                    var status = $("#inpApplyStatus").val();
                    var merchantName = $.trim($("#inpMerchantName").val());
                    var openingBank = $.trim($("#inpOpeningBank").val());
                    var cardHolder = $.trim($("#inpCardHolder").val());
                    var cardNumber = $.trim($("#inpCardNumber").val());
                    var remark = $.trim($("#inpRemark").val());
                    var applyMoney = $.trim($("#inpApplyMoney").val());
                    var startDate = $.trim($("#inpStartDate").val());
                    var endDate = $.trim($("#inpEndDate").val());
                    aoData.push(
                        { "name": "op", "value": "bwjs" },
                        { "name": "om", "value": "settlement" },
                        { "name": "action", "value": "getsettlementlist" },
                        { "name": "paymentMethod", "value": paymentMethod },
                        { "name": "status", "value": status },
                        { "name": "merchantName", "value": encodeURI(merchantName) },
                        { "name": "openingBank", "value": encodeURI(openingBank) },
                        { "name": "cardHolder", "value": encodeURI(cardHolder) },
                        { "name": "cardNumber", "value": encodeURI(cardNumber) },
                        { "name": "remark", "value": encodeURI(remark) },
                        { "name": "applyMoney", "value": encodeURI(applyMoney) },
                        { "name": "startDate", "value": encodeURI(startDate) },
                        { "name": "endDate", "value": encodeURI(endDate) },
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
                    {
                        sClass: "text-center",
                        data: "OrderRebateSettlementApplyId",
                        render: function (data, type, full, meta) {
                            var result = "";
                            if (full.ApplyStatus != 1) {
                                result = '<input type="checkbox"  class="checkchild"  value="' + full.OrderRebateSettlementApplyId + '" />';
                            }
                            return result;
                        },
                        bSortable: false
                    },
                    { mData: "MerchantName" },
                    {
                        mData: "StartDate",
                        mRender: function (data, type, full) {
                            var result = "";
                            if (full.StartDate != null && full.StartDate != "" && full.EndDate != "" && full.EndDate != "") {
                                result = $.formatDateTime("yy-mm-dd", new Date(full.StartDate)) + "至" + $.formatDateTime("yy-mm-dd", new Date(full.EndDate));
                            }
                            return result;
                        },
                    },
                    { mData: "ApplyMoney", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                    { mData: "OpeningBank" },
                    { mData: "CardHolder" },
                    {
                        mData: "CardNumber", mRender: function (data, type, row) {
                            var cardNumber = "";
                            if (row.CardNumber != null && row.CardNumber != "") {
                                //cardNumber = row.CardNumber.replace(/^(\d{4})(\d*)(\d{4})$/, "$1******$12");
                                cardNumber = row.CardNumber.replace(/^(.{6}).+(.{4})$/g, "$1******$2");
                            }
                            return cardNumber;
                        }
                    },
                    //{
                    //    mData: "SettlementMethod",
                    //    mRender: function (data, type, full) {
                    //        var result = full.SettlementMethod;
                    //        switch (full.SettlementMethod) {
                    //            case 1:
                    //                result = "销售额百分比";
                    //                break;
                    //            case 2:
                    //                result = "单笔结算";
                    //                break;
                    //        }
                    //        return result;
                    //    },
                    //},
                    {
                        mData: "ApplyStatus",
                        mRender: function (data, type, full) {
                            var result = full.ApplyStatus;
                            switch (full.ApplyStatus) {
                                case 0:
                                    result = "<span style=\"color:green\">未结算<span/>";
                                    break;
                                case 1:
                                    result = "<span style=\"color:red\">已结算<span/>";
                                    break;
                            }
                            return result;
                        },
                    },
                    {
                        mData: "PaymentMethod",
                        mRender: function (data, type, full) {
                            var result = full.PaymentMethod;
                            switch (full.PaymentMethod) {
                                case 1:
                                    result = "线下转账";
                                    break;
                                case 2:
                                    result = "在线支付";
                                    break;
                            }
                            return result;
                        },
                    },
                    { mData: "CreateName" },
                    {
                        mData: "CreateDate",
                        mRender: function (data, type, full) {
                            var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.CreateDate));
                            return result;
                        },
                    },
                    {
                        sClass: "center",
                        mData: "OrderRebateSettlementApplyId",
                        bSortable: false,
                        mRender: function (data, type, full) {
                            var option = "";
                                <%if (this.CheckedAuthorize("omzjkw"))
        { %>
                            option = "<a data-toggle=\"modal\" data-target=\"#detailsModal\" data-action=\"orderCancle\" data-id=\"" + full.OrderRebateSettlementApplyId + "\" class=\"btn btn-mini\" title=\"查看详情\">查看</a>";
                            <%} %>

                            <%if (this.CheckedAuthorize("k0bntq"))
        { %>
                            if (full.ApplyStatus != 1) {
                                option += "<a class=\"btn btn-mini\" onclick=\"singleSettlement(" + full.OrderRebateSettlementApplyId + ")\" title=\"结算完成\">结算完成</a>";
                            }
                              <%} %>


                            return option;
                        }
                    },
                ],
            });
            //
                $(".checkall").click(function () {
                    var check = $(this).prop("checked");
                    $(".checkchild").prop("checked", check);
                });
            }

            function look(postId) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "settlement";
                paramter.action = "getsettlementmodel";
                paramter.OrderRebateSettlementApplyId = postId;
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

            //单条结算
            function singleSettlement(OrderRebateSettlementApplyId) {
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("确认结算吗？", function (result) {
                    if (result) {
                        if (OrderRebateSettlementApplyId > 0) {
                            $.ajax({
                                type: "POST",
                                async: false,
                                dataType: "json",
                                url: "/ajax/helper.ashx?r=" + Math.random(),
                                data: { op: "bwjs", om: "settlement", action: "confirmsettlement", OrderRebateSettlementApplyId: OrderRebateSettlementApplyId },
                                success: function (json) {
                                    if (json.result) {
                                        if (typeof (settlementTable) != "undefined") {
                                            settlementTable.fnDraw(false);
                                        }
                                    }
                                    myAlert(json.msg);
                                }
                            });
                        }
                    }
                });
            }

            function modelConvert(key, value) {
                var html = "";
                var left = "";
                switch (key) {
                    case "StartDate":
                        left = "申请起始日期";
                        if (value != null && value != "") {
                            value = $.formatDateTime("yy-mm-dd", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                        }
                        break;
                    case "EndDate":
                        left = "申请截止日期";
                        if (value != null && value != "") {
                            value = $.formatDateTime("yy-mm-dd", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                        }
                        break;
                    case "ApplyMoney":
                        left = "申请结算金额";
                        break;
                    case "ActualMoney":
                        left = "实际结算金额";
                        break;
                    case "ApplyStatus":
                        left = "结算申请状态";
                        switch (value) {
                            case 0:
                                value = "未结算";
                                break;
                            case 1:
                                value = "待支付";
                                break;
                            case 2:
                                value = "已结算";
                                break;
                        }
                        break;
                    case "SettlementMethod":
                        left = "结算方式";
                        switch (value) {
                            case 1:
                                value = "销售额百分比";
                                break;
                            case 2:
                                value = "单笔结算";
                                break;
                        }
                        break;
                    case "SalesPercentage":
                        left = "销售额百分比";
                        break;
                    case "PaymentMethod":
                        left = "支付方式";
                        switch (value) {
                            case 1:
                                value = "线下转账";
                                break;
                            case 2:
                                value = "在线支付";
                                break;
                        }
                        break;
                    case "OpeningBank": left = "开户行"; break;
                    case "CardHolder": left = "持卡人"; break;
                    case "CardNumber":
                        left = "卡号";
                        if (value != null && value != "") {
                            value = value.replace(/^(.{6}).+(.{4})$/g, "$1******$2");
                        }
                        break;
                    case "Remark": left = "备注"; break;
                    case "CreateDate":
                        left = "建档日期";
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

            //批量结算
            function multySettlement() {
                if ($(".checkchild:checked").length == 0) {
                    myAlert("请先选择一条数据");
                    return false;
                }
                else {
                    bootbox.setDefaults("locale", "zh_CN");
                    bootbox.confirm("确认结算吗？", function (result) {
                        if (result) {
                            var ids = "";
                            $(".checkchild:checked").each(function () {
                                ids += $(this).val() + ",";
                            });

                            ids = ids.substring(0, ids.length - 1);
                            //myAlert(ids);
                            if (ids != "") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    dataType: "json",
                                    url: "/ajax/helper.ashx?r=" + Math.random(),
                                    data: { op: "bwjs", om: "settlement", action: "confirmsettlement", OrderRebateSettlementApplyId: ids },
                                    success: function (json) {
                                        if (json.result) {
                                            if (typeof (settlementTable) != "undefined") {
                                                settlementTable.fnDraw(false);
                                            }
                                        }
                                        myAlert(json.msg);
                                    }
                                });
                            }
                        }
                    });
                }
            }
    </script>
</asp:Content>
