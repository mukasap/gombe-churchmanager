Imports System.Data.OleDb
Public Class frmCommunity
    Dim sql As String = Nothing
    Sub clearForm()
        txtCommunity.Text = ""
        cmbParish.Text = ""
        cmbSubparish.Text = ""
    End Sub
    Sub FillDataGrid()
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "Select * from tblCommunity"
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        DataGrid.DataSource = dt
        DataGrid.Refresh()
        DataGrid.Columns("id").Visible = False
        'DataGrid.Columns("parishid").Visible = False
        DataGrid.Columns("communityName").HeaderText = "Name"
        DataGrid.Columns("parishName").HeaderText = "Parish"
        DataGrid.Columns("subparishName").HeaderText = "Subparish"
    End Sub
    Sub loadParish()
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "SELECT id,parishName FROM tblParish"
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        cmbParish.DataSource = dt
        cmbParish.DisplayMember = "parishName"
        cmbParish.ValueMember = "id"
    End Sub

    Sub loadSubparish()
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "SELECT id,subparishName FROM tblSubparish"
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        cmbSubparish.DataSource = dt
        cmbSubparish.DisplayMember = "subparishName"
        cmbSubparish.ValueMember = "id"
    End Sub


    Private Sub frmCommunity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadParish()
        loadSubparish()
        FillDataGrid()
    End Sub

    
    Private Sub cmbParish_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbParish.SelectedIndexChanged

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtCommunity.Text = "" Then
            MessageBox.Show("All fields are required", "Community Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCommunity.Focus()
            Exit Sub
        Else
            If conn.State = ConnectionState.Closed Then conn.Open()
            'insert 
            sql = "INSERT INTO tblCommunity (communityName,parishName,subparishName)"
            sql = sql + "VALUES('" & txtCommunity.Text & "','" & cmbParish.Text & "', '" & cmbSubparish.Text & "')"
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            clearForm()
            'fill the data grid
            Call FillDataGrid()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If conn.State = ConnectionState.Closed Then conn.Open()
        'update
        sql = "UPDATE tblCommunity SET "
        sql = sql + " communityName='" & txtCommunity.Text & "', parishName='" & cmbParish.Text & "',subparishName = '" & cmbSubparish.Text & "'"
        sql = sql + " WHERE "
        sql = sql + " ID = " & txtID.Text
        Dim cmd As New OleDbCommand(sql, conn)
        cmd.ExecuteNonQuery()
        Call FillDataGrid()
        Call clearForm()
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnAdd.Enabled = True
    End Sub

    

    Private Sub DataGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellDoubleClick
        txtID.Text = DataGrid.SelectedRows(0).Cells("id").Value
        txtCommunity.Text = DataGrid.SelectedRows(0).Cells("communityName").Value.ToString
        cmbParish.Text = DataGrid.SelectedRows(0).Cells("parishName").Value.ToString
        cmbSubparish.Text = DataGrid.SelectedRows(0).Cells("subparishName").Value.ToString
        'txtParishID.Text = DataGrid.SelectedRows(0).Cells("parishID").Value
        btnAdd.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dr As New DialogResult
        dr = MessageBox.Show("Are you sure you want to permanently Community?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If dr = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            If conn.State = ConnectionState.Closed Then conn.Open()
            'update
            sql = "DELETE * from tblCommunity  WHERE ID = " & txtID.Text
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            Call FillDataGrid()
            Call clearForm()
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            btnAdd.Enabled = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "Select * from tblCommunity  WHERE (communityName Like '%" & txtSearch.Text & "%') OR (parishName Like '%" & txtSearch.Text & "%') OR (subparishName Like '%" & txtSearch.Text & "%') "
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        DataGrid.DataSource = dt
        DataGrid.Refresh()
    End Sub
End Class