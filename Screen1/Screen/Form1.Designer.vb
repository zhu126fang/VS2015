﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
        Inherits System.Windows.Forms.Form

        'Form 重写 Dispose，以清理组件列表。
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
                Try
                        If disposing AndAlso components IsNot Nothing Then
                                components.Dispose()
                        End If
                Finally
                        MyBase.Dispose(disposing)
                End Try
        End Sub

        'Windows 窗体设计器所必需的
        Private components As System.ComponentModel.IContainer

        '注意: 以下过程是 Windows 窗体设计器所必需的
        '可以使用 Windows 窗体设计器修改它。  
        '不要使用代码编辑器修改它。
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
                Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
                Me.Button1 = New System.Windows.Forms.Button()
                Me.Label1 = New System.Windows.Forms.Label()
                Me.SuspendLayout()
                '
                'Button1
                '
                Me.Button1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
                Me.Button1.Location = New System.Drawing.Point(90, 161)
                Me.Button1.Name = "Button1"
                Me.Button1.Size = New System.Drawing.Size(100, 40)
                Me.Button1.TabIndex = 0
                Me.Button1.Text = "截图并保存"
                Me.Button1.UseVisualStyleBackColor = True
                '
                'Label1
                '
                Me.Label1.AutoSize = True
                Me.Label1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
                Me.Label1.Location = New System.Drawing.Point(43, 103)
                Me.Label1.Name = "Label1"
                Me.Label1.Size = New System.Drawing.Size(0, 27)
                Me.Label1.TabIndex = 1
                Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                '
                'Form1
                '
                Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
                Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                Me.ClientSize = New System.Drawing.Size(282, 255)
                Me.Controls.Add(Me.Label1)
                Me.Controls.Add(Me.Button1)
                Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
                Me.Name = "Form1"
                Me.Text = "Screen"
                Me.ResumeLayout(False)
                Me.PerformLayout()

        End Sub

        Friend WithEvents Button1 As Button
        Friend WithEvents Label1 As Label
End Class
