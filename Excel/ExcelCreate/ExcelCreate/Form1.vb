'''''' 需要引用
''''''Microsoft Excel 11.0 Object Library
''''''Microsoft Office 11.0 Object Library
Public Class Form1
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
                Try
                        Dim excelObj As Object = GetObject(, "Excel.Application")
                        If excelObj.Workbooks.Count = 0 Then '注意，如果是新建未保存的工作簿不算打开
                                MsgBox("没有工作簿打开")
                                excelObj = Nothing
                                'Exit Sub
                        Else
                                MsgBox("已经打开了" & excelObj.Workbooks.Count & “个工作簿”)
                        End If

                        excelObj = Nothing
                Catch ex As Exception
                        'MsgBox(ex.Message)
                        MsgBox("查询失败！")
                End Try
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
                Try
                        Dim excelObj As Object = GetObject(, "Excel.Application")
                        Dim Count As Integer

                        Count = excelObj.Workbooks.Count
                        If Count = 0 Then
                                MsgBox("没有工作簿打开")
                                excelObj = Nothing
                                Exit Sub
                        Else
                                'excelObj.Workbooks(1).test()
                                For i = 1 To Count
                                        'MsgBox(i)
                                        excelObj.Workbooks(i).Worksheets(1).Range("A1").Value = Now
                                        excelObj.Workbooks(i).Save
                                Next
                                excelObj.Quit
                        End If
                        excelObj = Nothing
                Catch ex As Exception
                        'MsgBox(ex.Message)
                        MsgBox("关闭失败！")
                End Try
        End Sub

        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
                Try
                        Dim excelObj As Object = GetObject(, "Excel.Application")
                        If excelObj.Workbooks.Count = 0 Then '注意，如果是新建未保存的工作簿不算打开
                                MsgBox("没有工作簿打开")
                                excelObj = Nothing
                                'Exit Sub
                        Else
                                excelObj.Visible = True
                        End If

                        excelObj = Nothing
                Catch ex As Exception
                        'MsgBox(ex.Message)
                        MsgBox("查询失败！")
                End Try
        End Sub
End Class