Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  Partial Public Class tlwVRSessionByEmployee
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
    Public Shared Function UZ_tlwVRSessionByEmployeeSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRSessionID As Int32, ByVal UserName As String) As List(Of SIS.TLW.tlwVRSessionByEmployee)
      Dim Results As List(Of SIS.TLW.tlwVRSessionByEmployee) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlw_LG_VRSessionByEmployeeSelectListSearch"
            Cmd.CommandText = "sptlwVRSessionByEmployeeSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlw_LG_VRSessionByEmployeeSelectListFilteres"
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
    Public Shared Function UZ_tlwVRSessionByEmployeeInsert(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As SIS.TLW.tlwVRSessionByEmployee
      Dim _Result As SIS.TLW.tlwVRSessionByEmployee = tlwVRSessionByEmployeeInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tlwVRSessionByEmployeeUpdate(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As SIS.TLW.tlwVRSessionByEmployee
      Dim _Result As SIS.TLW.tlwVRSessionByEmployee = tlwVRSessionByEmployeeUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tlwVRSessionByEmployeeDelete(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As Integer
      Dim _Result as Integer = tlwVRSessionByEmployeeDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_RecordID"), TextBox).Text = ""
        CType(.FindControl("F_VRSessionID"),Object).SelectedValue = ""
        CType(.FindControl("F_UserName"), TextBox).Text = ""
        CType(.FindControl("F_UserName_Display"), Label).Text = ""
        CType(.FindControl("F_MaintainGrid"), CheckBox).Checked = False
        CType(.FindControl("F_InsertForm"), CheckBox).Checked = False
        CType(.FindControl("F_UpdateForm"), CheckBox).Checked = False
        CType(.FindControl("F_DisplayGrid"), CheckBox).Checked = False
        CType(.FindControl("F_DisplayForm"), CheckBox).Checked = False
        CType(.FindControl("F_DeleteOption"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function DistinctInsert(ByVal Record As SIS.TLW.tlwVRSessionByEmployee) As Int32
      Dim Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Dim Cmd As SqlCommand = Con.CreateCommand()
      Cmd.CommandType = CommandType.StoredProcedure
      Cmd.CommandText = "spSYS_LG_VRSessionByEmployeeDistinctInsert"
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName", SqlDbType.NVarChar, Record.UserName.Length, Record.UserName)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRSessionID", SqlDbType.Int, Record.VRSessionID.ToString.Length, Record.VRSessionID)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.NVarChar, 50, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintainGrid", SqlDbType.Bit, 3, Record.MaintainGrid)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InsertForm", SqlDbType.Bit, 3, Record.InsertForm)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateForm", SqlDbType.Bit, 3, Record.UpdateForm)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DisplayGrid", SqlDbType.Bit, 3, Record.DisplayGrid)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DisplayForm", SqlDbType.Bit, 3, Record.DisplayForm)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteOption", SqlDbType.Bit, 3, Record.DeleteOption)
      Cmd.Parameters.Add("@RecordID", SqlDbType.Int)
      Cmd.Parameters("@RecordID").Direction = ParameterDirection.Output
      Using Con
        Con.Open()
        Cmd.ExecuteNonQuery()
      End Using
      If Convert.IsDBNull(Cmd.Parameters("@RecordID").Value) Then
        Return 0
      End If
      Return 1
    End Function
  End Class
End Namespace
