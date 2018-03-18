/*
    依赖的引用
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    调用
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>

*/

var emailReg2 = /^\w+((-\w+)|(\.\w+))*\@("@")[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
var emailReg = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;
var realnameReg = /^([\u4e00-\u9fa5]{2,4})$/;
var realnameReg2 = /^([\u4e00-\u9fa5]{2,8}|[a-zA-Z]{2,16})$/g;
var mobileReg2 = /^1[3|4|5|6|7|8|9]\d{9}$/;
var mobileReg1 = /^(0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8})|(400|800)([0-9\\-]{7,10})|(([0-9]{4}|[0-9]{3})(-| )?)?([0-9]{7,8})((-| |转)*([0-9]{1,4}))?$/;

$(document).ready(function () {
});

//bootbox
function bwjsAlert(msg) {
    bootbox.dialog({
        message: "<div style=\"word-wrap: break-word;word-break: normal;\">" + msg + "</div>",
        buttons: {
            "success": {
                "label": "关闭",
                "className": "btn btn-sm btn-primary"
            }
        }
    });
}

function myConfirm(msg) {
    bootbox.setDefaults("locale", "zh_CN");
    bootbox.confirm(msg, function (result) {
        return result;
    });
}

function getJson(paramter, async) {
    var result = "";
    try {
        paramter.timeUnix = new Date().getTime();
        $.ajax({
            type: "post",
            url: "/ajax/helper.ashx",
            data: paramter,
            dataType: "json",
            async: async,
            beforeSend: function (XMLHttpRequest) {
                //$("#loading").modal("show");
                //layer.msg('努力加载中.....', { icon: 6, time: 1000 });
                //bwjsLoadingDemo("努力加载中...");
            },
            success: function (json) {
                result = json;
                bwjsLoadingClose();
            },
            complete: function (XMLHttpRequest, textStatus) {
                bwjsLoadingClose();
            },
            error: function () {
                myAlert("服务器没有返回数据，可能服务器忙，请重试");
                bwjsLoadingClose();
            }
        });
    }
    catch (ex) {
        myAlert("出错了，可能服务器忙，请重试");
        bwjsLoadingClose();
    }
    return result;
}

function getJsonByDataType(paramter, async, dataType) {
    var result = "";
    try {
        paramter.timeUnix = new Date().getTime();
        $.ajax({
            type: "post",
            url: "/ajax/helper.ashx",
            data: paramter,
            dataType: dataType,
            async: async,
            beforeSend: function (XMLHttpRequest) {
                //bwjsLoadingDemo("努力加载中...");
            },
            success: function (json) {
                result = json;
                bwjsLoadingClose();
            },
            complete: function (XMLHttpRequest, textStatus) {
                bwjsLoadingClose();
            },
            error: function () {
                myAlert("服务器没有返回数据，可能服务器忙，请重试");
                bwjsLoadingClose();
            }
        });
    }
    catch (ex) {
        myAlert("出错了，可能服务器忙，请重试");
        //$("#loading").modal("hide");
        bwjsLoadingClose();
    }
    return result;
}

function Base64Decode(base64DecodeCode) {
    var result = "";
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "base64decode";
    paramter.base64Code = base64DecodeCode;
    var json = getJson(paramter, false);
    if (json.success) {
        result = json.data;
    }
    return result;
}

//百度IP定位当前位置信息
function getLocationJson() {
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "getlocationjson";
    var json = getJson(paramter, false);
    if (json != null) {
        //province = json.content.address_detail.province;
        //city = json.content.address_detail.city;
    }
    return json;
}

/// <summary>
/// 逆地址解析
/// </summary>
/// <param name="longitude">经度</param>
/// <param name="latitude">纬度</param>
/// <param name="output">输出格式为json或者xml</param>
/// <param name="pois">是否显示指定位置周边的poi，0为不显示，1为显示。当值为1时，默认显示周边1000米内的poi。</param>
/// <returns>json或者xml</returns>
function getAddressByLocation(longitude, latitude, output, pois) {
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "getaddressbylocation";
    paramter.longitude = longitude;
    paramter.latitude = latitude;
    paramter.output = output;
    paramter.pois = pois;
    var json = getJson(paramter, false);
    if (json.success) {
    }
    return json;
}

function myAlert(msg) {
    if ($("#alertlayer").length > 0) {
        $("#alertlayer").remove();
    }
    var alertHtml = "";
    alertHtml += "<div class=\"mask\" id=\"alertlayer\" style=\"z-index:9998;\" >";
    alertHtml += "<div class=\"pop-box-msg\">";
    alertHtml += "<div class=\"pop-msg\"> " + msg;
    alertHtml += "<div class=\"clo-btn\" onclick=\"closeLayer();\">关 闭</div>";
    alertHtml += "<div class=\"ok-btn qd hid\">确定</div>";
    alertHtml += "<div class=\"cal-btn qd hid\">取消</div>";
    alertHtml += "</div>";
    alertHtml += "</div>";
    alertHtml += "</div>";
    $("body").append(alertHtml);
    //打开层
    $(".mask").fadeIn(); 
}
function closeLayer() {
        $(".mask").fadeOut() 
}

function bwjsLoading(loadText) {
    layer.msg(loadText, { icon: 6, time: 1000 });
}

function bwjsLoadingDemo1() {
    if ($("#loading").length == 0) {
        var loadingHtml = "<div style=\"z-index: 9999;position: fixed;width: 100%;height: 100%;\">";
        loadingHtml += "<img src=\"/Content/img/NewSSKD/loading.gif\" style=\"position: absolute;top: 35%;left: 45%;\">";
        loadingHtml += "</div>";
        $("body").append(loadingHtml)
    }
    $("#loading").modal("show");
}

