using BLL.BrewingManagement;
using BLL.IdentityManagement;
using BLL.IdentityManagement.Interfaces;
using Infrustructure.Dto.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace heisenbrew_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrewingController : ControllerBase
    {
        private readonly IBrewingService _brewingService;

        public BrewingController(IBrewingService brewingService)
        {
            _brewingService = brewingService;

        }

        [Authorize]
        [HttpGet("abort/{equipmentId}")]
        public async Task<IActionResult> AbortBrewing(Guid equipmentId)
        {
            var result = await _brewingService.AbortBrewingAsync(equipmentId);
            return this.CreateResponse(result);
        }

        [Authorize]
        [HttpGet("brewings/{equipmentId}")]
        public async Task<IActionResult> StartBrewing(Guid equipmentId)
        {
            var result = await _brewingService.GetBrewingsAsync(equipmentId);
            return this.CreateResponse(result);
        }

        [Authorize]
        [HttpGet("get-status/{equipmentId}")]
        public async Task<IActionResult> GetBrewingStatus(Guid equipmentId)
        {
            var result = await _brewingService.GetBrewingStatusAsync(equipmentId);
            return this.CreateResponse(result);
        }

        [Authorize]
        [HttpGet("start")]
        public async Task<IActionResult> StartBrewing([FromQuery] Guid recipeId, Guid equipmentId)
        {
            var result = await _brewingService.StartBrewingAsync(recipeId, equipmentId);
            return this.CreateResponse(result);
        }
    }
}
