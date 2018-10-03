<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_tlwVRSessions.aspx.vb" Inherits="AF_tlwVRSessions" title="Add: Sessions" %>
<asp:Content ID="CPHtlwVRSessions" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwVRSessions" runat="server" Text="&nbsp;Add: Sessions"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwVRSessions" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwVRSessions"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "tlwVRSessions"
    runat = "server" />
<asp:FormView ID="FVtlwVRSessions"
  runat = "server"
  DataKeyNames = "VRSessionID"
  DataSourceID = "ODStlwVRSessions"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtlwVRSessions" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_VRSessionID" ForeColor="#CC6633" runat="server" Text="VRSessionID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_VRSessionID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FileName" runat="server" Text="FileName :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRSessions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for FileName."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFileName"
            runat = "server"
            ControlToValidate = "F_FileName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRSessions"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRSessions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRSessions"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FolderLocation" runat="server" Text="FolderLocation :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_FolderLocation"
            Text='<%# Bind("FolderLocation") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRSessions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for FolderLocation."
            MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFolderLocation"
            runat = "server"
            ControlToValidate = "F_FolderLocation"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRSessions"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VRMenuName" runat="server" Text="VRMenuName :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VRMenuName"
            Text='<%# Bind("VRMenuName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRSessions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for VRMenuName."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVVRMenuName"
            runat = "server"
            ControlToValidate = "F_VRMenuName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRSessions"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ToolTip" runat="server" Text="ToolTip :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ToolTip"
            Text='<%# Bind("ToolTip") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRSessions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ToolTip."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVToolTip"
            runat = "server"
            ControlToValidate = "F_ToolTip"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRSessions"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VRSessionType" runat="server" Text="VRSessionType :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VRSessionType"
            Text='<%# Bind("VRSessionType") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRSessions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for VRSessionType."
            MaxLength="1"
            Width="7px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVVRSessionType"
            runat = "server"
            ControlToValidate = "F_VRSessionType"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRSessions"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CSSClass" runat="server" Text="CSSClass :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CSSClass"
            Text='<%# Bind("CSSClass") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwVRSessions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CSSClass."
            MaxLength="30"
            Width="210px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCSSClass"
            runat = "server"
            ControlToValidate = "F_CSSClass"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwVRSessions"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaintainGrid" runat="server" Text="MaintainGrid :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_MaintainGrid"
           Checked='<%# Bind("MaintainGrid") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InsertForm" runat="server" Text="InsertForm :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_InsertForm"
           Checked='<%# Bind("InsertForm") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UpdateForm" runat="server" Text="UpdateForm :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_UpdateForm"
           Checked='<%# Bind("UpdateForm") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DisplayGrid" runat="server" Text="DisplayGrid :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DisplayGrid"
           Checked='<%# Bind("DisplayGrid") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DisplayForm" runat="server" Text="DisplayForm :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DisplayForm"
           Checked='<%# Bind("DisplayForm") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DeleteOption" runat="server" Text="DeleteOption :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DeleteOption"
           Checked='<%# Bind("DeleteOption") %>'
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
  ID = "ODStlwVRSessions"
  DataObjectTypeName = "SIS.TLW.tlwVRSessions"
  InsertMethod="UZ_tlwVRSessionsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwVRSessions"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
