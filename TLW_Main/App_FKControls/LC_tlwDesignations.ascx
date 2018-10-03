<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tlwDesignations.ascx.vb" Inherits="LC_tlwDesignations" %>
<asp:DropDownList 
  ID = "DDLtlwDesignations"
  DataSourceID = "OdsDdltlwDesignations"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortlwDesignations"
  Runat = "server" 
  ControlToValidate = "DDLtlwDesignations"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltlwDesignations"
  TypeName = "SIS.TLW.tlwDesignations"
  SortParameterName = "OrderBy"
  SelectMethod = "tlwDesignationsSelectList"
  Runat="server" />
