using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Keyless]
    [Table("DewormingHistory")]
    public partial class DewormingHistory
    {
        public int DewormingHistoryId { get; set; }
        public int PetInfoId { get; set; }
        public int DewormingId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DewormingStartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DewormingEndDate { get; set; }

        [ForeignKey(nameof(DewormingId))]
        public virtual DewormingInfo Deworming { get; set; } = null!;
        [ForeignKey(nameof(PetInfoId))]
        public virtual PetInfo PetInfo { get; set; } = null!;
    }
}
