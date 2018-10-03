Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GT_GenerateUserAuthorization
  Inherits SIS.SYS.GridBase
  Protected Sub TBLtlwVRMenus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessions.Init
    SetToolBar = TBLtlwVRSessions
  End Sub
  Protected Sub CmdGenMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdGenMenu.Click
    Dim RoleID As Integer = 0
    Dim ApplID As Integer = HttpContext.Current.Session("ApplicationID")
    If LC_VRRoles1.SelectedValue <> String.Empty Then
      RoleID = LC_VRRoles1.SelectedValue
    End If
    SIS.SYS.GenerateMenu.WriteMenu(ApplID, RoleID, F_CardNo.Text, T_CardNo.Text)
  End Sub
  Protected Sub cmdGenMenuOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGenMenuOnly.Click
    Dim aUser() As String = F_WebUser.Text.Split(",".ToCharArray)
    Dim RoleID As Integer = 0
    Dim ApplID As Integer = HttpContext.Current.Session("ApplicationID")
    If LC_VRRoles1.SelectedValue <> String.Empty Then
      RoleID = LC_VRRoles1.SelectedValue
    End If
    For Each usr As String In aUser
      SIS.SYS.GenerateMenu.WriteNewMenuX(ApplID, RoleID, usr)
    Next
    'Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
    'Dim script As String = String.Format("alert({0});", message)
    'ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  End Sub
  Protected Sub cmdUpdEmployeeInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdEmployeeInfo.Click
    Dim oUsrs As List(Of SIS.TLW.tlwUsers) = SIS.TLW.tlwUsers.tlwUsersSelectList("")
    For Each usr As SIS.TLW.tlwUsers In oUsrs
      Dim oEmp As SIS.TLW.tlwEmployees = SIS.TLW.tlwEmployees.tlwEmployeesGetByID(usr.LoginID)
      If Not oEmp Is Nothing Then
        With usr
          .C_CompanyID = oEmp.C_CompanyID
          .C_DateOfJoining = oEmp.C_DateOfJoining
          .C_DepartmentID = oEmp.C_DepartmentID
          .C_DesignationID = oEmp.C_DesignationID
          .C_DivisionID = oEmp.C_DivisionID
          .C_OfficeID = oEmp.C_OfficeID
          .ActiveState = oEmp.ActiveState
          .UserFullName = oEmp.EmployeeName
        End With
        SIS.TLW.tlwUsers.tlwUsersUpdate(usr)
      End If
    Next
  End Sub
End Class
