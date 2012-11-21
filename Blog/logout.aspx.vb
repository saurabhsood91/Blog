Public Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("uid") IsNot Nothing Then
            Session.Remove("uid")
        End If
        Response.Redirect("home.aspx")
    End Sub

End Class