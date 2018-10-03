<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_tlwLGPageSize.aspx.vb" Inherits="AF_tlwLGPageSize" title="Add: Page Size" %>
<asp:Content ID="CPHtlwLGPageSize" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwLGPageSize" runat="server" Text="&nbsp;Add: Page Size"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwLGPageSize" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwLGPageSize"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "tlwLGPageSize"
    runat = "server" />
<asp:FormView ID="FVtlwLGPageSize"
  runat = "server"
  DataKeyNames = "PageID"
  DataSourceID = "ODStlwLGPageSize"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtlwLGPageSize" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PageID" ForeColor="#CC6633" runat="server" Text="PageID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_PageID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_LoginID" runat="server" Text="LoginID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_LoginID"
            Text='<%# Bind("LoginID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwLGPageSize"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for LoginID."
            MaxLength="20"
            Width="140px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwLGPageSize"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PageName."
            MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
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
            Width="70px"
            style="text-align: right"
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
            Width="70px"
            style="text-align: right"
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
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwLGPageSize"
  DataObjectTypeName = "SIS.TLW.tlwLGPageSize"
  InsertMethod="UZ_tlwLGPageSizeInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwLGPageSize"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
