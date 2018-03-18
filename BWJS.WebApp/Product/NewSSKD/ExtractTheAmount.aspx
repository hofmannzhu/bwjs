<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtractTheAmount.aspx.cs" Inherits="BWJS.WebApp.Product.NewSSKD.ExtractTheAmount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" name="viewport" />
    <title>评估报告</title>
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/NewSSKD/main.css" rel="stylesheet" />
    <%--<link href="/Content/css/NewSSKD/userReport.css" rel="stylesheet" />--%>
    <script src="/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/main.js" type="text/javascript"></script>
    <script src="/Scripts/bootbox.js" type="text/javascript"></script>
    <script src="/Scripts/NewSSKD/common.js" type="text/javascript"></script>
    <script src="/Scripts/pagecommon.js"></script>
     <script>
        $(document).ready(function () {
        $(".qr").click(function () {
            $(".mask").fadeIn();
        });
        $(".btn-n").click(function () {
            $(".mask").fadeOut();
        });
        });
    </script>

</head>
<body>
     <div class="mask">
        <div class="pop-box-dhk">
            <div class="col-lg-12 col-sm-12 col-xs-12 text-center">
                <span class="qr-msg">请您确认是否授额</span>
            </div>
            <div class="col-lg-12 col-sm-12 col-xs-12">

                 <div class="col-lg-1 col-sm-1 col-xs-1">
                </div>

                <div class="col-lg-4 col-sm-4 col-xs-4">
                    <a href="AddBankCard.aspx"><span class="btn-y">是</span></a>
                </div>
                <div class="col-lg-2 col-sm-2 col-xs-2">
                </div>
                <div class="col-lg-4 col-sm-4 col-xs-4">
                
                       <span class="btn-n">否</span>
                 
                </div>
                  <div class="col-lg-1 col-sm-1 col-xs-1">
                </div>

            </div>
        </div>
    </div>
    <!--遮罩弹窗显示是和否end-->
    <!--遮罩弹窗显示是和否end-->
 <div class="main">
        <!--头部元素start-->
        <div class="head-box">
            <div class="col-lg-12">
                <!--申请成功移动字幕start-->
                <script src="/Scripts/NewSSKD/success.js"></script>

            </div>
        </div>
        <!--头部元素end-->

        <!--步骤条start-->
               <!--步骤条start-->
        <div class="tab-box">
            <ul>
                <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot1.png"></span>人像采集</li>
                <li class="" style="color: #FA6113"><span class="linea"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot2.png"></span>授权认证</li>
                <li class="" style="color: #FA6113"><span class="line"></span><span class="bg-r active">
                    <img src="../../Content/img/NewSSKD/tab-dot3.png"></span>评估报告</li>
                <li class=""><span class="line"></span><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot5.png"></span>选择银行卡</li>
                <li class=""><span class="bg-r">
                    <img src="../../Content/img/NewSSKD/tab-dot4.png"></span>申请确认</li>

            </ul>
        </div>
   <div class="formbox">
            <form method="post" class="form-horizontal mar-top1" role="form" id="bankCardForm" action="/Product/NewSSKD/ApplyForConfirmation">
                <div class="col-sm-12  text-right" style="margin-top: 40px;">
                    <div class="form-group">
                        <label for="inpBankCardNo" class="col-lg-3 col-sm-3 col-xs-3 control-label">可提额度：</label>
                          <div class="col-lg-8 col-sm-8 col-xs-8">
                            <input type="text" value="" id="" name="inpBankCardMobileValidCode" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="6" class="form-control" placeholder="可提额度5000-20000元" data-msg-required="不能为空" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpBankCardNo" class="col-lg-3 col-sm-3 col-xs-3 control-label">商家账号：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8 text-left">
                            <input type="text" class="form-control" id="" name="inpBankCardNo" onkeyup="CheckbankNum(this)" maxlength="30" placeholder="请输入商家账号" data-msg-required="不能为空" data-msg-age="用户唯一标识" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inpMobileForBankCard" class="col-lg-3 col-sm-3 col-xs-3 control-label">特许商家授权密码：</label>
                      
                      <div class="col-lg-8 col-sm-8 col-xs-8 text-left">
                            <input type="text" class="form-control" id="" name="inpBankCardNo" onkeyup="CheckbankNum(this)" maxlength="30" placeholder="请输入商家授权密码" data-msg-required="不能为空" data-msg-age="用户唯一标识" required />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inpBankCardMobileValidCode" class="col-lg-3 col-sm-3 col-xs-3 control-label">商家身份证号：</label>
                        <div class="col-lg-8 col-sm-8 col-xs-8">
                            <input type="text" value="" id="" name="inpBankCardMobileValidCode" onkeyup="this.value=this.value.replace(/\D/g,'');" maxlength="6" class="form-control" placeholder="请输入商家身份证号" data-msg-required="不能为空" />
                        </div>
                    </div>

                </div>
                <div class="col-lg-12 col-sm-12 col-xs-12">
                     <div class="col-lg-1 col-sm-1 col-xs-1">
                      
                    </div>

                    <div class="col-lg-4 col-sm-4 col-xs-4">
                        <div class="next-btn qr" id="">确 认</div>
                    </div>
                    <div class="col-lg-2 col-sm-2 col-xs-2">
                        
                    </div>
                    <div class="col-lg-4 col-sm-4 col-xs-4">
                         <a href="TheAppraisalReport.aspx">
                           <div class="btn-cal" id="">取 消</div>
                         </a>
                    </div>
                     <div class="col-lg-1 col-sm-1 col-xs-1">
                      
                    </div>
                </div>
               
              
            </form>
        </div>
       </div>
</body>
</html>
