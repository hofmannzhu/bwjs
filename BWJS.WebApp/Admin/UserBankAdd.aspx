<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserBankAdd.aspx.cs" Inherits="BWJS.WebApp.Admin.UserBankAdd" %>

<div class="modal-dialog" role="document">
    <form class="form-horizontal" role="form" id="userBankForm">
        <ul>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpBankCodeForInput">银行代码：</label>
                <div class="col-sm-6">
                    <input id="inpBankCodeForInput" name="inpBankCodeForInput" class="form-control" type="text" placeholder="请输入银行代码" />
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpOpeningBankForInput">开户行：</label>
                <div class="col-sm-6">
                    <input id="inpOpeningBankForInput" name="inpOpeningBankForInput" class="form-control" type="text" placeholder="请输入开户行" required /><em>*</em>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpCardHolderForInput">持卡人：</label>
                <div class="col-sm-6">
                    <input id="inpCardHolderForInput" name="inpCardHolderForInput" class="form-control" type="text" placeholder="请输入持卡人" /><em>*</em>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpCardNumberForInput">银行卡号：</label>
                <div class="col-sm-6">
                    <input id="inpCardNumberForInput" name="inpCardNumberForInput" class="form-control" type="text" placeholder="请输入银行卡号" /><em>*</em>
                </div>
            </li>
            <li class="form-group">
                <label class="col-sm-3 control-label" for="inpBankAddressForInput">银行地址：</label>
                <div class="col-sm-6">
                    <input id="inpBankAddressForInput" name="inpBankAddressForInput" class="form-control" type="text" placeholder="请输入银行地址" /><em>*</em>
                </div>
            </li>
            <li class="form-group">
                <div class="col-sm-12 text-center">
                    <button id="btnSubmit" type="button" class="btn btn-success btn-group-lg">提 交</button>
                    <button id="btnReset" type="reset" class="btn btn-danger btn-group-lg">重 置</button>
                    <button id="btnClose" type="button" class="btn btn-danger btn-group-lg" data-dismiss="modal">关 闭</button>
                </div>
            </li>
        </ul>
        <script type="text/javascript">
            jQuery.validator.addMethod("checkCardHolder", function (value, element) {
                var realname = /^([\u4e00-\u9fa5]{2,8}|[a-zA-Z]{2,16})$/g;
                return this.optional(element) || (realname.test(value));
            }, "只能输入2-8个汉字或2-16个英文字符");

            jQuery.validator.addMethod("checkCardNumber", function (value, element) {
                return this.optional(element) || (luhmCheck(value));
            }, "卡号输入有误，请检查输入");

            $.validator.setDefaults({
                errorElement: 'span',
                rules: {
                    inpBankCodeForInput: {
                        maxlength: 16
                    },
                    inpOpeningBankForInput: {
                        required: true,
                        maxlength: 64
                    },
                    inpCardHolderForInput: {
                        required: true,
                        checkCardHolder: true,
                        maxlength: 16
                    },
                    inpCardNumberForInput: {
                        required: true,
                        checkCardNumber: true,
                        maxlength: 19
                    },
                    inpBankAddressForInput: {
                        required: true,
                        maxlength: 256
                    }
                },
            });

            //Description:  银行卡号Luhm校验
            //Luhm校验规则：16位银行卡号（19位通用）:
            // 1.将未带校验位的 15（或18）位卡号从右依次编号 1 到 15（18），位于奇数位号上的数字乘以 2。
            // 2.将奇位乘积的个十位全部相加，再加上所有偶数位上的数字。
            // 3.将加法和加上校验位能被 10 整除。
            //方法步骤很清晰，易理解，需要在页面引用Jquery.js
            //bankno为银行卡号 banknoInfo为显示提示信息的DIV或其他控件
            function luhmCheck(bankno) {
                var lastNum = bankno.substr(bankno.length - 1, 1);//取出最后一位（与luhm进行比较）

                var first15Num = bankno.substr(0, bankno.length - 1);//前15或18位
                var newArr = new Array();
                for (var i = first15Num.length - 1; i > -1; i--) {    //前15或18位倒序存进数组
                    newArr.push(first15Num.substr(i, 1));
                }
                var arrJiShu = new Array();  //奇数位*2的积 <9
                var arrJiShu2 = new Array(); //奇数位*2的积 >9

                var arrOuShu = new Array();  //偶数位数组
                for (var j = 0; j < newArr.length; j++) {
                    if ((j + 1) % 2 == 1) {//奇数位
                        if (parseInt(newArr[j]) * 2 < 9)
                            arrJiShu.push(parseInt(newArr[j]) * 2);
                        else
                            arrJiShu2.push(parseInt(newArr[j]) * 2);
                    }
                    else //偶数位
                        arrOuShu.push(newArr[j]);
                }

                var jishu_child1 = new Array();//奇数位*2 >9 的分割之后的数组个位数
                var jishu_child2 = new Array();//奇数位*2 >9 的分割之后的数组十位数
                for (var h = 0; h < arrJiShu2.length; h++) {
                    jishu_child1.push(parseInt(arrJiShu2[h]) % 10);
                    jishu_child2.push(parseInt(arrJiShu2[h]) / 10);
                }

                var sumJiShu = 0; //奇数位*2 < 9 的数组之和
                var sumOuShu = 0; //偶数位数组之和
                var sumJiShuChild1 = 0; //奇数位*2 >9 的分割之后的数组个位数之和
                var sumJiShuChild2 = 0; //奇数位*2 >9 的分割之后的数组十位数之和
                var sumTotal = 0;
                for (var m = 0; m < arrJiShu.length; m++) {
                    sumJiShu = sumJiShu + parseInt(arrJiShu[m]);
                }

                for (var n = 0; n < arrOuShu.length; n++) {
                    sumOuShu = sumOuShu + parseInt(arrOuShu[n]);
                }

                for (var p = 0; p < jishu_child1.length; p++) {
                    sumJiShuChild1 = sumJiShuChild1 + parseInt(jishu_child1[p]);
                    sumJiShuChild2 = sumJiShuChild2 + parseInt(jishu_child2[p]);
                }
                //计算总和
                sumTotal = parseInt(sumJiShu) + parseInt(sumOuShu) + parseInt(sumJiShuChild1) + parseInt(sumJiShuChild2);

                //计算Luhm值
                var k = parseInt(sumTotal) % 10 == 0 ? 10 : parseInt(sumTotal) % 10;
                var luhm = 10 - k;

                if (lastNum == luhm && lastNum.length != 0) {
                    //$("#banknoInfo").html("Luhm验证通过");
                    return true;
                }
                else {
                    //$("#banknoInfo").html("银行卡号必须符合Luhm校验");
                    return false;
                }
            }

            $(document).ready(function () {
                $("#btnSubmit").click(function () {
                    if ($("#userBankForm").valid()) {
                        BankSubmit();
                    }
                });
                $("#btnReset").click(function () {
                    $("#userBankForm").resetForm;
                });
            });

            function BankSubmit() {
                var modelUserBank = getBankModel();
                var paramter = {};
                paramter.op = "bwjs";
                paramter.om = "gl";
                paramter.action = "userbankadd";
                paramter.userBankId = $("#hiddId").val();
                paramter.userId = $("#hiddUserId").val();
                paramter.modelUserBank = JSON.stringify(modelUserBank);
                paramter.timeStamp = new Date().getTime();
                $.ajax({
                    type: "POST",
                    url: "/Ajax/helper.ashx",
                    data: paramter,
                    dataType: "json",
                    async: false,
                    success: function (json) {
                        if (json.result) {
                            $("#userBankModal").modal("hide");
                        }
                        else {
                            myAlert(json.msg);
                        }
                    },
                    error: function () { myAlert("服务器没有返回数据，可能服务器忙，请重试"); }
                });
            }

            function getBankModel() {
                var model = {};
                model.BankCode = $.trim($("#inpBankCodeForInput").val());
                model.OpeningBank = $.trim($("#inpOpeningBankForInput").val());
                model.CardHolder = $.trim($("#inpCardHolderForInput").val());
                model.CardNumber = $.trim($("#inpCardNumberForInput").val());
                model.BankAddress = $.trim($("#inpBankAddressForInput").val());
                return model;
            }
        </script>
    </form>
</div>
