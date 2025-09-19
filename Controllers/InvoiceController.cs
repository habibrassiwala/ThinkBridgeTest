using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            // Mock data for now (later replace with DB)
            var items = new List<Item>
            {
                new Item { Name = "Widget A", price = 19.99 },
                new Item { Name = "Widget B", price = 29.99 }
            };

            return Ok(new { items });
        }

        public class Item
        {
            public string Name { get; set; }
            public double price { get; set; }
        }
    }
}
