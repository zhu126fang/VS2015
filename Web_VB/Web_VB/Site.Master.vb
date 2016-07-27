Imports Microsoft.AspNet.Identity

Public Class SiteMaster
    Inherits MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' 以下代码可帮助防御 XSRF 攻击
        Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
            ' 使用 Cookie 中的 Anti-XSRF 令牌
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' 生成新的 Anti-XSRF 令牌并保存到 Cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With { _
                 .HttpOnly = True, _
                 .Value = _antiXsrfTokenValue _
            }
            If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                responseCookie.Secure = True
            End If
            Response.Cookies.[Set](responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            ' 设置 Anti-XSRF 令牌
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
        Else
            ' 验证 Anti-XSRF 令牌
            If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
                Throw New InvalidOperationException("Anti-XSRF 令牌验证失败。")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
    End Sub

End Class