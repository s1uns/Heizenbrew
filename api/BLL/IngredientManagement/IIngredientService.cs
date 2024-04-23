using Core;
using Infrustructure.Dto.Ingredient;
using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IngredientManagement
{
    public interface IIngredientService
    {
        // Ingredient Management
        public Task<Result<IngredientDto, Error>> AddIngredientAsync(CreateIngredientDto createIngredientDto); 
        public Task<Result<IngredientDto, Error>> UpdateIngredientAsync(UpdateIngredientDto updateIngredientDto); 
        public Task<Result<bool, Error>> DeleteIngredientAsync(Guid ingredientId); 
        public Task<Result<List<IngredientDto>, Error>> GetAllIngredientsAsync();

        // Brewer's Ingredient Management
        public Task<Result<List<BrewerIngredientDto>, Error>> AddIngredientsToInventoryAsync(List<BuyIngredientDto> buyIngredients);
        public Task<Result<List<BrewerIngredientDto>, Error>> GetBrewerIngredientsAsync();

    }
}
