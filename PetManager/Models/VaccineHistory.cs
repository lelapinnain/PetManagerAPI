using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Table("VaccineHistory")]
    public partial class VaccineHistory
    {
        [Key]
        public int VaccineHistoryId { get; set; }
        public int PetInfoId { get; set; }
        public int VaccineId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? VaccineDate { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Notes { get; set; }
        public bool? IsPostponed { get; set; }
        [Column(TypeName = "date")]
        public DateTime? PostponeDate { get; set; }
        public bool? IsDone { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ActualDate { get; set; }
    }
}
