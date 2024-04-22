using BLL.EquipmentManagement;
using Core;
using Infrustructure.Dto.Account;
using Infrustructure.Dto.EquipmentDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace heisenbrew_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBrewingEquipment([FromBody] CreateBrewingEquipmentDto request)
        {
            var result = await _equipmentService.AddEquipmentAsync(request);
            return this.CreateResponse(result);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBrewingEquipment([FromBody] UpdateBrewingEquipmentDto request)
        {
            var result = await _equipmentService.UpdateEquipmentAsync(request);
            return this.CreateResponse(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBrewingEquipment(Guid id)
        {
            var result = await _equipmentService.DeleteEquipmentAsync(id);
            return this.CreateResponse(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEquipment()
        {
            var result = await _equipmentService.GetAllEquipmentAsync();
            return this.CreateResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipmentById(Guid id)
        {
            var result = await _equipmentService.GetBrewingEquipmentAsync(id);
            return this.CreateResponse(result);
        }

        [Authorize(Roles = nameof(Roles.Brewer))]
        [HttpGet("my-equipment")]
        public async Task<IActionResult> GetBrewerEquipment()
        {
            var result = await _equipmentService.GetBrewerEquipmentAsync();
            return this.CreateResponse(result);
        }

        [Authorize(Roles = nameof(Roles.Brewer))]
        [HttpGet("my-equipment/{id}")]
        public async Task<IActionResult> GetBrewerEquipmentById(Guid id)
        {
            var result = await _equipmentService.GetBrewerEquipmentByIdAsync(id);
            return this.CreateResponse(result);
        }

        [Authorize(Roles = nameof(Roles.Brewer))]
        [HttpGet("my-equipment/buy/{id}")]
        public async Task<IActionResult> BuyEquipment(Guid id)
        {
            var result = await _equipmentService.BuyBrewingEquipmentAsync(id);
            return this.CreateResponse(result);
        }

        [Authorize(Roles = nameof(Roles.Brewer))]
        [HttpGet("my-equipment/update-string/{id}/{connectionString}")]
        public async Task<IActionResult> UpdateConnectionString(Guid id, string connectionString)
        {
            var result = await _equipmentService.UpdateConnectionStringAsync(id, connectionString);
            return this.CreateResponse(result);
        }

    }
}
