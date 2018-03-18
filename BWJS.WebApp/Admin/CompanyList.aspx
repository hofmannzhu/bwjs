<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="BWJS.WebApp.Admin.CompanyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <!--important start -->

    <div class="container-fluid user-list mat1">
        <div class="add-box">
            <div class="add-box" style="background:#e6e4e4;border-radius:12px 12px 12px 12px;height:90px;">
                <div class="input-group" style="width: 4%; margin-left: 1%; float: left">
                    <%--<%if (this.CheckedAuthorize("zsyo4z"))
                        { %>--%>
                    <button id="add-user1" class="btn btn-info add" onclick=" return ShowAdd(0)">
                        <span class="glyphicon glyphicon-plus"></span>添 加 渠 道
                    </button>
                    <%-- <%} %>--%>
                </div>

                <div class="input-group" style="width: 20%; margin-left: 15%; float: left">
                    <label class="col-sm-4 control-label">渠道类型:</label>
                    <div class="col-sm-6" style="margin-top: -10px; margin-left: -5%">
                        <select name="CompanyCategoryId" id="CompanyCategoryId" style="border-radius:8px" class="form-control"></select>
                    </div>
                </div>
                <div class="input-group" style="width: 20%; margin-left: 30%">
                    <label class="col-sm-4 control-label">负责人:</label>
                    <div class="col-sm-6" style="margin-top: -10px; margin-left: -10%">
                        <input type="text" id="CompanyManagerId" name="CompanyManager"   style="border-radius:8px" class="form-control" placeholder="支持负责人搜索" />
                    </div>
                </div>
            </div>

            <div class="search-box">
                <div class="input-group" style="width:90%">
                    <input type="text" id="inpSearchValue" name="inpSearchValue" class="form-control" placeholder="支持渠道名称搜索" />
                    <span   class="input-group-addon" id="btnSearch">搜 索 <i class="glyphicon glyphicon-search"></i></span>
                </div>
            </div>
        </div>

        <div id="tableArea">
                <table class="display table table-bordered" id="table" scrollX:"true"  cellspacing="0" width="100%">
          <%--  <table class="table table-striped " id="table">--%>
                <thead>
                    <tr>
                        <th>渠道名称</th>
                        <th>负责人</th>
                        <th>电话</th>
                        <th>手机</th>
                        <th>地址</th>
                        <th>主页</th>
                        <th>渠道类型</th>
                        <th>产品名称</th>
                        <th>推荐码</th>
                        <th>备注</th>
                        <th>操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <!--important End  -->
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">
        var dataTable;
        var CompanyTable;
        $(document).ready(function () {
            GetCompanyList();
            GetCompanyCategory();
            $("#btnSearch").click(function () {
                GetCompanyList()
            });
        });//  

        function GetCompanyList() {
            if (typeof (CompanyTable) != "undefined") {
                CompanyTable.fnClearTable(false); //清空一下table
                CompanyTable.fnDestroy(); //还原初始化了的datatable
            }
            CompanyTable = $("#table").dataTable({
                bAutoWidth: true,
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
                sAjaxSource: "/ajax/helper.ashx",
                fnServerData: function (sUrl, aoData, fnCallback) {
                    var searchValue = $("#inpSearchValue").val();
                    var CompanyCategoryId = $("#CompanyCategoryId").val();
                    var CompanyManager = $("#CompanyManagerId").val();
                    aoData.push(
                            { "name": "op", "value": "bwjs" },
                            { "name": "om", "value": "func" },
                            { "name": "action", "value": "CompanyList" },
                            { "name": "CompanyCategoryId", "value": encodeURI(CompanyCategoryId) },
                            { "name": "CompanyManager", "value": encodeURI(CompanyManager) },
                            { "name": "searchValue", "value": encodeURI(searchValue) },
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
                    { mData: "CompanyName", sWidth: "150px" },
                    { mData: "CompanyManager" },
                    { mData: "Phone" },
                    { mData: "Mobile" },
                    { mData: "Address", sWidth: "150px" },
                    { mData: "SiteUrl" },
                    { mData: "CompanyCategoryName" },
                    { mData: "MainBusiness", sWidth: "280px" },
                    { mData: "RecommendationCode" },
                    { mData: "Remark" },
                    {
                        mData: "CompanyId", mRender: function (data, type, full) {
                            var str = "";
        <%--           <%if (this.IsMaster || this.CheckedAuthorize("fqq73a"))
        { %>--%>
                            str += "<input class=\"btn btn-mini\" onclick=\"ShowAdd(" + full.CompanyId + ")\" type=\"button\" value=\"修改\">&nbsp&nbsp";
                            <%--   <%} %>--%>
                        <%-- <%if (this.IsMaster || this.CheckedAuthorize("9rc0pw"))
        { %>--%>
                            str += "<input class=\"btn btn-mini\" onclick=\"DeleteCompany(" + full.CompanyId + ")\" type=\"button\" value=\"删除\">";
                 <%--  <%} %>--%>

                            return str;
                        }
                    },
                ],
            });
            };
       <%--    var videoBtn = document.getElementById("SubmitID");
        videoBtn.innerHTML = "修改";
        if (<%=UserID%> > 0) {
            $.ajax({
                type: "GET",
                async: false,
                dataType: "json",
                url: "../Ajax/Admin/UserManager.ashx?r=" + Math.random(),
                data: { Action: "GetUsersOne", UsersID: <%=UserID%> },
                success: function (data) {
                    $('#SeleCity1').html('<%=strCityAreaTree%>');--%>



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
        //显示添加页面
        function ShowAdd(CompanyId) {
            var titledata;
            if (CompanyId == 0) {
                titledata = '添加渠道信息';
            } else {
                titledata = '修改渠道信息';
            }
            $.layer({
                type: 2,
                title: [
                   titledata
                ],
                border: [0],
                area: ['900px', '700px'],
                end: function () {
                    if (typeof (CompanyTable) != "undefined") {
                        CompanyTable.fnDraw(false);
                    }
                },
                iframe: { src: 'CompanyAdd.aspx?CompanyId=' + CompanyId }
            });
            return false;
        }

        function DeleteCompany(CompanyId) {
            layer.confirm('确定删除吗？', function (index) {
                if (CompanyId > 0) {
                    $.ajax({
                        type: "GET",
                        async: false,
                        dataType: "json",
                        url: "/Ajax/Admin/HCompany.ashx?r=" + Math.random(),
                        data: { Action: "DeleteCompany", CompanyId: CompanyId },
                        success: function (json) {
                            layer.msg(json.msg, 1, 1);
                            if (typeof (CompanyTable) != "undefined") {
                                CompanyTable.fnDraw(false);
                            }
                        }
                    });
                }
            });
        }
    </script>
</asp:Content>
