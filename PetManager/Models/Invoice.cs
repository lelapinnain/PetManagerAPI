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
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public int InvoiceId { get; set; }
        public int PetinfoId { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DiscountAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfPurchase { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReleaseDate { get; set; }
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
        [InverseProperty(nameof(Transaction.Invoice))]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
