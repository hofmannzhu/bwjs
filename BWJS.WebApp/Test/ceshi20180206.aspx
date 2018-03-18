<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ceshi20180206.aspx.cs" Inherits="BWJS.WebApp.Test.ceshi20180206" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Baidu JavaScript API v3.0</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/email.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.query-2.1.7.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="inpText1" name="inpText1" autocomplete="off" />
            <br />
            <input id="btnLayerOpen" type="button" value="layeropen" class="btn btn-default" />
            <br />
            <input id="btnRedirect" type="button" value="redirect" class="btn btn-default" />
        </div>
        <div id="allmap"></div>
        <script src="http://api.map.baidu.com/api?v=3.0&ak=TBHTGEjDi6X1MRIthT3TLFvo5Zy07IhK" type="text/javascript"></script>
        <script type="text/javascript">
            //var map = new BMap.Map("allmap");
            //var point = new BMap.Point(116.331398, 39.897445);
            //map.centerAndZoom(point, 12);

            //var geolocation = new BMap.Geolocation();
            //// 开启SDK辅助定位
            //geolocation.enableSDKLocation();
            //geolocation.getCurrentPosition(function (r) {
            //    if (this.getStatus() == BMAP_STATUS_SUCCESS) {
            //        var mk = new BMap.Marker(r.point);
            //        map.addOverlay(mk);
            //        map.panTo(r.point);
            //        myAlert('您的位置：' + r.point.lng + ',' + r.point.lat);
            //        myAlert(getAddressByLocation(r.point.lng, r.point.lat, "json", 0));
            //    }
            //    else {
            //        myAlert('failed' + this.getStatus());
            //    }
            //});
            var index = -1;
            var canSubmit = false;
            $(document).ready(function () {
                //authStateCheck();

                $("#btnLayerOpen").bind("click", function () {
                    //index = layer.open({
                    //    type: 2,
                    //    content: "/Test/ceshi20180206.aspx",
                    //    area: ['640px', '480px'],
                    //    maxmin: true,
                    //    title: "授权认证"
                    //});
                    //layer.full(index);
                    //alert(index);

                    layer.open({
                        type: 2,
                        area: ['700px', '450px'],
                        maxmin: true,
                        content: "/Test/ceshi20180206.aspx",
                        title: "授权认证"
                    });

                });
                $("#btnRedirect").bind("click", function () {
                    window.location.href = "/Test/ceshi20180206.aspx?i=1&userId=193&outUniqueId=26772a40-9925-4726-a03c-9b2e04e082c1&state=login";
                });

                var userId = $.query.get("userId");
                var outUniqueId = $.query.get("outUniqueId");
                var state = $.query.get("state");
                if (state != null && state != "") {
                    if (state == "report" || state == "login" || state == "crawl") {
                        var i = $.query.get("i");
                        if (i != null && i != "") {
                            canSubmit = true;
                            var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
                            parent.layer.close(index);
                            parent.authStateCheck();
                        }
                    }
                }

            });
            var authStateCheckTimer;
            function authStateCheck() {
                if (canSubmit) {
                    clearTimeout(authStateCheckTimer);
                    bwjsLoadingClose();
                }
                else {
                    bwjsLoadingDemo("努力加载中...");
                    authStateCheckTimer = setTimeout(function () {
                        authStateCheck();
                    }
                    , 10000)
                }
            }
        </script>
    </form>
</body>
</html>
