SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecHSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecHSelectByID]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecHSelectByID]
  @LoginID NVarChar(8),
  @t_rcno VarChar(9),
  @t_revn VarChar(20) 
  AS
  SELECT
    [tdmisg134200].*  
  FROM [tdmisg134200] 
  WHERE
  [tdmisg134200].[t_rcno] = @t_rcno
  AND [tdmisg134200].[t_revn] = @t_revn
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecHSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecHSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecHSelectListSearch]
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
 ,t_rcno VarChar(9) NOT NULL
 ,t_revn VarChar(20) NOT NULL
  )
  INSERT INTO #PageIndex (t_rcno, t_revn)
  SELECT [tdmisg134200].[t_rcno], [tdmisg134200].[t_revn] FROM [tdmisg134200]
 WHERE  
   ( 
         LOWER(ISNULL([tdmisg134200].[t_rcno],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_revn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_item],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_bpid],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_nama],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_stat], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_user],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_sent_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_sent_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_sent_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_sent_4], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_sent_5], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_sent_6], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_sent_7], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_rece_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_rece_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_rece_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_rece_4], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_rece_5], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_rece_6], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_rece_7], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_suer],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_appr],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_subm_1], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_subm_2], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_subm_3], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_subm_4], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_subm_5], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_subm_6], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_subm_7], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_orno],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_pono], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_trno],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg134200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_docn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg134200].[t_eunt],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_rcno' THEN [tdmisg134200].[t_rcno] END,
     CASE @OrderBy WHEN 't_rcno DESC' THEN [tdmisg134200].[t_rcno] END DESC,
     CASE @OrderBy WHEN 't_revn' THEN [tdmisg134200].[t_revn] END,
     CASE @OrderBy WHEN 't_revn DESC' THEN [tdmisg134200].[t_revn] END DESC,
     CASE @OrderBy WHEN 't_cprj' THEN [tdmisg134200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [tdmisg134200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_item' THEN [tdmisg134200].[t_item] END,
     CASE @OrderBy WHEN 't_item DESC' THEN [tdmisg134200].[t_item] END DESC,
     CASE @OrderBy WHEN 't_bpid' THEN [tdmisg134200].[t_bpid] END,
     CASE @OrderBy WHEN 't_bpid DESC' THEN [tdmisg134200].[t_bpid] END DESC,
     CASE @OrderBy WHEN 't_nama' THEN [tdmisg134200].[t_nama] END,
     CASE @OrderBy WHEN 't_nama DESC' THEN [tdmisg134200].[t_nama] END DESC,
     CASE @OrderBy WHEN 't_stat' THEN [tdmisg134200].[t_stat] END,
     CASE @OrderBy WHEN 't_stat DESC' THEN [tdmisg134200].[t_stat] END DESC,
     CASE @OrderBy WHEN 't_user' THEN [tdmisg134200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [tdmisg134200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_date' THEN [tdmisg134200].[t_date] END,
     CASE @OrderBy WHEN 't_date DESC' THEN [tdmisg134200].[t_date] END DESC,
     CASE @OrderBy WHEN 't_sent_1' THEN [tdmisg134200].[t_sent_1] END,
     CASE @OrderBy WHEN 't_sent_1 DESC' THEN [tdmisg134200].[t_sent_1] END DESC,
     CASE @OrderBy WHEN 't_sent_2' THEN [tdmisg134200].[t_sent_2] END,
     CASE @OrderBy WHEN 't_sent_2 DESC' THEN [tdmisg134200].[t_sent_2] END DESC,
     CASE @OrderBy WHEN 't_sent_3' THEN [tdmisg134200].[t_sent_3] END,
     CASE @OrderBy WHEN 't_sent_3 DESC' THEN [tdmisg134200].[t_sent_3] END DESC,
     CASE @OrderBy WHEN 't_sent_4' THEN [tdmisg134200].[t_sent_4] END,
     CASE @OrderBy WHEN 't_sent_4 DESC' THEN [tdmisg134200].[t_sent_4] END DESC,
     CASE @OrderBy WHEN 't_sent_5' THEN [tdmisg134200].[t_sent_5] END,
     CASE @OrderBy WHEN 't_sent_5 DESC' THEN [tdmisg134200].[t_sent_5] END DESC,
     CASE @OrderBy WHEN 't_sent_6' THEN [tdmisg134200].[t_sent_6] END,
     CASE @OrderBy WHEN 't_sent_6 DESC' THEN [tdmisg134200].[t_sent_6] END DESC,
     CASE @OrderBy WHEN 't_sent_7' THEN [tdmisg134200].[t_sent_7] END,
     CASE @OrderBy WHEN 't_sent_7 DESC' THEN [tdmisg134200].[t_sent_7] END DESC,
     CASE @OrderBy WHEN 't_rece_1' THEN [tdmisg134200].[t_rece_1] END,
     CASE @OrderBy WHEN 't_rece_1 DESC' THEN [tdmisg134200].[t_rece_1] END DESC,
     CASE @OrderBy WHEN 't_rece_2' THEN [tdmisg134200].[t_rece_2] END,
     CASE @OrderBy WHEN 't_rece_2 DESC' THEN [tdmisg134200].[t_rece_2] END DESC,
     CASE @OrderBy WHEN 't_rece_3' THEN [tdmisg134200].[t_rece_3] END,
     CASE @OrderBy WHEN 't_rece_3 DESC' THEN [tdmisg134200].[t_rece_3] END DESC,
     CASE @OrderBy WHEN 't_rece_4' THEN [tdmisg134200].[t_rece_4] END,
     CASE @OrderBy WHEN 't_rece_4 DESC' THEN [tdmisg134200].[t_rece_4] END DESC,
     CASE @OrderBy WHEN 't_rece_5' THEN [tdmisg134200].[t_rece_5] END,
     CASE @OrderBy WHEN 't_rece_5 DESC' THEN [tdmisg134200].[t_rece_5] END DESC,
     CASE @OrderBy WHEN 't_rece_6' THEN [tdmisg134200].[t_rece_6] END,
     CASE @OrderBy WHEN 't_rece_6 DESC' THEN [tdmisg134200].[t_rece_6] END DESC,
     CASE @OrderBy WHEN 't_rece_7' THEN [tdmisg134200].[t_rece_7] END,
     CASE @OrderBy WHEN 't_rece_7 DESC' THEN [tdmisg134200].[t_rece_7] END DESC,
     CASE @OrderBy WHEN 't_suer' THEN [tdmisg134200].[t_suer] END,
     CASE @OrderBy WHEN 't_suer DESC' THEN [tdmisg134200].[t_suer] END DESC,
     CASE @OrderBy WHEN 't_sdat' THEN [tdmisg134200].[t_sdat] END,
     CASE @OrderBy WHEN 't_sdat DESC' THEN [tdmisg134200].[t_sdat] END DESC,
     CASE @OrderBy WHEN 't_appr' THEN [tdmisg134200].[t_appr] END,
     CASE @OrderBy WHEN 't_appr DESC' THEN [tdmisg134200].[t_appr] END DESC,
     CASE @OrderBy WHEN 't_adat' THEN [tdmisg134200].[t_adat] END,
     CASE @OrderBy WHEN 't_adat DESC' THEN [tdmisg134200].[t_adat] END DESC,
     CASE @OrderBy WHEN 't_subm_1' THEN [tdmisg134200].[t_subm_1] END,
     CASE @OrderBy WHEN 't_subm_1 DESC' THEN [tdmisg134200].[t_subm_1] END DESC,
     CASE @OrderBy WHEN 't_subm_2' THEN [tdmisg134200].[t_subm_2] END,
     CASE @OrderBy WHEN 't_subm_2 DESC' THEN [tdmisg134200].[t_subm_2] END DESC,
     CASE @OrderBy WHEN 't_subm_3' THEN [tdmisg134200].[t_subm_3] END,
     CASE @OrderBy WHEN 't_subm_3 DESC' THEN [tdmisg134200].[t_subm_3] END DESC,
     CASE @OrderBy WHEN 't_subm_4' THEN [tdmisg134200].[t_subm_4] END,
     CASE @OrderBy WHEN 't_subm_4 DESC' THEN [tdmisg134200].[t_subm_4] END DESC,
     CASE @OrderBy WHEN 't_subm_5' THEN [tdmisg134200].[t_subm_5] END,
     CASE @OrderBy WHEN 't_subm_5 DESC' THEN [tdmisg134200].[t_subm_5] END DESC,
     CASE @OrderBy WHEN 't_subm_6' THEN [tdmisg134200].[t_subm_6] END,
     CASE @OrderBy WHEN 't_subm_6 DESC' THEN [tdmisg134200].[t_subm_6] END DESC,
     CASE @OrderBy WHEN 't_subm_7' THEN [tdmisg134200].[t_subm_7] END,
     CASE @OrderBy WHEN 't_subm_7 DESC' THEN [tdmisg134200].[t_subm_7] END DESC,
     CASE @OrderBy WHEN 't_orno' THEN [tdmisg134200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [tdmisg134200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_pono' THEN [tdmisg134200].[t_pono] END,
     CASE @OrderBy WHEN 't_pono DESC' THEN [tdmisg134200].[t_pono] END DESC,
     CASE @OrderBy WHEN 't_trno' THEN [tdmisg134200].[t_trno] END,
     CASE @OrderBy WHEN 't_trno DESC' THEN [tdmisg134200].[t_trno] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [tdmisg134200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [tdmisg134200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [tdmisg134200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [tdmisg134200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_docn' THEN [tdmisg134200].[t_docn] END,
     CASE @OrderBy WHEN 't_docn DESC' THEN [tdmisg134200].[t_docn] END DESC,
     CASE @OrderBy WHEN 't_eunt' THEN [tdmisg134200].[t_eunt] END,
     CASE @OrderBy WHEN 't_eunt DESC' THEN [tdmisg134200].[t_eunt] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [tdmisg134200].*  
  FROM [tdmisg134200] 
      INNER JOIN #PageIndex
          ON [tdmisg134200].[t_rcno] = #PageIndex.t_rcno
          AND [tdmisg134200].[t_revn] = #PageIndex.t_revn
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecHSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecHSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecHSelectListFilteres]
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
 ,t_rcno VarChar(9) NOT NULL
 ,t_revn VarChar(20) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_rcno'
  SET @LGSQL = @LGSQL + ', t_revn'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[tdmisg134200].[t_rcno]'
  SET @LGSQL = @LGSQL + ', [tdmisg134200].[t_revn]'
  SET @LGSQL = @LGSQL + ' FROM [tdmisg134200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_rcno' THEN '[tdmisg134200].[t_rcno]'
                        WHEN 't_rcno DESC' THEN '[tdmisg134200].[t_rcno] DESC'
                        WHEN 't_revn' THEN '[tdmisg134200].[t_revn]'
                        WHEN 't_revn DESC' THEN '[tdmisg134200].[t_revn] DESC'
                        WHEN 't_cprj' THEN '[tdmisg134200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[tdmisg134200].[t_cprj] DESC'
                        WHEN 't_item' THEN '[tdmisg134200].[t_item]'
                        WHEN 't_item DESC' THEN '[tdmisg134200].[t_item] DESC'
                        WHEN 't_bpid' THEN '[tdmisg134200].[t_bpid]'
                        WHEN 't_bpid DESC' THEN '[tdmisg134200].[t_bpid] DESC'
                        WHEN 't_nama' THEN '[tdmisg134200].[t_nama]'
                        WHEN 't_nama DESC' THEN '[tdmisg134200].[t_nama] DESC'
                        WHEN 't_stat' THEN '[tdmisg134200].[t_stat]'
                        WHEN 't_stat DESC' THEN '[tdmisg134200].[t_stat] DESC'
                        WHEN 't_user' THEN '[tdmisg134200].[t_user]'
                        WHEN 't_user DESC' THEN '[tdmisg134200].[t_user] DESC'
                        WHEN 't_date' THEN '[tdmisg134200].[t_date]'
                        WHEN 't_date DESC' THEN '[tdmisg134200].[t_date] DESC'
                        WHEN 't_sent_1' THEN '[tdmisg134200].[t_sent_1]'
                        WHEN 't_sent_1 DESC' THEN '[tdmisg134200].[t_sent_1] DESC'
                        WHEN 't_sent_2' THEN '[tdmisg134200].[t_sent_2]'
                        WHEN 't_sent_2 DESC' THEN '[tdmisg134200].[t_sent_2] DESC'
                        WHEN 't_sent_3' THEN '[tdmisg134200].[t_sent_3]'
                        WHEN 't_sent_3 DESC' THEN '[tdmisg134200].[t_sent_3] DESC'
                        WHEN 't_sent_4' THEN '[tdmisg134200].[t_sent_4]'
                        WHEN 't_sent_4 DESC' THEN '[tdmisg134200].[t_sent_4] DESC'
                        WHEN 't_sent_5' THEN '[tdmisg134200].[t_sent_5]'
                        WHEN 't_sent_5 DESC' THEN '[tdmisg134200].[t_sent_5] DESC'
                        WHEN 't_sent_6' THEN '[tdmisg134200].[t_sent_6]'
                        WHEN 't_sent_6 DESC' THEN '[tdmisg134200].[t_sent_6] DESC'
                        WHEN 't_sent_7' THEN '[tdmisg134200].[t_sent_7]'
                        WHEN 't_sent_7 DESC' THEN '[tdmisg134200].[t_sent_7] DESC'
                        WHEN 't_rece_1' THEN '[tdmisg134200].[t_rece_1]'
                        WHEN 't_rece_1 DESC' THEN '[tdmisg134200].[t_rece_1] DESC'
                        WHEN 't_rece_2' THEN '[tdmisg134200].[t_rece_2]'
                        WHEN 't_rece_2 DESC' THEN '[tdmisg134200].[t_rece_2] DESC'
                        WHEN 't_rece_3' THEN '[tdmisg134200].[t_rece_3]'
                        WHEN 't_rece_3 DESC' THEN '[tdmisg134200].[t_rece_3] DESC'
                        WHEN 't_rece_4' THEN '[tdmisg134200].[t_rece_4]'
                        WHEN 't_rece_4 DESC' THEN '[tdmisg134200].[t_rece_4] DESC'
                        WHEN 't_rece_5' THEN '[tdmisg134200].[t_rece_5]'
                        WHEN 't_rece_5 DESC' THEN '[tdmisg134200].[t_rece_5] DESC'
                        WHEN 't_rece_6' THEN '[tdmisg134200].[t_rece_6]'
                        WHEN 't_rece_6 DESC' THEN '[tdmisg134200].[t_rece_6] DESC'
                        WHEN 't_rece_7' THEN '[tdmisg134200].[t_rece_7]'
                        WHEN 't_rece_7 DESC' THEN '[tdmisg134200].[t_rece_7] DESC'
                        WHEN 't_suer' THEN '[tdmisg134200].[t_suer]'
                        WHEN 't_suer DESC' THEN '[tdmisg134200].[t_suer] DESC'
                        WHEN 't_sdat' THEN '[tdmisg134200].[t_sdat]'
                        WHEN 't_sdat DESC' THEN '[tdmisg134200].[t_sdat] DESC'
                        WHEN 't_appr' THEN '[tdmisg134200].[t_appr]'
                        WHEN 't_appr DESC' THEN '[tdmisg134200].[t_appr] DESC'
                        WHEN 't_adat' THEN '[tdmisg134200].[t_adat]'
                        WHEN 't_adat DESC' THEN '[tdmisg134200].[t_adat] DESC'
                        WHEN 't_subm_1' THEN '[tdmisg134200].[t_subm_1]'
                        WHEN 't_subm_1 DESC' THEN '[tdmisg134200].[t_subm_1] DESC'
                        WHEN 't_subm_2' THEN '[tdmisg134200].[t_subm_2]'
                        WHEN 't_subm_2 DESC' THEN '[tdmisg134200].[t_subm_2] DESC'
                        WHEN 't_subm_3' THEN '[tdmisg134200].[t_subm_3]'
                        WHEN 't_subm_3 DESC' THEN '[tdmisg134200].[t_subm_3] DESC'
                        WHEN 't_subm_4' THEN '[tdmisg134200].[t_subm_4]'
                        WHEN 't_subm_4 DESC' THEN '[tdmisg134200].[t_subm_4] DESC'
                        WHEN 't_subm_5' THEN '[tdmisg134200].[t_subm_5]'
                        WHEN 't_subm_5 DESC' THEN '[tdmisg134200].[t_subm_5] DESC'
                        WHEN 't_subm_6' THEN '[tdmisg134200].[t_subm_6]'
                        WHEN 't_subm_6 DESC' THEN '[tdmisg134200].[t_subm_6] DESC'
                        WHEN 't_subm_7' THEN '[tdmisg134200].[t_subm_7]'
                        WHEN 't_subm_7 DESC' THEN '[tdmisg134200].[t_subm_7] DESC'
                        WHEN 't_orno' THEN '[tdmisg134200].[t_orno]'
                        WHEN 't_orno DESC' THEN '[tdmisg134200].[t_orno] DESC'
                        WHEN 't_pono' THEN '[tdmisg134200].[t_pono]'
                        WHEN 't_pono DESC' THEN '[tdmisg134200].[t_pono] DESC'
                        WHEN 't_trno' THEN '[tdmisg134200].[t_trno]'
                        WHEN 't_trno DESC' THEN '[tdmisg134200].[t_trno] DESC'
                        WHEN 't_Refcntd' THEN '[tdmisg134200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[tdmisg134200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[tdmisg134200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[tdmisg134200].[t_Refcntu] DESC'
                        WHEN 't_docn' THEN '[tdmisg134200].[t_docn]'
                        WHEN 't_docn DESC' THEN '[tdmisg134200].[t_docn] DESC'
                        WHEN 't_eunt' THEN '[tdmisg134200].[t_eunt]'
                        WHEN 't_eunt DESC' THEN '[tdmisg134200].[t_eunt] DESC'
                        ELSE '[tdmisg134200].[t_rcno],[tdmisg134200].[t_revn]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [tdmisg134200].*  
  FROM [tdmisg134200] 
      INNER JOIN #PageIndex
          ON [tdmisg134200].[t_rcno] = #PageIndex.t_rcno
          AND [tdmisg134200].[t_revn] = #PageIndex.t_revn
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecHInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecHInsert]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecHInsert]
  @t_rcno VarChar(9),
  @t_revn VarChar(20),
  @t_cprj VarChar(9),
  @t_item VarChar(47),
  @t_bpid VarChar(9),
  @t_nama VarChar(35),
  @t_stat Int,
  @t_user VarChar(16),
  @t_date DateTime,
  @t_sent_1 Int,
  @t_sent_2 Int,
  @t_sent_3 Int,
  @t_sent_4 Int,
  @t_sent_5 Int,
  @t_sent_6 Int,
  @t_sent_7 Int,
  @t_rece_1 Int,
  @t_rece_2 Int,
  @t_rece_3 Int,
  @t_rece_4 Int,
  @t_rece_5 Int,
  @t_rece_6 Int,
  @t_rece_7 Int,
  @t_suer VarChar(16),
  @t_sdat DateTime,
  @t_appr VarChar(16),
  @t_adat DateTime,
  @t_subm_1 Int,
  @t_subm_2 Int,
  @t_subm_3 Int,
  @t_subm_4 Int,
  @t_subm_5 Int,
  @t_subm_6 Int,
  @t_subm_7 Int,
  @t_orno VarChar(9),
  @t_pono Int,
  @t_trno VarChar(9),
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_docn VarChar(3),
  @t_eunt VarChar(6),
  @Return_t_rcno VarChar(9) = null OUTPUT, 
  @Return_t_revn VarChar(20) = null OUTPUT 
  AS
  INSERT [tdmisg134200]
  (
   [t_rcno]
  ,[t_revn]
  ,[t_cprj]
  ,[t_item]
  ,[t_bpid]
  ,[t_nama]
  ,[t_stat]
  ,[t_user]
  ,[t_date]
  ,[t_sent_1]
  ,[t_sent_2]
  ,[t_sent_3]
  ,[t_sent_4]
  ,[t_sent_5]
  ,[t_sent_6]
  ,[t_sent_7]
  ,[t_rece_1]
  ,[t_rece_2]
  ,[t_rece_3]
  ,[t_rece_4]
  ,[t_rece_5]
  ,[t_rece_6]
  ,[t_rece_7]
  ,[t_suer]
  ,[t_sdat]
  ,[t_appr]
  ,[t_adat]
  ,[t_subm_1]
  ,[t_subm_2]
  ,[t_subm_3]
  ,[t_subm_4]
  ,[t_subm_5]
  ,[t_subm_6]
  ,[t_subm_7]
  ,[t_orno]
  ,[t_pono]
  ,[t_trno]
  ,[t_Refcntd]
  ,[t_Refcntu]
  ,[t_docn]
  ,[t_eunt]
  )
  VALUES
  (
   UPPER(@t_rcno)
  ,UPPER(@t_revn)
  ,@t_cprj
  ,@t_item
  ,@t_bpid
  ,@t_nama
  ,@t_stat
  ,@t_user
  ,@t_date
  ,@t_sent_1
  ,@t_sent_2
  ,@t_sent_3
  ,@t_sent_4
  ,@t_sent_5
  ,@t_sent_6
  ,@t_sent_7
  ,@t_rece_1
  ,@t_rece_2
  ,@t_rece_3
  ,@t_rece_4
  ,@t_rece_5
  ,@t_rece_6
  ,@t_rece_7
  ,@t_suer
  ,@t_sdat
  ,@t_appr
  ,@t_adat
  ,@t_subm_1
  ,@t_subm_2
  ,@t_subm_3
  ,@t_subm_4
  ,@t_subm_5
  ,@t_subm_6
  ,@t_subm_7
  ,@t_orno
  ,@t_pono
  ,@t_trno
  ,@t_Refcntd
  ,@t_Refcntu
  ,@t_docn
  ,@t_eunt
  )
  SET @Return_t_rcno = @t_rcno
  SET @Return_t_revn = @t_revn
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecHUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecHUpdate]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecHUpdate]
  @Original_t_rcno VarChar(9), 
  @Original_t_revn VarChar(20), 
  @t_rcno VarChar(9),
  @t_revn VarChar(20),
  @t_cprj VarChar(9),
  @t_item VarChar(47),
  @t_bpid VarChar(9),
  @t_nama VarChar(35),
  @t_stat Int,
  @t_user VarChar(16),
  @t_date DateTime,
  @t_sent_1 Int,
  @t_sent_2 Int,
  @t_sent_3 Int,
  @t_sent_4 Int,
  @t_sent_5 Int,
  @t_sent_6 Int,
  @t_sent_7 Int,
  @t_rece_1 Int,
  @t_rece_2 Int,
  @t_rece_3 Int,
  @t_rece_4 Int,
  @t_rece_5 Int,
  @t_rece_6 Int,
  @t_rece_7 Int,
  @t_suer VarChar(16),
  @t_sdat DateTime,
  @t_appr VarChar(16),
  @t_adat DateTime,
  @t_subm_1 Int,
  @t_subm_2 Int,
  @t_subm_3 Int,
  @t_subm_4 Int,
  @t_subm_5 Int,
  @t_subm_6 Int,
  @t_subm_7 Int,
  @t_orno VarChar(9),
  @t_pono Int,
  @t_trno VarChar(9),
  @t_Refcntd Int,
  @t_Refcntu Int,
  @t_docn VarChar(3),
  @t_eunt VarChar(6),
  @RowCount int = null OUTPUT
  AS
  UPDATE [tdmisg134200] SET 
   [t_rcno] = @t_rcno
  ,[t_revn] = @t_revn
  ,[t_cprj] = @t_cprj
  ,[t_item] = @t_item
  ,[t_bpid] = @t_bpid
  ,[t_nama] = @t_nama
  ,[t_stat] = @t_stat
  ,[t_user] = @t_user
  ,[t_date] = @t_date
  ,[t_sent_1] = @t_sent_1
  ,[t_sent_2] = @t_sent_2
  ,[t_sent_3] = @t_sent_3
  ,[t_sent_4] = @t_sent_4
  ,[t_sent_5] = @t_sent_5
  ,[t_sent_6] = @t_sent_6
  ,[t_sent_7] = @t_sent_7
  ,[t_rece_1] = @t_rece_1
  ,[t_rece_2] = @t_rece_2
  ,[t_rece_3] = @t_rece_3
  ,[t_rece_4] = @t_rece_4
  ,[t_rece_5] = @t_rece_5
  ,[t_rece_6] = @t_rece_6
  ,[t_rece_7] = @t_rece_7
  ,[t_suer] = @t_suer
  ,[t_sdat] = @t_sdat
  ,[t_appr] = @t_appr
  ,[t_adat] = @t_adat
  ,[t_subm_1] = @t_subm_1
  ,[t_subm_2] = @t_subm_2
  ,[t_subm_3] = @t_subm_3
  ,[t_subm_4] = @t_subm_4
  ,[t_subm_5] = @t_subm_5
  ,[t_subm_6] = @t_subm_6
  ,[t_subm_7] = @t_subm_7
  ,[t_orno] = @t_orno
  ,[t_pono] = @t_pono
  ,[t_trno] = @t_trno
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  ,[t_docn] = @t_docn
  ,[t_eunt] = @t_eunt
  WHERE
  [t_rcno] = @Original_t_rcno
  AND [t_revn] = @Original_t_revn
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecHDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecHDelete]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecHDelete]
  @Original_t_rcno VarChar(9),
  @Original_t_revn VarChar(20),
  @RowCount int = null OUTPUT
  AS
  DELETE [tdmisg134200]
  WHERE
  [tdmisg134200].[t_rcno] = @Original_t_rcno
  AND [tdmisg134200].[t_revn] = @Original_t_revn
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecDSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecDSelectByID]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecDSelectByID]
  @LoginID NVarChar(8),
  @t_rcno VarChar(9),
  @t_revn VarChar(20),
  @t_srno Int 
  AS
  SELECT
    [tdmisg135200].*  
  FROM [tdmisg135200] 
  WHERE
  [tdmisg135200].[t_rcno] = @t_rcno
  AND [tdmisg135200].[t_revn] = @t_revn
  AND [tdmisg135200].[t_srno] = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecDSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecDSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecDSelectListSearch]
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
 ,t_rcno VarChar(9) NOT NULL
 ,t_revn VarChar(20) NOT NULL
 ,t_srno Int NOT NULL
  )
  INSERT INTO #PageIndex (t_rcno, t_revn, t_srno)
  SELECT [tdmisg135200].[t_rcno], [tdmisg135200].[t_revn], [tdmisg135200].[t_srno] FROM [tdmisg135200]
 WHERE  
   ( 
         LOWER(ISNULL([tdmisg135200].[t_rcno],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg135200].[t_revn],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg135200].[t_srno], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg135200].[t_docn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg135200].[t_revi],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg135200].[t_dsca],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg135200].[t_idoc],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg135200].[t_irev],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg135200].[t_remk],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg135200].[t_proc], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg135200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg135200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_rcno' THEN [tdmisg135200].[t_rcno] END,
     CASE @OrderBy WHEN 't_rcno DESC' THEN [tdmisg135200].[t_rcno] END DESC,
     CASE @OrderBy WHEN 't_revn' THEN [tdmisg135200].[t_revn] END,
     CASE @OrderBy WHEN 't_revn DESC' THEN [tdmisg135200].[t_revn] END DESC,
     CASE @OrderBy WHEN 't_srno' THEN [tdmisg135200].[t_srno] END,
     CASE @OrderBy WHEN 't_srno DESC' THEN [tdmisg135200].[t_srno] END DESC,
     CASE @OrderBy WHEN 't_docn' THEN [tdmisg135200].[t_docn] END,
     CASE @OrderBy WHEN 't_docn DESC' THEN [tdmisg135200].[t_docn] END DESC,
     CASE @OrderBy WHEN 't_revi' THEN [tdmisg135200].[t_revi] END,
     CASE @OrderBy WHEN 't_revi DESC' THEN [tdmisg135200].[t_revi] END DESC,
     CASE @OrderBy WHEN 't_dsca' THEN [tdmisg135200].[t_dsca] END,
     CASE @OrderBy WHEN 't_dsca DESC' THEN [tdmisg135200].[t_dsca] END DESC,
     CASE @OrderBy WHEN 't_idoc' THEN [tdmisg135200].[t_idoc] END,
     CASE @OrderBy WHEN 't_idoc DESC' THEN [tdmisg135200].[t_idoc] END DESC,
     CASE @OrderBy WHEN 't_irev' THEN [tdmisg135200].[t_irev] END,
     CASE @OrderBy WHEN 't_irev DESC' THEN [tdmisg135200].[t_irev] END DESC,
     CASE @OrderBy WHEN 't_date' THEN [tdmisg135200].[t_date] END,
     CASE @OrderBy WHEN 't_date DESC' THEN [tdmisg135200].[t_date] END DESC,
     CASE @OrderBy WHEN 't_remk' THEN [tdmisg135200].[t_remk] END,
     CASE @OrderBy WHEN 't_remk DESC' THEN [tdmisg135200].[t_remk] END DESC,
     CASE @OrderBy WHEN 't_proc' THEN [tdmisg135200].[t_proc] END,
     CASE @OrderBy WHEN 't_proc DESC' THEN [tdmisg135200].[t_proc] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [tdmisg135200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [tdmisg135200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [tdmisg135200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [tdmisg135200].[t_Refcntu] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [tdmisg135200].*  
  FROM [tdmisg135200] 
      INNER JOIN #PageIndex
          ON [tdmisg135200].[t_rcno] = #PageIndex.t_rcno
          AND [tdmisg135200].[t_revn] = #PageIndex.t_revn
          AND [tdmisg135200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecDSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecDSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecDSelectListFilteres]
  @Filter_t_rcno VarChar(9),
  @Filter_t_revn VarChar(20),
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
 ,t_rcno VarChar(9) NOT NULL
 ,t_revn VarChar(20) NOT NULL
 ,t_srno Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_rcno'
  SET @LGSQL = @LGSQL + ', t_revn'
  SET @LGSQL = @LGSQL + ', t_srno'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[tdmisg135200].[t_rcno]'
  SET @LGSQL = @LGSQL + ', [tdmisg135200].[t_revn]'
  SET @LGSQL = @LGSQL + ', [tdmisg135200].[t_srno]'
  SET @LGSQL = @LGSQL + ' FROM [tdmisg135200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_rcno > '') 
    SET @LGSQL = @LGSQL + ' AND [tdmisg135200].[t_rcno] = ''' + @Filter_t_rcno + ''''
  IF (@Filter_t_revn > '') 
    SET @LGSQL = @LGSQL + ' AND [tdmisg135200].[t_revn] = ''' + @Filter_t_revn + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_rcno' THEN '[tdmisg135200].[t_rcno]'
                        WHEN 't_rcno DESC' THEN '[tdmisg135200].[t_rcno] DESC'
                        WHEN 't_revn' THEN '[tdmisg135200].[t_revn]'
                        WHEN 't_revn DESC' THEN '[tdmisg135200].[t_revn] DESC'
                        WHEN 't_srno' THEN '[tdmisg135200].[t_srno]'
                        WHEN 't_srno DESC' THEN '[tdmisg135200].[t_srno] DESC'
                        WHEN 't_docn' THEN '[tdmisg135200].[t_docn]'
                        WHEN 't_docn DESC' THEN '[tdmisg135200].[t_docn] DESC'
                        WHEN 't_revi' THEN '[tdmisg135200].[t_revi]'
                        WHEN 't_revi DESC' THEN '[tdmisg135200].[t_revi] DESC'
                        WHEN 't_dsca' THEN '[tdmisg135200].[t_dsca]'
                        WHEN 't_dsca DESC' THEN '[tdmisg135200].[t_dsca] DESC'
                        WHEN 't_idoc' THEN '[tdmisg135200].[t_idoc]'
                        WHEN 't_idoc DESC' THEN '[tdmisg135200].[t_idoc] DESC'
                        WHEN 't_irev' THEN '[tdmisg135200].[t_irev]'
                        WHEN 't_irev DESC' THEN '[tdmisg135200].[t_irev] DESC'
                        WHEN 't_date' THEN '[tdmisg135200].[t_date]'
                        WHEN 't_date DESC' THEN '[tdmisg135200].[t_date] DESC'
                        WHEN 't_remk' THEN '[tdmisg135200].[t_remk]'
                        WHEN 't_remk DESC' THEN '[tdmisg135200].[t_remk] DESC'
                        WHEN 't_proc' THEN '[tdmisg135200].[t_proc]'
                        WHEN 't_proc DESC' THEN '[tdmisg135200].[t_proc] DESC'
                        WHEN 't_Refcntd' THEN '[tdmisg135200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[tdmisg135200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[tdmisg135200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[tdmisg135200].[t_Refcntu] DESC'
                        ELSE '[tdmisg135200].[t_rcno],[tdmisg135200].[t_revn],[tdmisg135200].[t_srno]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [tdmisg135200].*  
  FROM [tdmisg135200] 
      INNER JOIN #PageIndex
          ON [tdmisg135200].[t_rcno] = #PageIndex.t_rcno
          AND [tdmisg135200].[t_revn] = #PageIndex.t_revn
          AND [tdmisg135200].[t_srno] = #PageIndex.t_srno
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecDInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecDInsert]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecDInsert]
  @t_rcno VarChar(9),
  @t_revn VarChar(20),
  @t_srno Int,
  @t_docn VarChar(32),
  @t_revi VarChar(20),
  @t_dsca VarChar(100),
  @t_idoc VarChar(32),
  @t_irev VarChar(20),
  @t_date DateTime,
  @t_remk VarChar(100),
  @t_proc Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @Return_t_rcno VarChar(9) = null OUTPUT, 
  @Return_t_revn VarChar(20) = null OUTPUT, 
  @Return_t_srno Int = null OUTPUT 
  AS
  INSERT [tdmisg135200]
  (
   [t_rcno]
  ,[t_revn]
  ,[t_srno]
  ,[t_docn]
  ,[t_revi]
  ,[t_dsca]
  ,[t_idoc]
  ,[t_irev]
  ,[t_date]
  ,[t_remk]
  ,[t_proc]
  ,[t_Refcntd]
  ,[t_Refcntu]
  )
  VALUES
  (
   UPPER(@t_rcno)
  ,UPPER(@t_revn)
  ,@t_srno
  ,@t_docn
  ,@t_revi
  ,@t_dsca
  ,@t_idoc
  ,@t_irev
  ,@t_date
  ,@t_remk
  ,@t_proc
  ,@t_Refcntd
  ,@t_Refcntu
  )
  SET @Return_t_rcno = @t_rcno
  SET @Return_t_revn = @t_revn
  SET @Return_t_srno = @t_srno
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecDUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecDUpdate]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecDUpdate]
  @Original_t_rcno VarChar(9), 
  @Original_t_revn VarChar(20), 
  @Original_t_srno Int, 
  @t_rcno VarChar(9),
  @t_revn VarChar(20),
  @t_srno Int,
  @t_docn VarChar(32),
  @t_revi VarChar(20),
  @t_dsca VarChar(100),
  @t_idoc VarChar(32),
  @t_irev VarChar(20),
  @t_date DateTime,
  @t_remk VarChar(100),
  @t_proc Int,
  @t_Refcntd Int,
  @t_Refcntu Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [tdmisg135200] SET 
   [t_rcno] = @t_rcno
  ,[t_revn] = @t_revn
  ,[t_srno] = @t_srno
  ,[t_docn] = @t_docn
  ,[t_revi] = @t_revi
  ,[t_dsca] = @t_dsca
  ,[t_idoc] = @t_idoc
  ,[t_irev] = @t_irev
  ,[t_date] = @t_date
  ,[t_remk] = @t_remk
  ,[t_proc] = @t_proc
  ,[t_Refcntd] = @t_Refcntd
  ,[t_Refcntu] = @t_Refcntu
  WHERE
  [t_rcno] = @Original_t_rcno
  AND [t_revn] = @Original_t_revn
  AND [t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPRecDDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPRecDDelete]
