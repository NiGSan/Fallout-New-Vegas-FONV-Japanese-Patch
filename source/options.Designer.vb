<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class options
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(options))
        Me.FOSE_L = New System.Windows.Forms.Label()
        Me.FOSE_URL = New System.Windows.Forms.TextBox()
        Me.FOSE_HASH = New System.Windows.Forms.TextBox()
        Me.FOSE_L_H = New System.Windows.Forms.Label()
        Me.FO3JP_URL = New System.Windows.Forms.TextBox()
        Me.FO3JP_L = New System.Windows.Forms.Label()
        Me.FO3JP_HASH = New System.Windows.Forms.TextBox()
        Me.FO3JP_L_H = New System.Windows.Forms.Label()
        Me.update_check_button = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FOSE_L
        '
        Me.FOSE_L.AutoSize = True
        Me.FOSE_L.BackColor = System.Drawing.Color.Transparent
        Me.FOSE_L.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FOSE_L.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FOSE_L.Location = New System.Drawing.Point(10, 120)
        Me.FOSE_L.Name = "FOSE_L"
        Me.FOSE_L.Size = New System.Drawing.Size(142, 12)
        Me.FOSE_L.TabIndex = 0
        Me.FOSE_L.Text = "Fallout Script Extender (FOSE):"
        '
        'FOSE_URL
        '
        Me.FOSE_URL.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FOSE_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FOSE_URL.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FOSE_URL.ForeColor = System.Drawing.Color.Silver
        Me.FOSE_URL.Location = New System.Drawing.Point(12, 132)
        Me.FOSE_URL.Name = "FOSE_URL"
        Me.FOSE_URL.ReadOnly = True
        Me.FOSE_URL.Size = New System.Drawing.Size(535, 21)
        Me.FOSE_URL.TabIndex = 1
        '
        'FOSE_HASH
        '
        Me.FOSE_HASH.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FOSE_HASH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FOSE_HASH.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FOSE_HASH.ForeColor = System.Drawing.Color.Silver
        Me.FOSE_HASH.Location = New System.Drawing.Point(14, 168)
        Me.FOSE_HASH.Name = "FOSE_HASH"
        Me.FOSE_HASH.ReadOnly = True
        Me.FOSE_HASH.Size = New System.Drawing.Size(533, 21)
        Me.FOSE_HASH.TabIndex = 3
        '
        'FOSE_L_H
        '
        Me.FOSE_L_H.AutoSize = True
        Me.FOSE_L_H.BackColor = System.Drawing.Color.Transparent
        Me.FOSE_L_H.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FOSE_L_H.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FOSE_L_H.Location = New System.Drawing.Point(12, 156)
        Me.FOSE_L_H.Name = "FOSE_L_H"
        Me.FOSE_L_H.Size = New System.Drawing.Size(185, 12)
        Me.FOSE_L_H.TabIndex = 2
        Me.FOSE_L_H.Text = "Fallout Script Extender (FOSE) <HASH>:"
        '
        'FO3JP_URL
        '
        Me.FO3JP_URL.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FO3JP_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FO3JP_URL.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FO3JP_URL.ForeColor = System.Drawing.Color.Silver
        Me.FO3JP_URL.Location = New System.Drawing.Point(14, 204)
        Me.FO3JP_URL.Name = "FO3JP_URL"
        Me.FO3JP_URL.ReadOnly = True
        Me.FO3JP_URL.Size = New System.Drawing.Size(533, 21)
        Me.FO3JP_URL.TabIndex = 5
        '
        'FO3JP_L
        '
        Me.FO3JP_L.AutoSize = True
        Me.FO3JP_L.BackColor = System.Drawing.Color.Transparent
        Me.FO3JP_L.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FO3JP_L.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FO3JP_L.Location = New System.Drawing.Point(12, 192)
        Me.FO3JP_L.Name = "FO3JP_L"
        Me.FO3JP_L.Size = New System.Drawing.Size(139, 12)
        Me.FO3JP_L.TabIndex = 4
        Me.FO3JP_L.Text = "FO3日本語化まとめ(20141114):"
        '
        'FO3JP_HASH
        '
        Me.FO3JP_HASH.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FO3JP_HASH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FO3JP_HASH.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FO3JP_HASH.ForeColor = System.Drawing.Color.Silver
        Me.FO3JP_HASH.Location = New System.Drawing.Point(12, 240)
        Me.FO3JP_HASH.Name = "FO3JP_HASH"
        Me.FO3JP_HASH.ReadOnly = True
        Me.FO3JP_HASH.Size = New System.Drawing.Size(535, 21)
        Me.FO3JP_HASH.TabIndex = 7
        '
        'FO3JP_L_H
        '
        Me.FO3JP_L_H.AutoSize = True
        Me.FO3JP_L_H.BackColor = System.Drawing.Color.Transparent
        Me.FO3JP_L_H.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FO3JP_L_H.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FO3JP_L_H.Location = New System.Drawing.Point(10, 228)
        Me.FO3JP_L_H.Name = "FO3JP_L_H"
        Me.FO3JP_L_H.Size = New System.Drawing.Size(182, 12)
        Me.FO3JP_L_H.TabIndex = 6
        Me.FO3JP_L_H.Text = "FO3日本語化まとめ(20141114) <HASH>:"
        '
        'update_check_button
        '
        Me.update_check_button.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.update_check_button.ForeColor = System.Drawing.Color.White
        Me.update_check_button.Location = New System.Drawing.Point(442, 100)
        Me.update_check_button.Name = "update_check_button"
        Me.update_check_button.Size = New System.Drawing.Size(105, 26)
        Me.update_check_button.TabIndex = 8
        Me.update_check_button.Text = "更新チェック"
        Me.update_check_button.UseVisualStyleBackColor = False
        '
        'options
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(559, 269)
        Me.Controls.Add(Me.update_check_button)
        Me.Controls.Add(Me.FO3JP_HASH)
        Me.Controls.Add(Me.FO3JP_L_H)
        Me.Controls.Add(Me.FO3JP_URL)
        Me.Controls.Add(Me.FO3JP_L)
        Me.Controls.Add(Me.FOSE_HASH)
        Me.Controls.Add(Me.FOSE_L_H)
        Me.Controls.Add(Me.FOSE_URL)
        Me.Controls.Add(Me.FOSE_L)
        Me.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "options"
        Me.Text = "options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FOSE_L As Label
    Friend WithEvents FOSE_URL As TextBox
    Friend WithEvents FOSE_HASH As TextBox
    Friend WithEvents FOSE_L_H As Label
    Friend WithEvents FO3JP_URL As TextBox
    Friend WithEvents FO3JP_L As Label
    Friend WithEvents FO3JP_HASH As TextBox
    Friend WithEvents FO3JP_L_H As Label
    Friend WithEvents update_check_button As Button
End Class
