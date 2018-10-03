<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_tlwVRSessionByVRMenu.aspx.vb" Inherits="AF_tlwVRSessionByVRMenu" title="Add: Sessions By Menu" %>
<asp:Content ID="CPHtlwVRSessionByVRMenu" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRSessionByVRMenu" runat="server" Text="&nbsp;Add: Sessions By Menu"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRSessionByVRMenu" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRSessionByVRMenu"
    ToolType = "lgNMAdd"
    InsertAndStay = "True"
    ValidationGroup = "tlwVRSessionByVRMenu"
    runat = "server" />
<asp:FormView ID="FVtlwVRSessionByVRMenu"
  runat = "server"
  DataKeyNames = "RecordID"
  DataSourceID = "ODStlwVRSessionByVRMenu"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtlwVRSessionByVRMenu" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecordID" ForeColor="#CC6633" runat="server" Text="RecordID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_RecordID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
            Width="70px"
            style="text-align: right"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwVRSessionByVRMenu"
  DataObjectTypeName = "SIS.TLW.tlwVRSessionByVRMenu"
  InsertMethod="UZ_tlwVRSessionByVRMenuInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRSessionByVRMenu"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
