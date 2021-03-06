using Microsoft.EntityFrameworkCore;
using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class UpdateVaccinationByIDQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private int vaccinationId;
        private VaccineHistory? vaccineHistory;
        private AddVaccinationInputDTO addVaccinationInputDTO;
        private string response;

        public UpdateVaccinationByIDQuery(AddVaccinationInputDTO _addVaccinationInputDTO)
        {
            vaccinationId = _addVaccinationInputDTO.VHistoryID;
            addVaccinationInputDTO = _addVaccinationInputDTO;

            db = new CoreDbContext();

            vaccineHistory = null;

        }
        public override string GetResult()
        {
            return response;

        }
        public override async Task<string> RunQuery()
        {
            try
            {
                vaccineHistory =await db.VaccineHistories.Where(v => v.VaccineHistoryId == vaccinationId).SingleOrDefaultAsync();
                if (vaccineHistory != null)
                {
                    vaccineHistory.VaccineId = addVaccinationInputDTO.VaccinationId;
                    vaccineHistory.VaccineDate = addVaccinationInputDTO.VaccinationDate;
                    vaccineHistory.Notes = addVaccinationInputDTO.Notes;

                    db.Update(vaccineHistory);
                    await db.SaveChangesAsync();

                    response = "ok";


                }
                else
                {
                       response = "Vaccination Not Found";
                }
            }
            catch (Exception ex)
            {

               response = ex.Message;
            }
          return response;

        }
    }
}
