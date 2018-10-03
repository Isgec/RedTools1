Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  <DataObject()> _
  Partial Public Class tlwVRSessionByEmployee
    Private Shared _RecordCount As Integer
    Private _RecordID As Int32 = 0
    Private _VRSessionID As Int32 = 0
    Private _ApplicationID As Int32 = 0
    Private _UserName As String = ""
    Private _MaintainGrid As Boolean = False
    Private _InsertForm As Boolean = False
    Private _UpdateForm As Boolean = False
    Private _DisplayGrid As Boolean = False
    Private _DisplayForm As Boolean = False
    Private _DeleteOption As Boolean = False
    Private _SYS_Applications1_Description As String = ""
    Private _SYS_VRSessions2_Description As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _FK_SYS_VRSessionByEmployee_SYS_Applications As SIS.TLW.tlwApplications = Nothing
    Private _FK_SYS_SessionByEmployee_SYS_Sessions As SIS.TLW.tlwVRSessions = Nothing
    Private _FK_SYS_VRSessionByEmployee_UserName As SIS.TLW.tlwUsers = Nothing
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
    Public Property VRSessionID() As Int32
      Get
        Return _VRSessionID
      End Get
      Set(ByVal value As Int32)
        _VRSessionID = value
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
    Public Property UserName() As String
      Get
        Return _UserName
      End Get
      Set(ByVal value As String)
        _UserName = value
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
    Public Property SYS_VRSessions2_Description() As String
      Get
        Return _SYS_VRSessions2_Description
      End Get
      Set(ByVal value As String)
        _SYS_VRSessions2_Description = value
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
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
    Public Class PKtlwVRSessionByEmployee
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
    Public ReadOnly Property FK_SYS_VRSessionByEmployee_SYS_Applications() As SIS.TLW.tlwApplications
      Get
        If _FK_SYS_VRSessionByEmployee_SYS_Applications Is Nothing Then
          _FK_SYS_VRSessionByEmployee_SYS_Applications = SIS.TLW.tlwApplications.tlwApplicationsGetByID(_ApplicationID)
        End If
        Return _FK_SYS_VRSessionByEmployee_SYS_Applications
      End Get
    End Property
    Public ReadOnly Property FK_SYS_SessionByEmployee_SYS_Sessions() As SIS.TLW.tlwVRSessions
      Get
        If _FK_SYS_SessionByEmployee_SYS_Sessions Is Nothing Then
          _FK_SYS_SessionByEmployee_SYS_Sessions = SIS.TLW.tlwVRSessions.tlwVRSessionsGetByID(_VRSessionID)
        End If
        Return _FK_SYS_SessionByEmployee_SYS_Sessions
      End Get
    End Property
    Public ReadOnly Property FK_SYS_VRSessionByEmployee_UserName() As SIS.TLW.tlwUsers
      Get
        If _FK_SYS_VRSessionByEmployee_UserName Is Nothing Then
          _FK_SYS_VRSessionByEmployee_UserName = SIS.TLW.tlwUsers.tlwUsersGetByID(_UserName)
        End If
        Return _FK_SYS_VRSessionByEmployee_UserName
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionByEmployeeGetNewRecord() As SIS.TLW.tlwVRSessionByEmployee
      Return New SIS.TLW.tlwVRSessionByEmployee()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionByEmployeeGetByID(ByVal RecordID As Int32) As SIS.TLW.tlwVRSessionByEmployee
      Dim Results As SIS.TLW.tlwVRSessionByEmployee = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByEmployeeSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID",SqlDbType.Int,RecordID.ToString.Length, RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TLW.tlwVRSessionByEmployee(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionByEmployeeSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRSessionID As Int32, ByVal UserName As String) As List(Of SIS.TLW.tlwVRSessionByEmployee)
      Dim Results As List(Of SIS.TLW.tlwVRSessionByEmployee) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlwVRSessionByEmployeeSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlwVRSessionByEmployeeSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VRSessionID",SqlDbType.Int,10, IIf(VRSessionID = Nothing, 0,VRSessionID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserName",SqlDbType.NVarChar,20, IIf(UserName Is Nothing, String.Empty,UserName))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRSessionByEmployee)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRSessionByEmployee(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tlwVRSessionByEmployeeSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRSessionID As Int32, ByVal UserName As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRSessionByEmployeeGetByID(ByVal RecordID As Int32, ByVal Filter_VRSessionID As Int32, ByVal Filter_UserName As String) As SIS.TLW.tlwVRSessionByEmployee
      Return tlwVRSessionByEmployeeGetByID(RecordID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tlwVRSessionByEmployeeInsert(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As SIS.TLW.tlwVRSessionByEmployee
      Dim _Rec As SIS.TLW.tlwVRSessionByEmployee = SIS.TLW.tlwVRSessionByEmployee.tlwVRSessionByEmployeeGetNewRecord()
      With _Rec
        .VRSessionID = Record.VRSessionID
        .ApplicationID =  Global.System.Web.HttpContext.Current.Session("ApplicationID")
        .UserName = Record.UserName
        .MaintainGrid = Record.MaintainGrid
        .InsertForm = Record.InsertForm
        .UpdateForm = Record.UpdateForm
        .DisplayGrid = Record.DisplayGrid
        .DisplayForm = Record.DisplayForm
        .DeleteOption = Record.DeleteOption
      End With
      Return SIS.TLW.tlwVRSessionByEmployee.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As SIS.TLW.tlwVRSessionByEmployee
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByEmployeeInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRSessionID",SqlDbType.Int,11, Record.VRSessionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName",SqlDbType.NVarChar,21, Record.UserName)
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
    Public Shared Function tlwVRSessionByEmployeeUpdate(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As SIS.TLW.tlwVRSessionByEmployee
      Dim _Rec As SIS.TLW.tlwVRSessionByEmployee = SIS.TLW.tlwVRSessionByEmployee.tlwVRSessionByEmployeeGetByID(Record.RecordID)
      With _Rec
        .VRSessionID = Record.VRSessionID
        .ApplicationID = Global.System.Web.HttpContext.Current.Session("ApplicationID")
        .UserName = Record.UserName
        .MaintainGrid = Record.MaintainGrid
        .InsertForm = Record.InsertForm
        .UpdateForm = Record.UpdateForm
        .DisplayGrid = Record.DisplayGrid
        .DisplayForm = Record.DisplayForm
        .DeleteOption = Record.DeleteOption
      End With
      Return SIS.TLW.tlwVRSessionByEmployee.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As SIS.TLW.tlwVRSessionByEmployee
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByEmployeeUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,11, Record.RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRSessionID",SqlDbType.Int,11, Record.VRSessionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName",SqlDbType.NVarChar,21, Record.UserName)
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
    Public Shared Function tlwVRSessionByEmployeeDelete(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRSessionByEmployeeDelete"
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
