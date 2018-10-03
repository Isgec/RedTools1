Partial Class GF_tlwVRMenus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwVRMenus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?VRMenuID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwVRMenus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwVRMenus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim VRMenuID As Int32 = GVtlwVRMenus.DataKeys(e.CommandArgument).Values("VRMenuID")  
        Dim RedirectUrl As String = TBLtlwVRMenus.EditUrl & "?VRMenuID=" & VRMenuID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwVRMenus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwVRMenus.Init
    DataClassName = "GtlwVRMenus"
    SetGridView = GVtlwVRMenus
  End Sub
  Protected Sub TBLtlwVRMenus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRMenus.Init
    SetToolBar = TBLtlwVRMenus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
