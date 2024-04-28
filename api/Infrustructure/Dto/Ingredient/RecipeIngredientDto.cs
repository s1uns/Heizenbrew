using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Ingredient
{
    public record RecipeIngredientDto
    (
      Guid Id,
      string Name,
      double Weight
    );
}
