using InventoryProject.Domain.Contracts;
using InventoryProject.Domain.DTOs;
using InventoryProject.Domain.Models;
using InventoryProject.Services.Contracts;
using InventoryProject.Services.DTOs;


namespace InventoryProject.Services
{
    public class InventoryService : IInventoryService
    {
        IInventoryRepository InventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            InventoryRepository = inventoryRepository;
        }

        public async Task<Inventory> AddInventoryItem(NewInventory item)
        {
            var inventory = new Domain.Models.Inventory
            {
                MaterialId = item.MaterialId,
                Quantity = item.Quantity,
                CreatedDate = item.CreatedDate
            };

            return await InventoryRepository.AddAsync(inventory);
        }

        public async Task<InventoryStatusDTO?> GetMaterialCurrentInventory(int materialId)
        {
            var result = await InventoryRepository.GetMaterialCurrentInventory(materialId);
            InventoryStatusDTO? inventoryStatusDTO = new InventoryStatusDTO
            {
                MaterialId = result!.MaterialId,
                Quantity = result.Quantity,
                LastEntryDate = result.LastEntryDate
            };
            return inventoryStatusDTO;
        }

        public async Task<List<InventoryStatusDTO>> GetAllMaterialsCurrentInventory()
        {
            var result = await InventoryRepository.GetAllMaterialsCurrentInventory();
            List<InventoryStatusDTO> inventoryStatusDTOs = new List<InventoryStatusDTO>();
            foreach (var item in result)
            {
                inventoryStatusDTOs.Add(new InventoryStatusDTO
                {
                    MaterialId = item.MaterialId,
                    Quantity = item.Quantity,
                    LastEntryDate = item.LastEntryDate
                });
            }
            return inventoryStatusDTOs;
        }

        public async Task<Inventory> UpdateInventoryItem(Inventory item)
        {
            return await InventoryRepository.UpdateAsync(item);
        }

        public async Task DeleteInventoryItem(int id)
        {
            //Find inventory entry by id
            var inventory = await InventoryRepository.GetByIdAsync(id);
            await InventoryRepository.DeleteAsync(inventory!);
        }

        public Material AddMaterialAsync(Material material)
        {
            return InventoryRepository.AddMaterial(material).Result;
        }

        public MaterialCategory AddMaterialCategoryAsync(MaterialCategory materialCategory)
        {
            return InventoryRepository.AddMaterialCategory(materialCategory).Result;
        }

    }
}
