<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeInsurance.aspx.cs" Inherits="BWJS.WebApp.Mofang.NoticeInsurance" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <script src="/Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="/Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/main.css" />
    <link rel="stylesheet" href="/Content/css/Mofang/templatemo_style.css" />
    <script type="text/javascript" src="//cps.hzins.com/v2/js/health.js"></script>

    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/layer.js"></script>
    <script src="/Scripts/pagecommon.js"></script>
</head>
<body>

    <div class="main1">
        <div class="back" onclick="javascript:history.go(-1)">返回</div>
        <div class="zc-box">
            <div class="form-box">
                <div class="group-box1 bg-a">

                    <form id="form1" style="font-size: 14px; font-style: normal" runat="server" action="/Mofang/OrderApplys">
                        <%=resp.healthNotifyHtml %>
                        <input type="hidden" name='HealthOld' id='HealthOld' />
                        <input type="hidden" name='healthId' id='healthId' />
                        <input type="hidden" name='transNo' value="<%=TransNo%>" />
                        <input type="hidden" name='CaseCode' value="<%= CaseCode %>" />
                        <input type="hidden" name='protectitemid' value="<%=protectitemid%>" />
                        <input type="hidden" name='priceArgsId' value="<%=priceArgsId%>" />
                        <input type="hidden" name='price' value="<%=price%>" />
                        <input type="hidden" name='buyCount' value="<%=buyCount%>" />
                        <input type="hidden" id="SinglePrice" name="SinglePrice" value="<%=SinglePrice %>" />
                        <input type="hidden" id="hdinsurantDateLimitVal" name="hdinsurantDateLimitVal" value="<%=insurantDateLimitVal%>" />
                        <input type="hidden" id="hdinsurantDateLimitUnit" name="hdinsurantDateLimitUnit" value="<%=insurantDateLimitUnit%>" />
                    </form>
                    <div class="imbox">
                        <img src="/Content/img/Mofang/wenpic.png" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript"> 
        duck.trialGenes = function() {
            //通过Trial.getTrialGenes() 获取
            var trialGenes =<%=strPriceArgs %>;
		 
            return trialGenes;
        }
        //下一步跳转
        duck.pass = function(notifyAnswerId) {
            document.getElementById("form").submit();
        }
        duck.nopass = function(notifyAnswerId) {
            layer.alert("健康告知没有通过");
            //	document.getElementById("form").submit();
        }
        duck.postNotifyAnswer = function () {

            $("#HealthOld").val(duck.getHealthOld());             
            if($('#is_1').is(':checked')) {
                layer.alert("很抱歉，被保险人的健康状况不满足该保险投保规定！不能进行下一步")
            }
            else if($('#not_1').is(':checked'))
            {
                healthsubmit(); 
            }
            else
            {
                layer.alert("对不起，您的健康告知未选择或未填写完整，保险公司无法受理您此险种的投保申请");
            }
            
        }
        ///////////////////////////////////////////////////////////////////////////////////////
        function healthsubmit()
        {
            layer.msg('努力加载中.....', { icon: 6, time: 120000 });
            $.ajax({
                url: '/Ajax/MofangOrder/HealthHandler.ashx',
                type: 'post',
                dataType: 'Json',
                timeout: 0,
                async: false,
                data: {
                    Action: "001",
                    transNo:'<%=TransNo%>',
                    answer:duck.getHealthOld()
                },
                success: function (resultData) {
                    if (resultData.respstat == "0000") {
                        if('<%= CaseCode %>'=="0001076209802609")//经过和魔方沟通这2款产品先写固定的，后期说要调在改
                        {
                            $("#healthId").val("4175100"); 
                        }
                        else if('<%= CaseCode %>'=="0001076211102627")
                        {
                            $("#healthId").val("4175114 "); 
                        }
                        else
                        { 
                            $("#healthId").val(resultData.healthId);  
                        }
                        
                       
                        
                        $("#form1").submit();
                    }
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    if (textStatus != 'timeout') {
                        layer.alert(xmlHttpRequest.responseText);
                    } else {
                        //  $("#submit_message").html("噗, 您的网络忒慢了! 访问服务器超时了, 请再试一下!");
                    }
                }
            });
        }
    </script>
</body>
</html>
