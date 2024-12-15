using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchase.Domain.Contracts
{
    public interface IPurchaseRepository : IGenericRepository<Domain.Models.Purchase>
    {
        IQueryable<Domain.Models.Purchase> GetAllPurchaseDetails();
    }
}
