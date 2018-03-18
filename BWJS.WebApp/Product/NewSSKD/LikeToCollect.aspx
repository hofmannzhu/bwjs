<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LikeToCollect.aspx.cs" Inherits="BWJS.WebApp.Product.SSKD.LikeToCollect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <title>人像采集</title>
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js"></script>
    <script src="/Scripts/jquery-2.2.2.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/camera.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <%-- ////////摄像头js开始(新版本谷歌不支持，必须用旧版本)///////////--%>
    <script src="/Scripts/Photograph/html5media.min.js"></script>
    <script src="/Scripts/Photograph/html5shiv.min.js"></script>
    <%-- ////////摄像头js结束///////////--%>
    <script type="text/javascript">
        var canSubmit = false;
        $(document).ready(function () {
            $("#next-photo").click(function () {
                if (!canSubmit) {
                    canSubmit = true;
                    return nextphorzClick();
                }
            });
            checkUserIsAuthentication();
        });
        var i = 5;
        function btnCameraClick(obj) { 
            if (i == 0) {
                obj.removeClass("mr");
                obj.addClass("gl");
                obj.on("click", function () {
                    btnCameraClick($(this));
                });
                obj.html("点击拍照");
                $("#next-photo").removeClass("mr");
                $("#next-photo").addClass("gl");
                i = 5;
                showPicture()
            }
            else {
                obj.removeClass("gl");
                obj.addClass("mr");
                $("#next-photo").removeClass("gl");
                $("#next-photo").addClass("mr");
                obj.unbind("click");
                obj.html(i + "秒后自动抓拍");
                i--;
                setTimeout(function () {
                    btnCameraClick(obj)
                }
                , 1000);
            }
            return false;
        }
        function showPicture() {

            var video = document.getElementById('video');
            var canvas = document.getElementById('canvas');
            var context = canvas.getContext('2d');

            context.drawImage(video, 0, 0, 480, 320);
            var dataURL = canvas.toDataURL('image/jpeg'); //转换图片为dataURL  
         

            $("#showImg1").attr("src", dataURL);
            dataURL = dataURL.substr(22);
            imgAdd(1, dataURL);
        }
    </script>
    <script type="text/javascript">
        function nextphorzClick() {
            var imgid1 = $("#hiddImgId1").val();
            var checkUserIsAuthentication = parseInt($("#hiddCheckUserIsAuthentication").val());
            if (checkUserIsAuthentication == 0) {
                if (imgid1 == "") {
                    myAlert("请先拍照");
                    return false;
                }
                else {
                    var auth = idinformationAuthentication();
                    if (!auth) {
                        return false;
                    }
                    $("#jsForm").submit();
                }
            }
            else {
                $("#jsForm").submit();
            }
            return false;
        }

        function checkUserIsAuthentication() {
            var result = false;
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "checkuserisauthentication";
            paramter.netLoanApplyId = '<%= sskdModel.ConsultId %>';
            var json = getJson(paramter, false);
            if (json.result) {
                result = json.result;
                $("#hiddCheckUserIsAuthentication").val(1);
            }
            return result;
        }

        function idinformationAuthentication() {
            var result = false;
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "submitidinformation";
            paramter.faceIds = $.trim($("#hiddImgId1").val());
            paramter.idCardIds = $.trim($("#hiddImgId1").val());
            paramter.idCardNo = '<%=sskdModel.IDCardNo%>';
            paramter.realName = '<%=sskdModel.FullName%>';
            paramter.sex = '<%=sskdModel.Sex%>';
            paramter.birth = '<%=sskdModel.Birth%>';
            paramter.national = '<%=sskdModel.National%>';
            paramter.address = '<%=sskdModel.Address%>';
            paramter.authority = '<%=sskdModel.Authority%>';
            paramter.validperiod = '<%=sskdModel.Validperiod%>';
            paramter.consultId = '<%= sskdModel.ConsultId %>';
            paramter.sign = '<%=GetSign%>';
            paramter.orderNo = '<%=sskdModel.OrderNo%>';
            paramter.equipmentNo = '<%= sskdModel.MachineId %>';
            paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
            paramter.token = '<%= sskdModel.Token %>';
            bwjsLoadingDemo("努力加载中...");
            var json = getJson(paramter, false);
            //myAlert(JSON.stringify(json));
            if (json.success) {
                result = json.success;
            }
            else {
                myAlert(json.message);
                canSubmit = false;
            }
            return result;
        }
        function imgAdd(id, base64Code) {

            var sskdRequestParas = {};
            sskdRequestParas.PageLoadDateTime = '<%= sskdRequestParas.PageLoadDateTime %>';
            sskdRequestParas.ConsultId = '<%= sskdModel.ConsultId %>';
            sskdRequestParas.Timestamp = '<%= sskdModel.TimeStamp %>';
            sskdRequestParas.Sign = '<%= GetSign %>';
            sskdRequestParas.OrderNo = '<%= sskdModel.OrderNo %>';
            sskdRequestParas.Token = '<%= sskdModel.Token %>';
            sskdRequestParas.EquipmentNo = '<%= sskdModel.MachineId %>';
            sskdRequestParas.MerchantsNo = '<%= sskdModel.MerchantId %>';
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "imagesupload";
            paramter.base64Code = base64Code;
            paramter.netLoanApplyId = '<%= sskdModel.ConsultId %>';
            paramter.sign = '<%= GetSign %>';
            paramter.orderNo = '<%= sskdModel.OrderNo %>';
            paramter.equipmentNo = '<%= sskdModel.MachineId %>';
            paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
            paramter.token = '<%= sskdModel.Token %>';
            paramter.timeStamp = '<%= sskdModel.TimeStamp %>';
            paramter.sskdRequestParas = JSON.stringify(sskdRequestParas);
            var json = getJson(paramter, false);
            //myAlert(JSON.stringify(json));
            if (json.success) {
                $("#hiddImgId" + id).val(json.data.imgId);
            } else {
                myAlert(json.message);
            }
        }
    </script>
    <style>
        #pho-b {
            position: relative;
            width: 100%;
            margin: auto;
            height: auto;
        }

            #pho-b img {
                margin-top: 100px;
            }

        #HTML5Div {
            position: absolute;
            left: 50%;
            margin-left: -250px;
            height: 400px;
            top: 10%;
            z-index: 1000;
        }

        #FalshDiv {
            position: absolute;
            left: 50%;
            margin-left: -250px;
            height: 400px;
            top: 10%;
            z-index: 1000;
        }
    </style>
