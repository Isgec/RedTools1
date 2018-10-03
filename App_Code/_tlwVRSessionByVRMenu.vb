Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  <DataObject()> _
  Partial Public Class tlwVRSessionByVRMenu
    Private Shared _RecordCount As Integer
    Private _RecordID As Int32 = 0
    Private _VRMenuID As Int32 = 0
    Private _VRSessionID As Int32 = 0
    Private _Sequence As Int32 = 0
    Private _ApplicationID As Int32 = 0
    Private _MaintainGrid As Boolean = False
    Private _InsertForm As Boolean = False
    Private _UpdateForm As Boolean = False
    Private _DisplayGrid As Boolean = False
    Private _DisplayForm As Boolean = False
    Private _DeleteOption As Boolean = False
    Private _SYS_Applications1_Description As String = ""
    Private _SYS_VRMenus2_VRMenuName As String = ""
    Private _SYS_VRSessions3_Description As String = ""
    Private _FK_SYS_VRSessionByVRMenu_SYS_Applications As SIS.TLW.tlwApplications = Nothing
    Private _FK_SYS_SessionsByMenu_SYS_Menu As SIS.TLW.tlwVRMenus = Nothing
    Private _FK_SYS_SessionsByMenu_SYS_SessionMaster As SIS.TLW.tlwVRSessions = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property RecordID() As Int32
      Get
        Return _RecordID
      End Get
      Set(ByVal value As Int32)
        _RecordID = value
      End Set
    End Property
    Public Property VRMenuID() As Int32
      Get
        Return _VRMenuID
      End Get
      Set(ByVal value As Int32)
        _VRMenuID = value
      End Set
    End Property
    Public Property VRSessionID() As Int32
      Get
        Return _VRSessionID
      End Get
      Set(ByVal value As Int32)
        _VRSessionID = value
      End Set
    End Property
    Public Property Sequence() As Int32
      Get
        Return _Sequence
      End Get
      Set(ByVal value As Int32)
        _Sequence = value
      End Set
    End Property
    Public Property ApplicationID() As Int32
      Get
        Return _ApplicationID
      End Get
      Set(ByVal value As Int32)
        _ApplicationID = value
      End Set
    End Property
    Public Property MaintainGrid() As Boolean
      Get
        Return _MaintainGrid
      End Get
      Set(ByVal value As Boolean)
        _MaintainGrid = value
      End Set
    End Property
    Public Property InsertForm() As Boolean
      Get
        Return _InsertForm
      End Get
      Set(ByVal value As Boolean)
        _InsertForm = value
      End Set
    End Property
    Public Property UpdateForm() As Boolean
      Get
        Return _UpdateForm
      End Get
      Set(ByVal value As Boolean)
        _UpdateForm = value
      End Set
    End Property
    Public Property DisplayGrid() As Boolean
      Get
        Return _DisplayGrid
      End Get
      Set(ByVal value As Boolean)
        _DisplayGrid = value
      End Set
    End Property
    Public Property DisplayForm() As Boolean
      Get
        Return _DisplayForm
      End Get
      Set(ByVal value As Boolean)
        _DisplayForm = value
      End Set
    End Property
    Public Property DeleteOption() As Boolean
      Get
        Return _DeleteOption
      End Get
      Set(ByVal value As Boolean)
        _DeleteOption = value
      End Set
    End Property
    Public Property SYS_Applications1_Description() As String
      Get
        Return _SYS_Applications1_Description
      End Get
      Set(ByVal value As String)
        _SYS_Applications1_Description = value
      End Set
    End Property
    Public Property SYS_VRMenus2_VRMenuName() As String
      Get
        Return _SYS_VRMenus2_VRMenuName
      End Get
      Set(ByVal value As String)
        _SYS_VRMenus2_VRMenuName = value
      End Set
    End Property
    Public Property SYS_VRSessions3_Description() As String
      Get
        Return _SYS_VRSessions3_Description
      End Get
      Set(ByVal value As String)
        _SYS_VRSessions3_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RecordID
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKtlwVRSessionByVRMenu
      Private _RecordID As Int32 = 0
      Public Property RecordID() As Int32
        Get
          Return _RecordID
        End Get
        Set(ByVal value As Int32)
          _RecordID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_SYS_VRSessionByVRMenu_SYS_Applications() As SIS.TLW.tlwApplications
      Get
        If _FK_SYS_VRSessionByVRMenu_SYS_Applications Is Nothing Then
          _FK_SYS_VRSessionByVRMenu_SYS_Applications = SIS.TLW.tlwApplications.tlwApplicationsGetByID(_ApplicationID)
        End If
        Return _FK_SYS_VRSessionByVRMenu_SYS_Applications
      End Get
    End Property
    Public ReadOnly Property FK_SYS_SessionsByMenu_SYS_Menu() As SIS.TLW.tlwVRMenus
      Get
        If _FK_SYS_SessionsByMenu_SYS_Menu Is Nothing Then
          _FK_SYS_SessionsByMenu_SYS_Menu = SIS.TLW.tlwVRMenus.tlwVRMenusGetByID(_VRMenuID)
        End If
        Return _FK_SYS_SessionsByMenu_SYS_Menu
      End Get
    End Property
    Public ReadOnly Property FK_SYS_SessionsByMenu_SYS_SessionMaster() As SIS.TLW.tlwVRSessions
      Get
        If _FK_SYS_SessionsByMenu_SYS_SessionMaster Is Nothing Then
          _FK_SYS_SessionsByMenu_SYS_SessionMaster = SIS.TLW.tlwVRSessions.tlwVRSessionsGetByID(_VRSessionID)
        End If
        Return _FK_SYS_SessionsByMenu_SYS_SessionMaster
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionByVRMenuGetNewRecord() As SIS.TLW.tlwVRSessionByVRMenu
      Return New SIS.TLW.tlwVRSessionByVRMenu()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionByVRMenuGetByID(ByVal RecordID As Int32) As SIS.TLW.tlwVRSessionByVRMenu
      Dim Results As SIS.TLW.tlwVRSessionByVRMenu = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByVRMenuSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID",SqlDbType.Int,RecordID.ToString.Length, RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TLW.tlwVRSessionByVRMenu(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByVRMenuID(ByVal VRMenuID As Int32, ByVal OrderBy as String) As List(Of SIS.TLW.tlwVRSessionByVRMenu)
      Dim Results As List(Of SIS.TLW.tlwVRSessionByVRMenu) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByVRMenuSelectByVRMenuID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuID",SqlDbType.Int,VRMenuID.ToString.Length, VRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRSessionByVRMenu)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRSessionByVRMenu(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionByVRMenuSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRMenuID As Int32, ByVal VRSessionID As Int32) As List(Of SIS.TLW.tlwVRSessionByVRMenu)
      Dim Results As List(Of SIS.TLW.tlwVRSessionByVRMenu) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlwVRSessionByVRMenuSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlwVRSessionByVRMenuSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VRMenuID",SqlDbType.Int,10, IIf(VRMenuID = Nothing, 0,VRMenuID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VRSessionID",SqlDbType.Int,10, IIf(VRSessionID = Nothing, 0,VRSessionID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRSessionByVRMenu)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRSessionByVRMenu(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tlwVRSessionByVRMenuSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRMenuID As Int32, ByVal VRSessionID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionByVRMenuGetByID(ByVal RecordID As Int32, ByVal Filter_VRMenuID As Int32, ByVal Filter_VRSessionID As Int32) As SIS.TLW.tlwVRSessionByVRMenu
      Return tlwVRSessionByVRMenuGetByID(RecordID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tlwVRSessionByVRMenuInsert(ByVal Record As SIS.TLW.tlwVRSessionByVRMenu) As SIS.TLW.tlwVRSessionByVRMenu
      Dim _Rec As SIS.TLW.tlwVRSessionByVRMenu = SIS.TLW.tlwVRSessionByVRMenu.tlwVRSessionByVRMenuGetNewRecord()
      With _Rec
        .VRMenuID = Record.VRMenuID
        .VRSessionID = Record.VRSessionID
        .Sequence = Record.Sequence
        .ApplicationID =  Global.System.Web.HttpContext.Current.Session("ApplicationID")
        .MaintainGrid = Record.MaintainGrid
        .InsertForm = Record.InsertForm
        .UpdateForm = Record.UpdateForm
        .DisplayGrid = Record.DisplayGrid
        .DisplayForm = Record.DisplayForm
        .DeleteOption = Record.DeleteOption
      End With
      Return SIS.TLW.tlwVRSessionByVRMenu.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TLW.tlwVRSessionByVRMenu) As SIS.TLW.tlwVRSessionByVRMenu
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByVRMenuInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuID",SqlDbType.Int,11, Record.VRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRSessionID",SqlDbType.Int,11, Record.VRSessionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintainGrid",SqlDbType.Bit,3, Record.MaintainGrid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsertForm",SqlDbType.Bit,3, Record.InsertForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateForm",SqlDbType.Bit,3, Record.UpdateForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DisplayGrid",SqlDbType.Bit,3, Record.DisplayGrid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DisplayForm",SqlDbType.Bit,3, Record.DisplayForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteOption",SqlDbType.Bit,3, Record.DeleteOption)
          Cmd.Parameters.Add("@Return_RecordID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecordID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RecordID = Cmd.Parameters("@Return_RecordID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tlwVRSessionByVRMenuUpdate(ByVal Record As SIS.TLW.tlwVRSessionByVRMenu) As SIS.TLW.tlwVRSessionByVRMenu
      Dim _Rec As SIS.TLW.tlwVRSessionByVRMenu = SIS.TLW.tlwVRSessionByVRMenu.tlwVRSessionByVRMenuGetByID(Record.RecordID)
      With _Rec
        .VRMenuID = Record.VRMenuID
        .VRSessionID = Record.VRSessionID
        .Sequence = Record.Sequence
        .ApplicationID = Global.System.Web.HttpContext.Current.Session("ApplicationID")
        .MaintainGrid = Record.MaintainGrid
        .InsertForm = Record.InsertForm
        .UpdateForm = Record.UpdateForm
        .DisplayGrid = Record.DisplayGrid
        .DisplayForm = Record.DisplayForm
        .DeleteOption = Record.DeleteOption
      End With
      Return SIS.TLW.tlwVRSessionByVRMenu.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TLW.tlwVRSessionByVRMenu) As SIS.TLW.tlwVRSessionByVRMenu
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByVRMenuUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,11, Record.RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuID",SqlDbType.Int,11, Record.VRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRSessionID",SqlDbType.Int,11, Record.VRSessionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintainGrid",SqlDbType.Bit,3, Record.MaintainGrid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsertForm",SqlDbType.Bit,3, Record.InsertForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateForm",SqlDbType.Bit,3, Record.UpdateForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DisplayGrid",SqlDbType.Bit,3, Record.DisplayGrid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DisplayForm",SqlDbType.Bit,3, Record.DisplayForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteOption",SqlDbType.Bit,3, Record.DeleteOption)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function tlwVRSessionByVRMenuDelete(ByVal Record As SIS.TLW.tlwVRSessionByVRMenu) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByVRMenuDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,Record.RecordID.ToString.Length, Record.RecordID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
