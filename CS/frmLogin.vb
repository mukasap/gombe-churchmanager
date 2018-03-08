Imports System.Data.OleDb
Public Class frmLogin

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'check if username or password filled
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please fill in Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'check if user exists in db
            If conn.State = ConnectionState.Closed Then conn.Open()

            Try
                'conncet to db for records
                Dim sql As String = "SELECT * FROM tblUsers WHERE username='" & txtUsername.Text & "' AND pswd = '" & txtPassword.Text & "'"
                Dim cmd As New OleDbCommand(sql, conn)

                Dim sqlRead As System.Data.OleDb.OleDbDataReader = cmd.ExecuteReader()

                If sqlRead.Read() Then
                    'user found open the app
                    Me.Hide()
                    frmMain.Show()
                Else
                    'user not found
                    MessageBox.Show("Invaild Username and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    txtPassword.Text = ""
                    txtUsername.Text = ""

                    txtUsername.Focus()

                End If
            Catch ex As Exception
                MessageBox.Show("Failed to connect to database:" & ex.Message, "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class