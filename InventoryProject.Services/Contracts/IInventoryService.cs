using InventoryProject.Domain.DTOs;
using InventoryProject.Domain.Models;
using InventoryProject.Services.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryProject.Services.Contracts
{
    public interface IInventoryService
    {
        Task<Inventory> AddInventoryItem(NewInventory item);
        Task DeleteInventoryItem(int id);
        Task<List<InventoryStatusDTO>> GetAllMaterialsCurrentInventory();
        Task<InventoryStatusDTO?> GetMaterialCurrentInventory(int materialId);
        Task<Inventory> UpdateInventoryItem(Inventory item);

        Material AddMaterialAsync(Material material);
        MaterialCategory AddMaterialCategoryAsync(MaterialCategory materialCategory);
    }
}
