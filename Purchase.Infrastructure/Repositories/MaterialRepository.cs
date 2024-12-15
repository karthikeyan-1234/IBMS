using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialMaster.Domain.Models;

using Microsoft.EntityFrameworkCore;

using Purchase.Domain.Contracts;
using Purchase.Infrastructure.Contexts;

namespace Purchase.Infrastructure.Repositories
{
    public class MaterialRepository : SQLGenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(PurchaseContext materialContext) : base(materialContext)
        {
        }

        public async Task<Material?> GetMaterialByNameAsync(string name)
        {
            return await _dbContext.Set<Material>().FirstOrDefaultAsync(m => m.Name == name);
        }
    }


}
