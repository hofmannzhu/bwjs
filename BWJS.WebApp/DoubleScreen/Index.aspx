<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BWJS.WebApp.DoubleScreen.Index" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>
    <!--添加日期：2017年10月31日 添加人：张建永 双屏下让不同IFRAME的高能够按百分比显示这样就能控制各个iframe窗口的高-->
    <style>
        body, html {
            margin: 0;
            padding: 0;
            width: 100%;
            height: 98%;
        }

        #adframeId {
            position: fixed;
            left: 0;
            top: 0;
            height: 30%;
        }

        #productframeId {
            position: fixed;
            left: 0;
            top: 31%;
            height: 70%;
        }

        .line-box {
            position: fixed;
            top: 30%;
            width: 100%;
            height: 1%;
            background: #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <iframe name="adframe" id="adframeId" src="/AD/Index" width="100%" frameborder="0" scrolling="0"></iframe>
            <div class="line-box"></div>
            <iframe name="productframe" id="productframeId" src="/Product/Index?wd=0" width="100%" frameborder="0" scrolling="0"></iframe>
        </div>
    </form>
</body>
</html>
