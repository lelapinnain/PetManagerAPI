using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Keyless]
    public partial class VaccinationView
    {
        [Column("name")]
        [StringLength(150)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime? Date { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Notes { get; set; }
        public int PetInfoId { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Column("vId")]
        public int VId { get; set; }
    }
}
