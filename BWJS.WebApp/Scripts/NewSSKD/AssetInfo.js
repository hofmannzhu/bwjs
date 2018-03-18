
var modelIdentityCardLibrary = {};
var modelNetLoanApply = {};

$(document).ready(function () {

    GetaInformation();
    $("#ValidCodeBT").attr("disabled", "disabled");
    $("#ValidCodeBT").click(function () {
        var moblie = $("#MobileId").val();
        var c = true;
        if (!moblie) {
            layer.msg('手机号不能为空！', 1, 3);
            c = false;
            return c;
        } else {
            var isIDCard2 = /^1[3|4|5|6|7|8|9][0-9]{9}$/; //验证规则
            var lengthvalue = document.getElementById('MobileId').value.length;
            if (lengthvalue == 11) {
                if (isIDCard2.test(document.getElementById('MobileId').value) === false) {
                    layer.msg('手机号输入不合法,请重新填写!', 2, 3, function () {
                        $("#MobileId").val("");
                    })
                    c = false;
                    return c;
                }
            } else {
                layer.msg('手机号位数不正确！', 1, 3);
                c = false;
                return c;
            }
        }
        if (c) {
            $.ajax({
                url: '/Ajax/MofangOrder/ValidCode.ashx',
                type: 'post',
                dataType: 'json',
                timeout: 0,
                async: true,
                data: {
                    Action: "ValidCodeAction",
                    moblie: moblie
                },
                success: function (result) {
                    if (result.isSend == "ok") {
                        $("#sedMSM").val("ok");
                        $("#NumberId").val(result.number);
                    }
                    else {
                        $("#sedMSM").val("");
                        $("#NumberId").val("");
                    }

                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    if (textStatus != 'timeout') {
                        //   alert(xmlHttpRequest.responseText);
                    } else {
                    }
                }
            });
        }
    });


    $("#AreaCodeID").change(function () {
        var label = document.getElementById("ShowCode");
        label.innerText = $("#AreaCodeID").val() + "+";
        var label1 = document.getElementById("ShowCode1");
        label1.innerText = $("#AreaCodeID").val() + "+";
        var label2 = document.getElementById("ShowCode2");
        label2.innerText = $("#AreaCodeID").val() + "+";
    });

    $("#AreaCodeID1").change(function () {
        var label1 = document.getElementById("ShowCode1");
        label1.innerText = $("#AreaCodeID").val() + "+";
    });

    $("#readCardId").click(function () {
        return false;
    });

    $("#next-addinfo").click(function () {
        return nextaddinfoClick();
    });

});


//页面初始化，如果用户三要素存在，将最新的详细信息显示出来
function GetaInformation() {
    var arraylist = "";
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "newnetloan";
    paramter.action = "GetaInformation";
    paramter.idNo = $("#hididNo").val();
    paramter.Mobile = $("#hidMobile").val();
    paramter.FullName = $("#hidFullName").val();
    var json = getJson(paramter, false);
    //myAlert(JSON.stringify(json));
    if (json.success) {
        //arraylist = json.data;
        //$("#SeleCity1").val(json.data.consultml.ProvinceId);
        //$("#SeleCity2").val(json.data.consultml.CityId);
        //$("#SeleCity3").val(json.data.consultml.DistrictId);
        //$("#AddressId").val(json.data.consultml.Address);
        //$("#MonthlyIncomeId").val(json.data.professionInfo.MonthlyIncome);
        //$("#WorkingHourId").val(json.data.professionInfo.WorkingHour);
        //$("#FundId").val(json.data.professionInfo.Fund);
        //$("#PayrollId").val(json.data.professionInfo.Payroll);
        //$("#DegreeId").val(json.data.professionInfo.Degree);
        //$("#HousesId").val(json.data.identityInfo.HousingStatus);
        //$("#CarsId").val(json.data.identityInfo.DrivingLicense);
        //$("#OtherLoansId").val(json.data.identityInfo.OtherLoan);
        //$("#SesameSeedId").val(json.data.identityInfo.SesameSeed);
        //$("#TaobaoAccountId").val(json.data.identityInfo.TaobaoAccount);
        //$("#CreditCardId").val(json.data.assetInfo.CreditCard);
        //$("#CreditSituationId").val(json.data.identityInfo.CreditHistory);
        //$("#CreditCardServiceLifenId").val(json.data.identityInfo.CreditCardAgeLimit);

    }
}


