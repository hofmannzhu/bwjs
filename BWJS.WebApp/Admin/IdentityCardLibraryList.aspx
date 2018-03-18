<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="IdentityCardLibraryList.aspx.cs" Inherits="BWJS.WebApp.Admin.IdentityCardLibrary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
    <script src="/Scripts/WdatePicker/WdatePicker.js"></script>
    <script src="/Scripts/WdatePicker/config.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="container-fluid user-list mat1">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpFullNameForQuery"><i class="jg">姓</i>名</label>
                        <input id="inpFullNameForQuery" name="inpFullNameForQuery" type="text" class="form-control" placeholder="请输入姓名" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpIdentityCardNumberForQuery">证件号码</label>
                        <input id="inpIdentityCardNumberForQuery" name="inpIdentityCardNumberForQuery" type="text" class="form-control" placeholder="请输入证件号码" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpNationForQuery"><i class="jg">民</i>族</label>
                        <input id="inpNationForQuery" name="inpNationForQuery" type="text" class="form-control" placeholder="请输入民族" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpEffectedDateForQuery">有效日期</label>
                        <input id="inpEffectedDateForQuery" name="inpEffectedDateForQuery" type="text" class="form-control" placeholder="请选择有效日期" readonly />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpAddressForQuery"><i class="jg">地</i>址</label>
                        <input id="inpAddressForQuery" name="inpAddressForQuery" type="text" class="form-control" placeholder="请输入地址" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpIssuedAtForQuery">发证机关</label>
                        <input id="inpIssuedAtForQuery" name="inpIssuedAtForQuery" type="text" class="form-control" placeholder="请输入发证机关" />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpBirthDayForQuery"><i class="jg">生</i>日</label>
                        <input id="inpBirthDayForQuery" name="inpBirthDayForQuery" type="text" class="form-control" placeholder="请输入生日" readonly />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpExpiredDateForQuery">失效日期</label>
                        <input id="inpExpiredDateForQuery" name="inpExpiredDateForQuery" type="text" class="form-control" placeholder="请选择失效日期" readonly />
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpCompanyIdForQuery"><i class="jg">来</i>源</label>
                        <select id="inpCompanyIdForQuery" name="inpCompanyIdForQuery" class="form-control" style="width: 196px;"></select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <label for="inpSexForQuery"><i class="jg">性</i>别</label>
                        <select id="inpSexForQuery" name="inpSexForQuery" class="form-control">
                            <option value="">请选择</option>
                            <option value="0">女</option>
                            <option value="1">男</option>
                        </select>
                    </div>
                </div>
                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12 a ma-bt">
                    <div class="form-inline">
                        <a class="btn btn-info" id="btnSearch"><span class="glyphicon glyphicon-search"></span>查 询</a>
                        <button id="btnReset" type="reset" class="btn btn-info"><span class="glyphicon glyphicon-refresh"></span>重 置</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="tableArea">
            <table id="idCardList" class="display table table-bordered">
                <thead>
                    <tr>
                        <th style="width: 6%;">编号</th>
                        <th style="width: 6%;">来源</th>
                        <th style="width: 6%;">证件号码</th>
                        <th style="width: 6%;">姓名</th>
                        <th style="width: 6%;">性别</th>
                        <th style="width: 6%;">民族</th>
                        <th style="width: 6%;">生日</th>
                        <th style="width: 6%;">地址</th>
                        <th style="width: 6%;">发证机关</th>
                        <th style="width: 6%;">有效期</th>
                        <th style="width: 6%;">身份证照片</th>
                        <th style="width: 6%;">建档日期</th>
                        <th style="width: 6%;">操作</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <div class="modal fade" id="detailsModal" tabindex="-1" role="dialog" aria-labelledby="detailsModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title" id="detailsModalLabel">查看详情</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row" id="detailsDiv">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input id="hiddId" name="hiddId" type="hidden" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">

        var idCardTable;

        $(document).ready(function () {
            $('#inpEffectedDateForQuery').on('focus', function () {
                WdatePicker({ onpicked: function (db) { db.$('inpEffectedDateForQuery').focus(); }, dateFmt: 'yyyy-MM-dd' });
            });
            $('#inpExpiredDateForQuery').on('focus', function () {
                WdatePicker({ onpicked: function (db) { db.$('inpExpiredDateForQuery').focus(); }, dateFmt: 'yyyy-MM-dd' });
            });
            $('#inpBirthDayForQuery').on('focus', function () {
                WdatePicker({ onpicked: function (db) { db.$('inpBirthDayForQuery').focus(); }, dateFmt: 'yyyy-MM-dd' });
            });
            getCompanyList();
            GetIdCardList();

            $("#btnReset").click(function () {
                GetIdCardList()
            });

            $("#btnSearch").click(function () {
                GetIdCardList()
            });

            $("#detailsModal")
                .on('show.bs.modal', function (e) {
                    var op = $(e.relatedTarget);
                    var id = op.data("id");
                })
                .on('shown.bs.modal', function (e) {
                    var op = $(e.relatedTarget);
                    var id = op.data("id");
                    if (id != undefined) {
                        $("#hiddId").val(id);
                        look(id);
                    }
                })
                .on('hide.bs.modal', function () {
                })
                .on('hidden.bs.modal', function () {

                });
        });

        function GetIdCardList() {
            try {
                if (typeof (idCardTable) != "undefined") {
                    idCardTable.fnClearTable(false); //清空一下table
                    idCardTable.fnDestroy(); //还原初始化了的datatable
                }
                idCardTable = $("#idCardList").dataTable({
                    bAutoWidth: true,
                    aaSorting: [[0, "desc"]],
                    bDestroy: true,
                    bServerSide: true,
                    sServerMethod: "POST",
                    sAjaxSource: "/ajax/helper.ashx",
                    fnServerData: function (sUrl, aoData, fnCallback) {
                        var identityCardNumber = $.trim($("#inpIdentityCardNumberForQuery").val());
                        var fullName = $.trim($("#inpFullNameForQuery").val());
                        var nation = $.trim($("#inpNationForQuery").val());
                        var birthDay = $.trim($("#inpBirthDayForQuery").val());
                        var address = $.trim($("#inpAddressForQuery").val());
                        var issuedAt = $.trim($("#inpIssuedAtForQuery").val());
                        var effectedDate = $.trim($("#inpEffectedDateForQuery").val());
                        var expiredDate = $.trim($("#inpExpiredDateForQuery").val());
                        var companyId = $.trim($("#inpCompanyIdForQuery").val());
                        var sex = $.trim($("#inpSexForQuery").val());
                        aoData.push(
                                { "name": "op", "value": "bwjs" },
                                { "name": "om", "value": "netloan" },
                                { "name": "action", "value": "getidcard" },
                                { "name": "identityCardNumber", "value": encodeURI(identityCardNumber) },
                                { "name": "fullName", "value": encodeURI(fullName) },
                                { "name": "nation", "value": encodeURI(nation) },
                                { "name": "birthDay", "value": encodeURI(birthDay) },
                                { "name": "address", "value": encodeURI(address) },
                                { "name": "issuedAt", "value": encodeURI(issuedAt) },
                                { "name": "effectedDate", "value": encodeURI(effectedDate) },
                                { "name": "expiredDate", "value": encodeURI(expiredDate) },
                                { "name": "companyId", "value": companyId },
                                { "name": "sex", "value": sex },
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
                                //alert(JSON.stringify(json));
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
                        { mData: "IdentityCardLibraryId" },
                        { mData: "CompanyName" },
                        { mData: "IdentityCardNumber" },
                        { mData: "FullName" },
                        {
                            mData: "Sex",
                            mRender: function (data, type, full) {
                                var result = full.Sex;
                                switch (full.Sex) {
                                    case 0:
                                        result = "女";
                                        break;
                                    case 1:
                                        result = "男";
                                        break;
                                }
                                return result;
                            },
                        },
                        { mData: "Nation" },
                        {
                            mData: "BirthDay",
                            mRender: function (data, type, full) {
                                var result = "";
                                if (full.BirthDay != null && full.BirthDay != "") {
                                    result = $.formatDateTime("yy-mm-dd", new Date(full.BirthDay));
                                }
                                return result;
                            },
                        },
                        { mData: "Address" },
                        { mData: "IssuedAt" },
                        {
                            mData: "EffectedDate",
                            mRender: function (data, type, full) {
                                var result = "";
                                if (full.EffectedDate != null && full.EffectedDate != "") {
                                    result = $.formatDateTime("yy.mm.dd", new Date(full.EffectedDate)) + "-" + $.formatDateTime("yy.mm.dd", new Date(full.ExpiredDate));
                                }
                                return result;
                            },
                        },
                        {
                            mData: "IdentityCardPhotoData",
                            mRender: function (data, type, full) {
                                var result = "";
                                if (full.IdentityCardPhotoData != "" && full.IdentityCardPhotoData != null) {
                                    result = "<img id=\"" + full.IdCard + "\" name=\"" + full.IdCard + "\" style=\"width: 96px; height: 118px;\" src=\"" + "data:image/jpeg;base64," + full.IdentityCardPhotoData + "\" />";
                                }
                                return result;
                            },
                        },
                        {
                            mData: "CreateDate",
                            mRender: function (data, type, full) {
                                var result = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(full.CreateDate));
                                return result;
                            },
                        },
                        {
                            sClass: "center",
                            mData: "IdentityCardLibraryId",
                            bSortable: false,
                            mRender: function (data, type, full) {
                                var option = "<a data-toggle=\"modal\" data-target=\"#detailsModal\" data-action=\"orderCancle\" data-id=\"" + full.IdentityCardLibraryId + "\" class=\"btn btn-mini\" title=\"查看详情\">查看</a>";
                                return option;
                            }
                        },
                    ],
                });
            }
            catch (e) {
                myAlert(e.message);
            }
        }

        function look(postId) {
            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "netloan";
            paramter.action = "getidcardmodel";
            paramter.identityCardLibraryId = postId;
            var json = getJson(paramter, false);
            if (json.result) {
                selectedData = json.data;
                var html = "";
                $.each(json.data, function (key, value) {
                    html += modelConvert(key, value);
                });
                $("#detailsDiv").html(html);
            } else {
                myAlert(json.msg);
            }
        }

        function modelConvert(key, value) {
            var html = "";
            var left = "";
            switch (key) {
                case "IdentityCardLibraryId": left = "证件号码库编号"; break;
                case "CompanyId":
                    left = "数据来源";
                    switch (value) {
                        case 1:
                            value = "捌零易贷";
                            break;
                        case 2:
                            value = "保险";
                            break;
                    }
                    break;
                case "IdentityCardNumber": left = "证件号码"; break;
                case "FullName": left = "姓名"; break;
                case "Sex":
                    left = "性别";
                    switch (value) {
                        case 0:
                            value = "女";
                            break;
                        case 1:
                            value = "男";
                            break;
                    }
                    break;
                case "Nation": left = "民族"; break;
                case "BirthDay":
                    left = "生日";
                    if (value != null && value != "") {
                        value = $.formatDateTime("yy-mm-dd", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    }
                    break;
                case "Address": left = "地址"; break;
                case "IssuedAt": left = "发证机关"; break;
                case "EffectedDate":
                    left = "有效期开始";
                    if (value != null && value != "") {
                        value = $.formatDateTime("yy-mm-dd", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    }
                    break;
                case "ExpiredDate":
                    left = "有效期结束";
                    if (value != null && value != "") {
                        value = $.formatDateTime("yy-mm-dd", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    }
                    break;
                case "IdentityCardPhotoData":
                    left = "身份证照片";
                    if (value != null && value != "") {
                        value = "<img style=\"width: 96px; height: 118px;\" src=\"" + "data:image/jpeg;base64," + value + "\" />";
                    }
                    break;
                case "CreateDate":
                    left = "建档日期";
                    value = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    break;
                case "EditDate": {
                    left = "修改日期";
                    if (value != null && value != "") {
                        value = $.formatDateTime("yy-mm-dd hh:ii:ss", new Date(value.replace(/\T/g, " ").replace(/\-/g, "/")));
                    }
                }
                    break;
            }
            if (left != "" && value != "" && value != null) {
                html += "<div class=\"col-lg-4 text-right\">" + left + "</div>";
                html += "<div class=\"col-lg-8\">" + value + "</div>";
            }
            return html;
        }

        //渠道列表
        function getCompanyList() {
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/x-www-form-urlencoded",
                url: "/ajax/helper.ashx",
                data: { op: "bwjs", om: "gl", action: "companyListForSelect", r: Math.random() },
                async: false,
                cache: false,
                traditional: false,
                success: function (json) {
                    if (json.result) {
                        $("#inpCompanyIdForQuery").append("<option value=\"\">请选择</option>");
                        $.each(json.data, function (key, value) {
                            $("#inpCompanyIdForQuery").append("<option value=\"" + value.CompanyId + "\">" + value.CompanyName + "</option>");
                        });
                    } else {
                        alert(json.msg);
                    }
                },
                error: function (json) {
                    alert("加载渠道列表失败，请重试");
                },
            });
        }
    </script>
</asp:Content>
