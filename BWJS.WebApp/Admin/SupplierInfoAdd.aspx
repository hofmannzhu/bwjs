<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierInfoAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.SupplierInfoAdd" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css">
    <link rel="stylesheet" href="/Content/jquery.dataTables.css">
    <link rel="stylesheet" href="/Content/css/Admin/main.css">
    <script src="../Scripts/jquery.dataTables.min.js"></script>
    <script src="../Scripts/uril.js"></script>
    <link href="../Content/css/jquery.dataTables.css" rel="stylesheet" />
    <link href="../Content/css/jquery.dataTables.min.css" rel="stylesheet" />
    <%--<script src="../Scripts/layer.js"></script>--%>
    <script src="../Scripts/layer.min.js"></script>
    <style>
        .row {
            margin-top: 0px;
        }
    </style>
    <title></title>
</head>
<body>
    <div class="form-box form-user">
        <form method="post" class="form-horizontal" role="form" id="jsForm" runat="server">
            <div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="margin-top: 4px;">
                                <div class="col-md-4 text-right">商户名称：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="SignName" name="SignName" class="form-control" placeholder="请填写商户名称" required data-msg-required="必填" data-msg-age="请填写商户名称" /><em>*</em>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="margin-top: 4px;">
                                <div class="col-md-4 text-right">真实姓名：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="UserName" name="UserName" class="form-control" placeholder="请填写您的真实姓名" /><em>*</em>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="form-group" id="IsShow">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">手机号：</div>
                        </div>
                        <div class="col-sm-10">
                            <input class="form-control" id="UserMobile" name="UserMobile" value="" placeholder="请填写您的手机号" required data-rule-remote="" style="width: 98%"><em>*</em>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">身份证号：</div>
                        </div>
                        <div class="col-sm-10">
                            <input class="form-control" id="extend1" name="extend1" value="" placeholder="请填写您的身份证号" required data-rule-remote="" style="width: 98%"><em>*</em>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">Email：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" id="UserEmail" value="" name="UserEmail" class="form-control" placeholder="请填写您的Email" style="width: 98%" /><em>*</em>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">详细地址：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" id="UserAdress" value="" name="UserAdress" class="form-control" placeholder="请填写您的详细地址" style="width: 98%" /><em>*</em>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="margin-top: 4px;">
                                <div class="col-md-4 text-right">QQ号：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="UserQQ" name="UserQQ" class="form-control" placeholder="请填写您的QQ号" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="margin-top: 4px;">
                                <div class="col-md-4 text-right">微信号：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="UserWechat" name="UserWechat" class="form-control" placeholder="请填写您的微信号" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">公司名称：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="CorporateName" name="CorporateName" class="form-control" placeholder="请填写您的公司名称" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">公司网站：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="CompanyWebsite" name="CompanyWebsite" class="form-control" placeholder="请填写您的公司网站" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">公司电话：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="CompanyPhone" name="CompanyPhone" class="form-control" placeholder="请填写您的公司电话" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">保证金：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="CautionMoney" name="CautionMoney" class="form-control" placeholder="请填写您的保证金" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">担保人：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="Guarantee" name="Guarantee" class="form-control" placeholder="请填写担保人" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">担保人电话：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="GuaranteeMobile" name="GuaranteeMobile" class="form-control" placeholder="请填写担保人电话" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">备注：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="Remark" name="Remark" class="form-control" placeholder="请填写备注" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-10 text-center">
                        <input id="SubmitID" type="button" class="btn btn-info" onclick="Submit()" value="提交注册" style="width: 200px; margin-left: 100px" />
                        <button type="reset" class="btn btn-danger btn-group-lg" onclick="ReturnList()" style="width: 200px; margin-left: 100px">返回</button>
                    </div>
                </div>
            </div>
            <input type="hidden" id="hidSId" name="SId" value="<%=SId %>" />
            <input type="hidden" id="hidRecordUpdateTime" name="RecordUpdateTime" value="" />
        </form>

    </div>
