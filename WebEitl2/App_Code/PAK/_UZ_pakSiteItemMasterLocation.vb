Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSiteItemMasterLocation
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
    Public Function GetDeleteable() As Boolean
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
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_pakSiteItemMasterLocationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal SiteMarkNo As String) As List(Of SIS.PAK.pakSiteItemMasterLocation)
      Dim Results As List(Of SIS.PAK.pakSiteItemMasterLocation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SiteItemMasterLocationSelectListSearch"
            Cmd.CommandText = "sppakSiteItemMasterLocationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SiteItemMasterLocationSelectListFilteres"
            Cmd.CommandText = "sppakSiteItemMasterLocationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SiteMarkNo",SqlDbType.NVarChar,30, IIf(SiteMarkNo Is Nothing, String.Empty,SiteMarkNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteItemMasterLocation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteItemMasterLocation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSiteItemMasterLocationInsert(ByVal Record As SIS.PAK.pakSiteItemMasterLocation) As SIS.PAK.pakSiteItemMasterLocation
      Dim _Result As SIS.PAK.pakSiteItemMasterLocation = pakSiteItemMasterLocationInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSiteItemMasterLocationUpdate(ByVal Record As SIS.PAK.pakSiteItemMasterLocation) As SIS.PAK.pakSiteItemMasterLocation
      Dim _Result As SIS.PAK.pakSiteItemMasterLocation = pakSiteItemMasterLocationUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSiteItemMasterLocationDelete(ByVal Record As SIS.PAK.pakSiteItemMasterLocation) As Integer
      Dim _Result as Integer = pakSiteItemMasterLocationDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_SiteMarkNo"), TextBox).Text = ""
        CType(.FindControl("F_SiteMarkNo_Display"), Label).Text = ""
        CType(.FindControl("F_LocationID"),Object).SelectedValue = ""
        CType(.FindControl("F_UOMQuantity"),Object).SelectedValue = ""
        CType(.FindControl("F_Quantity"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
