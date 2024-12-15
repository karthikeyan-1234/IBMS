using InventoryProject.Domain.Models;
using InventoryProject.Infrastructure.Contexts;
using InventoryProject.Domain.Contracts;

using Microsoft.EntityFrameworkCore;
using InventoryProject.Domain.Models.DTOs;
using Common.Infrastructure;

namespace InventoryProject.Infrastructure.Repositories
{
    public class InventoryRepository : SQLGenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(InventoryContext inventoryContext) : base(inventoryContext)
        {
        }

        public async Task<InventoryStatusDTO?> GetMaterialCurrentInventory(int materialId)
        {
            var inventoryQty = await _dbContext.Set<Inventory>().Where(i => i.MaterialId == materialId).SumAsync(i => i.Quantity);
            return new InventoryStatusDTO
            {
                MaterialId = materialId,
                Quantity = inventoryQty,
                LastEntryDate = (await _dbContext.Set<Inventory>().Where(i => i.MaterialId == materialId).LastOrDefaultAsync())!.CreatedDate
            };
        }

        //Get current inventory of all materials by adding all quantities of entries for each material
        public async Task<List<InventoryStatusDTO>> GetAllMaterialsCurrentInventory()
        {
            return await _dbContext.Set<Inventory>()
                       .GroupBy(i => i.MaterialId)
                       .Select(g => new InventoryStatusDTO
                       {
                           MaterialId = g.Key,
                           Quantity = g.Sum(i => i.Quantity),
                           LastEntryDate = g.Last().CreatedDate
                       })
                       .ToListAsync();
        }

        //Add material to material table
        public async Task<Material> AddMaterial(Material material)
        {
            var result = await _dbContext.Set<Material>().AddAsync(material);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        //Add material category to material category table
        public async Task<MaterialCategory> AddMaterialCategory(MaterialCategory materialCategory)
        {
            var result = await _dbContext.Set<MaterialCategory>().AddAsync(materialCategory);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        //Check if material exists in material table
        public async Task<bool> MaterialExists(int materialId)
        {
            return await _dbContext.Set<Material>().AnyAsync(m => m.Id == materialId);
        }


    }


}
