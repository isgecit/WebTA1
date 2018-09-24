SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spediWTmtlHSelectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spediWTmtlHSelectList]
GO
 
CREATE PROCEDURE [dbo].[spediWTmtlHSelectList]
  @LoginID NVarChar(8),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
    [tdmisg131200].*  
  FROM [tdmisg131200] 
  WHERE 1 = 1  
  ORDER BY
     CASE @OrderBy WHEN 't_tran' THEN [tdmisg131200].[t_tran] END,
     CASE @OrderBy WHEN 't_tran DESC' THEN [tdmisg131200].[t_tran] END DESC,
     CASE @OrderBy WHEN 't_type' THEN [tdmisg131200].[t_type] END,
     CASE @OrderBy WHEN 't_type DESC' THEN [tdmisg131200].[t_type] END DESC,
     CASE @OrderBy WHEN 't_bpid' THEN [tdmisg131200].[t_bpid] END,
     CASE @OrderBy WHEN 't_bpid DESC' THEN [tdmisg131200].[t_bpid] END DESC,
     CASE @OrderBy WHEN 't_cadr' THEN [tdmisg131200].[t_cadr] END,
     CASE @OrderBy WHEN 't_cadr DESC' THEN [tdmisg131200].[t_cadr] END DESC,
     CASE @OrderBy WHEN 't_cprj' THEN [tdmisg131200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [tdmisg131200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_logn' THEN [tdmisg131200].[t_logn] END,
     CASE @OrderBy WHEN 't_logn DESC' THEN [tdmisg131200].[t_logn] END DESC,
     CASE @OrderBy WHEN 't_subj' THEN [tdmisg131200].[t_subj] END,
     CASE @OrderBy WHEN 't_subj DESC' THEN [tdmisg131200].[t_subj] END DESC,
     CASE @OrderBy WHEN 't_remk' THEN [tdmisg131200].[t_remk] END,
     CASE @OrderBy WHEN 't_remk DESC' THEN [tdmisg131200].[t_remk] END DESC,
     CASE @OrderBy WHEN 't_issu' THEN [tdmisg131200].[t_issu] END,
     CASE @OrderBy WHEN 't_issu DESC' THEN [tdmisg131200].[t_issu] END DESC,
     CASE @OrderBy WHEN 't_stat' THEN [tdmisg131200].[t_stat] END,
     CASE @OrderBy WHEN 't_stat DESC' THEN [tdmisg131200].[t_stat] END DESC,
     CASE @OrderBy WHEN 't_ofbp' THEN [tdmisg131200].[t_ofbp] END,
     CASE @OrderBy WHEN 't_ofbp DESC' THEN [tdmisg131200].[t_ofbp] END DESC,
     CASE @OrderBy WHEN 't_vadr' THEN [tdmisg131200].[t_vadr] END,
     CASE @OrderBy WHEN 't_vadr DESC' THEN [tdmisg131200].[t_vadr] END DESC,
     CASE @OrderBy WHEN 't_padr' THEN [tdmisg131200].[t_padr] END,
     CASE @OrderBy WHEN 't_padr DESC' THEN [tdmisg131200].[t_padr] END DESC,
     CASE @OrderBy WHEN 't_dprj' THEN [tdmisg131200].[t_dprj] END,
     CASE @OrderBy WHEN 't_dprj DESC' THEN [tdmisg131200].[t_dprj] END DESC,
     CASE @OrderBy WHEN 't_user' THEN [tdmisg131200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [tdmisg131200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_date' THEN [tdmisg131200].[t_date] END,
     CASE @OrderBy WHEN 't_date DESC' THEN [tdmisg131200].[t_date] END DESC,
     CASE @OrderBy WHEN 't_subt' THEN [tdmisg131200].[t_subt] END,
     CASE @OrderBy WHEN 't_subt DESC' THEN [tdmisg131200].[t_subt] END DESC,
     CASE @OrderBy WHEN 't_refr' THEN [tdmisg131200].[t_refr] END,
     CASE @OrderBy WHEN 't_refr DESC' THEN [tdmisg131200].[t_refr] END DESC,
     CASE @OrderBy WHEN 't_appr' THEN [tdmisg131200].[t_appr] END,
     CASE @OrderBy WHEN 't_appr DESC' THEN [tdmisg131200].[t_appr] END DESC,
     CASE @OrderBy WHEN 't_rejc' THEN [tdmisg131200].[t_rejc] END,
     CASE @OrderBy WHEN 't_rejc DESC' THEN [tdmisg131200].[t_rejc] END DESC,
     CASE @OrderBy WHEN 't_rekm' THEN [tdmisg131200].[t_rekm] END,
     CASE @OrderBy WHEN 't_rekm DESC' THEN [tdmisg131200].[t_rekm] END DESC,
     CASE @OrderBy WHEN 't_apdt' THEN [tdmisg131200].[t_apdt] END,
     CASE @OrderBy WHEN 't_apdt DESC' THEN [tdmisg131200].[t_apdt] END DESC,
     CASE @OrderBy WHEN 't_apsu' THEN [tdmisg131200].[t_apsu] END,
     CASE @OrderBy WHEN 't_apsu DESC' THEN [tdmisg131200].[t_apsu] END DESC,
     CASE @OrderBy WHEN 't_irmk' THEN [tdmisg131200].[t_irmk] END,
     CASE @OrderBy WHEN 't_irmk DESC' THEN [tdmisg131200].[t_irmk] END DESC,
     CASE @OrderBy WHEN 't_iisu' THEN [tdmisg131200].[t_iisu] END,
     CASE @OrderBy WHEN 't_iisu DESC' THEN [tdmisg131200].[t_iisu] END DESC,
     CASE @OrderBy WHEN 't_retn' THEN [tdmisg131200].[t_retn] END,
     CASE @OrderBy WHEN 't_retn DESC' THEN [tdmisg131200].[t_retn] END DESC,
     CASE @OrderBy WHEN 't_smdt' THEN [tdmisg131200].[t_smdt] END,
     CASE @OrderBy WHEN 't_smdt DESC' THEN [tdmisg131200].[t_smdt] END DESC,
     CASE @OrderBy WHEN 't_isby' THEN [tdmisg131200].[t_isby] END,
     CASE @OrderBy WHEN 't_isby DESC' THEN [tdmisg131200].[t_isby] END DESC,
     CASE @OrderBy WHEN 't_isdt' THEN [tdmisg131200].[t_isdt] END,
     CASE @OrderBy WHEN 't_isdt DESC' THEN [tdmisg131200].[t_isdt] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [tdmisg131200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [tdmisg131200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [tdmisg131200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [tdmisg131200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_edif' THEN [tdmisg131200].[t_edif] END,
     CASE @OrderBy WHEN 't_edif DESC' THEN [tdmisg131200].[t_edif] END DESC 
  SET @RecordCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spediWTmtlHAutoCompleteList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spediWTmtlHAutoCompleteList]
GO
 
CREATE PROCEDURE [dbo].[spediWTmtlHAutoCompleteList]
  @LoginID NVarChar(8),
  @Prefix NVarChar(250),
  @Records Int,
  @ByCode Int 
  AS 
  BEGIN 
  DECLARE @Prefix1 VarChar(260)
  SET @Prefix1 = LOWER(@Prefix) + '%'
  DECLARE @LGSQL VarChar(8000)
  SET @LGSQL = 'SELECT TOP (' + STR(@Records) + ') ' 
  SET @LGSQL = @LGSQL + ' [tdmisg131200].[t_refr]' 
  SET @LGSQL = @LGSQL + ',[tdmisg131200].[t_tran]' 
  SET @LGSQL = @LGSQL + ' FROM [tdmisg131200] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([tdmisg131200].[t_tran],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([tdmisg131200].[t_refr],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  
  EXEC (@LGSQL)
  END 
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spediWTmtlHSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spediWTmtlHSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spediWTmtlHSelectByID]
  @LoginID NVarChar(8),
  @t_tran VarChar(9) 
  AS
  SELECT
    [tdmisg131200].*  
  FROM [tdmisg131200] 
  WHERE
  [tdmisg131200].[t_tran] = @t_tran
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spediWTmtlHSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spediWTmtlHSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spediWTmtlHSelectListSearch]
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
 ,t_tran VarChar(9) NOT NULL
  )
  INSERT INTO #PageIndex (t_tran)
  SELECT [tdmisg131200].[t_tran] FROM [tdmisg131200]
 WHERE  
   ( 
         LOWER(ISNULL([tdmisg131200].[t_tran],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_type], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_bpid],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_cadr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_cprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_logn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_subj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_remk],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_issu],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_stat], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_ofbp],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_vadr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_padr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_dprj],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_user],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_subt], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_refr],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_appr], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_rejc], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_rekm],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_apsu],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_irmk],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_iisu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_retn], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg131200].[t_isby],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg131200].[t_edif], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_tran' THEN [tdmisg131200].[t_tran] END,
     CASE @OrderBy WHEN 't_tran DESC' THEN [tdmisg131200].[t_tran] END DESC,
     CASE @OrderBy WHEN 't_type' THEN [tdmisg131200].[t_type] END,
     CASE @OrderBy WHEN 't_type DESC' THEN [tdmisg131200].[t_type] END DESC,
     CASE @OrderBy WHEN 't_bpid' THEN [tdmisg131200].[t_bpid] END,
     CASE @OrderBy WHEN 't_bpid DESC' THEN [tdmisg131200].[t_bpid] END DESC,
     CASE @OrderBy WHEN 't_cadr' THEN [tdmisg131200].[t_cadr] END,
     CASE @OrderBy WHEN 't_cadr DESC' THEN [tdmisg131200].[t_cadr] END DESC,
     CASE @OrderBy WHEN 't_cprj' THEN [tdmisg131200].[t_cprj] END,
     CASE @OrderBy WHEN 't_cprj DESC' THEN [tdmisg131200].[t_cprj] END DESC,
     CASE @OrderBy WHEN 't_logn' THEN [tdmisg131200].[t_logn] END,
     CASE @OrderBy WHEN 't_logn DESC' THEN [tdmisg131200].[t_logn] END DESC,
     CASE @OrderBy WHEN 't_subj' THEN [tdmisg131200].[t_subj] END,
     CASE @OrderBy WHEN 't_subj DESC' THEN [tdmisg131200].[t_subj] END DESC,
     CASE @OrderBy WHEN 't_remk' THEN [tdmisg131200].[t_remk] END,
     CASE @OrderBy WHEN 't_remk DESC' THEN [tdmisg131200].[t_remk] END DESC,
     CASE @OrderBy WHEN 't_issu' THEN [tdmisg131200].[t_issu] END,
     CASE @OrderBy WHEN 't_issu DESC' THEN [tdmisg131200].[t_issu] END DESC,
     CASE @OrderBy WHEN 't_stat' THEN [tdmisg131200].[t_stat] END,
     CASE @OrderBy WHEN 't_stat DESC' THEN [tdmisg131200].[t_stat] END DESC,
     CASE @OrderBy WHEN 't_ofbp' THEN [tdmisg131200].[t_ofbp] END,
     CASE @OrderBy WHEN 't_ofbp DESC' THEN [tdmisg131200].[t_ofbp] END DESC,
     CASE @OrderBy WHEN 't_vadr' THEN [tdmisg131200].[t_vadr] END,
     CASE @OrderBy WHEN 't_vadr DESC' THEN [tdmisg131200].[t_vadr] END DESC,
     CASE @OrderBy WHEN 't_padr' THEN [tdmisg131200].[t_padr] END,
     CASE @OrderBy WHEN 't_padr DESC' THEN [tdmisg131200].[t_padr] END DESC,
     CASE @OrderBy WHEN 't_dprj' THEN [tdmisg131200].[t_dprj] END,
     CASE @OrderBy WHEN 't_dprj DESC' THEN [tdmisg131200].[t_dprj] END DESC,
     CASE @OrderBy WHEN 't_user' THEN [tdmisg131200].[t_user] END,
     CASE @OrderBy WHEN 't_user DESC' THEN [tdmisg131200].[t_user] END DESC,
     CASE @OrderBy WHEN 't_date' THEN [tdmisg131200].[t_date] END,
     CASE @OrderBy WHEN 't_date DESC' THEN [tdmisg131200].[t_date] END DESC,
     CASE @OrderBy WHEN 't_subt' THEN [tdmisg131200].[t_subt] END,
     CASE @OrderBy WHEN 't_subt DESC' THEN [tdmisg131200].[t_subt] END DESC,
     CASE @OrderBy WHEN 't_refr' THEN [tdmisg131200].[t_refr] END,
     CASE @OrderBy WHEN 't_refr DESC' THEN [tdmisg131200].[t_refr] END DESC,
     CASE @OrderBy WHEN 't_appr' THEN [tdmisg131200].[t_appr] END,
     CASE @OrderBy WHEN 't_appr DESC' THEN [tdmisg131200].[t_appr] END DESC,
     CASE @OrderBy WHEN 't_rejc' THEN [tdmisg131200].[t_rejc] END,
     CASE @OrderBy WHEN 't_rejc DESC' THEN [tdmisg131200].[t_rejc] END DESC,
     CASE @OrderBy WHEN 't_rekm' THEN [tdmisg131200].[t_rekm] END,
     CASE @OrderBy WHEN 't_rekm DESC' THEN [tdmisg131200].[t_rekm] END DESC,
     CASE @OrderBy WHEN 't_apdt' THEN [tdmisg131200].[t_apdt] END,
     CASE @OrderBy WHEN 't_apdt DESC' THEN [tdmisg131200].[t_apdt] END DESC,
     CASE @OrderBy WHEN 't_apsu' THEN [tdmisg131200].[t_apsu] END,
     CASE @OrderBy WHEN 't_apsu DESC' THEN [tdmisg131200].[t_apsu] END DESC,
     CASE @OrderBy WHEN 't_irmk' THEN [tdmisg131200].[t_irmk] END,
     CASE @OrderBy WHEN 't_irmk DESC' THEN [tdmisg131200].[t_irmk] END DESC,
     CASE @OrderBy WHEN 't_iisu' THEN [tdmisg131200].[t_iisu] END,
     CASE @OrderBy WHEN 't_iisu DESC' THEN [tdmisg131200].[t_iisu] END DESC,
     CASE @OrderBy WHEN 't_retn' THEN [tdmisg131200].[t_retn] END,
     CASE @OrderBy WHEN 't_retn DESC' THEN [tdmisg131200].[t_retn] END DESC,
     CASE @OrderBy WHEN 't_smdt' THEN [tdmisg131200].[t_smdt] END,
     CASE @OrderBy WHEN 't_smdt DESC' THEN [tdmisg131200].[t_smdt] END DESC,
     CASE @OrderBy WHEN 't_isby' THEN [tdmisg131200].[t_isby] END,
     CASE @OrderBy WHEN 't_isby DESC' THEN [tdmisg131200].[t_isby] END DESC,
     CASE @OrderBy WHEN 't_isdt' THEN [tdmisg131200].[t_isdt] END,
     CASE @OrderBy WHEN 't_isdt DESC' THEN [tdmisg131200].[t_isdt] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [tdmisg131200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [tdmisg131200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [tdmisg131200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [tdmisg131200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 't_edif' THEN [tdmisg131200].[t_edif] END,
     CASE @OrderBy WHEN 't_edif DESC' THEN [tdmisg131200].[t_edif] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [tdmisg131200].*  
  FROM [tdmisg131200] 
      INNER JOIN #PageIndex
          ON [tdmisg131200].[t_tran] = #PageIndex.t_tran
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spediWTmtlHSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spediWTmtlHSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spediWTmtlHSelectListFilteres]
  @Filter_t_tran VarChar(9),
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
 ,t_tran VarChar(9) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_tran'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[tdmisg131200].[t_tran]'
  SET @LGSQL = @LGSQL + ' FROM [tdmisg131200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_tran > '') 
    SET @LGSQL = @LGSQL + ' AND [tdmisg131200].[t_tran] = ''' + @Filter_t_tran + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_tran' THEN '[tdmisg131200].[t_tran]'
                        WHEN 't_tran DESC' THEN '[tdmisg131200].[t_tran] DESC'
                        WHEN 't_type' THEN '[tdmisg131200].[t_type]'
                        WHEN 't_type DESC' THEN '[tdmisg131200].[t_type] DESC'
                        WHEN 't_bpid' THEN '[tdmisg131200].[t_bpid]'
                        WHEN 't_bpid DESC' THEN '[tdmisg131200].[t_bpid] DESC'
                        WHEN 't_cadr' THEN '[tdmisg131200].[t_cadr]'
                        WHEN 't_cadr DESC' THEN '[tdmisg131200].[t_cadr] DESC'
                        WHEN 't_cprj' THEN '[tdmisg131200].[t_cprj]'
                        WHEN 't_cprj DESC' THEN '[tdmisg131200].[t_cprj] DESC'
                        WHEN 't_logn' THEN '[tdmisg131200].[t_logn]'
                        WHEN 't_logn DESC' THEN '[tdmisg131200].[t_logn] DESC'
                        WHEN 't_subj' THEN '[tdmisg131200].[t_subj]'
                        WHEN 't_subj DESC' THEN '[tdmisg131200].[t_subj] DESC'
                        WHEN 't_remk' THEN '[tdmisg131200].[t_remk]'
                        WHEN 't_remk DESC' THEN '[tdmisg131200].[t_remk] DESC'
                        WHEN 't_issu' THEN '[tdmisg131200].[t_issu]'
                        WHEN 't_issu DESC' THEN '[tdmisg131200].[t_issu] DESC'
                        WHEN 't_stat' THEN '[tdmisg131200].[t_stat]'
                        WHEN 't_stat DESC' THEN '[tdmisg131200].[t_stat] DESC'
                        WHEN 't_ofbp' THEN '[tdmisg131200].[t_ofbp]'
                        WHEN 't_ofbp DESC' THEN '[tdmisg131200].[t_ofbp] DESC'
                        WHEN 't_vadr' THEN '[tdmisg131200].[t_vadr]'
                        WHEN 't_vadr DESC' THEN '[tdmisg131200].[t_vadr] DESC'
                        WHEN 't_padr' THEN '[tdmisg131200].[t_padr]'
                        WHEN 't_padr DESC' THEN '[tdmisg131200].[t_padr] DESC'
                        WHEN 't_dprj' THEN '[tdmisg131200].[t_dprj]'
                        WHEN 't_dprj DESC' THEN '[tdmisg131200].[t_dprj] DESC'
                        WHEN 't_user' THEN '[tdmisg131200].[t_user]'
                        WHEN 't_user DESC' THEN '[tdmisg131200].[t_user] DESC'
                        WHEN 't_date' THEN '[tdmisg131200].[t_date]'
                        WHEN 't_date DESC' THEN '[tdmisg131200].[t_date] DESC'
                        WHEN 't_subt' THEN '[tdmisg131200].[t_subt]'
                        WHEN 't_subt DESC' THEN '[tdmisg131200].[t_subt] DESC'
                        WHEN 't_refr' THEN '[tdmisg131200].[t_refr]'
                        WHEN 't_refr DESC' THEN '[tdmisg131200].[t_refr] DESC'
                        WHEN 't_appr' THEN '[tdmisg131200].[t_appr]'
                        WHEN 't_appr DESC' THEN '[tdmisg131200].[t_appr] DESC'
                        WHEN 't_rejc' THEN '[tdmisg131200].[t_rejc]'
                        WHEN 't_rejc DESC' THEN '[tdmisg131200].[t_rejc] DESC'
                        WHEN 't_rekm' THEN '[tdmisg131200].[t_rekm]'
                        WHEN 't_rekm DESC' THEN '[tdmisg131200].[t_rekm] DESC'
                        WHEN 't_apdt' THEN '[tdmisg131200].[t_apdt]'
                        WHEN 't_apdt DESC' THEN '[tdmisg131200].[t_apdt] DESC'
                        WHEN 't_apsu' THEN '[tdmisg131200].[t_apsu]'
                        WHEN 't_apsu DESC' THEN '[tdmisg131200].[t_apsu] DESC'
                        WHEN 't_irmk' THEN '[tdmisg131200].[t_irmk]'
                        WHEN 't_irmk DESC' THEN '[tdmisg131200].[t_irmk] DESC'
                        WHEN 't_iisu' THEN '[tdmisg131200].[t_iisu]'
                        WHEN 't_iisu DESC' THEN '[tdmisg131200].[t_iisu] DESC'
                        WHEN 't_retn' THEN '[tdmisg131200].[t_retn]'
                        WHEN 't_retn DESC' THEN '[tdmisg131200].[t_retn] DESC'
                        WHEN 't_smdt' THEN '[tdmisg131200].[t_smdt]'
                        WHEN 't_smdt DESC' THEN '[tdmisg131200].[t_smdt] DESC'
                        WHEN 't_isby' THEN '[tdmisg131200].[t_isby]'
                        WHEN 't_isby DESC' THEN '[tdmisg131200].[t_isby] DESC'
                        WHEN 't_isdt' THEN '[tdmisg131200].[t_isdt]'
                        WHEN 't_isdt DESC' THEN '[tdmisg131200].[t_isdt] DESC'
                        WHEN 't_Refcntd' THEN '[tdmisg131200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[tdmisg131200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[tdmisg131200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[tdmisg131200].[t_Refcntu] DESC'
                        WHEN 't_edif' THEN '[tdmisg131200].[t_edif]'
                        WHEN 't_edif DESC' THEN '[tdmisg131200].[t_edif] DESC'
                        ELSE '[tdmisg131200].[t_tran]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [tdmisg131200].*  
  FROM [tdmisg131200] 
      INNER JOIN #PageIndex
          ON [tdmisg131200].[t_tran] = #PageIndex.t_tran
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spediWTmtlDSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spediWTmtlDSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spediWTmtlDSelectByID]
  @LoginID NVarChar(8),
  @t_tran VarChar(9),
  @t_docn VarChar(32),
  @t_revn VarChar(20) 
  AS
  SELECT
    [tdmisg132200].* ,
    [tdmisg1312001].[t_refr] AS tdmisg1312001_t_refr 
  FROM [tdmisg132200] 
  INNER JOIN [tdmisg131200] AS [tdmisg1312001]
    ON [tdmisg132200].[t_tran] = [tdmisg1312001].[t_tran]
  WHERE
  [tdmisg132200].[t_tran] = @t_tran
  AND [tdmisg132200].[t_docn] = @t_docn
  AND [tdmisg132200].[t_revn] = @t_revn
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spediWTmtlDSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spediWTmtlDSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spediWTmtlDSelectListSearch]
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
 ,t_tran VarChar(9) NOT NULL
 ,t_docn VarChar(32) NOT NULL
 ,t_revn VarChar(20) NOT NULL
  )
  INSERT INTO #PageIndex (t_tran, t_docn, t_revn)
  SELECT [tdmisg132200].[t_tran], [tdmisg132200].[t_docn], [tdmisg132200].[t_revn] FROM [tdmisg132200]
  INNER JOIN [tdmisg131200] AS [tdmisg1312001]
    ON [tdmisg132200].[t_tran] = [tdmisg1312001].[t_tran]
 WHERE  
   ( 
         LOWER(ISNULL([tdmisg132200].[t_tran],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg132200].[t_docn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg132200].[t_revn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg132200].[t_remk],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg132200].[t_recv],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg132200].[t_pono], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg132200].[t_refr],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg132200].[t_rekm],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg132200].[t_issu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg132200].[t_lock], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg132200].[t_revd], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([tdmisg132200].[t_stid],'')) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg132200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg132200].[t_Refcntu], 0)) LIKE @KeyWord1
     OR STR(ISNULL([tdmisg132200].[t_recc], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_tran' THEN [tdmisg132200].[t_tran] END,
     CASE @OrderBy WHEN 't_tran DESC' THEN [tdmisg132200].[t_tran] END DESC,
     CASE @OrderBy WHEN 't_docn' THEN [tdmisg132200].[t_docn] END,
     CASE @OrderBy WHEN 't_docn DESC' THEN [tdmisg132200].[t_docn] END DESC,
     CASE @OrderBy WHEN 't_revn' THEN [tdmisg132200].[t_revn] END,
     CASE @OrderBy WHEN 't_revn DESC' THEN [tdmisg132200].[t_revn] END DESC,
     CASE @OrderBy WHEN 't_stid' THEN [tdmisg132200].[t_stid] END,
     CASE @OrderBy WHEN 't_stid DESC' THEN [tdmisg132200].[t_stid] END DESC,
     CASE @OrderBy WHEN 't_pono' THEN [tdmisg132200].[t_pono] END,
     CASE @OrderBy WHEN 't_pono DESC' THEN [tdmisg132200].[t_pono] END DESC,
     CASE @OrderBy WHEN 't_remk' THEN [tdmisg132200].[t_remk] END,
     CASE @OrderBy WHEN 't_remk DESC' THEN [tdmisg132200].[t_remk] END DESC,
     CASE @OrderBy WHEN 't_recv' THEN [tdmisg132200].[t_recv] END,
     CASE @OrderBy WHEN 't_recv DESC' THEN [tdmisg132200].[t_recv] END DESC,
     CASE @OrderBy WHEN 't_refr' THEN [tdmisg132200].[t_refr] END,
     CASE @OrderBy WHEN 't_refr DESC' THEN [tdmisg132200].[t_refr] END DESC,
     CASE @OrderBy WHEN 't_redt' THEN [tdmisg132200].[t_redt] END,
     CASE @OrderBy WHEN 't_redt DESC' THEN [tdmisg132200].[t_redt] END DESC,
     CASE @OrderBy WHEN 't_rekm' THEN [tdmisg132200].[t_rekm] END,
     CASE @OrderBy WHEN 't_rekm DESC' THEN [tdmisg132200].[t_rekm] END DESC,
     CASE @OrderBy WHEN 't_lock' THEN [tdmisg132200].[t_lock] END,
     CASE @OrderBy WHEN 't_lock DESC' THEN [tdmisg132200].[t_lock] END DESC,
     CASE @OrderBy WHEN 't_recc' THEN [tdmisg132200].[t_recc] END,
     CASE @OrderBy WHEN 't_recc DESC' THEN [tdmisg132200].[t_recc] END DESC,
     CASE @OrderBy WHEN 't_revd' THEN [tdmisg132200].[t_revd] END,
     CASE @OrderBy WHEN 't_revd DESC' THEN [tdmisg132200].[t_revd] END DESC,
     CASE @OrderBy WHEN 't_issu' THEN [tdmisg132200].[t_issu] END,
     CASE @OrderBy WHEN 't_issu DESC' THEN [tdmisg132200].[t_issu] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [tdmisg132200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [tdmisg132200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [tdmisg132200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [tdmisg132200].[t_Refcntu] END DESC,
     CASE @OrderBy WHEN 'tdmisg1312001_t_refr' THEN [tdmisg1312001].[t_refr] END,
     CASE @OrderBy WHEN 'tdmisg1312001_t_refr DESC' THEN [tdmisg1312001].[t_refr] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [tdmisg132200].* ,
    [tdmisg1312001].[t_refr] AS tdmisg1312001_t_refr 
  FROM [tdmisg132200] 
      INNER JOIN #PageIndex
          ON [tdmisg132200].[t_tran] = #PageIndex.t_tran
          AND [tdmisg132200].[t_docn] = #PageIndex.t_docn
          AND [tdmisg132200].[t_revn] = #PageIndex.t_revn
  INNER JOIN [tdmisg131200] AS [tdmisg1312001]
    ON [tdmisg132200].[t_tran] = [tdmisg1312001].[t_tran]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spediWTmtlDSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spediWTmtlDSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spediWTmtlDSelectListFilteres]
  @Filter_t_tran VarChar(9),
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
 ,t_tran VarChar(9) NOT NULL
 ,t_docn VarChar(32) NOT NULL
 ,t_revn VarChar(20) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_tran'
  SET @LGSQL = @LGSQL + ', t_docn'
  SET @LGSQL = @LGSQL + ', t_revn'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[tdmisg132200].[t_tran]'
  SET @LGSQL = @LGSQL + ', [tdmisg132200].[t_docn]'
  SET @LGSQL = @LGSQL + ', [tdmisg132200].[t_revn]'
  SET @LGSQL = @LGSQL + ' FROM [tdmisg132200] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [tdmisg131200] AS [tdmisg1312001]'
  SET @LGSQL = @LGSQL + '    ON [tdmisg132200].[t_tran] = [tdmisg1312001].[t_tran]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_t_tran > '') 
    SET @LGSQL = @LGSQL + ' AND [tdmisg132200].[t_tran] = ''' + @Filter_t_tran + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_tran' THEN '[tdmisg132200].[t_tran]'
                        WHEN 't_tran DESC' THEN '[tdmisg132200].[t_tran] DESC'
                        WHEN 't_docn' THEN '[tdmisg132200].[t_docn]'
                        WHEN 't_docn DESC' THEN '[tdmisg132200].[t_docn] DESC'
                        WHEN 't_revn' THEN '[tdmisg132200].[t_revn]'
                        WHEN 't_revn DESC' THEN '[tdmisg132200].[t_revn] DESC'
                        WHEN 't_stid' THEN '[tdmisg132200].[t_stid]'
                        WHEN 't_stid DESC' THEN '[tdmisg132200].[t_stid] DESC'
                        WHEN 't_pono' THEN '[tdmisg132200].[t_pono]'
                        WHEN 't_pono DESC' THEN '[tdmisg132200].[t_pono] DESC'
                        WHEN 't_remk' THEN '[tdmisg132200].[t_remk]'
                        WHEN 't_remk DESC' THEN '[tdmisg132200].[t_remk] DESC'
                        WHEN 't_recv' THEN '[tdmisg132200].[t_recv]'
                        WHEN 't_recv DESC' THEN '[tdmisg132200].[t_recv] DESC'
                        WHEN 't_refr' THEN '[tdmisg132200].[t_refr]'
                        WHEN 't_refr DESC' THEN '[tdmisg132200].[t_refr] DESC'
                        WHEN 't_redt' THEN '[tdmisg132200].[t_redt]'
                        WHEN 't_redt DESC' THEN '[tdmisg132200].[t_redt] DESC'
                        WHEN 't_rekm' THEN '[tdmisg132200].[t_rekm]'
                        WHEN 't_rekm DESC' THEN '[tdmisg132200].[t_rekm] DESC'
                        WHEN 't_lock' THEN '[tdmisg132200].[t_lock]'
                        WHEN 't_lock DESC' THEN '[tdmisg132200].[t_lock] DESC'
                        WHEN 't_recc' THEN '[tdmisg132200].[t_recc]'
                        WHEN 't_recc DESC' THEN '[tdmisg132200].[t_recc] DESC'
                        WHEN 't_revd' THEN '[tdmisg132200].[t_revd]'
                        WHEN 't_revd DESC' THEN '[tdmisg132200].[t_revd] DESC'
                        WHEN 't_issu' THEN '[tdmisg132200].[t_issu]'
                        WHEN 't_issu DESC' THEN '[tdmisg132200].[t_issu] DESC'
                        WHEN 't_Refcntd' THEN '[tdmisg132200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[tdmisg132200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[tdmisg132200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[tdmisg132200].[t_Refcntu] DESC'
                        WHEN 'tdmisg1312001_t_refr' THEN '[tdmisg1312001].[t_refr]'
                        WHEN 'tdmisg1312001_t_refr DESC' THEN '[tdmisg1312001].[t_refr] DESC'
                        ELSE '[tdmisg132200].[t_tran],[tdmisg132200].[t_docn],[tdmisg132200].[t_revn]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [tdmisg132200].* ,
    [tdmisg1312001].[t_refr] AS tdmisg1312001_t_refr 
  FROM [tdmisg132200] 
      INNER JOIN #PageIndex
          ON [tdmisg132200].[t_tran] = #PageIndex.t_tran
          AND [tdmisg132200].[t_docn] = #PageIndex.t_docn
          AND [tdmisg132200].[t_revn] = #PageIndex.t_revn
  INNER JOIN [tdmisg131200] AS [tdmisg1312001]
    ON [tdmisg132200].[t_tran] = [tdmisg1312001].[t_tran]
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
