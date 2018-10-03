<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwUsers.ascx.vb" Inherits="LC_tlwUsers" %>
<asp:DropDownList 
  ID = "DDLtlwUsers"
  DataSourceID = "OdsDdltlwUsers"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwUsers"
  Runat = "server" 
  ControlToValidate = "DDLtlwUsers"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwUsers"
  TypeName = "SIS.TLW.tlwUsers"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwUsersSelectList"
  Runat="server" />
