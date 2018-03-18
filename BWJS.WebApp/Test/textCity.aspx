<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="textCity.aspx.cs" Inherits="BWJS.WebApp.AD.textCity" %>

<!DOCTYPE html>
<script src="../Scripts/jquery-3.2.1.min.js"></script>
<script src="../Scripts/jquery.min.js"></script>
    <script src="/Scripts/layer.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
    <script>
        $(function () {

            var indexLayer = layer.msg('努力加载中.....', { icon: 6 });
            layer.close(indexLayer);
        });
       // 
      

    </script>
<body>
    <form id="form1" runat="server">
        <div>
            省:
            <select name="province" id="SeleCity1" onchange="if(this.value != '') GetSeleCity2(this.value);"  style="width: 220px;" ></select>

           市:<select id="SeleCity2" name="SeleCity2" onchange="if(this.value != '') GetSeleCity3(this.value);"   style="width: 220px;"></select>

                区（县）:
                <select id="SeleCity3" name="SeleCity3" style="width: 220px;"></select>
        </div>
    </form>

</body>
</html>



<script type="text/javascript">

    $(document).ready(function () {
        $('#SeleCity1').html('<%=strCityAreaTree%>');
    });

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
            GetCityArea(selectObj,optionList);
        }
    }



    function GetCityArea(selectObj,ParentID) {
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
</script>



