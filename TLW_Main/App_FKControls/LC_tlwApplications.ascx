<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwApplications.ascx.vb" Inherits="LC_tlwApplications" %>
<asp:DropDownList 
  ID = "DDLtlwApplications"
  DataSourceID = "OdsDdltlwApplications"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwApplications"
  Runat = "server" 
  ControlToValidate = "DDLtlwApplications"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwApplications"
  TypeName = "SIS.TLW.tlwApplications"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwApplicationsSelectList"
  Runat="server" />
