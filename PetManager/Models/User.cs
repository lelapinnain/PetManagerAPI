using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Email { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
    }
}
