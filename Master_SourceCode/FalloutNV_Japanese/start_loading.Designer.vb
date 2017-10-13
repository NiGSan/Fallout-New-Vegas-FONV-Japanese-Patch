<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class start_loading
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(start_loading))
        Me.loding = New System.Windows.Forms.Label()
        Me.close_box = New System.Windows.Forms.PictureBox()
        Me.INI_URL = New System.Windows.Forms.Timer(Me.components)
        CType(Me.close_box, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'loding
        '
        Me.loding.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.loding, "loding")
        Me.loding.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.loding.Name = "loding"
        '
        'close_box
        '
        Me.close_box.BackColor = System.Drawing.Color.Transparent
        Me.close_box.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.close_box, "close_box")
        Me.close_box.Name = "close_box"
        Me.close_box.TabStop = False
        '
        'start_loading
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.close_box)
        Me.Controls.Add(Me.loding)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "start_loading"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.close_box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents loding As System.Windows.Forms.Label
    Friend WithEvents close_box As System.Windows.Forms.PictureBox
    Friend WithEvents INI_URL As Timer
End Class
