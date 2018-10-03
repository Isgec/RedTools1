<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_tlwLGPageSize.aspx.vb" Inherits="EF_tlwLGPageSize" title="Edit: Page Size" %>
<asp:Content ID="CPHtlwLGPageSize" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwLGPageSize" runat="server" Text="&nbsp;Edit: Page Size"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwLGPageSize" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwLGPageSize"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "tlwLGPageSize"
    runat = "server" />
<asp:FormView ID="FVtlwLGPageSize"
  runat = "server"
  DataKeyNames = "PageID"
  DataSourceID = "ODStlwLGPageSize"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PageID" runat="server" ForeColor="#CC6633" Text="PageID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_PageID"
            Text='<%# Bind("PageID") %>'
            ToolTip="Value of PageID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_LoginID" runat="server" Text="LoginID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_LoginID"
            Text='<%# Bind("LoginID") %>'
            Width="140px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwLGPageSize"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for LoginID."
            MaxLength="20"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVLoginID"
            runat = "server"
            ControlToValidate = "F_LoginID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwLGPageSize"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PageName" runat="server" Text="PageName :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_PageName"
            Text='<%# Bind("PageName") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwLGPageSize"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PageName."
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPageName"
            runat = "server"
            ControlToValidate = "F_PageName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwLGPageSize"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PageSize" runat="server" Text="PageSize :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_PageSize"
            Text='<%# Bind("PageSize") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="tlwLGPageSize"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPageSize"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PageSize" />
          <AJX:MaskedEditValidator 
            ID = "MEVPageSize"
            runat = "server"
            ControlToValidate = "F_PageSize"
            ControlExtender = "MEEPageSize"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwLGPageSize"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PageNo" runat="server" Text="PageNo :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_PageNo"
            Text='<%# Bind("PageNo") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="tlwLGPageSize"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPageNo"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_PageNo" />
          <AJX:MaskedEditValidator 
            ID = "MEVPageNo"
            runat = "server"
            ControlToValidate = "F_PageNo"
            ControlExtender = "MEEPageNo"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwLGPageSize"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwLGPageSize"
  DataObjectTypeName = "SIS.TLW.tlwLGPageSize"
  SelectMethod = "tlwLGPageSizeGetByID"
  UpdateMethod="UZ_tlwLGPageSizeUpdate"
  DeleteMethod="UZ_tlwLGPageSizeDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwLGPageSize"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PageID" Name="PageID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
