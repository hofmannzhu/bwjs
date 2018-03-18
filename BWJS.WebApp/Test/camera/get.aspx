<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="get.aspx.cs" Inherits="BWJS.WebApp.Test.camera.get" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
</head>
<body>
    <form class="form-horizontal" role="form" id="form1" runat="server">
        <ul class="list-unstyled">
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpBankCodeForInput">身份证正面：</label>
                <div class="col-sm-6">
                    <img id="img1" alt="140x140" src="" onerror="this.src='/Content/img/Admin/people3.png'" style="width: 140px; height: 140px;" />
                    <a class="btn btn-info" data-toggle="modal" data-target="#cameraModal" data-id="1" title="拍照"><span class="glyphicon glyphicon-camera"></span>拍照</a>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpOpeningBankForInput">身份证反面：</label>
                <div class="col-sm-6">
                    <img id="img2" alt="140x140" src="" onerror="this.src='/Content/img/Admin/people3.png'" style="width: 140px; height: 140px;" />
                    <a class="btn btn-info" data-toggle="modal" data-target="#cameraModal" data-id="2" title="拍照"><span class="glyphicon glyphicon-camera"></span>拍照</a>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpCardHolderForInput">手持身份证：</label>
                <div class="col-sm-6">
                    <img id="img3" alt="140x140" src="" onerror="this.src='/Content/img/Admin/people3.png'" style="width: 140px; height: 140px;" />
                    <a class="btn btn-info" data-toggle="modal" data-target="#cameraModal" data-id="3" title="拍照"><span class="glyphicon glyphicon-camera"></span>拍照</a>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpCardNumberForInput">脸部正面：</label>
                <div class="col-sm-6">
                    <img id="img4" alt="140x140" src="" onerror="this.src='/Content/img/Admin/people3.png'" style="width: 140px; height: 140px;" />
                    <a class="btn btn-info" data-toggle="modal" data-target="#cameraModal" data-id="4" title="拍照"><span class="glyphicon glyphicon-camera"></span>拍照</a>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpBankAddressForInput">脸部侧面：</label>
                <div class="col-sm-6">
                    <img id="img5" alt="140x140" src="" onerror="this.src='/Content/img/Admin/people3.png'" style="width: 140px; height: 140px;" />
                    <a class="btn btn-info" data-toggle="modal" data-target="#cameraModal" data-id="5" title="拍照"><span class="glyphicon glyphicon-camera"></span>拍照</a>
                </div>
            </li>
            <li class="form-group">
                <div class="col-sm-12 text-center">
                    <button id="btnSubmit" type="button" class="btn btn-success btn-group-lg">提 交</button>
                    <button id="btnReset" type="reset" class="btn btn-danger btn-group-lg">重 置</button>
                    <button id="btnClose" type="button" class="btn btn-danger btn-group-lg" data-dismiss="modal">关 闭</button>
                </div>
            </li>
        </ul>
    </form>
    <input id="hiddId" name="hiddId" type="hidden" value="1" />
    <div class="modal fade" id="cameraModal" data-backdrop="false" tabindex="-1" role="dialog" aria-labelledby="cameraModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel1">拍照</h4>
                </div>
                <div class="modal-body">
                    <!-- FLASH调用 -->
                    <div id="FalshDiv" style="text-align: center; display: none;">
                        <object style="z-index: 10001" id="My_Cam" align="middle" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
                            codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0"
                            height="400" viewastext="在线拍照" width="500">
                            <param name="allowScriptAccess" value="sameDomain" />
                            <param name="movie" value="/Test/camera/js/MyCamera.swf" />
                            <param name="quality" value="high" />
                            <param name="bgcolor" value="#ffffff" />
                            <param name="wmode" value="transparent" />
                            <embed style="z-index: 10001" align="middle" allowscriptaccess="sameDomain" bgcolor="#ffffff" height="400"
                                name="My_Cam" pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high" wmode="transparent"
                                src="/Test/camera/js/MyCamera.swf" type="application/x-shockwave-flash" width="500"></embed>
                        </object>
                    </div>
                    <div>
                        <img style="width: 320px; height: 240px;" id="showImg" />
                    </div>
                    <!-- HTML5调用 -->
                    <div id="HTML5Div" style="text-align: center; display: none;">
                        <video id="video" width="500" height="400" autoplay></video>
                        <canvas id="canvas" width="500" height="400" style="display: none;"></canvas>
                    </div>
                    <!-- 执行按钮 -->
                    <div align="center" id="secondPageBT">
                        <input id="takePhoto" type="button" value="拍 照" onclick="photo()" class="btn btn-sm btn-primary" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnConfirmation" type="button" class="btn btn-sm btn-primary" data-dismiss="modal">确 认</button>
                    <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">关 闭</button>
                </div>
            </div>
        </div>
    </div>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.query-2.1.7.js" type="text/javascript"></script>
    <script src="/Scripts/Admin/m1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#cameraModal")
                .on('show.bs.modal', function (e) {
                })
                .on('shown.bs.modal', function (e) {
                    $("#showImg").attr("src", "");
                    var op = $(e.relatedTarget);
                    var id = op.data("id");
                    if (id != undefined) {
                        $("#hiddId").val(id);
                    }
                    initCamera();
                })
                .on('hide.bs.modal', function () {
                })
                .on('hidden.bs.modal', function () {
                });
            $("#btnConfirmation").click(function () {

            });
        });
    </script>
    <script type="text/javascript">
        var isBrowser;
        function initCamera() {
            $("#takePhoto").button()
              .click(function (event) {
                  event.preventDefault();
              });
            //判断浏览器
            isBrowser = doVerificationBrowser();
            //根据浏览器不同使用不同方法调用摄像头
            if (isBrowser) {
                $("#FalshDiv").show();
            } else {
                //判断浏览器是否 支持HTML5
                if (checkHtml5()) {
                    $("#HTML5Div").show();
                    doHtml5();
                }
            }
        }
        /**
         * 检查摄像头是否存在
         */
        function checkCamera() {
        }
        /**
         * 检测浏览器是否兼容HTML5
         */
        function checkHtml5() {
            return !!document.createElement("video").canPlayType;
        }
        /**
         *  判断浏览器是否为IE或者其他浏览器
         */
        function doVerificationBrowser() {
            var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串
            //判断浏览是否为IE
            if (!!window.ActiveXObject || "ActiveXObject" in window || userAgent.indexOf("trident") > -1) {
                return true;
            } else {
                return false;
            }
        }
        /**
         * 使用HTML5调用摄像头拍摄照片(适用于非IE浏览器)
         */
        var canvas, context, video, videoObj, errBack;
        function doHtml5() {
            //Put event listeners into place
            window.addEventListener("DOMContentLoaded", function () {
                // Grab elements, create settings, etc.
                canvas = document.getElementById("canvas"),
                context = canvas.getContext("2d"),
                video = document.getElementById("video"),
                videoObj = { "video": true },
                errBack = function (error) {
                    console.log("Video capture error: ", error.code);
                };
                // Put video listeners into place
                if (navigator.getUserMedia) { // Standard
                    navigator.getUserMedia(videoObj, function (stream) {
                        video.src = stream;
                        video.play();
                    }, errBack);
                } else if (navigator.webkitGetUserMedia) { // WebKit-prefixed
                    navigator.webkitGetUserMedia(videoObj, function (stream) {
                        video.src = window.webkitURL.createObjectURL(stream);
                        video.play();
                    }, errBack);
                }
                else if (navigator.mozGetUserMedia) { // Firefox-prefixed
                    navigator.mozGetUserMedia(videoObj, function (stream) {
                        video.src = window.URL.createObjectURL(stream);
                        video.play();
                    }, errBack);
                }
            }, false);
        }
        /**
         * 拍照
         */
        function photo() {
            //IE
            if (isBrowser) {
                doFlash();
            } else {
                //非IE
                tabkePhotoForHtml5();
            }
        }
        /**
         * 使用FLASH调用摄像头拍照(适用于IE浏览器)
         */
        function doFlash() {
            var MyCan = thisMovie("My_Cam");
            var base64Data = MyCan.GetBase64Code();
            var src = "data:image/jpeg;base64," + base64Data;
            var imgId = $("#hiddId").val();
            $("#img" + imgId).attr("src", src);
            $("#showImg").attr("src", src);
            var data = { "data": base64Data };
            $.ajax({
                url: "/Test/camera/save",
                type: "post",
                data: data,
                async: false,
                dataType: "json",
                success: function (htmlVal) {
                    alert("保存图片成功！");
                },
                error: function (e) {
                    //alert("不成功"); //alert錯誤訊息
                }
            });
        }
        /**
         * 获取Flash对象
         */
        function thisMovie(movieName) {
            if (navigator.appName.indexOf("Microsoft") != -1) {
                return document[movieName];
            }
            else {
                return document[movieName];
            }
        }
        /**
         * 拍摄照片(非IE)
         */
        function tabkePhotoForHtml5() {
            //拍照画在画布上
            context.drawImage(video, 0, 0, 500, 400);
            var canvas = document.getElementById("canvas");
            //从画布上获取照片数据
            var imgData = canvas.toDataURL();
            //将图片转换为Base64
            var base64Data = imgData.substr(22);
            var src = "data:image/jpeg;base64," + base64Data;
            var imgId = $("#hiddId").val();
            $("#img" + imgId).attr("src", src);
            $("#showImg").attr("src", src);
            var data = { "data": base64Data };
            //执行确定操作
            $.ajax({
                url: "/Test/camera/save",
                type: "post",
                data: data,
                async: false,
                dataType: "json",
                success: function (htmlVal) {
                    alert("保存图片成功！");
                },
                error: function (e) {
                    //alert("不成功"); //alert錯誤訊息
                }
            });
        }
    </script>
</body>
</html>
