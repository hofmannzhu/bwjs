
document.writeln(

//'<div class="col-lg-10 col-sm-10 col-xs-10 bg-a">'+
//'<span class="success-box"><img src="../../Content/img/NewSSKD/head-success-dot.png"></span><span class="success-box">' +
//'<div class="winBox">'+
//'<ul class="scroll">'+
//'<li>河北的李先生成功获得贷款5000元</li>'+
//'<li>四川的王女士2018年1月6日成功获得贷款2000元</li>'+
//'<li>山东的郑先生成功获得3000元贷款</a></li>'+
//'<li>宁夏的好女士2018年1月9成功获得贷款1300元</li>'+
//'<li>湖北的吴先生2018年1月12日成功获得贷款1300元</li>'+
//'<!--给所要的内容复制一份-->'+
//' <li>河北的李先生成功获得贷款5000元</li>'+
//' <li>四川的王女士2018年1月6日成功获得贷款2000元</li>'+
//'<li>山东的郑先生成功获得3000元贷款</a></li>'+
//'<li>宁夏的好女士2018年1月9成功获得贷款1300元</li>'+
//' <li>湖北的吴先生2018年1月12日成功获得贷款1300元</li>'+
//' </ul>'+
//' </div>'+
//' </span>'+
//' </div>'


'<div class="col-lg-10 col-sm-10 col-xs-10 bg-a">' +
'<span class="success-box"><img src="../../Content/img/NewSSKD/head-success-dot.png" /></span>' +
'<div class="winBox">' +
'<ul>' +
'<li>河北的李先生2018年1月6成功获得贷款5000元</li>' +
'<li>四川的王女士2018年1月6日成功获得贷款2000元</li>' +
'<li>山东的郑先生2018年1月6成功获得贷款3000元</li>' +
'<li>宁夏的好女士2018年1月9成功获得贷款1300元</li>' +
'<li>湖北的吴先生2018年1月12日成功获得贷款1300元</li>' +
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


