Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  <DataObject()> _
  Partial Public Class tlwVRMenus
    Private Shared _RecordCount As Integer
    Private _VRMenuID As Int32 = 0
    Private _VRMenuName As String = ""
    Private _ParentVRMenuID As Int32 = 0
    Private _ToolTip As String = ""
    Private _VRMenuType As String = ""
    Private _CSSClass As String = ""
    Private _Sequence As Int32 = 0
    Private _ApplicationID As Int32 = 0
    Private _SYS_Applications1_Description As String = ""
    Private _FK_SYS_VRMenus_SYS_Applications As SIS.TLW.tlwApplications = Nothing
    Private _FK_SYS_VRMenus_SYS_VRMenus As SIS.TLW.tlwVRMenus = Nothing
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
    Public Property VRMenuID() As Int32
      Get
        Return _VRMenuID
      End Get
      Set(ByVal value As Int32)
        _VRMenuID = value
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
    Public Property ParentVRMenuID() As Int32
      Get
        Return _ParentVRMenuID
      End Get
      Set(ByVal value As Int32)
        _ParentVRMenuID = value
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
    Public Property VRMenuType() As String
      Get
        Return _VRMenuType
      End Get
      Set(ByVal value As String)
        _VRMenuType = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _VRMenuName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _VRMenuID
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
    Public Class PKtlwVRMenus
      Private _VRMenuID As Int32 = 0
      Public Property VRMenuID() As Int32
        Get
          Return _VRMenuID
        End Get
        Set(ByVal value As Int32)
          _VRMenuID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_SYS_VRMenus_SYS_Applications() As SIS.TLW.tlwApplications
      Get
        If _FK_SYS_VRMenus_SYS_Applications Is Nothing Then
          _FK_SYS_VRMenus_SYS_Applications = SIS.TLW.tlwApplications.tlwApplicationsGetByID(_ApplicationID)
        End If
        Return _FK_SYS_VRMenus_SYS_Applications
      End Get
    End Property
    Public ReadOnly Property FK_SYS_VRMenus_SYS_VRMenus() As SIS.TLW.tlwVRMenus
      Get
        If _FK_SYS_VRMenus_SYS_VRMenus Is Nothing Then
          _FK_SYS_VRMenus_SYS_VRMenus = SIS.TLW.tlwVRMenus.tlwVRMenusGetByID(_VRMenuID)
        End If
        Return _FK_SYS_VRMenus_SYS_VRMenus
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRMenusSelectList(ByVal OrderBy As String) As List(Of SIS.TLW.tlwVRMenus)
      Dim Results As List(Of SIS.TLW.tlwVRMenus) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenusSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRMenus)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRMenus(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRMenusGetNewRecord() As SIS.TLW.tlwVRMenus
      Return New SIS.TLW.tlwVRMenus()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRMenusGetByID(ByVal VRMenuID As Int32) As SIS.TLW.tlwVRMenus
      Dim Results As SIS.TLW.tlwVRMenus = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenusSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuID",SqlDbType.Int,VRMenuID.ToString.Length, VRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TLW.tlwVRMenus(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByParentVRMenuID(ByVal ParentVRMenuID As Int32, ByVal OrderBy as String) As List(Of SIS.TLW.tlwVRMenus)
      Dim Results As List(Of SIS.TLW.tlwVRMenus) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenusSelectByParentVRMenuID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentVRMenuID",SqlDbType.Int,ParentVRMenuID.ToString.Length, ParentVRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRMenus)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRMenus(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tlwVRMenusSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TLW.tlwVRMenus)
      Dim Results As List(Of SIS.TLW.tlwVRMenus) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlwVRMenusSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlwVRMenusSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRMenus)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRMenus(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tlwVRMenusSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tlwVRMenusInsert(ByVal Record As SIS.TLW.tlwVRMenus) As SIS.TLW.tlwVRMenus
      Dim _Rec As SIS.TLW.tlwVRMenus = SIS.TLW.tlwVRMenus.tlwVRMenusGetNewRecord()
      With _Rec
        .VRMenuName = Record.VRMenuName
        .ParentVRMenuID = Record.ParentVRMenuID
        .ToolTip = Record.ToolTip
        .VRMenuType = Record.VRMenuType
        .CSSClass = Record.CSSClass
        .Sequence = Record.Sequence
        .ApplicationID =  Global.System.Web.HttpContext.Current.Session("ApplicationID")
      End With
      Return SIS.TLW.tlwVRMenus.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TLW.tlwVRMenus) As SIS.TLW.tlwVRMenus
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenusInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuName",SqlDbType.NVarChar,51, Record.VRMenuName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentVRMenuID",SqlDbType.Int,11, Record.ParentVRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToolTip",SqlDbType.NVarChar,101, Record.ToolTip)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuType",SqlDbType.NChar,2, Record.VRMenuType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CSSClass",SqlDbType.NVarChar,21, Record.CSSClass)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Sequence",SqlDbType.Int,11, Record.Sequence)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          Cmd.Parameters.Add("@Return_VRMenuID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_VRMenuID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.VRMenuID = Cmd.Parameters("@Return_VRMenuID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tlwVRMenusUpdate(ByVal Record As SIS.TLW.tlwVRMenus) As SIS.TLW.tlwVRMenus
      Dim _Rec As SIS.TLW.tlwVRMenus = SIS.TLW.tlwVRMenus.tlwVRMenusGetByID(Record.VRMenuID)
      With _Rec
        .VRMenuName = Record.VRMenuName
        .ParentVRMenuID = Record.ParentVRMenuID
        .ToolTip = Record.ToolTip
        .VRMenuType = Record.VRMenuType
        .CSSClass = Record.CSSClass
        .Sequence = Record.Sequence
        .ApplicationID = Global.System.Web.HttpContext.Current.Session("ApplicationID")
      End With
      Return SIS.TLW.tlwVRMenus.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TLW.tlwVRMenus) As SIS.TLW.tlwVRMenus
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenusUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VRMenuID",SqlDbType.Int,11, Record.VRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuName",SqlDbType.NVarChar,51, Record.VRMenuName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentVRMenuID",SqlDbType.Int,11, Record.ParentVRMenuID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToolTip",SqlDbType.NVarChar,101, Record.ToolTip)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRMenuType",SqlDbType.NChar,2, Record.VRMenuType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CSSClass",SqlDbType.NVarChar,21, Record.CSSClass)
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
    Public Shared Function tlwVRMenusDelete(ByVal Record As SIS.TLW.tlwVRMenus) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenusDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VRMenuID",SqlDbType.Int,Record.VRMenuID.ToString.Length, Record.VRMenuID)
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
    Public Shared Function SelecttlwVRMenusAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptlwVRMenusAutoCompleteList"
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
            Dim Tmp As SIS.TLW.tlwVRMenus = New SIS.TLW.tlwVRMenus(Reader)
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
