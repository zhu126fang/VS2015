Public Class Form1
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
                Dim p As New System.Diagnostics.Process
                Dim inst As Process
                Dim myProcess() As Process

                '查找并关闭进程
                myProcess = System.Diagnostics.Process.GetProcessesByName("notepad")
                For Each inst In myProcess
                        p = System.Diagnostics.Process.GetProcessById(inst.Id)
                        p.Kill()
                Next
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
                Dim p As New System.Diagnostics.Process
                Dim inst As Process
                Dim myProcess() As Process

        '查找并关闭进程
        '可以正常关闭所有Excel进程，但会有文档恢复提示
        myProcess = System.Diagnostics.Process.GetProcessesByName("excel")
                For Each inst In myProcess
                        p = System.Diagnostics.Process.GetProcessById(inst.Id)
                        p.Kill()
                Next
        End Sub
End Class