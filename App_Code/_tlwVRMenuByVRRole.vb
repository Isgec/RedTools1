Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  <DataObject()> _
  Partial Public Class tlwVRMenuByVRRole
    Private Shared _RecordCount As Integer
    Private _RecordID As Int32 = 0
    Private _VRRoleID As Int32 = 0
    Private _VRMenuID As Int32 = 0
    Private _Sequence As Int32 = 0
    Private _ApplicationID As Int32 = 0
    Private _SYS_Applications1_Description As String = ""
    Private _SYS_VRMenus2_VRMenuName As String = ""
    Private _SYS_VRRoles3_Description As String = ""
    Private _FK_SYS_VRMenuByVRRole_SYS_Applications As SIS.TLW.tlwApplications = Nothing
    Private _FK_SYS_VRMenuByVRRole_SYS_VRMenus As SIS.TLW.tlwVRMenus = Nothing
    Private _FK_SYS_VRMenuByVRRole_SYS_VRRoles As SIS.TLW.tlwVRRoles = Nothing
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
    Public Property VRRoleID() As Int32
      Get
        Return _VRRoleID
      End Get
      Set(ByVal value As Int32)
        _VRRoleID = value
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
    Public Property SYS_VRRoles3_Description() As String
      Get
        Return _SYS_VRRoles3_Description
      End Get
      Set(ByVal value As String)
        _SYS_VRRoles3_Description = value
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
    Public Class PKtlwVRMenuByVRRole
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
    Public ReadOnly Property FK_SYS_VRMenuByVRRole_SYS_Applications() As SIS.TLW.tlwApplications
      Get
        If _FK_SYS_VRMenuByVRRole_SYS_Applications Is Nothing Then
          _FK_SYS_VRMenuByVRRole_SYS_Applications = SIS.TLW.tlwApplications.tlwApplicationsGetByID(_ApplicationID)
        End If
        Return _FK_SYS_VRMenuByVRRole_SYS_Applications
      End Get
    End Property
    Public ReadOnly Property FK_SYS_VRMenuByVRRole_SYS_VRMenus() As SIS.TLW.tlwVRMenus
      Get
        If _FK_SYS_VRMenuByVRRole_SYS_VRMenus Is Nothing Then
          _FK_SYS_VRMenuByVRRole_SYS_VRMenus = SIS.TLW.tlwVRMenus.tlwVRMenusGetByID(_VRMenuID)
        End If
        Return _FK_SYS_VRMenuByVRRole_SYS_VRMenus
      End Get
    End Property
    Public ReadOnly Property FK_SYS_VRMenuByVRRole_SYS_VRRoles() As SIS.TLW.tlwVRRoles
      Get
        If _FK_SYS_VRMenuByVRRole_SYS_VRRoles Is Nothing Then
          _FK_SYS_VRMenuByVRRole_SYS_VRRoles = SIS.TLW.tlwVRRoles.tlwVRRolesGetByID(_VRRoleID)
        End If
        Return _FK_SYS_VRMenuByVRRole_SYS_VRRoles
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRMenuByVRRoleGetNewRecord() As SIS.TLW.tlwVRMenuByVRRole
      Return New SIS.TLW.tlwVRMenuByVRRole()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRMenuByVRRoleGetByID(ByVal RecordID As Int32) As SIS.TLW.tlwVRMenuByVRRole
      Dim Results As SIS.TLW.tlwVRMenuByVRRole = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenuByVRRoleSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID",SqlDbType.Int,RecordID.ToString.Length, RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TLW.tlwVRMenuByVRRole(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByVRRoleID(ByVal VRRoleID As Int32, ByVal OrderBy as String) As List(Of SIS.TLW.tlwVRMenuByVRRole)
      Dim Results As List(Of SIS.TLW.tlwVRMenuByVRRole) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenuByVRRoleSelectByVRRoleID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRoleID",SqlDbType.Int,VRRoleID.ToString.Length, VRRoleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRMenuByVRRole)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRMenuByVRRole(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRMenuByVRRoleSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRRoleID As Int32, ByVal VRMenuID As Int32) As List(Of SIS.TLW.tlwVRMenuByVRRole)
      Dim Results As List(Of SIS.TLW.tlwVRMenuByVRRole) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlwVRMenuByVRRoleSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlwVRMenuByVRRoleSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VRRoleID",SqlDbType.Int,10, IIf(VRRoleID = Nothing, 0,VRRoleID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VRMenuID",SqlDbType.Int,10, IIf(VRMenuID = Nothing, 0,VRMenuID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRMenuByVRRole)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRMenuByVRRole(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tlwVRMenuByVRRoleSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRRoleID As Int32, ByVal VRMenuID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRMenuByVRRoleGetByID(ByVal RecordID As Int32, ByVal Filter_VRRoleID As Int32, ByVal Filter_VRMenuID As Int32) As SIS.TLW.tlwVRMenuByVRRole
      Return tlwVRMenuByVRRoleGetByID(RecordID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tlwVRMenuByVRRoleInsert(ByVal Record As SIS.TLW.tlwVRMenuByVRRole) As SIS.TLW.tlwVRMenuByVRRole
      Dim _Rec As SIS.TLW.tlwVRMenuByVRRole = SIS.TLW.tlwVRMenuByVRRole.tlwVRMenuByVRRoleGetNewRecord()
      With _Rec
        .VRRoleID = Record.VRRoleID
        .VRMenuID = Record.VRMenuID
        .Sequence = Record.Sequence
        .ApplicationID =  Global.System.Web.HttpContext.Current.Session("ApplicationID")
      End With
      Return SIS.TLW.tlwVRMenuByVRRole.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TLW.tlwVRMenuByVRRole) As SIS.TLW.tlwVRMenuByVRRole
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenuByVRRoleInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRoleID",SqlDbType.Int,11, Record.VRRoleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuID",SqlDbType.Int,11, Record.VRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
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
    Public Shared Function tlwVRMenuByVRRoleUpdate(ByVal Record As SIS.TLW.tlwVRMenuByVRRole) As SIS.TLW.tlwVRMenuByVRRole
      Dim _Rec As SIS.TLW.tlwVRMenuByVRRole = SIS.TLW.tlwVRMenuByVRRole.tlwVRMenuByVRRoleGetByID(Record.RecordID)
      With _Rec
        .VRRoleID = Record.VRRoleID
        .VRMenuID = Record.VRMenuID
        .Sequence = Record.Sequence
        .ApplicationID = Global.System.Web.HttpContext.Current.Session("ApplicationID")
      End With
      Return SIS.TLW.tlwVRMenuByVRRole.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TLW.tlwVRMenuByVRRole) As SIS.TLW.tlwVRMenuByVRRole
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenuByVRRoleUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,11, Record.RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRoleID",SqlDbType.Int,11, Record.VRRoleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuID",SqlDbType.Int,11, Record.VRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
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
    Public Shared Function tlwVRMenuByVRRoleDelete(ByVal Record As SIS.TLW.tlwVRMenuByVRRole) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenuByVRRoleDelete"
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
