SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPOLChildSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPOLChildSelectByID]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPOLChildSelectByID]
  @LoginID NVarChar(8),
  @t_orno VarChar(9),
  @t_vrsn Int,
  @t_pono Int,
  @t_item VarChar(47) 
  AS
  SELECT
    [ttdisg002200].*  
  FROM [ttdisg002200] 
  WHERE
  [ttdisg002200].[t_orno] = @t_orno
  AND [ttdisg002200].[t_vrsn] = @t_vrsn
  AND [ttdisg002200].[t_pono] = @t_pono
  AND [ttdisg002200].[t_item] = @t_item
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPOLChildSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPOLChildSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPOLChildSelectListSearch]
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
 ,t_vrsn Int NOT NULL
 ,t_pono Int NOT NULL
 ,t_item VarChar(47) NOT NULL
  )
  INSERT INTO #PageIndex (t_orno, t_vrsn, t_pono, t_item)
  SELECT [ttdisg002200].[t_orno], [ttdisg002200].[t_vrsn], [ttdisg002200].[t_pono], [ttdisg002200].[t_item] FROM [ttdisg002200]
 WHERE  
   ( 
         LOWER(ISNULL([ttdisg002200].[t_orno],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_vrsn], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_pono], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_item],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_desc],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_qnty], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_quom],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_wght], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_slct], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_stat], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_pric], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_amnt], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_qoor], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_acht], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_docn],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ttdisg002200].[t_revi],'')) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_Refcntd], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ttdisg002200].[t_Refcntu], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 't_orno' THEN [ttdisg002200].[t_orno] END,
     CASE @OrderBy WHEN 't_orno DESC' THEN [ttdisg002200].[t_orno] END DESC,
     CASE @OrderBy WHEN 't_vrsn' THEN [ttdisg002200].[t_vrsn] END,
     CASE @OrderBy WHEN 't_vrsn DESC' THEN [ttdisg002200].[t_vrsn] END DESC,
     CASE @OrderBy WHEN 't_pono' THEN [ttdisg002200].[t_pono] END,
     CASE @OrderBy WHEN 't_pono DESC' THEN [ttdisg002200].[t_pono] END DESC,
     CASE @OrderBy WHEN 't_item' THEN [ttdisg002200].[t_item] END,
     CASE @OrderBy WHEN 't_item DESC' THEN [ttdisg002200].[t_item] END DESC,
     CASE @OrderBy WHEN 't_desc' THEN [ttdisg002200].[t_desc] END,
     CASE @OrderBy WHEN 't_desc DESC' THEN [ttdisg002200].[t_desc] END DESC,
     CASE @OrderBy WHEN 't_qnty' THEN [ttdisg002200].[t_qnty] END,
     CASE @OrderBy WHEN 't_qnty DESC' THEN [ttdisg002200].[t_qnty] END DESC,
     CASE @OrderBy WHEN 't_quom' THEN [ttdisg002200].[t_quom] END,
     CASE @OrderBy WHEN 't_quom DESC' THEN [ttdisg002200].[t_quom] END DESC,
     CASE @OrderBy WHEN 't_wght' THEN [ttdisg002200].[t_wght] END,
     CASE @OrderBy WHEN 't_wght DESC' THEN [ttdisg002200].[t_wght] END DESC,
     CASE @OrderBy WHEN 't_slct' THEN [ttdisg002200].[t_slct] END,
     CASE @OrderBy WHEN 't_slct DESC' THEN [ttdisg002200].[t_slct] END DESC,
     CASE @OrderBy WHEN 't_stat' THEN [ttdisg002200].[t_stat] END,
     CASE @OrderBy WHEN 't_stat DESC' THEN [ttdisg002200].[t_stat] END DESC,
     CASE @OrderBy WHEN 't_pric' THEN [ttdisg002200].[t_pric] END,
     CASE @OrderBy WHEN 't_pric DESC' THEN [ttdisg002200].[t_pric] END DESC,
     CASE @OrderBy WHEN 't_amnt' THEN [ttdisg002200].[t_amnt] END,
     CASE @OrderBy WHEN 't_amnt DESC' THEN [ttdisg002200].[t_amnt] END DESC,
     CASE @OrderBy WHEN 't_qoor' THEN [ttdisg002200].[t_qoor] END,
     CASE @OrderBy WHEN 't_qoor DESC' THEN [ttdisg002200].[t_qoor] END DESC,
     CASE @OrderBy WHEN 't_acht' THEN [ttdisg002200].[t_acht] END,
     CASE @OrderBy WHEN 't_acht DESC' THEN [ttdisg002200].[t_acht] END DESC,
     CASE @OrderBy WHEN 't_docn' THEN [ttdisg002200].[t_docn] END,
     CASE @OrderBy WHEN 't_docn DESC' THEN [ttdisg002200].[t_docn] END DESC,
     CASE @OrderBy WHEN 't_revi' THEN [ttdisg002200].[t_revi] END,
     CASE @OrderBy WHEN 't_revi DESC' THEN [ttdisg002200].[t_revi] END DESC,
     CASE @OrderBy WHEN 't_Refcntd' THEN [ttdisg002200].[t_Refcntd] END,
     CASE @OrderBy WHEN 't_Refcntd DESC' THEN [ttdisg002200].[t_Refcntd] END DESC,
     CASE @OrderBy WHEN 't_Refcntu' THEN [ttdisg002200].[t_Refcntu] END,
     CASE @OrderBy WHEN 't_Refcntu DESC' THEN [ttdisg002200].[t_Refcntu] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ttdisg002200].*  
  FROM [ttdisg002200] 
      INNER JOIN #PageIndex
          ON [ttdisg002200].[t_orno] = #PageIndex.t_orno
          AND [ttdisg002200].[t_vrsn] = #PageIndex.t_vrsn
          AND [ttdisg002200].[t_pono] = #PageIndex.t_pono
          AND [ttdisg002200].[t_item] = #PageIndex.t_item
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPOLChildSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPOLChildSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPOLChildSelectListFilteres]
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
 ,t_vrsn Int NOT NULL
 ,t_pono Int NOT NULL
 ,t_item VarChar(47) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 't_orno'
  SET @LGSQL = @LGSQL + ', t_vrsn'
  SET @LGSQL = @LGSQL + ', t_pono'
  SET @LGSQL = @LGSQL + ', t_item'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ttdisg002200].[t_orno]'
  SET @LGSQL = @LGSQL + ', [ttdisg002200].[t_vrsn]'
  SET @LGSQL = @LGSQL + ', [ttdisg002200].[t_pono]'
  SET @LGSQL = @LGSQL + ', [ttdisg002200].[t_item]'
  SET @LGSQL = @LGSQL + ' FROM [ttdisg002200] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 't_orno' THEN '[ttdisg002200].[t_orno]'
                        WHEN 't_orno DESC' THEN '[ttdisg002200].[t_orno] DESC'
                        WHEN 't_vrsn' THEN '[ttdisg002200].[t_vrsn]'
                        WHEN 't_vrsn DESC' THEN '[ttdisg002200].[t_vrsn] DESC'
                        WHEN 't_pono' THEN '[ttdisg002200].[t_pono]'
                        WHEN 't_pono DESC' THEN '[ttdisg002200].[t_pono] DESC'
                        WHEN 't_item' THEN '[ttdisg002200].[t_item]'
                        WHEN 't_item DESC' THEN '[ttdisg002200].[t_item] DESC'
                        WHEN 't_desc' THEN '[ttdisg002200].[t_desc]'
                        WHEN 't_desc DESC' THEN '[ttdisg002200].[t_desc] DESC'
                        WHEN 't_qnty' THEN '[ttdisg002200].[t_qnty]'
                        WHEN 't_qnty DESC' THEN '[ttdisg002200].[t_qnty] DESC'
                        WHEN 't_quom' THEN '[ttdisg002200].[t_quom]'
                        WHEN 't_quom DESC' THEN '[ttdisg002200].[t_quom] DESC'
                        WHEN 't_wght' THEN '[ttdisg002200].[t_wght]'
                        WHEN 't_wght DESC' THEN '[ttdisg002200].[t_wght] DESC'
                        WHEN 't_slct' THEN '[ttdisg002200].[t_slct]'
                        WHEN 't_slct DESC' THEN '[ttdisg002200].[t_slct] DESC'
                        WHEN 't_stat' THEN '[ttdisg002200].[t_stat]'
                        WHEN 't_stat DESC' THEN '[ttdisg002200].[t_stat] DESC'
                        WHEN 't_pric' THEN '[ttdisg002200].[t_pric]'
                        WHEN 't_pric DESC' THEN '[ttdisg002200].[t_pric] DESC'
                        WHEN 't_amnt' THEN '[ttdisg002200].[t_amnt]'
                        WHEN 't_amnt DESC' THEN '[ttdisg002200].[t_amnt] DESC'
                        WHEN 't_qoor' THEN '[ttdisg002200].[t_qoor]'
                        WHEN 't_qoor DESC' THEN '[ttdisg002200].[t_qoor] DESC'
                        WHEN 't_acht' THEN '[ttdisg002200].[t_acht]'
                        WHEN 't_acht DESC' THEN '[ttdisg002200].[t_acht] DESC'
                        WHEN 't_docn' THEN '[ttdisg002200].[t_docn]'
                        WHEN 't_docn DESC' THEN '[ttdisg002200].[t_docn] DESC'
                        WHEN 't_revi' THEN '[ttdisg002200].[t_revi]'
                        WHEN 't_revi DESC' THEN '[ttdisg002200].[t_revi] DESC'
                        WHEN 't_Refcntd' THEN '[ttdisg002200].[t_Refcntd]'
                        WHEN 't_Refcntd DESC' THEN '[ttdisg002200].[t_Refcntd] DESC'
                        WHEN 't_Refcntu' THEN '[ttdisg002200].[t_Refcntu]'
                        WHEN 't_Refcntu DESC' THEN '[ttdisg002200].[t_Refcntu] DESC'
                        ELSE '[ttdisg002200].[t_orno],[ttdisg002200].[t_vrsn],[ttdisg002200].[t_pono],[ttdisg002200].[t_item]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ttdisg002200].*  
  FROM [ttdisg002200] 
      INNER JOIN #PageIndex
          ON [ttdisg002200].[t_orno] = #PageIndex.t_orno
          AND [ttdisg002200].[t_vrsn] = #PageIndex.t_vrsn
          AND [ttdisg002200].[t_pono] = #PageIndex.t_pono
          AND [ttdisg002200].[t_item] = #PageIndex.t_item
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppakERPPOLChildInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppakERPPOLChildInsert]
GO
 
