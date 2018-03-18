var heartbeatInterval = 120000;
$(document).ready(function () {
    getHeartbeatInterval();
    var time1 = window.setInterval(heartbeatCheck, heartbeatInterval);
    //window.clearInterval(timer1)
    //window.clearTimeout(time1);

    //heartbeatCheck();
});

function getHeartbeatInterval() {
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "heartbeat";
    paramter.action = "getheartbeatinterval";
    paramter.enabled = true;
    var json = getJson(paramter, false);
    if (json.result) {
        heartbeatInterval = json.data;
    }
}
function heartbeatCheck() {
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "heartbeat";
    paramter.action = "heartbeatcheck";
    paramter.enabled = true;
    var json = getJson(paramter, true);
    if (json.result) {

    }
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
                result = json;
            },
            error: function () { alert("服务器没有返回数据，可能服务器忙，请重试"); }
        });
    }
    catch (ex) { alert("服务器忙，请稍后重试"); }
    return result;
}