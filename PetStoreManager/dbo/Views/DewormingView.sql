CREATE VIEW [dbo].[DewormingView]
AS
SELECT dbo.DewormingHistory.DewormingHistoryId, dbo.DewormingHistory.PetInfoId, dbo.DewormingHistory.DewormingStartDate AS startDate, dbo.DewormingHistory.DewormingEndDate AS endDate, dbo.DewormingInfo.DewormingId, dbo.DewormingInfo.DewormingTitle AS name
FROM  dbo.DewormingInfo INNER JOIN
         dbo.DewormingHistory ON dbo.DewormingInfo.DewormingId = dbo.DewormingHistory.DewormingId
