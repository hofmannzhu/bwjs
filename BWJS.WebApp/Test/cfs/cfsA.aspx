<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CfsA.aspx.cs" Inherits="BWJS.WebApp.Test.CfsA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script> 
        function chrome()
        {
            var WSH = new ActiveXObject("WScript.Shell");
            WSH.Run("chrome.exe http://localhost/Test/cfs/cfsb.aspx");
 
        }

        function MicrosoftEdge()
        {
            var WSH = new ActiveXObject("WScript.Shell");
            WSH.Run("MicrosoftEdge.exe http://www.baidu.com");

        }
        
</script>
</head>
<body>
    
    <div>

     <input  type="button"  value="chrome" onclick="chrome()" /> <br/><br/>

    </div>
    
</body>
</html>
