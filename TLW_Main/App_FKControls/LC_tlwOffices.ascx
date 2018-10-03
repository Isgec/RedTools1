<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwOffices.ascx.vb" Inherits="LC_tlwOffices" %>
<asp:DropDownList 
  ID = "DDLtlwOffices"
  DataSourceID = "OdsDdltlwOffices"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwOffices"
  Runat = "server" 
  ControlToValidate = "DDLtlwOffices"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwOffices"
  TypeName = "SIS.TLW.tlwOffices"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwOfficesSelectList"
  Runat="server" />
