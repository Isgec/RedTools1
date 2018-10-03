Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  <DataObject()> _
  Partial Public Class tlwUsers
    Private Shared _RecordCount As Integer
    Private _LoginID As String = ""
    Private _UserFullName As String = ""
    Private _ExtnNo As String = ""
    Private _MobileNo As String = ""
    Private _EMailID As String = ""
    Private _C_DateOfJoining As String = ""
    Private _C_CompanyID As String = ""
    Private _C_DivisionID As String = ""
    Private _C_OfficeID As String = ""
    Private _C_DepartmentID As String = ""
    Private _C_DesignationID As String = ""
    Private _ActiveState As String = ""
    Private _Contractual As Boolean = False
    Private _wp_user As String = ""
    Private _pw As String = ""
    Private _HRM_Companies2_Description As String = ""
    Private _HRM_Departments3_Description As String = ""
    Private _HRM_Designations4_Description As String = ""
    Private _HRM_Divisions5_Description As String = ""
    Private _HRM_Offices6_Description As String = ""
    Private _FK_USR_Company As SIS.TLW.tlwCompanies = Nothing
    Private _FK_USR_Department As SIS.TLW.tlwDepartments = Nothing
    Private _FK_USR_Designation As SIS.TLW.tlwDesignations = Nothing
    Private _FK_USR_Division As SIS.TLW.tlwDivisions = Nothing
    Private _FK_USR_OfficeID As SIS.TLW.tlwOffices = Nothing
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
    Public Property LoginID() As String
      Get
        Return _LoginID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LoginID = ""
         Else
           _LoginID = value
         End If
      End Set
    End Property
    Public Property UserFullName() As String
      Get
        Return _UserFullName
      End Get
      Set(ByVal value As String)
        _UserFullName = value
      End Set
    End Property
    Public Property ExtnNo() As String
      Get
        Return _ExtnNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ExtnNo = ""
         Else
           _ExtnNo = value
         End If
      End Set
    End Property
    Public Property MobileNo() As String
      Get
        Return _MobileNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MobileNo = ""
         Else
           _MobileNo = value
         End If
      End Set
    End Property
    Public Property EMailID() As String
      Get
        Return _EMailID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EMailID = ""
         Else
           _EMailID = value
         End If
      End Set
    End Property
    Public Property C_DateOfJoining() As String
      Get
        If Not _C_DateOfJoining = String.Empty Then
          Return Convert.ToDateTime(_C_DateOfJoining).ToString("dd/MM/yyyy")
        End If
        Return _C_DateOfJoining
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_DateOfJoining = ""
         Else
           _C_DateOfJoining = value
         End If
      End Set
    End Property
    Public Property C_CompanyID() As String
      Get
        Return _C_CompanyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_CompanyID = ""
         Else
           _C_CompanyID = value
         End If
      End Set
    End Property
    Public Property C_DivisionID() As String
      Get
        Return _C_DivisionID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_DivisionID = ""
         Else
           _C_DivisionID = value
         End If
      End Set
    End Property
    Public Property C_OfficeID() As String
      Get
        Return _C_OfficeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_OfficeID = ""
         Else
           _C_OfficeID = value
         End If
      End Set
    End Property
    Public Property C_DepartmentID() As String
      Get
        Return _C_DepartmentID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_DepartmentID = ""
         Else
           _C_DepartmentID = value
         End If
      End Set
    End Property
    Public Property C_DesignationID() As String
      Get
        Return _C_DesignationID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _C_DesignationID = ""
         Else
           _C_DesignationID = value
         End If
      End Set
    End Property
    Public Property ActiveState() As String
      Get
        Return _ActiveState
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ActiveState = ""
         Else
           _ActiveState = value
         End If
      End Set
    End Property
    Public Property Contractual() As Boolean
      Get
        Return _Contractual
      End Get
      Set(ByVal value As Boolean)
        _Contractual = value
      End Set
    End Property
    Public Property wp_user() As String
      Get
        Return _wp_user
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _wp_user = ""
         Else
           _wp_user = value
         End If
      End Set
    End Property
    Public Property pw() As String
      Get
        Return _pw
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _pw = ""
         Else
           _pw = value
         End If
      End Set
    End Property
    Public Property HRM_Companies2_Description() As String
      Get
        Return _HRM_Companies2_Description
      End Get
      Set(ByVal value As String)
        _HRM_Companies2_Description = value
      End Set
    End Property
    Public Property HRM_Departments3_Description() As String
      Get
        Return _HRM_Departments3_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments3_Description = value
      End Set
    End Property
    Public Property HRM_Designations4_Description() As String
      Get
        Return _HRM_Designations4_Description
      End Get
      Set(ByVal value As String)
        _HRM_Designations4_Description = value
      End Set
    End Property
    Public Property HRM_Divisions5_Description() As String
      Get
        Return _HRM_Divisions5_Description
      End Get
      Set(ByVal value As String)
        _HRM_Divisions5_Description = value
      End Set
    End Property
    Public Property HRM_Offices6_Description() As String
      Get
        Return _HRM_Offices6_Description
      End Get
      Set(ByVal value As String)
        _HRM_Offices6_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _UserFullName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _LoginID
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
    Public Class PKtlwUsers
      Private _LoginID As String = ""
      Public Property LoginID() As String
        Get
          Return _LoginID
        End Get
        Set(ByVal value As String)
          _LoginID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_USR_Company() As SIS.TLW.tlwCompanies
      Get
        If _FK_USR_Company Is Nothing Then
          _FK_USR_Company = SIS.TLW.tlwCompanies.tlwCompaniesGetByID(_C_CompanyID)
        End If
        Return _FK_USR_Company
      End Get
    End Property
    Public ReadOnly Property FK_USR_Department() As SIS.TLW.tlwDepartments
      Get
        If _FK_USR_Department Is Nothing Then
          _FK_USR_Department = SIS.TLW.tlwDepartments.tlwDepartmentsGetByID(_C_DepartmentID)
        End If
        Return _FK_USR_Department
      End Get
    End Property
    Public ReadOnly Property FK_USR_Designation() As SIS.TLW.tlwDesignations
      Get
        If _FK_USR_Designation Is Nothing Then
          _FK_USR_Designation = SIS.TLW.tlwDesignations.tlwDesignationsGetByID(_C_DesignationID)
        End If
        Return _FK_USR_Designation
      End Get
    End Property
    Public ReadOnly Property FK_USR_Division() As SIS.TLW.tlwDivisions
      Get
        If _FK_USR_Division Is Nothing Then
          _FK_USR_Division = SIS.TLW.tlwDivisions.tlwDivisionsGetByID(_C_DivisionID)
        End If
        Return _FK_USR_Division
      End Get
    End Property
    Public ReadOnly Property FK_USR_OfficeID() As SIS.TLW.tlwOffices
      Get
        If _FK_USR_OfficeID Is Nothing Then
          _FK_USR_OfficeID = SIS.TLW.tlwOffices.tlwOfficesGetByID(_C_OfficeID)
        End If
        Return _FK_USR_OfficeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwUsersSelectList(ByVal OrderBy As String) As List(Of SIS.TLW.tlwUsers)
      Dim Results As List(Of SIS.TLW.tlwUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwUsersSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwUsersGetNewRecord() As SIS.TLW.tlwUsers
      Return New SIS.TLW.tlwUsers()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwUsersGetByID(ByVal LoginID As String) As SIS.TLW.tlwUsers
      Dim Results As SIS.TLW.tlwUsers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwUsersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID",SqlDbType.NVarChar,LoginID.ToString.Length, LoginID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TLW.tlwUsers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwUsersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal C_CompanyID As String, ByVal C_DivisionID As String, ByVal C_OfficeID As Int32, ByVal C_DepartmentID As String, ByVal C_DesignationID As Int32) As List(Of SIS.TLW.tlwUsers)
      Dim Results As List(Of SIS.TLW.tlwUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlwUsersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlwUsersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_CompanyID",SqlDbType.NVarChar,6, IIf(C_CompanyID Is Nothing, String.Empty,C_CompanyID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DivisionID",SqlDbType.NVarChar,6, IIf(C_DivisionID Is Nothing, String.Empty,C_DivisionID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_OfficeID",SqlDbType.Int,10, IIf(C_OfficeID = Nothing, 0,C_OfficeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DepartmentID",SqlDbType.NVarChar,6, IIf(C_DepartmentID Is Nothing, String.Empty,C_DepartmentID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_C_DesignationID",SqlDbType.Int,10, IIf(C_DesignationID = Nothing, 0,C_DesignationID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tlwUsersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal C_CompanyID As String, ByVal C_DivisionID As String, ByVal C_OfficeID As Int32, ByVal C_DepartmentID As String, ByVal C_DesignationID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwUsersGetByID(ByVal LoginID As String, ByVal Filter_C_CompanyID As String, ByVal Filter_C_DivisionID As String, ByVal Filter_C_OfficeID As Int32, ByVal Filter_C_DepartmentID As String, ByVal Filter_C_DesignationID As Int32) As SIS.TLW.tlwUsers
      Return tlwUsersGetByID(LoginID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tlwUsersInsert(ByVal Record As SIS.TLW.tlwUsers) As SIS.TLW.tlwUsers
      Dim _Rec As SIS.TLW.tlwUsers = SIS.TLW.tlwUsers.tlwUsersGetNewRecord()
      With _Rec
        .LoginID = Record.LoginID
        .UserFullName = Record.UserFullName
        .ExtnNo = Record.ExtnNo
        .MobileNo = Record.MobileNo
        .EMailID = Record.EMailID
        .C_DateOfJoining = Record.C_DateOfJoining
        .C_CompanyID = Record.C_CompanyID
        .C_DivisionID = Record.C_DivisionID
        .C_OfficeID = Record.C_OfficeID
        .C_DepartmentID = Record.C_DepartmentID
        .C_DesignationID = Record.C_DesignationID
        .ActiveState = Record.ActiveState
        .Contractual = Record.Contractual
        .wp_user = Record.wp_user
        .pw = Record.pw
      End With
      Return SIS.TLW.tlwUsers.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TLW.tlwUsers) As SIS.TLW.tlwUsers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwUsersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID",SqlDbType.NVarChar,9, Iif(Record.LoginID= "" ,Convert.DBNull, Record.LoginID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserFullName",SqlDbType.NVarChar,51, Record.UserFullName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExtnNo",SqlDbType.NVarChar,51, Iif(Record.ExtnNo= "" ,Convert.DBNull, Record.ExtnNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileNo",SqlDbType.NVarChar,51, Iif(Record.MobileNo= "" ,Convert.DBNull, Record.MobileNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID",SqlDbType.NVarChar,51, Iif(Record.EMailID= "" ,Convert.DBNull, Record.EMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfJoining",SqlDbType.DateTime,21, Iif(Record.C_DateOfJoining= "" ,Convert.DBNull, Record.C_DateOfJoining))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID",SqlDbType.NVarChar,7, Iif(Record.C_CompanyID= "" ,Convert.DBNull, Record.C_CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID",SqlDbType.NVarChar,7, Iif(Record.C_DivisionID= "" ,Convert.DBNull, Record.C_DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID",SqlDbType.Int,11, Iif(Record.C_OfficeID= "" ,Convert.DBNull, Record.C_OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID",SqlDbType.NVarChar,7, Iif(Record.C_DepartmentID= "" ,Convert.DBNull, Record.C_DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID",SqlDbType.Int,11, Iif(Record.C_DesignationID= "" ,Convert.DBNull, Record.C_DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState",SqlDbType.Bit,3, Iif(Record.ActiveState= "" ,Convert.DBNull, Record.ActiveState))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual",SqlDbType.Bit,3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@wp_user",SqlDbType.NVarChar,51, Iif(Record.wp_user= "" ,Convert.DBNull, Record.wp_user))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@pw",SqlDbType.NVarChar,51, Iif(Record.pw= "" ,Convert.DBNull, Record.pw))
          Cmd.Parameters.Add("@Return_LoginID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_LoginID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.LoginID = Cmd.Parameters("@Return_LoginID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tlwUsersUpdate(ByVal Record As SIS.TLW.tlwUsers) As SIS.TLW.tlwUsers
      Dim _Rec As SIS.TLW.tlwUsers = SIS.TLW.tlwUsers.tlwUsersGetByID(Record.LoginID)
      With _Rec
        .UserFullName = Record.UserFullName
        .ExtnNo = Record.ExtnNo
        .MobileNo = Record.MobileNo
        .EMailID = Record.EMailID
        .C_DateOfJoining = Record.C_DateOfJoining
        .C_CompanyID = Record.C_CompanyID
        .C_DivisionID = Record.C_DivisionID
        .C_OfficeID = Record.C_OfficeID
        .C_DepartmentID = Record.C_DepartmentID
        .C_DesignationID = Record.C_DesignationID
        .ActiveState = Record.ActiveState
        .Contractual = Record.Contractual
        .wp_user = Record.wp_user
        .pw = Record.pw
      End With
      Return SIS.TLW.tlwUsers.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TLW.tlwUsers) As SIS.TLW.tlwUsers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwUsersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LoginID",SqlDbType.NVarChar,9, Record.LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID",SqlDbType.NVarChar,9, Iif(Record.LoginID= "" ,Convert.DBNull, Record.LoginID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserFullName",SqlDbType.NVarChar,51, Record.UserFullName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExtnNo",SqlDbType.NVarChar,51, Iif(Record.ExtnNo= "" ,Convert.DBNull, Record.ExtnNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileNo",SqlDbType.NVarChar,51, Iif(Record.MobileNo= "" ,Convert.DBNull, Record.MobileNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID",SqlDbType.NVarChar,51, Iif(Record.EMailID= "" ,Convert.DBNull, Record.EMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DateOfJoining",SqlDbType.DateTime,21, Iif(Record.C_DateOfJoining= "" ,Convert.DBNull, Record.C_DateOfJoining))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID",SqlDbType.NVarChar,7, Iif(Record.C_CompanyID= "" ,Convert.DBNull, Record.C_CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID",SqlDbType.NVarChar,7, Iif(Record.C_DivisionID= "" ,Convert.DBNull, Record.C_DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID",SqlDbType.Int,11, Iif(Record.C_OfficeID= "" ,Convert.DBNull, Record.C_OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID",SqlDbType.NVarChar,7, Iif(Record.C_DepartmentID= "" ,Convert.DBNull, Record.C_DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID",SqlDbType.Int,11, Iif(Record.C_DesignationID= "" ,Convert.DBNull, Record.C_DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState",SqlDbType.Bit,3, Iif(Record.ActiveState= "" ,Convert.DBNull, Record.ActiveState))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual",SqlDbType.Bit,3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@wp_user",SqlDbType.NVarChar,51, Iif(Record.wp_user= "" ,Convert.DBNull, Record.wp_user))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@pw",SqlDbType.NVarChar,51, Iif(Record.pw= "" ,Convert.DBNull, Record.pw))
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
    Public Shared Function tlwUsersDelete(ByVal Record As SIS.TLW.tlwUsers) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwUsersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LoginID",SqlDbType.NVarChar,Record.LoginID.ToString.Length, Record.LoginID)
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
    Public Shared Function SelecttlwUsersAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwUsersAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TLW.tlwUsers = New SIS.TLW.tlwUsers(Reader)
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
