using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Ingredient
{
    public record IngredientDto
    (
        Guid Id,
        string Name,
        decimal Price,
        string ImgUrl
    );
}
