using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Table("PaymentMethod")]
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            AppointmentHistories = new HashSet<AppointmentHistory>();
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        public int PaymentMethodId { get; set; }
        [Unicode(false)]
        public string? Name { get; set; }

        [InverseProperty(nameof(AppointmentHistory.PaymentMethod))]
        public virtual ICollection<AppointmentHistory> AppointmentHistories { get; set; }
        [InverseProperty(nameof(Transaction.PaymentMethod))]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
