Imports System.Data.SqlClient
Public Class home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("uid") IsNot Nothing Then
            log.InnerText = "Logout"
            log.HRef = "logout.aspx"
            admin.Visible = True
        Else
            admin.Visible = False
        End If


        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=(local)\SQLExpress;Initial Catalog=blogdb;Integrated Security=SSPI"

        Dim cmd As New SqlCommand
        cmd.CommandText = "select * from tblposts order by pid desc"
        cmd.Connection = conn

        conn.Open()

        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()

        Dim i As Integer = 1

        While reader.Read()
            Dim lblTitle As New Label
            Dim lblContent As New Label

            lblTitle.Text = "<b><a href = viewpost.aspx?pid=" & reader("pid") & ">" & reader("title") & "</a></b>"
            Debug.Write(reader("title"))
            Debug.Write(reader("content"))
            lblContent.Text = reader("content")

            middlePane.Controls.Add(New LiteralControl("<b>" & i & ".) </b>"))
            middlePane.Controls.Add(lblTitle)
            middlePane.Controls.Add(New LiteralControl("<br /><br />"))
            middlePane.Controls.Add(lblContent)
            middlePane.Controls.Add(New LiteralControl("<br /><br />"))
            middlePane.Controls.Add(New LiteralControl("<br /><br />"))

            i = i + 1

        End While

        conn.Close()

    End Sub

End Class