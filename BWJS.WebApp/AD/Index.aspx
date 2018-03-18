<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BWJS.WebApp.AD.Index" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" /> 
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery.soChange-min.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <title></title>
    <!--2017/10/31日 张建永修改：修改了原来固定大小屏幕为目前响应式，广告图片和窗口能够在再不同分辨率下100%显示-->
    <style>
        body, html {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        #banner {
            overflow: hidden;
        }

            #banner .m-banner {
                position: fixed;
                float: left;
                width: 100%;
                height: 100%;
            }

            #banner .change-box div {
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
            }

            #banner .change-box img {
                width: 100%;
                height: 100%;
            }

            #banner .lunBoNmb {
                position: absolute;
                bottom: 2px;
                right: 3%;
            }

            #banner .m-banner .pm-slide-a {
                position: fixed;
                width: 100%;
                height: 100%;
                top: 0;
                left: 0;
            }

            #banner .lunBoNmb li {
                float: left;
                list-style-type: none;
            }

            #banner .lunBoNmb span {
                display: block;
                width: 17px;
                height: 17px;
                background: #fff;
                border-radius: 50%;
                margin-left: 25px;
            }

                #banner .lunBoNmb span:hover {
                    cursor: pointer;
                }

                #banner .lunBoNmb span.on {
                    background: red;
                }
    </style>
</head>
<script type="text/javascript">    //window.location.reload(); 
    $(document).ready(function () {
        getNewData();
        window.onload =
            function () {
                setInterval(function () {
                    $.ajax({
                        type: "GET",
                        async: false,
                        dataType: "text",
                        url: "/Ajax/BWJS/HPageRefresh.ashx?r=" + Math.random(),
                        success: function (data) {
                            if (data == "OnLine") {
                                window.location.reload();
                            }
                        }
                    });
                }, parseInt('<%=adRefreshTime%>'));
            };
    });
            function timedata() {
                $('.m-banner .change-box div').soChange({
                    thumbObj: '.m-banner .lunBoNmb span',
                    thumbNowClass: 'on',
                    overStop: true,
                    changeTime: 3000
                });
            }
            function getNewData() {
                GetList();
                timedata();
            }
            function GetList() {
                $.ajax({
                    type: "GET",
                    async: false,
                    dataType: "json",
                    url: "../Ajax/Admin/HAdRelease.ashx?r=" + Math.random(),
                    data: { Action: "GetAdPostionReleaseList", typeId: 1 },
                    success: function (data) {
                        var htmlData = "";
                        var lunBoNmbData = "";
                        var classdata = "";
                        var lengtht = data.length;
                        if (data != null) {
                            for (var k = 0; k < lengtht; k++) {
                                if ('<%=u%>' == "1") {
                                    htmlData += "<div><a href=\"javascript:;\" class=\"pm-slide-a\"><img src='" + data[k].DefaultPicUrl + "'   alt=\"\"/></a></div>";
                                } else {
                                    htmlData += "<div><a href=\"javascript:;\" class=\"pm-slide-a\"><img src='" + data[k].FilePath + "'   alt=\"\"/></a></div>";
                                }
                                if (k == 0) {
                                    classdata = "'class=on'";
                                } else {
                                    classdata = "";
                                }
                                lunBoNmbData += " <li  " + classdata + "><span></span></li>";
                            }
                            $("#showFilePathID").html(htmlData);
                            $("#lunBoNmbData").html(lunBoNmbData);
                        }
                    }
                });
            }
</script>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="banner">
                <div class="m-banner">
                    <div class="change-box" id="showFilePathID">
                    </div>
                    <ul class="lunBoNmb" id="lunBoNmbData">
                    </ul>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
