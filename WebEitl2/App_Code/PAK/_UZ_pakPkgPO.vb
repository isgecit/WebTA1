Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Namespace SIS.PAK
  Partial Public Class pakPkgPO
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ChildCreatable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If POStatusID = pakPOStates.UnderDespatch Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          If AcceptedBySupplier Then
            mRet = False
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If POStatusID = pakPOStates.UnderDespatch Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function InitiateWF(ByVal SerialNo As Int32) As SIS.PAK.pakPkgPO
      Dim Results As SIS.PAK.pakPkgPO = pakPkgPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Shadows Function ApproveWF(ByVal SerialNo As Int32) As SIS.PAK.pakPkgPO
      Dim Results As SIS.PAK.pakPkgPO = pakPkgPOGetByID(SerialNo)
      Results.AcceptedBySupplier = True
      Results.AcceptedBySupplierOn = Now
      Results = SIS.PAK.pakPkgPO.UpdateData(Results)
      Try
        SIS.CT.ctUpdates.CT_POAccepted(Results)
      Catch ex As Exception
        Throw New Exception(ex.Message)
      End Try
      Return Results
    End Function

    Public Shared Shadows Function RejectWF(ByVal SerialNo As Int32) As SIS.PAK.pakPkgPO
      Dim Results As SIS.PAK.pakPkgPO = pakPkgPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Shadows Function CompleteWF(ByVal SerialNo As Int32) As SIS.PAK.pakPkgPO
      Dim Results As SIS.PAK.pakPkgPO = pakPkgPOGetByID(SerialNo)
      With Results
        .ClosedBy = HttpContext.Current.Session("LoginID")
        .ClosedOn = Now
        .POStatusID = pakPOStates.Closed
      End With
      Results = SIS.PAK.pakPkgPO.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_pakPkgPOSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal BuyerID As String, ByVal IssuedBy As String) As List(Of SIS.PAK.pakPkgPO)
      Dim Results As List(Of SIS.PAK.pakPkgPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_PkgPOSelectListSearch"
            Cmd.CommandText = "sppakPkgPOSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_PkgPOSelectListFilteres"
            Cmd.CommandText = "sppakPkgPOSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BuyerID", SqlDbType.NVarChar, 8, IIf(BuyerID Is Nothing, String.Empty, BuyerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssuedBy", SqlDbType.NVarChar, 8, IIf(IssuedBy Is Nothing, String.Empty, IssuedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, "S" & HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POStatusID", SqlDbType.Int, 10, pakPOStates.UnderDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POFOR", SqlDbType.NVarChar, 2, "PK")
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgPO(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakPkgPOUpdate(ByVal Record As SIS.PAK.pakPkgPO) As SIS.PAK.pakPkgPO
      Dim _Result As SIS.PAK.pakPkgPO = pakPkgPOUpdate(Record)
      Return _Result
    End Function
    Public Shared Function DownloadTmplForPkg(ByVal Value As String) As String

      Dim aVal() As String = Value.Split("|".ToCharArray)

      Dim SerialNo As String = ""
      Dim PkgNo As String = ""

      Try
        SerialNo = aVal(0)
        PkgNo = aVal(1)
      Catch ex As Exception
      End Try

      Dim TemplateName As String = "PackingList_TEMPLATE.xlsx"
      Dim FileName As String = ""

      Dim tmpFile As String = HttpContext.Current.Server.MapPath("~/App_Templates/" & TemplateName)
      If IO.File.Exists(tmpFile) Then
        FileName = HttpContext.Current.Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
        IO.File.Copy(tmpFile, FileName)
        Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
        Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

        '1.
        Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Packing List")
        Dim r As Integer = 1
        Dim c As Integer = 1
        Dim cnt As Integer = 1

        '1. Header
        Dim tmpPO As SIS.PAK.pakPkgPO = SIS.PAK.pakPkgPO.pakPkgPOGetByID(SerialNo)
        Dim tmpPkg As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo, PkgNo)
        With xlWS
          .Cells(2, 4).Value = SerialNo
          .Cells(3, 4).Value = PkgNo
          .Cells(4, 4).Value = "'" & Convert.ToDateTime(tmpPkg.CreatedOn).ToString("dd/MM/yyyy")
          .Cells(5, 4).Value = tmpPO.ProjectID & " - " & tmpPO.IDM_Projects4_Description
          .Cells(6, 4).Value = tmpPO.PONumber
          .Cells(7, 4).Value = tmpPkg.TotalWeight

          .Cells(2, 12).Value = tmpPO.SupplierID & " - " & tmpPO.VR_BusinessPartner9_BPName
          .Cells(3, 12).Value = tmpPkg.SupplierRefNo
          .Cells(4, 12).Value = IIf(tmpPkg.TransporterID <> "", tmpPkg.VR_BusinessPartner4_BPName, tmpPkg.TransporterName)
          .Cells(5, 12).Value = tmpPkg.VehicleNo
          .Cells(6, 12).Value = tmpPkg.GRNo
          .Cells(7, 12).Value = "'" & Convert.ToDateTime(tmpPkg.GRDate).ToString("dd/MM/yyyy")
        End With

        '2. Data
        r = 11
        c = 1

        Dim PkgItems As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.pakPkgListDSelectList(0, 99999, "", False, "", PkgNo, SerialNo)

        For Each tmp As SIS.PAK.pakPkgListD In PkgItems
          With xlWS
            c = 1
            .Cells(r, c).Value = cnt
            c += 1
            .Cells(r, c).Value = tmp.ItemNo
            c += 1
            .Cells(r, c).Value = tmp.FK_PAK_PkgListD_ItemNo.ItemCode
            c += 1
            .Cells(r, c).Value = tmp.FK_PAK_PkgListD_ItemNo.ItemDescription
            c += 1
            If tmp.UOMQuantity <> "" Then .Cells(r, c).Value = tmp.FK_PAK_PkgListD_UOMQuantity.Description
            c += 1
            .Cells(r, c).Value = tmp.Quantity
            c += 1
            If tmp.UOMWeight <> "" Then .Cells(r, c).Value = tmp.FK_PAK_PkgListD_UOMWeight.Description
            c += 1
            .Cells(r, c).Value = tmp.WeightPerUnit
            c += 1
            .Cells(r, c).Value = (tmp.Quantity * tmp.WeightPerUnit).ToString("n")
            c += 1
            .Cells(r, c).Value = tmp.DocumentNo
            c += 1
            .Cells(r, c).Value = tmp.DocumentRevision
            c += 1
            .Cells(r, c).Value = tmp.PAK_PakTypes1_Description
            c += 1
            .Cells(r, c).Value = tmp.PackingMark
            c += 1
            .Cells(r, c).Value = tmp.PackLength
            c += 1
            .Cells(r, c).Value = tmp.PackWidth
            c += 1
            .Cells(r, c).Value = tmp.PackHeight
            c += 1
            .Cells(r, c).Value = tmp.PAK_Units8_Description
            c += 1

            cnt += 1
            r += 1
          End With
        Next

        xlPk.Save()
        xlPk.Dispose()

      End If
      Return filename
    End Function

  End Class
End Namespace
