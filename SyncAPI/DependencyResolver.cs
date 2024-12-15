using Common.Domain;
using Common.Infrastructure;

using InventoryProject.Domain.Contracts;
using InventoryProject.Infrastructure.Contexts;
using InventoryProject.Infrastructure.Repositories;
using InventoryProject.Services;
using InventoryProject.Services.Contracts;

namespace SyncAPI.Dependencies
{
    public static class DependencyResolver
    {
        public static void AddBusinessDependencies(this IServiceCollection collection)
        {
            collection.AddDbContext<InventoryContext>();
            collection.AddScoped<IInventoryService, InventoryService>();
            collection.AddScoped<IInventoryRepository, InventoryRepository>();
            collection.AddScoped<IMaterialCategoryRepository, MaterialCategoryRepository>();
            collection.AddScoped<IMaterialRepository, MaterialRepository>();
            collection.AddScoped(typeof(IGenericRepository<>), typeof(SQLGenericRepository<>));

            //start background service
            collection.AddHostedService<InventoryBackgroundService>();
        }
    }
}
