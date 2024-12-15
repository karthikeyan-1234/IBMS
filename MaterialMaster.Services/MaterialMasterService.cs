using MaterialMaster.Domain.Contracts;
using MaterialMaster.Services.Contracts;
using MaterialMaster.Domain.Models;
using System.Text.Json;
using MaterialMaster.Services.DTOs;
using MaterialMaster.Domain;
using Common.Domain;

namespace MaterialMaster.Services
{
    public class MaterialMasterService : IMaterialMasterService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialCategoryRepository _materialCategoryRepository;
        private readonly IReportRepository _reportRepository;
        private readonly INotificationService _notificationService;

        public MaterialMasterService(IMaterialRepository materialRepository, IReportRepository reportRepository, IMaterialCategoryRepository materialCategoryRepository, INotificationService notificationService)
        {
            _materialRepository = materialRepository;
            _reportRepository = reportRepository;
            _materialCategoryRepository = materialCategoryRepository;
            _notificationService = notificationService;
        }

        public async Task<Material?> GetMaterialByNameAsync(string name)
        {
            return await _materialRepository.GetMaterialByNameAsync(name);
        }

        //Add new material
        public async Task AddMaterialAsync(NewMaterialDTO material)
        {
            Material newMaterial = new Material
            {
                Name = material.Name,
                MaterialCategoryId = material.MaterialCategoryId,
            };

            var createdMaterial = await _materialRepository.AddAsync(newMaterial);
            await _notificationService.SendNotification(material.Name, JsonSerializer.Serialize(createdMaterial),"new-material");
        }

        //Get All material details
        public IEnumerable<dynamic> GetAllMaterialInfo()
        {
            return _reportRepository.GetAllMaterialDetails().ToList();
        }

        //Update material
        public async Task UpdateMaterialAsync(Material material)
        {
            await _materialRepository.UpdateAsync(material);
        }

        //Delete material
        public async Task DeleteMaterialAsync(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            await _materialRepository.DeleteAsync(material!);
        }

        //Similar methods for MaterialCategory
        public async Task AddMaterialCategoryAsync(MaterialCategory materialCategory)
        {
            await _materialCategoryRepository.AddAsync(materialCategory);

            await _notificationService.SendNotification(materialCategory.Name!, JsonSerializer.Serialize(materialCategory), "new-material-group");
        }

        public async Task UpdateMaterialCategoryAsync(MaterialCategory materialCategory)
        {
            await _materialCategoryRepository.UpdateAsync(materialCategory);
        }

        public async Task DeleteMaterialCategoryAsync(int id)
        {
            var materialCategory = await _materialCategoryRepository.GetByIdAsync(id);
            await _materialCategoryRepository.DeleteAsync(materialCategory!);
        }

        public async Task<MaterialCategory?> GetMaterialCategoryByNameAsync(string name)
        {
            return await _materialCategoryRepository.GetMaterialCategoryByNameAsync(name);
        }

        public IEnumerable<MaterialCategory?> GetAllMaterialCategories()
        {
            return _materialCategoryRepository.GetAll().ToList();
        }

    }
}
