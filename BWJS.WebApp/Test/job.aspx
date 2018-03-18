<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="job.aspx.cs" Inherits="BWJS.WebApp.Test.job" %>

<!DOCTYPE html>
<script src="../Scripts/jquery-3.2.1.min.js"></script>
<script src="../Scripts/jquery.min.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<script src="/Scripts/Mofang/mofanghelperjob.js"></script>
<body>
    <form id="form1" runat="server">
        <div>
            第一级:
            <select id="inpOne" name="inpOne" style="width: 220px;" ></select>

           第二级:<select id="inpTwo" name="inpTwo"  style="width: 220px;"></select>

               第三级:
                <select id="inpThree" name="inpThree" style="width: 220px;"></select>
        </div>
        <div
            >
          

        </div>
    </form>
</body>
</html>



<script type="text/javascript">
 
    $(document).ready(function () {
        helperjob.transNo = '<%=TransNo%>';
        helperjob.caseCode = '<%=CaseCode%>';
        helperjob.initOne($("#inpOne"), $("#inpTwo"), $("#inpThree"));
    });
     
</script>



