Partial Class GF_tlwDesignations
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwDesignations.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DesignationID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwDesignations_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwDesignations.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DesignationID As Int32 = GVtlwDesignations.DataKeys(e.CommandArgument).Values("DesignationID")  
        Dim RedirectUrl As String = TBLtlwDesignations.EditUrl & "?DesignationID=" & DesignationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwDesignations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwDesignations.Init
    DataClassName = "GtlwDesignations"
    SetGridView = GVtlwDesignations
  End Sub
  Protected Sub TBLtlwDesignations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwDesignations.Init
    SetToolBar = TBLtlwDesignations
  End Sub
  Protected Sub F_DesignationID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DesignationID.TextChanged
    Session("F_DesignationID") = F_DesignationID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