function nextaddinfoClick() {
    var ConsultId = $("#hidConsultId").val();
    var token = $("#hiddToken").val();
    var FullName = $("#hidFullName").val();
    var IDNo = $("#hididNo").val();
    try {
        var professionInfo = {};
        professionInfo.ConsultId = ConsultId;
        professionInfo.FullName = FullName;
        professionInfo.Age = 0;
        professionInfo.MonthlyIncome = 5;
        //$("#MonthlyIncomeId").val();
        professionInfo.Company = '';
        professionInfo.UnitNature = 0;
        professionInfo.WorkingHour = $("#WorkingHourId").val();
        professionInfo.Payroll = $("#PayrollId").val();
        professionInfo.JobPosition = 0;
        professionInfo.SocialSecurit = 0;
        professionInfo.Fund = $("#FundId").val();
        professionInfo.Degree = $("#DegreeId").val();
        professionInfo.GraduationYear = 0;

        var identityInfo = {};
        identityInfo.ConsultId = ConsultId;
        identityInfo.FullName = FullName;
        identityInfo.IDNo = IDNo;
        identityInfo.MonthlyIncome = 5;
        //$("#MonthlyIncomeid").val();
        identityInfo.CreditHistory = $("#CreditSituationId").val();
        identityInfo.HousingStatus = $("#HousesId").val();
        identityInfo.DrivingLicense = $("#CarsId").val();
        identityInfo.Face = 0;
        identityInfo.IdentityCardScanner = 0;
        identityInfo.DebitCard = 0;
        identityInfo.CreditCard = 0;
        identityInfo.ParticleLoan = 0;
        identityInfo.BusinessPolicy = $("#BusinessPolicyId").val();
        identityInfo.CreditCardAgeLimit = $("#CreditCardServiceLifenId").val();
        identityInfo.OtherLoan = $("#OtherLoansId").val();
        identityInfo.SesameSeed = $("#SesameSeedId").val();
        identityInfo.TaobaoAccount = $("#TaobaoAccountId").val();
        identityInfo.Company = 0;
        identityInfo.UnitNature = 0;
        identityInfo.WorkingHour = $("#WorkingHourId").val();
        identityInfo.Payroll = $("#PayrollId").val();
        identityInfo.JobPosition = 0;
        identityInfo.SocialSecurit = 0;
        identityInfo.Fund = $("#FundId").val();
        identityInfo.Degree = $("#DegreeId").val();
        identityInfo.GraduationYear = 0;

        var assetInfo = {};
        assetInfo.ConsultId = ConsultId;
        assetInfo.Cars = $("#CarsId").val();
        assetInfo.Houses = $("#HousesId").val();
        assetInfo.OtherLoans = $("#OtherLoansId").val();
        assetInfo.SesameSeed = $("#SesameSeedId").val();
        assetInfo.TaobaoAccount = $("#TaobaoAccountId").val();
        assetInfo.ParticleLoan = 0;
        assetInfo.BusinessPolicy = $("#BusinessPolicyId").val();
        assetInfo.CreditCard = $("#CreditCardId").val();
        assetInfo.CreditSituation = $("#CreditSituationId").val();
        assetInfo.CreditCardServiceLife = $("#CreditCardServiceLifenId").val();

        getcontacts();

        var paramter = {};
        paramter.op = "bwjs";
        paramter.om = "newnetloan";
        paramter.action = "UpdataConsult";
        paramter.ConsultId = ConsultId;
        paramter.ProvinceId = $("#SeleCity1").val();
        paramter.CityId = $("#SeleCity2").val();
        paramter.DistrictId = $("#SeleCity3").val();
        paramter.Area = "";
        paramter.Address = $("#AddressId").val();
        paramter.sign = $("#hidsign").val();
        paramter.orderNo = $("#hidorderNo").val();
        paramter.array = JSON.stringify(list);
        paramter.professionInfo = JSON.stringify(professionInfo);
        paramter.identityInfo = JSON.stringify(identityInfo);
        paramter.assetInfo = JSON.stringify(assetInfo);
        paramter.token = token;
        paramter.equipmentNo = $("#hiddEquipmentNo").val();
        paramter.merchantsNo = $("#hiddMerchantsNo").val();
        var json = getJson(paramter, false);
        if (json.success) {

            $("#jsForm").submit();
        }
        else {
            myAlert(json.message);
        }
    }
    catch (e) {
        myAlert(e.message);
    }
}
function GetSeleCity2() {
    setSelectOption('SeleCity2', $('#SeleCity1').val(), '-请选择-');
}

function GetSeleCity3() {
    setSelectOption('SeleCity3', $('#SeleCity2').val(), '-请选择-');
}

function setSelectOption(selectObj, optionList, firstOption) {
    if (typeof selectObj != 'object') {
        selectObj = document.getElementById(selectObj);
    }
    // 清空选项
    removeOptions(selectObj);
    // 选项计数
    var start = 0;
    // 如果需要添加第一个选项
    if (firstOption) {
        selectObj.options[0] = new Option(firstOption, '');
        GetCityArea(selectObj, optionList);
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
    var number = parseInt($("#hidNumber").val());
    if (number != "") {
        for (var i = 1; i <= number; i++) {
            list.push(new Contact($("#RelationContact_" + i + "").val(), $("#ContactName_" + i + "").val(), $("#ContactMobile_" + i + "").val()));
        }
    }
}

function removeOptions(selectObj) {
    if (typeof selectObj != 'object') {
        selectObj = document.getElementById(selectObj);
    }
    // 原有选项计数

    var len = selectObj.options.length;
    for (var i = 0; i < len; i++) {
        // 移除当前选项
        selectObj.options[0] = null;
    }
}
function GetCityArea(selectObj, ParentID) {
    $.ajax({
        type: "GET",
        async: false,
        dataType: "text",
        url: "../../../Ajax/BWJS/HCityArea.ashx?r=" + Math.random(),
        data: { Action: "GetCityArea", ParentID: ParentID },
        success: function (data) {
            $(selectObj).html(data);
        }
    });
}

//显示添加页面
function ShowAssetInfo() {
    location.href = "LikeToCollect.aspx";
    return false;
}
