USE [IJTPerks]
GO
/****** Object:  StoredProcedure [dbo].[spidm_LG_ProjectsAutoCompleteList]    Script Date: 02/15/2012 16:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spidm_LG_ProjectsAutoCompleteList]
  @LoginID NvarChar(8),
  @AuthorisedProjects Bit,
  @Prefix NVarChar(250),
  @Records Int,
  @ByCode Int 
  AS 
  BEGIN 
  DECLARE @Prefix1 VarChar(260)
  SET @Prefix1 = LOWER(@Prefix) + '%'
  DECLARE @LGSQL VarChar(8000)
  SET @LGSQL = 'SELECT TOP (' + STR(@Records) + ') ' 
  SET @LGSQL = @LGSQL + ' [IDM_Projects].[Description]' 
  SET @LGSQL = @LGSQL + ',[IDM_Projects].[ProjectID]' 
  SET @LGSQL = @LGSQL + ',[IDM_Customers1].[Description]' 
  SET @LGSQL = @LGSQL + ',[IDM_Customers1].[CustomerID]' 
  SET @LGSQL = @LGSQL + ' FROM [IDM_Projects] ' 
  IF(@AuthorisedProjects=0)
		SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  ELSE
		SET @LGSQL = @LGSQL + ' WHERE [IDM_Projects].[ProjectID]  IN (SELECT PROJECTID FROM IDM_ProjectsByEmployee WHERE CardNo = ''' + @LoginID + ''') ' 
  SET @LGSQL = @LGSQL + ' AND (LOWER(ISNULL([IDM_Projects].[ProjectID],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([IDM_Projects].[Description],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([IDM_Customers1].[CustomerID],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ' OR LOWER(ISNULL([IDM_Customers1].[Description],'''')) LIKE ''' + @Prefix1 + ''''
  SET @LGSQL = @LGSQL + ')' 
  
  EXEC (@LGSQL)
  END
GO
/****** Object:  StoredProcedure [dbo].[spidm_LG_ProjectsSelectList]    Script Date: 02/15/2012 16:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spidm_LG_ProjectsSelectList]
  @LoginID NvarChar(8),
  @AuthorisedProjects Bit,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  IF (@AuthorisedProjects = 0)
    BEGIN
			SELECT
				[IDM_Projects].[ProjectID] ,
				[IDM_Projects].[Description] ,
				[IDM_Projects].[CustomerID] ,
				[IDM_Projects].[CustomerOrderReference] ,
				[IDM_Customers1].[Description] AS IDM_Customers1_Description 
			FROM [IDM_Projects] 
			LEFT OUTER JOIN [IDM_Customers] AS [IDM_Customers1]
				ON [IDM_Projects].[CustomerID] = [IDM_Customers1].[CustomerID]
			WHERE 1 = 1  
			ORDER BY
				 CASE @orderBy WHEN 'ProjectID' THEN [IDM_Projects].[ProjectID] END,
				 CASE @orderBy WHEN 'ProjectID DESC' THEN [IDM_Projects].[ProjectID] END DESC,
				 CASE @orderBy WHEN 'Description' THEN [IDM_Projects].[Description] END,
				 CASE @orderBy WHEN 'Description DESC' THEN [IDM_Projects].[Description] END DESC,
				 CASE @orderBy WHEN 'CustomerID' THEN [IDM_Projects].[CustomerID] END,
				 CASE @orderBy WHEN 'CustomerID DESC' THEN [IDM_Projects].[CustomerID] END DESC,
				 CASE @orderBy WHEN 'CustomerOrderReference' THEN [IDM_Projects].[CustomerOrderReference] END,
				 CASE @orderBy WHEN 'CustomerOrderReference DESC' THEN [IDM_Projects].[CustomerOrderReference] END DESC,
				 CASE @orderBy WHEN 'IDM_Customers1_Description' THEN [IDM_Customers1].[Description] END,
				 CASE @orderBy WHEN 'IDM_Customers1_Description DESC' THEN [IDM_Customers1].[Description] END DESC 
			SET @RecordCount = @@RowCount
		END
  ELSE
		BEGIN
			SELECT
				[IDM_Projects].[ProjectID] ,
				[IDM_Projects].[Description] ,
				[IDM_Projects].[CustomerID] ,
				[IDM_Projects].[CustomerOrderReference] ,
				[IDM_Customers1].[Description] AS IDM_Customers1_Description 
			FROM [IDM_Projects] 
			LEFT OUTER JOIN [IDM_Customers] AS [IDM_Customers1]
				ON [IDM_Projects].[CustomerID] = [IDM_Customers1].[CustomerID]
			WHERE [IDM_Projects].[ProjectID] IN (SELECT PROJECTID FROM IDM_ProjectsByEmployee WHERE CardNo = @LoginID)    
			ORDER BY
				 CASE @orderBy WHEN 'ProjectID' THEN [IDM_Projects].[ProjectID] END,
				 CASE @orderBy WHEN 'ProjectID DESC' THEN [IDM_Projects].[ProjectID] END DESC,
				 CASE @orderBy WHEN 'Description' THEN [IDM_Projects].[Description] END,
				 CASE @orderBy WHEN 'Description DESC' THEN [IDM_Projects].[Description] END DESC,
				 CASE @orderBy WHEN 'CustomerID' THEN [IDM_Projects].[CustomerID] END,
				 CASE @orderBy WHEN 'CustomerID DESC' THEN [IDM_Projects].[CustomerID] END DESC,
				 CASE @orderBy WHEN 'CustomerOrderReference' THEN [IDM_Projects].[CustomerOrderReference] END,
				 CASE @orderBy WHEN 'CustomerOrderReference DESC' THEN [IDM_Projects].[CustomerOrderReference] END DESC,
				 CASE @orderBy WHEN 'IDM_Customers1_Description' THEN [IDM_Customers1].[Description] END,
				 CASE @orderBy WHEN 'IDM_Customers1_Description DESC' THEN [IDM_Customers1].[Description] END DESC 
			SET @RecordCount = @@RowCount
    END

GO
/****** Object:  StoredProcedure [dbo].[spidm_LG_ProjectsSelectListFilteres]    Script Date: 02/15/2012 16:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidm_LG_ProjectsSelectListFilteres]
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @LoginID NvarChar(8),
  @AuthorisedProjects Bit,
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexId INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'ProjectID'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[IDM_Projects].[ProjectID]'
  SET @LGSQL = @LGSQL + ' FROM [IDM_Projects] '
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [IDM_Customers] AS [IDM_Customers1]'
  SET @LGSQL = @LGSQL + '    ON [IDM_Projects].[CustomerID] = [IDM_Customers1].[CustomerID]'
  IF(@AuthorisedProjects=0)
		SET @LGSQL = @LGSQL + ' WHERE 1 = 1 ' 
  ELSE
		SET @LGSQL = @LGSQL + ' WHERE [IDM_Projects].[ProjectID]  IN (SELECT PROJECTID FROM IDM_ProjectsByEmployee WHERE CardNo = ''' + @LoginID + ''') ' 
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'ProjectID' THEN '[IDM_Projects].[ProjectID]'
                        WHEN 'ProjectID DESC' THEN '[IDM_Projects].[ProjectID] DESC'
                        WHEN 'Description' THEN '[IDM_Projects].[Description]'
                        WHEN 'Description DESC' THEN '[IDM_Projects].[Description] DESC'
                        WHEN 'CustomerID' THEN '[IDM_Projects].[CustomerID]'
                        WHEN 'CustomerID DESC' THEN '[IDM_Projects].[CustomerID] DESC'
                        WHEN 'CustomerOrderReference' THEN '[IDM_Projects].[CustomerOrderReference]'
                        WHEN 'CustomerOrderReference DESC' THEN '[IDM_Projects].[CustomerOrderReference] DESC'
                        WHEN 'IDM_Customers1_Description' THEN '[IDM_Customers].[Description]'
                        WHEN 'IDM_Customers1_Description DESC' THEN '[IDM_Customers1].[Description] DESC'
                        ELSE '[IDM_Projects].[ProjectID]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
		[IDM_Projects].[ProjectID] ,
		[IDM_Projects].[Description] ,
		[IDM_Projects].[CustomerID] ,
		[IDM_Projects].[CustomerOrderReference] ,
		[IDM_Customers1].[Description] AS IDM_Customers1_Description 
  FROM [IDM_Projects] 
    	INNER JOIN #PageIndex
          ON [IDM_Projects].[ProjectID] = #PageIndex.ProjectID
  LEFT OUTER JOIN [IDM_Customers] AS [IDM_Customers1]
    ON [IDM_Projects].[CustomerID] = [IDM_Customers1].[CustomerID]
  WHERE
        #PageIndex.IndexID > @startRowIndex
        AND #PageIndex.IndexID < (@startRowIndex + @maximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
GO
/****** Object:  StoredProcedure [dbo].[spidm_LG_ProjectsSelectListSearch]    Script Date: 02/15/2012 16:14:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidm_LG_ProjectsSelectListSearch]
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @LoginID NvarChar(8),
  @AuthorisedProjects Bit,
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexId INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
  )
  IF (@AuthorisedProjects = 0)
    BEGIN
			INSERT INTO #PageIndex (ProjectID)
			SELECT [IDM_Projects].[ProjectID] FROM [IDM_Projects]
			LEFT OUTER JOIN [IDM_Customers] AS [IDM_Customers1]
				ON [IDM_Projects].[CustomerID] = [IDM_Customers1].[CustomerID]
			WHERE  
			 ( 
						 LOWER(ISNULL([IDM_Projects].[ProjectID],'')) LIKE @KeyWord1
				 OR LOWER(ISNULL([IDM_Projects].[Description],'')) LIKE @KeyWord1
				 OR LOWER(ISNULL([IDM_Projects].[CustomerID],'')) LIKE @KeyWord1
				 OR LOWER(ISNULL([IDM_Projects].[CustomerOrderReference],'')) LIKE @KeyWord1
			 ) 
			ORDER BY
				 CASE @orderBy WHEN 'ProjectID' THEN [IDM_Projects].[ProjectID] END,
				 CASE @orderBy WHEN 'ProjectID DESC' THEN [IDM_Projects].[ProjectID] END DESC,
				 CASE @orderBy WHEN 'Description' THEN [IDM_Projects].[Description] END,
				 CASE @orderBy WHEN 'Description DESC' THEN [IDM_Projects].[Description] END DESC,
				 CASE @orderBy WHEN 'CustomerID' THEN [IDM_Projects].[CustomerID] END,
				 CASE @orderBy WHEN 'CustomerID DESC' THEN [IDM_Projects].[CustomerID] END DESC,
				 CASE @orderBy WHEN 'CustomerOrderReference' THEN [IDM_Projects].[CustomerOrderReference] END,
				 CASE @orderBy WHEN 'CustomerOrderReference DESC' THEN [IDM_Projects].[CustomerOrderReference] END DESC,
				 CASE @orderBy WHEN 'IDM_Customers1_Description' THEN [IDM_Customers1].[Description] END,
				 CASE @orderBy WHEN 'IDM_Customers1_Description DESC' THEN [IDM_Customers1].[Description] END DESC 

				SET @RecordCount = @@RowCount
    END
  ELSE
    BEGIN
			INSERT INTO #PageIndex (ProjectID)
			SELECT [IDM_Projects].[ProjectID] FROM [IDM_Projects]
			LEFT OUTER JOIN [IDM_Customers] AS [IDM_Customers1]
				ON [IDM_Projects].[CustomerID] = [IDM_Customers1].[CustomerID]
			WHERE  [IDM_Projects].[ProjectID] IN (SELECT PROJECTID FROM IDM_ProjectsByEmployee WHERE CardNo = @LoginID)
			  AND ( 
						 LOWER(ISNULL([IDM_Projects].[ProjectID],'')) LIKE @KeyWord1
				 OR LOWER(ISNULL([IDM_Projects].[Description],'')) LIKE @KeyWord1
				 OR LOWER(ISNULL([IDM_Projects].[CustomerID],'')) LIKE @KeyWord1
				 OR LOWER(ISNULL([IDM_Projects].[CustomerOrderReference],'')) LIKE @KeyWord1
			 ) 
			ORDER BY
				 CASE @orderBy WHEN 'ProjectID' THEN [IDM_Projects].[ProjectID] END,
				 CASE @orderBy WHEN 'ProjectID DESC' THEN [IDM_Projects].[ProjectID] END DESC,
				 CASE @orderBy WHEN 'Description' THEN [IDM_Projects].[Description] END,
				 CASE @orderBy WHEN 'Description DESC' THEN [IDM_Projects].[Description] END DESC,
				 CASE @orderBy WHEN 'CustomerID' THEN [IDM_Projects].[CustomerID] END,
				 CASE @orderBy WHEN 'CustomerID DESC' THEN [IDM_Projects].[CustomerID] END DESC,
				 CASE @orderBy WHEN 'CustomerOrderReference' THEN [IDM_Projects].[CustomerOrderReference] END,
				 CASE @orderBy WHEN 'CustomerOrderReference DESC' THEN [IDM_Projects].[CustomerOrderReference] END DESC,
				 CASE @orderBy WHEN 'IDM_Customers1_Description' THEN [IDM_Customers1].[Description] END,
				 CASE @orderBy WHEN 'IDM_Customers1_Description DESC' THEN [IDM_Customers1].[Description] END DESC 

				SET @RecordCount = @@RowCount
    END

  SELECT
		[IDM_Projects].[ProjectID] ,
		[IDM_Projects].[Description] ,
		[IDM_Projects].[CustomerID] ,
		[IDM_Projects].[CustomerOrderReference] ,
		[IDM_Customers1].[Description] AS IDM_Customers1_Description 
  FROM [IDM_Projects] 
    	INNER JOIN #PageIndex
          ON [IDM_Projects].[ProjectID] = #PageIndex.ProjectID
  LEFT OUTER JOIN [IDM_Customers] AS [IDM_Customers1]
    ON [IDM_Projects].[CustomerID] = [IDM_Customers1].[CustomerID]
  WHERE
        #PageIndex.IndexID > @startRowIndex
        AND #PageIndex.IndexID < (@startRowIndex + @maximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
 