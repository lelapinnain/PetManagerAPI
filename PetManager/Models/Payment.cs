using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    public partial class Payment
    {
        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        public int? InvoiceId { get; set; }
        public int? PaymentMethodId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        [InverseProperty("Payments")]
        public virtual Invoice? Invoice { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        [InverseProperty("Payments")]
        public virtual PaymentMethod? PaymentMethod { get; set; }
    }
}
