<%@ Page Language="C#" AutoEventWireup="true" 
    MasterPageFile="~/Site.Master"
    CodeBehind="TwoFactor.aspx.cs" 
    Inherits="GoogleAuthenticatorInAspNetWF.Views.TwoFactor" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label Text="Enter 2FA code from Google Authenticator:" runat="server" /><br /><br />
    <asp:TextBox ID="txtCode" runat="server" /><br /><br />
    <asp:Button ID="btnVerify" Text="Verify" runat="server" OnClick="btnVerify_Click" /><br /><br />
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" />

</asp:Content>
