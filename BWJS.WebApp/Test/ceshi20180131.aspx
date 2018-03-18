<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ceshi20180131.aspx.cs" Inherits="BWJS.WebApp.Test.ceshi20180131" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>邮箱输入自动提醒</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/email.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1">
        <div class="col-lg-12 col-sm-12 col-xs-12">
            <div class="form-group">
                <label for="inpEmail" class="col-lg-2 col-sm-2 col-xs-2 control-label"></label>
                <div class="col-lg-9 col-sm-9 col-xs-9 ">
                    <input type="email" id="inpEmail" name="inpEmail" class="form-control" placeholder="请输入邮箱" required="" autofocus="" autocomplete="off" />
                </div>
            </div>
            <div class="form-group">
                <label for="Text1" class="col-lg-2 col-sm-2 col-xs-2 control-label"></label>
                <div class="col-lg-9 col-sm-9 col-xs-9">
                    <input id="Text1" type="text" class="form-control" autocomplete="off" />
                </div>
            </div>
            <div class="form-group">
                <label for="Text2" class="col-lg-2 col-sm-2 col-xs-2 control-label"></label>
                <div class="col-lg-9 col-sm-9 col-xs-9">
                    <input id="Text2" type="text" class="form-control" value="" autocomplete="off" />
                </div>
            </div>
            <div class="form-group">
                <label for="Text3" class="col-lg-2 col-sm-2 col-xs-2 control-label"></label>
                <div class="col-lg-9 col-sm-9 col-xs-9">
                    <input id="Text3" type="text" class="form-control" value="" autocomplete="off" />
                </div>
            </div>
        </div>
        <script src="/Scripts/jquery.autocomplete.js"></script>
        <script src="/Scripts/jquery.mailAutoComplete-4.0.js"></script>
        <script type="text/javascript">
            $("#inpEmail").mailAutoComplete();

            $("#Text1").autocomplete({});

            $(document).ready(function () {
                var index = layer.open({
                    type: 2,
                    content: "https://www.baidu.com",
                    area: ['320px', '195px'],
                    maxmin: true
                });
                layer.full(index);

                $("#Text2").val(bankCardNoSplit("6217000010116354088"));
                $("#Text1").val(bankCardNoTrim($.trim($("#Text2").val()), "g"));
                $("#Text2").bind("keyup", function () {
                    $(this).val(bankCardNoSplit($(this).val()));
                });
                
                $("#Text3").bind("blur", function () {
                    var temp = $(this).val().replace(/[\w]/, '');
                    alert(temp);
                    $(this).val(temp);

                    //if (!realnameReg.test($(this).val()))
                    //{
                    //    var temp = $(this).val().replace(/[^\w]/, '');
                    //    alert(temp);
                    //    $(this).val(temp);
                    //}
                });
            });

        </script>
    </form>
</body>
</html>
