<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="OrderCheck.aspx.cs" Inherits="BWJS.WebApp.Admin.OrderCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
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
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        渠道反馈模板 <a href="/Upload/渠道反馈模板.xls" style="color: red;">下载</a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="form-inline">
                    <%if (CheckedAuthorize("iy5ipg"))
                        { %>
                    <a class="btn btn-info" data-toggle="modal" data-target="#userBankModal" href="/Admin/OrderImport.aspx" title="导入"><span class="glyphicon glyphicon-plus"></span>导入</a>
                    <%} %>
                    <%if (CheckedAuthorize("5qx96z"))
                        { %>
                    <a class="btn btn-info" id="btnMultyDel"><span class="glyphicon glyphicon-check"></span>检查</a>
                    <%} %>
                </div>
            </div>
        </div>
        <div id="tableArea">
            <table id="bankList" class="display table table-bordered">
                <thead>
                    <tr>
                        <th style="width: 5%;">
                            <input type="checkbox" class="checkall" />
                        </th>
                        <th style="width: 10%;">银行代码</th>
                        <th style="width: 10%;">开户行</th>
                        <th style="width: 10%;">持卡人</th>
                        <th style="width: 10%;">卡号</th>
                        <th style="width: 10%;">银行地址</th>
                        <th style="width: 10%;">建档日期</th>
                        <th style="width: 10%;">操作</th>
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
                    <h4 class="modal-title" id="detailsModalLabel">我的银行卡详情</h4>
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
    <div class="modal fade" id="userBankModal" data-backdrop="false" tabindex="-1" role="dialog" aria-labelledby="userBankModalLabel">
        <div class="modal-dialog" role="document">
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

        var bankTable;

        $(document).ready(function () {
            $("#userBankModal")
                .on('show.bs.modal', function (e) {
                })
                .on('shown.bs.modal', function (e) {
                    var op = $(e.relatedTarget);
                    var id = op.data("id");
                    if (id != undefined) {
                        $("#hiddId").val(id);
                        getBankModelFromServer(id);
                    }
                    else {
                        $("#inpBankCodeForInput").val("");
                        $("#inpOpeningBankForInput").val("");
                        $("#inpCardHolderForInput").val("");
                        $("#inpCardNumberForInput").val("");
                        $("#inpBankAddressForInput").val("");
                    }
                })
                .on('hide.bs.modal', function () {
                })
                .on('hidden.bs.modal', function () {
                    if (typeof (bankTable) != "undefined") {
                        bankTable.fnDraw(false);
                    }
                });

            GetUserBank();

            $("#btnMultyDel").click(function () {
                multyDel();
            });

            $("#btnSearch").click(function () {
                GetUserBank()
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

        function GetUserBank() {
            try {
                if (typeof (bankTable) != "undefined") {
                    bankTable.fnClearTable(false);
                    bankTable.fnDestroy();
                }
                bankTable = $("#bankList").dataTable({
                    bAutoWidth: true,
                    aaSorting: [[0, "desc"]],
                    bDestroy: true,
                    bServerSide: true,
                    sServerMethod: "POST",
                    sAjaxSource: "/ajax/helper.ashx",
                    fnServerData: function (sUrl, aoData, fnCallback) {
                        var bankCode = $.trim($("#inpBankCodeForQuery").val());
                        var openingBank = $.trim($("#inpOpeningBankForQuery").val());
                        var cardHolder = $.trim($("#inpCardHolderForQuery").val());
                        var cardNumber = $.trim($("#inpCardNumberForQuery").val());
                        var bankAddress = $.trim($("#inpBankAddressForQuery").val());
                        aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "gl" },
                            { "name": "action", "value": "userbankl" },
                            { "name": "bankCode", "value": encodeURI(bankCode) },
                            { "name": "openingBank", "value": encodeURI(openingBank) },
                            { "name": "cardHolder", "value": encodeURI(cardHolder) },
                            { "name": "cardNumber", "value": encodeURI(cardNumber) },
                            { "name": "bankAddress", "value": encodeURI(bankAddress) },
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
                            data: "UserBankId",
                            render: function (data, type, full, meta) {
                                return '<input type="checkbox"  class="checkchild"  value="' + full.UserBankId + '" />';
                            },
                            bSortable: false
                        },
                        { mData: "BankCode" },
                        { mData: "OpeningBank" },
                        { mData: "CardHolder" },
                        { mData: "CardNumber" },
                        { mData: "BankAddress" },
                        {
                            mData: "CreateDate",
                            mRender: function (data, type, full) {
                                var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.CreateDate));
                                return result;
                            },
                        },
                        {
                            sClass: "center",
                            mData: "UserBankId",
                            bSortable: false,
                            mRender: function (data, type, full) {
                                var option = "";
                                <%if (this.CheckedAuthorize("u1qtzy"))
        { %>
                                option = "<a data-toggle=\"modal\" data-target=\"#detailsModal\" data-action=\"orderCancle\" data-id=\"" + full.UserBankId + "\" class=\"btn btn-mini\" title=\"查看详情\">查看</a>";
                                <%} %>
                            
                                <%if (this.CheckedAuthorize("a24x3c"))
        { %>
                                option += "<a class=\"btn btn-mini\" data-toggle=\"modal\" data-id=\"" + full.UserBankId + "\" data-target=\"#userBankModal\" href=\"/Admin/UserBankAdd.aspx\" title=\"修改\">修改</a>";

                                <%} %>
                                <%if (this.CheckedAuthorize("5qx96z"))
        { %>
                                option += "<a class=\"btn btn-mini\" onclick=\"singleDel(" + full.UserBankId + ")\" title=\"删除\">删除</a>";
                                <%} %>
                                return option;
                            }
                        },
                    ],
                });
                    $(".checkall").click(function () {
                        var check = $(this).prop("checked");
                        $(".checkchild").prop("checked", check);
                    });
                }
                catch (ex) {
                    myAlert(ex.message);
                }
            }

            function look(postId) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "gl";
                paramter.action = "userbankmodel";
                paramter.userBankId = postId;
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
            function getBankModelFromServer(postId) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "gl";
                paramter.action = "userbankmodel";
                paramter.userBankId = postId;
                var json = getJson(paramter, false);
                if (json.result) {
                    $("#inpBankCodeForInput").val(json.data.BankCode);
                    $("#inpOpeningBankForInput").val(json.data.OpeningBank);
                    $("#inpCardHolderForInput").val(json.data.CardHolder);
                    $("#inpCardNumberForInput").val(json.data.CardNumber);
                    $("#inpBankAddressForInput").val(json.data.BankAddress);
                }
            }

            function modelConvert(key, value) {
                var html = "";
                var left = "";
                switch (key) {
                    case "BankCode": left = "银行代码"; break;
                    case "OpeningBank": left = "开户行"; break;
                    case "CardHolder": left = "持卡人"; break;
                    case "CardNumber": left = "卡号"; break;
                    case "BankAddress": left = "银行地址"; break;
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

            //单条删除
            function singleDel(userBankId) {
                bootbox.setDefaults("locale", "zh_CN");
                bootbox.confirm("确认删除吗？", function (result) {
                    if (result) {
                        if (userBankId > 0) {
                            $.ajax({
                                type: "POST",
                                async: false,
                                dataType: "json",
                                url: "/ajax/helper.ashx?r=" + Math.random(),
                                data: { op: "bwjs", om: "gl", action: "userbankdel", userBankId: userBankId },
                                success: function (json) {
                                    if (json.result) {
                                        if (typeof (bankTable) != "undefined") {
                                            bankTable.fnDraw(false);
                                        }
                                    }
                                    myAlert(json.msg);
                                }
                            });
                        }
                    }
                });
            }

            //批量删除
            function multyDel() {
                if ($(".checkchild:checked").length == 0) {
                    myAlert("请先选择一条数据");
                    return false;
                }
                else {
                    bootbox.setDefaults("locale", "zh_CN");
                    bootbox.confirm("确认删除吗？", function (result) {
                        if (result) {
                            var ids = "";
                            $(".checkchild:checked").each(function () {
                                ids += $(this).val() + ",";
                            });

                            ids = ids.substring(0, ids.length - 1);
                            if (ids != "") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    dataType: "json",
                                    url: "/ajax/helper.ashx?r=" + Math.random(),
                                    data: { op: "bwjs", om: "gl", action: "userbankdel", userBankId: ids },
                                    success: function (json) {
                                        if (json.result) {
                                            if (typeof (bankTable) != "undefined") {
                                                bankTable.fnDraw(false);
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
