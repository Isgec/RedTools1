<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwVRMenus.ascx.vb" Inherits="LC_tlwVRMenus" %>
<asp:DropDownList 
  ID = "DDLtlwVRMenus"
  DataSourceID = "OdsDdltlwVRMenus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwVRMenus"
  Runat = "server" 
  ControlToValidate = "DDLtlwVRMenus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwVRMenus"
  TypeName = "SIS.TLW.tlwVRMenus"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwVRMenusSelectList"
  Runat="server" />
