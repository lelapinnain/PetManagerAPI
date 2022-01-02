using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Keyless]
    public partial class DappvView
    {
        public string PetName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime Dob { get; set; }
        public string Microchip { get; set; } = null!;
        public int PetId { get; set; }
    }
}
