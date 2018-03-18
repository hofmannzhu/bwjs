<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.RoleAdd" %>

<!DOCTYPE html>
<link href="/Content/zTree/zTreeStyle/zTreeStyle.css" rel="stylesheet" />
<link href="/Content/zTree/zTree.css" rel="stylesheet" />
<script src="/Scripts/jquery.min.js"></script>
<script src="/Scripts/bootstrap.min.js"></script>
<link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
<script src="/Scripts/zTree/jquery.ztree.core-3.5.js"></script>
<script src="/Scripts/zTree/jquery.ztree.excheck-3.5.js"></script>
<script src="/Scripts/uril.js"></script>
<link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
<script src="/Scripts/layer.min.js"></script>
<link href="/Scripts/skin/layer.css" rel="stylesheet" />
<script src="/Scripts/jquery-form.js"></script>
<script src="/Scripts/layer.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row-fluid margintop10">
            <div class="container">
                <div class="row">
                    <div style="width: 50%">
                        <div id="DivLeft" style="height: 424px; width: 329px; padding-left: 52px; padding-top: 20px; float: left; auto; color: #666666; border: 1px solid #dddddd;">

                            <ul id="tree1" class="ztree">
                                <li>数据加载...</li>
                            </ul>
                        </div>
                    </div>
                    <div style="width: 50%; margin-left: 50%">
                        <div id="DivRight" class="span6">
                            <br />
                            <br />
                            <div class="row-fluid margintop10">
                                <div style="text-align: right; width: 20%; float: left">
                                    父角色：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <input id="txtRoleName" type="text" runat="server" class="form-control" value="添加根节点" enabled="False" readonly />

                                    &nbsp;<asp:HiddenField ID="txtRoleId" runat="server" />
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div style="text-align: right; width: 20%; float: left">
                                    角色名称：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <input id="txtRoleNameChild" type="text" runat="server" class="form-control" />
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div style="text-align: right; width: 30%; float: left; margin-left: -36px">
                                    是否管理岗位：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    是&nbsp;<input type="radio" name="cb" id="yes" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;否&nbsp;<input type="radio" name="cb" id="no" runat="server" checked="true" />
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div style="text-align: right; width: 20%; float: left">
                                    备注：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <input id="txtRemark" type="text" runat="server" class="form-control" />
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div class="span2"></div>
                                <div style="text-align: right; width: 20%; float: left">
                                    <asp:Button ID="btnRoot" runat="server" class=" btn btn-info" Text="清空角色" OnClick="btnRoot_Click" />
                                </div>
                                <div class="span2"></div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <asp:Button ID="btnSave" runat="server" Text="保存" class=" btn btn-info" OnClientClick="return Change()" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>


<script src="/Scripts/bootbox.js" type="text/javascript"></script>
<script src="/Scripts/Admin/m1.js" type="text/javascript"></script>
<script type="text/javascript">


    function Change() {
        var RoleNameChild = $("#txtRoleNameChild").val();
        if (RoleNameChild == "") {
            layer.alert('角色名称不能为空！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if (RoleNameChild.length > 50) {
            layer.alert('角色名称长度过长！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if ($("#txtRoleId").val()!=0&&<%=RoleId%>!=0&&($("#txtRoleId").val()==<%=RoleId%>)) {
            layer.alert('父级选择错误，请重新选择！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if (GetParentID($("#txtRoleId").val())) {
            layer.alert('父级选择错误，请重新选择！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if (RoleNameRepeat(RoleNameChild)) {
            layer.alert('角色名称重复,重新填写！', { closeBtn: 0, anim: 4 });
            return false;
        }

        return true;
    }

    function RoleNameRepeat(RoleName){
        var b = false;
        $.ajax({
            type: "GET",
            async: false,
            dataType: "text",
            url: "../Ajax/Admin/HRole.ashx?r=" + Math.random(),
            data: { Action: "RoleNameRepeat", RoleName: RoleName,RoleId:<%=RoleId%>},
            success: function (data) {
                if (data==1) {
                    b = true;
                }
            }
        });
        return b;
    }
    function GetParentID(PRoleId){
        var b = false;
        $.ajax({
            type: "GET",
            async: false,
            dataType: "text",
            url: "../Ajax/Admin/HRole.ashx?r=" + Math.random(),
            data: { Action: "GetParentID", ParentId: PRoleId,RoleId:<%=RoleId%>},
            success: function (data) {
                if (data==1) {
                    b = true;
                }
            }
        });
        return b;
    }

    function getClassList() {
        var tree_data;
        var paramter = {};
        paramter.op = "bwjs";
        paramter.om = "func";
        paramter.action = "getRolelist";
        paramter.channelId = 1;
        paramter.parentId = 0;
        var json = getJson(paramter, false);
        if (json.result) {
            tree_data = json.data;
        } else {
            myAlert(json.msg);
        }
        return tree_data;
    }

    function zTreeOnClick(event, treeId, treeNode) {
        $("#txtRoleId").val(treeNode.id);
        $("#txtRoleName").val(treeNode.name);
    };

    var setting = {
        data: {
            simpleData: {
                enable: true
            }
        },
        callback: {
            onClick: zTreeOnClick
        }
    };

    var zNodes = getClassList();

    $(document).ready(function () {
        $.fn.zTree.init($("#tree1"), setting, zNodes);
    });
</script>

