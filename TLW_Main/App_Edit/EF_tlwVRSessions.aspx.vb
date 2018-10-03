Partial Class EF_tlwVRSessions
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
  Protected Sub ODStlwVRSessions_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwVRSessions.Selected
    Dim tmp As SIS.TLW.tlwVRSessions = CType(e.ReturnValue, SIS.TLW.tlwVRSessions)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwVRSessions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessions.Init
    DataClassName = "EtlwVRSessions"
    SetFormView = FVtlwVRSessions
  End Sub
  Protected Sub TBLtlwVRSessions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessions.Init
    SetToolBar = TBLtlwVRSessions
  End Sub
  Protected Sub FVtlwVRSessions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessions.PreRender
    TBLtlwVRSessions.EnableSave = Editable
    TBLtlwVRSessions.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwVRSessions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRSessions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRSessions", mStr)
    End If
  End Sub

End Class
