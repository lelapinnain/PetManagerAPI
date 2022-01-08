namespace PetManager.Models
{
    public class AppointmentRecord
    {
        public int AppointmentId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? CustomerPhoneNumber { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? AppointmentStartTime { get; set; }
        public int? AppointmentDuration { get; set; }
        public string? Notes { get; set; }
    }
}
