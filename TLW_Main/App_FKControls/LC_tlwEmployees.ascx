<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwEmployees.ascx.vb" Inherits="LC_tlwEmployees" %>
<asp:DropDownList 
  ID = "DDLtlwEmployees"
  DataSourceID = "OdsDdltlwEmployees"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwEmployees"
  Runat = "server" 
  ControlToValidate = "DDLtlwEmployees"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwEmployees"
  TypeName = "SIS.TLW.tlwEmployees"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwEmployeesSelectList"
  Runat="server" />
