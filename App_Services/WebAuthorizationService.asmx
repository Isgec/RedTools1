<%@ WebService Language="VB" Class="WebAuthorizationService" %>

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace := "http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
Public Class WebAuthorizationService
  Inherits System.Web.Services.WebService

  <WebMethod(EnableSession:=True)>
  Public Function CreateWebAuthorization(ByVal ApplID As Integer, ByVal UsrID As String, ByVal RolID As Integer) As String
    Dim mRet As String = ""
    HttpContext.Current.Session("LoginID") = "0340"
    HttpContext.Current.Session("ApplicationID") = ApplID
    Try
      SIS.SYS.GenerateMenu.CreateWebAuthorization(ApplID, UsrID, RolID)
    Catch ex As Exception
      mRet = ex.Message
    End Try
    Return mRet
  End Function

End Class
