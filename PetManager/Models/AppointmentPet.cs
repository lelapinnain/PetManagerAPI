using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    public partial class AppointmentPet
    {
        [Key]
        [Column("AppointmentPetID")]
        public int AppointmentPetId { get; set; }
        public int AppointmentHistoryId { get; set; }
        public int PetId { get; set; }

        [ForeignKey(nameof(AppointmentHistoryId))]
        [InverseProperty("AppointmentPets")]
        public virtual AppointmentHistory AppointmentHistory { get; set; } = null!;
        [ForeignKey(nameof(PetId))]
        [InverseProperty(nameof(PetInfo.AppointmentPets))]
        public virtual PetInfo Pet { get; set; } = null!;
    }
}
