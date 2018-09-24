Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakItems
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/filedownload.aspx?tmpl=" & PrimaryKey & "', 'win" & _ItemNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public ReadOnly Property PWeightPerUnit As String
      Get
        If WeightPerUnit <= 0 Then
          Return ""
        Else
          Return WeightPerUnit
        End If
      End Get
    End Property
    Public ReadOnly Property PQuantity As String
      Get
        If Quantity <= 0 Then
          Return ""
        Else
          Return Quantity
        End If
      End Get
    End Property
    Public ReadOnly Property PItemDescription As String
      Get
        Return Prefix & " " & ItemDescription
      End Get
    End Property
    Public ReadOnly Property FontBold As Boolean
      Get
        Dim mRet As Boolean = False
        If Not Bottom Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If Root Then
        mRet = Drawing.Color.Red
      ElseIf Middle Then
        Select Case ItemLevel
          Case 1
            mRet = Drawing.Color.Blue
          Case 2
            mRet = Drawing.Color.Green
          Case 3
            mRet = Drawing.Color.Crimson
          Case 4
            mRet = Drawing.Color.LightSeaGreen
          Case 5
            mRet = Drawing.Color.MediumVioletRed
          Case Else
            mRet = Drawing.Color.Olive
        End Select
      ElseIf Bottom Then
        mRet = Drawing.Color.Black
      End If
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
        Dim mRet As Boolean = False
        Try
          mRet = False
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_pakItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RootItem As Int32) As List(Of SIS.PAK.pakItems)
      Dim Results As List(Of SIS.PAK.pakItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_ItemsSelectListSearch"
            Cmd.CommandText = "sppakItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_ItemsSelectListFilteres"
            Cmd.CommandText = "sppakItemsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RootItem",SqlDbType.Int,10, IIf(RootItem = Nothing, 0,RootItem))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,2, True)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakItemsInsert(ByVal Record As SIS.PAK.pakItems) As SIS.PAK.pakItems
      Record.Root = True
      Record.DivisionID = Global.System.Web.HttpContext.Current.Session("DivisionID")
      Record = InsertData(Record)
      Record.RootItem = Record.ItemNo
      Record = UpdateData(Record)
      Return Record
    End Function
    Public Shared Function UZ_pakItemsUpdate(ByVal Record As SIS.PAK.pakItems) As SIS.PAK.pakItems
      Dim _Rec As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetByID(Record.ItemNo)
      With _Rec
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .Active = Record.Active
      End With
      Return SIS.PAK.pakItems.UpdateData(_Rec)
    End Function
    Public Shared Function UZ_pakItemsDelete(ByVal Record As SIS.PAK.pakItems) As Integer
      Dim _Result As Integer = pakItemsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_Quantity"), TextBox).Text = "0.00"
          CType(.FindControl("F_WeightPerUnit"), TextBox).Text = "0.00"
          CType(.FindControl("F_ItemDescription"), TextBox).Text = ""
        CType(.FindControl("F_ElementID"), TextBox).Text = ""
        CType(.FindControl("F_ElementID_Display"), Label).Text = ""
        CType(.FindControl("F_Active"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function pakItemsGetByDescription(ByVal ItemDescription As String) As SIS.PAK.pakItems
      Dim Results As SIS.PAK.pakItems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_ItemsSelectByDescription"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription", SqlDbType.NVarChar, ItemDescription.ToString.Length, ItemDescription)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakItems(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
