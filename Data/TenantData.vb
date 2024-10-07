Imports Npgsql
Imports System.IO

Public Class TenantData
    Shared cn As NpgsqlConnection
    Shared cmd As NpgsqlCommand
    Shared da As NpgsqlDataAdapter
    Shared dt As DataTable

    Shared setingCon As String

    Shared Sub connect()
        setingCon = My.Computer.FileSystem.ReadAllText(Application.StartupPath() + "setingCon.txt")
        'cn = New NpgsqlConnection("Host=abd.sokrates.co.id:62112;Username=sokrates;Database=sokrates;Password=Rockfish-Green-Lyricism-Plethora-Headrest1-s0kr4T3s-20210810")
        cn = New NpgsqlConnection(setingCon)
    End Sub

    Shared Function executeSQL(ByVal SQL As String) As Boolean
        Try
            cmd = New NpgsqlCommand(SQL, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            Return True
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Shared Function generateResultSet(ByVal SQL As String) As DataTable
        da = New NpgsqlDataAdapter
        dt = New DataTable
        Try
            cmd = New NpgsqlCommand(SQL, cn)
            cn.Open()
            da.SelectCommand = cmd
            da.Fill(dt)
            cn.Close()
            Return dt
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
            dt = Nothing
            Return dt
        End Try
    End Function
End Class
