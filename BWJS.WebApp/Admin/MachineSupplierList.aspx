<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/m1.Master" CodeBehind="MachineSupplierList.aspx.cs" Inherits="BWJS.WebApp.Admin.MachineSupplierList" %>

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
                <a class="btn btn-info" onclick="return ShowAdd(0)"><span class="glyphicon glyphicon-plus"></span>添加供应商</a>

                <%} %>
                <%if (this.CheckedAuthorize("2t4bua"))
                    { %>
                <a class="btn btn-info" id="btnMultyDel"><span class="glyphicon glyphicon-trash"></span>批量删除</a>
                <%} %>

                <select id="inpStatus" name="inpStatus" class="form-control">
                    <option value="">请选择状态</option>
                    <option value="0">正常</option>
                    <option value="1">锁定</option>
                </select>
                <select id="inpSearchKey" name="inpSearchKey" class="form-control">
                    <option value="">请选择条件</option>
                    <option value="1">供应商名称</option>
                    <option value="2">负责人</option>
                    <option value="3">手机</option>
                    <option value="4">地址</option>
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
            <table id="supplierList" class="display table table-bordered">
                <thead>
                    <tr>
                        <th>
                            <input type="checkbox" class="checkall" />
                        </th>
                        <th>供应商名称</th>
                        <th>负责人</th>
                        <th>电话</th>
                        <th>手机</th>
                        <th>地址</th>
                        <th>QQ</th>
                        <th>微信号</th>
                        <th>公众号</th>
                        <th>状态</th>
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
                    <h4 class="modal-title" id="detailsModalLabel">供应商详情</h4>
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

        var supplierTable;

        $(document).ready(function () {

            GetSupplierList();

            $("#btnMultyDel").click(function () {
                delSupplierList();
            });

            $("#btnSearch").click(function () {
                GetSupplierList()
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

        function GetSupplierList() {
            if (typeof (supplierTable) != "undefined") {
                supplierTable.fnClearTable(false); //清空一下table
                supplierTable.fnDestroy(); //还原初始化了的datatable
            }
            supplierTable = $("#supplierList").dataTable({
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
                            { "name": "action", "value": "supplierList" },
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
                        data: "MachineSupplierId",
                        render: function (data, type, full, meta) {
                            return '<input type="checkbox"  class="checkchild"  value="' + full.MachineSupplierId + '" />';
                        },
                        bSortable: false
                    },
                    { mData: "SupplierName" },
                    { mData: "Manager" },
                    { mData: "Phone" },
                    { mData: "Mobile" },
                    { mData: "Address" },
                    { mData: "QQ" },
                    { mData: "Wechat" },
                    { mData: "PublicWechat" },
                    {
                        mData: "Status",
                        mRender: function (data, type, full) {
                            var result = full.Status;
                            switch (full.Status) {
                                case 0:
                                    result = "正常";
                                    break;
                                case 1:
                                    result = "锁定";
                                    break;
                            }
                            return result;
                        },
                    },
                    {
                        sClass: "center",
                        mData: "MachineSupplierId",
                        bSortable: false,
                        mRender: function (data, type, full) {
                            var option = "";
                                <%if (this.CheckedAuthorize("yduqij"))
        { %>
                            option = "<a data-toggle=\"modal\" data-target=\"#detailsModal\" data-action=\"orderCancle\" data-id=\"" + full.MachineSupplierId + "\" class=\"btn btn-mini\" title=\"查看详情\">查看</a>";
                            <%} %>

                            <%if (this.CheckedAuthorize("sb4iyg"))
        { %>
                            option += "<a class=\"btn btn-mini\" onclick=\"UpdateMachineSupplier(" + full.MachineSupplierId + ")\" title=\"修改\">修改</a>";
                            <%} %>

                            <%if (this.CheckedAuthorize("2t4bua"))
        { %>
                            option += "<a class=\"btn btn-mini\" onclick=\"DeleteMachineSupplier(" + full.MachineSupplierId + ")\" title=\"删除\">删除</a>";
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

            //显示添加页面
            function ShowAdd(MachineSupplierId) {
                var titledata;
                if (MachineSupplierId == 0) {
                    titledata = '添加供应商信息';
                } else {
                    titledata = '修改供应商信息';
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
                        if (typeof (supplierTable) != "undefined") {
                            supplierTable.fnDraw(false);
                        }
                    },
                    iframe: { src: '/Admin/MachineSupplierAdd.aspx?MachineSupplierId=' + MachineSupplierId }
                })
                return false;
            }

            function DeleteMachineSupplier(MachineSupplierId) {
                layer.confirm('确定删除吗？', function (index) {
                    if (MachineSupplierId > 0) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            dataType: "json",
                            url: "/ajax/helper.ashx?r=" + Math.random(),
                            data: { op: "bwjs", om: "gl", action: "DeleteMachineSupplier", MachineSupplierId: MachineSupplierId },
                            success: function (data) {
                                if (data.result) {
                                    layer.msg('删除成功！', 1, 1);
                                    if (typeof (supplierTable) != "undefined") {
                                        supplierTable.fnDraw(false);
                                    }
                                } else {
                                    layer.msg('删除失败！', 2, 1);
                                }
                            }
                        });
                    }
                });
            }

            function UpdateMachineSupplier(MachineSupplierId) {
                ShowAdd(MachineSupplierId);
            }

            function look(postId) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "gl";
                paramter.action = "GetMachineSupplier";
                paramter.MachineSupplierId = postId;
                var json = getJson(paramter, false);
                if (json.result) {
                    selectedData = json.data;
                    var html = "";
                    $.each(json.data, function (key, value) {
                        var left = modelConvert(key);
                        if (left != "") {
                            if (left == "状态") {
                                if (value == 0) {
                                    value = "正常";
                                } else {
                                    value = "冻结";
                                }
                            } else if (left == "建档日期" || left == "最后修改日期") {
                                if (value != "" && value != null) {
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
                    });
                    $("#detailsDiv").html(html);
                } else {
                    myAlert(json.msg);
                }
            }

            function modelConvert(key) {
                var res = "";
                switch (key) {
                    case "SupplierName": res = "供应商名称"; break;
                    case "Manager": res = "负责人"; break;
                    case "Phone": res = "电话"; break;
                    case "Mobile": res = "手机号"; break;
                    case "Address": res = "地址"; break;
                    case "QQ": res = "QQ号"; break;
                    case "SiteUrl": res = "主页"; break;
                    case "Logo": res = "Logo"; break;
                    case "API": res = "业务对接地址"; break;
                    case "QRCode": res = "二维码地址"; break;
                    case "MainBrand": res = "主要品牌"; break;
                    case "MainBusiness": res = "主营业务"; break;
                    case "Wechat": res = "微信号"; break;
                    case "PublicWechat": res = "公众号"; break;
                    case "Remark": res = "备注"; break;
                    case "Status": res = "状态"; break;
                    case "CreateDate": res = "建档日期"; break;
                    case "EditDate": res = "最后修改日期"; break;
                }
                return res;
            }
            //批量删除
            function delSupplierList() {
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
                                    data: { op: "bwjs", om: "gl", action: "DeleteMachineSupplier", MachineSupplierId: ids },
                                    success: function (json) {
                                        if (json.result) {
                                            if (typeof (supplierTable) != "undefined") {
                                                supplierTable.fnDraw(false);
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
