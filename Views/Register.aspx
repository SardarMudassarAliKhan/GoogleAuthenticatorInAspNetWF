<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Register.aspx.cs"
    Inherits="GoogleAuthenticatorInAspNetWF.Views.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label Text="Email:" runat="server" /><br />
    <asp:TextBox ID="txtEmail" runat="server" /><br /><br />

    <asp:Label Text="Password:" runat="server" /><br />
    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" /><br /><br />

    <asp:Button ID="btnRegister" Text="Register" runat="server" OnClick="btnRegister_Click" /><br /><br />

    <asp:Image ID="imgQrCode" runat="server" Width="250" Height="250" /><br /><br />
    <asp:Label ID="lblSecret" runat="server" ForeColor="Red" />

</asp:Content>
