Partial Class AF_tlwVRSessionByEmployee
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwVRSessionByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByEmployee.Init
    DataClassName = "AtlwVRSessionByEmployee"
    SetFormView = FVtlwVRSessionByEmployee
  End Sub
  Protected Sub TBLtlwVRSessionByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessionByEmployee.Init
    SetToolBar = TBLtlwVRSessionByEmployee
  End Sub
  Protected Sub FVtlwVRSessionByEmployee_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByEmployee.DataBound
    SIS.TLW.tlwVRSessionByEmployee.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwVRSessionByEmployee_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByEmployee.PreRender
    Dim oF_VRSessionID As LC_tlwVRSessions = FVtlwVRSessionByEmployee.FindControl("F_VRSessionID")
    oF_VRSessionID.Enabled = True
    oF_VRSessionID.SelectedValue = String.Empty
    If Not Session("F_VRSessionID") Is Nothing Then
      If Session("F_VRSessionID") <> String.Empty Then
        oF_VRSessionID.SelectedValue = Session("F_VRSessionID")
      End If
    End If
    Dim oF_UserName_Display As Label  = FVtlwVRSessionByEmployee.FindControl("F_UserName_Display")
    oF_UserName_Display.Text = String.Empty
    If Not Session("F_UserName_Display") Is Nothing Then
      If Session("F_UserName_Display") <> String.Empty Then
        oF_UserName_Display.Text = Session("F_UserName_Display")
      End If
    End If
    Dim oF_UserName As TextBox  = FVtlwVRSessionByEmployee.FindControl("F_UserName")
    oF_UserName.Enabled = True
    oF_UserName.Text = String.Empty
    If Not Session("F_UserName") Is Nothing Then
      If Session("F_UserName") <> String.Empty Then
        oF_UserName.Text = Session("F_UserName")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwVRSessionByEmployee.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRSessionByEmployee") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRSessionByEmployee", mStr)
    End If
    If Request.QueryString("RecordID") IsNot Nothing Then
      CType(FVtlwVRSessionByEmployee.FindControl("F_RecordID"), TextBox).Text = Request.QueryString("RecordID")
      CType(FVtlwVRSessionByEmployee.FindControl("F_RecordID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserNameCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TLW.tlwUsers.SelecttlwUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_SYS_VRSessionByEmployee_UserName(ByVal value As String) As String
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
