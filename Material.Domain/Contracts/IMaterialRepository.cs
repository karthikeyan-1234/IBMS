﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Material.Domain.Contracts
{
    public interface IMaterialRepository: IGenericRepository<Models.Material>
    {
        Task<Models.Material?> GetMaterialByNameAsync(string name);
    }
}
