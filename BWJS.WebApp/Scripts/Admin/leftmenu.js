$(document).ready(function () {
    //getLeftMenu();
    $(".right").addClass("addleft")

   


    $(".menu-box li.par").each(function () {
        $(this).click(function () {
            $(this).addClass("act").siblings("li.par").removeClass("act");
            $(this).next(".child").slideToggle();
        })
        if ($($(this).children("a"))[0] != undefined) {
            if ($($(this).children("a"))[0].href.replace(".aspx", "") == String(window.location).replace(window.location.search, "")) {
                $(this).addClass("actchild");
            }
        }
    });
    $("div.child li a").each(function () {
        if ($($(this))[0].href.replace(".aspx", "") == String(window.location).replace(window.location.search, "")) {
            $(this).parent().addClass('actchild');
            $(this).parent().parent().parent().prev().addClass('act')
            $(this).parent().parent().parent().show();
            //var divIndex = $(this).parent().parent().parent().index();
           // var liIndex = divIndex - 1;
            //$("#ulId ul>li").eq(liIndex).addClass('act')
        }
    });

    //张建永：左侧菜单的显示与隐藏效果 2017/09/29
    $(".noshow").click(function () {
        $(".left").hide();
        $(".right").addClass("isleft")
        $(".noshow1").show();
    })
    $(".noshow1").click(function () {
        $(".left").show();
        $(".right").removeClass("isleft")
        $(".noshow1").hide();
    })
});

function getLeftMenu() {
    var html = "";
    var paramter = {};
    paramter.op = "bwjs";
    paramter.om = "menu";
    paramter.action = "getleft";
    paramter.parentId = 0;
    var json = getJson(paramter, false);
    if (json.result) {
        myAlert(JSON.stringify(json))
        $.each(json.data, function (key, value) {
            html += "<option value=\"" + value.code + "\">" + value.text + "</option>";
        });
        $(".menu-box").html(html);
    }
}