Partial Class GF_tlwEmployees
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwEmployees.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CardNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwEmployees_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwEmployees.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CardNo As String = GVtlwEmployees.DataKeys(e.CommandArgument).Values("CardNo")  
        Dim RedirectUrl As String = TBLtlwEmployees.EditUrl & "?CardNo=" & CardNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwEmployees.Init
    DataClassName = "GtlwEmployees"
    SetGridView = GVtlwEmployees
  End Sub
  Protected Sub TBLtlwEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwEmployees.Init
    SetToolBar = TBLtlwEmployees
  End Sub
  Protected Sub F_CardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CardNo.TextChanged
    Session("F_CardNo") = F_CardNo.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
