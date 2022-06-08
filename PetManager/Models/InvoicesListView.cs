using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PetManager.Models
{
    [Keyless]
    public partial class InvoicesListView
    {
        public int InvoiceId { get; set; }
        public string PetName { get; set; } = null!;
        [StringLength(150)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? RemainingBalance { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DepositAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfPurchase { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PriceAfterTax { get; set; }
    }
}
