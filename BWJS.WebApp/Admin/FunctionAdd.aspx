<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FunctionAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.FunctionAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                                    父功能：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <%--<asp:TextBox ID="txtFunctionName" runat="server"   class="form-control"  Text="添加根节点" Enabled="False" ReadOnly="True"></asp:TextBox>--%>
                                    <input id="txtFunctionName" type="text" runat="server" class="form-control" value="添加根节点" enabled="False" readonly="readonly" />

                                    &nbsp;<asp:HiddenField ID="txtFunctionID" runat="server" />
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div style="text-align: right; width: 20%; float: left">
                                    功能名称：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <input id="txtFunctionNameChild" type="text" runat="server" class="form-control" />
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div style="text-align: right; width: 20%; float: left">
                                    链接地址：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <input id="txtExternalLinkAddress" name="txtExternalLinkAddress" type="text" runat="server" class="form-control" value="javascript:void(0)" />
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div style="text-align: right; width: 20%; float: left">
                                    排序编号：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <input id="txtOrderId" name="txtOrderId" type="text" runat="server" class="form-control" value="1" />
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div style="text-align: right; width: 20%; float: left">
                                    类型：
                   
                                </div>
                                <div style="text-align: left; width: 80%; margin-left: 30%">
                                    <select style="width: 166px" id="SeleFunctionType" runat="server" class="form-control">
                                        <option value="2">- 请选择-</option>
                                        <option value="0">导航</option>
                                        <option value="1">操作</option>
                                    </select>
                                </div>
                            </div>
                            <br />
                            <div class="row-fluid margintop10">
                                <div class="span2"></div>
                                <div style="text-align: right; width: 20%; float: left">
                                    <asp:Button ID="btnRoot" runat="server" class=" btn btn-info" Text="清空父功能" OnClick="btnRoot_Click" />
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
        <asp:HiddenField ID="HidFunctionCode" runat="server" />
    </form>
</body>
</html>


<script src="/Scripts/bootbox.js" type="text/javascript"></script>
<script src="/Scripts/Admin/m1.js" type="text/javascript"></script>
<script type="text/javascript">

    function Change() {
        var FunctionNameChild = $("#txtFunctionNameChild").val();
        var SeleFunctionType = $("#SeleFunctionType").val();
        if (FunctionNameChild == "") {
            layer.alert('功能名称不能为空！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if (FunctionNameChild.length > 50) {
            layer.alert('功能名称长度过长！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if (SeleFunctionType == "2") {
            layer.alert('请选择功能类型！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if ($("#txtFunctionID").val()!=0&&<%=FunctionId%>!=0&&($("#txtFunctionID").val()==<%=FunctionId%>)) {
            layer.alert('父级选择错误，请重新选择！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if (GetParentID($("#txtFunctionID").val())) {
            layer.alert('父级选择错误，请重新选择！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if (FunctionNameRepeat(FunctionNameChild)) {
            layer.alert('功能名称重复,重新填写！', { closeBtn: 0, anim: 4 });
            return false;
        }


        return true;
    }

    function FunctionNameRepeat(FunctionName){
      var b = false;
        $.ajax({
            type: "GET",
            async: false,
            dataType: "text",
            url: "../Ajax/Admin/HFunction.ashx?r=" + Math.random(),
            data: { Action: "FunctionNameRepeat", FunctionName: FunctionName,FunctionID:<%=FunctionId%>},
            success: function (data) {
                if (data==1) {
                    b = true;
                }
            }
        });
        return b;}
    function GetParentID(PFunctionID){
        var b = false;
        $.ajax({
            type: "GET",
            async: false,
            dataType: "text",
            url: "../Ajax/Admin/HFunction.ashx?r=" + Math.random(),
            data: { Action: "GetParentID", ParentId: PFunctionID,FunctionID:<%=FunctionId%>},
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
        paramter.action = "getfunctionlist";
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
        $("#txtFunctionID").val(treeNode.id);
        $("#txtFunctionName").val(treeNode.name);
        $("#txtExternalLinkAddress").val(treeNode.externalLink);
        $("#txtOrderId").val(treeNode.orderId);
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
