<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwVRRoles.ascx.vb" Inherits="LC_tlwVRRoles" %>
<asp:DropDownList 
  ID = "DDLtlwVRRoles"
  DataSourceID = "OdsDdltlwVRRoles"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwVRRoles"
  Runat = "server" 
  ControlToValidate = "DDLtlwVRRoles"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwVRRoles"
  TypeName = "SIS.TLW.tlwVRRoles"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwVRRolesSelectList"
  Runat="server" />
