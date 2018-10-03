<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_tlwApplications.aspx.vb" Inherits="EF_tlwApplications" title="Edit: Applications" %>
<asp:Content ID="CPHtlwApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwApplications" runat="server" Text="&nbsp;Edit: Applications"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwApplications" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwApplications"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "tlwApplications"
    runat = "server" />
<asp:FormView ID="FVtlwApplications"
  runat = "server"
  DataKeyNames = "ApplicationID"
  DataSourceID = "ODStlwApplications"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ApplicationID" runat="server" ForeColor="#CC6633" Text="ApplicationID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ApplicationID"
            Text='<%# Bind("ApplicationID") %>'
            ToolTip="Value of ApplicationID."
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
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwApplications"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WebPath" runat="server" Text="WebPath :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_WebPath"
            Text='<%# Bind("WebPath") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for WebPath."
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVWebPath"
            runat = "server"
            ControlToValidate = "F_WebPath"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwApplications"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GenerateDefaults" runat="server" Text="GenerateDefaults :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_GenerateDefaults"
            Checked='<%# Bind("GenerateDefaults") %>'
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
  ID = "ODStlwApplications"
  DataObjectTypeName = "SIS.TLW.tlwApplications"
  SelectMethod = "tlwApplicationsGetByID"
  UpdateMethod="UZ_tlwApplicationsUpdate"
  DeleteMethod="UZ_tlwApplicationsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwApplications"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplicationID" Name="ApplicationID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
