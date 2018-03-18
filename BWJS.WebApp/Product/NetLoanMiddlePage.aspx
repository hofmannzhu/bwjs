<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetLoanMiddlePage.aspx.cs" Inherits="BWJS.WebApp.Product.NetLoanMiddlePage" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>
    <link rel="stylesheet" href="../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/main.css" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/pagecommon.js"></script>


    <script type="text/javascript">
        var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 
        function Rreturn() {
            setTimeout(function () {
                window.parent.location.reload();
                parent.layer.close(index);
            }, 1);
        }
        function copyText(num) {
            var obj;
            if (num == 1) {
                obj = document.getElementById("android");
            }
            else if (num == 2) {
                obj = document.getElementById("ios");
            }
            else {
                alert("非法操作！");
            }
            var rng = document.body.createTextRange();
            rng.moveToElementText(obj);
            rng.scrollIntoView();
            rng.execCommand("Copy");
            rng.collapse(false);
            alert("链接复制成功，可贴粘在您浏览器打开。");
        }
    </script>
    <script type="text/javascript">
        function androidDown() {
            var androidUrl = document.getElementById("androidUrl").value;
            if (androidUrl) {
                location.href = androidUrl;
            }
            else {
                return;
            }
        }
        function iosdDown() {
            var iosUrl = document.getElementById("iosUrl").value;
            if (iosUrl) {
                location.href = iosUrl;
            }
            else {
                return;
            }
        }
    </script>
</head>
<body style="background: #ddd">
    <% string AndroidURL = string.Empty;
        string IosURL = string.Empty;
        if (model != null)
        {
            AndroidURL = model.AndroidURL;
            IosURL = model.IosURL;
        }
    %>
    <input type="hidden" id="androidUrl" value="<%=AndroidURL %>" />
    <input type="hidden" id="iosUrl" value="<%=IosURL %>" />

    <form id="form1" runat="server">
        <%if (openTypeQR == 1) %>
        <%{ %>
        <div class="container">
            <div class="col-lg-12">
                <div class="col-lg-6 col-sm-6 col-xs-12" style="margin-bottom: 30px;">
                    <div onclick="androidDown()">
                        <img src="../Content/img/BWJS/android.png" class="thumbnail img-responsive" />
                        <p>
                            <button class="btn btn-danger">安卓下载</button>
                        </p>
                        <span style="color: red; font-size: 14px;">提示：若不能直接下载将以下链接复制到浏览器打开下载。</span><br />
                    </div>
                    安卓版链接：
            <input style="border: 0; width: 100%" class="form-control" id="android" readonly="readonly" value="<%=model.AndroidURL %>" />
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-12" style="margin-bottom: 30px;">
                    <div onclick="iosdDown()">
                        <img src="../Content/img/BWJS/iOS.png" class="thumbnail img-responsive" />
                        <p>
                            <button class="btn btn-danger">苹果下载</button>
                        </p>
                    </div>
                    <span style="color: red; font-size: 14px;">提示：若不能直接下载将以下链接复制到浏览器打开下载。</span><br />
                    苹果版链接：
            <input style="border: 0; width: 100%" id="ios" class="form-control" readonly="readonly" value="<%=model.IosURL %>" />

                </div>
            </div>
            <%} %>
            <%else%>
            <%{ %>
        </div>

        <div class="evmbox">

            <div class="evm-back" onclick="Rreturn()">返回</div>
            <%--//javascript:history.go(-1)--%>

            <img src="<%=QRImg %>" />
        </div>
        <%} %>
    </form>
</body>
</html>
