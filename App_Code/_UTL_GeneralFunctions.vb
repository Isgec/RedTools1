'Imports System
'Imports System.Web
'Imports Microsoft.VisualBasic
'Imports System.Data
'Imports System.Data.SqlClient
'Imports System.Net.Mail
'Imports System.Net.Mail.SmtpClient
'Imports System.Collections.Generic
'Imports System.Configuration
'Imports System.Web.Configuration
'Imports System.Net.Configuration
'Imports System.Text
'Imports System.Security.Cryptography

'Namespace SIS.SYS.Utilities
'  Public Class ValidateURL
'		Public Shared Function Validate(ByVal PageUrl As String) As Boolean
'			If HttpContext.Current.User.Identity.Name = "0340" Then
'				Return True
'			End If
'			Dim aParts() As String = PageUrl.Split("/".ToCharArray)
'			If aParts.Length <= 3 Then
'				Return True
'			End If
'			Return ValidateURL(PageUrl)
'		End Function
'    Public Shared Function ValidateURL(ByVal PageUrl As String) As Boolean
'      Dim _Result As Boolean = False
'      Dim afile() As String = PageUrl.Split("/".ToCharArray)
'      Dim FileName As String = afile(afile.GetUpperBound(0)).ToString
'      Dim UserCase As String = FileName.Substring(0, 3)
'      Select Case UserCase
'        Case "AF_"
'          FileName = FileName.Replace("AF_", "GF_")
'        Case "EF_"
'          FileName = FileName.Replace("EF_", "GF_")
'        Case "DF_"
'          FileName = FileName.Replace("DF_", "GD_")
'      End Select
'      Dim oVrs As SIS.SYS.VRSessionByUser = SIS.SYS.VRSessionByUser.GetByUserFile(FileName)
'      If Not oVrs Is Nothing Then
'        Select Case UserCase
'          Case "AF_"
'            If oVrs.InsertForm Then
'              _Result = True
'            End If
'          Case "EF_"
'            If oVrs.UpdateForm Then
'              _Result = True
'            End If
'          Case "DF_"
'            If oVrs.DisplayForm Then
'              _Result = True
'            End If
'          Case "GD_"
'            If oVrs.DisplayGrid Then
'              _Result = True
'            End If
'          Case Else    '"GF_", "GT_", "GU_", "GP_"
'            If oVrs.MaintainGrid Then
'              _Result = True
'            End If
'        End Select
'      End If
'      Return _Result
'    End Function
'  End Class
'  Public Class SessionManager
'    Public Shared Sub CreateSessionEnvironement()
'      With HttpContext.Current
'        .Session("ApplicationID") = 0
'        .Session("ThisApplicationID") = 0
'        .Session("ApplicationDefaultPage") = ""
'        .Session("LoginID") = Nothing
'        .Session("PageSizeProvider") = False
'        .Session("PageNoProvider") = False
'      End With
'    End Sub
'    Public Shared Sub InitializeEnvironment()
'      HttpContext.Current.Session("LoginID") = Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.Name)
'      CommonInitialize()
'    End Sub
'    Public Shared Sub InitializeEnvironment(ByVal UserID As String)
'      HttpContext.Current.Session("LoginID") = Convert.ToInt32(UserID)
'      CommonInitialize()
'    End Sub
'    Private Shared Sub CommonInitialize()
'      With HttpContext.Current
'        .Session("ApplicationID") = 1
'        .Session("ThisApplicationID") = 1
'        .Session("ApplicationDefaultPage") = "~/Default.aspx"
'        'Read from web config
'        Dim PageNoProvider As String = ConfigurationManager.AppSettings("PageNoProvider")
'        If Not PageNoProvider Is Nothing Then
'          .Session("PageNoProvider") = Convert.ToBoolean(PageNoProvider)
'        Else
'          .Session("PageNoProvider") = True
'        End If
'        Dim PageSizeProvider As String = ConfigurationManager.AppSettings("PageSizeProvider")
'        If Not PageSizeProvider Is Nothing Then
'          .Session("PageSizeProvider") = Convert.ToBoolean(PageSizeProvider)
'        Else
'          .Session("PageSizeProvider") = True
'        End If
'      End With
'    End Sub
'    Public Shared Sub DestroySessionEnvironement()
'      With HttpContext.Current
'        .Session.Clear()
'        .Session.Abandon()
'      End With
'    End Sub
'		Public Shared Function getMD5(ByVal value As String) As String
'			Dim MD5 As MD5 = MD5.Create()
'			Dim md5Bytes As Byte() = System.Text.Encoding.Default.GetBytes(value)

