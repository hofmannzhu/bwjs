<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ceshi20171229.aspx.cs" Inherits="BWJS.WebApp.Test.ceshi20171229" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container list-inline ">
            <a id="open" class="btn btn-success btn-sm btn-next" href="javascript:void(0)" title="打开Loading">打开Loading</a>
            <a id="close" class="btn btn-danger btn-sm btn-next" href="javascript:void(0)" title="关闭Loading">关闭Loading</a>
            <asp:Button ID="btnUploadImg" runat="server" Text="image" CssClass="btn btn-default btn-sm btn-next" OnClick="btnUploadImg_Click"/>
        </div>
        <div class="modal fade" id="loading" tabindex="-1" role="dialog" aria-labelledby="loadingModalLabel" data-backdrop="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <img src="/Content/img/loadingsmall.gif" />
                        处理中，请稍候。。。
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#open").click(function () {
                    $("#loading").modal("show");
                });
                $("#close").click(function () {
                    $("#loading").modal("hide");
                });
            });
        </script>
    </form>
</body>
</html>
