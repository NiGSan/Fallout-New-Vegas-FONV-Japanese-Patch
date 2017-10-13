Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO

Imports System.ComponentModel

Public Class start_loading
    Public Declare Function GetPrivateProfileString Lib "kernel32" _
        Alias "GetPrivateProfileStringA" (
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpApplicationName As String,
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpKeyName As String,
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpDefault As String,
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpReturnedString As StringBuilder,
        ByVal nSize As UInt32,
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpFileName As String) As UInt32

    Private Declare Auto Function GetPrivateProfileStringW Lib "kernel32" (ByVal lpAppName As String,
    ByVal lpKeyName As String,
    ByVal lpDefault As String,
    ByVal lpReturnedString As StringBuilder,
    ByVal nSize As Integer,
    ByVal lpFileName As String) As Integer

    '定義(起動場所)
    Dim Root As String
    'URL/Hash
    Dim NVSE_URL As String
    Dim NVSE_BETA_URL As String
    Dim FOJP_URL As String
    Dim FOJPN_URL As String
    Dim DLC_FOJP_URL As String
    Dim NVSE_MD5 As String
    Dim NVSE_BETA_MD5 As String
    Dim FOJP_MD5 As String
    Dim DLC_MD5 As String
    '名前
    Dim Titles As String = "Fallout: New Vegas Japanese Patch - "
    'Version
    Dim VersionB As String = My.Application.Info.Version.ToString
    Private Sub close_box_Click(sender As Object, e As EventArgs) Handles close_box.Click
        Application.Exit()
    End Sub
    Private Sub ErrorBypass()
        'テキスト表示
        loding.Refresh()
        loding.Text = "エラーが発生したためデフォルトURLを設定しています。お待ちください"

        '何かしらの理由でエラーが発生した場合の処置
        Dim NVSE_URL As String = "https://github.com/NiGSan/Fallout-New-Vegas-FONV-Japanese-Patch/raw/master/Download/nvse_5_0_b2.zip"
        Dim NVSE_BETA_URL As String = "https://github.com/NiGSan/Fallout-New-Vegas-FONV-Japanese-Patch/raw/master/Download/nvse_5_0_b3.zip"
        Dim FOJP_URL As String = "https://github.com/NiGSan/Fallout-New-Vegas-FONV-Japanese-Patch/raw/master/Download/FOJP2_v4_6.zip"
        Dim FOJPN_URL As String = "https://github.com/NiGSan/Fallout-New-Vegas-FONV-Japanese-Patch/raw/master/Download/fonvj-dictionary-pack.zip"
        Dim DLC_FOJP_URL As String = "https://raw.githubusercontent.com/NiGSan/Fallout-New-Vegas-FONV-Japanese-Patch/master/Download/fojp.xml"
        Dim NVSE_MD5 As String = "24e92e554e15842dd1c1896d027196b5"
        Dim NVSE_BETA_MD5 As String = "42cd1fb77dba25eef78f2f33173a2967"
        Dim FOJP_MD5 As String = "8f338f699a9dde831a72f41410232419"
        Dim DLC_MD5 As String = "69bba8fc3c3d2d90b75908c5fa0511d8"

        'メイン表示
        MAIN_FOUM_VIS()
    End Sub

    Private Sub loadin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '初期チェック
        Me.Visible = True
        Me.ShowInTaskbar = True
        Me.Size = New Size(650, 304)
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Refresh()
        '
        '#### 実行中パス確認 ####
        File_Path_Checker()

    End Sub

    Private Sub File_Path_Checker()
        '実行中のパスを取得可能確認(権限チェック/ダウンロード保存)
        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\FalloutNV_Japanese.exe") Then
            Root = AppDomain.CurrentDomain.BaseDirectory & "\"
            '##### オプション確認する #####
            File_Option_Check()
        Else
            '存在しない場合(旧式)
            If File.Exists(Application.StartupPath & "\FalloutNV_Japanese.exe") Then
                Root = Application.StartupPath & "\"
                '##### オプション確認する #####
                File_Option_Check()
            Else
                'それでも見つからない場合
                MessageBox.Show("申し訳ありません。このユーザでは権限不足もしくは環境の問題により" & vbCr &
                                "取得出来ませんでした。" & vbCr & vbCr &
                                "管理者として実行するか、ユーザをご変更してください。", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub File_Option_Check()
        'オプションファイル確認チェック
        Try
            '#### オフラインモード (優先チェック) ####
            If System.IO.File.Exists(Root & "offline.dll") Then
                'オフラインモードを実行する
                OPTION_OFFLINE_MODE()
            Else
                '#### 設定ファイル読み込み無効 (優先チェック) ####
                If System.IO.File.Exists(Root & "offline.dll") Then
                    'オフラインモードを実行する
                    OPTION_INI_DAMEDESU_MODE()
                Else
                    '##### オプションなし #####
                    URL_DATA_INI_DOWNLOAD_CHECK()
                End If
            End If
        Catch ex As Exception
            'パス不具合用
            MessageBox.Show(ex.Message & vbCr & vbCr &
                            "上記エラーにより正しく読み込む事が出来ません" & vbCr &
                            "管理者として実行するか、ユーザをご変更してください。", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub OPTION_OFFLINE_MODE()
        'メインフォーム名変更
        mains.Text = Titles & VersionB & "<オフライン>"
        'ダウンロードパネル無効化
        mains.re_download_pabnel.Enabled = False
        'ダウンロードパネル非表示
        mains.DownloadButtons.Visible = False
        'オフラインモード用パネル表示
        mains.offline_mode_1.Visible = False
        '整合性チェック(CHECK_BOX)を非表示
        mains.Hashsan.Visible = False
        'NVSEベータ版を利用する(CHECK_BOX)を非表示
        mains.NVSE_checks.Visible = False
        '設定ボタンを非表示
        mains.optionButtons.Enabled = False

        '日本語化を適用するボタンを有効化
        mains.JPButtons.Enabled = True
        mains.UIC = True

        '設定(1=NVSE 2=FOJP)
        mains.unPack_FileName_1 = "nvse_5_0_b2"
        mains.unPack_FileName_2 = "FOJP2_v4_6"

        '位置変更
        mains.JPButtons.SetBounds(18, 198, 254, 42, BoundsSpecified.All)
        mains.JPButtons.Refresh()

        'テキスト変更
        mains.JPButtons.Text = "日本語化を適用する" & vbCr & "(オフラインモード中)"
        mains.optionButtons.Text = "設定利用不可" & vbCr & "(OPTION)"

        '表示する
        Me.Visible = False
        mains.Show()
    End Sub

    Private Sub OPTION_INI_DAMEDESU_MODE()
        'メインフォーム名変更
        mains.Text = Titles & VersionB & "<設定ファイル未最新>"
        'デフォルトを導入
        ErrorBypass()

    End Sub

    Private Sub URL_DATA_INI_DOWNLOAD_CHECK()
        If System.IO.File.Exists(Root & "\setting.ini") Then
            '##### ファイルが存在する場合 ####
            INI_OK_DESU()
        Else
            '##### ファイルが存在しない場合 ####
            INI_NAI_DESU()
        End If
    End Sub

    Private Sub INI_NAI_DESU()
        Dim result As DialogResult = MessageBox.Show("ダウンロードURL設定ファイルがありません。取得しますか？",
                                                         "質問",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Information,
                                                         MessageBoxDefaultButton.Button1)
        If result = DialogResult.Yes Then
            Try
                'ファイル取得する
                My.Computer.Network.DownloadFile("https://raw.githubusercontent.com/NiGSan/Fallout-New-Vegas-FONV-Japanese-Patch/master/Download/setting.ini",
                                                Root & "\setting.ini", "", "", True, 60000, True, FileIO.UICancelOption.ThrowException)
                '表示する
                URL_DATA_INI_DOWNLOAD_CHECK()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End Try
        ElseIf result = DialogResult.No Then
            'デフォルトの設定を適用する
            INI_OK_DESU()
        End If
    End Sub

    Private Sub INI_OK_DESU()
        '保存場所
        Dim ini_A As String = Root & "\setting.ini"

        '########## 設定ファイルを読み込む ##########
        Try
            '読み込み開始(NVSE)
            Dim NVSE As New StringBuilder(500)
            Dim NVSE_A As Integer = GetPrivateProfileString("DOWNLOAD_URL", "NVSE_URL", "", NVSE, NVSE.Capacity, ini_A)
            If NVSE_A > 0 Then
                cfg.NVSE_URL.Text = NVSE.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "NVSE Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            '読み込み開始(NVSEベータ版)
            Dim NVSEBETA As New StringBuilder(500)
            Dim NVSE_BETA_A As Integer = GetPrivateProfileString("DOWNLOAD_URL", "NVSE_BETA_URL", "", NVSEBETA, NVSEBETA.Capacity, ini_A)
            If NVSE_BETA_A > 0 Then
                cfg.NVSE_BETA_URL.Text = NVSEBETA.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "NVSE BETA Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            '読み込み開始(FOJP)
            Dim FOJP As New StringBuilder(500)
            Dim FOJP_A As Integer = GetPrivateProfileString("DOWNLOAD_URL", "FOJP2_URL", "", FOJP, FOJP.Capacity, ini_A)
            If FOJP_A > 0 Then
                cfg.FOJP_URL.Text = FOJP.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "FOJP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            '読み込み開始(FOJPN)
            Dim FOPACK As New StringBuilder(500)
            Dim FOPACK_A As Integer = GetPrivateProfileString("DOWNLOAD_URL", "FO_PACK_URL", "", FOPACK, FOPACK.Capacity, ini_A)
            If FOPACK_A > 0 Then
                cfg.FOJPN_URL.Text = FOPACK.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "FO PACK Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            '読み込み開始(DLC_FOJP)
            Dim DLC_FOJP As New StringBuilder(500)
            Dim DLC_FOJP_A As Integer = GetPrivateProfileString("DOWNLOAD_URL", "FOJP_XML_URL", "", DLC_FOJP, DLC_FOJP.Capacity, ini_A)
            If DLC_FOJP_A > 0 Then
                cfg.DLC_FOJP_URL.Text = DLC_FOJP.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "XML FOJP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            'ハッシュ値を別途処理
            HASH_LOADING_STACK()
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

    Private Sub HASH_LOADING_STACK()
        '保存場所
        Dim ini_A As String = Root & "\setting.ini"

        Try
            '読み込み開始(NVSE)
            Dim NVSE_MD5 As New StringBuilder(500)
            Dim NVSE_MD5_A As Integer = GetPrivateProfileString("DOWNLOAD_HAAAASH", "NVSE_MD5", "", NVSE_MD5, NVSE_MD5.Capacity, ini_A)
            If NVSE_MD5_A > 0 Then
                cfg.NVSE_MD5.Text = NVSE_MD5.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            '読み込み開始(NVSEベータ版)
            Dim NVSEBETA_MD5 As New StringBuilder(500)
            Dim NVSE_MD5_BETA_A As Integer = GetPrivateProfileString("DOWNLOAD_HAAAASH", "NVSE_BETA_MD5", "", NVSEBETA_MD5, NVSEBETA_MD5.Capacity, ini_A)
            If NVSE_MD5_BETA_A > 0 Then
                cfg.NVSE_BETA_MD5.Text = NVSEBETA_MD5.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            '読み込み開始(FOJP)
            Dim FOJP_MD5 As New StringBuilder(500)
            Dim FOJP_MD5_A As Integer = GetPrivateProfileString("DOWNLOAD_HAAAASH", "FOJP2_MD5", "", FOJP_MD5, FOJP_MD5.Capacity, ini_A)
            If FOJP_MD5_A > 0 Then
                cfg.FOJP_MD5.Text = FOJP_MD5.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            '読み込み開始(DLC_FOJP)
            Dim DLC_FOJP_MD5 As New StringBuilder(500)
            Dim DLC_FOJP_MD5_A As Integer = GetPrivateProfileString("DOWNLOAD_HAAAASH", "FOJP_XML_MD5", "", DLC_FOJP_MD5, DLC_FOJP_MD5.Capacity, ini_A)
            If DLC_FOJP_MD5_A > 0 Then
                cfg.DLC_MD5.Text = DLC_FOJP_MD5.ToString()
            Else
                Dim ex As New Win32Exception(Marshal.GetLastWin32Error())
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrorBypass()
            End If

            'メイン表示
            MAIN_FOUM_VIS()
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr &
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorBypass()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MAIN_FOUM_VIS()
        '#####
        'メイン表示
        mains.Text = Titles & VersionB
        '読み込みフォームを非表示する
        Me.Visible = False
        Me.ShowInTaskbar = False
        Me.WindowState = FormWindowState.Minimized
        'メインを表示する
        mains.Show()
    End Sub
End Class