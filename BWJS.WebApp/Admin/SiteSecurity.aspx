<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/m1.Master" AutoEventWireup="true" CodeBehind="SiteSecurity.aspx.cs" Inherits="BWJS.WebApp.Admin.SiteSecurity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headLink" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headScript" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="topContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="col-lg-8">
    </div>
    <div class="col-lg-4 text-left">
    </div>
    <br />
    <div class="container">
        <div class="row-fluid clearfix">
            <div class="form-group">
                <label for="txtSecretKey" contenteditable="true">密钥</label>
                <div class="controls">
                    <asp:TextBox ID="txtSecretKey" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="txtPlaintext" contenteditable="true">加密</label>
                <div class="controls">
                    <asp:TextBox ID="txtPlaintext" runat="server" CssClass="form-control" placeholder="请输入明文"></asp:TextBox>
                    <asp:Button ID="btnEncrypt" runat="server" Text="加密" CssClass="btn btn-success btn-group-lg" OnClick="btnEncrypt_Click" OnClientClick="return checkPlaintext();" />
                    <br />
                    <asp:Literal ID="litCiphertext" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="txtCiphertext" contenteditable="true">解密</label>
                <div class="controls">
                    <asp:TextBox ID="txtCiphertext" runat="server" CssClass="form-control" placeholder="请输入密文"></asp:TextBox>
                    <asp:Button ID="btnDecrypt" runat="server" Text="解密" CssClass="btn btn-success btn-group-lg" OnClick="btnDecrypt_Click" OnClientClick="return checkCiphertext();" />
                    <br />
                    <asp:Literal ID="litPlaintext" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="footerContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
        });
        function checkPlaintext() {
            if ($.trim($("#<%=txtPlaintext.ClientID%>").val()) == "") {
                myAlert("请输入明文");
                $("#<%=txtPlaintext.ClientID%>")[0].focus();
                return false;
            }
        }
        function checkCiphertext() {
            if ($.trim($("#<%=txtCiphertext.ClientID%>").val()) == "") {
                myAlert("请输入密文");
                $("#<%=txtCiphertext.ClientID%>")[0].focus();
                return false;
            }
        }
    </script>
</asp:Content>
