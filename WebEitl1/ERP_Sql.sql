SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
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

go


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

go

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


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

 

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
