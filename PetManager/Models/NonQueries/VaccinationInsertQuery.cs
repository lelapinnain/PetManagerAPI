using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class VaccinationInsertQuery:AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private AddVaccinationInputDTO addVaccinationInputDTO;
        private String response;

        public VaccinationInsertQuery(AddVaccinationInputDTO _addVaccinationInputDTO)
        {
            addVaccinationInputDTO = _addVaccinationInputDTO;
            db = new CoreDbContext();
        }
        public async override Task<string> RunQuery()
        {
            try
            {
                VaccineHistory vaccineHistory = new VaccineHistory()
                {
                    VaccineId = addVaccinationInputDTO.VaccinationId,
                    VaccineDate = addVaccinationInputDTO.VaccinationDate,
                    Notes = addVaccinationInputDTO.Notes,
                    PetInfoId = addVaccinationInputDTO.PetId,
                    IsDone = true


                };
                db.Add(vaccineHistory);
                await db.SaveChangesAsync();
                response = "ok";
            }
            catch (Exception ex)
            {

                response = ex.Message;
            }
            return response;
        }
        public override string GetResult()
        {
            return response;
        }


    }
}

