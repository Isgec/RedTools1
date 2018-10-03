Partial Class GF_tlwCompanies
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwCompanies.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CompanyID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwCompanies_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwCompanies.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CompanyID As String = GVtlwCompanies.DataKeys(e.CommandArgument).Values("CompanyID")  
        Dim RedirectUrl As String = TBLtlwCompanies.EditUrl & "?CompanyID=" & CompanyID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwCompanies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwCompanies.Init
    DataClassName = "GtlwCompanies"
    SetGridView = GVtlwCompanies
  End Sub
  Protected Sub TBLtlwCompanies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwCompanies.Init
    SetToolBar = TBLtlwCompanies
  End Sub
  Protected Sub F_CompanyID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CompanyID.TextChanged
    Session("F_CompanyID") = F_CompanyID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
