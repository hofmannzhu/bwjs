<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Decrypt.aspx.cs" Inherits="BWJS.WebApp.Test.Decrypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; margin-top:100px;">

        密文： <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        解密：<asp:Label ID="Label1" runat="server" Text=""></asp:Label>  
         <br />
         <br />
          <asp:Button ID="Button1" runat="server" Text="解密"   OnClick="Button1_Click" /> 
           <br />
      
        <hr />
        明文： <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        加密：<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <br />
       
       <asp:Button ID="Button2" runat="server" Text="加密" OnClick="Button2_Click" />
        
    </div>
    </form>
</body>
</html>
