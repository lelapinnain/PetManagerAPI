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
            vaccinationId = _addVaccinationInputDTO.VInfoID;
            addVaccinationInputDTO = _addVaccinationInputDTO;

            db = new CoreDbContext();

            vaccineHistory = null;

        }
        public override string GetResult()
        {
            return response;

        }
        public override void RunQuery()
        {
            vaccineHistory = db.VaccineHistories.Where(v => v.VaccineHistoryId == vaccinationId).SingleOrDefault();
            if (vaccineHistory != null)
            {
                vaccineHistory.VaccineId = addVaccinationInputDTO.VaccinationId;
                vaccineHistory.VaccineDate = addVaccinationInputDTO.VaccinationDate;
                vaccineHistory.Notes = addVaccinationInputDTO.Notes;

                db.Update(vaccineHistory);
                db.SaveChanges();

                response = "ok";


            }
            else
            {
                //   response = "PetInfo Not Found";
            }

        }
    }
}
