﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Domain.DTOs
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MaterialCategoryId { get; set; }
    }
}
