using MaterialMaster.Domain.Contracts;
using MaterialMaster.Infrastructure.Contexts;
using MaterialMaster.Infrastructure.Repositories;
using MaterialMaster.Services;
using MaterialMaster.Services.Contracts;

namespace MaterialMasterAPI.Dependencies
{
    public static class DependencyResolver
    {
        public static void AddBusinessDependencies(this IServiceCollection collection)
        {
            collection.AddDbContext<MaterialContext>();
            collection.AddScoped<IMaterialMasterService, MaterialMasterService>();
            collection.AddScoped<IMaterialRepository, MaterialRepository>();
            collection.AddScoped<IMaterialCategoryRepository, MaterialCategoryRepository>();
            collection.AddScoped<IReportRepository, ReportRepository>();
            collection.AddScoped(typeof(IGenericRepository<>), typeof(SQLGenericRepository<>));
        }
    }
}
