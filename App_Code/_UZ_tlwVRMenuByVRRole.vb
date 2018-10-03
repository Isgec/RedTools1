Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TLW
  Partial Public Class tlwVRMenuByVRRole
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
    Public Shared Function UZ_tlwVRMenuByVRRoleSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRRoleID As Int32, ByVal VRMenuID As Int32) As List(Of SIS.TLW.tlwVRMenuByVRRole)
      Dim Results As List(Of SIS.TLW.tlwVRMenuByVRRole) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptlw_LG_VRMenuByVRRoleSelectListSearch"
            Cmd.CommandText = "sptlwVRMenuByVRRoleSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptlw_LG_VRMenuByVRRoleSelectListFilteres"
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
    Public Shared Function UZ_tlwVRMenuByVRRoleInsert(ByVal Record As SIS.TLW.tlwVRMenuByVRRole) As SIS.TLW.tlwVRMenuByVRRole
      Dim _Result As SIS.TLW.tlwVRMenuByVRRole = tlwVRMenuByVRRoleInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tlwVRMenuByVRRoleUpdate(ByVal Record As SIS.TLW.tlwVRMenuByVRRole) As SIS.TLW.tlwVRMenuByVRRole
      Dim _Result As SIS.TLW.tlwVRMenuByVRRole = tlwVRMenuByVRRoleUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tlwVRMenuByVRRoleDelete(ByVal Record As SIS.TLW.tlwVRMenuByVRRole) As Integer
      Dim _Result as Integer = tlwVRMenuByVRRoleDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_RecordID"), TextBox).Text = ""
        CType(.FindControl("F_VRRoleID"),Object).SelectedValue = ""
        CType(.FindControl("F_VRMenuID"),Object).SelectedValue = ""
        CType(.FindControl("F_Sequence"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
