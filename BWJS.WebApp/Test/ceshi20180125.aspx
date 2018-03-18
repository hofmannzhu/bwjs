<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ceshi20180125.aspx.cs" Inherits="BWJS.WebApp.Test.ceshi20180125" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>获取经纬度和位置信息</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" class="form-horizontal mar-top1" role="form" runat="server">
        <div id="allmap"></div>
        <div class="col-lg-12 col-sm-12 col-xs-12">
            <div class="form-group">
                <label for="" class="col-lg-2 col-sm-2 col-xs-2 control-label"></label>
                <div class="col-lg-9 col-sm-9 col-xs-9">
                    <div id="spLocation"></div>
                </div>

            </div>
        </div>
        <script src="http://api.map.baidu.com/api?v=2.0&ak=TBHTGEjDi6X1MRIthT3TLFvo5Zy07IhK" type="text/javascript"></script>
        <%--<script src="http://api.map.baidu.com/api?v=1.2" type="text/javascript"></script>--%>
        <script src="/Scripts/NewSSKD/getLocation.js" type="text/javascript"></script>
        <script type="text/javascript">
            var msg = "";
            $(document).ready(function () {
                var msg = "";
                msg += JSON.stringify(getLocationJson()) + "<br />";
                msg += getLocation.getLocation() + "<br />";
                msg += getLocation.longitude + "<br />";
                msg += getLocation.latitude + "<br />";
                msg += getLocation.address + "<br />";
                msg += getLocation.addressObj + "<br />";
                $("#spLocation").html(msg);
            });
        </script>
    </form>
</body>
</html>
