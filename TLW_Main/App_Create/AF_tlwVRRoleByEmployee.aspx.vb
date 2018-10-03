Partial Class AF_tlwVRRoleByEmployee
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwVRRoleByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoleByEmployee.Init
    DataClassName = "AtlwVRRoleByEmployee"
    SetFormView = FVtlwVRRoleByEmployee
  End Sub
  Protected Sub TBLtlwVRRoleByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRRoleByEmployee.Init
    SetToolBar = TBLtlwVRRoleByEmployee
  End Sub
  Protected Sub FVtlwVRRoleByEmployee_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoleByEmployee.DataBound
    SIS.TLW.tlwVRRoleByEmployee.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwVRRoleByEmployee_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoleByEmployee.PreRender
    Dim oF_VRRoleID As LC_tlwVRRoles = FVtlwVRRoleByEmployee.FindControl("F_VRRoleID")
    oF_VRRoleID.Enabled = True
    oF_VRRoleID.SelectedValue = String.Empty
    If Not Session("F_VRRoleID") Is Nothing Then
      If Session("F_VRRoleID") <> String.Empty Then
        oF_VRRoleID.SelectedValue = Session("F_VRRoleID")
      End If
    End If
    Dim oF_UserName_Display As Label  = FVtlwVRRoleByEmployee.FindControl("F_UserName_Display")
    Dim oF_UserName As TextBox  = FVtlwVRRoleByEmployee.FindControl("F_UserName")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwVRRoleByEmployee.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRRoleByEmployee") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRRoleByEmployee", mStr)
    End If
    If Request.QueryString("RecordID") IsNot Nothing Then
      CType(FVtlwVRRoleByEmployee.FindControl("F_RecordID"), TextBox).Text = Request.QueryString("RecordID")
      CType(FVtlwVRRoleByEmployee.FindControl("F_RecordID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserNameCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TLW.tlwUsers.SelecttlwUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_SYS_VRRoleByEmployee_UserName(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UserName As String = CType(aVal(1),String)
    Dim oVar As SIS.TLW.tlwUsers = SIS.TLW.tlwUsers.tlwUsersGetByID(UserName)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
