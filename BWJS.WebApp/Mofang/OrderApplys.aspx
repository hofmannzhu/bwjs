<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderApplys.aspx.cs" Debug="true" Inherits="BWJS.WebApp.Mofang.OrderApplys" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/jquery.validate.js"></script>
    <script src="/Scripts/Mofang/mofanghelper.js" type="text/javascript"></script>
    <script src="/Scripts/Mofang/mofanghelperjob.js" type="text/javascript"></script>
    <script src="/Scripts/WdatePicker/config.js"></script>
    <script src="/Scripts/WdatePicker/calendar.js"></script>
    <script src="/Scripts/WdatePicker/WdatePicker.js"></script>

    <link rel="stylesheet" href="/Content/css/bootstrap.min.css">
    <link rel="stylesheet" href="/Content/css/Mofang/main.css">
    <link href="/Scripts/skin/layer.ext.css" rel="stylesheet" />
    <link href="/Scripts/skin/layer.css" rel="stylesheet" />
    <script src="/Scripts/layer.js"></script>

    <script src="/Scripts/Pinyin/pinyin_dict_polyphone.js"></script>
    <script src="/Scripts/Pinyin/pinyin_dict_withtone.js"></script>
    <script src="/Scripts/Pinyin/pinyinUtil.js"></script> 
    <script src="/Scripts/pagecommon.js"></script>
    <title></title>
    <style>
        .tb-boxc hdCalss {
        }
    </style>
 
