<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_tlwVRMenuByVRRole.aspx.vb" Inherits="EF_tlwVRMenuByVRRole" title="Edit: Menu By Roles" %>
<asp:Content ID="CPHtlwVRMenuByVRRole" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRMenuByVRRole" runat="server" Text="&nbsp;Edit: Menu By Roles"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRMenuByVRRole" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRMenuByVRRole"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "tlwVRMenuByVRRole"
    runat = "server" />
<asp:FormView ID="FVtlwVRMenuByVRRole"
  runat = "server"
  DataKeyNames = "RecordID"
  DataSourceID = "ODStlwVRMenuByVRRole"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecordID" runat="server" ForeColor="#CC6633" Text="RecordID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_RecordID"
            Text='<%# Bind("RecordID") %>'
            ToolTip="Value of RecordID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VRRoleID" runat="server" Text="VRRoleID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_tlwVRRoles
            ID="F_VRRoleID"
            SelectedValue='<%# Bind("VRRoleID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "tlwVRMenuByVRRole"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VRMenuID" runat="server" Text="VRMenuID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_tlwVRMenus
            ID="F_VRMenuID"
            SelectedValue='<%# Bind("VRMenuID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "tlwVRMenuByVRRole"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_Sequence" runat="server" Text="Sequence :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Sequence"
            Text='<%# Bind("Sequence") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="tlwVRMenuByVRRole"
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
            ValidationGroup = "tlwVRMenuByVRRole"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwVRMenuByVRRole"
  DataObjectTypeName = "SIS.TLW.tlwVRMenuByVRRole"
  SelectMethod = "tlwVRMenuByVRRoleGetByID"
  UpdateMethod="UZ_tlwVRMenuByVRRoleUpdate"
  DeleteMethod="UZ_tlwVRMenuByVRRoleDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRMenuByVRRole"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecordID" Name="RecordID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
