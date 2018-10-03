Partial Class EF_tlwLGPageSize
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
  Protected Sub ODStlwLGPageSize_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwLGPageSize.Selected
    Dim tmp As SIS.TLW.tlwLGPageSize = CType(e.ReturnValue, SIS.TLW.tlwLGPageSize)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwLGPageSize_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwLGPageSize.Init
    DataClassName = "EtlwLGPageSize"
    SetFormView = FVtlwLGPageSize
  End Sub
  Protected Sub TBLtlwLGPageSize_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwLGPageSize.Init
    SetToolBar = TBLtlwLGPageSize
  End Sub
  Protected Sub FVtlwLGPageSize_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwLGPageSize.PreRender
    TBLtlwLGPageSize.EnableSave = Editable
    TBLtlwLGPageSize.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwLGPageSize.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwLGPageSize") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwLGPageSize", mStr)
    End If
  End Sub

End Class
