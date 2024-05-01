using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Ingredient
{
    public record CreateRecipeIngredientDto
    (
      Guid IngredientId,
      double Weight
    );
}
