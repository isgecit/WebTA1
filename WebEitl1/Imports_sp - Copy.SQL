SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfDBPreOrderHistorySelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfDBPreOrderHistorySelectByID]
GO
 
CREATE PROCEDURE [dbo].[spwfDBPreOrderHistorySelectByID]
  @LoginID NVarChar(8),
  @WFID Int 
  AS
  SELECT
    [WF1_PreOrder_History].* ,
    [aspnet_Users3].[UserFullName] AS aspnet_Users3_UserFullName,
    [aspnet_Users2].[UserFullName] AS aspnet_Users2_UserFullName 
  FROM [WF1_PreOrder_History] 
  INNER JOIN [aspnet_Users] AS [aspnet_Users3]
    ON [WF1_PreOrder_History].[UserId] = [aspnet_Users3].[LoginID]
  INNER JOIN [aspnet_Users] AS [aspnet_Users2]
    ON [WF1_PreOrder_History].[Buyer] = [aspnet_Users2].[LoginID]
  WHERE
  [WF1_PreOrder_History].[WFID] = @WFID
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfDBPreOrderHistorySelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfDBPreOrderHistorySelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spwfDBPreOrderHistorySelectListSearch]
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
 ,WFID Int NOT NULL
  )
  INSERT INTO #PageIndex (WFID)
  SELECT [WF1_PreOrder_History].[WFID] FROM [WF1_PreOrder_History]
  INNER JOIN [aspnet_Users] AS [aspnet_Users3]
    ON [WF1_PreOrder_History].[UserId] = [aspnet_Users3].[LoginID]
  INNER JOIN [aspnet_Users] AS [aspnet_Users2]
    ON [WF1_PreOrder_History].[Buyer] = [aspnet_Users2].[LoginID]
 WHERE  
   ( 
         STR(ISNULL([WF1_PreOrder_History].[WFID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[Project],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[Element],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[SpecificationNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[Buyer],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[SupplierName],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[Supplier],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[Notes],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[UserId],'')) LIKE @KeyWord1
     OR STR(ISNULL([WF1_PreOrder_History].[Parent_WFID], 0)) LIKE @KeyWord1
     OR STR(ISNULL([WF1_PreOrder_History].[WFID_SlNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([WF1_PreOrder_History].[WF_Status],'')) LIKE @KeyWord1
     OR STR(ISNULL([WF1_PreOrder_History].[WF_HistoryID], 0)) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'WFID' THEN [WF1_PreOrder_History].[WFID] END,
     CASE @OrderBy WHEN 'WFID DESC' THEN [WF1_PreOrder_History].[WFID] END DESC,
     CASE @OrderBy WHEN 'Project' THEN [WF1_PreOrder_History].[Project] END,
     CASE @OrderBy WHEN 'Project DESC' THEN [WF1_PreOrder_History].[Project] END DESC,
     CASE @OrderBy WHEN 'Element' THEN [WF1_PreOrder_History].[Element] END,
     CASE @OrderBy WHEN 'Element DESC' THEN [WF1_PreOrder_History].[Element] END DESC,
     CASE @OrderBy WHEN 'SpecificationNo' THEN [WF1_PreOrder_History].[SpecificationNo] END,
     CASE @OrderBy WHEN 'SpecificationNo DESC' THEN [WF1_PreOrder_History].[SpecificationNo] END DESC,
     CASE @OrderBy WHEN 'Buyer' THEN [WF1_PreOrder_History].[Buyer] END,
     CASE @OrderBy WHEN 'Buyer DESC' THEN [WF1_PreOrder_History].[Buyer] END DESC,
     CASE @OrderBy WHEN 'SupplierName' THEN [WF1_PreOrder_History].[SupplierName] END,
     CASE @OrderBy WHEN 'SupplierName DESC' THEN [WF1_PreOrder_History].[SupplierName] END DESC,
     CASE @OrderBy WHEN 'Supplier' THEN [WF1_PreOrder_History].[Supplier] END,
     CASE @OrderBy WHEN 'Supplier DESC' THEN [WF1_PreOrder_History].[Supplier] END DESC,
     CASE @OrderBy WHEN 'Notes' THEN [WF1_PreOrder_History].[Notes] END,
     CASE @OrderBy WHEN 'Notes DESC' THEN [WF1_PreOrder_History].[Notes] END DESC,
     CASE @OrderBy WHEN 'DateTime' THEN [WF1_PreOrder_History].[DateTime] END,
     CASE @OrderBy WHEN 'DateTime DESC' THEN [WF1_PreOrder_History].[DateTime] END DESC,
     CASE @OrderBy WHEN 'UserId' THEN [WF1_PreOrder_History].[UserId] END,
     CASE @OrderBy WHEN 'UserId DESC' THEN [WF1_PreOrder_History].[UserId] END DESC,
     CASE @OrderBy WHEN 'Parent_WFID' THEN [WF1_PreOrder_History].[Parent_WFID] END,
     CASE @OrderBy WHEN 'Parent_WFID DESC' THEN [WF1_PreOrder_History].[Parent_WFID] END DESC,
     CASE @OrderBy WHEN 'WFID_SlNo' THEN [WF1_PreOrder_History].[WFID_SlNo] END,
     CASE @OrderBy WHEN 'WFID_SlNo DESC' THEN [WF1_PreOrder_History].[WFID_SlNo] END DESC,
     CASE @OrderBy WHEN 'WF_Status' THEN [WF1_PreOrder_History].[WF_Status] END,
     CASE @OrderBy WHEN 'WF_Status DESC' THEN [WF1_PreOrder_History].[WF_Status] END DESC,
     CASE @OrderBy WHEN 'WF_HistoryID' THEN [WF1_PreOrder_History].[WF_HistoryID] END,
     CASE @OrderBy WHEN 'WF_HistoryID DESC' THEN [WF1_PreOrder_History].[WF_HistoryID] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users3_UserFullName' THEN [aspnet_Users3].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users3_UserFullName DESC' THEN [aspnet_Users3].[UserFullName] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users2_UserFullName' THEN [aspnet_Users2].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users2_UserFullName DESC' THEN [aspnet_Users2].[UserFullName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [WF1_PreOrder_History].* ,
    [aspnet_Users3].[UserFullName] AS aspnet_Users3_UserFullName,
    [aspnet_Users2].[UserFullName] AS aspnet_Users2_UserFullName 
  FROM [WF1_PreOrder_History] 
      INNER JOIN #PageIndex
          ON [WF1_PreOrder_History].[WFID] = #PageIndex.WFID
  INNER JOIN [aspnet_Users] AS [aspnet_Users3]
    ON [WF1_PreOrder_History].[UserId] = [aspnet_Users3].[LoginID]
  INNER JOIN [aspnet_Users] AS [aspnet_Users2]
    ON [WF1_PreOrder_History].[Buyer] = [aspnet_Users2].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfDBPreOrderHistorySelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfDBPreOrderHistorySelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spwfDBPreOrderHistorySelectListFilteres]
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
 ,WFID Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'WFID'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[WF1_PreOrder_History].[WFID]'
  SET @LGSQL = @LGSQL + ' FROM [WF1_PreOrder_History] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [aspnet_Users] AS [aspnet_Users3]'
  SET @LGSQL = @LGSQL + '    ON [WF1_PreOrder_History].[UserId] = [aspnet_Users3].[LoginID]'
  SET @LGSQL = @LGSQL + '  INNER JOIN [aspnet_Users] AS [aspnet_Users2]'
  SET @LGSQL = @LGSQL + '    ON [WF1_PreOrder_History].[Buyer] = [aspnet_Users2].[LoginID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'WFID' THEN '[WF1_PreOrder_History].[WFID]'
                        WHEN 'WFID DESC' THEN '[WF1_PreOrder_History].[WFID] DESC'
                        WHEN 'Project' THEN '[WF1_PreOrder_History].[Project]'
                        WHEN 'Project DESC' THEN '[WF1_PreOrder_History].[Project] DESC'
                        WHEN 'Element' THEN '[WF1_PreOrder_History].[Element]'
                        WHEN 'Element DESC' THEN '[WF1_PreOrder_History].[Element] DESC'
                        WHEN 'SpecificationNo' THEN '[WF1_PreOrder_History].[SpecificationNo]'
                        WHEN 'SpecificationNo DESC' THEN '[WF1_PreOrder_History].[SpecificationNo] DESC'
                        WHEN 'Buyer' THEN '[WF1_PreOrder_History].[Buyer]'
                        WHEN 'Buyer DESC' THEN '[WF1_PreOrder_History].[Buyer] DESC'
                        WHEN 'SupplierName' THEN '[WF1_PreOrder_History].[SupplierName]'
                        WHEN 'SupplierName DESC' THEN '[WF1_PreOrder_History].[SupplierName] DESC'
                        WHEN 'Supplier' THEN '[WF1_PreOrder_History].[Supplier]'
                        WHEN 'Supplier DESC' THEN '[WF1_PreOrder_History].[Supplier] DESC'
                        WHEN 'Notes' THEN '[WF1_PreOrder_History].[Notes]'
                        WHEN 'Notes DESC' THEN '[WF1_PreOrder_History].[Notes] DESC'
                        WHEN 'DateTime' THEN '[WF1_PreOrder_History].[DateTime]'
                        WHEN 'DateTime DESC' THEN '[WF1_PreOrder_History].[DateTime] DESC'
                        WHEN 'UserId' THEN '[WF1_PreOrder_History].[UserId]'
                        WHEN 'UserId DESC' THEN '[WF1_PreOrder_History].[UserId] DESC'
                        WHEN 'Parent_WFID' THEN '[WF1_PreOrder_History].[Parent_WFID]'
                        WHEN 'Parent_WFID DESC' THEN '[WF1_PreOrder_History].[Parent_WFID] DESC'
                        WHEN 'WFID_SlNo' THEN '[WF1_PreOrder_History].[WFID_SlNo]'
                        WHEN 'WFID_SlNo DESC' THEN '[WF1_PreOrder_History].[WFID_SlNo] DESC'
                        WHEN 'WF_Status' THEN '[WF1_PreOrder_History].[WF_Status]'
                        WHEN 'WF_Status DESC' THEN '[WF1_PreOrder_History].[WF_Status] DESC'
                        WHEN 'WF_HistoryID' THEN '[WF1_PreOrder_History].[WF_HistoryID]'
                        WHEN 'WF_HistoryID DESC' THEN '[WF1_PreOrder_History].[WF_HistoryID] DESC'
                        WHEN 'aspnet_Users3_UserFullName' THEN '[aspnet_Users3].[UserFullName]'
                        WHEN 'aspnet_Users3_UserFullName DESC' THEN '[aspnet_Users3].[UserFullName] DESC'
                        WHEN 'aspnet_Users2_UserFullName' THEN '[aspnet_Users2].[UserFullName]'
                        WHEN 'aspnet_Users2_UserFullName DESC' THEN '[aspnet_Users2].[UserFullName] DESC'
                        ELSE '[WF1_PreOrder_History].[WFID]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [WF1_PreOrder_History].* ,
    [aspnet_Users3].[UserFullName] AS aspnet_Users3_UserFullName,
    [aspnet_Users2].[UserFullName] AS aspnet_Users2_UserFullName 
  FROM [WF1_PreOrder_History] 
      INNER JOIN #PageIndex
          ON [WF1_PreOrder_History].[WFID] = #PageIndex.WFID
  INNER JOIN [aspnet_Users] AS [aspnet_Users3]
    ON [WF1_PreOrder_History].[UserId] = [aspnet_Users3].[LoginID]
  INNER JOIN [aspnet_Users] AS [aspnet_Users2]
    ON [WF1_PreOrder_History].[Buyer] = [aspnet_Users2].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfDBPreOrderHistoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfDBPreOrderHistoryInsert]
GO
 
CREATE PROCEDURE [dbo].[spwfDBPreOrderHistoryInsert]
  @WFID Int,
  @Project VarChar(50),
  @Element VarChar(50),
  @SpecificationNo VarChar(100),
  @Buyer VarChar(8),
  @SupplierName VarChar(100),
  @Supplier VarChar(50),
  @Notes VarChar(4000),
  @DateTime DateTime,
  @UserId VarChar(8),
  @Parent_WFID Int,
  @WFID_SlNo Int,
  @WF_Status VarChar(100),
  @WF_HistoryID Int,
  @Return_WFID Int = null OUTPUT 
  AS
  INSERT [WF1_PreOrder_History]
  (
   [WFID]
  ,[Project]
  ,[Element]
  ,[SpecificationNo]
  ,[Buyer]
  ,[SupplierName]
  ,[Supplier]
  ,[Notes]
  ,[DateTime]
  ,[UserId]
  ,[Parent_WFID]
  ,[WFID_SlNo]
  ,[WF_Status]
  ,[WF_HistoryID]
  )
  VALUES
  (
   @WFID
  ,@Project
  ,@Element
  ,@SpecificationNo
  ,@Buyer
  ,@SupplierName
  ,@Supplier
  ,@Notes
  ,@DateTime
  ,@UserId
  ,@Parent_WFID
  ,@WFID_SlNo
  ,@WF_Status
  ,@WF_HistoryID
  )
  SET @Return_WFID = @WFID
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfDBPreOrderHistoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfDBPreOrderHistoryUpdate]
GO
 
CREATE PROCEDURE [dbo].[spwfDBPreOrderHistoryUpdate]
  @Original_WFID Int, 
  @WFID Int,
  @Project VarChar(50),
  @Element VarChar(50),
  @SpecificationNo VarChar(100),
  @Buyer VarChar(8),
  @SupplierName VarChar(100),
  @Supplier VarChar(50),
  @Notes VarChar(4000),
  @DateTime DateTime,
  @UserId VarChar(8),
  @Parent_WFID Int,
  @WFID_SlNo Int,
  @WF_Status VarChar(100),
  @WF_HistoryID Int,
  @RowCount int = null OUTPUT
  AS
  UPDATE [WF1_PreOrder_History] SET 
   [WFID] = @WFID
  ,[Project] = @Project
  ,[Element] = @Element
  ,[SpecificationNo] = @SpecificationNo
  ,[Buyer] = @Buyer
  ,[SupplierName] = @SupplierName
  ,[Supplier] = @Supplier
  ,[Notes] = @Notes
  ,[DateTime] = @DateTime
  ,[UserId] = @UserId
  ,[Parent_WFID] = @Parent_WFID
  ,[WFID_SlNo] = @WFID_SlNo
  ,[WF_Status] = @WF_Status
  ,[WF_HistoryID] = @WF_HistoryID
  WHERE
  [WFID] = @Original_WFID
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfDBPreOrderHistoryDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfDBPreOrderHistoryDelete]
GO
 
CREATE PROCEDURE [dbo].[spwfDBPreOrderHistoryDelete]
  @Original_WFID Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [WF1_PreOrder_History]
  WHERE
  [WF1_PreOrder_History].[WFID] = @Original_WFID
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfdbNotesSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfdbNotesSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spwfdbNotesSelectByID]
  @LoginID NVarChar(8),
  @IndexValue VarChar(200),
  @NotesId VarChar(200) 
  AS
  SELECT
    [Note_Notes].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Notes] 
  INNER JOIN [aspnet_Users] AS [aspnet_Users1]
    ON [Note_Notes].[UserId] = [aspnet_Users1].[LoginID]
  WHERE
  [Note_Notes].[IndexValue] = @IndexValue
  AND [Note_Notes].[NotesId] = @NotesId
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfdbNotesSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfdbNotesSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spwfdbNotesSelectListSearch]
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
 ,IndexValue VarChar(200) NOT NULL
 ,NotesId VarChar(200) NOT NULL
  )
  INSERT INTO #PageIndex (IndexValue, NotesId)
  SELECT [Note_Notes].[IndexValue], [Note_Notes].[NotesId] FROM [Note_Notes]
  INNER JOIN [aspnet_Users] AS [aspnet_Users1]
    ON [Note_Notes].[UserId] = [aspnet_Users1].[LoginID]
 WHERE  
   ( 
         LOWER(ISNULL([Note_Notes].[IndexValue],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[Title],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[UserId],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[SendEmailTo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[NotesId],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[Description],'')) LIKE @KeyWord1
     OR STR(ISNULL([Note_Notes].[Notes_RunningNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([Note_Notes].[NotesHandle],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'IndexValue' THEN [Note_Notes].[IndexValue] END,
     CASE @OrderBy WHEN 'IndexValue DESC' THEN [Note_Notes].[IndexValue] END DESC,
     CASE @OrderBy WHEN 'SendEmailTo' THEN [Note_Notes].[SendEmailTo] END,
     CASE @OrderBy WHEN 'SendEmailTo DESC' THEN [Note_Notes].[SendEmailTo] END DESC,
     CASE @OrderBy WHEN 'Title' THEN [Note_Notes].[Title] END,
     CASE @OrderBy WHEN 'Title DESC' THEN [Note_Notes].[Title] END DESC,
     CASE @OrderBy WHEN 'Description' THEN [Note_Notes].[Description] END,
     CASE @OrderBy WHEN 'Description DESC' THEN [Note_Notes].[Description] END DESC,
     CASE @OrderBy WHEN 'Notes_RunningNo' THEN [Note_Notes].[Notes_RunningNo] END,
     CASE @OrderBy WHEN 'Notes_RunningNo DESC' THEN [Note_Notes].[Notes_RunningNo] END DESC,
     CASE @OrderBy WHEN 'NotesHandle' THEN [Note_Notes].[NotesHandle] END,
     CASE @OrderBy WHEN 'NotesHandle DESC' THEN [Note_Notes].[NotesHandle] END DESC,
     CASE @OrderBy WHEN 'UserId' THEN [Note_Notes].[UserId] END,
     CASE @OrderBy WHEN 'UserId DESC' THEN [Note_Notes].[UserId] END DESC,
     CASE @OrderBy WHEN 'Created_Date' THEN [Note_Notes].[Created_Date] END,
     CASE @OrderBy WHEN 'Created_Date DESC' THEN [Note_Notes].[Created_Date] END DESC,
     CASE @OrderBy WHEN 'NotesId' THEN [Note_Notes].[NotesId] END,
     CASE @OrderBy WHEN 'NotesId DESC' THEN [Note_Notes].[NotesId] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [Note_Notes].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Notes] 
      INNER JOIN #PageIndex
          ON [Note_Notes].[IndexValue] = #PageIndex.IndexValue
          AND [Note_Notes].[NotesId] = #PageIndex.NotesId
  INNER JOIN [aspnet_Users] AS [aspnet_Users1]
    ON [Note_Notes].[UserId] = [aspnet_Users1].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfdbNotesSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfdbNotesSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spwfdbNotesSelectListFilteres]
  @Filter_IndexValue VarChar(200),
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
 ,IndexValue VarChar(200) NOT NULL
 ,NotesId VarChar(200) NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'IndexValue'
  SET @LGSQL = @LGSQL + ', NotesId'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[Note_Notes].[IndexValue]'
  SET @LGSQL = @LGSQL + ', [Note_Notes].[NotesId]'
  SET @LGSQL = @LGSQL + ' FROM [Note_Notes] '
  SET @LGSQL = @LGSQL + '  INNER JOIN [aspnet_Users] AS [aspnet_Users1]'
  SET @LGSQL = @LGSQL + '    ON [Note_Notes].[UserId] = [aspnet_Users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_IndexValue > '') 
    SET @LGSQL = @LGSQL + ' AND [Note_Notes].[IndexValue] = ''' + @Filter_IndexValue + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'IndexValue' THEN '[Note_Notes].[IndexValue]'
                        WHEN 'IndexValue DESC' THEN '[Note_Notes].[IndexValue] DESC'
                        WHEN 'SendEmailTo' THEN '[Note_Notes].[SendEmailTo]'
                        WHEN 'SendEmailTo DESC' THEN '[Note_Notes].[SendEmailTo] DESC'
                        WHEN 'Title' THEN '[Note_Notes].[Title]'
                        WHEN 'Title DESC' THEN '[Note_Notes].[Title] DESC'
                        WHEN 'Description' THEN '[Note_Notes].[Description]'
                        WHEN 'Description DESC' THEN '[Note_Notes].[Description] DESC'
                        WHEN 'Notes_RunningNo' THEN '[Note_Notes].[Notes_RunningNo]'
                        WHEN 'Notes_RunningNo DESC' THEN '[Note_Notes].[Notes_RunningNo] DESC'
                        WHEN 'NotesHandle' THEN '[Note_Notes].[NotesHandle]'
                        WHEN 'NotesHandle DESC' THEN '[Note_Notes].[NotesHandle] DESC'
                        WHEN 'UserId' THEN '[Note_Notes].[UserId]'
                        WHEN 'UserId DESC' THEN '[Note_Notes].[UserId] DESC'
                        WHEN 'Created_Date' THEN '[Note_Notes].[Created_Date]'
                        WHEN 'Created_Date DESC' THEN '[Note_Notes].[Created_Date] DESC'
                        WHEN 'NotesId' THEN '[Note_Notes].[NotesId]'
                        WHEN 'NotesId DESC' THEN '[Note_Notes].[NotesId] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        ELSE '[Note_Notes].[IndexValue],[Note_Notes].[NotesId]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [Note_Notes].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName 
  FROM [Note_Notes] 
      INNER JOIN #PageIndex
          ON [Note_Notes].[IndexValue] = #PageIndex.IndexValue
          AND [Note_Notes].[NotesId] = #PageIndex.NotesId
  INNER JOIN [aspnet_Users] AS [aspnet_Users1]
    ON [Note_Notes].[UserId] = [aspnet_Users1].[LoginID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfdbNotesInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfdbNotesInsert]
GO
 
CREATE PROCEDURE [dbo].[spwfdbNotesInsert]
  @IndexValue VarChar(200),
  @Title VarChar(4000),
  @UserId VarChar(8),
  @Created_Date DateTime,
  @SendEmailTo VarChar(4000),
  @NotesId VarChar(200),
  @Description VarChar(4000),
  @Notes_RunningNo Int,
  @NotesHandle VarChar(200),
  @Return_IndexValue VarChar(200) = null OUTPUT, 
  @Return_NotesId VarChar(200) = null OUTPUT 
  AS
  INSERT [Note_Notes]
  (
   [IndexValue]
  ,[Title]
  ,[UserId]
  ,[Created_Date]
  ,[SendEmailTo]
  ,[NotesId]
  ,[Description]
  ,[Notes_RunningNo]
  ,[NotesHandle]
  )
  VALUES
  (
   UPPER(@IndexValue)
  ,@Title
  ,@UserId
  ,@Created_Date
  ,@SendEmailTo
  ,UPPER(@NotesId)
  ,@Description
  ,@Notes_RunningNo
  ,@NotesHandle
  )
  SET @Return_IndexValue = @IndexValue
  SET @Return_NotesId = @NotesId
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfdbNotesUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfdbNotesUpdate]
GO
 
CREATE PROCEDURE [dbo].[spwfdbNotesUpdate]
  @Original_IndexValue VarChar(200), 
  @Original_NotesId VarChar(200), 
  @IndexValue VarChar(200),
  @Title VarChar(4000),
  @UserId VarChar(8),
  @Created_Date DateTime,
  @SendEmailTo VarChar(4000),
  @NotesId VarChar(200),
  @Description VarChar(4000),
  @Notes_RunningNo Int,
  @NotesHandle VarChar(200),
  @RowCount int = null OUTPUT
  AS
  UPDATE [Note_Notes] SET 
   [IndexValue] = @IndexValue
  ,[Title] = @Title
  ,[UserId] = @UserId
  ,[Created_Date] = @Created_Date
  ,[SendEmailTo] = @SendEmailTo
  ,[NotesId] = @NotesId
  ,[Description] = @Description
  ,[Notes_RunningNo] = @Notes_RunningNo
  ,[NotesHandle] = @NotesHandle
  WHERE
  [IndexValue] = @Original_IndexValue
  AND [NotesId] = @Original_NotesId
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spwfdbNotesDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spwfdbNotesDelete]
GO
 
CREATE PROCEDURE [dbo].[spwfdbNotesDelete]
  @Original_IndexValue VarChar(200),
  @Original_NotesId VarChar(200),
  @RowCount int = null OUTPUT
  AS
  DELETE [Note_Notes]
  WHERE
  [Note_Notes].[IndexValue] = @Original_IndexValue
  AND [Note_Notes].[NotesId] = @Original_NotesId
  SET @RowCount = @@RowCount
  GO


SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
