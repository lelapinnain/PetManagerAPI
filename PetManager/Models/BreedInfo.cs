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
        public BreedInfo()
        {
            PetInfos = new HashSet<PetInfo>();
        }

        [Key]
        public int BreedId { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? BreedName { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? BreedSize { get; set; }

        [InverseProperty(nameof(PetInfo.BreedNavigation))]
        public virtual ICollection<PetInfo> PetInfos { get; set; }
    }
}
