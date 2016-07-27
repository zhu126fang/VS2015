Imports System
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.DataProtection
Imports Microsoft.Owin.Security.Google
Imports Owin

Partial Public Class Startup

    ' 有关配置身份验证的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301883
    Public Sub ConfigureAuth(app As IAppBuilder)
        '配置数据库上下文、用户管理器和登录管理器，以便为每个请求使用单个实例
        app.CreatePerOwinContext(AddressOf ApplicationDbContext.Create)
        app.CreatePerOwinContext(Of ApplicationUserManager)(AddressOf ApplicationUserManager.Create)
        app.CreatePerOwinContext(Of ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create)

        ' 使应用程序可以使用 Cookie 来存储已登录用户的信息
        app.UseCookieAuthentication(New CookieAuthenticationOptions() With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .Provider = New CookieAuthenticationProvider() With {
                .OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(
                    validateInterval:=TimeSpan.FromMinutes(30),
                    regenerateIdentity:=Function(manager, user) user.GenerateUserIdentityAsync(manager))},
            .LoginPath = New PathString("/Account/Login")})
        ' 使用 Cookie 临时存储有关某个用户使用第三方登录提供程序进行登录的信息
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie)

        ' 使应用程序可以在双重身份验证过程中验证第二因素时暂时存储用户信息。
        app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5))

        ' 使应用程序可以记住第二登录验证因素，例如电话或电子邮件。
        ' 选中此选项后，登录过程中执行的第二个验证步骤将保存到你登录时所在的设备上。
        ' 此选项类似于在登录时提供的“记住我”选项。
        app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie)

        ' 取消注释以下行可允许使用第三方登录提供程序登录
        'app.UseMicrosoftAccountAuthentication(
        '    clientId:= "",
        '    clientSecret:= "")

        'app.UseTwitterAuthentication(
        '   consumerKey:= "",
        '   consumerSecret:= "")

        'app.UseFacebookAuthentication(
        '   appId:= "",
        '   appSecret:= "")

        'app.UseGoogleAuthentication(New GoogleOAuth2AuthenticationOptions() With {
        '   .ClientId = "",
        '   .ClientSecret = ""})
    End Sub
End Class
