<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwDivisions.ascx.vb" Inherits="LC_tlwDivisions" %>
<asp:DropDownList 
  ID = "DDLtlwDivisions"
  DataSourceID = "OdsDdltlwDivisions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwDivisions"
  Runat = "server" 
  ControlToValidate = "DDLtlwDivisions"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwDivisions"
  TypeName = "SIS.TLW.tlwDivisions"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwDivisionsSelectList"
  Runat="server" />
