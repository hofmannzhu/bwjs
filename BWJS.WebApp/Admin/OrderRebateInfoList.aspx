<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="OrderRebateInfoList.aspx.cs" Inherits="BWJS.WebApp.Admin.OrderRebateInfoList" %>
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
        <div class="add-box">
            <div class="search-box">
                <div class="input-group">
                        <input type="text" id="inpSearchValue" class="form-control" placeholder="订单号/保单号搜索" />
                    <span class="input-group-addon" id="btnSearch"><i class="glyphicon glyphicon-search"></i></span>
                </div>
            </div>
        </div>
         <div style="padding-top:60px">
             </div>

        <div id="tableArea">
        
            <table class="display table table-bordered" id="table" scrollX:"true"  cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>保单号</th>
                        <th>订单流水号</th>
                        <th>订单金额</th>
                        <th>所属商家</th>
                        <th>所属部门</th>
                        <th>博望总部返利百分比</th>
                        <th>博望总部返利金额</th>
                        <th>代理商返利百分比</th>
                        <th>代理商返利金额</th>
                        <th>商家返利百分比</th>
                        <th>商家返利金额</th>
                        <th>净利润</th>
                        <th>支付状态</th>
                        <th>结算状态</th>
                        <th>退保状态</th>
                        <th>结算日期</th> 
                        <th>建档日期</th>
                        <th>备注</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
        <script type="text/javascript">
            var OrderRebateTable;

            $(document).ready(function () {
                GetOrderRebateTable();
                $("#btnSearch").click(function () {
                    GetOrderRebateTable()
                });
            });


            function GetOrderRebateTable() {
                if (typeof (OrderRebateTable) != "undefined") {
                    OrderRebateTable.fnClearTable(false); //清空一下table
                    OrderRebateTable.fnDestroy(); //还原初始化了的datatable
                }

                OrderRebateTable = $("#table").dataTable({
                    bAutoWidth: false,
                    aaSorting: [[1, "desc"]],
                    bDestroy: true,
                    bFilter: false,
                    "sDefaultContent": "",
                    "bProcessing": true,
                    "scrollX": true,
                    sScrollXInner: "130%",
                    bScrollCollapse: true,
                    bServerSide: true,
                    sServerMethod: "POST",
                    sAjaxSource: "../Ajax/helper.ashx",
                    fnServerData: function (sUrl, aoData, fnCallback) {
                        var searchValue = $("#inpSearchValue").val();
                        aoData.push(
                                { "name": "op", "value": "bwjs" },
                                { "name": "om", "value": "func" },
                                { "name": "action", "value": "OrderRebateList" },
                                { "name": "searchValue", "value": encodeURI(searchValue) },
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
                              mData: "InsureNum",
                              mRender: function (data, type, row) {
                                  var nulyrl = '';
                                  if (data != null) {
                                      nulyrl = ' <lable id="InsureNumID" style="color:blue" onclick=" return SubInsureNum(' + row.OrderRebateId + ',' + row.OrderApplyId + ',' + row.InsureNum + ')" >' + data + '</label>';
                                  }
                                  return nulyrl;
                              }
                          },
                            { mData: "TransNo", sWidth: "100px" },
                            {
                                mData: "OrderMoney", mRender: function (data, type, row) { return data + "元" }
                            },
                             {
                                 mData: "MerchantName", mRender: function (data, type, row) {
                                     if (row.uIsDeleted == 1) {
                                         return data + "(<span style=\"color:red\">已删除</span>)";
                                     } else {
                                         return data
                                     }
                                 }
                             },
                            { mData: "DepartmentName", sWidth: "100px" },
                            { mData: "HQRebate", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "%" } },
                            { mData: "HQMoney", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                            { mData: "AgentRebate", mRender: function (data, type, row) { return ((row.AgentRebate == null) ? ("0.00") : (row.AgentRebate.toFixed(2))) + "%" } },
                            { mData: "AgentMoney", mRender: function (data, type, row) { return ((row.AgentMoney == null) ? ("0.00") : (row.AgentMoney.toFixed(2))) + "元" } },
                            { mData: "MerchantRebate", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "%" } },
                            { mData: "MerchantMoney", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                            { mData: "NetProfit", mRender: function (data, type, row) { return ((data == null) ? ("0.00") : (data.toFixed(2))) + "元" } },
                            {
                                mData: "PayStatus",
                                mRender: function (data, type, full) {
                                    var b = '';
                                    //支付状态0未支付1已支付2支付失败
                                    if (data == 0) {
                                        b = '<span style="color:grey">未支付<span/>';
                                    } else if (data == 1) {
                                        b = '<span style="color:green">已支付<span/>';
                                    } else if (data == 2) {
                                        b = '<span style="color:red">支付失败<span/>';
                                    } else {
                                        b = '<span style="color:grey">未支付<span/>';
                                    }
                                    return b;
                                }
                            },

                            {
                                mData: "IsSettled",
                                mRender: function (data, type, full) {
                                    //结算状态0未结算1已申请2已结算
                                    var c = '';
                                    if (data == 0) {
                                        c = '<span style="color:grey">未结算<span/>';
                                    } else if (data == 1) {
                                        c = '<span style="color:yellow">已申请<span/>';
                                    } else if (data == 2) {
                                        c = '<span style="color:green">已结算<span/>';
                                    }
                                    return c;
                                },
                            }, {
                                mData: "IsCancel",
                                mRender: function (data, type, full) {
                                    var d = '';
                                    //退保状态0未退保1已退保
                                    if (data == 0) {
                                        d = '<span style="color:green">未退保<span/>';
                                    } else {
                                        d = '<span style="color:red">已退保<span/>';
                                    }
                                    return d;
                                },
                            },

                            {
                                mData: "SettlementDate",
                                mRender: function (data, type, full) {
                                    var result = "";
                                    if (full.SettlementDate != null && full.SettlementDate != "") {
                                        $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.SettlementDate));
                                    }
                                    return result;
                                },
                            },
                            {
                                mData: "CreateDate",
                                mRender: function (data, type, full) {
                                    var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.CreateDate));
                                    return result;
                                },
                            },
                            { mData: "Remark" }
                    ],
                });
            };



            function SubInsureNum(OrderRebateId, OrderApplyId, InsureNum) {
                $.layer({
                    type: 2,
                    title: [
                       "承保详情"
                    ],
                    border: [0],
                    area: ['570px', '580px'],
                    end: function () {
                        if (typeof (OrderRebateTable) != "undefined") {
                            OrderRebateTable.fnDraw(false);
                        }
                    },
                    iframe: { src: 'OrderRebateInfo.aspx?OrderRebateId=' + OrderRebateId + '&OrderApplyId=' + OrderApplyId + '&InsureNum=' + InsureNum }
                });
                return false;
            }
    </script>
</asp:Content>
