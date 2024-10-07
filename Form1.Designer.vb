<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Label1 = New Label()
        auditCtrl = New TabControl()
        TabPage1 = New TabPage()
        StatusStrip1 = New StatusStrip()
        tssTotal = New ToolStripStatusLabel()
        btnExport = New Button()
        dtpTo = New DateTimePicker()
        Label4 = New Label()
        dtpFr = New DateTimePicker()
        Label3 = New Label()
        cbTenantAudit = New ComboBox()
        Label2 = New Label()
        TabPage2 = New TabPage()
        GroupBox1 = New GroupBox()
        rtbError = New RichTextBox()
        btnLog = New Button()
        txtErrorId = New TextBox()
        Label6 = New Label()
        cbTenantLog = New ComboBox()
        Label5 = New Label()
        TabPage3 = New TabPage()
        btnVA = New Button()
        txtVA = New TextBox()
        Label7 = New Label()
        cbTenantVA = New ComboBox()
        Label8 = New Label()
        Timer1 = New Timer(components)
        auditCtrl.SuspendLayout()
        TabPage1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        TabPage2.SuspendLayout()
        GroupBox1.SuspendLayout()
        TabPage3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 30F, FontStyle.Bold)
        Label1.Location = New Point(36, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(296, 54)
        Label1.TabIndex = 0
        Label1.Text = "APP GA GUNA"
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' auditCtrl
        ' 
        auditCtrl.Controls.Add(TabPage1)
        auditCtrl.Controls.Add(TabPage2)
        auditCtrl.Controls.Add(TabPage3)
        auditCtrl.Location = New Point(1, 78)
        auditCtrl.Name = "auditCtrl"
        auditCtrl.SelectedIndex = 0
        auditCtrl.Size = New Size(366, 332)
        auditCtrl.TabIndex = 8
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(StatusStrip1)
        TabPage1.Controls.Add(btnExport)
        TabPage1.Controls.Add(dtpTo)
        TabPage1.Controls.Add(Label4)
        TabPage1.Controls.Add(dtpFr)
        TabPage1.Controls.Add(Label3)
        TabPage1.Controls.Add(cbTenantAudit)
        TabPage1.Controls.Add(Label2)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(358, 304)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Audit"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {tssTotal})
        StatusStrip1.Location = New Point(3, 279)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(352, 22)
        StatusStrip1.TabIndex = 12
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' tssTotal
        ' 
        tssTotal.Name = "tssTotal"
        tssTotal.Size = New Size(68, 17)
        tssTotal.Text = "Total Data : "
        ' 
        ' btnExport
        ' 
        btnExport.BackColor = Color.Red
        btnExport.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnExport.Location = New Point(250, 92)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(98, 30)
        btnExport.TabIndex = 11
        btnExport.Text = "GASSS"
        btnExport.UseVisualStyleBackColor = False
        ' 
        ' dtpTo
        ' 
        dtpTo.CustomFormat = "yyyy-mm-dd"
        dtpTo.Location = New Point(234, 53)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(114, 23)
        dtpTo.TabIndex = 10
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(200, 56)
        Label4.Name = "Label4"
        Label4.Size = New Size(19, 15)
        Label4.TabIndex = 9
        Label4.Text = "To"
        ' 
        ' dtpFr
        ' 
        dtpFr.CustomFormat = "yyyy-mm-dd"
        dtpFr.Location = New Point(71, 53)
        dtpFr.Name = "dtpFr"
        dtpFr.Size = New Size(114, 23)
        dtpFr.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 56)
        Label3.Name = "Label3"
        Label3.Size = New Size(35, 15)
        Label3.TabIndex = 7
        Label3.Text = "From"
        ' 
        ' cbTenantAudit
        ' 
        cbTenantAudit.FormattingEnabled = True
        cbTenantAudit.Location = New Point(71, 15)
        cbTenantAudit.Name = "cbTenantAudit"
        cbTenantAudit.Size = New Size(277, 23)
        cbTenantAudit.TabIndex = 4
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 18)
        Label2.Name = "Label2"
        Label2.Size = New Size(42, 15)
        Label2.TabIndex = 3
        Label2.Text = "Tenant"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(GroupBox1)
        TabPage2.Controls.Add(btnLog)
        TabPage2.Controls.Add(txtErrorId)
        TabPage2.Controls.Add(Label6)
        TabPage2.Controls.Add(cbTenantLog)
        TabPage2.Controls.Add(Label5)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(358, 304)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Log"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(rtbError)
        GroupBox1.Location = New Point(12, 120)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(336, 162)
        GroupBox1.TabIndex = 10
        GroupBox1.TabStop = False
        GroupBox1.Text = "Result"
        ' 
        ' rtbError
        ' 
        rtbError.Location = New Point(6, 22)
        rtbError.Name = "rtbError"
        rtbError.Size = New Size(324, 134)
        rtbError.TabIndex = 0
        rtbError.Text = ""
        ' 
        ' btnLog
        ' 
        btnLog.Location = New Point(273, 92)
        btnLog.Name = "btnLog"
        btnLog.Size = New Size(75, 23)
        btnLog.TabIndex = 9
        btnLog.Text = "Result"
        btnLog.UseVisualStyleBackColor = True
        ' 
        ' txtErrorId
        ' 
        txtErrorId.Location = New Point(71, 53)
        txtErrorId.Name = "txtErrorId"
        txtErrorId.Size = New Size(277, 23)
        txtErrorId.TabIndex = 8
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 56)
        Label6.Name = "Label6"
        Label6.Size = New Size(45, 15)
        Label6.TabIndex = 7
        Label6.Text = "Error Id"
        ' 
        ' cbTenantLog
        ' 
        cbTenantLog.FormattingEnabled = True
        cbTenantLog.Location = New Point(71, 15)
        cbTenantLog.Name = "cbTenantLog"
        cbTenantLog.Size = New Size(277, 23)
        cbTenantLog.TabIndex = 6
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 18)
        Label5.Name = "Label5"
        Label5.Size = New Size(42, 15)
        Label5.TabIndex = 5
        Label5.Text = "Tenant"
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(btnVA)
        TabPage3.Controls.Add(txtVA)
        TabPage3.Controls.Add(Label7)
        TabPage3.Controls.Add(cbTenantVA)
        TabPage3.Controls.Add(Label8)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(358, 304)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Check VA"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' btnVA
        ' 
        btnVA.Location = New Point(273, 92)
        btnVA.Name = "btnVA"
        btnVA.Size = New Size(75, 23)
        btnVA.TabIndex = 13
        btnVA.Text = "Check"
        btnVA.UseVisualStyleBackColor = True
        ' 
        ' txtVA
        ' 
        txtVA.Location = New Point(71, 53)
        txtVA.Name = "txtVA"
        txtVA.Size = New Size(277, 23)
        txtVA.TabIndex = 12
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(12, 56)
        Label7.Name = "Label7"
        Label7.Size = New Size(40, 15)
        Label7.TabIndex = 11
        Label7.Text = "No VA"
        ' 
        ' cbTenantVA
        ' 
        cbTenantVA.FormattingEnabled = True
        cbTenantVA.Location = New Point(71, 15)
        cbTenantVA.Name = "cbTenantVA"
        cbTenantVA.Size = New Size(277, 23)
        cbTenantVA.TabIndex = 10
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(12, 18)
        Label8.Name = "Label8"
        Label8.Size = New Size(42, 15)
        Label8.TabIndex = 9
        Label8.Text = "Tenant"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(365, 406)
        Controls.Add(auditCtrl)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Script Dynamo"
        auditCtrl.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents auditCtrl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnExport As Button
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpFr As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents cbTenantAudit As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cbTenantLog As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rtbError As RichTextBox
    Friend WithEvents btnLog As Button
    Friend WithEvents txtErrorId As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tssTotal As ToolStripStatusLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents txtVA As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbTenantVA As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnVA As Button

End Class
