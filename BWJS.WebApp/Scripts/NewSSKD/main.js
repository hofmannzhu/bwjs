; (function () {
    $(document).ready(function () {
        window.onload = function () {
            var boxh = document.body.clientHeight;

            $("#iframeId").height(boxh);

            $(window).resize(function () {
                $("#iframeId").height(boxh);
            });
        }
        var num = 0;
        function goLeft() {
            //750是根据你给的尺寸，可变的
            if (num == -750) {
                num = 0;
            }
            num -= 1;
            $(".scroll").css({
                left: num
            })
        }
        //设置滚动速度
        var timer = setInterval(goLeft, 20);
        //设置鼠标经过时滚动停止
        $(".box").hover(function () {
            clearInterval(timer);
        },
            function () {
                timer = setInterval(goLeft, 20);
            })
    })


}());