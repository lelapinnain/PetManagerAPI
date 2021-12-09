using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Table("VaccineInfo")]
    public partial class VaccineInfo
    {
        [Key]
        public int VaccineId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? VaccineTitle { get; set; }
    }
}
