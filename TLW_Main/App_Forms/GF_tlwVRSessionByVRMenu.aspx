<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwVRSessionByVRMenu.aspx.vb" Inherits="GF_tlwVRSessionByVRMenu" title="Maintain List: Sessions By Menu" %>
<asp:Content ID="CPHtlwVRSessionByVRMenu" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwVRSessionByVRMenu" runat="server" Text="&nbsp;List: Sessions By Menu"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRSessionByVRMenu" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwVRSessionByVRMenu"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwVRSessionByVRMenu.aspx"
      AddUrl = "~/TLW_Main/App_Create/AF_tlwVRSessionByVRMenu.aspx"
      ValidationGroup = "tlwVRSessionByVRMenu"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwVRSessionByVRMenu" runat="server" AssociatedUpdatePanelID="UPNLtlwVRSessionByVRMenu" DisplayAfter="100">
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
          <b><asp:Label ID="L_VRMenuID" runat="server" Text="VRMenuID :" /></b>
        </td>
        <td>
          <LGM:LC_tlwVRMenus
            ID="F_VRMenuID"
            SelectedValue=""
            OrderBy="VRMenuName"
            DataTextField="VRMenuName"
            DataValueField="VRMenuID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_VRSessionID" runat="server" Text="VRSessionID :" /></b>
        </td>
        <td>
          <LGM:LC_tlwVRSessions
            ID="F_VRSessionID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="VRSessionID"
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
    <asp:GridView ID="GVtlwVRSessionByVRMenu" SkinID="gv_silver" runat="server" DataSourceID="ODStlwVRSessionByVRMenu" DataKeyNames="RecordID">
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
        <asp:TemplateField HeaderText="VRMenuID" SortExpression="SYS_VRMenus2_VRMenuName">
          <ItemTemplate>
             <asp:Label ID="L_VRMenuID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VRMenuID") %>' Text='<%# Eval("SYS_VRMenus2_VRMenuName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VRSessionID" SortExpression="SYS_VRSessions3_Description">
          <ItemTemplate>
             <asp:Label ID="L_VRSessionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VRSessionID") %>' Text='<%# Eval("SYS_VRSessions3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence">
          <ItemTemplate>
            <asp:Label ID="LabelSequence" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Sequence") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
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
      ID = "ODStlwVRSessionByVRMenu"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwVRSessionByVRMenu"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tlwVRSessionByVRMenuSelectList"
      TypeName = "SIS.TLW.tlwVRSessionByVRMenu"
      SelectCountMethod = "tlwVRSessionByVRMenuSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_VRMenuID" PropertyName="SelectedValue" Name="VRMenuID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_VRSessionID" PropertyName="SelectedValue" Name="VRSessionID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwVRSessionByVRMenu" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_VRMenuID" />
    <asp:AsyncPostBackTrigger ControlID="F_VRSessionID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
