Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PSF
    Partial Public Class psfReport
        Public Property TOurRefNo As String = ""
        Public Property TBankVoucherDate As String = ""
        Public Property TSupplierCode As String = ""
        Public Property TIRN As String = ""
        Public Property TDueDate As String = ""
        Public Property TPaymentDateToBank As String = ""
        Public Property THSBCToVendor As String = ""
        Public Property FOurRefNo As String = ""
        Public Property FBankVoucherDate As String = ""
        Public Property FSupplierCode As String = ""
        Public Property FIRN As String = ""
        Public Property FDueDate As String = ""
        Public Property FPaymentDateToBank As String = ""
        Public Property FHSBCToVendor As String = ""

        Public Shared Function UZ_psfReportSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PSF.psfReport)
            Dim Results As List(Of SIS.PSF.psfReport) = Nothing
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
                Using Cmd As SqlCommand = Con.CreateCommand()
                    If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
                    Cmd.CommandType = CommandType.StoredProcedure
                    If SearchState Then
                        Cmd.CommandText = "sppsf_LG_ReportSelectListSearch"
                        Cmd.CommandText = "sppsfReportSelectListSearch"
                        SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
                    Else
                        Cmd.CommandText = "sppsf_LG_ReportSelectListFilteres"
                        Cmd.CommandText = "sppsfReportSelectListFilteres"
                    End If
                    SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
                    SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
                    SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
                    SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
                    Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
                    Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
                    RecordCount = -1
                    Results = New List(Of SIS.PSF.psfReport)()
                    Con.Open()
                    Dim Reader As SqlDataReader = Cmd.ExecuteReader()
                    While (Reader.Read())
                        Results.Add(New SIS.PSF.psfReport(Reader))
                    End While
                    Reader.Close()
                    RecordCount = Cmd.Parameters("@RecordCount").Value
                End Using
            End Using
            Return Results
        End Function
    End Class
End Namespace
