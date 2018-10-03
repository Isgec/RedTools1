<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_tlwVRRoleByEmployee.aspx.vb" Inherits="EF_tlwVRRoleByEmployee" title="Edit: Roles By Employee" %>
<asp:Content ID="CPHtlwVRRoleByEmployee" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRRoleByEmployee" runat="server" Text="&nbsp;Edit: Roles By Employee"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRRoleByEmployee" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRRoleByEmployee"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "tlwVRRoleByEmployee"
    runat = "server" />
<asp:FormView ID="FVtlwVRRoleByEmployee"
  runat = "server"
  DataKeyNames = "RecordID"
  DataSourceID = "ODStlwVRRoleByEmployee"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecordID" runat="server" ForeColor="#CC6633" Text="RecordID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_RecordID"
            Text='<%# Bind("RecordID") %>'
            ToolTip="Value of RecordID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VRRoleID" runat="server" Text="VRRoleID :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_tlwVRRoles
            ID="F_VRRoleID"
            SelectedValue='<%# Bind("VRRoleID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "tlwVRRoleByEmployee"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserName" runat="server" Text="UserName :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserName"
            CssClass = "myfktxt"
            Text='<%# Bind("UserName") %>'
            AutoCompleteType = "None"
            Width="140px"
            onfocus = "return this.select();"
            ToolTip="Enter value for UserName."
            ValidationGroup = "tlwVRRoleByEmployee"
            onblur= "script_tlwVRRoleByEmployee.validate_UserName(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserName"
            runat = "server"
            ControlToValidate = "F_UserName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRRoleByEmployee"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_UserName_Display"
            Text='<%# Eval("aspnet_Users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserName"
            BehaviorID="B_ACEUserName"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserNameCompletionList"
            TargetControlID="F_UserName"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_tlwVRRoleByEmployee.ACEUserName_Selected"
            OnClientPopulating="script_tlwVRRoleByEmployee.ACEUserName_Populating"
            OnClientPopulated="script_tlwVRRoleByEmployee.ACEUserName_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwVRRoleByEmployee"
  DataObjectTypeName = "SIS.TLW.tlwVRRoleByEmployee"
  SelectMethod = "tlwVRRoleByEmployeeGetByID"
  UpdateMethod="UZ_tlwVRRoleByEmployeeUpdate"
  DeleteMethod="UZ_tlwVRRoleByEmployeeDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRRoleByEmployee"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecordID" Name="RecordID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
