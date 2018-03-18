<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="FunctionList.aspx.cs" Inherits="BWJS.WebApp.Admin.FunctionList" %>

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
            <button id="add-user1" class="btn btn-info add" onclick="return ShowAdd(0)">
                <span class="glyphicon glyphicon-plus"></span>添 加 功 能
            </button>
            <div class="search-box">
                <div class="input-group">
                    <input type="text" id="inpSearchValue" class="form-control" placeholder="功能名称、编码搜索" />
                    <span class="input-group-addon" id="btnSearch"><i class="glyphicon glyphicon-search"></i></span>
                </div>
            </div>
        </div>

        <div id="tableArea">

            <table class="display table table-bordered" id="table" scrollX:"true"  cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>功能ID</th>
                        <th>功能名称</th>
                        <th>功能代码</th>
                        <th>功能类别</th>
                        <th>父名称</th>
                        <th>最后修改人</th>
                        <th>修改日期</th>
                        <th>创建日期</th>
                        <th>备注</th>
                        <th>操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">
        var functionTable;

        $(document).ready(function () {
            GetFunctionTable();
            $("#btnSearch").click(function () {
                GetFunctionTable()
            });
        });


        function GetFunctionTable() {
            if (typeof (functionTable) != "undefined") {
                functionTable.fnClearTable(false); //清空一下table
                functionTable.fnDestroy(); //还原初始化了的datatable
            }


            functionTable = $("#table").dataTable({
                bAutoWidth: false,
                aaSorting: [[1, "desc"]],
                bDestroy: true,
                bFilter: false,
                "sDefaultContent": "",
                "bProcessing": true,
                "scrollX": true,
                sScrollXInner: "120%",
                bScrollCollapse: true,
                bServerSide: true,
                sServerMethod: "POST",
                sAjaxSource: "../Ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var searchValue = $("#inpSearchValue").val();
                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "func" },
                            { "name": "action", "value": "FunctionList" },
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
                    { mData: "FunctionId", sWidth: "100px" },
                    { mData: "FunctionName" },
                    { mData: "FunctionCode" },
                    {
                        mData: "ClassId",
                        mRender: function (data, type, full) {
                            var result = full.ClassId;
                            switch (full.ClassId) {
                                case 0:
                                    result = "导航";
                                    break;
                                case 1:
                                    result = "操作";
                                    break;
                            }
                            return result;
                        },
                    },
                    { mData: "ParentName" },
                    //{
                    //    mData: "Status",
                    //    mRender: function (data, type, full) {
                    //        var str = "";
                    //        if (full.Status == "0") {
                    //            str = "无效";
                    //        } else if (full.Status == "1") {
                    //            str = "有效";
                    //        } else {
                    //            str = "无";
                    //        }
                    //        return str;
                    //    }
                    //},
                    { mData: "lastName" },
                    {
                        mData: "EditDate",
                        mRender: function (data, type, full) {
                            var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.EditDate));
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
                          { mData: "Remark" },
                            {
                                sTitle: '操作', 'mData': 'FunctionId', sWidth: "150px", mRender: function (data, type, full) {
                                    return "<input class=\"btn btn-mini\" onclick=\"ShowAdd(" + full.FunctionId + ")\" type=\"button\" value=\"修改\">&nbsp&nbsp<input class=\"btn btn-mini\" onclick=\"FunctionDelete(" + full.FunctionId + ")\" type=\"button\" value=\"删除\">";
                                }
                            }
                ],
            });
        };


        function FunctionDelete(RoleId) {
            if (VerifySon(RoleId)) {
                layer.confirm('不能删除！存在子级功能，请优先删除子级功能！');
            } else {
                if (VerifyRelation(RoleId)) {
                    layer.confirm('此功能关联角色，若删除功能将影响用户无操作权限！', function (index) {
                        DeleteRole(RoleId)
                    });
                } else {
                    layer.confirm('确定删除此功能吗？', function (index) { DeleteRole(RoleId) });
                }
            }
        };

        function VerifyRelation(FunctionID) {
            var b = false;
            $.ajax({
                type: "GET",
                async: false,
                dataType: "text",
                url: "../Ajax/Admin/HFunction.ashx?r=" + Math.random(),
                data: { Action: "VerifyRelationRole", FunctionID: FunctionID },
                success: function (data) {
                    if (data > 0) {
                        b = true;
                    }
                }
            });
            return b;
        };
        function VerifySon(FunctionID) {
            var b = false;
            $.ajax({
                type: "GET",
                async: false,
                dataType: "text",
                url: "../Ajax/Admin/HFunction.ashx?r=" + Math.random(),
                data: { Action: "VerifySonRole", FunctionID: FunctionID },
                success: function (data) {
                    if (data > 0) {
                        b = true;
                    }
                }
            });
            return b;
        };

        function DeleteRole(FunctionID) {
            if (FunctionID > 0) {
                $.ajax({
                    type: "GET",
                    async: false,
                    dataType: "text",
                    url: "../Ajax/Admin/HFunction.ashx?r=" + Math.random(),
                    data: { Action: "DeleteFunction", FunctionID: FunctionID },
                    success: function (data) {
                        if (data > 0) {
                            layer.msg('删除成功！', 1, 1);
                            if (typeof (functionTable) != "undefined") {
                                functionTable.fnDraw(false);
                            }
                        } else {
                            layer.msg('删除失败！', 2, 1);
                        }
                    }
                });
            }
        };


        //显示添加页面
        function ShowAdd(FunctionId) {
            var titledata;
            if (FunctionId == 0) {
                titledata = '添加功能';
            } else {
                titledata = '修改功能';
            }

            $.layer({
                type: 2,
                title: [
                   titledata
                ],
                border: [0],
                area: ['900px', '600px'],
                end: function () {
                    //location.reload();
                    if (typeof (functionTable) != "undefined") {
                        functionTable.fnDraw(false);
                    }
                },
                iframe: { src: 'FunctionAdd.aspx?FunctionId=' + FunctionId }
            });
            return false;
        }

    </script>
</asp:Content>
