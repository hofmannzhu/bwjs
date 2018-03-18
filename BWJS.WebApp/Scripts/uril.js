        var defaultDataGridOption = {
            "bJQueryUI": true,
            "sPaginationType": "full_numbers",
            "sDom": '<""l>t<"F"fpi>',
            "bLengthChange": false,
            "bSort": true,
            "bFilter": false,
            "oLanguage": {
                "sZeroRecords": "没有找到符合条件的数据",
                "sInfoEmpty": "",
                "sInfo": "当前第 _START_ - _END_ 条　共计 _TOTAL_ 条",
                "oPaginate": {
                    "sFirst": "首页",
                    "sPrevious": "前一页",
                    "sNext": "后一页",
                    "sLast": "尾页"
                },
                "sInfoFiltered": "( 搜索完成 )"
            }
        };
        /* 侧边栏的初始化 */
        $(document).ready(function() {
            $('.fangsuo').click(function(e) {
                $('#content,#sidebar').toggleClass("folding");
                $('.fangsuo .fangsuo2').toggleClass("hide");
            });
            $('.submenu > a').click(function(e) {
                e.preventDefault();
                var submenu = $(this).siblings('ul'),
                    li = $(this).parents('li'),
                    submenus = $('.sideMenuBar li.submenu ul'),
                    submenus_parents = $('.sideMenuBar li.submenu');
                if (li.hasClass('open')) {
                    if (($(window).width() > 768) || ($(window).width() < 479)) { submenu.slideUp(); }
                    else { submenu.fadeOut(250); }
                    li.removeClass('open');
                } else {
                    if (($(window).width() > 768) || ($(window).width() < 479)) { submenus.slideUp(); submenu.slideDown(); }
                    else { submenus.fadeOut(250); submenu.fadeIn(250); }
                    submenus_parents.removeClass('open');
                    li.addClass('open');
                }
            });
            var ul = $('.sideMenuBar > ul');
            $('.sideMenuBar > a').click(function(e) {
                e.preventDefault();
                var sidebar = $('.sideMenuBar');
                if (sidebar.hasClass('open')) { sidebar.removeClass('open'); ul.slideUp(250); }
                else { sidebar.addClass('open'); ul.slideDown(250); }
            });
            $(window).resize(function() {
                w = $(window).width();
                if (w > 479) { ul.css({ 'display': 'block' }); $('#content-header .btn-group').css({ width: 'auto' }); }
                if (w < 479) { ul.css({ 'display': 'none' }); fix_position(); }
                if (w > 768) { $('#user-nav > ul').css({ width: 'auto', margin: '0' }); $('#content-header .btn-group').css({ width: 'auto' }); }
            });
            var w = $(window).width();
            if (w < 468) { ul.css({ 'display': 'none' }); fix_position(); }
            if (w > 479) { $('#content-header .btn-group').css({ width: 'auto' }); ul.css({ 'display': 'block' }); }
            function fix_position() {
                var uwidth = $('#user-nav > ul').width();
                $('#user-nav > ul').css({ width: uwidth, 'margin-left': '-' + uwidth / 2 + 'px' });
                var cwidth = $('#content-header .btn-group').width();
                $('#content-header .btn-group').css({ width: cwidth, 'margin-left': '-' + uwidth / 2 + 'px' });
            }
        });
        /* 下拉框的初始化 */
        $(document).ready(function() {
            $(".dropdown").each(function() {
                var i = $(this).find("[type=hidden]");
                var b = $(this).find(".xx");
                $(this).find("ul li a").click(function() {
                    var x1 = $(this).html(),
                    x2 = $(this).attr('data');
                    i.val(x2);
                    b.html(x1);
                }); //  这里注意 原来的写法  i.val(x2 || x1); 如果为空那么会读取 x1的值 那么就会出问题
            });
        });
        /* 时间戳转日期 */
        function getTime(/** timestamp=0 **/) {
            var ts = arguments[0] || 0;
            var t, y, m, d, h, i, s;
            t = ts ? new Date(ts * 1000) : new Date();
            y = t.getFullYear();
            m = t.getMonth() + 1;
            d = t.getDate();
            h = t.getHours();
            i = t.getMinutes();
            s = t.getSeconds();
            // 可根据需要在这里定义时间格式
            return y + "-" + (m < 10 ? "0" + m: m) + "-" + (d < 10 ? "0" + d: d) + " " + (h < 10 ? "0" + h: h) + ":" + (i < 10 ? "0" + i: i) + ":" + (s < 10 ? "0" + s: s);
        }
        /* 获取xxx(291923123) 中的数字时间戳 */
        function getdate(date) {
            var pa = /.*\((.*)\)/;
            var unixtime = date.match(pa)[1].substring(0, 10);
            return getTime(unixtime);
        }
        /* 显示控件的错误 */
        function showMassageInMoDal(id,eid,msg) {
            var m = $(eid).find(".control-label").html().replace(":", "") + msg;
            $(id+" .alert").attr("class", "alert alert-error").show().find("span").html(m);
        }
        /* 显示自定义的错误 */
        function showMassageInMoDal2(id,msg) {
            $(id+" .alert").attr("class", "alert alert-error").show().find("span").html(msg);
        }
        /* 审核的各个颜色 */
        function loadstatus(id) {
            var re = "";
            if (id == 0) { re = "<span class=\"text-info\">未审核</span>"; }
            else if (id == 1) { re = "<span class=\"text-success\">审核通过</span>"; }
            else if (id == 2) { re = "<span class=\"text-warning\">审核未通过</span>"; }
            else if (id == 3) { re = "<span class=\"muted\">违规</span>"; }
            return re;
        }
        /* 修改表单项名称 */
        function modify(jq, text) {
            $(jq).find(".control-label").html(text + ":");
            $(jq).find(".controls input").attr("placeholder", text);
        }
        function textmod(str) {
            var args = arguments, re = new RegExp("%([0-9]{1,2})", "g");
            return String(str).replace(re, function ($1, $2) { return args[$2]; });
        }
        //$.fn.dataTable.Api.register('column().data().sum()', function () {
        //    if (!this.length) return 0;
        //    return this.reduce(function (a, b) {
        //        return parseInt(a) + parseInt(b);
        //    });
        //});

/*********************************毛用啊*******************************/
        function goPage(newURL) {
            if (newURL != "") {
                if (newURL == "-") { resetMenu(); }
                else { document.location.href = newURL; }
            }
        }
        function resetMenu() {
            document.gomenu.selector.selectedIndex = 2;
        }