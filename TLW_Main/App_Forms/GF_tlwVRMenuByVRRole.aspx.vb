Partial Class GF_tlwVRMenuByVRRole
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwVRMenuByVRRole.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RecordID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwVRMenuByVRRole_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwVRMenuByVRRole.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RecordID As Int32 = GVtlwVRMenuByVRRole.DataKeys(e.CommandArgument).Values("RecordID")  
        Dim RedirectUrl As String = TBLtlwVRMenuByVRRole.EditUrl & "?RecordID=" & RecordID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwVRMenuByVRRole_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwVRMenuByVRRole.Init
    DataClassName = "GtlwVRMenuByVRRole"
    SetGridView = GVtlwVRMenuByVRRole
  End Sub
  Protected Sub TBLtlwVRMenuByVRRole_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRMenuByVRRole.Init
    SetToolBar = TBLtlwVRMenuByVRRole
  End Sub
  Protected Sub F_VRRoleID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VRRoleID.SelectedIndexChanged
    Session("F_VRRoleID") = F_VRRoleID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_VRMenuID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VRMenuID.SelectedIndexChanged
    Session("F_VRMenuID") = F_VRMenuID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_VRRoleID.SelectedValue = String.Empty
    If Not Session("F_VRRoleID") Is Nothing Then
      If Session("F_VRRoleID") <> String.Empty Then
        F_VRRoleID.SelectedValue = Session("F_VRRoleID")
      End If
    End If
    F_VRMenuID.SelectedValue = String.Empty
    If Not Session("F_VRMenuID") Is Nothing Then
      If Session("F_VRMenuID") <> String.Empty Then
        F_VRMenuID.SelectedValue = Session("F_VRMenuID")
      End If
    End If
  End Sub
End Class
