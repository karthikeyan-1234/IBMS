using Purchase.Domain.Contracts;
using Purchase.Domain.Models;
using Purchase.Services.DTOs;

namespace Purchase.Services
{
    public class PurchaseService : IPurchaseService
    {
        IPurchaseRepository purchaseRepository;
        IMaterialRepository materialRepository;
        IMaterialCategoryRepository materialCategoryRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository, IMaterialRepository materialRepository, IMaterialCategoryRepository materialCategoryRepository)
        {
            this.purchaseRepository = purchaseRepository;
            this.materialRepository = materialRepository;
            this.materialCategoryRepository = materialCategoryRepository;
        }

        public async Task AddPurchaseAsync(PurchaseDTO purchase)
        {
            Domain.Models.Purchase newPurchase = new Domain.Models.Purchase
            {
                PurchaseDate = purchase.PurchaseDate,
                MaterialId = purchase.MaterialId,
                Quantity = purchase.Quantity,
                Price = purchase.Price
            };
            await purchaseRepository.AddAsync(newPurchase);
        }

        public IEnumerable<PurchaseDTO> GetAllPurchases()
        {
            var purchases = purchaseRepository.GetAllPurchaseDetails();

            return purchases.Select(p => new PurchaseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                PurchaseDate = p.PurchaseDate,
                Quantity = p.Quantity,
                MaterialId = p.MaterialId
            });
        }

        //Find purchase by purchase id
        public async Task<PurchaseDTO> GetPurchaseById(int id)
        {
            var purchase = await purchaseRepository.GetByIdAsync(id);
            return new PurchaseDTO
            {
                Id = purchase!.Id,
                Name = purchase.Name,
                Description = purchase.Description,
                Price = purchase.Price,
                PurchaseDate = purchase.PurchaseDate,
                Quantity = purchase.Quantity,
                MaterialId = purchase.MaterialId
            };
        }

        //Delete purchase by purchase id
        public async Task DeletePurchaseAsync(int id)
        {
            //Get purchase by id
            var purchase = await purchaseRepository.GetByIdAsync(id);
            await purchaseRepository.DeleteAsync(purchase!);
        }

        //Update purchase
        public async Task UpdatePurchaseAsync(PurchaseDTO purchase)
        {
            Domain.Models.Purchase updatedPurchase = new()
            {
                Id = purchase.Id,
                Name = purchase.Name,
                Description = purchase.Description,
                Price = purchase.Price,
                PurchaseDate = purchase.PurchaseDate,
                Quantity = purchase.Quantity,
                MaterialId = purchase.MaterialId
            };
            await purchaseRepository.UpdateAsync(updatedPurchase);
        }

        public async Task<Material> AddMaterialAsync(Material material)
        {
            return await materialRepository.AddAsync(material);
        }

        public async Task<MaterialCategory> AddMaterialCategoryAsync(MaterialCategory materialCategory)
        {
            return await materialCategoryRepository.AddAsync(materialCategory);
        }
    }
}
