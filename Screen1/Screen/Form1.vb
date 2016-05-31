Public Class Form1
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
                Me.Hide()
                Dim FileName As String
                Dim p1 As New Point(0, 0)
                'Dim p2 As New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
                Dim p2 As New Point(1024, 768)
                Dim pic As New Bitmap(p2.X, p2.Y)

                If Not IO.Directory.Exists("D:/Report/" & Now.ToString("yyyyMMdd")) Then
                        MsgBox("文件夹不存在需要创建")
                        IO.Directory.CreateDirectory("D:/Report/" & Now.ToString("yyyyMMdd"))
                Else
                        'MsgBox("文件夹已经存在")
                End If

                FileName = "D:/Report/" & Now.ToString("yyyyMMdd") & "/" & Now.ToString("yyyyMMdd_HHmm_ss") & ".jpg"

                Using g As Graphics = Graphics.FromImage(pic)
                        g.CopyFromScreen(p1, p1, p2)
                        'Me.BackgroundImage = pic
                        pic.Save(FileName)
                        Label1.Text = "截图文件保存成功！"
                End Using

                Me.Show()
                'MsgBox(FileName)
        End Sub
End Class
