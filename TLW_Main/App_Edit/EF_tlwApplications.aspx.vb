Partial Class EF_tlwApplications
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
  Protected Sub ODStlwApplications_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwApplications.Selected
    Dim tmp As SIS.TLW.tlwApplications = CType(e.ReturnValue, SIS.TLW.tlwApplications)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwApplications.Init
    DataClassName = "EtlwApplications"
    SetFormView = FVtlwApplications
  End Sub
  Protected Sub TBLtlwApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwApplications.Init
    SetToolBar = TBLtlwApplications
  End Sub
  Protected Sub FVtlwApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwApplications.PreRender
    TBLtlwApplications.EnableSave = Editable
    TBLtlwApplications.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwApplications", mStr)
    End If
  End Sub

End Class
