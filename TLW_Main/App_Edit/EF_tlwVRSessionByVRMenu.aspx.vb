Partial Class EF_tlwVRSessionByVRMenu
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
  Protected Sub ODStlwVRSessionByVRMenu_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStlwVRSessionByVRMenu.Selected
    Dim tmp As SIS.TLW.tlwVRSessionByVRMenu = CType(e.ReturnValue, SIS.TLW.tlwVRSessionByVRMenu)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtlwVRSessionByVRMenu_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByVRMenu.Init
    DataClassName = "EtlwVRSessionByVRMenu"
    SetFormView = FVtlwVRSessionByVRMenu
  End Sub
  Protected Sub TBLtlwVRSessionByVRMenu_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtlwVRSessionByVRMenu.Init
    SetToolBar = TBLtlwVRSessionByVRMenu
  End Sub
  Protected Sub FVtlwVRSessionByVRMenu_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtlwVRSessionByVRMenu.PreRender
    TBLtlwVRSessionByVRMenu.EnableSave = Editable
    TBLtlwVRSessionByVRMenu.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TLW_Main/App_Edit") & "/EF_tlwVRSessionByVRMenu.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttlwVRSessionByVRMenu") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttlwVRSessionByVRMenu", mStr)
    End If
  End Sub

End Class
