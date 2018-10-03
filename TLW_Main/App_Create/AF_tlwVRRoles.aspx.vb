Partial Class AF_tlwVRRoles
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwVRRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoles.Init
    DataClassName = "AtlwVRRoles"
    SetFormView = FVtlwVRRoles
  End Sub
  Protected Sub TBLtlwVRRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRRoles.Init
    SetToolBar = TBLtlwVRRoles
  End Sub
  Protected Sub FVtlwVRRoles_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoles.DataBound
    SIS.TLW.tlwVRRoles.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwVRRoles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoles.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwVRRoles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRRoles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRRoles", mStr)
    End If
    If Request.QueryString("VRRoleID") IsNot Nothing Then
      CType(FVtlwVRRoles.FindControl("F_VRRoleID"), TextBox).Text = Request.QueryString("VRRoleID")
      CType(FVtlwVRRoles.FindControl("F_VRRoleID"), TextBox).Enabled = False
    End If
  End Sub

End Class
