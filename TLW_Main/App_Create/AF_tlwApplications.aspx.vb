Partial Class AF_tlwApplications
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwApplications.Init
    DataClassName = "AtlwApplications"
    SetFormView = FVtlwApplications
  End Sub
  Protected Sub TBLtlwApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwApplications.Init
    SetToolBar = TBLtlwApplications
  End Sub
  Protected Sub FVtlwApplications_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwApplications.DataBound
    SIS.TLW.tlwApplications.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwApplications.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwApplications", mStr)
    End If
    If Request.QueryString("ApplicationID") IsNot Nothing Then
      CType(FVtlwApplications.FindControl("F_ApplicationID"), TextBox).Text = Request.QueryString("ApplicationID")
      CType(FVtlwApplications.FindControl("F_ApplicationID"), TextBox).Enabled = False
    End If
  End Sub

End Class
