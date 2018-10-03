Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  <DataObject()> _
  Partial Public Class tlwVRSessions
    Private Shared _RecordCount As Integer
    Private _VRSessionID As Int32 = 0
    Private _FileName As String = ""
    Private _Description As String = ""
    Private _FolderLocation As String = ""
    Private _VRMenuName As String = ""
    Private _ToolTip As String = ""
    Private _VRSessionType As String = ""
    Private _CSSClass As String = ""
    Private _ApplicationID As Int32 = 0
    Private _MaintainGrid As Boolean = False
    Private _InsertForm As Boolean = False
    Private _UpdateForm As Boolean = False
    Private _DisplayGrid As Boolean = False
    Private _DisplayForm As Boolean = False
    Private _DeleteOption As Boolean = False
    Private _SYS_Applications1_Description As String = ""
    Private _FK_SYS_VRSessions_SYS_Applications As SIS.TLW.tlwApplications = Nothing
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
    Public Property VRSessionID() As Int32
      Get
        Return _VRSessionID
      End Get
      Set(ByVal value As Int32)
        _VRSessionID = value
      End Set
    End Property
    Public Property FileName() As String
      Get
        Return _FileName
      End Get
      Set(ByVal value As String)
        _FileName = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property FolderLocation() As String
      Get
        Return _FolderLocation
      End Get
      Set(ByVal value As String)
        _FolderLocation = value
      End Set
    End Property
    Public Property VRMenuName() As String
      Get
        Return _VRMenuName
      End Get
      Set(ByVal value As String)
        _VRMenuName = value
      End Set
    End Property
    Public Property ToolTip() As String
      Get
        Return _ToolTip
      End Get
      Set(ByVal value As String)
        _ToolTip = value
      End Set
    End Property
    Public Property VRSessionType() As String
      Get
        Return _VRSessionType
      End Get
      Set(ByVal value As String)
        _VRSessionType = value
      End Set
    End Property
    Public Property CSSClass() As String
      Get
        Return _CSSClass
      End Get
      Set(ByVal value As String)
        _CSSClass = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(500, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _VRSessionID
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
    Public Class PKtlwVRSessions
      Private _VRSessionID As Int32 = 0
      Public Property VRSessionID() As Int32
        Get
          Return _VRSessionID
        End Get
        Set(ByVal value As Int32)
          _VRSessionID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_SYS_VRSessions_SYS_Applications() As SIS.TLW.tlwApplications
      Get
        If _FK_SYS_VRSessions_SYS_Applications Is Nothing Then
          _FK_SYS_VRSessions_SYS_Applications = SIS.TLW.tlwApplications.tlwApplicationsGetByID(_ApplicationID)
        End If
        Return _FK_SYS_VRSessions_SYS_Applications
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionsSelectList(ByVal OrderBy As String) As List(Of SIS.TLW.tlwVRSessions)
      Dim Results As List(Of SIS.TLW.tlwVRSessions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRSessions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRSessions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionsGetNewRecord() As SIS.TLW.tlwVRSessions
      Return New SIS.TLW.tlwVRSessions()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionsGetByID(ByVal VRSessionID As Int32) As SIS.TLW.tlwVRSessions
      Dim Results As SIS.TLW.tlwVRSessions = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRSessionID",SqlDbType.Int,VRSessionID.ToString.Length, VRSessionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TLW.tlwVRSessions(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByFileName(ByVal FileName As String, ByVal OrderBy as String) As List(Of SIS.TLW.tlwVRSessions)
      Dim Results As List(Of SIS.TLW.tlwVRSessions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionsSelectByFileName"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,FileName.ToString.Length, FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRSessions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRSessions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TLW.tlwVRSessions)
      Dim Results As List(Of SIS.TLW.tlwVRSessions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlwVRSessionsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlwVRSessionsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRSessions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRSessions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tlwVRSessionsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tlwVRSessionsInsert(ByVal Record As SIS.TLW.tlwVRSessions) As SIS.TLW.tlwVRSessions
      Dim _Rec As SIS.TLW.tlwVRSessions = SIS.TLW.tlwVRSessions.tlwVRSessionsGetNewRecord()
      With _Rec
        .FileName = Record.FileName
        .Description = Record.Description
        .FolderLocation = Record.FolderLocation
        .VRMenuName = Record.VRMenuName
        .ToolTip = Record.ToolTip
        .VRSessionType = Record.VRSessionType
        .CSSClass = Record.CSSClass
        .ApplicationID =  Global.System.Web.HttpContext.Current.Session("ApplicationID")
        .MaintainGrid = Record.MaintainGrid
        .InsertForm = Record.InsertForm
        .UpdateForm = Record.UpdateForm
        .DisplayGrid = Record.DisplayGrid
        .DisplayForm = Record.DisplayForm
        .DeleteOption = Record.DeleteOption
      End With
      Return SIS.TLW.tlwVRSessions.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TLW.tlwVRSessions) As SIS.TLW.tlwVRSessions
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,51, Record.FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,501, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderLocation",SqlDbType.NVarChar,251, Record.FolderLocation)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuName",SqlDbType.NVarChar,51, Record.VRMenuName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToolTip",SqlDbType.NVarChar,101, Record.ToolTip)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRSessionType",SqlDbType.NChar,2, Record.VRSessionType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CSSClass",SqlDbType.NVarChar,31, Record.CSSClass)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintainGrid",SqlDbType.Bit,3, Record.MaintainGrid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsertForm",SqlDbType.Bit,3, Record.InsertForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateForm",SqlDbType.Bit,3, Record.UpdateForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DisplayGrid",SqlDbType.Bit,3, Record.DisplayGrid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DisplayForm",SqlDbType.Bit,3, Record.DisplayForm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteOption",SqlDbType.Bit,3, Record.DeleteOption)
          Cmd.Parameters.Add("@Return_VRSessionID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_VRSessionID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.VRSessionID = Cmd.Parameters("@Return_VRSessionID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tlwVRSessionsUpdate(ByVal Record As SIS.TLW.tlwVRSessions) As SIS.TLW.tlwVRSessions
      Dim _Rec As SIS.TLW.tlwVRSessions = SIS.TLW.tlwVRSessions.tlwVRSessionsGetByID(Record.VRSessionID)
      With _Rec
        .FileName = Record.FileName
        .Description = Record.Description
        .FolderLocation = Record.FolderLocation
        .VRMenuName = Record.VRMenuName
        .ToolTip = Record.ToolTip
        .VRSessionType = Record.VRSessionType
        .CSSClass = Record.CSSClass
        .ApplicationID = Global.System.Web.HttpContext.Current.Session("ApplicationID")
        .MaintainGrid = Record.MaintainGrid
        .InsertForm = Record.InsertForm
        .UpdateForm = Record.UpdateForm
        .DisplayGrid = Record.DisplayGrid
        .DisplayForm = Record.DisplayForm
        .DeleteOption = Record.DeleteOption
      End With
      Return SIS.TLW.tlwVRSessions.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TLW.tlwVRSessions) As SIS.TLW.tlwVRSessions
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VRSessionID",SqlDbType.Int,11, Record.VRSessionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,51, Record.FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,501, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderLocation",SqlDbType.NVarChar,251, Record.FolderLocation)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuName",SqlDbType.NVarChar,51, Record.VRMenuName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToolTip",SqlDbType.NVarChar,101, Record.ToolTip)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRSessionType",SqlDbType.NChar,2, Record.VRSessionType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CSSClass",SqlDbType.NVarChar,31, Record.CSSClass)
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
    Public Shared Function tlwVRSessionsDelete(ByVal Record As SIS.TLW.tlwVRSessions) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VRSessionID",SqlDbType.Int,Record.VRSessionID.ToString.Length, Record.VRSessionID)
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
'    Autocomplete Method
    Public Shared Function SelecttlwVRSessionsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(500, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TLW.tlwVRSessions = New SIS.TLW.tlwVRSessions(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
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
