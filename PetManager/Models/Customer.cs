using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        public int CustomerId { get; set; }
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

        [InverseProperty(nameof(Invoice.Customer))]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
