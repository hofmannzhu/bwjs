var helper = function () {
    return {
        transNo: "",
        caseCode: "",
        initProvince: function (objProvince, objCity, objDistrict) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "regionhelper";
            paramter.action = "getR";
            paramter.transNo = helper.transNo;
            paramter.caseCode = helper.caseCode;
            paramter.areaCode = "";
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.code + "\">" + value.text + "</option>";
                });
            }
            objProvince.html(html);
            objProvince.change(function () {
                helper.initCity(objCity, objDistrict, $(this).val());
                objDistrict.html("");
            });
        },

        initCity: function (objCity, objDistrict, areaCode) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "regionhelper";
            paramter.action = "getR";
            paramter.transNo = helper.transNo;
            paramter.caseCode = helper.caseCode;
            paramter.areaCode = areaCode;
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.code + "\">" + value.text + "</option>";
                });
            }
            objCity.html(html);
            objCity.change(function () {
                helper.initRegion(objDistrict, $(this).val());
            });
        },

        initRegion: function (objDistrict, areaCode) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "regionhelper";
            paramter.action = "getR";
            paramter.transNo = helper.transNo;
            paramter.caseCode = helper.caseCode;
            paramter.areaCode = areaCode;
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.code + "\">" + value.text + "</option>";
                });
            }
            objDistrict.html(html);
            objDistrict.change(function () {
                //alert($(this).val());
            });
        },

        ////////////////////////////////

        //areaTransNo: "",
        //areaCaseCode: "",
        //initProductPropertyArea: function () {
        //    var html = "<option value=\"\">请选择</option>";
        //    var paramter = {};
        //    paramter.op = "mofang";
        //    paramter.action = "getProductPropertyArea";
        //    paramter.transNo = helper.areaTransNo;
        //    paramter.caseCode = helper.areaCaseCode;
        //    paramter.areaCode = "";
        //    var json = getJson(paramter, false);
        //    if (json.result) {
        //        $.each(json.data, function (key, value) {
        //            html += "<option value=\"" + value.code + "\">" + value.text + "</option>";
        //        });
        //    }
        //    $("#inpProductPropertyArea").html(html);
        //},
        ////////////////////
        areaTransNo: "",
        areaCaseCode: "",
        ProductPropertyAreaProvince: function (objOne, objTwo, objThree) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "regionhelper";
            paramter.action = "getProductPropertyArea";
            paramter.transNo = helper.areaTransNo;
            paramter.caseCode = helper.areaCaseCode;
            paramter.areaCode = "";
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.code + "\">" + value.text + "</option>";
                });
            }
            objOne.html(html);
            objOne.change(function () {
                helper.ProductPropertyAreaCity(objTwo, objThree, $(this).val());
                objThree.html("");
            });
        },

        ProductPropertyAreaCity: function (objTwo, objThree, oneParentId) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "regionhelper";
            paramter.action = "getProductPropertyArea";
            paramter.transNo = helper.areaTransNo;
            paramter.caseCode = helper.areaCaseCode;
            paramter.areaCode = oneParentId;
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.code + "\">" + value.text + "</option>";
                });
            }
            objTwo.html(html);
            objTwo.change(function () {
                helper.ProductPropertyAreaDistrict(objThree, $(this).val());
            });
        },

        ProductPropertyAreaDistrict: function (objThree, twoParentId) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "regionhelper";
            paramter.action = "getProductPropertyArea";
            paramter.transNo = helper.areaTransNo;
            paramter.caseCode = helper.areaCaseCode;
            paramter.areaCode = twoParentId;
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.code + "\">" + value.text + "</option>";
                });
            }
            objThree.html(html);
            objThree.change(function () {
                //alert($(this).val());
            });
        },




    }
}();


//bootbox
function myAlert(msg) {
    bootbox.dialog({
        message: msg,
        buttons: {
            "success": {
                "label": "关闭",
                "className": "btn btn-sm btn-primary"
            }
        }
    });
}

function getJson(paramter, async) {
    var result = "";
    try {
        paramter.timeStamp = new Date().getTime();
        $.ajax({
            type: "post",
            url: "/ajax/helper.ashx",
            data: paramter,
            dataType: "json",
            async: async,
            success: function (json) {
                //if (json.result) {
                result = json;
                //}
                //else {
                //    myAlert(json.msg);
                //}
            },
            error: function () { myAlert("服务器没有返回数据，可能服务器忙，请重试"); }
        });
    }
    catch (ex) { myAlert("出错了，可能服务器忙，请重试"); }
    return result;
}