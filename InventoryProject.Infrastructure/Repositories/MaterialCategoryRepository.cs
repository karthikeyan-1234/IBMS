using Common.Infrastructure;

using InventoryProject.Domain.Contracts;
using InventoryProject.Domain.Models;
using InventoryProject.Infrastructure.Contexts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Infrastructure.Repositories
{
    public class MaterialCategoryRepository : SQLGenericRepository<MaterialCategory>, IMaterialCategoryRepository
    {
        public MaterialCategoryRepository(InventoryContext context) : base(context)
        {
        }

        public async Task<MaterialCategory?> GetMaterialCategoryByNameAsync(string name)
        {
            return await _dbContext.Set<MaterialCategory>().FirstOrDefaultAsync(m => m.Name == name);
        }
    }
}
