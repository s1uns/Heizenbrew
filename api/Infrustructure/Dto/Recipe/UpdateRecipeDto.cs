using Infrustructure.Dto.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Recipe
{
    public record UpdateRecipeDto
    (
        Guid Id,
        string Title,
        string Description,
        IList<RecipeIngredientDto> Ingredients
    );
}
