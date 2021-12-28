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
        [Key]
        public int DewormingId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? DewormingTitle { get; set; }
    }
}
