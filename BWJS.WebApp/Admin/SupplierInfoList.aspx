<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/m1.Master" CodeBehind="SupplierInfoList.aspx.cs" Inherits="BWJS.WebApp.Admin.SupplierInfoList" %>

<asp:content id="Content1" contentplaceholderid="headLink" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="headScript" runat="server">
    <style>
        th, td {
            white-space: nowrap;
        }

        div.dataTables_wrapper {
            width: 100%;
            margin: 0 auto;
        }
    </style>
</asp:content>
<asp:content id="Content3" contentplaceholderid="topContent" runat="server">
</asp:content>
<asp:content id="Content4" contentplaceholderid="leftContent" runat="server">
</asp:content>
<asp:content id="Content5" contentplaceholderid="bodyContent" runat="server">
    <!--用户列表start-->
    <div class="container-fluid user-list mat1"> 
        <div class="add-box">
            <div class="add-box" style="background: #e6e4e4; border-radius: 12px 12px 12px 12px; height: 90px;">
                <div class="input-group" style="width: 4%; margin-left: 1%; float: left">
                    <%if (this.CheckedAuthorize("zsyo4z"))
                        { %>
                    <button id="add-user1" class="btn btn-info add" onclick=" return ShowAdd(0)">
                        <span class="glyphicon glyphicon-plus"></span>添 加 商 户
                    </button>
                    <%} %>
                </div>
                <div class="input-group" style="width: 20%; margin-left: 8%; float: left">
                    <label class="col-sm-4 control-label" style="margin-top: 2%">商户名称:</label>
                    <div class="col-sm-6" style="margin-left: -5%; margin-top: -1%">
                        <input type="text" style="width: 110%; border-radius: 8px" id="SignName" class="form-control" placeholder="商户名称" />
                    </div>
                </div>
                <div class="input-group" style="width: 20%; margin-left: -2%; float: left">
                    <label class="col-sm-4 control-label" style="margin-top: 2%">真实姓名:</label>
                    <div class="col-sm-6" style="margin-left: -10%; margin-top: -1%">
                        <input type="text" style="width: 110%; border-radius: 8px" id="UserName" class="form-control" placeholder="真实姓名" />
                    </div>
                </div>
                   <div class="input-group" style="width: 20%; margin-left: -2%; float: left">
                    <label class="col-sm-4 control-label" style="margin-top: 2%">手机号:</label>
                    <div class="col-sm-6" style="margin-left: -10%; margin-top: -1%">
                        <input type="text" style="width: 110%; border-radius: 8px" id="UserMobile" class="form-control" placeholder="手机号" />
                    </div>
                </div> 
                <div class="input-group" style="width: 30%; margin-left: -30%; float: left">
                    <div class="col-sm-12" style="margin-left: 100%">
                        <a class="btn btn-info" id="btnSearch" style="width: 30%"><span class="glyphicon glyphicon-search"></span>查 询</a>
                    </div>
                </div>
            </div>

        </div>
        <div id="tableArea"> 
            <table class="display table table-bordered" id="table" scrollX:"true" cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>商户名称</th>
                        <th>真实姓名</th>
                        <th>手机号</th>
                        <th>Email</th>
                        <th>QQ号</th>
                        <th>微信号</th>
                        <th>可提现金额</th>
                        <th>锁定总返利</th>
                        <th>总返利</th>
                        <th>状态</th> 
                        <th>更新时间</th>
                        <th>操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</asp:content>
