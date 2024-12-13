using MaterialMaster.Domain.Contracts;
using MaterialMaster.Domain.Models;
using MaterialMaster.Infrastructure.Contexts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMaster.Infrastructure.Repositories
{
    public class MaterialCategoryRepository : SQLGenericRepository<MaterialCategory>, IMaterialCategoryRepository
    {
        public MaterialCategoryRepository(MaterialContext context) : base(context)
        {
        }

        public async Task<MaterialCategory?> GetMaterialCategoryByNameAsync(string name)
        {
            return await _dbContext.Set<MaterialCategory>().FirstOrDefaultAsync(m => m.Name == name);
        }
    }
}
