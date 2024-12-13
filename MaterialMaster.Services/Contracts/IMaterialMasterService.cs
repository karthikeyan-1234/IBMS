
using MaterialMaster.Domain.Models;

namespace MaterialMaster.Services.Contracts
{
    public interface IMaterialMasterService
    {
        Task AddMaterialAsync(Material material);
        Task<Material?> GetMaterialByNameAsync(string name);
        IEnumerable<dynamic> GetAllMaterialInfo();
    }
}