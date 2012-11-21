Imports System.Data.SqlClient

Public Class update
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("uid") Is Nothing Then
            Response.Redirect("home.aspx")
        End If

        If Not Me.IsPostBack Then
            Dim id As Integer = CType(Request.QueryString("id"), Integer)

            Dim conn As New SqlConnection
            conn.ConnectionString = "Data Source=(local)\SQLExpress;Initial Catalog=blogdb;Integrated Security=SSPI"

            Dim cmd As New SqlCommand
            cmd.CommandText = "select * from tblposts where pid=@pid"
            cmd.Parameters.AddWithValue("pid", Request.QueryString("id"))
            cmd.Connection = conn

            conn.Open()

            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            reader.Read()

            txtTitle.Text = reader("title")
            txtcontent.InnerText = reader("content")

            conn.Close()
        End If
    End Sub

    Protected Sub updatebutton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles updatebutton.Click
        Dim conn As New SqlConnection
        conn.ConnectionString = "Data Source=(local)\SQLExpress;Initial Catalog=blogdb;Integrated Security=SSPI"

        'MsgBox(txtcontent.InnerText)
        'MsgBox(txtTitle.Text)

        'Dim p As Integer
        'p = CType(Request.Cookies("p").ToString, Integer)
        'Debug.Write("post id is " & p)

        Dim cmd As New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "update tblposts set title=@ptitle, content=@pcontent where pid=@p"
        cmd.Parameters.AddWithValue("@ptitle", txtTitle.Text)
        cmd.Parameters.AddWithValue("@pcontent", txtcontent.Value)
        cmd.Parameters.AddWithValue("@p", CType(Request.QueryString("id").ToString, Integer))

        'Debug.Write("cookie value is ")
        'Debug.Write(Request.Cookies("p"))

        conn.Open()

        Dim res As Integer

        Try
            res = cmd.ExecuteNonQuery()
        Catch ex As Exception
            Debug.Write(ex)
        End Try


        If res = 1 Then
            Debug.Write("successfull update")
            lblOutput.Text = "Successfully Updated the Post!!!"
        Else
            Debug.Write("update failed")
            lblOutput.Text = "Updated Failed!!!"
        End If

    End Sub
End Class