<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_tlwVRSessionByVRMenu.aspx.vb" Inherits="EF_tlwVRSessionByVRMenu" title="Edit: Sessions By Menu" %>
<asp:Content ID="CPHtlwVRSessionByVRMenu" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRSessionByVRMenu" runat="server" Text="&nbsp;Edit: Sessions By Menu"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRSessionByVRMenu" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRSessionByVRMenu"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "tlwVRSessionByVRMenu"
    runat = "server" />
<asp:FormView ID="FVtlwVRSessionByVRMenu"
  runat = "server"
  DataKeyNames = "RecordID"
  DataSourceID = "ODStlwVRSessionByVRMenu"
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
            ValidationGroup = "tlwVRSessionByVRMenu"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VRSessionID" runat="server" Text="VRSessionID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_tlwVRSessions
            ID="F_VRSessionID"
            SelectedValue='<%# Bind("VRSessionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "tlwVRSessionByVRMenu"
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
            ValidationGroup="tlwVRSessionByVRMenu"
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
            ValidationGroup = "tlwVRSessionByVRMenu"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaintainGrid" runat="server" Text="MaintainGrid :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_MaintainGrid"
            Checked='<%# Bind("MaintainGrid") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InsertForm" runat="server" Text="InsertForm :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_InsertForm"
            Checked='<%# Bind("InsertForm") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UpdateForm" runat="server" Text="UpdateForm :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_UpdateForm"
            Checked='<%# Bind("UpdateForm") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DisplayGrid" runat="server" Text="DisplayGrid :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DisplayGrid"
            Checked='<%# Bind("DisplayGrid") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DisplayForm" runat="server" Text="DisplayForm :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DisplayForm"
            Checked='<%# Bind("DisplayForm") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DeleteOption" runat="server" Text="DeleteOption :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DeleteOption"
            Checked='<%# Bind("DeleteOption") %>'
            CssClass = "mychk"
            runat="server" />
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
  ID = "ODStlwVRSessionByVRMenu"
  DataObjectTypeName = "SIS.TLW.tlwVRSessionByVRMenu"
  SelectMethod = "tlwVRSessionByVRMenuGetByID"
  UpdateMethod="UZ_tlwVRSessionByVRMenuUpdate"
  DeleteMethod="UZ_tlwVRSessionByVRMenuDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRSessionByVRMenu"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecordID" Name="RecordID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
