<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LDO
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LDO))
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.INI_CHK = New System.Windows.Forms.Timer(Me.components)
        Me.message_txt = New System.Windows.Forms.Label()
        Me.URL_DATA_ = New System.Windows.Forms.Timer(Me.components)
        Me.HASH_ = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(496, 5)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(44, 14)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "[閉じる]"
        '
        'INI_CHK
        '
        Me.INI_CHK.Interval = 1500
        '
        'message_txt
        '
        Me.message_txt.BackColor = System.Drawing.Color.Transparent
        Me.message_txt.Font = New System.Drawing.Font("Meiryo UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.message_txt.ForeColor = System.Drawing.Color.White
        Me.message_txt.Location = New System.Drawing.Point(28, 254)
        Me.message_txt.Name = "message_txt"
        Me.message_txt.Size = New System.Drawing.Size(502, 21)
        Me.message_txt.TabIndex = 1
        Me.message_txt.Text = "現在読み込んでいます。お待ち下さい..."
        Me.message_txt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'URL_DATA_
        '
        Me.URL_DATA_.Interval = 1500
        '
        'HASH_
        '
        Me.HASH_.Interval = 500
        '
        'LDO
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(548, 296)
        Me.ControlBox = False
        Me.Controls.Add(Me.message_txt)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LDO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LDO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents INI_CHK As Timer
    Friend WithEvents message_txt As Label
    Friend WithEvents URL_DATA_ As Timer
    Friend WithEvents HASH_ As Timer
End Class
