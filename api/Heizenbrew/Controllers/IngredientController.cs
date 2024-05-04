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


        /// <summary>
        /// Creates new ingredient.
        /// </summary>
        /// <param name="createIngredientDto">The dto to create the ingredient.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [Authorize(Roles = nameof(Roles.Administrator))]
        [HttpPost("create")]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientDto createIngredientDto)
        {
            var result = await _ingredientService.AddIngredientAsync(createIngredientDto);
            return this.CreateResponse(result);
        }

        /// <summary>
        /// Updates an existing ingredient.
        /// </summary>
        /// <param name="updateIngredientDto">The dto to update an existing ingredient.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [Authorize(Roles = nameof(Roles.Administrator))]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateIngredient([FromBody] UpdateIngredientDto updateIngredientDto)
        {
            var result = await _ingredientService.UpdateIngredientAsync(updateIngredientDto);
            return this.CreateResponse(result);
        }


        /// <summary>
        /// Deletes an existing ingredient.
        /// </summary>
        /// <param name="id">The id of the ingredient which should be deleted.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [Authorize(Roles = nameof(Roles.Administrator))]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            var result = await _ingredientService.DeleteIngredientAsync(id);
            return this.CreateResponse(result);
        }

        /// <summary>
        /// Gets list of brewering ingredients.
        /// </summary>
        /// <remarks>
        /// If the operation is successful, it will return a List<IngredientDto>.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllIngredient()
        {
            var result = await _ingredientService.GetAllIngredientsAsync();
            return this.CreateResponse(result);
        }

        /// <summary>
        /// Gets list of brewer's ingredients.
        /// </summary>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [Authorize]
        [HttpGet("my-ingredients")]
        public async Task<IActionResult> GetBrewerIngredients()
        {
            var result = await _ingredientService.GetBrewerIngredientsAsync();
            return this.CreateResponse(result);
        }

        /// <summary>
        /// Adds brewering ingredient to the brewer's inventory.
        /// </summary>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [Authorize(Roles = nameof(Roles.Brewer))]
        [HttpPost("my-ingredient/buy")]
        public async Task<IActionResult> BuyIngredient([FromBody] List<BuyIngredientDto> ingredients)
        {
            var result = await _ingredientService.AddIngredientsToInventoryAsync(ingredients);
            return this.CreateResponse(result);
        }
    }
}
