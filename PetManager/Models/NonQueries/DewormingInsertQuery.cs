using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class DewormingInsertQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private AddDewormingInputDTO addDewormingInputDTO;
        private String response;

        public DewormingInsertQuery(AddDewormingInputDTO _addDewormingInputDTO)
        {
            addDewormingInputDTO = _addDewormingInputDTO;
            db = new CoreDbContext();
        }
        public override string GetResult()
        {
            return response;
        }

        public  async override Task<string> RunQuery()
        {
            try
            {
                DewormingHistory dewormingHistory = new DewormingHistory()
                {
                    DewormingId = addDewormingInputDTO.DeWormingId,
                    DewormingStartDate = addDewormingInputDTO.DewormingDate,
                    DewormingEndDate = addDewormingInputDTO.DewormingDate.AddDays(addDewormingInputDTO.NumberOfDays),
                    PetInfoId = addDewormingInputDTO.PetId,
                   


                };
                db.Add(dewormingHistory);
                await db.SaveChangesAsync();
                response = "ok";
            }
            catch (Exception ex)
            {

                response = ex.Message;
            }
            return (response);
        }
    }
}
