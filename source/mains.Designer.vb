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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mains))
        Me.version_tx = New System.Windows.Forms.Label()
        Me.ProBar = New System.Windows.Forms.ProgressBar()
        Me.DownloadButton = New System.Windows.Forms.Button()
        Me.JPButton = New System.Windows.Forms.Button()
        Me.UnInstallButton = New System.Windows.Forms.Button()
        Me.OptiButton = New System.Windows.Forms.Button()
        Me.fose_1_3 = New System.Windows.Forms.CheckBox()
        Me.dl_not = New System.Windows.Forms.CheckBox()
        Me.fose_not = New System.Windows.Forms.CheckBox()
        Me.now_tx = New System.Windows.Forms.Label()
        Me.path_txt = New System.Windows.Forms.Label()
        Me.ProgressPars = New System.Windows.Forms.Label()
        Me.ViewerButton = New System.Windows.Forms.Button()
        Me.paths = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'version_tx
        '
        Me.version_tx.BackColor = System.Drawing.Color.Transparent
        Me.version_tx.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.version_tx.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.version_tx.ForeColor = System.Drawing.Color.White
        Me.version_tx.Location = New System.Drawing.Point(0, 279)
        Me.version_tx.Name = "version_tx"
        Me.version_tx.Size = New System.Drawing.Size(541, 16)
        Me.version_tx.TabIndex = 0
        Me.version_tx.Text = "Japanese Patch Version 1.0 | FO3JP 20141114 | FOSE v1.2/v1.3 "
        Me.version_tx.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ProBar
        '
        Me.ProBar.Location = New System.Drawing.Point(12, 262)
        Me.ProBar.Name = "ProBar"
        Me.ProBar.Size = New System.Drawing.Size(517, 17)
        Me.ProBar.TabIndex = 1
        '
        'DownloadButton
        '
        Me.DownloadButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.DownloadButton.ForeColor = System.Drawing.Color.White
        Me.DownloadButton.Location = New System.Drawing.Point(228, 24)
        Me.DownloadButton.Name = "DownloadButton"
        Me.DownloadButton.Size = New System.Drawing.Size(148, 40)
        Me.DownloadButton.TabIndex = 2
        Me.DownloadButton.Text = "Download" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(FO3JP/FOSE)"
        Me.DownloadButton.UseVisualStyleBackColor = False
        '
        'JPButton
        '
        Me.JPButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.JPButton.Enabled = False
        Me.JPButton.ForeColor = System.Drawing.Color.White
        Me.JPButton.Location = New System.Drawing.Point(382, 24)
        Me.JPButton.Name = "JPButton"
        Me.JPButton.Size = New System.Drawing.Size(148, 40)
        Me.JPButton.TabIndex = 3
        Me.JPButton.Text = "日本語化を適用する" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(ダウンロードしてください)"
        Me.JPButton.UseVisualStyleBackColor = False
        '
        'UnInstallButton
        '
        Me.UnInstallButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.UnInstallButton.Enabled = False
        Me.UnInstallButton.ForeColor = System.Drawing.Color.White
        Me.UnInstallButton.Location = New System.Drawing.Point(228, 67)
        Me.UnInstallButton.Name = "UnInstallButton"
        Me.UnInstallButton.Size = New System.Drawing.Size(148, 40)
        Me.UnInstallButton.TabIndex = 4
        Me.UnInstallButton.Text = "アンインストールする" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(パスを指定してください)"
        Me.UnInstallButton.UseVisualStyleBackColor = False
        '
        'OptiButton
        '
        Me.OptiButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.OptiButton.ForeColor = System.Drawing.Color.White
        Me.OptiButton.Location = New System.Drawing.Point(382, 67)
        Me.OptiButton.Name = "OptiButton"
        Me.OptiButton.Size = New System.Drawing.Size(148, 40)
        Me.OptiButton.TabIndex = 5
        Me.OptiButton.Text = "設定" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(OPTION)"
        Me.OptiButton.UseVisualStyleBackColor = False
        '
        'fose_1_3
        '
        Me.fose_1_3.AutoSize = True
        Me.fose_1_3.BackColor = System.Drawing.Color.Transparent
        Me.fose_1_3.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.fose_1_3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.fose_1_3.Location = New System.Drawing.Point(228, 108)
        Me.fose_1_3.Name = "fose_1_3"
        Me.fose_1_3.Size = New System.Drawing.Size(112, 15)
        Me.fose_1_3.TabIndex = 6
        Me.fose_1_3.Text = "FOSE1.3を利用する"
        Me.fose_1_3.UseVisualStyleBackColor = False
        '
        'dl_not
        '
        Me.dl_not.AutoSize = True
        Me.dl_not.BackColor = System.Drawing.Color.Transparent
        Me.dl_not.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dl_not.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dl_not.Location = New System.Drawing.Point(339, 108)
        Me.dl_not.Name = "dl_not"
        Me.dl_not.Size = New System.Drawing.Size(104, 15)
        Me.dl_not.TabIndex = 7
        Me.dl_not.Text = "整合性を無視する"
        Me.dl_not.UseVisualStyleBackColor = False
        '
        'fose_not
        '
        Me.fose_not.AutoSize = True
        Me.fose_not.BackColor = System.Drawing.Color.Transparent
        Me.fose_not.Enabled = False
        Me.fose_not.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.fose_not.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.fose_not.Location = New System.Drawing.Point(445, 108)
        Me.fose_not.Name = "fose_not"
        Me.fose_not.Size = New System.Drawing.Size(92, 15)
        Me.fose_not.TabIndex = 8
        Me.fose_not.Text = "FOSEを非削除"
        Me.fose_not.UseVisualStyleBackColor = False
        '
        'now_tx
        '
        Me.now_tx.BackColor = System.Drawing.Color.Transparent
        Me.now_tx.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.now_tx.ForeColor = System.Drawing.Color.Aqua
        Me.now_tx.Location = New System.Drawing.Point(12, 250)
        Me.now_tx.Name = "now_tx"
        Me.now_tx.Size = New System.Drawing.Size(517, 14)
        Me.now_tx.TabIndex = 9
        Me.now_tx.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０"
        Me.now_tx.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'path_txt
        '
        Me.path_txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.path_txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.path_txt.Location = New System.Drawing.Point(6, 4)
        Me.path_txt.Name = "path_txt"
        Me.path_txt.Size = New System.Drawing.Size(298, 14)
        Me.path_txt.TabIndex = 10
        Me.path_txt.Text = "(Fallout3.exeがある場所まで指定して下さい)"
        '
        'ProgressPars
        '
        Me.ProgressPars.AutoSize = True
        Me.ProgressPars.BackColor = System.Drawing.Color.SteelBlue
        Me.ProgressPars.Font = New System.Drawing.Font("Meiryo UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ProgressPars.ForeColor = System.Drawing.Color.White
        Me.ProgressPars.Location = New System.Drawing.Point(18, 265)
        Me.ProgressPars.Name = "ProgressPars"
        Me.ProgressPars.Size = New System.Drawing.Size(26, 12)
        Me.ProgressPars.TabIndex = 11
        Me.ProgressPars.Text = "---%"
        Me.ProgressPars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ProgressPars.Visible = False
        '
        'ViewerButton
        '
        Me.ViewerButton.BackgroundImage = CType(resources.GetObject("ViewerButton.BackgroundImage"), System.Drawing.Image)
        Me.ViewerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ViewerButton.Location = New System.Drawing.Point(503, 1)
        Me.ViewerButton.Name = "ViewerButton"
        Me.ViewerButton.Size = New System.Drawing.Size(35, 21)
        Me.ViewerButton.TabIndex = 13
        Me.ViewerButton.UseVisualStyleBackColor = True
        '
        'paths
        '
        Me.paths.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.paths.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.paths.Enabled = False
        Me.paths.ForeColor = System.Drawing.Color.White
        Me.paths.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.paths.Location = New System.Drawing.Point(1, 1)
        Me.paths.Name = "paths"
        Me.paths.ReadOnly = True
        Me.paths.Size = New System.Drawing.Size(498, 21)
        Me.paths.TabIndex = 12
        Me.paths.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mains
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(541, 295)
        Me.Controls.Add(Me.ViewerButton)
        Me.Controls.Add(Me.ProgressPars)
        Me.Controls.Add(Me.path_txt)
        Me.Controls.Add(Me.now_tx)
        Me.Controls.Add(Me.fose_not)
        Me.Controls.Add(Me.dl_not)
        Me.Controls.Add(Me.fose_1_3)
        Me.Controls.Add(Me.OptiButton)
        Me.Controls.Add(Me.UnInstallButton)
        Me.Controls.Add(Me.JPButton)
        Me.Controls.Add(Me.DownloadButton)
        Me.Controls.Add(Me.ProBar)
        Me.Controls.Add(Me.version_tx)
        Me.Controls.Add(Me.paths)
        Me.Font = New System.Drawing.Font("Meiryo UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mains"
        Me.Text = "Fallout 3 Japanese Patch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents version_tx As Label
    Friend WithEvents ProBar As ProgressBar
    Friend WithEvents DownloadButton As Button
    Friend WithEvents JPButton As Button
    Friend WithEvents UnInstallButton As Button
    Friend WithEvents OptiButton As Button
    Friend WithEvents fose_1_3 As CheckBox
    Friend WithEvents dl_not As CheckBox
    Friend WithEvents fose_not As CheckBox
    Friend WithEvents now_tx As Label
    Friend WithEvents path_txt As Label
    Friend WithEvents ProgressPars As Label
    Friend WithEvents ViewerButton As Button
    Friend WithEvents paths As TextBox
End Class
