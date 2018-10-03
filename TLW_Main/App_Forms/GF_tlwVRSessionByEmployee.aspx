<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwVRSessionByEmployee.aspx.vb" Inherits="GF_tlwVRSessionByEmployee" title="Maintain List: Sessions By Employee" %>
<asp:Content ID="CPHtlwVRSessionByEmployee" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwVRSessionByEmployee" runat="server" Text="&nbsp;List: Sessions By Employee"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRSessionByEmployee" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwVRSessionByEmployee"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwVRSessionByEmployee.aspx"
      AddUrl = "~/TLW_Main/App_Create/AF_tlwVRSessionByEmployee.aspx"
      ValidationGroup = "tlwVRSessionByEmployee"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwVRSessionByEmployee" runat="server" AssociatedUpdatePanelID="UPNLtlwVRSessionByEmployee" DisplayAfter="100">
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
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UserName" runat="server" Text="UserName :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserName"
            CssClass = "myfktxt"
            Width="140px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_UserName(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UserName_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserName"
            BehaviorID="B_ACEUserName"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserNameCompletionList"
            TargetControlID="F_UserName"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEUserName_Selected"
            OnClientPopulating="ACEUserName_Populating"
            OnClientPopulated="ACEUserName_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVtlwVRSessionByEmployee" SkinID="gv_silver" runat="server" DataSourceID="ODStlwVRSessionByEmployee" DataKeyNames="RecordID">
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
        <asp:TemplateField HeaderText="VRSessionID" SortExpression="SYS_VRSessions2_Description">
          <ItemTemplate>
             <asp:Label ID="L_VRSessionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VRSessionID") %>' Text='<%# Eval("SYS_VRSessions2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserName" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_UserName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserName") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
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
      ID = "ODStlwVRSessionByEmployee"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwVRSessionByEmployee"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tlwVRSessionByEmployeeSelectList"
      TypeName = "SIS.TLW.tlwVRSessionByEmployee"
      SelectCountMethod = "tlwVRSessionByEmployeeSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_VRSessionID" PropertyName="SelectedValue" Name="VRSessionID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_UserName" PropertyName="Text" Name="UserName" Type="String" Size="20" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwVRSessionByEmployee" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_VRSessionID" />
    <asp:AsyncPostBackTrigger ControlID="F_UserName" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
