<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillInTheInformation.aspx.cs" Inherits="BWJS.WebPad.Product.SSKD.FillInTheInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>填写信息</title>

    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/email.css" rel="stylesheet" />
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.mailAutoComplete-4.0.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/FillInTheInformation.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js" type="text/javascript"></script>
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/layer.js" type="text/javascript"></script>
    <style>
        .mr {
            background: #ccc;
        }

        .dj {
            background: #ea5002;
        }

        .gl {
            background: #fb6113;
        }

        .form-group {
            margin-bottom: 6px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".head-btn").click(function () {
                $(".mask").fadeIn();
            });
            $(".btn-n").click(function () {
                $(".mask").fadeOut();
            });

            //调取安卓方法
            GetAndroidFun();
            $("#hidConsultId").val(<%=consultid%>);
            $("#hiddToken").val('<%=postToken%>');
        });

        function GetAndroidFun() {
            try {
                var header = {};
                header.target = "pcrk";
                header.key = "myjm";
                header.version = "V1";
                header.requestType = 1;
                header.timestamp = '<%=sskdModel.TimeStamp%>';
                header.sign = '<%=GetSign %>';
                header.orderNo = '<%=orderNo %>';
                header.merchantsNo = '<%=sskdModel.MerchantId%>';
                header.equipmentNo = '<%=sskdModel.MachineId%>';
                header.orderType = "LOAN";
                header.orderSource = "BWPAD";
                header.token = '<%=sskdModel.Token%>';
                header.telNo = '<%=mobile %>';
                header.realName = '<%=fullName %>';
                header.idNo = '<%=IDNo %>';
                android.postParams(JSON.stringify(header));
            } catch (e) {
                alert(e.message);
            }
        }
    </script>
