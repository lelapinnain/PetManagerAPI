CREATE VIEW [dbo].[VaccinationView]
AS
SELECT dbo.VaccineInfo.VaccineTitle AS name, dbo.VaccineHistory.VaccineDate AS date, dbo.VaccineHistory.Notes, dbo.VaccineHistory.PetInfoId, dbo.VaccineHistory.VaccineHistoryId AS id, dbo.VaccineInfo.VaccineId AS vId
FROM  dbo.VaccineHistory INNER JOIN
         dbo.VaccineInfo ON dbo.VaccineHistory.VaccineId = dbo.VaccineInfo.VaccineId
