Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  Partial Public Class eitlSuppliers
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
    Public Shared Function UZ_eitlSuppliersInsert(ByVal Record As SIS.EITL.eitlSuppliers) As SIS.EITL.eitlSuppliers
      Dim _Result As SIS.EITL.eitlSuppliers = eitlSuppliersInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_eitlSuppliersUpdate(ByVal Record As SIS.EITL.eitlSuppliers) As SIS.EITL.eitlSuppliers
      Dim _Result As SIS.EITL.eitlSuppliers = eitlSuppliersUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_eitlSuppliersDelete(ByVal Record As SIS.EITL.eitlSuppliers) As Integer
      Dim _Result as Integer = eitlSuppliersDelete(Record)
      Return _Result
    End Function
  End Class
End Namespace
