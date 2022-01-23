using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int InvoiceId { get; set; }
        public int PetinfoId { get; set; }
        public int CustomerId { get; set; }
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

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Invoices")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey(nameof(PetinfoId))]
        [InverseProperty(nameof(PetInfo.Invoices))]
        public virtual PetInfo Petinfo { get; set; } = null!;
        [InverseProperty(nameof(Payment.Invoice))]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
