using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Domain.DTOs
{
    public class InventoryStatusDTO
    {
        public int MaterialId { get; set; }
        public double Quantity { get; set; }
        public DateTime LastEntryDate { get; set; }
    }
}
