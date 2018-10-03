<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwCompanies.ascx.vb" Inherits="LC_tlwCompanies" %>
<asp:DropDownList 
  ID = "DDLtlwCompanies"
  DataSourceID = "OdsDdltlwCompanies"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwCompanies"
  Runat = "server" 
  ControlToValidate = "DDLtlwCompanies"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwCompanies"
  TypeName = "SIS.TLW.tlwCompanies"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwCompaniesSelectList"
  Runat="server" />
