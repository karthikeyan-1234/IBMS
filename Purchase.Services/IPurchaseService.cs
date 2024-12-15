using Purchase.Domain.Models;
using Purchase.Services.DTOs;

namespace Purchase.Services
{
    public interface IPurchaseService
    {
        Task AddPurchaseAsync(PurchaseRequestDTO purchase);
        Task DeletePurchaseAsync(int id);
        IEnumerable<PurchaseDTO> GetAllPurchases();
        Task<PurchaseDTO> GetPurchaseById(int id);
        Task UpdatePurchaseAsync(PurchaseDTO purchase);

        Task<Material> AddMaterialAsync(Material material)
        Task<MaterialCategory> AddMaterialCategoryAsync(MaterialCategory materialCategory);
    }
}