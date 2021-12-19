using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Table("PetInfo")]
    public partial class PetInfo
    {
        public PetInfo()
        {
            VaccineHistories = new HashSet<VaccineHistory>();
        }

        [Key]
        public int PetId { get; set; }
        public string PetName { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BuyPrice { get; set; }
        public int BreedId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Dob { get; set; }
        public string Microchip { get; set; } = null!;
        public string Images { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime ReceiveDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TransportationPrice { get; set; }
        [StringLength(50)]
        public string Color { get; set; } = null!;
        [StringLength(50)]
        public string Gender { get; set; } = null!;
        [Column("isSold")]
        public bool IsSold { get; set; }
        public int? PetTypeId { get; set; }
        public int? BreederId { get; set; }

        [ForeignKey(nameof(BreedId))]
        [InverseProperty(nameof(BreedInfo.PetInfos))]
        public virtual BreedInfo Breed { get; set; } = null!;
        [InverseProperty(nameof(VaccineHistory.PetInfo))]
        public virtual ICollection<VaccineHistory> VaccineHistories { get; set; }
    }
}
