Imports System
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin

Partial Public Class Manage
    Inherits System.Web.UI.Page
    Protected Property SuccessMessage() As String
        Get
            Return m_SuccessMessage
        End Get
        Private Set(value As String)
            m_SuccessMessage = value
        End Set
    End Property
    Private m_SuccessMessage As String

    Private Function HasPassword(manager As ApplicationUserManager) As Boolean
        Dim appUser = manager.FindById(User.Identity.GetUserId())
        Return (appUser IsNot Nothing AndAlso appUser.PasswordHash IsNot Nothing)
    End Function

    Protected Property HasPhoneNumber() As Boolean
        Get
            Return m_HasPhoneNumber
        End Get
        Private Set(value As Boolean)
            m_HasPhoneNumber = value
        End Set
    End Property
    Private m_HasPhoneNumber As Boolean

    Protected Property TwoFactorEnabled() As Boolean
        Get
            Return m_TwoFactorEnabled
        End Get
        Private Set(value As Boolean)
            m_TwoFactorEnabled = value
        End Set
    End Property
    Private m_TwoFactorEnabled As Boolean

    Protected Property TwoFactorBrowserRemembered() As String
        Get
            Return m_TwoFactorBrowserRemembered
        End Get
        Private Set(value As String)
            m_TwoFactorBrowserRemembered = value
        End Set
    End Property
    Private m_TwoFactorBrowserRemembered As String

    Public Property LoginsCount As Integer

    Protected Sub Page_Load() Handles Me.Load
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()

        HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()))

        ' 在设置双重身份验证后启用此功能
        'PhoneNumber.Text = If(manager.GetPhoneNumber(User.Identity.GetUserId()), String.Empty)

        TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId())

        LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count

        Dim authenticationManager = HttpContext.Current.GetOwinContext().Authentication

        If Not IsPostBack Then
            ' 确定要呈现的节
            If HasPassword(manager) Then
              ChangePassword.Visible = True
            Else
              CreatePassword.Visible = True
              ChangePassword.Visible = False
            End If

            ' 呈现成功消息
            Dim message = Request.QueryString("m")
            If message IsNot Nothing Then
                ' 从操作中去除查询字符串
                Form.Action = ResolveUrl("~/Account/Manage")

                SuccessMessage = If(message = "ChangePwdSuccess", "已更改你的密码。", 
                    If(message = "SetPwdSuccess", "已设置你的密码。", 
                    If(message = "RemoveLoginSuccess", "该帐户已删除。", 
                    If(message = "AddPhoneNumberSuccess", "已添加电话号码", 
                    If(message = "RemovePhoneNumberSuccess", "已删除电话号码", String.Empty)))))
                SuccessMessagePlaceHolder.Visible = Not String.IsNullOrEmpty(SuccessMessage)
            End If
        End If
    End Sub

    Private Sub AddErrors(result As IdentityResult)
        For Each [error] As String In result.Errors
            ModelState.AddModelError("", [error])
        Next
    End Sub

    ' 从用户信息中删除电话号码
    Protected Sub RemovePhone_Click(sender As Object, e As EventArgs)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()
        Dim result = manager.SetPhoneNumber(User.Identity.GetUserId(), Nothing)
        If Not result.Succeeded Then
            Return
        End If
        Dim userInfo = manager.FindById(User.Identity.GetUserId())
        If userInfo IsNot Nothing Then
            signInManager.SignIn(userInfo, isPersistent := False, rememberBrowser := False)
            Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess")
        End If
    End Sub

    ' DisableTwoFactorAuthentication
    Protected Sub TwoFactorDisable_Click(sender As Object, e As EventArgs)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        manager.SetTwoFactorEnabled(User.Identity.GetUserId(), False)

        Response.Redirect("/Account/Manage")
    End Sub

    'EnableTwoFactorAuthentication 
    Protected Sub TwoFactorEnable_Click(sender As Object, e As EventArgs)
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        manager.SetTwoFactorEnabled(User.Identity.GetUserId(), True)

        Response.Redirect("/Account/Manage")
    End Sub
End Class