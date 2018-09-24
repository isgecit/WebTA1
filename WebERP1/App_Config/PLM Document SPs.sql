USE [wcadmin]
GO
/****** Object:  StoredProcedure [dbo].[spidm_LG_lgEPDocumentSelectByID]    Script Date: 07/26/2012 11:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidm_LG_lgEPDocumentSelectByID]
  @ProjectID NVarChar(6),
  @DocumentID NVarChar(30) 
  AS
  SELECT
		[PLM_lgEPDocument].[ProjectID] ,
		[PLM_lgEPDocument].[DocumentID] ,
		[PLM_lgEPDocument].[Revision] ,
		[PLM_lgEPDocument].[Description] ,
		[PLM_lgEPDocument].[ElementID] ,
		[PLM_lgEPDocument].[ElementDescription] ,
		[PLM_lgEPDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgEPDocument] 
  WHERE
  [PLM_lgEPDocument].[ProjectID] = @ProjectID
  AND [PLM_lgEPDocument].[DocumentID] = @DocumentID


GO
/****** Object:  StoredProcedure [dbo].[spidm_LG_lgWTDocumentSelectByID]    Script Date: 07/26/2012 11:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spidm_LG_lgWTDocumentSelectByID]
  @ProjectID NVarChar(6),
  @DocumentID NVarChar(30)  
  AS
  SELECT
		[PLM_lgWTDocument].[ProjectID] ,
		[PLM_lgWTDocument].[DocumentID] ,
		[PLM_lgWTDocument].[Revision] ,
		[PLM_lgWTDocument].[Description] ,
		[PLM_lgWTDocument].[ElementID] ,
		[PLM_lgWTDocument].[ElementDescription] ,
		[PLM_lgWTDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgWTDocument] 
  WHERE
  [PLM_lgWTDocument].[ProjectID] = @ProjectID
  AND [PLM_lgWTDocument].[DocumentID] = @DocumentID

GO
/****** Object:  StoredProcedure [dbo].[spidmlgEPDocumentSelectByID]    Script Date: 07/26/2012 11:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidmlgEPDocumentSelectByID]
  @ProjectID NVarChar(6),
  @DocumentID NVarChar(30),
  @Revision NVarChar(2) 
  AS
  SELECT
		[PLM_lgEPDocument].[ProjectID] ,
		[PLM_lgEPDocument].[DocumentID] ,
		[PLM_lgEPDocument].[Revision] ,
		[PLM_lgEPDocument].[Description] ,
		[PLM_lgEPDocument].[ElementID] ,
		[PLM_lgEPDocument].[ElementDescription] ,
		[PLM_lgEPDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgEPDocument] 
  WHERE
  [PLM_lgEPDocument].[ProjectID] = @ProjectID
  AND [PLM_lgEPDocument].[DocumentID] = @DocumentID
  AND [PLM_lgEPDocument].[Revision] = @Revision


GO
/****** Object:  StoredProcedure [dbo].[spidmlgEPDocumentSelectByProjectID]    Script Date: 07/26/2012 11:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidmlgEPDocumentSelectByProjectID]
  @ProjectID NVarChar(6),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
		[PLM_lgEPDocument].[ProjectID] ,
		[PLM_lgEPDocument].[DocumentID] ,
		[PLM_lgEPDocument].[Revision] ,
		[PLM_lgEPDocument].[Description] ,
		[PLM_lgEPDocument].[ElementID] ,
		[PLM_lgEPDocument].[ElementDescription] ,
		[PLM_lgEPDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgEPDocument] 
  WHERE
  [PLM_lgEPDocument].[ProjectID] = @ProjectID
  ORDER BY
     CASE @OrderBy WHEN 'ProjectID' THEN [PLM_lgEPDocument].[ProjectID] END,
     CASE @OrderBy WHEN 'ProjectID DESC' THEN [PLM_lgEPDocument].[ProjectID] END DESC,
     CASE @OrderBy WHEN 'DocumentID' THEN [PLM_lgEPDocument].[DocumentID] END,
     CASE @OrderBy WHEN 'DocumentID DESC' THEN [PLM_lgEPDocument].[DocumentID] END DESC,
     CASE @OrderBy WHEN 'Revision' THEN [PLM_lgEPDocument].[Revision] END,
     CASE @OrderBy WHEN 'Revision DESC' THEN [PLM_lgEPDocument].[Revision] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [PLM_lgEPDocument].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [PLM_lgEPDocument].[Description] END DESC,
     CASE @OrderBy WHEN 'ElementID' THEN [PLM_lgEPDocument].[ElementID] END,
     CASE @OrderBy WHEN 'ElementID DESC' THEN [PLM_lgEPDocument].[ElementID] END DESC,
     CASE @OrderBy WHEN 'ElementDescription' THEN [PLM_lgEPDocument].[ElementDescription] END,
     CASE @OrderBy WHEN 'ElementDescription DESC' THEN [PLM_lgEPDocument].[ElementDescription] END DESC,
     CASE @OrderBy WHEN 'Status' THEN [PLM_lgEPDocument].[Status] END,
     CASE @OrderBy WHEN 'Status DESC' THEN [PLM_lgEPDocument].[Status] END DESC
  SET @RecordCount = @@RowCount


GO
/****** Object:  StoredProcedure [dbo].[spidmlgEPDocumentSelectListFilteres]    Script Date: 07/26/2012 11:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidmlgEPDocumentSelectListFilteres]
  @Filter_ProjectID NVarChar(6),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex ( 
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
 ,DocumentID NVarChar(30) NOT NULL
 ,Revision NVarChar(2) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'ProjectID'
  SET @LGSQL = @LGSQL + ', DocumentID'
  SET @LGSQL = @LGSQL + ', Revision'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[PLM_lgEPDocument].[ProjectID]'
  SET @LGSQL = @LGSQL + ', [PLM_lgEPDocument].[DocumentID]'
  SET @LGSQL = @LGSQL + ', [PLM_lgEPDocument].[Revision]'
  SET @LGSQL = @LGSQL + ' FROM [PLM_lgEPDocument] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_ProjectID > '') 
    SET @LGSQL = @LGSQL + ' AND [PLM_lgEPDocument].[ProjectID] = ''' + @Filter_ProjectID + ''''
  ELSE
    SET @LGSQL = @LGSQL + ' AND [PLM_lgEPDocument].[ProjectID] = ''JB0802'''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'ProjectID' THEN '[PLM_lgEPDocument].[ProjectID]'
                        WHEN 'ProjectID DESC' THEN '[PLM_lgEPDocument].[ProjectID] DESC'
                        WHEN 'DocumentID' THEN '[PLM_lgEPDocument].[DocumentID]'
                        WHEN 'DocumentID DESC' THEN '[PLM_lgEPDocument].[DocumentID] DESC'
                        WHEN 'Revision' THEN '[PLM_lgEPDocument].[Revision]'
                        WHEN 'Revision DESC' THEN '[PLM_lgEPDocument].[Revision] DESC'
                        WHEN 'Description' THEN '[PLM_lgEPDocument].[Description]'
                        WHEN 'Description DESC' THEN '[PLM_lgEPDocument].[Description] DESC'
                        WHEN 'ElementID' THEN '[PLM_lgEPDocument].[ElementID]'
                        WHEN 'ElementID DESC' THEN '[PLM_lgEPDocument].[ElementID] DESC'
                        WHEN 'ElementDescription' THEN '[PLM_lgEPDocument].[ElementDescription]'
                        WHEN 'ElementDescription DESC' THEN '[PLM_lgEPDocument].[ElementDescription] DESC'
                        WHEN 'Status' THEN '[PLM_lgEPDocument].[Status]'
                        WHEN 'Status DESC' THEN '[PLM_lgEPDocument].[Status] DESC'
                        ELSE '[PLM_lgEPDocument].[ProjectID],[PLM_lgEPDocument].[DocumentID],[PLM_lgEPDocument].[Revision]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
		[PLM_lgEPDocument].[ProjectID] ,
		[PLM_lgEPDocument].[DocumentID] ,
		[PLM_lgEPDocument].[Revision] ,
		[PLM_lgEPDocument].[Description] ,
		[PLM_lgEPDocument].[ElementID] ,
		[PLM_lgEPDocument].[ElementDescription] ,
		[PLM_lgEPDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgEPDocument] 
    	INNER JOIN #PageIndex
          ON [PLM_lgEPDocument].[ProjectID] = #PageIndex.ProjectID
          AND [PLM_lgEPDocument].[DocumentID] = #PageIndex.DocumentID
          AND [PLM_lgEPDocument].[Revision] = #PageIndex.Revision
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END


GO
/****** Object:  StoredProcedure [dbo].[spidmlgEPDocumentSelectListSearch]    Script Date: 07/26/2012 11:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidmlgEPDocumentSelectListSearch]
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
 ,ProjectID NVarChar(6) NOT NULL
 ,DocumentID NVarChar(30) NOT NULL
 ,Revision NVarChar(2) NOT NULL
  )
  INSERT INTO #PageIndex (ProjectID, DocumentID, Revision)
  SELECT [PLM_lgEPDocument].[ProjectID], [PLM_lgEPDocument].[DocumentID], [PLM_lgEPDocument].[Revision] FROM [PLM_lgEPDocument]
 WHERE  
   ( 
         LOWER(ISNULL([PLM_lgEPDocument].[ProjectID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgEPDocument].[DocumentID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgEPDocument].[Revision],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgEPDocument].[Description],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgEPDocument].[ElementID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgEPDocument].[ElementDescription],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgEPDocument].[Status],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'ProjectID' THEN [PLM_lgEPDocument].[ProjectID] END,
     CASE @OrderBy WHEN 'ProjectID DESC' THEN [PLM_lgEPDocument].[ProjectID] END DESC,
     CASE @OrderBy WHEN 'DocumentID' THEN [PLM_lgEPDocument].[DocumentID] END,
     CASE @OrderBy WHEN 'DocumentID DESC' THEN [PLM_lgEPDocument].[DocumentID] END DESC,
     CASE @OrderBy WHEN 'Revision' THEN [PLM_lgEPDocument].[Revision] END,
     CASE @OrderBy WHEN 'Revision DESC' THEN [PLM_lgEPDocument].[Revision] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [PLM_lgEPDocument].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [PLM_lgEPDocument].[Description] END DESC,
     CASE @OrderBy WHEN 'ElementID' THEN [PLM_lgEPDocument].[ElementID] END,
     CASE @OrderBy WHEN 'ElementID DESC' THEN [PLM_lgEPDocument].[ElementID] END DESC,
     CASE @OrderBy WHEN 'ElementDescription' THEN [PLM_lgEPDocument].[ElementDescription] END,
     CASE @OrderBy WHEN 'ElementDescription DESC' THEN [PLM_lgEPDocument].[ElementDescription] END DESC,
     CASE @OrderBy WHEN 'Status' THEN [PLM_lgEPDocument].[Status] END,
     CASE @OrderBy WHEN 'Status DESC' THEN [PLM_lgEPDocument].[Status] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
		[PLM_lgEPDocument].[ProjectID] ,
		[PLM_lgEPDocument].[DocumentID] ,
		[PLM_lgEPDocument].[Revision] ,
		[PLM_lgEPDocument].[Description] ,
		[PLM_lgEPDocument].[ElementID] ,
		[PLM_lgEPDocument].[ElementDescription] ,
		[PLM_lgEPDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgEPDocument] 
    	INNER JOIN #PageIndex
          ON [PLM_lgEPDocument].[ProjectID] = #PageIndex.ProjectID
          AND [PLM_lgEPDocument].[DocumentID] = #PageIndex.DocumentID
          AND [PLM_lgEPDocument].[Revision] = #PageIndex.Revision
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
GO
/****** Object:  StoredProcedure [dbo].[spidmlgWTDocumentSelectByID]    Script Date: 07/26/2012 11:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidmlgWTDocumentSelectByID]
  @ProjectID NVarChar(6),
  @DocumentID NVarChar(30),
  @Revision NVarChar(2) 
  AS
  SELECT
		[PLM_lgWTDocument].[ProjectID] ,
		[PLM_lgWTDocument].[DocumentID] ,
		[PLM_lgWTDocument].[Revision] ,
		[PLM_lgWTDocument].[Description] ,
		[PLM_lgWTDocument].[ElementID] ,
		[PLM_lgWTDocument].[ElementDescription] ,
		[PLM_lgWTDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgWTDocument] 
  WHERE
  [PLM_lgWTDocument].[ProjectID] = @ProjectID
  AND [PLM_lgWTDocument].[DocumentID] = @DocumentID
  AND [PLM_lgWTDocument].[Revision] = @Revision

GO
/****** Object:  StoredProcedure [dbo].[spidmlgWTDocumentSelectByProjectID]    Script Date: 07/26/2012 11:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidmlgWTDocumentSelectByProjectID]
  @ProjectID NVarChar(6),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  SELECT
		[PLM_lgWTDocument].[ProjectID] ,
		[PLM_lgWTDocument].[DocumentID] ,
		[PLM_lgWTDocument].[Revision] ,
		[PLM_lgWTDocument].[Description] ,
		[PLM_lgWTDocument].[ElementID] ,
		[PLM_lgWTDocument].[ElementDescription] ,
		[PLM_lgWTDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgWTDocument] 
  WHERE
  [PLM_lgWTDocument].[ProjectID] = @ProjectID
  ORDER BY
     CASE @OrderBy WHEN 'ProjectID' THEN [PLM_lgWTDocument].[ProjectID] END,
     CASE @OrderBy WHEN 'ProjectID DESC' THEN [PLM_lgWTDocument].[ProjectID] END DESC,
     CASE @OrderBy WHEN 'DocumentID' THEN [PLM_lgWTDocument].[DocumentID] END,
     CASE @OrderBy WHEN 'DocumentID DESC' THEN [PLM_lgWTDocument].[DocumentID] END DESC,
     CASE @OrderBy WHEN 'Revision' THEN [PLM_lgWTDocument].[Revision] END,
     CASE @OrderBy WHEN 'Revision DESC' THEN [PLM_lgWTDocument].[Revision] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [PLM_lgWTDocument].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [PLM_lgWTDocument].[Description] END DESC,
     CASE @OrderBy WHEN 'ElementID' THEN [PLM_lgWTDocument].[ElementID] END,
     CASE @OrderBy WHEN 'ElementID DESC' THEN [PLM_lgWTDocument].[ElementID] END DESC,
     CASE @OrderBy WHEN 'ElementDescription' THEN [PLM_lgWTDocument].[ElementDescription] END,
     CASE @OrderBy WHEN 'ElementDescription DESC' THEN [PLM_lgWTDocument].[ElementDescription] END DESC,
     CASE @OrderBy WHEN 'Status' THEN [PLM_lgWTDocument].[Status] END,
     CASE @OrderBy WHEN 'Status DESC' THEN [PLM_lgWTDocument].[Status] END DESC 
  SET @RecordCount = @@RowCount

GO
/****** Object:  StoredProcedure [dbo].[spidmlgWTDocumentSelectListFilteres]    Script Date: 07/26/2012 11:54:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidmlgWTDocumentSelectListFilteres]
  @Filter_ProjectID NVarChar(6),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,ProjectID NVarChar(6) NOT NULL
 ,DocumentID NVarChar(30) NOT NULL
 ,Revision NVarChar(2) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'ProjectID'
  SET @LGSQL = @LGSQL + ', DocumentID'
  SET @LGSQL = @LGSQL + ', Revision'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[PLM_lgWTDocument].[ProjectID]'
  SET @LGSQL = @LGSQL + ', [PLM_lgWTDocument].[DocumentID]'
  SET @LGSQL = @LGSQL + ', [PLM_lgWTDocument].[Revision]'
  SET @LGSQL = @LGSQL + ' FROM [PLM_lgWTDocument] '
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_ProjectID > '') 
    SET @LGSQL = @LGSQL + ' AND [PLM_lgWTDocument].[ProjectID] = ''' + @Filter_ProjectID + ''''
  ELSE
    SET @LGSQL = @LGSQL + ' AND [PLM_lgWTDocument].[ProjectID] = ''JB0802'''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'ProjectID' THEN '[PLM_lgWTDocument].[ProjectID]'
                        WHEN 'ProjectID DESC' THEN '[PLM_lgWTDocument].[ProjectID] DESC'
                        WHEN 'DocumentID' THEN '[PLM_lgWTDocument].[DocumentID]'
                        WHEN 'DocumentID DESC' THEN '[PLM_lgWTDocument].[DocumentID] DESC'
                        WHEN 'Revision' THEN '[PLM_lgWTDocument].[Revision]'
                        WHEN 'Revision DESC' THEN '[PLM_lgWTDocument].[Revision] DESC'
                        WHEN 'Description' THEN '[PLM_lgWTDocument].[Description]'
                        WHEN 'Description DESC' THEN '[PLM_lgWTDocument].[Description] DESC'
                        WHEN 'ElementID' THEN '[PLM_lgWTDocument].[ElementID]'
                        WHEN 'ElementID DESC' THEN '[PLM_lgWTDocument].[ElementID] DESC'
                        WHEN 'ElementDescription' THEN '[PLM_lgWTDocument].[ElementDescription]'
                        WHEN 'ElementDescription DESC' THEN '[PLM_lgWTDocument].[ElementDescription] DESC'
                        WHEN 'Status' THEN '[PLM_lgWTDocument].[Status]'
                        WHEN 'Status DESC' THEN '[PLM_lgWTDocument].[Status] DESC'
                        ELSE '[PLM_lgWTDocument].[ProjectID],[PLM_lgWTDocument].[DocumentID],[PLM_lgWTDocument].[Revision]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
		[PLM_lgWTDocument].[ProjectID] ,
		[PLM_lgWTDocument].[DocumentID] ,
		[PLM_lgWTDocument].[Revision] ,
		[PLM_lgWTDocument].[Description] ,
		[PLM_lgWTDocument].[ElementID] ,
		[PLM_lgWTDocument].[ElementDescription] ,
		[PLM_lgWTDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgWTDocument] 
    	INNER JOIN #PageIndex
          ON [PLM_lgWTDocument].[ProjectID] = #PageIndex.ProjectID
          AND [PLM_lgWTDocument].[DocumentID] = #PageIndex.DocumentID
          AND [PLM_lgWTDocument].[Revision] = #PageIndex.Revision
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END

GO
/****** Object:  StoredProcedure [dbo].[spidmlgWTDocumentSelectListSearch]    Script Date: 07/26/2012 11:54:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spidmlgWTDocumentSelectListSearch]
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
 ,ProjectID NVarChar(6) NOT NULL
 ,DocumentID NVarChar(30) NOT NULL
 ,Revision NVarChar(2) NOT NULL
  )
  INSERT INTO #PageIndex (ProjectID, DocumentID, Revision)
  SELECT [PLM_lgWTDocument].[ProjectID], [PLM_lgWTDocument].[DocumentID], [PLM_lgWTDocument].[Revision] FROM [PLM_lgWTDocument]
 WHERE  
   ( 
         LOWER(ISNULL([PLM_lgWTDocument].[ProjectID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgWTDocument].[DocumentID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgWTDocument].[Revision],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgWTDocument].[Description],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgWTDocument].[ElementID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgWTDocument].[ElementDescription],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([PLM_lgWTDocument].[Status],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'ProjectID' THEN [PLM_lgWTDocument].[ProjectID] END,
     CASE @OrderBy WHEN 'ProjectID DESC' THEN [PLM_lgWTDocument].[ProjectID] END DESC,
     CASE @OrderBy WHEN 'DocumentID' THEN [PLM_lgWTDocument].[DocumentID] END,
     CASE @OrderBy WHEN 'DocumentID DESC' THEN [PLM_lgWTDocument].[DocumentID] END DESC,
     CASE @OrderBy WHEN 'Revision' THEN [PLM_lgWTDocument].[Revision] END,
     CASE @OrderBy WHEN 'Revision DESC' THEN [PLM_lgWTDocument].[Revision] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [PLM_lgWTDocument].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [PLM_lgWTDocument].[Description] END DESC,
     CASE @OrderBy WHEN 'ElementID' THEN [PLM_lgWTDocument].[ElementID] END,
     CASE @OrderBy WHEN 'ElementID DESC' THEN [PLM_lgWTDocument].[ElementID] END DESC,
     CASE @OrderBy WHEN 'ElementDescription' THEN [PLM_lgWTDocument].[ElementDescription] END,
     CASE @OrderBy WHEN 'ElementDescription DESC' THEN [PLM_lgWTDocument].[ElementDescription] END DESC,
     CASE @OrderBy WHEN 'Status' THEN [PLM_lgWTDocument].[Status] END,
     CASE @OrderBy WHEN 'Status DESC' THEN [PLM_lgWTDocument].[Status] END DESC   

    SET @RecordCount = @@RowCount

  SELECT
		[PLM_lgWTDocument].[ProjectID] ,
		[PLM_lgWTDocument].[DocumentID] ,
		[PLM_lgWTDocument].[Revision] ,
		[PLM_lgWTDocument].[Description] ,
		[PLM_lgWTDocument].[ElementID] ,
		[PLM_lgWTDocument].[ElementDescription] ,
		[PLM_lgWTDocument].[Status] ,
		'' AS IDM_Projects1_Description 
  FROM [PLM_lgWTDocument] 
    	INNER JOIN #PageIndex
          ON [PLM_lgWTDocument].[ProjectID] = #PageIndex.ProjectID
          AND [PLM_lgWTDocument].[DocumentID] = #PageIndex.DocumentID
          AND [PLM_lgWTDocument].[Revision] = #PageIndex.Revision
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END