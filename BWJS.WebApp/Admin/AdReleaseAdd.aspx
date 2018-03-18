<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdReleaseAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.AdReleaseAdd" %>

<!DOCTYPE html>

<script src="../Scripts/jquery.min.js"></script>
<script src="../Scripts/bootstrap.min.js"></script>
<link href="../Content/css/bootstrap.min.css" rel="stylesheet" />
<link rel="stylesheet" href="/Content/css/Admin/main.css">
<script src="../Scripts/jquery.dataTables.min.js"></script>
<link href="../Content/css/jquery.dataTables.css" rel="stylesheet" />
<link href="../Content/css/jquery.dataTables.min.css" rel="stylesheet" />
<script src="../Scripts/uril.js"></script>
<script src="../Scripts/WdatePicker/WdatePicker.js"></script>
<script src="../Scripts/WdatePicker/config.js"></script>
<script src="../Scripts/WdatePicker/calendar.js"></script>
<link href="../Scripts/skin/layer.ext.css" rel="stylesheet" />
<script src="../Scripts/layer.min.js"></script>
<link href="../Scripts/skin/layer.css" rel="stylesheet" />
<script src="../Scripts/jquery-form.js"></script>
<script src="/Scripts/layer.js"></script>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <!--添加广告 start-->
    <div class="form-box form-user tabshow">
        <form method="post" class="form-horizontal" role="form" id="jsForm" enctype="multipart/form-data">
            <ul>
                <li class="form-group">
                    <label class="col-sm-3 control-label">广告名称:</label>
                    <div class="col-sm-9">
                        <input id="AdReleaseNameId" name="AdReleaseName" type="text" class="form-control fl " placeholder="广告名称" style="width: 100%; height: 30px" /><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label">广告开始时间:</label>
                    <div class="col-sm-9">
                        <input id="BeginTimeId" name="BeginTime" type="text" class="form-control fl Wdate" placeholder="广告开始时间" style="width: 100%; height: 30px" /><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label">广告结束时间：</label>
                    <div class="col-sm-9">
                        <input id="EndTimeId" name="EndTime" type="text" class="form-control fl Wdate" placeholder="广告结束时间" style="width: 100%; height: 30px" /><em>*</em>
                    </div>
                </li>
                <%--    name="ResourceInfo"--%>
                <li class="form-group">
                    <label class="col-sm-3 control-label">上传文件：</label>
                    <div class="col-sm-9">
                        <div class="col-sm-12">
                            <label id="txtAdReleaseFile" datavalue="">（文件传入）</label><em>*</em>
                        </div>
                        <div class="col-sm-12">
                            <input id="AdReleaseFileLoad" name="FileLoad1" type="file" style="display: none" onchange="fileChange(this);" />
                            <input type="hidden" id="hidResourceID" name="hidResourceID" />
                            <input type="button" value="添加文件" onclick="$('#AdReleaseFileLoad').click();" class="btn btn-default " />
                            <input type="button" value="删除文件" onclick="DelAdReleaseUrl()" class="btn btn-default " />
                            <%--  <a href="#" id="BrandAdReleaseUrl" class="imgFile" target="_blank" style="display: none">查看</a>--%>
                        </div>
                    </div>


                </li>
                <li class="form-group">
                    <label class="col-sm-3 control-label">广告位绑定：</label>
                    <div class="col-sm-9">
                        <select name="province" id="AdPositionID" style="width: 500px; height: 30px"></select><em>*</em>
                    </div>
                </li>

                <li class="form-group">
                    <div class="col-sm-10 text-center">
                        <input id="SubmitID" type="button" class="btn btn-info" onclick="Submit()" value="添加保存" />
                        <button type="reset" class="btn btn-danger btn-group-lg" onclick="ReturnList()">返回</button>
                    </div>
                </li>
            </ul>
        </form>
    </div>

    <div class="form-box " style="width: 720px; height: 230px" id="IsShow">

        <img id="imgID" style="width: 680px; height: 180px; padding-bottom: 20px" src="../Content/img/Admin/bg-white.png" />

    </div>
