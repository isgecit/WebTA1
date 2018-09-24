Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization


Partial Class GF_updEstimate
	Inherits SIS.SYS.GridBase


	Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
		Dim st As Long = HttpContext.Current.Server.ScriptTimeout
		HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
		Try
			With F_FileUpload
				If .HasFile Then
					Dim tmpPath As String = Server.MapPath("~/../App_Temp")
					Dim tmpName As String = IO.Path.GetRandomFileName()
					Dim tmpFile As String = tmpPath & "\\" & tmpName
					.SaveAs(tmpFile)
					Dim fi As FileInfo = New FileInfo(tmpFile)
					Dim ErrorInProcess As Boolean = False
					Using xlP As ExcelPackage = New ExcelPackage(fi)
						Dim wsD As ExcelWorksheet = Nothing
						Try
							Try
								wsD = xlP.Workbook.Worksheets("Estimate Detail Lines")
							Catch ex As Exception
								wsD = Nothing
							End Try
							If wsD Is Nothing Then
								errMsg.Text = "XL File does not have Estimate Detail Lines sheet, Invalid MS-EXCEL file."
								errMsg.Visible = True
								xlP.Dispose()
								Exit Sub
							End If
							Dim ProjectID As String = wsD.Cells(3, 12).Text
							Dim Version As String = wsD.Cells(4, 12).Text

							If ProjectID = String.Empty Or Version = String.Empty Then
								errMsg.Text = "Project ID or Version not found in XL."
								errMsg.Visible = True
								xlP.Dispose()
								Exit Sub
							End If
							'===============
							'For New Company
							If ProjectID.StartsWith("BS") Then
								eLine.Company = "700"
							Else
								eLine.Company = "200"
							End If
							'===============
							Dim tmpPO As New eLine

							Dim delText As String = eLine.DeleteEstimateLineByProject(ProjectID)

							If delText <> String.Empty Then
								errMsg.Text = delText
								errMsg.Visible = True
								xlP.Dispose()
								Exit Sub
							End If

							Dim Sern As Integer = 0
							Dim Err As String = ""
							For I As Integer = 10 To 99000
								Dim ElementID As String = wsD.Cells(I, 10).Text
								If ElementID = String.Empty Then Exit For
								Dim el As New eLine
								With el
									.t_quan = wsD.Cells(I, 17).Text									 'From XL	Quantity    
									If .t_quan = String.Empty Then
										Continue For
									End If
									.t_pric = wsD.Cells(I, 22).Text
									If .t_pric = String.Empty Then
										Continue For
									End If
									Sern += 10
									.t_cprj = ProjectID															 'From XL	Project     
									.t_vers = "001"																	 'Always	001         
									.t_sern = Sern																	 'From XL	Sequence    
									.t_ffno = eLine.GetFFNo() - 1										 'First Free No	    
									.t_dico = Now.ToString("dd/MM/yyyy HH:mm")			 '24/03/2017 10:17"			Uploaded Date	      
									.t_desa = .t_dico																 'Uploaded Date	      
									.t_psel = ElementID															 'From XL	Element     
									.t_cotp = IIf(ElementID.StartsWith("99"), "5", "2")		 'Values are 2 & 5 Ele starts with 99=5 Sundry Cost else 2=Material	  
									.t_quan = wsD.Cells(I, 17).Text									 'From XL	Quantity    
									.t_pric = (wsD.Cells(I, 22).Text) * 100000			 'From XL	Price       
									.t_rats = .t_pric																 'From XL	Price       
									.t_nspr = .t_pric																 'From XL	Pric    
									Try
										.t_asve_l = Math.Round(Convert.ToDecimal(.t_pric), 0)				 'From XL	Pric        
									Catch ex As Exception
										.t_asve_l = 0
										ErrorInProcess = True
										wsD.Cells(I, 46).Value = ex.Message
									End Try
									.t_asvv_l = .t_asve_l						'From XL	Pric        
									.t_asvs_l = .t_asve_l						'From XL	Pric        
									.t_easv_l = .t_pric							'From XL	Pric        
									.t_vasv_l = .t_pric							'From XL	Pric        
									.t_sasv_l = .t_pric							'From XL	Pric        
									.t_tave_l = .t_pric							'From XL	Pric        
									.t_tavv_l = .t_pric							'From XL	Pric        
									.t_tavs_l = .t_pric							'From XL	Pric    
									Try
										.t_cosa = Math.Round(Convert.ToDecimal(.t_quan) * Convert.ToDecimal(.t_pric), 2)			 't_quan * t_pric	  
									Catch ex As Exception
										.t_cosa = 0
										ErrorInProcess = True
										wsD.Cells(I, 47).Value = ex.Message
									End Try
									.t_lcos = .t_cosa								't_quan * t_pric	  
									.t_gsam = .t_cosa								't_quan * t_pric	  
									.t_nsam = .t_cosa								't_quan * t_pric	  
									.t_unit = wsD.Cells(I, 16).Text							'From XL	can be blank
									.t_unrt = .t_unit								'From XL	can be blank
								End With
								Try
									Err = eLine.InsertData(el)
								Catch ex As Exception
									ErrorInProcess = True
									wsD.Cells(I, 45).Value = ex.Message
								End Try
							Next
						Catch ex As Exception
							Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
							Dim script As String = String.Format("alert({0});", message)
							ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
						End Try
						xlP.Save()
						wsD.Dispose()
						xlP.Dispose()
						If ErrorInProcess Then
							errMsg.Text = "There are error during Upload Process"
							errMsg.Visible = True
						End If
					End Using
					Dim FileNameForUser As String = F_FileUpload.FileName
					'======================
					Response.Clear()
					Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
					Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
					Response.WriteFile(tmpFile)
					HttpContext.Current.Server.ScriptTimeout = st
					Response.End()
				End If
			End With
		Catch ex As Exception
			Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
			Dim script As String = String.Format("alert({0});", message)
			ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
		End Try
