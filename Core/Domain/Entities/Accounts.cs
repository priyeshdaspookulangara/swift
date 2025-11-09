using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARCAERP.Domain.Entities
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }

        public DateTime ReceiptDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(150)]
        public string? ReceivedFrom { get; set; } // Can be linked to Customer later

        [StringLength(250)]
        public string? Narration { get; set; }

        // Crucial Constraint: Is the receipt against a specific bill/invoice?
        [Required]
        public bool IsAgainstBill { get; set; }

        // Optional: Link to a specific Sales Invoice if IsAgainstBill is true
        public int? SalesInvoiceId { get; set; }
    }

    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(150)]
        public string? PaidTo { get; set; } // Can be linked to Supplier/Employee later

        [StringLength(250)]
        public string? Narration { get; set; }

        // Crucial Constraint: Is the payment against a specific bill/invoice?
        [Required]
        public bool IsAgainstBill { get; set; }

        // Optional: Link to a specific Purchase Invoice if IsAgainstBill is true
        public int? PurchaseInvoiceId { get; set; }
    }
}
