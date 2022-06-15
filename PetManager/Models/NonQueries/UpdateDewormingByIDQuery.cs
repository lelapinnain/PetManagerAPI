using Microsoft.EntityFrameworkCore;
using PetManager.DTOs.InputDTOs;

namespace PetManager.Models.NonQueries
{
    public class UpdateDewormingByIDQuery : AbstractNonQuery<string>
    {
        private readonly CoreDbContext db;
        private int dewormingId;
        private DewormingHistory? dewormingHistory;
        private AddDewormingInputDTO addDewormingInputDTO;
        private string response;

        public UpdateDewormingByIDQuery(AddDewormingInputDTO _addDewormingInputDTO)
        {
            dewormingId = _addDewormingInputDTO.DeWormingHistoryId;
            addDewormingInputDTO = _addDewormingInputDTO;

            db = new CoreDbContext();

            dewormingHistory = null;

        }
        public override string GetResult()
        {
            return response;
        }

        public override async Task<string> RunQuery()
        {
            try
            {
                dewormingHistory = await db.DewormingHistories.Where(v => v.DewormingHistoryId == dewormingId).SingleOrDefaultAsync();
                if (dewormingHistory != null)
                {
                    dewormingHistory.DewormingId = addDewormingInputDTO.DeWormingId;
                    dewormingHistory.DewormingStartDate = addDewormingInputDTO.DewormingDate;
                    dewormingHistory.DewormingEndDate = addDewormingInputDTO.DewormingDate.AddDays(addDewormingInputDTO.NumberOfDays);

                   

                    db.Update(dewormingHistory);
                   await db.SaveChangesAsync();

                    response = "ok";


                }
                else
                {
                    response = "Deworming Not Found";
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
