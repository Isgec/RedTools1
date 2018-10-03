Partial Class EF_tlwVRSessionByEmployee
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
  Protected Sub ODStlwVRSessionByEmployee_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwVRSessionByEmployee.Selected
    Dim tmp As SIS.TLW.tlwVRSessionByEmployee = CType(e.ReturnValue, SIS.TLW.tlwVRSessionByEmployee)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwVRSessionByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByEmployee.Init
    DataClassName = "EtlwVRSessionByEmployee"
    SetFormView = FVtlwVRSessionByEmployee
  End Sub
  Protected Sub TBLtlwVRSessionByEmployee_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessionByEmployee.Init
    SetToolBar = TBLtlwVRSessionByEmployee
  End Sub
  Protected Sub FVtlwVRSessionByEmployee_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByEmployee.PreRender
    TBLtlwVRSessionByEmployee.EnableSave = Editable
    TBLtlwVRSessionByEmployee.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwVRSessionByEmployee.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRSessionByEmployee") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRSessionByEmployee", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserNameCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TLW.tlwUsers.SelecttlwUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
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
