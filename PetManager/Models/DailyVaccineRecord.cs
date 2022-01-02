namespace PetManager.Models
{
    public class DailyVaccineRecord
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public DateTime Dob { get; set; }
        public string Microchip { get; set; }
    }
}
