using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Services.DTOs
{
    public class NewInventory
    {
        public int MaterialId { get; set; }
        public double Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