</body>
</html>
<script type="text/javascript">
    var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 
    $(document).ready(function () { 
        EditData();
        //var inputText = document.getElementById('LoginNameId');
        //inputText.onblur = function () {
        //    var LoginName = document.getElementById('LoginNameId').value;
        //    if (LoginName.length>20||LoginName.length<5 ){
        //        layer.msg('用户名长度在5-20之间,请重新填写用户名！',2,3,function(){
        //            $("#LoginNameId").val("");
        //        })
        //    }else{
        //        var un = /^\w+$/;
        //        if (!un.test($("#LoginNameId").val())) {
        //            layer.msg('用户名只能为字母、数字或下划线的组合,请重新填写用户名！',2,3,function(){
        //                $("#LoginNameId").val("");
        //            })
        //            return false;
        //        }else{
        //            $.ajax({
        //                type: "GET",
        //                async: false,
        //                dataType: "text",
        //                url: "../Ajax/Admin/UserManager.ashx?r=" + Math.random(),
        //                data: { Action: "VerificationIsUserName", LoginName: LoginName},
        //                success: function (data) {
        //                    if (data > 0) {
        //                        layer.msg('该用户名已经注册,请重新填写用户名！',2,3,function(){
        //                            $("#LoginNameId").val("");
        //                        })

        //                        return false;
        //                    } else {
        //                        return true;
        //                    }
        //                }
        //            });
        //        }
        //    }
        //}
    }); 
    function removeOptions(selectObj) {
        if (typeof selectObj != 'object') {
            selectObj = document.getElementById(selectObj);
        }
        // 原有选项计数
        var len = selectObj.options.length;
        for (var i = 0; i < len; i++) {
            // 移除当前选项
            selectObj.options[0] = null;
        }
    }  
    function ReturnList() {
        parent.layer.close(index);
    } 
    function EditData() {
        var videoBtn = document.getElementById("SubmitID");
        videoBtn.innerHTML = "修改"; 
        if (<%=SId%> > 0) { 
            $.ajax({
                type: "GET",
                async: false,
                dataType: "json",
                url: "/Ajax/Admin/UserManager.ashx?r=" + Math.random(),
                data: { Action: "GetSupplierInfo", SId: <%=SId%> },
                success: function (data) {   
                    $("#hidSId").val(<%=SId%>);
                    $("#SignName").val(data.SignName);
                    $("#UserName").val(data.UserName);
                    $("#UserMobile").val(data.UserMobile);
                    $("#extend1").val(data.extend1); 
                    $("#UserEmail").val(data.UserEmail);
                    $("#UserAdress").val(data.UserAdress);
                    $("#UserWechat").val(data.UserWechat);
                    $("#CorporateName").val(data.CorporateName);
                    $("#CompanyWebsite").val(data.CompanyWebsite); 
                    $("#CompanyPhone").val(data.CompanyPhone);
                    $("#CautionMoney").val(data.CautionMoney);
                    $("#Guarantee").val(data.Guarantee);
                    $("#UserQQ").val(data.UserQQ);
                    $("#GuaranteeMobile").val(data.GuaranteeMobile);
                    
                    //$("#Type").val(data.Type);
                    //$("#State").val(data.State);
                    $("#Remark").val(data.Remark);  
                }
            });
        }
    } 
    function VerificationIsNull(){
        var b=true;
        if ($("#SignName").val()=="") {
            layer.msg('商户名称不能为空！', 1,3); 
            b= false;
            return;
        };
        if ($("#UserName").val()=="") {
            layer.msg('真实姓名不能为空！', 1,3); 
            b= false;
            return;
        } 
        if ($("#UserMobile").val()=="") {
            layer.msg('手机号不能为空！', 1,3); 
            b= false;
            return;
        }else{
            var isIDCard2 =/^1[3|4|5|7|8][0-9]{9}$/; //验证规则
            var lengthvalue = document.getElementById('UserMobile').value.length;
            if (lengthvalue == 11) {
                if (isIDCard2.test(document.getElementById('UserMobile').value) === false) {
                    layer.msg('手机号输入不合法,请重新填写!',2,3,function(){
                        $("#UserMobile").val("");
                    })
                    b= false;
                    return;
                }
            }else{
                layer.msg('手机号位数不正确！', 1,3); 
                b= false;
                return;
            }
        }
        if ($("#extend1").val()=="") {
            layer.msg('身份证号不能为空！', 1,3); 
            b= false;
            return;
        }else{
            var isIDCard2 = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;//(18位)
            var lengthvalue = document.getElementById('extend1').value.length;
            if (lengthvalue == 18) {
                if (isIDCard2.test(document.getElementById('extend1').value) === false) {
                    layer.msg('身份证输入不合法,请重新填写!',2,3,function(){
                        $("#extend1").val("");
                    })
                    b= false;
                    return;
                }
                else {
                    b= true;
                }
            }else{
                layer.msg('身份证号位数不正确！', 1,3); 
                b= false;
                return;
            }
        } 
        if ($("#UserEmail").val()!=""&&$("#UserEmail").val()!=null) {
            var isIDCard2 =/^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/; 
           
            if (isIDCard2.test(document.getElementById('UserEmail').value) === false) {
                layer.msg('邮箱输入不合法,请重新填写!',2,3,function(){
                    $("#UserEmail").val("");
                })
                b= false;
                return;
            }
        }
        if ($("#UserAdress").val()=="") {
            layer.msg('详细地址不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#UserQQ").val()=="") {
            layer.msg('QQ号不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#UserWechat").val()=="") {
            layer.msg('微信号不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#CorporateName").val()=="") {
            layer.msg('公司名称不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#CompanyWebsite").val()=="") {
            layer.msg('公司网站不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#CompanyPhone").val()=="") {
            layer.msg('公司电话不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#CautionMoney").val()=="") {
            layer.msg('保证金不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#Guarantee").val()=="") {
            layer.msg('担保人不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#GuaranteeMobile").val()=="") {
            layer.msg('担保人电话不能为空！', 1,3); 
            b= false;
            return;
        }  
        return  b;
    }

    function Submit() {
        var strmsg='添加';
        var useridnum=<%= SId %>;
        if (  useridnum > 0) {
            strmsg='修改';
        }
        if (VerificationIsNull()) {
            var SId = $("#hidSId").val();
            $.ajax({
                type: "GET",
                async: false,
                dataType: "text",
                url: "../Ajax/Admin/UserManager.ashx?r=" + Math.random(),
                data: { Action: "AddSupplierInfo", SId: <%=SId%>,UsersModel: JSON.stringify(usersmodel()) },
                success: function (data) {
                    if (data > 0) {
                        parent.layer.msg(strmsg+'成功', 2,1); 
                        setTimeout( function(){
                            window.parent.location.reload();
                            parent.layer.close(index);
                        }, 1000 );
                    } else {
                        layer.msg(strmsg+'失败', 1,3); 
                    }
                }
            });
        } 
    } 
    function UsersInfo() {
        this.SId = "";
        this.SignName = "";
        this.UserName = "";
        this.UserMobile = "";
        this.extend1 = ""; 
        this.UserEmail = "";
        this.UserAdress = "";
        this.UserQQ = "";
        this.UserWechat = "";
        this.CorporateName = "";
        this.CompanyWebsite = "";
        this.CompanyPhone = "";
        this.CautionMoney = "";
        this.Guarantee = "";
        this.GuaranteeMobile = ""; 
        this.Type = "";
        this.State = "";
        this.Remark = ""; 
    } 
    function usersmodel() {
        var usersInfo = new UsersInfo();
        usersInfo.SId = $("#hidSId").val();
        usersInfo.SignName = $("#SignName").val();
        usersInfo.UserName = $("#UserName").val();
        usersInfo.UserMobile = $("#UserMobile").val();
        usersInfo.extend1=$("#extend1").val(); 
        usersInfo.UserEmail = $("#UserEmail").val();
        usersInfo.UserAdress = $("#UserAdress").val();
        usersInfo.UserQQ = $("#UserQQ").val();
        usersInfo.UserWechat = $("#UserWechat").val();
        usersInfo.CorporateName = $("#CorporateName").val();
        usersInfo.CompanyWebsite = $("#CompanyWebsite").val();
        usersInfo.CompanyPhone =  $("#CompanyPhone").val();
        usersInfo.CautionMoney = $("#CautionMoney").val();
        usersInfo.Guarantee = $("#Guarantee").val();
        usersInfo.GuaranteeMobile =$("#GuaranteeMobile").val();
        usersInfo.Type = $("#Type").val();
        usersInfo.State = $("#State").val();
        usersInfo.Remark = $("#Remark").val();
        usersInfo.CreateTime = '<%=DateTime.Now.ToString()%>'; 
        usersInfo.UpdateTime = '<%=DateTime.Now.ToString()%>'; 
        return usersInfo;
    }
   
</script>
