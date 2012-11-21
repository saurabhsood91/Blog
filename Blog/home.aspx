<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.Master" CodeBehind="home.aspx.vb" Inherits="Blog.home" %>

<asp:Content ContentPlaceHolderID="lp" runat="server">
<asp:Panel runat="server" ID="leftPane">
    <b><li /><a id="log" href = "login.aspx" runat="server">Login</a></b>
    <b><li /><a id="admin" href = "admin.aspx" runat="server">Admin Panel</a></b>
</asp:Panel>
</asp:Content>

<asp:Content ContentPlaceHolderID="mp" runat="server">
<asp:Panel ID= "middlePane" runat="server">
</asp:Panel>
</asp:Content>
