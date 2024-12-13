using MaterialMaster.Domain.Contracts;
using MaterialMaster.Infrastructure.Contexts;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialMaster.Infrastructure.Repositories
{
    public class ReportRepository: IReportRepository
    {
        MaterialContext dbContext;

        public ReportRepository(MaterialContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get material details with material category names

        public IQueryable<dynamic> GetAllMaterialDetails()
        {
            return from material in dbContext.Materials
                          join materialCategory in dbContext.MaterialCategories
                          on material.MaterialCategoryId equals materialCategory.Id
                          select new
                          {
                              MaterialName = material.Name,
                              CategoryName = materialCategory.Name
                          };
        }
    }
}
