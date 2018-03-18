<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagerAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.UserManagerAdd" %>

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
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">所属部门：</div>
                        </div>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="drpDepartmentInfoID" runat="server" class="form-control" Style="width: 98%"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">所属商户：</div>
                        </div>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="DropDownSupplierInfo" runat="server" class="form-control" Style="width: 98%"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="margin-top: 4px;">
                                <div class="col-md-4 text-right">登录名：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="LoginNameId" name="LoginName" class="form-control" placeholder="请填写用户名" required data-msg-required="必填" data-msg-age="请填写用户名" /><em>*</em>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="margin-top: 4px;">
                                <div class="col-md-4 text-right">真实姓名：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="UserNameId" name="UserName" class="form-control" placeholder="请填写您的真实姓名" /><em>*</em>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="form-group" id="IsShow">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">密码：</div>
                        </div>
                        <div class="col-sm-10">
                            <input class="form-control" type="password" id="passwordId" name="password" value="" placeholder="请填写您的密码" required data-rule-remote="" style="width: 98%"><em>*</em>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">身份证号：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" id="CardID" value="" name="2" class="form-control" placeholder="请填写您的18位身份证号" style="width: 98%" /><em>*</em>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">性别：</div>
                        </div>
                        <div class="col-sm-10">
                            <label>
                                <input name="Sex" type="radio" value="1" id="radio1" checked>
                                男</label>
                            <label>
                                <input name="Sex" type="radio" value="0" id="radio0">
                                女</label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">手机号：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="PhoneId" name="Phone" class="form-control" placeholder="请填写您的11位电话号码" style="width: 98%" /><em>*</em>
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
                                <input type="text" value="" id="QQId" name="QQ" class="form-control" placeholder="请填写您的QQ号" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="margin-top: 4px;">
                                <div class="col-md-4 text-right">微信号：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="WechatId" name="Wechat" class="form-control" placeholder="请填写您的微信号" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">邮箱：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="EmailId" name="Email" class="form-control" placeholder="请填写您的邮箱" data-msg-required="必填" data-msg-age="邮箱格式不正确" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-2" style="margin-top: 4px; margin-left: -33px">
                        <div class="col-md-4 text-right">分润类型：</div>
                    </div>
                    <div class="col-sm-10">
                        <label>
                            <input name="UserType" type="radio" value="1" id="UserType1">
                            管理员</label>
                        <label>
                            <input name="UserType" type="radio" value="2" id="UserType2" checked>
                            经销商</label>
                        <label>
                            <input name="UserType" type="radio" value="3" id="UserType3">
                            代理商</label>

                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-2" style="margin-top: 10px; margin-left: -33px">
                        <div class="col-md-4 text-right">所在城市：</div>
                    </div>
                    <div class="col-sm-10">
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-2" style="margin-top: 4px;">
                                    <div class="col-md-4 text-right">省：</div>
                                </div>
                                <div class="col-sm-9">
                                    <select name="SeleCity1" id="SeleCity1" class="form-control" onchange="if(this.value != '') GetSeleCity2(this.value);" style="width: 90%"></select>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-2" style="margin-top: 4px;">
                                    <div class="col-md-4 text-right">市：</div>
                                </div>
                                <div class="col-sm-9">
                                    <select id="SeleCity2" name="SeleCity2" class="form-control" onchange="if(this.value != '') GetSeleCity3(this.value);" style="width: 90%"></select>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-4" style="margin-top: 4px;">
                                    <div class="col-md-4 text-right">县(区)：</div>
                                </div>
                                <div class="col-sm-8">
                                    <select id="SeleCity3" name="SeleCity3" class="form-control" style="width: 93%"></select>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">详细地址：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="AddressId" name="Address" class="form-control" placeholder="请填写详细地址" style="width: 98%" />
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
            <input type="hidden" id="hidUserID" name="UserID" value="0" />
            <input type="hidden" id="hidRecordUpdateTime" name="RecordUpdateTime" value="" />
        </form>

    </div>
