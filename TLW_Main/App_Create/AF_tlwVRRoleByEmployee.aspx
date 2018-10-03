<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_tlwVRRoleByEmployee.aspx.vb" Inherits="AF_tlwVRRoleByEmployee" title="Add: Roles By Employee" %>
<asp:Content ID="CPHtlwVRRoleByEmployee" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRRoleByEmployee" runat="server" Text="&nbsp;Add: Roles By Employee"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRRoleByEmployee" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRRoleByEmployee"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "tlwVRRoleByEmployee"
    runat = "server" />
<asp:FormView ID="FVtlwVRRoleByEmployee"
  runat = "server"
  DataKeyNames = "RecordID"
  DataSourceID = "ODStlwVRRoleByEmployee"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtlwVRRoleByEmployee" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecordID" ForeColor="#CC6633" runat="server" Text="RecordID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_RecordID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
            Width="140px"
            Text='<%# Bind("UserName") %>'
            AutoCompleteType = "None"
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
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwVRRoleByEmployee"
  DataObjectTypeName = "SIS.TLW.tlwVRRoleByEmployee"
  InsertMethod="UZ_tlwVRRoleByEmployeeInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRRoleByEmployee"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
