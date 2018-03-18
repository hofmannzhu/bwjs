var locationJson = null;
var provinceId = -1;
var province = "";
var cityId = -1;
var city = "";

$(document).ready(function () {
    $("#inpEmail").mailAutoComplete();
    locationJson = getLocationJson();
    initProvince($("#SeleCity1"), $("#SeleCity2"), $("#SeleCity3"));
    //myAlert(province + "," + city);
    if (provinceId != -1) {
        $("#SeleCity1").val(provinceId);
        //$("#SeleCity1").attr("disabled", "disabled");
        initCity($("#SeleCity2"), $("#SeleCity3"), provinceId);
        if (cityId != -1) {
            $("#SeleCity2").val(cityId);
            //$("#SeleCity2").attr("disabled", "disabled");
            initRegion($("#SeleCity3"), cityId);
        }
    }

    bindFormInpKeyupEvent();
});

function bindFormInpKeyupEvent() {
    $("#SeleCity3").bind("change", function () {
        keyUpCheck();
    });
    $("#inpAddress").bind("keyup", function () {
        keyUpCheck();
    });
    $("#inpCompanyName").bind("keyup", function () {
        keyUpCheck();
    });
    $("#inpEmail").bind("blur", function () {
        keyUpCheck();
    });
    $("#ContactName_1").bind("blur", function () {
        keyUpCheck();
    });
    $("#RelationContact_1").bind("change", function () {
        keyUpCheck();
    });
    $("#ContactMobile_1").bind("keyup", function () {
        keyUpCheck();
    });
    $("#ContactName_2").bind("blur", function () {
        keyUpCheck();
    });
    $("#RelationContact_2").bind("change", function () {
        keyUpCheck();
    });
    $("#ContactMobile_2").bind("keyup", function () {
        keyUpCheck();
    });
}

var canSubmit = false;
function keyUpCheck() {
    if ($.trim($("#SeleCity3").val()) &&
    $.trim($("#inpAddress").val()) &&
    $.trim($("#inpCompanyName").val()) &&
    $.trim($("#inpEmail").val()) &&
    $.trim($("#ContactName_1").val()) &&
    $.trim($("#RelationContact_1").val()) &&
    ($.trim($("#ContactMobile_1").val().length == 11)) &&
    $.trim($("#ContactName_2").val()) &&
    $.trim($("#RelationContact_2").val()) &&
    ($.trim($("#ContactMobile_2").val()).length == 11)) {
        $("#nextStep").removeClass("mr");
        $("#nextStep").addClass("gl");
        var checkResult = formCheck();
        if (checkResult) {
            clickBinding();
        }
        else {
            $("#nextStep").removeClass("gl");
            $("#nextStep").addClass("mr");
            $("#nextStep").unbind("click");
        }
        //clickBinding();
    }
    else {
        $("#nextStep").removeClass("gl");
        $("#nextStep").addClass("mr");
        $("#nextStep").unbind("click");
    }
}

function clickBinding() {
    if (!checkClickIsBind($("#nextStep"))) {
        $("#nextStep").bind("click", function () {
            $("#nextStep").removeClass("gl");
            $("#nextStep").addClass("dj");

            var checkResult = formCheck();
            if (checkResult) {
                if (!canSubmit) {
                    canSubmit = true;
                    return nextStepClick();
                }
            }
            else {
                $("#nextStep").removeClass("dj");
                $("#nextStep").addClass("gl");
            }
        });
    }
}

