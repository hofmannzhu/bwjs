<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/m1.Master" CodeBehind="OrderCancelList.aspx.cs" Inherits="BWJS.WebApp.Admin.OrderCancelList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container-fluid user-list ">
        <div class="add-box">
            <div class="search-box">
                <div class="input-group">
                    <input id="inpSearchValue" name="inpSearchValue" type="text" class="form-control" placeholder="检索保单号" />
                    <a href="javascript:void(0)" id="btnSearch" class="input-group-addon"><i class="glyphicon glyphicon-search"></i></a>
                </div>
            </div>
        </div>
        <div style="padding-top: 60px">
        </div>
        <div id="tableArea">
            <table class="table table-striped " id="orderCancelList">
                <thead>
                    <tr>
                        <th>保单号</th>
                        <th>订单流水号</th>
                        <th>所属商家</th>
                        <th>所属部门</th>
                        <th>退保返回消息</th>
                        <th>申请日期</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <!--广告位列表 end-->
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">

        var orderCancelTable;

        $(document).ready(function () {

            GetOrderCancelList();

            $("#btnSearch").click(function () {
                GetOrderCancelList()
            });
        });

        function GetOrderCancelList() {
            debugger;
            if (typeof (orderCancelTable) != "undefined") {
                orderCancelTable.fnClearTable(false); //清空一下table
                orderCancelTable.fnDestroy(); //还原初始化了的datatable
            }
            orderCancelTable = $("#orderCancelList").dataTable({
                bAutoWidth: true,
                aaSorting: [[0, "desc"]],
                bDestroy: true,
                bServerSide: true,
                sServerMethod: "POST",
                sAjaxSource: "/ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var searchValue = $("#inpSearchValue").val();
                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "gl" },
                            { "name": "action", "value": "orderCancleList" },
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
                                 nulyrl = ' <lable id="InsureNumID" style="color:blue" onclick=" return SubInsureNum(' + row.OrderRebateId + ',' + row.OrderApplyID + ',' + row.InsureNum + ')" >' + data + '</label>';
                             }
                             return nulyrl;
                         }
                     },
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
                    { mData: "RespMsg" },
                    {
                        mData: "RecordCreateTime",
                        mRender: function (data, type, full) {
                            var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.RecordCreateTime));
                            return result;
                        },
                    },
                ],
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
