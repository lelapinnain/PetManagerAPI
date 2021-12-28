using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Keyless]
    public partial class DewormingView
    {
        public int DewormingHistoryId { get; set; }
        public int PetInfoId { get; set; }
        [Column("startDate", TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column("endDate", TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public int DewormingId { get; set; }
        [Column("name")]
        [StringLength(150)]
        [Unicode(false)]
        public string? Name { get; set; }
    }
}
