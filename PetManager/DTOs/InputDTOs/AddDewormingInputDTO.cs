namespace PetManager.DTOs.InputDTOs
{
    public class AddDewormingInputDTO
    {
        public int DeWormingId { get; set; }
        public int DeWormingHistoryId { get; set; }
        public int PetId { get; set; }
        public DateTime DewormingDate { get; set; }
        public int NumberOfDays { get; set; }
    }
}
