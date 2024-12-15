using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Purchase.Services;
using Purchase.Services.DTOs;

namespace PurchaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        IPurchaseService purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
        }

        [HttpPost("AddPurchase")]
        public async Task<IActionResult> AddPurchase([FromBody] PurchaseRequestDTO request)
        {
            await purchaseService.AddPurchaseAsync(request);
            return Ok();
        }

        [HttpGet("GetAllPurchases")]
        public IActionResult GetAllPurchases()
        {
            var purchases = purchaseService.GetAllPurchases();
            return Ok(purchases);
        }

        [HttpGet("GetPurchaseById/{id}")]
        public async Task<IActionResult> GetPurchaseById(int id)
        {
            var purchase = await purchaseService.GetPurchaseById(id);
            return Ok(purchase);
        }

        [HttpPut("UpdatePurchase")]
        public async Task<IActionResult> UpdatePurchase([FromBody] PurchaseDTO purchase)
        {
            await purchaseService.UpdatePurchaseAsync(purchase);
            return Ok();
        }

        [HttpDelete("DeletePurchase/{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            await purchaseService.DeletePurchaseAsync(id);
            return Ok();
        }
    }
}
