<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Login.aspx.cs"
    Inherits="GoogleAuthenticatorInAspNetWF.Views.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label Text="Email:" runat="server" /><br />
    <asp:TextBox ID="txtEmail" runat="server" /><br /><br />

    <asp:Label Text="Password:" runat="server" /><br />
    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" /><br /><br />

    <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" /><br /><br />

    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

</asp:Content>
