
namespace Core.Models.Ingredient
{
    public class BrewerIngredient : BaseEntity
    {
        public Brewer Brewer { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Weight { get; set; }

    }
}
