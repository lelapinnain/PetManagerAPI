using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    public partial class Transaction
    {
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
        public int? InvoiceId { get; set; }
        public int? PaymentMethodId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("Transactions")]
        public virtual Invoice? Invoice { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        [InverseProperty("Transactions")]
        public virtual PaymentMethod? PaymentMethod { get; set; }
    }
}
