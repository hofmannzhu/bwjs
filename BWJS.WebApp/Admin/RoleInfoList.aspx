<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="RoleInfoList.aspx.cs" Inherits="BWJS.WebApp.Admin.RoleInfoList" %>

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

            <button id="add-user1" class="btn btn-info add" onclick="return ShowAdd(0)">
                <span class="glyphicon glyphicon-plus"></span>添 加 角 色
            </button>
            <div class="search-box">
                <div class="input-group">
                    <input type="text" id="inpSearchValue" class="form-control" placeholder="支持角色名搜索" />
                    <span class="input-group-addon" id="btnSearch" onclick="GetRoleList()"><i class="glyphicon glyphicon-search"></i></span>
                </div>
            </div>
        </div>

        <div id="tableArea">
            <table class="table table-striped " id="table_content">
                <thead>
                    <tr>
                        <th>角色名称</th>
                        <th>角色父级名称</th>
                        <th>是否管理者</th>
                        <%--   <th>角色类型</th>--%>
                        <%-- <th>状态</th>--%>
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
        var RoleTable;
        $(document).ready(function () {
            GetRoleList();
            //GetDataInfoList();
            $('#txtRemark').focus(function () {
                var val = $(this).val();
                if (val == '支持角色名、备注搜索')
                    $(this).val('');
            }).blur(function () {
                var val = $(this).val();
                if (val == '')
                    $(this).val('支持角色名、备注搜索');
            });

        });//  

        function GetRoleList() {
            if (typeof (RoleTable) != "undefined") {
                RoleTable.fnClearTable(false); //清空一下table
                RoleTable.fnDestroy(); //还原初始化了的datatable
            }
            RoleTable = $("#table_content").dataTable({
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
                            { "name": "action", "value": "RoleList" },
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
                    { mData: "RoleName" },
                    { mData: "ParentRoleName" },
                      { mData: "IsManager", mRender:function (data, type, full) {
                          var b="";
                          if (full.IsManager==1) {
                              b="是";
                          }else{
                              b="否";
                          }
                          return b;
                      }
                      },
                          
                      //{ mData: "RoleType" },
                    //{
                    //    mData: "RoleStatus",
                    //    mRender: function (data, type, full) {
                    //        var result = full.RoleStatus;
                    //        switch (full.RoleStatus) {
                    //            case 0:
                    //                result = "无效";
                    //                break;
                    //            case 1:
                    //                result = "有效";
                    //                break;
                    //        }
                    //        return result;
                    //    },
                    //},
                { mData: "Remark" },
        {
        mData: 'RoleId', mRender: function (data, type, full) {
            return "<input class=\"btn btn-mini\" onclick=\"ShowAdd(" + full.RoleId + ")\" type=\"button\" value=\"修改\">  &nbsp&nbsp<input class=\"btn btn-mini\" onclick=\"ShowRoleFunction(" + full.RoleId + ")\" type=\"button\" value=\"功能授权\">&nbsp&nbsp<input class=\"btn btn-mini\" onclick=\"RoleDelete(" + full.RoleId + ")\" type=\"button\" value=\"删除\">";
        }
        }
        ],
        });
        }


        function ShowRoleFunction(RoleId) {
            if (RoleId > 0) {
                $.layer({
                    type: 2,
                    title: [
                       "功能授权"
                    ],
                    border: [0],
                    area: ['330px', '560px'],
                    end: function () {
                        if (typeof (RoleTable) != "undefined") {
                            RoleTable.fnDraw(false);
                        }
                    },
                    iframe: { src: 'RRoleFunction.aspx?RoleId=' + RoleId }
                });
            } else {
                layer.msg('授权失败！', 2, 1);
            }
            return false;
        }



        function VerifySon(RoleId) {
            var b = false;
            $.ajax({
                type: "GET",
                async: false,
                dataType: "text",
                url: "../Ajax/Admin/HRole.ashx?r=" + Math.random(),
                data: { Action: "VerifySonRole", RoleId: RoleId },
                success: function (data) {
                    if (data > 0) {
                        b = true;
                    }
                }
            });
            return b;
        };
        function VerifyRelation(RoleId) {
            var b = false;
            $.ajax({
                type: "GET",
                async: false,
                dataType: "text",
                url: "../Ajax/Admin/HRole.ashx?r=" + Math.random(),
                data: { Action: "VerifyRelationRole", RoleId: RoleId },
                success: function (data) {
                    if (data > 0) {
                        b = true;
                    }
                }
            });
            return b;
        };

        function RoleDelete(RoleId) {
            if (VerifySon(RoleId)) {
                layer.confirm('存在子级角色，请优先删除下属部门！');
            } else {
                if (VerifyRelation(RoleId)) {
                    layer.confirm('此角色关联用户，若删除角色将影响用户无操作权限！', function (index) {
                        DeleteRole(RoleId)
                    });
                } else {
                    layer.confirm('确定删除此角色吗？', function (index) { DeleteRole(RoleId) });
                }
            }
        };


        function DeleteRole(RoleId) {
            if (RoleId > 0) {
                $.ajax({
                    type: "GET",
                    async: false,
                    dataType: "text",
                    url: "../Ajax/Admin/HRole.ashx?r=" + Math.random(),
                    data: { Action: "DeleteRole", RoleId: RoleId },
                    success: function (data) {
                        if (data > 0) {
                            layer.msg('删除成功！', 1, 1);
                            if (typeof (RoleTable) != "undefined") {
                                RoleTable.fnDraw(false);
                            }
                        } else {
                            layer.msg('删除失败！', 2, 1);
                        }
                    }
                });
            }
        };


    <%--    <%} %>
         <%if (this.AdminUser.IsMaster || this.AdminUser.CheckedAuthorize("ochfia"))
           { %>--%>
        function ShowAdd(RoleId) {
            var titledata;
            if (RoleId == 0) {
                titledata = '添加系统角色';
            } else {
                titledata = '修改系统角色';
            }
            $.layer({
                type: 2,
                title: [
                   titledata
                ],
                border: [0],
                area: ['880px', '540px'],
                end: function () {

                    if (typeof (RoleTable) != "undefined") {
                        RoleTable.fnDraw(false);
                    }
                },
                iframe: { src: '/Admin/RoleAdd.aspx?RoleId=' + RoleId }
            });
            return false;
        }
    </script>
</asp:Content>
