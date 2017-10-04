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
    Private Sub OptiButton_Click(sender As Object, e As EventArgs) Handles OptiButton.Click
        options.Visible = True
        options.Show()
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
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr &
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub
    Public Overloads Shared Sub DeleteDirectory(ByVal stDirPath As String)
        Try
            Call DeleteDirectory(New DirectoryInfo(stDirPath))
        Catch access_error As System.Security.SecurityException
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr &
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
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
            MessageBox.Show("Error:" & access_error.Message & vbCr & vbCr &
                            "アクセス権限が足りませんでした。管理者へお問い合わせ下さい",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub mains_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '実行中のアプリケーションパスが正しく取得出来ているか
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\Fallout3_Japanese.exe") Then
                Root = AppDomain.CurrentDomain.BaseDirectory
                '実行中ディレクトリにFallout3がある場合
                If File.Exists(Root & "Fallout3.exe") Then
                    '説明文非表示
                    path_txt.Visible = False
                    'パス代入
                    paths.Text = Root
                End If
            Else
                '存在しない場合(旧式)
                If File.Exists(Application.StartupPath & "\Fallout3_Japanese.exe") Then
                    Root = Application.StartupPath & "\"
                    '実行中ディレクトリにFallout3がある場合
                    If File.Exists(Root & "FalloutNV.exe") Then
                        '説明文非表示
                        path_txt.Visible = False
                        'パス代入
                        paths.Text = Root
                    End If
                Else
                    'それでも見つからない場合
                    MessageBox.Show("申し訳ありません。このユーザでは権限不足もしくは環境の問題により" & vbCr &
                                    "取得出来ませんでした。" & vbCr & vbCr &
                                    "管理者として実行するか、ユーザをご変更してください。", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Application.Exit()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("申し訳ありません。このユーザでは権限不足もしくは環境の問題により" & vbCr &
                            "取得出来ませんでした。" & vbCr & vbCr &
                            "管理者として実行するか、ユーザをご変更してください。", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try

    End Sub
    Private Sub ViewerButton_MouseDown(sender As Object, e As MouseEventArgs) Handles ViewerButton.MouseDown
        If (Control.MouseButtons And MouseButtons.Left) = MouseButtons.Left Then
            Try
                Dim directryopens As New FolderBrowserDialog
                directryopens.Description = "Fallout3.exeがあるフォルダを指定してください。"
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
                            '説明文非表示
                            path_txt.Visible = False
                            'テキスト設置
                            paths.Text = directryopens.SelectedPath
                            'アンインストール確認
                            '#########################
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                paths.ReadOnly = False
            End Try
        End If
        If (Control.MouseButtons And MouseButtons.Right) = MouseButtons.Right Then
            Try
                Dim fileop As New OpenFileDialog()
                '最初にデスクトップを指定する
                Dim Desktop_select As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop)
                fileop.FileName = "Fallout3.exe"
                fileop.InitialDirectory = Desktop_select
                fileop.Filter =
                    "実行ファイル(*.exe)|*.exe"
                fileop.FilterIndex = 1
                'タイトルを設定する
                fileop.Title = "FalloutNV.exeがあるフォルダまで行き、Fallout3.exeを指定してください。"
                fileop.RestoreDirectory = True
                fileop.CheckFileExists = True
                fileop.CheckPathExists = True
                If fileop.ShowDialog() = DialogResult.OK Then 'fileop.FileName
                    Dim Path_FilePath As String = Path.GetDirectoryName(fileop.FileName)
                    'それ本当にFalloutNV.exe?
                    If File.Exists(Path_FilePath & "\Fallout3.exe") Then
                        '確認
                        'パスに使用出来ない文字確認
                        Dim filepath As String = Path_FilePath
                        Dim invalidPathChars As Char() = Path.GetInvalidPathChars()
                        For Each invalidChar As Char In invalidPathChars
                            If filepath.IndexOf(invalidChar) > -1 Then
                                MessageBox.Show("使用できない文字 " & invalidChar.ToString() & " が含まれています。")
                            Else
                                '説明文非表示
                                path_txt.Visible = False
                                'テキスト設置
                                paths.Text = Path_FilePath
                                'アンインストール確認
                                '#########################
                                Exit For
                            End If
                        Next
                    Else
                        'NO
                        MessageBox.Show("これはFallout3.exeではありません", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                paths.ReadOnly = False
            End Try
        End If
    End Sub

    Private Sub DownloadButton_Click(sender As Object, e As EventArgs) Handles DownloadButton.Click
        'インターネットオフラインチェック
        If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then

            '不具合対策(FOSEチェック無効化)
            fose_1_3.Enabled = False

            'テキスト更新
            now_tx.Refresh()
            now_tx.Text = "しばらくお待ち下さい。ダウンロードする準備を開始しました..."

            'ダウンロードを開始する
            download_ready_data()
        Else
            MessageBox.Show("現在インターネットに接続されていない為、実行できません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub
    Private Sub download_ready_data()
        'フォルダワッショイ！
        If Directory.Exists(Root & "Data") Then
            '例外対策のため一旦削除する
            Directory.Delete(Root & "Data", True)
            '作成ワッショイ
            Directory.CreateDirectory(Root & "Data")
            '次に移動する
            download_ready_dl()
        Else
            '作成ワッショイ
            Directory.CreateDirectory(Root & "Data")
            '次に移動する
            download_ready_dl()
        End If
    End Sub

    Private Sub download_ready_dl()
        'フォルダワッショイ！
        If Directory.Exists(Root & "Download") Then
            '例外対策のため一旦削除する
            Directory.Delete(Root & "Download", True)
            '作成ワッショイ
            Directory.CreateDirectory(Root & "Download")
            '次に移動する
            download_1_()
        Else
            '作成ワッショイ
            Directory.CreateDirectory(Root & "Download")
            '次に移動する
            download_1_()
        End If
    End Sub

    Private Sub download_1_()

    End Sub

End Class
