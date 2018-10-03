Partial Class EF_tlwVRRoleByEmployee
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODStlwVRRoleByEmployee_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwVRRoleByEmployee.Selected
    Dim tmp As SIS.TLW.tlwVRRoleByEmployee = CType(e.ReturnValue, SIS.TLW.tlwVRRoleByEmployee)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwVRRoleByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoleByEmployee.Init
    DataClassName = "EtlwVRRoleByEmployee"
    SetFormView = FVtlwVRRoleByEmployee
  End Sub
  Protected Sub TBLtlwVRRoleByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRRoleByEmployee.Init
    SetToolBar = TBLtlwVRRoleByEmployee
  End Sub
  Protected Sub FVtlwVRRoleByEmployee_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoleByEmployee.PreRender
    TBLtlwVRRoleByEmployee.EnableSave = Editable
    TBLtlwVRRoleByEmployee.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwVRRoleByEmployee.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRRoleByEmployee") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRRoleByEmployee", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserNameCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TLW.tlwUsers.SelecttlwUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_SYS_VRRoleByEmployee_UserName(ByVal value As String) As String
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