over:
	End Sub

	Public Class eLine

		Public Shared Function GetFFNo() As String
			Dim ffno As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select t_ffno as cnt from ttcmcs050" & Company & " where t_nrgr='002' and t_seri='101'"
          Con.Open()
          ffno = Cmd.ExecuteScalar
        End Using
        ffno = Convert.ToInt32(ffno) + 1
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "update ttcmcs050" & Company & " set t_ffno=" & ffno & " where t_nrgr='002' and t_seri='101'"
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return ffno
    End Function
    Public Shared Function GetEstimateLineByID(ByVal ProjectID As String, ByVal Sern As String, ByVal FfNo As String) As eLine
      Dim mSql As String = ""
      mSql = mSql & " select TOP 1 * "
      mSql = mSql & " from ttpest200" & Company & " "
      mSql = mSql & " where t_cprj = '" & ProjectID & "'"
      mSql = mSql & " and   t_vers = '001'"
      mSql = mSql & " and   t_sern = " & Sern
      mSql = mSql & " and   t_ffno = " & FfNo

      Dim Results As eLine = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = mSql
          Results = New eLine
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results = New eLine(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function DeleteEstimateLineByProject(ByVal ProjectID As String) As String
      Dim mSql As String = ""
      mSql = mSql & " Delete "
      mSql = mSql & " from ttpest200" & Company & " "
      mSql = mSql & " where t_cprj = '" & ProjectID & "'"
      mSql = mSql & " and   t_vers = '001'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Try
            Cmd.ExecuteReader()
          Catch ex As Exception
            Return ex.Message
          End Try
        End Using
      End Using
      Return ""
    End Function
    Public Shared Function InsertData(ByVal eL As eLine) As String
      Dim Sql As String = ""
      Sql &= "Insert Into ttpest200200 "
      Sql &= "(t_cprj,t_vers,t_sern,t_ffno,t_dico,t_desa,t_cotp,t_psel,t_quan,t_pric,t_rats,t_nspr,t_asve_l,t_asvv_l,t_asvs_l,t_easv_l,t_vasv_l,t_sasv_l,t_tave_l,t_tavv_l,t_tavs_l,t_cosa,t_lcos,t_gsam,t_nsam,t_unit,t_unrt,t_etyp,t_levl,t_udst,t_item,t_cequ,t_desc,t_stat,t_isco,t_icos,t_isal,t_cspt,t_scpf,t_adjf,t_norm,t_prat,t_clrt,t_curr,t_dfpc,t_rtcc_1,t_rtcc_2,t_rtcc_3,t_rtfc_1,t_rtfc_2,t_rtfc_3,t_sper,t_sura,t_esca,t_cona,t_mper,t_mara,t_scur,t_fspr,t_rtcs_1,t_rtcs_2,t_rtcs_3,t_rtfs_1,t_rtfs_2,t_rtfs_3,t_dper,t_disa,t_asta,t_astb,t_astc,t_astd,t_aste,t_astf,t_astg,t_ssel,t_laun,t_cpva,t_ocpr,t_ospr,t_prim,t_exbc_1,t_exbc_2,t_exbc_3,t_exbs_1,t_exbs_2,t_exbs_3,t_cvat_l,t_cltx_l,t_extx_l,t_stmt_l,t_cch1_l,t_ccp1_l,t_cch2_l,t_ccp2_l,t_cch3_l,t_ccp3_l,t_cch4_l,t_ccp4_l,t_octr_l,t_ocpr_l,t_otbp,t_txta,t_Refcntd,t_Refcntu)"
      Sql &= " Values('" & eL.t_cprj & "','" & eL.t_vers & "','" & eL.t_sern & "','" & eL.t_ffno & "',Convert(DateTime,'" & eL.t_dico & "',103),Convert(DateTime,'" & eL.t_desa & "',103),'" & eL.t_cotp & "','" & eL.t_psel & "','" & eL.t_quan & "','" & eL.t_pric & "','" & eL.t_rats & "','" & eL.t_nspr & "','" & eL.t_asve_l & "','" & eL.t_asvv_l & "','" & eL.t_asvs_l & "','" & eL.t_easv_l & "','" & eL.t_vasv_l & "','" & eL.t_sasv_l & "','" & eL.t_tave_l & "','" & eL.t_tavv_l & "','" & eL.t_tavs_l & "','" & eL.t_cosa & "','" & eL.t_lcos & "','" & eL.t_gsam & "','" & eL.t_nsam & "','" & eL.t_unit & "','" & eL.t_unrt & "','" & eL.t_etyp & "','" & eL.t_levl & "','" & eL.t_udst & "','" & eL.t_item & "','" & eL.t_cequ & "','" & eL.t_desc & "','" & eL.t_stat & "','" & eL.t_isco & "','" & eL.t_icos & "','" & eL.t_isal & "','" & eL.t_cspt & "','" & eL.t_scpf & "','" & eL.t_adjf & "','" & eL.t_norm & "','" & eL.t_prat & "','" & eL.t_clrt & "','" & eL.t_curr & "','" & eL.t_dfpc & "','" & eL.t_rtcc_1 & "','" & eL.t_rtcc_2 & "','" & eL.t_rtcc_3 & "','" & eL.t_rtfc_1 & "','" & eL.t_rtfc_2 & "','" & eL.t_rtfc_3 & "','" & eL.t_sper & "','" & eL.t_sura & "','" & eL.t_esca & "','" & eL.t_cona & "','" & eL.t_mper & "','" & eL.t_mara & "','" & eL.t_scur & "','" & eL.t_fspr & "','" & eL.t_rtcs_1 & "','" & eL.t_rtcs_2 & "','" & eL.t_rtcs_3 & "','" & eL.t_rtfs_1 & "','" & eL.t_rtfs_2 & "','" & eL.t_rtfs_3 & "','" & eL.t_dper & "','" & eL.t_disa & "','" & eL.t_asta & "','" & eL.t_astb & "','" & eL.t_astc & "','" & eL.t_astd & "','" & eL.t_aste & "','" & eL.t_astf & "','" & eL.t_astg & "','" & eL.t_ssel & "','" & eL.t_laun & "','" & eL.t_cpva & "','" & eL.t_ocpr & "','" & eL.t_ospr & "','" & eL.t_prim & "','" & eL.t_exbc_1 & "','" & eL.t_exbc_2 & "','" & eL.t_exbc_3 & "','" & eL.t_exbs_1 & "','" & eL.t_exbs_2 & "','" & eL.t_exbs_3 & "','" & eL.t_cvat_l & "','" & eL.t_cltx_l & "','" & eL.t_extx_l & "','" & eL.t_stmt_l & "','" & eL.t_cch1_l & "','" & eL.t_ccp1_l & "','" & eL.t_cch2_l & "','" & eL.t_ccp2_l & "','" & eL.t_cch3_l & "','" & eL.t_ccp3_l & "','" & eL.t_cch4_l & "','" & eL.t_ccp4_l & "','" & eL.t_octr_l & "','" & eL.t_ocpr_l & "','" & eL.t_otbp & "','" & eL.t_txta & "','" & eL.t_Refcntd & "','" & eL.t_Refcntu & "')"

      Dim Err As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Err
    End Function
    Public Shared Function GetEstimateLineByProject(ByVal ProjectID As String) As List(Of eLine)
      Dim mSql As String = ""
      mSql = mSql & " select * "
      mSql = mSql & " from ttpest200" & Company & " "
      mSql = mSql & " where t_cprj = '" & ProjectID & "'"
      mSql = mSql & " and   t_vers = '001'"

      Dim Results As List(Of eLine) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = mSql
          Results = New List(Of eLine)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New eLine(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
		End Function
		Private Shared _Company As String = "200"
		Public Shared Property Company() As String
			Get
				Return _Company
			End Get
			Set(ByVal value As String)
				_Company = value
			End Set
		End Property

		Private _t_cprj As String = "JB0993"						 'From XL	Project     
		Private _t_vers As String = "1"									 'Always	001         
		Private _t_sern As String = "20"								 'From XL	Sequence    
		Private _t_ffno As String = "101070912"					 'First Free No	    
		Private _t_dico As String = "24/03/2017 10:17"	 'Uploaded Date	      
		Private _t_desa As String = "24/03/2017 10:17"	 'Uploaded Date	      
		Private _t_cotp As String = "2"									 'Values are 2 & 5 Ele starts with 99=5 Sundry Cost else 2=Material	  
		Private _t_psel As String = "50010100"					 'From XL	Element     
		Private _t_quan As String = "23.16848536"				 'From XL	Quantity    
		Private _t_pric As String = "214580"						 'From XL	Price       
		Private _t_rats As String = "214580.0001"				 'From XL	Price       
		Private _t_nspr As String = "214580.0001"				 'From XL	Pric        
		Private _t_asve_l As String = "214580"					 'From XL	Pric        
		Private _t_asvv_l As String = "214580"					 'From XL	Pric        
		Private _t_asvs_l As String = "214580"					 'From XL	Pric        
		Private _t_easv_l As String = "214580.0001"			 'From XL	Pric        
		Private _t_vasv_l As String = "214580.0001"			 'From XL	Pric        
		Private _t_sasv_l As String = "214580.0001"			 'From XL	Pric        
		Private _t_tave_l As String = "214580"					 'From XL	Pric        
		Private _t_tavv_l As String = "214580"					 'From XL	Pric        
		Private _t_tavs_l As String = "214580"					 'From XL	Pric        
		Private _t_cosa As String = "4971493.59"				 't_quan * t_pric	  
		Private _t_lcos As String = "4971493.59"				 't_quan * t_pric	  
		Private _t_gsam As String = "4971493.59"				 't_quan * t_pric	  
		Private _t_nsam As String = "4971493.59"				 't_quan * t_pric	  
		Private _t_unit As String = "mt"								 'From XL	can be blank
		Private _t_unrt As String = "mt"								 'From XL	can be blank

		Private _t_etyp As String = "2"									 'Always	            
		Private _t_levl As String = "4"									 'Always	            
		Private _t_udst As String = ""									 'Always	            
		Private _t_item As String = ""									 'Always	            
		Private _t_cequ As String = ""									 'Always	            
		Private _t_desc As String = ""									 'Always	            
		Private _t_stat As String = "1"									 'Always	            
		Private _t_isco As String = "1"									 'Always	            
		Private _t_icos As String = "1"									 'Always	            
		Private _t_isal As String = "1"									 'Always	            
		Private _t_cspt As String = "1"									 'Always	            
		Private _t_scpf As String = "0"									 'Always	            
		Private _t_adjf As String = "1"									 'Always	            
		Private _t_norm As String = "1"									 'Always	            
		Private _t_prat As String = "1"									 'Always	            
		Private _t_clrt As String = ""									 'Always	            
		Private _t_curr As String = "INR"								 'Always	            
		Private _t_dfpc As String = "2"									 'Always	            
		Private _t_rtcc_1 As String = "1"								 'Always	            
		Private _t_rtcc_2 As String = "0.000001"				 'Always	            
		Private _t_rtcc_3 As String = "0.000001"				 'Always	            
		Private _t_rtfc_1 As String = "1"								 'Always	            
		Private _t_rtfc_2 As String = "1"								 'Always	            
		Private _t_rtfc_3 As String = "1"								 'Always	            
		Private _t_sper As String = "0"									 'Always	            
		Private _t_sura As String = "0"									 'Always	            
		Private _t_esca As String = "0"									 'Always	            
		Private _t_cona As String = "0"									 'Always	            
		Private _t_mper As String = "0"									 'Always	            
		Private _t_mara As String = "0"									 'Always	            
		Private _t_scur As String = "INR"								 'Always	            
		Private _t_fspr As String = "2"									 'Always	            
		Private _t_rtcs_1 As String = "1"								 'Always	            
		Private _t_rtcs_2 As String = "0.000001"				 'Always	            
		Private _t_rtcs_3 As String = "0.000001"				 'Always	            
		Private _t_rtfs_1 As String = "1"								 'Always	            
		Private _t_rtfs_2 As String = "1"								 'Always	            
		Private _t_rtfs_3 As String = "1"								 'Always	            
		Private _t_dper As String = "0"									 'Always	            
		Private _t_disa As String = "0"									 'Always	            
		Private _t_asta As String = ""									 'Always	            
		Private _t_astb As String = ""									 'Always	            
		Private _t_astc As String = ""									 'Always	            
		Private _t_astd As String = ""									 'Always	            
		Private _t_aste As String = ""									 'Always	            
		Private _t_astf As String = ""									 'Always	            
		Private _t_astg As String = ""									 'Always	            
		Private _t_ssel As String = ""									 'Always	            
		Private _t_laun As String = "2"									 'Always	            
		Private _t_cpva As String = "0"									 'Always	            
		Private _t_ocpr As String = "1"									 'Always	            
		Private _t_ospr As String = "1"									 'Always	            
		Private _t_prim As String = "1"									 'Always	            
		Private _t_exbc_1 As String = "1"								 'Always	            
		Private _t_exbc_2 As String = "2"								 'Always	            
		Private _t_exbc_3 As String = "2"								 'Always	            
		Private _t_exbs_1 As String = "1"								 'Always	            
		Private _t_exbs_2 As String = "2"								 'Always	            
		Private _t_exbs_3 As String = "2"								 'Always	            
		Private _t_cvat_l As String = ""								 'Always	            
		Private _t_cltx_l As String = "0"								 'Always	            
		Private _t_extx_l As String = "0"								 'Always	            
		Private _t_stmt_l As String = "0"								 'Always	            
		Private _t_cch1_l As String = ""								 'Always	            
		Private _t_ccp1_l As String = "0"								 'Always	            
		Private _t_cch2_l As String = ""								 'Always	            
		Private _t_ccp2_l As String = "0"								 'Always	            
		Private _t_cch3_l As String = ""								 'Always	            
		Private _t_ccp3_l As String = "0"								 'Always	            
		Private _t_cch4_l As String = ""								 'Always	            
		Private _t_ccp4_l As String = "0"								 'Always	            
		Private _t_octr_l As String = ""								 'Always	            
		Private _t_ocpr_l As String = "0"								 'Always	            
		Private _t_otbp As String = ""									 'Always	            
		Private _t_txta As String = "0"									 'Always	            
		Private _t_Refcntd As String = "0"							 'Always	            
		Private _t_Refcntu As String = "0"							 'Always	     
		Public Property t_cotp() As String
			Get
				Return _t_cotp
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(_t_psel) Then
					_t_cotp = Value
				Else
					_t_cotp = ""
				End If
			End Set
		End Property

		Public Property t_cprj() As String
			Get
				Return _t_cprj
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cprj = Value
				Else
					_t_cprj = ""
				End If
			End Set
		End Property
		Public Property t_vers() As String
			Get
				Return _t_vers
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_vers = Value
				Else
					_t_vers = ""
				End If
			End Set
		End Property


		Public Property t_sern() As String
			Get
				Return _t_sern
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_sern = Value
				Else
					_t_sern = ""
				End If
			End Set
		End Property


		Public Property t_dico() As String
			Get
				Return _t_dico
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_dico = Value
				Else
					_t_dico = ""
				End If
			End Set
		End Property


		Public Property t_desa() As String
			Get
				Return _t_desa
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_desa = Value
				Else
					_t_desa = ""
				End If
			End Set
		End Property




		Public Property t_psel() As String
			Get
				Return _t_psel
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_psel = Value
				Else
					_t_psel = ""
				End If
			End Set
		End Property


		Public Property t_quan() As String
			Get
				Return _t_quan
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_quan = Value
				Else
					_t_quan = ""
				End If
			End Set
		End Property


		Public Property t_pric() As String
			Get
				Return _t_pric
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_pric = Value
				Else
					_t_pric = ""
				End If
			End Set
		End Property


		Public Property t_rats() As String
			Get
				Return _t_rats
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rats = Value
				Else
					_t_rats = ""
				End If
			End Set
		End Property


		Public Property t_nspr() As String
			Get
				Return _t_nspr
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_nspr = Value
				Else
					_t_nspr = ""
				End If
			End Set
		End Property


		Public Property t_asve_l() As String
			Get
				Return _t_asve_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_asve_l = Value
				Else
					_t_asve_l = ""
				End If
			End Set
		End Property


		Public Property t_asvv_l() As String
			Get
				Return _t_asvv_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_asvv_l = Value
				Else
					_t_asvv_l = ""
				End If
			End Set
		End Property


		Public Property t_asvs_l() As String
			Get
				Return _t_asvs_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_asvs_l = Value
				Else
					_t_asvs_l = ""
				End If
			End Set
		End Property


		Public Property t_easv_l() As String
			Get
				Return _t_easv_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_easv_l = Value
				Else
					_t_easv_l = ""
				End If
			End Set
		End Property


		Public Property t_vasv_l() As String
			Get
				Return _t_vasv_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_vasv_l = Value
				Else
					_t_vasv_l = ""
				End If
			End Set
		End Property


		Public Property t_sasv_l() As String
			Get
				Return _t_sasv_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_sasv_l = Value
				Else
					_t_sasv_l = ""
				End If
			End Set
		End Property


		Public Property t_tave_l() As String
			Get
				Return _t_tave_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_tave_l = Value
				Else
					_t_tave_l = ""
				End If
			End Set
		End Property


		Public Property t_tavv_l() As String
			Get
				Return _t_tavv_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_tavv_l = Value
				Else
					_t_tavv_l = ""
				End If
			End Set
		End Property


		Public Property t_tavs_l() As String
			Get
				Return _t_tavs_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_tavs_l = Value
				Else
					_t_tavs_l = ""
				End If
			End Set
		End Property


		Public Property t_cosa() As String
			Get
				Return _t_cosa
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cosa = Value
				Else
					_t_cosa = ""
				End If
			End Set
		End Property


		Public Property t_lcos() As String
			Get
				Return _t_lcos
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_lcos = Value
				Else
					_t_lcos = ""
				End If
			End Set
		End Property


		Public Property t_gsam() As String
			Get
				Return _t_gsam
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_gsam = Value
				Else
					_t_gsam = ""
				End If
			End Set
		End Property


		Public Property t_nsam() As String
			Get
				Return _t_nsam
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_nsam = Value
				Else
					_t_nsam = ""
				End If
			End Set
		End Property


		Public Property t_ffno() As String
			Get
				Return _t_ffno
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ffno = Value
				Else
					_t_ffno = ""
				End If
			End Set
		End Property


		Public Property t_unit() As String
			Get
				Return _t_unit
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_unit = Value
				Else
					_t_unit = ""
				End If
			End Set
		End Property


		Public Property t_unrt() As String
			Get
				Return _t_unrt
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_unrt = Value
				Else
					_t_unrt = ""
				End If
			End Set
		End Property


		Public Property t_etyp() As String
			Get
				Return _t_etyp
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_etyp = Value
				Else
					_t_etyp = ""
				End If
			End Set
		End Property


		Public Property t_levl() As String
			Get
				Return _t_levl
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_levl = Value
				Else
					_t_levl = ""
				End If
			End Set
		End Property


		Public Property t_udst() As String
			Get
				Return _t_udst
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_udst = Value
				Else
					_t_udst = ""
				End If
			End Set
		End Property


		Public Property t_item() As String
			Get
				Return _t_item
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_item = Value
				Else
					_t_item = ""
				End If
			End Set
		End Property


		Public Property t_cequ() As String
			Get
				Return _t_cequ
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cequ = Value
				Else
					_t_cequ = ""
				End If
			End Set
		End Property


		Public Property t_desc() As String
			Get
				Return _t_desc
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_desc = Value
				Else
					_t_desc = ""
				End If
			End Set
		End Property


		Public Property t_stat() As String
			Get
				Return _t_stat
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_stat = Value
				Else
					_t_stat = ""
				End If
			End Set
		End Property


		Public Property t_isco() As String
			Get
				Return _t_isco
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_isco = Value
				Else
					_t_isco = ""
				End If
			End Set
		End Property


		Public Property t_icos() As String
			Get
				Return _t_icos
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_icos = Value
				Else
					_t_icos = ""
				End If
			End Set
		End Property


		Public Property t_isal() As String
			Get
				Return _t_isal
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_isal = Value
				Else
					_t_isal = ""
				End If
			End Set
		End Property


		Public Property t_cspt() As String
			Get
				Return _t_cspt
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cspt = Value
				Else
					_t_cspt = ""
				End If
			End Set
		End Property


		Public Property t_scpf() As String
			Get
				Return _t_scpf
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_scpf = Value
				Else
					_t_scpf = ""
				End If
			End Set
		End Property


		Public Property t_adjf() As String
			Get
				Return _t_adjf
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_adjf = Value
				Else
					_t_adjf = ""
				End If
			End Set
		End Property


		Public Property t_norm() As String
			Get
				Return _t_norm
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_norm = Value
				Else
					_t_norm = ""
				End If
			End Set
		End Property


		Public Property t_prat() As String
			Get
				Return _t_prat
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_prat = Value
				Else
					_t_prat = ""
				End If
			End Set
		End Property


		Public Property t_clrt() As String
			Get
				Return _t_clrt
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_clrt = Value
				Else
					_t_clrt = ""
				End If
			End Set
		End Property


		Public Property t_curr() As String
			Get
				Return _t_curr
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_curr = Value
				Else
					_t_curr = ""
				End If
			End Set
		End Property


		Public Property t_dfpc() As String
			Get
				Return _t_dfpc
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_dfpc = Value
				Else
					_t_dfpc = ""
				End If
			End Set
		End Property


		Public Property t_rtcc_1() As String
			Get
				Return _t_rtcc_1
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtcc_1 = Value
				Else
					_t_rtcc_1 = ""
				End If
			End Set
		End Property


		Public Property t_rtcc_2() As String
			Get
				Return _t_rtcc_2
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtcc_2 = Value
				Else
					_t_rtcc_2 = ""
				End If
			End Set
		End Property


		Public Property t_rtcc_3() As String
			Get
				Return _t_rtcc_3
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtcc_3 = Value
				Else
					_t_rtcc_3 = ""
				End If
			End Set
		End Property


		Public Property t_rtfc_1() As String
			Get
				Return _t_rtfc_1
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtfc_1 = Value
				Else
					_t_rtfc_1 = ""
				End If
			End Set
		End Property


		Public Property t_rtfc_2() As String
			Get
				Return _t_rtfc_2
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtfc_2 = Value
				Else
					_t_rtfc_2 = ""
				End If
			End Set
		End Property


		Public Property t_rtfc_3() As String
			Get
				Return _t_rtfc_3
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtfc_3 = Value
				Else
					_t_rtfc_3 = ""
				End If
			End Set
		End Property


		Public Property t_sper() As String
			Get
				Return _t_sper
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_sper = Value
				Else
					_t_sper = ""
				End If
			End Set
		End Property


		Public Property t_sura() As String
			Get
				Return _t_sura
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_sura = Value
				Else
					_t_sura = ""
				End If
			End Set
		End Property


		Public Property t_esca() As String
			Get
				Return _t_esca
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_esca = Value
				Else
					_t_esca = ""
				End If
			End Set
		End Property


		Public Property t_cona() As String
			Get
				Return _t_cona
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cona = Value
				Else
					_t_cona = ""
				End If
			End Set
		End Property


		Public Property t_mper() As String
			Get
				Return _t_mper
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_mper = Value
				Else
					_t_mper = ""
				End If
			End Set
		End Property


		Public Property t_mara() As String
			Get
				Return _t_mara
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_mara = Value
				Else
					_t_mara = ""
				End If
			End Set
		End Property


		Public Property t_scur() As String
			Get
				Return _t_scur
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_scur = Value
				Else
					_t_scur = ""
				End If
			End Set
		End Property


		Public Property t_fspr() As String
			Get
				Return _t_fspr
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_fspr = Value
				Else
					_t_fspr = ""
				End If
			End Set
		End Property


		Public Property t_rtcs_1() As String
			Get
				Return _t_rtcs_1
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtcs_1 = Value
				Else
					_t_rtcs_1 = ""
				End If
			End Set
		End Property


		Public Property t_rtcs_2() As String
			Get
				Return _t_rtcs_2
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtcs_2 = Value
				Else
					_t_rtcs_2 = ""
				End If
			End Set
		End Property


		Public Property t_rtcs_3() As String
			Get
				Return _t_rtcs_3
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtcs_3 = Value
				Else
					_t_rtcs_3 = ""
				End If
			End Set
		End Property


		Public Property t_rtfs_1() As String
			Get
				Return _t_rtfs_1
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtfs_1 = Value
				Else
					_t_rtfs_1 = ""
				End If
			End Set
		End Property


		Public Property t_rtfs_2() As String
			Get
				Return _t_rtfs_2
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtfs_2 = Value
				Else
					_t_rtfs_2 = ""
				End If
			End Set
		End Property


		Public Property t_rtfs_3() As String
			Get
				Return _t_rtfs_3
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_rtfs_3 = Value
				Else
					_t_rtfs_3 = ""
				End If
			End Set
		End Property


		Public Property t_dper() As String
			Get
				Return _t_dper
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_dper = Value
				Else
					_t_dper = ""
				End If
			End Set
		End Property


		Public Property t_disa() As String
			Get
				Return _t_disa
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_disa = Value
				Else
					_t_disa = ""
				End If
			End Set
		End Property


		Public Property t_asta() As String
			Get
				Return _t_asta
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_asta = Value
				Else
					_t_asta = ""
				End If
			End Set
		End Property


		Public Property t_astb() As String
			Get
				Return _t_astb
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_astb = Value
				Else
					_t_astb = ""
				End If
			End Set
		End Property


		Public Property t_astc() As String
			Get
				Return _t_astc
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_astc = Value
				Else
					_t_astc = ""
				End If
			End Set
		End Property


		Public Property t_astd() As String
			Get
				Return _t_astd
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_astd = Value
				Else
					_t_astd = ""
				End If
			End Set
		End Property


		Public Property t_aste() As String
			Get
				Return _t_aste
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_aste = Value
				Else
					_t_aste = ""
				End If
			End Set
		End Property


		Public Property t_astf() As String
			Get
				Return _t_astf
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_astf = Value
				Else
					_t_astf = ""
				End If
			End Set
		End Property


		Public Property t_astg() As String
			Get
				Return _t_astg
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_astg = Value
				Else
					_t_astg = ""
				End If
			End Set
		End Property


		Public Property t_ssel() As String
			Get
				Return _t_ssel
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ssel = Value
				Else
					_t_ssel = ""
				End If
			End Set
		End Property


		Public Property t_laun() As String
			Get
				Return _t_laun
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_laun = Value
				Else
					_t_laun = ""
				End If
			End Set
		End Property


		Public Property t_cpva() As String
			Get
				Return _t_cpva
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cpva = Value
				Else
					_t_cpva = ""
				End If
			End Set
		End Property


		Public Property t_ocpr() As String
			Get
				Return _t_ocpr
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ocpr = Value
				Else
					_t_ocpr = ""
				End If
			End Set
		End Property


		Public Property t_ospr() As String
			Get
				Return _t_ospr
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ospr = Value
				Else
					_t_ospr = ""
				End If
			End Set
		End Property


		Public Property t_prim() As String
			Get
				Return _t_prim
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_prim = Value
				Else
					_t_prim = ""
				End If
			End Set
		End Property


		Public Property t_exbc_1() As String
			Get
				Return _t_exbc_1
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_exbc_1 = Value
				Else
					_t_exbc_1 = ""
				End If
			End Set
		End Property


		Public Property t_exbc_2() As String
			Get
				Return _t_exbc_2
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_exbc_2 = Value
				Else
					_t_exbc_2 = ""
				End If
			End Set
		End Property


		Public Property t_exbc_3() As String
			Get
				Return _t_exbc_3
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_exbc_3 = Value
				Else
					_t_exbc_3 = ""
				End If
			End Set
		End Property


		Public Property t_exbs_1() As String
			Get
				Return _t_exbs_1
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_exbs_1 = Value
				Else
					_t_exbs_1 = ""
				End If
			End Set
		End Property


		Public Property t_exbs_2() As String
			Get
				Return _t_exbs_2
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_exbs_2 = Value
				Else
					_t_exbs_2 = ""
				End If
			End Set
		End Property


		Public Property t_exbs_3() As String
			Get
				Return _t_exbs_3
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_exbs_3 = Value
				Else
					_t_exbs_3 = ""
				End If
			End Set
		End Property


		Public Property t_cvat_l() As String
			Get
				Return _t_cvat_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cvat_l = Value
				Else
					_t_cvat_l = ""
				End If
			End Set
		End Property


		Public Property t_cltx_l() As String
			Get
				Return _t_cltx_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cltx_l = Value
				Else
					_t_cltx_l = ""
				End If
			End Set
		End Property


		Public Property t_extx_l() As String
			Get
				Return _t_extx_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_extx_l = Value
				Else
					_t_extx_l = ""
				End If
			End Set
		End Property


		Public Property t_stmt_l() As String
			Get
				Return _t_stmt_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_stmt_l = Value
				Else
					_t_stmt_l = ""
				End If
			End Set
		End Property


		Public Property t_cch1_l() As String
			Get
				Return _t_cch1_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cch1_l = Value
				Else
					_t_cch1_l = ""
				End If
			End Set
		End Property


		Public Property t_ccp1_l() As String
			Get
				Return _t_ccp1_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ccp1_l = Value
				Else
					_t_ccp1_l = ""
				End If
			End Set
		End Property


		Public Property t_cch2_l() As String
			Get
				Return _t_cch2_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cch2_l = Value
				Else
					_t_cch2_l = ""
				End If
			End Set
		End Property


		Public Property t_ccp2_l() As String
			Get
				Return _t_ccp2_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ccp2_l = Value
				Else
					_t_ccp2_l = ""
				End If
			End Set
		End Property


		Public Property t_cch3_l() As String
			Get
				Return _t_cch3_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cch3_l = Value
				Else
					_t_cch3_l = ""
				End If
			End Set
		End Property


		Public Property t_ccp3_l() As String
			Get
				Return _t_ccp3_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ccp3_l = Value
				Else
					_t_ccp3_l = ""
				End If
			End Set
		End Property


		Public Property t_cch4_l() As String
			Get
				Return _t_cch4_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_cch4_l = Value
				Else
					_t_cch4_l = ""
				End If
			End Set
		End Property


		Public Property t_ccp4_l() As String
			Get
				Return _t_ccp4_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ccp4_l = Value
				Else
					_t_ccp4_l = ""
				End If
			End Set
		End Property


		Public Property t_octr_l() As String
			Get
				Return _t_octr_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_octr_l = Value
				Else
					_t_octr_l = ""
				End If
			End Set
		End Property


		Public Property t_ocpr_l() As String
			Get
				Return _t_ocpr_l
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_ocpr_l = Value
				Else
					_t_ocpr_l = ""
				End If
			End Set
		End Property


		Public Property t_otbp() As String
			Get
				Return _t_otbp
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_otbp = Value
				Else
					_t_otbp = ""
				End If
			End Set
		End Property


		Public Property t_txta() As String
			Get
				Return _t_txta
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_txta = Value
				Else
					_t_txta = ""
				End If
			End Set
		End Property


		Public Property t_Refcntd() As String
			Get
				Return _t_Refcntd
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_Refcntd = Value
				Else
					_t_Refcntd = ""
				End If
			End Set
		End Property


		Public Property t_Refcntu() As String
			Get
				Return _t_Refcntu
			End Get
			Set(ByVal Value As String)
				If Not Convert.IsDBNull(Value) Then
					_t_Refcntu = Value
				Else
					_t_Refcntu = ""
				End If
			End Set
		End Property









		Public Sub New(ByVal Reader As SqlDataReader)
			Try
				For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
					If pi.MemberType = Reflection.MemberTypes.Property Then
						Try
							If Convert.IsDBNull(Reader(pi.Name)) Then
								CallByName(Me, pi.Name, CallType.Let, String.Empty)
							Else
								CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
							End If
						Catch ex As Exception
						End Try
					End If
				Next
			Catch ex As Exception
			End Try
		End Sub
		Public Sub New()
		End Sub

	End Class

	Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
		If errMsg.Text <> String.Empty Then
			errMsg.Visible = True
		End If
	End Sub
End Class

'Sql = "Update ttpest200200 set "
'Sql &= "	 t_cprj   ='" & eL.t_cprj & "'"
'Sql &= "	,t_vers   ='" & eL.t_vers & "'"
'Sql &= "	,t_sern   ='" & eL.t_sern & "'"
'Sql &= "	,t_ffno   ='" & eL.t_ffno & "'"
'Sql &= "	,t_dico   ='" & eL.t_dico & "'"
'Sql &= "	,t_desa   ='" & eL.t_desa & "'"
'Sql &= "	,t_cotp   ='" & eL.t_cotp & "'"
'Sql &= "	,t_psel   ='" & eL.t_psel & "'"
'Sql &= "	,t_quan   ='" & eL.t_quan & "'"
'Sql &= "	,t_pric   ='" & eL.t_pric & "'"
'Sql &= "	,t_rats   ='" & eL.t_rats & "'"
'Sql &= "	,t_nspr   ='" & eL.t_nspr & "'"
'Sql &= "	,t_asve_l ='" & eL.t_asve_l & "'"
'Sql &= "	,t_asvv_l ='" & eL.t_asvv_l & "'"
'Sql &= "	,t_asvs_l ='" & eL.t_asvs_l & "'"
'Sql &= "	,t_easv_l ='" & eL.t_easv_l & "'"
'Sql &= "	,t_vasv_l ='" & eL.t_vasv_l & "'"
'Sql &= "	,t_sasv_l ='" & eL.t_sasv_l & "'"
'Sql &= "	,t_tave_l ='" & eL.t_tave_l & "'"
'Sql &= "	,t_tavv_l ='" & eL.t_tavv_l & "'"
'Sql &= "	,t_tavs_l ='" & eL.t_tavs_l & "'"
'Sql &= "	,t_cosa   ='" & eL.t_cosa & "'"
'Sql &= "	,t_lcos   ='" & eL.t_lcos & "'"
'Sql &= "	,t_gsam   ='" & eL.t_gsam & "'"
'Sql &= "	,t_nsam   ='" & eL.t_nsam & "'"
'Sql &= "	,t_unit   ='" & eL.t_unit & "'"
'Sql &= "	,t_unrt   ='" & eL.t_unrt & "'"
'Sql &= "	,t_etyp   ='" & eL.t_etyp & "'"
'Sql &= "	,t_levl   ='" & eL.t_levl & "'"
'Sql &= "	,t_udst   ='" & eL.t_udst & "'"
'Sql &= "	,t_item   ='" & eL.t_item & "'"
'Sql &= "	,t_cequ   ='" & eL.t_cequ & "'"
'Sql &= "	,t_desc   ='" & eL.t_desc & "'"
'Sql &= "	,t_stat   ='" & eL.t_stat & "'"
'Sql &= "	,t_isco   ='" & eL.t_isco & "'"
'Sql &= "	,t_icos   ='" & eL.t_icos & "'"
'Sql &= "	,t_isal   ='" & eL.t_isal & "'"
'Sql &= "	,t_cspt   ='" & eL.t_cspt & "'"
'Sql &= "	,t_scpf   ='" & eL.t_scpf & "'"
'Sql &= "	,t_adjf   ='" & eL.t_adjf & "'"
'Sql &= "	,t_norm   ='" & eL.t_norm & "'"
'Sql &= "	,t_prat   ='" & eL.t_prat & "'"
'Sql &= "	,t_clrt   ='" & eL.t_clrt & "'"
'Sql &= "	,t_curr   ='" & eL.t_curr & "'"
'Sql &= "	,t_dfpc   ='" & eL.t_dfpc & "'"
'Sql &= "	,t_rtcc_1 ='" & eL.t_rtcc_1 & "'"
'Sql &= "	,t_rtcc_2 ='" & eL.t_rtcc_2 & "'"
'Sql &= "	,t_rtcc_3 ='" & eL.t_rtcc_3 & "'"
'Sql &= "	,t_rtfc_1 ='" & eL.t_rtfc_1 & "'"
'Sql &= "	,t_rtfc_2 ='" & eL.t_rtfc_2 & "'"
'Sql &= "	,t_rtfc_3 ='" & eL.t_rtfc_3 & "'"
'Sql &= "	,t_sper   ='" & eL.t_sper & "'"
'Sql &= "	,t_sura   ='" & eL.t_sura & "'"
'Sql &= "	,t_esca   ='" & eL.t_esca & "'"
'Sql &= "	,t_cona   ='" & eL.t_cona & "'"
'Sql &= "	,t_mper   ='" & eL.t_mper & "'"
'Sql &= "	,t_mara   ='" & eL.t_mara & "'"
'Sql &= "	,t_scur   ='" & eL.t_scur & "'"
'Sql &= "	,t_fspr   ='" & eL.t_fspr & "'"
'Sql &= "	,t_rtcs_1 ='" & eL.t_rtcs_1 & "'"
'Sql &= "	,t_rtcs_2 ='" & eL.t_rtcs_2 & "'"
'Sql &= "	,t_rtcs_3 ='" & eL.t_rtcs_3 & "'"
'Sql &= "	,t_rtfs_1 ='" & eL.t_rtfs_1 & "'"
'Sql &= "	,t_rtfs_2 ='" & eL.t_rtfs_2 & "'"
'Sql &= "	,t_rtfs_3 ='" & eL.t_rtfs_3 & "'"
'Sql &= "	,t_dper   ='" & eL.t_dper & "'"
'Sql &= "	,t_disa   ='" & eL.t_disa & "'"
'Sql &= "	,t_asta   ='" & eL.t_asta & "'"
'Sql &= "	,t_astb   ='" & eL.t_astb & "'"
'Sql &= "	,t_astc   ='" & eL.t_astc & "'"
'Sql &= "	,t_astd   ='" & eL.t_astd & "'"
'Sql &= "	,t_aste   ='" & eL.t_aste & "'"
'Sql &= "	,t_astf   ='" & eL.t_astf & "'"
'Sql &= "	,t_astg   ='" & eL.t_astg & "'"
'Sql &= "	,t_ssel   ='" & eL.t_ssel & "'"
'Sql &= "	,t_laun   ='" & eL.t_laun & "'"
'Sql &= "	,t_cpva   ='" & eL.t_cpva & "'"
'Sql &= "	,t_ocpr   ='" & eL.t_ocpr & "'"
'Sql &= "	,t_ospr   ='" & eL.t_ospr & "'"
'Sql &= "	,t_prim   ='" & eL.t_prim & "'"
'Sql &= "	,t_exbc_1 ='" & eL.t_exbc_1 & "'"
'Sql &= "	,t_exbc_2 ='" & eL.t_exbc_2 & "'"
'Sql &= "	,t_exbc_3 ='" & eL.t_exbc_3 & "'"
'Sql &= "	,t_exbs_1 ='" & eL.t_exbs_1 & "'"
'Sql &= "	,t_exbs_2 ='" & eL.t_exbs_2 & "'"
'Sql &= "	,t_exbs_3 ='" & eL.t_exbs_3 & "'"
'Sql &= "	,t_cvat_l ='" & eL.t_cvat_l & "'"
'Sql &= "	,t_cltx_l ='" & eL.t_cltx_l & "'"
'Sql &= "	,t_extx_l ='" & eL.t_extx_l & "'"
'Sql &= "	,t_stmt_l ='" & eL.t_stmt_l & "'"
'Sql &= "	,t_cch1_l ='" & eL.t_cch1_l & "'"
'Sql &= "	,t_ccp1_l ='" & eL.t_ccp1_l & "'"
'Sql &= "	,t_cch2_l ='" & eL.t_cch2_l & "'"
'Sql &= "	,t_ccp2_l ='" & eL.t_ccp2_l & "'"
'Sql &= "	,t_cch3_l ='" & eL.t_cch3_l & "'"
'Sql &= "	,t_ccp3_l ='" & eL.t_ccp3_l & "'"
'Sql &= "	,t_cch4_l ='" & eL.t_cch4_l & "'"
'Sql &= "	,t_ccp4_l ='" & eL.t_ccp4_l & "'"
'Sql &= "	,t_octr_l ='" & eL.t_octr_l & "'"
'Sql &= "	,t_ocpr_l ='" & eL.t_ocpr_l & "'"
'Sql &= "	,t_otbp   ='" & eL.t_otbp & "'"
'Sql &= "	,t_txta   ='" & eL.t_txta & "'"
'Sql &= "  ,t_Refcntd ='" & eL.t_Refcntd & "'"
'Sql &= "  ,t_Refcntu ='" & eL.t_Refcntu & "'"