namespace PetManager.DTOs.InputDTOs
{
    public class AddVaccinationInputDTO
    {
        public int VHistoryID { get; set; }
        public int PetId { get; set; }
        public int VaccinationId { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string? Notes { get; set;}
    }
}
