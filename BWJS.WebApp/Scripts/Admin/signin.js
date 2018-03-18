



$(document).ready(function () {
    $("#inpUid").keydown(function (e) {
        if (e.keyCode == 13) {
            login_submit();
        }
    });
    //$("#inpUid").blur(function () {
    //    usernameBlur();
    //});
    $("#inpPwd").keydown(function (e) {
        if (e.keyCode == 13) {
            login_submit();
        }
    });
    $("#inpbtnSignIn").click(function () {
        login_submit();
    });
});

function login_submit() {
    if ($.trim($("#inpUid").val()) == "请输入用户名" || $.trim($("#inpUid").val()) == "") {
        layer.alert("请输入用户名");
        //$("#inpUid").focus();
        return false;
    }
    //else {
    //    usernameBlur();
    //}
    if ($.trim($("#inpPwd").val()) == "") {
        layer.alert("请输入密码");
        //$("#inpPwd").focus();
        return false;
    }
    if ($.trim($("#inpUid").val()) != "" && $.trim($("#inpPwd").val()) != "") {
        try {
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "gl";
            paramter.action = "signin";
            paramter.inpUid = $.trim($("#inpUid").val());
            paramter.inpPwd = $.trim($("#inpPwd").val());
            paramter.timeStamp = new Date().getTime();
            $.ajax({
                type: "POST",
                url: "/Ajax/helper.ashx",
                data: paramter,
                dataType: "json",
                async: false,
                success: function (json) {
                    if (json.result) {
                        window.location.href = "/Admin/default.aspx";
                    }
                    else {
                        layer.alert(json.msg);
                    }
                },
                error: function () { layer.alert("服务器没有返回数据，可能服务器忙，请重试"); }
            });
        }
        catch (e) { layer.alert(e.message); }
    }
}

function usernameBlur() {
    //登录名
    if ($.trim($("#inpUid").val()) != "请输入用户名" && $.trim($("#inpUid").val()) != "") {

        var un = /^\w+$/;
        if (!un.test($("#inpUid").val())) {
            //$("#inpUid").focus();
            layer.alert("输入错误，用户名只能为字母、数字或下划线的组合");
            return false;
        }
        else {
            var ulen = $("#inpUid").val().length;
            if (ulen < 5 || ulen > 20) {
                //$("#inpUid").focus();
                layer.alert("输入限制，用户名长度必须在5至20位之间");
                return false;
            }
            //else {
            //    var json = checkUserName($("#inpUid").val());
            //    if (json.result) {
            //        $("#inpUid").focus();
            //        alert("登录名不存在");
            //        return false;
            //    }
            //}
        }
    }
}

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