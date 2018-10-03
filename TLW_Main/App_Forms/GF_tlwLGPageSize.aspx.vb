Partial Class GF_tlwLGPageSize
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwLGPageSize.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PageID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwLGPageSize_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwLGPageSize.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PageID As Int32 = GVtlwLGPageSize.DataKeys(e.CommandArgument).Values("PageID")  
        Dim RedirectUrl As String = TBLtlwLGPageSize.EditUrl & "?PageID=" & PageID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwLGPageSize_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwLGPageSize.Init
    DataClassName = "GtlwLGPageSize"
    SetGridView = GVtlwLGPageSize
  End Sub
  Protected Sub TBLtlwLGPageSize_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwLGPageSize.Init
    SetToolBar = TBLtlwLGPageSize
  End Sub
  Protected Sub F_LoginID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_LoginID.TextChanged
    Session("F_LoginID") = F_LoginID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
