<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GT_GenerateUserAuthorization.aspx.vb" Inherits="GT_GenerateUserAuthorization" title="ISGEC: Generate User Authorization" %>
<asp:Content ID="CPHtlwVRSessions" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltlwVRSessions" runat="server" Text="&nbsp;Generate Authorization"></asp:Label>
</div>
<div class="pagedata">
	<asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" runat="server">
    <ContentTemplate>
    <LGM:ToolBar0 
      ID = "TBLtlwVRSessions"
      ToolType="lgNReport"
      runat = "server" />
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <table style="width: 520px; height: 60px; margin:auto">
        <tr>
          <td colspan="2" style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid;
            border-left: #0000ff 1pt solid; color: #000099; border-bottom: #0000ff 1pt solid;
            background-color: #ccccff; text-align: center">
            <strong>
              <br />
              GENERATE USER AUTHORIZATION<br />
            </strong></td>
        </tr>
        <tr>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
            <strong>
                From Card No.</strong></td>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
                <asp:TextBox ID="F_CardNo" runat="server" MaxLength="8" Width="70px" CssClass="mytxt">0340</asp:TextBox></td>
        </tr>
        <tr>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
            <strong>
                To Card No.</strong></td>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
                <asp:TextBox 
                  ID="T_CardNo" 
                  Text = "0340" 
                  runat="server" 
                  MaxLength="8" 
                  Width="70px" CssClass="mytxt"></asp:TextBox></td>
        </tr>
        <tr>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
            <strong>Add Default Role</strong></td>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
          <LGM:LC_tlwVRRoles
            ID="LC_VRRoles1"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="VRRoleID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            ValidationGroup="PrkEntitlements" 
            RequiredFieldErrorMessage = "*"
            Runat="Server" />
          </td>
        </tr>
        <tr>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
            [To give additional ROLE to User, Use Role By Employee Session]</td>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
            <br />
          <asp:Button 
            ID="CmdGenMenu" 
            runat="server" 
            Text="Create Role Authorization [Emp]" CssClass="mytxt" OnClientClick="return confirm('Create Role Authorization for employee ?')" /></td>
        </tr>
        <tr>
          <td colspan="2" style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid;
            border-left: #0000ff 1pt solid; color: #000099; border-bottom: #0000ff 1pt solid;
            background-color: #ccccff; text-align: center">
            <strong>
              <br />
              GENERATE STANDALONE USER AUTHORIZATION<br />
            </strong>
          </td>
        </tr>
        <tr>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
            Login ID</td>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
            <asp:TextBox ID="F_WebUser" runat="server" CssClass="mytxt" Width="70px">0340</asp:TextBox></td>
        </tr>
        <tr>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
          </td>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
            &nbsp; &nbsp;<asp:Button ID="cmdGenMenuOnly" runat="server" CssClass="mytxt"
              OnClientClick="return confirm('Generate Authorization ?')" Text="Create Role Authorization"
              ValidationGroup="PrkEntitlements" OnClick="cmdGenMenuOnly_Click" /></td>
        </tr>
        <tr>
          <td style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center" colspan="2">
          	<strong>
						<br />
						UPDATE USER INFORMATION FROM EMPLOYEE MASTER<br />
						</strong>&nbsp;&nbsp;</td>
        </tr>
      	<tr>
					<td colspan="2" style="border-right: #0000ff 1pt solid; border-top: #0000ff 1pt solid; border-left: #0000ff 1pt solid;
            color: #000099; border-bottom: #0000ff 1pt solid; background-color: #ccccff; text-align: center">
						<asp:Button ID="cmdUpdEmployeeInfo" runat="server" CssClass="mytxt" OnClientClick="return confirm('Update From Employee Master ?')" Text="Update From Employee Master" ValidationGroup="PrkEntitlements" />
					</td>
				</tr>
      </table>
    </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="CmdGenMenu" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="CmdGenMenuOnly" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>
</div>
</div>
</asp:Content>

