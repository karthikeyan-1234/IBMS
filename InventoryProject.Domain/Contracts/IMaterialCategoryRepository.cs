﻿using Common.Domain;

using InventoryProject.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Domain.Contracts
{
    public interface IMaterialCategoryRepository: IGenericRepository<MaterialCategory>
    {
        Task<MaterialCategory?> GetMaterialCategoryByNameAsync(string name);
    }
}
