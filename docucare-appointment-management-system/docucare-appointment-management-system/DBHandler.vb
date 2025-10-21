Imports MySql.Data.MySqlClient

Public Class DBHandler
    Private ConnectionString As String = "server=localhost;user=root;database=DocUCare;port=3306;password=;"
    Private conn As MySqlConnection

    Public Sub New()
        conn = New MySqlConnection(ConnectionString)
    End Sub

    ' Method to authenticate user
    Public Function AuthenticateUser(username As String, password As String, verifiedID As String) As Boolean
        Dim sql As String = "SELECT Personnel_Name, Password, Verified_ID FROM PersonnelTable WHERE Personnel_Name = @username AND Password = @password AND Verified_ID = @verifiedID"
        Dim authenticated As Boolean = False

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                ' Use parameterized queries to prevent SQL injection
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)
                cmd.Parameters.AddWithValue("@verifiedID", verifiedID)

                Using dReader As MySqlDataReader = cmd.ExecuteReader()
                    If dReader.Read() Then
                        authenticated = True
                        ' Store user data if needed
                        DataStore.currentUser = {dReader("Personnel_Name").ToString(), password, verifiedID, ""}
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return authenticated
    End Function

    ' Generic Read method - returns DataTable
    Public Function Read(sql As String) As DataTable
        Dim dt As New DataTable()

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return dt
    End Function

    ' Read method with parameters - returns DataTable
    Public Function ReadWithParameters(sql As String, parameters As Dictionary(Of String, Object)) As DataTable
        Dim dt As New DataTable()

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                ' Add parameters
                For Each param In parameters
                    cmd.Parameters.AddWithValue(param.Key, param.Value)
                Next

                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return dt
    End Function

    ' Generic Insert/Update/Delete method - returns number of affected rows
    Public Function ExecuteNonQuery(sql As String) As Integer
        Dim rowsAffected As Integer = 0

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                rowsAffected = cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return rowsAffected
    End Function

    ' Insert/Update/Delete with parameters
    Public Function ExecuteNonQueryWithParameters(sql As String, parameters As Dictionary(Of String, Object)) As Integer
        Dim rowsAffected As Integer = 0

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                ' Add parameters
                For Each param In parameters
                    cmd.Parameters.AddWithValue(param.Key, param.Value)
                Next

                rowsAffected = cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return rowsAffected
    End Function

    ' Insert method with parameters
    Public Function Insert(tableName As String, parameters As Dictionary(Of String, Object)) As Boolean
        Dim columns As String = String.Join(", ", parameters.Keys)
        Dim values As String = String.Join(", ", parameters.Keys.Select(Function(k) "@" & k.Replace("@", "")))
        Dim sql As String = $"INSERT INTO {tableName} ({columns}) VALUES ({values})"

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    ' Update method with parameters
    Public Function Update(tableName As String, parameters As Dictionary(Of String, Object), whereClause As String) As Boolean
        Dim setClause As String = String.Join(", ", parameters.Keys.Select(Function(k) $"{k} = @{k.Replace("@", "")}"))
        Dim sql As String = $"UPDATE {tableName} SET {setClause} WHERE {whereClause}"

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    ' Delete method
    Public Function Delete(tableName As String, whereClause As String) As Boolean
        Dim sql As String = $"DELETE FROM {tableName} WHERE {whereClause}"

        Return ExecuteNonQuery(sql) > 0
    End Function

    ' Delete method with parameters
    Public Function DeleteWithParameters(tableName As String, whereClause As String, parameters As Dictionary(Of String, Object)) As Boolean
        Dim sql As String = $"DELETE FROM {tableName} WHERE {whereClause}"

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    ' Check if connection is working
    Public Function TestConnection() As Boolean
        Try
            conn.Open()
            conn.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    ' Dispose method to clean up resources
    Public Sub Dispose()
        If conn IsNot Nothing Then
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Dispose()
        End If
    End Sub
End Class