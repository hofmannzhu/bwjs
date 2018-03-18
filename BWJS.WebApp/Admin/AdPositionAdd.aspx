<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdPositionAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.AdPositionAdd" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css">
    <link rel="stylesheet" href="/Content/css/Admin/main.css">
    <link href="../Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="../Scripts/skin/layer.css" rel="stylesheet" />
    <script src="../Scripts/layer.min.js"></script>
    <script src="../Scripts/jquery-form.js"></script>
    <title></title>
</head>
<body>
    <!--添加广告位 start-->
    <div class="form-box ">
        <form method="post" class="form-horizontal" role="form" id="jsForm" enctype="multipart/form-data">
            <ul>
                <li class="form-group">
                    <label class="col-sm-2 control-label">名称:</label>
                    <div class="col-sm-10">
                        <input id="NameId" name="Name" class="form-control" type="text" placeholder="广告位名称" required /><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-2 control-label">排 序：</label>
                    <div class="col-sm-10">

                        <input id="SortId" name="SortId" class="form-control" type="text" placeholder="排 序" required /><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <label class="col-sm-2 control-label">广告类型：</label>
                    <div class="col-sm-10">
                        <select id="inpTypeId" name="inpTypeId" class="form-control">
                            <option value="1">PC</option>
                            <option value="2">Pad</option>
                        </select><em>*</em>
                    </div>
                </li>
                <li class="form-group">
                    <%--         DefaultPicUrl--%>
                    <label class="col-sm-2 control-label">默认图片：</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <label id="txtAdReleaseFile" datavalue="">（文件传入）</label><em>*</em>
                        </div>
                        <div class="col-sm-12">
                            <input id="AdReleaseFileLoad" name="FileLoad1" type="file" style="display: none" onchange="fileChange(this);" />
                            <input type="button" value="添加文件" onclick="$('#AdReleaseFileLoad').click();" class="btn btn-default " />
                            <input type="button" value="删除文件" onclick="DelAdReleaseUrl()" class="btn btn-default " />
                            <%--     <a href="#" id="DefaultPicUrl" class="imgFile" target="_blank">查看</a>--%>
                        </div>
                    </div>
                </li>

                <%--             <li class="form-group">
                    <label class="col-sm-2 control-label">编号：</label>
                    <div class="col-sm-10">
                        <input id="AdReleaseID" name="AdReleaseID" class="form-control" type="text" placeholder="编号" required /><em>*</em>
                    </div>
                </li>--%>
                <li class="form-group">
                    <div class="col-sm-10 text-center">
                        <input id="SubmitID" type="button" class="btn btn-info" onclick=" return  Submit()" value="保存" />
                        <button type="reset" class="btn btn-danger btn-group-lg" onclick=" ReturnList()">返回</button>
                    </div>




            </ul>
            <input type="hidden" id="hidAdPositionID" name="hidAdPositionID" value="0" />
            <input type="hidden" id="hidRecordUpdateTime" name="RecordUpdateTime" value="" />
            <input type="hidden" id="hidDefaultPicUrl" name="hidDefaultPicUrl" value="0" />
            <%--  <input type="hidden" id="hidSeleSortId" name="hidSeleSortId" value="0" />--%>
        </form>
    </div>
    <div class="form-box " style="width: 720px; height: 300px">

        <img id="imgID" style="width: 700px; height: 280px; padding-bottom: 20px" src="../Content/img/Admin/bg-white.png" />

    </div>
    <!--添加广告位 end-->
</body>
</html>

