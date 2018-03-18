<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ceshi.aspx.cs" Inherits="BWJS.WebApp.Test.ceshi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>接口测试</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js"></script>
    <script src="/Scripts/layer.js"></script>
    <style>
        .bgcoclor {
            background: #4cff00;
        }
    </style>
</head>
<body>
    <form runat="server" method="post" class="form-horizontal" role="form" id="frmMain" name="frmMain" enctype="multipart/form-data">
        <div class="container">
            <div class="row bgcoclor">
                我思故我在
            </div>
        </div>
        <div class="container">
            <div class="row">
                <ul>
                    <li class="nav-parent">
                        <a href="javacsript:void(0)"><span>1</span></a>
                        <ul class="children">
                            <li><a href="javacsript:void(0)">1.1</a></li>
                            <li><a href="javacsript:void(0)">1.2</a></li>
                            <li><a href="javacsript:void(0)">1.3</a></li>
                        </ul>
                    </li>
                    <li class="nav-parent">
                        <a href="javacsript:void(0)"><span>2</span></a>
                        <ul class="children">
                            <li><a href="javacsript:void(0)">2.1</a></li>
                            <li><a href="javacsript:void(0)">2.2</a></li>
                            <li><a href="javacsript:void(0)">2.3</a></li>
                        </ul>
                    </li>
                    <li class="nav-parent">
                        <a href="javacsript:void(0)"><span>3</span></a>
                        <ul class="children">
                            <li><a href="javacsript:void(0)">3.1</a></li>
                            <li><a href="javacsript:void(0)">3.2</a></li>
                            <li><a href="javacsript:void(0)">3.3</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <script type="text/javascript">
                $(document).ready(function () {
                    var $container = $('.children'),
                    $trigger = $('.nav-parent');  // 分别获取所有的“父子”
                    $container.hide();// 隐藏所有的“子”
                    $trigger.first().find('.children').show();// 显示第一个“父”的子（展开第一个）      
                    $trigger.on('click', function (e) {// 当“父”发生点击事件
                        if ($(this).find('.children').is(':hidden')) {
                            $trigger.find('.children').hide(300);// 关闭其他
                            $(this).find('.children').show(300);// 显示自己
                        }
                        e.preventDefault();
                    });
                });
            </script>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-lg-3 text-right">ajaxLoading</div>
                <div class="col-lg-7">
                    <asp:Button ID="btnAjaxLoading" runat="server" Text="ajax loading ..." class="btn btn-default" />
                    <input id="saveButton" type="button" value="点击拍照" class="btn btn-default" data-loading-text="请稍等..." />
                    <input id="getAddress" type="button" value="获取位置" class="btn btn-default" data-loading-text="请稍等..." />
                    <input id="btnOpenGoogle" type="button" value="打开谷歌浏览器" class="btn btn-default" data-loading-text="请稍等..." />
                    <input id="openOne" type="button" value="弹出" class="btn btn-default" data-loading-text="请稍等..." />
                    <input id="btnOpenFullScreen" type="button" value="弹出即全屏" class="btn btn-default" data-loading-text="请稍等..." />
                    <br />
                    <div id="loading"></div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right">解析json</div>
                <div class="col-lg-7">
                    <asp:Button ID="btnJson" runat="server" Text="解析json" OnClick="btnJson_Click" /><br />
                    <span onclick="return test20171204();">测试</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right">接收号码</div>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtMsisdns" runat="server" TextMode="MultiLine" Width="500px" Text="13426086182"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right">发送内容</div>
                <div class="col-lg-7">
                    <asp:TextBox ID="txtSmsContent" runat="server" TextMode="MultiLine" Width="500px"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right"></div>
                <div class="col-lg-7">
                    <asp:Button ID="btnSmsSend" runat="server" Text="点我发送" OnClick="btnSmsSend_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right">发送结果</div>
                <div class="col-lg-7">
                    <asp:Literal ID="litSendResult" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right"></div>
                <div class="col-lg-7">
                    <asp:Button ID="btnRandom" runat="server" Text="生成6位随机数" OnClick="btnRandom_Click" />
                    <br />
                    <asp:Literal ID="litRandom" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right">身份证照片</div>
                <div class="col-lg-7">
                    <%--<img alt="" src="data:image/jpeg;base64,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" />--%>
                    <asp:Image ID="Image1" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right">当前经纬度</div>
                <div class="col-lg-7">
                    <asp:Literal ID="litLocationInfo" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right">JavaScript获取客户端IP[搜狐接口]</div>
                <div class="col-lg-7" id="litClentIp">
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 text-right">本机信息</div>
                <div class="col-lg-7">
                    <asp:Literal ID="litIpInfo" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <div class="container list-inline ">
            <input id="inpFile" name="inpFile" type="file" />
            <input id="btnFL" name="btnFL" type="button" value="upload" />
        </div>
        <div class="container list-inline ">
            <a href="/Mofang/PayResult.aspx">我要跳转</a>
            <a class="btn btn-success btn-sm btn-next" href="javascript:void(0)" id="btnAlert0">alert0</a>

            <span><a href="javascript:void(0)" id="btnAlert1">alert1</a></span>
            <span><a href="javascript:void(0)" id="btnAlert2">alert2</a></span>
            <span><a href="javascript:void(0)" id="btnAlert3">alert3</a></span>
            <span><a href="javascript:void(0)" id="btnConfirm1">Confirm1</a></span>
            <span><a href="javascript:void(0)" id="btnConfirm2">Confirm2</a></span>
        </div>
        <br />
        <div class="container list-inline ">

            <a class="btn btn-success btn-sm btn-next" data-toggle="modal" data-target="#myModal1" data-id="add" href="/Test/ceshi.aspx" title="新增">新增</a>
            <a class="btn btn-danger btn-sm btn-next" data-toggle="modal" data-target="#myModal1" data-id="edit" href="/Test/ceshi.aspx" title="编辑">编辑</a>
            <a class="btn btn-success btn-sm btn-next" data-toggle="modal" data-target="#hhtycfModal" data-id="03001" href="/Test/ceshi.aspx" title="模式对话框">模式对话框</a>
            <a class="btn btn-success btn-sm btn-next" title="模态窗口" id="modelDialogId1">模态窗口</a>

            <button class="btn btn-danger btn-sm btn-next" type="button" data-dismiss="modal">
                关闭
            </button>
        </div>
        <br />
        <span>
            <input id="btnAjax" name="btnAjax" type="button" value="Ajax" />
        </span>
        <span>
            <input id="btnProductInsuredArea" name="btnProductInsuredArea" type="button" value="Post" />
        </span>
        <span>
            <input id="btnOrderSummary" name="btnOrderSummary" type="button" value="OrderSummary" />
        </span>
        <div class="modal fade" id="hhtycfModal" tabindex="-1" role="dialog" aria-labelledby="hhtycfModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                        <h4 class="modal-title" id="hhtycfModalLabel">捌零易贷</h4>
                    </div>
                    <div class="modal-body">
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" data-backdrop="false">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                        <h4 class="modal-title" id="myModalLabel1">删除确认</h4>
                    </div>
                    <div class="modal-body">
                        <p>确认删除吗？</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-sm btn-primary">确认</button>
                        <button type="button" class="btn btn-sm btn-default" data-dismiss="modal">取消</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div id="map" style="width: 600px; height: 600px;">我在这，看我</div>

                <input type="hidden" id="transNo" name="transNo" value="111a9b83e771498bb137c58d0a53ead4" />
                <input type="hidden" id="CaseCode" name="CaseCode" value="0001077178502139" />

                <input type="button" id="btnApply" name="btnApply" value="立即购买" style="width: 200px; height: 50px; margin-bottom: 2px; background-color: aqua; border: 0; border-radius: 4px;" />
            </div>
        </div>

        <script type="text/javascript">

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

            $(document).ready(function () {
                //$("#btnFL").click(function () {
                //    $("#form1").submit();
                //});
                $("#btnFL").click(function () {
                    var formData = new FormData();
                    formData.append('inpFile', $('input[name=inpFile]')[0].files[0]);
                    $.ajax({
                        url: "/Test/ceshiHelper.ashx",
                        method: 'POST',
                        data: formData,
                        contentType: false,
                        processData: false,
                        cache: false,
                        success: function (data) {
                            if (JSON.parse(data).result == 1) {
                                $('.prompt').html("文件${JSON.parse(data).filename}已上传成功");
                            }
                        },
                        error: function (jqXHR) {
                            console.log(JSON.stringify(jqXHR));
                        }
                    })
                    .done(function (data) {
                        console.log('done');
                    })
                    .fail(function (data) {
                        console.log('fail');
                    })
                    .always(function (data) {
                        console.log('always');
                    });
                });


                $("#btnAlert0").click(function () {
                    myAlert("btnAlert0");
                });

                $("#btnAlert1").click(function () {
                    //myAlert("test");
                    bootbox.dialog({
                        message: "alert1",
                        buttons: {
                            "success": {
                                "label": "关闭",
                                "className": "btn btn-sm btn-primary"
                            }
                        }
                    });
                });

                $("#btnAlert2").click(function () {
                    bootbox.dialog({
                        message: "I am a custom confirm",
                        title: "Confirm title",
                        buttons: {
                            Cancel: {
                                label: "Cancel",
                                className: "btn-default",
                                callback: function () {
                                    alert("Cancel");
                                }
                            }
                            , OK: {
                                label: "OK",
                                className: "btn-primary",
                                callback: function () {
                                    alert("OK");
                                }
                            }
                        }
                    });

                });

                $("#btnAlert3").click(function () {
                    bootbox.alert({
                        buttons: {
                            ok: {
                                label: '我是ok按钮',
                                className: 'btn-myStyle'
                            }
                        },
                        message: '提示信息',
                        callback: function () {
                            alert('关闭了alert');
                        },
                        title: "bootbox alert也可以添加标题哦",
                    });
                });

                $("#btnConfirm1").click(function () {
                    bootbox.confirm("Hello world!", function (result) {
                        if (result) {
                            alert('点击了确认按钮');
                        } else {
                            alert('点击了取消按钮');
                        }
                    });
                });

                $("#btnConfirm2").click(function () {
                    bootbox.confirm({
                        buttons: {
                            confirm: {
                                label: '我是确认按钮',
                                className: 'btn-myStyle'
                            },
                            cancel: {
                                label: '我是取消按钮',
                                className: 'btn-default'
                            }
                        },
                        message: '提示信息',
                        callback: function (result) {
                            if (result) {
                                alert('点击确认按钮了');
                            } else {
                                alert('点击取消按钮了');
                            }
                        },
                        //title: "bootbox confirm也可以添加标题哦",  
                    });
                });

                $("#btnAjax").click(function () {


                    var paramter = {};
                    paramter.areaCode = $("#areaCode").val();
                    paramter.caseCode = $("#caseCode").val();
                    paramter.customkey = $("#customkey").val();
                    paramter.transNo = $("#transNo").val();
                    paramter.timeStamp = new Date().getTime();

                    var paramterData = JSON.stringify(paramter);
                    try {
                        $.ajax({
                            type: "post",
                            url: "http://landauni.ngrok.cc/yilucaifu-open/insurance/channelApi/productInsuredArea.html?sign=cedaccf324ff434246bee9e82c859fc2",
                            data: paramterData,
                            dataType: "json",
                            async: false,
                            traditional: true,
                            success: function (json) {
                                alert(json);
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(XMLHttpRequest.responseText);
                            }
                        });
                    }
                    catch (ex) { alert("ex:" + ex.message); }

                });

            });
        </script>

        <script type="text/javascript">

            $(document).ready(function () {

                $("#btnSave").click(function () {
                    $("#delModal").modal("hide");
                });

                $("#myModal1")
                    .on('show.bs.modal', function (e) {
                        //弹窗前判断是否选择了记录
                        var btn = $(e.relatedTarget);
                        var action = btn.data("id");
                        switch (action) {
                            case "edit":
                                //myAlert("您选择了编辑，请先选择一条数据");
                                break;
                            default:
                                break;
                        }
                    })
                    .on('shown.bs.modal', function (e) {
                        var btn = $(e.relatedTarget);
                        var action = btn.data("id");
                        switch (action) {
                            case "edit":
                                //GetModel给控件赋值并显示
                                break;
                            default:
                                break;
                        }
                    })
                    .on('hide.bs.modal', function () {
                    })
                    .on('hidden.bs.modal', function () {
                        //模式窗口关闭去，刷新页面
                    });

            });

        </script>

        <script type="text/javascript" src="http://api.map.baidu.com/api?v=2&ak=TBHTGEjDi6X1MRIthT3TLFvo5Zy07IhK"></script>
        <script type="text/javascript" src="http://developer.baidu.com/map/jsdemo/demo/convertor.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                //getLocation();
                //Test();
            });
            function Test() {

                //根据IP获取城市  
                var myCity = new BMap.LocalCity();
                myCity.get(function (obj) {
                    var error = "";
                    error += "," + obj.center.lng;
                    error += "," + obj.center.lat;
                    error += "," + obj.level;
                    error += "," + obj.name;
                    error += "," + obj.code;




                    //$.each(obj, function (key, value) {
                    //    error += "key=" + key + "," + ((error == "") ? (value) : ("," + value));
                    //    switch (key) {
                    //        case "center":
                    //            $.each(value, function (key, value) {
                    //                error += "\r\nkey=" + key + "," + ((error == "") ? (value) : ("," + value));
                    //            });
                    //            break;
                    //    }
                    //});
                    myAlert(error);
                });

            }
        </script>
        <script type="text/javascript">

            $(document).ready(function () {
                //getLocation();
            });


            var map;
            var gpsPoint;
            var baiduPoint;
            var gpsAddress;
            var baiduAddress;

            function getLocation() {
                //根据IP获取城市  
                var myCity = new BMap.LocalCity();
                myCity.get(getCityByIP);

                //获取GPS坐标  
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(showMap, handleError, { enableHighAccuracy: true, maximumAge: 1000 });
                } else {
                    alert("您的浏览器不支持使用HTML 5来获取地理位置服务");
                }
            }

            function showMap(value) {
                var longitude = value.coords.longitude;
                var latitude = value.coords.latitude;
                map = new BMap.Map("map");
                alert("坐标经度为：" + latitude + "， 纬度为：" + longitude);
                gpsPoint = new BMap.Point(longitude, latitude);    // 创建点坐标  
                map.centerAndZoom(gpsPoint, 15);

                //根据坐标逆解析地址  
                var geoc = new BMap.Geocoder();
                geoc.getLocation(gpsPoint, getCityByCoordinate);

                BMap.Convertor.translate(gpsPoint, 0, translateCallback);
            }

            translateCallback = function (point) {
                baiduPoint = point;
                var geoc = new BMap.Geocoder();
                geoc.getLocation(baiduPoint, getCityByBaiduCoordinate);
            }

            function getCityByCoordinate(rs) {
                gpsAddress = rs.addressComponents;
                var address = "GPS标注：" + gpsAddress.province + "," + gpsAddress.city + "," + gpsAddress.district + "," + gpsAddress.street + "," + gpsAddress.streetNumber;
                var marker = new BMap.Marker(gpsPoint);  // 创建标注  
                map.addOverlay(marker);              // 将标注添加到地图中  
                var labelgps = new BMap.Label(address, { offset: new BMap.Size(20, -10) });
                marker.setLabel(labelgps); //添加GPS标注      
            }

            function getCityByBaiduCoordinate(rs) {
                baiduAddress = rs.addressComponents;
                var address = "百度标注：" + baiduAddress.province + "," + baiduAddress.city + "," + baiduAddress.district + "," + baiduAddress.street + "," + baiduAddress.streetNumber;
                var marker = new BMap.Marker(baiduPoint);  // 创建标注  
                map.addOverlay(marker);              // 将标注添加到地图中  
                var labelbaidu = new BMap.Label(address, { offset: new BMap.Size(20, -10) });
                marker.setLabel(labelbaidu); //添加百度标注    
            }

            //根据IP获取城市  
            function getCityByIP(rs) {
                var cityName = rs.name;
                alert("根据IP定位您所在的城市为:" + cityName);
                var error = "";
                $.each(rs, function (key, value) {
                    error += "key=" + key + "," + ((error == "") ? (value) : ("," + value));
                    switch (key) {
                        case "center":
                            $.each(value, function (key, value) {
                                error += "\r\nkey=" + key + "," + ((error == "") ? (value) : ("," + value));
                            });
                            break;
                    }
                });
                myAlert(error);
            }

            function handleError(value) {
                switch (value.code) {
                    case 1:
                        alert("位置服务被拒绝");
                        break;
                    case 2:
                        alert("暂时获取不到位置信息");
                        break;
                    case 3:
                        alert("获取信息超时");
                        break;
                    case 4:
                        alert("未知错误");
                        break;
                }
            }

            //function init() {  
            //    getLocation();  
            //}  

            //window.onload = init;  

        </script>

        <script type="text/javascript">
            //// 百度地图API功能
            //var map = new BMap.Map("allmap");
            //var point = new BMap.Point(116.331398,39.897445);
            //map.centerAndZoom(point,12);

            //var geolocation = new BMap.Geolocation();
            //geolocation.getCurrentPosition(function(r){
            //    if(this.getStatus() == BMAP_STATUS_SUCCESS){
            //        var mk = new BMap.Marker(r.point);
            //        map.addOverlay(mk);
            //        map.panTo(r.point);
            //        alert('您的位置：'+r.point.lng+','+r.point.lat);
            //    }
            //    else {
            //        alert('failed'+this.getStatus());
            //    }        
            //},{enableHighAccuracy: true})


        </script>
        <script>
            $(document).ready(function () {
                //getCurLocation();
            });
            var x = document.getElementById("map");
            function getCurLocation() {

                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(showPosition);
                }
                else { x.innerHTML = "Geolocation is not supported by this browser."; }
            }
            function showPosition(position) {
                x.innerHTML = "Latitude: " + position.coords.latitude +
                "<br />Longitude: " + position.coords.longitude;
            }
        </script>
        <script type="text/javascript">
            $(document).ready(function () {

                //$.ajax({
                //    //url: "http://api.map.baidu.com/location/ip?ak=r1RHUvFS7cwX0i4yct6Gyzdu3nXKVDIc&coor=bd09ll",
                //    url: "/Test/ceshiHelper.ashx?r=" + Math.random(),
                //    type: "post",
                //    contentType: "application/json",
                //    data: null,
                //    dataType: "json",
                //    cache: false,
                //    traditional: true,
                //    success: function (json) {
                //        alert(JSON.stringify(json));
                //    },
                //    error: function (json) {
                //        var error = "";
                //        $.each(json, function (key, value) {
                //            switch (key) {
                //                case "status":
                //                case "statusText":
                //                    error += ((error == "") ? (value) : ("," + value));
                //                    break;
                //            }
                //        });
                //        myAlert(error);
                //    },
                //});

            });
        </script>

        <script type="text/javascript">

            $(document).ready(function () {
                $("#btnApply").click(function () {
                    var urlData = "";
                    urlData = "/Test/ceshiHelper.aspx";

                    //var options = {
                    //    type: "post",
                    //    async: false,
                    //    dataType: "text",
                    //    url: urlData,
                    //    //data: { DataModel: 1 },
                    //    data: { Action: "1" },
                    //    success: function (data) {
                    //        if (data > 0) {
                    //            layer.msg('添加成功！', 1, 1);
                    //            return true;
                    //        } else {
                    //            layer.msg('添加失败！', 2, 1);
                    //            return false;
                    //        }
                    //    }
                    //};
                    //$("#frmMain").ajaxSubmit(options);
                    $("#frmMain").attr("action", urlData);
                    $("#frmMain").submit();
                });
                $("#btnProductInsuredArea").click(function () {
                    var paras = {};
                    paras.r = Math.random();
                    paras.action = "btnProductInsuredArea_Click";
                    $.ajax({
                        url: "/Test/ceshiHelper.ashx",
                        type: "post",
                        data: paras,
                        dataType: "json",
                        cache: false,
                        traditional: true,
                        success: function (json) {
                            myAlert(JSON.stringify(json));
                        },
                        error: function (json) {
                            myAlert(JSON.stringify(json));
                        },
                    });
                });
                $("#btnOrderSummary").click(function () {
                    var paras = {};
                    paras.r = Math.random();
                    paras.action = "btnOrderSummary_Click";
                    $.ajax({
                        url: "/Test/ceshiHelper.ashx",
                        type: "post",
                        data: paras,
                        dataType: "json",
                        cache: false,
                        traditional: true,
                        success: function (json) {
                            myAlert(JSON.stringify(json));
                        },
                        error: function (json) {
                            myAlert(JSON.stringify(json));
                        },
                    });
                });
            });
        </script>

        <div id="allmap"></div>
        <script src="http://api.map.baidu.com/api?v=2.0&ak=TBHTGEjDi6X1MRIthT3TLFvo5Zy07IhK" type="text/javascript"></script>
        <script type="text/javascript">
            //// 百度地图API功能
            //var map = new BMap.Map("allmap");
            //var point = new BMap.Point(116.331398, 39.897445);
            //map.centerAndZoom(point, 12);

            //var geolocation = new BMap.Geolocation();
            //geolocation.getCurrentPosition(function (r) {
            //    if (this.getStatus() == BMAP_STATUS_SUCCESS) {
            //        var mk = new BMap.Marker(r.point);
            //        map.addOverlay(mk);
            //        map.panTo(r.point);
            //        myAlert('您的位置：' + r.point.lng + ',' + r.point.lat);
            //    }
            //    else {
            //        myAlert('failed' + this.getStatus());
            //    }
            //}, { enableHighAccuracy: true })
            ////关于状态码
            ////BMAP_STATUS_SUCCESS	检索成功。对应数值“0”。
            ////BMAP_STATUS_CITY_LIST	城市列表。对应数值“1”。
            ////BMAP_STATUS_UNKNOWN_LOCATION	位置结果未知。对应数值“2”。
            ////BMAP_STATUS_UNKNOWN_ROUTE	导航结果未知。对应数值“3”。
            ////BMAP_STATUS_INVALID_KEY	非法密钥。对应数值“4”。
            ////BMAP_STATUS_INVALID_REQUEST	非法请求。对应数值“5”。
            ////BMAP_STATUS_PERMISSION_DENIED	没有权限。对应数值“6”。(自 1.1 新增)
            ////BMAP_STATUS_SERVICE_UNAVAILABLE	服务不可用。对应数值“7”。(自 1.1 新增)
            ////BMAP_STATUS_TIMEOUT	超时。对应数值“8”。(自 1.1 新增)
        </script>

        <script src="http://pv.sohu.com/cityjson?ie=utf-8"></script>
        <script type="text/javascript">
            //$("#litClentIp").html(returnCitySN["cip"] + ',' + returnCitySN["cname"])
            //myAlert("20121018".replace(/^(\d{4})(\d{2})(\d{2})$/, "$1-$2-$3"));
            $("#modelDialogId1").click(function () {
                var url = "http://hhtycf.com/admins";
                //var sFeatures = {};
                //vReturnValue = window.showModalDialog(url, window, sFeatures);
                //vReturnValue = window.showModelessDialog(url, window, sFeatures);

                var iWidth = 800;
                var iHeight = 480;
                var iTop = (window.screen.availHeight - 30 - iHeight) / 2;
                var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;
                var win = window.open(url, "弹出窗口", "width=" + iWidth + ", height=" + iHeight + ",top=" + iTop + ",left=" + iLeft + ",toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no,alwaysRaised=yes,depended=yes");

            });
        </script>

        <script type="text/javascript">
            function test20171204() {
                var json1 = { "data": [], "success": true, "code": null, "message": null, "mark": true, "timestamp": 0 };
                var json = { "data": [{ "bankCardId": 95, "memberId": 54109591, "customerId": 129, "realName": "孙妍", "idNo": "130825199510124523", "bankCode": null, "bankCardNo": "6210985200023057882", "telNo": "8613066666666", "isCorrect": null }, { "bankCardId": 96, "memberId": 54109591, "customerId": 129, "realName": "孙妍", "idNo": "130825199510124523", "bankCode": null, "bankCardNo": "6217921470033088", "telNo": "8613066666666", "isCorrect": null }], "success": true, "code": null, "message": null, "mark": true, "timestamp": 0 };

                alert(json1.data);
                alert(json1.data.length);
                alert(json.data);
                alert(json.data.length);
                return false;
            }
        </script>
        <script type="text/javascript">
            $("#btnAjaxLoading").click(function () {
                $.ajax({
                    url: "",
                    type: "post",
                    data: {},
                    timeout: 15000,
                    beforeSend: function (XMLHttpRequest) {
                        $("#loading").html("<img src='/Content/images/loading.gif' />");
                    },
                    success: function (data, textStatus) {
                        //alert('开始回调，状态文本值：' + textStatus + ' 返回数据：' + data);
                        //$("#loading").empty();
                    },
                    complete: function (XMLHttpRequest, textStatus) {
                        //alert('远程调用成功，状态文本值：' + textStatus);
                        //$("#loading").empty();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //alert('error...状态文本值：' + textStatus + " 异常信息：" + errorThrown);
                        //$("#loading").empty();
                    }
                });
            });

            $(document).ready(function () {
                $("#saveButton").click(function () {
                    //$(this).button("操作中...");
                    //setTimeout(function () { $(this).button('reset'); }, 10000);
                    saveButtonClick($(this));
                });

                var i = 5;
                function saveButtonClick(obj) {
                    if (i == 1) {
                        obj.attr("disabled", false);
                        obj.val("点击拍照");
                        i = 5;
                        cameraClick();
                    }
                    else {
                        obj.attr("disabled", true);
                        obj.val("(" + i + ")秒后自动抓拍");
                        i--;
                        setTimeout(function () {
                            saveButtonClick(obj)
                        }
                        , 1000);
                    }
                    return false;
                }

                function cameraClick() {
                    alert("抓拍完毕");
                }

                $("#getAddress").click(function () {
                    getCurLocation();
                });



                $("#btnOpenFullScreen").click(function () {
                    openFullScreen();
                    return false;
                });
                function openFullScreen() {
                    var index = layer.open({
                        type: 2,
                        content: 'http://layim.layui.com',
                        area: ['320px', '195px'],
                        maxmin: true
                    });
                    layer.full(index);
                }

                $("#openOne").click(function () {
                    layertan();
                    return false;
                });
                function layertan() {
                    layer.open({
                        type: 2 //此处以iframe举例
                      , title: '授权认证'
                      , area: ['640px', '480px']
                      , shade: 0
                      , offset: [ //为了演示，随机坐标
                        Math.random() * ($(window).height() - 300)
                        , Math.random() * ($(window).width() - 390)
                      ]
                      , maxmin: true
                      , content: 'http://layim.layui.com'
                      , btn2: function () {
                          layer.closeAll();
                      }

                      , zIndex: layer.zIndex //重点1
                      , success: function (layero) {
                          layer.setTop(layero); //重点2
                      }
                    });
                }

                $("#btnOpenGoogle").click(function () {
                    openGoogle();
                    return false;
                });
                function openGoogle() {
                    var WSH = new ActiveXObject("WScript.Shell");
                    WSH.Run("chrome.exe   http://layim.layui.com");
                }

            });
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $(window.document).find(".bg").css({ "backgroud": "red" });

                var time = new Date(1515846324776);
                var y = time.getFullYear();//年
                var m = time.getMonth() + 1;//月
                var d = time.getDate();//日
                var h = time.getHours();//时
                var mm = time.getMinutes();//分
                var s = time.getSeconds();//秒
                //alert(y + "-" + m + "-" + d + " " + h + ":" + mm + ":" + s);

            });

        </script>
    </form>
</body>
</html>
