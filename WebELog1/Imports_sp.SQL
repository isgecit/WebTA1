SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spelogDetentionBillSelectByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spelogDetentionBillSelectByID]
GO
 
CREATE PROCEDURE [dbo].[spelogDetentionBillSelectByID]
  @LoginID NVarChar(8),
  @IRNo Int 
  AS
  SELECT
    [ELOG_DetentionBill].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [ELOG_DetentionBillStatus2].[Description] AS ELOG_DetentionBillStatus2_Description,
    [ELOG_DetentionBillTypes3].[Description] AS ELOG_DetentionBillTypes3_Description,
    [IDM_Projects4].[Description] AS IDM_Projects4_Description,
    [VR_BusinessPartner5].[BPName] AS VR_BusinessPartner5_BPName 
  FROM [ELOG_DetentionBill] 
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [ELOG_DetentionBill].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [ELOG_DetentionBillStatus] AS [ELOG_DetentionBillStatus2]
    ON [ELOG_DetentionBill].[StatusID] = [ELOG_DetentionBillStatus2].[StatusID]
  LEFT OUTER JOIN [ELOG_DetentionBillTypes] AS [ELOG_DetentionBillTypes3]
    ON [ELOG_DetentionBill].[BillTypeID] = [ELOG_DetentionBillTypes3].[BillTypeID]
  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects4]
    ON [ELOG_DetentionBill].[ProjectID] = [IDM_Projects4].[ProjectID]
  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner5]
    ON [ELOG_DetentionBill].[SupplierID] = [VR_BusinessPartner5].[BPID]
  WHERE
  [ELOG_DetentionBill].[IRNo] = @IRNo
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spelogDetentionBillSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spelogDetentionBillSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[spelogDetentionBillSelectListSearch]
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
 ,IRNo Int NOT NULL
  )
  INSERT INTO #PageIndex (IRNo)
  SELECT [ELOG_DetentionBill].[IRNo] FROM [ELOG_DetentionBill]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [ELOG_DetentionBill].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [ELOG_DetentionBillStatus] AS [ELOG_DetentionBillStatus2]
    ON [ELOG_DetentionBill].[StatusID] = [ELOG_DetentionBillStatus2].[StatusID]
  LEFT OUTER JOIN [ELOG_DetentionBillTypes] AS [ELOG_DetentionBillTypes3]
    ON [ELOG_DetentionBill].[BillTypeID] = [ELOG_DetentionBillTypes3].[BillTypeID]
  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects4]
    ON [ELOG_DetentionBill].[ProjectID] = [IDM_Projects4].[ProjectID]
  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner5]
    ON [ELOG_DetentionBill].[SupplierID] = [VR_BusinessPartner5].[BPID]
 WHERE  
   ( 
         STR(ISNULL([ELOG_DetentionBill].[IRNo], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ELOG_DetentionBill].[SupplierID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ELOG_DetentionBill].[SupplierBillNo],'')) LIKE @KeyWord1
     OR STR(ISNULL([ELOG_DetentionBill].[BillAmount], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ELOG_DetentionBill].[GRNo],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ELOG_DetentionBill].[ProjectID],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([ELOG_DetentionBill].[PONumber],'')) LIKE @KeyWord1
     OR STR(ISNULL([ELOG_DetentionBill].[BillTypeID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ELOG_DetentionBill].[OtherBillType],'')) LIKE @KeyWord1
     OR STR(ISNULL([ELOG_DetentionBill].[VehicleExeNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ELOG_DetentionBill].[MRNNo], 0)) LIKE @KeyWord1
     OR STR(ISNULL([ELOG_DetentionBill].[StatusID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([ELOG_DetentionBill].[CreatedBy],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'IRNo' THEN [ELOG_DetentionBill].[IRNo] END,
     CASE @OrderBy WHEN 'IRNo DESC' THEN [ELOG_DetentionBill].[IRNo] END DESC,
     CASE @OrderBy WHEN 'IRDate' THEN [ELOG_DetentionBill].[IRDate] END,
     CASE @OrderBy WHEN 'IRDate DESC' THEN [ELOG_DetentionBill].[IRDate] END DESC,
     CASE @OrderBy WHEN 'SupplierID' THEN [ELOG_DetentionBill].[SupplierID] END,
     CASE @OrderBy WHEN 'SupplierID DESC' THEN [ELOG_DetentionBill].[SupplierID] END DESC,
     CASE @OrderBy WHEN 'SupplierBillNo' THEN [ELOG_DetentionBill].[SupplierBillNo] END,
     CASE @OrderBy WHEN 'SupplierBillNo DESC' THEN [ELOG_DetentionBill].[SupplierBillNo] END DESC,
     CASE @OrderBy WHEN 'SupplierBillDate' THEN [ELOG_DetentionBill].[SupplierBillDate] END,
     CASE @OrderBy WHEN 'SupplierBillDate DESC' THEN [ELOG_DetentionBill].[SupplierBillDate] END DESC,
     CASE @OrderBy WHEN 'BillAmount' THEN [ELOG_DetentionBill].[BillAmount] END,
     CASE @OrderBy WHEN 'BillAmount DESC' THEN [ELOG_DetentionBill].[BillAmount] END DESC,
     CASE @OrderBy WHEN 'GRNo' THEN [ELOG_DetentionBill].[GRNo] END,
     CASE @OrderBy WHEN 'GRNo DESC' THEN [ELOG_DetentionBill].[GRNo] END DESC,
     CASE @OrderBy WHEN 'GRDate' THEN [ELOG_DetentionBill].[GRDate] END,
     CASE @OrderBy WHEN 'GRDate DESC' THEN [ELOG_DetentionBill].[GRDate] END DESC,
     CASE @OrderBy WHEN 'ProjectID' THEN [ELOG_DetentionBill].[ProjectID] END,
     CASE @OrderBy WHEN 'ProjectID DESC' THEN [ELOG_DetentionBill].[ProjectID] END DESC,
     CASE @OrderBy WHEN 'PONumber' THEN [ELOG_DetentionBill].[PONumber] END,
     CASE @OrderBy WHEN 'PONumber DESC' THEN [ELOG_DetentionBill].[PONumber] END DESC,
     CASE @OrderBy WHEN 'BillTypeID' THEN [ELOG_DetentionBill].[BillTypeID] END,
     CASE @OrderBy WHEN 'BillTypeID DESC' THEN [ELOG_DetentionBill].[BillTypeID] END DESC,
     CASE @OrderBy WHEN 'OtherBillType' THEN [ELOG_DetentionBill].[OtherBillType] END,
     CASE @OrderBy WHEN 'OtherBillType DESC' THEN [ELOG_DetentionBill].[OtherBillType] END DESC,
     CASE @OrderBy WHEN 'VehicleExeNo' THEN [ELOG_DetentionBill].[VehicleExeNo] END,
     CASE @OrderBy WHEN 'VehicleExeNo DESC' THEN [ELOG_DetentionBill].[VehicleExeNo] END DESC,
     CASE @OrderBy WHEN 'MRNNo' THEN [ELOG_DetentionBill].[MRNNo] END,
     CASE @OrderBy WHEN 'MRNNo DESC' THEN [ELOG_DetentionBill].[MRNNo] END DESC,
     CASE @OrderBy WHEN 'CreatedOn' THEN [ELOG_DetentionBill].[CreatedOn] END,
     CASE @OrderBy WHEN 'CreatedOn DESC' THEN [ELOG_DetentionBill].[CreatedOn] END DESC,
     CASE @OrderBy WHEN 'StatusID' THEN [ELOG_DetentionBill].[StatusID] END,
     CASE @OrderBy WHEN 'StatusID DESC' THEN [ELOG_DetentionBill].[StatusID] END DESC,
     CASE @OrderBy WHEN 'CreatedBy' THEN [ELOG_DetentionBill].[CreatedBy] END,
     CASE @OrderBy WHEN 'CreatedBy DESC' THEN [ELOG_DetentionBill].[CreatedBy] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC,
     CASE @OrderBy WHEN 'ELOG_DetentionBillStatus2_Description' THEN [ELOG_DetentionBillStatus2].[Description] END,
     CASE @OrderBy WHEN 'ELOG_DetentionBillStatus2_Description DESC' THEN [ELOG_DetentionBillStatus2].[Description] END DESC,
     CASE @OrderBy WHEN 'ELOG_DetentionBillTypes3_Description' THEN [ELOG_DetentionBillTypes3].[Description] END,
     CASE @OrderBy WHEN 'ELOG_DetentionBillTypes3_Description DESC' THEN [ELOG_DetentionBillTypes3].[Description] END DESC,
     CASE @OrderBy WHEN 'IDM_Projects4_Description' THEN [IDM_Projects4].[Description] END,
     CASE @OrderBy WHEN 'IDM_Projects4_Description DESC' THEN [IDM_Projects4].[Description] END DESC,
     CASE @OrderBy WHEN 'VR_BusinessPartner5_BPName' THEN [VR_BusinessPartner5].[BPName] END,
     CASE @OrderBy WHEN 'VR_BusinessPartner5_BPName DESC' THEN [VR_BusinessPartner5].[BPName] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [ELOG_DetentionBill].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [ELOG_DetentionBillStatus2].[Description] AS ELOG_DetentionBillStatus2_Description,
    [ELOG_DetentionBillTypes3].[Description] AS ELOG_DetentionBillTypes3_Description,
    [IDM_Projects4].[Description] AS IDM_Projects4_Description,
    [VR_BusinessPartner5].[BPName] AS VR_BusinessPartner5_BPName 
  FROM [ELOG_DetentionBill] 
      INNER JOIN #PageIndex
          ON [ELOG_DetentionBill].[IRNo] = #PageIndex.IRNo
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [ELOG_DetentionBill].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [ELOG_DetentionBillStatus] AS [ELOG_DetentionBillStatus2]
    ON [ELOG_DetentionBill].[StatusID] = [ELOG_DetentionBillStatus2].[StatusID]
  LEFT OUTER JOIN [ELOG_DetentionBillTypes] AS [ELOG_DetentionBillTypes3]
    ON [ELOG_DetentionBill].[BillTypeID] = [ELOG_DetentionBillTypes3].[BillTypeID]
  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects4]
    ON [ELOG_DetentionBill].[ProjectID] = [IDM_Projects4].[ProjectID]
  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner5]
    ON [ELOG_DetentionBill].[SupplierID] = [VR_BusinessPartner5].[BPID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spelogDetentionBillSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spelogDetentionBillSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[spelogDetentionBillSelectListFilteres]
  @Filter_SupplierID NVarChar(9),
  @Filter_ProjectID NVarChar(6),
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
 ,IRNo Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'IRNo'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[ELOG_DetentionBill].[IRNo]'
  SET @LGSQL = @LGSQL + ' FROM [ELOG_DetentionBill] '
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]'
  SET @LGSQL = @LGSQL + '    ON [ELOG_DetentionBill].[CreatedBy] = [aspnet_users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ELOG_DetentionBillStatus] AS [ELOG_DetentionBillStatus2]'
  SET @LGSQL = @LGSQL + '    ON [ELOG_DetentionBill].[StatusID] = [ELOG_DetentionBillStatus2].[StatusID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [ELOG_DetentionBillTypes] AS [ELOG_DetentionBillTypes3]'
  SET @LGSQL = @LGSQL + '    ON [ELOG_DetentionBill].[BillTypeID] = [ELOG_DetentionBillTypes3].[BillTypeID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects4]'
  SET @LGSQL = @LGSQL + '    ON [ELOG_DetentionBill].[ProjectID] = [IDM_Projects4].[ProjectID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner5]'
  SET @LGSQL = @LGSQL + '    ON [ELOG_DetentionBill].[SupplierID] = [VR_BusinessPartner5].[BPID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_SupplierID > '') 
    SET @LGSQL = @LGSQL + ' AND [ELOG_DetentionBill].[SupplierID] = ''' + @Filter_SupplierID + ''''
  IF (@Filter_ProjectID > '') 
    SET @LGSQL = @LGSQL + ' AND [ELOG_DetentionBill].[ProjectID] = ''' + @Filter_ProjectID + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'IRNo' THEN '[ELOG_DetentionBill].[IRNo]'
                        WHEN 'IRNo DESC' THEN '[ELOG_DetentionBill].[IRNo] DESC'
                        WHEN 'IRDate' THEN '[ELOG_DetentionBill].[IRDate]'
                        WHEN 'IRDate DESC' THEN '[ELOG_DetentionBill].[IRDate] DESC'
                        WHEN 'SupplierID' THEN '[ELOG_DetentionBill].[SupplierID]'
                        WHEN 'SupplierID DESC' THEN '[ELOG_DetentionBill].[SupplierID] DESC'
                        WHEN 'SupplierBillNo' THEN '[ELOG_DetentionBill].[SupplierBillNo]'
                        WHEN 'SupplierBillNo DESC' THEN '[ELOG_DetentionBill].[SupplierBillNo] DESC'
                        WHEN 'SupplierBillDate' THEN '[ELOG_DetentionBill].[SupplierBillDate]'
                        WHEN 'SupplierBillDate DESC' THEN '[ELOG_DetentionBill].[SupplierBillDate] DESC'
                        WHEN 'BillAmount' THEN '[ELOG_DetentionBill].[BillAmount]'
                        WHEN 'BillAmount DESC' THEN '[ELOG_DetentionBill].[BillAmount] DESC'
                        WHEN 'GRNo' THEN '[ELOG_DetentionBill].[GRNo]'
                        WHEN 'GRNo DESC' THEN '[ELOG_DetentionBill].[GRNo] DESC'
                        WHEN 'GRDate' THEN '[ELOG_DetentionBill].[GRDate]'
                        WHEN 'GRDate DESC' THEN '[ELOG_DetentionBill].[GRDate] DESC'
                        WHEN 'ProjectID' THEN '[ELOG_DetentionBill].[ProjectID]'
                        WHEN 'ProjectID DESC' THEN '[ELOG_DetentionBill].[ProjectID] DESC'
                        WHEN 'PONumber' THEN '[ELOG_DetentionBill].[PONumber]'
                        WHEN 'PONumber DESC' THEN '[ELOG_DetentionBill].[PONumber] DESC'
                        WHEN 'BillTypeID' THEN '[ELOG_DetentionBill].[BillTypeID]'
                        WHEN 'BillTypeID DESC' THEN '[ELOG_DetentionBill].[BillTypeID] DESC'
                        WHEN 'OtherBillType' THEN '[ELOG_DetentionBill].[OtherBillType]'
                        WHEN 'OtherBillType DESC' THEN '[ELOG_DetentionBill].[OtherBillType] DESC'
                        WHEN 'VehicleExeNo' THEN '[ELOG_DetentionBill].[VehicleExeNo]'
                        WHEN 'VehicleExeNo DESC' THEN '[ELOG_DetentionBill].[VehicleExeNo] DESC'
                        WHEN 'MRNNo' THEN '[ELOG_DetentionBill].[MRNNo]'
                        WHEN 'MRNNo DESC' THEN '[ELOG_DetentionBill].[MRNNo] DESC'
                        WHEN 'CreatedOn' THEN '[ELOG_DetentionBill].[CreatedOn]'
                        WHEN 'CreatedOn DESC' THEN '[ELOG_DetentionBill].[CreatedOn] DESC'
                        WHEN 'StatusID' THEN '[ELOG_DetentionBill].[StatusID]'
                        WHEN 'StatusID DESC' THEN '[ELOG_DetentionBill].[StatusID] DESC'
                        WHEN 'CreatedBy' THEN '[ELOG_DetentionBill].[CreatedBy]'
                        WHEN 'CreatedBy DESC' THEN '[ELOG_DetentionBill].[CreatedBy] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        WHEN 'ELOG_DetentionBillStatus2_Description' THEN '[ELOG_DetentionBillStatus2].[Description]'
                        WHEN 'ELOG_DetentionBillStatus2_Description DESC' THEN '[ELOG_DetentionBillStatus2].[Description] DESC'
                        WHEN 'ELOG_DetentionBillTypes3_Description' THEN '[ELOG_DetentionBillTypes3].[Description]'
                        WHEN 'ELOG_DetentionBillTypes3_Description DESC' THEN '[ELOG_DetentionBillTypes3].[Description] DESC'
                        WHEN 'IDM_Projects4_Description' THEN '[IDM_Projects4].[Description]'
                        WHEN 'IDM_Projects4_Description DESC' THEN '[IDM_Projects4].[Description] DESC'
                        WHEN 'VR_BusinessPartner5_BPName' THEN '[VR_BusinessPartner5].[BPName]'
                        WHEN 'VR_BusinessPartner5_BPName DESC' THEN '[VR_BusinessPartner5].[BPName] DESC'
                        ELSE '[ELOG_DetentionBill].[IRNo]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [ELOG_DetentionBill].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [ELOG_DetentionBillStatus2].[Description] AS ELOG_DetentionBillStatus2_Description,
    [ELOG_DetentionBillTypes3].[Description] AS ELOG_DetentionBillTypes3_Description,
    [IDM_Projects4].[Description] AS IDM_Projects4_Description,
    [VR_BusinessPartner5].[BPName] AS VR_BusinessPartner5_BPName 
  FROM [ELOG_DetentionBill] 
      INNER JOIN #PageIndex
          ON [ELOG_DetentionBill].[IRNo] = #PageIndex.IRNo
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [ELOG_DetentionBill].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [ELOG_DetentionBillStatus] AS [ELOG_DetentionBillStatus2]
    ON [ELOG_DetentionBill].[StatusID] = [ELOG_DetentionBillStatus2].[StatusID]
  LEFT OUTER JOIN [ELOG_DetentionBillTypes] AS [ELOG_DetentionBillTypes3]
    ON [ELOG_DetentionBill].[BillTypeID] = [ELOG_DetentionBillTypes3].[BillTypeID]
  LEFT OUTER JOIN [IDM_Projects] AS [IDM_Projects4]
    ON [ELOG_DetentionBill].[ProjectID] = [IDM_Projects4].[ProjectID]
  LEFT OUTER JOIN [VR_BusinessPartner] AS [VR_BusinessPartner5]
    ON [ELOG_DetentionBill].[SupplierID] = [VR_BusinessPartner5].[BPID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spelogDetentionBillInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spelogDetentionBillInsert]
GO
 
CREATE PROCEDURE [dbo].[spelogDetentionBillInsert]
  @IRNo Int,
  @IRDate DateTime,
  @SupplierID NVarChar(9),
  @SupplierBillNo NVarChar(50),
  @SupplierBillDate DateTime,
  @BillAmount Decimal(18,2),
  @GRNo NVarChar(50),
  @GRDate DateTime,
  @ProjectID NVarChar(6),
  @PONumber NVarChar(9),
  @BillTypeID Int,
  @OtherBillType NVarChar(20),
  @VehicleExeNo Int,
  @MRNNo Int,
  @CreatedOn DateTime,
  @StatusID Int,
  @CreatedBy NVarChar(8),
  @Return_IRNo Int = null OUTPUT 
  AS
  INSERT [ELOG_DetentionBill]
  (
   [IRNo]
  ,[IRDate]
  ,[SupplierID]
  ,[SupplierBillNo]
  ,[SupplierBillDate]
  ,[BillAmount]
  ,[GRNo]
  ,[GRDate]
  ,[ProjectID]
  ,[PONumber]
  ,[BillTypeID]
  ,[OtherBillType]
  ,[VehicleExeNo]
  ,[MRNNo]
  ,[CreatedOn]
  ,[StatusID]
  ,[CreatedBy]
  )
  VALUES
  (
   @IRNo
  ,@IRDate
  ,@SupplierID
  ,@SupplierBillNo
  ,@SupplierBillDate
  ,@BillAmount
  ,@GRNo
  ,@GRDate
  ,@ProjectID
  ,@PONumber
  ,@BillTypeID
  ,@OtherBillType
  ,@VehicleExeNo
  ,@MRNNo
  ,@CreatedOn
  ,@StatusID
  ,@CreatedBy
  )
  SET @Return_IRNo = @IRNo
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spelogDetentionBillUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spelogDetentionBillUpdate]
GO
 
CREATE PROCEDURE [dbo].[spelogDetentionBillUpdate]
  @Original_IRNo Int, 
  @IRNo Int,
  @IRDate DateTime,
  @SupplierID NVarChar(9),
  @SupplierBillNo NVarChar(50),
  @SupplierBillDate DateTime,
  @BillAmount Decimal(18,2),
  @GRNo NVarChar(50),
  @GRDate DateTime,
  @ProjectID NVarChar(6),
  @PONumber NVarChar(9),
  @BillTypeID Int,
  @OtherBillType NVarChar(20),
  @VehicleExeNo Int,
  @MRNNo Int,
  @CreatedOn DateTime,
  @StatusID Int,
  @CreatedBy NVarChar(8),
  @RowCount int = null OUTPUT
  AS
  UPDATE [ELOG_DetentionBill] SET 
   [IRNo] = @IRNo
  ,[IRDate] = @IRDate
  ,[SupplierID] = @SupplierID
  ,[SupplierBillNo] = @SupplierBillNo
  ,[SupplierBillDate] = @SupplierBillDate
  ,[BillAmount] = @BillAmount
  ,[GRNo] = @GRNo
  ,[GRDate] = @GRDate
  ,[ProjectID] = @ProjectID
  ,[PONumber] = @PONumber
  ,[BillTypeID] = @BillTypeID
  ,[OtherBillType] = @OtherBillType
  ,[VehicleExeNo] = @VehicleExeNo
  ,[MRNNo] = @MRNNo
  ,[CreatedOn] = @CreatedOn
  ,[StatusID] = @StatusID
  ,[CreatedBy] = @CreatedBy
  WHERE
  [IRNo] = @Original_IRNo
  SET @RowCount = @@RowCount
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spelogDetentionBillDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spelogDetentionBillDelete]
GO
 
CREATE PROCEDURE [dbo].[spelogDetentionBillDelete]
  @Original_IRNo Int,
  @RowCount int = null OUTPUT
  AS
  DELETE [ELOG_DetentionBill]
  WHERE
  [ELOG_DetentionBill].[IRNo] = @Original_IRNo
  SET @RowCount = @@RowCount
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
