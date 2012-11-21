Imports System.Security.Cryptography
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class login1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()

    End Function 'GetMd5Hash

    Protected Sub submit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles submit.Click
        Dim [source] As String = pwd.Value
        Dim hash As String
        Using md5Hash As MD5 = MD5.Create()
            hash = GetMd5Hash(md5Hash, source)
            'Response.Write(hash)
        End Using

        Dim username As String = uname.Text

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

        cmd.CommandText = "select * from tblusers"
        cmd.Connection = conn

        reader = cmd.ExecuteReader()

        Dim found As Integer = 0
        Dim isAdmin As Integer = 0
        Dim userid As Integer
        While reader.Read()
            If reader("uname") = username And reader("pwd") = hash Then
                found = 1
                userid = CType(reader("uid"), Integer)
                If reader("role") = 1 Then
                    '                    Debug.WriteLine("It is admin")
                    System.Diagnostics.Debug.WriteLine("it is admin")
                    isAdmin = 1
                    Exit While
                End If

            End If
        End While

        If found = 1 Then
            Response.Write("logged in")
            Session("uid") = userid
            'Redirect Code follows here
            Response.Redirect("admin.aspx")
        Else
            'Response.Write("error logging in")
            lblErr.Text = "Invalid username/password"
        End If

    End Sub
End Class