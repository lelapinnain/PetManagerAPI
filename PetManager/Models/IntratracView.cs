using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Keyless]
    public partial class IntratracView
    {
        public string PetName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime Dob { get; set; }
        public string Microchip { get; set; } = null!;
        public int PetId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastDose { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Expr1 { get; set; }
        public int? Expr2 { get; set; }
        public int? DoseCount { get; set; }
    }
}
