Imports System.Data.OleDb
Imports System.IO
Imports Microsoft.Win32
Public Class frmMembers
    Dim sql As String = Nothing
    Dim _filename As String = Nothing
    Dim _path As String = Nothing
    Dim imgDir As String = Application.StartupPath & "\images"
    Sub clearForm()
        txtFirstname.Text = ""
        txtLastname.Text = ""
        txtMiddlename.Text = ""
        cmbGender.Text = ""
        txtTelephone.Text = ""
        txtOccupation.Text = ""
        cmbSacraments.Text = ""
        cmbMaritalstatus.Text = ""
        txtChildren.Text = ""
        cmbResidenceNature.Text = ""
        txtEmployedMembers.Text = ""
        txtChildrenCathehesis.Text = ""
        cmbParish.Text = ""
        cmbSubparish.Text = ""
        cmbCommunity.Text = ""
        cmbMajorFaiths.Text = ""
        cmbParish.Text = ""
        cmbSubparish.Text = ""
        pcbImage.Image = Nothing
        DBFilePath.Text = ""
        FilePath.Text = ""
    End Sub
    Sub loadResidenceNature()
        cmbResidenceNature.Items.Clear()
        cmbResidenceNature.Items.Add("PARMANENT")
        cmbResidenceNature.Items.Add("RENTING")
        cmbResidenceNature.Items.Add("CONTRACT WORK")
    End Sub
    Sub loadMajorFaiths()
        cmbMajorFaiths.Items.Clear()
        cmbMajorFaiths.Items.Add("CATHOLIC")
        cmbMajorFaiths.Items.Add("SDA")
        cmbMajorFaiths.Items.Add("MUSLIMS")
        cmbMajorFaiths.Items.Add("ORTHODOX")
        cmbMajorFaiths.Items.Add("ANGLICAN")
        cmbMajorFaiths.Items.Add("PENTECOSTALS")
        cmbMajorFaiths.Items.Add("OTHERS")
    End Sub
    Sub loadGender()
        cmbGender.Items.Clear()
        cmbGender.Items.Add("Male")
        cmbGender.Items.Add("Female")
    End Sub
    Sub loadMaritalstatus()
        cmbMaritalstatus.Items.Clear()
        cmbMaritalstatus.Items.Add("Married")
        cmbMaritalstatus.Items.Add("single")
        cmbMaritalstatus.Items.Add("Matrimony Marriage")
    End Sub
    Sub loadSacraments()
        cmbSacraments.Items.Clear()
        cmbSacraments.Items.Add("Batismu")
        cmbSacraments.Items.Add("Konfrimasio")
        cmbSacraments.Items.Add("Ukaristia")
        cmbSacraments.Items.Add("Penitensia")
        cmbSacraments.Items.Add("Kusiigibwa kwa'balwadde")
        cmbSacraments.Items.Add("Oridini")
        cmbSacraments.Items.Add("Maltimoni")
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

    Sub loadCommunities()
        'cmbCommunity.Items.Clear()
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "SELECT id,communityName FROM tblCommunity"
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        cmbCommunity.DataSource = dt
        cmbCommunity.DisplayMember = "communityName"
        cmbCommunity.ValueMember = "id"
    End Sub
    'fill datagrid
    Sub FillDataGrid()
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "Select * from tblMembers"
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        DataGrid.DataSource = dt
        DataGrid.Refresh()
        DataGrid.Columns("id").Visible = False
        DataGrid.Columns("middlename").Visible = False
        DataGrid.Columns("occupation").Visible = False
        DataGrid.Columns("sacrament").Visible = False
        DataGrid.Columns("maritalstatus").Visible = False
        DataGrid.Columns("children").Visible = False
        DataGrid.Columns("residenceNature").Visible = False
        DataGrid.Columns("employedMembers").Visible = False
        DataGrid.Columns("childrenCathesis").Visible = False
        DataGrid.Columns("picture").Visible = False
        DataGrid.Columns("parish").Visible = False
        DataGrid.Columns("subparish").Visible = False
        DataGrid.Columns("majorFaiths").Visible = False

        DataGrid.Columns("firstname").HeaderText = "First Name"
        DataGrid.Columns("lastname").HeaderText = "Last Name"
        DataGrid.Columns("phone").HeaderText = "Telephone"
    End Sub
    Private Sub frmMembers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadMajorFaiths()
        loadResidenceNature()
        loadGender()
        loadMaritalstatus()
        loadSacraments()
        loadParish()
        loadSubparish()
        loadCommunities()
        FillDataGrid()
    End Sub

    
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        
        If txtFirstname.Text = "" Then
            MessageBox.Show("All fields are required", "Parish Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'txtParishname.Focus()
            Exit Sub
        Else
            'handle image
            If DBFilePath.Text <> "" Then
                'move image to imgDir
                pcbImage.Image.Save(DBFilePath.Text, System.Drawing.Imaging.ImageFormat.Jpeg)
            Else
                DBFilePath.Text = ""
            End If
            'MsgBox(_path)
            'Exit Sub
            sql = "INSERT INTO tblMembers (firstname,lastname,middlename,gender,phone,occupation,sacrament,parish,subparish,community,maritalstatus,children,picture, residenceNature, employedMembers, childrenCathesis, majorFaiths)"
            sql = sql + "VALUES('" & txtFirstname.Text & "', '" & txtLastname.Text & "','" & txtMiddlename.Text & "', '" & cmbGender.Text & "', '" & txtTelephone.Text & "', '" & txtOccupation.Text & "', '" & cmbSacraments.Text & "', '" & cmbParish.Text & "', '" & cmbSubparish.Text & "', '" & cmbCommunity.Text & "', '" & cmbMaritalstatus.Text & "', '" & txtChildren.Text & "','" & DBFilePath.Text & "', '" & cmbResidenceNature.Text & "', '" & txtEmployedMembers.Text & "', '" & txtChildrenCathehesis.Text & "', '" & cmbMajorFaiths.Text & "')"
            If conn.State = ConnectionState.Closed Then conn.Open()
            'insert 
           
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            clearForm()
            'fill the data grid
            Call FillDataGrid()

        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        'on update
        If btnUpdate.Visible Then
            If DBFilePath.Text <> "" Then
                'delete from file system
                File.Delete(DBFilePath.Text)
            End If
        End If
        Dim img As String
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = Nothing
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.FileName = ""
        openFileDialog1.Title = "Select member image"

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                'get the file
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    FilePath.Text = ""
                    img = openFileDialog1.FileName.ToString
                    pcbImage.Image = System.Drawing.Bitmap.FromFile(img)
                    FilePath.Text = openFileDialog1.FileName
                    _filename = System.IO.Path.GetFileName(FilePath.Text).ToString
                    _path = imgDir & "\" & _filename
                    DBFilePath.Text = _path
                End If
            Catch ex As Exception
                MessageBox.Show("Cannot read file from disk. Original Error" & ex.Message)
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If

            End Try
        End If
    End Sub

    Private Sub DataGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellDoubleClick
        'clear picturebox
        pcbImage.Image = Nothing
        txtID.Text = DataGrid.SelectedRows(0).Cells("id").Value
        txtFirstname.Text = DataGrid.SelectedRows(0).Cells("firstname").Value
        txtLastname.Text = DataGrid.SelectedRows(0).Cells("lastname").Value
        txtMiddlename.Text = DataGrid.SelectedRows(0).Cells("middlename").Value
        cmbGender.Text = DataGrid.SelectedRows(0).Cells("gender").Value
        txtTelephone.Text = DataGrid.SelectedRows(0).Cells("phone").Value
        If Not IsDBNull(DataGrid.SelectedRows(0).Cells("residenceNature").Value) Then
            txtOccupation.Text = DataGrid.SelectedRows(0).Cells("occupation").Value
        End If
        cmbSacraments.Text = DataGrid.SelectedRows(0).Cells("sacrament").Value
        cmbMaritalstatus.Text = DataGrid.SelectedRows(0).Cells("maritalstatus").Value
        txtChildren.Text = DataGrid.SelectedRows(0).Cells("children").Value
        If Not IsDBNull(DataGrid.SelectedRows(0).Cells("residenceNature").Value) Then
            cmbResidenceNature.Text = DataGrid.SelectedRows(0).Cells("residenceNature").Value
        End If
        If Not IsDBNull(DataGrid.SelectedRows(0).Cells("employedMembers").Value) Then
            txtEmployedMembers.Text = DataGrid.SelectedRows(0).Cells("employedMembers").Value
        End If

        If Not IsDBNull(DataGrid.SelectedRows(0).Cells("childrenCathesis").Value) Then
            txtChildrenCathehesis.Text = DataGrid.SelectedRows(0).Cells("childrenCathesis").Value
        End If

        cmbParish.Text = DataGrid.SelectedRows(0).Cells("parish").Value
        cmbSubparish.Text = DataGrid.SelectedRows(0).Cells("subparish").Value
        cmbCommunity.Text = DataGrid.SelectedRows(0).Cells("community").Value

        If Not IsDBNull(DataGrid.SelectedRows(0).Cells("majorFaiths").Value) Then
            cmbMajorFaiths.Text = DataGrid.SelectedRows(0).Cells("majorFaiths").Value
        End If
        'picture
        If Not IsDBNull(DataGrid.SelectedRows(0).Cells("picture").Value) Then
            'value not empty string
            If DataGrid.SelectedRows(0).Cells("picture").Value <> "" Then
                pcbImage.Image = System.Drawing.Bitmap.FromFile(DataGrid.SelectedRows(0).Cells("picture").Value)
                FilePath.Text = DataGrid.SelectedRows(0).Cells("picture").Value
                DBFilePath.Text = DataGrid.SelectedRows(0).Cells("picture").Value
            End If

        End If



        'buttons
        btnAdd.Enabled = False
        btnUpdate.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If DBFilePath.Text <> DataGrid.SelectedRows(0).Cells("picture").Value Then
            'move image to imgDir
            pcbImage.Image.Save(DBFilePath.Text, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
        If conn.State = ConnectionState.Closed Then conn.Open()
        'update
        sql = "UPDATE tblMembers SET "
        sql = sql + " firstname = '" & txtFirstname.Text & "', lastname='" & txtLastname.Text & "', middlename='" & txtMiddlename.Text & "', gender='" & cmbGender.Text & "', phone='" & txtTelephone.Text & "', sacrament = '" & cmbSacraments.Text & "', maritalstatus='" & cmbMaritalstatus.Text & "', children='" & txtChildren.Text & "', parish='" & cmbParish.Text & "', subparish='" & cmbSubparish.Text & "', community='" & cmbCommunity.Text & "', picture='" & DBFilePath.Text & "', residenceNature = '" & cmbResidenceNature.Text & "', employedMembers = '" & txtEmployedMembers.Text & "', childrenCathesis = '" & txtChildrenCathehesis.Text & "', majorFaiths= '" & cmbMajorFaiths.Text & "' "
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
        dr = MessageBox.Show("Are you sure you want to permanently Parish?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If dr = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            If conn.State = ConnectionState.Closed Then conn.Open()
            'update
            sql = "DELETE * from tblMembers  WHERE ID = " & txtID.Text
            Dim cmd As New OleDbCommand(sql, conn)
            cmd.ExecuteNonQuery()
            Call FillDataGrid()
            Call clearForm()
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            btnAdd.Enabled = True
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        pcbImage.Image = Nothing
        FilePath.Text = ""
        DBFilePath.Text = ""
    End Sub

   

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim source1 As New BindingSource()
        Dim dt As New DataTable
        sql = "Select * from tblMembers  WHERE (firstname Like '%" & txtSearch.Text & "%') OR (lastname Like '%" & txtSearch.Text & "%')"
        Dim da As New OleDb.OleDbDataAdapter(sql, conn)
        da.Fill(dt)
        da.Dispose()
        source1.DataSource = dt
        DataGrid.DataSource = dt
        DataGrid.Refresh()
    End Sub
End Class