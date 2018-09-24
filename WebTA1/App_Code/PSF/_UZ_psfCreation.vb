Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports OfficeOpenXml
Namespace SIS.PSF
  Partial Public Class psfCreation
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = System.Drawing.Color.Black
      Select Case PSFStatus
        Case 2
          mRet = System.Drawing.Color.DarkGoldenrod
        Case 3
          mRet = System.Drawing.Color.Green
        Case 4
          mRet = System.Drawing.Color.Red
      End Select
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
      Dim mRet As Boolean = False
      If PSFStatus = 1 Or PSFStatus = 4 Then
        mRet = True
      End If
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If PSFStatus = 1 Or PSFStatus = 4 Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal SerialNo As Int32) As SIS.PSF.psfCreation
      Dim Results As SIS.PSF.psfCreation = psfCreationGetByID(SerialNo)
      With Results
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .PSFStatus = 2
      End With
      Results = SIS.PSF.psfCreation.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_psfCreationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal SupplierCode As String, ByVal PSFStatus As Int32) As List(Of SIS.PSF.psfCreation)
      Dim Results As List(Of SIS.PSF.psfCreation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppsf_LG_CreationSelectListSearch"
            Cmd.CommandText = "sppsfCreationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppsf_LG_CreationSelectListFilteres"
            Cmd.CommandText = "sppsfCreationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierCode", SqlDbType.NVarChar, 9, IIf(SupplierCode Is Nothing, String.Empty, SupplierCode))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PSFStatus", SqlDbType.Int, 10, IIf(PSFStatus = Nothing, 0, PSFStatus))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PSF.psfCreation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PSF.psfCreation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_psfCreationInsert(ByVal Record As SIS.PSF.psfCreation) As SIS.PSF.psfCreation
      Record.AmountInWords = SpellNumber(Record.TotalAmountDisbursed)
      Dim _Result As SIS.PSF.psfCreation = psfCreationInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_psfCreationUpdate(ByVal Record As SIS.PSF.psfCreation) As SIS.PSF.psfCreation
      Record.AmountInWords = SpellNumber(Record.TotalAmountDisbursed)
      Dim _Result As SIS.PSF.psfCreation = psfCreationUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_psfCreationDelete(ByVal Record As SIS.PSF.psfCreation) As Integer
      Dim _Result As Integer = psfCreationDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_PaymentRequestNo"), TextBox).Text = ""
          CType(.FindControl("F_OurRefNo"), TextBox).Text = ""
          CType(.FindControl("F_BankVoucherDate"), TextBox).Text = ""
          CType(.FindControl("F_SupplierCode"), TextBox).Text = ""
          CType(.FindControl("F_SupplierCode_Display"), Label).Text = ""
          CType(.FindControl("F_IRN"), TextBox).Text = ""
          CType(.FindControl("F_InvoiceNumber"), TextBox).Text = ""
          CType(.FindControl("F_InvoiceDate"), TextBox).Text = ""
          CType(.FindControl("F_InvoiceAmount"), TextBox).Text = 0
          CType(.FindControl("F_TotalAmountDisbursed"), TextBox).Text = 0
          CType(.FindControl("F_InterestForDays"), TextBox).Text = 0
          CType(.FindControl("F_InterestAmount"), TextBox).Text = 0
          CType(.FindControl("F_PDNNo"), TextBox).Text = ""
          CType(.FindControl("F_DueDate"), TextBox).Text = ""
          CType(.FindControl("F_TDSAmount"), TextBox).Text = 0
          CType(.FindControl("F_ServiceTax"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function

#Region "   Spell Number "
    Public Shared Function SpellNumber(ByVal MyNumber As String) As String
      Dim Dollars, Cents, Temp As String
      Dim DecimalPlace, Count As Integer
      Dim Place(9) As String
      Place(2) = " Thousand "
      Place(3) = " Million "
      Place(4) = " Billion "
      Place(5) = " Trillion "
      Dollars = ""
      Cents = ""
      Temp = ""
      ' String representation of amount.
      MyNumber = Trim(Str(MyNumber))
      ' Position of decimal place 0 if none.
      DecimalPlace = InStr(MyNumber, ".")
      ' Convert cents and set MyNumber to dollar amount.
      If DecimalPlace > 0 Then
        Cents = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & "00", 2))
        MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
      End If
      Count = 1
      Do While MyNumber <> ""
        Temp = GetHundreds(Right(MyNumber, 3))
        If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
        If Len(MyNumber) > 3 Then
          MyNumber = Left(MyNumber, Len(MyNumber) - 3)
        Else
          MyNumber = ""
        End If
        Count = Count + 1
      Loop
      Select Case Dollars
        Case ""
          Dollars = "No Rs."
        Case "One"
          Dollars = "One Rs."
        Case Else
          Dollars = Dollars & " Rs."
      End Select
      Select Case Cents
        Case ""
          Cents = " and No Paisa"
        Case "One"
          Cents = " and One Paisa"
        Case Else
          Cents = " and " & Cents & " Paisa"
      End Select
      SpellNumber = Dollars & Cents
    End Function

    ' Converts a number from 100-999 into text 
    Shared Function GetHundreds(ByVal MyNumber As String) As String
      Dim Result As String = ""
      If Val(MyNumber) = 0 Then Return ""
      MyNumber = Right("000" & MyNumber, 3)
      ' Convert the hundreds place.
      If Mid(MyNumber, 1, 1) <> "0" Then
        Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
      End If
      ' Convert the tens and ones place.
      If Mid(MyNumber, 2, 1) <> "0" Then
        Result = Result & GetTens(Mid(MyNumber, 2))
      Else
        Result = Result & GetDigit(Mid(MyNumber, 3))
      End If
      GetHundreds = Result
    End Function

    ' Converts a number from 10 to 99 into text. 
    Shared Function GetTens(ByVal TensText As Integer) As String
      Dim Result As String
      Result = ""           ' Null out the temporary function value.
      If Val(Left(TensText, 1)) = 1 Then   ' If value between 10-19...
        Select Case Val(TensText)
          Case 10 : Result = "Ten"
          Case 11 : Result = "Eleven"
          Case 12 : Result = "Twelve"
          Case 13 : Result = "Thirteen"
          Case 14 : Result = "Fourteen"
          Case 15 : Result = "Fifteen"
          Case 16 : Result = "Sixteen"
          Case 17 : Result = "Seventeen"
          Case 18 : Result = "Eighteen"
          Case 19 : Result = "Nineteen"
          Case Else
        End Select
      Else                                 ' If value between 20-99...
        Select Case Val(Left(TensText, 1))
          Case 2 : Result = "Twenty "
          Case 3 : Result = "Thirty "
          Case 4 : Result = "Forty "
          Case 5 : Result = "Fifty "
          Case 6 : Result = "Sixty "
          Case 7 : Result = "Seventy "
          Case 8 : Result = "Eighty "
          Case 9 : Result = "Ninety "
          Case Else
        End Select
        Result = Result & GetDigit(Right(TensText, 1))  ' Retrieve ones place.
      End If
      GetTens = Result
    End Function

    ' Converts a number from 1 to 9 into text. 
    Shared Function GetDigit(ByVal Digit As Integer) As String
      Select Case Val(Digit)
        Case 1 : GetDigit = "One"
        Case 2 : GetDigit = "Two"
        Case 3 : GetDigit = "Three"
        Case 4 : GetDigit = "Four"
        Case 5 : GetDigit = "Five"
        Case 6 : GetDigit = "Six"
        Case 7 : GetDigit = "Seven"
        Case 8 : GetDigit = "Eight"
        Case 9 : GetDigit = "Nine"
        Case Else : GetDigit = ""
      End Select
    End Function

