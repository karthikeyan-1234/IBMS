using MaterialMaster.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MaterialMaster.Domain.Models;

namespace MaterialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        IMaterialMasterService _materialService;

        public MaterialController(IMaterialMasterService materialService)
        {
            _materialService = materialService;
        }

        //Get GetMaterialByNameAsync
        [HttpGet("{name}")]
        public async Task<ActionResult<Material>> GetMaterialByNameAsync(string name)
        {
            var material = await _materialService.GetMaterialByNameAsync(name);
            if (material == null)
            {
                return NotFound();
            }
            return material;
        }

        //Add new material
        [HttpPost("AddMaterialAsync")]
        public async Task<ActionResult<Material>> AddMaterialAsync(Material material)
        {
            await _materialService.AddMaterialAsync(material);
            return Ok();
        }

        //Get all material info
        [HttpGet("GetAllMaterialInfo")]
        public IEnumerable<dynamic> GetAllMaterialInfo()
        {
            return _materialService.GetAllMaterialInfo();
        }

        //Update material
        [HttpPut("UpdateMaterialAsync")]
        public async Task<ActionResult<Material>> UpdateMaterialAsync(Material material)
        {
            await _materialService.UpdateMaterialAsync(material);
            return Ok();
        }

        //Delete material
        [HttpDelete("DeleteMaterialAsync/{id}")]
        public async Task<ActionResult<Material>> DeleteMaterialAsync(int id)
        {
            await _materialService.DeleteMaterialAsync(id);
            return Ok();
        }

        //Add new material category
        [HttpPost("AddMaterialCategoryAsync")]
        public async Task<ActionResult<MaterialCategory>> AddMaterialCategoryAsync(MaterialCategory materialCategory)
        {
            await _materialService.AddMaterialCategoryAsync(materialCategory);
            return Ok();
        }

        //Get all material categories
        [HttpGet("GetAllMaterialCategories")]
        public IEnumerable<MaterialCategory?> GetAllMaterialCategories()
        {
            return _materialService.GetAllMaterialCategories();
        }

        //Update material category
        [HttpPut("UpdateMaterialCategoryAsync")]
        public async Task<ActionResult<MaterialCategory>> UpdateMaterialCategoryAsync(MaterialCategory materialCategory)
        {
            await _materialService.UpdateMaterialCategoryAsync(materialCategory);
            return Ok();
        }

        //Delete material category
        [HttpDelete("DeleteMaterialCategoryAsync/{id}")]
        public async Task<ActionResult<MaterialCategory>> DeleteMaterialCategoryAsync(int id)
        {
            await _materialService.DeleteMaterialCategoryAsync(id);
            return Ok();
        }

        //Get GetMaterialCategoryByNameAsync
        [HttpGet("GetMaterialCategoryByNameAsync/{name}")]
        public async Task<ActionResult<MaterialCategory>> GetMaterialCategoryByNameAsync(string name)
        {
            var materialCategory = await _materialService.GetMaterialCategoryByNameAsync(name);
            if (materialCategory == null)
            {
                return NotFound();
            }
            return materialCategory;
        }

    }
}
