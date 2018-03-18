$(document).ready(function () {
});

//bootbox
function myAlert(msg) {
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