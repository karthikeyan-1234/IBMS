﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public double Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}