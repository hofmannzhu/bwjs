<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/m1.Master" CodeBehind="UserUpdatepwd.aspx.cs" Inherits="BWJS.WebApp.Admin.UserUpdatepwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="form-box form-user tabshow">
        <div class="form-horizontal">
            <ul> 
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpSN">原始密码：</label>
                    <div class="col-sm-8">
                        <input id="oldPwd" name="oldPwd" class="form-control" type="text" placeholder="请输入原始密码" required /><em>*</em>
                    </div>
                </li> 
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">新密码：</label>
                    <div class="col-sm-8">
                        <input id="newPwd" name="newPwd" type="password" class="form-control" placeholder="请输入新密码" required /><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label" for="inpAddress">确认新密码：</label>
                    <div class="col-sm-8">
                        <input id="surePwd" name="surePwd" type="password" class="form-control" placeholder="请输入确认密码" required /><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <div class="col-sm-12 text-center">
                        <button id="btnSubmit" class="btn btn-success btn-group-lg" type="button" style="width: 30%; margin-left: 4%; margin-right: 6%">保 存</button>
                        <button id="btnCancel" type="reset" class="btn btn-danger btn-group-lg" style="width: 30%; margin-right: -13%">返 回</button>
                    </div>
                </li>
            </ul>
            <input type="hidden" id="hidUserId" name="hidUserId" value="<%=UserId %>" /> 
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#btnSubmit").click(function () { 
                        if (VerificationIsNull()) {
                            var userId = $("#hidUserId").val();
                            var oldPwd = $("#oldPwd").val();
                            var newPwd = $("#newPwd").val(); 
                            $.ajax({
                                type: "POST",
                                async: false,
                                dataType: "json",
                                url: "/ajax/helper.ashx?r=" + Math.random(),
                                data: { op: "bwjs", om: "gl", action: "UserUpdatePwd", userId: userId, oldPwd: oldPwd, newPwd: newPwd },
                                success: function (json) {
                                    if (json.result) {
                                        parent.layer.msg("密码修改成功！", 1, 1);
                                        setTimeout(function () {
                                            location.href = "/admin/login.aspx";
                                        }, 2000);
                                    } else {
                                        parent.layer.msg(json.msg, 1, 3);
                                    }
                                }
                            });
                        }  
                    });
                    $("#btnCancel").click(function () {
                        window.history.back();
                    });
                });
                function VerificationIsNull() { 
                    var newPwd = $("#newPwd").val();
                    var surePwd = $("#surePwd").val(); 
                    if (!$("#hidUserId").val()) {
                        layer.msg('非法进入！', 1, 3);
                        return false;
                    } 
                    if (!$("#oldPwd").val()) { 
                        layer.msg('请填写旧密码！', 1, 3); 
                        return false;
                    } 
                    if (!$("#newPwd").val()) {
                        layer.msg('请填写新密码！', 1, 3);
                        return false;
                    }
                    if (newPwd.trim() != surePwd.trim()) {
                        layer.msg('两次输入密码不一致！', 1, 3);
                        return false;
                    } 
                    return true;
                }
            </script>
        </div>
    </div>
</asp:Content>