function formCheck() {
    var SeleCity3 = $.trim($("#SeleCity3").val());
    var inpAddress = $.trim($("#inpAddress").val());
    var inpCompanyName = $.trim($("#inpCompanyName").val());
    var inpEmail = $.trim($("#inpEmail").val());
    var ContactName_1 = $.trim($("#ContactName_1").val());
    var RelationContact_1 = $.trim($("#RelationContact_1").val());
    var ContactMobile_1 = $.trim($("#ContactMobile_1").val());
    var ContactName_2 = $.trim($("#ContactName_2").val());
    var RelationContact_2 = $.trim($("#RelationContact_2").val());
    var ContactMobile_2 = $.trim($("#ContactMobile_2").val());

    if (SeleCity3 == "") {
        myAlert("请选择所在城市");
        return false;
    }

    if (inpAddress == "") {
        myAlert("请填写现居住地址");
        return false;
    }

    if (inpCompanyName == "") {
        myAlert("请填写公司名称");
        return false;
    }

    if (inpEmail == "") {
        myAlert("请填写常用邮箱");
        return false;
    }
    else {
        if (!emailReg.test(inpEmail)) {
            myAlert("请输入正确的常用邮箱");
            return false;
        }
    }

    if (ContactName_1 == "") {
        myAlert("请填写紧急联系人姓名");
        return false;
    }
    else {
        if (!realnameReg.test(ContactName_1)) {
            myAlert("姓名只能输入2-4个汉字");
            return false;
        }
    }

    if (RelationContact_1 == "") {
        myAlert("请选择紧急联系人关系");
        return false;
    }

    if (ContactMobile_1 == "") {
        myAlert("请填写紧急联系人联系方式");
        return false;
    }
    else {
        if (!mobileReg2.test(ContactMobile_1)) {
            myAlert("请输入正确的联系方式");
            return false;
        }
    }

    if (ContactName_2 == "") {
        myAlert("请填写紧急联系人2姓名");
        return false;
    }
    else {
        if (!realnameReg.test(ContactName_2)) {
            myAlert("紧急联系人2姓名只能输入2-4个汉字");
            return false;
        }
    }

    if (RelationContact_2 == "") {
        myAlert("请选择紧急联系人2关系");
        return false;
    }

    if (ContactMobile_2 == "") {
        myAlert("请填写紧急联系人2联系方式");
        return false;
    }
    else {
        if (!mobileReg2.test(ContactMobile_2)) {
            myAlert("请输入正确的联系方式");
            return false;
        }
    }
    if (ContactName_1 == ContactName_2) {
        myAlert("紧急联系人姓名不能是同一个人");
        return false;
    }
    if (ContactMobile_1 == ContactMobile_2) {
        myAlert("紧急联系人联系方式不能相同");
        return false;
    }

    return true;
}
function nextStepClick() {
    var ConsultId = $("#hidConsultId").val();
    var token = $("#hiddToken").val();
    var FullName = $("#hidFullName").val();
    var IDNo = $("#hididNo").val();
    try {
        var sskdRequestParas = {};
        sskdRequestParas.PageLoadDateTime = $("#hiddPageLoadDateTime").val();
        sskdRequestParas.ConsultId = $("#hidConsultId").val();
        sskdRequestParas.Timestamp = $("#hiddTimestamp").val();
        sskdRequestParas.ProvinceId = $("#SeleCity1").val();
        sskdRequestParas.CityId = $("#SeleCity2").val();
        sskdRequestParas.DistrictId = $("#SeleCity3").val();
        sskdRequestParas.Address = $.trim($("#inpAddress").val());
        sskdRequestParas.CompanyName = $.trim($("#inpCompanyName").val());
        sskdRequestParas.Email = $.trim($("#inpEmail").val());
        sskdRequestParas.Sign = $("#hidsign").val();
        sskdRequestParas.OrderNo = $("#hidorderNo").val();
        sskdRequestParas.Token = $("#hiddToken").val();
        sskdRequestParas.EquipmentNo = $("#hiddEquipmentNo").val();
        sskdRequestParas.MerchantsNo = $("#hiddMerchantsNo").val();

        getcontacts();

        var paramter = {};
        paramter.op = "bwjs";
        paramter.om = "newnetloan";
        paramter.action = "fillintheinformation";
        paramter.sskdRequestParas = JSON.stringify(sskdRequestParas);
        paramter.array = JSON.stringify(list);
        bwjsLoadingDemo("努力加载中...");
        var json = getJson(paramter, false);
        if (json.success) {
            $("#jsForm").submit();
        }
        else {
            myAlert(json.message);
            canSubmit = false;
        }
    }
    catch (e) {
        myAlert(e.message);
    }
}

var list = [];
function Contact(relationId, contactName, contactMobile) {
    this.RelationId = relationId;
    this.FullName = contactName;
    this.Mobile = contactMobile;
}

function getcontacts() {
    list = [];
    for (var i = 1; i <= 2; i++) {
        list.push(new Contact($("#RelationContact_" + i + "").val(), $("#ContactName_" + i + "").val(), $("#ContactMobile_" + i + "").val()));
    }
}

function initProvince(objProvince, objCity, objDistrict) {
    var html = "<option value=\"\">请选择</option>";
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "getR";
    paramter.parentId = 1;
    var json = getJson(paramter, false);
    if (json.success) {
        $.each(json.data, function (key, value) {
            var selected = "";
            if (isContains(value.Name, province)) {
                provinceId = value.ID;
            }
            else {
                selected = "";
            }
            html += "<option value=\"" + value.ID + "\">" + value.Name + "</option>";
        });
    }
    objProvince.html(html);
    objProvince.change(function () {
        initCity(objCity, objDistrict, $(this).val());
        objDistrict.html("");
    });
}

function initCity(objCity, objDistrict, parentId) {
    var html = "<option value=\"\">请选择</option>";
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "getR";
    paramter.parentId = parentId;
    var json = getJson(paramter, false);
    if (json.success) {
        $.each(json.data, function (key, value) {
            var selected = "";
            if (isContains(value.Name, city)) {
                cityId = value.ID;
            }
            else {
                selected = "";
            }
            html += "<option value=\"" + value.ID + "\">" + value.Name + "</option>";
        });
    }
    objCity.html(html);
    objCity.change(function () {
        initRegion(objDistrict, $(this).val());
    });
}

function initRegion(objDistrict, parentId) {
    var html = "<option value=\"\">请选择</option>";
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "getR";
    paramter.parentId = parentId;
    var json = getJson(paramter, false);
    if (json.success) {
        $.each(json.data, function (key, value) {
            html += "<option value=\"" + value.ID + "\">" + value.Name + "</option>";
        });
    }
    objDistrict.html(html);
    objDistrict.change(function () {
        //alert($(this).val());
    });
}

function getLocationJson() {
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "getlocationjson";
    var json = getJson(paramter, false);
    if (json != null) {
        province = json.content.address_detail.province;
        city = json.content.address_detail.city;
        if (province != "") {
            province = province.replace("省", "");
            province = province.replace("市", "");
            province = province.replace("自治区", "");
            province = province.replace("特别行政区", "");
        }
        if (city != "") {
            city = city.replace("省", "");
            city = city.replace("市", "");
            city = city.replace("自治区", "");
            city = city.replace("特别行政区", "");
        }
    }
    return json;
}