using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Material.Domain.Models;
using Material.Infrastructure.Contexts;
using Material.Domain.Contracts;

using Microsoft.EntityFrameworkCore;

namespace Material.Infrastructure.Repositories
{
    public class MaterialRepository : SQLGenericRepository<Domain.Models.Material>, IMaterialRepository
    {
        public MaterialRepository(MaterialContext materialContext) : base(materialContext)
        {
        }

        public async Task<Domain.Models.Material?> GetMaterialByNameAsync(string name)
        {
            return await _dbContext.Set<Domain.Models.Material>().FirstOrDefaultAsync(m => m.Name == name);
        }
    }


}
