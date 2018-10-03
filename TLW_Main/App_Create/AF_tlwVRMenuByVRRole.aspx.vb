Partial Class AF_tlwVRMenuByVRRole
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwVRMenuByVRRole_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenuByVRRole.Init
    DataClassName = "AtlwVRMenuByVRRole"
    SetFormView = FVtlwVRMenuByVRRole
  End Sub
  Protected Sub TBLtlwVRMenuByVRRole_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRMenuByVRRole.Init
    SetToolBar = TBLtlwVRMenuByVRRole
  End Sub
  Protected Sub FVtlwVRMenuByVRRole_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenuByVRRole.DataBound
    SIS.TLW.tlwVRMenuByVRRole.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwVRMenuByVRRole_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenuByVRRole.PreRender
    Dim oF_VRRoleID As LC_tlwVRRoles = FVtlwVRMenuByVRRole.FindControl("F_VRRoleID")
    oF_VRRoleID.Enabled = True
    oF_VRRoleID.SelectedValue = String.Empty
    If Not Session("F_VRRoleID") Is Nothing Then
      If Session("F_VRRoleID") <> String.Empty Then
        oF_VRRoleID.SelectedValue = Session("F_VRRoleID")
      End If
    End If
    Dim oF_VRMenuID As LC_tlwVRMenus = FVtlwVRMenuByVRRole.FindControl("F_VRMenuID")
    oF_VRMenuID.Enabled = True
    oF_VRMenuID.SelectedValue = String.Empty
    If Not Session("F_VRMenuID") Is Nothing Then
      If Session("F_VRMenuID") <> String.Empty Then
        oF_VRMenuID.SelectedValue = Session("F_VRMenuID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwVRMenuByVRRole.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRMenuByVRRole") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRMenuByVRRole", mStr)
    End If
    If Request.QueryString("RecordID") IsNot Nothing Then
      CType(FVtlwVRMenuByVRRole.FindControl("F_RecordID"), TextBox).Text = Request.QueryString("RecordID")
      CType(FVtlwVRMenuByVRRole.FindControl("F_RecordID"), TextBox).Enabled = False
    End If
  End Sub

End Class
