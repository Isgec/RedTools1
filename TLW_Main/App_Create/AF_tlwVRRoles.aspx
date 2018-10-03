<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_tlwVRRoles.aspx.vb" Inherits="AF_tlwVRRoles" title="Add: Roles" %>
<asp:Content ID="CPHtlwVRRoles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRRoles" runat="server" Text="&nbsp;Add: Roles"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRRoles" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRRoles"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "tlwVRRoles"
    runat = "server" />
<asp:FormView ID="FVtlwVRRoles"
  runat = "server"
  DataKeyNames = "VRRoleID"
  DataSourceID = "ODStlwVRRoles"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtlwVRRoles" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_VRRoleID" ForeColor="#CC6633" runat="server" Text="VRRoleID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_VRRoleID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRRoles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="350px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRRoles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for VRRoleType."
            MaxLength="1"
            Width="7px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwVRRoles"
  DataObjectTypeName = "SIS.TLW.tlwVRRoles"
  InsertMethod="UZ_tlwVRRolesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRRoles"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