</body>
</html>
<script type="text/javascript">
    var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 
    
    $(document).ready(function () {
        $("#IsShow").hide();
        GetAdPosition();
        $('#BeginTimeId').on('focus', function () {
            WdatePicker({ minDate:'<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%>',onpicked: function (db) { db.$('EndTimeId').focus(); }, dateFmt: 'yyyy-MM-dd HH:mm:ss' });
        });
        $('#EndTimeId').on('focus', function () {
            WdatePicker({ minDate: '#F{$dp.$D(\'BeginTimeId\')}', dateFmt: 'yyyy-MM-dd HH:mm:ss' });
        });
        
        $("#AdReleaseFileLoad").bind("change", function () {
            var filename = this.value;
            if (tipsFile($("#txtAdReleaseFile"), filename, '|jpg|jpeg|png|')) {
                $("#txtAdReleaseFile").html(this.value);
                $("#txtAdReleaseFile").attr("dataValue", this.value);
            }
            else {
                $("#AdReleaseFileLoad").val('');
                layer.msg('暂不支持该文件格式', 2, 1);
                return;
            }
        });

        if (<%=AdReleaseID%> > 0) {
            $("#IsShow").show();
            EditData();
        }


    
    });


    // 判断是否为IE浏览器： /msie/i.test(navigator.userAgent) 为一个简单正则
    var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
    function fileChange(target){
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
            layer.msg('附件不能大于10M！',2, 1); 
            DelAdReleaseUrl();
            parent.layer.close(2);
            return;
        }
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
    function GetAdPosition() {
        $.ajax({
            type: "GET",
            async: false,
            dataType: "text",
            url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
            data: { Action: "GetAdPositionName",AdReleaseID:<%=AdReleaseID%>},
            success: function (data) {
                $("#AdPositionID").html(data);
            }
        });
    }

    function ReturnList() {
        parent.layer.close(index);
    }
    //function Submitwww(){
    //    $("#jsForm").submit();
    //}
    
    function EditData() {
        GetAdPosition();
        var videoBtn = document.getElementById("SubmitID");
        videoBtn.innerHTML = "修改保存";
   
        if (<%=AdReleaseID%> > 0) {
            $.ajax({
                type: "GET",
                async: false,
                dataType: "json",
                url: "../Ajax/Admin/HAdRelease.ashx?r=" + Math.random(),
                data: { Action: "GetAdReleaseOne", AdReleaseID: <%=AdReleaseID%> },
                success: function (data) {
                    $("#BeginTimeId").val(data.BeginTime);
                    $("#EndTimeId").val(data.EndTime);
                    $("#AdReleaseNameId").val(data.AdReleaseName);
                    if (data.ResourceID!=null) {
                        $("#hidResourceID").val(data.ResourceID);
                        $("#txtAdReleaseFile").html(data.ResourceInfo);
                        $("#AdPositionID").val(data.AdPositionID);
                        $("#imgID").attr("src", data.ResourceInfo);
                    }
                }
            });
        }
    }
    //adreleasemodel()
    function Submit() {
        var strmsg='添加';
        if (<%=AdReleaseID%>>0) {
            strmsg='修改';
        }
        if (VerificationIsNull()) {

            var jsonFrm =JSON.stringify($('#jsForm').serialize());
            var options = {
                type: "POST",
                async: false,
                dataType: "text",
                url: "../Ajax/Admin/HAdRelease.ashx?r=" + Math.random(),
                data: { Action: "AdReleaseAddList", AdReleaseID: <%=AdReleaseID%>, AdPositionID:$("#AdPositionID").val(),AdReleaseModel: JSON.stringify(adreleasemodel()),DataModel:jsonFrm},
                success: function (data) {
                    if (data > 0) {
                        parent.layer.msg(strmsg+'成功', 1, 1);
                        setTimeout( function(){
                            parent.layer.close(index);
                            window.parent.GetAdPositionList();
                        }, 1000 );
                        return true;
                    } else {
                        layer.msg(strmsg+'失败！', 2, 1);
                        return false;
                    }
                }
            };
            $("#jsForm").ajaxSubmit(options);
        }
    }


    function VerificationIsNull(){
        var b=true;
        var AdReleaseName=$("#AdReleaseNameId").val();
        if (AdReleaseName=="") {
            layer.alert('广告名称不能为空！', { closeBtn: 0, anim: 4 });
            b= false;
            return;
        }
        if (AdReleaseName.length>50) {
            layer.alert('广告名称过长,请重新填写！', { closeBtn: 0, anim: 4 });
            b= false;
            return;
        }
        if (AdReleaseRepeat(AdReleaseName)) {
            layer.alert('广告名称重复,重新填写！', { closeBtn: 0, anim: 4 });
            return false;
        }
        if ($("#BeginTimeId").val()=="") {
            layer.alert('开始时间不能为空！', { closeBtn: 0, anim: 4 });
            b= false;
            return;
        };
        if ($("#EndTimeId").val()=="") {
            layer.alert('结束时间不能为空！', { closeBtn: 0, anim: 4 });
            b= false;
            return;
        };
        if ($("#txtAdReleaseFile").html()=="（文件传入）") {
            layer.alert('上传文件不能为空！', { closeBtn: 0, anim: 4 });
            b= false;
            return;
        }
        if ($("#AdPositionID").val()=="") {
            layer.alert('广告位不能为空！', { closeBtn: 0, anim: 4 });
            b= false;
            return;
        }
      
        return  b;
    }
    function AdReleaseRepeat(AdReleaseName){
        var b = false;
        $.ajax({
            type: "GET",
            async: false,
            dataType: "text",
            url: "../Ajax/Admin/HAdRelease.ashx?r=" + Math.random(),
            data: { Action: "AdReleaseRepeat", AdReleaseName: AdReleaseName,AdReleaseID:<%=AdReleaseID%>},
            success: function (data) {
                if (data==1) {
                    b = true;
                }
            }
        });
        return b;}

    //设置合同信息
    function AdReleaseInfo() {
        this.AdReleaseID="";
        this.BeginTime="";
        this.EndTime="";
        this.ResourceID="";
        this.ResourceInfo="";
        this.CreatUserID="";
        this.RecordUpdateUserID="";
        this.RecordIsDelete="";
        this.RecordUpdateTime="";
        this.RecordCreateTime="";
        this.AdReleaseName="";
        this.Remark="";
    }

    function adreleasemodel() {
        var adreleaseInfo = new AdReleaseInfo();
        adreleaseInfo.AdReleaseID = <%=AdReleaseID%>;
        adreleaseInfo.AdReleaseName = $("#AdReleaseNameId").val();
        adreleaseInfo.BeginTime = $("#BeginTimeId").val();
        adreleaseInfo.EndTime = $("#EndTimeId").val();
        adreleaseInfo.ResourceInfo=$("#AdReleaseFileLoad").val();
        
        adreleaseInfo.ResourceID=  $("#hidResourceID").val()==""?0:$("#hidResourceID").val();

        adreleaseInfo.RecordUpdateUserID = 1;
        adreleaseInfo.CreatUserID = 1;
        adreleaseInfo.RecordUpdateAdReleaseID = 1;


        adreleaseInfo.RecordIsDelete = 0;

        adreleaseInfo.RecordUpdateTime =  '<%=System.DateTime.Now %>';
        adreleaseInfo.RecordCreateTime = '<%=System.DateTime.Now %>';
        return adreleaseInfo;
    }

    function DelAdReleaseUrl() {
        $("#txtAdReleaseFile").attr("dataValue", "");
        $("#txtAdReleaseFile").html("（文件传入）");
        $("#AdReleaseFileLoad").val("");
        //$("#BrandAdReleaseUrl").hide();
    }
   
</script>

