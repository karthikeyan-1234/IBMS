using InventoryProject.Domain.Models;
using InventoryProject.Services.Contracts;
using InventoryProject.Services.DTOs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        IInventoryService InventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            InventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterialsCurrentInventory()
        {
            var result = await InventoryService.GetAllMaterialsCurrentInventory();
            return Ok(result);
        }

        [HttpGet("{materialId}")]
        public async Task<IActionResult> GetMaterialCurrentInventory(int materialId)
        {
            var result = await InventoryService.GetMaterialCurrentInventory(materialId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddInventoryItem(NewInventory item)
        {
            var result = await InventoryService.AddInventoryItem(item);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInventoryItem(Inventory item)
        {
            var result = await InventoryService.UpdateInventoryItem(item);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            await InventoryService.DeleteInventoryItem(id);
            return Ok();
        }
    }
}
