
namespace Core.Models.Ingredient
{
    public class BrewerIngredient : BaseEntity
    {
        public Guid BrewerId { get; set; }
        public Brewer Brewer { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Weight { get; set; }

    }
}