</head>
<body>

    <div class="main">
        <!--头部元素start-->
        <div class="head-box">
            <div class="col-lg-12">
                <!--申请成功移动字幕start-->
                <script src="/Scripts/NewSSKD/success.js"></script>

            </div>
        </div>
        <!--头部元素end-->
        <!--步骤条start-->
        <div class="tab-box">
            <ul>
                <li class="" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot1.png" /></span>人像采集 </li>
                <li class=""><span class="line"></span><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot2.png" /></span>授权认证</li>
                <li class=""><span class="line"></span><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot3.png" /></span>评估报告</li>
                <li class=""><span class="line"></span><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot5.png" /></span>选择银行卡</li>
                <li class=""><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot4.png" /></span>申请确认</li>

            </ul>
        </div>
        <!--步骤条end-->

        <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NewSSKD/AuthorizationCertification">
            <!--人像采集Start-->
            <div class="col-lg-12 col-sm-12 col-xs-12 hei">
                <canvas id="canvas" style="display: none;" width="480" height="320"></canvas>
                <div style="text-align: center;">
                    <video id="video" width="480" height="320" controls></video>
                </div>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="photo-btn gl" style="width: 16%; margin-left: 42%;" id="capture">点击拍照</div>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                <div class="ts-til1 ">
                    请拍摄手持身份证正面照片，照片的清晰度会影响授信额度和审批进度
                </div>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12 ma-b text-center zp">
                <div class="col-lg-2 col-sm-2  col-xs-2 ">
                </div>
                <div class="col-lg-3 col-sm-3  col-xs-3 text-center">
                    <img src="../../Content/img/NewSSKD/rl1.png" />
                    <div class="ts-til">示 例</div>
                </div>
                <div class="col-lg-1 col-sm-1  col-xs-1 ">
                </div>
                <div class="col-lg-1 col-sm-1  col-xs-1">
                </div>
                <div class="col-lg-3 col-sm-3  col-xs-3 text-center">
                    <img src="../../Content/img/NewSSKD/rl2.png" id="showImg1" style="height: 195px; width: 206px;" />
                    <div class="ts-til">照片显示区</div>
                </div>
                <div class="col-lg-2 col-sm-2  col-xs-2 ">
                </div>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-top: 0;">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <div class="next-btn mr" id="next-photo" style="margin-top: 16px;">下 一 步 </div>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
            <!--人像采集end-->
            <input id="hiddCheckUserIsAuthentication" name="hiddCheckUserIsAuthentication" type="hidden" value="0" />
            <input id="hiddImgId1" name="hiddImgId1" type="hidden" />
            <input id="hiddImgId2" name="hiddImgId2" type="hidden" />
            <input id="hiddImgId3" name="hiddImgId3" type="hidden" />
            <input id="hiddImgId4" name="hiddImgId4" type="hidden" />
            <input id="hiddImgId5" name="hiddImgId5" type="hidden" />
            <input id="hiddImgId6" name="hiddImgId6" type="hidden" />
            <input id="hiddImgId7" name="hiddImgId7" type="hidden" />
            <input id="hiddImgId8" name="hiddImgId8" type="hidden" />
            <input id="hidorderNo" name="hidorderNo" type="hidden" value="<%=sskdModel.OrderNo %>" />
            <input id="hiddToken" name="hiddToken" type="hidden" value="<%=sskdModel.Token %>" />
            <input id="hidConsultId" name="hidConsultId" type="hidden" value="<%=sskdModel.ConsultId %>" />
            <input id="hidMobile" name="hidMobile" type="hidden" value="<%=sskdModel.Mobile %>" />
            <input id="hididNo" name="hididNo" type="hidden" value="<%=sskdModel.IDCardNo %>" />
            <input id="hidFullName" name="hidFullName" type="hidden" value="<%=sskdModel.FullName %>" />
            <input id="hiddSex" name="hiddSex" type="hidden" value="<%=sskdModel.Sex %>" />
            <input id="hiddBirth" name="hiddBirth" type="hidden" value="<%=sskdModel.Birth %>" />
            <input id="hiddNational" name="hiddNational" type="hidden" value="<%=sskdModel.National %>" />
            <input id="hiddAddress" name="hiddAddress" type="hidden" value="<%=sskdModel.Address %>" />
            <input id="hiddAuthority" name="hiddAuthority" type="hidden" value="<%=sskdModel.Authority %>" />
            <input id="hiddValidperiod" name="hiddValidperiod" type="hidden" value="<%=sskdModel.Validperiod %>" />
            <script>
                //访问用户媒体设备的兼容方法
                function getUserMedia(constraints, success, error) {
                    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
                        //最新的标准API
                        navigator.mediaDevices.getUserMedia(constraints).then(success).catch(error);
                    } else if (navigator.webkitGetUserMedia) {
                        //webkit核心浏览器
                        navigator.webkitGetUserMedia(constraints, success, error)
                    } else if (navigator.mozGetUserMedia) {
                        //firfox浏览器
                        navigator.mozGetUserMedia(constraints, success, error);
                    } else if (navigator.getUserMedia) {
                        //旧版API
                        navigator.getUserMedia(constraints, success, error);
                    }
                }

                var video = document.getElementById('video');
                var canvas = document.getElementById('canvas');
                var context = canvas.getContext('2d');

                function success(stream) {
                    //兼容webkit核心浏览器
                    var CompatibleURL = window.URL || window.webkitURL;
                    //将视频流设置为video元素的源
                    console.log(stream);
                    video.src = CompatibleURL.createObjectURL(stream);
                    video.srcObject = stream;
                    video.play();
                }
                function getBase64(url) {
                    //通过构造函数来创建的 img 实例，在赋予 src 值后就会立刻下载图片，相比 createElement() 创建 <img> 省去了 append()，也就避免了文档冗余和污染
                    var Img = new Image(),
                     dataURL = '';
                    Img.src = url;
                    Img.onload = function () { //要先确保图片完整获取到，这是个异步事件
                        var canvas = document.createElement("canvas"), //创建canvas元素
                         width = Img.width, //确保canvas的尺寸和图片一样
                         height = Img.height;
                        canvas.width = width;
                        canvas.height = height;
                        canvas.getContext("2d").drawImage(Img, 0, 0, width, height); //将图片绘制到canvas中
                        dataURL = canvas.toDataURL('image/jpeg'); //转换图片为dataURL
                    };
                }
                function error(error) {
                    console.log(`访问用户媒体设备失败${error.name}, ${error.message}`);
                }
                console.log(navigator);
                if ((navigator.mediaDevices && navigator.mediaDevices.getUserMedia) || navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia) {
                    //调用用户媒体设备, 访问摄像头
                    // getUserMedia({ video: { width: 480, height: 320 } }, success, error);
                    getUserMedia({ audio: true, video: true }, success, error);
                } else {
                    alert('不支持访问用户媒体');
                } 
                $(document).ready(function () {
                    $("#capture").click(function () { 
                        btnCameraClick($(this));
                    });
                });

            </script>
        </form>
    </div>
</body>
</html>
