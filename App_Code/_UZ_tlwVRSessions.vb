Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  Partial Public Class tlwVRSessions
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
    Public Shared Function UZ_tlwVRSessionsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TLW.tlwVRSessions)
      Dim Results As List(Of SIS.TLW.tlwVRSessions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlw_LG_VRSessionsSelectListSearch"
            Cmd.CommandText = "sptlwVRSessionsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlw_LG_VRSessionsSelectListFilteres"
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
    Public Shared Function UZ_tlwVRSessionsInsert(ByVal Record As SIS.TLW.tlwVRSessions) As SIS.TLW.tlwVRSessions
      Dim _Result As SIS.TLW.tlwVRSessions = tlwVRSessionsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tlwVRSessionsUpdate(ByVal Record As SIS.TLW.tlwVRSessions) As SIS.TLW.tlwVRSessions
      Dim _Result As SIS.TLW.tlwVRSessions = tlwVRSessionsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tlwVRSessionsDelete(ByVal Record As SIS.TLW.tlwVRSessions) As Integer
      Dim _Result as Integer = tlwVRSessionsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_VRSessionID"), TextBox).Text = ""
        CType(.FindControl("F_FileName"), TextBox).Text = ""
        CType(.FindControl("F_Description"), TextBox).Text = ""
        CType(.FindControl("F_FolderLocation"), TextBox).Text = ""
        CType(.FindControl("F_VRMenuName"), TextBox).Text = ""
        CType(.FindControl("F_ToolTip"), TextBox).Text = ""
        CType(.FindControl("F_VRSessionType"), TextBox).Text = ""
        CType(.FindControl("F_CSSClass"), TextBox).Text = ""
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
  End Class
End Namespace
