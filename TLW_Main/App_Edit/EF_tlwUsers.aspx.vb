Partial Class EF_tlwUsers
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
  Protected Sub ODStlwUsers_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwUsers.Selected
    Dim tmp As SIS.TLW.tlwUsers = CType(e.ReturnValue, SIS.TLW.tlwUsers)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwUsers.Init
    DataClassName = "EtlwUsers"
    SetFormView = FVtlwUsers
  End Sub
  Protected Sub TBLtlwUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwUsers.Init
    SetToolBar = TBLtlwUsers
  End Sub
  Protected Sub FVtlwUsers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwUsers.PreRender
    TBLtlwUsers.EnableSave = Editable
    TBLtlwUsers.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwUsers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwUsers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwUsers", mStr)
    End If
  End Sub

End Class
