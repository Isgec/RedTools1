Partial Class GF_tlwOffices
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwOffices.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?OfficeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwOffices_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwOffices.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim OfficeID As Int32 = GVtlwOffices.DataKeys(e.CommandArgument).Values("OfficeID")  
        Dim RedirectUrl As String = TBLtlwOffices.EditUrl & "?OfficeID=" & OfficeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwOffices_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwOffices.Init
    DataClassName = "GtlwOffices"
    SetGridView = GVtlwOffices
  End Sub
  Protected Sub TBLtlwOffices_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwOffices.Init
    SetToolBar = TBLtlwOffices
  End Sub
  Protected Sub F_OfficeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_OfficeID.TextChanged
    Session("F_OfficeID") = F_OfficeID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
