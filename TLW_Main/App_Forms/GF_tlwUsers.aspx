<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_tlwUsers.aspx.vb" Inherits="GF_tlwUsers" title="Maintain List: Web User" %>
<asp:Content ID="CPHtlwUsers" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwUsers" runat="server" Text="&nbsp;List: Web User"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtlwUsers" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtlwUsers"
      ToolType = "lgNMGrid"
      EditUrl = "~/TLW_Main/App_Edit/EF_tlwUsers.aspx"
      AddUrl = "~/TLW_Main/App_Create/AF_tlwUsers.aspx"
      ValidationGroup = "tlwUsers"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStlwUsers" runat="server" AssociatedUpdatePanelID="UPNLtlwUsers" DisplayAfter="100">
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
          <b><asp:Label ID="L_C_CompanyID" runat="server" Text="C_CompanyID :" /></b>
        </td>
        <td>
          <LGM:LC_tlwCompanies
            ID="F_C_CompanyID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="CompanyID"
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
          <b><asp:Label ID="L_C_DivisionID" runat="server" Text="C_DivisionID :" /></b>
        </td>
        <td>
          <LGM:LC_tlwDivisions
            ID="F_C_DivisionID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DivisionID"
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
          <b><asp:Label ID="L_C_OfficeID" runat="server" Text="C_OfficeID :" /></b>
        </td>
        <td>
          <LGM:LC_tlwOffices
            ID="F_C_OfficeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="OfficeID"
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
          <b><asp:Label ID="L_C_DepartmentID" runat="server" Text="C_DepartmentID :" /></b>
        </td>
        <td>
          <LGM:LC_tlwDepartments
            ID="F_C_DepartmentID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DepartmentID"
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
          <b><asp:Label ID="L_C_DesignationID" runat="server" Text="C_DesignationID :" /></b>
        </td>
        <td>
          <LGM:LC_tlwDesignations
            ID="F_C_DesignationID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="DesignationID"
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
    <script type="text/javascript"> 
   var script_wp_user = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVtlwUsers" SkinID="gv_silver" runat="server" DataSourceID="ODStlwUsers" DataKeyNames="LoginID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="LoginID" SortExpression="LoginID">
          <ItemTemplate>
            <asp:Label ID="LabelLoginID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LoginID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserFullName" SortExpression="UserFullName">
          <ItemTemplate>
            <asp:Label ID="LabelUserFullName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C_DepartmentID" SortExpression="HRM_Departments3_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DepartmentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DepartmentID") %>' Text='<%# Eval("HRM_Departments3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C_DesignationID" SortExpression="HRM_Designations4_Description">
          <ItemTemplate>
             <asp:Label ID="L_C_DesignationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("C_DesignationID") %>' Text='<%# Eval("HRM_Designations4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ActiveState" SortExpression="ActiveState">
          <ItemTemplate>
            <asp:Label ID="LabelActiveState" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ActiveState") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="New PW" SortExpression="wp_user">
          <ItemTemplate>
          <asp:TextBox ID="F_wp_user"
            Text='<%# Bind("wp_user") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "ChangePW" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for wp_user."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVwp_user"
            runat = "server"
            ControlToValidate = "F_wp_user"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "ChangePW" & Container.DataItemIndex %>'
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ChangePW">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="ChangePW" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""ChangePW record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UnBlock">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="UnBlock" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""UnBlock record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Block">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Block" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Block record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStlwUsers"
      runat = "server"
      DataObjectTypeName = "SIS.TLW.tlwUsers"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_tlwUsersSelectList"
      TypeName = "SIS.TLW.tlwUsers"
      SelectCountMethod = "tlwUsersSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_C_CompanyID" PropertyName="SelectedValue" Name="C_CompanyID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_C_DivisionID" PropertyName="SelectedValue" Name="C_DivisionID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_C_OfficeID" PropertyName="SelectedValue" Name="C_OfficeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_C_DepartmentID" PropertyName="SelectedValue" Name="C_DepartmentID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_C_DesignationID" PropertyName="SelectedValue" Name="C_DesignationID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtlwUsers" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_C_CompanyID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DivisionID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_OfficeID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DepartmentID" />
    <asp:AsyncPostBackTrigger ControlID="F_C_DesignationID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
