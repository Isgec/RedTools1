Partial Class AF_tlwVRSessionByVRMenu
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwVRSessionByVRMenu_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByVRMenu.Init
    DataClassName = "AtlwVRSessionByVRMenu"
    SetFormView = FVtlwVRSessionByVRMenu
  End Sub
  Protected Sub TBLtlwVRSessionByVRMenu_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessionByVRMenu.Init
    SetToolBar = TBLtlwVRSessionByVRMenu
  End Sub
  Protected Sub FVtlwVRSessionByVRMenu_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByVRMenu.DataBound
    SIS.TLW.tlwVRSessionByVRMenu.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwVRSessionByVRMenu_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByVRMenu.PreRender
    Dim oF_VRMenuID As LC_tlwVRMenus = FVtlwVRSessionByVRMenu.FindControl("F_VRMenuID")
    oF_VRMenuID.Enabled = True
    oF_VRMenuID.SelectedValue = String.Empty
    If Not Session("F_VRMenuID") Is Nothing Then
      If Session("F_VRMenuID") <> String.Empty Then
        oF_VRMenuID.SelectedValue = Session("F_VRMenuID")
      End If
    End If
    Dim oF_VRSessionID As LC_tlwVRSessions = FVtlwVRSessionByVRMenu.FindControl("F_VRSessionID")
    oF_VRSessionID.Enabled = True
    oF_VRSessionID.SelectedValue = String.Empty
    If Not Session("F_VRSessionID") Is Nothing Then
      If Session("F_VRSessionID") <> String.Empty Then
        oF_VRSessionID.SelectedValue = Session("F_VRSessionID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwVRSessionByVRMenu.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRSessionByVRMenu") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRSessionByVRMenu", mStr)
    End If
    If Request.QueryString("RecordID") IsNot Nothing Then
      CType(FVtlwVRSessionByVRMenu.FindControl("F_RecordID"), TextBox).Text = Request.QueryString("RecordID")
      CType(FVtlwVRSessionByVRMenu.FindControl("F_RecordID"), TextBox).Enabled = False
    End If
  End Sub

End Class
