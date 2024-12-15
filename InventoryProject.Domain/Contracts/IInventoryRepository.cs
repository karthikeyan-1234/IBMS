using Common.Domain;

using InventoryProject.Domain.Models;
using InventoryProject.Domain.Models.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Domain.Contracts
{
    public interface IInventoryRepository : IGenericRepository<Inventory>
    {
        Task<InventoryStatusDTO?> GetMaterialCurrentInventory(int materialId);
        Task<List<InventoryStatusDTO>> GetAllMaterialsCurrentInventory();
        Task<Material> AddMaterial(Material material);
        Task<MaterialCategory> AddMaterialCategory(MaterialCategory materialCategory);
        Task<bool> MaterialExists(int materialId);
    }
}
