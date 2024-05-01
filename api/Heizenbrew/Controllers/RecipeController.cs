using BLL.IdentityManagement.Interfaces;
using BLL.RecipeManagement;
using Infrustructure.Dto.Recipe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace heisenbrew_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        /// <summary>
        /// Returns the list of all recipes.
        /// </summary>
        /// <param name="page">The current page of the recipes list.</param>
        /// <remarks>
        /// If the operation is successful, it will return a RecipesListDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRecipes([FromQuery] int page = 0)
        {
            var result = await _recipeService.GetAllRecipesAsync(page);

            return this.CreateResponse(result);
        }


        /// <summary>
        /// Returns the list of user's recipes.
        /// </summary>
        /// <param name="page">The current page of the recipes list.</param>
        /// <remarks>
        /// If the operation is successful, it will return a RecipesListDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("my-recipes")]
        [Authorize]
        public async Task<IActionResult> GetMyRecipes([FromQuery] int page = 0)
        {
            var result = await _recipeService.GetOwnRecipesAsync(page);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Returns the recipeby its id.
        /// </summary>
        /// <param name="id">The id of the recipe.</param>
        /// <remarks>
        /// If the operation is successful, it will return a RecipeDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            var result = await _recipeService.GetRecipeByIdAsync(id);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Creates a new recipe.
        /// </summary>
        /// <param name="createRecipeDto">The dto to create a recipe.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeDto createRecipeDto)
        {
            var result = await _recipeService.CreateRecipeAsync(createRecipeDto);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Updated an existing recipe.
        /// </summary>
        /// <param name="updateRecipeDto">The dto to update a recipe.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateRecipe([FromBody] UpdateRecipeDto updateRecipeDto)
        {
            var result = await _recipeService.UpdateRecipeAsync(updateRecipeDto);

            return this.CreateResponse(result);
        }


        /// <summary>
        /// Deletes an existing recipe.
        /// </summary>
        /// <param name="id">The id of the recipe which should be deleted.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            var result = await _recipeService.DeleteRecipeAsync(id);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Votes an existing recipe.
        /// </summary>
        /// <param name="recipeId">The id of the recipe which should be voted.</param>
        /// <param name="voteStatus">The info about given vote.</param>
        /// <remarks>
        /// If the operation is successful, it will return a corresponding message.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("vote")]
        [Authorize]
        public async Task<IActionResult> VoteRecipe([FromQuery] Guid recipeId, string voteStatus)
        {
            var result = await _recipeService.VoteRecipeAsync(recipeId, voteStatus);

            return this.CreateResponse(result);
        }
    }
}
