Imports System.Data.SqlClient

Public Class updatepost
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("uid") Is Nothing Then
            Response.Redirect("home.aspx")
        End If

        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=(local)\SQLExpress;Initial Catalog=blogdb;Integrated Security=SSPI"

        Dim cmd As New SqlCommand
        cmd.CommandText = "select pid, title from tblposts"
        cmd.Connection = conn

        conn.Open()

        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()

        Response.Write("<ul>")
        While reader.Read()
            Dim lblTitle As New Label

            lblTitle.Text = "<li><a href = update.aspx?id=" & reader("pid") & ">" & reader("title") & "</a>"
            lp.Controls.Add(lblTitle)
            lp.Controls.Add(New LiteralControl("<br />"))
            Debug.Write(reader("title"))

        End While
        Response.Write("</ul>")

        conn.Close()
    End Sub

End Class