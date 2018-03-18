<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demoDataTable.aspx.cs" Inherits="BWJS.WebApp.Test.demoDataTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Content/css/Admin/main.css" rel="stylesheet" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Content/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="/Content/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/uril.js" type="text/javascript"></script>
    <script src="/Scripts/layer.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-striped table-bordered" id="orderPayApplyList">
            <thead>
                <tr>
                    <th>
                        <input type="checkbox" class="checkall" />
                    </th>
                    <th>支付申请编号</th>
                    <th>保单号</th>
                    <th>投保人</th>
                    <th>被保人</th>
                    <th>支付金额</th>
                    <th>支付状态</th>
                    <th>购买产品</th>
                    <th>下单日期</th>
                    <th>支付完成日期</th>
                    <th>操作</th>
                </tr>
            </thead>
        </table>
        <script src="http://res.80community.com/ace/assets/js/dataTables/jquery.dataTables.bootstrap.js"></script>
        <script src="http://res.80community.com/jquery.formatDateTime/jquery.formatDateTime.js"></script>
        <script type="text/javascript">

            var orderPayApplyTable;

            $(document).ready(function () {

                GetOrderPayApplyList();
            });

            function GetOrderPayApplyList() {
                debugger;
                if (typeof (orderPayApplyTable) != "undefined") {
                    orderPayApplyTable.fnClearTable(false); //清空一下table
                    orderPayApplyTable.fnDestroy(); //还原初始化了的datatable
                }
                orderPayApplyTable = $("#orderPayApplyList").dataTable({
                    //bAutoWidth: true,
                    //iDisplayStart: 0,
                    //iDisplayLength: 10,
                    aaSorting: [[1, "desc"]],
                    bDestroy: true,
                    bFilter: false,
                    bServerSide: true,
                    sServerMethod: "POST",
                    //sAjaxSource: "/ajax/helper.ashx",
                    sAjaxSource: "/ajax/helper.ashx",
                    fnServerData: function (sUrl, aoData, fnCallback) {
                        var searchValue = $("#inpSearchValue").val();
                        aoData.push(
                                { "name": "op", "value": "bwjs" },
                                { "name": "action", "value": "orderPayApplyL" },
                                { "name": "searchValue", "value": encodeURI(searchValue) },
                                { "name": "timeStamp", "value": new Date().getTime() },
                                { "name": "iDisplayStart", "value": iDisplayStart },
                                { "name": "iDisplayLength", "value": iDisplayLength }
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
                            data: "OrderPayApplyId",
                            render: function (data, type, full, meta) {
                                return '<input type="checkbox"  class="checkchild"  value="' + full.OrderPayApplyId + '" />';
                            },
                            bSortable: false
                        },
                        { mData: "OrderPayApplyId" },
                        { mData: "InsureNum" },
                        { mData: "TBName" },
                        { mData: "BBName" },
                        { mData: "OrderMoney" },
                        {
                            mData: "PayStatus",
                            mRender: function (data, type, full) {
                                var result = full.PayStatus;
                                switch (full.PayStatus) {
                                    case 0:
                                        result = "未支付";
                                        break;
                                    case 1:
                                        result = "已支付";
                                        break;
                                }
                                return result;
                            },
                        },
                        { mData: "Remark" },
                        {
                            mData: "CreateDate",
                            mRender: function (data, type, full) {
                                var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.CreateDate));
                                return result;
                            },
                        },
                        {
                            mData: "PayDate",
                            mRender: function (data, type, full) {
                                var result = full.PayDate;
                                if (full.PayDate != "" && full.PayDate != null) {
                                    result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.PayDate));;
                                }
                                return result;
                            },
                        },
                        {
                            sClass: "center",
                            mData: "OrderPayApplyId",
                            bSortable: false,
                            mRender: function (data, type, full) {//<i class=\"ace-icon fa fa-angle-double-down\"></i> 
                                var option = " <a data-toggle=\"modal\" data-target=\"#funcModel\" data-id=\"" + full.OrderPayApplyId + "\" title=\"查看详情\" style=\"cursor: pointer;\"><i class=\"ace-icon fa fa-cog\"></i></a>";
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
        </script>
    </form>
</body>
</html>
