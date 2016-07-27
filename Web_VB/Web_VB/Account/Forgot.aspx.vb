Imports System
Imports System.Web
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Owin

Partial Public Class ForgotPassword
    Inherits System.Web.UI.Page

    Protected Property StatusMessage() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub Forgot(sender As Object, e As EventArgs)
        If IsValid Then
            ' 验证用户的电子邮件地址
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim user As ApplicationUser = manager.FindByName(Email.Text)
            If user Is Nothing OrElse Not manager.IsEmailConfirmed(user.Id) Then
                FailureText.Text = "用户不存在或未确认。"
                ErrorMessage.Visible = True
                Return
            End If
            ' 有关如何启用帐户确认和密码重置的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=320771
            ' 发送包含此代码和重定向到“重置密码”页的电子邮件
            ' Dim code = manager.GeneratePasswordResetToken(user.Id)
            ' Dim callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request)
            ' manager.SendEmail(user.Id, "重置密码", "请通过单击 <a href=""" & callbackUrl & """>此处</a>来重置你的密码。")
            loginForm.Visible = False
            DisplayEmail.Visible = True
        End If
    End Sub
End Class