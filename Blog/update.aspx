<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/admin.Master" CodeBehind="update.aspx.vb" Inherits="Blog.update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="settings" runat="server">
Title:<br /><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br /><br />
Content:<br /><textarea name="txtcontent" runat="server" id="txtcontent" rows="20" cols="50"></textarea><br /><br />
    <asp:Label ID="lblOutput" runat="server"></asp:Label>
    <br />
    <br />
<asp:Button ID="updatebutton" runat="server" Text="Update Post" />
</asp:Content>
