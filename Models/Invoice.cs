using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        // Use null-forgiving since EF will set it / seed will populate
        public string CustomerName { get; set; } = null!;

        public List<InvoiceItem> Items { get; set; } = new();
    }
}
