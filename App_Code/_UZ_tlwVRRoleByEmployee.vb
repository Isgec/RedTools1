Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  Partial Public Class tlwVRRoleByEmployee
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function WebUserRoleInsert(ByVal ApplicationID As Integer, ByVal RoleID As Integer, ByVal UserID As String) As SIS.TLW.tlwVRRoleByEmployee
      Dim _Rec As SIS.TLW.tlwVRRoleByEmployee = SIS.TLW.tlwVRRoleByEmployee.tlwVRRoleByEmployeeGetNewRecord()
      With _Rec
        .VRRoleID = RoleID
        .ApplicationID = ApplicationID
        .UserName = UserID
      End With
      Return SIS.TLW.tlwVRRoleByEmployee.InsertData(_Rec)
    End Function
    Public Shared Function UZ_tlwVRRoleByEmployeeSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRRoleID As Int32) As List(Of SIS.TLW.tlwVRRoleByEmployee)
      Dim Results As List(Of SIS.TLW.tlwVRRoleByEmployee) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlw_LG_VRRoleByEmployeeSelectListSearch"
            Cmd.CommandText = "sptlwVRRoleByEmployeeSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlw_LG_VRRoleByEmployeeSelectListFilteres"
            Cmd.CommandText = "sptlwVRRoleByEmployeeSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VRRoleID", SqlDbType.Int, 10, IIf(VRRoleID = Nothing, 0, VRRoleID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TLW.tlwVRRoleByEmployee)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TLW.tlwVRRoleByEmployee(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_tlwVRRoleByEmployeeInsert(ByVal Record As SIS.TLW.tlwVRRoleByEmployee) As SIS.TLW.tlwVRRoleByEmployee
      Dim _Result As SIS.TLW.tlwVRRoleByEmployee = tlwVRRoleByEmployeeInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tlwVRRoleByEmployeeUpdate(ByVal Record As SIS.TLW.tlwVRRoleByEmployee) As SIS.TLW.tlwVRRoleByEmployee
      Dim _Result As SIS.TLW.tlwVRRoleByEmployee = tlwVRRoleByEmployeeUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tlwVRRoleByEmployeeDelete(ByVal Record As SIS.TLW.tlwVRRoleByEmployee) As Integer
      Dim _Result as Integer = tlwVRRoleByEmployeeDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_RecordID"), TextBox).Text = ""
        CType(.FindControl("F_VRRoleID"),Object).SelectedValue = ""
        CType(.FindControl("F_UserName"), TextBox).Text = ""
        CType(.FindControl("F_UserName_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
