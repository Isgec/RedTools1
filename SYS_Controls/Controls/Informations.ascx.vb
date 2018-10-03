Imports System.Collections.Generic
Partial Class Informations
  Inherits System.Web.UI.UserControl
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If HttpContext.Current.User.Identity.IsAuthenticated Then
      Dim oEmp As SIS.TLW.tlwUsers = SIS.TLW.tlwUsers.tlwUsersGetByID(HttpContext.Current.User.Identity.Name)
			If Not oEmp Is Nothing Then
        F_EmployeeName.Text = oEmp.UserFullName
        F_LoginID.Text = HttpContext.Current.User.Identity.Name
      End If
      Me.Visible = True
      If Not Page.IsPostBack And Not Page.IsCallback Then
        SelectedApplication.SelectedValue = Session("ApplicationID").ToString
      End If
    End If
	End Sub
  Protected Sub SelectedApplication_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectedApplication.SelectedIndexChanged
    HttpContext.Current.Session("ApplicationID") = Convert.ToInt32(SelectedApplication.SelectedValue)
  End Sub
End Class
