﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserBankListForUserManager.aspx.cs" Inherits="BWJS.WebApp.Admin.UserBankListForUserManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Content/css/Admin/main.css" rel="stylesheet" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Content/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/uril.js" type="text/javascript"></script>
    <script src="/Scripts/layer.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/messages_zh.min.js"></script>
    <script src="/Scripts/WdatePicker/WdatePicker.js"></script>
    <script src="/Scripts/WdatePicker/config.js"></script>
</head>


<body>
    <form id="form1" runat="server">
        <div class="container-fluid user-list mat1">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                        <div class="form-inline">
                            <label for="inpBankCodeForQuery">银行代码</label>
                            <input id="inpBankCodeForQuery" name="inpBankCodeForQuery" type="text" class="form-control" placeholder="请输入银行代码" maxlength="16" />
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                        <div class="form-inline">
                            <label for="inpOpeningBankForQuery"><i class="jg3">开</i><i class="jg3">户</i>行</label>
                            <input id="inpOpeningBankForQuery" name="inpOpeningBankForQuery" type="text" class="form-control" placeholder="请输入开户行" />
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                        <div class="form-inline">
                            <label for="inpCardHolderForQuery"><i class="jg3">持</i><i class="jg3">卡</i>人</label>
                            <input id="inpCardHolderForQuery" name="inpCardHolderForQuery" type="text" class="form-control" placeholder="请输入持卡人" />
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                        <div class="form-inline">
                            <label for="inpCardNumberForQuery"><i class="jg">卡</i>号</label>
                            <input id="inpCardNumberForQuery" name="inpCardNumberForQuery" type="text" class="form-control" placeholder="请输入卡号" />
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                        <div class="form-inline">
                            <label for="inpBankAddressForQuery">银行地址</label>
                            <input id="inpBankAddressForQuery" name="inpBankAddressForQuery" type="text" class="form-control" placeholder="请输入银行地址" />
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
                        <%if (CheckedAuthorize("iy5ipg"))
                            { %>
                        <a class="btn btn-info" data-toggle="modal" data-target="#userBankModal" href="/Admin/UserBankAdd.aspx" title="新增银行卡"><span class="glyphicon glyphicon-plus"></span>新增银行卡</a>

                        <%} %>
                        <%if (CheckedAuthorize("5qx96z"))
                            { %>
                        <a class="btn btn-info" id="btnMultyDel"><span class="glyphicon glyphicon-trash"></span>批量删除</a>
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
        <input id="hiddUserId" name="hiddUserId" type="hidden" />
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
        <script src="/Scripts/jquery.dataTables.bootstrap.js"></script>
        <script src="/Scripts/bootbox.js" type="text/javascript"></script>
        <script src="/Scripts/jquery.formatDateTime/jquery.formatDateTime.js"></script>
        <script src="/Scripts/jquery.query-2.1.7.js" type="text/javascript"></script>
        <script src="/Scripts/Admin/m1.js" type="text/javascript"></script>
        <script type="text/javascript">

            var bankTable;

            $(document).ready(function () {
                $("#userBankModal")
                    .on('show.bs.modal', function (e) {
                    })
                    .on('shown.bs.modal', function (e) {
                        $("#hiddUserId").val($.query.get("UserId"));
                        var op = $(e.relatedTarget);
                        var id = op.data("id");
                        if (id != undefined) {
                            $("#hiddId").val(id);
                            getBankModelFromServer(id);
                        }
                        else {
                            $("#hiddId").val("");
                            $("hiddUserId").val("");
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
                        $("#hiddUserId").val("");
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
                var userId = $.query.get("UserId");
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
                                { "name": "userId", "value": userId },
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
                                    if (full.IsDefault != 1) {
                                        <%if (this.CheckedAuthorize("k24i4i"))
            { %>
                                        option = "<a class=\"btn btn-mini\" style=\"color:red;\" href=\"javascript:void(0)\" title=\"设为默认收款账户\" onclick=\"setIsDefault(" + full.UserId + "," + full.UserBankId + ")\">设为默认</a>";
                                        <%} %>
                                    }
                                    else {
                                        option = "<a class=\"btn btn-mini\" style=\"color:green;\" href=\"javascript:void(0)\" title=\"已默认\">已默认</a>";
                                    }
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
                                var paramter = {};
                                paramter.op = "bwjs";
                                paramter.om = "gl";
                                paramter.action = "userbankdel";
                                paramter.userBankId = userBankId;
                                var json = getJson(paramter, false);
                                if (json.result) {
                                    if (typeof (bankTable) != "undefined") {
                                        bankTable.fnDraw(false);
                                    }
                                }
                                myAlert(json.msg);
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
                                    var paramter = {};
                                    paramter.op = "bwjs";
                                    paramter.om = "gl";
                                    paramter.action = "userbankdel";
                                    paramter.userBankId = ids;
                                    var json = getJson(paramter, false);
                                    if (json.result) {
                                        if (typeof (bankTable) != "undefined") {
                                            bankTable.fnDraw(false);
                                        }
                                    }
                                    myAlert(json.msg);
                                }
                            }
                        });
                    }
                }

                function setIsDefault(userId, userBankId) {
                    var paramter = {};
                    paramter.op = "bwjs";
                    paramter.om = "gl";
                    paramter.action = "setdefault";
                    paramter.userId = userId;
                    paramter.userBankId = userBankId;
                    var json = getJson(paramter, false);
                    if (json.result) {
                        if (typeof (bankTable) != "undefined") {
                            bankTable.fnDraw(false);
                        }
                    }
                    //myAlert(json.msg);
                }

        </script>
    </form>
</body>
</html>
