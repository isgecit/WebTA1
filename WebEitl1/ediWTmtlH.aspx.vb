Imports System.Web.Script.Serialization
Partial Class EF_ediWTmtlH
  Inherits SIS.SYS.UpdateBase
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvediWTmtlDCC As New gvBase
  Protected Sub GVediWTmtlD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVediWTmtlD.Init
    gvediWTmtlDCC.DataClassName = "GediWTmtlD"
    gvediWTmtlDCC.SetGridView = GVediWTmtlD
  End Sub
  Protected Sub TBLediWTmtlD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLediWTmtlD.Init
    gvediWTmtlDCC.SetToolBar = TBLediWTmtlD
  End Sub

  Private Sub EF_ediWTmtlH_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    SIS.SYS.Utilities.SessionManager.InitializeEnvironment("0340")
  End Sub

End Class
