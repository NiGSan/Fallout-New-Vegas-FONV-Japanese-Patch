<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cfg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cfg))
        Me.NVSE_URL_TXT = New System.Windows.Forms.Label()
        Me.NVSE_URL = New System.Windows.Forms.TextBox()
        Me.FOJP_URL = New System.Windows.Forms.TextBox()
        Me.FOJP_URL_TXT = New System.Windows.Forms.Label()
        Me.DLC_FOJP_URL = New System.Windows.Forms.TextBox()
        Me.DLC_URL_TXT = New System.Windows.Forms.Label()
        Me.FOJPN_URL = New System.Windows.Forms.TextBox()
        Me.FOJPN_URL_TXT = New System.Windows.Forms.Label()
        Me.DLC_MD5 = New System.Windows.Forms.TextBox()
        Me.DLC_MD5_TEXT = New System.Windows.Forms.Label()
        Me.FOJPN_MD5 = New System.Windows.Forms.TextBox()
        Me.FOJPN_MD5_TXT = New System.Windows.Forms.Label()
        Me.FOJP_MD5 = New System.Windows.Forms.TextBox()
        Me.FOJP_MD5_TXT = New System.Windows.Forms.Label()
        Me.NVSE_MD5 = New System.Windows.Forms.TextBox()
        Me.NVSE_MD5_TXT = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.NVSE_BETA_URL = New System.Windows.Forms.TextBox()
        Me.NVSE_BETA_URL_TXT = New System.Windows.Forms.Label()
        Me.NVSE_BETA_MD5 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'NVSE_URL_TXT
        '
        Me.NVSE_URL_TXT.AutoSize = True
        Me.NVSE_URL_TXT.BackColor = System.Drawing.Color.Transparent
        Me.NVSE_URL_TXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NVSE_URL_TXT.ForeColor = System.Drawing.Color.White
        Me.NVSE_URL_TXT.Location = New System.Drawing.Point(5, 123)
        Me.NVSE_URL_TXT.Name = "NVSE_URL_TXT"
        Me.NVSE_URL_TXT.Size = New System.Drawing.Size(183, 12)
        Me.NVSE_URL_TXT.TabIndex = 0
        Me.NVSE_URL_TXT.Text = "New Vegas Script Extender (NVSE) URL:"
        '
        'NVSE_URL
        '
        Me.NVSE_URL.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NVSE_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVSE_URL.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NVSE_URL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NVSE_URL.Location = New System.Drawing.Point(7, 138)
        Me.NVSE_URL.Name = "NVSE_URL"
        Me.NVSE_URL.Size = New System.Drawing.Size(243, 22)
        Me.NVSE_URL.TabIndex = 1
        '
        'FOJP_URL
        '
        Me.FOJP_URL.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FOJP_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FOJP_URL.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FOJP_URL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FOJP_URL.Location = New System.Drawing.Point(7, 212)
        Me.FOJP_URL.Name = "FOJP_URL"
        Me.FOJP_URL.Size = New System.Drawing.Size(243, 22)
        Me.FOJP_URL.TabIndex = 3
        '
        'FOJP_URL_TXT
        '
        Me.FOJP_URL_TXT.AutoSize = True
        Me.FOJP_URL_TXT.BackColor = System.Drawing.Color.Transparent
        Me.FOJP_URL_TXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FOJP_URL_TXT.ForeColor = System.Drawing.Color.White
        Me.FOJP_URL_TXT.Location = New System.Drawing.Point(5, 197)
        Me.FOJP_URL_TXT.Name = "FOJP_URL_TXT"
        Me.FOJP_URL_TXT.Size = New System.Drawing.Size(132, 12)
        Me.FOJP_URL_TXT.TabIndex = 2
        Me.FOJP_URL_TXT.Text = "Fallout Japanese (FOJP) URL:"
        '
        'DLC_FOJP_URL
        '
        Me.DLC_FOJP_URL.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DLC_FOJP_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DLC_FOJP_URL.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DLC_FOJP_URL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DLC_FOJP_URL.Location = New System.Drawing.Point(7, 286)
        Me.DLC_FOJP_URL.Name = "DLC_FOJP_URL"
        Me.DLC_FOJP_URL.Size = New System.Drawing.Size(243, 22)
        Me.DLC_FOJP_URL.TabIndex = 7
        '
        'DLC_URL_TXT
        '
        Me.DLC_URL_TXT.AutoSize = True
        Me.DLC_URL_TXT.BackColor = System.Drawing.Color.Transparent
        Me.DLC_URL_TXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DLC_URL_TXT.ForeColor = System.Drawing.Color.White
        Me.DLC_URL_TXT.Location = New System.Drawing.Point(5, 271)
        Me.DLC_URL_TXT.Name = "DLC_URL_TXT"
        Me.DLC_URL_TXT.Size = New System.Drawing.Size(77, 12)
        Me.DLC_URL_TXT.TabIndex = 6
        Me.DLC_URL_TXT.Text = "DLC用forjp URL:"
        '
        'FOJPN_URL
        '
        Me.FOJPN_URL.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FOJPN_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FOJPN_URL.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FOJPN_URL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FOJPN_URL.Location = New System.Drawing.Point(7, 249)
        Me.FOJPN_URL.Name = "FOJPN_URL"
        Me.FOJPN_URL.Size = New System.Drawing.Size(243, 22)
        Me.FOJPN_URL.TabIndex = 5
        '
        'FOJPN_URL_TXT
        '
        Me.FOJPN_URL_TXT.AutoSize = True
        Me.FOJPN_URL_TXT.BackColor = System.Drawing.Color.Transparent
        Me.FOJPN_URL_TXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FOJPN_URL_TXT.ForeColor = System.Drawing.Color.White
        Me.FOJPN_URL_TXT.Location = New System.Drawing.Point(5, 234)
        Me.FOJPN_URL_TXT.Name = "FOJPN_URL_TXT"
        Me.FOJPN_URL_TXT.Size = New System.Drawing.Size(175, 12)
        Me.FOJPN_URL_TXT.TabIndex = 4
        Me.FOJPN_URL_TXT.Text = "New Vegas 日本語翻訳作業所 (γ+) URL:"
        '
        'DLC_MD5
        '
        Me.DLC_MD5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DLC_MD5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DLC_MD5.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DLC_MD5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DLC_MD5.Location = New System.Drawing.Point(258, 286)
        Me.DLC_MD5.Name = "DLC_MD5"
        Me.DLC_MD5.Size = New System.Drawing.Size(225, 22)
        Me.DLC_MD5.TabIndex = 17
        '
        'DLC_MD5_TEXT
        '
        Me.DLC_MD5_TEXT.AutoSize = True
        Me.DLC_MD5_TEXT.BackColor = System.Drawing.Color.Transparent
        Me.DLC_MD5_TEXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DLC_MD5_TEXT.ForeColor = System.Drawing.Color.White
        Me.DLC_MD5_TEXT.Location = New System.Drawing.Point(256, 271)
        Me.DLC_MD5_TEXT.Name = "DLC_MD5_TEXT"
        Me.DLC_MD5_TEXT.Size = New System.Drawing.Size(85, 12)
        Me.DLC_MD5_TEXT.TabIndex = 16
        Me.DLC_MD5_TEXT.Text = "DLC用forjp HASH:"
        '
        'FOJPN_MD5
        '
        Me.FOJPN_MD5.BackColor = System.Drawing.Color.Black
        Me.FOJPN_MD5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FOJPN_MD5.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FOJPN_MD5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FOJPN_MD5.Location = New System.Drawing.Point(258, 249)
        Me.FOJPN_MD5.Name = "FOJPN_MD5"
        Me.FOJPN_MD5.ReadOnly = True
        Me.FOJPN_MD5.Size = New System.Drawing.Size(225, 21)
        Me.FOJPN_MD5.TabIndex = 15
        Me.FOJPN_MD5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FOJPN_MD5_TXT
        '
        Me.FOJPN_MD5_TXT.AutoSize = True
        Me.FOJPN_MD5_TXT.BackColor = System.Drawing.Color.Transparent
        Me.FOJPN_MD5_TXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FOJPN_MD5_TXT.ForeColor = System.Drawing.Color.White
        Me.FOJPN_MD5_TXT.Location = New System.Drawing.Point(256, 234)
        Me.FOJPN_MD5_TXT.Name = "FOJPN_MD5_TXT"
        Me.FOJPN_MD5_TXT.Size = New System.Drawing.Size(183, 12)
        Me.FOJPN_MD5_TXT.TabIndex = 14
        Me.FOJPN_MD5_TXT.Text = "New Vegas 日本語翻訳作業所 (γ+) HASH:"
        '
        'FOJP_MD5
        '
        Me.FOJP_MD5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FOJP_MD5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FOJP_MD5.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FOJP_MD5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.FOJP_MD5.Location = New System.Drawing.Point(258, 212)
        Me.FOJP_MD5.Name = "FOJP_MD5"
        Me.FOJP_MD5.Size = New System.Drawing.Size(225, 22)
        Me.FOJP_MD5.TabIndex = 13
        '
        'FOJP_MD5_TXT
        '
        Me.FOJP_MD5_TXT.AutoSize = True
        Me.FOJP_MD5_TXT.BackColor = System.Drawing.Color.Transparent
        Me.FOJP_MD5_TXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FOJP_MD5_TXT.ForeColor = System.Drawing.Color.White
        Me.FOJP_MD5_TXT.Location = New System.Drawing.Point(256, 197)
        Me.FOJP_MD5_TXT.Name = "FOJP_MD5_TXT"
        Me.FOJP_MD5_TXT.Size = New System.Drawing.Size(140, 12)
        Me.FOJP_MD5_TXT.TabIndex = 12
        Me.FOJP_MD5_TXT.Text = "Fallout Japanese (FOJP) HASH:"
        '
        'NVSE_MD5
        '
        Me.NVSE_MD5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NVSE_MD5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVSE_MD5.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NVSE_MD5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NVSE_MD5.Location = New System.Drawing.Point(256, 138)
        Me.NVSE_MD5.Name = "NVSE_MD5"
        Me.NVSE_MD5.Size = New System.Drawing.Size(225, 22)
        Me.NVSE_MD5.TabIndex = 11
        '
        'NVSE_MD5_TXT
        '
        Me.NVSE_MD5_TXT.AutoSize = True
        Me.NVSE_MD5_TXT.BackColor = System.Drawing.Color.Transparent
        Me.NVSE_MD5_TXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NVSE_MD5_TXT.ForeColor = System.Drawing.Color.White
        Me.NVSE_MD5_TXT.Location = New System.Drawing.Point(254, 123)
        Me.NVSE_MD5_TXT.Name = "NVSE_MD5_TXT"
        Me.NVSE_MD5_TXT.Size = New System.Drawing.Size(191, 12)
        Me.NVSE_MD5_TXT.TabIndex = 10
        Me.NVSE_MD5_TXT.Text = "New Vegas Script Extender (NVSE) HASH:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(400, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "閉じる(&C)"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'NVSE_BETA_URL
        '
        Me.NVSE_BETA_URL.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NVSE_BETA_URL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVSE_BETA_URL.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NVSE_BETA_URL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NVSE_BETA_URL.Location = New System.Drawing.Point(7, 175)
        Me.NVSE_BETA_URL.Name = "NVSE_BETA_URL"
        Me.NVSE_BETA_URL.Size = New System.Drawing.Size(243, 22)
        Me.NVSE_BETA_URL.TabIndex = 20
        '
        'NVSE_BETA_URL_TXT
        '
        Me.NVSE_BETA_URL_TXT.AutoSize = True
        Me.NVSE_BETA_URL_TXT.BackColor = System.Drawing.Color.Transparent
        Me.NVSE_BETA_URL_TXT.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NVSE_BETA_URL_TXT.ForeColor = System.Drawing.Color.White
        Me.NVSE_BETA_URL_TXT.Location = New System.Drawing.Point(5, 160)
        Me.NVSE_BETA_URL_TXT.Name = "NVSE_BETA_URL_TXT"
        Me.NVSE_BETA_URL_TXT.Size = New System.Drawing.Size(205, 12)
        Me.NVSE_BETA_URL_TXT.TabIndex = 19
        Me.NVSE_BETA_URL_TXT.Text = "New Vegas Script Extender Beta (NVSE) URL:"
        '
        'NVSE_BETA_MD5
        '
        Me.NVSE_BETA_MD5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.NVSE_BETA_MD5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NVSE_BETA_MD5.Font = New System.Drawing.Font("Microsoft MHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NVSE_BETA_MD5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NVSE_BETA_MD5.Location = New System.Drawing.Point(256, 175)
        Me.NVSE_BETA_MD5.Name = "NVSE_BETA_MD5"
        Me.NVSE_BETA_MD5.Size = New System.Drawing.Size(227, 22)
        Me.NVSE_BETA_MD5.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(254, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "New Vegas Script Extender Beta (NVSE) HASH:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(258, 97)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 23)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "正式バージョン更新確認"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(258, 66)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(217, 25)
        Me.Button3.TabIndex = 24
        Me.Button3.Text = "Pre-Release Version Check"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'cfg
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(493, 318)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.NVSE_BETA_MD5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NVSE_BETA_URL)
        Me.Controls.Add(Me.NVSE_BETA_URL_TXT)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DLC_MD5)
        Me.Controls.Add(Me.DLC_MD5_TEXT)
        Me.Controls.Add(Me.FOJPN_MD5)
        Me.Controls.Add(Me.FOJPN_MD5_TXT)
        Me.Controls.Add(Me.FOJP_MD5)
        Me.Controls.Add(Me.FOJP_MD5_TXT)
        Me.Controls.Add(Me.NVSE_MD5)
        Me.Controls.Add(Me.NVSE_MD5_TXT)
        Me.Controls.Add(Me.DLC_FOJP_URL)
        Me.Controls.Add(Me.DLC_URL_TXT)
        Me.Controls.Add(Me.FOJPN_URL)
        Me.Controls.Add(Me.FOJPN_URL_TXT)
        Me.Controls.Add(Me.FOJP_URL)
        Me.Controls.Add(Me.FOJP_URL_TXT)
        Me.Controls.Add(Me.NVSE_URL)
        Me.Controls.Add(Me.NVSE_URL_TXT)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "cfg"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NVSE_URL_TXT As System.Windows.Forms.Label
    Friend WithEvents NVSE_URL As System.Windows.Forms.TextBox
    Friend WithEvents FOJP_URL As System.Windows.Forms.TextBox
    Friend WithEvents FOJP_URL_TXT As System.Windows.Forms.Label
    Friend WithEvents DLC_FOJP_URL As System.Windows.Forms.TextBox
    Friend WithEvents DLC_URL_TXT As System.Windows.Forms.Label
    Friend WithEvents FOJPN_URL As System.Windows.Forms.TextBox
    Friend WithEvents FOJPN_URL_TXT As System.Windows.Forms.Label
    Friend WithEvents DLC_MD5 As System.Windows.Forms.TextBox
    Friend WithEvents DLC_MD5_TEXT As System.Windows.Forms.Label
    Friend WithEvents FOJPN_MD5 As System.Windows.Forms.TextBox
    Friend WithEvents FOJPN_MD5_TXT As System.Windows.Forms.Label
    Friend WithEvents FOJP_MD5 As System.Windows.Forms.TextBox
    Friend WithEvents FOJP_MD5_TXT As System.Windows.Forms.Label
    Friend WithEvents NVSE_MD5 As System.Windows.Forms.TextBox
    Friend WithEvents NVSE_MD5_TXT As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NVSE_BETA_URL As System.Windows.Forms.TextBox
    Friend WithEvents NVSE_BETA_URL_TXT As System.Windows.Forms.Label
    Friend WithEvents NVSE_BETA_MD5 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
