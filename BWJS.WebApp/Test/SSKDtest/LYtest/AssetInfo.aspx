<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetInfo.aspx.cs" Inherits="BWJS.WebApp.Test.SSKDtest.LYtest.AssetInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1 " />
    <link href="/Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/css/Mofang/main.css" rel="stylesheet" />
    <link href="../../../Scripts/skin/layer.css" rel="stylesheet" />
    <link href="../../../Scripts/skin/layer.ext.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../../../Scripts/jquery.validate.js"></script>
    <script src="../../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="../../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/bootbox.js" type="text/javascript"></script>
    <%--    <script src="../../../Scripts/layer.js"></script>--%>
    <script src="../../../Scripts/layer.min.js"></script>
    <script src="../../../Scripts/Product/heartbeatcheck.js"></script>
    <title></title>
</head>
<body>
    
    <script type="text/javascript">
        var modelIdentityCardLibrary = {};
        var modelNetLoanApply = {};
        $(document).ready(function () {
            $('#SeleCity1').html('<%=strCityAreaTree%>');
            $("#ValidCodeBT").attr("disabled", "disabled");
            $("#ValidCodeBT").click(function(){   
                var moblie= $("#MobileId").val();
                var c=true;
                if(!moblie)
                {    
                    layer.msg('手机号不能为空！', 1,3); 
                    c=false;
                    return  c;
                }else{
                    var isIDCard2 =/^1[3|4|5|6|7|8|9][0-9]{9}$/; //验证规则
                    var lengthvalue = document.getElementById('MobileId').value.length;
                    if (lengthvalue == 11) {
                        if (isIDCard2.test(document.getElementById('MobileId').value) === false) {
                            layer.msg('手机号输入不合法,请重新填写!',2,3,function(){
                                $("#MobileId").val("");
                            })
                            c=false;
                            return  c;
                        }
                    }else{
                        layer.msg('手机号位数不正确！', 1,3); 
                        c=false;
                        return  c;
                    }
                }
                if (c) {
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
                                $("#NumberId").val(result.number);
                            }
                            else {
                                $("#sedMSM").val("");
                                $("#NumberId").val("");
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
            });
            $("#AreaCodeID").change(function(){
                var label=document.getElementById("ShowCode");  
                label.innerText= $("#AreaCodeID").val()+"+";
                var label1=document.getElementById("ShowCode1");  
                label1.innerText= $("#AreaCodeID").val()+"+";
                var label2=document.getElementById("ShowCode2");  
                label2.innerText= $("#AreaCodeID").val()+"+";
            });
            $("#AreaCodeID1").change(function(){
                var label1=document.getElementById("ShowCode1");  
                label1.innerText= $("#AreaCodeID").val()+"+";
            });
            $("#readCardId").click(function () {
                return false;
            });

            $("#next-assetinfo").click(function () {
                return nextassetinfoClick();
            });

            $("#next-addinfo").click(function () {
                return nextaddinfoClick();
            });

            function nextassetinfoClick() {
                $("#ConsultForm").hide();
                $(".show1").show();
            }
            
            function  nextaddinfoClick() {
                //入我方库
                InsertData();
                //下级页面
                //$("#ConsultForm").hide();
                //$(".show1").show();
            }
           

        });
        //存入我方库
        function InsertData() {
            debugger;
            var ConsultId =<%=ConsultId%>;
            var FullName ="";
            var IDNo ="";
            try {
    
           
            var ProfessionInfo = {};

            ProfessionInfo.ConsultId= ConsultId;
            ProfessionInfo.FullName =FullName;
            ProfessionInfo.Age= 0;
            ProfessionInfo.MonthlyIncome	= 	$("#MonthlyIncomeId").val();
            ProfessionInfo.Company	= 	$("#CompanyId").val();
            ProfessionInfo.UnitNature= 	$("#UnitNature	Id").val();
            ProfessionInfo.WorkingHour	= 	$("#WorkingHourId").val();
            ProfessionInfo.Payroll	= 	$("#PayrollId	").val();
            ProfessionInfo.JobPosition = $("#JobPositionId").val();
            ProfessionInfo.SocialSecurit	=	$("#SocialSecuritId").val();
            ProfessionInfo.Fund	 = $("#FundId").val();
            ProfessionInfo.Degree	 = 	$("#DegreeId").val();
            ProfessionInfo.GraduationYear	 =0;
            var IdentityInfo = {};
      
            IdentityInfo.ConsultId	 = 	ConsultId;
            IdentityInfo.FullName	 = 	FullName;
            IdentityInfo.IDNo	 = 	IDNo;	
            IdentityInfo.MonthlyIncome	 = 	$("#MonthlyIncomeid").val();	
            IdentityInfo.CreditHistory	 = 	$("#CreditSituationId").val();	
            IdentityInfo.HousingStatus	 = 	$("#HousesId").val();	
            IdentityInfo.DrivingLicense	 = 	$("#CarsId").val();	
            IdentityInfo.Face	 = 0;	
            IdentityInfo.IdentityCardScanner	 = 	0;
            IdentityInfo.DebitCard	=0;	
            IdentityInfo.CreditCard	 = 	0;	
            IdentityInfo.ParticleLoan	 = 	0;	
            IdentityInfo.BusinessPolicy	 = 	$("#BusinessPolicyId").val();	
            IdentityInfo.CreditCardAgeLimit	 = 	$("#CreditCardServiceLifenId").val();	
            IdentityInfo.OtherLoan	 = 	$("#OtherLoanId").val();	
            IdentityInfo.SesameSeed	 = 	$("#SesameSeedId").val();	
            IdentityInfo.TaobaoAccount	 = 	$("#TaobaoAccountId").val();	
            IdentityInfo.Company	 = 	0;
            IdentityInfo.UnitNature	 = 	0;
            IdentityInfo.WorkingHour	 = 	$("#WorkingHourId").val();	
            IdentityInfo.Payroll	 = 	$("#PayrollId").val();	
            IdentityInfo.JobPosition	 = 	$("#JobPositionId").val();	
            IdentityInfo.SocialSecurit	 = 	"";
            IdentityInfo.Fund	 = 	$("#FundId").val();	
            IdentityInfo.Degree	 = 	$("#DegreeId").val();	
            IdentityInfo.GraduationYear	 = 	0;


            var AssetInfo = {};
            AssetInfo.ConsultId	=	ConsultId;
            AssetInfo.Cars	=	$("#CarsId").val(); 	
            AssetInfo.Houses	=	$("#HousesId").val(); 	
            AssetInfo.OtherLoans	=	$("#OtherLoansId").val(); 	
            AssetInfo.SesameSeed	=	$("#SesameSeedId").val(); 	
            AssetInfo.TaobaoAccount	=	$("#TaobaoAccountId").val(); 	
            AssetInfo.ParticleLoan	=0; 	
            AssetInfo.BusinessPolicy	=	$("#BusinessPolicyId").val(); 	
            AssetInfo.CreditCard	=	$("#CreditCardId").val(); 	
            AssetInfo.CreditSituation	=	$("#CreditSituationId").val(); 	
            AssetInfo.CreditCardServiceLife	=	$("#CreditCardServiceLifenId").val(); 	



            var paramter = {};
            paramter.op = "bwjs";
            paramter.om = "newnetloan";
            paramter.action = "UpdataConsult";
            paramter.ConsultId = ConsultId;
            paramter.ProvinceId =$("#SeleCity1").val();
            paramter.CityId=$("#SeleCity2").val();
            paramter.DistrictId=$("#SeleCity3").val();
            paramter.Area="";
            paramter. Address=$("#AddressId").val();

            paramter.ProfessionInfo = JSON.stringify(ProfessionInfo);
            paramter.IdentityInfo = JSON.stringify(IdentityInfo);
            paramter.AssetInfo = JSON.stringify(AssetInfo);
            var json = getJson(paramter, false);
            if (json.result) {
                ConsultId = json.data;
            }
            return ConsultId;
            } catch (e) {
                aler(e.message);
            }
        }

        function GetSeleCity2() {
            setSelectOption('SeleCity2', $('#SeleCity1').val(), '-请选择-');
        }

        function GetSeleCity3() {
            setSelectOption('SeleCity3', $('#SeleCity2').val(), '-请选择-');
        }

        function setSelectOption(selectObj, optionList, firstOption) {
            if (typeof selectObj != 'object') {
                selectObj = document.getElementById(selectObj);
            }
            // 清空选项
            removeOptions(selectObj);
            // 选项计数
            var start = 0;
            // 如果需要添加第一个选项
            if (firstOption) {
                selectObj.options[0] = new Option(firstOption, '');
                GetCityArea(selectObj,optionList);
            }
        }
        function removeOptions(selectObj) {
            if (typeof selectObj != 'object') {
                selectObj = document.getElementById(selectObj);
            }
            // 原有选项计数
            var len = selectObj.options.length;
            for (var i = 0; i < len; i++) {
                // 移除当前选项
                selectObj.options[0] = null;
            }
        }
        function GetCityArea(selectObj,ParentID) {
            $.ajax({
                type: "GET",
                async: false,
                dataType: "text",
                url: "../../../Ajax/BWJS/HCityArea.ashx?r=" + Math.random(),
                data: { Action: "GetCityArea", ParentID: ParentID },
                success: function (data) {
                    $(selectObj).html(data);
                }
            });
        } 
    </script>
    <!--添加自我描述信息-->
    <div class="show0">
        <form method="post" class="form-horizontal mar-top1" role="form" id="ConsultForm">
            <div class="col-sm-12">

                <div class="form-group">
                    <div class="col-sm-2" style="margin-top: 10px; margin-left: -33px">
                        <div class="col-md-4 text-right">所在城市：</div>
                    </div>
                    <div class="col-sm-10">
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-2" style="margin-top: 4px;">
                                    <div class="col-md-4 text-right">省：</div>
                                </div>
                                <div class="col-sm-9">
                                    <select name="SeleCity1" id="SeleCity1" class="form-control" onchange="if(this.value != '') GetSeleCity2(this.value);" style="width: 90%"></select>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-2" style="margin-top: 4px;">
                                    <div class="col-md-4 text-right">市：</div>
                                </div>
                                <div class="col-sm-9">
                                    <select id="SeleCity2" name="SeleCity2" class="form-control" onchange="if(this.value != '') GetSeleCity3(this.value);" style="width: 90%"></select>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="row">
                                <div class="col-sm-4" style="margin-top: 4px;">
                                    <div class="col-md-4 text-right">县(区)：</div>
                                </div>
                                <div class="col-sm-8">
                                    <select id="SeleCity3" name="SeleCity3" class="form-control" style="width: 93%"></select>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 4px; margin-left: -23px">
                            <div class="col-md-4 text-right">详细地址：</div>
                        </div>
                        <div class="col-sm-10">
                            <input type="text" value="" id="AddressId" name="Address" class="form-control" placeholder="请填写详细地址" style="width: 98%" />
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="MonthlyIncome" class="col-sm-3 control-label">您的月收入：</label>
                    <div class="col-sm-8">
                        <select name="MonthlyIncomeId" id="MonthlyIncomeId" style="border-radius: 8px" class="form-control">
                            <%=strMonthlyIncome %>
                        </select><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="JobPosition" class="col-sm-3 control-label">职业身份：</label>
                    <div class="col-sm-8">
                        <select name="JobPosition" id="JobPositionId" style="border-radius: 8px" class="form-control">
                            <%=strJobPosition %>
                        </select><em>*</em>
                    </div>
                </div>



                <div class="form-group">
                    <label for="WorkingHour" class="col-sm-3 control-label">当前单位工作时间：</label>
                    <div class="col-sm-8">
                        <select name="WorkingHour" id="WorkingHourId" style="border-radius: 8px" class="form-control">
                            <%=strWorkingHour %>
                        </select><em>*</em>
                    </div>
                </div>


                <div class="form-group">
                    <label for="Fund" class="col-sm-3 control-label">是否有本地公积金：</label>
                    <div class="col-sm-8">
                        <select name="Fund" id="FundId" style="border-radius: 8px" class="form-control">
                            <%=strFund %>
                        </select><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="Payroll" class="col-sm-3 control-label">工资发放形式：</label>
                    <div class="col-sm-8">
                        <select name="Payroll" id="PayrollId" style="border-radius: 8px" class="form-control">
                            <%=strPayroll %>
                        </select><em>*</em>
                    </div>
                </div>


                <div class="form-group">
                    <label for="Degree" class="col-sm-3 control-label">您的学历：</label>
                    <div class="col-sm-8">
                        <select name="Degree" id="DegreeId" style="border-radius: 8px" class="form-control">
                            <%=strDegree %>
                        </select><em>*</em>
                    </div>
                </div>


                <div class="form-group">
                    <label for="Cars" class="col-sm-3 control-label">名下是否有车：</label>
                    <div class="col-sm-8">
                        <select name="Cars" id="CarsId" style="border-radius: 8px" class="form-control">
                            <%=strCars %>
                        </select><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="Houses" class="col-sm-3 control-label">名下是否有房：</label>
                    <div class="col-sm-8">
                        <select name="Houses" id="HousesId" style="border-radius: 8px" class="form-control">
                            <%=strHouses %>
                        </select><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="OtherLoans" class="col-sm-3 control-label">是否做过其他贷款：</label>
                    <div class="col-sm-8">
                        <select name="OtherLoans" id="OtherLoansId" style="border-radius: 8px" class="form-control">
                            <%=strOtherLoans %>
                        </select><em>*</em>
                    </div>
                </div>
            </div>
            <div class="text-center">
                <input id="next-assetinfo" type="button" value="下一步" class="sub2" />
            </div>
        </form>
    </div>
    <!--添加自我描述end-->


    <!--添加附加信息-->
    <div class="show1">
        <form method="post" class="form-horizontal mar-top1" role="form" id="AddInfoForm">
            <div class="col-sm-12">

                <div class="form-group">
                    <label for="inpIdentityCardNumber" class="col-sm-3 control-label">是否有支付宝芝麻分：</label>
                    <div class="col-sm-8">
                        <select name="SesameSeed" id="SesameSeedId" style="border-radius: 8px" class="form-control">
                            <%=strSesameSeed %>
                        </select><em>*</em>
                    </div>
                </div>


                <div class="form-group">
                    <label for="TaobaoAccount" class="col-sm-3 control-label">是否有淘宝账号：</label>
                    <div class="col-sm-8">
                        <select name="TaobaoAccount" id="TaobaoAccountId" style="border-radius: 8px" class="form-control">
                            <%=strTaobaoAccount %>
                        </select><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="BusinessPolicy" class="col-sm-3 control-label">是否有商业保单：</label>
                    <div class="col-sm-8">
                        <select name="BusinessPolicy" id="BusinessPolicyId" style="border-radius: 8px" class="form-control">
                            <%=strBusinessPolicy %>
                        </select><em>*</em>
                    </div>
                </div>



                <div class="form-group">
                    <label for="CreditCard" class="col-sm-3 control-label">是否有信用卡：</label>
                    <div class="col-sm-8">
                        <select name="CreditCard" id="CreditCardId" style="border-radius: 8px" class="form-control">
                            <%=strCreditCard %>
                        </select><em>*</em>
                    </div>
                </div>


                <div class="form-group">
                    <label for="CreditSituation" class="col-sm-3 control-label">您的信用情况：</label>
                    <div class="col-sm-8">
                        <select name="CreditSituation" id="CreditSituationId" style="border-radius: 8px" class="form-control">
                            <%=strCreditSituation %>
                        </select><em>*</em>
                    </div>
                </div>

                <div class="form-group">
                    <label for="CreditCardServiceLifen" class="col-sm-3 control-label">信用卡使用年限：</label>
                    <div class="col-sm-8">
                        <select name="CreditCardServiceLifen" id="CreditCardServiceLifenId" style="border-radius: 8px" class="form-control">
                            <%=strCreditCardServiceLifen %>
                        </select><em>*</em>
                    </div>
                </div>
            </div>
            <div class="text-center">
                <input id="next-addinfo" type="button" value="下一步" class="sub2" />
            </div>
        </form>
    </div>
    <!--添加附加信息-->
</body>
</html>
