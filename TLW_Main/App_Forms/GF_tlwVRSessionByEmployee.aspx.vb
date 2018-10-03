Partial Class GF_tlwVRSessionByEmployee
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TLW_Main/App_Display/DF_tlwVRSessionByEmployee.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RecordID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtlwVRSessionByEmployee_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtlwVRSessionByEmployee.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RecordID As Int32 = GVtlwVRSessionByEmployee.DataKeys(e.CommandArgument).Values("RecordID")  
        Dim RedirectUrl As String = TBLtlwVRSessionByEmployee.EditUrl & "?RecordID=" & RecordID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtlwVRSessionByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtlwVRSessionByEmployee.Init
    DataClassName = "GtlwVRSessionByEmployee"
    SetGridView = GVtlwVRSessionByEmployee
  End Sub
  Protected Sub TBLtlwVRSessionByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessionByEmployee.Init
    SetToolBar = TBLtlwVRSessionByEmployee
  End Sub
  Protected Sub F_VRSessionID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VRSessionID.SelectedIndexChanged
    Session("F_VRSessionID") = F_VRSessionID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_UserName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_UserName.TextChanged
    Session("F_UserName") = F_UserName.Text
    Session("F_UserName_Display") = F_UserName_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserNameCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TLW.tlwUsers.SelecttlwUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_VRSessionID.SelectedValue = String.Empty
    If Not Session("F_VRSessionID") Is Nothing Then
      If Session("F_VRSessionID") <> String.Empty Then
        F_VRSessionID.SelectedValue = Session("F_VRSessionID")
      End If
    End If
    F_UserName_Display.Text = String.Empty
    If Not Session("F_UserName_Display") Is Nothing Then
      If Session("F_UserName_Display") <> String.Empty Then
        F_UserName_Display.Text = Session("F_UserName_Display")
      End If
    End If
    F_UserName.Text = String.Empty
    If Not Session("F_UserName") Is Nothing Then
      If Session("F_UserName") <> String.Empty Then
        F_UserName.Text = Session("F_UserName")
      End If
    End If
    Dim strScriptUserName As String = "<script type=""text/javascript""> " & _
      "function ACEUserName_Selected(sender, e) {" & _
      "  var F_UserName = $get('" & F_UserName.ClientID & "');" & _
      "  var F_UserName_Display = $get('" & F_UserName_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_UserName.value = p[0];" & _
      "  F_UserName_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserName") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserName", strScriptUserName)
      End If
    Dim strScriptPopulatingUserName As String = "<script type=""text/javascript""> " & _
      "function ACEUserName_Populating(o,e) {" & _
      "  var p = $get('" & F_UserName.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEUserName_Populated(o,e) {" & _
      "  var p = $get('" & F_UserName.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserNamePopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserNamePopulating", strScriptPopulatingUserName)
      End If
    Dim validateScriptUserName As String = "<script type=""text/javascript"">" & _
      "  function validate_UserName(o) {" & _
      "    validated_FK_SYS_VRSessionByEmployee_UserName_main = true;" & _
      "    validate_FK_SYS_VRSessionByEmployee_UserName(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateUserName") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateUserName", validateScriptUserName)
    End If
    Dim validateScriptFK_SYS_VRSessionByEmployee_UserName As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_SYS_VRSessionByEmployee_UserName(o) {" & _
      "    var value = o.id;" & _
      "    var UserName = $get('" & F_UserName.ClientID & "');" & _
      "    try{" & _
      "    if(UserName.value==''){" & _
      "      if(validated_FK_SYS_VRSessionByEmployee_UserName.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + UserName.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_SYS_VRSessionByEmployee_UserName(value, validated_FK_SYS_VRSessionByEmployee_UserName);" & _
      "  }" & _
      "  validated_FK_SYS_VRSessionByEmployee_UserName_main = false;" & _
      "  function validated_FK_SYS_VRSessionByEmployee_UserName(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_SYS_VRSessionByEmployee_UserName") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_SYS_VRSessionByEmployee_UserName", validateScriptFK_SYS_VRSessionByEmployee_UserName)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_SYS_VRSessionByEmployee_UserName(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UserName As String = CType(aVal(1),String)
    Dim oVar As SIS.TLW.tlwUsers = SIS.TLW.tlwUsers.tlwUsersGetByID(UserName)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
