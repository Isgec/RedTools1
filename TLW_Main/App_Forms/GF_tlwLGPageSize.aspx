<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwLGPageSize.aspx.vb" Inherits="GF_tlwLGPageSize" title="Maintain List: Page Size" %>
<asp:Content ID="CPHtlwLGPageSize" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwLGPageSize" runat="server" Text="&nbsp;List: Page Size"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwLGPageSize" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwLGPageSize"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwLGPageSize.aspx"
      AddUrl = "~/TLW_Main/App_Create/AF_tlwLGPageSize.aspx"
      ValidationGroup = "tlwLGPageSize"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwLGPageSize" runat="server" AssociatedUpdatePanelID="UPNLtlwLGPageSize" DisplayAfter="100">
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
          <b><asp:Label ID="L_LoginID" runat="server" Text="LoginID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_LoginID"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="20"
            Width="140px"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtlwLGPageSize" SkinID="gv_silver" runat="server" DataSourceID="ODStlwLGPageSize" DataKeyNames="PageID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PageID" SortExpression="PageID">
          <ItemTemplate>
            <asp:Label ID="LabelPageID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PageID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="LoginID" SortExpression="LoginID">
          <ItemTemplate>
            <asp:Label ID="LabelLoginID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LoginID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PageName" SortExpression="PageName">
          <ItemTemplate>
            <asp:Label ID="LabelPageName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PageName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PageSize" SortExpression="PageSize">
          <ItemTemplate>
            <asp:Label ID="LabelPageSize" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PageSize") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PageNo" SortExpression="PageNo">
          <ItemTemplate>
            <asp:Label ID="LabelPageNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PageNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStlwLGPageSize"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwLGPageSize"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tlwLGPageSizeSelectList"
      TypeName = "SIS.TLW.tlwLGPageSize"
      SelectCountMethod = "tlwLGPageSizeSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_LoginID" PropertyName="Text" Name="LoginID" Type="String" Size="20" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwLGPageSize" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_LoginID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
