using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;   // <-- add this

namespace WebApplication1.Models
{
    public class InvoiceItem
    {
        [Key]
        public int ItemID { get; set; }

        public int InvoiceID { get; set; }

        [ForeignKey("InvoiceID")]
        [JsonIgnore]           // <-- prevent serializing back-reference
        public Invoice? Invoice { get; set; }

        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