<script type="text/javascript">
    //@ sourceURL=AdPositionAdd.aspx

    var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引 
    var flagMsg='';
    $(document).ready(function () {
        //$("#SeleSortId").hide();
        //GetMaxSort();
        //GetSeleSort();
        
        $("#AdReleaseFileLoad").bind("change", function () {
            flagMsg='';
            var filename = this.value;
            if (tipsFile($("#txtAdReleaseFile"), filename, '|jpg|jpeg|png|')) { 
                $("#txtAdReleaseFile").html(this.value);
                $("#txtAdReleaseFile").attr("dataValue", this.value);
            }
            else { 
                //  $("#AdReleaseFileLoad").val('');
                $("#txtAdReleaseFile").html(filename);
                layer.msg('暂不支持该文件格式', 1, 3);
                flagMsg='暂不支持该文件格式';
                return;
            }
        });
        //$("#AdReleaseFileLoad").bind("change", function () {
        //    var filename = this.value;
        //    $("#txtAdReleaseFile").html(this.value);
        //    $("#txtAdReleaseFile").attr("dataValue", this.value);
        //});
     
        if (<%=AdPositionID%> > 0) {
            EditData();
        }
     
        //GetadpositionList();
        //iniTable();

    });

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
    //function GetMaxSort(){
    //    $.ajax({
    //        type: "GET",
    //        async: false,
    //        dataType: "text",
    //        url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
    //        data: { Action: "GetMaxSort"},
    //        success: function (data) {
    //            $("#SortId").html(data);
    //        }
    //    });
    //}
    //function GetSeleSort() {
    //    $.ajax({
    //        type: "GET",
    //        async: false,
    //        dataType: "text",
    //        url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
    //        data: { Action: "GetSeleSort"},
    //        success: function (data) {
    //            $("#SeleSortId").html(data);
    //        }
    //    });
    //}
    function ReturnList() {
        parent.layer.close(index);
    }
    function EditData() {
     
        var videoBtn = document.getElementById("SubmitID");
        videoBtn.value = "修改保存";
        if (<%=AdPositionID%> > 0) {
            $.ajax({
                type: "GET",
                async: false,
                dataType: "json",
                url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
                data: { Action: "GetAdPositionOne", AdPositionID: <%=AdPositionID%> },
                success: function (data) {
                    $("#hidAdPositionID").val(<%=AdPositionID%>);
                    $("#NameId").val(data.Name);
                    //$("#txtAdReleaseFile").attr("href", data.DefaultPicUrl);
                    $("#txtAdReleaseFile").html(data.DefaultPicUrl);
                    $("#txtAdReleaseFile").attr("dataValue", this.value);
                    $("#SortId").val(data.Sort);
                    $("#inpTypeId").val(data.TypeId);
                    
                    //$("#SeleSortId").val(data.Sort);
                    $("#hidDefaultPicUrl").val(data.DefaultPicUrl);
                    $("#imgID").attr("src", data.DefaultPicUrl);
                    //$("#AdReleaseID").val(data.AdReleaseID);
                }
            });
            }
        }

        function Submit() {
            var strmsg='添加';
            if (<%=AdPositionID%>>0) {
                strmsg='修改';
            }
            if ($("#txtAdReleaseFile").html()=="（文件传入）"||!$("#txtAdReleaseFile").html()) {
                layer.msg('上传文件不能为空！', 1,3);  
                return;
            }
            if(flagMsg)
            {
                layer.msg(flagMsg, 1,3);  
                return;
            }
            var indexload = layer.load("数据保存中");
            if (VerificationIsNull()) {
                var jsonFrm =JSON.stringify($('#jsForm').serialize());
                var options = {
                    type: "POST",
                    async: false,
                    dataType: "text",
                    url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
                    data: { Action: "AdPositionAddList", AdPositionID: <%=AdPositionID%>, adpositionModel: JSON.stringify(adpositionmodel()),DataModel:jsonFrm},
                    success: function (data) {
                        layer.close(indexload);
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
            if ($("#NameId").val()=="") {
                layer.msg('名称不能为空！', 1,3); 
                b= false;
                return;
            }else{
                $.ajax({
                    type: "GET",
                    async: false,
                    dataType: "text",
                    url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
                    data: { Action: "VerificationIsName", Name: $("#NameId").val(),AdPositionID:<%=AdPositionID%>},
                    success: function (data) {
                        if (data > 0) {
                            layer.msg('名称重复，请重新填写！',2,3,function(){
                                $("#NameId").val("");
                            })
                            b= false;
                            return;
                        } 
                    }
                });
            
            };

            if ($("#SortId").val()=="") {
                layer.msg('排序不能为空！', 1,3); 
                b= false;
                return;
            };
            if ($("#txtAdReleaseFile").html()=="（文件传入）") {
                layer.msg('上传文件不能为空！', 1,3); 
                b= false;
                return;
            }
            return  b;
        }

        //设置合同信息AdPosition
        function AdPositionInfo() {
            this.AdPositionID = "";
            this.Name = "";
            this.Sort = "";
            this.DefaultPicUrl="";
            this.CreatUserID = "";
            this.RecordUpdateUserID = "";
            this.RecordIsDelete = "";
            this.RecordUpdateTime = "";
            this.RecordCreateTime = "";
        }

        function adpositionmodel() {
            var adpositionInfo = new AdPositionInfo();
            adpositionInfo.AdPositionID = <%=AdPositionID%>;
            adpositionInfo.Name = $("#NameId").val();
            adpositionInfo.Sort = $("#SortId").val()==""?0:$("#SortId").val();
            adpositionInfo.TypeId = $("#inpTypeId").val();
            adpositionInfo.DefaultPicUrl = $("#txtAdReleaseFile").val();
            adpositionInfo.CreatUserID = <%=LoginUserID%>;
            adpositionInfo.RecordUpdateUserID = <%=LoginUserID%>;
            adpositionInfo.RecordIsDelete = 0;
            adpositionInfo.RecordUpdateTime = $("#hidRecordUpdateTime").val() == "" ? '<%=System.DateTime.Now %>' : $("#hidRecordUpdateTime").val();
            adpositionInfo.RecordCreateTime = '<%=System.DateTime.Now %>';
            return adpositionInfo;
        }
   

        function DelAdReleaseUrl() {
            $("#txtAdReleaseFile").attr("dataValue", "");
            $("#txtAdReleaseFile").html("（文件传入）");
            $("#AdReleaseFileLoad").val("");
        }
</script>

