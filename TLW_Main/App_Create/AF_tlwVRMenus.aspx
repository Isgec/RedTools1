<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_tlwVRMenus.aspx.vb" Inherits="AF_tlwVRMenus" title="Add: Menus" %>
<asp:Content ID="CPHtlwVRMenus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRMenus" runat="server" Text="&nbsp;Add: Menus"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRMenus" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRMenus"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "tlwVRMenus"
    runat = "server" />
<asp:FormView ID="FVtlwVRMenus"
  runat = "server"
  DataKeyNames = "VRMenuID"
  DataSourceID = "ODStlwVRMenus"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtlwVRMenus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_VRMenuID" ForeColor="#CC6633" runat="server" Text="VRMenuID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_VRMenuID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VRMenuName" runat="server" Text="VRMenuName :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VRMenuName"
            Text='<%# Bind("VRMenuName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRMenus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for VRMenuName."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVVRMenuName"
            runat = "server"
            ControlToValidate = "F_VRMenuName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRMenus"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ToolTip" runat="server" Text="ToolTip :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ToolTip"
            Text='<%# Bind("ToolTip") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRMenus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ToolTip."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVToolTip"
            runat = "server"
            ControlToValidate = "F_ToolTip"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRMenus"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ParentVRMenuID" runat="server" Text="VRMenuID :" />
        </td>
        <td>
          <LGM:LC_tlwVRMenus
            ID="F_ParentVRMenuID"
            SelectedValue='<%# Bind("ParentVRMenuID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VRMenuType" runat="server" Text="VRMenuType :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VRMenuType"
            Text='<%# Bind("VRMenuType") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRMenus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for VRMenuType."
            MaxLength="1"
            Width="7px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CSSClass" runat="server" Text="CSSClass :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CSSClass"
            Text='<%# Bind("CSSClass") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRMenus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CSSClass."
            MaxLength="20"
            Width="140px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Sequence" runat="server" Text="Sequence :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Sequence"
            Text='<%# Bind("Sequence") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            ValidationGroup="tlwVRMenus"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEESequence"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Sequence" />
          <AJX:MaskedEditValidator 
            ID = "MEVSequence"
            runat = "server"
            ControlToValidate = "F_Sequence"
            ControlExtender = "MEESequence"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRMenus"
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
  ID = "ODStlwVRMenus"
  DataObjectTypeName = "SIS.TLW.tlwVRMenus"
  InsertMethod="UZ_tlwVRMenusInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRMenus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
