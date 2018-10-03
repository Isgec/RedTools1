Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Namespace SIS.SYS
  Public Class GenerateMenu
    Implements IDisposable
    Public Shared Sub CreateWebAuthorization(ByVal ApplID As Integer, ByVal UsrID As String, Optional ByVal RolID As Integer = 0)
      If RolID > 0 Then
        WriteNewMenuX(ApplID, UsrID, RolID)
      End If
    End Sub
    Public Shared Sub WriteMenu(ByVal ApplID As Integer, ByVal RoleID As Integer, ByVal F_CardNo As String, ByVal T_CardNo As String)
      If F_CardNo <> T_CardNo Then
        Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd1 As SqlCommand = Con1.CreateCommand()
            Cmd1.CommandType = CommandType.Text
            Cmd1.CommandText = "SELECT [HRM_Employees].[CardNo] FROM [HRM_Employees] WHERE [HRM_Employees].[CardNo] >='" & F_CardNo & "' AND [HRM_Employees].[CardNo] <='" & T_CardNo & "'"
            Con1.Open()
            Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
            While (Reader.Read())
              WriteNewMenuX(ApplID, RoleID, Reader("CardID"))
            End While
            Reader.Close()
          End Using
        End Using
      Else
        WriteNewMenuX(ApplID, RoleID, F_CardNo)
      End If
    End Sub
    Public Sub New()
    End Sub

    Private Shared Sub SubNewMenu(ByVal oMnu As SIS.SYS.lgMenu, ByVal oTW As IO.StreamWriter, ByVal Indent As Integer, ByVal CardNo As String, ByRef cntID As Integer)
      Indent += 1
      cntID += 1
      Dim IndentChar As String = Space(Indent * 2)
      oTW.WriteLine(IndentChar & "<li class=""active has-sub""><a href=""#"" id=""MenuP_" & oMnu.VRMenuID & "_" & cntID & """><span>" & oMnu.VRMenuName & "</span></a>")
      oTW.WriteLine(IndentChar & "<ul>")
      Dim oSens As List(Of SIS.SYS.lgMenuSessions) = SIS.SYS.lgMenuSessions.GetAllSessionsInMenuForApl(oMnu.ApplicationID, oMnu.VRMenuID)
      Dim ItemIndent As Integer = Indent + 1
      Dim ItemIndentChar As String = Space(ItemIndent * 2)
      Dim count As Integer = oSens.Count
      For Each oSns As SIS.SYS.lgMenuSessions In oSens
        count -= 1
        cntID += 1
        Dim tmpSession As lgSession = SIS.SYS.lgSession.GetByID(oSns.ApplicationID, oSns.VRSessionID)
        Try
          Dim LGImageUrl As String = "~/App_Themes/Default/Images/application.png"
          Select Case tmpSession.VRSessionType.ToLower
            Case "m" 'maintain
              LGImageUrl = LGImageUrl.Replace("application.png", "ST_Maintain.png")
            Case "d" 'display
              LGImageUrl = LGImageUrl.Replace("application.png", "ST_Display.png")
            Case "p" 'print
              LGImageUrl = LGImageUrl.Replace("application.png", "ST_Print.png")
            Case "u" 'update
              LGImageUrl = LGImageUrl.Replace("application.png", "ST_Update.png")
            Case "t" 'Tools
              LGImageUrl = LGImageUrl.Replace("application.png", "ST_Tools.png")
          End Select
          Select Case tmpSession.VRSessionType.ToLower
            Case "m", "d", "p", "u", "t"
              If count = 0 Then
                oTW.WriteLine(ItemIndentChar & "<li class=""last""><a href=""" & tmpSession.FolderLocation & """ id=""Session_" & oSns.VRSessionID.ToString & "_" & cntID & """ title=""" & tmpSession.ToolTip & """  ><span>" & tmpSession.VRMenuName & "</span></a></li>")
              Else
                oTW.WriteLine(ItemIndentChar & "<li><a href=""" & tmpSession.FolderLocation & """ id=""Session_" & oSns.VRSessionID.ToString & "_" & cntID & """ title=""" & tmpSession.ToolTip & """  ><span>" & tmpSession.VRMenuName & "</span></a></li>")
              End If
          End Select
        Catch ex As Exception
          oTW.WriteLine("<!--" & ex.Message & "-->")
        End Try
        'Insert in session by Employee
        Dim Found As Boolean = False
        Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd1 As SqlCommand = Con1.CreateCommand()
            Cmd1.CommandType = CommandType.Text
            Cmd1.CommandText = "SELECT * FROM SYS_VRSessionByEmployee WHERE ApplicationID = " & oSns.ApplicationID & " and VRSessionID = " & oSns.VRSessionID & " and UserName = '" & CardNo & "'"
            Con1.Open()
            Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
            While (Reader.Read())
              Found = True
            End While
            Reader.Close()
          End Using
        End Using
        If Not Found Then
          Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
            Using Cmd1 As SqlCommand = Con1.CreateCommand()
              Dim Sql As String = "Insert SYS_VRSessionByEmployee (VRSessionID,	ApplicationID,	UserName,	MaintainGrid,	InsertForm,	UpdateForm,	DisplayGrid,	DisplayForm,	DeleteOption) Values "
              Sql &= "(" & oSns.VRSessionID & "," & oSns.ApplicationID & ", '" & CardNo & "', " & IIf(tmpSession.MaintainGrid, 1, 0) & "," & IIf(tmpSession.InsertForm, 1, 0) & "," & IIf(tmpSession.UpdateForm, 1, 0) & "," & IIf(tmpSession.DisplayGrid, 1, 0) & "," & IIf(tmpSession.DisplayForm, 1, 0) & "," & IIf(tmpSession.DeleteOption, 1, 0) & ")"
              Cmd1.CommandType = CommandType.Text
              Cmd1.CommandText = Sql
              Con1.Open()
              Try
                Cmd1.ExecuteNonQuery()
              Catch ex As Exception
              End Try
            End Using
          End Using
        End If
        'end of Insert
      Next
      Dim oMenus As List(Of SIS.SYS.lgMenu) = SIS.SYS.lgMenu.GetByParentID(oMnu.ApplicationID, oMnu.VRMenuID)
      For Each oMenu As SIS.SYS.lgMenu In oMenus
        cntID += 1
        Try
          SubNewMenu(oMenu, oTW, ItemIndent, CardNo, cntID)
        Catch ex As Exception
          oTW.WriteLine("<!--" & ex.Message & "-->")
        End Try
      Next
      oTW.WriteLine(IndentChar & "</ul>")
      oTW.WriteLine(IndentChar & "</li>")
    End Sub
    Public Shared Sub WriteNewMenuX(ByVal ApplID As Integer, ByVal RoleID As Integer, ByVal CardNo As String)
      If RoleID > 0 Then
        'Check RoleID 
        Dim Found As Boolean = False
        Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd1 As SqlCommand = Con1.CreateCommand()
            Cmd1.CommandType = CommandType.Text
            Cmd1.CommandText = "SELECT * FROM SYS_VRRoleByEmployee WHERE ApplicationID = " & ApplID & " and VRRoleID = " & RoleID & " and UserName = '" & CardNo & "'"
            Con1.Open()
            Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
            While (Reader.Read())
              Found = True
            End While
            Reader.Close()
          End Using
        End Using
        If Not Found Then
          'Insert Role
          Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
            Using Cmd1 As SqlCommand = Con1.CreateCommand()
              Cmd1.CommandType = CommandType.Text
              Cmd1.CommandText = "Insert SYS_VRRoleByEmployee (ApplicationID,VRRoleID,UserName) Values (" & ApplID & "," & RoleID & ", '" & CardNo & "')"
              Con1.Open()
              Try
                Cmd1.ExecuteNonQuery()
              Catch ex As Exception
              End Try
            End Using
          End Using
          'User Role Inserted
        End If
        'End Check RoleID
      End If

      Dim oApl As SIS.SYS.lgApplication = SIS.SYS.lgApplication.GetByID(ApplID)
      Dim LinkedApls() As String = oApl.LinkedApplications.Split(",".ToCharArray)
      Dim cntID As Integer = 0
      Dim oTW As IO.StreamWriter = New IO.StreamWriter(HttpContext.Current.Server.MapPath("~/..") & "/UserRights/" & oApl.MainApplicationID.ToString & "/" & CardNo & "_nMenu.xml")
      With oTW
        Try
          .WriteLine("<div id=""cssmenu"">")
          .WriteLine("  <ul>")
          For Each lApl As String In LinkedApls
            Dim oRoles As List(Of SIS.SYS.lgUserRoles) = SIS.SYS.lgUserRoles.GetAllRolesInAplForUser(lApl, CardNo)
            For Each oRole As SIS.SYS.lgUserRoles In oRoles
              cntID += 1
              Dim tmpRole As SIS.SYS.lgRole = SIS.SYS.lgRole.GetByID(oRole.ApplicationID, oRole.VRRoleID)
              Try
                .WriteLine("    <li class=""active has-sub""><a href=""#"" id=""Role_" & oRole.VRRoleID.ToString & "_" & cntID & """><span>" & tmpRole.Description & "</span></a>")
                .WriteLine("      <ul>")
              Catch ex As Exception
                .WriteLine("<!--" & ex.Message & "-->")
              End Try
              Dim oMenus As List(Of SIS.SYS.lgRoleMenus) = SIS.SYS.lgRoleMenus.GetAllMenusInRolesForApl(oRole.ApplicationID, oRole.VRRoleID)
              For Each oMenu As SIS.SYS.lgRoleMenus In oMenus
                cntID += 1
                Dim tmpMenu As SIS.SYS.lgMenu = SIS.SYS.lgMenu.GetByID(oMenu.ApplicationID, oMenu.VRMenuID)
                Try
                  SubNewMenu(tmpMenu, oTW, 2, CardNo, cntID)
                Catch ex As Exception
                  .WriteLine("<!--" & ex.Message & "-->")
                End Try
              Next
              .WriteLine("      </ul>")
              .WriteLine("    </li>")
            Next

          Next
          .WriteLine("  </ul>")
          .WriteLine("</div>")
          .Close()
        Catch ex As Exception
          .WriteLine("<!--" & ex.Message & "-->")
          .Close()
        End Try
      End With
    End Sub

#Region " IDisposable Support "

    Private disposedValue As Boolean = False    ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: free managed resources when explicitly called
        End If

        ' TODO: free shared unmanaged resources
      End If
      Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class
  Public Class lgSession
    Public Property VRSessionID As Integer = 0
    Public Property FileName As String = ""
    Public Property Description As String = ""
    Public Property FolderLocation As String = ""
    Public Property VRMenuName As String = ""
    Public Property ToolTip As String = ""
    Public Property VRSessionType As String = ""
    Public Property CSSClass As String = ""
    Public Property ApplicationID As Integer = 0
    Public Property MaintainGrid As Boolean = False
    Public Property InsertForm As Boolean = False
    Public Property UpdateForm As Boolean = False
    Public Property DisplayGrid As Boolean = False
    Public Property DisplayForm As Boolean = False
    Public Property DeleteOption As Boolean = False

    Public Shared Function GetByID(ByVal ApplID As Integer, ByVal SessionID As Integer) As SIS.SYS.lgSession
      Dim Tmp As SIS.SYS.lgSession = Nothing
      Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd1 As SqlCommand = Con1.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          Cmd1.CommandText = "SELECT * FROM SYS_VRSessions Where ApplicationID = " & ApplID & " and VRSessionID = " & SessionID
          Con1.Open()
          Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
          While (Reader.Read())
            Tmp = New SIS.SYS.lgSession(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Tmp
    End Function

    Sub New()
      'Dummy
    End Sub
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub

  End Class
  Public Class lgMenuSessions
    Public Property RecordID As Integer = 0
    Public Property VRMenuID As Integer = 0
    Public Property VRSessionID As Integer = 0
    Public Property Sequence As Integer = 0
    Public Property ApplicationID As Integer = 0
    Public Property MaintainGrid As Boolean = False
    Public Property InsertForm As Boolean = False
    Public Property UpdateForm As Boolean = False
    Public Property DisplayGrid As Boolean = False
    Public Property DisplayForm As Boolean = False
    Public Property DeleteOption As Boolean = False
    Public Shared Function GetAllSessionsInMenuForApl(ByVal ApplID As Integer, ByVal MenuID As Integer) As List(Of SIS.SYS.lgMenuSessions)
      Dim Tmp As New List(Of SIS.SYS.lgMenuSessions)
      Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd1 As SqlCommand = Con1.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          Cmd1.CommandText = "SELECT * FROM SYS_VRSessionByVRMenu WHERE ApplicationID = " & ApplID & " and VRMenuID = " & MenuID & " Order By Sequence"
          Con1.Open()
          Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
          While (Reader.Read())
            Tmp.Add(New SIS.SYS.lgMenuSessions(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Tmp
    End Function
    Sub New()
      'Dummy
    End Sub
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub

  End Class
  Public Class lgMenu
    Public Property VRMenuID As Integer = 0
    Public Property VRMenuName As String = ""
    Public Property ToolTip As String = ""
    Public Property ParentVRMenuID As Integer = 0
    Public Property VRMenuType As String = ""
    Public Property CSSClass As String = ""
    Public Property Sequence As Integer = 0
    Public Property ApplicationID As Integer = 0
    Public Shared Function GetByParentID(ByVal ApplID As Integer, ByVal MenuID As Integer) As List(Of SIS.SYS.lgMenu)
      Dim Tmp As New List(Of SIS.SYS.lgMenu)
      Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd1 As SqlCommand = Con1.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          Cmd1.CommandText = "SELECT * FROM SYS_VRMenus Where ApplicationID = " & ApplID & " and ParentVRMenuID = " & MenuID & " Order By Sequence"
          Con1.Open()
          Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
          While (Reader.Read())
            Tmp.Add(New SIS.SYS.lgMenu(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Tmp
    End Function

    Public Shared Function GetByID(ByVal ApplID As Integer, ByVal MenuID As Integer) As SIS.SYS.lgMenu
      Dim Tmp As SIS.SYS.lgMenu = Nothing
      Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd1 As SqlCommand = Con1.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          Cmd1.CommandText = "SELECT * FROM SYS_VRMenus Where ApplicationID = " & ApplID & " and VRMenuID = " & MenuID
          Con1.Open()
          Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
          While (Reader.Read())
            Tmp = New SIS.SYS.lgMenu(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Tmp
    End Function

    Sub New()
      'Dummy
    End Sub
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub


  End Class
  Public Class lgRoleMenus
    Public Property RecordID As Integer = 0
    Public Property VRRoleID As Integer = 0
    Public Property VRMenuID As Integer = 0
    Public Property Sequence As Integer = 0
    Public Property ApplicationID As Integer = 0
    Public Shared Function GetAllMenusInRolesForApl(ByVal ApplID As Integer, ByVal RoleID As Integer) As List(Of SIS.SYS.lgRoleMenus)
      Dim Tmp As New List(Of SIS.SYS.lgRoleMenus)
      Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd1 As SqlCommand = Con1.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          Cmd1.CommandText = "SELECT * FROM SYS_VRMenuByVRRole WHERE ApplicationID = " & ApplID & " and VRRoleID = " & RoleID & " Order By Sequence"
          Con1.Open()
          Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
          While (Reader.Read())
            Tmp.Add(New SIS.SYS.lgRoleMenus(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Tmp
    End Function
    Sub New()
      'Dummy
    End Sub
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub

  End Class
  Public Class lgRole
    Public Property VRRoleID As Integer = 0
    Public Property Description As String = ""
    Public Property VRRoleType As String = ""
    Public Property ApplicationID As Integer = 0
    Public Property DefaultRole As Boolean = False
    Public Shared Function GetByID(ByVal ApplID As Integer, ByVal RoleID As Integer) As SIS.SYS.lgRole
      Dim Tmp As SIS.SYS.lgRole = Nothing
      Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd1 As SqlCommand = Con1.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          Cmd1.CommandText = "SELECT * FROM SYS_VRRoles Where ApplicationID = " & ApplID & " and VRRoleID = " & RoleID
          Con1.Open()
          Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
          While (Reader.Read())
            Tmp = New SIS.SYS.lgRole(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Tmp
    End Function
    Sub New()
      'Dummy
    End Sub
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub

  End Class
  Public Class lgUserRoles
    Public Property RecordID As Integer = 0
    Public Property VRRoleID As Integer = 0
    Public Property RoleName As String = ""
    Public Property ApplicationID As Integer = 0
    Public Property UserName As String = ""
    Sub New()
      'Dummy
    End Sub
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Shared Function GetAllRolesInAplForUser(ByVal ApplID As Integer, ByVal CardNo As String) As List(Of SIS.SYS.lgUserRoles)
      Dim Tmp As New List(Of SIS.SYS.lgUserRoles)
      Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd1 As SqlCommand = Con1.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          Cmd1.CommandText = "SELECT * FROM SYS_VRRoleByEmployee WHERE ApplicationID = " & ApplID & " and UserName = '" & CardNo & "'"
          Con1.Open()
          Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
          While (Reader.Read())
            Tmp.Add(New SIS.SYS.lgUserRoles(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Tmp
    End Function

  End Class
  Public Class lgApplication
    Public Property ApplicationID As Integer = 0
    Public Property Description As String = ""
    Public Property WebPath As String = ""
    Public Property GenerateDefaults As Boolean = False
    Public Property LinkedApplications As String = ""
    Public Property MainApplicationID As Integer = 0
    Public Shared Function GetByID(ByVal ApplID As Integer) As SIS.SYS.lgApplication
      Dim Tmp As SIS.SYS.lgApplication = Nothing
      Using Con1 As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd1 As SqlCommand = Con1.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          Cmd1.CommandText = "SELECT * FROM SYS_Applications WHERE ApplicationID = " & ApplID
          Con1.Open()
          Dim Reader As SqlDataReader = Cmd1.ExecuteReader()
          While (Reader.Read())
            Tmp = New SIS.SYS.lgApplication(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Tmp
    End Function
    Sub New()
      'Dummy
    End Sub
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub

  End Class
End Namespace
