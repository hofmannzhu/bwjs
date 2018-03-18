<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CfsB.aspx.cs" Inherits="BWJS.WebApp.Test.cfs.CfsB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>

        function ClosePage()
        {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1"  >
    <div>
      <input type="button" onclick="ClosePage()" value="确定关闭" />
    </div>
    </form>
</body>
</html>
