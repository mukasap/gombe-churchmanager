Imports System.Data.OleDb
Public Class frmSubparish
    Dim sql As String = Nothing
    'fill datagrid
    Sub FillDataGrid()
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "Select * from tblSubparish"
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        DataGrid.DataSource = dt
        DataGrid.Refresh()
        DataGrid.Columns("id").Visible = False
        DataGrid.Columns("parishid").Visible = False
        DataGrid.Columns("subparishName").HeaderText = "Name"
        DataGrid.Columns("parishName").HeaderText = "Parish"
        DataGrid.Columns("diocese").HeaderText = "Diocese"
    End Sub
    Sub loadDiocese()
        cmbDiocese.Items.Clear()
        cmbDiocese.Items.Add("Arua")
        cmbDiocese.Items.Add("Lira")
        cmbDiocese.Items.Add("Nebbi")
        cmbDiocese.Items.Add("Kampala")
        cmbDiocese.Items.Add("Kasana - Luwero")
        cmbDiocese.Items.Add("Kiyinda - Mityana")
        cmbDiocese.Items.Add("Lugazi")
        cmbDiocese.Items.Add("Masaka")
        cmbDiocese.Items.Add("Fort Portal")
        cmbDiocese.Items.Add("Hioma")
        cmbDiocese.Items.Add("Kabale")
        cmbDiocese.Items.Add("Kasese")
        cmbDiocese.Items.Add("Jinja")
        cmbDiocese.Items.Add("Kotido")
        cmbDiocese.Items.Add("Moroto")
        cmbDiocese.Items.Add("Soroti")
    End Sub
    Sub clearForm()
        txtParishname.Text = ""
        cmbDiocese.Text = ""
    End Sub

    Private Sub frmSubparish_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillDataGrid()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If txtParishname.Text = "" Then
            MessageBox.Show("All fields are required", "Parish Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtParishname.Focus()
            Exit Sub
        Else
            If conn.State = ConnectionState.Closed Then conn.Open()
            'insert 
            sql = "INSERT INTO tblSubparish (subparishName,parishID,parishName,diocese)"
            sql = sql + "VALUES('" & txtSubparish.Text & "','" & txtParishID.Text & "','" & txtParishname.Text & "', '" & cmbDiocese.Text & "')"
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            clearForm()
            'fill the data grid
            Call FillDataGrid()

        End If
    End Sub

    Private Sub DataGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellContentClick

    End Sub

    Private Sub DataGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellDoubleClick
        txtID.Text = DataGrid.SelectedRows(0).Cells("id").Value
        txtSubparish.Text = DataGrid.SelectedRows(0).Cells("subparishName").Value.ToString
        txtParishname.Text = DataGrid.SelectedRows(0).Cells("parishName").Value.ToString
        cmbDiocese.Text = DataGrid.SelectedRows(0).Cells("diocese").Value.ToString
        txtParishID.Text = DataGrid.SelectedRows(0).Cells("parishID").Value
        btnAdd.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If conn.State = ConnectionState.Closed Then conn.Open()
        'update
        sql = "UPDATE tblSubparish SET "
        sql = sql + " subparishName='" & txtSubparish.Text & "', parishID='" & txtParishID.Text & "',parishName = '" & txtParishname.Text & "', diocese = '" & cmbDiocese.Text & "'"
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dr As New DialogResult
        dr = MessageBox.Show("Are you sure you want to permanently Subparish?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If dr = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            If conn.State = ConnectionState.Closed Then conn.Open()
            'update
            sql = "DELETE * from tblSubparish  WHERE ID = " & txtID.Text
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

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "Select * from tblSubparish  WHERE (parishName Like '%" & txtSearch.Text & "%') OR (subparishName Like '%" & txtSearch.Text & "%') "
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        DataGrid.DataSource = dt
        DataGrid.Refresh()
    End Sub
End Class