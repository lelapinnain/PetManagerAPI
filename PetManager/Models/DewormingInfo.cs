using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Table("DewormingInfo")]
    public partial class DewormingInfo
    {
        public DewormingInfo()
        {
            DewormingHistories = new HashSet<DewormingHistory>();
        }

        [Key]
        public int DewormingId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? DewormingTitle { get; set; }

        [InverseProperty(nameof(DewormingHistory.Deworming))]
        public virtual ICollection<DewormingHistory> DewormingHistories { get; set; }
    }
}
