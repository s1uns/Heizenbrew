using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Ingredient
{
    public class RecipeIngredient : BaseEntity
    {
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public double Weight { get; set; }
    }
}
