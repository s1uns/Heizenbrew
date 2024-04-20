using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Ingredient
{
    public class RecipeIngredient : BaseEntity
    {
        public Ingredient Ingredient { get; set; }
        public double Weight { get; set; }
    }
}
