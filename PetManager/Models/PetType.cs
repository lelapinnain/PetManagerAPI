using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    public partial class PetType
    {
        [Key]
        public int PetTypeId { get; set; }
        [StringLength(250)]
        [Unicode(false)]
        public string? PetTypeName { get; set; }
    }
}
