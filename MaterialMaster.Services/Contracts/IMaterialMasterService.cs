using MaterialMaster.Domain.Models;
using MaterialMaster.Services.DTOs;

namespace MaterialMaster.Services.Contracts
{
    public interface IMaterialMasterService
    {
        Task AddMaterialAsync(NewMaterialDTO material);
        Task AddMaterialCategoryAsync(MaterialCategory materialCategory);
        Task DeleteMaterialAsync(int id);
        Task DeleteMaterialCategoryAsync(int id);
        IEnumerable<MaterialCategory?> GetAllMaterialCategories();
        IEnumerable<dynamic> GetAllMaterialInfo();
        Task<Material?> GetMaterialByNameAsync(string name);
        Task<MaterialCategory?> GetMaterialCategoryByNameAsync(string name);
        Task UpdateMaterialAsync(Material material);
        Task UpdateMaterialCategoryAsync(MaterialCategory materialCategory);
    }
}