<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MachineSupplierAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.MachineSupplierAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加厂商</title>
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
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpSN">供应商名称：</label>
                    <div class="col-sm-8">
                        <input id="SupplierName" name="SupplierName" class="form-control" type="text" placeholder="供应商名称" required /><em>*</em>
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">负责人：</label>
                    <div class="col-sm-8">
                        <input id="Manager" name="Manager" type="text" class="form-control" placeholder="负责人" required /><em>*</em>
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">电话：</label>
                    <div class="col-sm-8">
                        <input id="Phone" name="Phone" type="text" class="form-control" placeholder="电话" /> 
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">手机：</label>
                    <div class="col-sm-8">
                        <input id="Mobile" name="Mobile" type="text" class="form-control" placeholder="手机" required /><em>*</em>
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">地址：</label>
                    <div class="col-sm-8">
                        <input id="Address" name="Address" type="text" class="form-control" placeholder="地址" />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">QQ：</label>
                    <div class="col-sm-8">
                        <input id="QQ" name="QQ" type="text" class="form-control" placeholder="QQ" />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">主页：</label>
                    <div class="col-sm-8">
                        <input id="SiteUrl" name="SiteUrl" type="text" class="form-control" placeholder="主页" />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">Logo：</label>
                    <div class="col-sm-8">
                        <input id="Logo" name="Logo" type="text" class="form-control" placeholder="Logo"  />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">业务对接地址：</label>
                    <div class="col-sm-8">
                        <input id="API" name="API" type="text" class="form-control" placeholder="业务对接地址"  />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">二维码地址：</label>
                    <div class="col-sm-8">
                        <input id="QRCode" name="QRCode" type="text" class="form-control" placeholder="二维码地址"  />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">主要品牌：</label>
                    <div class="col-sm-8">
                        <input id="MainBrand" name="MainBrand" type="text" class="form-control" placeholder="主要品牌"  />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">主营业务：</label>
                    <div class="col-sm-8">
                        <input id="MainBusiness" name="MainBusiness" type="text" class="form-control" placeholder="主营业务"  />
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">微信号：</label>
                    <div class="col-sm-8">
                        <input id="Wechat" name="Wechat" type="text" class="form-control" placeholder="微信号"  />
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">公众号：</label>
                    <div class="col-sm-8">
                        <input id="PublicWechat" name="PublicWechat" type="text" class="form-control" placeholder="公众号"  />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label">状 态：</label>
                    <div class="col-sm-8">
                        <label>
                            <input id="inpStatus1" name="inpStatus" type="radio" value="0" checked="checked" />
                            正 常</label>
                        <label>
                            <input id="inpStatus0" name="inpStatus" type="radio" value="1" />
                            冻 结</label>
                        <span class="error"></span><em>*</em>
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
            <input type="hidden" id="hidMachineSupplierId" name="hidMachineSupplierId" value="0" />
            <script src="/Scripts/bootbox.js" type="text/javascript"></script>
            <script type="text/javascript">
                var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 

                $(document).ready(function () {  
                    if (<%=MachineSupplierId%> > 0) {
                        EditData();
                    }
                    $("#btnSubmit").click(function (){ 
                        if ($("#jsForm").valid()) { 
                            var machineSupplierModel=getMachineSupplierModel(); 
                            $.ajax({
                                type: "POST",
                                async: false,
                                dataType: "json",
                                url: "/ajax/helper.ashx?r=" + Math.random(),
                                data: { op: "bwjs", om: "gl", action: "AddMachineSupplier", MachineSupplierId: <%=MachineSupplierId%>, MachineSupplierModel: JSON.stringify(machineSupplierModel) },
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

                

                    function EditData() {
                        var objBtnSubmit = document.getElementById("btnSubmit");
                        objBtnSubmit.innerHTML = "修改";
                        if (<%=MachineSupplierId%> > 0) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            dataType: "json",
                            url: "/ajax/helper.ashx?r=" + Math.random(),
                            data: { op: "bwjs", om: "gl", action: "GetMachineSupplier", MachineSupplierId: <%=MachineSupplierId%> },
                            success: function (json) {
                                if(json.result){
                      
                                    $("#hidMachineSupplierId").val('<%=MachineSupplierId%>');   
                                    $("#SupplierName").val(json.data.SupplierName);
                                    $("#Manager").val(json.data.Manager);
                                    $("#Phone").val(json.data.Phone);
                                    $("#Mobile").val(json.data.Mobile);
                                    $("#Address").val(json.data.Address);
                                    $("#QQ").val(json.data.QQ);
                                    $("#SiteUrl").val(json.data.SiteUrl);
                                    $("#Logo").val(json.data.Logo);
                                    $("#API").val(json.data.API);
                                    $("#QRCode").val(json.data.QRCode);
                                    $("#MainBrand").val(json.data.MainBrand);
                                    $("#MainBusiness").val(json.data.MainBusiness);
                                    $("#Wechat").val(json.data.Wechat);
                                    $("#PublicWechat").val(json.data.PublicWechat);
                                    $("#inpRemark").val(json.data.Remark);
                                    if (json.data.Status == 1) {
                                        $("#inpStatus0").attr('checked', 'checked');
                                    } else {
                                        $("#inpStatus1").attr('checked', 'checked');
                                    }

                                }
                                else{
                                }
                            }
                        });
                    }
                }

                function getMachineSupplierModel() {  
                    var model = {};
                    model.MachineSupplierId = $("#hidMachineSupplierId").val();
                    model.SupplierName = $("#SupplierName").val();
                    model.Manager =$("#Manager").val();
                    model.Phone = $("#Phone").val();
                    model.Mobile = $("#Mobile").val();
                    model.Address = $("#Address").val();
                    model.QQ = $("#QQ").val();
                    model.SiteUrl = $("#SiteUrl").val();
                    model.Logo  = $("#Logo").val();
                    model.API = $("#API").val();
                    model.QRCode = $("#QRCode").val();
                    model.MainBrand = $("#MainBrand").val();
                    model.MainBusiness  = $("#MainBusiness").val();
                    model.Wechat = $("#Wechat").val();
                    model.PublicWechat = $("#PublicWechat").val();
                    model.Remark = $("#inpRemark").val();
                    model.Status = parseInt($("input[name='inpStatus']:checked").val());
                    return model;
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