CREATE PROCEDURE [dbo].[sppakERPPOLChildInsert]
  @t_orno VarChar(9),
  @t_vrsn Int,
  @t_pono Int,
  @t_item VarChar(47),
  @t_desc VarChar(30),
  @t_qnty Float,
  @t_quom VarChar(3),
  @t_wght Float,
  @t_slct Int,
  @t_stat Int,
  @t_pric Float,
  @t_amnt Float,
  @t_qoor Float,
  @t_acht Float,
  @t_docn VarChar(32),
  @t_revi VarChar(20),
  @t_Refcntd Int,
  @t_Refcntu Int,
  @Return_t_orno VarChar(9) = null OUTPUT, 
  @Return_t_vrsn Int = null OUTPUT, 
  @Return_t_pono Int = null OUTPUT, 
  @Return_t_item VarChar(47) = null OUTPUT 
  AS
  INSERT [ttdisg002200]
  (
   [t_orno]
  ,[t_vrsn]
  ,[t_pono]
  ,[t_item]
  ,[t_desc]
  ,[t_qnty]
  ,[t_quom]
  ,[t_wght]
  ,[t_slct]
  ,[t_stat]
  ,[t_pric]
  ,[t_amnt]
  ,[t_qoor]
  ,[t_acht]
  ,[t_docn]
  ,[t_revi]
  ,[t_Refcntd]
  ,[t_Refcntu]
  )
  VALUES
  (
   UPPER(@t_orno)
  ,@t_vrsn
  ,@t_pono
  ,UPPER(@t_item)
  ,@t_desc
  ,@t_qnty
  ,@t_quom
  ,@t_wght
  ,@t_slct
  ,@t_stat
  ,@t_pric
  ,@t_amnt
  ,@t_qoor
  ,@t_acht
  ,@t_docn
  ,@t_revi
  ,@t_Refcntd
  ,@t_Refcntu
  )
  SET @Return_t_orno = @t_orno
  SET @Return_t_vrsn = @t_vrsn
  SET @Return_t_pono = @t_pono
  SET @Return_t_item = @t_item
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
