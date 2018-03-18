<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="DepartmentInfoList.aspx.cs" Inherits="BWJS.WebApp.Admin.DepartmentInfoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">

    <!--important start -->

    <div class="container-fluid user-list mat1">
        <div class="add-box">
            <div class="add-box">
                <%if (this.CheckedAuthorize("a3gftl"))
                    { %>
                <button id="add-user1" class="btn btn-info add" onclick="return ShowAdd(0)">
                    <span class="glyphicon glyphicon-plus"></span>添 加 部 门
                </button>
                <%} %>
            </div>

            <div class="search-box">
                <div class="input-group">
                    <input type="text" id="inpSearchValue" name="inpSearchValue" class="form-control" placeholder="支持部门名称搜索" />
                    <span class="input-group-addon" id="btnSearch"><i class="glyphicon glyphicon-search"></i></span>
                </div>
            </div>
        </div>

        <div id="tableArea">
            <table class="table table-striped " id="table_content">
                <thead>
                    <tr>
                        <th>部门ID</th>
                        <th>部门名称</th>
                        <th>部门父级名称</th>
                         <th>是否业务部门</th>
                        <th>部门编码</th>
                        <th>备注</th>
                        <th>操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <!--important End  -->


</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">
        var dataTable;
        var DepartmentTable;
        $(document).ready(function () {
            GetDepartmentList();
            $("#btnSearch").click(function () {
                GetDepartmentList()
            });
        });//  

        function GetDepartmentList() {
            if (typeof (DepartmentTable) != "undefined") {
                DepartmentTable.fnClearTable(false); //清空一下table
                DepartmentTable.fnDestroy(); //还原初始化了的datatable
            }
            DepartmentTable = $("#table_content").dataTable({
                bAutoWidth: true,
                aaSorting: [[1, "desc"]],
                bDestroy: true,
                bServerSide: true,
                sServerMethod: "POST",
                sAjaxSource: "/ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var searchValue = $("#inpSearchValue").val();
                    var payStatus = $("#inpPayStatus").val();
                    var isSettled = $("#inpIsSettled").val();
                    var isCancel = $("#inpIsCancel").val();
                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "func" },
                            { "name": "action", "value": "DepartmentList" },
                            { "name": "payStatus", "value": payStatus },
                            { "name": "isSettled", "value": isSettled },
                            { "name": "isCancel", "value": isCancel },
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
                    { mData: "DepartmentID" },
                    { mData: "DepartmentName" },
                    { mData: "ParentDepartmentInfoName" },
                    {
                        mData: "IsReceiveBusiness", mRender: function (data, type, full) {
                            var b = "";
                            if (full.IsReceiveBusiness == true) {
                                b = "是";
                            } else {
                                b = "否";
                            }
                            return b;
                        }
                    },
                    { mData: "DepartmentCode" },
                    { mData: "Remark" },
                            {

                                mData: 'DepartmentID', mRender: function (data, type, full) {
                                    var str = "";
                      <%if (this.CheckedAuthorize("g3fax4"))
        { %>
                                    str += "<input class=\"btn btn-mini\" onclick=\"ShowAdd(" + full.DepartmentID + ")\" type=\"button\" value=\"修改\"> &nbsp&nbsp";
                                    <%} %>
                               <%if (this.CheckedAuthorize("	w3g7za"))
        { %>
                                    str += "<input class=\"btn btn-mini\" onclick=\"DepartmentDelete(" + full.DepartmentID + ")\" type=\"button\" value=\"删除\">";

                              <%} %>
                                    return str;
                                }
                            }
                ],
            });
                    }


                    function ShowDepartmentFunction(DepartmentId) {
                        if (DepartmentId > 0) {
                            $.layer({
                                type: 2,
                                title: [
                                   "功能授权"
                                ],
                                border: [0],
                                area: ['800px', '580px'],
                                end: function () {
                                    if (typeof (DepartmentTable) != "undefined") {
                                        DepartmentTable.fnDraw(false);
                                    }
                                },
                                iframe: { src: 'RDepartmentFunction.aspx?DepartmentID=' + DepartmentId }
                            });
                        } else {
                            layer.msg('授权失败！', 2, 1);
                        }
                        return false;
                    }




                    function VerifySon(DepartmentID) {
                        var b = false;
                        $.ajax({
                            type: "GET",
                            async: false,
                            dataType: "text",
                            url: "../Ajax/Admin/HDepartment.ashx?r=" + Math.random(),
                            data: { Action: "VerifySonDepartment", DepartmentID: DepartmentID },
                            success: function (data) {
                                if (data > 0) {
                                    b = true;
                                }
                            }
                        });
                        return b;
                    };
                    function VerifyRelation(DepartmentID) {
                        var b = false;
                        $.ajax({
                            type: "GET",
                            async: false,
                            dataType: "text",
                            url: "../Ajax/Admin/HDepartment.ashx?r=" + Math.random(),
                            data: { Action: "VerifyRelationDepartment", DepartmentID: DepartmentID },
                            success: function (data) {
                                if (data > 0) {
                                    b = true;
                                }
                            }
                        });
                        return b;
                    };
                    function DeleteDepartment(DepartmentID) {
                        if (DepartmentID > 0) {
                            $.ajax({
                                type: "GET",
                                async: false,
                                dataType: "text",
                                url: "../Ajax/Admin/HDepartment.ashx?r=" + Math.random(),
                                data: { Action: "DeleteDepartment", DepartmentID: DepartmentID },
                                success: function (data) {
                                    if (data > 0) {
                                        layer.msg('删除成功！', 1, 1);
                                        if (typeof (DepartmentTable) != "undefined") {
                                            DepartmentTable.fnDraw(false);
                                        }
                                    } else {
                                        layer.msg('删除失败！', 2, 1);
                                    }
                                }
                            });
                        };
                    };

                    function DepartmentDelete(DepartmentID) {
                        if (VerifySon(DepartmentID)) {
                            layer.confirm('不能删除！存在下属部门，请优先删除下属部门。');
                        } else {
                            if (VerifyRelation(DepartmentID)) {
                                layer.confirm('此部门已关联用户，若删除部门将影响用户无操作权限。确定删除吗？', function (index) {
                                    DeleteDepartment(DepartmentID)
                                });
                            } else {
                                layer.confirm('确定删除此部门吗？', function (index) { DeleteDepartment(DepartmentID) });
                            }
                        }
                    };


    <%--    <%} %>
         <%if (this.AdminUser.IsMaster || this.AdminUser.CheckedAuthorize("ochfia"))
           { %>--%>
        function ShowAdd(DepartmentID) {
            var titledata;
            if (DepartmentID == 0) {
                titledata = '添加部门';
            } else {
                titledata = '修改部门';
            }
            $.layer({
                type: 2,
                title: [
                   titledata
                ],
                border: [0],
                area: ['880px', '540px'],
                end: function () {
                    if (typeof (DepartmentTable) != "undefined") {
                        DepartmentTable.fnDraw(false);
                    }
               
                },
                iframe: { src: 'DepartmentInfoAdd.aspx?DepartmentID=' + DepartmentID }
            });
            return false;
        }
    </script>
</asp:Content>
