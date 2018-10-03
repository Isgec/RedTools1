<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwDepartments.ascx.vb" Inherits="LC_tlwDepartments" %>
<asp:DropDownList 
  ID = "DDLtlwDepartments"
  DataSourceID = "OdsDdltlwDepartments"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwDepartments"
  Runat = "server" 
  ControlToValidate = "DDLtlwDepartments"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwDepartments"
  TypeName = "SIS.TLW.tlwDepartments"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwDepartmentsSelectList"
  Runat="server" />