<asp:content id="Content6" contentplaceholderid="footerContent" runat="server">
    <script type="text/javascript">
        var usersTable;
        $(document).ready(function () {
            GetUsersTable();
            $("#btnSearch").click(function () {
                GetUsersTable()
            });
        });
        function GetUsersTable() {
            if (typeof (usersTable) != "undefined") {
                usersTable.fnClearTable(false); //清空一下table
                usersTable.fnDestroy(); //还原初始化了的datatable
            }
            usersTable = $("#table").dataTable({
                bAutoWidth: false,
                aaSorting: [[1, "desc"]],
                bDestroy: true,
                bFilter: false,
                "sDefaultContent": "",
                "bProcessing": true,
                "scrollX": true,
                sScrollXInner: "130%",
                bScrollCollapse: true,
                bServerSide: true,
                //lengthMenu:[2],
                sServerMethod: "POST",
                sAjaxSource: "../Ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var SignName = $("#SignName").val();
                    var UserName = $("#UserName").val();
                    var UserMobile = $("#UserMobile").val(); 
                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "func" },
                            { "name": "action", "value": "SupplierInfo" },
                            { "name": "SignName", "value": encodeURI(SignName) },
                            { "name": "UserName", "value": encodeURI(UserName) },
                            { "name": "UserMobile", "value": encodeURI(UserMobile) }, 
                            { "name": "timeStamp", "value": new Date().getTime() }
                    );
                    $.ajax({
                        url: sUrl,
                        type: "POST",
                        contentType: "application/json",
                        data: JSON.stringify(aoData),
                        dataType: "json",
                        cache: false,
                        traditional: true,
                        async: false,
                        success: function (json) {
                            if (json.result) {
                                fnCallback(json);
                            } else {
                                myAlert(json.msg);
                            }
                        },
                        error: function (json) {
                            var error = "";
                            $.each(json, function (key, value) {
                                switch (key) {
                                    case "status":
                                    case "statusText":
                                        error += ((error == "") ? (value) : ("," + value));
                                        break;
                                }
                            });
                            myAlert(error);
                        },
                    });
                },
                columns: [
                  { mData: "SignName", sWidth: "100px" },
                  { mData: "UserName", sWidth: "100px" },
                  { mData: "UserMobile", sWidth: "100px" },
                  { mData: "UserEmail", sWidth: "100px" },
                  { mData: "UserQQ", sWidth: "100px" },
                  { mData: "UserWechat", sWidth: "100px" },
                  {
                      mData: "Balance", sWidth: "100px",
                      mRender: function (data, type, row) { 
                          if (!data) { return "暂无" }
                      }
                  },
                  {
                      mData: "LockBalance", sWidth: "100px",
                      mRender: function (data, type, row) {
                          if (!data) { return "暂无" }
                      }
                  },
                  {
                      mData: "TotalBalance", sWidth: "100px",
                      mRender: function (data, type, row) {
                          if (!data) { return "暂无" }
                      }
                  },
                  {
                      mData: "State", sWidth: "100px",
                      mRender: function (data, type, row) {
                          if (data == 0) { return "正常" } else { return "暂无" }
                      }

                  },
                  { mData: "UpdateTime", sWidth: "100px" },
                  {
                      mData: "SId", sWidth: "100px", mRender: function (data, type, full) {
                          var str = "";
                          <%if (this.IsMaster || this.CheckedAuthorize("fqq73a"))
        { %>
                          str += "<input class=\"btn btn-mini\" onclick=\"UpdateUsers(" + full.SId + ")\" type=\"button\" value=\"修改\">&nbsp&nbsp";
                          <%} %> 
  
                          <%if (this.IsMaster || this.CheckedAuthorize("9rc0pw"))
        { %>
                          str += "<input class=\"btn btn-mini\" onclick=\"DeleteSupplierInfo(" + full.SId + ")\" type=\"button\" value=\"删除\">";
                          <%} %>

                          return str;
                      }
                  }
                ],
            });
          };
          //显示添加页面
          function ShowAdd(SId) {
              var titledata;
              if (SId == 0) {
                  titledata = '添加商户信息';
              } else {
                  titledata = '修改商户信息';
              }
              $.layer({
                  type: 2,
                  title: [
                     titledata
                  ],
                  border: [0],
                  area: ['900px', '700px'],
                  end: function () {
                      if (typeof (usersTable) != "undefined") {
                          usersTable.fnDraw(false);
                      }
                  },
                  iframe: { src: 'SupplierInfoAdd.aspx?SId=' + SId }
              });
              return false;
          }
          function DeleteSupplierInfo(SId) {
              layer.confirm('确定删除吗？', function (index) {
                  if (SId > 0) {
                      $.ajax({
                          type: "GET",
                          async: false,
                          dataType: "json",
                          url: "/Ajax/Admin/UserManager.ashx?r=" + Math.random(),
                          data: { Action: "DeleteSupplierInfo", SId: SId },
                          success: function (json) {
                              layer.msg(json.msg, 1, 1);
                              if (typeof (usersTable) != "undefined") {
                                  usersTable.fnDraw(false);
                              }
                          }
                      });
                  }
              });
          }
          function UpdateUsers(usersid) {
              ShowAdd(usersid);
          }
    </script>
</asp:content>

