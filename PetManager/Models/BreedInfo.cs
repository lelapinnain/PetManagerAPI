using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Table("BreedInfo")]
    public partial class BreedInfo
    {
        [Key]
        public int BreedId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? BreedName { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? BreedSize { get; set; }
    }
}
