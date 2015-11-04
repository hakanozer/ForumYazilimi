<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kullanici.aspx.cs" Inherits="Site.kullanici.kullanici" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/css" /> 

    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts><asp:ScriptReference Name="jquery" /></Scripts>
    </asp:ScriptManager>

        <style>
            html {
                background-color:white;
            }
            .adminGirisForm {
                margin-top: 10%;
            }
        </style>

    <div>
        <div class="adminGirisForm">
            <h1>Kullanıcı Giriş Paneli</h1>
        &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Giriş Yap" />
    </div>
    </div>
    </form>
</body>
</html>
