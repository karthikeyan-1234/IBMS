using Common.Infrastructure;


using Microsoft.EntityFrameworkCore;

using Purchase.Domain.Contracts;
using Purchase.Domain.Models;
using Purchase.Infrastructure.Contexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase.Infrastructure.Repositories
{
    public class MaterialCategoryRepository : SQLGenericRepository<MaterialCategory>, IMaterialCategoryRepository
    {
        public MaterialCategoryRepository(PurchaseContext context) : base(context)
        {
        }

        public async Task<MaterialCategory?> GetMaterialCategoryByNameAsync(string name)
        {
            return await _dbContext.Set<MaterialCategory>().FirstOrDefaultAsync(m => m.Name == name);
        }
    }
}
