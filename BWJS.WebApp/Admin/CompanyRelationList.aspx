<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/m1.Master" CodeBehind="CompanyRelationList.aspx.cs" Inherits="BWJS.WebApp.Admin.CompanyRelationList" %>

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

        #detailsDiv {
            word-wrap: break-word;
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
            <div class="form-inline">

                <%if (this.CheckedAuthorize("91uwrm"))
                    { %>
                <a class="btn btn-info" onclick="return ShowAdd(0)"><span class="glyphicon glyphicon-plus"></span>添加渠道关系</a>

                <%} %>
                <%if (this.CheckedAuthorize("2t4bua"))
                    { %>
                <a class="btn btn-info" id="btnMultyDel"><span class="glyphicon glyphicon-trash"></span>批量删除</a>
                <%} %>

                <select id="inpSearchKey" name="inpSearchKey" class="form-control">
                    <option value="">请选择条件</option>
                    <option value="1">渠道</option>
                    <option value="2">商家</option>
                    <option value="3">商家部门</option>
                    <option value="4">产品</option>
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
            <table id="companyRelationList" class="display table table-bordered" scrollX:"true" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>
                            <input type="checkbox" class="checkall" />
                        </th>
                        <th>渠道</th>
                        <th>产品</th>
                        <th>商家</th>
                        <th>商家部门</th>
                        <th>推荐码</th>
                        <th>二维码地址</th>
                        <th>备注</th>
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
                    <h4 class="modal-title" id="detailsModalLabel">渠道关系详情</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid" >
                        <div class="row" id="detailsDiv" >
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

        var companyRelationTable;

        $(document).ready(function () {

            GetCompanyRelationList();

            $("#btnMultyDel").click(function () {
                delCompanyRelationList();
            });

            $("#btnSearch").click(function () {
                GetCompanyRelationList();
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

        function GetCompanyRelationList() {
            if (typeof (companyRelationTable) != "undefined") {
                companyRelationTable.fnClearTable(false); //清空一下table
                companyRelationTable.fnDestroy(); //还原初始化了的datatable
            }
            companyRelationTable = $("#companyRelationList").dataTable({
                bAutoWidth: true,
                aaSorting: [[0, "desc"]],
                bDestroy: true,
                bFilter: false,
                "sDefaultContent": "",
                "bProcessing": true,
                "scrollX": true,
                sScrollXInner: "130%",
                bScrollCollapse: true,
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
                            { "name": "action", "value": "companyRelationList" },
                            { "name": "searchKey", "value": searchKey },
                            { "name": "searchValue", "value": encodeURI(searchValue) }
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
                        data: "CompanyRelationId",
                        render: function (data, type, full, meta) {
                            return '<input type="checkbox"  class="checkchild"  value="' + full.CompanyRelationId + '" />';
                        },
                        bSortable: false
                    },
                    { mData: "CompanyName" },
                    { mData: "MainBusiness" },
                    { mData: "UserName" },
                    { mData: "DepartmentName" },
                    { mData: "RecommendationCode" },
                    { mData: "QRCode", sWidth: "200px" },
                    { mData: "Remark", sWidth: "300px" },
                    {
                        sClass: "center",
                        mData: "CompanyRelationId",
                        sWidth: "50px",
                        bSortable: false,
                        mRender: function (data, type, full) {
                            var option = "";
                                <%if (this.CheckedAuthorize("yduqij"))
        { %>
                            option = "<a data-toggle=\"modal\" data-target=\"#detailsModal\" data-action=\"orderCancle\" data-id=\"" + full.CompanyRelationId + "\" class=\"btn btn-mini\" title=\"查看详情\">查看</a>";
                            <%} %>

                            <%if (this.CheckedAuthorize("sb4iyg"))
        { %>
                            option += "<a class=\"btn btn-mini\" onclick=\"UpdateCompanyRelation(" + full.CompanyRelationId + ")\" title=\"修改\">修改</a>";
                            <%} %>

                            <%if (this.CheckedAuthorize("2t4bua"))
        { %>
                            option += "<a class=\"btn btn-mini\" onclick=\"DeleteCompanyRelation(" + full.CompanyRelationId + ")\" title=\"删除\">删除</a>";
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

            //显示添加页面
            function ShowAdd(CompanyRelationId) {
                var titledata;
                if (CompanyRelationId == 0) {
                    titledata = '添加渠道关系信息';
                } else {
                    titledata = '修改渠道关系信息';
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
                        if (typeof (companyRelationTable) != "undefined") {
                            companyRelationTable.fnDraw(false);
                        }
                    },
                    iframe: { src: '/Admin/CompanyRelationAdd.aspx?CompanyRelationId=' + CompanyRelationId }
                })
                return false;
            }

            function DeleteCompanyRelation(CompanyRelationId) {
                layer.confirm('确定删除吗？', function (index) {
                    if (CompanyRelationId > 0) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            dataType: "json",
                            url: "/ajax/helper.ashx?r=" + Math.random(),
                            data: { op: "bwjs", om: "gl", action: "DeleteCompanyRelation", CompanyRelationId: CompanyRelationId },
                            success: function (data) {
                                if (data.result) {
                                    layer.msg('删除成功！', 1, 1);
                                    if (typeof (companyRelationTable) != "undefined") {
                                        companyRelationTable.fnDraw(false);
                                    }
                                } else {
                                    layer.msg('删除失败！', 2, 1);
                                }
                            }
                        });
                    }
                });
            }

            function UpdateCompanyRelation(CompanyRelationId) {
                ShowAdd(CompanyRelationId);
            }

            function look(postId) {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "gl";
                paramter.action = "GetCompanyRelationOne";
                paramter.CompanyRelationId = postId;
                var json = getJson(paramter, false);
                if (json.result) {
                    selectedData = json.data;
                    var html = "";
                    $.each(json.data, function (key, value) {
                        var left = modelConvert(key);
                        if (left != "") {
                            if (left == "建档日期" || left == "最后修改日期") {
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
                    case "CompanyName": res = "渠道"; break;
                    case "MainBusiness": res = "产品"; break;
                    case "UserName": res = "商家"; break;
                    case "DepartmentName": res = "商家部门"; break;
                    case "RecommendationCode": res = "推荐码"; break;
                    case "QRCode": res = "二维码地址"; break;
                    case "Remark": res = "备注"; break;
                    case "API": res = "业务对接地址"; break;
                    case "CreateDate": res = "建档日期"; break;
                    case "EditDate": res = "最后修改日期"; break;
                }
                return res;
            }
            //批量删除
            function delCompanyRelationList() {
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
                                    data: { op: "bwjs", om: "gl", action: "DeleteCompanyRelation", CompanyRelationId: ids },
                                    success: function (json) {
                                        if (json.result) {
                                            if (typeof (companyRelationTable) != "undefined") {
                                                companyRelationTable.fnDraw(false);
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

