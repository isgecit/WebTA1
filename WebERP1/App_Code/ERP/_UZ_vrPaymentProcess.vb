Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrPaymentProcess
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
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function CompleteWF(ByVal SerialNo As Int32) As SIS.VR.vrPaymentProcess
      Dim Results As SIS.VR.vrPaymentProcess = vrPaymentProcessGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function UZ_vrPaymentProcessSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrPaymentProcess)
      Dim Results As List(Of SIS.VR.vrPaymentProcess) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvr_LG_PaymentProcessSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrPaymentProcess)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrPaymentProcess(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
		Public Shared Function UZ_vrPaymentProcessInsert(ByVal Record As SIS.VR.vrPaymentProcess) As SIS.VR.vrPaymentProcess
			Dim _Result As SIS.VR.vrPaymentProcess = vrPaymentProcessInsert(Record)
			Return _Result
		End Function
		Public Shared Function UZ_vrPaymentProcessUpdate(ByVal Record As SIS.VR.vrPaymentProcess) As SIS.VR.vrPaymentProcess
			Dim _Result As SIS.VR.vrPaymentProcess = vrPaymentProcessUpdate(Record)
			Return _Result
		End Function
		Public Shared Function PaymentInBaaNByIRNo(ByVal IRNo As String) As List(Of SIS.VR.vrPaymentProcess)
			Dim Results As List(Of SIS.VR.vrPaymentProcess) = Nothing
			Dim Sql As String = ""
			Sql = Sql & "select ir.t_ninv as IRNo,"
			Sql = Sql & "       ir.t_ctyp as PTR,"
			Sql = Sql & "       ir.t_cinv as PTRNo,"
			Sql = Sql & "       pb.t_refr as PaymentReference,"
			Sql = Sql & "       pb.t_pdat as PTRDate,"
			Sql = Sql & "       pb.t_amnt as PTRAmount,"
			Sql = Sql & "       pb.t_btno as Batch,"
			Sql = Sql & "       cq.t_cheq as ChequeNo,"
			Sql = Sql & "       cq.t_dout as ChequeDate,"
			Sql = Sql & "       cq.t_amnt as ChequeAmount,"
			Sql = Sql & "       cq.t_chnm as PaymentDescription,"
			Sql = Sql & "       cq.t_drec as ReconciledOn,"
			Sql = Sql & "       (case when cq.t_drec ='' then 0 else 1 end) as Freezed, "
			Sql = Sql & "       bt.t_user as ProcessedBy,"
			Sql = Sql & "       bt.t_date as ProcessedOn "
			Sql = Sql & "from ttfacp100200 as ir "
			Sql = Sql & "     inner join ttfcmg101200 as pb on (ir.t_ctyp = pb.t_ttyp and ir.t_cinv = pb.t_ninv)  "
			Sql = Sql & "     inner join ttfcmg100200 as cq on pb.t_btno = cq.t_pbtn "
			Sql = Sql & "     inner join ttfcmg109200 as bt on pb.t_btno = bt.t_btno "
			Sql = Sql & "where ir.t_ctyp = 'PTR' and ir.t_ninv = " & IRNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.VR.vrPaymentProcess)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrPaymentProcess(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
		End Function
	End Class
End Namespace
