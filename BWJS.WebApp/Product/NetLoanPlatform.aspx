<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetLoanPlatform.aspx.cs" Inherits="BWJS.WebApp.Product.NetLoanPlatform" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="../Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/css/Mofang/main.css" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <title></title>
</head>
<body>
    <div class="main1">
        <div class="zc-box">
            <form id="form1" runat="server">
                <div class="leftbox">
                    <div class="back" onclick="javascript:history.go(-1)">返回</div>
                </div>
                <div class="form-box">
                    <div class="wdbox text-center" style="display: block;">
                        <h1>专属5位推荐码(<asp:Literal ID="litRecommendationCode" runat="server"></asp:Literal>)</h1>
                        <iframe id="ifNetLoan" name="ifNetLoan" frameborder="0" src="http://hhtycf.com/" height="700px" width="100%"></iframe>
                        <%--<a href="http://hhtycf.com/" target="_self">马上去贷款</a>--%>
                    </div>
                </div>
            </form>
            <div class="footer">
                <span class="logo"></span>
                <div class="adm-box">商家管理员：<%=loginUserName %></div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#ifNetLoan").attr("src", "http://hhtycf.com/");
            //window.open("http://hhtycf.com/");
        });
    </script>
</body>
</html>