'			Dim cryString As Byte() = MD5.ComputeHash(md5Bytes)
'			Dim md5Str As String = String.Empty
'			'To Return String of 32 Bytes
'			For i As Integer = 0 To cryString.Length - 1
'				md5Str &= cryString(i).ToString("x")
'			Next

'			'To return string of 24 Bytes
'			'md5Str = Convert.ToBase64String(cryString)
'			Return md5Str
'		End Function
'	End Class
'  Public Class GlobalVariables
'		Public Shared Function mkPass(ByVal UserName As String) As Boolean
'			Dim UserID As Guid = GetUserID(UserName)
'			If UserID.ToString = String.Empty Then
'				Return False
'			End If
'			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
'				Using Cmd As SqlCommand = Con.CreateCommand()
'					Dim mSql As String = "UPDATE aspnet_Membership SET Password='3DrEKbtItX/00J/1GLEvpX1PdnA=', PasswordSalt='J9WC17LFQxkVD1NpH1V3Ow==' WHERE UserID='" & Convert.ToString(UserID) & "'"
'					Cmd.CommandType = System.Data.CommandType.Text
'					Cmd.CommandText = mSql
'					Con.Open()
'					Cmd.ExecuteNonQuery()
'				End Using
'			End Using
'			Return True
'		End Function
'		Public Shared Function GetUserID(ByVal UserName As String) As Guid
'			Dim _Result As Guid = Nothing
'			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
'				Using Cmd As SqlCommand = Con.CreateCommand()
'					Dim mSql As String = "SELECT TOP 1 [aspnet_Users].[UserID] FROM [aspnet_Users] WHERE [aspnet_Users].[UserName] = '" & UserName & "'"
'					Cmd.CommandType = System.Data.CommandType.Text
'					Cmd.CommandText = mSql
'					Con.Open()
'					_Result = Cmd.ExecuteScalar()
'				End Using
'			End Using
'			Return _Result
'		End Function
'		Public Shared Function PageNo(ByVal PageName As String, ByVal LoginID As String) As Integer
'			Dim _Result As Integer = 0
'			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
'				Using Cmd As SqlCommand = Con.CreateCommand()
'					Dim mSql As String = "SELECT TOP 1 [SYS_LGPageSize].[PageNo] FROM [SYS_LGPageSize] WHERE [SYS_LGPageSize].[PageName] = '" & PageName & "' AND [SYS_LGPageSize].[LoginID] = '" & LoginID & "' AND [SYS_LGPageSize].[ApplicationID] = '" & HttpContext.Current.Session("ThisApplicationID") & "'"
'					Cmd.CommandType = System.Data.CommandType.Text
'					Cmd.CommandText = mSql
'					Con.Open()
'					_Result = Cmd.ExecuteScalar()
'					If _Result = 0 Then
'						_Result = 0
'					End If
'				End Using
'			End Using
'			Return _Result
'		End Function
'		Public Shared Function PageNo(ByVal PageName As String, ByVal LoginID As String, ByVal Position As Integer) As Integer
'			Dim _Result As Integer = 0
'			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
'				Using Cmd As SqlCommand = Con.CreateCommand()
'					Cmd.CommandType = CommandType.StoredProcedure
'					Cmd.CommandText = "spSYS_LG_SetPageNumber"
'					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageName", SqlDbType.NVarChar, 250, PageName)
'					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 20, LoginID)
'					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageNo", SqlDbType.Int, 10, Position)
'					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ThisApplicationID"))
'					Con.Open()
'					Cmd.ExecuteNonQuery()
'				End Using
'			End Using
'			Return _Result
'		End Function
'    Public Shared Function PageSize(ByVal PageName As String, ByVal LoginID As String) As Integer
'      Dim _Result As Integer = 0
'      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
'        Using Cmd As SqlCommand = Con.CreateCommand()
'          Dim mSql As String = "SELECT TOP 1 [SYS_LGPageSize].[PageSize] FROM [SYS_LGPageSize] WHERE [SYS_LGPageSize].[PageName] = '" & PageName & "' AND [SYS_LGPageSize].[LoginID] = '" & LoginID & "' AND [SYS_LGPageSize].[ApplicationID] = " & HttpContext.Current.Session("ThisApplicationID")
'          Cmd.CommandType = System.Data.CommandType.Text
'          Cmd.CommandText = mSql
'          Con.Open()
'          _Result = Cmd.ExecuteScalar()
'          If _Result = 0 Then
'            _Result = 10
'          End If
'        End Using
'      End Using
'      Return _Result
'    End Function
'    Public Shared Function PageSize(ByVal PageName As String, ByVal LoginID As String, ByVal Size As Integer) As Integer
'      Dim _Result As Integer = 0
'      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
'        Using Cmd As SqlCommand = Con.CreateCommand()
'          Cmd.CommandType = CommandType.StoredProcedure
'          Cmd.CommandText = "spSYS_LG_SetPageSize"
'          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageName", SqlDbType.NVarChar, 250, PageName)
'          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 20, LoginID)
'          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageSize", SqlDbType.Int, 10, Size)
'          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ThisApplicationID"))
'          Con.Open()
'          Cmd.ExecuteNonQuery()
'        End Using
'      End Using
'      Return _Result
'    End Function
'  End Class
'  Public Class lgMail
'    Private _To As String
'    Private _Subject As String
'    Private _Values As New Dictionary(Of String, String)
'    Private _Links As New Dictionary(Of String, String)
'    Private _Body As String
'    Public Property Body() As String
'      Get
'        Return _Body
'      End Get
'      Set(ByVal value As String)
'        _Body = value
'      End Set
'    End Property
'    Public Sub Links(ByVal Key As String, ByVal Value As String)
'      _Links.Add(Key, Value)
'    End Sub
'    Public Sub Values(ByVal Key As String, ByVal Value As String)
'      _Values.Add(Key, Value)
'    End Sub
'    Public Property Subject() As String
'      Get
'        Return _Subject
'      End Get
'      Set(ByVal value As String)
'        _Subject = value
'      End Set
'    End Property
'    Public Property EMailID() As String
'      Get
'        Return _To
'      End Get
'      Set(ByVal value As String)
'        _To = value
'      End Set
'    End Property
'    Public Sub Send()
'      Dim oSMTP As New System.Net.Mail.SmtpClient
'      Dim oMail As New System.Net.Mail.MailMessage
'      With oMail
'        .To.Add(New MailAddress(_To))
'        .Subject = _Subject
'        .Body = String.Empty
'        .Body = "<table>"
'        For Each Itm As KeyValuePair(Of String, String) In _Values
'          .Body &= "<tr>"
'          .Body &= "<td><B>" & Itm.Key & "<B></td><td>" & Itm.Value & "</td>"
'          .Body &= "</tr>"
'        Next
'        For Each Itm As KeyValuePair(Of String, String) In _Links
'          .Body &= "<tr>"
'          .Body &= "<td colspan=""2""><a href=""http://" & Itm.Value & """>" & Itm.Key & "</a></td>"
'          .Body &= "</tr>"
'        Next
'        .Body &= "<tr>"
'        .Body &= "<td colspan=""2"">" & _Body & "</td>"
'        .Body &= "</tr>"
'        .Body &= "</table>"
'        .IsBodyHtml = True
'      End With
'      oSMTP.Send(oMail)
'    End Sub
'  End Class
'End Namespace
