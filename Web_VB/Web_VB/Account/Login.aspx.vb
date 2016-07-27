Imports System.Web
Imports System.Web.UI
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin

Partial Public Class Login
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register"
        ' 在为密码重置功能启用帐户确认后，启用此项
        ' ForgotPasswordHyperLink.NavigateUrl = "Forgot"
        OpenAuthLogin.ReturnUrl = Request.QueryString("ReturnUrl")
        Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        If Not [String].IsNullOrEmpty(returnUrl) Then
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" & returnUrl
        End If
    End Sub

    Protected Sub LogIn(sender As Object, e As EventArgs)
        If IsValid Then
            ' 验证用户密码
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim signinManager = Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)()

            ' 这不会计入到为执行帐户锁定而统计的登录失败次数中
            ' 若要在多次输入错误密码的情况下触发锁定，请更改为 shouldLockout := True
            Dim result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout := False)

            Select Case result
                Case SignInStatus.Success
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
                    Exit Select
                Case SignInStatus.LockedOut
                    Response.Redirect("/Account/Lockout")
                    Exit Select
                Case SignInStatus.RequiresVerification
                    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                    Request.QueryString("ReturnUrl"),
                                                    RememberMe.Checked),
                                      True)
                    Exit Select
                Case Else
                    FailureText.Text = "无效的登录尝试"
                    ErrorMessage.Visible = True
                    Exit Select
            End Select
        End If
    End Sub
End Class
