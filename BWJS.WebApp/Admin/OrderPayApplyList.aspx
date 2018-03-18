<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="OrderPayApplyList.aspx.cs" Inherits="BWJS.WebApp.Admin.OrderPayApplyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
    <script src="/Scripts/WdatePicker/WdatePicker.js"></script>
    <script src="/Scripts/WdatePicker/config.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container-fluid user-list mat1">
        <div class="container-fluid" style="background:#e6e4e4;border-radius:12px 12px 12px 12px;height:150px;margin-top:1%">
            <div class="row">
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpPayStatus">支付状态</label>
                        <select id="inpPayStatus" name="inpPayStatus" class="form-control">
                            <option value="">请选择</option>
                            <option value="0">未支付</option>
                            <option value="1">已支付</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpIsSettled">结算状态</label>
                        <select id="inpIsSettled" name="inpIsSettled" class="form-control">
                            <option value="">请选择</option>
                            <option value="0">未结算</option>
                            <option value="1">已申请</option>
                            <option value="2">已结算</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a  ma-bt">
                    <div class="form-inline">
                        <label for="inpIsCancel">退保状态</label>
                        <select id="inpIsCancel" name="inpIsCancel" class="form-control">
                            <option value="">请选择</option>
                            <option value="0">未退保</option>
                            <option value="1">已退保</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt" >
                    <div class="form-inline">
                        <label for="inpTransNo"><i class="jg3">流</i><i class="jg3">水</i>号</label>
                        <input id="inpTransNo" name="inpTransNo" type="text" class="form-control" placeholder="请输入订单流水号" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpInsureNum"><i class="jg3">保</i><i class="jg3">单</i>号</label>
                        <input id="inpInsureNum" name="inpInsureNum" type="text" class="form-control" placeholder="请输入保单号" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpTBName"><i class="jg3">投</i><i class="jg3">保</i>人</label>
                        <input id="inpTBName" name="inpTBName" type="text" class="form-control" placeholder="请输入投保人" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpBBName"><i class="jg3">被</i><i class="jg3">保</i>人</label>
                        <input id="inpBBName" name="inpBBName" type="text" class="form-control" placeholder="请输入被保人" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpMerchantNameForQuery"><i class="jg">商</i>家</label>
                        <input id="inpMerchantNameForQuery" name="inpMerchantNameForQuery" type="text" class="form-control" placeholder="请输入商家" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpRemark">购买产品</label>
                        <input id="inpRemark" name="inpRemark" type="text" class="form-control" placeholder="请输入购买产品" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpCreateDateStart">下单日期</label>
                        <input id="inpCreateDateStart" name="inpCreateDateStart" type="text" class="form-control" placeholder="下单开始日期" readonly />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpCreateDateEnd"><i class="jg1a">-</i>至</label>
                        <input id="inpCreateDateEnd" name="inpCreateDateEnd" type="text" class="form-control" placeholder="下单截止日期" readonly />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <a class="btn btn-info" id="btnSearch" style="width:38%"><span class="glyphicon glyphicon-search"></span>查 询</a>
                        <button id="btnReset" type="reset" class="btn btn-info" style="width:38%"><span class="glyphicon glyphicon-refresh"></span>重 置</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a">
                    <div class="form-inline">
                    </div>
                </div>
            </div>
        </div>
        <div id="tableArea">
            <table class="display table table-bordered" id="orderPayApplyList" scrollX:"true" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>保单号</th>
                        <th>订单流水号</th>
                        <th>所属商家</th>
                        <th>所属部门</th>
                        <th>投保人</th>
                        <th>被保人</th>
                        <th>支付金额</th>
                        <th>支付状态</th>
                        <th>结算状态</th>
                        <th>退保状态</th>
                        <th>购买产品</th>
                        <th>下单日期</th>
                        <th>支付完成日期</th>
                        <th>操作</th>
                    </tr>
                </thead>
            </table>
        </div>

    </div>
    <div class="modal fade" id="orderCancleModal" tabindex="-1" role="dialog" aria-labelledby="orderCancleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="orderCancleModalLabel">退保确认</h4>
                </div>
                <div class="modal-body">
                    <p>确认退保吗？</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-sm btn-primary" id="btnOrderCancle">确认</button>
                    <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">取消</button>
                </div>
            </div>
        </div>
    </div>
    <input id="hiddId" name="hiddId" type="hidden" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">

        var orderPayApplyTable;

        $(document).ready(function () {
            $('#inpCreateDateStart').on('focus', function () {
                WdatePicker({ onpicked: function (db) { db.$('inpCreateDateEnd').focus(); }, dateFmt: 'yyyy-MM-dd' });
            });
            $('#inpCreateDateEnd').on('focus', function () {
                WdatePicker({ minDate: '#F{$dp.$D(\'inpCreateDateStart\')}', dateFmt: 'yyyy-MM-dd' });
            });

            GetOrderPayApplyList();

            $("#btnSearch").click(function () {
                GetOrderPayApplyList()
            });

            $("#btnOrderCancle").click(function () {
                orderCancle();
            });

            $("#orderCancleModal")
                .on('show.bs.modal', function (e) {
                    var op = $(e.relatedTarget);
                    var id = op.data("id");
                    if (id == undefined) {
                        if ($(".checkchild:checked").length == 0) {
                            myAlert("请先选择一条数据");
                            $("#orderCancleModal").modal("hide");
                            return false;
                        }
                    }
                })
                .on('shown.bs.modal', function (e) {
                    var op = $(e.relatedTarget);
                    var id = op.data("id");
                    if (id != undefined) {
                        $("#hiddId").val(id);
                    }
                    var orderNo = op.data("id");
                    if (orderNo != undefined) {
                        $("#orderNo").val(orderNo);
                    }
                })
                .on('hide.bs.modal', function () {
                })
                .on('hidden.bs.modal', function () {
                    if (typeof (orderPayApplyTable) != "undefined") {
                        orderPayApplyTable.fnDraw(false);
                    }
                });
        });

        function GetOrderPayApplyList() {
            if (typeof (orderPayApplyTable) != "undefined") {
                orderPayApplyTable.fnClearTable(false); //清空一下table
                orderPayApplyTable.fnDestroy(); //还原初始化了的datatable
            }
            orderPayApplyTable = $("#orderPayApplyList").dataTable({
                bAutoWidth: true,
                aaSorting: [[1, "desc"]],
                bDestroy: true,
                bFilter: false,
                "sDefaultContent": "",
                "bProcessing": true,
                "scrollX": true,
                sScrollXInner: "140%",
                bScrollCollapse: true,
                bServerSide: true,
                sServerMethod: "POST",
                sAjaxSource: "/ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var payStatus = $("#inpPayStatus").val();
                    var isSettled = $("#inpIsSettled").val();
                    var isCancel = $("#inpIsCancel").val();
                    var transNo = $.trim($("#inpTransNo").val());
                    var insureNum = $.trim($("#inpInsureNum").val());
                    var tBName = $.trim($("#inpTBName").val());
                    var bBName = $.trim($("#inpBBName").val());
                    var merchantName = $.trim($("#inpMerchantNameForQuery").val());
                    var remark = $.trim($("#inpRemark").val());
                    var createDateStart = $.trim($("#inpCreateDateStart").val());
                    var createDateEnd = $.trim($("#inpCreateDateEnd").val());

                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "gl" },
                            { "name": "action", "value": "orderPayApplyL" },
                            { "name": "payStatus", "value": payStatus },
                            { "name": "isSettled", "value": isSettled },
                            { "name": "isCancel", "value": isCancel },
                            { "name": "transNo", "value": encodeURI(transNo) },
                            { "name": "insureNum", "value": encodeURI(insureNum) },
                            { "name": "tBName", "value": encodeURI(tBName) },
                            { "name": "bBName", "value": encodeURI(bBName) },
                            { "name": "merchantName", "value": encodeURI(merchantName) },
                            { "name": "remark", "value": encodeURI(remark) },
                            { "name": "createDateStart", "value": encodeURI(createDateStart) },
                            { "name": "createDateEnd", "value": encodeURI(createDateEnd) },
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
                     { mData: "InsureNum", sWidth: "150px" },
                    { mData: "TransNo" },
                     {
                         mData: "MerchantName", mRender: function (data, type, row) {
                             if (row.uIsDeleted == 1) {
                                 return data + "(<span style=\"color:red\">已删除</span>)";
                             } else {
                                 return data
                             }

                         }
                     },
                     { mData: "DepartmentName" },
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
                    {
                        mData: "IsSettled",
                        mRender: function (data, type, full) {
                            var result = full.IsSettled;
                            switch (full.IsSettled) {
                                case 0:
                                    result = "未结算";
                                    break;
                                case 1:
                                    result = "已申请";
                                    break;
                                case 2:
                                    result = "已结算";
                                    break;
                            }
                            return result;
                        },
                    },
                    {
                        mData: "IsCancel",
                        mRender: function (data, type, full) {
                            var result = full.IsCancel;
                            switch (full.IsCancel) {
                                case 0:
                                    result = "未退保";
                                    break;
                                case 1:
                                    result = "已退保";
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
                                result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.PayDate));
                            }
                            return result;
                        },
                    },
                    {
                        sClass: "center",
                        mData: "OrderPayApplyId",
                        bSortable: false,
                        mRender: function (data, type, full) {//<i class=\"ace-icon fa fa-angle-double-down\"></i> 
                            var option = " <a onclick=\" return SubInsureNum(" + full.OrderRebateId + "," + full.OrderApplyId + "," + full.InsureNum + ");\" href=\"javascript:void(0)\" title=\"查看详情\">查看</a>";
                            //已支付未结算未退保的记录显示退保按钮
                            if (full.PayStatus == 1 && full.IsSettled == 0 && full.IsCancel == 0 && full.InsureNum != null) {
                                //option += " <a onclick=\" return orderCancle(" + full.InsureNum + ");\" href=\"javascript:void(0)\" title=\"退保\">退保</a>";

                                  <%if (this.CheckedAuthorize("py54h1"))
        { %>
                                option += " <a data-toggle=\"modal\" data-target=\"#orderCancleModal\" data-action=\"orderCancle\" data-id=\"" + full.OrderRebateId + "," + full.InsureNum + "," + full.OrderApplyId + "," +<%=LoginUserId%> +"," + full.TransNo + "\"  title=\"退保\" style=\"cursor: pointer;\">退保</a>"
                                   <%} %>
                            }
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

            function SubInsureNum(OrderRebateId, OrderApplyId, InsureNum) {
                $.layer({
                    type: 2,
                    title: [
                       "承保详情"
                    ],
                    border: [0],
                    area: ['570px', '580px'],
                    end: function () {
                        location.reload();
                    },
                    iframe: { src: '/Admin/OrderRebateInfo.aspx?OrderRebateId=' + OrderRebateId + '&OrderApplyId=' + OrderApplyId + '&InsureNum=' + InsureNum }
                });
                return false;
            }
            //退保
            function orderCancle() {
                var dataParam = $("#hiddId").val();

                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "gl";
                paramter.action = "orderCancle";
                paramter.dataParam = dataParam;
                $.ajax({
                    url: "/ajax/helper.ashx",
                    type: "POST",
                    data: paramter,
                    dataType: "json",
                    async: false,
                    success: function (json) {
                        if (json.result) {
                            $("#hiddId").val("");
                        }
                        myAlert(json.msg);
                        $("#orderCancleModal").modal("hide");
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
            }

    </script>
</asp:Content>
