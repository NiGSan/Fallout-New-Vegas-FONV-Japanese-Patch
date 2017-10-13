<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mains
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mains))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Path_pass = New System.Windows.Forms.TextBox()
        Me.Path_tex = New System.Windows.Forms.Label()
        Me.ViewerButton = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.ProgressPars = New System.Windows.Forms.Label()
        Me.DownloadButtons = New System.Windows.Forms.Button()
        Me.EventTxT = New System.Windows.Forms.Label()
        Me.JPButtons = New System.Windows.Forms.Button()
        Me.UnlockButton = New System.Windows.Forms.Timer(Me.components)
        Me.Version_text = New System.Windows.Forms.Label()
        Me.UnistallButtons = New System.Windows.Forms.Button()
        Me.re_download_pabnel = New System.Windows.Forms.Panel()
        Me.UnInstall_1 = New System.Windows.Forms.Timer(Me.components)
        Me.NVSE_DEL_X = New System.Windows.Forms.CheckBox()
        Me.UnInstall_2 = New System.Windows.Forms.Timer(Me.components)
        Me.UnInstall_3 = New System.Windows.Forms.Timer(Me.components)
        Me.UnInstall_End = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.optionButtons = New System.Windows.Forms.Button()
        Me.offline_mode_1 = New System.Windows.Forms.LinkLabel()
        Me.WarningHide = New System.Windows.Forms.Timer(Me.components)
        Me.NVSE_DEL = New System.Windows.Forms.CheckBox()
        Me.Hashsan = New System.Windows.Forms.CheckBox()
        Me.NVSE_checks = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.SteelBlue
        Me.ProgressBar1.Location = New System.Drawing.Point(4, 246)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(537, 16)
        Me.ProgressBar1.TabIndex = 0
        '
        'Path_pass
        '
        Me.Path_pass.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Path_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Path_pass.Enabled = False
        Me.Path_pass.ForeColor = System.Drawing.Color.White
        Me.Path_pass.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Path_pass.Location = New System.Drawing.Point(4, 17)
        Me.Path_pass.Name = "Path_pass"
        Me.Path_pass.ReadOnly = True
        Me.Path_pass.Size = New System.Drawing.Size(498, 21)
        Me.Path_pass.TabIndex = 1
        Me.Path_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Path_tex
        '
        Me.Path_tex.AutoSize = True
        Me.Path_tex.BackColor = System.Drawing.Color.Transparent
        Me.Path_tex.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Path_tex.ForeColor = System.Drawing.Color.White
        Me.Path_tex.Location = New System.Drawing.Point(2, 2)
        Me.Path_tex.Name = "Path_tex"
        Me.Path_tex.Size = New System.Drawing.Size(109, 12)
        Me.Path_tex.TabIndex = 2
        Me.Path_tex.Text = "Fallout New Vegas Path:"
        '
        'ViewerButton
        '
        Me.ViewerButton.BackgroundImage = CType(resources.GetObject("ViewerButton.BackgroundImage"), System.Drawing.Image)
        Me.ViewerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ViewerButton.Location = New System.Drawing.Point(506, 17)
        Me.ViewerButton.Name = "ViewerButton"
        Me.ViewerButton.Size = New System.Drawing.Size(35, 21)
        Me.ViewerButton.TabIndex = 3
        Me.ViewerButton.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(448, 2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(96, 15)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "DLCを適用する"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
        Me.CheckBox2.Location = New System.Drawing.Point(305, 2)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(137, 15)
        Me.CheckBox2.TabIndex = 5
        Me.CheckBox2.Text = "ターミナル日本語化適用"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'ProgressPars
        '
        Me.ProgressPars.AutoSize = True
        Me.ProgressPars.BackColor = System.Drawing.Color.SteelBlue
        Me.ProgressPars.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ProgressPars.ForeColor = System.Drawing.Color.White
        Me.ProgressPars.Location = New System.Drawing.Point(8, 248)
        Me.ProgressPars.Name = "ProgressPars"
        Me.ProgressPars.Size = New System.Drawing.Size(26, 12)
        Me.ProgressPars.TabIndex = 6
        Me.ProgressPars.Text = "---%"
        Me.ProgressPars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ProgressPars.Visible = False
        '
        'DownloadButtons
        '
        Me.DownloadButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DownloadButtons.ForeColor = System.Drawing.Color.White
        Me.DownloadButtons.Location = New System.Drawing.Point(4, 198)
        Me.DownloadButtons.Name = "DownloadButtons"
        Me.DownloadButtons.Size = New System.Drawing.Size(138, 42)
        Me.DownloadButtons.TabIndex = 7
        Me.DownloadButtons.Text = "Download" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(NVSE/FOJP/翻訳)"
        Me.DownloadButtons.UseVisualStyleBackColor = False
        '
        'EventTxT
        '
        Me.EventTxT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.EventTxT.AutoEllipsis = True
        Me.EventTxT.BackColor = System.Drawing.Color.Transparent
        Me.EventTxT.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.EventTxT.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.EventTxT.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.EventTxT.Location = New System.Drawing.Point(19, 146)
        Me.EventTxT.Name = "EventTxT"
        Me.EventTxT.Size = New System.Drawing.Size(512, 32)
        Me.EventTxT.TabIndex = 11
        Me.EventTxT.Text = "..."
        Me.EventTxT.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'JPButtons
        '
        Me.JPButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.JPButtons.Enabled = False
        Me.JPButtons.ForeColor = System.Drawing.Color.White
        Me.JPButtons.Location = New System.Drawing.Point(148, 198)
        Me.JPButtons.Name = "JPButtons"
        Me.JPButtons.Size = New System.Drawing.Size(124, 42)
        Me.JPButtons.TabIndex = 13
        Me.JPButtons.Text = "日本語化を適用する" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(ダウンロードしてください)"
        Me.JPButtons.UseVisualStyleBackColor = False
        '
        'UnlockButton
        '
        Me.UnlockButton.Interval = 3000
        '
        'Version_text
        '
        Me.Version_text.AutoSize = True
        Me.Version_text.BackColor = System.Drawing.Color.Transparent
        Me.Version_text.ForeColor = System.Drawing.Color.White
        Me.Version_text.Location = New System.Drawing.Point(44, 281)
        Me.Version_text.Name = "Version_text"
        Me.Version_text.Size = New System.Drawing.Size(455, 14)
        Me.Version_text.TabIndex = 15
        Me.Version_text.Text = "Japanese Patch Version 2.1 | FOJP2 v4.6 | NVSE 4.5 | 日本語翻訳作業所（常時最新)"
        '
        'UnistallButtons
        '
        Me.UnistallButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.UnistallButtons.Enabled = False
        Me.UnistallButtons.ForeColor = System.Drawing.Color.White
        Me.UnistallButtons.Location = New System.Drawing.Point(278, 198)
        Me.UnistallButtons.Name = "UnistallButtons"
        Me.UnistallButtons.Size = New System.Drawing.Size(124, 42)
        Me.UnistallButtons.TabIndex = 17
        Me.UnistallButtons.Text = "アンインストール" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(パスを指定して下さい)"
        Me.UnistallButtons.UseVisualStyleBackColor = False
        '
        're_download_pabnel
        '
        Me.re_download_pabnel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.re_download_pabnel.BackColor = System.Drawing.Color.Transparent
        Me.re_download_pabnel.Enabled = False
        Me.re_download_pabnel.Location = New System.Drawing.Point(152, 50)
        Me.re_download_pabnel.Name = "re_download_pabnel"
        Me.re_download_pabnel.Size = New System.Drawing.Size(26, 19)
        Me.re_download_pabnel.TabIndex = 18
        '
        'UnInstall_1
        '
        '
        'NVSE_DEL_X
        '
        Me.NVSE_DEL_X.AutoSize = True
        Me.NVSE_DEL_X.BackColor = System.Drawing.Color.Transparent
        Me.NVSE_DEL_X.Checked = True
        Me.NVSE_DEL_X.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NVSE_DEL_X.Enabled = False
        Me.NVSE_DEL_X.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NVSE_DEL_X.ForeColor = System.Drawing.Color.White
        Me.NVSE_DEL_X.Location = New System.Drawing.Point(423, 180)
        Me.NVSE_DEL_X.Name = "NVSE_DEL_X"
        Me.NVSE_DEL_X.Size = New System.Drawing.Size(110, 15)
        Me.NVSE_DEL_X.TabIndex = 19
        Me.NVSE_DEL_X.Text = "NVSEを削除しない"
        Me.NVSE_DEL_X.UseVisualStyleBackColor = False
        '
        'UnInstall_2
        '
        '
        'UnInstall_3
        '
        '
        'UnInstall_End
        '
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 267)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(547, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Japanese Patch Version 3.7 | FOJP2 v4.6 | NVSE 5.0b2/5.0b3 | 日本語翻訳作業所（最終版)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'optionButtons
        '
        Me.optionButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.optionButtons.ForeColor = System.Drawing.Color.White
        Me.optionButtons.Location = New System.Drawing.Point(408, 197)
        Me.optionButtons.Name = "optionButtons"
        Me.optionButtons.Size = New System.Drawing.Size(133, 42)
        Me.optionButtons.TabIndex = 26
        Me.optionButtons.Text = "設定" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(OPTION)"
        Me.optionButtons.UseVisualStyleBackColor = False
        '
        'offline_mode_1
        '
        Me.offline_mode_1.BackColor = System.Drawing.Color.Transparent
        Me.offline_mode_1.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.offline_mode_1.LinkColor = System.Drawing.Color.Teal
        Me.offline_mode_1.Location = New System.Drawing.Point(112, 1)
        Me.offline_mode_1.Name = "offline_mode_1"
        Me.offline_mode_1.Size = New System.Drawing.Size(85, 14)
        Me.offline_mode_1.TabIndex = 27
        Me.offline_mode_1.TabStop = True
        Me.offline_mode_1.Text = "オフラインモード"
        Me.offline_mode_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WarningHide
        '
        Me.WarningHide.Interval = 10000
        '
        'NVSE_DEL
        '
        Me.NVSE_DEL.AutoSize = True
        Me.NVSE_DEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NVSE_DEL.Location = New System.Drawing.Point(111, 4)
        Me.NVSE_DEL.Name = "NVSE_DEL"
        Me.NVSE_DEL.Size = New System.Drawing.Size(12, 11)
        Me.NVSE_DEL.TabIndex = 32
        Me.NVSE_DEL.UseVisualStyleBackColor = True
        Me.NVSE_DEL.Visible = False
        '
        'Hashsan
        '
        Me.Hashsan.AutoSize = True
        Me.Hashsan.BackColor = System.Drawing.Color.Transparent
        Me.Hashsan.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Hashsan.ForeColor = System.Drawing.Color.White
        Me.Hashsan.Location = New System.Drawing.Point(303, 180)
        Me.Hashsan.Name = "Hashsan"
        Me.Hashsan.Size = New System.Drawing.Size(114, 15)
        Me.Hashsan.TabIndex = 33
        Me.Hashsan.Text = "整合性チェック無視"
        Me.Hashsan.UseVisualStyleBackColor = False
        '
        'NVSE_checks
        '
        Me.NVSE_checks.AutoSize = True
        Me.NVSE_checks.BackColor = System.Drawing.Color.Transparent
        Me.NVSE_checks.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NVSE_checks.ForeColor = System.Drawing.Color.White
        Me.NVSE_checks.Location = New System.Drawing.Point(156, 180)
        Me.NVSE_checks.Name = "NVSE_checks"
        Me.NVSE_checks.Size = New System.Drawing.Size(143, 15)
        Me.NVSE_checks.TabIndex = 34
        Me.NVSE_checks.Text = "NVSEベータ版を利用する" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.NVSE_checks.UseVisualStyleBackColor = False
        '
        'mains
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(547, 280)
        Me.Controls.Add(Me.offline_mode_1)
        Me.Controls.Add(Me.NVSE_checks)
        Me.Controls.Add(Me.Hashsan)
        Me.Controls.Add(Me.NVSE_DEL)
        Me.Controls.Add(Me.EventTxT)
        Me.Controls.Add(Me.optionButtons)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NVSE_DEL_X)
        Me.Controls.Add(Me.re_download_pabnel)
        Me.Controls.Add(Me.UnistallButtons)
        Me.Controls.Add(Me.Version_text)
        Me.Controls.Add(Me.JPButtons)
        Me.Controls.Add(Me.DownloadButtons)
        Me.Controls.Add(Me.ProgressPars)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ViewerButton)
        Me.Controls.Add(Me.Path_tex)
        Me.Controls.Add(Me.Path_pass)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "mains"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fallout: New Vegas Japanese Patch 3.6"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Path_pass As System.Windows.Forms.TextBox
    Friend WithEvents Path_tex As System.Windows.Forms.Label
    Friend WithEvents ViewerButton As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressPars As System.Windows.Forms.Label
    Friend WithEvents DownloadButtons As System.Windows.Forms.Button
    Friend WithEvents EventTxT As System.Windows.Forms.Label
    Friend WithEvents JPButtons As System.Windows.Forms.Button
    Friend WithEvents UnlockButton As System.Windows.Forms.Timer
    Friend WithEvents Version_text As System.Windows.Forms.Label
    Friend WithEvents UnistallButtons As System.Windows.Forms.Button
    Friend WithEvents re_download_pabnel As System.Windows.Forms.Panel
    Friend WithEvents UnInstall_1 As System.Windows.Forms.Timer
    Friend WithEvents NVSE_DEL_X As System.Windows.Forms.CheckBox
    Friend WithEvents UnInstall_2 As System.Windows.Forms.Timer
    Friend WithEvents UnInstall_3 As System.Windows.Forms.Timer
    Friend WithEvents UnInstall_End As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents optionButtons As System.Windows.Forms.Button
    Friend WithEvents offline_mode_1 As System.Windows.Forms.LinkLabel
    Friend WithEvents WarningHide As System.Windows.Forms.Timer
    Friend WithEvents NVSE_DEL As System.Windows.Forms.CheckBox
    Friend WithEvents Hashsan As System.Windows.Forms.CheckBox
    Friend WithEvents NVSE_checks As System.Windows.Forms.CheckBox

End Class
