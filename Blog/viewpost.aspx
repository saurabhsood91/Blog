<%@ Page Language="vb" MasterPageFile="~/main.Master" AutoEventWireup="false" CodeBehind="viewpost.aspx.vb" Inherits="Blog.viewpost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="lp" runat="server">
<asp:Panel runat="server" ID="leftPane">
    <b><li /><a id="home" href = "home.aspx" runat="server">Home</a></b>
    <b><li /><a id="log" href = "login.aspx" runat="server">Login</a></b>
    <b><li /><a id="admin" href = "admin.aspx" runat="server">Admin Panel</a></b>
</asp:Panel>
</asp:Content>

<asp:Content ContentPlaceHolderID="mp" ID="left" runat="server">
<asp:Panel runat="server" ID="details">
    &nbsp;
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblContent" runat="server"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <h4>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="text-decoration: underline">Comments:&nbsp;</span></h4>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Panel ID="panelComments" runat="server">
    </asp:Panel>
    <br />
    &nbsp;<h4>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="text-decoration: underline">Add a Comment:</span></h4>
    &nbsp;<br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email Address:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Comment:<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <textarea ID="txtComment" name="txtComment" style="height: 117px; width: 314px" runat="server"></textarea><br />
    <br />
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" ControlToValidate="txtName" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email Required" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Content Required" ControlToValidate="txtComment" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Not A Valid Email" ControlToValidate="txtEmail" Display="None" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnPost" runat="server" Text="Post Comment" />
    <br />
    
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblPosted" runat="server"></asp:Label>
    <br />
    <br />
</asp:Panel>
</asp:Content>
