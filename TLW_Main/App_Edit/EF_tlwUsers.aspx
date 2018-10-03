<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_tlwUsers.aspx.vb" Inherits="EF_tlwUsers" title="Edit: Web User" %>
<asp:Content ID="CPHtlwUsers" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltlwUsers" runat="server" Text="&nbsp;Edit: Web User"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtlwUsers" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtlwUsers"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "tlwUsers"
    runat = "server" />
<asp:FormView ID="FVtlwUsers"
  runat = "server"
  DataKeyNames = "LoginID"
  DataSourceID = "ODStlwUsers"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LoginID" runat="server" ForeColor="#CC6633" Text="LoginID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_LoginID"
            Text='<%# Bind("LoginID") %>'
            ToolTip="Value of LoginID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="56px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserFullName" runat="server" Text="UserFullName :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_UserFullName"
            Text='<%# Bind("UserFullName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="tlwUsers"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for UserFullName."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserFullName"
            runat = "server"
            ControlToValidate = "F_UserFullName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "tlwUsers"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ExtnNo" runat="server" Text="ExtnNo :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ExtnNo"
            Text='<%# Bind("ExtnNo") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ExtnNo."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MobileNo" runat="server" Text="MobileNo :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MobileNo"
            Text='<%# Bind("MobileNo") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for MobileNo."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EMailID" runat="server" Text="EMailID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_EMailID"
            Text='<%# Bind("EMailID") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for EMailID."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DateOfJoining" runat="server" Text="C_DateOfJoining :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_C_DateOfJoining"
            Text='<%# Bind("C_DateOfJoining") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonC_DateOfJoining" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEC_DateOfJoining"
            TargetControlID="F_C_DateOfJoining"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonC_DateOfJoining" />
          <AJX:MaskedEditExtender 
            ID = "MEEC_DateOfJoining"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_C_DateOfJoining" />
          <AJX:MaskedEditValidator 
            ID = "MEVC_DateOfJoining"
            runat = "server"
            ControlToValidate = "F_C_DateOfJoining"
            ControlExtender = "MEEC_DateOfJoining"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_C_CompanyID" runat="server" Text="C_CompanyID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_tlwCompanies
            ID="F_C_CompanyID"
            SelectedValue='<%# Bind("C_CompanyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DivisionID" runat="server" Text="C_DivisionID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_tlwDivisions
            ID="F_C_DivisionID"
            SelectedValue='<%# Bind("C_DivisionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_C_OfficeID" runat="server" Text="C_OfficeID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_tlwOffices
            ID="F_C_OfficeID"
            SelectedValue='<%# Bind("C_OfficeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_C_DepartmentID" runat="server" Text="C_DepartmentID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_tlwDepartments
            ID="F_C_DepartmentID"
            SelectedValue='<%# Bind("C_DepartmentID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_C_DesignationID" runat="server" Text="C_DesignationID :" />&nbsp;
        </td>
        <td>
          <LGM:LC_tlwDesignations
            ID="F_C_DesignationID"
            SelectedValue='<%# Bind("C_DesignationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ActiveState" runat="server" Text="ActiveState :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ActiveState"
            Checked='<%# Bind("ActiveState") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Contractual" runat="server" Text="Contractual :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Contractual"
            Checked='<%# Bind("Contractual") %>'
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
  ID = "ODStlwUsers"
  DataObjectTypeName = "SIS.TLW.tlwUsers"
  SelectMethod = "tlwUsersGetByID"
  UpdateMethod="UZ_tlwUsersUpdate"
  DeleteMethod="UZ_tlwUsersDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TLW.tlwUsers"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="LoginID" Name="LoginID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
