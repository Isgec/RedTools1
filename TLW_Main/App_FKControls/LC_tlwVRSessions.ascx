<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwVRSessions.ascx.vb" Inherits="LC_tlwVRSessions" %>
<asp:DropDownList 
  ID = "DDLtlwVRSessions"
  DataSourceID = "OdsDdltlwVRSessions"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwVRSessions"
  Runat = "server" 
  ControlToValidate = "DDLtlwVRSessions"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwVRSessions"
  TypeName = "SIS.TLW.tlwVRSessions"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwVRSessionsSelectList"
  Runat="server" />
