namespace PetManager.DTOs.InputDTOs
{
    public class AppointmentInputDTO
    {
        public int ApptId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? AppointmentDate { get; set; }
        public string? AppointmentTime { get; set; }
        public int? AppointmentDuration { get; set; }
        public string? Notes { get; set; }
    }
}
