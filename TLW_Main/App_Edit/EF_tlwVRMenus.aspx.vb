Partial Class EF_tlwVRMenus
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
  Protected Sub ODStlwVRMenus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwVRMenus.Selected
    Dim tmp As SIS.TLW.tlwVRMenus = CType(e.ReturnValue, SIS.TLW.tlwVRMenus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwVRMenus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenus.Init
    DataClassName = "EtlwVRMenus"
    SetFormView = FVtlwVRMenus
  End Sub
  Protected Sub TBLtlwVRMenus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRMenus.Init
    SetToolBar = TBLtlwVRMenus
  End Sub
  Protected Sub FVtlwVRMenus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenus.PreRender
    TBLtlwVRMenus.EnableSave = Editable
    TBLtlwVRMenus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwVRMenus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRMenus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRMenus", mStr)
    End If
  End Sub

End Class
