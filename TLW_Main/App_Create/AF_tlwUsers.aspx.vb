Partial Class AF_tlwUsers
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtlwUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwUsers.Init
    DataClassName = "AtlwUsers"
    SetFormView = FVtlwUsers
  End Sub
  Protected Sub TBLtlwUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwUsers.Init
    SetToolBar = TBLtlwUsers
  End Sub
  Protected Sub FVtlwUsers_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwUsers.DataBound
    SIS.TLW.tlwUsers.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtlwUsers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwUsers.PreRender
    Dim oF_C_CompanyID As LC_tlwCompanies = FVtlwUsers.FindControl("F_C_CompanyID")
    oF_C_CompanyID.Enabled = True
    oF_C_CompanyID.SelectedValue = String.Empty
    If Not Session("F_C_CompanyID") Is Nothing Then
      If Session("F_C_CompanyID") <> String.Empty Then
        oF_C_CompanyID.SelectedValue = Session("F_C_CompanyID")
      End If
    End If
    Dim oF_C_DivisionID As LC_tlwDivisions = FVtlwUsers.FindControl("F_C_DivisionID")
    oF_C_DivisionID.Enabled = True
    oF_C_DivisionID.SelectedValue = String.Empty
    If Not Session("F_C_DivisionID") Is Nothing Then
      If Session("F_C_DivisionID") <> String.Empty Then
        oF_C_DivisionID.SelectedValue = Session("F_C_DivisionID")
      End If
    End If
    Dim oF_C_OfficeID As LC_tlwOffices = FVtlwUsers.FindControl("F_C_OfficeID")
    oF_C_OfficeID.Enabled = True
    oF_C_OfficeID.SelectedValue = String.Empty
    If Not Session("F_C_OfficeID") Is Nothing Then
      If Session("F_C_OfficeID") <> String.Empty Then
        oF_C_OfficeID.SelectedValue = Session("F_C_OfficeID")
      End If
    End If
    Dim oF_C_DepartmentID As LC_tlwDepartments = FVtlwUsers.FindControl("F_C_DepartmentID")
    oF_C_DepartmentID.Enabled = True
    oF_C_DepartmentID.SelectedValue = String.Empty
    If Not Session("F_C_DepartmentID") Is Nothing Then
      If Session("F_C_DepartmentID") <> String.Empty Then
        oF_C_DepartmentID.SelectedValue = Session("F_C_DepartmentID")
      End If
    End If
    Dim oF_C_DesignationID As LC_tlwDesignations = FVtlwUsers.FindControl("F_C_DesignationID")
    oF_C_DesignationID.Enabled = True
    oF_C_DesignationID.SelectedValue = String.Empty
    If Not Session("F_C_DesignationID") Is Nothing Then
      If Session("F_C_DesignationID") <> String.Empty Then
        oF_C_DesignationID.SelectedValue = Session("F_C_DesignationID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Create") & "/AF_tlwUsers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwUsers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwUsers", mStr)
    End If
    If Request.QueryString("LoginID") IsNot Nothing Then
      CType(FVtlwUsers.FindControl("F_LoginID"), TextBox).Text = Request.QueryString("LoginID")
      CType(FVtlwUsers.FindControl("F_LoginID"), TextBox).Enabled = False
    End If
  End Sub

End Class
