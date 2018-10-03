Partial Class GF_tlwVRSessions
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwVRSessions.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?VRSessionID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwVRSessions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwVRSessions.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim VRSessionID As Int32 = GVtlwVRSessions.DataKeys(e.CommandArgument).Values("VRSessionID")  
        Dim RedirectUrl As String = TBLtlwVRSessions.EditUrl & "?VRSessionID=" & VRSessionID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwVRSessions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwVRSessions.Init
    DataClassName = "GtlwVRSessions"
    SetGridView = GVtlwVRSessions
  End Sub
  Protected Sub TBLtlwVRSessions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessions.Init
    SetToolBar = TBLtlwVRSessions
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
