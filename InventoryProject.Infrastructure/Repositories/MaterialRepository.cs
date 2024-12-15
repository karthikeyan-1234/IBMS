using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryProject.Domain.Models;
using InventoryProject.Infrastructure.Contexts;
using InventoryProject.Domain.Contracts;

using Microsoft.EntityFrameworkCore;
using Common.Infrastructure;

namespace InventoryProject.Infrastructure.Repositories
{
    public class MaterialRepository : SQLGenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(InventoryContext materialContext) : base(materialContext)
        {
        }

        public async Task<Material?> GetMaterialByNameAsync(string name)
        {
            return await _dbContext.Set<Material>().FirstOrDefaultAsync(m => m.Name == name);
        }
    }


}
