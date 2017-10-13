Imports ICSharpCode.SharpZipLib
Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO
Imports System
Imports System.Security
Imports Microsoft.Win32
Imports System.Net

Public Class mains
    Dim downloadClient As WebClient = Nothing
    'ルートの取得
    Dim Root As String
    'ツールチップ
    Private toolTipMsg As New ToolTip
    'タイトル保存
    Dim toolname As String
    'ファイルパス
    Dim Download_File_1 As String
    Dim Download_File_2 As String
    Dim Download_File_3 As String
    'ファイル名
    Dim Download_FileName_1 As String
    Dim Download_FileName_2 As String
    '解凍ファイル名
    Friend unPack_FileName_1 As String
    Friend unPack_FileName_2 As String
    '確認用
    Dim DL_1_ As Boolean
    Dim DL_2_ As Boolean
    Dim DL_3_ As Boolean
    Dim DL_4_ As Boolean
    Dim Hash1_ As Boolean
    Dim Hash2_ As Boolean
    Dim Hash3_ As Boolean
    Dim Unzip1_ As Boolean
    Dim Unzip2_ As Boolean
    Dim Unzip3_ As Boolean
    Friend UIC As Boolean
    '作成用
    Private WarningTxT As System.Windows.Forms.Label

    Private Sub mains_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ツールチップを追加
        '表示されるまでの時間
        toolTipMsg.InitialDelay = 0
        toolTipMsg.SetToolTip(Path_tex, """Fallout: New Vegas""のFalloutNV.exeが" & vbCr & "置いてあるフォルダまで指定してください")
        toolTipMsg.SetToolTip(Path_pass, """Fallout: New Vegas""のFalloutNV.exeが" & vbCr & "置いてあるフォルダまで指定してください")
        toolTipMsg.SetToolTip(CheckBox2, "ゲーム内のターミナル(PC)を日本語化します。")
        toolTipMsg.SetToolTip(CheckBox1, "ゲームDLCの日本語化を行います" & vbCr & "仮にDLCが無くてもチェックしたままで問題はありません")
        toolTipMsg.SetToolTip(DownloadButtons, "日本語化に必要なファイルをダウンロードします" & vbCr & "エラーの場合は時間を置くか、サーバ側が削除されている可能性があります")
        toolTipMsg.SetToolTip(JPButtons, "日本語化を適用します。" & vbCr & "最初に最新のファイルをダウンロードする必要性があります。")
        toolTipMsg.SetToolTip(UnistallButtons, "アンインストールです。" & vbCr & "NVSE、FOJP用フォント、日本語データのみを削除します")
        toolTipMsg.SetToolTip(ProgressBar1, "ダウンロードや解凍などの進行状況が分かります")
        toolTipMsg.SetToolTip(EventTxT, "処理状況です")
        toolTipMsg.SetToolTip(ViewerButton, "左クリックでフォルダ指定、右クリックでファイル選択によるフォルダ指定が出来ます")
        toolTipMsg.SetToolTip(Version_text, "ダブルクリックで、このツールの開発者ブログに接続します")
        toolTipMsg.SetToolTip(re_download_pabnel, "「FALL」つまり何かしらで失敗した場合は、ココをダブルクリック！")
        toolTipMsg.SetToolTip(ViewerButton, "フォルダを選択する画面を表示します")
        toolTipMsg.SetToolTip(offline_mode_1, "インターネットに接続していなくても日本語化します" & vbCr & "日本語化構成ファイルが別途で必要です")

        '実行中のアプリケーションパスが正しく取得出来ているか
        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\FalloutNV_Japanese.exe") Then
            Root = AppDomain.CurrentDomain.BaseDirectory
            'falloutnv検出
            If File.Exists(Root & "FalloutNV.exe") Then
                Path_pass.Text = Root
            End If
        Else
            '存在しない場合(旧式)
            If File.Exists(Application.StartupPath & "\FalloutNV_Japanese.exe") Then
                Root = Application.StartupPath & "\"
                'falloutnv検出
                If File.Exists(Root & "FalloutNV.exe") Then
                    Path_pass.Text = Root
                End If
            Else
                'それでも見つからない場合
                MessageBox.Show("申し訳ありません。このユーザでは権限不足もしくは環境の問題により" & vbCr & _
                                "取得出来ませんでした。" & vbCr & vbCr & _
                                "管理者として実行するか、ユーザをご変更してください。", "Error", _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub WarningHide_Tick(sender As Object, e As EventArgs) Handles WarningHide.Tick
        WarningHide.Enabled = False
        '警告メッセージを非表示にする
        WarningTxT.Visible = False
        WarningTxT.Text = ""
        'NVSE単体をアンインストールボタン有効
        UnistallButtons.Refresh()
        UnistallButtons.Text = "アンインストールする" & vbCr & "(準備が完了しました)"
        UnistallButtons.Enabled = True
        NVSE_DEL_X.Enabled = False
        NVSE_DEL_X.Text = "NVSEを削除します"
    End Sub

    Public Overloads Shared Sub CopyDirectory(ByVal stSourcePath As String, ByVal stDestPath As String, ByVal bOverwrite As Boolean)
        Try
            ' コピー先のディレクトリがなければ作成する
            If Directory.Exists(stDestPath) = False Then
                Directory.CreateDirectory(stDestPath)
                File.SetAttributes(stDestPath, File.GetAttributes(stSourcePath))
                bOverwrite = True
            End If

            ' コピー元のディレクトリにあるすべてのファイルをコピーする
            If bOverwrite Then
                For Each stCopyFrom As String In Directory.GetFiles(stSourcePath)
                    Dim stCopyTo As String = Path.Combine(stDestPath, Path.GetFileName(stCopyFrom))
                    File.Copy(stCopyFrom, stCopyTo, True)
                Next stCopyFrom

                ' 上書き不可能な場合は存在しない時のみコピーする
            Else
                For Each stCopyFrom As String In Directory.GetFiles(stSourcePath)
                    Dim stCopyTo As String = Path.Combine(stDestPath, Path.GetFileName(stCopyFrom))

                    If File.Exists(stCopyTo) = False Then
                        File.Copy(stCopyFrom, stCopyTo, False)
                    End If
                Next stCopyFrom
            End If

            ' コピー元のディレクトリをすべてコピーする (再帰)
            For Each stCopyFrom As String In Directory.GetDirectories(stSourcePath)
                Dim stCopyTo As String = Path.Combine(stDestPath, Path.GetFileName(stCopyFrom))
                CopyDirectory(stCopyFrom, stCopyTo, bOverwrite)
            Next stCopyFrom
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Overloads Shared Sub DeleteDirectory(ByVal stDirPath As String)
        Try
            Call DeleteDirectory(New DirectoryInfo(stDirPath))
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Overloads Shared Sub DeleteDirectory(ByVal hDirectoryInfo As DirectoryInfo)
        Try
            ' すべてのファイルの読み取り専用属性を解除する
            For Each cFileInfo As FileInfo In hDirectoryInfo.GetFiles()
                If (cFileInfo.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                    cFileInfo.Attributes = FileAttributes.Normal
                End If
            Next cFileInfo

            ' サブディレクトリ内の読み取り専用属性を解除する (再帰)
            For Each hDirInfo As DirectoryInfo In hDirectoryInfo.GetDirectories()
                Call DeleteDirectory(hDirInfo)
            Next hDirInfo

            ' このディレクトリの読み取り専用属性を解除する
            If (hDirectoryInfo.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                hDirectoryInfo.Attributes = FileAttributes.Directory
            End If

            ' このディレクトリを削除する
            hDirectoryInfo.Delete(True)
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Version_text_DoubleClick(sender As Object, e As EventArgs) Handles Version_text.DoubleClick
        'ブログへアクセスする
        System.Diagnostics.Process.Start("http://gamesmod.blog.fc2.com/")
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles NVSE_DEL_X.Click
        If NVSE_DEL_X.Checked Then
        Else
            Dim result As DialogResult = MessageBox.Show("NVSEを削除する事でMOD等に影響する場合があります" & vbCr & _
                                                         "それでも削除しますか？", _
                                                         "New Vegas Script Extender Uninstall", _
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

            '何が選択されたか調べる 
            If result = DialogResult.Yes Then
                'Event
                EventTxT.Refresh()
                EventTxT.Text = "NVSEを削除するように設定しました"
            ElseIf result = DialogResult.No Then
                'Event
                EventTxT.Refresh()
                EventTxT.Text = "NVSEの削除禁止を設定しました"
                NVSE_DEL_X.Checked = True
            End If
        End If
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles re_download_pabnel.DoubleClick
        ClearDownload()
    End Sub

    Private Sub ClearDownload()
        Try
            '全て初期化した上で再度ダウンロードを有効化する
            If Directory.Exists(Root & "Download") Then
                '例外エラー対策で一度初期化する
                Directory.Delete(Root & "Download", True)
                Directory.Delete(Root & "Data", True)
                '適用無効化
                JPButtons.Enabled = False
                'ダウンロードボタン有効化
                DownloadButtons.Enabled = True
                'Event
                EventTxT.Refresh()
                EventTxT.Text = "ダウンロードの有効化に成功しました。"
                'テキストを変更する
                JPButtons.Refresh()
                JPButtons.Text = "日本語化を適用する" & vbCr & "(ダウンロードしてください)"
                NVSE_checks.Enabled = True
                'PogressBer Update
                ProgressBar1.Value = 0
                ProgressPars.Visible = False
            Else
                '適用無効化
                JPButtons.Enabled = False
                'ダウンロードボタン有効化
                DownloadButtons.Enabled = True
                'Event
                EventTxT.Refresh()
                EventTxT.Text = "ダウンロードの有効化に成功しました。"
                'テキストを変更する
                JPButtons.Refresh()
                JPButtons.Text = "日本語化を適用する" & vbCr & "(ダウンロードしてください"
                NVSE_checks.Enabled = True
                'PogressBer Update
                ProgressBar1.Value = 0
                ProgressPars.Visible = False
            End If
        Catch ex As Exception
            '適用無効化
            JPButtons.Enabled = False
            'ダウンロードボタン有効化
            DownloadButtons.Enabled = True
            'Event
            EventTxT.Refresh()
            EventTxT.Text = "ダウンロードの有効化に成功しました。"
            'テキストを変更する
            JPButtons.Refresh()
            JPButtons.Text = "日本語化を適用する" & vbCr & "(ダウンロードしてください)"
            NVSE_checks.Enabled = True
            'PogressBer Update
            ProgressBar1.Value = 0
            ProgressPars.Visible = False
        End Try
    End Sub

    Private Sub mains_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If UIC Then
            Application.Exit()
        Else
            If ViewerButton.Enabled Then
                Try
                    '残骸削除
                    If Directory.Exists(Root & "Download") Then
                        Directory.Delete(Root & "Download", True)
                        If Directory.Exists(Root & "Data") Then
                            Directory.Delete(Root & "Data", True)
                            Application.Exit()
                        Else
                            Application.Exit()
                        End If
                    Else
                        If Directory.Exists(Root & "Data") Then
                            Directory.Delete(Root & "Data", True)
                            Application.Exit()
                        Else
                            Application.Exit()
                        End If
                    End If
                Catch ex As Exception
                    Application.Exit()
                End Try
            Else
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub downloadClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        'ダウンロード処理表示
        ProgressBar1.Value = e.ProgressPercentage
        ProgressBar1.Refresh()
        ProgressPars.Visible = True
        ProgressPars.Text = e.ProgressPercentage & "%"
        ProgressPars.Refresh()
    End Sub

    Private Sub Progress(ByVal sender As Object, ByVal e As ICSharpCode.SharpZipLib.Core.ProgressEventArgs)
        '解凍処理表示
        ProgressBar1.Value = e.PercentComplete
        ProgressBar1.Refresh()
        ProgressPars.Visible = True
        ProgressPars.Text = e.PercentComplete & "%"
        ProgressPars.Refresh()
    End Sub

    Private Sub DirectoryFailure(ByVal sender As Object, ByVal e As ICSharpCode.SharpZipLib.Core.ScanFailureEventArgs)
        '解凍でエラーが発生した際に表示するメッセージ
        MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Application.Exit()
    End Sub

    Private Sub downloadClient_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If e.Cancelled Then
            'Event
            EventTxT.Refresh()
            EventTxT.Text = "ダウンロードをキャンセルしました。"
            DownloadButtons.Text = "Download" & vbCr & "(NVSE/FOJP/翻訳)"
            DownloadButtons.Enabled = True
        ElseIf Not (e.Error Is Nothing) Then
            MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DownloadButtons.Text = "Download" & vbCr & "(NVSE/FOJP/翻訳)"
            DownloadButtons.Enabled = True
            Application.Exit()
        ElseIf DL_1_ Then
            'FOJPダウンロード
            DL_1_ = False
            Download_2_()
        ElseIf DL_2_ Then
            '日本語ダウンロード
            DL_2_ = False
            Download_3_()
        ElseIf DL_3_ Then
            '日本語ダウンロード
            DL_3_ = False
            Download_4_()
            'テキスト修正
            DownloadButtons.Text = "Download" & vbCr & "(NVSE/FOJP/翻訳)"
        ElseIf DL_4_ Then
            '解凍処理前にハッシュチェック
            If Hashsan.Checked Then
                Unzip_1_()
            Else
                Hash_file_1()
            End If
        End If
    End Sub

    Private Sub CompletedFile(ByVal sender As Object, ByVal e As ICSharpCode.SharpZipLib.Core.ScanEventArgs)
        '解凍完了合図確認(NVJP)
        If DL_1_ Then
            'FOJP解凍
            DL_1_ = False
            Unzip_2_()
        ElseIf DL_2_ Then
            '日本語解凍
            DL_2_ = False
            Unzip_3_()
        ElseIf DL_3_ Then
            UnlockButton.Enabled = True
        End If
    End Sub

    Private Sub UnlockButton_Tick(sender As Object, e As EventArgs) Handles UnlockButton.Tick
        UnlockButton.Enabled = False
        '解凍処理の二重処理対策

        'Event
        EventTxT.Refresh()
        EventTxT.Text = "ファイルの準備が出来ました！日本語化を適用してください。" & vbCr & "再度ダウンロードする場合は左上の電球をダブルクリックしてください"
        re_download_pabnel.Enabled = True
        '適用可能にする
        JPButtons.Enabled = True
        'テキストを変更する
        JPButtons.Refresh()
        JPButtons.Text = "日本語化を適用する" & vbCr & "(準備が完了しました)"
    End Sub

    Private Sub ViewerButton_MouseDown(sender As Object, e As MouseEventArgs) Handles ViewerButton.MouseDown
        If (Control.MouseButtons And MouseButtons.Left) = MouseButtons.Left Then
            Try
                Dim directryopens As New FolderBrowserDialog
                directryopens.Description = "FalloutNV.exeがあるフォルダを指定してください。"
                directryopens.RootFolder = Environment.SpecialFolder.Desktop
                directryopens.SelectedPath = Environment.SpecialFolder.Desktop
                directryopens.ShowNewFolderButton = False
                If directryopens.ShowDialog(Me) = DialogResult.OK Then
                    'パスに使用出来ない文字確認
                    Dim filepath As String = directryopens.SelectedPath
                    Dim invalidPathChars As Char() = Path.GetInvalidPathChars()
                    For Each invalidChar As Char In invalidPathChars
                        If filepath.IndexOf(invalidChar) > -1 Then
                            MessageBox.Show("使用できない文字 " & invalidChar.ToString() & " が含まれています。")
                        Else
                            'テキスト設置
                            Path_pass.Text = directryopens.SelectedPath
                            'アンインストール確認
                            UnInstall_check_system()
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Path_pass.ReadOnly = False
            End Try
        End If
        If (Control.MouseButtons And MouseButtons.Right) = MouseButtons.Right Then
            Try
                Dim fileop As New OpenFileDialog()
                '最初にデスクトップを指定する
                Dim Desktop_select As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)
                fileop.FileName = "FalloutNV.exe"
                fileop.InitialDirectory = Desktop_select
                fileop.Filter = _
                    "実行ファイル(*.exe)|*.exe"
                fileop.FilterIndex = 1
                'タイトルを設定する
                fileop.Title = "FalloutNV.exeがあるフォルダまで行き、FalloutNV.exeを指定してください。"
                fileop.RestoreDirectory = True
                fileop.CheckFileExists = True
                fileop.CheckPathExists = True
                If fileop.ShowDialog() = DialogResult.OK Then 'fileop.FileName
                    Dim Path_FilePath As String = Path.GetDirectoryName(fileop.FileName)
                    'それ本当にFalloutNV.exe?
                    If File.Exists(Path_FilePath & "\FalloutNV.exe") Then
                        '確認
                        'パスに使用出来ない文字確認
                        Dim filepath As String = Path_FilePath
                        Dim invalidPathChars As Char() = Path.GetInvalidPathChars()
                        For Each invalidChar As Char In invalidPathChars
                            If filepath.IndexOf(invalidChar) > -1 Then
                                MessageBox.Show("使用できない文字 " & invalidChar.ToString() & " が含まれています。")
                            Else
                                'テキスト設置
                                Path_pass.Text = Path_FilePath
                                'アンインストール確認
                                UnInstall_check_system()
                                Exit For
                            End If
                        Next
                    Else
                        'NO
                        MessageBox.Show("これはFalloutNV.exeではありません", "Error", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Path_pass.ReadOnly = False
            End Try
        End If
    End Sub

    Private Sub DownloadButtons_Click(sender As Object, e As EventArgs) Handles DownloadButtons.Click
        'Event(回線状態が良くない時多少時間が待たされる場合があるためのイベント)
        EventTxT.Refresh()
        EventTxT.Text = "しばらくお待ち下さい。ダウンロードする準備を開始しました..."
        NVSE_checks.Enabled = False
        download_ready()
    End Sub

    Private Sub download_ready()
        Try
            If Directory.Exists(Root & "Data") Then
                If Directory.Exists(Root & "Download") Then
                    '例外エラー対策で一度初期化する
                    Directory.Delete(Root & "Data", True)
                    Directory.Delete(Root & "Download", True)
                    '必要な物をダウンロードする前にDLフォルダを作る
                    If Directory.Exists(Root & "Download") Then
                        '解凍フォルダ
                        If Directory.Exists(Root & "Data") Then
                            'New Vegas Script Extender 
                            download_1_()
                            DownloadButtons.Enabled = False
                        Else
                            'フォルダ生成
                            Directory.CreateDirectory(Root & "Data")
                            'New Vegas Script Extender 
                            download_1_()
                            DownloadButtons.Enabled = False
                        End If
                    Else
                        '解凍フォルダ
                        If Directory.Exists(Root & "Data") Then
                            'New Vegas Script Extender 
                            download_1_()
                            DownloadButtons.Enabled = False
                        Else
                            'フォルダ生成
                            Directory.CreateDirectory(Root & "Data")
                            'フォルダ生成
                            Directory.CreateDirectory(Root & "Download")
                            'New Vegas Script Extender
                            download_1_()
                            DownloadButtons.Enabled = False
                        End If
                    End If
                Else
                    '例外エラー対策で一度初期化する
                    Directory.Delete(Root & "Data", True)
                    '必要な物をダウンロードする前にDLフォルダを作る
                    If Directory.Exists(Root & "Download") Then
                        '解凍フォルダ
                        If Directory.Exists(Root & "Data") Then
                            'New Vegas Script Extender 
                            download_1_()
                            DownloadButtons.Enabled = False
                        Else
                            'フォルダ生成
                            Directory.CreateDirectory(Root & "Data")
                            'New Vegas Script Extender 
                            download_1_()
                            DownloadButtons.Enabled = False
                        End If
                    Else
                        '解凍フォルダ
                        If Directory.Exists(Root & "Data") Then
                            'New Vegas Script Extender 
                            download_1_()
                            DownloadButtons.Enabled = False
                        Else
                            'フォルダ生成
                            Directory.CreateDirectory(Root & "Data")
                            'フォルダ生成
                            Directory.CreateDirectory(Root & "Download")
                            'New Vegas Script Extender
                            download_1_()
                            DownloadButtons.Enabled = False
                        End If
                    End If
                End If
            Else
                '必要な物をダウンロードする前にDLフォルダを作る
                If Directory.Exists(Root & "Download") Then
                    '解凍フォルダ
                    If Directory.Exists(Root & "Data") Then
                        'New Vegas Script Extender 
                        download_1_()
                        DownloadButtons.Enabled = False
                    Else
                        'フォルダ生成
                        Directory.CreateDirectory(Root & "Data")
                        'New Vegas Script Extender 
                        download_1_()
                        DownloadButtons.Enabled = False
                    End If
                Else
                    '解凍フォルダ
                    If Directory.Exists(Root & "Data") Then
                        'New Vegas Script Extender 
                        download_1_()
                        DownloadButtons.Enabled = False
                    Else
                        'フォルダ生成
                        Directory.CreateDirectory(Root & "Data")
                        'フォルダ生成
                        Directory.CreateDirectory(Root & "Download")
                        'New Vegas Script Extender
                        download_1_()
                        DownloadButtons.Enabled = False
                    End If
                End If
            End If
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            EventTxT.Refresh()
            EventTxT.Text = access_error.Message
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub download_1_()
        If NVSE_checks.Checked Then
            Try
                'ファイル名を取得する
                Dim URL_FILE_NAME As String = Path.GetFileNameWithoutExtension(cfg.NVSE_BETA_URL.Text)
                'ダウンロードしたファイルの保存先
                Dim fileName As String = Root & "Download\" & URL_FILE_NAME & ".zip"
                'ファイルパス保存
                Download_File_1 = Root & "Download\" & URL_FILE_NAME & ".zip"
                'ファイル名保存
                Download_FileName_1 = URL_FILE_NAME
                'ダウンロード基のURL
                Dim u As New Uri(cfg.NVSE_BETA_URL.Text)

                'WebClientの作成
                If downloadClient Is Nothing Then
                    downloadClient = New WebClient()
                    'イベントハンドラの作成
                    AddHandler downloadClient.DownloadProgressChanged, _
                        AddressOf downloadClient_DownloadProgressChanged
                    AddHandler downloadClient.DownloadFileCompleted, _
                        AddressOf downloadClient_DownloadFileCompleted
                End If
                'DL完了合図
                DL_1_ = True
                'Event
                EventTxT.Text = """New Vegas Script Extender [Beta版]""のダウンロードを開始します.."
                EventTxT.Refresh()
                DownloadButtons.Text = "Download Cancel" & vbCr & "(NVSE/FOJP/翻訳)"
                downloadClient.DownloadFileAsync(u, fileName)
            Catch exa As WebException
                'HTTP Error(404/503/500)対策
                MessageBox.Show(exa.Message, "Error: ""New Vegas Script Extender [Beta版]""", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            Catch ex As Exception
                'WebClientが動作しない場合の対処(WebRequest)
                Try
                    'WebRequest Version
                    'ファイル名を取得する
                    Dim URL_FILE_NAME As String = Path.GetFileNameWithoutExtension(cfg.NVSE_BETA_URL.Text)

                    'ダウンロードしたファイルの保存先
                    Dim url As String = cfg.NVSE_BETA_URL.Text
                    Dim fileName As String = Root & "Download\" & URL_FILE_NAME & ".zip"

                    'ファイル名保存
                    Download_File_1 = Root & "Download\" & URL_FILE_NAME & ".zip"

                    'Event
                    EventTxT.Refresh()
                    EventTxT.Text = """New Vegas Script Extender [Beta版]""のダウンロードを開始します.."

                    'リクエスト生成
                    Dim webreq As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
                    Dim webres As HttpWebResponse = DirectCast(webreq.GetResponse(), HttpWebResponse)
                    Dim strm As Stream = webres.GetResponseStream()
                    Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.Write)
                    Dim readData As Byte() = New Byte(1023) {}
                    While True
                        Dim readSize As Integer = strm.Read(readData, 0, readData.Length)
                        If readSize = 0 Then
                            Exit While
                        End If
                        fs.Write(readData, 0, readSize)
                    End While
                    '残骸処理をする
                    fs.Close()
                    strm.Close()
                    'WebClient完了時に確認していた処理を実施
                    'FOJPダウンロード
                    Download_2_()
                Catch access_error As System.Security.SecurityException
                    MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                    "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DownloadButtons.Text = "Download" & vbCr & "(NVSE/FOJP/翻訳)"
                    DownloadButtons.Enabled = True
                Catch wq As Exception
                    MessageBox.Show(wq.Message, "Error: ""New Vegas Script Extender [Beta版]""", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End Try
            End Try
        Else
            Try
                'ファイル名を取得する
                Dim URL_FILE_NAME As String = Path.GetFileNameWithoutExtension(cfg.NVSE_URL.Text)
                'ダウンロードしたファイルの保存先
                Dim fileName As String = Root & "Download\" & URL_FILE_NAME & ".zip"
                'ファイルパス保存
                Download_File_1 = Root & "Download\" & URL_FILE_NAME & ".zip"
                'ファイル名保存
                Download_FileName_1 = URL_FILE_NAME
                'ダウンロード基のURL
                Dim u As New Uri(cfg.NVSE_URL.Text)

                'WebClientの作成
                If downloadClient Is Nothing Then
                    downloadClient = New WebClient()
                    'イベントハンドラの作成
                    AddHandler downloadClient.DownloadProgressChanged, _
                        AddressOf downloadClient_DownloadProgressChanged
                    AddHandler downloadClient.DownloadFileCompleted, _
                        AddressOf downloadClient_DownloadFileCompleted
                End If
                'DL完了合図
                DL_1_ = True
                'Event
                EventTxT.Refresh()
                EventTxT.Text = """New Vegas Script Extender""のダウンロードを開始します.."
                downloadClient.DownloadFileAsync(u, fileName)
            Catch exa As WebException
                'HTTP Error(404/503/500)対策
                MessageBox.Show(exa.Message, "Error: ""New Vegas Script Extender""", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            Catch ex As Exception
                'WebClientが動作しない場合の対処(WebRequest)
                Try
                    'WebRequest Version
                    'ファイル名を取得する
                    Dim URL_FILE_NAME As String = Path.GetFileNameWithoutExtension(cfg.NVSE_URL.Text)

                    'ダウンロードしたファイルの保存先
                    Dim url As String = cfg.NVSE_URL.Text
                    Dim fileName As String = Root & "Download\" & URL_FILE_NAME & ".zip"

                    'ファイル名保存
                    Download_File_1 = Root & "Download\" & URL_FILE_NAME & ".zip"

                    'Event
                    EventTxT.Refresh()
                    EventTxT.Text = """New Vegas Script Extender""のダウンロードを開始します.."

                    'リクエスト生成
                    Dim webreq As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
                    Dim webres As HttpWebResponse = DirectCast(webreq.GetResponse(), HttpWebResponse)
                    Dim strm As Stream = webres.GetResponseStream()
                    Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.Write)
                    Dim readData As Byte() = New Byte(1023) {}
                    While True
                        Dim readSize As Integer = strm.Read(readData, 0, readData.Length)
                        If readSize = 0 Then
                            Exit While
                        End If
                        fs.Write(readData, 0, readSize)
                    End While
                    '残骸処理をする
                    fs.Close()
                    strm.Close()
                    'WebClient完了時に確認していた処理を実施
                    'FOJPダウンロード
                    Download_2_()
                Catch access_error As System.Security.SecurityException
                    MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                    "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DownloadButtons.Text = "Download" & vbCr & "(NVSE/FOJP/翻訳)"
                    DownloadButtons.Enabled = True
                Catch wq As Exception
                    MessageBox.Show(wq.Message, "Error: ""New Vegas Script Extender""", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End Try
            End Try
        End If
    End Sub

    Private Sub Download_2_()
        Try
            'ファイル名を取得する
            Dim URL_FILE_NAME As String = Path.GetFileNameWithoutExtension(cfg.FOJP_URL.Text)
            'ダウンロードしたファイルの保存先
            Dim fileName As String = Root & "Download\" & URL_FILE_NAME & ".zip"
            'ファイル名保存
            Download_File_2 = Root & "Download\" & URL_FILE_NAME & ".zip"
            'ファイル名保存
            Download_FileName_2 = URL_FILE_NAME
            'ダウンロード基のURL
            Dim u As New Uri(cfg.FOJP_URL.Text)

            'WebClientの作成
            If downloadClient Is Nothing Then
                downloadClient = New WebClient()
                'イベントハンドラの作成
                AddHandler downloadClient.DownloadProgressChanged, _
                    AddressOf downloadClient_DownloadProgressChanged
                AddHandler downloadClient.DownloadFileCompleted, _
                    AddressOf downloadClient_DownloadFileCompleted
            End If
            'DL完了合図
            DL_2_ = True
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """Fallout JP""のダウンロードを開始します.."
            downloadClient.DownloadFileAsync(u, fileName)
        Catch exa As WebException
            'HTTP Error(404/503/500)対策
            MessageBox.Show(exa.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            'WebClientが動作しない場合の対処(WebRequest)
            Try
                'WebRequest Version

                'ファイル名を取得する
                Dim URL_FILE_NAME As String = Path.GetFileNameWithoutExtension(cfg.FOJP_URL.Text)

                'ダウンロードしたファイルの保存先
                Dim url As String = cfg.FOJP_URL.Text
                Dim fileName As String = Root & "Download\" & URL_FILE_NAME & ".zip"
                'ファイル名保存
                Download_File_2 = Root & "Download\" & URL_FILE_NAME & ".zip"

                'Event
                EventTxT.Refresh()
                EventTxT.Text = """Fallout JP""のダウンロードを開始します.."

                'リクエスト生成
                Dim webreq As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
                Dim webres As HttpWebResponse = DirectCast(webreq.GetResponse(), HttpWebResponse)
                Dim strm As Stream = webres.GetResponseStream()
                Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.Write)
                Dim readData As Byte() = New Byte(1023) {}
                While True
                    Dim readSize As Integer = strm.Read(readData, 0, readData.Length)
                    If readSize = 0 Then
                        Exit While
                    End If
                    fs.Write(readData, 0, readSize)
                End While
                '残骸処理をする
                fs.Close()
                strm.Close()
                'WebClient完了時に確認していた処理を実施
                'FOJPダウンロード
                Download_3_()
            Catch access_error As System.Security.SecurityException
                MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DownloadButtons.Text = "Download" & vbCr & "(NVSE/FOJP/翻訳)"
                DownloadButtons.Enabled = True
            Catch wq As Exception
                MessageBox.Show(wq.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End Try
        End Try
    End Sub

    Private Sub Download_3_()
        Try
            'ダウンロードしたファイルの保存先
            Dim fileName As String = Root & "Download\fonvj-dictionary-pack.zip"
            'ダウンロード基のURL
            Dim u As New Uri(cfg.FOJPN_URL.Text)

            'WebClientの作成
            If downloadClient Is Nothing Then
                downloadClient = New WebClient()
                'イベントハンドラの作成
                AddHandler downloadClient.DownloadProgressChanged, _
                    AddressOf downloadClient_DownloadProgressChanged
                AddHandler downloadClient.DownloadFileCompleted, _
                    AddressOf downloadClient_DownloadFileCompleted
            End If
            'DL完了合図
            DL_3_ = True
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """日本語化用辞書ファイル""のダウンロードを開始します.."
            downloadClient.DownloadFileAsync(u, fileName)
        Catch exa As WebException
            'HTTP Error(404/503/500)対策
            MessageBox.Show(exa.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            'WebClientが動作しない場合の対処(WebRequest)
            Try
                'WebRequest Version
                'ダウンロードしたファイルの保存先
                Dim url As String = cfg.FOJPN_URL.Text
                Dim fileName As String = Root & "Download\fonvj-dictionary-pack.zip"

                'Event
                EventTxT.Refresh()
                EventTxT.Text = """日本語化用辞書ファイル""のダウンロードを開始します.."

                'リクエスト生成
                Dim webreq As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
                Dim webres As HttpWebResponse = DirectCast(webreq.GetResponse(), HttpWebResponse)
                Dim strm As Stream = webres.GetResponseStream()
                Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.Write)
                Dim readData As Byte() = New Byte(1023) {}
                While True
                    Dim readSize As Integer = strm.Read(readData, 0, readData.Length)
                    If readSize = 0 Then
                        Exit While
                    End If
                    fs.Write(readData, 0, readSize)
                End While
                '残骸処理をする
                fs.Close()
                strm.Close()
                'WebClient完了時に確認していた処理を実施
                'FOJPダウンロード
                Download_4_()
            Catch access_error As System.Security.SecurityException
                MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DownloadButtons.Text = "Download" & vbCr & "(NVSE/FOJP/翻訳)"
                DownloadButtons.Enabled = True
            Catch wq As Exception
                MessageBox.Show(wq.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End Try
        End Try
    End Sub

    Private Sub Download_4_()
        Try
            'ダウンロードしたファイルの保存先
            Dim fileName As String = Root & "Download\fojp.xml"
            'ファイル名保存
            Download_File_3 = Root & "Download\fojp.xml"
            'ダウンロード基のURL
            Dim u As New Uri(cfg.DLC_FOJP_URL.Text)

            'WebClientの作成
            If downloadClient Is Nothing Then
                downloadClient = New WebClient()
                'イベントハンドラの作成
                AddHandler downloadClient.DownloadProgressChanged, _
                    AddressOf downloadClient_DownloadProgressChanged
                AddHandler downloadClient.DownloadFileCompleted, _
                    AddressOf downloadClient_DownloadFileCompleted
            End If
            'DL完了合図
            DL_4_ = True
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """DLC用fojp.xml""のダウンロードを開始します.."
            downloadClient.DownloadFileAsync(u, fileName)
        Catch exa As WebException
            'HTTP Error(404/503/500)対策
            MessageBox.Show(exa.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            'WebClientが動作しない場合の対処(WebRequest)
            Try
                'WebRequest Version
                'ダウンロードしたファイルの保存先
                Dim url As String = cfg.DLC_FOJP_URL.Text
                Dim fileName As String = Root & "Download\fojp.xml"
                'ファイル名保存
                Download_File_3 = Root & "Download\fojp.xml"

                'Event
                EventTxT.Refresh()
                EventTxT.Text = """DLC用fojp.xml""のダウンロードを開始します.."

                'リクエスト生成
                Dim webreq As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
                Dim webres As HttpWebResponse = DirectCast(webreq.GetResponse(), HttpWebResponse)
                Dim strm As Stream = webres.GetResponseStream()
                Dim fs As New FileStream(fileName, FileMode.Create, FileAccess.Write)
                Dim readData As Byte() = New Byte(1023) {}
                While True
                    Dim readSize As Integer = strm.Read(readData, 0, readData.Length)
                    If readSize = 0 Then
                        Exit While
                    End If
                    fs.Write(readData, 0, readSize)
                End While
                '残骸処理をする
                fs.Close()
                strm.Close()
                'WebClient完了時に確認していた処理を実施
                'FOJPダウンロード
                '解凍処理
                '解凍処理前にハッシュチェック
                If Hashsan.Checked Then
                    Unzip_1_()
                Else
                    Hash_file_1()
                End If
            Catch access_error As System.Security.SecurityException
                MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DownloadButtons.Text = "Download" & vbCr & "(NVSE/FOJP/翻訳)"
                DownloadButtons.Enabled = True
            Catch wq As Exception
                MessageBox.Show(wq.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End Try
        End Try
    End Sub

    Private Sub Unzip_1_()
        Try
            'NVJP解凍
            'ファイル名を取得する
            Dim FILE_NAME_UNP As String = Path.GetFileNameWithoutExtension(Download_File_1)
            '解凍ファイル名
            unPack_FileName_1 = FILE_NAME_UNP
            '作成するZIP書庫のパス 
            Dim zipFileName As String = Download_File_1
            '圧縮するフォルダのパス 
            Dim sourceDirectory As String = Root & "Data\"
            Dim fileFilter As String = ""
            Dim fastZipEvents As New ICSharpCode.SharpZipLib.Zip.FastZipEvents()
            fastZipEvents.CompletedFile = New ICSharpCode.SharpZipLib.Core.CompletedFileHandler(AddressOf CompletedFile)
            fastZipEvents.Progress = New ICSharpCode.SharpZipLib.Core.ProgressHandler(AddressOf Progress)
            Dim fastZip As New ICSharpCode.SharpZipLib.Zip.FastZip(fastZipEvents)
            'DL完了合図
            DL_1_ = True
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """New Vegas Script Extender""の解凍を開始します.."
            '圧縮してZIP書庫を作成 
            fastZip.ExtractZip(zipFileName, sourceDirectory, fileFilter)
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub Unzip_2_()
        Try
            'FOJP解凍
            'ファイル名を取得する
            Dim FILE_NAME_UNP As String = Path.GetFileNameWithoutExtension(Download_File_2)
            '解凍ファイル名
            unPack_FileName_2 = FILE_NAME_UNP
            '作成するZIP書庫のパス 
            Dim zipFileName As String = Download_File_2
            '圧縮するフォルダのパス 
            Dim sourceDirectory As String = Root & "Data\"
            Dim fileFilter As String = ""
            Dim fastZipEvents As New ICSharpCode.SharpZipLib.Zip.FastZipEvents()
            fastZipEvents.CompletedFile = New ICSharpCode.SharpZipLib.Core.CompletedFileHandler(AddressOf CompletedFile)
            fastZipEvents.Progress = New ICSharpCode.SharpZipLib.Core.ProgressHandler(AddressOf Progress)
            Dim fastZip As New ICSharpCode.SharpZipLib.Zip.FastZip(fastZipEvents)
            'DL完了合図
            DL_2_ = True
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """Fallout JP""の解凍を開始します.."
            '圧縮してZIP書庫を作成 
            fastZip.ExtractZip(zipFileName, sourceDirectory, fileFilter)
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub Unzip_3_()
        Try
            'NVJP解凍
            '作成するZIP書庫のパス 
            Dim zipFileName As String = Root & "Download\fonvj-dictionary-pack.zip"
            '圧縮するフォルダのパス 
            Dim sourceDirectory As String = Root & "Data\"
            Dim fileFilter As String = ""
            Dim fastZipEvents As New ICSharpCode.SharpZipLib.Zip.FastZipEvents()
            fastZipEvents.CompletedFile = New ICSharpCode.SharpZipLib.Core.CompletedFileHandler(AddressOf CompletedFile)
            fastZipEvents.Progress = New ICSharpCode.SharpZipLib.Core.ProgressHandler(AddressOf Progress)
            Dim fastZip As New ICSharpCode.SharpZipLib.Zip.FastZip(fastZipEvents)
            'DL完了合図
            DL_3_ = True
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """日本語化用辞書ファイル""の解凍を開始します.."
            '圧縮してZIP書庫を作成 
            fastZip.ExtractZip(zipFileName, sourceDirectory, fileFilter)
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub Hash_file_1()
        If NVSE_checks.Checked Then
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """New Vegas Script Extender [Beta]""のハッシュ(整合性)チェックを開始します.."

            'ハッシュチェック用
            Dim fileName As String = Download_File_1
            Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
            Dim md5 As New Cryptography.MD5CryptoServiceProvider()
            Dim bs As Byte() = md5.ComputeHash(fs)
            md5.Clear()
            fs.Close()
            Dim result As New System.Text.StringBuilder()
            For Each b As Byte In bs
                result.Append(b.ToString("x2"))
            Next
            'チェック
            If result.ToString() = cfg.NVSE_BETA_MD5.Text Then
                Hash_file_2()
            Else
                '再ダウンロードする（二重DL確認）
                If Hash1_ Then
                    '二度目の失敗はオフライン推奨
                    MessageBox.Show("Error:" & "再ダウンロードしましたがダウンロードファイルが破損しています。" & vbCr & _
                                    "お時間を空けてダウンロードするか、オフラインモードに切り換えて下さい" & vbCr & vbCr & _
                                    "File:" & fileName & vbCr & vbCr & _
                                    "MD5(設定値):" & cfg.NVSE_BETA_MD5.Text & vbCr & vbCr & _
                                    "MD5(DL値):" & result.ToString(), _
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ClearDownload()
                Else
                    '無限ループ回避
                    Hash1_ = True
                    Try
                        '例外エラー対策で一度初期化する
                        Directory.Delete(Root & "Data", True)
                        Directory.Delete(Root & "Download", True)
                        'New Vegas Script Extender 
                        download_ready()
                        DownloadButtons.Enabled = False
                    Catch access_error As System.Security.SecurityException
                        MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                        "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Application.Exit()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Application.Exit()
                    End Try
                End If
            End If
        Else
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """New Vegas Script Extender""のハッシュ(整合性)チェックを開始します.."

            'ハッシュチェック用
            Dim fileName As String = Download_File_1
            Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
            Dim md5 As New Cryptography.MD5CryptoServiceProvider()
            Dim bs As Byte() = md5.ComputeHash(fs)
            md5.Clear()
            fs.Close()
            Dim result As New System.Text.StringBuilder()
            For Each b As Byte In bs
                result.Append(b.ToString("x2"))
            Next
            'チェック
            If result.ToString() = cfg.NVSE_MD5.Text Then
                Hash_file_2()
            Else
                '再ダウンロードする（二重DL確認）
                If Hash1_ Then
                    '二度目の失敗はオフライン推奨
                    MessageBox.Show("Error:" & "再ダウンロードしましたがダウンロードファイルが破損しています。" & vbCr & _
                                    "お時間を空けてダウンロードするか、オフラインモードに切り換えて下さい" & vbCr & vbCr & _
                                    "File:" & fileName & vbCr & vbCr & _
                                    "MD5(設定値):" & cfg.NVSE_MD5.Text & vbCr & vbCr & _
                                    "MD5(DL値):" & result.ToString(), _
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ClearDownload()
                Else
                    '無限ループ回避
                    Hash1_ = True
                    Try
                        '例外エラー対策で一度初期化する
                        Directory.Delete(Root & "Data", True)
                        Directory.Delete(Root & "Download", True)
                        'New Vegas Script Extender 
                        download_ready()
                        DownloadButtons.Enabled = False
                    Catch access_error As System.Security.SecurityException
                        MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                        "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Application.Exit()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Application.Exit()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub Hash_file_2()
        'Event
        EventTxT.Refresh()
        EventTxT.Text = """Fallout JP""のダウンロードをハッシュ(整合性)チェックします.."

        'ハッシュチェック用
        Dim fileName As String = Download_File_2
        Dim fs As New FileStream(fileName, _
            FileMode.Open, FileAccess.Read)
        Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bs As Byte() = md5.ComputeHash(fs)
        md5.Clear()
        fs.Close()
        Dim result As New System.Text.StringBuilder()
        For Each b As Byte In bs
            result.Append(b.ToString("x2"))
        Next
        'チェック
        If result.ToString() = cfg.FOJP_MD5.Text Then
            Hash_file_3()
        Else
            '再ダウンロードする（二重DL確認）
            If Hash2_ Then
                '二度目の失敗はオフライン推奨
                MessageBox.Show("Error:" & "再ダウンロードしましたがダウンロードファイルが破損しています。" & vbCr & _
                                "お時間を空けてダウンロードするか、オフラインモードに切り換えて下さい" & vbCr & vbCr & _
                                "File:" & fileName & vbCr & vbCr & _
                                "MD5(設定値):" & cfg.FOJP_MD5.Text & vbCr & vbCr & _
                                "MD5(DL値):" & result.ToString(), _
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ClearDownload()
            Else
                '無限ループ回避
                Hash2_ = True
                Try
                    'Fallout 日本語化必須ファイル
                    download_ready()
                    DownloadButtons.Enabled = False
                Catch access_error As System.Security.SecurityException
                    MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                    "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End Try
            End If
        End If
    End Sub

    Private Sub Hash_file_3()
        'Event
        EventTxT.Refresh()
        EventTxT.Text = """DLC用fojp.xml""のハッシュ(整合性)チェックを開始します.."

        'ハッシュチェック用
        Dim fileName As String = Download_File_3
        Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim md5 As New Cryptography.MD5CryptoServiceProvider()
        Dim bs As Byte() = md5.ComputeHash(fs)
        md5.Clear()
        fs.Close()
        Dim result As New System.Text.StringBuilder()
        For Each b As Byte In bs
            result.Append(b.ToString("x2"))
        Next
        'チェック
        If result.ToString() = cfg.DLC_MD5.Text Then
            '解凍処理
            Unzip_1_()
        Else
            '再ダウンロードする（二重DL確認）
            If Hash3_ Then
                '二度目の失敗はオフライン推奨
                MessageBox.Show("Error:" & "再ダウンロードしましたがダウンロードファイルが破損しています。" & vbCr & _
                                "お時間を空けてダウンロードするか、オフラインモードに切り換えて下さい" & vbCr & vbCr & _
                                "File:" & fileName & vbCr & vbCr & _
                                "MD5(設定値):" & cfg.DLC_MD5.Text & vbCr & vbCr & _
                                "MD5(DL値):" & result.ToString(), _
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ClearDownload()
            Else
                '無限ループ回避
                Hash3_ = True
                Try
                    'Fallout 日本語化必須ファイル
                    download_ready()
                    DownloadButtons.Enabled = False
                Catch access_error As System.Security.SecurityException
                    MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                                    "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End Try
            End If
        End If
    End Sub

    Private Sub JPButtons_Click(sender As Object, e As EventArgs) Handles JPButtons.Click
        Try
            '短縮化
            Dim FONVPath As String = Path_pass.Text

            'オフライン用
            If UIC Then
                'パス確認
                If Path_pass.Text = "" Then
                    MessageBox.Show("...\SteamApps\common\Fallout New Vegas" & vbCr & vbCr & _
                                    "上記までのフルパスを指定してください。", "Null Error", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If Directory.Exists(Root & "Download") Then
                        'パス確認
                        If Path_pass.Text = "" Then
                            MessageBox.Show("...\SteamApps\common\Fallout New Vegas" & vbCr & vbCr & _
                                            "上記までのフルパスを指定してください。", "Null Error", _
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            '適用開始
                            If CheckBox1.Checked Then
                                If File.Exists(Root & "Download\fojp.xml") Then
                                    'Event
                                    EventTxT.Refresh()
                                    EventTxT.Text = """fojp.xml""のコピーを開始します.."
                                    'fojp.xml
                                    File.Copy(Root & "Download\fojp.xml", _
                                                        FONVPath & "\fojp.xml", True)
                                    Directory1()
                                Else
                                    MessageBox.Show(Root & "\Data\fojp.xml" & vbCr & vbCr & _
                                                    "ファイルが見つかりません。再度ダウンロードして下さい", "Error", _
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            Else
                                'DLCなし
                                If File.Exists(Root & "\Data\" & unPack_FileName_2 & "\fojp.xml") Then
                                    'Event
                                    EventTxT.Refresh()
                                    EventTxT.Text = """fojp.xml""のコピーを開始します.."
                                    'fojp.xml
                                    File.Copy(Root & "\Data\" & unPack_FileName_2 & "\fojp.xml", _
                                                        FONVPath & "\fojp.xml", True)
                                    Directory1()
                                Else
                                    MessageBox.Show(Root & "\Data\" & unPack_FileName_2 & "\fojp.xml" & vbCr & vbCr & _
                                                    "ファイルが見つかりません。再度ダウンロードして下さい", "Error", _
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End If
                    Else
                        MessageBox.Show(Root & "Download" & vbCr & vbCr & _
                                        "オフライン用ファイルがありません。確認してください", "No Download File", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                'パス確認
                If Path_pass.Text = "" Then
                    MessageBox.Show("...\SteamApps\common\Fallout New Vegas" & vbCr & vbCr & _
                                    "上記までのフルパスを指定してください。", "Null Error", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'パス確認
                    If Path_pass.Text = "" Then
                        MessageBox.Show("...\SteamApps\common\Fallout New Vegas" & vbCr & vbCr & _
                                        "上記までのフルパスを指定してください。", "Null Error", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        '適用開始
                        If CheckBox1.Checked Then
                            If File.Exists(Root & "Download\fojp.xml") Then
                                'Event
                                EventTxT.Refresh()
                                EventTxT.Text = """fojp.xml""のコピーを開始します.."
                                'fojp.xml
                                File.Copy(Root & "Download\fojp.xml", _
                                                    FONVPath & "\fojp.xml", True)
                                Directory1()
                            Else
                                MessageBox.Show(Root & "\Data\fojp.xml" & vbCr & vbCr & _
                                                "ファイルが見つかりません。再度ダウンロードして下さい", "Error", _
                                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            'DLCなし
                            If File.Exists(Root & "\Data\" & unPack_FileName_2 & "\fojp.xml") Then
                                'Event
                                EventTxT.Refresh()
                                EventTxT.Text = """fojp.xml""のコピーを開始します.."
                                'fojp.xml
                                File.Copy(Root & "\Data\" & unPack_FileName_2 & "\fojp.xml", _
                                                    FONVPath & "\fojp.xml", True)
                                Directory1()
                            Else
                                MessageBox.Show(Root & "\Data\" & unPack_FileName_2 & "\fojp.xml" & vbCr & vbCr & _
                                                "ファイルが見つかりません。再度ダウンロードして下さい", "Error", _
                                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End If
                End If
            End If

        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub Directory1()
        Try
            '短縮化
            Dim FONVPath As String = Path_pass.Text
            'Event
            EventTxT.Refresh()
            EventTxT.Text = "プラグインフォルダ作成と""_fojp""のコピーを開始します.."
            Try
                'プラグイン
                If Directory.Exists(FONVPath & "\Data\NVSE\plugins") Then
                    '_fojp.dll
                    If File.Exists(Root & "\Data\" & unPack_FileName_2 & "\_fojp.dll") Then
                        File.Copy(Root & "\Data\" & unPack_FileName_2 & "\_fojp.dll", _
                                            FONVPath & "\Data\NVSE\plugins\_fojp.dll", True)
                        Directory2()
                    Else
                        MessageBox.Show(Root & "\Data\" & unPack_FileName_2 & "\fojp.xml" & vbCr & vbCr & _
                                        "ファイルが見つかりません。再度ダウンロードして下さい", "Error", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    'フォルダ生成(プラグイン)
                    Directory.CreateDirectory(FONVPath & "\Data\NVSE\plugins")
                    If File.Exists(Root & "\Data\" & unPack_FileName_2 & "\_fojp.dll") Then
                        File.Copy(Root & "\Data\" & unPack_FileName_2 & "\_fojp.dll", _
                                            FONVPath & "\Data\NVSE\plugins\_fojp.dll", True)
                        Directory2()
                    Else
                        MessageBox.Show(Root & "\Data\" & unPack_FileName_2 & "\fojp.xml" & vbCr & vbCr & _
                                        "ファイルが見つかりません。再度ダウンロードして下さい", "Error", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End Try

        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Directory2()
        Try
            '短縮化
            Dim FONVPath As String = Path_pass.Text
            'Event
            EventTxT.Refresh()
            EventTxT.Text = """Font""フォルダのコピーを開始します.."
            'フォント
            If Directory.Exists(FONVPath & "\Data\Textures\fonts") Then
                '残骸判定
                If Directory.Exists(Root & "\Data\" & unPack_FileName_2 & "\【NV】VANILLAのフォント") Then
                    '処理簡易化の為のコピー後削除
                    My.Computer.FileSystem.CopyDirectory(Root & "\Data\" & unPack_FileName_2 & "\【NV】VANILLAのフォント", _
                                                         Root & "\Data\" & unPack_FileName_2 & "\font", _
                                                         FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                    ' フォルダを削除する
                    Directory.Delete(Root & "\Data\" & unPack_FileName_2 & "\【NV】VANILLAのフォント", True)
                    '更に処理簡易化のため丸ごとコピー
                    CopyDirectory(Root & "\Data\" & unPack_FileName_2 & "\font", _
                                  FONVPath & "\Data\Textures\fonts", True)
                    Directory3()
                Else
                    '更に処理簡易化のため丸ごとコピー
                    CopyDirectory(Root & "\Data\" & unPack_FileName_2 & "\font", _
                                  FONVPath & "\Data\Textures\fonts", True)
                    Directory3()
                End If
            Else
                'フォルダ生成(フォント)
                Directory.CreateDirectory(FONVPath & "\Data\Textures\fonts")
                '残骸判定
                If Directory.Exists(Root & "\Data\" & unPack_FileName_2 & "\【NV】VANILLAのフォント") Then
                    '処理簡易化の為のコピー後削除
                    My.Computer.FileSystem.CopyDirectory(Root & "\Data\" & unPack_FileName_2 & "\【NV】VANILLAのフォント", _
                                                         Root & "\Data\" & unPack_FileName_2 & "\font", _
                                                         FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                    ' フォルダを削除する
                    Directory.Delete(Root & "\Data\" & unPack_FileName_2 & "\【NV】VANILLAのフォント", True)
                    '更に処理簡易化のため丸ごとコピー
                    CopyDirectory(Root & "\Data\" & unPack_FileName_2 & "\font", _
                                  FONVPath & "\Data\Textures\fonts", True)
                    Directory3()
                Else
                    '更に処理簡易化のため丸ごとコピー
                    CopyDirectory(Root & "\Data\" & unPack_FileName_2 & "\font", _
                                  FONVPath & "\Data\Textures\fonts", True)
                    Directory3()
                End If
            End If
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Directory3()
        Try
            '短縮化
            Dim FONVPath As String = Path_pass.Text
            If CheckBox2.Checked Then
                'Event
                EventTxT.Refresh()
                EventTxT.Text = "ターミナルの日本語化を適用しています.."
                Try
                    'メニュー
                    If Directory.Exists(FONVPath & "\Data\Menus") Then
                        'computers_menu.xml
                        If File.Exists(Root & "\Data\" & unPack_FileName_2 & "\computers_menu.xml") Then
                            File.Copy(Root & "\Data\" & unPack_FileName_2 & "\computers_menu.xml", _
                                                FONVPath & "\Data\Menus\computers_menu.xml", True)
                            Directory4()
                        Else
                            MessageBox.Show(Root & "\Data\" & unPack_FileName_2 & "\computers_menu.xml" & vbCr & vbCr & _
                                            "ファイルが見つかりません。再度ダウンロードして下さい", "Error", _
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        'フォルダ生成(メニュー)
                        Directory.CreateDirectory(FONVPath & "\Data\Menus")
                        'computers_menu.xml
                        If File.Exists(Root & "\Data\" & unPack_FileName_2 & "\computers_menu.xml") Then
                            File.Copy(Root & "\Data\" & unPack_FileName_2 & "\computers_menu.xml", _
                                                FONVPath & "\Data\Menus\computers_menu.xml", True)
                            Directory4()
                        Else
                            MessageBox.Show(Root & "\Data\" & unPack_FileName_2 & "\computers_menu.xml" & vbCr & vbCr & _
                                            "ファイルが見つかりません。再度ダウンロードして下さい", "Error", _
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End Try
            Else
                Directory4()
            End If
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Directory4()
        '短縮化
        Dim FONVPath As String = Path_pass.Text
        'Event
        EventTxT.Refresh()
        EventTxT.Text = "NVJPを適用しています.."
        Try
            'NVJP
            If Directory.Exists(FONVPath & "\NVJP") Then
                CopyDirectory(Root & "\Data\" & unPack_FileName_2 & "\NVJP", FONVPath & "\NVJP", True)
                Directory5()
            Else
                'フォルダ生成(NVJP)
                Directory.CreateDirectory(FONVPath & "\NVJP")
                CopyDirectory(Root & "\Data\" & unPack_FileName_2 & "\NVJP", FONVPath & "\NVJP", True)
                Directory5()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub Directory5()
        Try
            '短縮化
            Dim FONVPath As String = Path_pass.Text
            'Event
            EventTxT.Refresh()
            EventTxT.Text = "NVSEを適用しています.."
            CopyDirectory(Root & "\Data\" & unPack_FileName_1, FONVPath, True)
            Directory6()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub Directory6()
        '短縮化
        Dim FONVPath As String = Path_pass.Text
        'Event
        EventTxT.Refresh()
        EventTxT.Text = "日本語化を適用しています.."
        Try
            'FOJP2_v4_6削除
            If Directory.Exists(Download_File_2) Then
                Directory.Delete(Download_File_2, True)
                'NVJP_4_5削除
                If Directory.Exists(Download_File_1) Then
                    Directory.Delete(Download_File_1, True)
                    'Readme削除
                    If File.Exists(Root & "\Data\~readme.txt") Then
                        File.Delete(Root & "\Data\~readme.txt")
                        '日本語化ファイルコピー
                        CopyDirectory(Root & "\Data", FONVPath & "\NVJP", True)
                        'Event
                        EventTxT.Refresh()
                        EventTxT.Text = """Fallout: New Vegas""の日本語化の適用が完了しました。再度ダウンロードする場合は電球をクリックして下さい。"
                        MessageBox.Show("""Fallout: New Vegas""の日本語化の適用が完了しました", "日本語化適用完了", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'アンインスコも有効
                        UnistallButtons.Refresh()
                        NVSE_DEL.Checked = False
                        UnInstall_check_system()
                        '無効化
                        JPButtons.Enabled = False
                        JPButtons.Text = "日本語化を適用する" & vbCr & "(ダウンロードしてください)"
                    Else
                        CopyDirectory(Root & "\Data", FONVPath & "\NVJP", True)
                        'Event
                        EventTxT.Refresh()
                        EventTxT.Text = """Fallout: New Vegas""の日本語化の適用が完了しました"
                        MessageBox.Show("""Fallout: New Vegas""の日本語化の適用が完了しました", "日本語化適用完了", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'アンインスコも有効
                        UnistallButtons.Refresh()
                        NVSE_DEL.Checked = False
                        UnInstall_check_system()
                    End If
                Else
                    'NVJP_4_5 :なし
                    'Readme削除
                    If File.Exists(Root & "\Data\~readme.txt") Then
                        File.Delete(Root & "\Data\~readme.txt")
                        '日本語化ファイルコピー
                        CopyDirectory(Root & "\Data", FONVPath & "\NVJP", True)
                        'Event
                        EventTxT.Refresh()
                        EventTxT.Text = """Fallout: New Vegas""の日本語化の適用が完了しました"
                        MessageBox.Show("""Fallout: New Vegas""の日本語化の適用が完了しました", "日本語化適用完了", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'アンインスコも有効
                        UnistallButtons.Refresh()
                        NVSE_DEL.Checked = False
                        UnInstall_check_system()
                        '無効化
                        JPButtons.Enabled = False
                        JPButtons.Text = "日本語化を適用する" & "(ダウンロードしてください)"
                    Else
                        CopyDirectory(Root & "\Data", FONVPath & "\NVJP", True)
                        'Event
                        EventTxT.Refresh()
                        EventTxT.Text = """Fallout: New Vegas""の日本語化の適用が完了しました"
                        MessageBox.Show("""Fallout: New Vegas""の日本語化の適用が完了しました", "日本語化適用完了", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'アンインスコも有効
                        UnistallButtons.Refresh()
                        NVSE_DEL.Checked = False
                        UnInstall_check_system()
                    End If
                End If
            Else
                'FOJP2_v4_6 :なし
                'NVJP_4_5削除
                If Directory.Exists(Root & "\Data\" & unPack_FileName_1) Then
                    Directory.Delete(Root & "\Data\" & unPack_FileName_1, True)
                    'Readme削除
                    If File.Exists(Root & "\Data\~readme.txt") Then
                        File.Delete(Root & "\Data\~readme.txt")
                        '日本語化ファイルコピー
                        CopyDirectory(Root & "\Data", FONVPath & "\NVJP", True)
                        'Event
                        EventTxT.Refresh()
                        EventTxT.Text = """Fallout: New Vegas""の日本語化の適用が完了しました"
                        MessageBox.Show("""Fallout: New Vegas""の日本語化の適用が完了しました", "日本語化適用完了", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'アンインスコも有効
                        UnistallButtons.Refresh()
                        NVSE_DEL.Checked = False
                        UnInstall_check_system()
                        '無効化
                        JPButtons.Enabled = False
                        JPButtons.Text = "日本語化を適用する" & vbCr & "(ダウンロードしてください)"
                    Else
                        CopyDirectory(Root & "\Data", FONVPath & "\NVJP", True)
                        'Event
                        EventTxT.Refresh()
                        EventTxT.Text = """Fallout: New Vegas""の日本語化の適用が完了しました"
                        MessageBox.Show("""Fallout: New Vegas""の日本語化の適用が完了しました", "日本語化適用完了", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'アンインスコも有効
                        UnistallButtons.Refresh()
                        NVSE_DEL.Checked = False
                        UnInstall_check_system()
                        '無効化
                        JPButtons.Enabled = False
                        JPButtons.Text = "日本語化を適用する" & vbCr & "(ダウンロードしてください)"
                    End If
                Else
                    'NVJP_4_5 :なし
                    'Readme削除
                    If File.Exists(Root & "\Data\~readme.txt") Then
                        File.Delete(Root & "\Data\~readme.txt")
                        '日本語化ファイルコピー
                        CopyDirectory(Root & "\Data", FONVPath & "\NVJP", True)
                        'Event
                        EventTxT.Refresh()
                        EventTxT.Text = """Fallout: New Vegas""の日本語化の適用が完了しました"
                        MessageBox.Show("""Fallout: New Vegas""の日本語化の適用が完了しました", "日本語化適用完了", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'アンインスコも有効
                        UnistallButtons.Refresh()
                        NVSE_DEL.Checked = False
                        UnInstall_check_system()
                        '無効化
                        JPButtons.Enabled = False
                        JPButtons.Text = "日本語化を適用する" & vbCr & "(ダウンロードしてください)"
                    Else
                        CopyDirectory(Root & "\Data", FONVPath & "\NVJP", True)
                        'Event
                        EventTxT.Refresh()
                        EventTxT.Text = """Fallout: New Vegas""の日本語化の適用が完了しました"
                        MessageBox.Show("""Fallout: New Vegas""の日本語化の適用が完了しました", "日本語化適用完了", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'アンインスコも有効
                        UnistallButtons.Refresh()
                        NVSE_DEL.Checked = False
                        UnInstall_check_system()
                        '無効化
                        JPButtons.Enabled = False
                        JPButtons.Text = "日本語化を適用する" & vbCr & "(ダウンロードしてください)"
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub
    Private Sub UnistallButtons_Click(sender As Object, e As EventArgs) Handles UnistallButtons.Click
        '日本語化ファイルのみアンインストール
        UnistallButtons.Enabled = False
        'NVSEチェック
        If NVSE_DEL.Checked Then
            'NVSE単体をアンインストールする場合
            UnInstall_NVSE_Only()
        Else
            'NVSEをアンインストールしない場合
            UnInstall_1.Enabled = True
        End If
    End Sub

    Private Sub UnInstall_check_system()
        '短縮化
        Dim FONVPath As String = Path_pass.Text & "\"

        If File.Exists(FONVPath & "\fojp.xml") Then
            UnistallButtons.Refresh()
            UnistallButtons.Text = "アンインストールする" & vbCr & "(準備完了)"
            NVSE_DEL_X.Text = "NVSEを削除しない"
            UnistallButtons.Enabled = True
            NVSE_DEL_X.Enabled = True
        Else
            If File.Exists(FONVPath & "\Data\NVSE\plugins\_fojp.dll") Then
                UnistallButtons.Refresh()
                UnistallButtons.Text = "アンインストールする" & vbCr & "(準備完了)"
                NVSE_DEL_X.Text = "NVSEを削除しない"
                UnistallButtons.Enabled = True
                NVSE_DEL_X.Enabled = True
            Else

                If File.Exists(FONVPath & "\nvse_loader.exe") Then
                    '警告メッセージを表示する前に作成
                    Me.WarningTxT = New System.Windows.Forms.Label()
                    Me.SuspendLayout()
                    Me.WarningTxT.Dock = DockStyle.Top
                    Me.WarningTxT.Size = New System.Drawing.Size(544, 25)
                    Me.WarningTxT.BackColor = Color.Yellow
                    Me.WarningTxT.ForeColor = Color.Red
                    Me.WarningTxT.Font = New Font("Meiryo UI", 6.75, FontStyle.Underline)
                    Me.WarningTxT.TextAlign = ContentAlignment.MiddleCenter
                    Me.Controls.Add(Me.WarningTxT)
                    Me.ResumeLayout(False)
                    WarningTxT.BringToFront()

                    WarningTxT.Refresh()
                    NVSE_DEL.Checked = True
                    WarningHide.Enabled = True
                    WarningTxT.Visible = True
                    WarningTxT.BringToFront()
                    WarningTxT.Text = _
                        "既に日本語化はアンインストールされていますが、" & _
                        """New Vegas Script Extender""が検出されました。NVSE単体をアンインストールしますか？" & vbCr & _
                        "他MODに影響する場合がありますが、それでも良いならボタンを押して下さい。(10秒後に非表示・有効化)"
                Else
                    UnistallButtons.Refresh()
                    UnistallButtons.Text = "アンインストール不可" & vbCr & "(ファイルなし)"
                    UnistallButtons.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub UnInstall_1_Tick(sender As Object, e As EventArgs) Handles UnInstall_1.Tick
        UnInstall_1.Enabled = False
        '短縮化
        Dim FONVPath As String = Path_pass.Text & "\"

        'NVSE UnInstall
        If NVSE_DEL_X.Checked Then
            UnInstall_2.Enabled = True
        Else
            Try
                'nvse_1_4.dll
                If File.Exists(FONVPath & "\nvse_1_4.dll") Then
                    File.Delete(FONVPath & "nvse_1_4.dll")
                    'nvse_1_4ng.dll
                    If File.Exists(FONVPath & "nvse_1_4ng.dll") Then
                        File.Delete(FONVPath & "nvse_1_4ng.dll")
                        'nvse_editor_1_4.dll
                        If File.Exists(FONVPath & "nvse_editor_1_4.dll") Then
                            File.Delete(FONVPath & "nvse_editor_1_4.dll")
                            'nvse_steam_loader.dll
                            If File.Exists(FONVPath & "nvse_steam_loader.dll") Then
                                File.Delete(FONVPath & "nvse_steam_loader.dll")
                                'nvse_loader.exe
                                If File.Exists(FONVPath & "nvse_loader.exe") Then
                                    File.Delete(FONVPath & "nvse_loader.exe")
                                    UnInstall_2.Enabled = True
                                Else
                                    'No! nvse_editor_1_4.dll
                                    UnInstall_2.Enabled = True
                                End If
                            Else
                                'No! nvse_steam_loader.dll
                                UnInstall_2.Enabled = True
                            End If
                        Else
                            'No! nvse_editor_1_4.dll
                            UnInstall_2.Enabled = True
                        End If
                    Else
                        'No! nvse_1_4ng.dll
                        UnInstall_2.Enabled = True
                    End If
                Else
                    'No! nvse_1_4.dll
                    UnInstall_2.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UnInstall_2.Enabled = True
            End Try
        End If
    End Sub

    Private Sub UnInstall_2_Tick(sender As Object, e As EventArgs) Handles UnInstall_2.Tick
        UnInstall_2.Enabled = False
        '短縮化
        Dim FONVPath As String = Path_pass.Text & "\"
        Try
            'FOJP2
            'NVSE選択
            If NVSE_DEL_X.Checked Then
                Dim un_fojp As New FileInfo(FONVPath & "fojp.xml")
                Dim un_log As New FileInfo(FONVPath & "fojp.log")
                Dim un_font_1 As New FileInfo(FONVPath & "Data\Textures\fonts\baked-in_monofonto_large.fnt")
                Dim un_font_2 As New FileInfo(FONVPath & "Data\Textures\fonts\fixedsys_comp_uniform_width.fnt")
                Dim un_font_3 As New FileInfo(FONVPath & "Data\Textures\fonts\glow_futura_caps_large.fnt")
                Dim un_font_4 As New FileInfo(FONVPath & "Data\Textures\fonts\glow_monofonto_large.fnt")
                Dim un_font_5 As New FileInfo(FONVPath & "Data\Textures\fonts\glow_monofonto_medium.fnt")
                Dim un_font_6 As New FileInfo(FONVPath & "Data\Textures\fonts\glow_monofonto_vl_dialogs.fnt")
                Dim un_font_7 As New FileInfo(FONVPath & "Data\Textures\fonts\monofonto_large.fnt")
                Dim un_font_8 As New FileInfo(FONVPath & "Data\Textures\fonts\monofonto_verylarge02_dialogs2.fnt")
                Dim un_font_9 As New FileInfo(FONVPath & "Data\Textures\fonts\nvfont_test.fnt")
                Dim un_menu_cp As New FileInfo(FONVPath & "Data\Menus\computers_menu.xml")
                '削除する
                un_fojp.Delete()
                un_font_1.Delete()
                un_font_2.Delete()
                un_font_3.Delete()
                un_font_4.Delete()
                un_font_5.Delete()
                un_font_6.Delete()
                un_font_7.Delete()
                un_font_8.Delete()
                un_font_9.Delete()
                un_menu_cp.Delete()
                '辞典削除
                UnInstall_3.Enabled = True
            Else
                'NVSE削除
                DeleteDirectory(FONVPath & "Data\NVSE")
                Dim un_fojp As New FileInfo(FONVPath & "fojp.xml")
                Dim un_log As New FileInfo(FONVPath & "fojp.log")
                Dim un_font_1 As New FileInfo(FONVPath & "Data\Textures\fonts\baked-in_monofonto_large.fnt")
                Dim un_font_2 As New FileInfo(FONVPath & "Data\Textures\fonts\fixedsys_comp_uniform_width.fnt")
                Dim un_font_3 As New FileInfo(FONVPath & "Data\Textures\fonts\glow_futura_caps_large.fnt")
                Dim un_font_4 As New FileInfo(FONVPath & "Data\Textures\fonts\glow_monofonto_large.fnt")
                Dim un_font_5 As New FileInfo(FONVPath & "Data\Textures\fonts\glow_monofonto_medium.fnt")
                Dim un_font_6 As New FileInfo(FONVPath & "Data\Textures\fonts\glow_monofonto_vl_dialogs.fnt")
                Dim un_font_7 As New FileInfo(FONVPath & "Data\Textures\fonts\monofonto_large.fnt")
                Dim un_font_8 As New FileInfo(FONVPath & "Data\Textures\fonts\monofonto_verylarge02_dialogs2.fnt")
                Dim un_font_9 As New FileInfo(FONVPath & "Data\Textures\fonts\nvfont_test.fnt")
                Dim un_menu_cp As New FileInfo(FONVPath & "Data\Menus\computers_menu.xml")
                '削除する
                un_fojp.Delete()
                un_log.Delete()
                un_font_1.Delete()
                un_font_2.Delete()
                un_font_3.Delete()
                un_font_4.Delete()
                un_font_5.Delete()
                un_font_6.Delete()
                un_font_7.Delete()
                un_font_8.Delete()
                un_font_9.Delete()
                un_menu_cp.Delete()
                '辞典削除
                UnInstall_3.Enabled = True
            End If
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            UnInstall_3.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            UnInstall_3.Enabled = True
        End Try
    End Sub

    Private Sub UnInstall_3_Tick(sender As Object, e As EventArgs) Handles UnInstall_3.Tick
        UnInstall_3.Enabled = False

        '短縮化
        Dim FONVPath As String = Path_pass.Text & "\"
        Try
            '更に残骸チェック
            If Directory.Exists(FONVPath & "Data\Menus") Then
                DeleteDirectory(FONVPath & "Data\Menus")
            Else
            End If
            If Directory.Exists(FONVPath & "Data\NVSE") Then
                DeleteDirectory(FONVPath & "Data\NVSE")
            Else
            End If
            If Directory.Exists(FONVPath & "\Data\Textures\fonts") Then
                DeleteDirectory(FONVPath & "\Data\Textures\fonts")
            Else
            End If

            UnInstall_End.Enabled = True
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub UnInstall_End_Tick(sender As Object, e As EventArgs) Handles UnInstall_End.Tick
        UnInstall_End.Enabled = False

        '短縮化
        Dim FONVPath As String = Path_pass.Text & "\"
        Try
            '辞典
            If Directory.Exists(FONVPath & "NVJP") Then
                DeleteDirectory(FONVPath & "NVJP")
                '完了メッセージ
                'Event
                EventTxT.Refresh()
                EventTxT.Text = "全ての日本語化パッチを削除しました。" & vbCr & "エラーが発生した場合は手動でお願いします"
                UnistallButtons.Refresh()
                UnistallButtons.Text = "アンインストールした" & vbCr & "(完了)"
            Else
                '完了メッセージ
                'Event
                EventTxT.Refresh()
                EventTxT.Text = "全ての日本語化パッチを削除しました。" & vbCr & "エラーが発生した場合は手動でお願いします"
                UnistallButtons.Refresh()
                UnistallButtons.Text = "アンインストールした" & vbCr & "(完了)"
            End If
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UnInstall_NVSE_Only()
        '短縮化
        Dim FONVPath As String = Path_pass.Text & "\"
        Try
            'NVSE単体削除する前に設定
            Dim un_nvse_1 As New FileInfo(FONVPath & "nvse_1_4.dll")
            Dim un_nvse_2 As New FileInfo(FONVPath & "nvse_1_4ng.dll")
            Dim un_nvse_3 As New FileInfo(FONVPath & "nvse_editor_1_4.dll")
            Dim un_nvse_4 As New FileInfo(FONVPath & "nvse_loader.exe")
            Dim un_nvse_5 As New FileInfo(FONVPath & "nvse_steam_loader.dll")
            '削除する
            un_nvse_1.Delete()
            un_nvse_2.Delete()
            un_nvse_3.Delete()
            un_nvse_4.Delete()
            un_nvse_5.Delete()
            '完了メッセージ
            'Event
            EventTxT.Refresh()
            EventTxT.Text = "NVSEの本体を削除しました。エラーが発生した場合は手動でお願いします"
            UnistallButtons.Refresh()
            UnistallButtons.Text = "アンインストールした" & vbCr & "(完了)"
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr & _
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい", _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles optionButtons.Click
        '表示する
        cfg.Visible = True
    End Sub

    Private Sub offline_mode_1_Click(sender As Object, e As EventArgs) Handles offline_mode_1.Click
        If offline_mode_1.Text = "オフラインモード" Then
            'オフラインモード仕様にする
            If Directory.Exists(Root & "Download") Then
                'タイトル変更
                toolname = Me.Text
                Me.Text = toolname & " - オフラインモード"

                'Event
                EventTxT.Refresh()
                EventTxT.Text = "オフラインモードに変更されました。戻す時はオンラインモードにして下さい"

                'テキスト変更
                offline_mode_1.Text = "オンラインモード"
                JPButtons.Text = "日本語化を適用する" & vbLf & "(オフラインモード)"

                '有効化
                re_download_pabnel.Enabled = False
                DownloadButtons.Visible = False
                JPButtons.Enabled = True

                '位置変更
                Me.JPButtons.SetBounds(18, 198, 254, 42, BoundsSpecified.All)
                JPButtons.Refresh()
            Else
                MessageBox.Show("オフラインモードに切り替える為のデータ・ダウンロードフォルダがありません", _
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            'タイトル変更
            Me.Text = "Fallout: New Vegas Japanese Patch"

            'Event
            EventTxT.Refresh()
            EventTxT.Text = "オンラインモードに変更されました。"

            'テキスト変更
            offline_mode_1.Text = "オフラインモード"
            JPButtons.Text = "日本語化を適用する" & vbLf & "(ダウンロードしてください)"

            '有効化
            re_download_pabnel.Enabled = False
            DownloadButtons.Visible = True
            JPButtons.Enabled = False

            '位置変更
            Me.JPButtons.SetBounds(148, 198, 124, 42, BoundsSpecified.All)
        End If
    End Sub
End Class
