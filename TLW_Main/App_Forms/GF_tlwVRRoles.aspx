<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwVRRoles.aspx.vb" Inherits="GF_tlwVRRoles" title="Maintain List: Roles" %>
<asp:Content ID="CPHtlwVRRoles" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwVRRoles" runat="server" Text="&nbsp;List: Roles"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRRoles" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwVRRoles"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwVRRoles.aspx"
      AddUrl = "~/TLW_Main/App_Create/AF_tlwVRRoles.aspx"
      ValidationGroup = "tlwVRRoles"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwVRRoles" runat="server" AssociatedUpdatePanelID="UPNLtlwVRRoles" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_VRRoleID" runat="server" Text="VRRoleID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_VRRoleID"
            Text=""
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEVRRoleID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_VRRoleID" />
          <AJX:MaskedEditValidator 
            ID = "MEVVRRoleID"
            runat = "server"
            ControlToValidate = "F_VRRoleID"
            ControlExtender = "MEEVRRoleID"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtlwVRRoles" SkinID="gv_silver" runat="server" DataSourceID="ODStlwVRRoles" DataKeyNames="VRRoleID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRRoleID" SortExpression="VRRoleID">
          <ItemTemplate>
            <asp:Label ID="LabelVRRoleID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VRRoleID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRRoleType" SortExpression="VRRoleType">
          <ItemTemplate>
            <asp:Label ID="LabelVRRoleType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VRRoleType") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DefaultRole" SortExpression="DefaultRole">
          <ItemTemplate>
            <asp:Label ID="LabelDefaultRole" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DefaultRole") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStlwVRRoles"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwVRRoles"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tlwVRRolesSelectList"
      TypeName = "SIS.TLW.tlwVRRoles"
      SelectCountMethod = "tlwVRRolesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_VRRoleID" PropertyName="Text" Name="VRRoleID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwVRRoles" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_VRRoleID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
