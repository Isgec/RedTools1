Partial Class GF_tlwVRRoles
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwVRRoles.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?VRRoleID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwVRRoles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwVRRoles.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim VRRoleID As Int32 = GVtlwVRRoles.DataKeys(e.CommandArgument).Values("VRRoleID")  
        Dim RedirectUrl As String = TBLtlwVRRoles.EditUrl & "?VRRoleID=" & VRRoleID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwVRRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwVRRoles.Init
    DataClassName = "GtlwVRRoles"
    SetGridView = GVtlwVRRoles
  End Sub
  Protected Sub TBLtlwVRRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRRoles.Init
    SetToolBar = TBLtlwVRRoles
  End Sub
  Protected Sub F_VRRoleID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VRRoleID.TextChanged
    Session("F_VRRoleID") = F_VRRoleID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
