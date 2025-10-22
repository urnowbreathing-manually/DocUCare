Imports MySql.Data.MySqlClient

Public Class DBHandler
    Private ConnectionString As String = "server=localhost;user=root;database=DocUCare;port=3306;password=;"
    Private conn As MySqlConnection

    Public Sub New()
        conn = New MySqlConnection(ConnectionString)
    End Sub

    ' Method to authenticate user (unchanged)
    Public Function AuthenticateUser(username As String, password As String, verifiedID As String) As Boolean
        Dim sql As String = "SELECT Personnel_Name, Password, Verified_ID, Role FROM personneltable WHERE Personnel_Name = @username AND Password = @password AND Verified_ID = @verifiedID"
        Dim authenticated As Boolean = False

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password)
                cmd.Parameters.AddWithValue("@verifiedID", verifiedID)

                Using dReader As MySqlDataReader = cmd.ExecuteReader()
                    If dReader.Read() Then
                        authenticated = True
                        DataStore.currentUser = {dReader("Personnel_Name").ToString(), password, verifiedID, dReader("Role").ToString()}
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

    ' ==================== PATIENT METHODS ====================

    Public Function InsertPatient(patientID As String, patientName As String, age As Integer,
                                  sex As String, contact As String, emContact As String,
                                  bloodType As String, allergies As String,
                                  medicalConditions As String,
                                  height As String, weight As String) As Boolean
        Dim sql As String = "INSERT INTO patient (patient_id, patient_name, age, sex, contact, em_contact, blood_type, allergies, medical_conditions, height, weight) " &
                           "VALUES (@patientID, @patientName, @age, @sex, @contact, @emContact, @bloodType, @allergies, @medicalConditions, @height, @weight)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@patientID", patientID},
            {"@patientName", patientName},
            {"@age", age},
            {"@sex", sex},
            {"@contact", contact},
            {"@emContact", emContact},
            {"@bloodType", bloodType},
            {"@allergies", allergies},
            {"@medicalConditions", medicalConditions},
            {"@height", height},
            {"@weight", weight}
        }

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    ' Generates a unique Patient ID in the format P-MMDDYYYY-XXXX
    Public Function GetNextPatientID() As String
        Dim datePrefix As String = "P-" & DateTime.Now.ToString("MMddyyyy") & "-"
        Dim nextID As String = datePrefix & "0001" ' Default for first patient of the day

        Dim sql As String = "SELECT patient_id FROM patient WHERE patient_id LIKE @prefix ORDER BY patient_id DESC LIMIT 1"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@prefix", datePrefix & "%")

                Using dReader As MySqlDataReader = cmd.ExecuteReader()
                    If dReader.Read() Then
                        Dim lastID As String = dReader("patient_id").ToString()
                        Dim lastNumStr As String = lastID.Substring(lastID.Length - 4)
                        Dim nextNum As Integer = CInt(lastNumStr) + 1
                        nextID = datePrefix & nextNum.ToString("D4")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error generating patient ID: " & ex.Message, MsgBoxStyle.Exclamation)
            Return Nothing
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return nextID
    End Function

    ' Get All Patients
    Public Function GetAllPatients() As DataTable
        Dim sql As String = "SELECT * FROM patient ORDER BY patient_name"
        Return Read(sql)
    End Function

    ' Get Patient by ID
    Public Function GetPatientByID(patientID As String) As DataTable
        Dim sql As String = "SELECT * FROM patient WHERE patient_id = @patientID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@patientID", patientID}
        }
        Return ReadWithParameters(sql, parameters)
    End Function

    ' Update Patient
    Public Function UpdatePatient(patientID As String, patientName As String, age As Integer,
                                  sex As String, contact As String, emContact As String,
                                  bloodType As String, allergies As String,
                                  medicalConditions As String, height As String, weight As String) As Boolean
        Dim sql As String = "UPDATE patient SET patient_name = @patientName, age = @age, sex = @sex, " &
                           "contact = @contact, em_contact = @emContact, blood_type = @bloodType, " &
                           "allergies = @allergies, medical_conditions = @medicalConditions, " &
                           "height = @height, weight = @weight " &
                           "WHERE patient_id = @patientID"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@patientID", patientID},
            {"@patientName", patientName},
            {"@age", age},
            {"@sex", sex},
            {"@contact", contact},
            {"@emContact", emContact},
            {"@bloodType", bloodType},
            {"@allergies", allergies},
            {"@medicalConditions", medicalConditions},
            {"@height", height},
            {"@weight", weight}
        }

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    ' Delete Patient
    Public Function DeletePatient(patientID As String) As Boolean
        Dim sql As String = "DELETE FROM patient WHERE patient_id = @patientID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@patientID", patientID}
        }
        Return DeleteWithParameters("patient", "patient_id = @patientID", parameters)
    End Function

    ' ==================== APPOINTMENT METHODS ====================
    ' (unchanged from your original — kept for completeness)
    Public Function InsertAppointment(patientName As String, patientID As String,
                                     doctorName As String, verifiedID As String,
                                     appointmentDate As String, appointmentTime As String,
                                     status As String, notes As String,
                                     consultFee As Decimal) As Integer
        Dim sql As String = "INSERT INTO appointments (patient_name, patient_id, doctor_name, Verified_ID, date, time, status, notes, consult_fee) " &
                           "VALUES (@patientName, @patientID, @doctorName, @verifiedID, @date, @time, @status, @notes, @consultFee); " &
                           "SELECT LAST_INSERT_ID();"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@patientName", patientName},
            {"@patientID", patientID},
            {"@doctorName", doctorName},
            {"@verifiedID", verifiedID},
            {"@date", appointmentDate},
            {"@time", appointmentTime},
            {"@status", status},
            {"@notes", notes},
            {"@consultFee", consultFee}
        }

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                For Each param In parameters
                    cmd.Parameters.AddWithValue(param.Key, param.Value)
                Next
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return -1
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    Public Function GetAllAppointments() As DataTable
        Dim sql As String = "SELECT * FROM appointments ORDER BY date DESC, time DESC"
        Return Read(sql)
    End Function

    Public Function GetAppointmentsByPatientID(patientID As String) As DataTable
        Dim sql As String = "SELECT * FROM appointments WHERE patient_id = @patientID ORDER BY date DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@patientID", patientID}
        }
        Return ReadWithParameters(sql, parameters)
    End Function

    Public Function GetAppointmentsByDoctor(verifiedID As String) As DataTable
        Dim sql As String = "SELECT * FROM appointments WHERE Verified_ID = @verifiedID ORDER BY date DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@verifiedID", verifiedID}
        }
        Return ReadWithParameters(sql, parameters)
    End Function

    Public Function UpdateAppointmentStatus(appointmentID As Integer, status As String) As Boolean
        Dim sql As String = "UPDATE appointments SET status = @status WHERE appointment_id = @appointmentID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@status", status},
            {"@appointmentID", appointmentID}
        }
        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    Public Function UpdateAppointmentFee(appointmentID As Integer, consultFee As Decimal) As Boolean
        Dim sql As String = "UPDATE appointments SET consult_fee = @consultFee WHERE appointment_id = @appointmentID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@consultFee", consultFee},
            {"@appointmentID", appointmentID}
        }
        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    Public Function DeleteAppointment(appointmentID As Integer) As Boolean
        Dim sql As String = "DELETE FROM appointments WHERE appointment_id = @appointmentID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@appointmentID", appointmentID}
        }
        Return DeleteWithParameters("appointments", "appointment_id = @appointmentID", parameters)
    End Function

    ' ==================== CONSULTATION METHODS ====================
    Public Function InsertConsultation(patientName As String, patientID As String,
                                       symptoms As String, diagnosis As String,
                                       drugsPrescription As String, doctorName As String,
                                       verifiedID As String, consultDate As Date,
                                       consultTime As TimeSpan, notesFromAppointment As String,
                                       appointmentID As Integer) As Boolean
        Dim sql As String = "INSERT INTO consultation (Patient_Name, Patient_ID, Symptoms, Diagnosis, Drugs_Prescription, " &
                           "Doctor_Name, Verified_ID, Date, Time, Notes_From_Appointments, Appointment_ID) " &
                           "VALUES (@patientName, @patientID, @symptoms, @diagnosis, @drugsPrescription, " &
                           "@doctorName, @verifiedID, @date, @time, @notes, @appointmentID)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@patientName", patientName},
            {"@patientID", patientID},
            {"@symptoms", symptoms},
            {"@diagnosis", diagnosis},
            {"@drugsPrescription", drugsPrescription},
            {"@doctorName", doctorName},
            {"@verifiedID", verifiedID},
            {"@date", consultDate},
            {"@time", consultTime},
            {"@notes", notesFromAppointment},
            {"@appointmentID", appointmentID}
        }

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    Public Function GetAllConsultations() As DataTable
        Dim sql As String = "SELECT * FROM consultation ORDER BY Date DESC, Time DESC"
        Return Read(sql)
    End Function

    Public Function GetConsultationsByPatientID(patientID As String) As DataTable
        Dim sql As String = "SELECT * FROM consultation WHERE Patient_ID = @patientID ORDER BY Date DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@patientID", patientID}
        }
        Return ReadWithParameters(sql, parameters)
    End Function

    Public Function GetConsultationByID(consultID As Integer) As DataTable
        Dim sql As String = "SELECT * FROM consultation WHERE Consult_ID = @consultID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@consultID", consultID}
        }
        Return ReadWithParameters(sql, parameters)
    End Function

    ' ==================== PERSONNEL METHODS ====================
    Public Function InsertDoctor(personnelName As String, verifiedID As String,
                                password As String, role As String,
                                 contactNo As String, schedule As String) As Boolean
        Dim sql As String = "INSERT INTO personneltable (Personnel_Name, Verified_ID, Password, Role, ContactNo, Schedule) " &
                           "VALUES (@personnelName, @verifiedID, @password, @role, @contactNo, @schedule)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@personnelName", personnelName},
            {"@verifiedID", verifiedID},
            {"@password", password},
            {"@role", role},
            {"@contactNo", contactNo},
            {"@schedule", schedule}
        }

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    Public Function InsertStaff(personnelName As String, verifiedID As String,
                               password As String, role As String) As Boolean
        Dim sql As String = "INSERT INTO personneltable (Personnel_Name, Verified_ID, Password, Role) " &
                           "VALUES (@personnelName, @verifiedID, @password, @role)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@personnelName", personnelName},
            {"@verifiedID", verifiedID},
            {"@password", password},
            {"@role", role}
        }

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    Public Function GetAllPersonnel() As DataTable
        Dim sql As String = "SELECT * FROM personneltable ORDER BY Role, Personnel_Name"
        Return Read(sql)
    End Function

    Public Function GetPersonnelByVerifiedID(verifiedID As String) As DataTable
        Dim sql As String = "SELECT * FROM personneltable WHERE Verified_ID = @verifiedID"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@verifiedID", verifiedID}
        }
        Return ReadWithParameters(sql, parameters)
    End Function

    Public Function GetAllDoctors() As DataTable
        Dim sql As String = "SELECT * FROM personneltable WHERE Role = 'doctor' ORDER BY Personnel_Name"
        Return Read(sql)
    End Function

    ' ==================== GENERIC METHODS ====================
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

    Public Function ReadWithParameters(sql As String, parameters As Dictionary(Of String, Object)) As DataTable
        Dim dt As New DataTable()

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
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

    Public Function ExecuteNonQueryWithParameters(sql As String, parameters As Dictionary(Of String, Object)) As Integer
        Dim rowsAffected As Integer = 0

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
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

    Public Function Insert(tableName As String, parameters As Dictionary(Of String, Object)) As Boolean
        Dim columns As String = String.Join(", ", parameters.Keys)
        Dim values As String = String.Join(", ", parameters.Keys.Select(Function(k) "@" & k.Replace("@", "")))
        Dim sql As String = $"INSERT INTO {tableName} ({columns}) VALUES ({values})"

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    Public Function Update(tableName As String, parameters As Dictionary(Of String, Object), whereClause As String) As Boolean
        Dim setClause As String = String.Join(", ", parameters.Keys.Select(Function(k) $"{k} = @{k.Replace("@", "")}"))
        Dim sql As String = $"UPDATE {tableName} SET {setClause} WHERE {whereClause}"

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

    Public Function Delete(tableName As String, whereClause As String) As Boolean
        Dim sql As String = $"DELETE FROM {tableName} WHERE {whereClause}"

        Return ExecuteNonQuery(sql) > 0
    End Function

    Public Function DeleteWithParameters(tableName As String, whereClause As String, parameters As Dictionary(Of String, Object)) As Boolean
        Dim sql As String = $"DELETE FROM {tableName} WHERE {whereClause}"

        Return ExecuteNonQueryWithParameters(sql, parameters) > 0
    End Function

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

    Public Sub Dispose()
        If conn IsNot Nothing Then
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Dispose()
        End If
    End Sub

    ' Fetches the schedule string for a single doctor by their name
    Public Function GetDoctorScheduleByName(ByVal doctorName As String) As String
        Dim schedule As String = ""
        Try
            conn.Open()
            Dim query As String = "SELECT Schedule FROM personneltable WHERE Personnel_Name = @DoctorName LIMIT 1"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@DoctorName", doctorName)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    schedule = result.ToString()
                Else
                    schedule = "Not Found"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching doctor schedule: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            schedule = "Error"
        Finally
            conn.Close()
        End Try
        Return schedule
    End Function
End Class
