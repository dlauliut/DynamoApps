Imports Amazon.DynamoDBv2
Imports Amazon.DynamoDBv2.DocumentModel
Imports Amazon.DynamoDBv2.Model
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports OfficeOpenXml

Public Class Form1
    Dim dtTenant As System.Data.DataTable
    Dim client As AmazonDynamoDBClient
    Dim documentList As New List(Of Document)()
    Dim nameWS As String = "Data"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TenantData.connect()
        dtpFr.Format = DateTimePickerFormat.Custom
        dtpFr.CustomFormat = "dd-MMM-yyyy"

        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd-MMM-yyyy"

        Dim query As String = "select c.name, w.uuid from customers c join websites w On c.id = w.customer_id where c.deleted_at isnull And w.deleted_at isnull order by c.name"
        dtTenant = TenantData.generateResultSet(query)
        If (dtTenant Is Nothing) Then
            MsgBox("No Record")
        Else
            cbTenantAudit.DataSource = dtTenant
            cbTenantAudit.DisplayMember = "Name"
            cbTenantAudit.ValueMember = "uuid"

            cbTenantLog.DataSource = dtTenant
            cbTenantLog.DisplayMember = "Name"
            cbTenantLog.ValueMember = "uuid"

            cbTenantVA.DataSource = dtTenant
            cbTenantVA.DisplayMember = "Name"
            cbTenantVA.ValueMember = "uuid"
        End If
        settingForm(True)
    End Sub
    Public Async Function GetDataAudit() As Task(Of List(Of Document))
        Dim queryReq As New QueryRequest()
        Dim lastKeyEvaluated As Dictionary(Of String, AttributeValue) = Nothing
        Dim response As New AmazonDynamoDBClient
        documentList.Clear()

        Do
            With queryReq
                .TableName = "sokrates-audit-production"
                .KeyConditionExpression = "pk = :pkvalue"
                .FilterExpression = "attribute_not_exists(deleted_at) and created_at between :startdt and :enddt"
                .ExclusiveStartKey = lastKeyEvaluated
                .ExpressionAttributeValues = New Dictionary(Of String, AttributeValue)() From
                    {
                        {":pkvalue", New AttributeValue With {.S = "TENANT#" + cbTenantAudit.SelectedValue}},
                        {":startdt", New AttributeValue With {.S = dtpFr.Value.ToString("yyyy-MM-dd")}},
                        {":enddt", New AttributeValue With {.S = dtpTo.Value.ToString("yyyy-MM-dd")}}
                    }
                '//yyyy-mm-dd
            End With

            Dim res = Await response.QueryAsync(queryReq)

            For Each item As Dictionary(Of String, AttributeValue) In res.Items
                Dim documentData As New Dictionary(Of String, DynamoDBEntry)()

                For Each kvp As KeyValuePair(Of String, AttributeValue) In item
                    'documentData.Add(kvp.Key, New Primitive(kvp.Value.S))
                    Select Case True
                        Case kvp.Value.S IsNot Nothing
                            documentData.Add(kvp.Key, New Primitive(kvp.Value.S))
                        Case kvp.Value.N IsNot Nothing
                            documentData.Add(kvp.Key, New Primitive(kvp.Value.N))
                        'Case kvp.Value.BOOL
                        '    documentData(kvp.Key) = kvp.Value.BOOL
                        Case kvp.Value.M IsNot Nothing
                            documentData.Add(kvp.Key, New Primitive(kvp.Value.M.ToString))
                        Case kvp.Value.L IsNot Nothing
                            documentData.Add(kvp.Key, New Primitive(kvp.Value.L.ToString))
                        Case kvp.Value.NULL
                            documentData.Add(kvp.Key, String.Empty)
                    End Select
                Next
                Dim document As New Document(documentData)

                documentList.Add(document)
            Next

            lastKeyEvaluated = res.LastEvaluatedKey

        Loop While lastKeyEvaluated IsNot Nothing AndAlso lastKeyEvaluated.Count <> 0
        Return documentList
    End Function
    Public Async Function GetDataLog() As Task(Of List(Of Document))
        Dim queryReq As New QueryRequest()
        Dim lastKeyEvaluated As Dictionary(Of String, AttributeValue) = Nothing
        Dim response As New AmazonDynamoDBClient
        documentList.Clear()

        Do
            With queryReq
                .TableName = "sokrates-log-prod"
                .KeyConditionExpression = "pk = :pkvalue AND begins_with(sk, :skValue)"
                .FilterExpression = "attribute_not_exists(deleted_at)"
                .ExclusiveStartKey = lastKeyEvaluated
                .ExpressionAttributeValues = New Dictionary(Of String, AttributeValue)() From
                    {
                        {":pkvalue", New AttributeValue With {.S = "TENANT#" + cbTenantLog.SelectedValue + "#LOG_ERROR"}},
                        {":skValue", New AttributeValue With {.S = "ERROR_ID#" + txtErrorId.Text}}
                    }
            End With

            Dim res = Await response.QueryAsync(queryReq)

            For Each item As Dictionary(Of String, AttributeValue) In res.Items
                Dim documentData As New Dictionary(Of String, DynamoDBEntry)()

                For Each kvp As KeyValuePair(Of String, AttributeValue) In item
                    documentData.Add(kvp.Key, New Primitive(kvp.Value.S))
                Next
                Dim document As New Document(documentData)

                documentList.Add(document)
            Next

            lastKeyEvaluated = res.LastEvaluatedKey

        Loop While lastKeyEvaluated IsNot Nothing AndAlso lastKeyEvaluated.Count <> 0
        Return documentList
    End Function
    Private Async Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            settingForm(False)
            btnExport.BackColor = Color.DarkGray
            tssTotal.Text = "Total Data : Loading..."

            Await GetDataAudit()

            tssTotal.Text = "Total Data : " + documentList.Count.ToString()
            Await Task.Delay(1000)

            If documentList.Count > 0 Then
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                Dim filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output" + cbTenantAudit.Text + ".xlsx")
                Using package As New ExcelPackage(New FileInfo(filePath))
                    Dim headers = documentList(0).Keys.ToArray()
                    Dim maxRowsPerSheet = 1000000
                    Dim sheetIndex = 1
                    Dim totalRows = documentList.Count
                    Dim rowIndex = 0

                    While rowIndex < totalRows
                        Dim worksheetName = "Data" & sheetIndex.ToString()
                        Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add(nameWS)

                        ' Tulis header ke dalam file Excel
                        For i As Integer = 0 To headers.Length - 1
                            worksheet.Cells(1, i + 1).Value = headers(i)
                        Next

                        Dim currentSheetRowIndex = 2

                        ' Tambahkan data dari JSON ke dalam file Excel
                        While rowIndex < totalRows And currentSheetRowIndex <= maxRowsPerSheet
                            Dim rowData = documentList(rowIndex)
                            For colIndex = 0 To headers.Length - 1
                                Dim key = headers(colIndex)
                                Dim value As Object = If(rowData.ContainsKey(key), rowData(key), Nothing)
                                worksheet.Cells(currentSheetRowIndex, colIndex + 1).Value = If(value IsNot Nothing, value.ToString(), "")
                            Next
                            rowIndex += 1
                            currentSheetRowIndex += 1
                        End While

                        sheetIndex += 1
                    End While

                    ' Simpan file Excel
                    Using stream As New FileStream(filePath, FileMode.Create)
                        package.SaveAs(stream)
                    End Using
                End Using

                MsgBox("File ada di : " + filePath, MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "Success")
            Else
                MsgBox("Tidak ada data", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "No Data")
            End If

        Catch ex As OutOfMemoryException
            MsgBox("Terjadi kesalahan: Memori tidak cukup. Coba dikurangin tanggal tarikan datanya", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Error")
            tssTotal.Text = "Total Data :"
        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " + ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Error")
            tssTotal.Text = "Total Data :"
        Finally
            settingForm(True)
            btnExport.BackColor = Color.Red
        End Try
    End Sub
    Private Async Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        settingForm(False)
        btnLog.Text = "Loading..."
        rtbError.Text = Nothing

        If txtErrorId.Text <> "" Then
            Await GetDataLog()
        Else
            MsgBox("Error ID tolong di isi dulu PAK BOSS", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "ERROR")
            settingForm(True)
            btnLog.Text = "Result"
            Exit Sub
        End If

        If documentList.Count > 0 Then
            rtbError.Text = documentList(0).ToJsonPretty
            'rtbError.Text = documentList(0).Values(4).ToString
        Else
            rtbError.Text = "[]"
        End If


        settingForm(True)
        btnLog.Text = "Result"
    End Sub
    Private Async Sub btnVA_Click(sender As Object, e As EventArgs) Handles btnVA.Click
        settingForm(False)
        btnVA.Text = "Loading..."
        'rtbError.Text = Nothing

        If txtVA.Text <> "" Then
            Await GetDataLog()
        Else
            MsgBox("Nomor VA tolong di isi dulu PAK BOSS", MsgBoxStyle.OkOnly And MsgBoxStyle.Information, "ERROR")
            settingForm(True)
            btnVA.Text = "Check"
            Exit Sub
        End If

        'If documentList.Count > 0 Then
        '    rtbError.Text = documentList(0).ToJsonPretty
        'Else
        '    rtbError.Text = "[]"
        'End If


        settingForm(True)
        btnVA.Text = "Check"
    End Sub
    Sub settingForm(ByVal status As Boolean)
        'TAB AUDIT
        cbTenantAudit.Enabled = status
        dtpFr.Enabled = status
        dtpTo.Enabled = status
        btnExport.Enabled = status

        'TAB LOG
        cbTenantLog.Enabled = status
        txtErrorId.Enabled = status
        btnLog.Enabled = status
        rtbError.Enabled = status

        'TAB CHECK VA
        cbTenantVA.Enabled = status
        txtVA.Enabled = status
        btnVA.Enabled = status
        'rtbError.Enabled = status
    End Sub
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


End Class
