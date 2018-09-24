Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSTCPOL
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
        Dim mRet As Boolean = True
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
    Public Shared Function UZ_pakSTCPOLInsert(ByVal Record As SIS.PAK.pakSTCPOL) As SIS.PAK.pakSTCPOL
      Dim _Result As SIS.PAK.pakSTCPOL = pakSTCPOLInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSTCPOLUpdate(ByVal Record As SIS.PAK.pakSTCPOL) As SIS.PAK.pakSTCPOL
      Dim _Result As SIS.PAK.pakSTCPOL = pakSTCPOLUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSTCPOLDelete(ByVal Record As SIS.PAK.pakSTCPOL) As Int32
      Dim _Result As Integer = pakTCPOLDelete(Record)
      Return _Result
    End Function
  End Class
End Namespace
