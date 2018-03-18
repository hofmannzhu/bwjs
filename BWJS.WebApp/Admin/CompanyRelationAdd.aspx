<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyRelationAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.CompanyRelationAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加渠道关系</title>
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
                    <label class="col-sm-3 control-label" for="inpCompany">渠道:</label>
                    <div class="col-sm-8">
                        <select id="inpCompany"  name="inpCompany" class="form-control"></select><em>*</em>
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpUserId">商家:</label>
                    <div class="col-sm-8">
                        <select id="inpUserId" name="inpUserId" class="form-control"></select><em>*</em>
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpDepartment">商家部门：</label>
                    <div class="col-sm-8">
                        <select id="inpDepartment" name="inpDepartment" class="form-control"></select><em>*</em>
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpRecommendationCode">推荐码：</label>
                    <div class="col-sm-8">
                        <input id="inpRecommendationCode" name="inpRecommendationCode" type="text" class="form-control" placeholder="推荐码" />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpQRCode">二维码地址：</label>
                    <div class="col-sm-8">
                        <input id="inpQRCode" name="inpQRCode" type="text" class="form-control" placeholder="二维码地址" />
                    </div>
                </li>

                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAPI">业务对接地址：</label>
                    <div class="col-sm-8">
                        <input id="inpAPI" name="inpAPI" type="text" class="form-control" placeholder="业务对接地址" />
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
            <input type="hidden" id="hidCompanyRelationId" name="hidCompanyRelationId" value="0" />
            <script src="/Scripts/bootbox.js" type="text/javascript"></script>
            <script type="text/javascript">
                var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 

                $(document).ready(function () {  
                    getCompanyList();
                    getMerchantList();
                    getDepartmentInfoList();
                    if (<%=companyRelationId%> > 0) {
                        EditData();
                    }
                    $("#btnSubmit").click(function (){ 
                        if ($("#jsForm").valid()) { 
                            var companyRelationModel = GetCompanyRelation();
                            $.ajax({
                                type: "POST",
                                async: false,
                                dataType: "json",
                                url: "/ajax/helper.ashx?r=" + Math.random(),
                                data: { op: "bwjs", om: "gl", action: "AddCompanyRelation", CompanyRelationId: <%=companyRelationId%>, CompanyRelationModel: JSON.stringify(companyRelationModel) },
                                success: function (json) {
                                    if (json.result) {
                                        parent.layer.msg(json.msg,1,1);
                                        setTimeout( function(){
                                            //window.parent.location.reload();
                                            parent.layer.close(index);
                                            window.parent.GetCompanyRelationList();
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
                    if (<%=companyRelationId%> > 0) {
                        $.ajax({
                            type: "POST",
                            async: false,
                            dataType: "json",
                            url: "/ajax/helper.ashx?r=" + Math.random(),
                            data: { op: "bwjs", om: "gl", action: "GetCompanyRelation", CompanyRelationId: <%=companyRelationId%> },
                            success: function (json) {
                                if(json.result){
                      
                                    $("#hidCompanyRelationId").val('<%=companyRelationId%>');   
                                    $("#inpCompany").val(json.data.CompanyId);
                                    $("#inpUserId").val(json.data.UserId);
                                    $("#inpDepartment").val(json.data.DepartmentId);
                                    $("#inpRecommendationCode").val(json.data.RecommendationCode);
                                    $("#inpQRCode").val(json.data.QRCode);
                                    $("#inpAPI").val(json.data.API);
                                    $("#inpRemark").val(json.data.Remark);
                                }
                                else{
                                }
                            }
                        });
                    }
                }

                function GetCompanyRelation() {  
                    var model = {};
                    model.CompanyRelationId = $("#hidCompanyRelationId").val();
                    model.CompanyId = $("#inpCompany").val();
                    model.UserId =$("#inpUserId").val();
                    model.DepartmentId = $("#inpDepartment").val();
                    model.RecommendationCode = $("#inpRecommendationCode").val();
                    model.QRCode = $("#inpQRCode").val();
                    model.API = $("#inpAPI").val();
                    model.Remark = $("#inpRemark").val();
                    model.IsDeleted=0;
                    model.CreateId=<%=LoginUserID%>;
                    model.EditId=<%=LoginUserID%>;
                    model.CreateDate='<%=DateTime.Now%>';
                    return model;
                }

                //获取渠道
                function getCompanyList() {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        contentType: "application/x-www-form-urlencoded",
                        url: "/ajax/helper.ashx",
                        data: { op: "bwjs", om: "gl", action: "companyListForSelect", r: Math.random() },
                        async: false,
                        cache: false,
                        traditional: false,
                        success: function (json) {
                            if (json.result) {
                                $("#inpCompany").append("<option value=\"\">请选择渠道</option>");
                                $.each(json.data, function (key, value) {
                                    $("#inpCompany").append("<option value=\"" + value.CompanyId + "\">" + value.CompanyName + " </option>");
                                });
                            } else {
                                alert(json.msg);
                            }
                        },
                        error: function (json) {
                            alert("加载渠道列表失败，请重试");
                        },
                    });
                }
    
                //商家列表
                function getMerchantList() {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        contentType: "application/x-www-form-urlencoded",
                        url: "/ajax/helper.ashx",
                        data: { op: "bwjs", om: "gl", action: "merchantList",r:Math.random() },
                        async: false,
                        cache: false,
                        traditional: false,
                        success: function (json) {
                            if (json.result) {
                                //alert(JSON.stringify(json.data));
                                $("#inpUserId").append("<option value=\"\">请选择商家</option>");
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

                //商家部门列表
                function getDepartmentInfoList() {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        contentType: "application/x-www-form-urlencoded",
                        url: "/ajax/helper.ashx",
                        data: { op: "bwjs", om: "func", action: "DepartmentInfoListForSelect",r:Math.random() },
                        async: false,
                        cache: false,
                        traditional: false,
                        success: function (json) {
                            if (json.result) {
                                //alert(JSON.stringify(json.data));
                                $("#inpDepartment").append("<option value=\"\">请选择商家部门</option>");
                                $.each(json.data, function (key, value) {
                                    $("#inpDepartment").append("<option value=\""+value.DepartmentID+"\">"+value.DepartmentName+" </option>");
                                });
                            } else {
                                alert(json.msg);
                            }
                        },
                        error: function (json) {
                            alert("加载商家部门列表失败，请重试");
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
