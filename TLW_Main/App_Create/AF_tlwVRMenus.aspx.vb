Partial Class AF_tlwVRMenus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwVRMenus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenus.Init
    DataClassName = "AtlwVRMenus"
    SetFormView = FVtlwVRMenus
  End Sub
  Protected Sub TBLtlwVRMenus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRMenus.Init
    SetToolBar = TBLtlwVRMenus
  End Sub
  Protected Sub FVtlwVRMenus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenus.DataBound
    SIS.TLW.tlwVRMenus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwVRMenus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwVRMenus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRMenus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRMenus", mStr)
    End If
    If Request.QueryString("VRMenuID") IsNot Nothing Then
      CType(FVtlwVRMenus.FindControl("F_VRMenuID"), TextBox).Text = Request.QueryString("VRMenuID")
      CType(FVtlwVRMenus.FindControl("F_VRMenuID"), TextBox).Enabled = False
    End If
  End Sub

End Class
