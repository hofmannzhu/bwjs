<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="UserManagerInfoList.aspx.cs" Inherits="BWJS.WebApp.Admin.UserManagerInfoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
    <style>
        th, td {
            white-space: nowrap;
        }

        div.dataTables_wrapper {
            width: 100%;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <!--用户列表start-->
    <div class="container-fluid user-list mat1">

        <div class="add-box">
            <div class="add-box" style="background: #e6e4e4; border-radius: 12px 12px 12px 12px; height: 90px;">
                <div class="input-group" style="width: 4%; margin-left: 1%; float: left">
                    <%if (this.CheckedAuthorize("zsyo4z"))
                        { %>
                    <button id="add-user1" class="btn btn-info add" onclick=" return ShowAdd(0)">
                        <span class="glyphicon glyphicon-plus"></span>添 加 用 户
                    </button>
                    <%} %>
                </div>
                <div class="input-group" style="width: 20%; margin-left: 8%; float: left">
                    <label class="col-sm-4 control-label" style="margin-top: 2%">登录名:</label>
                    <div class="col-sm-6" style="margin-left: -5%; margin-top: -1%">
                        <input type="text" style="width: 110%; border-radius: 8px" id="LoginName" class="form-control" placeholder="登录名" />
                    </div>
                </div>
                <div class="input-group" style="width: 20%; margin-left: -2%; float: left">
                    <label class="col-sm-4 control-label" style="margin-top: 2%">真实姓名:</label>
                    <div class="col-sm-6" style="margin-left: -10%; margin-top: -1%">
                        <input type="text" style="width: 110%; border-radius: 8px" id="UsersName" class="form-control" placeholder="用户名" />
                    </div>
                </div>
                <div class="input-group" style="width: 20%; margin-left: -2%; float: left">
                    <label class="col-sm-4 control-label" style="margin-top: 2%">部门:</label>
                    <div class="col-sm-6" style="margin-left: -10%; margin-top: -1%">
                        <asp:DropDownList ID="drpDepartmentInfoID" runat="server" class="form-control" Style="width: 110%; border-radius: 8px"></asp:DropDownList>
                    </div>
                </div>
                <div class="input-group" style="width: 20%; margin-left: -2%; float: left">
                    <label class="col-sm-4 control-label" style="margin-top: 2%">手机号:</label>
                    <div class="col-sm-6" style="margin-left: -10%; margin-top: -1%">
                        <input type="text" style="width: 110%; border-radius: 8px" id="Mobiles" class="form-control" placeholder="手机号" />
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
                        <th>登录名</th>
                        <th>真实姓名</th>
                        <th>商户名称</th>
                        <th>角色</th>
                        <th>部门</th>
                        <th>身份证号</th>
                        <th>性别</th>
                        <th>手机号</th>
                        <th>所在城市</th>
                        <th>更新时间</th>
                        <th>操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
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
                sServerMethod: "POST",
                sAjaxSource: "../Ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var LoginName = $("#LoginName").val();
                    var UsersName = $("#UsersName").val();
                    var Mobiles = $("#Mobiles").val();
                    var DepartmentInfoID = $("#bodyContent_drpDepartmentInfoID").val();
                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "func" },
                            { "name": "action", "value": "UsersList" },
                            { "name": "LoginName", "value": encodeURI(LoginName) },
                            { "name": "UsersName", "value": encodeURI(UsersName) },
                            { "name": "Mobiles", "value": encodeURI(Mobiles) },
                            { "name": "DepartmentInfoID", "value": encodeURI(DepartmentInfoID) },
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
                  { mData: "LoginName", sWidth: "100px" },
                  { mData: "UserName", sWidth: "100px" },
                    {
                        mData: "SId", sWidth: "100px"
                    },
                    { mData: "RoleName", sWidth: "100px" },
                  { mData: "DepartmentName", sWidth: "100px" },
                  {
                      mData: "CardID", sWidth: "100px",
                      mRender: function (data, type, row) {
                          var data = data.replace(/^(.{6})(?:\d+)(.{4})$/, "$1****$2");
                          return data;
                      }
                  },
                    {
                        mData: "Sex",
                        mRender: function (data, type, row) {
                            if (data == 1) { return "男" } else { return "女" }
                        }
                    },
                  {
                      mData: "Phone", sWidth: "100px",
                      mRender: function (data, type, row) {
                          var data = data.replace(/(\d{3})\d{4}(\d{4})/, '$1****$2');
                          return data;
                      }
                  },

                  { mData: "CityData", sWidth: "150px" },
                   {
                       mData: "RecordUpdateTime",
                       mRender: function (data, type, full) {
                           var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.RecordUpdateTime));
                           return result;
                       },
                   },
                  {
                      mData: "UserID", sWidth: "100px", mRender: function (data, type, full) {
                          var str = "";
                   <%if (this.IsMaster || this.CheckedAuthorize("c7nynp"))
        { %>
                          str += "<input class=\"btn btn-mini\" onclick=\"BankCardBinding(" + full.UserID + ")\" type=\"button\" value=\"银行卡绑定\">&nbsp&nbsp";
                          <%} %>
                   <%if (this.IsMaster || this.CheckedAuthorize("fqq73a"))
        { %>
                          str += "<input class=\"btn btn-mini\" onclick=\"UpdateUsers(" + full.UserID + ")\" type=\"button\" value=\"修改\">&nbsp&nbsp";
                              <%} %>
                          if (full.UserType != 1) {
                                  <%if (this.IsMaster || this.CheckedAuthorize("a3enqa"))
        { %>
                              str += "<input class=\"btn btn-mini\" onclick=\"ShowUserDepartment(" + full.UserID + ")\" type=\"button\" value=\"关联部门\">&nbsp&nbsp";
                              <%} %>
                       <%if (this.IsMaster || this.CheckedAuthorize("twosqi"))
        { %>
                              str += "<input class=\"btn btn-mini\" onclick=\"ShowUserRole(" + full.UserID + ")\" type=\"button\" value=\"角色授权\">&nbsp&nbsp";
                              <%} %>
                          }

                           <%if (this.IsMaster || this.CheckedAuthorize("twosqi"))
        { %>
                          str += "<input class=\"btn btn-mini\" onclick=\"CheckUMachine(" + full.UserID + ")\" type=\"button\" value=\"查看设备\">&nbsp&nbsp";
                          <%} %>
                        

                          
                         <%if (this.IsMaster || this.CheckedAuthorize("9rc0pw"))
        { %>
                          str += "<input class=\"btn btn-mini\" onclick=\"DeleteUsers(" + full.UserID + ")\" type=\"button\" value=\"删除\">";
                   <%} %>

                          return str;
                      }
                  },
                ],
            });
          };



          function ShowUserDepartment(UserId) {
              if (UserId > 0) {
                  $.layer({
                      type: 2,
                      title: [
                         "关联部门"
                      ],
                      border: [0],
                      area: ['880px', '580px'],
                      end: function () {
                          if (typeof (usersTable) != "undefined") {
                              usersTable.fnDraw(false);
                          }
                      },
                      iframe: { src: 'RUserDepartment.aspx?UserId=' + UserId }
                  });
              } else {
                  layer.msg('关联失败！', 2, 1);
              }
              return false;
          }

          function ShowUserRole(UserId) {
              if (UserId > 0) {
                  $.layer({
                      type: 2,
                      title: [
                         "角色授权"
                      ],
                      border: [0],
                      area: ['880px', '580px'],
                      end: function () {
                          if (typeof (usersTable) != "undefined") {
                              usersTable.fnDraw(false);
                          }
                      },
                      iframe: { src: 'RUserRole.aspx?UserId=' + UserId }
                  });
              } else {
                  layer.msg('授权失败！', 2, 1);
              }
              return false;
          }
          
          function CheckUMachine(UserId) {
              if (UserId > 0) {
                  $.layer({
                      type: 2,
                      title: [
                         "用户相关设备"
                      ],
                      border: [0],
                      area: ['880px', '580px'],
                      end: function () {
                          if (typeof (usersTable) != "undefined") {
                              usersTable.fnDraw(false);
                          }
                      },
                      iframe: { src: 'CheckUMachine.aspx?UserId=' + UserId }
                  });
              } else {
                  layer.msg('查看失败！', 2, 1);
              }
              return false;
          }
          //显示添加页面
          function ShowAdd(type) {
              var titledata;
              if (type == 0) {
                  titledata = '添加用户信息';
              } else {
                  titledata = '修改用户信息';
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
                  iframe: { src: 'UserManagerAdd.aspx?UserID=' + type }
              });
              return false;
          }



          function DeleteUsers(usersid) {
              layer.confirm('确定删除吗？', function (index) {
                  if (usersid > 0) {
                      $.ajax({
                          type: "GET",
                          async: false,
                          dataType: "json",
                          url: "/Ajax/Admin/UserManager.ashx?r=" + Math.random(),
                          data: { Action: "DeleteUser", UsersID: usersid },
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

          function BankCardBinding(UserId) {
              if (UserId > 0) {
                  $.layer({
                      type: 2,
                      title: [
                         "银行卡绑定"
                      ],
                      border: [0],
                      area: ['1024px', '600px'],
                      end: function () {
                          if (typeof (usersTable) != "undefined") {
                              usersTable.fnDraw(false);
                          }
                      },
                      iframe: { src: '/Admin/UserBankListForUserManager.aspx?UserId=' + UserId }
                  });
              } else {
                  layer.msg('银行卡绑定失败！', 2, 1);
              }
              return false;
          }
    </script>
</asp:Content>
