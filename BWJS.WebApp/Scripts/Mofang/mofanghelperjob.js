var helperjob = function () {
    return {
        transNo: "",
        caseCode: "",
        initOne: function (objOne, objTwo, objThree) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "jobhelper";
            paramter.action = "getJobInfo";
            paramter.transNo = helperjob.transNo;
            paramter.caseCode = helperjob.caseCode;
            paramter.parentId = "0";
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.id + "\">" + value.name + "</option>";
                });
            }
            objOne.html(html);
            objOne.change(function () {
                helperjob.initTwo(objTwo, objThree, $(this).val());
                objThree.html("");
            });
        },

        initTwo: function (objTwo, objThree, oneParentId) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "jobhelper";
            paramter.action = "getJobInfo";
            paramter.transNo = helperjob.transNo;
            paramter.caseCode = helperjob.caseCode;
            paramter.parentId = oneParentId;
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.id + "\">" + value.name + "</option>";
                });
            }
            objTwo.html(html);
            objTwo.change(function () {
                helperjob.initThree(objThree, $(this).val());
            });
        },

        initThree: function (objThree, twoParentId) {
            var html = "<option value=\"\">请选择</option>";
            var paramter = {};
            paramter.op = "mofang";
            paramter.om = "jobhelper";
            paramter.action = "getJobInfo";
            paramter.transNo = helperjob.transNo;
            paramter.caseCode = helperjob.caseCode;
            paramter.parentId = twoParentId;
            var json = getJson(paramter, false);
            if (json.result) {
                $.each(json.data, function (key, value) {
                    html += "<option value=\"" + value.id + "\">" + value.name + "</option>";
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