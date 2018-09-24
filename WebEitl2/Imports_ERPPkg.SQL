SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgHSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgHSelectByID]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgHSelectByID]
  @LoginID NVarChar(8),
  @t_orno VarChar(9),
  @t_pkno Int 
  AS
  SELECT
    [ttdisg017200].*  
  FROM [ttdisg017200] 
  WHERE
  [ttdisg017200].[t_orno] = @t_orno
  AND [ttdisg017200].[t_pkno] = @t_pkno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgHSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgHSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgHSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_orno VarChar(9) NOT NULL
 ,t_pkno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_orno, t_pkno)
  SELECT [ttdisg017200].[t_orno], [ttdisg017200].[t_pkno] FROM [ttdisg017200]
 WHERE  
   ( 
         LOWER(ISNULL([ttdisg017200].[t_orno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg017200].[t_pkno], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg017200].[t_srno], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg017200].[t_pkgn], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg017200].[t_rcno],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg017200].[t_isup],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg017200].[t_ntwt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg017200].[t_grwt], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg017200].[t_tnam],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg017200].[t_vhno],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg017200].[t_lrno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg017200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg017200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdisg017200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdisg017200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_pkno' THEN [ttdisg017200].[t_pkno] END,
     CASE @OrderBy WHEN 't_pkno DESC' THEN [ttdisg017200].[t_pkno] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [ttdisg017200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [ttdisg017200].[t_srno] END DESC,
     CASE @OrderBy WHEN 't_pkgn' THEN [ttdisg017200].[t_pkgn] END,
     CASE @OrderBy WHEN 't_pkgn DESC' THEN [ttdisg017200].[t_pkgn] END DESC,
     CASE @OrderBy WHEN 't_rcno' THEN [ttdisg017200].[t_rcno] END,
     CASE @OrderBy WHEN 't_rcno DESC' THEN [ttdisg017200].[t_rcno] END DESC,
     CASE @OrderBy WHEN 't_isup' THEN [ttdisg017200].[t_isup] END,
     CASE @OrderBy WHEN 't_isup DESC' THEN [ttdisg017200].[t_isup] END DESC,
     CASE @OrderBy WHEN 't_pkdt' THEN [ttdisg017200].[t_pkdt] END,
     CASE @OrderBy WHEN 't_pkdt DESC' THEN [ttdisg017200].[t_pkdt] END DESC,
     CASE @OrderBy WHEN 't_ntwt' THEN [ttdisg017200].[t_ntwt] END,
     CASE @OrderBy WHEN 't_ntwt DESC' THEN [ttdisg017200].[t_ntwt] END DESC,
     CASE @OrderBy WHEN 't_grwt' THEN [ttdisg017200].[t_grwt] END,
     CASE @OrderBy WHEN 't_grwt DESC' THEN [ttdisg017200].[t_grwt] END DESC,
     CASE @OrderBy WHEN 't_tnam' THEN [ttdisg017200].[t_tnam] END,
     CASE @OrderBy WHEN 't_tnam DESC' THEN [ttdisg017200].[t_tnam] END DESC,
     CASE @OrderBy WHEN 't_vhno' THEN [ttdisg017200].[t_vhno] END,
     CASE @OrderBy WHEN 't_vhno DESC' THEN [ttdisg017200].[t_vhno] END DESC,
     CASE @OrderBy WHEN 't_lrno' THEN [ttdisg017200].[t_lrno] END,
     CASE @OrderBy WHEN 't_lrno DESC' THEN [ttdisg017200].[t_lrno] END DESC,
     CASE @OrderBy WHEN 't_lrdt' THEN [ttdisg017200].[t_lrdt] END,
     CASE @OrderBy WHEN 't_lrdt DESC' THEN [ttdisg017200].[t_lrdt] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttdisg017200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttdisg017200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttdisg017200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttdisg017200].[t_Refcntu] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttdisg017200].*  
  FROM [ttdisg017200] 
      INNER JOIN #PageIndex
          ON [ttdisg017200].[t_orno] = #PageIndex.t_orno
          AND [ttdisg017200].[t_pkno] = #PageIndex.t_pkno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgHSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgHSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgHSelectListFilteres]
  @Filter_t_orno VarChar(9),
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_orno VarChar(9) NOT NULL
 ,t_pkno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_orno'
  SET @LGSQL = @LGSQL + ', t_pkno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttdisg017200].[t_orno]'
  SET @LGSQL = @LGSQL + ', [ttdisg017200].[t_pkno]'
  SET @LGSQL = @LGSQL + ' FROM [ttdisg017200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_orno > '') 
    SET @LGSQL = @LGSQL + ' AND [ttdisg017200].[t_orno] = ''' + @Filter_t_orno + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_orno' THEN '[ttdisg017200].[t_orno]'
                        WHEN 't_orno DESC' THEN '[ttdisg017200].[t_orno] DESC'
                        WHEN 't_pkno' THEN '[ttdisg017200].[t_pkno]'
                        WHEN 't_pkno DESC' THEN '[ttdisg017200].[t_pkno] DESC'
                        WHEN 't_srno' THEN '[ttdisg017200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[ttdisg017200].[t_srno] DESC'
                        WHEN 't_pkgn' THEN '[ttdisg017200].[t_pkgn]'
                        WHEN 't_pkgn DESC' THEN '[ttdisg017200].[t_pkgn] DESC'
                        WHEN 't_rcno' THEN '[ttdisg017200].[t_rcno]'
                        WHEN 't_rcno DESC' THEN '[ttdisg017200].[t_rcno] DESC'
                        WHEN 't_isup' THEN '[ttdisg017200].[t_isup]'
                        WHEN 't_isup DESC' THEN '[ttdisg017200].[t_isup] DESC'
                        WHEN 't_pkdt' THEN '[ttdisg017200].[t_pkdt]'
                        WHEN 't_pkdt DESC' THEN '[ttdisg017200].[t_pkdt] DESC'
                        WHEN 't_ntwt' THEN '[ttdisg017200].[t_ntwt]'
                        WHEN 't_ntwt DESC' THEN '[ttdisg017200].[t_ntwt] DESC'
                        WHEN 't_grwt' THEN '[ttdisg017200].[t_grwt]'
                        WHEN 't_grwt DESC' THEN '[ttdisg017200].[t_grwt] DESC'
                        WHEN 't_tnam' THEN '[ttdisg017200].[t_tnam]'
                        WHEN 't_tnam DESC' THEN '[ttdisg017200].[t_tnam] DESC'
                        WHEN 't_vhno' THEN '[ttdisg017200].[t_vhno]'
                        WHEN 't_vhno DESC' THEN '[ttdisg017200].[t_vhno] DESC'
                        WHEN 't_lrno' THEN '[ttdisg017200].[t_lrno]'
                        WHEN 't_lrno DESC' THEN '[ttdisg017200].[t_lrno] DESC'
                        WHEN 't_lrdt' THEN '[ttdisg017200].[t_lrdt]'
                        WHEN 't_lrdt DESC' THEN '[ttdisg017200].[t_lrdt] DESC'
                        WHEN 't_Refcntd' THEN '[ttdisg017200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttdisg017200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttdisg017200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttdisg017200].[t_Refcntu] DESC'
                        ELSE '[ttdisg017200].[t_orno],[ttdisg017200].[t_pkno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttdisg017200].*  
  FROM [ttdisg017200] 
      INNER JOIN #PageIndex
          ON [ttdisg017200].[t_orno] = #PageIndex.t_orno
          AND [ttdisg017200].[t_pkno] = #PageIndex.t_pkno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgHInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgHInsert]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgHInsert]
  @t_orno VarChar(9),
  @t_pkno Int,
  @t_srno Int,
  @t_pkgn Int,
  @t_rcno VarChar(9),
  @t_isup VarChar(30),
  @t_pkdt DateTime,
  @t_ntwt Float,
  @t_grwt Float,
  @t_tnam VarChar(35),
  @t_vhno VarChar(15),
  @t_lrno VarChar(30),
  @t_lrdt DateTime,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @Return_t_orno VarChar(9) = null OUTPUT, 
  @Return_t_pkno Int = null OUTPUT 
  AS
  INSERT [ttdisg017200]
  (
   [t_orno]
  ,[t_pkno]
  ,[t_srno]
  ,[t_pkgn]
  ,[t_rcno]
  ,[t_isup]
  ,[t_pkdt]
  ,[t_ntwt]
  ,[t_grwt]
  ,[t_tnam]
  ,[t_vhno]
  ,[t_lrno]
  ,[t_lrdt]
  ,[t_Refcntd]
  ,[t_Refcntu]
  )
  VALUES
  (
   UPPER(@t_orno)
  ,@t_pkno
  ,@t_srno
  ,@t_pkgn
  ,@t_rcno
  ,@t_isup
  ,@t_pkdt
  ,@t_ntwt
  ,@t_grwt
  ,@t_tnam
  ,@t_vhno
  ,@t_lrno
  ,@t_lrdt
  ,@t_Refcntd
  ,@t_Refcntu
  )
  SET @Return_t_orno = @t_orno
  SET @Return_t_pkno = @t_pkno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgHUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgHUpdate]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgHUpdate]
  @Original_t_orno VarChar(9), 
  @Original_t_pkno Int, 
  @t_orno VarChar(9),
  @t_pkno Int,
  @t_srno Int,
  @t_pkgn Int,
  @t_rcno VarChar(9),
  @t_isup VarChar(30),
  @t_pkdt DateTime,
  @t_ntwt Float,
  @t_grwt Float,
  @t_tnam VarChar(35),
  @t_vhno VarChar(15),
  @t_lrno VarChar(30),
  @t_lrdt DateTime,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttdisg017200] SET 
   [t_orno] = @t_orno
  ,[t_pkno] = @t_pkno
  ,[t_srno] = @t_srno
  ,[t_pkgn] = @t_pkgn
  ,[t_rcno] = @t_rcno
  ,[t_isup] = @t_isup
  ,[t_pkdt] = @t_pkdt
  ,[t_ntwt] = @t_ntwt
  ,[t_grwt] = @t_grwt
  ,[t_tnam] = @t_tnam
  ,[t_vhno] = @t_vhno
  ,[t_lrno] = @t_lrno
  ,[t_lrdt] = @t_lrdt
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  WHERE
  [t_orno] = @Original_t_orno
  AND [t_pkno] = @Original_t_pkno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgHDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgHDelete]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgHDelete]
  @Original_t_orno VarChar(9),
  @Original_t_pkno Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [ttdisg017200]
  WHERE
  [ttdisg017200].[t_orno] = @Original_t_orno
  AND [ttdisg017200].[t_pkno] = @Original_t_pkno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgDSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgDSelectByID]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgDSelectByID]
  @LoginID NVarChar(8),
  @t_orno VarChar(9),
  @t_pkno Int,
  @t_rcln Int 
  AS
  SELECT
    [ttdisg018200].*  
  FROM [ttdisg018200] 
  WHERE
  [ttdisg018200].[t_orno] = @t_orno
  AND [ttdisg018200].[t_pkno] = @t_pkno
  AND [ttdisg018200].[t_rcln] = @t_rcln
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgDSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgDSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgDSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_orno VarChar(9) NOT NULL
 ,t_pkno Int NOT NULL
 ,t_rcln Int NOT NULL
  )
  INSERT INTO #PageIndex (t_orno, t_pkno, t_rcln)
  SELECT [ttdisg018200].[t_orno], [ttdisg018200].[t_pkno], [ttdisg018200].[t_rcln] FROM [ttdisg018200]
 WHERE  
   ( 
         LOWER(ISNULL([ttdisg018200].[t_orno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_pkno], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_rcln], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg018200].[t_citm],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_pkgn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_bomn], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg018200].[t_cuni],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_itmn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_qnty], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_uwgt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_twgt], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg018200].[t_docn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg018200].[t_revn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg018200].[t_ptyp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg018200].[t_pmrk],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_leng], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_widt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_hght], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg018200].[t_unit],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg018200].[t_rcno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_srno], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg018200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdisg018200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdisg018200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_pkno' THEN [ttdisg018200].[t_pkno] END,
     CASE @OrderBy WHEN 't_pkno DESC' THEN [ttdisg018200].[t_pkno] END DESC,
     CASE @OrderBy WHEN 't_rcln' THEN [ttdisg018200].[t_rcln] END,
     CASE @OrderBy WHEN 't_rcln DESC' THEN [ttdisg018200].[t_rcln] END DESC,
     CASE @OrderBy WHEN 't_citm' THEN [ttdisg018200].[t_citm] END,
     CASE @OrderBy WHEN 't_citm DESC' THEN [ttdisg018200].[t_citm] END DESC,
     CASE @OrderBy WHEN 't_pkgn' THEN [ttdisg018200].[t_pkgn] END,
     CASE @OrderBy WHEN 't_pkgn DESC' THEN [ttdisg018200].[t_pkgn] END DESC,
     CASE @OrderBy WHEN 't_bomn' THEN [ttdisg018200].[t_bomn] END,
     CASE @OrderBy WHEN 't_bomn DESC' THEN [ttdisg018200].[t_bomn] END DESC,
     CASE @OrderBy WHEN 't_cuni' THEN [ttdisg018200].[t_cuni] END,
     CASE @OrderBy WHEN 't_cuni DESC' THEN [ttdisg018200].[t_cuni] END DESC,
     CASE @OrderBy WHEN 't_itmn' THEN [ttdisg018200].[t_itmn] END,
     CASE @OrderBy WHEN 't_itmn DESC' THEN [ttdisg018200].[t_itmn] END DESC,
     CASE @OrderBy WHEN 't_qnty' THEN [ttdisg018200].[t_qnty] END,
     CASE @OrderBy WHEN 't_qnty DESC' THEN [ttdisg018200].[t_qnty] END DESC,
     CASE @OrderBy WHEN 't_uwgt' THEN [ttdisg018200].[t_uwgt] END,
     CASE @OrderBy WHEN 't_uwgt DESC' THEN [ttdisg018200].[t_uwgt] END DESC,
     CASE @OrderBy WHEN 't_twgt' THEN [ttdisg018200].[t_twgt] END,
     CASE @OrderBy WHEN 't_twgt DESC' THEN [ttdisg018200].[t_twgt] END DESC,
     CASE @OrderBy WHEN 't_docn' THEN [ttdisg018200].[t_docn] END,
     CASE @OrderBy WHEN 't_docn DESC' THEN [ttdisg018200].[t_docn] END DESC,
     CASE @OrderBy WHEN 't_revn' THEN [ttdisg018200].[t_revn] END,
     CASE @OrderBy WHEN 't_revn DESC' THEN [ttdisg018200].[t_revn] END DESC,
     CASE @OrderBy WHEN 't_ptyp' THEN [ttdisg018200].[t_ptyp] END,
     CASE @OrderBy WHEN 't_ptyp DESC' THEN [ttdisg018200].[t_ptyp] END DESC,
     CASE @OrderBy WHEN 't_pmrk' THEN [ttdisg018200].[t_pmrk] END,
     CASE @OrderBy WHEN 't_pmrk DESC' THEN [ttdisg018200].[t_pmrk] END DESC,
     CASE @OrderBy WHEN 't_leng' THEN [ttdisg018200].[t_leng] END,
     CASE @OrderBy WHEN 't_leng DESC' THEN [ttdisg018200].[t_leng] END DESC,
     CASE @OrderBy WHEN 't_widt' THEN [ttdisg018200].[t_widt] END,
     CASE @OrderBy WHEN 't_widt DESC' THEN [ttdisg018200].[t_widt] END DESC,
     CASE @OrderBy WHEN 't_hght' THEN [ttdisg018200].[t_hght] END,
     CASE @OrderBy WHEN 't_hght DESC' THEN [ttdisg018200].[t_hght] END DESC,
     CASE @OrderBy WHEN 't_unit' THEN [ttdisg018200].[t_unit] END,
     CASE @OrderBy WHEN 't_unit DESC' THEN [ttdisg018200].[t_unit] END DESC,
     CASE @OrderBy WHEN 't_rcno' THEN [ttdisg018200].[t_rcno] END,
     CASE @OrderBy WHEN 't_rcno DESC' THEN [ttdisg018200].[t_rcno] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [ttdisg018200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [ttdisg018200].[t_srno] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttdisg018200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttdisg018200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttdisg018200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttdisg018200].[t_Refcntu] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttdisg018200].*  
  FROM [ttdisg018200] 
      INNER JOIN #PageIndex
          ON [ttdisg018200].[t_orno] = #PageIndex.t_orno
          AND [ttdisg018200].[t_pkno] = #PageIndex.t_pkno
          AND [ttdisg018200].[t_rcln] = #PageIndex.t_rcln
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgDSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgDSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgDSelectListFilteres]
  @Filter_t_orno VarChar(9),
  @Filter_t_pkno Int,
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,t_orno VarChar(9) NOT NULL
 ,t_pkno Int NOT NULL
 ,t_rcln Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_orno'
  SET @LGSQL = @LGSQL + ', t_pkno'
  SET @LGSQL = @LGSQL + ', t_rcln'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttdisg018200].[t_orno]'
  SET @LGSQL = @LGSQL + ', [ttdisg018200].[t_pkno]'
  SET @LGSQL = @LGSQL + ', [ttdisg018200].[t_rcln]'
  SET @LGSQL = @LGSQL + ' FROM [ttdisg018200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_orno > '') 
    SET @LGSQL = @LGSQL + ' AND [ttdisg018200].[t_orno] = ''' + @Filter_t_orno + ''''
  IF (@Filter_t_pkno > 0) 
    SET @LGSQL = @LGSQL + ' AND [ttdisg018200].[t_pkno] = ' + STR(@Filter_t_pkno)
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_orno' THEN '[ttdisg018200].[t_orno]'
                        WHEN 't_orno DESC' THEN '[ttdisg018200].[t_orno] DESC'
                        WHEN 't_pkno' THEN '[ttdisg018200].[t_pkno]'
                        WHEN 't_pkno DESC' THEN '[ttdisg018200].[t_pkno] DESC'
                        WHEN 't_rcln' THEN '[ttdisg018200].[t_rcln]'
                        WHEN 't_rcln DESC' THEN '[ttdisg018200].[t_rcln] DESC'
                        WHEN 't_citm' THEN '[ttdisg018200].[t_citm]'
                        WHEN 't_citm DESC' THEN '[ttdisg018200].[t_citm] DESC'
                        WHEN 't_pkgn' THEN '[ttdisg018200].[t_pkgn]'
                        WHEN 't_pkgn DESC' THEN '[ttdisg018200].[t_pkgn] DESC'
                        WHEN 't_bomn' THEN '[ttdisg018200].[t_bomn]'
                        WHEN 't_bomn DESC' THEN '[ttdisg018200].[t_bomn] DESC'
                        WHEN 't_cuni' THEN '[ttdisg018200].[t_cuni]'
                        WHEN 't_cuni DESC' THEN '[ttdisg018200].[t_cuni] DESC'
                        WHEN 't_itmn' THEN '[ttdisg018200].[t_itmn]'
                        WHEN 't_itmn DESC' THEN '[ttdisg018200].[t_itmn] DESC'
                        WHEN 't_qnty' THEN '[ttdisg018200].[t_qnty]'
                        WHEN 't_qnty DESC' THEN '[ttdisg018200].[t_qnty] DESC'
                        WHEN 't_uwgt' THEN '[ttdisg018200].[t_uwgt]'
                        WHEN 't_uwgt DESC' THEN '[ttdisg018200].[t_uwgt] DESC'
                        WHEN 't_twgt' THEN '[ttdisg018200].[t_twgt]'
                        WHEN 't_twgt DESC' THEN '[ttdisg018200].[t_twgt] DESC'
                        WHEN 't_docn' THEN '[ttdisg018200].[t_docn]'
                        WHEN 't_docn DESC' THEN '[ttdisg018200].[t_docn] DESC'
                        WHEN 't_revn' THEN '[ttdisg018200].[t_revn]'
                        WHEN 't_revn DESC' THEN '[ttdisg018200].[t_revn] DESC'
                        WHEN 't_ptyp' THEN '[ttdisg018200].[t_ptyp]'
                        WHEN 't_ptyp DESC' THEN '[ttdisg018200].[t_ptyp] DESC'
                        WHEN 't_pmrk' THEN '[ttdisg018200].[t_pmrk]'
                        WHEN 't_pmrk DESC' THEN '[ttdisg018200].[t_pmrk] DESC'
                        WHEN 't_leng' THEN '[ttdisg018200].[t_leng]'
                        WHEN 't_leng DESC' THEN '[ttdisg018200].[t_leng] DESC'
                        WHEN 't_widt' THEN '[ttdisg018200].[t_widt]'
                        WHEN 't_widt DESC' THEN '[ttdisg018200].[t_widt] DESC'
                        WHEN 't_hght' THEN '[ttdisg018200].[t_hght]'
                        WHEN 't_hght DESC' THEN '[ttdisg018200].[t_hght] DESC'
                        WHEN 't_unit' THEN '[ttdisg018200].[t_unit]'
                        WHEN 't_unit DESC' THEN '[ttdisg018200].[t_unit] DESC'
                        WHEN 't_rcno' THEN '[ttdisg018200].[t_rcno]'
                        WHEN 't_rcno DESC' THEN '[ttdisg018200].[t_rcno] DESC'
                        WHEN 't_srno' THEN '[ttdisg018200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[ttdisg018200].[t_srno] DESC'
                        WHEN 't_Refcntd' THEN '[ttdisg018200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttdisg018200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttdisg018200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttdisg018200].[t_Refcntu] DESC'
                        ELSE '[ttdisg018200].[t_orno],[ttdisg018200].[t_pkno],[ttdisg018200].[t_rcln]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttdisg018200].*  
  FROM [ttdisg018200] 
      INNER JOIN #PageIndex
          ON [ttdisg018200].[t_orno] = #PageIndex.t_orno
          AND [ttdisg018200].[t_pkno] = #PageIndex.t_pkno
          AND [ttdisg018200].[t_rcln] = #PageIndex.t_rcln
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgDInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgDInsert]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgDInsert]
  @t_orno VarChar(9),
  @t_pkno Int,
  @t_rcln Int,
  @t_citm VarChar(47),
  @t_pkgn Int,
  @t_bomn Int,
  @t_cuni VarChar(3),
  @t_itmn Int,
  @t_qnty Float,
  @t_uwgt Float,
  @t_twgt Float,
  @t_docn VarChar(32),
  @t_revn VarChar(32),
  @t_ptyp VarChar(30),
  @t_pmrk VarChar(100),
  @t_leng Float,
  @t_widt Float,
  @t_hght Float,
  @t_unit VarChar(3),
  @t_rcno VarChar(9),
  @t_srno Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @Return_t_orno VarChar(9) = null OUTPUT, 
  @Return_t_pkno Int = null OUTPUT, 
  @Return_t_rcln Int = null OUTPUT 
  AS
  INSERT [ttdisg018200]
  (
   [t_orno]
  ,[t_pkno]
  ,[t_rcln]
  ,[t_citm]
  ,[t_pkgn]
  ,[t_bomn]
  ,[t_cuni]
  ,[t_itmn]
  ,[t_qnty]
  ,[t_uwgt]
  ,[t_twgt]
  ,[t_docn]
  ,[t_revn]
  ,[t_ptyp]
  ,[t_pmrk]
  ,[t_leng]
  ,[t_widt]
  ,[t_hght]
  ,[t_unit]
  ,[t_rcno]
  ,[t_srno]
  ,[t_Refcntd]
  ,[t_Refcntu]
  )
  VALUES
  (
   UPPER(@t_orno)
  ,@t_pkno
  ,@t_rcln
  ,@t_citm
  ,@t_pkgn
  ,@t_bomn
  ,@t_cuni
  ,@t_itmn
  ,@t_qnty
  ,@t_uwgt
  ,@t_twgt
  ,@t_docn
  ,@t_revn
  ,@t_ptyp
  ,@t_pmrk
  ,@t_leng
  ,@t_widt
  ,@t_hght
  ,@t_unit
  ,@t_rcno
  ,@t_srno
  ,@t_Refcntd
  ,@t_Refcntu
  )
  SET @Return_t_orno = @t_orno
  SET @Return_t_pkno = @t_pkno
  SET @Return_t_rcln = @t_rcln
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgDUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgDUpdate]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgDUpdate]
  @Original_t_orno VarChar(9), 
  @Original_t_pkno Int, 
  @Original_t_rcln Int, 
  @t_orno VarChar(9),
  @t_pkno Int,
  @t_rcln Int,
  @t_citm VarChar(47),
  @t_pkgn Int,
  @t_bomn Int,
  @t_cuni VarChar(3),
  @t_itmn Int,
  @t_qnty Float,
  @t_uwgt Float,
  @t_twgt Float,
  @t_docn VarChar(32),
  @t_revn VarChar(32),
  @t_ptyp VarChar(30),
  @t_pmrk VarChar(100),
  @t_leng Float,
  @t_widt Float,
  @t_hght Float,
  @t_unit VarChar(3),
  @t_rcno VarChar(9),
  @t_srno Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [ttdisg018200] SET 
   [t_orno] = @t_orno
  ,[t_pkno] = @t_pkno
  ,[t_rcln] = @t_rcln
  ,[t_citm] = @t_citm
  ,[t_pkgn] = @t_pkgn
  ,[t_bomn] = @t_bomn
  ,[t_cuni] = @t_cuni
  ,[t_itmn] = @t_itmn
  ,[t_qnty] = @t_qnty
  ,[t_uwgt] = @t_uwgt
  ,[t_twgt] = @t_twgt
  ,[t_docn] = @t_docn
  ,[t_revn] = @t_revn
  ,[t_ptyp] = @t_ptyp
  ,[t_pmrk] = @t_pmrk
  ,[t_leng] = @t_leng
  ,[t_widt] = @t_widt
  ,[t_hght] = @t_hght
  ,[t_unit] = @t_unit
  ,[t_rcno] = @t_rcno
  ,[t_srno] = @t_srno
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  WHERE
  [t_orno] = @Original_t_orno
  AND [t_pkno] = @Original_t_pkno
  AND [t_rcln] = @Original_t_rcln
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPkgDDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPkgDDelete]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPkgDDelete]
  @Original_t_orno VarChar(9),
  @Original_t_pkno Int,
  @Original_t_rcln Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [ttdisg018200]
  WHERE
  [ttdisg018200].[t_orno] = @Original_t_orno
  AND [ttdisg018200].[t_pkno] = @Original_t_pkno
  AND [ttdisg018200].[t_rcln] = @Original_t_rcln
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
