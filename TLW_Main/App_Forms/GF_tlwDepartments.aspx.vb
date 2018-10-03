Partial Class GF_tlwDepartments
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwDepartments.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DepartmentID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwDepartments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwDepartments.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DepartmentID As String = GVtlwDepartments.DataKeys(e.CommandArgument).Values("DepartmentID")  
        Dim RedirectUrl As String = TBLtlwDepartments.EditUrl & "?DepartmentID=" & DepartmentID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwDepartments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwDepartments.Init
    DataClassName = "GtlwDepartments"
    SetGridView = GVtlwDepartments
  End Sub
  Protected Sub TBLtlwDepartments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwDepartments.Init
    SetToolBar = TBLtlwDepartments
  End Sub
  Protected Sub F_DepartmentID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DepartmentID.TextChanged
    Session("F_DepartmentID") = F_DepartmentID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
