<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="AdReleaseList.aspx.cs" Inherits="BWJS.WebApp.Admin.AdReleaseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <!--广告列表start-->
    <div class="container-fluid user-list mat1">
        <div class="add-box">
            <div class="add-box">
                <%if (this.CheckedAuthorize("rh7xe5"))
                    { %>
                <button id="add-user1" class="btn btn-info add" onclick=" return ShowAdd(0)">
                    <span class="glyphicon glyphicon-plus"></span>添 加 广 告 
                </button>
                <%} %>
            </div>
            <a href="../AD/Index.aspx" target="_blank">&nbsp &nbsp 广告页面链接</a>
            <div class="search-box">
                <div class="input-group">
                    <input type="text" id="SearchAdRelease" class="form-control" placeholder="检索广告名称" />
                    <span id="btnSearch" onclick="GetAdReleaseList2()" class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>
                </div>
            </div>
        </div>
        <div id="tableArea">
            <table id="table" class="display table table-bordered">
            </table>
        </div>
    </div>
    <!--广告列表 end-->
    <!--列表详情 start-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">广告详情
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped table-bordered table-hover">
                        <tbody>
                            <tr>
                                <td style="width: 120px">广告ID</td>
                                <td id="AdReleaseID2"></td>
                            </tr>
                            <tr>
                                <td style="width: 120px">广告名称</td>
                                <td id="AdReleaseName2"></td>
                            </tr>
                            <tr class="success">
                                <td>广告开始时间</td>
                                <td id="BeginTime2"></td>
                            </tr>
                            <tr class="warning">

                                <td>广告结束时间</td>
                                <td id="EndTime2"></td>
                            </tr>
                            <tr class="info">
                                <td>文件名称</td>
                                <td id="FileName2"></td>
                            </tr>
                            <tr class="danger">
                                <td>广告图片</td>
                                <td class="tp" style="width: 100px; height: 100px">
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
            GetAdReleaseList();
        });

        /*
    初始化表格
    */

        function GetAdReleaseList2() {
            var AdReleaseData = $("#SearchAdRelease").val();
            var table = $('#table').DataTable();
            table.ajax.url('../Ajax/Admin/HAdRelease.ashx?Action=GetAdReleaseList');
            table.settings()[0].ajax.data = { AdReleaseData: AdReleaseData };
            table.ajax.reload();
            return;
        }
        var AdReleaseList;
        function GetAdReleaseList() {
            if (typeof (AdReleaseList) != "undefined") {
                //AdReleaseList.fnClearTable(false); //清空一下table
                AdReleaseList.fnDestroy(); //还原初始化了的datatable
            }

            var option = defaultDataGridOption;
            option.ajax = {
                "url": "../Ajax/Admin/HAdRelease.ashx?Action=GetAdReleaseList&r=" + Math.random(),
                "type": "Get",
                "pagingType": "full_numbers",
                "scrollX": true,
                "data": function (d) {
                }
            };
            option.columnDefs = [
                //{
                //    "data": "AdReleaseID",
                //    "title": "广告ID",
                //    "width": "100px",
                //    "render": function (data, type, row) { return data },
                //    "targets": 0
                //},
                {
                    "data": "AdReleaseName",
                    "title": "广告名称",
                    "width": "100px",
                    "render": function (data, type, row) {
                        return data;

                    },
                    "targets": 0
                },
                      {
                          "data": "PositionName",
                          "title": "关联广告位",
                          "width": "100px",
                          "render": function (data, type, row) {
                              if (data != null) {
                                  return data
                              } else {
                                  return "<span style='color:red'>未连接</span>";
                              }

                          },
                          "targets": 0
                      },
                {
                    "data": "Sort",
                    "title": "广告位排序",
                    "width": "100px",
                    "render": function (data, type, row) {
                        if (data != null) {
                            return data
                        } else {
                            return "<span style='color:red'>未连接</span>";
                        }
                    },
                    "targets": 1
                },
               {
                   "data": "BeginTime",
                   "title": "开始时间",
                   "width": "150px",
                   "render": function (data, type, row) {
                       return data
                   },
                   "targets": 2
               },
           {
               "data": "EndTime",
               "title": "结束时间",
               "width": "150px",
               "render": function (data, type, row) { return data },
               "targets": 3
           },

           {
               "data": null,
               "title": "操作",
               width: "150px",
               "render": function (data, type, row) {
                   var str = "";
                      <%if (this.CheckedAuthorize("9azon9"))
        { %>
                   str += "<button href=\"#\" class=\"btn btn-primary \" data-toggle=\"modal\"  onclick=\" return InfoData(" + row.AdReleaseID + ")\" data-target=\"#myModal\"><span class=\"glyphicon glyphicon-edit \" ></span> 详情</button>&nbsp&nbsp";
                   <%} %>
                                         <%if (this.CheckedAuthorize("jkwxah"))
        { %>
                   str += "<input class=\"btn btn-mini\" onclick=\"UpdateAdRelease(" + row.AdReleaseID + ")\" type=\"button\" value=\"修改\">&nbsp&nbsp";
                   <%} %>

                      <%if (this.CheckedAuthorize("7tadhk"))
        { %>
                   str += "<input class=\"btn btn-mini\" onclick=\"DeleteAdRelease(" + row.AdReleaseID + ")\" type=\"button\" value=\"删除\">";
                   <%} %>
                   return str;
               },
               "targets": 4
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
                   url: "../Ajax/Admin/HAdRelease.ashx?r=" + Math.random(),
                   data: { Action: "GetAdReleaseOne", AdReleaseID: b },
                   success: function (data) {
                       $("#AdReleaseID2").html(data.AdReleaseID);
                       $("#AdReleaseName2").html(data.AdReleaseName);
                       $("#BeginTime2").html(data.BeginTime);
                       $("#EndTime2").html(data.EndTime);
                       $("#FileName2").html(data.FileName);
                       $("#imgID").attr("src", data.ResourceInfo);
                   }
               });
           }
           return false;
       }



       //显示添加页面
       function ShowAdd(AdReleaseID) {
           var titledata;
           if (AdReleaseID == 0) {
               titledata = '添加广告信息';
           } else {
               titledata = '修改广告信息';
           }
           $.layer({
               type: 2,
               title: [
                  titledata
               ],
               border: [0],
               area: ['800px', '500px'],
               end: function () {
                   location.reload();
               },
               iframe: { src: 'AdReleaseAdd.aspx?AdReleaseID=' + AdReleaseID }
           });
           return false;
       }


       function DeleteAdRelease(AdReleaseid) {
           layer.confirm('确定删除吗？', function (index) {
               if (AdReleaseid > 0) {
                   $.ajax({
                       type: "GET",
                       async: false,
                       dataType: "text",
                       url: "../Ajax/Admin/HAdRelease.ashx?r=" + Math.random(),
                       data: { Action: "DeleteAdRelease", AdReleaseID: AdReleaseid },
                       success: function (data) {
                           if (data > 0) {
                               layer.msg('删除成功！', 1, 1);
                               location.reload();
                           } else {
                               layer.msg('删除失败！', 2, 1);
                           }
                       }
                   });
               }
           });
       }

       function UpdateAdRelease(AdReleaseID) {
           var titledata = '修改广告信息';
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
               iframe: { src: 'AdReleaseAdd.aspx?AdReleaseID=' + AdReleaseID }
           });
           return false;
       }


    </script>
</asp:Content>
