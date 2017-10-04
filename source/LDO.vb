Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO
Public Class LDO
    Public Declare Function GetPrivateProfileString Lib "kernel32" _
        Alias "GetPrivateProfileStringA" (
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpApplicationName As String,
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpKeyName As String,
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpDefault As String,
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpReturnedString As StringBuilder,
        ByVal nSize As UInt32,
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpFileName As String) As UInt32

    '現在パス
    Dim Root As String
    '定義(INI場所)
    Dim ini_A As String = Root & "\setting.ini"
    'URL/Hash
    Dim FOSE_URL_INI As String = "http://fallout.allplay.jp/download/fonv_jp/nvse_5_0_b2.zip"
    Dim FO3JP_URL_INI As String = "http://fallout.allplay.jp/download/fonv_jp/nvse_5_0_b3.zip"
    Dim FOSE_MD5_INI As String = "24e92e554e15842dd1c1896d027196b5"
    Dim FO3JP_MD5_INI As String = "42cd1fb77dba25eef78f2f33173a2967"
    '名前
    Dim Titles As String = "Fallout 3 Japanese Patch - "
    'Version
    Dim VersionB As String = My.Application.Info.Version.ToString

    Private Sub ErrorBypass()
        'テキスト表示
        message_txt.Refresh()
        message_txt.Text = "エラーが発生したためデフォルトURLを設定しています。お待ちください"

        '何かしらの理由でエラーが発生した場合の処置
        options.FOSE_URL.Text = FOSE_URL_INI
        options.FOSE_HASH.Text = FOSE_MD5_INI
        options.FO3JP_URL.Text = FO3JP_URL_INI
        options.FO3JP_HASH.Text = FO3JP_MD5_INI

        'メイン表示
        mains.Text = Titles & VersionB

        '表示する
        Me.Visible = False
        mains.Show()
    End Sub

    Private Sub LDO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '現在パス取得(アクセス権限)
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\Fallout3_Japanese.exe") Then
                '場所指定
                Root = AppDomain.CurrentDomain.BaseDirectory & "\"
            Else
                If File.Exists(Application.StartupPath & "\Fallout3_Japanese.exe") Then
                    '場所指定
                    Root = Application.StartupPath & "\"
                Else
                    MessageBox.Show("申し訳ありません。このユーザでは権限不足もしくは環境の問題により" & vbCr &
                                    "取得出来ませんでした。" & vbCr & vbCr &
                                    "管理者として実行するか、ユーザをご変更してください。", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End If
            End If
        Catch ex As Exception
            'パス取得不可
            MessageBox.Show("申し訳ありません。このユーザでは権限不足もしくは環境の問題により" & vbCr &
                            "取得出来ませんでした。" & vbCr & vbCr &
                            "管理者として実行するか、ユーザをご変更してください。", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub
    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        Application.Exit()
    End Sub
    Private Sub LDO_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If System.IO.File.Exists(Root & "setting.ini") Then
                '設定する
                INI_CHK.Enabled = True
            Else
                Dim result As DialogResult = MessageBox.Show("ダウンロードURL設定ファイルがありません。取得しますか？",
                                                     "質問",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                                                     MessageBoxDefaultButton.Button1)
                If result = DialogResult.Yes Then
                    Try
                        'ファイル取得する
                        My.Computer.Network.DownloadFile("http://blog-imgs-106.fc2.com/g/a/m/gamesmod/setting_ini.jpg",
                                                        Root & "setting.ini", "", "", True, 60000, True, FileIO.UICancelOption.ThrowException)
                        '設定する
                        INI_CHK.Enabled = True
                    Catch ex As Exception
                        'デフォルトの設定を適用する
                        ErrorBypass()
                    End Try
                ElseIf result = DialogResult.No Then
                    'デフォルトの設定を適用する
                    ErrorBypass()
                End If
            End If

        Catch ex As Exception
            'デフォルトの設定を適用する
            ErrorBypass()
        End Try
    End Sub

    Private Sub INI_CHK_Tick(sender As Object, e As EventArgs) Handles INI_CHK.Tick
        INI_CHK.Enabled = False
        Try
            'INI存在確認
            If System.IO.File.Exists(Root & "setting.ini") Then
                'テキスト表示
                message_txt.Refresh()
                message_txt.Text = "URL設定を読み込んでいます。お待ちください"

                'INI設定読み込み開始
                URL_DATA_.Enabled = True
            Else
                '存在しない場合はデフォルト設定
                options.FOSE_URL.Text = FOSE_URL_INI
                options.FOSE_HASH.Text = FOSE_MD5_INI
                options.FO3JP_URL.Text = FO3JP_URL_INI
                options.FO3JP_HASH.Text = FO3JP_MD5_INI

            End If
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr &
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorBypass()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorBypass()
        End Try
    End Sub

    Private Sub URL_DATA__Tick(sender As Object, e As EventArgs) Handles URL_DATA_.Tick
        URL_DATA_.Enabled = False
        Try
            '読み込み開始(FOSE)
            Dim FOSE As StringBuilder = New StringBuilder(256)
            Dim FOSE_A As UInt32 =
                GetPrivateProfileString("DOWNLOAD_URL", "FOSE_URL", FOSE_URL_INI,
                    FOSE, Convert.ToUInt32(FOSE.Capacity), ini_A)
            options.FOSE_URL.Text = FOSE.ToString()

            '読み込み開始(日本語化キット)
            Dim FO3JP As StringBuilder = New StringBuilder(256)
            Dim FO3JP_A As UInt32 =
                GetPrivateProfileString("DOWNLOAD_URL", "FO3JP_URL", FO3JP_URL_INI,
                    FO3JP, Convert.ToUInt32(FO3JP.Capacity), ini_A)
            options.FO3JP_URL.Text = FO3JP.ToString()


            'テキスト表示
            message_txt.Refresh()
            message_txt.Text = "ハッシュ値を読み込んでいます。お待ちください"
            'ハッシュ値を別途処理
            HASH_.Enabled = True
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr &
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorBypass()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorBypass()
        End Try
    End Sub

    Private Sub HASH__Tick(sender As Object, e As EventArgs) Handles HASH_.Tick
        HASH_.Enabled = False
        Try
            '読み込み開始(FOSE)
            Dim FOSE As StringBuilder = New StringBuilder(256)
            Dim FOSE_A As UInt32 =
                GetPrivateProfileString("DOWNLOAD_HAAAASH", "FOSE_MD5", FOSE_MD5_INI,
                    FOSE, Convert.ToUInt32(FOSE.Capacity), ini_A)
            options.FOSE_URL.Text = FOSE.ToString()

            '読み込み開始(日本語化キット)
            Dim FO3JP As StringBuilder = New StringBuilder(256)
            Dim FO3JP_A As UInt32 =
                GetPrivateProfileString("DOWNLOAD_HAAAASH", "FO3JP_MD5", FO3JP_MD5_INI,
                    FO3JP, Convert.ToUInt32(FO3JP.Capacity), ini_A)
            options.FO3JP_URL.Text = FO3JP.ToString()

            'ハッシュ値を別途処理
            HASH_.Enabled = True
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr &
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorBypass()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorBypass()
        End Try
    End Sub
End Class