using MaterialMaster.Domain.Contracts;
using MaterialMaster.Services.Contracts;
using MaterialMaster.Domain.Models;

namespace MaterialMaster.Services
{
    public class MaterialMasterService : IMaterialMasterService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IReportRepository _reportRepository;

        public MaterialMasterService(IMaterialRepository materialRepository,IReportRepository reportRepository)
        {
            _materialRepository = materialRepository;
            _reportRepository = reportRepository;
        }

        public async Task<Material?> GetMaterialByNameAsync(string name)
        {
            return await _materialRepository.GetMaterialByNameAsync(name);
        }

        //Add new material
        public async Task AddMaterialAsync(Material material)
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
