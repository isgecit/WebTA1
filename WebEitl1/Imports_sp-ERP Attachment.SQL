SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfdbAttachmentsSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfdbAttachmentsSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spwfdbAttachmentsSelectListSearch]
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
 ,t_indx VarChar(50) NOT NULL
 ,t_dcid VarChar(200) NOT NULL
  )
  INSERT INTO #PageIndex (t_indx, t_dcid)
  SELECT [ttcisg132200].[t_indx], [ttcisg132200].[t_dcid] FROM [ttcisg132200]
 WHERE  
   ( 
         LOWER(ISNULL([ttcisg132200].[t_drid],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttcisg132200].[t_dcid],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttcisg132200].[t_indx],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttcisg132200].[t_prcd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttcisg132200].[t_fnam],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttcisg132200].[t_lbcd],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttcisg132200].[t_atby],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttcisg132200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttcisg132200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttcisg132200].[t_hndl],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_indx' THEN [ttcisg132200].[t_indx] END,
     CASE @OrderBy WHEN 't_indx DESC' THEN [ttcisg132200].[t_indx] END DESC,
     CASE @OrderBy WHEN 't_dcid' THEN [ttcisg132200].[t_dcid] END,
     CASE @OrderBy WHEN 't_dcid DESC' THEN [ttcisg132200].[t_dcid] END DESC,
     CASE @OrderBy WHEN 't_prcd' THEN [ttcisg132200].[t_prcd] END,
     CASE @OrderBy WHEN 't_prcd DESC' THEN [ttcisg132200].[t_prcd] END DESC,
     CASE @OrderBy WHEN 't_fnam' THEN [ttcisg132200].[t_fnam] END,
     CASE @OrderBy WHEN 't_fnam DESC' THEN [ttcisg132200].[t_fnam] END DESC,
     CASE @OrderBy WHEN 't_lbcd' THEN [ttcisg132200].[t_lbcd] END,
     CASE @OrderBy WHEN 't_lbcd DESC' THEN [ttcisg132200].[t_lbcd] END DESC,
     CASE @OrderBy WHEN 't_atby' THEN [ttcisg132200].[t_atby] END,
     CASE @OrderBy WHEN 't_atby DESC' THEN [ttcisg132200].[t_atby] END DESC,
     CASE @OrderBy WHEN 't_aton' THEN [ttcisg132200].[t_aton] END,
     CASE @OrderBy WHEN 't_aton DESC' THEN [ttcisg132200].[t_aton] END DESC,
     CASE @OrderBy WHEN 't_hndl' THEN [ttcisg132200].[t_hndl] END,
     CASE @OrderBy WHEN 't_hndl DESC' THEN [ttcisg132200].[t_hndl] END DESC,
     CASE @OrderBy WHEN 't_drid' THEN [ttcisg132200].[t_drid] END,
     CASE @OrderBy WHEN 't_drid DESC' THEN [ttcisg132200].[t_drid] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttcisg132200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttcisg132200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttcisg132200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttcisg132200].[t_Refcntu] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttcisg132200].*  
  FROM [ttcisg132200] 
      INNER JOIN #PageIndex
          ON [ttcisg132200].[t_indx] = #PageIndex.t_indx
          AND [ttcisg132200].[t_dcid] = #PageIndex.t_dcid
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfdbAttachmentsSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfdbAttachmentsSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spwfdbAttachmentsSelectListFilteres]
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
 ,t_indx VarChar(50) NOT NULL
 ,t_dcid VarChar(200) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_indx'
  SET @LGSQL = @LGSQL + ', t_dcid'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttcisg132200].[t_indx]'
  SET @LGSQL = @LGSQL + ', [ttcisg132200].[t_dcid]'
  SET @LGSQL = @LGSQL + ' FROM [ttcisg132200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_indx' THEN '[ttcisg132200].[t_indx]'
                        WHEN 't_indx DESC' THEN '[ttcisg132200].[t_indx] DESC'
                        WHEN 't_dcid' THEN '[ttcisg132200].[t_dcid]'
                        WHEN 't_dcid DESC' THEN '[ttcisg132200].[t_dcid] DESC'
                        WHEN 't_prcd' THEN '[ttcisg132200].[t_prcd]'
                        WHEN 't_prcd DESC' THEN '[ttcisg132200].[t_prcd] DESC'
                        WHEN 't_fnam' THEN '[ttcisg132200].[t_fnam]'
                        WHEN 't_fnam DESC' THEN '[ttcisg132200].[t_fnam] DESC'
                        WHEN 't_lbcd' THEN '[ttcisg132200].[t_lbcd]'
                        WHEN 't_lbcd DESC' THEN '[ttcisg132200].[t_lbcd] DESC'
                        WHEN 't_atby' THEN '[ttcisg132200].[t_atby]'
                        WHEN 't_atby DESC' THEN '[ttcisg132200].[t_atby] DESC'
                        WHEN 't_aton' THEN '[ttcisg132200].[t_aton]'
                        WHEN 't_aton DESC' THEN '[ttcisg132200].[t_aton] DESC'
                        WHEN 't_hndl' THEN '[ttcisg132200].[t_hndl]'
                        WHEN 't_hndl DESC' THEN '[ttcisg132200].[t_hndl] DESC'
                        WHEN 't_drid' THEN '[ttcisg132200].[t_drid]'
                        WHEN 't_drid DESC' THEN '[ttcisg132200].[t_drid] DESC'
                        WHEN 't_Refcntd' THEN '[ttcisg132200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttcisg132200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttcisg132200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttcisg132200].[t_Refcntu] DESC'
                        ELSE '[ttcisg132200].[t_indx],[ttcisg132200].[t_dcid]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttcisg132200].*  
  FROM [ttcisg132200] 
      INNER JOIN #PageIndex
          ON [ttcisg132200].[t_indx] = #PageIndex.t_indx
          AND [ttcisg132200].[t_dcid] = #PageIndex.t_dcid
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
