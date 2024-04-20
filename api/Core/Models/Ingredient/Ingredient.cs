using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Ingredient
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
