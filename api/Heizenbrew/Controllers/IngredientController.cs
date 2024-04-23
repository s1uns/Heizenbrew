using BLL.IngredientManagement;
using Core;
using Infrustructure.Dto.Ingredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace heisenbrew_api.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [Authorize(Roles = nameof(Roles.Administrator))]
        [HttpPost("create")]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientDto request)
        {
            var result = await _ingredientService.AddIngredientAsync(request);
            return this.CreateResponse(result);
        }

        [Authorize(Roles = nameof(Roles.Administrator))]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateIngredient([FromBody] UpdateIngredientDto request)
        {
            var result = await _ingredientService.UpdateIngredientAsync(request);
            return this.CreateResponse(result);
        }

        [Authorize(Roles = nameof(Roles.Administrator))]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            var result = await _ingredientService.DeleteIngredientAsync(id);
            return this.CreateResponse(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIngredient()
        {
            var result = await _ingredientService.GetAllIngredientsAsync();
            return this.CreateResponse(result);
        }


        [Authorize(Roles = nameof(Roles.Brewer))]
        [HttpGet("my-ingredients")]
        public async Task<IActionResult> GetBrewerIngredient()
        {
            var result = await _ingredientService.GetBrewerIngredientsAsync();
            return this.CreateResponse(result);
        }


        [Authorize(Roles = nameof(Roles.Brewer))]
        [HttpPost("my-ingredient/buy")]
        public async Task<IActionResult> BuyIngredient([FromBody] List<BuyIngredientDto> ingredients)
        {
            var result = await _ingredientService.AddIngredientsToInventoryAsync(ingredients);
            return this.CreateResponse(result);
        }
    }
}
