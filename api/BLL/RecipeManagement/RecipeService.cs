using AutoMapper;
using Core;
using Core.Models;
using DAL;
using Infrustructure.Dto.Recipe;
using Infrustructure.Dto.UserProfile;
using Infrustructure.ErrorHandling.Errors.Base;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Infrustructure.ErrorHandling.Exceptions.Services.Recipe;
using Infrustructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace BLL.RecipeManagement
{
    public class RecipeService : IRecipeService
    {
        private readonly ILogger<RecipeService> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;


        public RecipeService(ILogger<RecipeService> logger, IMapper mapper, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }


        public async Task<Result<string, Error>> CreateRecipeAsync(CreateRecipeDto createRecipeDto)
        {
            try
            {
                var isIdValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (isIdValid is false)
                {
                    return UserErrors.InvalidUserId;
                }

                var brewer = await _context
                    .Brewers
                    .FirstOrDefaultAsync(x => x.Id == userId);

                if (brewer is null)
                {
                    return ProfileServiceErrors.UserNotFoundError;
                }

                var recipe = _mapper.Map<Recipe>(createRecipeDto);

                await createRecipeDto.Ingredients.ForEachAsync(async iI =>
                {
                    var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == iI.IngredientId);

                    if (ingredient is null)
                    {
                        throw new WrongIngredientException("Wrong ingredient info!");
                    }

                    await _context.RecipeIngredients.AddAsync(new Core.Models.Ingredient.RecipeIngredient
                    {
                        IngredientId = ingredient.Id,
                        RecipeId = userId,
                        Recipe = recipe,
                        Weight = iI.Weight
                    });
                });



                return $"Successfully created the \"{recipe.Title}\" recipe!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.CreateRecipeAsync ERROR: {ex.Message}");

                return RecipeServiceErrors.CreateRecipeError;
            }
        }

        public async Task<Result<string, Error>> DeleteRecipeAsync(Guid recipeId)
        {
            try
            {
                var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == recipeId);

                if (recipe is null)
                {
                    return RecipeServiceErrors.GetRecipeByIdError;
                }

                _context.Recipes.Remove(recipe);
                return "Successfully deleted the recipe!";
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.DeleteRecipeAsync ERROR: {ex.Message}");

                return RecipeServiceErrors.DeleteRecipeError;
            }
        }

        public async Task<Result<string, Error>> UpdateRecipeAsync(UpdateRecipeDto updateRecipeDto)
        {
            try
            {
                var isIdValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (isIdValid is false)
                {
                    return UserErrors.InvalidUserId;
                }

                var brewer = await _context
                    .Brewers
                    .FirstOrDefaultAsync(x => x.Id == userId);

                if (brewer is null)
                {
                    return ProfileServiceErrors.UserNotFoundError;
                }

                var userHasRoles = _contextAccessor.TryGetUserRole(out string userRole);

                if (!userHasRoles)
                {
                    return UserErrors.InvalidUserId;
                }


                var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == updateRecipeDto.Id);

                if (recipe is null)
                {
                    return RecipeServiceErrors.GetRecipeByIdError;
                }

                if (recipe.BrewerId != userId && userRole != "Administrator")
                {
                    return RecipeServiceErrors.NotYourRecipeError;
                }

                recipe = _mapper.Map<Recipe>(updateRecipeDto);

                recipe.Ingredients.Clear();

                await updateRecipeDto.Ingredients.ForEachAsync(async iI =>
                {
                    var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == iI.IngredientId);

                    if (ingredient is null)
                    {
                        throw new WrongIngredientException("Wrong ingredient info!");
                    }

                    await _context.RecipeIngredients.AddAsync(new Core.Models.Ingredient.RecipeIngredient
                    {
                        IngredientId = ingredient.Id,
                        RecipeId = userId,
                        Recipe = recipe,
                        Weight = iI.Weight
                    });
                });

                return $"Successfully updated the \"{recipe.Title}\" recipe!";


            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.UpdateRecipeAsync ERROR: {ex.Message}");

                return RecipeServiceErrors.UpdateRecipeError;
            }
        }

        public Task<Result<string, Error>> VoteRecipeAsync(Guid recipeId, string voteStatus)
        {
            throw new NotImplementedException();
        }
    }
}
