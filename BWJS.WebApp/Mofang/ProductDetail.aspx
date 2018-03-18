<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="BWJS.WebApp.Mofang.ProductDetail" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport"> 
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery-form.js"></script>
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/main.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/font-awesome.min.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/templatemo_style.css" />
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/layer.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
    <title></title>
</head>
<body>
    <div class="main1">
        <div class="zc-box">
            <div class="leftbox">
                <div class="back" onclick="javascript:history.go(-1)">返回</div>
            </div>

            <form method="post" class="form-horizontal" action="/Mofang/OrderApplys" role="form" id="frmMain" name="frmMain" enctype="multipart/form-data">

                <div class="form-box ">
                    <div class="group-box1 bg-a">
                        <div class="til-xq">产品详情</div>

                        <%--产品特色 开始///////////////////////////////////////////////////////////////////////////////--%>
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <h3 class="panel-title add-big">产品特色</h3>
                            </div>
                            <div class="panel-body">
                                <%
                                    if (detailModel.features != null) %>
                                <%{%>
                                <% for (int i = 0; i < detailModel.features.Count; i++) %>
                                <%{ %>
                                <div><%=detailModel.features[i].content %> </div>
                                <%} %>
                                <%}%>
                            </div>
                        </div>
                        <%--产品特色 结束///////////////////////////////////////////////////////////////////////////////--%>
                        <%--常见问题 开始///////////////////////////////////////////////////////////////////////////////--%>
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <h3 class="panel-title add-big">常见问题</h3>
                            </div>
                            <div class="panel-body">
                                <%if (detailModel.commonQuestions != null) %>
                                <%{ %>
                                <%for (int i = 0; i < detailModel.commonQuestions.Count; i++) %>
                                <%{ %>
                                <div class="jg"></div>
                                <div>
                                    <i class="qu">问题：</i><br />
                                    <%=detailModel.commonQuestions[i].question %>
                                </div>
                                <div>
                                    <i class="an">回答：</i><br />
                                    <%=detailModel.commonQuestions[i].answer %>
                                </div>
                                <%} %>
                                <%} %>
                            </div>
                        </div>
                        <%--常见问题 结束///////////////////////////////////////////////////////////////////////////////--%>
                        <%--试算因子 开始///////////////////////////////////////////////////////////////////////////////--%>
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h3 class="panel-title add-big">产品选项<%--试算因子--%></h3>
                            </div>
                            <div class="panel-body">
                                <%=GetRestrictGenesList() %>
                            </div>
                        </div>
                        <%--试算因子 结束///////////////////////////////////////////////////////////////////////////////--%>
                        <%--保障项目 开始///////////////////////////////////////////////////////////////////////////////--%>
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                <h3 class="panel-title add-big">保障项目</h3>
                            </div>
                            <div class="panel-body">
                                <%if (detailModel.protectItems != null) %>
                                <%{ %>
                                <%for (int i = 0; i < detailModel.protectItems.Count; i++) %>
                                <%{ %>
                                <%{ %>
                                <div class="jg"></div>
                                <div>
                                    <i class="qu">保障项目名：</i><%=detailModel.protectItems[i].name %>
                                </div>

                                <div>
                                    <i class="qu">保障项金额：</i><%=detailModel.protectItems[i].defaultValue %>
                                </div>
                                <div>
                                    <i class="qu">保障项描述：</i><%=detailModel.protectItems[i].description %>
                                </div>


                                <%} %>
                                <%} %>
                                <%} %>
                            </div>
                        </div>
                        <%--保障项目 结束///////////////////////////////////////////////////////////////////////////////--%>
                        <%--产品试算信息 开始///////////////////////////////////////////////////////////////////////////////--%>
                        <%--      <div class="panel panel-danger">
                            <div class="panel-heading">
                                <h3 class="panel-title add-big">产品试算信息</h3>
                            </div>
                            <div class="panel-body">
                                <%if (detailModel.priceArgsId != null) %>
                                <%{ %>
                                <div>
                                    <i class="qu">试算信息：</i><br />
                                </div>
                                <%= detailModel.priceArgsId %>
                                <%} %>
                            </div>
                        </div>--%>
                        <%--产品试算信息 结束///////////////////////////////////////////////////////////////////////////////--%>

                        <%--价格 开始///////////////////////////////////////////////////////////////////////////////--%>
                        <div class="panel panel-danger">
                            <div class="panel-heading">
                                <h3 class="panel-title add-big">价格</h3>
                            </div>
                            <div class="panel-body">
                                <%if (detailModel.restrictGenes != null) %>
                                <%{ %>
                                <div>
                                    <i class="qu">投保金额：</i> <span id="priceId"><%= detailModel.price %> </span>元
                                </div>

                                <%} %>

                                <%else %>
                                <%{ %>
                                <div>暂无详情信息！</div>
                                <%} %>
                            </div>
                        </div>
                        <%--价格 结束///////////////////////////////////////////////////////////////////////////////--%>
                        <div style="text-align: center;">
                            <input type="button" id="bt" name="bt" value="立即购买" class="sub" />
                        </div>
                        <input type="hidden" id="hdVal" name="hdVal" value="" />
                        <input type="hidden" id="hdkey" name="hdkey" value="" />
                        <input type="hidden" id="hdsort" name="hdsort" value="" />
                        <input type="hidden" id="hdunit" name="hdunit" value="" />
                        <input type="hidden" id="hdprotectitemid" name="protectitemid" value="" />
                        <input type="hidden" id="hdpriceArgsId" name="priceArgsId" value="<%=detailModel.priceArgsId %>" />
                        <input type="hidden" id="transNo" name="transNo" value="<%=transNo%>" />
                        <input type="hidden" id="CaseCode" name="CaseCode" value="<%=caseCode%>" />
                        <input type="hidden" id="price" name="price" value="" />
                        <input type="hidden" id="productId" name="productId" value="<%= productId %>" />
                        <input type="hidden" id="SinglePrice" name="SinglePrice" value="<%=detailModel.price %>" />
                        <input type="hidden" id="hdinsurantDateLimitVal" name="hdinsurantDateLimitVal" value="" />
                        <input type="hidden" id="hdinsurantDateLimitUnit" name="hdinsurantDateLimitUnit" value="" />
                        <%--其它 结束///////////////////////////////////////////////////////////////////////////////--%>
                        <input type="hidden" id="isYQHWMZRestrictGenes" name="isYQHWMZRestrictGenes" value="<%=isYQHWMZRestrictGenes %>" />
                        <input type="hidden" id="isJBBERestrictGenes" name="isJBBERestrictGenes" value="<%=isJBBERestrictGenes %>" />
                        <%--其它 结束///////////////////////////////////////////////////////////////////////////////--%>
                    </div>
                </div>

            </form>
        </div>


    </div>

    <%-- <input type="hidden" id="hdcaseCode" value="<%=caseCode%>" />--%>

    <script>
        function funRestrictGenes() {
            var buyCount = $("#buyCount");
            var buyCountVal = buyCount.val();
            var buyCountsort = buyCount.attr("sort");
            var buyCountkey = buyCount.attr("key");
            var buyCountUnit = buyCount.find("option:selected").attr("unit");

            var insurantDate = $("#insurantDate");
            var insurantDateVal = insurantDate.val();
            var insurantDatekey = insurantDate.attr("key");
            var insurantDatesort = insurantDate.attr("sort");
            var insurantDatesortUnit = insurantDate.find("option:selected").attr("unit");

            var insurantDateLimit = $("#insurantDateLimit");
            var insurantDateLimitVal = insurantDateLimit.val();
            var insurantDateLimitkey = insurantDateLimit.attr("key");
            var insurantDateLimitsort = insurantDateLimit.attr("sort");
            var insurantDateLimitUnit = insurantDateLimit.find("option:selected").attr("unit");

            var jibenbaoe = $("#jibenbaoe");
            var jibenbaoeVal = jibenbaoe.val();
            var jibenbaoekey = jibenbaoe.attr("key");
            var jibenbaoesort = jibenbaoe.attr("sort");
            var jibenbaoeUnit = jibenbaoe.find("option:selected").attr("unit");
            var jibenbaoeprotectitemid = jibenbaoe.attr("protectitemid");
            ////////////////承保天数赋值开始////////////////////////
            $("#hdinsurantDateLimitVal").val(insurantDateLimitVal);
            $("#hdinsurantDateLimitUnit").val(insurantDateLimitUnit);
            ////////////////承保天数赋值结束///////////////////////

            ////////////////一起慧99-百万医疗保险赋值开始////////////////////////
            var haveSocialSecurity = $("#haveSocialSecurity");//是否有社保
            var haveSocialSecurityVal = haveSocialSecurity.val();
            var haveSocialSecuritykey = haveSocialSecurity.attr("key");
            var haveSocialSecuritysort = haveSocialSecurity.attr("sort");
            var haveSocialSecurityUnit = haveSocialSecurity.find("option:selected").attr("unit");

            var DeductibleAmount = $("#DeductibleAmount");//免赔额
            var DeductibleAmountVal = DeductibleAmount.val();
            var DeductibleAmountkey = DeductibleAmount.attr("key");
            var DeductibleAmountsort = DeductibleAmount.attr("sort");
            var DeductibleAmountUnit = DeductibleAmount.find("option:selected").attr("unit");


            var insurantJob = $("#insurantJob");//承保职业
            var insurantJobVal = insurantJob.val();
            var insurantJobkey = insurantJob.attr("key");
            var insurantJobsort = insurantJob.attr("sort");
            var insurantJobUnit = insurantJob.find("option:selected").attr("unit");
            ////////////////一起慧99-百万医疗保险赋值结束///////////////////////
            ////////////////获取后台数据开始///////////////////////
            var isYQHWMZ = $("#isYQHWMZRestrictGenes").val();
            var isJBBE = $("#isJBBERestrictGenes").val();

            ////////////////获取后台数据结束///////////////////////
            var JsonTrialReqObject =
            {
                "customkey": "",
                "transNo": "",
                "caseCode": "<%=caseCode%>",
                "newRestrictGenes": [
                  {
                      "key": insurantDatekey,
                      "protectItemId": "",
                      "sort": insurantDatesort,
                      "value": insurantDateVal + insurantDatesortUnit
                  },
                  {
                      "key": insurantDateLimitkey,
                      "protectItemId": "",
                      "sort": insurantDateLimitsort,
                      "value": insurantDateLimitVal + insurantDateLimitUnit
                  },
                  {
                      "key": buyCountkey,
                      "protectItemId": "",
                      "sort": buyCountsort,
                      "value": buyCountVal + buyCountUnit
                  }
                ],
                "oldRestrictGene": {
                    "key": $("#hdkey").val(),
                    "protectItemId": $("#hdprotectitemid").val(),
                    "sort": $("#hdsort").val(),
                    "value": $("#hdVal").val() + $("#hdunit").val()
                }
            };
            if (isJBBE == "True")//“账户保”个人账户资金安全险,基本保额
            {
                var arrays = { "key": jibenbaoekey, "protectItemId": jibenbaoeprotectitemid, "sort": jibenbaoesort, "value": jibenbaoeVal + jibenbaoeUnit }
                ;
                JsonTrialReqObject.newRestrictGenes.push(arrays);
            }
            if (isYQHWMZ == "True")//一起慧99-百万医疗保险
            {
                var arrays1 = { "key": insurantJobkey, "protectItemId": "", "sort": insurantJobsort, "value": insurantJobVal + insurantJobUnit };
                var arrays2 = { "key": DeductibleAmountkey, "protectItemId": "", "sort": DeductibleAmountsort, "value": DeductibleAmountVal + DeductibleAmountUnit };
                var arrays3 = { "key": haveSocialSecuritykey, "protectItemId": "", "sort": haveSocialSecuritysort, "value": haveSocialSecurityVal + haveSocialSecurityUnit };
                JsonTrialReqObject.newRestrictGenes.push(arrays1);
                JsonTrialReqObject.newRestrictGenes.push(arrays2);
                JsonTrialReqObject.newRestrictGenes.push(arrays3);
            }
            // console.log(JsonTrialReqObject);
            $.ajax({
                url: '/Ajax/MofangOrder/RestrictGenesHandler.ashx',
                type: 'POST',
                dataType: 'Json',
                timeout: 0,
                async: false,
                data: {
                    Action: "001",
                    JsonTrialReq: JSON.stringify(JsonTrialReqObject)
                },
                success: function (resultData) {
                    if (resultData.respstat == "0000") {
                        $("#hdpriceArgsId").val(resultData.priceArgsId);
                        $("#priceId").html(resultData.price);
                        $("#price").val(resultData.price);
                        var sigleprice = eval(resultData.price / buyCountVal);
                        $("#SinglePrice").val(sigleprice);
                        // $("#hdpriceArgs").val(resultData.strEncode);

                        //$("#hdpriceArgsId").val(resultData.priceArgsId); 
                        //$("#hdpriceArgs").val(resultData.strEncode);
                    }
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    if (textStatus != 'timeout') {
                        alert(xmlHttpRequest.responseText);
                    } else {
                        //  $("#submit_message").html("噗, 您的网络忒慢了! 访问服务器超时了, 请再试一下!");
                    }
                }
            });
        }
        $(document).ready(function () {
            //张建永添加的定时换背景图
            setInterval(showBgn, 55000);
            function showBgn() {
                var numbg = Math.floor(Math.random() * 5 + 1);
                $("body").css({
                    "background": "url('../Content/img/Mofang/body-bg" + numbg + ".jpg')",
                    "background-size": "100% 100%"
                })
            }


            $("#buyCount,#insurantDate,#insurantDateLimit,#jibenbaoe,#haveSocialSecurity,#DeductibleAmount,#insurantJob").on('focus', function () {
                $("#hdVal").val(this.value);
                $("#hdkey").val($(this).attr("key"));
                $("#hdsort").val($(this).attr("sort"));
                $("#hdunit").val($(this).attr("unit"))
                $("#hdprotectitemid").val($(this).attr("protectitemid"));


            }).change(function () {

                funRestrictGenes();
            });
            $("#bt").click(function () {
                var isGotoNoticeInsurance = "<%=isGotoNoticeInsurance.ToString().ToLower()%>";
                if (isGotoNoticeInsurance == "true") {
                    $("#frmMain").attr("action", "/Mofang/NoticeInsurance");

                }
                else {
                    $("#frmMain").attr("action", " /Mofang/OrderApplys");

                }
                layer.msg('努力加载中.....', { icon: 6, time: 120000 });
                $("#frmMain").submit();
            });
            $("#price").val($("#priceId").html());

            //页面加载完根据默认试算因子选项试算一次

            $("#hdVal").val($("#buyCount").val());
            $("#hdkey").val($("#insurantDate").attr("key"));
            $("#hdsort").val($("#insurantDateLimit").attr("sort"));
            funRestrictGenes();
        });

    </script>

</body>
</html>
