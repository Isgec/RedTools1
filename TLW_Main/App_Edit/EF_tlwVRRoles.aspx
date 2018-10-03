<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_tlwVRRoles.aspx.vb" Inherits="EF_tlwVRRoles" title="Edit: Roles" %>
<asp:Content ID="CPHtlwVRRoles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRRoles" runat="server" Text="&nbsp;Edit: Roles"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRRoles" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRRoles"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "tlwVRRoles"
    runat = "server" />
<asp:FormView ID="FVtlwVRRoles"
  runat = "server"
  DataKeyNames = "VRRoleID"
  DataSourceID = "ODStlwVRRoles"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_VRRoleID" runat="server" ForeColor="#CC6633" Text="VRRoleID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_VRRoleID"
            Text='<%# Bind("VRRoleID") %>'
            ToolTip="Value of VRRoleID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRRoles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRRoles"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VRRoleType" runat="server" Text="VRRoleType :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VRRoleType"
            Text='<%# Bind("VRRoleType") %>'
            Width="7px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRRoles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for VRRoleType."
            MaxLength="1"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVVRRoleType"
            runat = "server"
            ControlToValidate = "F_VRRoleType"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRRoles"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DefaultRole" runat="server" Text="DefaultRole :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DefaultRole"
            Checked='<%# Bind("DefaultRole") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwVRRoles"
  DataObjectTypeName = "SIS.TLW.tlwVRRoles"
  SelectMethod = "tlwVRRolesGetByID"
  UpdateMethod="UZ_tlwVRRolesUpdate"
  DeleteMethod="UZ_tlwVRRolesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRRoles"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="VRRoleID" Name="VRRoleID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
