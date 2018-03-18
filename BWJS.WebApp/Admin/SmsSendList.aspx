<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="SmsSendList.aspx.cs" Inherits="BWJS.WebApp.Admin.SmsSendList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container-fluid user-list mat1">
        <div class="add-box">
            <div class="form-inline">
                <select id="inpStatus" name="inpStatus" class="form-control">
                    <option value="">请选择发送状态</option>
                    <option value="0">未发送</option>
                    <option value="1">已发送</option>
                </select>
                <select id="inpSendType" name="inpSendType" class="form-control">
                    <option value="">请选择发送类型</option>
                    <option value="1">实时发送</option>
                    <option value="2">延迟发送</option>
                </select>
                <select id="inpSearchKey" name="inpSearchKey" class="form-control">
                    <option value="">请选择查询条件</option>
                    <option value="1">接收手机号码</option>
                    <option value="2">短信内容</option>
                    <option value="3">建档日期</option>
                    <option value="4">发送日期</option>
                    <option value="5">发送结果</option>
                </select>
            </div>
            <div class="search-box">
                <div class="input-group">
                    <input id="inpSearchValue" name="inpSearchValue" type="text" class="form-control" placeholder="请输入要检索的内容" />
                    <a href="javascript:void(0)" id="btnSearch" class="input-group-addon"><i class="glyphicon glyphicon-search"></i></a>
                </div>
            </div>
        </div>
        <div id="tableArea">
            <table id="smsSendList" class="display table table-bordered">
                <thead>
                    <tr>
                        <th>编号</th>
                        <th>发送类型</th>
                        <th>接收手机号码</th>
                        <th>短信内容</th>
                        <th>发送状态</th>
                        <th>建档日期</th>
                        <th>发送日期</th>
                        <th>发送结果</th>
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

        var smsSendTable;

        $(document).ready(function () {

            GetSmsSendList();

            $("#btnSearch").click(function () {
                GetSmsSendList()
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

        function GetSmsSendList() {
            try {
                if (typeof (smsSendTable) != "undefined") {
                    smsSendTable.fnClearTable(false); //清空一下table
                    smsSendTable.fnDestroy(); //还原初始化了的datatable
                }
                smsSendTable = $("#smsSendList").dataTable({
                    bAutoWidth: true,
                    aaSorting: [[0, "desc"]],
                    bDestroy: true,
                    bServerSide: true,
                    sServerMethod: "POST",
                    sAjaxSource: "/ajax/helper.ashx",
                    fnServerData: function (sUrl, aoData, fnCallback) {
                        var status = $("#inpStatus").val();
                        var sendType = $("#inpSendType").val();
                        var searchKey = $("#inpSearchKey").val();
                        var searchValue = $("#inpSearchValue").val();
                        aoData.push(
                                { "name": "op", "value": "bwjs" },
                                { "name": "om", "value": "gl" },
                                { "name": "action", "value": "getsmssendlist" },
                                { "name": "status", "value": status },
                                { "name": "sendType", "value": sendType },
                                { "name": "searchKey", "value": searchKey },
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
                                //alert(JSON.stringify(json));
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
                        { mData: "SmsLogId" },
                        {
                            mData: "SendType",
                            mRender: function (data, type, full) {
                                var result = full.SendType;
                                switch (full.SendType) {
                                    case 1:
                                        result = "实时发送";
                                        break;
                                    case 2:
                                        result = "延迟发送";
                                        break;
                                    default:
                                        result = "其他";
                                        break;
                                }
                                return result;
                            },
                        },
                        { mData: "Mobile" },
                        { mData: "SmsContent" },
                        {
                            mData: "Status",
                            mRender: function (data, type, full) {
                                var result = full.Status;
                                switch (full.Status) {
                                    case 0:
                                        result = "未发送";
                                        break;
                                    case 1:
                                        result = "已发送";
                                        break;
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
                        {
                            mData: "SendDate",
                            mRender: function (data, type, full) {
                                var result = "";
                                if (full.SendDate != null && full.SendDate != "") {
                                    result = $.formatDateTime("yy-mm-dd", new Date(full.SendDate));
                                }
                                return result;
                            },
                        },
                        { mData: "SendResult" },
                        {
                            sClass: "center",
                            mData: "SmsLogId",
                            bSortable: false,
                            mRender: function (data, type, full) {
                                var option = "<a data-toggle=\"modal\" data-target=\"#detailsModal\" data-action=\"orderCancle\" data-id=\"" + full.SmsLogId + "\" class=\"btn btn-mini\" title=\"查看详情\">查看</a>";
                                return option;
                            }
                        },
                    ],
                });
            }
            catch (e) {
                myAlert(e.message);
            }
        }

        function look(postId) {
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "gl";
            paramter.action = "getsmssendmodel";
            paramter.SmsLogId = postId;
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
                case "SmsLogId": left = "短信日志编号"; break;
                case "SendType":
                    left = "发送类型";
                    switch (value) {
                        case 1:
                            value = "实时发送";
                            break;
                        case 2:
                            value = "延迟发送";
                            break;
                    }
                    break;
                case "Status":
                    left = "发送状态";
                    switch (value) {
                        case 0:
                            value = "未发送";
                            break;
                        case 1:
                            value = "已发送";
                            break;
                    }
                    break;
                case "Mobile": left = "接收手机号码"; break;
                case "SmsContent": left = "短信内容"; break;
                case "CreateDate":
                    left = "建档日期";
                    value = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    break;
                case "SendDate": {
                    left = "发送日期";
                    if (value != null && value != "") {
                        value = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    }
                }
                    break;
                case "SendResult": left = "发送结果"; break;
            }
            if (left != "" && value != "") {
                html += "<div class=\"col-lg-4 text-right\">" + left + "</div>";
                html += "<div class=\"col-lg-8\">" + value + "</div>";
            }
            return html;
        }
    </script>
</asp:Content>