</body>
</html>
<script type="text/javascript">
    var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 
    $(document).ready(function () {
        $('#SeleCity1').html('<%=strCityAreaTree%>');
        if (<%=UserID%> > 0) {
            EditData();
        }
        var inputText = document.getElementById('LoginNameId');
        inputText.onblur = function () {
            var LoginName = document.getElementById('LoginNameId').value;
            if (LoginName.length>20||LoginName.length<5 ){
                layer.msg('用户名长度在5-20之间,请重新填写用户名！',2,3,function(){
                    $("#LoginNameId").val("");
                })
            }else{
                var un = /^\w+$/;
                if (!un.test($("#LoginNameId").val())) {
                    layer.msg('用户名只能为字母、数字或下划线的组合,请重新填写用户名！',2,3,function(){
                        $("#LoginNameId").val("");
                    })
                    return false;
                }else{
                    $.ajax({
                        type: "GET",
                        async: false,
                        dataType: "text",
                        url: "../Ajax/Admin/UserManager.ashx?r=" + Math.random(),
                        data: { Action: "VerificationIsUserName", LoginName: LoginName},
                        success: function (data) {
                            if (data > 0) {
                                layer.msg('该用户名已经注册,请重新填写用户名！',2,3,function(){
                                    $("#LoginNameId").val("");
                                })

                                return false;
                            } else {
                                return true;
                            }
                        }
                    });
                }
            }
        }
    });


    function GetSeleCity2() {
        setSelectOption('SeleCity2', $('#SeleCity1').val(), '-请选择-');
    }

    function GetSeleCity3() {
        setSelectOption('SeleCity3', $('#SeleCity2').val(), '-请选择-');
    }


    
    function setSelectOption(selectObj, optionList, firstOption) {
        if (typeof selectObj != 'object') {
            selectObj = document.getElementById(selectObj);
        }
        // 清空选项
        removeOptions(selectObj);
        // 选项计数
        var start = 0;
        // 如果需要添加第一个选项
        if (firstOption) {
            selectObj.options[0] = new Option(firstOption, '');
            GetCityArea(selectObj,optionList);
        }
    }

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


    function GetCityArea(selectObj,ParentID) {
        $.ajax({
            type: "GET",
            async: false,
            dataType: "text",
            url: "../Ajax/BWJS/HCityArea.ashx?r=" + Math.random(),
            data: { Action: "GetCityArea", ParentID: ParentID },
            success: function (data) {
                $(selectObj).html(data);
            }
        });
    } 


    function ReturnList() {
        parent.layer.close(index);
    }

    function EditData() {
        var videoBtn = document.getElementById("SubmitID");
        videoBtn.innerHTML = "修改";
        if (<%=UserID%> > 0) {
            $("#IsShow").hide();
            $.ajax({
                type: "GET",
                async: false,
                dataType: "json",
                url: "../Ajax/Admin/UserManager.ashx?r=" + Math.random(),
                data: { Action: "GetUsersOne", UsersID: <%=UserID%> },
                success: function (data) {
                    $('#SeleCity1').html('<%=strCityAreaTree%>');
                    $("#hidUserID").val(<%=UserID%>);
                    $("#LoginNameId").val(data.LoginName);
                    $("#passwordId").val(data.Password);
                    $("#UserNameId").val(data.UserName);
                    $("#CardID").val(data.CardID);
                    if (data.Sex == 1) {
                        $("#radio1").attr('checked', 'checked');
                    } else {
                        $("#radio0").attr('checked', 'checked');
                    }
                    $("#PhoneId").val(data.Phone);
                    $("#QQId").val(data.QQ);
                    $("#WechatId").val(data.Wechat);
                    $("#EmailId").val(data.Email);
                    $("#AddressId").val(data.Address);
                    if (data.UserType == 1) {
                        $("#UserType1").attr('checked', 'checked');
                    } else if(data.UserType == 2){
                        $("#UserType2").attr('checked', 'checked');
                    }else if(data.UserType == 3){
                        $("#UserType3").attr('checked', 'checked');
                    }
                    $("#hidRecordUpdateTime").val(data.RecordUpdateTime);
                    $("#SeleCity1").val(data.ProvinceID);
                    GetSeleCity2( $("#SeleCity1").val());
                    $("#SeleCity2").val(data.CityID);
                    GetSeleCity3( $("#SeleCity2").val());
                    $("#SeleCity3").val(data.CountyID);
                    $("#<%=drpDepartmentInfoID.ClientID%>").val(data.DepartmentID);
                    $("#<%=DropDownSupplierInfo.ClientID%>").val(data.SId);
                    
                }
            });
        }
    }
     
    function VerificationIsNull(){
        var b=true;
        if ($("#LoginNameId").val()=="") {
            layer.msg('用户名不能为空！', 1,3); 
            b= false;
            return;
        };
        if ($("#passwordId").val()=="") {
            layer.msg('密码不能为空！', 1,3); 
            b= false;
            return;
        }else{
            if(($("#passwordId").val().length>20)||($("#passwordId").val().length<6)){
                layer.msg('密码长度在6-20之间,请重新填写！', 1,3); 
                b= false;
                return;
            }
        }
        if ($("#UserNameId").val()=="") {
            layer.msg('真实姓名不能为空！', 1,3); 
            b= false;
            return;
        }else{
            if($("#UserNameId").val().length>20){
                layer.msg('真实姓名长度在1-20之间，请重新填写！', 1,3); 
                b= false;
                return;
            }
        }
        if ($("#CardID").val()=="") {
            layer.msg('身份证号不能为空！', 1,3); 
            b= false;
            return;
        }else{
            var isIDCard2 = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;//(18位)
            var lengthvalue = document.getElementById('CardID').value.length;
            if (lengthvalue == 18) {
                if (isIDCard2.test(document.getElementById('CardID').value) === false) {
                    layer.msg('身份证输入不合法,请重新填写!',2,3,function(){
                        $("#CardID").val("");
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
        if ($("#PhoneId").val()=="") {
            layer.msg('手机号不能为空！', 1,3); 
            b= false;
            return;
        }else{
            var isIDCard2 =/^1[3|4|5|7|8][0-9]{9}$/; //验证规则
            var lengthvalue = document.getElementById('PhoneId').value.length;
            if (lengthvalue == 11) {
                if (isIDCard2.test(document.getElementById('PhoneId').value) === false) {
                    layer.msg('手机号输入不合法,请重新填写!',2,3,function(){
                        $("#PhoneId").val("");
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
        if ($("#EmailId").val()!=""&&$("#EmailId").val()!=null) {
            var isIDCard2 =/^[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/; 
           
            if (isIDCard2.test(document.getElementById('EmailId').value) === false) {
                layer.msg('邮箱输入不合法,请重新填写!',2,3,function(){
                    $("#EmailId").val("");
                })
                b= false;
                return;
            }
        }
        return  b;
    }

    function Submit() {
        var strmsg='添加';
        var useridnum=<%=UserID%>;
        if (  useridnum > 0) {
            strmsg='修改';
        }
        if (VerificationIsNull()) {
            var UserID = $("#hidUserID").val();
            $.ajax({
                type: "GET",
                async: false,
                dataType: "text",
                url: "../Ajax/Admin/UserManager.ashx?r=" + Math.random(),
                data: { Action: "AddUser", UserID: <%=UserID%>,UsersModel: JSON.stringify(usersmodel()) },
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

    //设置合同信息
    function UsersInfo() {
        this.UserID = "";
        this.LoginName = "";
        this.Password = "";
        this.UserName = "";
        this.CardID = "";
        this.Sex = "";
        this.Phone = "";
        this.QQ = "";
        this.Wechat = "";
        this.Email = "";
        this.UserType = "";
        this.GravatarResourceID = "";
        this.CityID = "";
        this.LastAccessIP = "";
        this.CompanyName = "";
        this.CreatUserID = "";
        this.RecordUpdateUserID = "";
        this.RecordIsDelete = "";
        this.RecordUpdateTime = "";
        this.RecordCreateTime = "";
        this.ProvinceID = "";
        this.CityID= "";
        this.CountyID = "";
        this.Address = "";   
        this.DepartmentID=0;
        this.SId=""; 
    } 
    function usersmodel() {
        var usersInfo = new UsersInfo();
        usersInfo.UserID = $("#hidUserID").val();
        usersInfo.LoginName = $("#LoginNameId").val();
        usersInfo.Password = $("#passwordId").val();
        usersInfo.UserName = $("#UserNameId").val();
        usersInfo.CardID = $("#CardID").val();
        usersInfo.Sex = $("input[name='Sex']:checked").val();
        usersInfo.Phone = $("#PhoneId").val();
        usersInfo.QQ = $("#QQId").val();
        usersInfo.Wechat = $("#WechatId").val();
        usersInfo.Email = $("#EmailId").val();
        usersInfo.UserType = $("input[name='UserType']:checked").val();
        usersInfo.LastAccessIP = "";
        usersInfo.CompanyName = "";
        usersInfo.CreatUserID = <%=LoginUserID%>;
        usersInfo.RecordUpdateUserID = <%=LoginUserID%>;
        usersInfo.RecordIsDelete = 0;
        usersInfo.RecordIsDelete = 0;
        usersInfo.RecordUpdateTime ='<%=System.DateTime.Now %>';
            usersInfo.RecordCreateTime = '<%=System.DateTime.Now %>';
        usersInfo.ProvinceID = (($("#SeleCity1").val()=="")||($("#SeleCity1").val()==null))?0:$("#SeleCity1").val();
        usersInfo.CityID=($("#SeleCity2").val()==""||$("#SeleCity2").val()==null)?0:$("#SeleCity2").val();
        usersInfo.CountyID = ($("#SeleCity3").val()==""||$("#SeleCity3").val()==null)?0:$("#SeleCity3").val();
        usersInfo.Address = $("#AddressId").val();
        usersInfo.DepartmentID= $("#drpDepartmentInfoID").val();
        usersInfo.SId= $("#DropDownSupplierInfo").val(); 
        return usersInfo;
    }
   
</script>
