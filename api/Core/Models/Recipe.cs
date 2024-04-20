using Core.Models.Ingredient;

namespace Core.Models
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
