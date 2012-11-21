Imports System.Data.SqlClient

Public Class viewpost
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("uid") IsNot Nothing Then
            log.InnerText = "Logout"
            log.HRef = "logout.aspx"
            admin.Visible = True
        Else
            admin.Visible = False
        End If

        Dim postid As Integer = CType(Request.QueryString.Item("pid"), Integer)

        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=(local)\SQLExpress;Initial Catalog=blogdb;Integrated Security=True"

        Try
            conn.Open()
        Catch ex As Exception
            Debug.WriteLine("failed to open")
            Debug.WriteLine(ex)
        End Try

        Dim cmd As New SqlCommand

        Dim reader As SqlDataReader

        cmd.CommandText = "select * from tblposts where pid=" & postid

        Debug.Write(cmd.CommandText.ToString)
        cmd.Connection = conn

        reader = cmd.ExecuteReader()

        reader.Read()
        Me.Title = reader("title")
        'Response.Write("<b>" & reader("title") & "</b><br /><br />")
        'Response.Write(reader("content"))

        lblTitle.Text = "<h1><u><center>" & reader("title") & "</center></u></h1>"
        lblContent.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & reader("content")

        'Write Code to retrieve comments

        Dim pid As Integer = reader("pid")
        reader.Close()

        cmd.CommandText = "select * from tblcomments where pid=@pid order by cid desc"
        cmd.Parameters.AddWithValue("@pid", pid)

        Dim commentReader = cmd.ExecuteReader()
        panelComments.Controls.Add(New LiteralControl("<ul>"))
        While commentReader.Read()
            Dim lblName As New Label
            Dim lblComment As New Label

            lblName.Text = "<b>" & commentReader("name") & "</b> said:"
            lblComment.Text = "<i>" & commentReader("content") & "</i>"
            panelComments.Controls.Add(New LiteralControl("<li />"))
            panelComments.Controls.Add(lblName)
            panelComments.Controls.Add(New LiteralControl("<br /><br />"))
            panelComments.Controls.Add(lblComment)
            panelComments.Controls.Add(New LiteralControl("<br /><br />"))
        End While

        panelComments.Controls.Add(New LiteralControl("</ul>"))

    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPost.Click
        Dim pid As Integer = CType(Request.QueryString("pid").ToString, Integer)

        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=(local)\SQLExpress;Initial Catalog=blogdb;Integrated Security=True"

        Dim cmd As New SqlCommand
        cmd.CommandText = "insert into tblcomments(name, email, pid, content) values(@name, @email, @pid, @content)"
        cmd.Parameters.AddWithValue("@name", txtName.Text)
        cmd.Parameters.AddWithValue("@pid", pid)
        cmd.Parameters.AddWithValue("@email", txtEmail.Text)
        cmd.Parameters.AddWithValue("@content", txtComment.InnerText)
        cmd.Connection = conn

        conn.Open()

        Dim res As Integer = cmd.ExecuteNonQuery

        If res = 1 Then
            lblPosted.Text = "Comment Successully Added!!!"
        Else
            lblPosted.Text = "Could not post comment!!!"
        End If

        Response.Redirect(Request.Url.ToString)

    End Sub
End Class