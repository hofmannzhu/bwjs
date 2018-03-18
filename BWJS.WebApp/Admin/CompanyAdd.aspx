<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.CompanyAddpx" ValidateRequest="false" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css">
    <link rel="stylesheet" href="/Content/css/Admin/main.css">
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/layer.min.js"></script>
    <script src="/Scripts/jquery-form.js"></script>
    <style>
        .row {
            margin-top: 0px;
        }
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div class="form-box form-user">
        <form method="post" class="form-horizontal" role="form" id="jsForm" enctype="multipart/form-data">
            <%--        <form method="post" class="form-horizontal" role="form" id="jsForm" runat="server">--%>
            <div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">渠道名称：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="CompanyNameId" name="CompanyName" maxlength="100" class="form-control" placeholder="请填写渠道名称" required data-msg-required="必填" data-msg-age="请填写渠道名称" /><em>*</em>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">

                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">负责人：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="CompanyManagerId" name="CompanyManager" maxlength="50" class="form-control" placeholder="请填写负责人名称" /><em>*</em>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">手机：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="MobileId" name="Mobile" maxlength="15" class="form-control" placeholder="请填写手机" required data-msg-required="必填" data-msg-age="请填写手机" /><em>*</em>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">电话：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="PhoneId" name="Phone" class="form-control" placeholder="请填写电话" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">QQ：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="QQId" name="QQ" class="form-control" placeholder="请填写QQ" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">微信：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="WechatId" name="Wechat" class="form-control" placeholder="请填写微信" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">公众号：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="PublicWechatId" name="PublicWechat" class="form-control" placeholder="请填写公众号" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">官网主页：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="SiteUrlId" name="SiteUrl" class="form-control" placeholder="请填写官网主页" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">主营品牌：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="MainBrandId" name="LoginName" class="form-control" placeholder="请填写主营品牌" required data-msg-required="必填" data-msg-age="请填写主营品牌" />
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">产品名称：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="MainBusinessId" name="UserName" class="form-control" placeholder="请填写产品名称" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">渠道分类：</div>
                            </div>
                            <div class="col-sm-8">
                                <select name="CompanyCategoryId" id="CompanyCategoryId" class="form-control"></select>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">对接方式：</div>
                            </div>
                            <div class="col-sm-9">
                                <label>
                                    <input name="DockingMode" type="radio" value="0" id="radio8" onchange="ChanDockingMode(0)" checked>
                                    手持设备</label>
                                <label>
                                    <input name="DockingMode" type="radio" value="1" id="radio9" onchange="ChanDockingMode(1)">
                                    PC
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">状态：</div>
                            </div>
                            <div class="col-sm-9">
                                <label>
                                    <input name="inpStatus" type="radio" value="0" id="Status0" checked>
                                    正常</label>
                                <label>
                                    <input name="inpStatus" type="radio" value="1" id="Status1">
                                    锁定</label>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">API地址：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="APIId" name="LoginName" class="form-control" placeholder="请填写API地址" />
                            </div>
                        </div>
                    </div> 
                </div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="text-right">显示推荐码：</div>
                            </div>
                            <div class="col-sm-9">
                                <label>
                                    <input name="IsDisplay" type="radio" value="1" id="radio2" checked>
                                    是</label>
                                <label>
                                    <input name="IsDisplay" type="radio" value="0" id="radio3">
                                    否</label>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <%--//是否依赖主键--%>
                                <div class="text-right">自制推荐码：</div>
                            </div>
                            <div class="col-sm-9">
                                <label>
                                    <input name="IsRelyOnPrimaryKey" type="radio" value="1" id="radio4" onchange="ChangeKey(1)" checked>
                                    是</label>
                                <label>
                                    <input name="IsRelyOnPrimaryKey" type="radio" value="0" id="radio5" onchange="ChangeKey(0)">
                                    否</label>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group" id="IsShowRecommend">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">推荐码前缀：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="RecommendationPrefix" name="RecommendationPrefix" class="form-control" placeholder="请填写推荐码前缀" required data-msg-required="必填" data-msg-age="请填推荐码前缀" />
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">推荐码长度：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" id="RecommendationLength" name="RecommendationLength" class="form-control" placeholder="请填写推荐码长度" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-6" id="IsShowCode">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">推荐码：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="RecommendationCode" name="LoginName" class="form-control" placeholder="请填写推荐码" />
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="col-md-4 text-right">排序编号：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="OrderId" name="UserName" class="form-control" placeholder="请填写排序编号" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group" id="IsShowAPK">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class=" text-right">是否含安装包：</div>
                            </div>
                            <div class="col-sm-9">
                                <label>
                                    <input name="IsAPK" type="radio" value="1" id="radio6" onchange="ChangeIsAPK(1)">
                                    是</label>
                                <label>
                                    <input name="IsAPK" type="radio" value="0" onchange="ChangeIsAPK(0)" id="radio7" checked>
                                    否</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group" id="IsShow">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="col-md-4 text-right">Android路径：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="AndroidURL" name="UserName" class="form-control" placeholder="请填写Android路径" /><em>*</em>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6" id="IsShowIOS">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">IOS路径：</div>
                            </div>
                            <div class="col-sm-8">
                                <input type="text" value="" id="IosURL" name="LoginName" class="form-control" placeholder="请填写IOS路径" required data-msg-required="必填" data-msg-age="请填写IOS路径" /><em>*</em>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group" id="IsShowQRCode">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-2" style="margin-left: -32px">
                                <div class="col-md-4 text-right">二维码地址：</div>
                            </div>
                            <div class="col-sm-10">
                                <div class="col-sm-9" style="margin-left: -10px">
                                    <input type="text" id="txtQRCodeId" class="form-control" placeholder="（文件传入）" readonly="readonly" />
                                </div>
                                <div class="col-sm-3">
                                    <input id="QRCodeIdFileLoad" name="FileLoad1" type="file" style="display: none" onchange="fileChange(this);" />
                                    <input type="button" value="添加文件" onclick="$('#QRCodeIdFileLoad').click();" class="btn btn-default " />
                                    <input type="button" value="删除文件" onclick="DelQRCodeUrl()" class="btn btn-default " />
                                    <%--<a href="#" id="QRCodeIdUrl" class="imgFile" target="_blank">查看</a>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-2" style="margin-left: -32px">
                                <div class="col-md-4 text-right">Logo：</div>
                            </div>
                            <div class="col-sm-10">
                                <div class="col-sm-9" style="margin-left: -10px">
                                    <input type="text" id="txtLogoFile" name="Logo" class="form-control" placeholder="（文件传入）" readonly="readonly" />
                                </div>
                                <div class="col-sm-3">
                                    <input id="LogoFileLoad" name="FileLoad2" type="file" style="display: none" onchange="fileChange(this);" />
                                    <input type="button" value="添加文件" onclick="$('#LogoFileLoad').click();" class="btn btn-default " />
                                    <input type="button" value="删除文件" onclick="DelLogoUrl()" class="btn btn-default " />
                                    <%--     <a href="#" id="DefaultPicUrl" class="imgFile" target="_blank">查看</a>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="">
                                <div class="col-md-4 text-right">备注：</div>
                            </div>
                            <div class="col-sm-8">
                                <textarea id="RemarkId" name="Remark" class="form-control" placeholder="请填写备注" style="max-width: 100%"></textarea>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-3" style="margin-left: -32px">
                                <div class="col-md-4 text-right">描述Html：</div>
                            </div>
                            <div class="col-sm-8">
                                <textarea id="DescriptionHtml" name="DescriptionHtml" class="form-control" placeholder="请填写html" style="max-width: 100%"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
               <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-left: -23px">
                            <div class="col-md-4 text-right">审核条件：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="AuditConditions" name="AuditConditions" class="form-control" placeholder="请填写审核条件" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-left: -23px">
                            <div class="col-md-4 text-right">详细地址：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="AddressId" name="Address" class="form-control" placeholder="请填写详细地址" style="width: 98%" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-10 text-center">
                        <input id="SubmitID" type="button" class="btn btn-info" value="提交注册" style="width: 200px; margin-left: 100px" />
                        <button type="reset" class="btn btn-danger btn-group-lg" onclick="ReturnList()" style="width: 200px; margin-left: 100px">返回</button>
                    </div>
                </div>
            </div>
            <input type="hidden" id="hidUserID" name="UserID" value="0" />
            <input type="hidden" id="hidRecordUpdateTime" name="RecordUpdateTime" value="" />
        </form>

    </div>
