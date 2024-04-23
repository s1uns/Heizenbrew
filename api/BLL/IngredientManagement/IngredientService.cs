using AutoMapper;
using Core;
using Core.Models.Ingredient;
using DAL;
using Infrustructure.Dto.Ingredient;
using Infrustructure.ErrorHandling.Errors.Base;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Infrustructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IngredientManagement
{
    public class IngredientService : IIngredientService
    {

        private readonly ILogger<IngredientService> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public IngredientService(ILogger<IngredientService> logger, IMapper mapper, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public async Task<Result<IngredientDto, Error>> AddIngredientAsync(CreateIngredientDto createIngredientDto)
        {
            try
            {
                var ingredient = _mapper.Map<Ingredient>(createIngredientDto);
                await _context.Ingredients.AddAsync(ingredient);
                await _context.SaveChangesAsync();
                return _mapper.Map<IngredientDto>(ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.AddIngredientAsync ERROR: {ex.Message}");
                return IngredientServiceErrors.CreateIngredientError;
            }
        }

        public async Task<Result<List<BrewerIngredientDto>, Error>> AddIngredientsToInventoryAsync(List<BuyIngredientDto> buyIngredients)
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var user = await _context.Brewers.Where(u => u.Id == userId)
                    .Include(u => u.Ingredients)
                    .ThenInclude(bI => bI.Ingredient)
                    .FirstOrDefaultAsync();

                var existingIngredientIds = await _context.Ingredients
                    .Select(ing => ing.Id)
                    .ToListAsync();

                foreach (var i in buyIngredients)
                {
                    if (existingIngredientIds.Contains(i.IngredientId))
                    {
                        if (user.Ingredients.Any(ing => ing.IngredientId == i.IngredientId))
                        {
                            var ingredient = await _context.BrewerIngredients
                                .FirstOrDefaultAsync(ing => ing.BrewerId == userId && ing.IngredientId == i.IngredientId);
                            ingredient.Weight += i.Weight;
                        }
                        else
                        {
                            user.Ingredients.Add(new BrewerIngredient { IngredientId = i.IngredientId, Weight = i.Weight });
                        }
                    }
                    else
                    {
                        _logger.LogError($"BLL.AddIngredientsToInventoryAsync ERROR: the ingredient is not found");
                        return IngredientServiceErrors.GetIngredientByIdError;
                    }
                }

                await _context.SaveChangesAsync();
                return _mapper.Map<List<BrewerIngredientDto>>(user.Ingredients.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.AddIngredientsToInventoryAsync ERROR: {ex.Message}");
                return IngredientServiceErrors.BuyIngredientError;
            }
        }

        public async Task<Result<bool, Error>> DeleteIngredientAsync(Guid ingredientId)
        {
            try
            {
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(bE => bE.Id == ingredientId);

                if (ingredient is null)
                {
                    return IngredientServiceErrors.GetIngredientByIdError;
                }

                _context.Ingredients.Remove(ingredient);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.DeleteIngredientAsync ERROR: {ex.Message}");
                return IngredientServiceErrors.DeleteIngredientError;
            }
        }

        public async Task<Result<List<IngredientDto>, Error>> GetAllIngredientsAsync()
        {
            try
            {
                return _mapper.Map<List<IngredientDto>>(await _context.Ingredients.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetAllIngredientsAsync ERROR: {ex.Message}");
                return IngredientServiceErrors.GetIngredientsListError;
            }
        }

        public async Task<Result<List<BrewerIngredientDto>, Error>> GetBrewerIngredientsAsync()
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var user = await _context.Brewers.Where(u => u.Id == userId)
                    .Include(u => u.Ingredients)
                    .ThenInclude(bI => bI.Ingredient)
                    .FirstOrDefaultAsync();

                return _mapper.Map<List<BrewerIngredientDto>>(user.Ingredients);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetBrewerIngredients ERROR: {ex.Message}");
                return IngredientServiceErrors.GetIngredientsListError;
            }
        }

        public async Task<Result<IngredientDto, Error>> UpdateIngredientAsync(UpdateIngredientDto updateIngredientDto)
        {
            try
            {
                var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == updateIngredientDto.Id);

                if (ingredient is null)
                {
                    return IngredientServiceErrors.GetIngredientByIdError;
                }

                _mapper.Map(updateIngredientDto, ingredient);
                _context.Ingredients.Update(ingredient);
                await _context.SaveChangesAsync();

                return _mapper.Map<IngredientDto>(ingredient);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.UpdateIngredientAsync ERROR: {ex.Message}");
                return IngredientServiceErrors.UpdateIngredientError;
            }
        }

    }
}
