<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClosePage.aspx.cs" Inherits="BWJS.WebPad.Product.NewSSKD.ClosePage" %>
 <script src="/Scripts/pagecommon.js"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
        <link rel="stylesheet" href="/Content/css/bootstrap.min.css" />
     <link rel="stylesheet" href="/Content/css/NewSSKD/main.css" />
    <title></title>
</head>
<body>

    <div class="win-pop">
        <div class="col-lg-12 col-sm-12 col-xs-12">
            <div class="col-lg-3 col-sm-3 col-xs-3">
            </div>
            <div class="col-lg-6 col-sm-6 col-xs-6 text-center mar" >
                <img   src="../../../Content/img/NewSSKD/pic-jg.jpg" class="thumbnail img-responsive jg">
            </div>
            <div class="col-lg-3 col-sm-3 col-xs-3">
            </div>
        </div>

    <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
        <span class="ts-msg1"><i style="color:rgb(250, 97, 19); font-style:normal">温馨提示：</i>点击右上角关闭按钮关闭页面</span>
    </div>
  
</div>
</body>
</html>

<script type="text/javascript">

    function ClosePage() {
        window.close();
    }

</script>

