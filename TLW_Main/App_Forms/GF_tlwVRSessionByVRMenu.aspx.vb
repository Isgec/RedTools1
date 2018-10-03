Partial Class GF_tlwVRSessionByVRMenu
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwVRSessionByVRMenu.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RecordID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwVRSessionByVRMenu_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwVRSessionByVRMenu.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RecordID As Int32 = GVtlwVRSessionByVRMenu.DataKeys(e.CommandArgument).Values("RecordID")  
        Dim RedirectUrl As String = TBLtlwVRSessionByVRMenu.EditUrl & "?RecordID=" & RecordID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwVRSessionByVRMenu_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwVRSessionByVRMenu.Init
    DataClassName = "GtlwVRSessionByVRMenu"
    SetGridView = GVtlwVRSessionByVRMenu
  End Sub
  Protected Sub TBLtlwVRSessionByVRMenu_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessionByVRMenu.Init
    SetToolBar = TBLtlwVRSessionByVRMenu
  End Sub
  Protected Sub F_VRMenuID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VRMenuID.SelectedIndexChanged
    Session("F_VRMenuID") = F_VRMenuID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_VRSessionID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VRSessionID.SelectedIndexChanged
    Session("F_VRSessionID") = F_VRSessionID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_VRMenuID.SelectedValue = String.Empty
    If Not Session("F_VRMenuID") Is Nothing Then
      If Session("F_VRMenuID") <> String.Empty Then
        F_VRMenuID.SelectedValue = Session("F_VRMenuID")
      End If
    End If
    F_VRSessionID.SelectedValue = String.Empty
    If Not Session("F_VRSessionID") Is Nothing Then
      If Session("F_VRSessionID") <> String.Empty Then
        F_VRSessionID.SelectedValue = Session("F_VRSessionID")
      End If
    End If
  End Sub
End Class
