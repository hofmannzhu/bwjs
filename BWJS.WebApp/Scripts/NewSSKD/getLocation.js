﻿
var getLocation = {

    //经度
    longitude: "",
    //纬度
    latitude: "",
    //省市区
    address: "",
    //json
    addressObj: "",

    getLocation: function () {
        var options = {
            enableHighAccuracy: true,
            maximumAge: 1000
        }
        if (navigator.geolocation) {
            //浏览器支持geolocation
            navigator.geolocation.getCurrentPosition(onSuccess, onError, options);
        } else {
            //浏览器不支持geolocation
            bwjsAlert('您的浏览器不支持地理位置定位');
        }
    },
    //end

    //浏览器原生获取经纬度方法
    latAndLon: function (callback, error) {
        var that = this;
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var latitude = position.coords.latitude;
                var longitude = position.coords.longitude;
                localStorage.setItem("latitude", latitude);
                localStorage.setItem("longitude", longitude);
                var data = {
                    latitude: latitude,
                    longitude: longitude
                };
                if (typeof callback == "function") {
                    callback(data);
                }
            },
                function () {
                    if (typeof error == "function") {
                        error();
                    }
                });
        } else {
            if (typeof error == "function") {
                error();
            }
        }
    },

    //微信JS-SDK获取经纬度方法
    weichatLatAndLon: function (callback, error) {
        var that = this;
        var timestamp = new Date().getTime() + "";
        timestamp = timestamp.substring(0, 10);
        var ranStr = randomString();

        //微信接口配置
        wx.config({
            debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
            appId: 'XXXXXXXXXXXXXXXXX', // 必填，公众号的唯一标识
            timestamp: timestamp, // 必填，生成签名的时间戳
            nonceStr: ranStr, // 必填，生成签名的随机串
            signature: 'XXXXXXXXXXXXXXXXX',// 必填，签名，见附录1
            jsApiList: ['checkJsApi',
                'getLocation'
            ] // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
        });

        //参见微信JS SDK文档：http://mp.weixin.qq.com/wiki/7/aaa137b55fb2e0456bf8dd9148dd613f.html
        wx.ready(function () {

            wx.getLocation({
                success: function (res) {
                    var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90
                    var longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。
                    var speed = res.speed; // 速度，以米/每秒计
                    var accuracy = res.accuracy; // 位置精度
                    localStorage.setItem("latitude", latitude);
                    localStorage.setItem("longitude", longitude);
                    var data = {
                        latitude: latitude,
                        longitude: longitude
                    };
                    if (typeof callback == "function") {
                        callback(data);
                    }
                },
                cancel: function () {
                    //这个地方是用户拒绝获取地理位置
                    if (typeof error == "function") {
                        error();
                    }
                }
            });

        });
        wx.error(function (res) {
            if (typeof error == "function") {
                error();
            }
        });
    },
    //将经纬度转换成城市名和街道地址，参见百度地图接口文档：http://developer.baidu.com/map/index.php?title=webapi/guide/webservice-geocoding
    cityname: function (latitude, longitude, callback) {
        $.ajax({
            url: 'http://api.map.baidu.com/geocoder/v2/?ak=btsVVWf0TM1zUBEbzFz6QqWF&callback=renderReverse&location=' + latitude + ',' + longitude + '&output=json&pois=1',
            type: "get",
            dataType: "jsonp",
            jsonp: "callback",
            success: function (data) {
                console.log(data);
                var province = data.result.addressComponent.province;
                var cityname = (data.result.addressComponent.city);
                var district = data.result.addressComponent.district;
                var street = data.result.addressComponent.street;
                var street_number = data.result.addressComponent.street_number;
                var formatted_address = data.result.formatted_address;
                localStorage.setItem("province", province);
                localStorage.setItem("cityname", cityname);
                localStorage.setItem("district", district);
                localStorage.setItem("street", street);
                localStorage.setItem("street_number", street_number);
                localStorage.setItem("formatted_address", formatted_address);
                //domTempe(cityname,latitude,longitude);
                var data = {
                    latitude: latitude,
                    longitude: longitude,
                    cityname: cityname
                };
                if (typeof callback == "function") {
                    callback(data);
                }

            }
        });
    },
    //设置默认城市
    setDefaultCity: function (callback) {
        alert("获取地理位置失败！");
        //默认经纬度
        var latitude = "31.337882";
        var longitude = "120.616634";
        var cityname = "苏州市";
        localStorage.setItem("latitude", latitude);
        localStorage.setItem("longitude", longitude);
        localStorage.setItem("cityname", cityname);
        localStorage.setItem("province", "江苏省");
        localStorage.setItem("district", "虎丘区");
        localStorage.setItem("street", "珠江路");
        localStorage.setItem("street_number", "88号");
        localStorage.setItem("formatted_address", "江苏省苏州市虎丘区珠江路88号");
        var data = {
            latitude: latitude,
            longitude: longitude,
            cityname: cityname
        };
        if (typeof callback == "function") {
            callback(data);
        }
    },
    //更新地理位置
    refresh: function (callback) {
        var that = this;
        //重新获取经纬度和城市街道并设置到localStorage
        that.latAndLon(
            function (data) {
                that.cityname(data.latitude, data.longitude, function (datas) {
                    if (typeof callback == "function") {
                        callback();
                    }
                });
            },
            function () {
                that.setDefaultCity(function () {
                    if (typeof callback == "function") {
                        callback();
                    }
                });
            });
    }
};



//成功时
function onSuccess(position) {
    //经度
    longitude = position.coords.longitude;
    //纬度
    latitude = position.coords.latitude;
    bwjsAlert('经度' + longitude + '，纬度' + latitude);

    //根据经纬度获取地理位置，不太准确，获取城市区域还是可以的
    var map = new BMap.Map("allmap");
    var point = new BMap.Point(longitude, latitude);
    var gc = new BMap.Geocoder();
    gc.getLocation(point, function (rs) {
        var addComp = rs.addressComponents;
        bwjsAlert(addComp.province + ", " + addComp.city + ", " + addComp.district + ", " + addComp.street + ", " + addComp.streetNumber);
        bwjsAlert(JSON.stringify(rs));
        address = addComp.province + ", " + addComp.city + ", " + addComp.district + ", " + addComp.street + ", " + addComp.streetNumber;
        addressObj = rs;
    });
}
//失败时
function onError(error) {
    switch (error.code) {
        case 1:
            bwjsAlert("位置服务被拒绝");
            break;
        case 2:
            bwjsAlert("暂时获取不到位置信息");
            break;
        case 3:
            bwjsAlert("获取信息超时");
            break;
        case 4:
            bwjsAlert("未知错误");
            break;
    }
}

