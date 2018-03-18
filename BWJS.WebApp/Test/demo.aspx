<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="BWJS.WebApp.Test.demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>接口Demo</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js"></script>
</head>

<object id="objActiveX" classid="clsid:A66F5373-0A8A-4C42-814B-38A87B331D40" width="0" height="0"></object>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <table width="750px" border="0" cellspacing="1" cellpadding="2" align="center" bgcolor="#FFFFFF">
                    <tr>
                        <td colspan="3" align="center">
                            <input class="butt" type="button" name="OpenReader" value="打开设备" onclick="hxgc_OpenReader();">
                            <input class="butt" type="button" name="ReadIDCard" value="读二代证" onclick="hxgc_ReadIDCard();">
                            <input class="butt" type="button" name="CloseReader" value="关闭设备" onclick="hxgc_CloseReader();">
                            <input class="butt" type="button" name="Clear" value="清空信息" onclick="clearText();">
                        </td>
                    </tr>
                    <tr>
                        <td class="title">照片保存路径：</td>
                        <td colspan="2">
                            <input type="text" name="text_path" id="text_path" value="">
                            注：路径结尾需添加"\"
                        </td>
                    </tr>
                    <tr>
                        <td class="title">姓名：</td>
                        <td width="430px">
                            <input type="text" name="text_name" id="text_name" value="" readonly>
                        </td>
                        <td rowspan="5" align="center">
                            <img id="PhotoID" name="Photo" style="width: 96px; height: 118px;" /></td>
                    </tr>
                    <tr>
                        <td class="title">性别：</td>
                        <td>
                            <input type="text" name="text_sex" id="text_sex" value="" readonly>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">民族：</td>
                        <td>
                            <input type="text" name="text_nation" id="text_nation" value="" readonly>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">出生：</td>
                        <td>
                            <input type="text" name="text_birthday" id="text_birthday" value="" readonly>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">地址：</td>
                        <td>
                            <input type="text" name="text_address" id="text_address" value="" readonly>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">身份证号：</td>
                        <td colspan="2">
                            <input type="text" name="text_idNum" id="text_idNum" value="" readonly>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">签发机关：</td>
                        <td colspan="2">
                            <input type="text" name="text_dept" id="text_dept" value="" readonly>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">开始期限：</td>
                        <td colspan="2">
                            <input type="text" name="text_effDate" id="text_effDate" value="" readonly>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">结束期限：</td>
                        <td colspan="2">
                            <input type="text" name="text_expDate" id="text_expDate" value="" readonly>
                        </td>
                    </tr>
                    <tr>
                        <td class="title">返回数据：</td>
                        <td colspan="2">
                            <textarea id="text_result" rows="10" name="text_result" id="text_result" style="color: #FF0000" cols="70" readonly></textarea>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="container">
            <div class="row">
                产品可投保区域 省：<select id="inpProvince" name="inpProvince" class="form-control"></select>
                产品可投保区域 市：<select id="inpCity" name="inpCity" class="form-control"></select>
                产品可投保区域 区：<select id="inpDistrict" name="inpDistrict" class="form-control"></select>
            </div>
        </div>
        <div class="container">
            <div class="row">
                产品财产所在地 省：<select id="inpProductPropertyAreaProvince" name="inpProductPropertyAreaProvince" class="form-control"></select>
                产品财产所在地 市：<select id="inpProductPropertyAreaCity" name="inpProductPropertyAreaCity" class="form-control"></select>
                产品财产所在地 区：<select id="inpProductPropertyAreaDistrict" name="inpProductPropertyAreaDistrict" class="form-control"></select>
            </div>
        </div>
        <script src="/Scripts/Mofang/mofanghelper.js" type="text/javascript"></script>
        <script type="text/javascript">

            $(document).ready(function () {
                helper.transNo = "bwjs" + Math.round(Math.random() * 100000000000);
                helper.caseCode = "0000052178002133";
                helper.initProvince($("#inpProvince"), $("#inpCity"), $("#inpDistrict"));

                helper.transNo = "bwjs" + Math.round(Math.random() * 100000000000);
                helper.caseCode = "0000052178002133";
                helper.initProvince($("#inpProductPropertyAreaProvince"), $("#inpProductPropertyAreaCity"), $("#inpProductPropertyAreaDistrict"));
            });

        </script>

        <script type="text/javascript">

            var g_iPort = 1001;											//端口号；USB = 1001 ~ 1016 ，COM端口 = 1~16
            var g_strPHPath = "D:\\";			 					//保存照片路径初始值，路径结尾需添加"\\"
            var g_strBmpPHName = "_PhotoA.bmp";    	//保存bmp照片名称
            var g_strJpgPHName = "_PhotoB.jpg";    	//保存jpg照片名称

            document.getElementById("text_path").value = g_strPHPath;

            function clearText() {
                g_strPHPath = document.all("text_path").value;
                document.getElementById("text_name").value = "";
                document.getElementById("text_sex").value = "";
                document.getElementById("text_nation").value = "";
                document.getElementById("text_birthday").value = "";
                document.getElementById("text_address").value = "";
                document.getElementById("text_idNum").value = "";
                document.getElementById("text_dept").value = "";
                document.getElementById("text_effDate").value = "";
                document.getElementById("text_expDate").value = "";
                document.getElementById("text_result").value = "";
                document.getElementById("PhotoID").src = "";
            }

            function hxgc_OpenReader() {
                var iResult = 0;

                iResult = objActiveX.hxgc_OpenReader(g_iPort);//打开设备

                if (iResult == 0) {
                    var strSAMID = objActiveX.hxgc_GetSamIdToStr(g_iPort);//获取SAMID

                    document.getElementById("text_result").value = "打开设备成功.\r\nSAMID = " + strSAMID + ".";
                }
                else {
                    document.getElementById("text_result").value = "打开设备失败，错误代码：" + iResult + ".";
                }
            }

            function hxgc_ReadIDCard() {
                clearText();

                var iResult = 0;
                var strPhotoBase64 = "";

                iResult = objActiveX.hxgc_ReadIDCard(g_iPort);//读二代证

                if (iResult == 0) {
                    document.getElementById("text_result").value = "读二代证信息成功.";
                    document.getElementById("text_name").value = objActiveX.hxgc_GetName();   //姓名
                    document.getElementById("text_sex").value = objActiveX.hxgc_GetSex();     //性别
                    document.getElementById("text_nation").value = objActiveX.hxgc_GetNation();     //民族
                    document.getElementById("text_birthday").value = objActiveX.hxgc_GetBirthDate();      //出生日期
                    document.getElementById("text_address").value = objActiveX.hxgc_GetAddress();         //地址
                    document.getElementById("text_idNum").value = objActiveX.hxgc_GetIDCode();            //身份证号
                    document.getElementById("text_dept").value = objActiveX.hxgc_GetIssuingAuthority();   //签发机关
                    document.getElementById("text_effDate").value = objActiveX.hxgc_GetBeginPeriodOfValidity();      //有效日期起始
                    document.getElementById("text_expDate").value = objActiveX.hxgc_GetEndPeriodOfValidity();        //有效日期截止

                    //将照片保存到指定位置，格式为BMP格式
                    iResut = objActiveX.hxgc_SavePhAsBmp(g_strPHPath, g_strBmpPHName);
                    if (0 == iResut) {
                        document.getElementById("text_result").value += "\r\n保存BMP照片成功，路径 = " + g_strPHPath + g_strBmpPHName + ".";
                    }
                    else {
                        document.getElementById("text_result").value += "\r\n错误：保存BMP照片失败.";
                    }

                    //将照片保存到指定位置，格式为BMP格式
                    iResut = objActiveX.hxgc_SavePhAsJpg(g_strPHPath, g_strJpgPHName);
                    if (0 == iResut) {
                        document.getElementById("text_result").value += "\r\n保存JPG照片成功，路径 = " + g_strPHPath + g_strJpgPHName + ".";

                        //获得JPG图片的BASE64编码
                        strPhotoBase64 = objActiveX.hxgc_MakeFileToBeas64(g_strPHPath, g_strJpgPHName);

                        document.getElementById("text_result").value += "\r\nJPG照片Base64编码：" + strPhotoBase64 + ".";

                        document.all("PhotoID").src = "data:image/jpeg;base64," + strPhotoBase64;//显示图片
                    }
                    else {
                        document.getElementById("text_result").value += "\r\n错误：保存JPG照片失败.";
                    }

                }
                else {
                    document.getElementById("text_result").value = "读二代证信息失败，错误代码：" + iResult + ".";
                }
            }

            function hxgc_CloseReader() {
                var iResult = 0;

                iResult = objActiveX.hxgc_CloseReader(g_iPort);//关闭设备

                if (iResult == 0) {
                    document.getElementById("text_result").value = "关闭设备成功.";
                }
                else {
                    document.getElementById("text_result").value = "关闭设备失败，错误代码：" + iResult + ".";
                }
            }

        </script>
    </form>
</body>
</html>
