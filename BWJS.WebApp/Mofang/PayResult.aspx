<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayResult.aspx.cs" Inherits="BWJS.WebApp.Mofang.PayResult" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/Mofang/mofanghelper.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css">
    <link rel="stylesheet" href="/Content/css/Mofang/main.css">
    <link rel="stylesheet" href="/Content/css/Mofang/font-awesome.min.css">
    <link rel="stylesheet" href="/Content/css/Mofang/templatemo_style.css">
    <title>支付结果</title>
    <script type="text/javascript">
        $(document).ready(function () {
            setTimeout(function () {//两秒后跳转   
                location.href = "/Product/Index?wd=0";//PC网页式跳转   
            }, 3500);
        });
    </script>
</head>
<body>
    <div class="main1">
        <%--<div class="back" onclick="javascript:history.go(-1)">返回</div>--%>
        <div class="zc-box">
            <div class="form-box ">
                <div class="group-box1 bg-a">
                    <form id="form1" runat="server">
                        <div class="clearfix"></div>

                        <div class="row bor">
                            <div class="col-md-4 pad">
                                <h4>支付状态：</h4>
                            </div>
                            <div class="col-md-4">
                                <asp:Literal ID="litSuccess" runat="server"></asp:Literal>
                            </div>
                        </div>

                        <div class="row bor">
                            <div class="col-md-4 pad">
                                <h4>支付金额：
                                </h4>
                            </div>
                            <div class="col-md-4">
                                <asp:Literal ID="litPrice" runat="server"></asp:Literal>
                            </div>
                        </div>




                        <div class="row bor">
                            <div class="col-md-4 pad">
                                <h4>保单号：
                                </h4>
                            </div>
                            <div class="col-md-4">
                                <asp:Literal ID="litBSId" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="row bor">
                            <div class="col-md-4 pad">
                                <h4>支付方式：</h4>
                            </div>
                            <div class="col-md-4">
                                <h4>
                                    <asp:Literal ID="litPayMethod" runat="server" Text="支付宝"></asp:Literal></h4>
                            </div>
                        </div>
                        <%--<div class="row bor">
                <div class="col-md-4 pad">
                    <h4>支付单号码：<asp:Literal ID="litPayOrderNumber" runat="server"></asp:Literal></h4>
                </div>
                <div class="col-md-4">
                </div>
            </div>--%>
                        <div class="row bor">
                            <div class="col-md-4 pad">
                                <h4>所属产品：</h4>
                            </div>
                            <div class="col-md-4">
                                <h4>
                                    <asp:Literal ID="litRemark" runat="server"></asp:Literal></h4>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
