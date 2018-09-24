SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptarTravelRequestStatusSelectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptarTravelRequestStatusSelectList]
GO
 
CREATE PROCEDURE [dbo].[sptarTravelRequestStatusSelectList]
  @LoginID NVarChar(8),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
    [TA_TravelRequestStatus].*  
  FROM [TA_TravelRequestStatus] 
  WHERE 1 = 1  
  ORDER BY
     CASE @OrderBy WHEN 'StatusID' THEN [TA_TravelRequestStatus].[StatusID] END,
     CASE @OrderBy WHEN 'StatusID DESC' THEN [TA_TravelRequestStatus].[StatusID] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [TA_TravelRequestStatus].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [TA_TravelRequestStatus].[Description] END DESC 
  SET @RecordCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptarTravelRequestStatusAutoCompleteList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptarTravelRequestStatusAutoCompleteList]
GO
 
CREATE PROCEDURE [dbo].[sptarTravelRequestStatusAutoCompleteList]
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
  SET @LGSQL = @LGSQL + ' [TA_TravelRequestStatus].[Description]' 
  SET @LGSQL = @LGSQL + ',[TA_TravelRequestStatus].[StatusID]' 
  SET @LGSQL = @LGSQL + ' FROM [TA_TravelRequestStatus] ' 
  SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  SET @LGSQL = @LGSQL + ' AND (LTRIM(STR(ISNULL([TA_TravelRequestStatus].[StatusID],0))) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([TA_TravelRequestStatus].[Description],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  
  EXEC (@LGSQL)
  END 
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptarTravelRequestStatusSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptarTravelRequestStatusSelectByID]
GO
 
CREATE PROCEDURE [dbo].[sptarTravelRequestStatusSelectByID]
  @LoginID NVarChar(8),
  @StatusID Int 
  AS
  SELECT
    [TA_TravelRequestStatus].*  
  FROM [TA_TravelRequestStatus] 
  WHERE
  [TA_TravelRequestStatus].[StatusID] = @StatusID
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptarTravelRequestStatusSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptarTravelRequestStatusSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sptarTravelRequestStatusSelectListSearch]
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
 ,StatusID Int NOT NULL
  )
  INSERT INTO #PageIndex (StatusID)
  SELECT [TA_TravelRequestStatus].[StatusID] FROM [TA_TravelRequestStatus]
 WHERE  
   ( 
         STR(ISNULL([TA_TravelRequestStatus].[StatusID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([TA_TravelRequestStatus].[Description],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'StatusID' THEN [TA_TravelRequestStatus].[StatusID] END,
     CASE @OrderBy WHEN 'StatusID DESC' THEN [TA_TravelRequestStatus].[StatusID] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [TA_TravelRequestStatus].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [TA_TravelRequestStatus].[Description] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [TA_TravelRequestStatus].*  
  FROM [TA_TravelRequestStatus] 
      INNER JOIN #PageIndex
          ON [TA_TravelRequestStatus].[StatusID] = #PageIndex.StatusID
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptarTravelRequestStatusSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptarTravelRequestStatusSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sptarTravelRequestStatusSelectListFilteres]
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
 ,StatusID Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'StatusID'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[TA_TravelRequestStatus].[StatusID]'
  SET @LGSQL = @LGSQL + ' FROM [TA_TravelRequestStatus] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'StatusID' THEN '[TA_TravelRequestStatus].[StatusID]'
                        WHEN 'StatusID DESC' THEN '[TA_TravelRequestStatus].[StatusID] DESC'
                        WHEN 'Description' THEN '[TA_TravelRequestStatus].[Description]'
                        WHEN 'Description DESC' THEN '[TA_TravelRequestStatus].[Description] DESC'
                        ELSE '[TA_TravelRequestStatus].[StatusID]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [TA_TravelRequestStatus].*  
  FROM [TA_TravelRequestStatus] 
      INNER JOIN #PageIndex
          ON [TA_TravelRequestStatus].[StatusID] = #PageIndex.StatusID
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