</head>
<body>
    <div class="main1">
        <div class="leftbox">
            <div class="back" id="backId">返回</div>
        </div>
        <div class="zc-box">
            <div class="form-box">
                <form method="post" class="form-horizontal" role="form" id="jsForm">
                    <ul>
                        <!--给自己申请保险 start-->
                        <div class="group-box bg-a2">
                            <ul>
                                <li class="form-group">
                                    <div class="tb-boxa col-sm-12 text-center">
                                        <span class="active-btn tb-boxc" id="btziji">给自己投保</span>
                                        <span class="tb-boxc" id="bttaren">给他人投保</span>
                                    </div>
                                </li>
                                <ul>
                        </div>

                        <div class="group-box bg-a1">
                            <ul>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人证件类型：</label>
                                    <div class="col-sm-7">
                                        <select name="CardType" id="CardTypeId" class="form-control" required>
                                            <% for (int i = 0; i < oCardTypeList.Count; i++) %>
                                            <%{ %>
                                            <option value="<%=oCardTypeList[i].Value %>"><%=oCardTypeList[i].Name %></option>
                                            <%} %>
                                        </select>
                                    </div>
                                    <div class="col-sm-1">
                                        <button class="btn mar-btn btn-danger" id="readCardId">身份证扫描</button>
                                    </div>

                                    <div class="col-sm-3 "></div>
                                    <div class="col-sm-8" id="divIdCardDescription">
                                        <span class="ts"><i class="red">温馨提示：</i>请首选扫描身份证，系统将自动添加您的身份信息（<b>第1步：</b>在设备面板身份证区域放置身份证，<b>第2步：</b>点击“身份证扫描”按钮） ，当然您也可以选择手写输入信息。</span>
                                    </div>
                                </li>
                                <li class="form-group" id="tbPhotoID" style="display: none;">
                                    <label for="" class="col-sm-3 control-label">投保人头像：</label>
                                    <div class="col-sm-8">
                                        <div class="imgbox">
                                            <span class="pho">
                                                <img id="PhotoID" name="Photo" style="width: 96px; height: 118px;" /></span>
                                            <span class="sm">请将身份证拿起后放入感应器对应虚线内</span>
                                            <span class="bg1"></span>
                                        </div>


                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人姓名：</label>
                                    <div class="col-sm-8">
                                        <em>*</em><input type="text" value="" name="CName" id="CNameId" class="form-control" placeholder="您的中文名称" required data-msg-required="不能为空" data-msg-age="请输入姓名" />
                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人姓名拼音：</label>
                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <input type="text" name="EName" id="ENameId" value="" class="form-control" placeholder="被保险人姓名（拼音）" required data-msg-required="不能为空" data-msg-age="请输入姓名拼音" />
                                    </div>
                                </li>

                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人证件号：</label>
                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <input type="text" value="" name="CardCode" id="CardCodeId" class="form-control" placeholder="有效证件号" required data-msg-required="不能为空" />
                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人性别：</label>
                                    <div class="col-sm-8">
                                        <label>
                                            <input name="Sex" type="radio" value="1" checked="checked" required style="width: 22px; height: 22px;">
                                            男</label>
                                        <label>
                                            <input name="Sex" type="radio" value="0" style="width: 22px; height: 22px;">
                                            女</label>
                                        <span for="radio1" class="error"></span>
                                    </div>
                                </li>
                                <%-----------------------------------------动态区域开始-------------------------------------------------%>
                                <%if (isHaveJob) %>
                                <%{ %>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人职业：</label>
                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <div class="col-sm-12 pad1">
                                            <div class="col-sm-4 pad1">
                                                <select id="jobone" name="jobone" class="form-control"></select>
                                            </div>
                                            <div class="col-sm-4 pad1">
                                                <select id="jobtwo" name="jobtwo" class="form-control"></select>
                                            </div>
                                            <div class="col-sm-4 pad1">
                                                <select id="jobthree" name="jobthree" class="form-control "></select>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <%} %>
                                <%if (isluyouxianCXMDD) %>
                                <%{ %>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">出行目的地：</label>
                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <div class="wherebox"><%=CXMDDStr %></div>
                                    </div>
                                </li>
                                <%} %>

                                <% if (isShowrelatedPersonHouse) %>
                                <%{ %>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人与房屋关系：</label>
                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <select name="relatedPersonHouse" id="relatedPersonHouseId" class="form-control" required>
                                            <option value="0">房主</option>
                                            <option value="1">房主直系亲属</option>
                                            <option value="2">租户</option>
                                        </select>
                                    </div>
                                </li>

                                <%} %>

                                <% if (isShowcaichansuozaidi) %>
                                <%{ %>

                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">财产所在地：</label>
                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <div class="col-sm-12 pad1">
                                            <div class="col-sm-4 pad1">
                                                <select id="inpProductPropertyAreaProvince" name="inpProductPropertyAreaProvince" class="form-control" required></select>
                                            </div>
                                            <div class="col-sm-4 pad1">
                                                <select id="inpProductPropertyAreaCity" name="inpProductPropertyAreaCity" class="form-control" required></select>
                                            </div>
                                            <div class="col-sm-4 pad1">
                                                <select id="inpProductPropertyAreaDistrict" name="inpProductPropertyAreaDistrict" class="form-control required"></select>
                                            </div>

                                        </div>

                                    </div>
                                </li>


                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">详细地址：</label>
                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <input id="inpProductPropertyAreaXXDZ" name="inpProductPropertyAreaXXDZ" type="text" class="form-control" value="" placeholder="您的详细地址" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </li>

                                <%} %>

                                <%if (oTravelDestinationList != null) %>
                                <%{ %>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">出行目的：</label>
                                    <div class="col-sm-8">
                                        <select id="travelDestination" name="travelDestination" class="form-control">
                                            <%for (int i = 0; i < oTravelDestinationList.Count; i++) %>
                                            <%{ %>
                                            <option value="<%=oTravelDestinationList[i].Value %>"><%=oTravelDestinationList[i].Name %></option>
                                            <%} %>
                                        </select>
                                    </div>
                                </li>

                                <%} %>
                                <% if (isShowProvince) %>
                                <%{ %>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人居住地：</label>

                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <div class="col-sm-12 pad1">
                                            <div class="col-sm-4 pad1">
                                                <select id="inpProvince" name="inpProvince" class="form-control" required></select>
                                            </div>
                                            <div class="col-sm-4 pad1">
                                                <select id="inpCity" name="inpCity" class="form-control" required></select>
                                            </div>
                                            <div class="col-sm-4 pad1">
                                                <select id="inpDistrict" name="inpDistrict" class="form-control" required></select>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <%} %>
                                <%-----------------------------------------动态区域结束-------------------------------------------------%>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人出生日期：</label>
                                    <div class="col-sm-8">
                                        <%--  <input id="BirthDayId" class="form-control" name="BirthDay" type="date" value="1988-5-24" required /><em>*</em>--%>
                                        <input id="BirthDayId" class="form-control" name="BirthDay" type="text" placeholder="yyyy-mm-dd" value="" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </li>

                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">证件有效期：</label>
                                    <div class="col-sm-8">
                                        <input id="CardPeriodId" class="form-control" name="CardPeriod" type="text" value="" required /><em>*</em>
                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">起保时间：</label>
                                    <div class="col-sm-8">
                                        <%--           <input id="startDateId" name="startDate" class="form-control" type="date" value="2017-9-18" />--%>
                                        <input id="startDateId" name="startDate" type="text" class="form-control fl Wdate" value="<%=DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")%>" placeholder="起保时间" required /><em>*</em>
                                    </div>
                                </li>

                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label ">终保时间：</label>
                                    <div class="col-sm-8">
                                        <%-- <input id="endDateId" name="endDate" class="form-control" type="date" value="2017-12-6" />--%>
                                        <input id="endDateId" name="endDate" readonly="readonly" type="text" class="form-control fl Wdate" value="<%=GetEndDate(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),insurantDateLimitVal,insurantDateLimitUnit)%>" placeholder="终保时间" />
                                    </div>
                                </li>

                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">保险人购买份数：</label>
                                    <div class="col-sm-8">
                                        <input type="text" value="<%=buyCount %>" readonly="readonly" name="Count" id="CountId" class="form-control" required placeholder="被保险人购买份数" data-msg-required="必填" data-msg-age="请输入数字" />
                                    </div>
                                </li>

                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人移动电话：</label>
                                    <div class="col-sm-7">
                                        <div style="width: 100%">
                                            <div style="width: 100%; float: left">
                                                <input type="text" value="" id="MobileId" name="Mobile" maxlength="11" class="form-control" onkeyup="VMobileId()" placeholder="11位手机号" required data-rule-mobile="true"  />
                                                <em>*</em>
                                            </div>
                                            <div style="width: 100%; display: none" id="spanMobileId"><span style="color: red">输入有误</span></div>
                                        </div>
                                    </div>
                                    <div class="col-sm-1">
                                        <input type="button" class="btn mar-btn btn-info" id="ValidCodeBT" name="ValidCodeBT" value="获取验证码" onclick="settime(this)" />
                                    </div>
                                </li>


                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">短信验证码：</label>
                                    <div class="col-sm-8">
                                        <input type="text" value="" id="ValidCode" name="ValidCode" class="form-control" placeholder="请输入手机验证码" required data-msg-required="请输入手机验证码" />
                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">投保人邮箱：</label>
                                    <div class="col-sm-8">
                                        <input type="email" value="" name="Email" id="EmailId" class="form-control" placeholder="***@***.**" required data-rule-email="true" data-msg-required="不可为空，请输入email地址" data-msg-email="请输入正确的email地址" /><em>*</em>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <!--给自己申请保险 end-->
                        <!--给他人申请保险 start-->

                        <div class="btb-box group-box bg-c">
                            <ul>
                                <li class="form-group mtop">
                                    <label for="" class="col-sm-3 control-label">被保险人证件类型：</label>
                                    <div class="col-sm-7">
                                        <select name="BCardType" id="BCardTypeId" class="form-control" required>
                                            <% for (int i = 0; i < oCardTypeList.Count; i++) %>
                                            <%{ %>
                                            <option value="<%=oCardTypeList[i].Value %>"><%=oCardTypeList[i].Name %></option>
                                            <%} %>
                                        </select>
                                    </div>
                                    <div class="col-sm-1">
                                        <span class="btn mar-btn btn-danger" id="bReadCardId">身份证扫描</span>
                                    </div>
                                    <div class="col-sm-3 "></div>
                                    <div class="col-sm-8">
                                        <span class="ts"><i class="red">温馨提示：</i>请首选扫描身份证，系统将自动添加您的身份信息（<b>第1步：</b>在设备面板身份证区域放置身份证，<b>第2步：</b>点击“身份证扫描”按钮） ， 当然您也可以选择手写输入信息。</span>
                                    </div>
                                </li>
                                <li class="form-group" id="BtbPhotoID" style="display: none;">
                                    <label for="" class="col-sm-3 control-label">被投保人头像：</label>
                                    <div class="col-sm-8">
                                        <div class="imgbox">
                                            <span class="pho">
                                                <img id="BPhotoID" name="BPhoto" style="width: 96px; height: 118px;" /></span>
                                            <span class="sm">请将身份证拿起后放入感应器对应虚线内</span>
                                            <span class="bg2"></span>
                                        </div>

                                    </div>
                                </li>
                                <li class="form-group ">
                                    <label for="" class="col-sm-3 control-label">被保险人姓名：</label>
                                    <div class="col-sm-8">
                                        <input type="text" class="form-control" value="" name="BCName" id="BCNameId" placeholder="您的中文名称" /><em>*</em>
                                    </div>
                                </li>

                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">被保险人姓名拼音：</label>
                                    <div class="col-sm-8">
                                        <input type="text" value="" id="BENameId" name="BEName" class="form-control" placeholder="被保险人姓名（拼音）" data-msg-number="请输入拼音" />
                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">被保险人性别：</label>
                                    <div class="col-sm-8">
                                        <label>
                                            <input style="width: 22px; height: 22px;" name="BSex" type="radio" value="1" required>
                                            男</label>
                                        <label>
                                            <input style="width: 22px; height: 22px;" name="BSex" type="radio" checked="checked" value="0">
                                            女</label>
                                        <span for="radio1" class="error"></span>
                                    </div>
                                </li>
                                <%-----------------------------------------被投保人动态区域结束-------------------------------------------------%>
                                <%if (isHaveJob) %>
                                <%{ %>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">被保人职业：</label>
                                    <div class="col-sm-8">
                                        <em>*</em>
                                        <div class="col-sm-12 pad1">
                                            <div class="col-sm-4 pad1">
                                                <select id="Bjobone" name="Bjobone" class="form-control"></select>
                                            </div>
                                            <div class="col-sm-4 pad1">
                                                <select id="Bjobtwo" name="Bjobtwo" class="form-control"></select>
                                            </div>
                                            <div class="col-sm-4 pad1">
                                                <select id="Bjobthree" name="Bjobthree" class="form-control"></select>
                                            </div>

                                        </div>

                                    </div>
                                </li>
                                <%} %>
                                <%-----------------------------------------被投保人动态区域结束-------------------------------------------------%>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">被保险人证件号：</label>
                                    <div class="col-sm-8">
                                        <input type="text" value="" name="BCardCode" id="BCardCodeId" class="form-control" placeholder="有效证件号" required data-msg-required="不能为空" /><em>*</em>
                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">被保险人出生日期：</label>
                                    <div class="col-sm-8">
                                        <input id="BBirthDayId" type="text" class="form-control" name="BBirthDay" value="" required data-msg-required="必填" /><em>*</em>
                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">证件有效期：</label>
                                    <div class="col-sm-8">
                                        <%-- <input id="BCardPeriodId" name="BCardPeriod" class="form-control" type="date" value="2023-02-09" /><em>*</em>--%>
                                        <input id="BCardPeriodId" class="form-control" type="text" name="BCardPeriod" value="" required /><em>*</em>
                                    </div>
                                </li>
                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">与投保人关系：</label>
                                    <div class="col-sm-8">
                                        <select id="RelationID" name="RelationID" class="form-control" data-msg-required="必填">
                                            <em>*</em>
                                            <% for (int i = 0; i < listRelationViewMode.Count; i++) %>
                                            <%{ %>
                                            <option value="<%=listRelationViewMode[i].Value %>"><%=listRelationViewMode[i].Name %></option>
                                            <%} %>
                                        </select>
                                    </div>
                                </li>

                                <li class="form-group">
                                    <label for="" class="col-sm-3 control-label">手机号码：</label>
                                    <div class="col-sm-8">
                                        <input type="text" value="" name="BMobile" id="BMobileId" class="form-control" placeholder="11位手机号码" data-rule-mobile="true" required data-msg-required="不可空,请输入手机号" data-msg-mobile="请输入11位电话号码" /><em>*</em>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <!--给他人申请保险end-->

                        <div class="group-box  bg-b">
                            <ul>
                                <li class="form-group mtop">
                                    <label for="" class="col-sm-3 control-label">产品结算价：</label>
                                    <div class="col-sm-8">
                                        <input type="text" value="<%=price%>元" readonly="readonly" name="SinglePrice" id="SinglePriceId" class="form-control" placeholder="产品结算价" required data-msg-required="必填" data-msg-age="请输入数字" />
                                    </div>
                                </li>
                            </ul>
                        </div>

                        <div class="group-box bg-b">
                            <ul>
                                <li class="form-group mat">
                                    <div class="col-sm-12 text-center">
                                        <input id="sbOrderApply" type="button" value="提交申请" class="sub" />
                                        <input type="reset" value="重 置" class="res" />
                                    </div>
                                </li>
                                <ul>
                        </div>

                    </ul>
                    <input type="hidden" id="payUrl" name="payUrl" value="">
                </form>
            </div>
        </div>
    </div>
    <div>
        <input type="hidden" id="hidProvCityId" name="ProvCityId" value="" />
        <input type="hidden" id="hidType" name="Type" value="">
        <input type="hidden" id="sedMSM" name="sedMSM" value="">
        <input type="hidden" id="hidHaveJob" name="hidHaveJob" value="<%=isHaveJob %>">
        <input type="hidden" id="hidShowProvince" name="hidShowProvince" value="<%=isShowProvince %>">
        <input type="hidden" id="hidShowcaichansuozaidi" name="hidShowcaichansuozaidi" value="<%=isShowcaichansuozaidi %>">

        <%--        <%if (ProModel != null) %>
        <%{ %>
   <input type="hidden" id="hidInsuranceDate" name="hidInsuranceDate" value="<%=ProModel.InsuranceDate %>"> 
        <input type="hidden" id="hidPeriodDate" name="hidPeriodDate" value="<%=ProModel.PeriodDate %>">
        <%} %>--%>
        <%--   --%>
        <input type="hidden" id="hidOnlyOthers" name="hidOnlyOthers" value="<%=isOnlyOthers %>">
    </div>
    <object classid="clsid:5819234B-5977-4C82-9C59-A9D3C7D46083"
        id="CertCtl" name="CertCtl" width="0" height="0">
    </object>
    <script type="text/javascript">
        //////////////////////////////////读取卡信息/////////////////////////////////////////////// 
        var ucardType=0;//0表示投保人 1表示被投保人 
        function readCard()
        {  
            $("#readCardId").click(function(){   
                $("#tbPhotoID").css("display","block");
                ucardType=0;
                connect();  
              
            });
            $("#bReadCardId").click(function(){  
                document.getElementById("BPhotoID").src = "";
                $("#BtbPhotoID").css("display","block");
                ucardType=1;
                connect(); 
            }); 
        }
        function connect() {
            var CertCtl = document.getElementById("CertCtl");
            try {
                var result = CertCtl.OpenComm();
                if (result == "") { 
                    readCert();
                }
                else { 
                }
            } catch (e) {
            }
        } 
        function readCert() {
            var CertCtl = document.getElementById("CertCtl");
            try {
                var startDt = new Date();
                var result = CertCtl.ReadCard();
                var endDt = new Date(); 
                if (result == "") { 
                    //////////////////// 处理有效日期截止////////////////////////////////////////
                    var dateAll=CertCtl.ExpiredDate;
                    var year=dateAll.substring(0,4);
                    var month=dateAll.substring(4,6);
                    var day=dateAll.substring(6,8);
                    ////////////////////////////////////////////////////////////
                    //////////////////// 处理出生日期////////////////////////////////////////
                    var dateAllBirth=CertCtl.Born;
                    var yearBirth=dateAllBirth.substring(0,4);
                    var monthBirth=dateAllBirth.substring(4,6);
                    var dayBirth=dateAllBirth.substring(6,8); 
                    ////////////////////////////////////////////////////////////
                    //////////////////// 处理用户头像//////////////////////////////////////// 
                    var strPhotoBase64=CertCtl.CardPictureData;
                    ////////////////////////////////////////////////////////////
                    //////////////////// 处理用户性别////////////////////////////////////////
                    var sexperson= CertCtl.Sex;
                    var sexpersonValue=(sexperson=="男"?1:0);
                    ////////////////////////////////////////////////////////////
                    //////////////////// 处理用户性别////////////////////////////////////////
                    var Names=CertCtl.Name;
                    var  pinyinWords = pinyinUtil.getPinyin(Names, '', false, true);  
                    ////////////////////////////////////////////////////////////
                    //////////////////// 处理其它////////////////////////////////////////
                    var  CardNo= CertCtl.CardNo;
                    ////////////////////////////////////////////////////////////
                    if(ucardType==0)//投保人时候
                    {
                        $("#CNameId").val(Names);//姓名  
                        $("#ENameId").val(pinyinWords);  
                        $("#CardCodeId").val(CardNo); //身份证号
                        $("#BirthDayId").val(yearBirth+"-"+monthBirth+"-"+dayBirth);//出生日期  
                        $("#CardPeriodId").val(year+"-"+month+"-"+day);//有效日期截止
                        //  $("#CNameId").val(CertCtl.hxgc_GetSex()); //性别 
                        document.all("PhotoID").src = "data:image/jpeg;base64," + strPhotoBase64;//显示图片 
                        $("input[name='Sex'][value='"+sexpersonValue+"']").prop("checked","checked"); 
                        $("#CardTypeId").find("option[value='"+1+"']").attr("selected",true); 
                    }
                    if(ucardType==1)
                    {
                        $("#BCNameId").val(Names);//姓名
                        $("#BENameId").val(pinyinWords);  
                        $("#BCardCodeId").val(CardNo); //身份证号
                        $("#BBirthDayId").val(yearBirth+"-"+monthBirth+"-"+dayBirth);//出生日期  
                        $("#BCardPeriodId").val(year+"-"+month+"-"+day);//有效日期截止
                        document.all("BPhotoID").src = "data:image/jpeg;base64," + strPhotoBase64;//显示图片
                        $("input[name='BSex'][value='"+sexpersonValue+"']").prop("checked","checked");
                        $("#BCardTypeId").find("option[value='"+1+"']").attr("selected",true);
                    }  
                    //document.all("PhotoID").src = 'data:image/jpeg;base64,' + CertCtl.CardPictureData;//显示图片  
                    //$("#CardID").val(CertCtl.CardNo); //身份证号  
                }
                disconnect();
            } catch (e) {
            }
        }
        function disconnect() {
            var CertCtl = document.getElementById("CertCtl");
            try {
                var result = CertCtl.CloseComm(); 
            } catch (e) {
            }
        } 
        /////////////////////////////////////////////////////////////////////////////////

        function dateWdatePicker()
        {  
             
            $('#startDateId').val("<%=DateTime.Now.AddDays(StartDateParame).ToString("yyyy-MM-dd")%>"); 
            $('#startDateId').on('focus', function () {  
                WdatePicker({ minDate:"<%=DateTime.Now.AddDays(StartDateParame)%>",
                    maxDate:"<%=DateTime.Now.AddDays(Convert.ToInt32(ProModel.InsuranceDate))%>"
                    ,dateFmt: 'yyyy-MM-dd' ,onpicked:getMonday,readOnly:true});
            });  
       
            $("#endDateId").val("<%=GetEndDate(DateTime.Now.AddDays(StartDateParame).ToString("yyyy-MM-dd"),insurantDateLimitVal,insurantDateLimitUnit)%>");  
       
        
            //$('#endDateId').on('focus', function () {
            //    WdatePicker({ minDate: '#F{$dp.$D(\'endDateId\')}', dateFmt: 'yyyy-MM-dd' });
            //});
        }
        function getMonday()
        { 
            var beginDate=$(this).val();
            var dataValue='<%=insurantDateLimitVal%>';
            var dataUnit='<%=insurantDateLimitUnit%>'; 
            $.ajax({
                url: '/Ajax/MofangOrder/CollectHandler.ashx',
                type: 'post',
                dataType: 'text',
                timeout: 0,
                async: true,
                data: {
                    Action: "001" ,
                    beginDate:beginDate,
                    dataValue:dataValue,
                    dataUnit:dataUnit
                }, 
                success: function (resultData) { 
                    $("#endDateId").val(resultData);
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    if (textStatus != 'timeout') {
                        //    alert(xmlHttpRequest.responseText);
                    } else {
                        //  $("#submit_message").html("噗, 您的网络忒慢了! 访问服务器超时了, 请再试一下!");
                    }
                    //$("#order-loading").replaceWith(originSubmit);
                    //$("#submit_message").show();
                    //$(sender).fadeIn('slow');
                }});
            //$(this).val()
          <%--  $("#endDateId").val(<%=GetEndDate( ,ProModel.PeriodDate)%>);  --%>
          

        }
        function setProvCityId() {
            var inpProvince = $("#inpProvince").val();
            var inpCity = $("#inpCity").val();
            var inpDistrict = $("#inpDistrict").val();

            if (inpDistrict) {
                $("#hidProvCityId").val(inpProvince + "-" + inpCity + "-" + inpDistrict);
            }
            else {
                $("#hidProvCityId").val(inpProvince + "-" + inpCity);
            } 
        }  
        $(document).ready(function () { 
            $('#CardPeriodId').on('focus', function () {  
                WdatePicker({minDate:"<%=DateTime.Now%>",dateFmt: 'yyyy-MM-dd',readOnly:true});
            });  
            $('#BCardPeriodId').on('focus', function () {  
                WdatePicker({ minDate:"<%=DateTime.Now%>",dateFmt: 'yyyy-MM-dd',readOnly:true});
            });  
            $('#BirthDayId').on('focus', function () {  //投保人出生日期
            
                WdatePicker({ dateFmt: 'yyyy-MM-dd',readOnly:true});
            }); 
            $('#BBirthDayId').on('focus', function () {  //被投保人出生日期
                WdatePicker({ dateFmt: 'yyyy-MM-dd',readOnly:true});
            });  
            connect();//读取身份证信息
            readCard();

            dateWdatePicker();
            
            var  hidShowProvinceValue=$("#hidShowProvince").val(); 
            if(hidShowProvinceValue=="True")
            { 
                helper.transNo = '<%=TransNo%>';
                helper.caseCode = '<%=CaseCode%>';
                helper.initProvince($("#inpProvince"),$("#inpCity"),$("#inpDistrict"));
            }
    
            var  hidShowcaichansuozaidiValue=$("#hidShowcaichansuozaidi").val();  
            if(hidShowcaichansuozaidiValue=="True")
            {
                helper.areaTransNo = '<%=TransNo%>';
                helper.areaCaseCode='<%=CaseCode%>';
                helper.ProductPropertyAreaProvince($("#inpProductPropertyAreaProvince"), $("#inpProductPropertyAreaCity"), $("#inpProductPropertyAreaDistrict"));            
            }  
            var  haveJobValue=$("#hidHaveJob").val();  
            if(haveJobValue=="True")
            { 
                helperjob.transNo = '<%=TransNo%>';
                helperjob.caseCode = '<%=CaseCode%>';
                helperjob.initOne($("#jobone"), $("#jobtwo"), $("#jobthree"));
                helperjob.transNo = '<%=TransNo%>';
                helperjob.caseCode = '<%=CaseCode%>';
                helperjob.initOne($("#Bjobone"), $("#Bjobtwo"), $("#Bjobthree")); 
            } 

            $("#sbOrderApply").click(function () {  
              
                <%if (isShowProvince)%>
                     <%{%>
                setProvCityId();
                     <%}%>
                SubmitOrderApply();
            }); 


            $("#CardTypeId").change(function () {
                if ($.trim($(this).val()) == "1") {
                    $("#readCardId").removeAttr("disabled");
                    $("#divIdCardDescription").show();
                    //$("#tbPhotoID").show();
                    $("#CardCodeId").attr("minlength", 15);
                    $("#CardCodeId").rules("add",{required:true,checkIdentityCardNumber:true});  
                }
                else {
                    $("#readCardId").attr("disabled", "disabled");
                    //$("#divIdPhoto").hide();
                    $("#divIdCardDescription").hide();
                    $("#tbPhotoID").hide();
                    $("#CardCodeId").attr("minlength", 1);
                    $("#CardCodeId").rules("remove");  
                }
            });
        });
        //张建永：自己申请和给他人申请添加的样式
        $(document).ready(function () {
            $(".tb-boxa span").each(function () {
                $(this).click(function () {
                    $(this).addClass('active-btn').siblings("span").removeClass('active-btn'); 
                })
            })
            //点击重置时，身份证照片初始化路径
            $(".res").click(function(){
                document.all("PhotoID").src = '';
                $("#tbPhotoID").hide();
                $("#BtbPhotoID").hide();
            })
            $("#ValidCodeBT").attr("disabled", "disabled");
        });
        function validata()
        {     
            if(!$("#CNameId").val())
            { 
                layer.msg("投保人姓名不能为空");
                $("#CNameId").focus();
                return;
            }
            if(!$("#ENameId").val())
            { 
                layer.msg("投保人拼音不能为空");
                $("#ENameId").focus();
                return;
            }
            if(!$("#CardCodeId").val())
            {
                layer.msg("投保人证件号不能为空");
                $("#CardCodeId").focus();
                return;
            }
            else
            {
                if($("#CardTypeId").val()=="1")//选择身份证
                {
                    if(!isIdCardNo($("#CardCodeId").val()))
                    {
                        layer.msg("投保人身份证号不正确");
                        $("#CardCodeId").focus();
                        return; 
                    }  
                } 
            }
            if(!$("#MobileId").val())
            {
                layer.msg("投保人移动电话不能为空");
                $("#MobileId").focus();
                return;
            }
            if(!$("#ValidCode").val())
            {
                layer.msg("投保人验证码不能为空");
                $("#ValidCode").focus();
                return;
            }  
            if(!$("#EmailId").val())
            {
                layer.msg("投保人邮箱不能为空");
                $("#EmailId").focus();
                return;
            }
            if(!$("#BirthDayId").val())
            {
                layer.msg("投保人出生日期不能为空");
                $("#BirthDayId").focus();
                return;
            }
            if(!$("#CardPeriodId").val())
            {
                layer.msg("证件有效期不能为空");
                $("#CardPeriodId").focus();
                return;
            }
            if(!$("#startDateId").val())
            {
                layer.msg("起保时间不能为空");
                $("#startDateId").focus();
                return;
            } 
            if($("#hidType").val()!=0) //判断给别人投保时
            {
                <%if (!isoneSelf)%>//isoneSelf投保人必须是本人，投保人可以是别人时候
                <%{%> 
                if(!$("#BCNameId").val())
                {
                    layer.msg("被投保人姓名不能为空");
                    $("#BCNameId").focus();
                    return;
                }
                if(!$("#BENameId").val())
                {
                    layer.msg("被投保人拼音不能为空");
                    $("#BENameId").focus();
                    return;
                }
                if(!$("#BCardCodeId").val())
                {
                    layer.msg("被投保人证件号不能为空");
                    $("#BCardCodeId").focus();
                    return;
                }
                else
                {
                    if($("#BCardTypeId").val()=="1")//选择身份证
                    {
                        if(!isIdCardNo($("#BCardCodeId").val()))
                        {
                            layer.msg("被投保人身份证号不正确");
                            $("#BCardCodeId").focus();
                            return; 
                        }  
                    } 
                }
                if(!$("#BMobileId").val())
                {
                    layer.msg("被投保人移动电话不能为空");
                    $("#BMobileId").focus();
                    return;
                }
                //if(!$("#BEmailId").val())
                //{
                //    layer.msg("投保人邮箱不能为空");
                //    bool=false;
                //} 
                if(!$("#BBirthDayId").val())
                {
                    layer.msg("被投保人出生日期不能为空");
                    $("#BBirthDay").focus();
                    return;
                }
                if(!$("#BCardPeriodId").val())
                {
                    layer.msg("被投保人证件有效期不能为空");
                    $("#BCardPeriodId").focus();
                    return;
                } 
                <%}%> 
            }  
            <%if (isHaveJob)%>//有职业job时候
            <%{ %>  
            var ojobnoe = $("#jobone").val();
            var ojobtwo = $("#jobtwo").val();
            var ojobthree = $("#jobthree").val();  
            //if(!ojobnoe)
            //{
            //    layer.msg("请选择投保人职业"); 
            //    return; 
            //}
            //if(!ojobtwo||!ojobthree)
            //{
            //    layer.msg("请选择完整投保人职业"); 
            //    return; 
            //}
            //if($("#hidType").val()==1)
            //{
            //    var oBjobnoe = $("#Bjobnoe").val();
            //    var oBjobtwo = $("#Bjobtwo").val();
            //    var oBjobthree = $("#Bjobthree").val();
            //    if(oBjobnoe=="")
            //    {
            //        layer.msg("请选择被投保人职业"); 
            //        return; 
            //    }
            //    if(!oBjobtwo||!oBjobthree)
            //    {
            //        layer.msg("请选择完整被投保人职业"); 
            //        return; 
            //    }
            //}
            <%} %>
            if($("#sedMSM").val()!="ok")
            {
                layer.msg("请发送验证码"); 
                return;
            } 
            return true;
        }
       
        function SubmitOrderApply() { 
            var Type = $("#hidType").val();
            var CName = $("#CNameId").val();
            var EName = $("#ENameId").val();
            var CardType = $("#CardTypeId").val();
            var CardCode = $("#CardCodeId").val();

            var Sex = $("input[name='Sex']:checked").val();
            var BirthDay = $("#BirthDayId").val();
            var Mobile = $("#MobileId").val();

            var Email = $("#EmailId").val();
            var CardPeriod = $("#CardPeriodId").val();

            var StartDate = $("#startDateId").val();
            var EndDate = $("#endDateId").val();

            var BCName = $("#BCNameId").val();
            var BEName = $("#BENameId").val();


            var BSex = $("input[name='BSex']:checked").val();
            var BCardType = $("#BCardTypeId").val();
            var BCardCode = $("#BCardCodeId").val();
            var BBirthDay = $("#BBirthDayId").val(); 
            var RelationID = $("#RelationID").val();
            var BMobile = $("#BMobileId").val();
            var BCardPeriod = $("#BCardPeriodId").val();
            var Count = $("#CountId").val();
            var MachineID = $("#MachineID").val();
            //var UserID = $("#UserID").val();
            var InsureNum = $("#InsureNum").val();
            //var SinglePrice = $("#SinglePriceId").val();
            var ProvCityId = $("#hidProvCityId").val();
            var RelatedPersonHouse = $("#relatedPersonHouseId").val();

            /////////////////职业////////////////////////
            var jobone = $("#jobone").val();
            var jobtwo = $("#jobtwo").val();
            var jobthree = $("#jobthree").val();
            var Bjobone = $("#Bjobone").val();
            var Bjobtwo = $("#Bjobtwo").val();
            var Bjobthree = $("#Bjobthree").val();
            var resultjob="";
            var resultBjob="";
            if(jobone)
            { 
                resultjob=jobone+"-"+jobtwo+"-"+jobthree;
                resultBjob=Bjobone+"-"+Bjobtwo+"-"+Bjobthree;
            } 
            ////////////////////////////////////////
            var propertyAddress='';
            var oProvince = $("#inpProductPropertyAreaProvince").val(); 
            var oCity = $("#inpProductPropertyAreaCity").val(); 
            var oDistrict = $("#inpProductPropertyAreaDistrict").val(); 
            if(oProvince&&oCity)
            {
                propertyAddress=oProvince+"-"+oCity;
                if (oDistrict)
                {
                    propertyAddress=propertyAddress+"-"+oDistrict; 
                }   
                var xxdz=$("#inpProductPropertyAreaXXDZ").val();//详细地址
                if(xxdz)
                {
                    if(!(getByteLen(xxdz)>=16))
                    {
                        layer.msg("详细地址至少8个汉子");
                        return false;
                    }
                    reg=new RegExp("-","g");
                    xxdz=xxdz.replace(reg, "/");
                    propertyAddress = propertyAddress +"-"+ xxdz; 
                }   
            }
            var travelDestination=$("#travelDestination").val(); 
            //-------------------------出行目的地
          

            
            var InputType= $("#ProductDestinationId").attr("typeInput"); 
            var destinationValue='';
            if(InputType)
            {
                if(InputType=="radioR")
                { 
                    destinationValue=$("input[name='ProductDestination']:checked").val();
                }
                else
                {
                    var oProductDestination= $("input[name='ProductDestination']:checkbox:checked");
                    for(var i=0;i<oProductDestination.length;i++)
                    {
                        destinationValue+=oProductDestination[i].value;
                        if(i!=oProductDestination.length-1)
                        {
                            destinationValue+=oProductDestination[i].value+"、";
                        }
                    }
                    //$("input[name='ProductDestination']:checkbox:checked").each(function(){
                      
                    //    destinationValue=destinationValue+$(this).val()+"、";
                    //});    
                }
            }
            oValidCode=$("#ValidCode").val();
           
            <%if (isluyouxianCXMDD) %>
            <%{ %>
            if(!destinationValue)
            {
                layer.msg("出行目的地必填");
                return false;
            }
            <%}%>
            <%if (oTravelDestinationList != null) %>
            <%{ %>
            if(!travelDestination)
            {
                layer.msg("出行目的必填");
                return false;
            } 
            <%}%>
            <% if (isShowProvince) %>
            <%{ %>
            if(ProvCityId=="")
            {
                layer.msg("投保人居住地必填");
                return false;
            }  
            <%}%> 
          
            if(!validata())
            { 
                return;
            }
           
            //-------------------------出行目的地
        
            //-------------------------设置提交按钮开始 
            $("#sbOrderApply").val("提交申请中...");
            $("#sbOrderApply").css("background-color","#ccc");
            $("#sbOrderApply").attr("disabled", true);
            //-------------------------设置提交按钮结束
            var indexLayer= layer.msg('努力加载中.....', { icon: 6, time: 120000 }); 
            $.ajax({
                url: '/Ajax/MofangOrder/OrderHandler.ashx',
                type: 'post',
                dataType: 'Json',
                timeout: 0,
                async: true,
                data: {
                    Action: "SubmitOrderApply",
                    Type: Type,
                    CName: CName,
                    EName: EName,
                    CardType: CardType,
                    CardCode: CardCode,
                    Sex: Sex,
                    BirthDay: BirthDay,
                    Mobile: Mobile,
                    Email: Email,
                    CardPeriod: CardPeriod,
                    StartDate: StartDate,
                    EndDate: EndDate, 
                    BCName: BCName,
                    BEName: BEName,
                    BSex: BSex,
                    BCardType: BCardType,
                    BCardCode: BCardCode,
                    BBirthDay: BBirthDay,
                    RelationID: RelationID,
                    Count: Count,
                    SinglePrice: '<%=SinglePrice%>',
                    BCardPeriod: BCardPeriod,
                    BMobile: BMobile,
                    Protectitemid: '<%=protectitemid%>',
                    TransNo: '<%=TransNo%>',
                    CaseCode: '<%=CaseCode%>',
                    ApplicationDate: getNowFormatDate(),
                    PriceArgsId: '<%=priceArgsId%>',
                    ProvCityId: ProvCityId,
                    NotifyAnswerId: '<%=healthId%>', 
                    productId: <%= productId %>,
                    RelatedPersonHouse: RelatedPersonHouse,
                    PropertyAddress: propertyAddress,
                    userId:'<%=userId%>',
                    MachineID:'<%=MachineID%>',
                    TripPurposeId:travelDestination,
                    Destination:destinationValue, 
                    TotalPrice:'<%=price%>', 
                    Job:resultjob,
                    BJob:resultBjob,
                    ValidCode:oValidCode 
                },
                success: function (resultData) { 
                    if(resultData.ValidCodeError=="Error")
                    {  
                        layer.close(indexLayer);
                        layer.msg("您输入的验证码不正确");   
                        $("#sbOrderApply").css("background-color","#30abcd");
                        $("#sbOrderApply").attr("disabled", false);
                        $("#sbOrderApply").val("提交申请");
                        return false;
                    }
                    if(resultData.respstat=="I0001")
                    {
                        layer.msg(resultData.respmsg); 
                        $("#sbOrderApply").css("background-color","#30abcd");
                        $("#sbOrderApply").attr("disabled", false);
                        $("#sbOrderApply").val("提交申请");
                        return false;
                    }
                    else
                    {
                        OrderPay(resultData); 
                    } 
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    if (textStatus != 'timeout') {
                        //    alert(xmlHttpRequest.responseText);
                    } else {
                        //  $("#submit_message").html("噗, 您的网络忒慢了! 访问服务器超时了, 请再试一下!");
                    }
                    //$("#order-loading").replaceWith(originSubmit);
                    //$("#submit_message").show();
                    //$(sender).fadeIn('slow');
                }
            });

        }

        function OrderPay(resultData) {
            $.ajax({
                url: '/Ajax/MofangOrder/OrderHandler.ashx',
                type: 'post',
                dataType: 'json',
                timeout: 0,
                async: true,
                data: {
                    Action: "OrderPay",
                    transNo: resultData.transNo,// 
                    caseCode: '<%=CaseCode%>',
                    insureNum: resultData.insureNum,//
                    price: resultData.price
                },
                success: function (result) {
                    if (result.respstat == "0000") { 
                        location.href =result.payUrl;
                    }
                    else {
                        layer.msg(result.respmsg);  
                        $("#sbOrderApply").css("background-color","#30abcd");
                        $("#sbOrderApply").attr("disabled", false);
                        $("#sbOrderApply").val("提交申请");
                    }

                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    if (textStatus != 'timeout') {
                        //   alert(xmlHttpRequest.responseText);
                    } else {
                    }
                }
            });
        } 
        function getNowFormatDate() {
            var date = new Date();
            var seperator1 = "-";
            var seperator2 = ":";
            var month = date.getMonth() + 1;
            var strDate = date.getDate();
            if (month >= 1 && month <= 9) {
                month = "0" + month;
            }
            if (strDate >= 0 && strDate <= 9) {
                strDate = "0" + strDate;
            }
            var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
                    + " " + date.getHours() + seperator2 + date.getMinutes()
                    + seperator2 + date.getSeconds();
            return currentdate;
        }

    </script>

    <script>

        $("#bttaren").click(function () { 
            connect(); 
            $(".btb-box").show();
            $("#hidType").val("1");
            <%if (typeMen)%>
            <%{%> 
            $("input[name='Sex'][value='1']").prop("checked","checked");
            $("input[name='Sex']").attr("disabled",false); 
            $("input[name='BSex'][value='1']").prop("checked","checked");
            $("input[name='BSex']").attr("disabled",true); 
            <%}%>
            <%if (typeWomen)%>
            <%{%>
            $("input[name='Sex'][value='0']").prop("checked","checked");
            $("input[name='Sex']").attr("disabled",false); 
            $("input[name='BSex'][value='0']").prop("checked","checked");
            $("input[name='BSex']").attr("disabled",true); 
                     <%}%>

        });
        $("#btziji").click(function () {
            //connect(); 
            $("#hidType").val("0");
            $(".btb-box").hide(); 
            <%if (typeMen)%>
            <%{%> 
            $("input[name='Sex'][value='1']").prop("checked","checked");
            $("input[name='Sex']").attr("disabled",true); 
            $("input[name='BSex'][value='1']").prop("checked","checked"); 
            <%}%>
            <%if (typeWomen)%>
            <%{%>
            $("input[name='Sex'][value='0']").prop("checked","checked");
            $("input[name='Sex']").attr("disabled",true); 
            $("input[name='BSex'][value='0']").prop("checked","checked"); 
                     <%}%>

        });

        var countdown=60; 
        function settime(obj) { 
            $("#MobileId").attr("disabled","disabled");
            var moblie= $("#MobileId").val();
            if(!moblie)
            {
                layer.msg("请填写投保人手机号");
                return false;
            }else{
                var isIDCard2 =/^1[3|4|5|7|8][0-9]{9}$/; //验证规则
                var lengthvalue = document.getElementById('MobileId').value.length;
                if (lengthvalue == 11) {
                    if (isIDCard2.test(document.getElementById('MobileId').value) === false) {
                        layer.msg('手机号输入不合法,请重新填写!',2,3,function(){
                            $("#MobileId").val("");
                        })
                        return false;
                    }
                }else{
                    layer.msg('手机号位数不正确！', 1,3); 
                    return false;
                }
            }
            if (countdown == 0) { 
                $("#MobileId").removeAttr("disabled");
                obj.removeAttribute("disabled"); 
                obj.value="获取验证码"; 
                countdown = 60; 
                return;
            } else { 
                obj.setAttribute("disabled", true); 
                obj.value="重新发送(" + countdown + ")"; 
                countdown--; 
            } 
            setTimeout(function() { 
                settime(obj) }
            ,1000) 
        }
        $(function () {  
            <%if (isoneSelf)%>
            <%{%> 
            $("#RelationID").find("option[value='1']").attr("selected",true);

            $("#bttaren").css("background","#ccc");
            $("#bttaren").css("cursor","default");
            $("#bttaren").unbind("click"); 
            <%}%>
            var onlyOthers= $("#hidOnlyOthers").val();
         
            if(onlyOthers=="True")//只给他人投保时
            { 
                $("#btziji").css("background","#ccc");
                $("#btziji").unbind("click"); 
                $("#bttaren").click(); 
            }
            $("#btziji").click();
            //jquery.validate
            $("#jsForm").validate({
               
            })

            $("#ValidCodeBT").click(function(){   
                var moblie= $("#MobileId").val();
                if(!moblie)
                { 
                    return false;
                }
                $.ajax({
                    url: '/Ajax/MofangOrder/ValidCode.ashx',
                    type: 'post',
                    dataType: 'json',
                    timeout: 0,
                    async: true,
                    data: {
                        Action: "ValidCodeAction",
                        moblie: moblie
                    },
                    success: function (result) {
                        if (result.isSend == "ok") {    
                            $("#sedMSM").val("ok");
                        }
                        else {
                            $("#sedMSM").val("");
                        }

                    },
                    error: function (xmlHttpRequest, textStatus, errorThrown) {
                        if (textStatus != 'timeout') {
                            //   alert(xmlHttpRequest.responseText);
                        } else {
                        }
                    }
                });
            });
            BackClick();

        })
        //下面是一些常用的验证规则扩展
        //配置错误提示的节点，默认为label，这里配置成 span （errorElement:'span'）
        $.validator.setDefaults({
            errorElement: 'span'
        });

        //配置通用的默认提示语
        $.extend($.validator.messages, {
            required: '必选(填)',
            equalTo: "请再次输入相同的值"
        });

        ////手机验证规则
        //jQuery.validator.addMethod("mobile", function (value, element) {
        //    var mobile = /^1[3|4|5|6|7|8]\d{9}$/;
        //    return this.optional(element) || (mobile.test(value));
        //}, "手机格式不对");

        //邮箱或手机验证规则
        jQuery.validator.addMethod("mm", function (value, element) {
            var mm = /^[a-z0-9._%-]+@([a-z0-9-]+\.)+[a-z]{2,4}$|^1[3|4|5|7|8]\d{9}$/;
            return this.optional(element) || (mm.test(value));
        }, "格式不对");


        //身份证
        jQuery.validator.addMethod("idCard", function (value, element) {
            var isIDCard1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;//(15位)
            var isIDCard2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$/;//(18位)

            return this.optional(element) || (isIDCard1.test(value)) || (isIDCard2.test(value));
        }, "格式不对"); 


        //////////////////处理拼音开始/////////////////////////////// 
        function getPinyin()//投保人
        { 
            var value = $('#CNameId').val(); 
            result = pinyinUtil.getPinyin(value, '', false, true); 
            $('#ENameId').val(result);
        }
        document.getElementById('CNameId').addEventListener('input', getPinyin); 
        getPinyin(); 
        function getBPinyin()//被保人
        { 
            var value = $('#BCNameId').val(); 
            result = pinyinUtil.getPinyin(value, '', false, true); 
            $('#BENameId').val(result);
        }
        document.getElementById('BCNameId').addEventListener('input', getBPinyin); 
        getBPinyin(); 
        //////////////////处理拼音结束///////////////////////////////
        function getByteLen(val) {//获取输入字节个数
            var len = 0;
            for (var i = 0; i < val.length; i++) {
                var a = val.charAt(i);
                if (a.match(/[^\x00-\xff]/ig) != null) 
                {
                    len += 2;
                }
                else
                {
                    len += 1;
                }
            }
            return len;
        }
        function isIdCardNo(num) {    
            num = num.toUpperCase();           //身份证号码为15位或者18位，15位时全为数字，18位前17位为数字，最后一位是校验位，可能为数字或字符X。         
            if (!(/(^\d{15}$)|(^\d{17}([0-9]|X)$)/.test(num))) {      
                //alert('输入的身份证号长度不对，或者号码不符合规定！\n15位号码应全为数字，18位号码末位可以为数字或X。');               
                alert('身份证号长度不正确或不符合规定！');               
                return false;          
            }
            return true;
        }
        

        function VMobileId(){
            var b=true;
            var moblie= $("#MobileId").val();
            if(!moblie)
            {    
                $("#ValidCodeBT").attr("disabled","disabled");
                $("#spanMobileId").show();
                b=false;
            }else{
                var isIDCard2 =/^1[3|4|5|7|8][0-9]{9}$/; //验证规则
                var lengthvalue = document.getElementById('MobileId').value.length;
                if (lengthvalue == 11) {
                    if (isIDCard2.test(document.getElementById('MobileId').value) === false) {
                        $("#ValidCodeBT").attr("disabled","disabled");
                        $("#spanMobileId").show();
                        b=false;
                    }
                }else{
                    $("#ValidCodeBT").attr("disabled","disabled");
                    $("#spanMobileId").show();
                    b=false;
                }
            }
            if (b) {
                $("#ValidCodeBT").removeAttr("disabled");
                $("#spanMobileId").hide();
            }
        };
        function BackClick()
        {
            $("#backId").click(function(){ 
                $(':input').not(':button, :submit, :reset, :hidden').val('').removeAttr('checked').removeAttr('selected');
                history.go(-1);
            });  
        } 
    </script>

</body>
</html>

