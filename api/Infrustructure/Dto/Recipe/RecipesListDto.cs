using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Recipe
{
    public record RecipesListDto
    (
        IList<RecipeDto> Recipes,
        int TotalPages
    );
}
