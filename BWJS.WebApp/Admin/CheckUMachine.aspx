<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckUMachine.aspx.cs" Inherits="BWJS.WebApp.Admin.CheckUMachine" %>

<!DOCTYPE html> 
<script src="/Scripts/jquery.min.js"></script>
<script src="/Scripts/bootstrap.min.js"></script>
<link href="/Content/css/bootstrap.min.css" rel="stylesheet" /> 
<script src="/Scripts/uril.js"></script>
<link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
<script src="/Scripts/layer.min.js"></script>
<link href="/Scripts/skin/layer.css" rel="stylesheet" />
<script src="/Scripts/jquery-form.js"></script> 

<link rel="stylesheet" href="/Content/css/king-table.css"/>
<script type="text/javascript" src="/Scripts/king-table.js"></script>


<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <table id="cs_table" style="margin-top:30px;" border-color="blue" class="data-table"><div id="des" style=" display:none; text-align:center; font-size:14px; color:red;"> 暂无相关设备</div></table>
     
</body>
</html>

<script src="/Scripts/bootbox.js" type="text/javascript"></script>
<script src="/Scripts/Admin/m1.js" type="text/javascript"></script>
<script type="text/javascript">
    var data = [];
    var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引  
    function getClassList() {
     
        var paramter = {};
        paramter.op = "bwjs";
        paramter.om = "func";
        paramter.action = "CheckRUsersMachine"; 
        paramter.UserId =<%=UserId%>;
        var json = getJson(paramter, false);
        if (json) { 
            if(json.result==false)
            {
                $("#des").css("display","block");
            }else
            {
                var cs = new table({
                    "tableId":"cs_table",    //必须 表格id
                    "headers":["设备号","SN号","地址","平台","经度","维度"],   //必须 thead表头 
                    "data":json,         //必须 tbody 数据展示
                    "displayNum": 10,    //必须   默认 10  每页显示行数
                    "groupDataNum":1,     //可选    默认 10  组数
                    "display_tfoot":true, // true/false  是否显示tfoot --- 默认false
                    "bindContentTr":function(){ //可选 给tbody 每行绑定事件回调
                        this.tableObj.find("tbody").on("click",'tr',function(e){
                            return false;
                            var tr_index = $(this).data("tr_index");        // tr行号  从0开始
                            var data_index = $(this).data("data_index");   //数据行号  从0开始
                        })
                    }, 
                    sort:true,    // 点击表头是否排序 true/false  --- 默认false
                    sortContent:[
                        {
                            index:0,//表头序号
                            compareCallBack:function(a,b){ //排序比较的回调函数
                                var a=parseInt(a.MachineID,10);
                                var b=parseInt(b.MachineID,10);
                                if(a < b)
                                    return -1;
                                else if(a == b)
                                    return 0;
                                else
                                    return 1;
                            }
                        }
                        ,
                        {
                            index:3,//表头序号
                            compareCallBack:function(a,b){ //排序比较的回调函数
                                var a=parseInt(a.Platform,5);
                                var b=parseInt(b.Platform,5);
                                if(a < b)
                                    return -1;
                                else if(a == b)
                                    return 0;
                                else
                                    return 1;
                            }
                        }
                    ],
                    specialRows:[
                        {
                            row:4,
                            cssText:{
                                "color":"#FFCF17"
                            }
                        }
                    ],
                    search:false   // 默认为false 没有搜索
                    
                });
            }
       


        } else {
            myAlert(json.msg);
        } 
    } 
    $(document).ready(function () {
        getClassList(); 
    });
  
    
</script>
<script type="text/javascript">
   
    //for(var i=0;i<100;i++)
    //{
    //    data[i] = {id:i+1,name:"jason"+(i+1),gender:"男",age:i+1,other:"备注"+i};
    //}

  
	
	
	
</script>
