<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RUserDepartment.aspx.cs" Inherits="BWJS.WebApp.Admin.RUserDepartment" %>

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
<script src="../Scripts/layer.js"></script>
<script src="/Scripts/jquery-form.js"></script>
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
                        <div id="DivLeft" style="height: 424px; width: 324px; padding-left: 20px; padding-top: 20px; float: left; auto; color: #666666; border: 1px solid #dddddd;">

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
                                    部门：
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <input id="txtDepartmentName" type="text" runat="server" class="form-control" value="" enabled="False" readonly />
                                    &nbsp;<asp:HiddenField ID="txtDepartmentID" runat="server" />
                                </div>
                            </div>
                            <div class="row-fluid margintop10">
                                <div class="span2"></div>
                                <div style="text-align: right; width: 20%; float: left">
                                    <asp:Button ID="btnRoot" runat="server" class=" btn btn-info" Text="清空此部门" OnClick="btnRoot_Click" />
                                </div>
                                <div class="span2"></div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <asp:Button ID="btnSave" runat="server" Text="保存" class=" btn btn-info" OnClientClick=" return Change()" OnClick="btnSave_Click" />
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
        var DepartmentName = $("#txtDepartmentName").val();
        if (DepartmentName == "") {
            layer.alert('部门名称不能为空！', { closeBtn: 0 , anim: 4 });
            return false;
        }

        return true;
    }


    function getClassList() {
        var tree_data;
        var paramter = {};
        paramter.op = "bwjs";
        paramter.om = "func";
        paramter.action = "getDepartmentInfolist";
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
        $("#txtDepartmentID").val(treeNode.id);
        $("#txtDepartmentName").val(treeNode.name);
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

