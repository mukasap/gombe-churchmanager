<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptMembers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dbDataSetChurch = New CS.dbDataSetChurch()
        Me.tblMembersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tblMembersTableAdapter = New CS.dbDataSetChurchTableAdapters.tblMembersTableAdapter()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dbDataSetChurch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblMembersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSetMembers"
        ReportDataSource1.Value = Me.tblMembersBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "CS.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 31)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(911, 350)
        Me.ReportViewer1.TabIndex = 0
        '
        'dbDataSetChurch
        '
        Me.dbDataSetChurch.DataSetName = "dbDataSetChurch"
        Me.dbDataSetChurch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tblMembersBindingSource
        '
        Me.tblMembersBindingSource.DataMember = "tblMembers"
        Me.tblMembersBindingSource.DataSource = Me.dbDataSetChurch
        '
        'tblMembersTableAdapter
        '
        Me.tblMembersTableAdapter.ClearBeforeFill = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(841, 387)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(82, 36)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(348, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Church Members Report"
        '
        'rptMembers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 435)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "rptMembers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Members (Omukristu) Report"
        CType(Me.dbDataSetChurch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblMembersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblMembersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dbDataSetChurch As CS.dbDataSetChurch
    Friend WithEvents tblMembersTableAdapter As CS.dbDataSetChurchTableAdapters.tblMembersTableAdapter
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
