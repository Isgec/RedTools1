Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  <DataObject()> _
  Partial Public Class tlwVRRoles
    Private Shared _RecordCount As Integer
    Private _VRRoleID As Int32 = 0
    Private _Description As String = ""
    Private _VRRoleType As String = ""
    Private _ApplicationID As Int32 = 0
    Private _DefaultRole As Boolean = False
    Private _SYS_Applications1_Description As String = ""
    Private _FK_SYS_VRRoles_SYS_Applications As SIS.TLW.tlwApplications = Nothing
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
    Public Property VRRoleID() As Int32
      Get
        Return _VRRoleID
      End Get
      Set(ByVal value As Int32)
        _VRRoleID = value
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
    Public Property VRRoleType() As String
      Get
        Return _VRRoleType
      End Get
      Set(ByVal value As String)
        _VRRoleType = value
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
    Public Property DefaultRole() As Boolean
      Get
        Return _DefaultRole
      End Get
      Set(ByVal value As Boolean)
        _DefaultRole = value
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
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _VRRoleID
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
    Public Class PKtlwVRRoles
      Private _VRRoleID As Int32 = 0
      Public Property VRRoleID() As Int32
        Get
          Return _VRRoleID
        End Get
        Set(ByVal value As Int32)
          _VRRoleID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_SYS_VRRoles_SYS_Applications() As SIS.TLW.tlwApplications
      Get
        If _FK_SYS_VRRoles_SYS_Applications Is Nothing Then
          _FK_SYS_VRRoles_SYS_Applications = SIS.TLW.tlwApplications.tlwApplicationsGetByID(_ApplicationID)
        End If
        Return _FK_SYS_VRRoles_SYS_Applications
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRRolesSelectList(ByVal OrderBy As String) As List(Of SIS.TLW.tlwVRRoles)
      Dim Results As List(Of SIS.TLW.tlwVRRoles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRRolesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRRoles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRRoles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRRolesGetNewRecord() As SIS.TLW.tlwVRRoles
      Return New SIS.TLW.tlwVRRoles()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRRolesGetByID(ByVal VRRoleID As Int32) As SIS.TLW.tlwVRRoles
      Dim Results As SIS.TLW.tlwVRRoles = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRRolesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRoleID",SqlDbType.Int,VRRoleID.ToString.Length, VRRoleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TLW.tlwVRRoles(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRRolesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRRoleID As Int32) As List(Of SIS.TLW.tlwVRRoles)
      Dim Results As List(Of SIS.TLW.tlwVRRoles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlwVRRolesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlwVRRolesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VRRoleID",SqlDbType.Int,10, IIf(VRRoleID = Nothing, 0,VRRoleID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRRoles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRRoles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tlwVRRolesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRRoleID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRRolesGetByID(ByVal VRRoleID As Int32, ByVal Filter_VRRoleID As Int32) As SIS.TLW.tlwVRRoles
      Return tlwVRRolesGetByID(VRRoleID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tlwVRRolesInsert(ByVal Record As SIS.TLW.tlwVRRoles) As SIS.TLW.tlwVRRoles
      Dim _Rec As SIS.TLW.tlwVRRoles = SIS.TLW.tlwVRRoles.tlwVRRolesGetNewRecord()
      With _Rec
        .Description = Record.Description
        .VRRoleType = Record.VRRoleType
        .ApplicationID =  Global.System.Web.HttpContext.Current.Session("ApplicationID")
        .DefaultRole = Record.DefaultRole
      End With
      Return SIS.TLW.tlwVRRoles.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TLW.tlwVRRoles) As SIS.TLW.tlwVRRoles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRRolesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRoleType",SqlDbType.NVarChar,2, Record.VRRoleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefaultRole",SqlDbType.Bit,3, Record.DefaultRole)
          Cmd.Parameters.Add("@Return_VRRoleID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_VRRoleID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.VRRoleID = Cmd.Parameters("@Return_VRRoleID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tlwVRRolesUpdate(ByVal Record As SIS.TLW.tlwVRRoles) As SIS.TLW.tlwVRRoles
      Dim _Rec As SIS.TLW.tlwVRRoles = SIS.TLW.tlwVRRoles.tlwVRRolesGetByID(Record.VRRoleID)
      With _Rec
        .Description = Record.Description
        .VRRoleType = Record.VRRoleType
        .ApplicationID = Global.System.Web.HttpContext.Current.Session("ApplicationID")
        .DefaultRole = Record.DefaultRole
      End With
      Return SIS.TLW.tlwVRRoles.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TLW.tlwVRRoles) As SIS.TLW.tlwVRRoles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRRolesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VRRoleID",SqlDbType.Int,11, Record.VRRoleID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRoleType",SqlDbType.NVarChar,2, Record.VRRoleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefaultRole",SqlDbType.Bit,3, Record.DefaultRole)
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
    Public Shared Function tlwVRRolesDelete(ByVal Record As SIS.TLW.tlwVRRoles) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRRolesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VRRoleID",SqlDbType.Int,Record.VRRoleID.ToString.Length, Record.VRRoleID)
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
    Public Shared Function SelecttlwVRRolesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRRolesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TLW.tlwVRRoles = New SIS.TLW.tlwVRRoles(Reader)
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
