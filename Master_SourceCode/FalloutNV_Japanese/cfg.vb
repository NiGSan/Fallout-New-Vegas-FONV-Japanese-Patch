Imports System.Net
Imports System.IO
Imports System.Text
Public Class cfg
    Private mousePoint As Point
    Dim Root As String

    Private Sub cfg_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Location = New Point( _
                Me.Location.X + e.X - mousePoint.X, _
                Me.Location.Y + e.Y - mousePoint.Y)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim webreq As HttpWebRequest = _
            DirectCast(WebRequest.Create("http://fallout.allplay.jp/download/fonv_jp/ver.txt"), HttpWebRequest)
        Dim webres As HttpWebResponse = DirectCast(webreq.GetResponse(), HttpWebResponse)
        Dim st As Stream = webres.GetResponseStream()
        Dim sr As New StreamReader(st, Encoding.UTF8)
        Dim vers As String = sr.ReadToEnd()
        sr.Close()
        st.Close()
        webres.Close()
        If My.Application.Info.Version.ToString = vers Then
            MessageBox.Show("このバージョンは最新です。")
        Else
            MessageBox.Show("最新バージョンが見つかりました。ブログを開きます", "New Version", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            System.Diagnostics.Process.Start("http://gamesmod.blog.fc2.com/blog-category-6.html")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim webreq As HttpWebRequest = _
            DirectCast(WebRequest.Create("http://fallout.allplay.jp/download/fonv_jp/pre_ver.txt"), HttpWebRequest)
        Dim webres As HttpWebResponse = DirectCast(webreq.GetResponse(), HttpWebResponse)
        Dim st As Stream = webres.GetResponseStream()
        Dim sr As New StreamReader(st, Encoding.UTF8)
        Dim vers As String = sr.ReadToEnd()
        sr.Close()
        st.Close()
        webres.Close()
        If My.Application.Info.Version.ToString = vers Then
            MessageBox.Show("このバージョンは最新です。")
        Else
            MessageBox.Show("最新バージョンが見つかりました。プレリリース版をダウンロードします", "New Pre-Release Version", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            My.Computer.Network.DownloadFile("http://fallout.allplay.jp/download/fonv_jp/FONV_JP_APP_prerelase.zip", _
                                             Root & "FONV_JP_APP_prerelase.zip", "", "", True, 60000, True, FileIO.UICancelOption.ThrowException)
        End If
    End Sub

    Private Sub cfg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '実行中のアプリケーションパスが正しく取得出来ているか
        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\FalloutNV_Japanese.exe") Then
            Root = AppDomain.CurrentDomain.BaseDirectory
        Else
            '存在しない場合(旧式)
            If File.Exists(Application.StartupPath & "\FalloutNV_Japanese.exe") Then
                Root = Application.StartupPath & "\"
            Else
                'それでも見つからない場合
                MessageBox.Show("申し訳ありません。このユーザでは権限不足もしくは環境の問題により" & vbCr & _
                                "取得出来ませんでした。" & vbCr & vbCr & _
                                "管理者として実行するか、ユーザをご変更してください。", "Error", _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class