Imports System.Data.SqlClient

Public Class addpost
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Write(Session("uid"))
        If Session("uid") Is Nothing Then
            Response.Redirect("home.aspx")
        End If
    End Sub

    Protected Sub submit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles submit.Click
        Dim title As String = txttitle.Text
        Dim content As String = txtcontent.Value

        If Session("uid") Is Nothing Then
            'Not Logged in
            'Handle it
        Else
            Dim uid As Integer = CType(Session("uid"), Integer)
            Dim query As StringBuilder = New StringBuilder

            query.Append("insert into tblposts(title, content, uid,timestamp) values('")
            query.Append(title)
            query.Append("','")
            query.Append(content)
            query.Append("',")
            query.Append(uid)
            query.Append(",'")
            query.Append(DateTime.Now.ToString)
            query.Append("')")

            Debug.Write(query.ToString)

            Dim conn As New SqlConnection
            conn.ConnectionString = "Data Source=(local)\SQLExpress;Initial Catalog=blogdb;Integrated Security=True"

            Try
                conn.Open()
            Catch ex As Exception
                Debug.WriteLine("failed to open")
                Debug.WriteLine(ex)
            End Try

            Dim cmd As New SqlCommand
            cmd.CommandText = query.ToString
            cmd.Connection = conn

            Dim res As Integer = cmd.ExecuteNonQuery()

            If res <> 0 Then
                Debug.Write("successfully added to DB")
                lblRes.Text = "Post Successfully Added!!!"
            End If

        End If


    End Sub
End Class