</body>
</html>
<script type="text/javascript">
    var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 
    $(document).ready(function () {
        $("#IsShow").hide();
        $("#IsShowCode").hide();
        GetCompanyCategory();
        if (<%=CompanyId%> > 0) {
            EditData();
        }

        $("#LogoFileLoad").bind("change", function () {
            flagMsg='';
            var filename = this.value;
            if (tipsFile($("#txtLogoFile"), filename, '|jpg|jpeg|png|')) { 
                $("#txtLogoFile").val(this.value);
                $("#txtLogoFile").attr("dataValue", this.value);
            }
            else { 
                $("#txtQRCodeId").val(filename);
                layer.msg('暂不支持该文件格式', 1, 3);
                flagMsg='暂不支持该文件格式';
                return;
            }
        });
        $("#QRCodeIdFileLoad").bind("change", function () {
            flagMsg='';
            var filename = this.value;
            if (tipsFile($("#txtQRCodeId"), filename, '|jpg|jpeg|png|')) { 
                $("#txtQRCodeId").val(this.value);
                $("#txtQRCodeId").attr("dataValue", this.value);
            }
            else { 
                $("#txtQRCodeId").val(filename);
                layer.msg('暂不支持该文件格式', 1, 3);
                flagMsg='暂不支持该文件格式';
                return;
            }
        });
        $("#SubmitID").click(function (){
            var strmsg='添加';
            if (<%=CompanyId%>>0) {
                strmsg='修改';
            }
            if (VerificationIsNull()) {
                var jsonFrm =JSON.stringify($('#jsForm').serialize());
                var CompanyId = <%=CompanyId%>; 
           
                
                $("#jsForm").ajaxSubmit( {
                    type: "POST",
                    async: false,
                    dataType: "text",
                    url: "/Ajax/Admin/HCompany.ashx?r=" + Math.random(),
                    data: { 'Action': "AddCompany", 'CompanyId': CompanyId,'CompanyModel': JSON.stringify(Companymodel()),'DataModel':jsonFrm },
                    success: function (data) {
                        if (data > 0) {
                            parent.layer.msg(strmsg+'成功', 2,1); 
                            setTimeout( function(){
                                window.parent.location.reload();
                                parent.layer.close(index);
                            }, 1000 );
                        } else {
                            layer.msg(strmsg+'失败', 1,3); 
                        }
                    }
                });
            }
        });
    });

    function ReturnList() {
        parent.layer.close(index);
    }

    function DelLogoUrl() {
        $("#txtLogoFile").val("");
        $("#LogoFileLoad").val("");
    }
    function DelQRCodeUrl() {
        $("#txtQRCodeId").val("");
        $("#QRCodeIdFileLoad").val("");
    }


    //验证input file 上传文件类型是否符合要求
    //$obj  要显示提示标签参照控件
    //filename  上传附件的文件名
    //suffix  支持的后缀名
    function tipsFile($obj, filename, suffix) {
        var mime = filename.toLowerCase().substr(filename.lastIndexOf("."));
        mime = mime.substring(1);
        if (suffix.indexOf(mime) > -1) {
            return true;
        }
        var content = "上传附件格式不正确,只支持" + suffix;

        var t = $obj.offset().top,
            l = $obj.offset().left,
            h = $obj.outerHeight() + 5;
        var divStr = '<div class="tip" style="opacity: 0.9; width: auto; height: auto; top: ' + (t + h) + 'px; left: ' + (l + 10) + 'px; z-index:99999999;">'
            + '<div class="tip-normal tip-main"><div class="tip-normal tip-text">'
            + '<div style="color: #ff0000;"><img src="/Images/form_error_new.png" />' + content + '</div></div></div>'
            + '<div class="tip-normal tip-top" style="border-width: 0 9px 9px; top: -1px; left: 33px;"></div></div>';
        var $div = $("#validate");
        if ($div.size() == 0) {
            $("body").append('<div id="validate">' + divStr + '</div>');
        } else {
            $div.empty().append(divStr);
        }
        $obj.focus();
        $obj.change(function () {
            $("#validate > div").slideUp(500);
        });
        $("#validate").click(function () {
            $("#validate > div").slideUp(500);
        });
        return false;
    }


    // 判断是否为IE浏览器： /msie/i.test(navigator.userAgent) 为一个简单正则
    var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
    function fileChange(target){
        flagMsg='';
        var fileSize = 0;
        if (isIE && !target.files) {    // IE浏览器
            var filePath = target.value; // 获得上传文件的绝对路径
            var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
            // GetFile(path) 方法从磁盘获取一个文件并返回。
            var file = fileSystem.GetFile(filePath);
            fileSize = file.Size;    // 文件大小，单位：b
        }
        else {    // 非IE浏览器
            fileSize = target.files[0].size;
        }
        var size = fileSize / 1024 / 1024;
        if (size > 10) {
            layer.msg('附件不能大于10M！', 1, 3);
            DelAdReleaseUrl(); 
            flagMsg='附件不能大于10M！'; 
            return;
        }
    } 
    function VerificationIsNull(){
        var b=true;
        if ($("#CompanyNameId").val()=="") {
            layer.msg('渠道名称不能为空！', 1,3); 
            b= false;
            return;
        };
        if ($("#CompanyManagerId").val()=="") {
            layer.msg('负责人不能为空！', 1,3); 
            b= false;
            return;
        }
        if ($("#MobileId").val()=="") {
            layer.msg('手机号不能为空！', 1,3); 
            b= false;
            return;
        }else{
            var isIDCard2 =/^1[3|4|5|7|8][0-9]{9}$/; //验证规则
            var lengthvalue = document.getElementById('MobileId').value.length;
            if (lengthvalue == 11) {
                if (isIDCard2.test(document.getElementById('MobileId').value) === false) {
                    layer.msg('手机号输入不合法,请重新填写!',2,3,function(){
                        $("#MobileId").val("");
                    })
                    b= false;
                    return;
                }
            }else{
                layer.msg('手机号位数不正确！', 1,3); 
                b= false;
                return;
            }
        }
        return  b;
    }

    function GetSeleCity2() {
        setSelectOption('SeleCity2', $('#SeleCity1').val(), '-请选择-');
    }

    function GetSeleCity3() {
        setSelectOption('SeleCity3', $('#SeleCity2').val(), '-请选择-');
    }
    function setSelectOption(selectObj, optionList, firstOption) {
        if (typeof selectObj != 'object') {
            selectObj = document.getElementById(selectObj);
        }
        // 清空选项
        removeOptions(selectObj);
        // 选项计数
        var start = 0;
        // 如果需要添加第一个选项
        if (firstOption) {
            selectObj.options[0] = new Option(firstOption, '');
            GetCityArea(selectObj, optionList);
        }
    }
    function removeOptions(selectObj) {
        if (typeof selectObj != 'object') {
            selectObj = document.getElementById(selectObj);
        }
        // 原有选项计数
        var len = selectObj.options.length;
        for (var i = 0; i < len; i++) {
            // 移除当前选项
            selectObj.options[0] = null;
        }
    }
    function GetCityArea(selectObj, ParentID) {
        $.ajax({
            type: "GET",
            async: false,
            dataType: "text",
            url: "../Ajax/BWJS/HCityArea.ashx?r=" + Math.random(),
            data: { Action: "GetCityArea", ParentID: ParentID },
            success: function (data) {
                $(selectObj).html(data);
            }
        });
    }
    function GetCompanyCategory() {
        $.ajax({
            type: "GET",
            traditional: false,
            async: false,
            dataType: "json",
            url: "../Ajax/Admin/HCompany.ashx?r=" + Math.random(),
            data: { Action: "GetCompanyCategory" },
            success: function (json) {
                if (json.result) {
                    $("#CompanyCategoryId").append("<option value=\"\">请选择...</option>");
                    $.each(json.data, function (key, value) {
                        $("#CompanyCategoryId").append("<option value=\"" + value.CompanyCategoryId + "\">" + value.CompanyCategoryName + " </option>");
                    });
                } else {
                    layer.alert(json.msg);
                }
            }
        });
    };

    function ChangeIsAPK(IsAPK) {
        if (IsAPK == "1") {
            $("#IsShow").show();
        } else {
            $("#IsShow").hide();
            $("#AndroidURL").val("");
            $("#IosURL").val("");
        }
    }
    function ChanDockingMode(DockingMode) {
        if (DockingMode == "1") {
            $("#IsShowQRCode").hide();
            $("#IsShowAPK").hide();
            $("#IsShow").hide();
            $("#AndroidURL").val("");
            $("#IosURL").val("");
            DelQRCodeUrl();
        } else {
            ChangeIsAPK(0);
            $("#IsShowQRCode").show();
            $("#IsShowAPK").show();
            $("#IsShow").show();
           
         
        }
    }

    function ChangeKey(key) {
        if (key == "1") {
            $("#IsShowCode").hide();
            $("#IsShowRecommend").show();
            $("#RecommendationCode").val("");
        } else {
            $("#IsShowCode").show();
            $("#IsShowRecommend").hide();
            $("#RecommendationPrefix").val("");
            $("#RecommendationLength").val("");
        }
    }

    function EditData(){
        var videoBtn = document.getElementById("SubmitID");
        videoBtn.innerHTML = "修改";
        if (<%=CompanyId%> > 0) {
            $.ajax({
                type: "GET",
                async: false,
                dataType: "json",
                url: "../Ajax/Admin/HCompany.ashx?r=" + Math.random(),
                data: { Action: "GetCompanyOne", CompanyId: <%=CompanyId%> },
                success: function (data) {
                    $("#CompanyCategoryId").val(data.CompanyCategoryId);
                    $("#CompanyNameId").val(data.CompanyName);
                    $("#CompanyManagerId").val(data.CompanyManager);
                    $("#PhoneId").val(data.Phone);
                    $("#MobileId").val(data.Mobile);
                    $("#AuditConditions").val(data.AuditConditions);
                    $("#AddressId").val(data.Address);
                    $("#QQId").val(data.QQ);
                    $("#WechatId").val(data.Wechat);
                    $("#PublicWechatId").val(data.PublicWechat);
                    $("#SiteUrlId").val(data.SiteUrl);
                    $("#LogoFileLoad").attr("dataValue", data.Logo);
                    $("#txtLogoFile").val(data.Logo);
                    $("#APIId").val(data.API); 
                    $("#QRCodeIdFileLoad").attr("dataValue", data.QRCode);
                    $("#txtQRCodeId").val(data.QRCode);
                    $("#MainBrandId").val(data.MainBrand);
                    $("#MainBusinessId").val(data.MainBusiness);
                    if (data.IsDisplay == 1) {
                        $("#radio2").attr('checked', 'checked');
                    } else {
                        $("#radio3").attr('checked', 'checked');
                    }
                    if (data.IsRelyOnPrimaryKey == 1) {
                        $("#radio4").attr('checked', 'checked');
                        ChangeKey(1);
                    } else {
                        $("#radio5").attr('checked', 'checked');
                        ChangeKey(0);
                    }
                    $("#RecommendationPrefix").val(data.RecommendationPrefix);
                    $("#RecommendationLength").val(data.RecommendationLength);
                    $("#RecommendationCode").val(data.RecommendationCode);

                  
                    $("#RemarkId").val(data.Remark);
                    if (data.Status == 1) {
                        $("#Status1").attr('checked', 'checked');
                    } else {
                        $("#Status0").attr('checked', 'checked');
                    }
                    $("#OrderId").val(data.OrderId);
                    $("#AndroidURL").val(data.AndroidURL);
                    $("#IosURL").val(data.IosURL);
                    if (data.IsAPK == 1) {
                        ChangeIsAPK(1);
                        $("#radio6").attr('checked', 'checked');
                    } else {
                        ChangeIsAPK(0);
                        $("#radio7").attr('checked', 'checked');
                    }
                    if (data.DockingMode == 1) {
                        $("#radio9").attr('checked', 'checked');
                    } else {
                        $("#radio8").attr('checked', 'checked');
                    }
                
                    $("#DescriptionHtml").val(data.DescriptionHtml);
                }
            });
        }
    }
    function Companymodel() {
        var model = {};
        model.CompanyId=<%=CompanyId%>;
        model.CompanyName=$("#CompanyNameId").val();
        model.CompanyManager=$("#CompanyManagerId").val();
        model.Phone=$("#PhoneId").val();
        model.Mobile=$("#MobileId").val();
        model.Address=$("#AddressId").val();
        model.AuditConditions=$("#AuditConditions").val();
        model.QQ=$("#QQId").val();
        model.SiteUrl=$("#SiteUrlId").val();
        model.Remark=$("#RemarkId").val();
        model.Status= parseInt($("input[name='inpStatus']:checked").val());
        model.CompanyCategoryId=$("#CompanyCategoryId").val();
        model.Logo=$("#txtLogoFile").val();
        model.API=$("#APIId").val(); 
        model.QRCode=$("#txtQRCodeId").val();
        model.MainBrand=$("#MainBrandId").val();
        model.MainBusiness=$("#MainBusinessId").val();
        model.IsDisplay=parseInt($("input[name='IsDisplay']:checked").val());
        model.IsRelyOnPrimaryKey=parseInt($("input[name='IsRelyOnPrimaryKey']:checked").val());
        model.RecommendationPrefix=$("#RecommendationPrefix").val();
        model.RecommendationLength=$("#RecommendationLength").val()==""?"0":$("#RecommendationLength").val();
        model.RecommendationCode=$("#RecommendationCode").val();
        model.Wechat=$("#WechatId").val();
        model.PublicWechat=$("#PublicWechatId").val();
        model.OrderId=$("#OrderId").val();
        model.IsAPK=parseInt($("input[name='IsAPK']:checked").val());
        model.AndroidURL=$("#AndroidURL").val();
        model.IosURL=$("#IosURL").val();
        model.DockingMode=parseInt($("input[name='DockingMode']:checked").val());
        model.DescriptionHtml=$("#DescriptionHtml").val();
        model.IsDeleted=0;
        model.CreateId=<%=LoginUserID%>;
        model.EditId=<%=LoginUserID%>;
        model.CreateDate='<%=DateTime.Now%>';
        model.EditDate='<%=DateTime.Now%>';
        return model;
    }

        
</script>

