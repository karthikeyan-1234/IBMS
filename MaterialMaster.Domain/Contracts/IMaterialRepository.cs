using Common.Domain;

using MaterialMaster.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMaster.Domain.Contracts
{
    public interface IMaterialRepository: IGenericRepository<Material>
    {
        Task<Material?> GetMaterialByNameAsync(string name);
    }
}
