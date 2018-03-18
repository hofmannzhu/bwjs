<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LikeToCollect.aspx.cs" Inherits="BWJS.WebPad.Product.SSKD.LikeToCollect" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>人像采集</title>
    <link href="/Content/css/NewSSKD/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <script src="/Scripts/jquery-2.2.2.js"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js"></script>
    <link href="/Scripts/theme/default/layer.css" rel="stylesheet" />
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js"></script>
    <script type="text/javascript">
        /**
         * 初始化
         */
        $(document).ready(function () {
            $("#next-photo").click(function () {
                return nextphorzClick();
            });
            $(".head-btn").click(function () {
                $(".mask").fadeIn();
            });
            $(".btn-n").click(function () {
                $(".mask").fadeOut();
            });

        });
    </script>

    <script>

        var canSubmit = false;
        function nextphorzClick() {
            var auth = false;
            var imgid1 = $("#hiddImgId1").val();
            var imgid2 = $("#hiddImgId2").val();
            var imgid3 = $("#hiddImgId3").val();
            var imgid4 = $("#hiddImgId4").val();
            var imgid5 = $("#hiddImgId5").val();
            var imgid6 = $("#hiddImgId6").val();
            var imgid7 = $("#hiddImgId7").val();
            var imgid8 = $("#hiddImgId8").val();
            var imgid99 = $("#hiddImgId99").val();
            if (imgid1 != "" && imgid2 != "" && imgid3 != "" && imgid4 != "" && imgid5 != "" && imgid6 != "" && imgid7 != "" && imgid8 != "") {
                if (!canSubmit) {
                    canSubmit = true;
                    auth = idinformationAuthentication();
                    if (!auth) {
                        //layer.msg("提交采集的人像信息失败，请稍后再试");
                        return false;
                    } else {
                        //去下一步
                        window.location.href = "/Product/NewSSKD/AuthorizationCertification";
                    }
                }
                return false;
            } else {
                //layer.msg("提交采集的人像信息失败，请稍后再试");
                return false;
            }
        }

        function idinformationAuthentication() {
            //var lindex = layer.load("请稍等...");
            bwjsLoadingDemo("努力加载中...");
            var idCardIds = $.trim($("#hiddImgId5").val()) + "," + $.trim($("#hiddImgId6").val()) + "," + $.trim($("#hiddImgId7").val()) + "," + $.trim($("#hiddImgId8").val());
            var faceIds = $.trim($("#hiddImgId1").val()) + "," + $.trim($("#hiddImgId2").val()) + "," + $.trim($("#hiddImgId3").val()) + "," + $.trim($("#hiddImgId4").val()) + "," + $.trim($("#hiddImgId99").val());
            var result = false;
            var sskdRequestParas = {};
            sskdRequestParas.PageLoadDateTime = '<%=sskdRequestParas.PageLoadDateTime %>';

            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "submitidinformation";
            paramter.faceIds = faceIds;
            paramter.idCardIds = idCardIds;


            paramter.idCardNo = '<%=sskdModel.IDCardNo%>';
            paramter.realName = '<%=sskdModel.FullName%>';
            paramter.sex = $("#hiddSex").val();
            paramter.birth = $("#hiddBirth").val();
            paramter.national = $("#hiddNational").val();
            paramter.address = $("#hiddAddress").val();
            paramter.authority = $("#hiddAuthority").val();
            paramter.validperiod = $("#hiddValidperiod").val();
            paramter.consultId = '<%= sskdModel.ConsultId %>';
            paramter.sign = '<%=GetSign%>';
            paramter.orderNo = '<%=sskdModel.OrderNo%>';
            paramter.equipmentNo = '<%= sskdModel.MachineId %>';
            paramter.merchantsNo = '<%= sskdModel.MerchantId %>';
            paramter.token = '<%= sskdModel.Token %>';
            paramter.sskdRequestParas = JSON.stringify(sskdRequestParas);

            var json = getJson(paramter, false);
            //layer.close(lindex);
            if (json.success) {
                result = json.success;
            }
            else {
                canSubmit = false;
                layer.msg("提交采集的人像信息失败，[" + json.message + "]，请稍后再试");
            }
            return result;
        }



        function showFont() {
            $("#idFont").show();
            $("#idBank").hide();
        }

        function showBank() {
            $("#idBank").show();
            $("#idFont").hide();
        }

        function hideFont() {
            $("#idFont").hide();
        }

        function hideBank() {
            $("#idBank").hide();

        }
        function idFontphoto() {
            android.idcardCamera("front");

        }

        function idbankphoto() {
            android.idcardCamera("back");
        }

        //<!-- js调用android拍照 -->
        function photo() {
            if (photoSuccessnum > 5) {
                myAlertSuccess("您操作的次数已超限，请继续其他操作！");
            } else {
                android.openPhoto();
            }
        }
        var photoSuccessnum = 0;
        //<!-- android拍照结束，返回 -->
        function photoSuccess(img1, img2, img3, img4, fileId) {
            //var lindex = layer.load("请稍等...");
            bwjsLoadingDemo("努力加载中...");
            photoSuccessnum = photoSuccessnum + 1;
            $("#hiddImgId1").val(img1);
            $("#hiddImgId2").val(img2);
            $("#hiddImgId3").val(img3);
            $("#hiddImgId4").val(img4);
            $("#hiddImgId99").val(fileId);
            $("#showImg1").attr("src", "<%=xinboweinuoApi%>" + "/iservice/s/h/do/f?fileId=" + img1);


            //$("#showImg2").attr("src", LoanApi + "/iservice/s/h/do/f?fileId=" + img2);
            //$("#showImg3").attr("src", LoanApi + "/iservice/s/h/do/f?fileId=" + img3);
            //$("#showImg4").attr("src", LoanApi + "/iservice/s/h/do/f?fileId=" + img4);
            //layer.close(lindex);
            bwjsLoadingClose();
        }
        //<!-- js调用android身份证反面 -->
        function idCardBank() {
            if (idBankSuccesssnum > 5) {
                myAlertSuccess("您操作的次数已超限，请继续其他操作！");
            } else {
                android.idCardBank();
            }

        }

        var idBankSuccesssnum = 0;
        //<!-- android身份证反面 回调 -->
        function idBankSuccess(f1, f2, str) {
            //var lindex = layer.load("请稍等...");
            bwjsLoadingDemo("努力加载中...");
            idBankSuccesssnum = idBankSuccesssnum + 1;
            hideBank();
            var data = JSON.parse(str);
            $("#hiddAuthority").val(data.authority);
            $("#hiddValidperiod").val(data.validperiod);

            $("#hiddImgId7").val(f1);
            $("#hiddImgId8").val(f2);
            if ($("#hiddImgId7").val()!=""&&$("#hiddImgId8").val()!="") {
                 $("#showImg7").attr("src", "<%=xinboweinuoApi%>" + "/iservice/s/h/do/f?fileId=" + f1);
            }
            //$("#showImg8").attr("src", LoanApi + "/iservice/s/h/do/f?fileId=" + f2);
            //layer.close(lindex);
            bwjsLoadingClose();
        }

        //<!-- js调用android身份证正面 -->
        function idCardFont() {
            if (idFontSuccessnum > 5) {
                myAlertSuccess("您操作的次数已超限，请继续其他操作！");
            } else {
                android.idCardFont();
            }
        }
        var idFontSuccessnum = 0;
        //<!-- android身份证正面 回调 -->
        function idFontSuccess(b1, b2, str) {
            //var lindex = layer.load("请稍等...");
            bwjsLoadingDemo("努力加载中...");
            idFontSuccessnum = idFontSuccessnum + 1;
            hideFont();
            var data = JSON.parse(str);
            $("#hiddAddress").val(data.address);
            $("#hiddBirth").val(data.birth);
            $("#hiddNational").val(data.national);
            $("#hiddSex").val(data.sex);

            $("#hiddImgId5").val(b1);
            $("#hiddImgId6").val(b2);
            if ($("#hiddImgId5").val()!=""&&$("#hiddImgId6").val()!="") {
                 $("#showImg5").attr("src", "<%=xinboweinuoApi%>" + "/iservice/s/h/do/f?fileId=" + b1);
            }
           
            //$("#showImg6").attr("src", LoanApi + "/iservice/s/h/do/f?fileId=" + b2);
            //layer.close(lindex);
            bwjsLoadingClose();
        }


        function callAjaxApiLog(paramStr) {
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "AjaxApiLog";
            paramter.url = 'LikeToCollect.aspx';
            paramter.paramStr = paramStr;
            var json = getJson(paramter, false);
            if (json.success) {
            }
            else {
                layer.msg(json.message);
            }
        }

    </script>

