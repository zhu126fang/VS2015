Public Class Form1
        Dim xApp As Object = CreateObject("Excel.Application")

        Sub Finaly()
                MsgBox("创建结束")
        End Sub
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
                Label1.Text = "开始"
                Try
                        xApp.Workbooks.Add
                        With xApp.ActiveWorkbook.Worksheets(1)
                                .Rows("1:450").RowHeight = 15                                   '通用行高
                                .Columns("A:A").ColumnWidth = 1.5                          '列宽
                                .Columns("B:B").ColumnWidth = 5
                                .Columns("C:G").ColumnWidth = 14
                                .Columns("H:H").ColumnWidth = 1.5
                                With .Range(.cells(1, 1), .cells(450, 8))                        '通用单元格格式
                                        .HorizontalAlignment = 3
                                        .VerticalAlignment = -4108
                                        .Font.Name = "微软雅黑"
                                        .Font.Size = 8
                                End With
                        End With
                Catch ex As Exception
                        'MsgBox(ex.Message)
                        MsgBox("创建失败")
                End Try
                Label1.Text = "完成"
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
                Label1.Text = "开始"
                With xApp.ActiveWorkbook.Worksheets(1)
                        .Rows("2:2").RowHeight = 40                                        '2行高
                        .cells(2, 2).Font.Size = 15
                        .cells(2, 2).value = "空气制动系统-测试报告"
                        .Range(.cells(2, 2), .cells(2, 7)).MergeCells = True
                        .Rows("40:40").RowHeight = 30                                   '40行高
                        .cells(40, 2).Font.Size = 12
                        .cells(40, 2).value = "测试小节"
                        .Range(.cells(40, 2), .cells(40, 7)).MergeCells = True
                        .Range(.cells(41, 2), .cells(44, 7)).MergeCells = True


                        .Range(.cells(3, 2), .cells(3, 3)).MergeCells = True
                        .Range(.cells(3, 4), .cells(3, 5)).MergeCells = True
                        .Range(.cells(3, 6), .cells(3, 7)).MergeCells = True

                        .Range(.cells(4, 2), .cells(4, 3)).MergeCells = True
                        .Range(.cells(4, 4), .cells(4, 5)).MergeCells = True
                        .Range(.cells(4, 6), .cells(4, 7)).MergeCells = True

                        .Range(.cells(7, 2), .cells(7, 7)).MergeCells = True
                        .cells(3, 2).value = "日期"
                        .cells(3, 4).value = "车辆编号"
                        .cells(3, 6).value = "设备编号"
                        .cells(7, 2).value = "测试记录"

                        For i = 8 To 38 Step 1
                                .Range(.cells(i, 3), .cells(i, 4)).MergeCells = True

                                If i > 8 Then
                                        .cells(i, 2).value = i - 8
                                End If
                        Next
                        .cells(8, 2).value = "序号"
                        .cells(8, 3).value = "测试项目"
                        .cells(8, 5).value = "标记"
                        .cells(8, 6).value = "问题描述"
                        .cells(8, 7).value = "处理意见"

                        With .Range(.cells(1, 1), .cells(45, 8))                                        '测试总结外框
                                .Borders(7).LineStyle = 1  'Left
                                .Borders(8).LineStyle = 1  'Top
                                .Borders(9).LineStyle = 1  'Bottom
                                .Borders(10).LineStyle = 1  'Rigth
                        End With
                        .Range(.cells(2, 2), .cells(4, 7)).Borders.LineStyle = 1              '测试总结内框
                        .Range(.cells(7, 2), .cells(38, 7)).Borders.LineStyle = 1              '测试总结内框
                        .Range(.cells(40, 2), .cells(44, 7)).Borders.LineStyle = 1              '测试总结内框
                End With
                Label1.Text = "完成"
        End Sub

        Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
                Dim Max_Row As Integer
                Label1.Text = "开始"
                With xApp.ActiveWorkbook.Worksheets(1)
                        For i = 46 To 436 Step 15
                                .Rows(i & ":" & i).RowHeight = 30                                       '标题行
                                .Range(.cells(i, 2), .cells(i, 7)).MergeCells = True
                                .cells(i, 2).value = "测试" & (i - 46) / 15 + 1
                                .cells(i, 2).Font.Size = 12

                                With .Range(.cells(i + 1, 1), .cells(i + 14, 8))                        '单项测试外框
                                        .Borders(7).LineStyle = 1  'Left
                                        .Borders(8).LineStyle = 1  'Top
                                        .Borders(9).LineStyle = 1  'Bottom
                                        .Borders(10).LineStyle = 1  'Rigth
                                End With

                                Max_Row = 10
                                With .Range(.cells(i + 2, 2), .cells(i + 2 + Max_Row, 7))                        '单项测试内容记录
                                        .Borders.LineStyle = 1
                                End With
                                .cells(i + 1, 3).value = "停留时间:"
                                .cells(i + 1, 3).HorizontalAlignment = -4152
                                .cells(i + 1, 6).value = "记录时间:"
                                .cells(i + 1, 6).HorizontalAlignment = -4152
                                .cells(i + 2, 2).value = "序号"
                                .cells(i + 2, 3).value = "操作"
                                .cells(i + 2, 4).value = "代号"
                                .cells(i + 2, 5).value = "记录值"
                                .cells(i + 2, 6).value = "标准值"
                                .cells(i + 2, 7).value = "标记"
                                For j = 3 To Max_Row + 2 Step 1
                                        .cells(i + j, 2).value = j - 2
                                        .cells(i + j, 5).Interior.ColorIndex = 15
                                Next
                        Next
                End With
                Label1.Text = "完成"
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
                Label1.Text = "开始"
                xApp.ActiveWorkbook.SaveAs("D:\sample.xlsx")
                xApp.ActiveWorkbook.Close
                xApp.Quit
                xApp = Nothing
                'Call finaly()
                Label1.Text = "保存成功"
        End Sub

        Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
                System.Diagnostics.Process.Start("D:\sample.xlsx")
        End Sub
End Class