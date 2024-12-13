namespace Material.Services.Contracts
{
    public interface IMaterialService
    {
        Task AddMaterialAsync(Domain.Models.Material material);
        Task<Domain.Models.Material?> GetMaterialByNameAsync(string name);
        IEnumerable<dynamic> GetAllMaterialInfo();
    }
}