using Material.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        //Get GetMaterialByNameAsync
        [HttpGet("{name}")]
        public async Task<ActionResult<Material.Domain.Models.Material>> GetMaterialByNameAsync(string name)
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
        public async Task<ActionResult<Material.Domain.Models.Material>> AddMaterialAsync(Material.Domain.Models.Material material)
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

    }
}
