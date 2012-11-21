<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="login.aspx.vb" Inherits="Blog.login1" %>

<asp:Content ContentPlaceHolderID="mp" runat="server">
    <br /><br />
    <asp:Label ID="lblErr" runat="server"></asp:Label>
    <br /><br /><br />
    Username: <asp:TextBox runat=server ID="uname"></asp:TextBox><br /><br />
    Password: <input id="pwd" type="password" runat=server /><br />
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="Username Required" ControlToValidate="uname" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="Password Required" ControlToValidate="pwd" Display="None"></asp:RequiredFieldValidator>
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br /><br /><br />
    <asp:Button ID="submit" Text="Login" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="lp" runat="server">
    <b><li /><a href = "home.aspx">Home</a></b>
</asp:Content>