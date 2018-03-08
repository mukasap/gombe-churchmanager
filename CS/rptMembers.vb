Public Class rptMembers

    Private Sub rptMembers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dbDataSetChurch.tblMembers' table. You can move, or remove it, as needed.
        Me.tblMembersTableAdapter.Fill(Me.dbDataSetChurch.tblMembers)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub
End Class