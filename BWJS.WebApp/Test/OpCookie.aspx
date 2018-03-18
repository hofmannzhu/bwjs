<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpCookie.aspx.cs" Inherits="BWJS.WebApp.Test.OpCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title></title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 text-right">ajaxLoading</div>
                <div class="col-lg-7">
                    <a id="btnWrite" class="btn btn-success btn-sm btn-next" href="javascript:void(0)" title="writecookie">writecookie</a>
                    <a id="btnGet" class="btn btn-danger btn-sm btn-next" href="javascript:void(0)" title="getcookie">getcookie</a>
                    <asp:Button ID="btnClearCookie" runat="server" Text="clearcookie" CssClass="btn btn-default btn-sm btn-next" OnClick="btnClearCookie_Click" />
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#btnWrite").click(function () {
                    writecookie();
                });

                $("#btnGet").click(function () {
                    getcookie();
                });
            });

            function writecookie() {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "test";
                paramter.action = "writecookie";
                var json = getJson(paramter, false);
                myAlert(JSON.stringify(json));
                if (json.success) {

                }
                else {
                    myAlert(json.message);
                }
            }
            function getcookie() {
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "test";
                paramter.action = "getcookie";
                var json = getJson(paramter, false);
                myAlert(JSON.stringify(json));
                if (json.success) {

                }
                else {
                    myAlert(json.message);
                }
            }
        </script>
    </form>
</body>
</html>
