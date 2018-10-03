Partial Class EF_tlwVRMenuByVRRole
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
  Protected Sub ODStlwVRMenuByVRRole_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwVRMenuByVRRole.Selected
    Dim tmp As SIS.TLW.tlwVRMenuByVRRole = CType(e.ReturnValue, SIS.TLW.tlwVRMenuByVRRole)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwVRMenuByVRRole_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenuByVRRole.Init
    DataClassName = "EtlwVRMenuByVRRole"
    SetFormView = FVtlwVRMenuByVRRole
  End Sub
  Protected Sub TBLtlwVRMenuByVRRole_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRMenuByVRRole.Init
    SetToolBar = TBLtlwVRMenuByVRRole
  End Sub
  Protected Sub FVtlwVRMenuByVRRole_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRMenuByVRRole.PreRender
    TBLtlwVRMenuByVRRole.EnableSave = Editable
    TBLtlwVRMenuByVRRole.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwVRMenuByVRRole.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRMenuByVRRole") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRMenuByVRRole", mStr)
    End If
  End Sub

End Class
