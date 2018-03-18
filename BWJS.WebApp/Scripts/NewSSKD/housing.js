document.writeln(
'<div class="col-lg-10 col-sm-10 col-xs-10 bg-a">' +
'<span class="success-box"><img src="../../Content/img/NewSSKD/head-success-dot.png" /></span>' +
'<div class="winBox">' +
'<ul>' +
'<li>保定市涿州市的周先生2018年1月21成功获得房贷45万元</li>' +
'<li>保定市涿州市的赵女士2018年1月22成功获得房贷80万元</li>' +
'<li>保定市曲阳县的李先生2018年1月23成功获得房贷50万元</li>' +
'<li>保定市易县的张女士2018年1月23成功获得房贷63万元</li>' +
'<li>保定市阜平县的高先生2018年1月23成功获得房贷50万元</li>' +
'</ul>' +
'</div>' +
'</div>'
);

$(function () {
    //获得当前<ul>
    var $uList = $(".winBox ul");
    var timer = null;
    //触摸清空定时器
    $uList.hover(function () {
        clearInterval(timer);
    },
    function () { //离开启动定时器
        timer = setInterval(function () {
            scrollList($uList);
        },
        5000);
    }).trigger("mouseleave"); //自动触发触摸事件
    //滚动动画
    function scrollList(obj) {
        //获得当前<li>的高度
        var scrollHeight = $("ul li:first").height();
        //滚动出一个<li>的高度
        $uList.stop().animate({
            marginTop: -scrollHeight
        },
        400,
        function () {
            //动画结束后，将当前<ul>marginTop置为初始值0状态，再将第一个<li>拼接到末尾。
            $uList.css({
                marginTop: 0
            }).find("li:first").appendTo($uList);
        });
    }
});