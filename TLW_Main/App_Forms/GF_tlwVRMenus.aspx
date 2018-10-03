<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwVRMenus.aspx.vb" Inherits="GF_tlwVRMenus" title="Maintain List: Menus" %>
<asp:Content ID="CPHtlwVRMenus" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwVRMenus" runat="server" Text="&nbsp;List: Menus"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRMenus" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwVRMenus"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwVRMenus.aspx"
      AddUrl = "~/TLW_Main/App_Create/AF_tlwVRMenus.aspx"
      ValidationGroup = "tlwVRMenus"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwVRMenus" runat="server" AssociatedUpdatePanelID="UPNLtlwVRMenus" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtlwVRMenus" SkinID="gv_silver" runat="server" DataSourceID="ODStlwVRMenus" DataKeyNames="VRMenuID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRMenuID" SortExpression="VRMenuID">
          <ItemTemplate>
            <asp:Label ID="LabelVRMenuID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VRMenuID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRMenuName" SortExpression="VRMenuName">
          <ItemTemplate>
            <asp:Label ID="LabelVRMenuName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VRMenuName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ToolTip" SortExpression="ToolTip">
          <ItemTemplate>
            <asp:Label ID="LabelToolTip" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ToolTip") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRMenuID" SortExpression="SYS_VRMenus2_VRMenuName">
          <ItemTemplate>
             <asp:Label ID="L_ParentVRMenuID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ParentVRMenuID") %>' Text='<%# Eval("FK_SYS_VRMenus_SYS_VRMenus.VRMenuName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRMenuType" SortExpression="VRMenuType">
          <ItemTemplate>
            <asp:Label ID="LabelVRMenuType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VRMenuType") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CSSClass" SortExpression="CSSClass">
          <ItemTemplate>
            <asp:Label ID="LabelCSSClass" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CSSClass") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence">
          <ItemTemplate>
            <asp:Label ID="LabelSequence" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Sequence") %>'></asp:Label>
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
      ID = "ODStlwVRMenus"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwVRMenus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tlwVRMenusSelectList"
      TypeName = "SIS.TLW.tlwVRMenus"
      SelectCountMethod = "tlwVRMenusSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwVRMenus" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
