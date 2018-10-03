Partial Class GF_tlwVRRoleByEmployee
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwVRRoleByEmployee.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RecordID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwVRRoleByEmployee_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwVRRoleByEmployee.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RecordID As Int32 = GVtlwVRRoleByEmployee.DataKeys(e.CommandArgument).Values("RecordID")  
        Dim RedirectUrl As String = TBLtlwVRRoleByEmployee.EditUrl & "?RecordID=" & RecordID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwVRRoleByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwVRRoleByEmployee.Init
    DataClassName = "GtlwVRRoleByEmployee"
    SetGridView = GVtlwVRRoleByEmployee
  End Sub
  Protected Sub TBLtlwVRRoleByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRRoleByEmployee.Init
    SetToolBar = TBLtlwVRRoleByEmployee
  End Sub
  Protected Sub F_VRRoleID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VRRoleID.SelectedIndexChanged
    Session("F_VRRoleID") = F_VRRoleID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_VRRoleID.SelectedValue = String.Empty
    If Not Session("F_VRRoleID") Is Nothing Then
      If Session("F_VRRoleID") <> String.Empty Then
        F_VRRoleID.SelectedValue = Session("F_VRRoleID")
      End If
    End If
  End Sub
End Class