#End Region

    Public Shared Function psfCreationSelectForOurRefNo(ByVal SerialNo As Integer) As List(Of SIS.PSF.psfCreation)
      Dim Results As List(Of SIS.PSF.psfCreation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsf_LG_CreationSelectForOurRefNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PSF.psfCreation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PSF.psfCreation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function CreatePSFFile(ByVal SerialNo As Integer) As String
      Dim FileName As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
      IO.File.Copy(HttpContext.Current.Server.MapPath("~/App_Templates") & "\PSF_Template.xlsx", FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Letter")

      Dim oVars As List(Of SIS.PSF.psfCreation) = SIS.PSF.psfCreation.psfCreationSelectForOurRefNo(SerialNo)

      Dim r As Integer = 5
      Dim c As Integer = 1
      r = 5
      With xlWS
        Dim ooVar As SIS.PSF.psfCreation = oVars(0)

        .Cells(5, 3).Value = ooVar.OurRefNo
        .Cells(6, 3).Value = ooVar.BankVoucherDate

        r = 16
        Dim iAmt As Decimal = 0
        Dim dAmt As Decimal = 0
        Dim SN As Integer = 0
        For Each oVar As SIS.PSF.psfCreation In oVars
          If r > 16 Then xlWS.InsertRow(r, 1, r + 1)
          SN += 1
          .Cells(r, 1).Value = SN
          .Cells(r, 2).Value = oVar.PSF_Supplier5_SupplierName
          .Cells(r, 3).Value = oVar.IRN
          .Cells(r, 4).Value = oVar.InvoiceNumber
          .Cells(r, 5).Value = oVar.InvoiceDate
          .Cells(r, 6).Value = oVar.InvoiceAmount
          .Cells(r, 7).Value = oVar.TotalAmountDisbursed
          .Cells(r, 8).Value = oVar.DueDate
          .Cells(r, 9).Value = "As per invoice"
          iAmt += oVar.InvoiceAmount
          dAmt += oVar.TotalAmountDisbursed
          r += 1
        Next
        r += 1
        .Cells(r, 6).Value = iAmt
        .Cells(r, 7).Value = dAmt

        r += 1
        .Cells(r, 4).Value = SIS.PSF.psfCreation.SpellNumber(dAmt.ToString)

        r += 3
        .Cells(r, 1).Value = ooVar.PSF_Supplier5_SupplierName
        .Cells(r, 3).Value = ooVar.FK_PSF_HSBCMain_SupplierID.BankName & ", " & ooVar.FK_PSF_HSBCMain_SupplierID.BranchAddress
        .Cells(r, 7).Value = ooVar.FK_PSF_HSBCMain_SupplierID.BankAccountNo
        .Cells(r, 9).Value = ooVar.FK_PSF_HSBCMain_SupplierID.IFSCCode

      End With

      Try
        xlPk.Save()
        xlPk.Dispose()
      Catch ex As Exception
        xlPk.Dispose()
      End Try
      Return FileName
    End Function
    Public Shared Function getCqData(ByVal value As String) As String
      Dim aVal() As String = value.Split(",".ToCharArray)
      Dim mRet As String = "0|" & aVal(0)
      Dim CqNo As String = aVal(1).Replace("_", "")
      Dim Results As SIS.PSF.psfCreation = Nothing
      Dim Sql As String = ""
      Sql &= "select cq.t_cheq As OurRefNo,                       "
      Sql &= "       rq.t_adrq as PaymentRequestNo,               "
      Sql &= "       cq.t_dout As BankVoucherDate,                "
      Sql &= "       rq.t_bpid As SupplierCode                    "
      Sql &= " from ttfcmg100200 as cq                             "
      Sql &= " inner join ttfmsl020200 as rq on cq.t_cheq=rq.t_chqe"
      Sql &= " where ltrim(cq.t_cheq)='" & CqNo & "'"
      Sql &= " and ltrim(cq.t_bank)='SCB'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PSF.psfCreation(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Try
        mRet &= "|" & Results.OurRefNo
        mRet &= "|" & Results.PaymentRequestNo
        mRet &= "|" & Results.BankVoucherDate
        mRet &= "|" & Results.SupplierCode
      Catch ex As Exception

      End Try
      Return mRet
    End Function
    Public Shared Function getIRData(ByVal value As String) As String
      Dim aVal() As String = value.Split(",".ToCharArray)
      Dim mRet As String = "0|" & aVal(0)
      Dim IRNo As Integer = 0
      Try
        IRNo = CType(aVal(1).Replace("_", ""), Integer)
      Catch ex As Exception
      End Try
      Dim Results As SIS.PSF.psfCreation = Nothing
      Dim Sql As String = ""
      Sql &= "select t_ninv AS IRN,          "
      Sql &= "       t_isup as InvoiceNumber,"
      Sql &= "       t_invd as InvoiceDate,  "
      Sql &= "       t_amti as InvoiceAmount "
      Sql &= "from ttfacp100200              "
      Sql &= "where t_ninv =  " & IRNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PSF.psfCreation(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Try
        mRet &= "|" & Results.IRN
        mRet &= "|" & Results.InvoiceNumber
        mRet &= "|" & Results.InvoiceDate
        mRet &= "|" & Results.InvoiceAmount
      Catch ex As Exception

      End Try
      Return mRet
    End Function

  End Class
End Namespace
