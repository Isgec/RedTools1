Partial Class AF_tlwLGPageSize
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwLGPageSize_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwLGPageSize.Init
    DataClassName = "AtlwLGPageSize"
    SetFormView = FVtlwLGPageSize
  End Sub
  Protected Sub TBLtlwLGPageSize_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwLGPageSize.Init
    SetToolBar = TBLtlwLGPageSize
  End Sub
  Protected Sub FVtlwLGPageSize_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwLGPageSize.DataBound
    SIS.TLW.tlwLGPageSize.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwLGPageSize_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwLGPageSize.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwLGPageSize.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwLGPageSize") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwLGPageSize", mStr)
    End If
    If Request.QueryString("PageID") IsNot Nothing Then
      CType(FVtlwLGPageSize.FindControl("F_PageID"), TextBox).Text = Request.QueryString("PageID")
      CType(FVtlwLGPageSize.FindControl("F_PageID"), TextBox).Enabled = False
    End If
  End Sub

End Class
