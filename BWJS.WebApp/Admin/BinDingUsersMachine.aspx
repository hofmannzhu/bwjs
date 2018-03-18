<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BinDingUsersMachine.aspx.cs" Inherits="BWJS.WebApp.Admin.BinDingUsersMachine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设备绑定用户</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/Admin/main.css" rel="stylesheet" />
    <link href="/Content/css/list-style.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery-ui.js"></script>
    <script src="/Scripts/list-script.js"></script>
    <%--   <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/messages_zh.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/uril.js"></script>
    <script src="/Scripts/layer.min.js"></script>--%>
    <script>
        $(function(){
            getMerchantList();
            $('#selectTitle').initList();
          
        })
    </script>
</head>
<body>
    <div class="form-box form-user tabshow">
        <%-- <form class="form-horizontal" role="form" id="jsForm"> --%>


        <ul>
            <li class="form-group">
                <div id="selectTitle" class="list-select">
                    <div class="list-title">
                        <h4></h4>
                    </div>
                    <div class="list-body">
                        <div class="item-box left-box">
                            <!-- 左边框初始化待选项 -->

                        </div>
                        <div class="center-box">
                            <button class="add-one" title="添加选中项">></button>
                            <button class="add-all" title="添加全部">>></button>
                            <button class="remove-one" title="移除选中项"><</button>
                            <button class="remove-all" title="移除全部"><<</button>
                        </div>
                        <div class="item-box right-box">
                            <!-- 右边框存放已选项 -->
                        </div>
                    </div>
                    <div class="list-footer">
                        <button class="selected-val" id="btnSubmit" style="text-align: center; vertical-align: middle;" title="获取选择值，输出到控制台">保存</button>
                    </div>
                </div>
        </ul>
        <input type="hidden" id="hiddMachineId" name="hiddMachineId" value="0" />
        <script src="/Scripts/bootbox.js" type="text/javascript"></script>
        <script type="text/javascript">
            var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引  
            $(document).ready(function () {   
                $("#btnSubmit").click(function (){ 
                    var  usersId=getUsersId();
                    $.ajax({
                        type: "POST",
                        async: false,
                        dataType: "json",
                        url: "/ajax/helper.ashx?r=" + Math.random(),
                        data: { op: "bwjs", om: "gl", action: "BinDingUsersMachine", MachineID: <%=machineId%>, usersId: usersId },
                        success: function (json) {
                            if (json.result) {
                                parent.layer.msg(json.msg,1,1);
                                setTimeout( function(){ 
                                    parent.layer.close(index); 
                                }, 1000 );
                            } else {
                                parent.layer.msg(json.msg, 2, 1);
                            }
                        }
                    }); 
                            
                });
                $("#btnCancel").click(function (){
                    parent.layer.close(index);
                });
            });

            $.validator.setDefaults({
                errorElement: 'span',
                //rules: {
                //    inpFullName: {
                //        required: true,
                //        checkFullName: true,
                //    },
                //},
            });
 

            function getBinDingUsers() { 
               
            } 
            function getUsersId() 
            {   var strIds="";
                $(".right-box span").each(function(){
                    strIds=strIds+$(this).attr("data-id")+",";
                });
                return strIds; 
            } 
            //bootbox
            function myAlert(msg) {
                bootbox.dialog({
                    message: msg,
                    buttons: {
                        "success": {
                            "label": "关闭",
                            "className": "btn btn-sm btn-primary"
                        }
                    }
                });
            }  
            //商家列表
            function getMerchantList() {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/x-www-form-urlencoded",
                    url: "/ajax/helper.ashx",
                    data: { op: "bwjs", om: "gl", action: "merchantList","machineId":<%=machineId%>,"dbUserId":<%=dbUserId%>,r:Math.random() },
                    async: false,
                    cache: false,
                    traditional: false,
                    success: function (json) {
                        if (json.result) {  
                            $.ajax({
                                type: "POST",
                                async: false,
                                dataType: "json",
                                url: "/ajax/helper.ashx?r=" + Math.random(),
                                data: { op: "bwjs", om: "gl", action: "GetBinDingUsers", MachineID: <%=machineId%> },
                                success: function (jsonTwo) { 
                                    if(jsonTwo.result){ 
                                        var resultjson =json.data;
                                        for(var itemTwo in jsonTwo.data) {  
                                            for(var item in json.data) {
                                                if(jsonTwo.data[itemTwo].UserID==json.data[item].UserID)
                                                {
                                                    $(".right-box").append("<span class=\"item\" data-id=\""+json.data[item].UserID+"\">"+json.data[item].UserName+" "+json.data[item].LoginName+"</span>");                                                   
                                                    resultjson.splice(item,1); //排除已绑定的列
                                                } 
                                            } 
                                        } 
                                        for(var r in resultjson) { 
                                            $(".left-box").append("<span class=\"item\" data-id=\""+resultjson[r].UserID+"\">"+resultjson[r].UserName+" "+resultjson[r].LoginName+"</span>");  
                                        } 
                                    }
                                    else{ 
                                        $.each(json.data, function (key, value) {  
                                            $(".left-box").append("<span class=\"item\" data-id=\""+value.UserID+"\">"+value.UserName+" "+value.LoginName+"</span>");                                           
                                        });
                                    }
                                }
                            }); 
                        } else {
                            alert(json.msg);
                        }
                    },
                    error: function (json) {
                        alert("加载商家列表失败，请重试");
                    },
                });
            }


        </script>
        <%--    </form>--%>
    </div>
</body>
</html>
