<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RRoleFunction.aspx.cs" Inherits="BWJS.WebApp.Admin.RRoleFunction" %>

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
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form method="post" class="form-horizontal" role="form" id="jsForm" enctype="multipart/form-data" runat="server">
        <%--<form id="form1" runat="server">--%>
        <div>
            <div id="DivLeft" style="height: 424px; width: 329px; padding-left: 52px; padding-top: 20px; color: #666666; border: 1px solid #dddddd;">
                <ul id="tree1" class="ztree">
                    <li>数据加载...</li>
                </ul>
            </div>
            <br />
            <input id="btnSave" type="button" class=" btn btn-info" style="width:329px" onclick="Submit()" value="保存" />
        </div>
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />

    </form>
</body>
</html>

<script src="/Scripts/bootbox.js" type="text/javascript"></script>
<script src="/Scripts/Admin/m1.js" type="text/javascript"></script>
<script type="text/javascript">
    var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 
    var rowData;  
    $(document).ready(function () {
        $.fn.zTree.init($("#tree1"), setting, zNodes);
        AssignCheck();
    });

    function GetCheckedAll() {
        var treeObj = $.fn.zTree.getZTreeObj("tree1");
        var nodes = treeObj.getCheckedNodes(true);
        var msg = "";
        for (var i = 0; i < nodes.length; i++) {
            msg += nodes[i].id+",";
        }
        alert(msg);
    }    


    function RoleOk() {  
        var treeObj = $.fn.zTree.getZTreeObj("tree1");
        var nodes = treeObj.getCheckedNodes(true);
        var msg = "";
        for (var i = 0; i < nodes.length; i++) {
            msg += nodes[i].id+",";
        }
        alert(msg);

        return false;
    }  
    function Submit() {
        var indexload = layer.load("数据保存中");
        var treeObj = $.fn.zTree.getZTreeObj("tree1");
        var nodes = treeObj.getCheckedNodes(true);
        var msg = "";
        for (var i = 0; i < nodes.length; i++) {
            msg += nodes[i].id+",";
        }
        var jsonFrm =JSON.stringify($('#jsForm').serialize());
        var options = {
            type: "POST",
            async: false,
            dataType: "text",
            url: "../Ajax/Admin/HRoleFunction.ashx?r=" + Math.random(),
            data: { Action: "RoleFunctionAdd", RoleId: <%=RoleId%>, FunctionArray:msg},
            success: function (data) {
                layer.close(indexload);
                if (data > 0) {
                    parent.layer.msg('保存成功', 1, 1);
                    setTimeout( function(){
                        parent.layer.close(index);
                        window.parent.GetAdPositionList();
                    }, 1000 );
                    return true;
                } else {
                    layer.msg('保存失败！', 2, 1);
                    return false;
                }
            }
        };
        $("#jsForm").ajaxSubmit(options);
     
      
    }
    

    ////全选
    //function CheckAllNodes() {
    //    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    //    treeObj.checkAllNodes(true);
    //}

    ////全取消
    //function CancelAllNodes() {
    //    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    //    treeObj.checkAllNodes(false);
    //}
    
    //选中指定的节点
    function AssignCheck() {
        var treeObj = $.fn.zTree.getZTreeObj("tree1");
        $.ajax({
            type: "GET",
            async: false,
            dataType: "json",
            url: "../Ajax/Admin/HRoleFunction.ashx?r=" + Math.random(),
            data: { Action: "GetAssignCheck", RoleId: <%=RoleId%> },
            success: function (data) {
                if (data!=null&&data!="") {
                    json = eval(data.data) 
                    for(var i=0; i<json.length; i++)  
                    {  
                        treeObj.checkNode(treeObj.getNodeByParam("id",  json[i].FunctionId, null), true, true);
                    }  
                }
            }
        });
    }
    ////禁用、解禁选中节点
    //function Disabled1() {
    //    var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
    //    var nodes = treeObj.getCheckedNodes();

    //    for (var i = 0; i < nodes.length; i++) {
    //        treeObj.setChkDisabled(nodes[i], true);
    //    }
    //}

  


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
        $("#HiddenField1").val(treeNode.id);
        $("#HiddenField2").val(treeNode.name);
    };

    var setting = {
        data: {
            simpleData: {
                enable: true
            }
        },
        check: {
            enable: true,
            autoCheckTrigger: false,
            chkboxType: { "Y" : "", "N" : "" },
        },
        callback: {
            onClick: zTreeOnClick
        }
    };

    var zNodes = getClassList();
</script>
