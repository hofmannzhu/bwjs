<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="EquipmentList.aspx.cs" Inherits="BWJS.WebApp.Admin.EquipmentList" %>

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

                <%if (this.CheckedAuthorize("91uwrm"))
                    { %>
                <a class="btn btn-info" onclick="return ShowAdd(0)"><span class="glyphicon glyphicon-plus"></span>添加设备</a>

                <%} %>
                <%if (this.CheckedAuthorize("2t4bua"))
                    { %>
                <a class="btn btn-info" id="btnMultyDel"><span class="glyphicon glyphicon-trash"></span>批量删除</a>
                <%} %>

                <select id="inpStatus" name="inpStatus" class="form-control">
                    <option value="">请选择状态</option>
                    <option value="0">冻结</option>
                    <option value="1">正常</option>
                </select>
                <select id="inpSearchKey" name="inpSearchKey" class="form-control">
                    <option value="">请选择条件</option>
                    <option value="1">设备号</option>
                    <option value="2">mac地址</option>
                    <option value="3">所在地</option>
                    <option value="4">经纬度</option>
                    <option value="5">TeamViewer号</option>
                    <option value="6">备注</option>
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
            <table id="machineList" class="display table table-bordered">
                <thead>
                    <tr>
                        <th>
                            <input type="checkbox" class="checkall" />
                        </th>
                        <th>设备号</th>
                        <th>厂商</th>
                        <th>所属商户</th>
                        <th>mac地址</th>
                        <th>平台类型</th>
                        <th>所在地</th>
                        <th>经纬度</th>
                        <th>状态</th>
                        <th>TeamViewer账号/密码</th>
                        <th style="width:150px;">操作</th>
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
                    <h4 class="modal-title" id="detailsModalLabel">设备详情</h4>
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

        var machineTable;

        $(document).ready(function () {

            GetMachineList();

            $("#btnMultyDel").click(function () {
                delMachineList();
            });

            $("#btnSearch").click(function () {
                GetMachineList()
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

        function GetMachineList() {
            if (typeof (machineTable) != "undefined") {
                machineTable.fnClearTable(false); //清空一下table
                machineTable.fnDestroy(); //还原初始化了的datatable
            }
            machineTable = $("#machineList").dataTable({
                bAutoWidth: true,
                aaSorting: [[0, "desc"]],
                bDestroy: true,
                bServerSide: true,
                sServerMethod: "POST",
                sAjaxSource: "/ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var status = $("#inpStatus").val();
                    var searchKey = $("#inpSearchKey").val();
                    var searchValue = $("#inpSearchValue").val();
                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "gl" },
                            { "name": "action", "value": "GetMachineList" },
                            { "name": "status", "value": status },
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
                        data: "MachineID",
                        render: function (data, type, full, meta) {
                            return '<input type="checkbox"  class="checkchild"  value="' + full.MachineID + '" />';
                        },
                        bSortable: false
                    },
                    { mData: "SN" },
                    { mData: "SupplierName" },
                    { mData: "UserFullName" },
                    { mData: "MAC" },
                    {
                        mData: "Platform",
                        mRender: function (data, type, full) {
                            var result = full.Platform;
                            if (result == "1") {
                                result = "平板";
                            } else if (result == "2") {
                                result = "机器";
                            }
                            else {
                                result = "暂无";
                            }
                            return result;
                        },
                    },
                    { mData: "Address" },
                    {
                        mData: "Longitude",
                        mRender: function (data, type, full) {
                            var result = full.Longitude + "," + full.Latitude;
                            return result;
                        },
                    },
                    {
                        mData: "Status",
                        mRender: function (data, type, full) {
                            var result = full.Status;
                            switch (full.Status) {
                                case 0:
                                    result = "冻结";
                                    break;
                                case 1:
                                    result = "正常";
                                    break;
                            }
                            return result;
                        },
                    },
                    {
                        mData: "TeamViewerNumber",
                        mRender: function (data, type, full) {
                            var result = full.TeamViewerNumber + "/" + full.TeamViewerPwd;
                            return result;
                        },
                    },
                    {
                        sClass: "center",
                        mData: "MachineID",
                        bSortable: false,
                        mRender: function (data, type, full) {
                            var option = "";
                                <%if (this.CheckedAuthorize("yduqij"))
        { %>
                            option = "<a data-toggle=\"modal\" data-target=\"#detailsModal\" data-action=\"orderCancle\" data-id=\"" + full.MachineID + "\" class=\"btn btn-mini\" title=\"查看详情\">查看</a>";
                            <%} %>
                              <%if (this.CheckedAuthorize("sb4iyg"))
        { %>
                            option += "<a class=\"btn btn-mini\" onclick=\"UsersMachine(" + full.MachineID + "," + full.UserID + ")\" title=\"绑定用户\">绑定用户</a>";
                            <%} %>
                            <%if (this.CheckedAuthorize("sb4iyg"))
        { %>
                            option += "<a class=\"btn btn-mini\" onclick=\"UpdateMachine(" + full.MachineID + "," + full.UserID + ")\" title=\"修改\">修改</a>";
                            <%} %>

                            <%if (this.CheckedAuthorize("2t4bua"))
        { %>
                            option += "<a class=\"btn btn-mini\" onclick=\"DeleteMachine(" + full.MachineID + ")\" title=\"删除\">删除</a>";
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
        //显示绑定页面
        function UsersMachineAdd(machineId, dbUserId) {
            var titledata;
            if (machineId == 0) {
                titledata = '设备绑定用户';
            } else {
                titledata = '设备绑定用户';
            } 
            $.layer({
                type: 2,
                title: [
                   titledata
                ],
                border: [0],
                area: ['1200px', '600px'],
                end: function () {
                    //location.reload();
                    if (typeof (machineTable) != "undefined") {
                        machineTable.fnDraw(false);
                    }
                },
                iframe: { src: '/Admin/BinDingUsersMachine.aspx?MachineID=' + machineId + "&dbUserId=" + dbUserId }
            })
            return false;
        }

        
            //显示添加页面
            function ShowAdd(machineId, dbUserId) {
                var titledata;
                if (machineId == 0) {
                    titledata = '添加设备信息';
                } else {
                    titledata = '修改设备信息';
                }


                $.layer({
                    type: 2,
                    title: [
                       titledata
                    ],
                    border: [0],
                    area: ['1200px', '600px'],
                    end: function () {
                        //location.reload();
                        if (typeof (machineTable) != "undefined") {
                            machineTable.fnDraw(false);
                        }
                    },
                    iframe: { src: '/Admin/EquipmentAdd.aspx?MachineID=' + machineId + "&dbUserId=" + dbUserId }
                })
                return false;
            }

            function DeleteMachine(machineId) {
                layer.confirm('确定删除吗？', function (index) {
                    if (machineId > 0) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            dataType: "json",
                            url: "/ajax/helper.ashx?r=" + Math.random(),
                            data: { op: "bwjs", om: "gl", action: "DeleteMachine", MachineID: machineId },
                            success: function (data) {
                                if (data.result) {
                                    layer.msg('删除成功！', 1, 1);
                                    if (typeof (machineTable) != "undefined") {
                                        machineTable.fnDraw(false);
                                    }
                                } else {
                                    layer.msg('删除失败！', 2, 1);
                                }
                            }
                        });
                    }
                });
            }

            function UpdateMachine(machineId, dbUserId) {
                ShowAdd(machineId, dbUserId);
            }
            function UsersMachine(machineId, dbUserId) {
                UsersMachineAdd(machineId, dbUserId);
            }
            
            function look(postId) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "gl";
                paramter.action = "GetMachineOne2";
                paramter.MachineID = postId;
                var json = getJson(paramter, false);
                if (json.result) {
                    selectedData = json.data;
                    var html = "";
                    $.each(json.data, function (key, value) {
                        var left = modelConvert(key);
                        if (left != "") {
                            if (left == "状态") {
                                if (value != "" && value == 1) {
                                    value = "正常";
                                } else {
                                    value = "冻结";
                                }
                            } else if (left == "建档日期" || left == "最后修改日期") {
                                if (value != "" && value != null) {
                                    //.replace(/\-/g, "/")
                                    //var dateee = new Date(value).toJSON();
                                    //var date = new Date(+new Date(dateee) + 8 * 3600 * 1000).toISOString().replace(/T/g, ' ').replace(/\.[\d]{3}Z/, '')
                                    var date = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                                    value = date;
                                }
                            }
                            html += "<div class=\"col-lg-4 text-right\">" + left + "</div>";
                            if (value != "") {
                                html += "<div class=\"col-lg-8\">" + value + "</div>";
                            } else {
                                html += "<div class=\"col-lg-8\">无</div>";
                            }

                        }
                        //html += "<p>" + modelConvert(key) + "：" + value + "</p>";
                    });
                    //myAlert(html);
                    $("#detailsDiv").html(html);
                } else {
                    myAlert(json.msg);
                }
            }

            function modelConvert(key) {
                var res = "";
                switch (key) {
                    case "SN": res = "设备号"; break;
                    case "MAC": res = "mac地址"; break;
                    case "Address": res = "设备所在地"; break;
                    case "SignName": res = "所属商户"; break;
                    //case "LoginName": res = "用户登录名"; break;
                    case "Status": res = "状态"; break;
                    case "TeamViewerNumber": res = "远程TeamViewer号"; break;
                    case "TeamViewerPwd": res = "远程TeamViewer密码"; break;
                    case "ActivationCode": res = "随机生成激活码"; break;
                    case "Remark": res = "备注"; break;
                    case "RecordCreateTime": res = "建档日期"; break;
                    case "RecordUpdateTime": res = "最后修改日期"; break;
                    case "Latitude": res = "纬度"; break;
                    case "Longitude": res = "经度"; break;
                    case "LocationAddress": res = "百度地址解析"; break;
                    case "FlatDeviceNumber": res = "平板设备号"; break;
                }
                return res;
            }
            //批量删除
            function delMachineList() {
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
                            //myAlert(ids);
                            if (ids != "") {
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    dataType: "json",
                                    url: "/ajax/helper.ashx?r=" + Math.random(),
                                    data: { op: "bwjs", om: "gl", action: "DeleteMachine", MachineID: ids },
                                    success: function (json) {
                                        if (json.result) {
                                            if (typeof (machineTable) != "undefined") {
                                                machineTable.fnDraw(false);
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
