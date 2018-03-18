<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="AdPositionList.aspx.cs" Inherits="BWJS.WebApp.Admin.AdPositionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <!--广告位列表start-->
    <div class="container-fluid user-list mat1">
        <div class="add-box">
            <div class="add-box">
                <%if (this.CheckedAuthorize("8rzvhn"))
                    { %>
                <button id="add-user1" class="btn btn-info add" onclick="return ShowAdd(0)">
                    <span class="glyphicon glyphicon-plus"></span>添 加 广 告 位
                </button>
                <%} %>
            </div>
            <a href="../AD/Index.aspx?u=1" target="_blank">&nbsp &nbsp 默认图片广告链接</a>
            <div class="search-box">
                <div class="input-group">
                    <input type="text" id="SearchAdPosition" class="form-control" placeholder="广告位名称检索" />

                    <span class="input-group-addon" id="btnSearch" onclick="GetAdPositionList2()"><i class="glyphicon glyphicon-search"></i></span>

                </div>
            </div>
        </div>
        <div id="tableArea">
            <table id="table" class="display table table-bordered">
            </table>
        </div>
    </div>
    <!--广告位列表 end-->
    <!--列表详情 start-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">广告位默认图片详情
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped table-bordered table-hover">
                        <tbody>
                            <tr class="info">
                                <td style="word-break: break-all">广告位名称</td>
                                <td id="FileName2" style="word-break: break-all; width: 100px"></td>
                            </tr>
                            <tr class="info" style="width: 120px">
                                <td style="word-break: break-all">默认图片地址</td>
                                <td id="FilePath2" style="word-break: break-all"></td>
                            </tr>
                            <tr class="danger">
                                <td style="word-break: break-all; width: 100px">广告位默认图片</td>
                                <td class="tp" style="word-break: break-all; width: 100px; height: 100px">
                                    <img id="imgID" src="" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
    <!--列表详情 end-->
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            GetAdPositionList();

        });
        function GetAdPositionList2() {
            var AdPositionData = $("#SearchAdPosition").val();
            var table = $('#table').DataTable();
            table.ajax.url('../Ajax/Admin/HAdPosition.ashx?Action=GetAdPositionList');
            table.settings()[0].ajax.data = { AdPositionData: AdPositionData };
            table.ajax.reload();
            return;
        }
        /*
    初始化表格
    */
        var AdPositionList;
        function GetAdPositionList() {
            if (typeof (AdPositionList) != "undefined") {
                //AdPositionList.fnClearTable(false); //清空一下table
                AdPositionList.fnDestroy(); //还原初始化了的datatable
            }
            var option = defaultDataGridOption;
            option.ajax = {
                "url": "../Ajax/Admin/HAdPosition.ashx?Action=GetAdPositionList&r=" + Math.random(),
                "type": "Get",
                "pagingType": "full_numbers",
                "scrollX": true,
                "data": function (d) {
                }
            };
            option.columnDefs = [
                //{
                //    "data": "AdPositionID",
                //    "title": "广告位ID",
                //    "width": "80px",
                //    "render": function (data, type, row) { return data },
                //    "targets": 0
                //},
           {
               "data": "Name",
               "title": "广告位名称",
               "width": "150px",
               "render": function (data, type, row) { return data },
               "targets": 0
           },
           {
               "data": "Sort",
               "title": "序号",
               "width": "50px",
               "render": function (data, type, row) {
                   var returndata = " <input id=\"SortId\" name=\"SortId\" class=\"form-control\" type=\"text\" onblur=\"ChangeSort(this.value," + row.AdPositionID + ")\"  value=" + data + " />";

                   return returndata;


               },
               "targets": 1
           },
           {
               "data": "TypeId",
               "title": "广告类型",
               "width": "100px",
               "render": function (data, type, row) {
                   var str = data;
                   if (data == 1) {
                       str = "PC";
                   } else if (data == 2) {
                       str = "Pad";
                   }
                   return str;
               },
               "targets": 2
           },
           {
               "data": "AdReleaseID",
               "title": "广告位是否绑定",
               "width": "130px",
               "render": function (data, type, row) {
                   var str = "";
                   if (data > 0) {
                       str = "<b style='color:red'>已绑定<b/>";
                   } else {
                       str = "<b style='color:green'>未绑定<b/>";
                   }
                   return str;
               },
               "targets": 3
           },
              {
                  "data": "AdReleaseName",
                  "title": "绑定广告名称",
                  "width": "150px",
                  "render": function (data, type, row) { return data },
                  "targets": 4
              },
            {
                "data": "RecordCreateTime",
                "title": "创建时间",
                "width": "150px",
                "render": function (data, type, row) { return data; },
                "targets": 5
            },
           {
               "data": null,
               "title": "操作",
               width: "150px",
               "render": function (data, type, row) {
                   var str = "";
                   <%if (this.CheckedAuthorize("hkl8dg"))
        { %>
                   str += "<button href=\"#\" class=\"btn btn-primary \" data-toggle=\"modal\"  onclick=\" return InfoData(" + row.AdPositionID + ")\" data-target=\"#myModal\"><span class=\"glyphicon glyphicon-edit \" ></span> 详情</button>&nbsp&nbsp";
                   <%} %>

                   <%if (this.CheckedAuthorize("kll3ff"))
        { %>
                   str += "<input class=\"btn btn-mini\" onclick=\"UpdateAdPosition(" + row.AdPositionID + ")\" type=\"button\" value=\"修改\">&nbsp&nbsp";
                   <%} %>

                   <%if (this.CheckedAuthorize("jm50h4"))
        { %>
                   str += "<input class=\"btn btn-mini\" onclick=\"DeleteAdPosition(" + row.AdPositionID + ")\" type=\"button\" value=\"删除\">";
                     <%} %>

                   return str;
               },
               "targets": 6
           }];
           option.order = [[0, "desc"]];
           AdReleaseList = $('#table').DataTable(option);
       }

       function InfoData(b) {
           if (b > 0) {
               $.ajax({
                   type: "GET",
                   async: false,
                   dataType: "json",
                   url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
                   data: { Action: "GetAdPositionOne", AdPositionID: b },
                   success: function (data) {
                       $("#FileName2").html(data.Name);
                       $("#FilePath2").html(data.DefaultPicUrl);
                       $("#imgID").attr("src", data.DefaultPicUrl);
                   }
               });
           }
           return false;
       }

       function ChangeSort(Sort, AdPositionID) {
           $.ajax({
               type: "POST",
               async: false,
               dataType: "text",
               url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
               data: { Action: "ChangeSort", Sort: Sort, AdPositionID: AdPositionID },
               success: function (data) {
                   if (data) {
                       location.reload();
                   }
               }
           });
       }


       //显示添加页面
       function ShowAdd(adpositionid) {
           var titledata;
           if (adpositionid == 0) {
               titledata = '添加广告位';
           } else {
               titledata = '修改广告位';
           }
           $.layer({
               type: 2,
               title: [
                  titledata
               ],
               border: [0],
               area: ['800px', '750px'],
               end: function () {
                   location.reload();
               },
               iframe: { src: 'AdPositionAdd.aspx?AdPositionID=' + adpositionid }
           })
           return false;
       }

       function DeleteAdPosition(AdPositionID) {
           layer.confirm('确定删除吗？', function (index) {
               if (AdPositionID > 0) {
                   $.ajax({
                       type: "GET",
                       async: false,
                       dataType: "text",
                       url: "../Ajax/Admin/HAdPosition.ashx?r=" + Math.random(),
                       data: { Action: "DeleteAdPosition", AdPositionID: AdPositionID },
                       success: function (data) {
                           if (data > 0) {
                               layer.msg('删除成功！', 1, 1);
                               location.reload();
                               //GetUsersList();
                           } else {
                               layer.msg('删除失败！', 2, 1);
                           }
                       }
                   });
               }
           })

       };
       function UpdateAdPosition(AdPositionID) {
           ShowAdd(AdPositionID);
       }
    </script>
</asp:Content>
