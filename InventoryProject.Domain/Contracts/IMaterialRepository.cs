using Common.Domain;

using InventoryProject.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Domain.Contracts
{
    public interface IMaterialRepository: IGenericRepository<Material>
    {
        Task<Material?> GetMaterialByNameAsync(string name);
    }
}