///Content/img/NewSSKD/loading.gif
function bwjsLoadingDemo(loadText) {
    if ($("#loading").length == 0) {
        var loadingHtml = "";
        loadingHtml += "<div class=\"modal fade\" id=\"loading\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"loadingModalLabel\" data-backdrop=\"true\">";
        loadingHtml += "<div class=\"modal-dialog\" role=\"document\" style=\"position:absolute;top:40%;left:30%;\" >";
        loadingHtml += "<div class=\"modal-content\">";
        loadingHtml += "<div class=\"modal-body\">";
        loadingHtml += "<img src=\"/Content/img/loadingsmall.gif\" />&nbsp;&nbsp;";
        if (loadText == "") {
            loadingHtml += "处理中，请稍候。。。";
        }
        else {
            loadingHtml += loadText;
        }
        loadingHtml += "</div>";
        loadingHtml += "</div>";
        loadingHtml += "</div>";
        loadingHtml += "</div>";
        $("body").append(loadingHtml)
    }
    $("#loading").modal("show");
}

function bwjsLoadingClose() {
    if ($("#loading").length > 0) {
        $("#loading").modal("hide");
    }

    //if ($(".modal-backdrop").length > 0) {
    //    $(".modal-backdrop").remove();
    //}
}

function isContains(str, substr) {
    return str.indexOf(substr) >= 0;
}

function checkClickIsBind(obj) {
    var objEvt = $._data(obj[0], "events");
    if (objEvt && objEvt["click"]) {
        return true;
    }
    else {
        return false;
    }
}
//字符串4位一分割
function bankCardNoSplit(obj) {
    var temp = obj;
    temp = temp.replace(/\D/g, '');
    temp = temp.replace(/[\s]/g, '').replace(/(\d{4})(?=\d)/g, "$1 ");
    return temp;
}
//去除字符串所有空格
function bankCardNoTrim(str, is_global) {
    var result;
    result = str.replace(/(^\s+)|(\s+$)/g, "");
    if (is_global.toLowerCase() == "g") {
        result = result.replace(/\s/g, "");
    }
    return result;
}

//Description:  银行卡号Luhm校验
//Luhm校验规则：16位银行卡号（19位通用）:
// 1.将未带校验位的 15（或18）位卡号从右依次编号 1 到 15（18），位于奇数位号上的数字乘以 2。
// 2.将奇位乘积的个十位全部相加，再加上所有偶数位上的数字。
// 3.将加法和加上校验位能被 10 整除。
//方法步骤很清晰，易理解，需要在页面引用Jquery.js
//bankno为银行卡号 banknoInfo为显示提示信息的DIV或其他控件
function luhmCheck(bankno) {
    var lastNum = bankno.substr(bankno.length - 1, 1);//取出最后一位（与luhm进行比较）

    var first15Num = bankno.substr(0, bankno.length - 1);//前15或18位
    var newArr = new Array();
    for (var i = first15Num.length - 1; i > -1; i--) {    //前15或18位倒序存进数组
        newArr.push(first15Num.substr(i, 1));
    }
    var arrJiShu = new Array();  //奇数位*2的积 <9
    var arrJiShu2 = new Array(); //奇数位*2的积 >9

    var arrOuShu = new Array();  //偶数位数组
    for (var j = 0; j < newArr.length; j++) {
        if ((j + 1) % 2 == 1) {//奇数位
            if (parseInt(newArr[j]) * 2 < 9)
                arrJiShu.push(parseInt(newArr[j]) * 2);
            else
                arrJiShu2.push(parseInt(newArr[j]) * 2);
        }
        else //偶数位
            arrOuShu.push(newArr[j]);
    }

    var jishu_child1 = new Array();//奇数位*2 >9 的分割之后的数组个位数
    var jishu_child2 = new Array();//奇数位*2 >9 的分割之后的数组十位数
    for (var h = 0; h < arrJiShu2.length; h++) {
        jishu_child1.push(parseInt(arrJiShu2[h]) % 10);
        jishu_child2.push(parseInt(arrJiShu2[h]) / 10);
    }

    var sumJiShu = 0; //奇数位*2 < 9 的数组之和
    var sumOuShu = 0; //偶数位数组之和
    var sumJiShuChild1 = 0; //奇数位*2 >9 的分割之后的数组个位数之和
    var sumJiShuChild2 = 0; //奇数位*2 >9 的分割之后的数组十位数之和
    var sumTotal = 0;
    for (var m = 0; m < arrJiShu.length; m++) {
        sumJiShu = sumJiShu + parseInt(arrJiShu[m]);
    }

    for (var n = 0; n < arrOuShu.length; n++) {
        sumOuShu = sumOuShu + parseInt(arrOuShu[n]);
    }

    for (var p = 0; p < jishu_child1.length; p++) {
        sumJiShuChild1 = sumJiShuChild1 + parseInt(jishu_child1[p]);
        sumJiShuChild2 = sumJiShuChild2 + parseInt(jishu_child2[p]);
    }
    //计算总和
    sumTotal = parseInt(sumJiShu) + parseInt(sumOuShu) + parseInt(sumJiShuChild1) + parseInt(sumJiShuChild2);

    //计算Luhm值
    var k = parseInt(sumTotal) % 10 == 0 ? 10 : parseInt(sumTotal) % 10;
    var luhm = 10 - k;

    if (lastNum == luhm && lastNum.length != 0) {
        //$("#banknoInfo").html("Luhm验证通过");
        return true;
    }
    else {
        //$("#banknoInfo").html("银行卡号必须符合Luhm校验");
        return false;
    }
}