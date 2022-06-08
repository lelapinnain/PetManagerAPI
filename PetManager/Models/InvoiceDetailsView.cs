using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Keyless]
    public partial class InvoiceDetailsView
    {
        [StringLength(150)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        [StringLength(150)]
        public string? Phone { get; set; }
        public string PetName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime Dob { get; set; }
        public string Microchip { get; set; } = null!;
        public string Images { get; set; } = null!;
        [StringLength(50)]
        public string Color { get; set; } = null!;
        [StringLength(50)]
        public string Gender { get; set; } = null!;
        [StringLength(50)]
        public string? Breed { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ActualPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DiscountAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceAfterDiscount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RegistrationFees { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Tax { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PriceAfterTax { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DepositAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RemainingBalance { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfPurchase { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PickupDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DepositDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpectedPickupDate { get; set; }
        public int InvoiceId { get; set; }
        public int PetinfoId { get; set; }
        public int CustomerId { get; set; }
    }
}
