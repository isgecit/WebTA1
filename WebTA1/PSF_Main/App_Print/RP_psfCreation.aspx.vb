Partial Class RP_psfCreation
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim SerialNo As Int32 = CType(aVal(0), Int32)
    Dim FilePath As String = SIS.PSF.psfCreation.CreatePSFFile(SerialNo)
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=PSF" & "_" & SerialNo & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub

End Class
