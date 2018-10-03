<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwDivisions.aspx.vb" Inherits="GF_tlwDivisions" title="Maintain List: Division" %>
<asp:Content ID="CPHtlwDivisions" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwDivisions" runat="server" Text="&nbsp;List: Division"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwDivisions" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwDivisions"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwDivisions.aspx"
      EnableAdd = "False"
      ValidationGroup = "tlwDivisions"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwDivisions" runat="server" AssociatedUpdatePanelID="UPNLtlwDivisions" DisplayAfter="100">
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
          <b><asp:Label ID="L_DivisionID" runat="server" Text="DivisionID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_DivisionID"
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
    <asp:GridView ID="GVtlwDivisions" SkinID="gv_silver" runat="server" DataSourceID="ODStlwDivisions" DataKeyNames="DivisionID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DivisionID" SortExpression="DivisionID">
          <ItemTemplate>
            <asp:Label ID="LabelDivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DivisionID") %>'></asp:Label>
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
        <asp:TemplateField HeaderText="DivisionHead" SortExpression="HRM_Employees1_EmployeeName">
          <ItemTemplate>
             <asp:Label ID="L_DivisionHead" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DivisionHead") %>' Text='<%# Eval("HRM_Employees1_EmployeeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP_EU" SortExpression="ERP_EU">
          <ItemTemplate>
            <asp:Label ID="LabelERP_EU" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ERP_EU") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP_Div" SortExpression="ERP_Div">
          <ItemTemplate>
            <asp:Label ID="LabelERP_Div" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ERP_Div") %>'></asp:Label>
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
      ID = "ODStlwDivisions"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwDivisions"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "tlwDivisionsSelectList"
      TypeName = "SIS.TLW.tlwDivisions"
      SelectCountMethod = "tlwDivisionsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DivisionID" PropertyName="Text" Name="DivisionID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwDivisions" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_DivisionID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
