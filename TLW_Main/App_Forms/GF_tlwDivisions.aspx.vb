Partial Class GF_tlwDivisions
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwDivisions.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DivisionID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwDivisions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwDivisions.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DivisionID As String = GVtlwDivisions.DataKeys(e.CommandArgument).Values("DivisionID")  
        Dim RedirectUrl As String = TBLtlwDivisions.EditUrl & "?DivisionID=" & DivisionID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwDivisions.Init
    DataClassName = "GtlwDivisions"
    SetGridView = GVtlwDivisions
  End Sub
  Protected Sub TBLtlwDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwDivisions.Init
    SetToolBar = TBLtlwDivisions
  End Sub
  Protected Sub F_DivisionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DivisionID.TextChanged
    Session("F_DivisionID") = F_DivisionID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
