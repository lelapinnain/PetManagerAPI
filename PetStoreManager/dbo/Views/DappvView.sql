CREATE VIEW dbo.DappvView
AS
SELECT p.PetName, p.Dob, p.Microchip, p.PetId
FROM   (SELECT PetInfoId, MAX(VaccineDate) AS LastDose
             FROM    dbo.VaccineHistory
             WHERE  (VaccineId = 2)
             GROUP BY PetInfoId) AS vDate INNER JOIN
                 (SELECT PetInfoId, COUNT(PetInfoId) AS DoseCount
                 FROM    dbo.VaccineHistory AS VaccineHistory_1
                 WHERE (VaccineId = 2)
                 GROUP BY PetInfoId) AS vCount ON vDate.PetInfoId = vCount.PetInfoId INNER JOIN
             dbo.PetInfo AS p ON vCount.PetInfoId = p.PetId
WHERE (DATEDIFF(MONTH, vDate.LastDose, GETDATE()) >= 1) AND (vCount.DoseCount < 4) AND (p.VaccinePostponed = 0) OR
             (DATEDIFF(MONTH, vDate.LastDose, GETDATE()) >= 1) AND (vCount.DoseCount < 4) AND (p.VaccinePostponed = 1) AND (p.VaccinePostponeDate <= GETDATE())

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "vDate"
            Begin Extent = 
               Top = 46
               Left = 1579
               Bottom = 189
               Right = 1801
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "vCount"
            Begin Extent = 
               Top = 207
               Left = 1137
               Bottom = 350
               Right = 1359
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 50
               Left = 718
               Bottom = 247
               Right = 994
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'DappvView';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'DappvView';

