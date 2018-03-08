Imports System.Data.OleDb
Public Class frmUsers
    Dim sql As String = Nothing
    'load roles
    Sub loadRoles()
        cmbRoles.Items.Add("Administrator")
    End Sub
    'fill datagrid
    Sub FillDataGrid()
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "Select * from tblUsers"
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        DataGrid.DataSource = dt
        DataGrid.Refresh()
        DataGrid.Columns("id").Visible = False
        DataGrid.Columns("pswd").Visible = False
        DataGrid.Columns("firstname").HeaderText = "First Name"
        DataGrid.Columns("lastname").HeaderText = "Last Name"
        DataGrid.Columns("role").HeaderText = "Role"
        DataGrid.Columns("telephone").HeaderText = "Phone"
    End Sub
    'clear form
    Sub ClearForm()
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtPassword2.Text = ""
        txtFirstname.Text = ""
        txtLastname.Text = ""
        txtTelephone.Text = ""
        cmbRoles.Text = ""
    End Sub
    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call loadRoles()
        Call FillDataGrid()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtPassword.Text <> txtPassword2.Text Then
            MessageBox.Show("Passwords did not match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Text = ""
            txtPassword2.Text = ""
            txtPassword.Focus()
            Exit Sub
        Else
            If conn.State = ConnectionState.Closed Then conn.Open()
            'insert 
            sql = "INSERT INTO tblUsers (username, pswd, firstname,lastname,telephone,role)"
            sql = sql + "VALUES('" & txtUsername.Text & "', '" & txtPassword.Text & "', '" & txtFirstname.Text & "', '" & txtLastname.Text & "','" & txtTelephone.Text & "', '" & cmbRoles.Text & "')"
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            ClearForm()
            'fill the data grid
            Call FillDataGrid()

        End If
    End Sub

    Private Sub DataGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellContentClick

    End Sub

    
    Private Sub DataGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellDoubleClick
        txtID.Text = DataGrid.SelectedRows(0).Cells("id").Value
        txtUsername.Text = DataGrid.SelectedRows(0).Cells("username").Value.ToString
        txtFirstname.Text = DataGrid.SelectedRows(0).Cells("firstname").Value.ToString
        txtLastname.Text = DataGrid.SelectedRows(0).Cells("lastname").Value.ToString
        txtTelephone.Text = DataGrid.SelectedRows(0).Cells("telephone").Value.ToString
        cmbRoles.Text = DataGrid.SelectedRows(0).Cells("role").Value.ToString
        'disable adding
        btnAdd.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True


    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If conn.State = ConnectionState.Closed Then conn.Open()
        'update
        sql = "UPDATE tblUsers SET "
        sql = sql + " username = '" & txtUsername.Text & "', firstname = '" & txtFirstname.Text & "', lastname = '" & txtLastname.Text & "', telephone = '" & txtTelephone.Text & "', role = '" & cmbRoles.Text & "'"
        sql = sql + " WHERE "
        sql = sql + " ID = " & txtID.Text
        Dim cmd As New OleDbCommand(sql, conn)
        cmd.ExecuteNonQuery()
        Call FillDataGrid()
        Call ClearForm()
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnAdd.Enabled = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dr As New DialogResult
        dr = MessageBox.Show("Are you sure you want to permanently user?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If dr = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            If conn.State = ConnectionState.Closed Then conn.Open()
            'update
            sql = "DELETE * from tblUsers  WHERE ID = " & txtID.Text
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            Call FillDataGrid()
            Call ClearForm()
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            btnAdd.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "Select * from tblUsers  WHERE (firstname Like '%" & txtSearch.Text & "%') OR (lastname Like '%" & txtSearch.Text & "%') "
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        DataGrid.DataSource = dt
        DataGrid.Refresh()
    End Sub
End Class
