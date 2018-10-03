Partial Class AF_tlwVRSessions
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwVRSessions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessions.Init
    DataClassName = "AtlwVRSessions"
    SetFormView = FVtlwVRSessions
  End Sub
  Protected Sub TBLtlwVRSessions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessions.Init
    SetToolBar = TBLtlwVRSessions
  End Sub
  Protected Sub FVtlwVRSessions_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessions.DataBound
    SIS.TLW.tlwVRSessions.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwVRSessions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessions.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwVRSessions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRSessions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRSessions", mStr)
    End If
    If Request.QueryString("VRSessionID") IsNot Nothing Then
      CType(FVtlwVRSessions.FindControl("F_VRSessionID"), TextBox).Text = Request.QueryString("VRSessionID")
      CType(FVtlwVRSessions.FindControl("F_VRSessionID"), TextBox).Enabled = False
    End If
  End Sub

End Class
