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
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int PaymentMethodId { get; set; }
        [Unicode(false)]
        public string? Name { get; set; }

        [InverseProperty(nameof(AppointmentHistory.PaymentMethod))]
        public virtual ICollection<AppointmentHistory> AppointmentHistories { get; set; }
        [InverseProperty(nameof(Payment.PaymentMethod))]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