</head>
<body>

    <div class="mask">
        <div class="pop-box-dhk">
            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                <span class="qr-msg">您是否要取消申请吗？</span>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">

                <div class="col-lg-5 col-sm-5 col-xs-5">
                    <a href="home.aspx"><span class="btn-y">是</span></a>
                </div>
                <div class="col-lg-2 col-sm-2 col-xs-2">
                </div>
                <div class="col-lg-5 col-sm-5 col-xs-5">
                    <span class="btn-n">否</span>
                </div>

            </div>
        </div>
    </div>
    <!--遮罩弹窗显示是和否end-->

    <div class="main">
        <!--头部元素start-->
        <div class="head-box">
            <div class="col-lg-12">
                <!--申请成功移动字幕start-->
                <script src="/Scripts/NewSSKD/success.js"></script>
                <div class="col-lg-2 col-sm-2 col-xs-2">
                    <div class="head-btn">取消申请</div>
                </div>
            </div>
        </div>
        <!--头部元素end-->


        <!--填写信息start-->
        <div class="formbox" style="padding-bottom: 100px;">

            <form method="post" class="form-horizontal mar-top1" role="form" id="jsForm" runat="server" action="/Product/NewSSKD/LikeToCollect">
                <div class="col-sm-12 text-center til">
                    <span class="til1">填写信息</span>
                </div>

                <div class="form-group ma" style="margin-bottom: 10px;">
                    <label for="SeleCity" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right" style="margin-top: 2px;">所在城市：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9 ma" style="padding-left: 2px;">
                        <div class="col-lg-4 col-sm-4 col-xs-4" style="padding-left: 8px;">
                            <select name="SeleCity1" id="SeleCity1" class="form-control"></select>
                        </div>
                        <div class="col-lg-4 col-sm-4 col-xs-4" style="padding-right: 0;">
                            <select id="SeleCity2" name="SeleCity2" class="form-control"></select>
                        </div>
                        <div class="col-lg-4 col-sm-4 col-xs-4" style="padding-right: 0;">
                            <select id="SeleCity3" name="SeleCity3" class="form-control" style="width: 100.5%"></select>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inpAddress" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">现住址：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpAddress" name="inpAddress" class="form-control" placeholder="请输入您现居住地址" />

                    </div>
                </div>
                <div class="form-group">
                    <label for="inpCompanyName" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">公司名称：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="inpCompanyName" name="inpCompanyName" class="form-control" placeholder="请输入您的公司名称" />

                    </div>
                </div>

                <div class="form-group">
                    <label for="inpEmail" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">常用邮箱：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="email" id="inpEmail" name="inpEmail" maxlength="50" class="form-control emailist" placeholder="请输入您的常用邮箱" required="" autofocus="" autocomplete="off" style="padding-left: 14px;" />

                    </div>
                </div>

                <div class="col-sm-12 text-center til">
                    <span class="til-lxr">紧急联系人</span>
                </div>
                <div class="form-group">
                    <label for="ContactName_1" class="col-lg-2 col-sm-2 col-xs-2 control-label  text-right">姓 名：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="ContactName_1" name="ContactName_1" class="form-control" placeholder="请输入您的姓名" style="width: 99%" />

                    </div>
                </div>

                <div class="form-group">
                    <label for="RelationContact_1" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">关 系：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <select name="RelationContact_1" id="RelationContact_1" style="border-radius: 4px; width: 99%" class="form-control">
                            <option value="">请选择</option>
                            <option value="100">父 母</option>
                            <option value="101">配 偶</option>
                            <option value="102">其它亲属</option>
                        </select>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ContactMobile_1" class="col-lg-2 col-sm-2 col-xs-2 control-label ma text-right" style="letter-spacing: 0;">联系方式：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="ContactMobile_1" name="ContactMobile_1" class="form-control" maxlength="11" placeholder="请输入联系方式" style="width: 99%"  />

                    </div>
                </div>
                <div class="form-group">
                    <label for="ContactName_2" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">姓 名：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="ContactName_2" name="ContactName_2" class="form-control" maxlength="10" placeholder="请输入您的姓名" style="width: 99%" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="RelationContact_2" class="col-lg-2 col-sm-2 col-xs-2 control-label text-right">关 系：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <select name="RelationContact_2" id="RelationContact_2" style="border-radius: 4px; width: 99%" class="form-control">
                            <option value="">请选择</option>
                            <option value="201">同 学</option>
                            <option value="202">同 事</option>
                            <option value="203">朋 友</option>
                        </select>
                    </div>
                </div>

                <div class="form-group">
                    <label for="ContactMobile_2" class="col-lg-2 col-sm-2 col-xs-2 control-label ma text-right">联系方式：</label>
                    <div class="col-lg-9 col-sm-9 col-xs-9">
                        <input type="text" value="" id="ContactMobile_2" name="ContactMobile_2" class="form-control" maxlength="11" placeholder="请输入联系方式" style="width: 99%"  />
                    </div>
                </div>



                <div style="display: none">
                      <input id="hidtimestamp" name="hidtimestamp" type="hidden" value="<%=sskdModel.TimeStamp%>" />
                    <input id="hiddToken" name="hiddToken" type="hidden" value="<%=postToken%>" />
                    <input id="hidConsultId" name="hidConsultId" type="hidden" value="<%=consultid%>" />
                    <input id="hidsign" name="hidsign" type="hidden" value="<%=GetSign %>" />
                    <input id="hidorderNo" name="orderNo" type="hidden" value="<%=orderNo %>" />
                    <input id="hiddEquipmentNo" name="hiddEquipmentNo" type="hidden" value="<%=sskdModel.MachineId %>" />
                    <input id="hiddMerchantsNo" name="hiddMerchantsNo" type="hidden" value="<%=sskdModel.MerchantId %>" />
                    <input id="hiddPageLoadDateTime" name="hiddPageLoadDateTime" type="hidden" value="<%=sskdRequestParas.PageLoadDateTime %>" />

                </div>
            </form>
        </div>
        <div class="fix">
            <div class="col-lg-12 col-sm-12 col-xs-12">
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
                <div class="col-lg-6 col-sm-6 col-xs-6">
                    <div class="next-btn mr" id="nextStep" style="margin-bottom: 25px; margin-top: 10px;">下一步</div>
                </div>
                <div class="col-lg-3 col-sm-3 col-xs-3">
                </div>
            </div>
        </div>
    </div>



</body>
</html>
