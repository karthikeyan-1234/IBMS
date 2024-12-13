using Material.Domain.Contracts;
using Material.Services.Contracts;

namespace Material.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IReportRepository _reportRepository;

        public MaterialService(IMaterialRepository materialRepository,IReportRepository reportRepository)
        {
            _materialRepository = materialRepository;
            _reportRepository = reportRepository;
        }

        public async Task<Material.Domain.Models.Material?> GetMaterialByNameAsync(string name)
        {
            return await _materialRepository.GetMaterialByNameAsync(name);
        }

        //Add new material
        public async Task AddMaterialAsync(Material.Domain.Models.Material material)
        {
            await _materialRepository.AddAsync(material);
        }

        //Get All material details
        public IEnumerable<dynamic> GetAllMaterialInfo()
        {
            return _reportRepository.GetAllMaterialDetails().ToList();
        }

    }
}
