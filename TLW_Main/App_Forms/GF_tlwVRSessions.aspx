<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwVRSessions.aspx.vb" Inherits="GF_tlwVRSessions" title="Maintain List: Sessions" %>
<asp:Content ID="CPHtlwVRSessions" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwVRSessions" runat="server" Text="&nbsp;List: Sessions"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRSessions" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwVRSessions"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwVRSessions.aspx"
      AddUrl = "~/TLW_Main/App_Create/AF_tlwVRSessions.aspx"
      ValidationGroup = "tlwVRSessions"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwVRSessions" runat="server" AssociatedUpdatePanelID="UPNLtlwVRSessions" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtlwVRSessions" SkinID="gv_silver" runat="server" DataSourceID="ODStlwVRSessions" DataKeyNames="VRSessionID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRSessionID" SortExpression="VRSessionID">
          <ItemTemplate>
            <asp:Label ID="LabelVRSessionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VRSessionID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FileName" SortExpression="FileName">
          <ItemTemplate>
            <asp:Label ID="LabelFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FolderLocation" SortExpression="FolderLocation">
          <ItemTemplate>
            <asp:Label ID="LabelFolderLocation" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FolderLocation") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
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
        <asp:TemplateField HeaderText="VRSessionType" SortExpression="VRSessionType">
          <ItemTemplate>
            <asp:Label ID="LabelVRSessionType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VRSessionType") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CSSClass" SortExpression="CSSClass">
          <ItemTemplate>
            <asp:Label ID="LabelCSSClass" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CSSClass") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MaintainGrid" SortExpression="MaintainGrid">
          <ItemTemplate>
            <asp:Label ID="LabelMaintainGrid" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MaintainGrid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="InsertForm" SortExpression="InsertForm">
          <ItemTemplate>
            <asp:Label ID="LabelInsertForm" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("InsertForm") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UpdateForm" SortExpression="UpdateForm">
          <ItemTemplate>
            <asp:Label ID="LabelUpdateForm" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UpdateForm") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DisplayGrid" SortExpression="DisplayGrid">
          <ItemTemplate>
            <asp:Label ID="LabelDisplayGrid" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DisplayGrid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DisplayForm" SortExpression="DisplayForm">
          <ItemTemplate>
            <asp:Label ID="LabelDisplayForm" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DisplayForm") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DeleteOption" SortExpression="DeleteOption">
          <ItemTemplate>
            <asp:Label ID="LabelDeleteOption" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeleteOption") %>'></asp:Label>
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
      ID = "ODStlwVRSessions"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwVRSessions"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tlwVRSessionsSelectList"
      TypeName = "SIS.TLW.tlwVRSessions"
      SelectCountMethod = "tlwVRSessionsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtlwVRSessions" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
