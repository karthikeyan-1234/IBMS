using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialMaster.Domain.Models;
using MaterialMaster.Infrastructure.Contexts;
using MaterialMaster.Domain.Contracts;

using Microsoft.EntityFrameworkCore;
using Common.Infrastructure;

namespace MaterialMaster.Infrastructure.Repositories
{
    public class MaterialRepository : SQLGenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(MaterialContext materialContext) : base(materialContext)
        {
        }

        public async Task<Material?> GetMaterialByNameAsync(string name)
        {
            return await _dbContext.Set<Material>().FirstOrDefaultAsync(m => m.Name == name);
        }
    }


}
