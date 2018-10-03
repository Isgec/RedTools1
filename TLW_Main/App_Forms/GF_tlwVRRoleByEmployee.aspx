<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwVRRoleByEmployee.aspx.vb" Inherits="GF_tlwVRRoleByEmployee" title="Maintain List: Roles By Employee" %>
<asp:Content ID="CPHtlwVRRoleByEmployee" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwVRRoleByEmployee" runat="server" Text="&nbsp;List: Roles By Employee"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRRoleByEmployee" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwVRRoleByEmployee"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwVRRoleByEmployee.aspx"
      AddUrl = "~/TLW_Main/App_Create/AF_tlwVRRoleByEmployee.aspx"
      ValidationGroup = "tlwVRRoleByEmployee"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwVRRoleByEmployee" runat="server" AssociatedUpdatePanelID="UPNLtlwVRRoleByEmployee" DisplayAfter="100">
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
          <LGM:LC_tlwVRRoles
            ID="F_VRRoleID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="VRRoleID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtlwVRRoleByEmployee" SkinID="gv_silver" runat="server" DataSourceID="ODStlwVRRoleByEmployee" DataKeyNames="RecordID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RecordID" SortExpression="RecordID">
          <ItemTemplate>
            <asp:Label ID="LabelRecordID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RecordID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRRoleID" SortExpression="SYS_VRRoles2_Description">
          <ItemTemplate>
             <asp:Label ID="L_VRRoleID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VRRoleID") %>' Text='<%# Eval("SYS_VRRoles2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserName" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_UserName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserName") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStlwVRRoleByEmployee"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwVRRoleByEmployee"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tlwVRRoleByEmployeeSelectList"
      TypeName = "SIS.TLW.tlwVRRoleByEmployee"
      SelectCountMethod = "tlwVRRoleByEmployeeSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_VRRoleID" PropertyName="SelectedValue" Name="VRRoleID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwVRRoleByEmployee" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_VRRoleID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
