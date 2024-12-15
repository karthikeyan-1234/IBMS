
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
    public class PurchaseRepository : SQLGenericRepository<Domain.Models.Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(PurchaseContext purchaseContext) : base(purchaseContext)
        {
        }
        public IQueryable<Domain.Models.Purchase> GetAllPurchaseDetails()
        {
            return _dbContext.Set<Domain.Models.Purchase>().AsQueryable();
        }
    }
}