GO
 
CREATE PROCEDURE [dbo].[sppakERPRecDDelete]
  @Original_t_rcno VarChar(9),
  @Original_t_revn VarChar(20),
  @Original_t_srno Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [tdmisg135200]
  WHERE
  [tdmisg135200].[t_rcno] = @Original_t_rcno
  AND [tdmisg135200].[t_revn] = @Original_t_revn
  AND [tdmisg135200].[t_srno] = @Original_t_srno
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPOLineSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPOLineSelectByID]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPOLineSelectByID]
  @LoginID NVarChar(8),
  @t_orno VarChar(9),
  @t_pono Int 
  AS
  SELECT
    [ttdpur401200].*  
  FROM [ttdpur401200] 
  WHERE
  [ttdpur401200].[t_orno] = @t_orno
  AND [ttdpur401200].[t_pono] = @t_pono
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPOLineSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPOLineSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPOLineSelectListSearch]
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
 ,t_pono Int NOT NULL
  )
  INSERT INTO #PageIndex (t_orno, t_pono)
  SELECT [ttdpur401200].[t_orno], [ttdpur401200].[t_pono] FROM [ttdpur401200]
 WHERE  
   ( 
         LOWER(ISNULL([ttdpur401200].[t_orno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pono], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_item],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_qoor], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cuqp],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_pric], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdpur401200].[t_oamt], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdpur401200].[t_cspa],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdpur401200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdpur401200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_pono' THEN [ttdpur401200].[t_pono] END,
     CASE @OrderBy WHEN 't_pono DESC' THEN [ttdpur401200].[t_pono] END DESC,
     CASE @OrderBy WHEN 't_item' THEN [ttdpur401200].[t_item] END,
     CASE @OrderBy WHEN 't_item DESC' THEN [ttdpur401200].[t_item] END DESC,
     CASE @OrderBy WHEN 't_qoor' THEN [ttdpur401200].[t_qoor] END,
     CASE @OrderBy WHEN 't_qoor DESC' THEN [ttdpur401200].[t_qoor] END DESC,
     CASE @OrderBy WHEN 't_cuqp' THEN [ttdpur401200].[t_cuqp] END,
     CASE @OrderBy WHEN 't_cuqp DESC' THEN [ttdpur401200].[t_cuqp] END DESC,
     CASE @OrderBy WHEN 't_pric' THEN [ttdpur401200].[t_pric] END,
     CASE @OrderBy WHEN 't_pric DESC' THEN [ttdpur401200].[t_pric] END DESC,
     CASE @OrderBy WHEN 't_oamt' THEN [ttdpur401200].[t_oamt] END,
     CASE @OrderBy WHEN 't_oamt DESC' THEN [ttdpur401200].[t_oamt] END DESC,
     CASE @OrderBy WHEN 't_cprj' THEN [ttdpur401200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [ttdpur401200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_cspa' THEN [ttdpur401200].[t_cspa] END,
     CASE @OrderBy WHEN 't_cspa DESC' THEN [ttdpur401200].[t_cspa] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttdpur401200].*  
  FROM [ttdpur401200] 
      INNER JOIN #PageIndex
          ON [ttdpur401200].[t_orno] = #PageIndex.t_orno
          AND [ttdpur401200].[t_pono] = #PageIndex.t_pono
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPOLineSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPOLineSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPOLineSelectListFilteres]
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
 ,t_pono Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_orno'
  SET @LGSQL = @LGSQL + ', t_pono'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttdpur401200].[t_orno]'
  SET @LGSQL = @LGSQL + ', [ttdpur401200].[t_pono]'
  SET @LGSQL = @LGSQL + ' FROM [ttdpur401200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_orno' THEN '[ttdpur401200].[t_orno]'
                        WHEN 't_orno DESC' THEN '[ttdpur401200].[t_orno] DESC'
                        WHEN 't_pono' THEN '[ttdpur401200].[t_pono]'
                        WHEN 't_pono DESC' THEN '[ttdpur401200].[t_pono] DESC'
                        WHEN 't_item' THEN '[ttdpur401200].[t_item]'
                        WHEN 't_item DESC' THEN '[ttdpur401200].[t_item] DESC'
                        WHEN 't_qoor' THEN '[ttdpur401200].[t_qoor]'
                        WHEN 't_qoor DESC' THEN '[ttdpur401200].[t_qoor] DESC'
                        WHEN 't_cuqp' THEN '[ttdpur401200].[t_cuqp]'
                        WHEN 't_cuqp DESC' THEN '[ttdpur401200].[t_cuqp] DESC'
                        WHEN 't_pric' THEN '[ttdpur401200].[t_pric]'
                        WHEN 't_pric DESC' THEN '[ttdpur401200].[t_pric] DESC'
                        WHEN 't_oamt' THEN '[ttdpur401200].[t_oamt]'
                        WHEN 't_oamt DESC' THEN '[ttdpur401200].[t_oamt] DESC'
                        WHEN 't_cprj' THEN '[ttdpur401200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[ttdpur401200].[t_cprj] DESC'
                        WHEN 't_cspa' THEN '[ttdpur401200].[t_cspa]'
                        WHEN 't_cspa DESC' THEN '[ttdpur401200].[t_cspa] DESC'
                        ELSE '[ttdpur401200].[t_orno],[ttdpur401200].[t_pono]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttdpur401200].*  
  FROM [ttdpur401200] 
      INNER JOIN #PageIndex
          ON [ttdpur401200].[t_orno] = #PageIndex.t_orno
          AND [ttdpur401200].[t_pono] = #PageIndex.t_pono
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
