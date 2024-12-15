using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase.Services.DTOs
{
    public class PurchaseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public int MaterialId { get; set; }
    }
}
