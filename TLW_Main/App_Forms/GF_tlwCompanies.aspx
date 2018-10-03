<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwCompanies.aspx.vb" Inherits="GF_tlwCompanies" title="Maintain List: Companies" %>
<asp:Content ID="CPHtlwCompanies" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwCompanies" runat="server" Text="&nbsp;List: Companies"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwCompanies" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwCompanies"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwCompanies.aspx"
      EnableAdd = "False"
      ValidationGroup = "tlwCompanies"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwCompanies" runat="server" AssociatedUpdatePanelID="UPNLtlwCompanies" DisplayAfter="100">
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
          <b><asp:Label ID="L_CompanyID" runat="server" Text="CompanyID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_CompanyID"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="6"
            Width="42px"
            runat="server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtlwCompanies" SkinID="gv_silver" runat="server" DataSourceID="ODStlwCompanies" DataKeyNames="CompanyID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CompanyID" SortExpression="CompanyID">
          <ItemTemplate>
            <asp:Label ID="LabelCompanyID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CompanyID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ShortName" SortExpression="ShortName">
          <ItemTemplate>
            <asp:Label ID="LabelShortName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ShortName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BaaNID" SortExpression="BaaNID">
          <ItemTemplate>
            <asp:Label ID="LabelBaaNID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BaaNID") %>'></asp:Label>
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
      ID = "ODStlwCompanies"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwCompanies"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "tlwCompaniesSelectList"
      TypeName = "SIS.TLW.tlwCompanies"
      SelectCountMethod = "tlwCompaniesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_CompanyID" PropertyName="Text" Name="CompanyID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwCompanies" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_CompanyID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
