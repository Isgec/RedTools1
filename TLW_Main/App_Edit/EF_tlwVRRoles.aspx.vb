Partial Class EF_tlwVRRoles
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
  Protected Sub ODStlwVRRoles_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwVRRoles.Selected
    Dim tmp As SIS.TLW.tlwVRRoles = CType(e.ReturnValue, SIS.TLW.tlwVRRoles)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwVRRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoles.Init
    DataClassName = "EtlwVRRoles"
    SetFormView = FVtlwVRRoles
  End Sub
  Protected Sub TBLtlwVRRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRRoles.Init
    SetToolBar = TBLtlwVRRoles
  End Sub
  Protected Sub FVtlwVRRoles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRRoles.PreRender
    TBLtlwVRRoles.EnableSave = Editable
    TBLtlwVRRoles.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwVRRoles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRRoles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRRoles", mStr)
    End If
  End Sub

End Class
