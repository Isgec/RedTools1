<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_tlwApplications.aspx.vb" Inherits="AF_tlwApplications" title="Add: Applications" %>
<asp:Content ID="CPHtlwApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwApplications" runat="server" Text="&nbsp;Add: Applications"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwApplications" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwApplications"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "tlwApplications"
    runat = "server" />
<asp:FormView ID="FVtlwApplications"
  runat = "server"
  DataKeyNames = "ApplicationID"
  DataSourceID = "ODStlwApplications"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtlwApplications" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ApplicationID" ForeColor="#CC6633" runat="server" Text="ApplicationID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ApplicationID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for WebPath."
            MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStlwApplications"
  DataObjectTypeName = "SIS.TLW.tlwApplications"
  InsertMethod="UZ_tlwApplicationsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwApplications"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
