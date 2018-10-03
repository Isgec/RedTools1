Partial Class GF_tlwApplications
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwApplications.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ApplicationID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwApplications_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwApplications.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ApplicationID As Int32 = GVtlwApplications.DataKeys(e.CommandArgument).Values("ApplicationID")  
        Dim RedirectUrl As String = TBLtlwApplications.EditUrl & "?ApplicationID=" & ApplicationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwApplications.Init
    DataClassName = "GtlwApplications"
    SetGridView = GVtlwApplications
  End Sub
  Protected Sub TBLtlwApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwApplications.Init
    SetToolBar = TBLtlwApplications
  End Sub
  Protected Sub F_ApplicationID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ApplicationID.TextChanged
    Session("F_ApplicationID") = F_ApplicationID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