</head>
<body>

    <div class="mask">
        <div class="pop-box-dhk">
            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                <span class="qr-msg">您是否要取消申请吗？</span>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">

                <div class="col-lg-5 col-sm-5 col-xs-5">
                    <a href="home.aspx"><span class="btn-y">是</span></a>
                </div>
                <div class="col-lg-2 col-sm-2 col-xs-2">
                </div>
                <div class="col-lg-5 col-sm-5 col-xs-5">
                    <span class="btn-n">否</span>
                </div>

            </div>
        </div>
    </div>
    <!--遮罩弹窗显示是和否end-->


    <!--广告幻灯片部分 start 调用原来的一个IP地址-->
    <%--  <script src="/Scripts/NewSSKD/success.js" type="text/javascript"></script>--%>
    <!--广告幻灯片部分END-->
    <div class="main">

        <!--头部元素start-->
        <div class="head-box">
            <div class="col-lg-12">
                <!--申请成功移动字幕start-->
                <script src="/Scripts/NewSSKD/success.js"></script>
                <div class="col-lg-2 col-sm-2 col-xs-2">
                    <div class="head-btn">取消申请</div>
                </div>
            </div>
        </div>
        <!--头部元素end-->

        <!--步骤条start-->
        <div class="tab-box">
            <ul>
                <li class="" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot1.png" /></span>身份校验 </li>
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
        <!--人像采集Start-->
        <div class="col-lg-12 col-sm-12 col-xs-12 text-center" style="margin-top: -80px;">
            <span class="ts-msg3">请在拍摄边框内扫描</span>
            <img src="../../Content/img/NewSSKD/pad-sfz.png" id="showImg1" style="max-width: 200px; max-height: 175px;" onclick="photo()" />
            <div class="ts-til">人脸识别</div>
        </div>

        <div class="col-lg-12 col-sm-12 col-xs-12 text-center" style="margin-left: 0; padding-left: 0">

            <div class="col-lg-6 col-sm-6  col-xs-6 text-center" style="margin-left: 0; padding-left: 0;">

                <div class="pho-sel" id="idFont" style="display: none">
                    <span class="ts-msg4">请优先选择实时"扫描"识别</span>
                    <div class="sb-btn" onclick="idCardFont()">扫 描</div>
                    <div class="sb-btn" onclick="idFontphoto()">拍 照</div>
                </div>

                <img src="../../Content/img/NewSSKD/sfzz.jpg" id="showImg5" style="max-width: 275px; max-height: 175px;" onclick="showFont()" />

                <div class="ts-til">身份证正面</div>
            </div>


            <div class="col-lg-6 col-sm-6  col-xs-6 text-center" style="margin-left: 0; padding-left: 0;">
                <div class="img-box2">
                    <div class="pho-sel se-t" id="idBank" style="display: none;">
                        <span class="ts-msg4">请优先选择实时"扫描"识别</span>
                        <div class="sb-btn" onclick="idCardBank()">扫 描</div>
                        <div class="sb-btn" onclick="idbankphoto()">拍 照</div>
                    </div>
                    <img src="../../Content/img/NewSSKD/sfzf.jpg" id="showImg7" style="max-width: 275px; max-height: 175px;" onclick="showBank()" />

                    <div class="ts-til">身份证反面</div>
                </div>

            </div>
            <!--人像采集end-->
            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <div class="next-btn" id="next-photo" style="margin-bottom: 40px; margin-top: 10px;">下 一 步</div>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
        </div>

        <input id="hiddImgId1" name="hiddImgId1" type="hidden" />
        <input id="hiddImgId2" name="hiddImgId2" type="hidden" />
        <input id="hiddImgId3" name="hiddImgId3" type="hidden" />
        <input id="hiddImgId4" name="hiddImgId4" type="hidden" />
        <input id="hiddImgId5" name="hiddImgId5" type="hidden" />
        <input id="hiddImgId6" name="hiddImgId6" type="hidden" />
        <input id="hiddImgId7" name="hiddImgId7" type="hidden" />
        <input id="hiddImgId8" name="hiddImgId8" type="hidden" />
        <input id="hiddImgId99" name="hiddImgId99" type="hidden" />


        <input id="hiddSex" name="hiddSex" type="hidden" />
        <input id="hiddBirth" name="hiddBirth" type="hidden" />
        <input id="hiddNational" name="hiddNational" type="hidden" />
        <input id="hiddAddress" name="hiddAddress" type="hidden" />
        <input id="hiddAuthority" name="hiddAuthority" type="hidden" />
        <input id="hiddValidperiod" name="hiddValidperiod" type="hidden" />
</body>
</html>
