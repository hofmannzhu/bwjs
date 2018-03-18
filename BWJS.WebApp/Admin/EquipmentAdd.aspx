<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipmentAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.EquipmentAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加设备</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/Admin/main.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/messages_zh.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/uril.js"></script>
    <script src="/Scripts/layer.min.js"></script>
</head>
<body>
    <div class="form-box form-user tabshow">
        <form class="form-horizontal" role="form" id="jsForm">
            <ul>
               <%-- <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpUserId">所属用户:</label>
                    <div class="col-sm-8">
                        <select id="inpUserId" name="inpUserId" class="form-control"></select>
                    </div>
                </li>--%>
                    <li class="form-group">
                    <label class="col-sm-3 control-label" for="SupplierInfo">所属商户:</label>
                    <div class="col-sm-8">
                        <select id="SupplierInfo" name="SupplierInfo" class="form-control"></select>
                    </div>
                </li>
                
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="supplier">所属厂家:</label>
                    <div class="col-sm-8">
                        <select id="supplier" name="supplier" class="form-control"></select>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpSN">设备号：</label>
                    <div class="col-sm-8">
                        <input id="inpSN" name="inpSN" class="form-control" type="text" placeholder="设备号" required /><em>*</em>
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">设备所在地：</label>
                    <div class="col-sm-8">
                        <input id="inpAddress" name="inpAddress" type="text" class="form-control" placeholder="设备所在地" required /><em>*</em>
                    </div>
                </li>
                   <li class="form-group">
                    <label class="col-sm-3 control-label">平台类型：</label>
                    <div class="col-sm-8">
                        <label>
                            <input id="PlatformPad" name="Platform" type="radio" value="1" checked="checked" />
                            平 板</label>
                        <label>
                            <input id="PlatformPc" name="Platform" type="radio" value="2" />
                            机 器</label>
                        <span class="error"></span><em>*</em>
                    </div>
                </li>
                     <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpSN">平板设备号：</label>
                    <div class="col-sm-8">
                        <input id="FlatDeviceNumber" name="FlatDeviceNumber" class="form-control" type="text" placeholder="平板设备号" /><em></em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label">状 态：</label>
                    <div class="col-sm-8">
                        <label>
                            <input id="inpStatus1" name="inpStatus" type="radio" value="1" checked="checked" />
                            正 常</label>
                        <label>
                            <input id="inpStatus0" name="inpStatus" type="radio" value="0" />
                            冻 结</label>
                        <span class="error"></span><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpTeamViewerNumber">远程TeamViewer号：</label>
                    <div class="col-sm-8">
                        <input id="inpTeamViewerNumber" name="inpTeamViewerNumber" type="text" class="form-control" placeholder="远 程TeamViewer号" data-msg-age="请输入数字" required /><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpTeamViewerPwd">远程TeamViewer密码：</label>
                    <div class="col-sm-8">
                        <input id="inpTeamViewerPwd" name="inpTeamViewerPwd" type="password" class="form-control" placeholder="请输入6-12位字母数字组合密码" data-msg-age="密码格式不正确" required /><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpRemark">备 注：</label>
                    <div class="col-sm-8">
                        <textarea id="inpRemark" name="inpRemark" cols="" rows="4" class="form-control" placeholder="备 注 信 息"></textarea>
                    </div>
                </li>
                <li class="form-group">
                    <div class="col-sm-12 text-center">
                        <button id="btnSubmit" class="btn btn-success btn-group-lg" type="button" style="width: 30%; margin-left: 4%; margin-right: 6%">保 存</button>
                        <button id="btnCancel" type="reset" class="btn btn-danger btn-group-lg" style="width: 30%; margin-right: -13%">返 回</button>
                    </div>
                </li>
            </ul>
            <input type="hidden" id="hiddMachineId" name="hiddMachineId" value="0" />
            <script src="/Scripts/bootbox.js" type="text/javascript"></script>
            <script type="text/javascript">
                var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 

                $(document).ready(function () {
                    //getMerchantList();
                    getSupplierList();
                    getSupplierInfo();
                    if (<%=machineId%> > 0) {
                        EditData();
                    }
                    $("#btnSubmit").click(function (){
                        if ($("#jsForm").valid()) {
                            if (VerificationIsNull()) { 
                                var machineModel=getMachineModel();
                                $.ajax({
                                    type: "POST",
                                    async: false,
                                    dataType: "json",
                                    url: "/ajax/helper.ashx?r=" + Math.random(),
                                    data: { op: "bwjs", om: "gl", action: "AddMachine", MachineID: <%=machineId%>, MachineModel: JSON.stringify(machineModel) },
                                    success: function (json) {
                                        if (json.result) {
                                            parent.layer.msg(json.msg,1,1);
                                            setTimeout( function(){
                                                //window.parent.location.reload();
                                                parent.layer.close(index);
                                                window.parent.GetMachineList();
                                            }, 1000 );
                                        } else {
                                            parent.layer.msg(json.msg, 2, 1);
                                        }
                                    }
                                });
                            }
                        }
                        else{
                            layer.msg('请检查页面输入！', 2, 1);
                        }
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

                function VerificationIsNull(){
                    var b=true;
                    if ($("#inpTeamViewerPwd").val()=="") {
                        layer.msg('TeamViewer密码不能为空！', 1,3); 
                        b= false;
                        return;
                    }else{
                        if(($("#inpTeamViewerPwd").val().length>12)||($("#inpTeamViewerPwd").val().length<6)){
                            layer.msg('TeamViewer密码长度在6-12之间,请重新填写！', 1,3); 
                            b= false;
                            return;
                        }
                    } 
                    if (!$("#supplier").val()) {
                        layer.msg('请选择所属厂家！', 1,3); 
                        b= false;
                        return;
                    }
                    return  b;
                }

                function EditData() {
                    var objBtnSubmit = document.getElementById("btnSubmit");
                    objBtnSubmit.innerHTML = "修改";
                    if (<%=machineId%> > 0) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            dataType: "json",
                            url: "/ajax/helper.ashx?r=" + Math.random(),
                            data: { op: "bwjs", om: "gl", action: "GetMachineOne", MachineID: <%=machineId%> },
                            success: function (json) {
                                if(json.result){
                                    $("#hiddMachineId").val(<%=machineId%>);                        
                                    $("#SupplierInfo").val(json.data.SId); 
                                    $("#supplier").val(json.data.MachineSupplierId);
                                    $("#inpSN").val(json.data.SN);
                                    $("#inpAddress").val(json.data.Address);
                                    if (json.data.Status == 1) {
                                        $("#inpStatus1").attr('checked', 'checked');
                                    } else {
                                        $("#inpStatus0").attr('checked', 'checked');
                                    }
                                    $("#inpTeamViewerNumber").val(json.data.TeamViewerNumber);
                                    $("#inpTeamViewerPwd").val(json.data.TeamViewerPwd);
                                    $("#inpRemark").val(json.data.Remark);
                                    if (json.data.Platform == 1) {
                                        $("#PlatformPad").attr('checked', 'checked');
                                    } else if (json.data.Platform == 2) {
                                        $("#PlatformPc").attr('checked', 'checked');
                                    }
                                    $("input[name='Platform']:checked").val(json.data.Platform);
                                    $("#FlatDeviceNumber").val(json.data.FlatDeviceNumber);
                                }
                                else{
                                }
                            }
                        });
                    }
                }

                function getMachineModel() {
                    var model = {}; 
                    model.MachineSupplierId = parseInt(($("#supplier").val()==""||$("#supplier").val()==null)?("0"):($("#supplier").val())); 
                    model.SId = parseInt(($("#SupplierInfo").val()==""||$("#SupplierInfo").val()==null)?("0"):($("#SupplierInfo").val()));
                    model.SN = $("#inpSN").val();
                    model.MAC = "";
                    model.Address = $("#inpAddress").val();
                    model.Latitude = 0;
                    model.Longitude  = 0;
                    model.Status = parseInt($("input[name='inpStatus']:checked").val());
                    model.TeamViewerNumber = $("#inpTeamViewerNumber").val();
                    model.TeamViewerPwd = $("#inpTeamViewerPwd").val();
                    model.ActivationCode  = "";
                    model.Remark = $("#inpRemark").val();
                    model.Platform=$("input[name='Platform']:checked").val();
                    model.FlatDeviceNumber = $("#FlatDeviceNumber").val();
                    return model;
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
                                //alert(JSON.stringify(json.data));
                                $("#inpUserId").append("<option value=\"\">请选择所属用户</option>");
                                $.each(json.data, function (key, value) {
                                    $("#inpUserId").append("<option value=\""+value.UserID+"\">"+value.UserName+" "+value.LoginName+" </option>");
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

                //厂家列表
                function getSupplierList() {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        contentType: "application/x-www-form-urlencoded",
                        url: "/ajax/helper.ashx",
                        data: { op: "bwjs", om: "gl", action: "supplierL" },
                        async: false,
                        cache: false,
                        traditional: false,
                        success: function (json) {
                            if (json.result) {
                                //alert(JSON.stringify(json.data));
                                $("#supplier").append("<option value=\"\">请选择所属厂商</option>");
                                $.each(json.data, function (key, value) {
                                    $("#supplier").append("<option value=\""+value.MachineSupplierId+"\">"+value.SupplierName+"</option>");
                                });
                            } else {
                                alert(json.msg);
                            }
                        },
                        error: function (json) {
                            alert("加载厂家列表失败，请重试");
                        },
                    });
                }
                //商户列表
                function getSupplierInfo() {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        contentType: "application/x-www-form-urlencoded",
                        url: "/ajax/helper.ashx",
                        data: { op: "bwjs", om: "gl", action: "SupplierInfo" },
                        async: false,
                        cache: false,
                        traditional: false,
                        success: function (json) {
                            if (json.result) {
                                //alert(JSON.stringify(json.data));
                                $("#SupplierInfo").append("<option value=\"\">请选择所属商户</option>");
                                $.each(json.data, function (key, value) {
                                    $("#SupplierInfo").append("<option value=\""+value.SId+"\">"+value.SignName+"</option>");
                                });
                            } else {
                                alert(json.msg);
                            }
                        },
                        error: function (json) {
                            alert("加载商户列表失败，请重试");
                        },
                    });
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
            </script>
        </form>
    </div>
</body>
</html>
