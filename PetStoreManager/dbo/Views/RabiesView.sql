CREATE VIEW [dbo].[RabiesView]
AS
SELECT p.PetName, p.Dob, p.Microchip, p.PetId
FROM  PetInfo p
WHERE DATEDIFF(MONTH, p.Dob, GETDATE()) >= 4
AND p.VaccinePostponed = 0
OR (p.VaccinePostponed = 1 AND p.VaccinePostponeDate <= GETDATE())

EXCEPT

SELECT p.PetName, p.Dob, p.Microchip, p.PetId
FROM  PetInfo p JOIN
         VaccineHistory v ON p.PetId = v.PetInfoId
WHERE DATEDIFF(MONTH, p.Dob, GETDATE()) >= 4 AND v.VaccineId = 3
