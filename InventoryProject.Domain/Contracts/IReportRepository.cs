using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Domain.Contracts
{
    public interface IReportRepository
    {
        IQueryable<dynamic> GetAllMaterialDetails();
    }
}
