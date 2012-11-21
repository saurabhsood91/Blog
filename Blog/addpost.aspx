<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/admin.Master" CodeBehind="addpost.aspx.vb" Inherits="Blog.addpost" %>

<asp:Content ContentPlaceHolderID="settings" runat="server">
    <br /><br /><br /><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title:<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txttitle" runat=server /><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Content:<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<textarea id="txtcontent" cols="50" rows="20" runat=server></textarea><br />
    <br />

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Title Required" Display=None ControlToValidate="txttitle"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Content Required" Display=None ControlToValidate="txtcontent"></asp:RequiredFieldValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="submit" runat="server" Text="Add Post" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblRes" runat="server"></asp:Label>
    <br />
    <br />
</asp:Content>



