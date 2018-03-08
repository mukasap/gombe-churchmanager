Module DatabaseConnection
    Public conn As New System.Data.OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source =  " & Application.StartupPath & "\db.accdb;")
End Module
