using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Table("AppointmentHistory")]
    public partial class AppointmentHistory
    {
        public AppointmentHistory()
        {
            AppointmentPets = new HashSet<AppointmentPet>();
        }

        [Key]
        public int AppointmentId { get; set; }
        public string CustomerName { get; set; } = null!;
        [StringLength(50)]
        public string CustomerPhoneNumber { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? AppointmentDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AppointmentStartTime { get; set; }
        public int? AppointmentDuration { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? Notes { get; set; }

        [ForeignKey(nameof(PaymentMethodId))]
        [InverseProperty("AppointmentHistories")]
        public virtual PaymentMethod? PaymentMethod { get; set; }
        [InverseProperty(nameof(AppointmentPet.AppointmentHistory))]
        public virtual ICollection<AppointmentPet> AppointmentPets { get; set; }
    }
}
