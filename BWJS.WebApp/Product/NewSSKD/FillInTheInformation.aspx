<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillInTheInformation.aspx.cs" Inherits="BWJS.WebApp.Product.SSKD.FillInTheInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>填写信息</title>
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/email.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.mailAutoComplete-4.0.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/FillInTheInformation.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js" type="text/javascript"></script>
</head>
<body>
    <div class="main">
        <!--头部元素start-->
        <div class="head-box">
            <div class="col-lg-12">
                <!--申请成功移动字幕start-->
                <script src="/Scripts/NewSSKD/success.js"></script>
            </div>
        </div>
        <!--头部元素end-->

        <!--填写信息start-->
        <div class="formbox">

            <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NewSSKD/LikeToCollect">
                <div class="col-sm-12 text-center til">
                    <span class="til1">填 写 信 息</span>
                </div>

                <div class="form-group ma" style="margin-bottom: 18px;">
                    <label for="SeleCity3" class="col-lg-2 col-sm-2 col-xs-2 control-label">所在城市：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9 ma">
                        <div class="col-lg-4 col-sm-4 col-xs-4" style="padding-left: 8px;">
                            <select name="SeleCity1" id="SeleCity1" class="form-control"></select>


                        </div>
                        <div class="col-lg-4 col-sm-4 col-xs-4" style="padding-right: 0;">
                            <select id="SeleCity2" name="SeleCity2" class="form-control"></select>
                        </div>
                        <div class="col-lg-4 col-sm-4 col-xs-4" style="padding-right: 0;">
                            <select id="SeleCity3" name="SeleCity3" class="form-control" style="width: 100.5%" tabindex="1"></select>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inpAddress" class="col-lg-2 col-sm-2 col-xs-2 control-label">现居住地址：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpAddress" name="inpAddress" maxlength="50" class="form-control" placeholder="请输入您现居住地址" autocomplete="off" />

                    </div>
                </div>
                <div class="form-group">
                    <label for="inpCompanyName" class="col-lg-2 col-sm-2 col-xs-2 control-label">公司名称：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpCompanyName" name="inpCompanyName" maxlength="100" class="form-control" placeholder="请输入您的公司名称" autocomplete="off" />

                    </div>
                </div>
                <div class="form-group">
                    <label for="inpEmail" class="col-lg-2 col-sm-2 col-xs-2 control-label">常用邮箱：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="email" id="inpEmail" name="inpEmail" maxlength="50" class="form-control emailist" placeholder="请输入您的常用邮箱" required="" autocomplete="off" style="padding-left:14px;" />
                    </div>
                </div>

                <div class="lxr-box">

                    <div class="col-sm-12 text-center til">
                        <span class="til-lxr">紧急联系人</span>
                    </div>

                    <div class="col-lg-12 col-sm-12 col-xs-12 ma" style="margin-left: 7px;">
                        <div class="col-lg-6 col-sm-6 col-xs-6 ma">
                            <div class="form-group" style="padding-right: 14px;">
                                <label for="ContactName_1" class="col-lg-3 col-sm-3 col-xs-3 control-label">姓 名：</label>
                                <div class="col-lg-8 col-sm-8 col-xs-8">
                                    <input type="text" value="" id="ContactName_1" name="ContactName_1" class="form-control" maxlength="4" placeholder="请输入联系人的姓名" style="width: 99%" autocomplete="off" />

                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-sm-6 col-xs-6 ma">
                            <div class="form-group">
                                <label for="ContactName_2" class="col-lg-3 col-sm-3 col-xs-3 control-label">姓 名：</label>
                                <div class="col-lg-8 col-sm-8 col-xs-8">
                                    <input type="text" value="" id="ContactName_2" name="ContactName_2" class="form-control" maxlength="4" placeholder="请输入联系人的姓名" style="width: 99%" autocomplete="off"/>

                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-sm-6 col-xs-6 ma">
                            <div class="form-group" style="padding-right: 14px;">
                                <label for="RelationContact_1" class="col-lg-3 col-sm-3 col-xs-3 control-label ">关 系：</label>
                                <div class="col-lg-8 col-sm-8 col-xs-8">
                                    <select name="RelationContact_1" id="RelationContact_1" style="border-radius: 8px; width: 99%" class="form-control">
                                        <option value="">请选择</option>
                                        <option value="100">父 母</option>
                                        <option value="101">配 偶</option>
                                        <option value="102">其它亲属</option>
                                    </select>

                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-sm-6 col-xs-6 ma">
                            <div class="form-group">
                                <label for="RelationContact_2" class="col-lg-3 col-sm-3 col-xs-3 control-label">关 系：</label>
                                <div class="col-lg-8 col-sm-8 col-xs-8">
                                    <select name="RelationContact_2" id="RelationContact_2" style="border-radius: 8px; width: 99%" class="form-control">
                                        <option value="">请选择</option>
                                        <option value="201">同 学</option>
                                        <option value="202">同 事</option>
                                        <option value="203">朋 友</option>
                                    </select>

                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-sm-6 col-xs-6 ma">
                            <div class="form-group" style="padding-right: 14px;">
                                <label for="ContactMobile_1" class="col-lg-3 col-sm-3 col-xs-3 control-label ma" style="letter-spacing: 0;">联系方式：</label>
                                <div class="col-lg-8 col-sm-8 col-xs-8">
                                    <input type="text" value="" id="ContactMobile_1" name="ContactMobile_1" class="form-control" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="11" placeholder="请输入联系人的联系方式" style="width: 99%" autocomplete="off" />

                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-sm-6 col-xs-6 ma">
                            <div class="form-group">
                                <label for="ContactMobile_2" class="col-lg-3 col-sm-3 col-xs-3 control-label ma" style="letter-spacing: 0;">联系方式：</label>
                                <div class="col-lg-8 col-sm-8 col-xs-8">
                                    <input type="text" value="" id="ContactMobile_2" name="ContactMobile_2" class="form-control" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="11" placeholder="请输入联系人的联系方式" style="width: 99%" autocomplete="off" />

                                </div>
                            </div>
                        </div>


                    </div>
                </div>
                <div class="col-lg-12 col-sm-12 col-xs-12" style="margin-top: 100px;">
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                    </div>
                    <div class="col-lg-6 col-sm-6 col-xs-6">
                        <div class="next-btn mr" id="nextStep">下一步</div>
                    </div>
                    <div class="col-lg-3 col-sm-3 col-xs-3">
                    </div>
                </div>
                <div style="display: none">
                    <input id="hiddToken" name="hiddToken" type="hidden" value="<%=postToken%>" />
                    <input id="hidConsultId" name="hidConsultId" type="hidden" value="<%=consultid%>" />
                    <input id="hiddTimestamp" name="hiddTimestamp" type="hidden" value="<%=postTimeStamp %>" />
                    <input id="hidsign" name="hidsign" type="hidden" value="<%=GetSign %>" />
                    <input id="hidorderNo" name="orderNo" type="hidden" value="<%=orderNo %>" />
                    <input id="hiddEquipmentNo" name="hiddEquipmentNo" type="hidden" value="<%=sskdModel.MachineId %>" />
                    <input id="hiddMerchantsNo" name="hiddMerchantsNo" type="hidden" value="<%=sskdModel.MerchantId %>" />
                    <input id="hiddPageLoadDateTime" name="hiddPageLoadDateTime" type="hidden" value="<%=sskdRequestParas.PageLoadDateTime %>" />

                </div>
            </form>
        </div>
    </div>
    <!--填写信息end-->
</body>
</html>
