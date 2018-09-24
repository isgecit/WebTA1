USE [wcadmin]
GO
/****** Object:  View [dbo].[PLM_lgEPDocument]    Script Date: 07/26/2012 11:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PLM_lgEPDocument]
AS
SELECT     TOP (100) PERCENT wcadmin.PDMLinkProduct.namecontainerInfo AS ProjectID, wcadmin.EPMDocumentMaster.name AS Description, 
                      wcadmin.EPMDocumentMaster.documentNumber AS DocumentID, SUBSTRING(wcadmin.EPMDocument.nameB2folderingInfo,0,8) AS ElementID,wcadmin.EPMDocument.nameB2folderingInfo AS ElementDescription, 
                      wcadmin.EPMDocument.statestate AS Status, wcadmin.EPMDocument.versionIdA2versionInfo AS Revision
FROM         wcadmin.EPMDocumentMaster INNER JOIN
                      wcadmin.EPMDocument ON wcadmin.EPMDocumentMaster.idA2A2 = wcadmin.EPMDocument.idA3masterReference INNER JOIN
                      wcadmin.PDMLinkProduct ON wcadmin.EPMDocumentMaster.idA3containerReference = wcadmin.PDMLinkProduct.idA2A2
WHERE     (wcadmin.EPMDocument.statestate = N'RELEASED') AND (wcadmin.EPMDocument.versionIdA2versionInfo =
                          (SELECT     MAX(versionIdA2versionInfo) AS Rev
                            FROM          wcadmin.EPMDocument AS Ep1
                            WHERE      (idA3masterReference = wcadmin.EPMDocument.idA3masterReference) AND (statestate = N'RELEASED')))
ORDER BY DocumentID

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[25] 4[49] 3[4] 2) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1[56] 3) )"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[23] 4[33] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EPMDocumentMaster (wcadmin)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "EPMDocument (wcadmin)"
            Begin Extent = 
               Top = 6
               Left = 306
               Bottom = 114
               Right = 536
            End
            DisplayFlags = 280
            TopColumn = 49
         End
         Begin Table = "HolderToContent (wcadmin)"
            Begin Extent = 
               Top = 6
               Left = 574
               Bottom = 114
               Right = 752
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApplicationData (wcadmin)"
            Begin Extent = 
               Top = 115
               Left = 800
               Bottom = 223
               Right = 970
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "FvItem (wcadmin)"
            Begin Extent = 
               Top = 159
               Left = 434
               Bottom = 267
               Right = 630
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FvMount (wcadmin)"
            Begin Extent = 
               Top = 145
               Left = 18
               Bottom = 253
               Right = 238
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "PDMLinkProduct (wcadmin)"
            Begin Extent = 
               Top = 0
               Left = 861
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PLM_lgEPDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'            Bottom = 108
               Right = 1100
            End
            DisplayFlags = 280
            TopColumn = 12
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 2610
         Width = 5475
         Width = 2355
         Width = 1500
         Width = 1500
         Width = 4380
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2550
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2460
         Alias = 1815
         Table = 3255
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PLM_lgEPDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PLM_lgEPDocument'
GO
/****** Object:  View [dbo].[PLM_lgEPFileDetails]    Script Date: 07/26/2012 11:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PLM_lgEPFileDetails]
AS
SELECT     wcadmin.PDMLinkProduct.namecontainerInfo AS ProjectID, wcadmin.PDMLinkProduct.descriptioncontainerInfo AS ProjectDescription, 
                      wcadmin.ApplicationData.fileName AS DiskFileName, wcadmin.EPMDocumentMaster.name AS Description, 
                      wcadmin.EPMDocumentMaster.documentNumber AS DocumentID, wcadmin.EPMDocumentMaster.createStampA2 AS CreatedOn, 
                      wcadmin.EPMDocumentMaster.modifyStampA2 AS UpdatedOn, SUBSTRING(wcadmin.EPMDocument.nameB2folderingInfo, 0, 8) AS ElementID, 
                      wcadmin.EPMDocument.nameB2folderingInfo AS ElementDescription, wcadmin.EPMDocument.statestate AS Status, 
                      wcadmin.EPMDocument.versionIdA2versionInfo AS Revision, wcadmin.ApplicationData.category, wcadmin.ApplicationData.fileSize, 
                      wcadmin.FvItem.uniqueSequenceNumber AS FileNumber, wcadmin.FvMount.path
FROM         wcadmin.EPMDocumentMaster INNER JOIN
                      wcadmin.EPMDocument ON wcadmin.EPMDocumentMaster.idA2A2 = wcadmin.EPMDocument.idA3masterReference INNER JOIN
                      wcadmin.HolderToContent ON wcadmin.EPMDocument.idA2A2 = wcadmin.HolderToContent.idA3A5 INNER JOIN
                      wcadmin.ApplicationData ON wcadmin.HolderToContent.idA3B5 = wcadmin.ApplicationData.idA2A2 INNER JOIN
                      wcadmin.FvItem ON wcadmin.ApplicationData.idA3A5 = wcadmin.FvItem.idA2A2 INNER JOIN
                      wcadmin.FvMount ON wcadmin.FvItem.idA3A4 = wcadmin.FvMount.idA3A5 INNER JOIN
                      wcadmin.PDMLinkProduct ON wcadmin.EPMDocumentMaster.idA3containerReference = wcadmin.PDMLinkProduct.idA2A2
WHERE     (wcadmin.EPMDocument.statestate = N'RELEASED')
GO
/****** Object:  View [dbo].[PLM_lgWTDocument]    Script Date: 07/26/2012 11:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PLM_lgWTDocument]
AS
SELECT     TOP (100) PERCENT wcadmin.PDMLinkProduct.namecontainerInfo AS ProjectID,  
                      wcadmin.WTDocumentMaster.name AS Description, 
                      wcadmin.WTDocumentMaster.WTDocumentNumber AS DocumentID, 
											SUBSTRING(wcadmin.WTDocument.nameB2folderingInfo,0,8) AS ElementID,
                      wcadmin.WTDocument.nameB2folderingInfo AS ElementDescription, 
                      wcadmin.WTDocument.statestate AS Status, 
											wcadmin.WTDocument.versionIdA2versionInfo AS Revision    
FROM         wcadmin.WTDocumentMaster INNER JOIN
                      wcadmin.WTDocument ON wcadmin.WTDocumentMaster.idA2A2 = wcadmin.WTDocument.idA3masterReference INNER JOIN
                      wcadmin.PDMLinkProduct ON wcadmin.WTDocumentMaster.idA3containerReference = wcadmin.PDMLinkProduct.idA2A2  
WHERE                 (wcadmin.WTDocument.statestate = N'RELEASED') AND (wcadmin.WTDocument.versionIdA2versionInfo = 
											(SELECT     MAX(versionIdA2versionInfo) AS Rev
                            FROM          wcadmin.WTDocument AS Wt1
                            WHERE      (idA3masterReference = wcadmin.WTDocument.idA3masterReference) AND (statestate = N'RELEASED')))
ORDER BY DocumentID

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[22] 4[46] 2[2] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "WTDocumentMaster (wcadmin)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WTDocument (wcadmin)"
            Begin Extent = 
               Top = 6
               Left = 306
               Bottom = 114
               Right = 536
            End
            DisplayFlags = 280
            TopColumn = 50
         End
         Begin Table = "HolderToContent (wcadmin)"
            Begin Extent = 
               Top = 6
               Left = 574
               Bottom = 114
               Right = 794
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ApplicationData (wcadmin)"
            Begin Extent = 
               Top = 145
               Left = 588
               Bottom = 253
               Right = 758
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "FvItem (wcadmin)"
            Begin Extent = 
               Top = 146
               Left = 320
               Bottom = 254
               Right = 516
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "FvMount (wcadmin)"
            Begin Extent = 
               Top = 146
               Left = 36
               Bottom = 254
               Right = 256
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "PDMLinkProduct (wcadmin)"
            Begin Extent = 
               Top = 6
               Left = 832
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PLM_lgWTDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'           Bottom = 114
               Right = 1071
            End
            DisplayFlags = 280
            TopColumn = 12
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 4590
         Width = 2430
         Width = 2670
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2610
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PLM_lgWTDocument'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'PLM_lgWTDocument'
GO
/****** Object:  View [dbo].[PLM_lgWTFileDetails]    Script Date: 07/26/2012 11:55:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create VIEW [dbo].[PLM_lgWTFileDetails]
AS
SELECT     wcadmin.PDMLinkProduct.namecontainerInfo AS ProjectID, wcadmin.PDMLinkProduct.descriptioncontainerInfo AS ProjectDescription, 
                      wcadmin.ApplicationData.fileName AS DiskFileName, wcadmin.WTDocumentMaster.name AS Description, 
                      wcadmin.WTDocumentMaster.WTDocumentNumber AS DocumentID, wcadmin.WTDocument.createStampA2 AS CreatedOn, 
                      wcadmin.WTDocument.modifyStampA2 AS UpdatedOn, SUBSTRING(wcadmin.WTDocument.nameB2folderingInfo,0,8) AS ElementID, 
                      wcadmin.WTDocument.nameB2folderingInfo AS ElementDescription, 
                      wcadmin.WTDocument.statestate AS Status, wcadmin.WTDocument.versionIdA2versionInfo AS Revision, wcadmin.ApplicationData.category, 
                      wcadmin.ApplicationData.fileSize, wcadmin.FvItem.uniqueSequenceNumber AS FileNumber, wcadmin.FvMount.path
FROM         wcadmin.WTDocumentMaster INNER JOIN
                      wcadmin.WTDocument ON wcadmin.WTDocumentMaster.idA2A2 = wcadmin.WTDocument.idA3masterReference INNER JOIN
                      wcadmin.HolderToContent ON wcadmin.WTDocument.idA2A2 = wcadmin.HolderToContent.idA3A5 INNER JOIN
                      wcadmin.ApplicationData ON wcadmin.HolderToContent.idA3B5 = wcadmin.ApplicationData.idA2A2 INNER JOIN
                      wcadmin.FvItem ON wcadmin.ApplicationData.idA3A5 = wcadmin.FvItem.idA2A2 INNER JOIN
                      wcadmin.FvMount ON wcadmin.FvItem.idA3A4 = wcadmin.FvMount.idA3A5 INNER JOIN
                      wcadmin.PDMLinkProduct ON wcadmin.WTDocumentMaster.idA3containerReference = wcadmin.PDMLinkProduct.idA2A2   
WHERE     (wcadmin.WTDocument.statestate = N'RELEASED')
