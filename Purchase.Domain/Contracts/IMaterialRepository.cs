
using Common.Domain;

using Purchase.Domain.Contracts;
using Purchase.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase.Domain.Contracts
{
    public interface IMaterialRepository: IGenericRepository<Material>
    {
        Task<Material?> GetMaterialByNameAsync(string name);
    }
}
